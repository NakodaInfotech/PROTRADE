
Imports BL

Public Class StockRecoInDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockRecoInDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StockRecoInDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim dt As DataTable = objclsCMST.search(" STOCKADJUSTMENT.SA_no AS SANO, STOCKADJUSTMENT.SA_date AS DATE, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '')  AS BALENO, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDDESC, '') AS GRIDDESC, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS PCS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE,  ISNULL(SHELFMASTER.SHELF_NAME, '') AS SHELF, ISNULL(RACKMASTER.RACK_NAME, '') AS RACK ", "", "  STOCKADJUSTMENT INNER JOIN  STOCKADJUSTMENT_INDESC ON STOCKADJUSTMENT.SA_NO = STOCKADJUSTMENT_INDESC.SA_NO and STOCKADJUSTMENT.SA_yearid = STOCKADJUSTMENT_INDESC.SA_YEARID INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN RACKMASTER ON STOCKADJUSTMENT_INDESC.SA_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN SHELFMASTER ON STOCKADJUSTMENT_INDESC.SA_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND dbo.STOCKADJUSTMENT.SA_yearid=" & YearId & " order by DBO.STOCKADJUSTMENT.SA_NO")
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

            Dim PATH As String = Application.StartupPath & "\Stock Adjustment In Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Stock Adjustment In Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Adjustment In Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Stock Adjustment In Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class