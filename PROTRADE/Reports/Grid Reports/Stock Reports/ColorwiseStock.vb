
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class ColorwiseStock

    Public FRMSTRING, TEMPDESIGNNO, TEMPQUALITY As String
    Public WHERECLAUSE As String = ""

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
            Dim ObjGodownwiseStock As New GodownwiseStock
            ObjGodownwiseStock.MdiParent = MDIMain
            ObjGodownwiseStock.TEMPDESIGNNO = gridbill.GetFocusedRowCellValue("DESIGNNO")
            ObjGodownwiseStock.TEMPCOLOR = gridbill.GetFocusedRowCellValue("COLOR")
            ObjGodownwiseStock.TEMPQUALITY = gridbill.GetFocusedRowCellValue("QUALITY")
            ObjGodownwiseStock.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then TEMPCONDITION = TEMPCONDITION & " AND ROUND(MTRS,0) > 0 "
            If TEMPQUALITY <> "" Then TEMPCONDITION = TEMPCONDITION & " AND QUALITY='" & TEMPQUALITY & "' "
            If TEMPDESIGNNO <> "" Then TEMPCONDITION = TEMPCONDITION & " AND DESIGNNO='" & TEMPDESIGNNO & "' "

            Dim GROUPBY As String = " GROUP BY COLOR"
            If TEMPQUALITY <> "" Then GROUPBY = GROUPBY & ", QUALITY"
            If TEMPDESIGNNO <> "" Then GROUPBY = GROUPBY & ", DESIGNNO"

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If TEMPQUALITY = "" And TEMPDESIGNNO = "" Then
                If CHKNILSTOCK.CheckState = CheckState.Checked Then
                    dt = objclsCMST.search(" SUM(T.PCS) AS TOTALPCS, SUM(T.MTRS) AS TOTALMTRS, T.QUALITY, T.DESIGNNO, T.COLOR ", "", " (SELECT SUM(PCS) AS PCS, SUM(MTRS) AS MTRS, QUALITY, DESIGNNO, COLOR FROM BARCODESTOCK WHERE 1=1 " & WHERECLAUSE & TEMPCONDITION & " GROUP BY QUALITY, DESIGNNO, COLOR UNION ALL SELECT DISTINCT 0,0, QUALITY, DESIGNNO, COLOR FROM OUTBARCODESTOCK) AS T ", " GROUP BY T.QUALITY, T.DESIGNNO, T.COLOR")
                Else
                    dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, ITEMNAME, QUALITY, DESIGNNO, COLOR, MILLNAME ", "", "  BARCODESTOCK", WHERECLAUSE & TEMPCONDITION & " GROUP BY ITEMNAME, QUALITY, DESIGNNO, COLOR, MILLNAME ")
                End If
            Else
                dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPQUALITY & "' AS QUALITY,'" & TEMPDESIGNNO & "' AS DESIGNNO, COLOR", "", "  BARCODESTOCK", TEMPCONDITION & GROUPBY)
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
            PATH = Application.StartupPath & "\Shadewise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Shadewise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Shadewise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Shade Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
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