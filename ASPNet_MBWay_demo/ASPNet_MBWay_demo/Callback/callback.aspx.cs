using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ASPNet_MBWay_demo.Callback
{
    /// <summary>
    /// Page to be called by MBWay system to notify about updates
    /// </summary>
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.HttpMethod != "POST")
                return;


            MBWayStatus status;

            try
            {
               status = ReadStatusUpdate();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            try
            {
                DoSomethingWithStatus(status);
            }
            catch (Exception exception)
            {
                // if we can't do something with status, then return an HTTP 500 error in order to MBWay system to try the callback again
                // if we return HTTP 200, then MBWay system considers callback as successful
                Console.WriteLine(exception);
                throw;
            }
            


        }

        private void DoSomethingWithStatus(MBWayStatus status)
        {

            switch (status.StatusCode)
            {
                case "c1":
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + "Payment accepted");
                    break;
                case "er1":
                case "er2":
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + " Payment not accepted - invalid phone number");
                    break;
                case "c5":
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + " Payment expired");
                    break;
                case "c2":
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + " Client refused payment");
                    break;
                case "ap1":
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + " Payment refunded");
                    break;
                default:
                    Response.Write($"{status.OperationId } - {status.StatusCode} - {status.StatusDescription} | " + " (other)");
                    break;
            }
        }

        private MBWayStatus ReadStatusUpdate()
        {
            var size = Request.ContentLength;
            var enc = Request.ContentEncoding;

            byte[] buf = new byte[size];
            Request.InputStream.Read(buf, 0, size);

            var json = enc.GetString(buf);

            var status = JsonConvert.DeserializeObject<MBWayStatus>(json);

            return status;
        }
    }
}