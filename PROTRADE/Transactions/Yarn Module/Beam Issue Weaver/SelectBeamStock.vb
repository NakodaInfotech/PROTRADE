Imports BL

Public Class SelectBeamStock
    Public DT As New DataTable
    Public TEMPGODOWNNAME, WHERECLAUSE As String
    Dim BEAMSELECTED As Boolean
    Dim BEAMNO As Integer
    Public ALLOWEDBEAMS As Integer

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon()
            WHERE = WHERE & " " & WHERECLAUSE
            If TEMPGODOWNNAME <> "" Then WHERE = WHERE & " AND BEAMSTOCK.GODOWN='" & TEMPGODOWNNAME & "' "
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK , BEAMSTOCK.NAME, BEAMSTOCK.MILLNAME,BEAMSTOCK.TYPE,BEAMSTOCK.BEAMNAME, BEAMSTOCK.BEAMNO, BEAMSTOCK.CUT, BEAMSTOCK.WT, BEAMSTOCK.WTCUT, BEAMSTOCK.RECNO AS FROMNO, BEAMSTOCK.RECSRNO AS FROMSRNO, BEAMSTOCK.ENDS, BEAMSTOCK.TAPLINE", "", "BEAMSTOCK", WHERECLAUSE & " AND BEAMSTOCK.YEARID = " & YearId & " ORDER BY RECNO, RECSRNO")
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

            If ClientName = "SASHWINKUMAR" Then
                Dim SELECTEDBEAMS As Integer = 0
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        SELECTEDBEAMS += 1
                        If SELECTEDBEAMS > ALLOWEDBEAMS Then
                            MsgBox("Pls select Only " & ALLOWEDBEAMS & " Beams!")
                            Exit Sub
                        End If
                    End If
                Next
            End If

            DT.Columns.Add("BEAMNAME")
            DT.Columns.Add("BEAMNO")
            DT.Columns.Add("ENDS")
            DT.Columns.Add("TAPLINE")
            DT.Columns.Add("CUT")
            DT.Columns.Add("WT")
            DT.Columns.Add("WTCUT")
            DT.Columns.Add("FROMNO")
            DT.Columns.Add("FROMSRNO")
            DT.Columns.Add("TYPE")
            DT.Columns.Add("SIZERNAME")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("BEAMNAME"), dtrow("BEAMNO"), dtrow("ENDS"), dtrow("TAPLINE"), dtrow("CUT"), dtrow("WT"), dtrow("WTCUT"), dtrow("FROMNO"), dtrow("FROMSRNO"), dtrow("TYPE"), dtrow("NAME"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectBeamStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectBeamStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub gridbill_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Space Then
                Dim DTROW As DataRow = gridbill.GetFocusedDataRow()
                DTROW("CHK") = Not DTROW("CHK")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class