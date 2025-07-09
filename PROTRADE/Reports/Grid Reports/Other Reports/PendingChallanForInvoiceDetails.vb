
Imports BL

Public Class PendingChallanForInvoiceDetails

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PendingChallanForInvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PendingChallanForInvoiceDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  GDN.GDN_NO AS SRNO, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DELIVERYLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(ISNULL(GDN_DESC.GDN_PCS, 0)) AS PCS, SUM(ISNULL(GDN_DESC.GDN_MTRS, 0)) AS MTRS", "", " GDN INNER JOIN GODOWNMASTER ON GDN.GDN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID INNER JOIN ITEMMASTER ON GDN_DESC.GDN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS DELIVERYLEDGERS ON GDN.GDN_DISPATCHTOID = DELIVERYLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON GDN_DESC.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id ", " AND ROUND(ISNULL(GDN.GDN_OUTMTRS,0),0) = 0 AND GDN.GDN_YEARID = " & YearId & " GROUP BY GDN.GDN_NO, ISNULL(GDN.GDN_date, GETDATE()), ISNULL(LEDGERS.Acc_cmpname, ''), ISNULL(GODOWNMASTER.GODOWN_name, ''), ISNULL(DELIVERYLEDGERS.Acc_cmpname, ''), ISNULL(ITEMMASTER.item_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, '')")
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

            Dim PATH As String = Application.StartupPath & "\Challan Pending For Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Challan Pending For Invoice"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Pending For Invoice", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Challan Pending Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class