
Imports BL

Public Class DefaultUnit

    Sub FILLCMB()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DTUNIT As DataTable = OBJCMN.search(" CASE WHEN ISNULL(DEFAULTSTOCKUNIT.UNIT_ABBR,'') = '' THEN  CAST (0 AS BIT) ELSE  CAST (1 AS BIT) END AS CHK, UNITMASTER.UNIT_ABBR AS UNIT ", " ", " UNITMASTER LEFT OUTER JOIN DEFAULTSTOCKUNIT ON UNITMASTER.UNIT_ABBR = DEFAULTSTOCKUNIT.UNIT_ABBR ", " AND UNITMASTER.UNIT_YEARID = '" & YearId & "' ORDER BY UNITMASTER.UNIT_ABBR")
            gridbilldetailsunit.DataSource = DTUNIT
            If DTUNIT.Rows.Count > 0 Then
                gridbillunit.FocusedRowHandle = gridbillunit.RowCount - 1
                gridbillunit.TopRowIndex = gridbillunit.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefaultUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefaultUnit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CHKSELECTUNIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTUNIT.CheckedChanged
        Try
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                dtrow("CHK") = CHKSELECTUNIT.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Dim ALPARAVAL As New ArrayList

            Dim OBJDEFUNIT As New ClsDefaultUnit

            Dim UNIT As String = ""
            gridbillunit.ClearColumnsFilter()
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If UNIT = "" Then
                        UNIT = dtrow("UNIT")
                    Else
                        UNIT = UNIT & "|" & dtrow("UNIT")
                    End If
                End If
            Next

            OBJDEFUNIT.alParaval.Add(UNIT)
            Dim DT As Integer = OBJDEFUNIT.DEFAULTSTOCKUNIT()
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class