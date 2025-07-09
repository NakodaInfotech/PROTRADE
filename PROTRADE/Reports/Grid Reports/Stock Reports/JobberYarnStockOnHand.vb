
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class JobberYarnStockOnHand

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobberYarnStockOnHand_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            fillgrid(" AND ROUND(WT,2) <> 0 AND yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" NAME, YARNQUALITY, MILLNAME, DESIGNNO, COLOR, LOTNO,  SUM(ISNULL(CONES,0)) AS CONES, SUM(BAGS) AS BAGS, SUM(WT) AS WT ", "", "  JOBBERYARNSTOCK ", TEMPCONDITION & " GROUP BY NAME, YARNQUALITY, MILLNAME, DESIGNNO, COLOR, LOTNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Jobber Stock Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Jobber Stock Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Jobber Stock Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Jobber Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub


End Class