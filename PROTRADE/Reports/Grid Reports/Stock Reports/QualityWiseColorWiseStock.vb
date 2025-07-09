
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class QualityWiseColorWiseStock

    Public FRMSTRING, TEMPCOLOR As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QualityWiseColorWiseStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub QualityWiseColorWiseStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" AND ROUND(MTRS,0) > 0 and yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

                        Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If CHKNILSTOCK.CheckState = CheckState.Checked Then
                dt = objclsCMST.search(" SUM(T.PCS) AS TOTALPCS, SUM(T.MTRS) AS TOTALMTRS, T.COLOR, T.QUALITY ", "", " (SELECT SUM(PCS) AS PCS, SUM(MTRS) AS MTRS, COLOR, QUALITY FROM BARCODESTOCK WHERE 1=1 " & TEMPCONDITION & " GROUP BY COLOR, QUALITY UNION ALL SELECT DISTINCT 0,0, COLOR, QUALITY FROM OUTBARCODESTOCK) AS T ", " GROUP BY T.COLOR, T.QUALITY")
            Else
                dt = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, COLOR, QUALITY ", "", "  BARCODESTOCK", TEMPCONDITION & " GROUP BY COLOR, QUALITY ")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Quality Wise Shadewise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Quality Wise Shadewise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Quality Wise Shadewise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("quality-Shade Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid(" AND ROUND(MTRS,0) > 0 and yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QualityWiseColorWiseStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            CHKNILSTOCK.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class