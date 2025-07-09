
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class GodownwiseStock

    Public FRMSTRING, TEMPITEMNAME, TEMPDESIGNNO, TEMPCOLOR, TEMPQUALITY As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Dim ObjColorwiseStocks As New GodownwiseDetails
            ObjColorwiseStocks.MdiParent = MDIMain
            ObjColorwiseStocks.TEMPDESIGNNO = gridbill.GetFocusedRowCellValue("DESIGNNO")
            ObjColorwiseStocks.TEMPCOLOR = gridbill.GetFocusedRowCellValue("COLOR")
            ObjColorwiseStocks.TEMPGODOWN = gridbill.GetFocusedRowCellValue("GODOWN")
            ObjColorwiseStocks.TEMPITEMNAME = gridbill.GetFocusedRowCellValue("ITEMNAME")
            ObjColorwiseStocks.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then TEMPCONDITION = TEMPCONDITION & " AND ROUND(MTRS,0) > 0 "
            If TEMPDESIGNNO <> "" Then TEMPCONDITION = TEMPCONDITION & " AND DESIGNNO = '" & TEMPDESIGNNO & "'"
            If TEMPCOLOR <> "" Then TEMPCONDITION = TEMPCONDITION & " AND COLOR = '" & TEMPCOLOR & "'"
            If TEMPQUALITY <> "" Then TEMPCONDITION = TEMPCONDITION & " AND QUALITY = '" & TEMPQUALITY & "' "
            If TEMPITEMNAME <> "" Then TEMPCONDITION = TEMPCONDITION & " AND ITEMNAME ='" & TEMPITEMNAME & "' "

            Dim GROUPBY As String = " GROUP BY GODOWN "
            If TEMPQUALITY <> "" Then GROUPBY = GROUPBY & ", QUALITY "
            If TEMPDESIGNNO <> "" Then GROUPBY = GROUPBY & ", DESIGNNO "
            If TEMPCOLOR <> "" Then GROUPBY = GROUPBY & ", COLOR "
            If TEMPITEMNAME <> "" Then GROUPBY = GROUPBY & ", ITEMNAME "


            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If TEMPQUALITY = "" And TEMPDESIGNNO = "" And TEMPCOLOR = "" And TEMPITEMNAME = "" Then
                dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, QUALITY,DESIGNNO, COLOR , GODOWN, ITEMNAME ", "", "  BARCODESTOCK ", TEMPCONDITION & " GROUP BY QUALITY,DESIGNNO, COLOR , GODOWN, ITEMNAME")
            Else
                dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPQUALITY & "' AS QUALITY,'" & TEMPDESIGNNO & "' AS DESIGNNO, '" & TEMPCOLOR & "' AS COLOR , '" & TEMPITEMNAME & "' AS ITEMNAME , GODOWN ", "", "  BARCODESTOCK ", TEMPCONDITION & GROUPBY)
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        showform()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Godownwise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Godownwise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Godownwise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Godown Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GodownwiseStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then GITEMNAME.Visible = False
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid(" AND ROUND(MTRS,0) > 0 and yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class