
Imports BL

Public Class ReOrderLevelReport

    Private Sub ReOrderLevelReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReOrderLevelReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try


            Dim OBJCMN As New ClsCommonMaster

            Dim WHERECLAUSE As String = ""
            Dim DTUNIT As DataTable = OBJCMN.search("UNIT_ABBR", "", "DEFAULTSTOCKUNIT", "")
            If DTUNIT.Rows.Count > 0 Then WHERECLAUSE = WHERECLAUSE & " AND BARCODESTOCK.UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT)"

            Dim HAVINGCLAUSE As String = ""
            If ClientName = "MOMAI" Then HAVINGCLAUSE = " HAVING SUM(BARCODESTOCK.PCS)<T.QTY" Else HAVINGCLAUSE = " HAVING SUM(BARCODESTOCK.MTRS)<T.QTY"


            Dim DT As DataTable = OBJCMN.search(" T.ITEMNAME, T.QUALITYNAME, T.DESIGNNO, T.COLORNAME, T.QTY, SUM(BARCODESTOCK.PCS) AS PCS, SUM(BARCODESTOCK.MTRS) AS MTRS ", "", " (SELECT ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name,'') AS QUALITYNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLORNAME, REORDERLEVEL.REORDER_QTY AS QTY, REORDER_YEARID AS YEARID FROM REORDERLEVEL INNER JOIN ITEMMASTER ON REORDERLEVEL.REORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON REORDERLEVEL.REORDER_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON REORDERLEVEL.REORDER_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON REORDERLEVEL.REORDER_QUALITYID = QUALITYMASTER.QUALITY_id) AS T INNER JOIN BARCODESTOCK ON T.ITEMNAME = BARCODESTOCK.ITEMNAME AND T.QUALITYNAME = BARCODESTOCK.QUALITY AND T.DESIGNNO = BARCODESTOCK.DESIGNNO AND T.COLORNAME = BARCODESTOCK.COLOR AND T.YEARID= BARCODESTOCK.YEARID ", " AND T.YEARID = " & YearId & WHERECLAUSE & " GROUP BY T.ITEMNAME, T.QUALITYNAME, T.DESIGNNO, T.COLORNAME, T.QTY " & HAVINGCLAUSE)
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
            PATH = Application.StartupPath & "\ReOrder Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "ReOrder Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "ReOrder Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("ReOrder Report Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ReOrderLevelReport_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "MOMAI" Then GSTOCKMTRS.Visible = False Else GSTOCKPCS.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class