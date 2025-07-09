
Imports BL

Public Class StockRecoDetails

    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Public Where As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockAdjustmentDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StockAdjustmentDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'GDN'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" AND dbo.STOCKADJUSTMENT.SA_yearid=" & YearId & " order by dbo.STOCKADJUSTMENT.SA_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" STOCKADJUSTMENT.SA_no AS SRNO, STOCKADJUSTMENT.SA_date AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN,ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(STOCKADJUSTMENT.SA_TOTALPCS, 0) AS TOTALPCS, ISNULL(STOCKADJUSTMENT.SA_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(STOCKADJUSTMENT.SA_TOTALINPCS, 0) AS TOTALINPCS, ISNULL(STOCKADJUSTMENT.SA_TOTALINMTRS, 0) AS TOTALINMTRS, ISNULL(STOCKADJUSTMENT.SA_remarks, '') AS REMARKS", "", "  STOCKADJUSTMENT LEFT OUTER JOIN GODOWNMASTER ON STOCKADJUSTMENT.SA_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON STOCKADJUSTMENT.SA_TRANSID = TRANSNAME.Acc_id", Where & TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal RECONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objSTOCK As New StockReco
                objSTOCK.MdiParent = MDIMain
                objSTOCK.edit = editval
                objSTOCK.TEMPRECONO = RECONO
                objSTOCK.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLSTOCKOUT_Click(sender As Object, e As EventArgs) Handles TOOLSTOCKOUT.Click
        Try
            Dim OBJSTCK As New StockRecoOutDetails
            OBJSTCK.MdiParent = MDIMain
            OBJSTCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLSTOCKIN_Click(sender As Object, e As EventArgs) Handles TOOLSTOCKIN.Click
        Try
            Dim OBJSTOCK As New StockRecoInDetails
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Stock Adjustment Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Stock Adjustment Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Adjustment Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Stock Adjustment Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    
End Class