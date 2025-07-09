
Imports BL

Public Class LedgerDifference

    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub LedgerDifference_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LedgerDifference_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If FRMSTRING = "RECEIVABLE" Then
                dt = objclsCMST.search("DISTINCT *", "", " (SELECT LEDGERS.Acc_cmpname AS NAME,  (ISNULL(TRIALBALANCE.Dr,0) - ISNULL(TRIALBALANCE.Cr,0)) AS LEDGERBAL, SUM(OUTSTANDINGREC.BALANCE) AS OUTBALANCE FROM LEDGERS LEFT OUTER JOIN OUTSTANDINGREC ON LEDGERS.Acc_ID = OUTSTANDINGREC.LEDGERID LEFT OUTER JOIN TRIALBALANCE ON LEDGERS.Acc_CMPNAME = TRIALBALANCE.NAME AND LEDGERS.Acc_YEARID = TRIALBALANCE.YEARID INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.GROUP_ID WHERE LEDGERS.Acc_yearid = " & YearId & " AND GROUPMASTER.group_secondary = 'Sundry Debtors'  GROUP BY LEDGERS.Acc_cmpname, (ISNULL(TRIALBALANCE.Dr,0) - ISNULL(TRIALBALANCE.Cr,0))  HAVING ISNULL(SUM(OUTSTANDINGREC.BALANCE),0) <> (ISNULL(TRIALBALANCE.Dr,0) - ISNULL(TRIALBALANCE.Cr,0))  UNION ALL SELECT NAME, 0 AS LEDGERBAL, ROUND((CASE WHEN DEBIT>0 THEN DEBIT ELSE CREDIT END),2) AS OUTBALANCE FROM DIFFERENCEINOPENING WHERE YEARID = " & YearId & " AND SECONDARY = 'Sundry Debtors' and (ROUND(DEBIT,2)>0 OR ROUND(CREDIT,2) > 0)) AS T ", " ORDER BY T.NAME ")
            Else
                dt = objclsCMST.search("DISTINCT *", "", " (SELECT LEDGERS.Acc_cmpname AS NAME,  (ISNULL(TRIALBALANCE.Cr,0) - ISNULL(TRIALBALANCE.Dr,0)) AS LEDGERBAL, SUM(OUTSTANDINGPAY.BALANCE) AS OUTBALANCE FROM LEDGERS LEFT OUTER JOIN OUTSTANDINGPAY ON LEDGERS.Acc_ID = OUTSTANDINGPAY.LEDGERID LEFT OUTER JOIN TRIALBALANCE ON LEDGERS.Acc_CMPNAME = TRIALBALANCE.NAME AND LEDGERS.Acc_YEARID = TRIALBALANCE.YEARID INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.GROUP_ID WHERE LEDGERS.Acc_yearid = " & YearId & " AND GROUPMASTER.group_secondary = 'Sundry Creditors'  GROUP BY LEDGERS.Acc_cmpname, (ISNULL(TRIALBALANCE.Cr,0) - ISNULL(TRIALBALANCE.Dr,0))  HAVING ISNULL(SUM(OUTSTANDINGPAY.BALANCE),0) <> (ISNULL(TRIALBALANCE.Cr,0) - ISNULL(TRIALBALANCE.Dr,0))  UNION ALL SELECT NAME, 0 AS LEDGERBAL, ROUND((CASE WHEN DEBIT>0 THEN DEBIT ELSE CREDIT END),2) AS OUTBALANCE FROM DIFFERENCEINOPENING WHERE YEARID = " & YearId & " AND SECONDARY = 'Sundry Creditors' and (ROUND(DEBIT,2)>0 OR ROUND(CREDIT,2) > 0)) AS T ", " ORDER BY T.NAME ")
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

            Dim PATH As String = Application.StartupPath & "\Ledger Difference.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Ledger Difference"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Difference", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Ledger Diff Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class