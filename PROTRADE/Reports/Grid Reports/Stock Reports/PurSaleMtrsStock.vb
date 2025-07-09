
Imports BL

Public Class PurSaleMtrsStock

    Public PURCLAUSE As String = ""
    Public FROMDATE As Date = AccFrom
    Public TODATE As Date = AccTo

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillgrid()

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("*, 0.00 AS RUNNINGBAL", "", "(SELECT PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'PURCHASE' AS TYPE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_PARTYBILLNO AS REFNO, PURCHASEMASTER.BILL_TOTALMTRS AS INMTRS, 0 AS OUTMTRS, PURCHASEMASTER.BILL_NO AS BILL, REGISTERMASTER.register_name AS REGTYPE, PURCHASEMASTER.BILL_REMARKS AS REMARKS FROM PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id WHERE BILL_YEARID =  " & YearId & PURCLAUSE & " UNION ALL SELECT     INVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'SALE' AS TYPE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, INVOICEMASTER.INVOICE_REFNO AS REFNO, 0 AS INMTRS, INVOICEMASTER.INVOICE_TOTALMTRS AS OUTMTRS, INVOICEMASTER.INVOICE_NO AS BILL, REGISTERMASTER.register_name AS REGTYPE, INVOICEMASTER.INVOICE_REMARKS AS REMARKS FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id WHERE INVOICE_YEARID = " & YearId & " UNION ALL SELECT     SALERETURN.SALRET_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'SALE RETURN' AS TYPE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(20)) AS BILLINITIALS, CAST(SALERETURN.SALRET_INVOICENO AS VARCHAR(20)) AS REFNO, SALERETURN.SALRET_TOTALMTRS AS INMTRS, 0 AS OUTMTRS, SALERETURN.SALRET_NO AS BILL, 'SALE RETURN' AS REGTYPE, SALERETURN.SALRET_REMARKS AS REMARKS FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_LEDGERID = LEDGERS.Acc_id WHERE SALRET_YEARID = " & YearId & " UNION ALL SELECT     PURCHASERETURN.PR_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'PUR RETURN' AS TYPE, 'PR-' + CAST(PURCHASERETURN.PR_NO AS VARCHAR(20)) AS BILLINITIALS, CAST(PURCHASERETURN.PR_BILLNO AS VARCHAR(20)) AS REFNO, 0 AS INMTRS, PURCHASERETURN.PR_TOTALMTRS AS OUTMTRS, PURCHASERETURN.PR_NO AS BILL, 'PURCHASE RETURN' AS REGTYPE, PURCHASERETURN.PR_REMARKS AS REMARKS FROM PURCHASERETURN INNER JOIN LEDGERS ON PURCHASERETURN.PR_LEDGERID = LEDGERS.Acc_id WHERE PR_YEARID = " & YearId & ") AS T", " AND T.DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' ORDER BY T.DATE")
        griddetails.DataSource = DT

        'getting opening balances
        DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS", "", "(SELECT PURCHASEMASTER.BILL_TOTALMTRS AS MTRS FROM PURCHASEMASTER WHERE BILL_DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YearId & PURCLAUSE & " UNION ALL Select INVOICEMASTER.INVOICE_TOTALMTRS * -1 As MTRS FROM INVOICEMASTER WHERE INVOICE_DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YearId & " UNION ALL Select SALERETURN.SALRET_TOTALMTRS As MTRS FROM SALERETURN WHERE SALRET_DATE <'" & Format(FROMDATE, "MM/dd/yyyy") & "' AND SALRET_YEARID = " & YearId & " UNION ALL Select PURCHASERETURN.PR_TOTALMTRS*-1 As MTRS FROM PURCHASERETURN WHERE PR_DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND  PR_YEARID = " & YearId & ") As T", "")
        If DT.Rows.Count > 0 Then txtopening.Text = Format(Val(DT.Rows(0).Item("MTRS")), "0.00")
        TOTAL()

    End Sub

    Sub TOTAL()
        Try
            txttotal.Text = 0.0
            TXTINTOTAL.Text = 0.0
            TXTOUTTOTAL.Text = 0.0

            TXTOUTTOTAL.Text = Format(Val(GOUTMTRS.SummaryText), "0.00")
            TXTINTOTAL.Text = Format(Val(GINMTRS.SummaryText), "0.00")

            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double = Val(txtopening.Text)
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("RUNNINGBAL") = (Val(dtrow("INMTRS")) + Val(RUNNINGBAL)) - Val(dtrow("OUTMTRS"))
                RUNNINGBAL = dtrow("RUNNINGBAL")
            Next
            txttotal.Text = Format((Val(txtopening.Text)) + Val(TXTINTOTAL.Text) - Val(TXTOUTTOTAL.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurSaleMtrsStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurSaleMtrsStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                If dtrow("TYPE") = "STOCK" Then Exit Sub
                VIEWFORM(dtrow("TYPE"), True, dtrow("BILL"), dtrow("REGTYPE"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Pur Sale Stock.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Pur Sale Stock"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pur Sale Stock", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", "Period - " & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy"), Val(txtopening.Text.Trim), Val(txttotal.Text.Trim))
        Catch ex As Exception
            MsgBox("Pur-Sale Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub PurSaleMtrsStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

End Class