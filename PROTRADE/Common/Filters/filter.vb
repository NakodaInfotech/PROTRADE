
Imports BL

Public Class filter

    Public frmstring As String
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value.Date)
        a2 = DatePart(DateInterval.Month, dtfrom.Value.Date)
        a3 = DatePart(DateInterval.Year, dtfrom.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value.Date)
        a12 = DatePart(DateInterval.Month, dtto.Value.Date)
        a13 = DatePart(DateInterval.Year, dtto.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub filter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillgrid()
        If frmstring <> "SALEDETAILS" Then
            TXTCOMM.Visible = False
            LBLCOMM.Visible = False
        End If
    End Sub

    Sub fillgrid()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As New DataTable
            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Or frmstring = "PaymentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "PAYMENTBILLWISE" Or frmstring = "PAYMENTMONTHLYADJ" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "SALEDETAILS" Or frmstring = "salesummary" Or frmstring = "ReceiptDetails" Or frmstring = "AdvancesReceiveReport" Or frmstring = "RECEIPTBILLWISE" Or frmstring = "RECEIPTMONTHLYADJ" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid", " AND GROUP_SECONDARY = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & "  order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "Contra-PartyWise" Or frmstring = "Contra-Summary" Then
                dt = objclspo.search("    acc_cmpname as [NAME],0  ", "", "  ledgers inner join GroupMaster on acc_groupid = groupmaster.group_id and acc_cmpid = groupmaster.group_cmpid AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", "  AND (GROUPMASTER.GROUP_SECONDARY = 'CASH IN HAND' OR GROUPMASTER.GROUP_SECONDARY ='BANK A/C' OR GROUPMASTER.GROUP_SECONDARY ='BANK OD A/C') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "Journal-PartyWise" Or frmstring = "Journal-Summary" Then
                dt = objclspo.search("    acc_cmpname as [NAME],0  ", "", "  ledgers inner join GroupMaster on acc_groupid = groupmaster.group_id and acc_cmpid = groupmaster.group_cmpid AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid", " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            End If
            gridledger.DataSource = dt
            gridledger.Columns.Insert(0, col)
            gridledger.Columns(0).Width = 50
            gridledger.Columns(1).Width = 240

            gridledger.Columns(2).Visible = False
            gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridacc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridledger.CellClick
        If e.RowIndex >= 0 Then
            With gridledger.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkdate.Checked = True Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
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

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        If txtName.Text.Trim <> "" Then
            Dim rowno, b As Integer
            fillgrid_search()
            rowno = 0
            For b = 1 To gridledger.RowCount
                txtTempName.Text = gridledger.Item(1, rowno).Value.ToString()
                txtTempName.SelectionStart = 0
                txtTempName.SelectionLength = txtName.TextLength
                If LCase(txtName.Text.Trim) <> LCase(txtTempName.SelectedText.Trim) Then
                    gridledger.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If
            Next
        End If
    End Sub

    Private Sub dtfrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtfrom.Validating
        If Not datecheck(dtfrom.Value.Date) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub dtto_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtto.Validating
        If Not datecheck(dtto.Value.Date) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Or frmstring = "REGISTERPURCHASESUMMARY" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            ElseIf frmstring = "SALEDETAILS" Or frmstring = "salesummary" Or frmstring = "REGISTERSALESUMMARY" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            ElseIf frmstring = "Contra-PartyWise" Or frmstring = "Contra-Summary" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CONTRA'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            ElseIf frmstring = "Journal-PartyWise" Or frmstring = "Journal-Summary" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            ElseIf frmstring = "PaymentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "PAYMENTBILLWISE" Or frmstring = "PAYMENTMONTHLYADJ" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PAYMENT'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PAYMENT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            ElseIf frmstring = "ReceiptDetails" Or frmstring = "AdvancesReceiveReport" Or frmstring = "RECEIPTBILLWISE" Or frmstring = "RECEIPTMONTHLYADJ" Then
                If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'RECEIPT'")
                dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            End If

            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid_search()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As New DataTable
            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Or frmstring = "PaymentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "PAYMENTBILLWISE" Or frmstring = "PAYMENTMONTHLYADJ" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "SALEDETAILS" Or frmstring = "salesummary" Or frmstring = "ReceiptDetails" Or frmstring = "AdvancesReceiveReport" Or frmstring = "RECEIPTBILLWISE" Or frmstring = "RECEIPTMONTHLYADJ" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'  and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "Contra-PartyWise" Or frmstring = "Contra-Summary" Then
                dt = objclspo.search("    acc_cmpname as [NAME],0  ", "", "  ledgers inner join GroupMaster on acc_groupid = groupmaster.group_id and acc_cmpid = groupmaster.group_cmpid AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid", "  AND (GROUPMASTER.GROUP_SECONDARY = 'CASH IN HAND' OR GROUPMASTER.GROUP_SECONDARY ='BANK A/C' OR GROUPMASTER.GROUP_SECONDARY ='BANK OD A/C') and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "Journal-PartyWise" Or frmstring = "Journal-Summary" Then
                dt = objclspo.search("    acc_cmpname as [NAME],0  ", "", "  ledgers inner join GroupMaster on acc_groupid = groupmaster.group_id and acc_cmpid = groupmaster.group_cmpid AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid", " and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
            End If
            If dt.Rows.Count > 0 Then
                gridledger.DataSource = dt
                'gridledger.Columns.Insert(0, col)
                gridledger.Columns(0).Width = 50
                gridledger.Columns(1).Width = 240
                gridledger.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim i As Integer


            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Then
                Dim objpur As New purchasedesign
                ' getFromToDate()
                objpur.strsearch = ""
                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objpur.strsearch = "" Then
                            objpur.strsearch = objpur.strsearch & "  {REPORT_SP_PURCHASESUMMARY.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        Else
                            objpur.strsearch = objpur.strsearch & " or {REPORT_SP_PURCHASESUMMARY.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If objpur.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                Else
                    objpur.strsearch = "(" & objpur.strsearch & ")"
                End If
                If cmbregister.Text <> "" Then
                    objpur.strsearch = objpur.strsearch & " and ({REPORT_SP_PURCHASESUMMARY.register_name}='" & cmbregister.Text & "')"
                End If
                If chkdate.Checked = True Then
                    objpur.FROMDATE = dtfrom.Value.Date
                    objpur.TODATE = dtto.Value.Date
                Else
                    objpur.FROMDATE = AccFrom.Date
                    objpur.TODATE = AccTo.Date
                End If
                If frmstring = "purchasesummary" Then
                    objpur.strsumm = "Summary"
                Else
                    objpur.strsumm = ""
                End If
                objpur.MdiParent = MDIMain
                objpur.Show()
            ElseIf frmstring = "SALEDETAILS" Or frmstring = "salesummary" Then
                Dim objpur As New saledesign
                ' getFromToDate()
                objpur.strsearch = ""

                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objpur.strsearch = "" Then
                            objpur.strsearch = objpur.strsearch & "  {REPORT_SP_INVOICESUMMARY.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        Else
                            objpur.strsearch = objpur.strsearch & " or {REPORT_SP_INVOICESUMMARY.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If objpur.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                Else
                    objpur.strsearch = "(" & objpur.strsearch & ")"
                End If
                If cmbregister.Text <> "" Then objpur.strsearch = objpur.strsearch & " and ({REPORT_SP_INVOICESUMMARY.[REGISTER NAME]}='" & cmbregister.Text & "')"
                If chkdate.Checked = True Then
                    objpur.FROMDATE = dtfrom.Value.Date
                    objpur.TODATE = dtto.Value.Date
                Else
                    objpur.FROMDATE = AccFrom.Date
                    objpur.TODATE = AccTo.Date
                End If
                If frmstring = "salesummary" Then
                    objpur.strsumm = "Summary"
                Else
                    objpur.strsumm = "SALEDETAILS"
                End If
                objpur.COMM = Val(TXTCOMM.Text.Trim)
                objpur.MdiParent = MDIMain
                objpur.Show()

            ElseIf frmstring = "PaymentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "AdvancesReceiveReport" Or frmstring = "ReceiptDetails" Then

                Dim objadv_rec_dtls As New Adv_Rec_details
                ' getFromToDate()
                objadv_rec_dtls.strsearch = ""

                If frmstring = "PaymentDetails" Then
                    objadv_rec_dtls.x = "open_PaymentDetails"
                    Dim bracket_close As Boolean

                    For i = 0 To gridledger.RowCount - 1
                        If gridledger.Item(0, i).Value = True Then
                            If objadv_rec_dtls.strsearch = "" Then
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ({payment_report.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                                bracket_close = True
                            Else
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " or {payment_report.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            End If
                        End If
                    Next

                    If bracket_close = True Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ) "
                    End If

                    If chkdate.Checked = True Then
                        getFromToDate()
                        If objadv_rec_dtls.strsearch <> "" Then
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and {@PAYMENTDATE} in date " & fromD & " to date " & toD & ""
                        Else
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & "  {@PAYMENTDATE} in date " & fromD & " to date " & toD & ""
                        End If
                    End If


                    'Passing Company ID
                    If objadv_rec_dtls.strsearch <> "" Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and {payment_report.CMPID}=" & CmpId & " AND {payment_report.LOCATIONid}=" & Locationid & " AND {payment_report.YEARID}=" & YearId
                    Else
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & "  {payment_report.CMPID}=" & CmpId & " AND {payment_report.LOCATIONid}=" & Locationid & " AND {payment_report.YEARid}=" & YearId & " "
                    End If

                ElseIf frmstring = "AdvancesPaidReport" Then
                    objadv_rec_dtls.x = "open_AdvancesPaidReport"
                    Dim bracket_close As Boolean
                    For i = 0 To gridledger.RowCount - 1
                        If gridledger.Item(0, i).Value = True Then
                            If objadv_rec_dtls.strsearch = "" Then
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ( {LEDGERS.acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                                bracket_close = True
                            Else
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " or {LEDGERS.acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            End If
                        End If
                    Next

                    If bracket_close = True Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ) "
                    End If

                    If chkdate.Checked = True Then
                        getFromToDate()
                        If objadv_rec_dtls.strsearch <> "" Then
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ({@paymentdate} in date " & fromD & " to date " & toD & ")"
                        Else
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {@paymentdate} in date " & fromD & " to date " & toD & ""
                        End If
                    End If

                    'Passing Company ID
                    If objadv_rec_dtls.strsearch <> "" Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ( {PAYMENTMASTER.Payment_cmpid}=" & CmpId & " AND {PAYMENTMASTER.Payment_LOCATIONid}=" & Locationid & " AND {PAYMENTMASTER.Payment_YEARid}=" & YearId & " )"
                    Else
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {PAYMENTMASTER.Payment_cmpid}=" & CmpId & " AND {PAYMENTMASTER.Payment_LOCATIONid}=" & Locationid & " AND {PAYMENTMASTER.Payment_YEARid}=" & YearId & ""
                    End If


                ElseIf frmstring = "AdvancesReceiveReport" Then
                    objadv_rec_dtls.x = "open_AdvancesReceiveReport"
                    Dim bracket_close As Boolean
                    For i = 0 To gridledger.RowCount - 1
                        If gridledger.Item(0, i).Value = True Then
                            If objadv_rec_dtls.strsearch = "" Then
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ({Receipt_report4paytype.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                                bracket_close = True
                            Else
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " or {Receipt_report4paytype.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            End If
                        End If
                    Next

                    If bracket_close = True Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ) "
                    End If

                    If chkdate.Checked = True Then
                        getFromToDate()
                        If objadv_rec_dtls.strsearch <> "" Then
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ({@receiptdate} in date " & fromD & " to date " & toD & ")"
                        Else
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {@receiptdate} in date " & fromD & " to date " & toD & ""
                        End If
                    End If

                    'Passing Company ID
                    If objadv_rec_dtls.strsearch <> "" Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ({Receipt_report4paytype.CMPID}=" & CmpId & " AND {Receipt_report4paytype.LOCATIONID}=" & Locationid & " AND {Receipt_report4paytype.YEARID}=" & YearId & ")"
                    Else
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {Receipt_report4paytype.CMPID}=" & CmpId & " AND {Receipt_report4paytype.LOCATIONID}=" & Locationid & " AND {Receipt_report4paytype.YEARID}=" & YearId & " "
                    End If

                ElseIf frmstring = "ReceiptDetails" Then

                    objadv_rec_dtls.x = "open_ReceiptDetails"
                    Dim bracket_close As Boolean
                    For i = 0 To gridledger.RowCount - 1
                        If gridledger.Item(0, i).Value = True Then
                            If objadv_rec_dtls.strsearch = "" Then
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ( {Receipt_report.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                                bracket_close = True
                            Else
                                objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " or {Receipt_report.NAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            End If
                        End If
                    Next
                    If bracket_close = True Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " ) "
                    End If

                    If chkdate.Checked = True Then
                        getFromToDate()
                        If objadv_rec_dtls.strsearch <> "" Then
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and {@BILLDATE} in date " & fromD & " to date " & toD & ""
                        Else
                            objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {@BILLDATE} in date " & fromD & " to date " & toD & ""
                        End If
                    End If
                    'Passing Company ID
                    If objadv_rec_dtls.strsearch <> "" Then
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ({Receipt_report.CMPID}=" & CmpId & " AND {Receipt_report.LOCATIONID}=" & Locationid & " AND {Receipt_report.YEARID}=" & YearId & ")"
                    Else
                        objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " {Receipt_report.CMPID}=" & CmpId & " AND {Receipt_report.LOCATIONID}=" & Locationid & " AND {Receipt_report.YEARID}=" & YearId & ""
                    End If

                End If

                'If objadv_rec_dtls.strsearch = "" Then
                '    MsgBox("NO NAME BEEN SELECTED")
                '    Exit Sub
                'End If
                '  objadv_rec_dtls.strsearch = objadv_rec_dtls.strsearch & " and ({payment_report.NAME}='" & cmbregister.Text & "')"


                objadv_rec_dtls.MdiParent = MDIMain
                objadv_rec_dtls.Show()

            ElseIf frmstring = "Contra-PartyWise" Then

                Dim objcontra As New Journal_Contra_Design
                objcontra.strsearch = "Open-ContraPartyReport"
                objcontra.strsearch = ""

                Dim bracket_close As Boolean
                For i = 0 To gridledger.RowCount - 1

                    If gridledger.Item(0, i).Value = True Then
                        If objcontra.strsearch = "" Then
                            objcontra.strsearch = objcontra.strsearch & " ({REPORT_SP_ACCOUNT_CONTRA;1.Party Name}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            bracket_close = True
                        Else
                            objcontra.strsearch = objcontra.strsearch & " or {REPORT_SP_ACCOUNT_CONTRA;1.Party Name}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If bracket_close = True Then
                    objcontra.strsearch = objcontra.strsearch & " ) "
                End If

                If objcontra.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                End If
                If cmbregister.Text <> "" Then
                    objcontra.strsearch = objcontra.strsearch & " and ({REPORT_SP_ACCOUNT_CONTRA;1.register_name}='" & cmbregister.Text & "')"
                End If
                If chkdate.Checked = True Then
                    objcontra.FROMDATE = dtfrom.Value.Date
                    objcontra.TODATE = dtto.Value.Date
                Else
                    objcontra.FROMDATE = AccFrom.Date
                    objcontra.TODATE = AccTo.Date
                End If

                objcontra.MdiParent = MDIMain
                objcontra.Show()


            ElseIf frmstring = "Journal-PartyWise" Then

                Dim objjournal As New Journal_Contra_Design
                objjournal.strsearch = "Open-JournalPartyReport"
                objjournal.strsearch = ""
                Dim bracket_close As Boolean

                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objjournal.strsearch = "" Then
                            objjournal.strsearch = objjournal.strsearch & " ( {Report_SP_Account_Journal_Details;1.Party Name}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            bracket_close = True
                        Else
                            objjournal.strsearch = objjournal.strsearch & " or {Report_SP_Account_Journal_Details;1.Party Name}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next

                If bracket_close = True Then
                    objjournal.strsearch = objjournal.strsearch & " ) "
                End If

                If objjournal.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                End If

                If cmbregister.Text <> "" Then
                    objjournal.strsearch = objjournal.strsearch & " and ({Report_SP_Account_Journal_Details;1.register_name}='" & cmbregister.Text & "')"
                End If
                If chkdate.Checked = True Then
                    objjournal.FROMDATE = dtfrom.Value.Date
                    objjournal.TODATE = dtto.Value.Date
                Else
                    objjournal.FROMDATE = AccFrom.Date
                    objjournal.TODATE = AccTo.Date
                End If

                objjournal.MdiParent = MDIMain
                objjournal.Show()


            ElseIf frmstring = "Journal-Summary" Or frmstring = "Contra-Summary" Then

                Dim objjournal As New summarydesign

                objjournal.strsearch = ""
                Dim bracket_close As Boolean

                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objjournal.strsearch = "" Then
                            objjournal.strsearch = objjournal.strsearch & " ( {ledgers.acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            bracket_close = True
                        Else
                            objjournal.strsearch = objjournal.strsearch & " or {ledgers.acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next

                If bracket_close = True Then
                    objjournal.strsearch = objjournal.strsearch & " ) "
                End If

                If objjournal.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                End If

                If cmbregister.Text <> "" Then
                    objjournal.strsearch = objjournal.strsearch & " and ({registermaster.register_name}='" & cmbregister.Text & "')"
                End If
                If chkdate.Checked = True Then
                    objjournal.FROMDATE = dtfrom.Value.Date
                    objjournal.TODATE = dtto.Value.Date
                Else
                    objjournal.FROMDATE = AccFrom.Date
                    objjournal.TODATE = AccTo.Date
                End If
                objjournal.MdiParent = MDIMain
                objjournal.frmstring = frmstring
                objjournal.Show()

            ElseIf frmstring = "PAYMENTBILLWISE" Then

                Dim OBJPAY As New Adv_Rec_details
                OBJPAY.x = frmstring
                OBJPAY.strsearch = ""

                Dim bracket_close As Boolean
                For i = 0 To gridledger.RowCount - 1

                    If gridledger.Item(0, i).Value = True Then
                        If OBJPAY.strsearch = "" Then
                            OBJPAY.strsearch = OBJPAY.strsearch & " ({LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            bracket_close = True
                        Else
                            OBJPAY.strsearch = OBJPAY.strsearch & " or {LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If bracket_close = True Then OBJPAY.strsearch = OBJPAY.strsearch & " ) "

                If OBJPAY.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                End If
                If cmbregister.Text <> "" Then OBJPAY.strsearch = OBJPAY.strsearch & " and ({REGISTERMASTER.register_name}='" & cmbregister.Text & "')"
                If chkdate.Checked = True Then
                    getFromToDate()
                    If OBJPAY.strsearch <> "" Then
                        OBJPAY.strsearch = OBJPAY.strsearch & " and {@PAYDATE} in date " & fromD & " to date " & toD & ""
                    Else
                        OBJPAY.strsearch = OBJPAY.strsearch & " {@PAYDATE} in date " & fromD & " to date " & toD & ""
                    End If
                End If

                OBJPAY.MdiParent = MDIMain
                OBJPAY.Show()

            ElseIf frmstring = "RECEIPTBILLWISE" Then

                Dim OBJREC As New Adv_Rec_details
                OBJREC.x = frmstring
                OBJREC.strsearch = ""

                Dim bracket_close As Boolean
                For i = 0 To gridledger.RowCount - 1

                    If gridledger.Item(0, i).Value = True Then
                        If OBJREC.strsearch = "" Then
                            OBJREC.strsearch = OBJREC.strsearch & " ({LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                            bracket_close = True
                        Else
                            OBJREC.strsearch = OBJREC.strsearch & " or {LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If bracket_close = True Then OBJREC.strsearch = OBJREC.strsearch & " ) "

                If OBJREC.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                End If
                If cmbregister.Text <> "" Then OBJREC.strsearch = OBJREC.strsearch & " and ({REGISTERMASTER.register_name}='" & cmbregister.Text & "')"
                If chkdate.Checked = True Then
                    getFromToDate()
                    If OBJREC.strsearch <> "" Then
                        OBJREC.strsearch = OBJREC.strsearch & " and {@RECDATE} in date " & fromD & " to date " & toD & ""
                    Else
                        OBJREC.strsearch = OBJREC.strsearch & " {@RECDATE} in date " & fromD & " to date " & toD & ""
                    End If
                End If

                OBJREC.MdiParent = MDIMain
                OBJREC.Show()

            ElseIf frmstring = "RECEIPTMONTHLYADJ" Or frmstring = "PAYMENTMONTHLYADJ" Then

                Dim OBJREC As New Adv_Rec_details
                OBJREC.x = frmstring
                If frmstring = "RECEIPTMONTHLYADJ" Then
                    OBJREC.strsearch = OBJREC.strsearch & " {RECEIPTMASTER.RECEIPT_YEARID} = " & YearId & " AND {RECEIPTMASTER_DESC.RECEIPT_PAYTYPE} = 'Against Bill'"
                Else
                    OBJREC.strsearch = OBJREC.strsearch & " {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId & " AND {PAYMENTMASTER_DESC.PAYMENT_PAYTYPE} = 'Against Bill'"
                End If

                Dim NAMECLAUSE As String = ""
                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " or {LEDGERS.ACC_CMPNAME}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then OBJREC.strsearch = OBJREC.strsearch & NAMECLAUSE & " ) "

                If cmbregister.Text <> "" Then OBJREC.strsearch = OBJREC.strsearch & " and ({REGISTERMASTER.register_name}='" & cmbregister.Text & "')"
                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJREC.strsearch = OBJREC.strsearch & " and {@DATE} in date " & fromD & " to date " & toD & ""
                    OBJREC.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    OBJREC.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy")
                End If

                OBJREC.MdiParent = MDIMain
                OBJREC.Show()


            ElseIf frmstring = "REGISTERPURCHASESUMMARY" Then
                Dim STRSEARCH As String = ""
                If cmbregister.Text <> "" Then STRSEARCH = STRSEARCH & " and [REGISTER NAME] ='" & cmbregister.Text & "' "
                If chkdate.Checked = True Then
                    STRSEARCH = STRSEARCH & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE<= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                Else
                    STRSEARCH = STRSEARCH & " AND DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE<= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'"
                End If
                Dim OBJRPT As New clsReportDesigner("PURCHASE SUMMARY (REGISTER WISE)", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASE_SUMMARY.xlsx", 2)
                OBJRPT.REGISTERPURCHASESUMM_EXCEL(STRSEARCH, CmpId, Locationid, YearId)

            ElseIf frmstring = "REGISTERSALESUMMARY" Then
                Dim STRSEARCH As String = ""
                If cmbregister.Text <> "" Then STRSEARCH = STRSEARCH & " and [REGISTER NAME] ='" & cmbregister.Text & "' "
                If chkdate.Checked = True Then
                    STRSEARCH = STRSEARCH & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE<= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                Else
                    STRSEARCH = STRSEARCH & " AND DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE<= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'"
                End If
                Dim OBJRPT As New clsReportDesigner("SALE SUMMARY (REGISTER WISE)", System.AppDomain.CurrentDomain.BaseDirectory & "SALE_SUMMARY.xlsx", 2)
                OBJRPT.REGISTERSALESUMM_EXCEL(STRSEARCH, CmpId, Locationid, YearId)

                End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class