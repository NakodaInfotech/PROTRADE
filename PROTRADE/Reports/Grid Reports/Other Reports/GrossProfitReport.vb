
Imports BL

Public Class GrossProfitReport

    Private Sub GrossProfitReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GrossProfitReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INITIALS, INVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS.ACC_CMPNAME AS NAME, INVOICEMASTER.INVOICE_SUBTOTAL AS SALEAMT, PURLEDGERS.ACC_CMPNAME AS PURNAME, PURCHASEMASTER.BILL_INITIALS AS PURINITIALS, PURCHASEMASTER.BILL_SUBTOTAL AS PURAMT, ROUND((INVOICEMASTER.INVOICE_SUBTOTAL- PURCHASEMASTER.BILL_SUBTOTAL),2) AS GROSSAMT, ROUND(((INVOICEMASTER.INVOICE_SUBTOTAL- PURCHASEMASTER.BILL_SUBTOTAL)/PURCHASEMASTER.BILL_SUBTOTAL*100),2) AS GROSSPER ", "", " INVOICEMASTER INNER JOIN  PURCHASEMASTER ON INVOICEMASTER.INVOICE_REFNO = PURCHASEMASTER.BILL_INITIALS AND INVOICEMASTER.INVOICE_YEARID = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID INNER JOIN LEDGERS AS PURLEDGERS ON BILL_LEDGERID = PURLEDGERS.ACC_ID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXPORT_Click(sender As Object, e As EventArgs) Handles CMDEXPORT.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Gross Profit Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Gross Profit Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Gross Profit Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Gross Profit Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class