
Imports BL

Public Class RecFromPackFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RecFromPackFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then FILLCONTRACT(CMBCONTRACTOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RecFromPackFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJRECPACK As New MATRECDesign
            OBJRECPACK.MdiParent = MDIMain
            OBJRECPACK.WHERECLAUSE = "  {RECPACKING.REC_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJRECPACK.PERIOD = " CONTRACTOR WISE SUMMARY " & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJRECPACK.WHERECLAUSE = OBJRECPACK.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJRECPACK.PERIOD = " CONTRACTOR WISE SUMMARY " & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBCONTRACTOR.Text <> "" Then OBJRECPACK.WHERECLAUSE = OBJRECPACK.WHERECLAUSE & " and {CONTRACTMASTER.CONTRACT_NAME}='" & CMBCONTRACTOR.Text.Trim & "'"

            If RDBCONTRACTOR.Checked = True Then
                OBJRECPACK.FRMSTRING = "CONTRACTORWISE"
            End If

            OBJRECPACK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class