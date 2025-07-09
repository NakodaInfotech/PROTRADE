
Imports BL

Public Class StockRecoOutDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockRecoOutDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StockRecoOutDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" STOCKADJUSTMENT.SA_no AS SANO, STOCKADJUSTMENT.SA_date AS DATE, ISNULL(STOCKADJUSTMENT_DESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_DESC.SA_PCS, 0) AS PCS, ISNULL(STOCKADJUSTMENT_DESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_DESC.SA_BARCODE, '') AS BARCODE, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", "  PIECETYPEMASTER RIGHT OUTER JOIN STOCKADJUSTMENT LEFT OUTER JOIN STOCKADJUSTMENT_DESC LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_DESC.SA_UNITID = UNITMASTER.unit_id ON STOCKADJUSTMENT.SA_no = STOCKADJUSTMENT_DESC.SA_NO AND STOCKADJUSTMENT.SA_yearid = STOCKADJUSTMENT_DESC.SA_YEARID LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_DESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON STOCKADJUSTMENT_DESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_DESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON STOCKADJUSTMENT_DESC.SA_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGER ON STOCKADJUSTMENT.SA_TRANSID = TRANSLEDGER.Acc_id ON PIECETYPEMASTER.PIECETYPE_id = STOCKADJUSTMENT_DESC.SA_PIECETYPEID LEFT OUTER JOIN GODOWNMASTER ON STOCKADJUSTMENT.SA_GODOWNID = GODOWNMASTER.GODOWN_id ", " AND dbo.STOCKADJUSTMENT.SA_yearid=" & YearId & " order by dbo.STOCKADJUSTMENT.SA_no ")
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
                objSTOCK.EDIT = editval
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

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SANO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SANO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Stock Adjustment Out Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Stock Adjustment Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Adjustment Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Stock Adjustment Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class