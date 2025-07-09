
Imports BL

Public Class ChangeReminderDays

    Public EDIT As Boolean = True

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ChangeCheckinDays_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            clear()
            If EDIT = True Then
                Dim OBJREM As New ClsChangeReminderDays()
                Dim DT As DataTable = OBJREM.GETREMINDERDAYS(CmpId)
                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows
                        TXTDAYS.Text = Val(Convert.ToString(dr("DAYS")))
                    Next
                Else
                    EDIT = False
                    clear()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub clear()
        EP.Clear()
        TXTDAYS.Clear()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTDAYS.Text.Trim.Length = 0 Or Val(TXTDAYS.Text.Trim) <= 0 Then
            EP.SetError(TXTDAYS, "Days Cannot Be Zero")
            bln = False
        End If
        Return bln
    End Function

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(Val(TXTDAYS.Text.Trim))
            alParaval.Add(CmpId)

            Dim objAccountsMaster As New ClsChangeReminderDays
            objAccountsMaster.alParaval = alParaval

            If edit = False Then
                IntResult = objAccountsMaster.SAVE()
                MsgBox("Details Added")
            Else
                IntResult = objAccountsMaster.UPDATE()
                MsgBox("Details Updated")
            End If
            edit = False
            clear()
            TXTDAYS.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class