
Imports BL

Public Class SelectProgram

    Public PARTYNAME As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectProgram_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectProgram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Dim OPWHERE As String = ""
            Cursor.Current = Cursors.WaitCursor

            If PARTYNAME <> "" Then
                WHERE = WHERE & " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & PARTYNAME & "'"
                OPWHERE = OPWHERE & " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & PARTYNAME & "'"
            End If


            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search("CAST (0 AS BIT) AS CHK,*", "", " (SELECT  PROGRAMMASTER.PROGRAM_NO AS PROGNO, PROGRAMMASTER.PROGRAM_DATE AS DATE, PROGRAMMASTER_DESC.PROGRAM_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, (PROGRAMMASTER_DESC.PROGRAM_PCS - PROGRAMMASTER_DESC.PROGRAM_RECDPCS) AS MTRS, 'PROGRAM' AS TYPE, ISNULL(ACC_CMPNAME,'') AS NAME, ISNULL(PROGRAMMASTER_DESC.PROGRAM_LOTNO,'') AS LOTNO FROM PROGRAMMASTER INNER JOIN PROGRAMMASTER_DESC ON PROGRAMMASTER.PROGRAM_NO = PROGRAMMASTER_DESC.PROGRAM_NO AND PROGRAMMASTER.PROGRAM_YEARID = PROGRAMMASTER_DESC.PROGRAM_YEARID INNER JOIN ITEMMASTER ON PROGRAMMASTER_DESC.PROGRAM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PROGRAMMASTER_DESC.PROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PROGRAMMASTER_DESC.PROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS ON PROGRAMMASTER.PROGRAM_LEDGERID = LEDGERS.Acc_id WHERE PROGRAM_STATUS <> 'CANCEL' AND (PROGRAM_PCS - PROGRAM_RECDPCS) > 0 AND PROGRAMMASTER.PROGRAM_YEARID = " & YearId & WHERE & " UNION ALL SELECT        OPENINGPROGRAMMASTER.OPPROGRAM_NO, OPENINGPROGRAMMASTER.OPPROGRAM_DATE, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRIDSRNO, ITEMMASTER.item_name, ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_name,''), (OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PCS - OPENINGPROGRAMMASTER_DESC.OPPROGRAM_RECDPCS) AS MTRS, 'OPENING' AS TYPE, ISNULL(ACC_CMPNAME,'') AS NAME, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_LOTNO,'') AS LOTNO FROM  OPENINGPROGRAMMASTER INNER JOIN OPENINGPROGRAMMASTER_DESC ON OPENINGPROGRAMMASTER.OPPROGRAM_NO = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_NO AND OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_YEARID INNER JOIN ITEMMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS ON OPENINGPROGRAMMASTER.OPPROGRAM_LEDGERID = LEDGERS.Acc_id WHERE OPPROGRAM_STATUS <> 'CANCEL' AND (OPPROGRAM_PCS - OPPROGRAM_RECDPCS) > 0 AND OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = " & YearId & OPWHERE & ") AS T", " ORDER BY T.DATE, T.PROGNO, T.GRIDSRNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
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
            DT.Columns.Add("DATE")
            DT.Columns.Add("NAME")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("DESIGN")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("PROGNO")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("TYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("DATE"), dtrow("NAME"), dtrow("ITEMNAME"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("MTRS")), Val(dtrow("PROGNO")), Val(dtrow("GRIDSRNO")), dtrow("TYPE"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class