Imports BL
Imports System.Windows.Forms

Public Class SelectSOforScheduling

    Public DT As New DataTable
    Public JOBBER As String = ""
    Public TYPE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStockJobber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStockJobber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid("")
        fillgridstock()
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OBJCMN As New ClsCommon()
            Dim DT As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK, *", "", "(SELECT OPENINGSALEORDER_DESC.OPSO_NO AS SONO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, OPENINGSALEORDER_DESC.OPSO_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(OPENINGSALEORDER_DESC.OPSO_QTY - OPENINGSALEORDER_DESC.OPSO_RECDQTY, 0) AS QTY, ISNULL(OPENINGSALEORDER_DESC.OPSO_MTRS, 0) AS MTRS, ISNULL(OPENINGSALEORDER_DESC.OPSO_RECDQTY, 0) AS RECDQTY, 'OPENING' AS TYPE FROM OPENINGSALEORDER INNER JOIN OPENINGSALEORDER_DESC ON OPENINGSALEORDER.OPSO_no = OPENINGSALEORDER_DESC.OPSO_NO AND OPENINGSALEORDER.OPSO_YEARID = OPENINGSALEORDER_DESC.OPSO_YEARID INNER JOIN LEDGERS ON OPENINGSALEORDER.OPSO_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON OPENINGSALEORDER_DESC.OPSO_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER ON OPENINGSALEORDER_DESC.OPSO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON OPENINGSALEORDER_DESC.OPSO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON OPENINGSALEORDER_DESC.OPSO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER AS COLORMASTER ON OPENINGSALEORDER_DESC.OPSO_COLORID = COLORMASTER.COLOR_id WHERE (OPENINGSALEORDER_DESC.OPSO_QTY - OPENINGSALEORDER_DESC.OPSO_RECDQTY) > 0 AND OPENINGSALEORDER.OPSO_CLOSED = 0 AND OPENINGSALEORDER.OPSO_YEARID = " & YearId & " UNION ALL SELECT SALEORDER_DESC.SO_NO AS SONO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, SALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, (SALEORDER_DESC.SO_QTY - SALEORDER_DESC.SO_RECDQTY) AS QTY, ISNULL(SALEORDER_DESC.SO_MTRS, 0) AS MTRS, ISNULL(SALEORDER_DESC.SO_RECDQTY, 0) AS RECDQTY, 'SO' AS TYPE FROM SALEORDER INNER JOIN SALEORDER_DESC ON SALEORDER.so_no = SALEORDER_DESC.SO_NO AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON SALEORDER_DESC.SO_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER ON SALEORDER_DESC.SO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON SALEORDER_DESC.SO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER AS COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id WHERE (SALEORDER_DESC.SO_QTY - SALEORDER_DESC.SO_RECDQTY) > 0 AND SALEORDER_DESC.SO_CLOSED = 0 AND SALEORDER.SO_YEARID = " & YearId & ") AS T", " ORDER BY T.TYPE, T.SONO, T.GRIDSRNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillgridstock()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OBJCMN As New ClsCommon()
            Dim DT As DataTable = OBJCMN.search("ITEMNAME, COLOR, UNIT, SUM(PCS) AS PCS, SUM(MTRS) AS MTRS ", "", " BARCODESTOCK ", " AND ROUND(MTRS,0) > 0 AND YEARID = " & YearId & " GROUP BY ITEMNAME, COLOR, UNIT ")
            GRIDSTOCKDETAILS.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDSTOCK.FocusedRowHandle = GRIDSTOCK.RowCount - 1
                GRIDSTOCK.TopRowIndex = GRIDSTOCK.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("SONO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("ITEM")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("QTY")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("TYPE")
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("SONO")), dtrow("NAME"), Val(dtrow("GRIDSRNO")), dtrow("ITEM"), dtrow("QUALITY"), dtrow("COLOR"), Val(dtrow("QTY")), Val(dtrow("MTRS")), dtrow("TYPE"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class