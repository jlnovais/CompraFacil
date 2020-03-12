using System;
using System.Web.UI;
using ASPNet_MBWay_demo.MBWayService;

namespace ASPNet_MBWay_demo
{
    /// <summary>
    /// 
    /// Option 2
    /// 
    /// Example: access web service using Web References
    ///
    /// Important: update your access details in the Web.Config file
    /// 
    /// </summary>
    public partial class MBWay2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var phone = inputPhone.Text;
            decimal.TryParse(inputAmount.Text.Replace('.',','), out var amount);
            var clientEmail = inputEmail.Text;

            MBWayWebServiceV2  service = new MBWayWebServiceV2();

            string cfMerchantId = Properties.Settings.Default.Username;
            string password = Properties.Settings.Default.Password;
            int cfEntityOrType = Properties.Settings.Default.CfEntityOrType;
            bool cfEntityOrTypeSpecified = true;
            bool amountSpecified = true;
            string description = "test...";
            string clientVATNumber = "";
            string clientExternalReference = "123";
            string clientName = "";
            int categoryId = 0;
            bool categoryIdSpecified = true;
            string callBackURL = "http://www.merchant.callback.url";

            /*
            When the status changes the system will call back the URL defined in [callBackURL] using POST request. 
            Inside the body of the request the system sends a JSON object containing information about the payment.
            Example:
             
              {
               "OperationId":"PTPJLOSHSKGGISATB460",
               "Amount":1.00,
               "Phone":"919999999",
               "Description":"Supermercados/Mercearias|test...",
               "StatusCode":"c1",
               "StatusDescription":"Concluído",
               "StatusDescriptionDetails":"Operação registada com sucesso",
               "ClientExternalReference":"ext ref 123"
               }
             */

            var result = service.CreatePayment(cfMerchantId,
                password,
                cfEntityOrType,
                cfEntityOrTypeSpecified,
                amount,
                amountSpecified,
                phone,
                description,
                clientEmail,
                clientVATNumber,
                clientExternalReference,
                clientName,
                categoryId,
                categoryIdSpecified,
                callBackURL);


            formPanel.Visible = false;
            resultsOKPanel.Visible = result.Success;
            resultsErrorPanel.Visible = !result.Success;

            if (result.Success)
            {
                labelReference.Text = result.MBWayPaymentOperationResult.OperationId;
                labelStatus.Text = result.MBWayPaymentOperationResult.StatusCode + " / " +
                                   result.MBWayPaymentOperationResult.StatusDescription;
            }
            else
            {
                labelError.Text = result.ErrorCode.ToString();
                labelErrorDescription.Text = result.ErrorDescription;
                labelErrorDetails.Text = $"{result.MBWayPaymentOperationResult?.StatusCode} / {result.MBWayPaymentOperationResult?.StatusDescription} / {result.MBWayPaymentOperationResult?.StatusDescriptionDetail}";
            }




        }
    }
}