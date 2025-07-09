
Imports BL
Imports System.Windows.Forms

Public Class Cmppassword

    Public alParaval As ArrayList
    Public EDIT As Boolean
    Public TEMPCMPNAME As String

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Try
            Dim objExciseInf As New CmpExciseInf
            Me.Hide()
            objExciseInf.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Try
            Ep.Clear()
            If cmdback.Visible = True Then
                If (txtpassword.Text.Trim <> "" Or txtretypepassword.Text.Trim <> "") And txtpassword.Text.Trim <> txtretypepassword.Text.Trim Then
                    Ep.SetError(txtpassword, "Password Incorrect")
                    Ep.SetError(txtretypepassword, "Password Incorrect")
                    Exit Sub
                End If

                alParaval.Add(txtpassword.Text)


                Me.Hide()
                YearMaster.alParaval = alParaval
                YearMaster.EDIT = EDIT
                YearMaster.TEMPCMPNAME = TEMPCMPNAME
                YearMaster.FRMSTRING = ""
                YearMaster.ShowDialog()
            Else


                Dim objcmn As New ClsCommon
                Dim dt As New DataTable
                dt = objcmn.search("cmp_password", "", "CMPMASTER", " AND CMP_ID = " & CmpId)
                If dt.Rows.Count > 0 Then


                    If dt.Rows(0).Item(0).ToString <> txtpassword.Text.Trim Then
                        Ep.SetError(txtpassword, "Password Incorrect")
                        txtpassword.Clear()
                        txtpassword.Focus()
                        Exit Sub
                    Else

                        dt = objcmn.search(" DEPARTMENT_NAME AS DEPARTMENT", "", " USERMASTER INNER JOIN DEPARTMENTMASTER ON DEPARTMENT_ID = USER_DEPARTMENTID", " AND USER_NAME = '" & UserName & "' AND USER_CMPID = " & CmpId & " AND USER_LOCATIONID = " & Locationid & " AND USER_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then DEPARTMENTNAME = dt.Rows(0).Item("DEPARTMENT")
                        MDIMain.Show()
                        MDIMain.Refresh()
                

                        Me.Close()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmppassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmppassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            txtpassword.Clear()
            If EDIT = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                DT = OBJCMN.search("CMP_PASSWORD", "", " CMPMASTER", " AND CMP_NAME = '" & TEMPCMPNAME & "'")
                Dim DTROW As DataRow = DT.Rows(0)

                txtpassword.Text = DTROW(0).ToString
                txtretypepassword.Text = txtpassword.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter And cmdback.Visible = False Then Call cmdnext_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class