
Imports BL

Public Class DesignwiseJobberStock

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignwiseJobberStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DesignwiseJobberStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim TEMPCONDITION As String = ""
            If chkdate.CheckState = CheckState.Checked Then TEMPCONDITION = TEMPCONDITION & " AND JOBBERSTOCK.JODATE >= '" & Format(FROMDATE.Value.Date, "MM/dd/yyyy") & "' AND JOBBERSTOCK.JODATE <= '" & Format(TODATE.Value.Date, "MM/dd/yyyy") & "'"
            Dim dt As New DataTable
            If ClientName = "SVS" Then
                GCATEGORYNAME.Visible = False
                dt = objclsCMST.search(" NAME, DESIGNNO, ROUND(SUM(TOTALMTRS),2) AS TOTALMTRS ", "", "  JOBBERSTOCK ", TEMPCONDITION & " AND YEARID = " & YearId & " GROUP BY NAME, DESIGNNO order by Jobberstock.DESIGNNO ")
            Else
                dt = objclsCMST.search(" NAME, ITEMNAME AS DESIGNNO, CATEGORYNAME, ROUND(SUM(TOTALMTRS),2) AS TOTALMTRS ", "", "  JOBBERSTOCK ", TEMPCONDITION & " AND YEARID = " & YearId & " GROUP BY NAME, ITEMNAME, CATEGORYNAME HAVING ROUND(SUM(TOTALMTRS),2) > 0 order by Jobberstock.ITEMNAME ")
                GDESIGNNO.Caption = "Item Name"
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
            PATH = Application.StartupPath & "\Jobber Stock Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Jobber Stock Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Jobber Stock Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Job Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub showform()
        Try
            Dim OBJJOB As New DesignwiseJobberStockDetails
            OBJJOB.MdiParent = MDIMain
            If ClientName = "SVS" Then
                OBJJOB.STRSEARCH = " AND DESIGNNO = '" & gridbill.GetFocusedRowCellValue("DESIGNNO") & "' AND NAME = '" & gridbill.GetFocusedRowCellValue("NAME") & "'"
            Else
                OBJJOB.STRSEARCH = " AND ITEMNAME = '" & gridbill.GetFocusedRowCellValue("DESIGNNO") & "' AND NAME = '" & gridbill.GetFocusedRowCellValue("NAME") & "'"
            End If
            OBJJOB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        showform()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class