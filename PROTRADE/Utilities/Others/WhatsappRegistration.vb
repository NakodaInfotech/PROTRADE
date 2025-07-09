
Imports WAProAPI
Imports Newtonsoft.Json
Imports System.IO
Imports System.Web
Imports System.ServiceProcess
Imports System.Threading

Public Class WhatsappRegistration

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            Dim txnResp As TxnRespWithQRCode = Await APIMethods.GetQRCodeAsync
            TXTRESPONSE.Text = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
            If txnResp.success And IsDBNull(txnResp.QRCode) = False Then

                Dim MSTREAM As New IO.MemoryStream
                MSTREAM.Write(txnResp.QRCode, 0, Convert.ToInt32(txnResp.QRCode.Length))
                Dim bitmap1 As Bitmap = New Bitmap(MSTREAM, False)
                MSTREAM.Dispose()
                PictureBox1.Image = bitmap1
            Else
                'MessageBox.Show($"{txnResp.data.statusCode} : {txnResp.data.error} : {txnResp.data.message}")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WhatsappIntegration_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDSTATUS_Click(sender As Object, e As EventArgs) Handles CMDSTATUS.Click
        Try
            TXTRESPONSE.Text = Await CHECKMOBILECONNECTSTATUS()

            'FIRST CHECK STATUS OF MOBILE CONNECTION
            'Dim CONNECTSTATUS As String = JObject.Parse(Await CHECKMOBILECONNECTSTATUS())("success")
            'If CONNECTSTATUS = "False" Then
            '    MsgBox("Mobile Not connected, Please Check Connection", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDSENDINV_Click(sender As Object, e As EventArgs) Handles CMDSENDDOC.Click
        Try
            Dim dlgOpenDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
            dlgOpenDialog.Filter = "Attach File | *.png;*.jpg;*.pdf;*.doc;*.*"
            dlgOpenDialog.Title = "Select File"
            dlgOpenDialog.ShowDialog()
            TXTRESPONSE.Text = Await SENDWHATSAPPATTACHMENT("918850849073", dlgOpenDialog.FileName, Path.GetFileName(dlgOpenDialog.FileName))

            'OG CODE
            'Dim waMediaMsgBody As SendMediaMsgJson = New SendMediaMsgJson()
            'Dim dlgOpenDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
            'dlgOpenDialog.Filter = "Attach File | *.png;*.jpg;*.pdf;*.doc;*.*"
            'dlgOpenDialog.Title = "Select File"
            'If dlgOpenDialog.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            '    Dim Attachment As String = Convert.ToBase64String(File.ReadAllBytes(dlgOpenDialog.FileName))
            '    Dim AttachmentFileName As String = Path.GetFileName(dlgOpenDialog.FileName)
            '    waMediaMsgBody.base64data = Attachment
            '    waMediaMsgBody.mimeType = MimeMapping.GetMimeMapping(AttachmentFileName)
            '    waMediaMsgBody.caption = "APIMethod SendMediaMessage from CISPLWhatsAppAPI.dll"
            '    waMediaMsgBody.filename = AttachmentFileName
            '    Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendMediaMessageAsync(WHATSAPPNO, waMediaMsgBody)
            '    RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDDISCONNECT_Click(sender As Object, e As EventArgs) Handles CMDDISCONNECT.Click
        Try
            TXTRESPONSE.Text = ""
            Dim txnResp As TxnRespWithError = Await APIMethods.DisconnectAsync()
            TXTRESPONSE.Text = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

End Class