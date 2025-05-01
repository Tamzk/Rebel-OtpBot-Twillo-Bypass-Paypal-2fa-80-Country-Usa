Imports Twilio
Imports Twilio.Clients
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Public Class Form1
    ' بيانات الاعتماد الخاصة بـ Twilio
    Dim accountSid As String = "AC4692364a517ac10b9bb39e0a48ac3108"
    Dim authToken As String = "8e0ef6994e2e2b7a60b5cfec7b4ffbb0"
    Dim twilioPhoneNumber As String = "+19412567227"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' لا يتم تنفيذ أي شيء عند تحميل النموذج
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ' عند النقر فوق زر "Start Evil Calling"
        Dim toNumber As String = TextBox1.Text ' رقم الهاتف الذي سيتم الاتصال به
        Dim message As String = "This is an evil automated call from Twilio. Prepare for chaos!" ' الرسالة التي ستُقرأ للشخص الذي سيتم الاتصال به

        ' إنشاء عميل Twilio باستخدام بيانات الاعتماد
        Dim client As TwilioRestClient = New TwilioRestClient(accountSid, authToken)

        Try
            ' إنشاء مكالمة باستخدام Twilio
            Dim calll = CallResource.Create(
                to:=New PhoneNumber(toNumber),
                from:=New PhoneNumber(twilioPhoneNumber),
                twiml:=New Twilio.Types.Twiml("<Response><Say>" & message & "</Say></Response>")
            )

            'MsgBox($"Evil call initiated! Call SID: {call.Sid}")
            MsgBox($"Evil call initiated! Call SID: call.Sid")
        Catch ex As Exception
            MsgBox($"Error making evil call: {ex.Message}")
        End Try
    End Sub

End Class
