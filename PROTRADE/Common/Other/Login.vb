Imports BL

Public Class Login

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        End
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            CHECKVERSION()
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If txtusername.Text.Trim = "Admin" Then
                GoTo Line2
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT2 As DataTable = OBJCMN.Execute_Any_String(" UPDATE USERMASTER SET USER_CHK = 1", " WHERE USER_NAME='" & txtusername.Text.Trim & "' and user_cmpid='" & CmpId & "' and user_locationid='" & Locationid & "' and user_yearid='" & YearId & "'", "")
Line2:
            Dim objlogin As New clsLogin
            UserName = txtusername.Text.Trim
            Mydate = Now.Date
            Cmpdetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtusername.Text.Trim.Length = 0 Then
            EP.SetError(txtusername, "Fill User Name")
            bln = False
        End If

        If txtpassword.Text.Trim.Length = 0 Then
            EP.SetError(txtpassword, "Fill Password")
            bln = False
        End If

        Dim objcmn As New ClsCommon
        Dim dt As DataTable = objcmn.search("User_id, User_password", "", "UserMaster", " and user_namE= '" & txtusername.Text.Trim & "'")
        If dt.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt.Rows
                If txtpassword.Text.Trim <> DTROW(1).ToString Then
                    bln = False
                Else
                    Userid = DTROW(0)

                    ''*********SESSION CHECKING****************

                    If txtusername.Text.Trim = "Admin" Then
                        GoTo line1
                    End If

                    'Dim dt1 As DataTable = objcmn.search(" USER_CHK", "", " USERMASTER", " and user_namE= '" & txtusername.Text.Trim & "' and user_cmpid='" & CmpId & "' and user_locationid='" & Locationid & "' and user_yearid='" & YearId & "'")
                    'If dt1.Rows.Count > 0 Then
                    '    If dt1.Rows(0).Item("USER_CHK") = "1" Then
                    '        'Ep.SetError(txtpassword, "Please Logout from another system !")
                    '        MsgBox("Please Logout from another system", MsgBoxStyle.Critical)
                    '        bln = False
                    '        End
                    '    End If
                    'Else
                    '    'IF CLIENTNAME IS NOT PRESENT
                    '    End
                    'End If
