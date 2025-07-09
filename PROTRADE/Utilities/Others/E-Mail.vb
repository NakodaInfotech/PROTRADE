
Imports BL
Imports System.Net.Mail
Imports System.IO

Public Class E_Mail

    Public attachment As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            If MsgBox("Send Mail to Selected Receipients?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim TOMAIL As String = cmbfirstadd.Text.Trim

            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If TOMAIL = "" Then TOMAIL = dtrow("EMAILID") Else TOMAIL = TOMAIL & "," & dtrow("EMAILID")
                End If
            Next


            If cmbfirstadd.Text.Trim.Length = 0 And TOMAIL = "" Then
                EP.SetError(cmbfirstadd, "Enter Email Address")
                Exit Sub
            End If

            txtmailbody.Text = "<span style=""font-family:Tahoma;font-size: 10pt;"">" & txtmailbody.Text & "</span>"
            txtmailbody.Text = txtmailbody.Text.Replace(vbNewLine, "<br/>")


            'create the mail message
            Dim mail As New MailMessage
            mail.Bcc.Add(TOMAIL)

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            'DT = OBJCMN.search("USER_PHOTO AS FOOTERIMG", "", "USERMASTER", " AND USER_NAME ='" & UserName & "' AND USER_CMPID = " & CmpId)
            'If IsDBNull(DT.Rows(0).Item("FOOTERIMG")) = False Then PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("FOOTERIMG"), Byte())))
            Dim IC As New ImageConverter
            Dim CMPLOGO() As Byte = DirectCast(IC.ConvertTo(PBIMG.Image, GetType(Byte())), Byte())


            'set the content
            mail.Subject = txtsubject.Text.Trim
            mail.Body = txtmailbody.Text.Trim
            mail.IsBodyHtml = True

            If TXTATTACHMENT1.Text.Trim <> "" Then
                Dim MAILATTACHMENT1 As New Attachment(TXTATTACHMENT1.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT1)
            End If
            If TXTATTACHMENT2.Text.Trim <> "" Then
                Dim MAILATTACHMENT2 As New Attachment(TXTATTACHMENT2.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT2)
            End If
            If TXTATTACHMENT3.Text.Trim <> "" Then
                Dim MAILATTACHMENT3 As New Attachment(TXTATTACHMENT3.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT3)
            End If
            If TXTATTACHMENT4.Text.Trim <> "" Then
                Dim MAILATTACHMENT4 As New Attachment(TXTATTACHMENT4.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT4)
            End If
            If TXTATTACHMENT5.Text.Trim <> "" Then
                Dim MAILATTACHMENT5 As New Attachment(TXTATTACHMENT5.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT5)
            End If

            Dim myMailHTMLBody = "<html><head></head><body>" & txtmailbody.Text.Trim & "<br/><img src=cid:ThePictureID></body></html>"


            'CREATE LINKED RESOURCE FOR ALT VIEW
            Using MYSTREAM As New MemoryStream(CMPLOGO)

                If CMPLOGO.Length > 0 Then
                    Dim myAltView As AlternateView = AlternateView.CreateAlternateViewFromString(myMailHTMLBody, New System.Net.Mime.ContentType("text/html"))
                    Dim myLinkedResouce = New LinkedResource(MYSTREAM, "image/jpeg")

                    'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                    myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                    'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                    myAltView.LinkedResources.Add(myLinkedResouce)
                    mail.AlternateViews.Add(myAltView)
                End If


                Dim smtp As New SmtpClient
                Dim nc As New System.Net.NetworkCredential


                'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
                DT = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")

                    smtp.Port = Val(TXTSMTPPORT.Text.Trim)
                    smtp.EnableSsl = CHKSSL.Checked

                    If DT.Rows(0).Item("EMAIL") = "" Then
                        nc.UserName = "noreply.PROTRADE@gmail.com"
                        nc.Password = "infosys123"
                        smtp.Host = "smtp.gmail.com"
                        smtp.Port = (587)
                        smtp.EnableSsl = True
                    Else
                        nc.UserName = DT.Rows(0).Item("EMAIL")
                        nc.Password = DT.Rows(0).Item("PASS")
                    End If
                Else

                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = (587)
                    smtp.EnableSsl = True

                    nc.UserName = "noreply.PROTRADE@gmail.com"
                    nc.Password = "infosys123"

                End If
                mail.From = New MailAddress(nc.UserName, CmpName)

                smtp.Credentials = nc
                smtp.Send(mail)
                mail.Dispose()

            End Using

            MsgBox("Mail sent successfully")
            CLEAR()
            cmbfirstadd.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'CHECK THIS ON SAVE CLICK
        'DONE BY GULKIT
        'COZ SOMETIME WE MIGHT JUST SELECT NAMES IN THE GRID AND WONT WRITE ANYTHING IN COMBO
        'SO WE HAVE WRITTEN CODE ON SAVE
        'If cmbfirstadd.Text.Trim.Length = 0 And CMBGUESTCATEGORY.Text.Trim = "" And CMBGROUPDEPARTURE.Text.Trim = "" Then
        '    EP.SetError(cmbfirstadd, "Enter Email Address")
        '    bln = False
        'End If

        If txtsubject.Text.Trim = "" Then
            EP.SetError(txtsubject, "Enter Subject")
            bln = False
        End If


        If txtmailbody.Text.Trim = "" Then
            EP.SetError(txtsubject, "Enter Message")
            bln = False
        End If
        Return bln
    End Function

    Private Sub SendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.M Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            If cmb.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("email_id", "", "EmailMaster", " and email_cmpid = " & CmpId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Email_id"
                    cmb.DataSource = dt
                    cmb.DisplayMember = "Email_id"
                    cmb.Text = ""
                End If
                cmb.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfirstadd.GotFocus
        Try
            fillcmb(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub cmbvalidate(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            Dim intresult As Integer
            If cmb.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("Email_id", "", "EmailMaster", " and Email_id = '" & cmb.Text.Trim & "' and Email_cmpid = " & CmpId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Email Address not present, Add New?", MsgBoxStyle.YesNo, "Office Manager")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmb.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objEmailmaster As New ClsEmailMaster
                        objEmailmaster.alParaval = alParaval
                        intresult = objEmailmaster.save()
                        'e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfirstadd.Validating
        Try
            cmbvalidate(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdbrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE1.Click
        TXTATTACHMENT1.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE2.Click
        TXTATTACHMENT2.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT2.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE3.Click
        TXTATTACHMENT3.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT3.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE4.Click
        TXTATTACHMENT4.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT4.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE5.Click
        TXTATTACHMENT5.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT5.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub E_Mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID()
        CLEAR()
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS SECONDARY, ISNULL(LEDGERS.ACC_EMAIL,'') AS EMAILID, ISNULL(CITY_NAME,'') AS CITY ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') AND ISNULL(LEDGERS.ACC_EMAIL,'') <> '' AND (LEDGERS.ACC_YEARID = " & YearId & ") ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            Dim OBJCMN As New ClsCommon

            'get CMPADDRESS
            Dim DT As DataTable = OBJCMN.search("CMP_ADD1 AS ADD1, CMP_ADD2 AS ADD2, ISNULL(CMP_WEBSITE,'') AS WEBSITE, ISNULL(CMP_EMAIL,'') AS EMAIL", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            If txtmailbody.Text.Trim <> "" Then txtmailbody.Text = txtmailbody.Text.Trim Else txtmailbody.Text = "Please find the document as an attachment." & vbCrLf & CmpName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub E_Mail_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        fillcmb(cmbfirstadd)
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class