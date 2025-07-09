
Imports System.ComponentModel
Imports BL

Public Class UserGodownTagging

    Public EDIT As Boolean
    Public TEMPUSER As String

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim OBJRACK As New ClsUserGodownTagging

            OBJRACK.alParaval.Add(CMBUSER.Text.Trim)
            OBJRACK.alParaval.Add(CMBGODOWN.Text.Trim)
            OBJRACK.alParaval.Add(CmpId)

            If EDIT = False Then
                Dim INTRES As Integer = OBJRACK.SAVE()
                MsgBox("Details Added")
            Else
                OBJRACK.alParaval.Add(TEMPUSER)
                Dim INTRES As Integer = OBJRACK.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            CLEAR()
            CMBUSER.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBUSER.Text.Trim = "" Then
                EP.SetError(CMBUSER, "Enter Proper User")
                BLN = False
            End If
            If CMBGODOWN.Text.Trim = "" Then
                EP.SetError(CMBGODOWN, "Enter Proper GoDown")
                BLN = False
            End If


            'IF SAME USER IS TAGGED THEN DONT ALLOW
            If (EDIT = False) Or (EDIT = True And LCase(TEMPUSER) <> LCase(CMBUSER.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("GODOWN_USERID AS USERID", "", " USERGODOWNTAGGING INNER JOIN USERMASTER ON GODOWN_USERID = USER_ID", " AND USER_NAME = '" & CMBUSER.Text.Trim & "' AND GODOWN_CMPID = " & CmpId)
                If DT.Rows.Count > 0 Then
                    EP.SetError(CMBUSER, "User Already Tagged")
                    BLN = False
                End If
            End If


                Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub CLEAR()
        Try
            CMBUSER.Text = ""
            CMBGODOWN.Text = ""
            CMBUSER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                Dim OBJRACK As New ClsUserGodownTagging
                OBJRACK.alParaval.Add(TEMPUSER)
                OBJRACK.alParaval.Add(CmpId)

                Dim intResult As Integer = OBJRACK.DELETE
                MsgBox("GodownTagging Deleted Successfully")
                CLEAR()
                EDIT = False
                CMBUSER.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UserGodownTagging_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If EDIT = True Then
                fillcmb()
                Dim OBJDEPT As New ClsUserGodownTagging

                OBJDEPT.alParaval.Add(TEMPUSER)
                OBJDEPT.alParaval.Add(CmpId)
                Dim DT As DataTable = OBJDEPT.GETUSER()
                If DT.Rows.Count > 0 Then
                    TEMPUSER = DT.Rows(0).Item("USER")
                    CMBUSER.Text = DT.Rows(0).Item("USER")
                    CMBGODOWN.Text = DT.Rows(0).Item("GODOWN")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBUSER.Text.Trim = "" Then fillUSER(CMBUSER, EDIT)
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Enter(sender As Object, e As EventArgs) Handles CMBUSER.Enter
        Try
            If CMBUSER.Text.Trim = "" Then fillUSER(CMBUSER, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validating(sender As Object, e As CancelEventArgs) Handles CMBUSER.Validating
        Try
            If CMBUSER.Text.Trim <> "" Then USERvalidate(CMBUSER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOBOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class