
Imports BL

Public Class FormFilter

    Public frmstring As String
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CFormFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLGRID()
        If frmstring = "CFORMPURCHASE" Or frmstring = "VATPURCHASE" Or frmstring = "CFORMSALE" Or frmstring = "VATSALE" Then CHKEXCEL.Visible = True
        If frmstring = "CFORMAPPLICATION" Then GPREPORTS.Visible = False
        fillname(CMBBROKER, False, " AND LEDGERS.ACC_TYPE = 'AGENT'")
    End Sub

    Private Sub CMBFORM_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFORM.Enter
        Try
            If CMBFORM.Text.Trim = "" Then FILLFORMTYPE(CMBFORM, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFORM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFORM.Validating
        Try
            If CMBFORM.Text.Trim <> "" Then FORMVALIDATE(CMBFORM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Filter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        chkdate.Checked = False
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        enterkeypress(e, Me)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub getRECDFromToDate()
        a1 = DatePart(DateInterval.Day, RECDFROM.Value)
        a2 = DatePart(DateInterval.Month, RECDFROM.Value)
        a3 = DatePart(DateInterval.Year, RECDFROM.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, RECDTO.Value)
        a12 = DatePart(DateInterval.Month, RECDTO.Value)
        a13 = DatePart(DateInterval.Year, RECDTO.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try

            If frmstring = "CFORMAPPLICATION" Then
                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("CForm Application (SOR)", System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application (SOR).xlsx", 2)
                    Dim OBJRPT1 As New clsReportDesigner("CForm Application", System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.CFORMAPPLICATION(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                        OBJRPT1.CFORMAPPLICATION1(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.CFORMAPPLICATION(AccFrom, AccTo, CmpId, YearId)
                        OBJRPT1.CFORMAPPLICATION1(AccFrom, AccTo, CmpId, YearId)
                    End If
                    Exit Sub

                Else
                    Dim OBJRPT As New clsReportDesigner("CForm Application (SOR)", System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application (SOR).xlsx", 0)
                    Dim OBJRPT1 As New clsReportDesigner("CForm Application", System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.CFORMAPPLICATION(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                        OBJRPT1.CFORMAPPLICATION1(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.CFORMAPPLICATION(AccFrom, AccTo, CmpId, YearId)
                        OBJRPT1.CFORMAPPLICATION1(AccFrom, AccTo, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application (SOR).xlsx"
                    Dim TEMPATTACHMENT1 As String = System.AppDomain.CurrentDomain.BaseDirectory & "CForm Application.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.attachment1 = TEMPATTACHMENT1
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow
                    Exit Sub

                End If
            Else

                If CMBFORM.Text.Trim = "" Then
                    MsgBox("Select Form Type", MsgBoxStyle.Critical)
                    CMBFORM.Focus()
                    Exit Sub
                End If

                If CMBFORM.Text.Trim = "E1 FORM" And RBREC.Checked = True Then
                    MsgBox("Sale Type not allowed in E1 FORM", MsgBoxStyle.Critical)
                    CMBFORM.Focus()
                    Exit Sub
                End If


                'IF E1 FORM IS NOT SELECTED THEN CALL THESE REPORTS
                Dim OBJCFORM As New FormDesign
                OBJCFORM.MdiParent = MDIMain
                OBJCFORM.STRSEARCH = " {CFORMVIEW.YEARID} = " & YearId
                OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNAME} = '" & CMBFORM.Text.Trim & "'"

                'THIS IS DONE BCOZ WE NEED ALL THE BROKERS IN THIS REPORT AS PER REQUIREMENT
                If CMBBROKER.Text.Trim <> "" Then
                    If RBLETTER.Checked = False Then
                        OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.AGENT} = '" & CMBBROKER.Text.Trim & "'"
                    Else
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" DISTINCT NAME ", "", " CFORMVIEW ", " AND AGENT = '" & CMBBROKER.Text.Trim & "' AND YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            Dim NCLAUSE As String = ""
                            For Each ROW As DataRow In DT.Rows
                                If NCLAUSE = "" Then
                                    NCLAUSE = " AND ({@NAME} = '" & ROW("NAME") & "'"
                                Else
                                    NCLAUSE = NCLAUSE & " OR {@NAME} = '" & ROW("NAME") & "'"
                                End If
                            Next
                            NCLAUSE = NCLAUSE & ")"
                            OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & NCLAUSE
                        End If
                    End If
                End If
                If RBREC.Checked = True Then OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.TYPE} = 'SALE'" Else OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.TYPE} = 'PURCHASE'"

                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJCFORM.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {@DATE} in date " & fromD & " to date " & toD & ""
                Else
                    OBJCFORM.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If


                If CHKRECDDATE.Checked = True Then
                    getRECDFromToDate()
                    OBJCFORM.PERIOD = Format(RECDFROM.Value, "dd/MM/yyyy") & " - " & Format(RECDTO.Value, "dd/MM/yyyy")
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {@RECDATE} in date " & fromD & " to date " & toD & ""
                End If


                If RBDETAILSPENDING.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} = ''"
                    OBJCFORM.FRMSTRING = "BILLPENDING"
                    OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " PENDING - BILL WISE DETAILS"

                ElseIf RBDETAILSRECEIVED.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} <> ''"
                    OBJCFORM.FRMSTRING = "BILLRECEIVED"
                    OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " RECEIVED - BILL WISE DETAILS"

                ElseIf RBPENDING.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} = ''"
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "PENDINGSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " PENDING - PARTY WISE SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "PENDINGDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " PENDING - PARTY WISE DETAILS"
                    End If

                ElseIf RBRECEIVED.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} <> ''"
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "RECDSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " RECEIVED - PARTY WISE SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "RECDDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " RECEIVED - PARTY WISE DETAILS"
                    End If
                ElseIf RBALL.Checked = True Then
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "ALLSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " ALL - SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "ALLDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " ALL - DETAILS"
                    End If
                ElseIf RBBROKERPENDING.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} = '' AND {CFORMVIEW.AGENT} <> ''"
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "BROKERPENDINGSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE PENDING - SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "BROKERPENDINGDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE PENDING - DETAILS"
                    End If
                ElseIf RBBROKERRECD.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} <> '' AND {CFORMVIEW.AGENT} <> ''"
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "BROKERRECDSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE RECEIVED - SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "BROKERRECDDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE RECEIVED - DETAILS"
                    End If
                ElseIf RBBROKERALL.Checked = True Then
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " AND {CFORMVIEW.AGENT} <> ''"
                    If CHKSUMMARY.CheckState = CheckState.Checked Then
                        OBJCFORM.FRMSTRING = "BROKERALLSUMM"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE ALL - SUMMARY"
                    Else
                        OBJCFORM.FRMSTRING = "BROKERALLDTLS"
                        OBJCFORM.REPORTTITLE = CMBFORM.Text.Trim & " BROKER WISE ALL - DETAILS"
                    End If
                ElseIf RBLETTERALL.Checked = True Then
                    If CMBFORM.Text.Trim = "" Then
                        MsgBox("Select Form Type", MsgBoxStyle.Critical)
                        CMBFORM.Focus()
                        Exit Sub
                    End If
                    OBJCFORM.FRMSTRING = "LETTER"
                    OBJCFORM.PERIOD = CMBFORM.Text.Trim & " ANNEXURE FOR - " & OBJCFORM.PERIOD
                    OBJCFORM.FORMNO = CMBFORM.Text.Trim
                ElseIf RBLETTER.Checked = True Then
                    If CMBFORM.Text.Trim = "" Then
                        MsgBox("Select Form Type", MsgBoxStyle.Critical)
                        CMBFORM.Focus()
                        Exit Sub
                    End If
                    OBJCFORM.FRMSTRING = "LETTER"
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & " and {CFORMVIEW.FORMNO} = ''"
                    OBJCFORM.PERIOD = CMBFORM.Text.Trim & " PENDING ANNEXURE FOR - " & OBJCFORM.PERIOD
                    OBJCFORM.FORMNO = CMBFORM.Text.Trim

                End If


                gridbill.ClearColumnsFilter()
                Dim NAMECLAUSE As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND ({@NAME} = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR {@NAME} = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next

                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    OBJCFORM.STRSEARCH = OBJCFORM.STRSEARCH & NAMECLAUSE
                End If
                If CHKGROUPONNEWPG.Checked = True Then OBJCFORM.NEWPAGE = CHKGROUPONNEWPG.Checked
                OBJCFORM.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPAYABLE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPAYABLE.CheckedChanged
        FILLGRID()
    End Sub

    Private Sub RBREC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBREC.CheckedChanged
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Dim WHERECLAUSE As String = ""
            If RBREC.Checked = True Then WHERECLAUSE = " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'" Else WHERECLAUSE = " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'"
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CITYMASTER.city_name, '') AS CITY  ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id AND LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_yearid = CITYMASTER.city_yearid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_cityid = CITYMASTER.city_id ", WHERECLAUSE & " AND LEDGERS.ACC_TYPE = 'ACCOUNTS' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt

            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        gridbilldetails.Visible = True
        FILLGRID()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        gridbilldetails.Visible = False
    End Sub

    Private Sub RBACCOUNT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBACCOUNT.CheckedChanged
        FILLGRID()
    End Sub

    Private Sub RBGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGROUP.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK, group_name AS NAME, group_under AS UNDER, group_secondary AS CITY ", " ", " GROUPMASTER ", " AND (GROUPMASTER.GROUP_CMPID = '" & CmpId & "') AND (GROUPMASTER.GROUP_LOCATIONID = '" & Locationid & "') AND (GROUPMASTER.GROUP_YEARID = '" & YearId & "') ORDER BY group_name")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, False, " AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, CMBCODE, e, Me, TXTADD, " AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
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