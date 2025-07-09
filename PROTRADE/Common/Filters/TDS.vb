
Imports BL

Public Class TDS

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String = "TDS"

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" And FRMSTRING = "TDS" Then fillname(CMBNAME, False, " AND LEDGERS.ACC_TDSAC = 'TRUE' and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        gridbilldetails.Visible = True
    End Sub

    Private Sub RBALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBALL.CheckedChanged
        gridbilldetails.Visible = False
    End Sub

    Private Sub RBACCOUNT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBACCOUNT.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND LEDGERS.ACC_YEARID = " & YearId & " AND ISNULL(LEDGERS.ACC_TDSAC,'FALSE') = 'TRUE' ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt

            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGROUP.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK, group_name AS NAME, group_under AS UNDER ", " ", " GROUPMASTER ", " AND GROUP_YEARID = " & YearId & "ORDER BY group_name")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" And FRMSTRING = "TDS" Then fillname(CMBNAME, edit, " AND LEDGERS.ACC_TDSAC = 'TRUE' and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "TDS" Then
                fillcmb()
            Else
                CMBNAME.DropDownStyle = ComboBoxStyle.DropDownList
                CMBNAME.Items.Add("TCS (SALE)")
                RDBTDSREGISTER.Visible = False
                LBLCOMPANY.Visible = False
                CMBCOMPANYTYPE.Visible = False
                Me.Text = "TCS Filter"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RDBTDSREGISTER.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("TDS Challan (26Q Others)-Challan Details", System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Challan Details.xlsx", 2)
                    Dim OBJRPT1 As New clsReportDesigner("TDS Challan (26Q Others)-Deductee Details", System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Deductee Details.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.TDSCHALLANDETAILS(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                        OBJRPT1.TDSDEDUCTEEDETAILS(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.TDSCHALLANDETAILS(AccFrom, AccTo, CmpId, YearId)
                        OBJRPT1.TDSDEDUCTEEDETAILS(AccFrom, AccTo, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("TDS Challan (26Q Others)-Challan Details", System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Challan Details.xlsx", 0)
                    Dim OBJRPT1 As New clsReportDesigner("TDS Challan (26Q Others)-Deductee Details", System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Deductee Details.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.TDSCHALLANDETAILS(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                        OBJRPT1.TDSDEDUCTEEDETAILS(dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.TDSCHALLANDETAILS(AccFrom, AccTo, CmpId, YearId)
                        OBJRPT1.TDSDEDUCTEEDETAILS(AccFrom, AccTo, CmpId, YearId)
                    End If

                    'MAIL EXOCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Challan Details.xlsx"
                    Dim TEMPATTACHMENT1 As String = System.AppDomain.CurrentDomain.BaseDirectory & "TDS Challan (26Q Others)-Deductee Details.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.attachment1 = TEMPATTACHMENT1
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If
                
            End If


            Dim ObjTDS As New TDSDesign
            ObjTDS.MdiParent = MDIMain

            If FRMSTRING = "TDS" Then

                ObjTDS.WHERECLAUSE = " {TDSCHALLANVIEW.YEARID}=" & YearId
                If CMBCOMPANYTYPE.Text.Trim <> "" Then ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & " AND {TDSCHALLANVIEW.CMPNONCMP} = '" & CMBCOMPANYTYPE.Text.Trim & "'"
                If chkdate.Checked = True Then
                    getFromToDate()
                    ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                    ObjTDS.PERIOD = CMBCOMPANYTYPE.Text.Trim & "-" & Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
                Else
                    ObjTDS.PERIOD = CMBCOMPANYTYPE.Text.Trim & "-" & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
                If CMBNAME.Text.Trim <> "" Then ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & " AND {TDSCHALLANVIEW.TDSLEDGER} = '" & CMBNAME.Text.Trim & "'"
                gridbill.ClearColumnsFilter()
                Dim NAMECLAUSE As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND ({TDSCHALLANVIEW.TDSLEDGER} = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR {TDSCHALLANVIEW.TDSLEDGER} = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & NAMECLAUSE
                End If
                If CHKSUMMARY.CheckState = CheckState.Checked Then ObjTDS.FRMSTRING = "TDSPARTYWISESUMM" Else ObjTDS.FRMSTRING = "TDSPARTYWISE"

            Else

                ObjTDS.WHERECLAUSE = " {TCSCHALLANVIEW.YEARID}=" & YearId
                If chkdate.Checked = True Then
                    getFromToDate()
                    ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                    ObjTDS.PERIOD = CMBCOMPANYTYPE.Text.Trim & "-" & Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
                Else
                    ObjTDS.PERIOD = CMBCOMPANYTYPE.Text.Trim & "-" & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
                If CMBNAME.Text.Trim <> "" Then ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & " AND {TCSCHALLANVIEW.TCSLEDGER} = '" & CMBNAME.Text.Trim & "'"
                gridbill.ClearColumnsFilter()
                Dim NAMECLAUSE As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND ({TCSCHALLANVIEW.TCSLEDGER} = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR {TCSCHALLANVIEW.TCSLEDGER} = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    ObjTDS.WHERECLAUSE = ObjTDS.WHERECLAUSE & NAMECLAUSE
                End If
                If CHKSUMMARY.CheckState = CheckState.Checked Then ObjTDS.FRMSTRING = "TCSPARTYWISESUMM" Else ObjTDS.FRMSTRING = "TCSPARTYWISE"

            End If
            ObjTDS.NEWPAGE = CHKGROUPONNEWPG.CheckState
            If CHKADDRESS.Checked = True Then ObjTDS.ADDRESS = 1 Else ObjTDS.ADDRESS = 0
            ObjTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class