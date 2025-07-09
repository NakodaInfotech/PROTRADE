
Imports BL

Public Class UnCheckedStock
    Private Sub UnCheckedStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BARCODESTOCK.*", "", " BARCODESTOCK ", " AND BARCODESTOCK.BARCODE NOT IN (SELECT BARCODE FROM STOCKTAKING_DESC WHERE YEARID = " & YearId & ") AND BARCODESTOCK.YEARID = " & YearId)
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnCheckedStock_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\UnChecked Stock.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "UnChecked Stock"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "UnChecked Stock", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("UnChecked Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDADJUST_Click(sender As Object, e As EventArgs) Handles CMDADJUST.Click
        Try
            If UserName <> "Admin" Then MsgBox("Only Admin can Adjust Unchecked Stock", MsgBoxStyle.Critical)
            If gridbill.RowCount > 0 Then
                If MsgBox("Wish To Adjust Unchecked Stock?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
                Dim OBJRECO As New StockReco
                OBJRECO.MdiParent = MDIMain
                OBJRECO.UNCHECKEDSTOCK = True
                OBJRECO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class