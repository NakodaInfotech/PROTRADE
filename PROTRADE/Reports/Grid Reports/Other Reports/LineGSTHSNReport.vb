
Imports BL

Public Class LineGSTHSNReport
    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub LineGSTHSNReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtfrom.Value = AccFrom
        dtto.Value = AccTo
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_INITIALS AS INVINITIALS, INVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, LEDGERS.ACC_GSTIN AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, CAST(ISNULL(STATEMASTER.state_remark, '') AS VARCHAR(20)) AS STATECODE, ISNULL(CITYMASTER.city_name, '') AS CITYNAME, SUM(INVOICEMASTER_DESC.INVOICE_PCS) AS PCS, SUM(INVOICEMASTER_DESC.INVOICE_MTRS) AS MTRS, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_IGST, 0) AS GSTPER, SUM(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT) AS TAXABLEAMT, SUM(INVOICEMASTER_DESC.INVOICE_CGSTAMT) AS CGSTAMT, SUM(INVOICEMASTER_DESC.INVOICE_SGSTAMT) AS SGSTAMT, SUM(INVOICEMASTER_DESC.INVOICE_IGSTAMT) AS IGSTAMT, SUM(INVOICEMASTER_DESC.INVOICE_GRIDTOTAL) AS TOTALAMT  ", "", " LEDGERS INNER JOIN INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ON LEDGERS.Acc_id = INVOICEMASTER.INVOICE_LEDGERID LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " AND INVOICE_DATE >= '" & Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_INITIALS, INVOICEMASTER.INVOICE_PRINTINITIALS, LEDGERS.Acc_cmpname, LEDGERS.ACC_GSTIN, ISNULL(STATEMASTER.state_name, ''), CAST(ISNULL(STATEMASTER.state_remark, '') AS VARCHAR(20)), ISNULL(CITYMASTER.city_name, ''), ISNULL(HSNMASTER.HSN_CODE, ''), ISNULL(HSNMASTER.HSN_IGST, 0)")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\GST Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "GST Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GST Report", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("GST Report Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class