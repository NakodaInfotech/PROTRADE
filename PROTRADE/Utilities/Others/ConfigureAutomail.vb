
Imports BL

Public Class ConfigureAutomail

    Private Sub CHKSHOWPASS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSHOWPASS.CheckedChanged
        Try
            If CHKSHOWPASS.Checked = True Then txtsmtppass.PasswordChar = "" Else txtsmtppass.PasswordChar = "*"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class