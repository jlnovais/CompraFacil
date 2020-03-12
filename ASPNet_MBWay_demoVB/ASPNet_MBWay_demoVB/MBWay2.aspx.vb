
Imports ASPNet_MBWay_demoVB.MBWayService
Imports ASPNet_MBWay_demoVB.My


''' <summary>
''' 
'''option 2:
''' 
''' Example: access web service using Web References
''' 
''' Important: update your access details in the Web.Config file
''' 
''' </summary>


Public Class MBWay2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim phone As String = inputPhone.Text
        Dim clientEmail As String= inputEmail.Text
        
        Dim amount as Decimal

        Decimal.TryParse(inputAmount.Text.Replace(".",","), amount)

        Dim service = new MBWayWebServiceV2()
        

        Dim cfMerchantId As String = MySettings.Default.Username
        Dim password As String = MySettings.Default.Password
        Dim cfEntityOrType as Integer = MySettings.Default.CfEntityOrType
        Dim cfEntityOrTypeSpecified as Boolean = True
        Dim description As String = "test..."
        Dim clientVATNumber As String = ""
        Dim clientExternalReference As String = "123"
        Dim clientName As String = ""
        Dim categoryId As Integer = 0
        Dim categoryIdSpecified As Boolean = True
        Dim callBackURL As String = "http://www.merchant.callback.url"
        Dim amountSpecified As Boolean = true
        
        
        'When the status changes the system will call back the URL defined in [callBackURL] using POST request. 
        'Inside the body of the request the system sends a JSON object containing information about the payment.
        'Example:
        '    {
        '        "OperationId":"PTPJLOSHSKGGISATB460",
        '        "Amount":1.00,
        '        "Phone":"919999999",
        '        "Description":"Supermercados/Mercearias|test...",
        '        "StatusCode":"c1",
        '        "StatusDescription":"Concluído",
        '        "StatusDescriptionDetails":"Operação registada com sucesso",
        '        "ClientExternalReference":"ext ref 123"
        '   }
                
       Dim result As ResultOperation = service.CreatePayment(cfMerchantId,
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
            callBackURL)


        formPanel.Visible = false
        resultsOKPanel.Visible = result.Success
        resultsErrorPanel.Visible = Not result.Success

        If result.Success Then
            labelReference.Text = result.MBWayPaymentOperationResult.OperationId
            labelStatus.Text = result.MBWayPaymentOperationResult.StatusCode + " / " + result.MBWayPaymentOperationResult.StatusDescription

        Else 
            labelError.Text = result.ErrorCode.ToString()
            labelErrorDescription.Text = result.ErrorDescription
            labelErrorDetails.Text = $"{result.MBWayPaymentOperationResult?.StatusCode} / {result.MBWayPaymentOperationResult?.StatusDescription} / {result.MBWayPaymentOperationResult?.StatusDescriptionDetail}"

        End If


    End Sub

End Class