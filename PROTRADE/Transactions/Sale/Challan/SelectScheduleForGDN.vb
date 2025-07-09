
Imports BL
Imports System.Windows.Forms

Public Class SelectScheduleForGDN

    Public DT As New DataTable
    Public PARTYNAME As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectStockJobber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStockJobber_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            'If PARTYNAME <> "" Then WHERE = WHERE & " AND LEDGERS.ACC_CMPNAME  = '" & PARTYNAME & "'"

            Dim OBJCMN As New ClsCommon()
            'Dim DT As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(SCHEDULEMASTER_DESC.SCH_NO, 0) AS SRNO, ISNULL(SCHEDULEMASTER_DESC.SCH_GRIDSCHNO, 0) AS GRIDSCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(SCHEDULEMASTER_DESC.SCH_QTY, 0) AS QTY, ISNULL(SCHEDULEMASTER_DESC.SCH_MTRS, 0) AS MTRS, ISNULL(SCHEDULEMASTER_DESC.SCH_RECDQTY, 0) AS RECDQTY, ISNULL(SCHEDULEMASTER_DESC.SCH_TYPE, '') AS TYPE ", "", "  SCHEDULEMASTER INNER JOIN SCHEDULEMASTER_DESC ON SCHEDULEMASTER.SCH_NO = SCHEDULEMASTER_DESC.SCH_NO AND SCHEDULEMASTER.SCH_YEARID = SCHEDULEMASTER_DESC.SCH_YEARID INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id ", " AND LEDGERS.ACC_CMPNAME  = '" & PARTYNAME & "' AND SCHEDULEMASTER.SCH_YEARID = " & YearId)
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ISNULL(SCHEDULEMASTER_DESC.SCH_QTY, 0))- SUM(ISNULL(SCHEDULEMASTER_DESC.SCH_RECDQTY, 0)) AS QTY, SUM(ISNULL(SCHEDULEMASTER_DESC.SCH_MTRS, 0)) AS MTRS, ISNULL(SCHEDULEMASTER_DESC.SCH_RECDQTY, 0) AS RECDQTY, ISNULL(SCHEDULEMASTER_DESC.SCH_TYPE, '') AS TYPE ", "", " SCHEDULEMASTER INNER JOIN SCHEDULEMASTER_DESC ON SCHEDULEMASTER.SCH_NO = SCHEDULEMASTER_DESC.SCH_NO AND SCHEDULEMASTER.SCH_YEARID = SCHEDULEMASTER_DESC.SCH_YEARID INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id ", " AND LEDGERS.ACC_CMPNAME  = '" & PARTYNAME & "' AND SCHEDULEMASTER.SCH_YEARID = " & YearId & " GROUP BY ITEMMASTER.item_name, COLORMASTER.COLOR_name, SCHEDULEMASTER_DESC.SCH_RECDQTY, SCHEDULEMASTER_DESC.SCH_TYPE HAVING SUM(ISNULL(SCHEDULEMASTER_DESC.SCH_QTY, 0))- SUM(ISNULL(SCHEDULEMASTER_DESC.SCH_RECDQTY, 0)) > 0")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class