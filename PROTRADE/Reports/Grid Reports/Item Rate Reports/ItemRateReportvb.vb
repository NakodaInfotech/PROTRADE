
Imports BL

Public Class PurchaseItemRateReport

    Public FRMSTRING As String = ""
    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseItemRateReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseItemRateReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "SALE" Then
                gsrno.Caption = "Invoice No"
                GPARTYBILLNO.Caption = "Ref No"
                Me.Text = ""
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If FRMSTRING = "PURCHASE" Then dt = objclsCMST.search(" DISTINCT PURCHASEMASTER.BILL_NO AS SRNO, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_PARTYBILLNO AS PARTYBILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, ITEMMASTER.ITEM_NAME AS ITEMNAME ,  BILL_RATE AS RATE   ", "", " PURCHASEMASTER_DESC  AS B LEFT OUTER JOIN (SELECT BILL_ITEMID,  MAX(BILL_NO) AS SRNO, BILL_yearid FROM PURCHASEMASTER_DESC WHERE PURCHASEMASTER_DESC.BILL_YEARID = " & YearId & " GROUP BY BILL_ITEMID, BILL_yearid) T ON B.BILL_NO = T.SRNO AND B.BILL_ITEMID = T.BILL_ITEMID AND B.BILL_yearid = T.BILL_yearid  INNER JOIN ITEMMASTER ON item_id = B.BILL_ITEMID  INNER JOIN PURCHASEMASTER ON B.BILL_NO = PURCHASEMASTER.BILL_NO AND B.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID AND B.BILL_yearid = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON ACC_id = PURCHASEMASTER.BILL_LEDGERID INNER JOIN REGISTERMASTER ON register_id = PURCHASEMASTER.BILL_REGISTERID ", WHERECLAUSE & " AND B.BILL_YEARID = " & YearId & " ORDER BY SRNO, ITEMNAME") Else dt = objclsCMST.search(" DISTINCT INVOICEMASTER.INVOICE_NO AS SRNO, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.INVOICE_REFNO AS PARTYBILLNO, INVOICEMASTER.INVOICE_DATE AS PARTYBILLDATE, ITEMMASTER.ITEM_NAME AS ITEMNAME ,  INVOICE_RATE AS RATE   ", "", " INVOICEMASTER_DESC  AS B LEFT OUTER JOIN (SELECT INVOICE_ITEMID,  MAX(INVOICE_NO) AS SRNO, INVOICE_yearid FROM INVOICEMASTER_DESC WHERE INVOICEMASTER_DESC.INVOICE_YEARID = " & YearId & " GROUP BY INVOICE_ITEMID, INVOICE_yearid) T ON B.INVOICE_NO = T.SRNO AND B.INVOICE_ITEMID = T.INVOICE_ITEMID AND B.INVOICE_yearid = T.INVOICE_yearid  INNER JOIN ITEMMASTER ON item_id = B.INVOICE_ITEMID  INNER JOIN INVOICEMASTER ON B.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND B.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND B.INVOICE_yearid = INVOICEMASTER.INVOICE_YEARID INNER JOIN LEDGERS ON ACC_id = INVOICEMASTER.INVOICE_LEDGERID INNER JOIN REGISTERMASTER ON register_id = INVOICEMASTER.INVOICE_REGISTERID ", WHERECLAUSE & " AND B.INVOICE_YEARID = " & YearId & " ORDER BY SRNO, ITEMNAME")
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

            Dim PATH As String = Application.StartupPath & "\Item Rate Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Item Rate Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Item Rate Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Item Rate Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class