using System;
using System.IO;
using System.Threading.Tasks;
using CompraFacilWS;
using Microsoft.Extensions.Configuration;

namespace CompraFacilNetCoreDemo
{
    /// <summary>
    ///
    /// CompraFacil Webservice demo
    ///
    /// José Novais (jose.novais@mind-shaker.com)
    ///
    /// Compile with VS2017 and c# 7.1
    /// 
    /// </summary>
    class Program
    {
        private static IConfiguration _config;

        static async Task Main(string[] args)
        {

            SetupConfig();

            Console.WriteLine("CompraFacilWS demo");
            Console.WriteLine();

            string address = _config["CompraFacilWS_URL"];

            CompraFacilWSSoapClient wsSoapClient = new CompraFacilWSSoapClient(CompraFacilWSSoapClient.EndpointConfiguration.CompraFacilWSSoap12, address);

            try
            {
                var request = GetRequest();

                var res = await wsSoapClient.getReferenceMBAsync(request);

                Console.WriteLine("");

                Console.WriteLine(string.IsNullOrEmpty(res.error)
                    ? $"Entity: {res.entity} {Environment.NewLine}Reference: {res.reference} {Environment.NewLine}Amount: {res.amountOut} euros"
                    : $"Error: {res.error}");

                if (res.entity == "11249")
                {
                    Console.WriteLine($"Date limit for payment: { ShowDateForPayment(GetTimeLimitDays())}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}" );
            }

 
            Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
            Console.ReadLine();

        }

        private static string ShowDateForPayment(int getTimeLimitDays)
        {
            var newDate =  DateTime.Now.AddDays(getTimeLimitDays);

            return newDate.ToString("yyyy-MM-dd");
        }

        private static void SetupConfig()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static getReferenceMBRequest GetRequest()
        {
            getReferenceMBRequest request = new getReferenceMBRequest()
            {
                username = _config["CompraFacilWS_user"],
                password = _config["CompraFacilWS_pass"],
                address = "",
                IDUserBackoffice = 0,
                NIC = "",
                additionalInfo = "",
                amount = 1,
                city = "",
                contactPhone = "96969696",
                email = "test@test.test",
                externalReference = "123",
                name = "",
                origin = "http://www.merchantSite.pt/callback",
                postCode = "",
                sendEmailBuyer = false,
                timeLimitDays = GetTimeLimitDays()
            };
            return request;
        }

        private static int GetTimeLimitDays()
        {
            var res = -1;

            try
            {
                res = Convert.ToInt32(_config["timeLimitDays"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid time limit.");
                throw;
            }

            return res;

        }
    }
}
