
Imports BL

Public Class TermMaster

    Public EDIT As Boolean
    Public TEMPID As Integer
    Public TEMPNAME As String = ""

    Private Sub ShelfMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If EDIT = True Then
                Dim OBJDEPT As New ClsTermMaster
                OBJDEPT.alParaval.Add(TEMPID)
                OBJDEPT.alParaval.Add(YearId)
                Dim DT As DataTable = OBJDEPT.GETTERM()
                If DT.Rows.Count > 0 Then
                    txtname.Text = DT.Rows(0).Item("NAME")
                    TEMPNAME = DT.Rows(0).Item("NAME")
                    TXTCRDAYS.Text = Val(DT.Rows(0).Item("CRDAYS"))
                    TXTOTHERPER.Text = Val(DT.Rows(0).Item("OTHERPER"))
                    txtremarks.Text = DT.Rows(0).Item("REMARKS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShelfMaster_KEYDOWN(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If txtname.Text.Trim = "" Then
                EP.SetError(txtname, "Enter Proper Name")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim OBJRACK As New ClsTermMaster
            OBJRACK.alParaval.Add(txtname.Text.Trim)
            OBJRACK.alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            OBJRACK.alParaval.Add(Val(TXTOTHERPER.Text.Trim))
            OBJRACK.alParaval.Add(txtremarks.Text.Trim)
            OBJRACK.alParaval.Add(CmpId)
            OBJRACK.alParaval.Add(Userid)
            OBJRACK.alParaval.Add(YearId)

            If EDIT = False Then
                Dim INTRES As Integer = OBJRACK.SAVE()
                MsgBox("Details Added")
            Else
                OBJRACK.alParaval.Add(TEMPID)
                Dim INTRES As Integer = OBJRACK.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            CLEAR()
            txtname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        Try
            txtname.Clear()
            TXTCRDAYS.Clear()
            txtremarks.Clear()
            TXTOTHERPER.Clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                Dim OBJRACK As New ClsTermMaster
                OBJRACK.alParaval.Add(TEMPID)
                OBJRACK.alParaval.Add(YearId)

                Dim intResult As Integer = OBJRACK.DELETE
                MsgBox("Term Deleted Successfully")
                CLEAR()
                EDIT = False
                txtname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPNAME.Trim.ToLower <> txtname.Text.Trim.ToLower) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("TERM_ID AS ID", "", "TERMMASTER", " AND TERM_NAME = '" & txtname.Text.Trim & "' AND TERM_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Term Name Already Exists", MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class