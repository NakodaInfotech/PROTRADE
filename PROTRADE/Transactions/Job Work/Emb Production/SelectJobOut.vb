Imports BL

Public Class SelectJobOut

    Public DT As New DataTable

    Private Sub CMDEXIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectJobOut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectJobOut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, JOBOUT.JO_no AS JONO, JOBOUT.JO_date AS DATE, ISNULL(JOBOUT.JO_LOTNO, '') AS LOTNO, JOBOUT_DESC.JO_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(JOBOUT_DESC.JO_MTRS, 0) AS MTRS, ISNULL(ITEM_FOLD,0) AS STITCHES, ISNULL(JOBOUT_DESC.JO_RECDFRAMES, 0) AS RECDFRAMES ", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ISNULL(JO_EMBPRODDONE,0) = 0 AND JOBOUT.JO_YEARID = " & YearId & " AND ISNULL(JOBOUT.JO_CLOSE,0) = 0 order by JOBOUT.JO_NO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon

            DT.Columns.Add("JONO")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("SHADE")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("STITCHES")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("JONO")), Val(dtrow("GRIDSRNO")), dtrow("ITEMNAME"), dtrow("SHADE"), Val(dtrow("MTRS")), Val(dtrow("STITCHES")))
                    Exit For
                End If
            Next

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

End Class