
Imports BL

Public Class SelectYarnStock

    Public DT As New DataTable
    Public GODOWN As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectYarnStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            fillgrid("  AND yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If GODOWN <> "" Then TEMPCONDITION = TEMPCONDITION & " AND GODOWN ='" & GODOWN & "'"
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, YARNQUALITY, CATEGORY, MILLNAME, DESIGNNO, COLOR, LOTNO, LRNO, SUM(ISNULL(CONES,0)) AS CONES, SUM(BAGS) AS BAGS, SUM(WT) AS WT ", "", "  YARNSTOCKVIEW ", TEMPCONDITION & " GROUP BY GODOWN, YARNQUALITY, CATEGORY, MILLNAME, DESIGNNO, COLOR, LOTNO, LRNO HAVING SUM(WT) > 0 ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("YARNQUALITY")
            DT.Columns.Add("MILLNAME")
            DT.Columns.Add("DESIGNNO")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("LRNO")
            DT.Columns.Add("BAGS")
            DT.Columns.Add("WT")
            DT.Columns.Add("CONES")

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("YARNQUALITY"), dtrow("MILLNAME"), dtrow("DESIGNNO"), dtrow("COLOR"), dtrow("LOTNO"), dtrow("LRNO"), Val(dtrow("BAGS")), Val(dtrow("WT")), Val(dtrow("CONES")))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click_1(sender As Object, e As EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles SELECTALL.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = SELECTALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class