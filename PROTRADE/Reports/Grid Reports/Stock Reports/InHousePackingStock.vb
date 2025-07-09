
Imports BL

Public Class InHousePackingStock

    Public FRMSTRING As String = "DETAILS"

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InHousePackingStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "SUMMARY" Then
                GBARCODE.Visible = False
                GPCS.Visible = True
                If ClientName <> "AVIS" Then
                    GSRNO.Visible = False
                    GDATE.Visible = False
                End If

                If ClientName = "KARAN" Then
                    GLOTNO.Visible = True
                    GLOTNO.VisibleIndex = GSHADE.VisibleIndex + 1
                End If
            Else
                GPCS.Visible = False
            End If
            fillgrid(" AND ISSUEPACKING_DESC.ISS_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As New DataTable
            If FRMSTRING = "SUMMARY" Then
                If ClientName = "AVIS" Then
                    dt = OBJCMN.search(" ISSUEPACKING_DESC.ISS_NO AS SRNO, ISSUEPACKING.ISS_DATE AS DATE, ISNULL(CONTRACT_NAME,'') AS CONTRACTOR, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(ISSUEPACKING_DESC.ISS_MTRS) AS MTRS, SUM(ROUND(ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS RECDMTRS, SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS BALMTRS, COUNT(ISSUEPACKING_DESC.ISS_BARCODE) AS PCS ", "", "  ITEMMASTER INNER JOIN ISSUEPACKING_DESC ON ITEMMASTER.item_id = ISSUEPACKING_DESC.ISS_ITEMID LEFT OUTER JOIN COLORMASTER ON ISSUEPACKING_DESC.ISS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ISSUEPACKING_DESC.ISS_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID LEFT OUTER JOIN CONTRACTMASTER ON ISS_CONTRACTID = CONTRACT_ID ", TEMPCONDITION & " GROUP BY ISSUEPACKING_DESC.ISS_NO, ISSUEPACKING.ISS_DATE , ISNULL(CONTRACT_NAME,''), ITEMMASTER.item_name, ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, '') HAVING ROUND ( SUM( ISSUEPACKING_DESC.ISS_MTRS) - SUM(ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0)), 2) > 0  ")
                ElseIf ClientName = "KARAN" Then
                    dt = OBJCMN.search(" ISNULL(CONTRACT_NAME,'') AS CONTRACTOR, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(ISSUEPACKING_DESC.ISS_MTRS) AS MTRS, SUM(ROUND(ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS RECDMTRS, SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS BALMTRS, COUNT(ISSUEPACKING_DESC.ISS_BARCODE) AS PCS, ISNULL(ISS_LOTNO,'') AS LOTNO ", "", "  ITEMMASTER INNER JOIN ISSUEPACKING_DESC ON ITEMMASTER.item_id = ISSUEPACKING_DESC.ISS_ITEMID LEFT OUTER JOIN COLORMASTER ON ISSUEPACKING_DESC.ISS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ISSUEPACKING_DESC.ISS_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID LEFT OUTER JOIN CONTRACTMASTER ON ISS_CONTRACTID = CONTRACT_ID ", TEMPCONDITION & " AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0 GROUP BY ISNULL(CONTRACT_NAME,''), ITEMMASTER.item_name, ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(ISS_LOTNO,'') ")
                Else
                    dt = OBJCMN.search(" ISNULL(CONTRACT_NAME,'') AS CONTRACTOR, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(ISSUEPACKING_DESC.ISS_MTRS) AS MTRS, SUM(ROUND(ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS RECDMTRS, SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)) AS BALMTRS, COUNT(ISSUEPACKING_DESC.ISS_BARCODE) AS PCS ", "", "  ITEMMASTER INNER JOIN ISSUEPACKING_DESC ON ITEMMASTER.item_id = ISSUEPACKING_DESC.ISS_ITEMID LEFT OUTER JOIN COLORMASTER ON ISSUEPACKING_DESC.ISS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ISSUEPACKING_DESC.ISS_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID LEFT OUTER JOIN CONTRACTMASTER ON ISS_CONTRACTID = CONTRACT_ID ", TEMPCONDITION & " AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0 GROUP BY ISNULL(CONTRACT_NAME,''), ITEMMASTER.item_name, ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, '')")
                End If
            Else
                dt = OBJCMN.search(" ISSUEPACKING_DESC.ISS_NO AS SRNO, ISSUEPACKING.ISS_DATE AS DATE, ISNULL(CONTRACT_NAME,'') AS CONTRACTOR, ISSUEPACKING_DESC.ISS_BARCODE AS BARCODE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISSUEPACKING_DESC.ISS_MTRS AS MTRS, ROUND(ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) AS RECDMTRS, ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) AS BALMTRS  ", "", "  ITEMMASTER INNER JOIN ISSUEPACKING_DESC ON ITEMMASTER.item_id = ISSUEPACKING_DESC.ISS_ITEMID LEFT OUTER JOIN COLORMASTER ON ISSUEPACKING_DESC.ISS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON ISSUEPACKING_DESC.ISS_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID LEFT OUTER JOIN CONTRACTMASTER ON ISS_CONTRACTID = CONTRACT_ID ", TEMPCONDITION & " AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0 ORDER BY ISSUEPACKING_DESC.ISS_NO, ISSUEPACKING_DESC.ISS_GRIDSRNO")
            End If
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
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\In House Packing Stock.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "In House Packing Stock"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "In House Packing Stock", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("In House Packing Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Try
            If FRMSTRING <> "SUMMARY" Then
                Dim OBJREC As New RecFromPacking
                OBJREC.ISSUEBARCODE = gridbill.GetFocusedRowCellValue("BARCODE")
                OBJREC.MdiParent = MDIMain
                OBJREC.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid(" AND ISSUEPACKING_DESC.ISS_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class