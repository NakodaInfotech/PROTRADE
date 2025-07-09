
Imports BL

Public Class DefaultScreentype

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean
    Public TEMPDEFAULT As Boolean
    Dim regabbr, reginitial As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub DefaultRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim objcmn As New ClsCommon
            Dim DT As New DataTable
            DT = objcmn.search("DTYPE_PURSCREENTYPE AS SCREENTYPE", "", "DEFAULTPURSCREENTYPE INNER JOIN REGISTERMASTER ON DTYPE_PURREGID = REGISTER_ID ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND DTYPE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT = objcmn.Execute_Any_String(" UPDATE DEFAULTPURSCREENTYPE SET DTYPE_PURSCREENTYPE = '" & CMBTYPE.Text.Trim & "' FROM DEFAULTPURSCREENTYPE INNER JOIN REGISTERMASTER ON DTYPE_PURREGID = REGISTER_ID WHERE REGISTER_NAME = '" & cmbregister.Text & "' AND REGISTER_YEARID = " & YearId, "", "")
            Else
                DT = objcmn.Execute_Any_String(" INSERT INTO DEFAULTPURSCREENTYPE VALUES((SELECT REGISTER_ID FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_YEARID = " & YearId & "),'" & CMBTYPE.Text.Trim & "'," & CmpId & "," & Userid & "," & YearId & ")", "", "")
            End If
            MsgBox("Updated Successfully!")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type='PURCHASE' ")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_type='" & CMBTYPE.Text.Trim & "' and  register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        'Try
        '    If cmbregister.Text.Trim.Length > 0 And edit = False Then
        '        cmbregister.Text = UCase(cmbregister.Text)
        '        Dim clscommon As New ClsCommon
        '        Dim dt As DataTable
        '        dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type='" & CMBTYPE.Text.Trim & "' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
        '        If dt.Rows.Count > 0 Then
        '            regabbr = dt.Rows(0).Item(0).ToString
        '            reginitial = dt.Rows(0).Item(1).ToString
        '            TempID = dt.Rows(0).Item(2)
        '            'cmbregister.Enabled = False
        '        Else
        '            MsgBox("Register Not Present, Add New from Master Module")
        '            e.Cancel = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        Try
            If CMBTYPE.Text = "PURCHASE" Then
                fillregister(cmbregister, " and register_type='PURCHASE' ")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class