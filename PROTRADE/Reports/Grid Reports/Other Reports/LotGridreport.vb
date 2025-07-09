
Imports BL

Public Class LotGridreport

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""
    Public TILLDATE As Date = Now.Date

    Private Sub LotGridreport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim SHRINKAGECLAUSE As String = ""
            If LOTSTATUSONMTRS = False Then
                If FRMSTRING = "STOCKREGISTER" Then
                    SHRINKAGECLAUSE = " (CASE WHEN (ACCEPTEDPCS - SUM(RECDPCS)) <= 0 OR LOTCOMPLETED = 'TRUE' THEN ROUND((ACCEPTEDMTRS - ISNULL((SELECT SUM(Y.RECDMTRS)  FROM LOT_VIEW_DETAILS AS Y WHERE Y.LOTNO = T.LOTNO AND Y.YEARID = T.YEARID AND Y.JOBBERNAME = T.JOBBERNAME AND Y.GRNNO = T.GRNNO AND Y.RECDATE <= '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "' GROUP BY Y.LOTNO, Y.YEARID, Y.JOBBERNAME, Y.GRNNO),0)),2) ELSE 0 END)"
                Else
                    SHRINKAGECLAUSE = " (CASE WHEN (ACCEPTEDPCS - SUM(RECDPCS)) <= 0 OR LOTCOMPLETED = 'TRUE' THEN ROUND((ACCEPTEDMTRS - SUM(RECDMTRS)),2) ELSE 0 END)"
                End If
            Else
                SHRINKAGECLAUSE = " (CASE WHEN LOTCOMPLETED = 'TRUE' THEN (ACCEPTEDMTRS - SUM(RECDMTRS) - OPRECDMTRS)  ELSE 0 END)"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If FRMSTRING = "STOCKREGISTER" Then
                dt = objclsCMST.search(" PARTYNAME, JOBBERNAME,  LOTNO, QUALITY, DESIGN, ITEMNAME, TOTALPCS, TOTALMTRS, SHORTPCS, SHORTMTRS, CHECKPCS, CHECKMTRS, REJPCS, REJMTRS, ACCEPTEDPCS, ACCEPTEDMTRS, CMPID, YEARID, CHALLANNO, CATEGORYNAME, LOTCOMPLETED, FORPROCESS, SUM(RECDPCS) AS RECDPCS, (ISNULL((SELECT SUM(Y.RECDMTRS)  FROM LOT_VIEW_DETAILS AS Y WHERE Y.LOTNO = T.LOTNO AND Y.YEARID = T.YEARID AND Y.JOBBERNAME = T.JOBBERNAME AND Y.GRNNO = T.GRNNO AND Y.RECDATE <= '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "' GROUP BY Y.LOTNO, Y.YEARID, Y.JOBBERNAME, Y.GRNNO),0) + OPRECDMTRS) AS RECDMTRS, BALPCS AS BALPCS, ROUND((CASE WHEN ACCEPTEDMTRS > 0 THEN ROUND(ACCEPTEDMTRS - ((ISNULL((SELECT SUM(Y.RECDMTRS)  FROM LOT_VIEW_DETAILS AS Y WHERE Y.LOTNO = T.LOTNO AND Y.YEARID = T.YEARID AND Y.JOBBERNAME = T.JOBBERNAME AND Y.GRNNO = T.GRNNO AND Y.RECDATE <= '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "' GROUP BY Y.LOTNO, Y.YEARID, Y.JOBBERNAME, Y.GRNNO),0) + OPRECDMTRS) + " & SHRINKAGECLAUSE & "),2) ELSE TOTALMTRS + OPRECDMTRS END),2) AS BALMTRS, (CASE WHEN LOTCOMPLETED = 'TRUE' THEN (" & SHRINKAGECLAUSE & ") ELSE 0 END) AS SHRINKAGE, (CASE WHEN TOTALMTRS > 0 AND (ACCEPTEDPCS - SUM(RECDPCS) <= 0 OR LOTCOMPLETED = 'TRUE') THEN  ROUND((" & SHRINKAGECLAUSE & "/TOTALMTRS )*100 ,2) ELSE 0 END)  AS SHRINKPER, PURRATE, LRNO, LOTNODATE", "", " LOT_VIEW_DETAILS AS T ", WHERECLAUSE & " GROUP BY PARTYNAME, JOBBERNAME,  LOTNO, QUALITY, DESIGN, ITEMNAME, TOTALPCS, TOTALMTRS, SHORTPCS, SHORTMTRS, CHECKPCS, CHECKMTRS, REJPCS, REJMTRS, ACCEPTEDPCS, ACCEPTEDMTRS, BALPCS, CMPID, YEARID, CHALLANNO, CATEGORYNAME, LOTCOMPLETED, FORPROCESS, PURRATE, LRNO, LOTNODATE, GRNNO, OPRECDMTRS")
            Else
                dt = objclsCMST.search(" PARTYNAME, JOBBERNAME,  LOTNO, QUALITY, DESIGN, ITEMNAME, TOTALPCS, TOTALMTRS, SHORTPCS, SHORTMTRS, CHECKPCS, CHECKMTRS, REJPCS, REJMTRS, ACCEPTEDPCS, ACCEPTEDMTRS, CMPID, YEARID, CHALLANNO, CATEGORYNAME, LOTCOMPLETED, FORPROCESS, SUM(RECDPCS) AS RECDPCS, (SUM(RECDMTRS) + OPRECDMTRS) AS RECDMTRS,  SUM(BALPCS) AS BALPCS, ROUND((CASE WHEN ACCEPTEDMTRS > 0 THEN ROUND(ACCEPTEDMTRS - (SUM(RECDMTRS) + " & SHRINKAGECLAUSE & ") - OPRECDMTRS,2) ELSE TOTALMTRS-OPRECDMTRS END),2) AS BALMTRS, (CASE WHEN LOTCOMPLETED = 'TRUE' THEN (" & SHRINKAGECLAUSE & ") ELSE 0 END) AS SHRINKAGE, (CASE WHEN TOTALMTRS > 0 AND (ACCEPTEDPCS - SUM(RECDPCS) <= 0 OR LOTCOMPLETED = 'TRUE') THEN  ROUND( ((" & SHRINKAGECLAUSE & ")/TOTALMTRS )*100 ,2) ELSE 0 END)  AS SHRINKPER, PURRATE, LRNO, LOTNODATE", "", " LOT_VIEW_DETAILS ", WHERECLAUSE & " GROUP BY PARTYNAME, JOBBERNAME,  LOTNO, QUALITY, DESIGN, ITEMNAME, TOTALPCS, TOTALMTRS, SHORTPCS, SHORTMTRS, CHECKPCS, CHECKMTRS, REJPCS, REJMTRS, ACCEPTEDPCS, ACCEPTEDMTRS, CMPID, YEARID, CHALLANNO, CATEGORYNAME, LOTCOMPLETED, FORPROCESS, PURRATE, LRNO, LOTNODATE, OPRECDMTRS")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Lot Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Lot Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lot Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Lot Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LotGridreport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
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