line1:
                    bln = True
                    Exit For
                End If
            Next
        Else
            Ep.SetError(txtusername, "Invalid User")
            bln = False
        End If
        If bln = False Then Ep.SetError(txtpassword, "Incorrect Password")

        Return bln
    End Function

    Private Sub txtusername_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusername.Validated
        txtusername.Text = StrConv(txtusername.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.L Then       'for Login
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            End
        ElseIf e.KeyCode = Windows.Forms.Keys.Enter Then
            'SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub CHECKVERSION()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME, VERSION_REPORTTYPE AS REPORTTYPE, ISNULL(VERSION_ALLOWBARCODE,0)  AS ALLOWBARCODE, ISNULL(VERSION_INVOICELINEGST,0) AS INVLINEGST, ISNULL(VERSION_PURCHASELINEGST,0) AS PURLINEGST, ISNULL(VERSION_ALLOWSMS,0) AS ALLOWSMS, ISNULL(VERSION_MANUALINVNO,0) AS MANUALINVNO, ISNULL(VERSION_ITEMWISEDESIGN,0) AS ITEMWISEDESIGN, ISNULL(VERSION_GRNINCHECKING,0) AS GRNINCHECKING , ISNULL(VERSION_MANUALBILLNO,0) AS MANUALBILLNO, ISNULL(VERSION_ALLOWEWAYBILL,0) AS ALLOWEWAYBILL, ISNULL(VERSION_PRINTEWAYBILL,0) AS PRINTEWAYBILL, ISNULL(VERSION_ADDPROFITINCAPITAL,0) AS ADDPROFITINCAPITAL, ISNULL(VERSION_MANUALCNDN,0) AS MANUALCNDN, ISNULL(VERSION_MANUALGDNNO,0) AS MANUALGDNNO, ISNULL(VERSION_SALEAUTODISC,0) AS SALEAUTODISCOUNT, ISNULL(VERSION_ALLOWPACKINGSLIP,0) AS ALLOWPACKINGSLIP, ISNULL(VERSION_LOTSTATUSONMTRS,0) AS LOTSTATUSONMTRS, ISNULL(VERSION_SALEORDERONMTRS,0) AS SALEORDERONMTRS,  ISNULL(VERSION_SHOWJOBINLOTSTATUS,0) AS SHOWJOBINLOTSTATUS,  ISNULL(VERSION_GRIDLOTNO,0) AS GRIDLOTNO,  ISNULL(VERSION_ALLOWEINVOICE,0) AS ALLOWEINVOICE,  ISNULL(VERSION_TRANSPORTCOPYA4,0) AS TRANSPORTCOPYA4,  ISNULL(VERSION_CNDNA5,0) AS CNDNA5,  ISNULL(VERSION_ALLOWWHATSAPP,0) AS ALLOWWHATSAPP, ISNULL(VERSION_WHATSAPPACT,GETDATE()) AS WHATSAPPACT, ISNULL(VERSION_WHATSAPPAUTOCC,0) AS WHATSAPPAUTOCC", "", " VERSION", "")
            If DT.Rows.Count > 0 Then
                REPORTTYPE = DT.Rows(0).Item("REPORTTYPE")
                ClientName = DT.Rows(0).Item("CLIENTNAME")
                ALLOWBARCODEPRINT = Convert.ToBoolean(DT.Rows(0).Item("ALLOWBARCODE"))
                If Convert.ToBoolean(DT.Rows(0).Item("INVLINEGST")) = True Then INVOICESCREENTYPE = "LINE GST" Else INVOICESCREENTYPE = "TOTAL GST"
                If Convert.ToBoolean(DT.Rows(0).Item("PURLINEGST")) = True Then PURCHASESCREENTYPE = "LINE GST" Else PURCHASESCREENTYPE = "TOTAL GST"
                ALLOWSMS = Convert.ToBoolean(DT.Rows(0).Item("ALLOWSMS"))
                ALLOWMANUALINVNO = Convert.ToBoolean(DT.Rows(0).Item("MANUALINVNO"))
                FETCHITEMWISEDESIGN = Convert.ToBoolean(DT.Rows(0).Item("ITEMWISEDESIGN"))
                FETCHGRNINCHECKING = Convert.ToBoolean(DT.Rows(0).Item("GRNINCHECKING"))
                ALLOWMANUALBILLNO = Convert.ToBoolean(DT.Rows(0).Item("MANUALBILLNO"))
                ALLOWEWAYBILL = Convert.ToBoolean(DT.Rows(0).Item("ALLOWEWAYBILL"))
                PRINTEWAYBILL = Convert.ToBoolean(DT.Rows(0).Item("PRINTEWAYBILL"))
                ADDPROFITINCAPITAL = Convert.ToBoolean(DT.Rows(0).Item("ADDPROFITINCAPITAL"))
                ALLOWMANUALCNDN = Convert.ToBoolean(DT.Rows(0).Item("MANUALCNDN"))
                ALLOWMANUALGDNNO = Convert.ToBoolean(DT.Rows(0).Item("MANUALGDNNO"))
                SALEAUTODISCOUNT = Convert.ToBoolean(DT.Rows(0).Item("SALEAUTODISCOUNT"))
                ALLOWPACKINGSLIP = Convert.ToBoolean(DT.Rows(0).Item("ALLOWPACKINGSLIP"))
                LOTSTATUSONMTRS = Convert.ToBoolean(DT.Rows(0).Item("LOTSTATUSONMTRS"))
                SALEORDERONMTRS = Convert.ToBoolean(DT.Rows(0).Item("SALEORDERONMTRS"))
                SHOWJOBINLOTSTATUS = Convert.ToBoolean(DT.Rows(0).Item("SALEORDERONMTRS"))
                GRIDLOTNO = Convert.ToBoolean(DT.Rows(0).Item("GRIDLOTNO"))
                ALLOWEINVOICE = Convert.ToBoolean(DT.Rows(0).Item("ALLOWEINVOICE"))
                TRANSPORTCOPYA4 = Convert.ToBoolean(DT.Rows(0).Item("TRANSPORTCOPYA4"))
                CNDNA5 = Convert.ToBoolean(DT.Rows(0).Item("CNDNA5"))
                ALLOWWHATSAPP = Convert.ToBoolean(DT.Rows(0).Item("ALLOWWHATSAPP"))
                If ALLOWWHATSAPP = True Then WHATSAPPEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("WHATSAPPACT")).Date.AddYears(1) Else WHATSAPPEXPDATE = Now.Date
                WHATSAPPAUTOCC = Convert.ToBoolean(DT.Rows(0).Item("WHATSAPPAUTOCC"))


                HIDEACCOUNTSEXCEPTINVOICE = False
                HIDEACCOUNTS = False
                HIDESTOCK = False
                HIDEYARN = True
                HIDESTORES = True
                DISCONTINUECLIENT = False


                If ClientName = "MANALI" Then
                    If Now.Date > DateTime.Parse("15.05.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "REAL" Then
                    HIDECATALOG = False
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                End If

                If DT.Rows(0).Item("VERSION") <> "1.0.009" Then
                    MsgBox("Please Install New Version", MsgBoxStyle.Critical)
LINE1:
                    MsgBox(" VERSION EXPIRED PLEASE CONTACT NAKODA INFOTECH ON 02249724411", MsgBoxStyle.Critical)
                    End
                End If
            Else
                'IF CLIENTNAME IS NOT PRESENT
                End
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtusername.Text.Trim <> "" And txtpassword.Text.Trim <> "" Then Call cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            'FOR EXCEL MIS
            If TimeOfDay.Hour = 20 And TimeOfDay.Minute = 30 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME, VERSION_REPORTTYPE AS REPORTTYPE, ISNULL(VERSION_ALLOWBARCODE,0)  AS ALLOWBARCODE, ISNULL(VERSION_INVOICELINEGST,0) AS INVLINEGST, ISNULL(VERSION_PURCHASELINEGST,0) AS PURLINEGST, ISNULL(VERSION_ALLOWSMS,0) AS ALLOWSMS, ISNULL(VERSION_MANUALINVNO,0) AS MANUALINVNO, ISNULL(VERSION_ITEMWISEDESIGN,0) AS ITEMWISEDESIGN, ISNULL(VERSION_GRNINCHECKING,0) AS GRNINCHECKING , ISNULL(VERSION_MANUALBILLNO,0) AS MANUALBILLNO, ISNULL(VERSION_ALLOWEWAYBILL,0) AS ALLOWEWAYBILL, ISNULL(VERSION_PRINTEWAYBILL,0) AS PRINTEWAYBILL, ISNULL(VERSION_ADDPROFITINCAPITAL,0) AS ADDPROFITINCAPITAL, ISNULL(VERSION_MANUALCNDN,0) AS MANUALCNDN, ISNULL(VERSION_MANUALGDNNO,0) AS MANUALGDNNO, ISNULL(VERSION_SALEAUTODISC,0) AS SALEAUTODISCOUNT, ISNULL(VERSION_ALLOWPACKINGSLIP,0) AS ALLOWPACKINGSLIP, ISNULL(VERSION_LOTSTATUSONMTRS,0) AS LOTSTATUSONMTRS, ISNULL(VERSION_SALEORDERONMTRS,0) AS SALEORDERONMTRS,  ISNULL(VERSION_SHOWJOBINLOTSTATUS,0) AS SHOWJOBINLOTSTATUS,  ISNULL(VERSION_GRIDLOTNO,0) AS GRIDLOTNO", "", " VERSION", "")
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("CLIENTNAME") = "AVIS" Then

                    DT = OBJCMN.search("TOP 1 YEAR_CMPID AS CMPID, YEAR_ID AS YEARID", "", " YEARMASTER INNER JOIN CMPMASTER ON YEAR_CMPID = CMP_ID", " AND CMP_DISPLAYEDNAME = 'AVIS INDUSTRIES PVT. LTD.' ORDER BY YEAR_STARTDATE DESC")
                    If DT.Rows.Count > 0 Then
                        CmpId = DT.Rows(0).Item("CMPID")
                        YearId = DT.Rows(0).Item("YEARID")
                    End If

                    Dim OBJRPT As New clsReportDesigner("MIS Report", System.AppDomain.CurrentDomain.BaseDirectory & "MIS Report.xlsx", 0)
                    OBJRPT.MISALLDAILY_EXCEL(CmpId, YearId, Now.Date, Now.Date)
                    sendemail("rm@avisindustries.in,gm@avisindustries.in,aroraaoc@gmail.com,infoavisindustries@gmail.com", System.AppDomain.CurrentDomain.BaseDirectory & "MIS Report.xlsx", "MIS Report", "MIS REPORT AS ON " & Format(Now.Date, "dd/MM/yyyy"))
                    End
                End If
            End If


            'FOR DAILY DISPATCH
            If TimeOfDay.Hour = 22 And TimeOfDay.Minute = 30 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME, VERSION_REPORTTYPE AS REPORTTYPE, ISNULL(VERSION_ALLOWBARCODE,0)  AS ALLOWBARCODE, ISNULL(VERSION_INVOICELINEGST,0) AS INVLINEGST, ISNULL(VERSION_PURCHASELINEGST,0) AS PURLINEGST, ISNULL(VERSION_ALLOWSMS,0) AS ALLOWSMS, ISNULL(VERSION_MANUALINVNO,0) AS MANUALINVNO, ISNULL(VERSION_ITEMWISEDESIGN,0) AS ITEMWISEDESIGN, ISNULL(VERSION_GRNINCHECKING,0) AS GRNINCHECKING , ISNULL(VERSION_MANUALBILLNO,0) AS MANUALBILLNO, ISNULL(VERSION_ALLOWEWAYBILL,0) AS ALLOWEWAYBILL, ISNULL(VERSION_PRINTEWAYBILL,0) AS PRINTEWAYBILL, ISNULL(VERSION_ADDPROFITINCAPITAL,0) AS ADDPROFITINCAPITAL, ISNULL(VERSION_MANUALCNDN,0) AS MANUALCNDN, ISNULL(VERSION_MANUALGDNNO,0) AS MANUALGDNNO, ISNULL(VERSION_SALEAUTODISC,0) AS SALEAUTODISCOUNT, ISNULL(VERSION_ALLOWPACKINGSLIP,0) AS ALLOWPACKINGSLIP, ISNULL(VERSION_LOTSTATUSONMTRS,0) AS LOTSTATUSONMTRS, ISNULL(VERSION_SALEORDERONMTRS,0) AS SALEORDERONMTRS,  ISNULL(VERSION_SHOWJOBINLOTSTATUS,0) AS SHOWJOBINLOTSTATUS,  ISNULL(VERSION_GRIDLOTNO,0) AS GRIDLOTNO", "", " VERSION", "")
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("CLIENTNAME") = "AVIS" Then

                    DT = OBJCMN.search("TOP 1 YEAR_CMPID AS CMPID, YEAR_ID AS YEARID", "", " YEARMASTER INNER JOIN CMPMASTER ON YEAR_CMPID = CMP_ID", " AND CMP_DISPLAYEDNAME = 'AVIS INDUSTRIES PVT. LTD.' ORDER BY YEAR_STARTDATE DESC")
                    If DT.Rows.Count > 0 Then
                        CmpId = DT.Rows(0).Item("CMPID")
                        YearId = DT.Rows(0).Item("YEARID")
                    End If

                    Dim OBJRPT As New clsReportDesigner("Daily Dispatch Report", System.AppDomain.CurrentDomain.BaseDirectory & "Daily Dispatch Report.xlsx", 0)
                    OBJRPT.DAILYDISPATCH_EXCEL(CmpId, YearId, Now.Date, Now.Date)
                    sendemail("rm@avisindustries.in,gm@avisindustries.in,infoavisindustries@gmail.com", System.AppDomain.CurrentDomain.BaseDirectory & "Daily Dispatch Report.xlsx", "Daily Dispatch Report", "DAILY DISPATCH REPORT AS ON " & Format(Now.Date, "dd/MM/yyyy"))
                    End
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
