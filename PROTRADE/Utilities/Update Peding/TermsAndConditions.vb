
Imports BL

Public Class TermsAndConditions


    Private Sub ShelfMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim OBJDEPT As New ClsTermsAndConditions
            OBJDEPT.alParaval.Add(CmpId)
            Dim DT As DataTable = OBJDEPT.GETTERMS()
            If DT.Rows.Count > 0 Then
                txtremarks.Text = DT.Rows(0).Item("REMARKS")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim OBJRACK As New ClsTermsAndConditions
            OBJRACK.alParaval.Add(txtremarks.Text.Trim)
            OBJRACK.alParaval.Add(CmpId)

            'If EDIT = False Then
            Dim INTRES As Integer = OBJRACK.SAVE()
            MsgBox("Details Added")
            CLEAR()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        Try
            txtremarks.Clear()
            txtremarks.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            Dim OBJRACK As New ClsTermsAndConditions
            OBJRACK.alParaval.Add(CmpId)

            Dim intResult As Integer = OBJRACK.DELETE
            MsgBox("Terms And Conditions Deleted Successfully")
            CLEAR()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class