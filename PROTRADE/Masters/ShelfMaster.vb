
Imports BL

Public Class ShelfMaster

    Public EDIT As Boolean
    Public TEMPSHELFID As Integer
    Public TEMPSHELFNAME As String = ""

    Private Sub ShelfMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If EDIT = True Then
                Dim OBJDEPT As New ClsShelfMaster
                OBJDEPT.alParaval.Add(TEMPSHELFID)
                OBJDEPT.alParaval.Add(YearId)
                Dim DT As DataTable = OBJDEPT.GETSHELF()
                If DT.Rows.Count > 0 Then
                    txtname.Text = DT.Rows(0).Item("NAME")
                    TEMPSHELFNAME = DT.Rows(0).Item("NAME")
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

            Dim OBJSHELF As New ClsShelfMaster
            OBJSHELF.alParaval.Add(txtname.Text.Trim)
            OBJSHELF.alParaval.Add(txtremarks.Text.Trim)
            OBJSHELF.alParaval.Add(CmpId)
            OBJSHELF.alParaval.Add(Userid)
            OBJSHELF.alParaval.Add(YearId)

            If EDIT = False Then
                Dim INTRES As Integer = OBJSHELF.SAVE()
                MsgBox("Details Added")
            Else
                OBJSHELF.alParaval.Add(TEMPSHELFID)
                Dim INTRES As Integer = OBJSHELF.UPDATE()
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
            txtremarks.Clear()
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
                Dim OBJSHELF As New ClsShelfMaster
                OBJSHELF.alParaval.Add(TEMPSHELFID)
                OBJSHELF.alParaval.Add(YearId)

                Dim intResult As Integer = OBJSHELF.DELETE
                MsgBox("Shelf Deleted Successfully")
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
                If (EDIT = False) Or (EDIT = True And TEMPSHELFNAME.Trim.ToLower <> txtname.Text.Trim.ToLower) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("SHELF_ID AS ID", "", "SHELFMASTER", " AND SHELF_NAME = '" & txtname.Text.Trim & "' AND SHELF_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Shelf Name Already Exists", MsgBoxStyle.Critical)
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