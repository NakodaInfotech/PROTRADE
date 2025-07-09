
Imports BL

Public Class DesignwiseStock

    Public FRMSTRING As String
    Public WHERECLAUSE As String = ""
    Public TEMPQUALITY As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Designwise_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Designwise_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Dim ObjColorwiseStocks As New ColorwiseStock
            ObjColorwiseStocks.MdiParent = MDIMain
            ObjColorwiseStocks.TEMPQUALITY = gridbill.GetFocusedRowCellValue("QUALITY")
            ObjColorwiseStocks.TEMPDESIGNNO = gridbill.GetFocusedRowCellValue("DESIGNNO")
            ObjColorwiseStocks.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then TEMPCONDITION = TEMPCONDITION & " AND ROUND(MTRS,0) > 0 "
            If TEMPQUALITY <> "" Then TEMPCONDITION = TEMPCONDITION & " AND QUALITY='" & TEMPQUALITY & "' "

            Dim GROUPBY As String = " GROUP BY QUALITY,DESIGNNO"
            'If TEMPQUALITY <> "" Then GROUPBY = GROUPBY & ", QUALITY"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If TEMPQUALITY = "" Then
                dt = objclsCMST.search("ITEMNAME, QUALITY, DESIGNNO, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS", "", "  BARCODESTOCK", WHERECLAUSE & TEMPCONDITION & "GROUP BY ITEMNAME, QUALITY, DESIGNNO")
            Else
                dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPQUALITY & "' AS QUALITY, DESIGNNO", "", "  BARCODESTOCK", TEMPCONDITION & GROUPBY)
            End If

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Designwise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Designwise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Designwise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Design Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
End Class