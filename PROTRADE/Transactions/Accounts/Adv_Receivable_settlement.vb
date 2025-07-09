
Imports BL

Public Class Adv_Receivable_settlement

    Public flag_adv_settlement As Boolean
    Public flag_Rec_settlement As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Adv_Receivable_settlement_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        chkdate.Checked = False
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState

        If flag_adv_settlement = True Then
            Me.Text = "Advances Settlement"
            lbl.Visible = True
            lbl.Text = "Advances Settlement"

        ElseIf flag_Rec_settlement = True Then
            Me.Text = "Receivable Settlement"
            lbl.Visible = True
            lbl.Text = "Receivable Settlement"
        End If

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        'OPEN ALL LEDGERS
        If cmbname.Text.Trim = "" Then fillname(cmbname, True, " and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)

    End Sub

    Private Sub cmdshowdtls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdtls.Click
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable

            Dim condition As String = " "

            If cmbname.Text.Trim <> "" Then
                If flag_adv_settlement = True Then
                    condition = " and payment_report4paytype.NAME = '" & cmbname.Text.Trim & "'"
                ElseIf flag_Rec_settlement = True Then
                    condition = " and receipt_report4paytype.NAME = '" & cmbname.Text.Trim & "'"
                End If
            End If

            If flag_adv_settlement = True Then
                If CHKAGAINSTBILL.CheckState = CheckState.Checked Then condition = condition & " and payment_report4paytype.PAYTYPE= 'Against Bill' " Else condition = condition & " and payment_report4paytype.PAYTYPE<> 'Against Bill' "
            ElseIf flag_Rec_settlement = True Then
                If CHKAGAINSTBILL.CheckState = CheckState.Checked Then condition = condition & " and receipt_report4paytype.PAYTYPE= 'Against Bill' " Else condition = condition & " and receipt_report4paytype.PAYTYPE<> 'Against Bill' "
            End If

            If chkdate.Checked = True Then
                If flag_adv_settlement = True Then
                    condition = condition & " and  (dbo.PAYMENT_REPORT4PAYTYPE.PAYMENTDATE BETWEEN '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' AND '" & Format(dtto.Value, "MM/dd/yyyy") & "')"
                ElseIf flag_Rec_settlement = True Then
                    condition = condition & " and  (dbo.RECEIPT_REPORT4PAYTYPE.RECEIPTDATE BETWEEN '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' AND '" & Format(dtto.Value, "MM/dd/yyyy") & "')"
                End If
            End If

            If flag_adv_settlement = True Then
                dt = objclsCMST.search("  PAYMENTDATE as Date,PAYINITIALS as [Bill No.], PAYMENTAMT as [Amount], PAYTYPE as [Pay Type], ACCNAME as [Account], PAYMENTNO as [No], REGISTERID as [Reg Id], REGNAME as [Reg Name], NAME, GROUPNAME ", "", "  dbo.payment_report4paytype  ", " and payment_report4paytype.YEARID= " & YearId & condition)
            ElseIf flag_Rec_settlement = True Then
                dt = objclsCMST.search(" RECEIPTDATE as Date, PAYINITIALS as [Bill No.], RECEIPTAMT as [Amount], PAYTYPE as [Pay Type], ACCNAME as [Account], RECEIPTNO as [No], REGISTERID as [Reg Id], REGNAME as [Reg Name], NAME, GROUPNAME ", "", "  dbo.receipt_report4paytype  ", " and receipt_report4paytype.YEARID= " & YearId & condition)
            End If

            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridADVREC.FocusedRowHandle = gridADVREC.RowCount - 1
                gridADVREC.TopRowIndex = gridADVREC.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try

            If gridADVREC.RowCount > 0 Then
                Dim DTROW As DataRow = gridADVREC.GetFocusedDataRow

                If flag_adv_settlement = True Then
                    Dim objpaymentmaster As New PaymentMaster
                    objpaymentmaster.edit = True
                    objpaymentmaster.TEMPPAYMENTNO = DTROW("No").ToString
                    objpaymentmaster.TEMPREGNAME = DTROW("Reg Name").ToString
                    objpaymentmaster.MdiParent = MDIMain
                    objpaymentmaster.Show()

                ElseIf flag_Rec_settlement = True Then
                    Dim objreceiptmaster As New Receipt
                    objreceiptmaster.edit = True
                    objreceiptmaster.TEMPRECEIPTNO = DTROW("No").ToString
                    objreceiptmaster.TEMPREGNAME = DTROW("Reg Name").ToString
                    objreceiptmaster.MdiParent = MDIMain
                    objreceiptmaster.Show()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridADVREC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridADVREC.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\On Account Rec Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "On Account Rec Details"
            gridADVREC.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "On Account Rec Details", gridADVREC.VisibleColumns.Count + gridADVREC.GroupCount)
        Catch ex As Exception
            MsgBox("On Account Rec Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class