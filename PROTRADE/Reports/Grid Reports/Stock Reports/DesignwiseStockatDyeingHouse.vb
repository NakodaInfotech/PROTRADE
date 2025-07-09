
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class DesignwiseStockatDyeingHouse

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignwiseStockatDyeingHouse_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DesignwiseStockatDyeingHouse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            'dt = objclsCMST.search(" LEDGERS.Acc_cmpname AS NAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(SUM(CHECKINGMASTER_DESC.CHECK_CHECKEDMTRS), 0) AS BALMTRS ", "", "  DESIGNMASTER RIGHT OUTER JOIN GRN_DESC INNER JOIN GRN ON GRN_DESC.GRN_NO = GRN.grn_no AND GRN_DESC.GRN_GRIDTYPE = GRN.GRN_TYPE AND GRN_DESC.GRN_YEARID = GRN.grn_yearid AND GRN_DESC.GRN_CMPID = GRN.grn_cmpid AND GRN_DESC.GRN_LOCATIONID = GRN.grn_locationid INNER JOIN LEDGERS ON GRN.GRN_TOLEDGERID = LEDGERS.Acc_id AND GRN.grn_yearid = LEDGERS.Acc_yearid AND GRN.grn_cmpid = LEDGERS.Acc_cmpid AND GRN.grn_locationid = LEDGERS.Acc_locationid LEFT OUTER JOIN CHECKINGMASTER INNER JOIN CHECKINGMASTER_DESC ON CHECKINGMASTER.CHECK_NO = CHECKINGMASTER_DESC.CHECK_NO AND CHECKINGMASTER.CHECK_YEARID = CHECKINGMASTER_DESC.CHECK_YEARID AND CHECKINGMASTER.CHECK_CMPID = CHECKINGMASTER_DESC.CHECK_CMPID AND CHECKINGMASTER.CHECK_LOCATIONID = CHECKINGMASTER_DESC.CHECK_LOCATIONID ON GRN_DESC.GRN_LOCATIONID = CHECKINGMASTER.CHECK_LOCATIONID AND GRN_DESC.GRN_CMPID = CHECKINGMASTER.CHECK_CMPID AND GRN_DESC.GRN_NO = CHECKINGMASTER.CHECK_GRNNO AND GRN_DESC.GRN_GRIDSRNO = CHECKINGMASTER.CHECK_GRNGRIDSRNO AND GRN_DESC.GRN_YEARID = CHECKINGMASTER.CHECK_YEARID AND GRN_DESC.GRN_GRIDTYPE = CHECKINGMASTER.CHECK_TYPE ON DESIGNMASTER.DESIGN_locationid = GRN_DESC.GRN_LOCATIONID AND DESIGNMASTER.DESIGN_cmpid = GRN_DESC.GRN_CMPID AND DESIGNMASTER.DESIGN_id = GRN_DESC.GRN_DESIGNID AND DESIGNMASTER.DESIGN_yearid = GRN_DESC.GRN_YEARID ", " AND CHECKINGMASTER.CHECK_CMPID = " & CmpId & " AND CHECKINGMASTER.CHECK_LOCATIONID = " & Locationid & " AND CHECKINGMASTER.CHECK_YEARID =" & YearId & " AND (CHECKINGMASTER_DESC.CHECK_CHECKINGDONE = 0) GROUP BY ISNULL(DESIGNMASTER.DESIGN_NO, ''), LEDGERS.Acc_cmpname")
            'WHEN WE FETCH DATA FROM STOCKMASTER WE NEED TO CHECK SMPCS-OUTPCS COZ WE CANNOT KEEP TRACK ON MTRS HERE
            'COZ WHEN WE REC MTRS WE WILL GET SHRINKAGE THAT TIME SOFTWARE WILL SHOW THE LOT PENING, SO WE NEED TO WORK ON PCS HERE

            'THIS IS OLD CODE, CHANGED BY GULKIT, DO NOT CHNAGE
            'Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT LEDGERS.Acc_cmpname AS NAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(SUM(CHECKINGMASTER_DESC.CHECK_CHECKEDMTRS), 0) AS BALMTRS, ISNULL(COUNT(CHECKINGMASTER_DESC.CHECK_CHECKEDMTRS), 0) AS BALPCS, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME  FROM DESIGNMASTER RIGHT OUTER JOIN GRN_DESC INNER JOIN GRN ON GRN_DESC.GRN_NO = GRN.grn_no AND GRN_DESC.GRN_GRIDTYPE = GRN.GRN_TYPE AND GRN_DESC.GRN_YEARID = GRN.grn_yearid LEFT OUTER JOIN ITEMMASTER ON ITEM_ID = GRN_DESC.GRN_ITEMID INNER JOIN LEDGERS ON GRN.GRN_TOLEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN CHECKINGMASTER INNER JOIN CHECKINGMASTER_DESC ON CHECKINGMASTER.CHECK_NO = CHECKINGMASTER_DESC.CHECK_NO AND  CHECKINGMASTER.CHECK_YEARID = CHECKINGMASTER_DESC.CHECK_YEARID ON GRN_DESC.GRN_NO = CHECKINGMASTER.CHECK_GRNNO AND  GRN_DESC.GRN_GRIDSRNO = CHECKINGMASTER.CHECK_GRNGRIDSRNO AND GRN_DESC.GRN_YEARID = CHECKINGMASTER.CHECK_YEARID AND GRN_DESC.GRN_GRIDTYPE = CHECKINGMASTER.CHECK_TYPE ON DESIGNMASTER.DESIGN_id = GRN_DESC.GRN_DESIGNID WHERE(CHECKINGMASTER_DESC.CHECK_CHECKINGDONE = 0) AND CHECKINGMASTER.CHECK_YEARID = " & YearId & " GROUP BY LEDGERS.Acc_cmpname, ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(ITEMMASTER.ITEM_NAME,'') UNION ALL SELECT LEDGERS.Acc_cmpname AS NAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(SUM(STOCKMASTER.SM_MTRS - SM_OUTMTRS), 0) AS BALMTRS, ISNULL(SUM(STOCKMASTER.SM_PCS - SM_OUTPCS),0) AS BALPCS, ISNULL(ITEMMASTER.ITEM_NAME,'') FROM STOCKMASTER LEFT OUTER JOIN DESIGNMASTER ON SM_DESIGNID = DESIGN_ID INNER JOIN LEDGERS ON SM_LEDGERIDTO  = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON ITEM_ID = SM_ITEMID WHERE (STOCKMASTER.SM_PCS - SM_OUTPCS )> 0 AND SM_LOTNO <> '' AND SM_YEARID = " & YearId & " GROUP BY LEDGERS.Acc_cmpname, ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(ITEMMASTER.ITEM_NAME,'')) AS T ", "")
            Dim dt As DataTable = objclsCMST.search("JOBBERNAME AS NAME, CATEGORYNAME, ITEMNAME, DESIGN, SUM(BALPCS) AS BALPCS, SUM(BALMTRS) AS BALMTRS", "", " LOT_VIEW ", " AND BALPCS > 0 AND YEARID = " & YearId & " GROUP BY JOBBERNAME, CATEGORYNAME, ITEMNAME, DESIGN")
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
            PATH = Application.StartupPath & "\Dyeing House Stock.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Dyeing House Stock"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Dyeing House Stock", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Dyeing Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Dim OBJJOB As New DesignwiseStockDyeingHouseDetails
            OBJJOB.MdiParent = MDIMain
            OBJJOB.STRSEARCH = " AND T.DESIGNNO = '" & gridbill.GetFocusedRowCellValue("DESIGNNO") & "' AND T.NAME = '" & gridbill.GetFocusedRowCellValue("NAME") & "' AND T.ITEMNAME = '" & gridbill.GetFocusedRowCellValue("ITEMNAME") & "'"
            OBJJOB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        showform()
    End Sub

End Class