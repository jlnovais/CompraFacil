Imports Newtonsoft.Json


''' <summary>
''' Page to be called by MBWay system to notify about updates
''' </summary>
Public Class callback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.HttpMethod <> "POST" Then Return
        Dim status As MBWayStatus

        Try
            status = ReadStatusUpdate()
        Catch exception As Exception
            Console.WriteLine(exception)
            Throw
        End Try

        Try
            DoSomethingWithStatus(status)
        Catch exception As Exception
            Console.WriteLine(exception)
            Throw
        End Try
    End Sub


    Private Sub DoSomethingWithStatus(ByVal status As MBWayStatus)
        Select Case status.StatusCode
            Case "c1"
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "Payment accepted")
            Case "er1", "er2"
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "Payment not accepted - invalid phone number")
            Case "c5"
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "Payment expired")
            Case "c2"
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "Client refused payment")
            Case "ap1"
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "Payment refunded")
            Case Else
                Response.Write($"{status.OperationId} - {status.StatusCode} - {status.StatusDescription} | " & "(other)")
        End Select
    End Sub

    Private Function ReadStatusUpdate() As MBWayStatus
        Dim size = Request.ContentLength
        Dim enc = Request.ContentEncoding
        Dim buf As Byte() = New Byte(size - 1) {}
        Request.InputStream.Read(buf, 0, size)
        Dim json = enc.GetString(buf)
        Dim status = JsonConvert.DeserializeObject(Of MBWayStatus)(json)
        Return status
    End Function

End Class