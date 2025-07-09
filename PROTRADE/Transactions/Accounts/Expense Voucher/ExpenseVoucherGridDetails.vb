
Imports BL

Public Class ExpenseVoucherGridDetails

    Public FRMSTRING As String
    Dim PURCHASEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub ExpenseVoucherGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim OBJEXP As New ClsExpenseVoucher
            OBJEXP.alParaval.Add(0)
            OBJEXP.alParaval.Add(cmbregister.Text.Trim)
            OBJEXP.alParaval.Add(CmpId)
            OBJEXP.alParaval.Add(0)
            OBJEXP.alParaval.Add(YearId)
            Dim dt As DataTable = OBJEXP.selectNONpurchase()
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
                OBJNP.EDIT = editval
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
            showform(True, gridbill.GetFocusedRowCellValue("EXPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridNP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("EXPNO"))
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