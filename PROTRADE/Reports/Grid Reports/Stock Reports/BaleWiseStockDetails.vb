
Imports BL

Public Class BaleWiseStockDetails

    Public WHERECLAUSE As String = ""
    Public FROMDATE As Date = AccFrom
    Public TODATE As Date = AccTo

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillgrid()
        Dim OBJCMN As New ClsCommon
        'Dim DT As DataTable = OBJCMN.search(" T.ITEMNAME, T.BALENO, T.PCS, T.MTRS, STOCKREGISTER_1.RATE, STOCKREGISTER_1.AMOUNT ", "", " (SELECT ITEMNAME, BALENO, (SUM(PCS)-SUM(ISSPCS)) AS PCS, (SUM(MTRS)-SUM(ISSMTRS)) AS MTRS, YEARID FROM STOCKREGISTER WHERE 1=1 " & WHERECLAUSE & " GROUP BY ITEMNAME, BALENO, YEARID HAVING (ROUND(SUM(MTRS) - SUM(ISSMTRS), 0) <> 0)) AS T INNER JOIN STOCKREGISTER AS STOCKREGISTER_1 ON T.ITEMNAME = STOCKREGISTER_1.ITEMNAME AND T.BALENO = STOCKREGISTER_1.BALENO AND T.YEARID = STOCKREGISTER_1.YEARID ", " GROUP BY T.ITEMNAME, T.BALENO, T.PCS, T.MTRS, STOCKREGISTER_1.RATE, STOCKREGISTER_1.AMOUNT ")
        Dim DT As DataTable = OBJCMN.search(" DISTINCT T.ITEMNAME, T.BALENO, T.PCS, T.MTRS, S.RATE, CASE WHEN S.PER = 'Mtrs' THEN ROUND(T.MTRS * S.RATE,2) ELSE ROUND(T.PCS*S.RATE,2) END AS AMOUNT ", "", " (SELECT ITEMNAME, BALENO,  (SUM(PCS)-SUM(ISSPCS)) AS PCS, ROUND((SUM(MTRS)-SUM(ISSMTRS)),2) AS MTRS, YEARID FROM STOCKREGISTER WHERE 1=1 " & WHERECLAUSE & " GROUP BY ITEMNAME, BALENO,  YEARID HAVING (ROUND(SUM(MTRS) - SUM(ISSMTRS), 0) <> 0)) AS T CROSS APPLY (SELECT TOP 1  STOCKREGISTER_1.RATE AS RATE, STOCKREGISTER_1.PER AS PER FROM STOCKREGISTER AS STOCKREGISTER_1 WHERE STOCKREGISTER_1.BALENO = T.BALENO AND STOCKREGISTER_1.ITEMNAME = T.ITEMNAME AND STOCKREGISTER_1.YEARID = T.YEARID) AS S  ", " ORDER BY T.ITEMNAME, T.BALENO")
        griddetails.DataSource = DT
    End Sub

    Private Sub BaleWiseStockDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BaleWiseStockDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(sender As Object, e As EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\BalewiseStock Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "BalewiseStock Details"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "BalewiseStock Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Bale Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Dim OBJSTOCK As New StockDetailsGridReport
            OBJSTOCK.WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & gridregister.GetFocusedRowCellValue("ITEMNAME") & "'"
            OBJSTOCK.FROMDATE = FROMDATE
            OBJSTOCK.TODATE = TODATE
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.FRMSTRING = "GRIDSTOCKDETAILS"
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(sender As Object, e As EventArgs) Handles gridregister.DoubleClick
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class