
Imports BL
Imports System.Windows.Forms

Public Class SelectStockJobber

    Public DT As New DataTable
    Public JOBBER As String = ""
    Public TYPE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

            Dim OBJCMN As New ClsCommon()
            Dim DT As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK , SRNO,  PIECETYPE, ITEMNAME, QUALITY, COLOR, DESIGNNO, JOBBERNAME, UNIT, PCS, MTRS, FROMNO, FROMSRNO, TYPE", "", " PACKING_VIEW", " AND MTRS > 0 AND JOBBERNAME='" & JOBBER & "' AND YEARID = " & YearId)
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

            Dim n As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If n <> "" Then
                        If n = (dtrow("JOBBERNAME")) Then
                            GoTo Line1
                        Else
                            MsgBox("Pls select same jobbername !")
                            Exit Sub
                        End If
                    End If
Line1:
                    n = (dtrow("JOBBERNAME"))
                End If
            Next

            DT.Columns.Add("PIECETYPE")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("DESIGNNO")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("PCS")
            DT.Columns.Add("CUT")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("FROMNO")
            DT.Columns.Add("FROMSRNO")
            DT.Columns.Add("TYPE")
            DT.Columns.Add("BARCODE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("PIECETYPE"), dtrow("ITEMNAME"), dtrow("QUALITY"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("PCS")), Val(dtrow("MTRS")), Val(dtrow("MTRS")), Val(dtrow("FROMNO")), Val(dtrow("FROMSRNO")), dtrow("TYPE"), "")
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