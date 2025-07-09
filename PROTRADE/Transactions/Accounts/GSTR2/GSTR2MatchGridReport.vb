
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class GSTR2MatchGridReport

    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GSTR2MatchGridReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GSTR2MatchGridReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" *, (CASE WHEN T.INVNOBOOKS = '' THEN 'ONLY IN PORTAL' ELSE (CASE WHEN T.INVNOPORTAL = '' THEN 'ONLY IN BOOKS' ELSE (CASE WHEN (T.TAXABLEAMTBOOKS - T.TAXABLEAMTPORTAL) <> 0 THEN 'VALUE MISMATCH' ELSE 'EXACT MATCH' END) END)END) AS RECOSTATUS ", "", "(SELECT    GSTR2BILLS.BILLNO, GSTR2BILLS.TYPE  ,    COALESCE (GSTR2B2B.MONTH, UPPER(DATENAME(M, GSTR2BILLS.PARTYBILLDATE))) AS [MONTH], COALESCE(GSTR2B2B.GSTIN,  GSTR2BILLS.GSTIN) AS GSTIN, (CASE WHEN ISNULL(GSTR2B2B.NAME,'') <> '' THEN ISNULL(GSTR2B2B.NAME,'') ELSE GSTR2BILLS.NAME END) AS NAME, ISNULL(GSTR2BILLS.PARTYBILLNO,'') AS INVNOBOOKS, COALESCE(GSTR2BILLS.PARTYBILLDATE,GSTR2B2B.INVDATE) AS INVDATEBOOKS, ISNULL(GSTR2B2B.INVNO,'') AS INVNOPORTAL,  GSTR2B2B.INVDATE AS INVDATEPORTAL,  ISNULL(GSTR2BILLS.TAXABLEAMT,0) AS TAXABLEAMTBOOKS, ISNULL(GSTR2BILLS.CGSTAMT,0) AS CGSTAMTBOOKS, ISNULL(GSTR2BILLS.SGSTAMT,0) AS SGSTAMTBOOKS, ISNULL(GSTR2BILLS.IGSTAMT,0) AS IGSTAMTBOOKS, ISNULL(GSTR2BILLS.GRANDTOTAL,0) AS GRANDTOTALBOOKS, ISNULL(GSTR2B2B.TAXABLEAMT,0) AS TAXABLEAMTPORTAL, ISNULL(GSTR2B2B.CGSTAMT,0) AS CGSTAMTPORTAL, ISNULL(GSTR2B2B.SGSTAMT,0) AS SGSTAMTPORTAL, ISNULL(GSTR2B2B.IGSTAMT,0) AS IGSTAMTPORTAL, ISNULL(GSTR2B2B.GRANDTOTAL,0) AS GRANDTOTALPORTAL , COALESCE( GSTR2B2B.YEARID, GSTR2BILLS.YEARID) AS YEARID FROM GSTR2B2B FULL OUTER JOIN (SELECT * FROM GSTR2BILLS WHERE [TYPE] IN ('PURCHASE', 'NONPURCHASE')) AS GSTR2BILLS ON GSTR2B2B.YEARID = GSTR2BILLS.YEARID AND GSTR2B2B.INVNO = GSTR2BILLS.PARTYBILLNO AND GSTR2B2B.GSTIN = GSTR2BILLS.GSTIN AND GSTR2B2B.GSTRATE = GSTR2BILLS.GSTRATE UNION ALL SELECT GSTR2BILLS.BILLNO, GSTR2BILLS.TYPE, COALESCE (GSTR2CNDN.MONTH, UPPER(DATENAME(M, GSTR2BILLS.PARTYBILLDATE))) AS [MONTH], COALESCE(GSTR2CNDN.GSTIN,  GSTR2BILLS.GSTIN) AS GSTIN, (CASE WHEN ISNULL(GSTR2CNDN.NAME,'') <> '' THEN ISNULL(GSTR2CNDN.NAME,'') ELSE GSTR2BILLS.NAME END) AS NAME, ISNULL(GSTR2BILLS.PARTYBILLNO,'') AS INVNOBOOKS, COALESCE(GSTR2BILLS.PARTYBILLDATE,GSTR2CNDN.INVDATE) AS INVDATEBOOKS, ISNULL(GSTR2CNDN.INVNO,'') AS INVNOPORTAL, GSTR2CNDN.INVDATE AS INVDATEPORTAL, ISNULL(GSTR2BILLS.TAXABLEAMT,0) AS TAXABLEAMTBOOKS, ISNULL(GSTR2BILLS.CGSTAMT,0) AS CGSTAMTBOOKS, ISNULL(GSTR2BILLS.SGSTAMT,0) AS SGSTAMTBOOKS, ISNULL(GSTR2BILLS.IGSTAMT,0) AS IGSTAMTBOOKS, ISNULL(GSTR2BILLS.GRANDTOTAL,0) AS GRANDTOTALBOOKS, ISNULL(GSTR2CNDN.TAXABLEAMT,0) AS TAXABLEAMTPORTAL, ISNULL(GSTR2CNDN.CGSTAMT,0) AS CGSTAMTPORTAL, ISNULL(GSTR2CNDN.SGSTAMT,0) AS SGSTAMTPORTAL, ISNULL(GSTR2CNDN.IGSTAMT,0) AS IGSTAMTPORTAL, ISNULL(GSTR2CNDN.GRANDTOTAL,0) AS GRANDTOTALPORTAL, COALESCE( GSTR2CNDN.YEARID, GSTR2BILLS.YEARID) AS YEARID FROM GSTR2CNDN FULL OUTER JOIN (SELECT * FROM GSTR2BILLS WHERE [TYPE] IN ('CREDITNOTE', 'DEBITNOTE', 'PURCHASERETURN')) AS GSTR2BILLS ON GSTR2CNDN.YEARID = GSTR2BILLS.YEARID AND GSTR2CNDN.INVNO = GSTR2BILLS.PARTYBILLNO AND GSTR2CNDN.GSTIN = GSTR2BILLS.GSTIN AND GSTR2CNDN.GSTRATE = GSTR2BILLS.GSTRATE) AS T", " AND T.YEARID = " & YearId & WHERECLAUSE & " ORDER BY T.GSTIN,T.INVDATEBOOKS ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXPORT_Click(sender As Object, e As EventArgs) Handles CMDEXPORT.Click
        Try
            Dim PATH As String = Application.StartupPath & "\GSTR2 Match Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "GSTR2 Match Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GSTR2 Match Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("GSTR2 Match Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("RECOSTATUS")) = "ONLY IN BOOKS" Then
                    e.Appearance.BackColor = Color.Yellow
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("RECOSTATUS")) = "ONLY IN PORTAL" Then
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("RECOSTATUS")) = "VALUE MISMATCH" Then
                    e.Appearance.BackColor = Color.LightBlue
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("RECOSTATUS")) = "EXACT MATCH" Then
                    e.Appearance.BackColor = Color.White
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class