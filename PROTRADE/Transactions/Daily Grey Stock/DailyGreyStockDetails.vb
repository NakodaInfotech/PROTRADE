
Imports BL
Imports System.Windows.Forms

Public Class DailyGreyStockDetails

    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPSTOCKNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JOBINDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal STOCKNO As Integer)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New DailyGreyStock
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPSTOCKNO = STOCKNO
                objREQ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("STNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Daily Grey Stock Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Daily Grey Stock Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Daily Grey Stock  Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("STNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOBINDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      fillgrid(" AND dbo.GSTOCK.ST_yearid=" & YearId & " order by dbo.GSTOCK.ST_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
           
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("ISNULL(GSTOCK.ST_NO, 0) AS STNO, ISNULL(GSTOCK.ST_DATE, GETDATE()) AS DATE, ISNULL(GSTOCK.ST_TOTALPROD, 0) AS PCS, ISNULL(GSTOCK.ST_TOTALCLOSING, 0) AS CLOSINGPCS", "", "  GSTOCK", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

 
End Class