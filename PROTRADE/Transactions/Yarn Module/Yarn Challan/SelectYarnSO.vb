
Imports BL

Public Class SelectYarnSO

    Public PARTYNAME As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectYarnPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectYarnPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = ""
            If PARTYNAME <> "" Then where = where & " AND NAME = '" & PARTYNAME & "'"
            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable = objclspreq.search("*", "", " (SELECT YARNSALEORDER.YSO_NO AS SONO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, YARNSALEORDER.YSO_DATE AS DATE, YARNSALEORDER_DESC.YSO_GRIDSRNO AS GRIDSRNO, ISNULL(YARNQUALITYMASTER.YARN_name, '') AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(YARNSALEORDER_DESC.YSO_DESC, '') AS GRIDREMARKS, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, (YARNSALEORDER_DESC.YSO_BAGS - YARNSALEORDER_DESC.YSO_RECDBAGS) AS BAGS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ROUND(YARNSALEORDER_DESC.YSO_WT - YARNSALEORDER_DESC.YSO_RECDWT, 2) AS WT, YARNSALEORDER.YSO_DUEDATE AS DUEDATE, ISNULL(GROUPMASTER.group_name, '') AS GROUPNAME, ISNULL(YARNSALEORDER_DESC.YSO_RATE, 0) AS RATE, ISNULL(YARNSALEORDER.YSO_REFNO, '') AS ORDERNO, 'YARNSALEORDER' AS [TYPE] FROM YARNSALEORDER INNER JOIN YARNSALEORDER_DESC ON YARNSALEORDER.YSO_YEARID = YARNSALEORDER_DESC.YSO_YEARID AND YARNSALEORDER.YSO_NO = YARNSALEORDER_DESC.YSO_NO INNER JOIN LEDGERS ON YARNSALEORDER.YSO_LEDGERID = LEDGERS.Acc_id INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN UNITMASTER ON YARNSALEORDER_DESC.YSO_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON YARNSALEORDER_DESC.YSO_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN YARNQUALITYMASTER ON YARNSALEORDER_DESC.YSO_YARNQUALITYID = YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN DESIGNMASTER ON YARNSALEORDER_DESC.YSO_DESIGNID = DESIGNMASTER.DESIGN_id WHERE YARNSALEORDER_DESC.YSO_CLOSED='False' AND ROUND(YARNSALEORDER_DESC.YSO_WT - YARNSALEORDER_DESC.YSO_RECDWT,2) > 0 AND YARNSALEORDER.YSO_YEARID = " & YearId & " UNION ALL SELECT OPENINGYARNSALEORDER.OYSO_NO AS SONO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, OPENINGYARNSALEORDER.OYSO_DATE AS DATE, OPENINGYARNSALEORDER_DESC.OYSO_GRIDSRNO AS GRIDSRNO, ISNULL(YARNQUALITYMASTER.YARN_name, '') AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(OPENINGYARNSALEORDER_DESC.OYSO_DESC, '') AS GRIDREMARKS, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, (OPENINGYARNSALEORDER_DESC.OYSO_BAGS - OPENINGYARNSALEORDER_DESC.OYSO_RECDBAGS) AS BAGS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ROUND(OPENINGYARNSALEORDER_DESC.OYSO_WT - OPENINGYARNSALEORDER_DESC.OYSO_RECDWT, 2) AS WT, OPENINGYARNSALEORDER.OYSO_DUEDATE AS DUEDATE, ISNULL(GROUPMASTER.group_name, '') AS GROUPNAME, ISNULL(OPENINGYARNSALEORDER_DESC.OYSO_RATE, 0) AS RATE, ISNULL(OPENINGYARNSALEORDER.OYSO_REFNO, '') AS ORDERNO, 'OPENING' AS [TYPE] FROM OPENINGYARNSALEORDER INNER JOIN OPENINGYARNSALEORDER_DESC ON OPENINGYARNSALEORDER.OYSO_YEARID = OPENINGYARNSALEORDER_DESC.OYSO_YEARID AND OPENINGYARNSALEORDER.OYSO_NO = OPENINGYARNSALEORDER_DESC.OYSO_NO INNER JOIN LEDGERS ON OPENINGYARNSALEORDER.OYSO_LEDGERID = LEDGERS.Acc_id INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN UNITMASTER ON OPENINGYARNSALEORDER_DESC.OYSO_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON OPENINGYARNSALEORDER_DESC.OYSO_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN YARNQUALITYMASTER ON OPENINGYARNSALEORDER_DESC.OYSO_YARNQUALITYID = YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN DESIGNMASTER ON OPENINGYARNSALEORDER_DESC.OYSO_DESIGNID = DESIGNMASTER.DESIGN_id WHERE OPENINGYARNSALEORDER_DESC.OYSO_CLOSED='False' AND ROUND(OPENINGYARNSALEORDER_DESC.OYSO_WT - OPENINGYARNSALEORDER_DESC.OYSO_RECDWT,2) > 0 AND OPENINGYARNSALEORDER.OYSO_YEARID = " & YearId & ") AS T", where & " order by T.DATE, T.SONO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            DT.Columns.Add("SONO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("SODATE")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("DESIGNNO")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("BAGS")
            DT.Columns.Add("WT")
            DT.Columns.Add("DUEDATE")
            DT.Columns.Add("GROUPNAME")
            DT.Columns.Add("RATE")
            DT.Columns.Add("TYPE")

            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                DT.Rows.Add(dtrow("SONO"), dtrow("NAME"), dtrow("DATE"), Val(dtrow("GRIDSRNO")), dtrow("YARNQUALITY"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("BAGS")), Val(dtrow("WT")), dtrow("DUEDATE"), dtrow("GROUPNAME"), Val(dtrow("RATE")), dtrow("TYPE"))
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class