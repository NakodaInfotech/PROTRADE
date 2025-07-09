
Imports BL

Public Class ExpenseVoucherDetails

    Public FRMSTRING As String
    Dim PURCHASEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub NonPurchaseDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            'Dim dt As DataTable = objclsCMST.search("  dbo.NONPURCHASE.NP_NO AS [Sr. No], dbo.NONPURCHASE.NP_DATE AS Date, dbo.LEDGERS.ACC_cmpname AS [Party Name], dbo.NONPURCHASE.NP_REFNO AS [PartyBillNo], dbo.NONPURCHASE.NP_partybilldate AS [PartyBillDate], dbo.NONPURCHASE.NP_TOTALAMT AS [Total Amt.], dbo.NONPURCHASE.NP_REMARKS AS [Remarks]  ", "", "  dbo.NONPURCHASE INNER JOIN dbo.LEDGERS ON dbo.NONPURCHASE.NP_LEDGERID = dbo.LEDGERS.ACC_id INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID ", TEMPCONDITION)
            Dim dt As DataTable = objclsCMST.search("  NONPURCHASE.NP_NO AS [Sr. No], NONPURCHASE.NP_DATE AS Date, LEDGERS.Acc_cmpname AS [Party Name], NONPURCHASE.NP_REFNO AS PartyBillNo, NONPURCHASE.NP_PARTYBILLDATE AS PartyBillDate, NONPURCHASE.NP_TOTALAMT AS [Total Amt.], NONPURCHASE.NP_REMARKS AS Remarks, ISNULL(NONPURCHASE.NP_RCM, 0) AS RCM, ISNULL(NONPURCHASE.NP_MANUALGST, 0) AS MANUALGST, ISNULL(NONPURCHASE.NP_TOTALOTHERAMT, 0) AS TOTALOTHERAMT, ISNULL(NONPURCHASE.NP_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN,ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(NP_APPLYTCS,0) AS APPLYTCS, ISNULL(NP_TCSPER,0) AS TCSPER, ISNULL(NP_TCSAMT,0) AS TCSAMT ", "", "  NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid AND NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id ", TEMPCONDITION)

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal NPno As Integer)
        Try

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJNP As New ExpenseVoucher
                OBJNP.MdiParent = MDIMain
                OBJNP.edit = editval
                OBJNP.TEMPEXPNO = NPno
                OBJNP.TEMPREGNAME = cmbregister.Text.Trim
                OBJNP.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'EXPENSE'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then cmbregister.Text = dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURCHASEREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.NONPURCHASE.NP_cmpid=" & CmpId & " and NONPURCHASE.NP_locationid = " & Locationid & " and NONPURCHASE.NP_yearid = " & YearId & " AND NONPURCHASE.NP_registerid = " & PURCHASEREGID & " order by dbo.NONPURCHASE.NP_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJEXP As New ExpenseVoucherGridDetails
            OBJEXP.MdiParent = MDIMain
            OBJEXP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridNP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Expense Register Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Expense Register Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Expense Register Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Expense Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ExpenseVoucherDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class