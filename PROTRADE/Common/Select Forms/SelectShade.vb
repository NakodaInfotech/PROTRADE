Imports BL

Public Class SelectShade

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPNAME As String
    Public FRMSTRING As String

    Private Sub CMDEXIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectShade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID("")
            cmbname.Text = "Name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  ISNULL(COLOR_NAME, '') AS COLOR, COLOR_ID AS ID", "", "  COLORMASTER", WHERECLAUSE & "  AND COLORMASTER.COLOR_CMPID = " & CmpId & " AND COLORMASTER.COLOR_LOCATIONID = " & Locationid & " AND COLORMASTER.COLOR_YEARID = " & YearId & " order by COLORMASTER.COLOR_NAME ")
            GRIDCOLOR.DataSource = DT

            GRIDCOLOR.Columns(0).HeaderText = "Color"
            GRIDCOLOR.Columns(0).Width = 220
            GRIDCOLOR.Columns(1).Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDCOLOR.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDCOLOR.Rows(GRIDCOLOR.SelectedRows(0).Index).Cells(0).Value
            Else
                TEMPNAME = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOLOR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOLOR.CellDoubleClick
        Try
            If GRIDCOLOR.Rows.Count > 0 Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDCOLOR.CurrentRow.Cells(0).Value, GRIDCOLOR.CurrentRow.Cells(1).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal ID As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDCOLOR.RowCount > 0) Then
                Dim objCOLORmaster As New CategoryMaster
                objCOLORmaster.MdiParent = MDIMain
                objCOLORmaster.edit = editval
                objCOLORmaster.frmString = "COLOR"
                objCOLORmaster.TempName = name
                objCOLORmaster.TempID = ID
                objCOLORmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.TextChanged
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND COLORMASTER.COLOR_NAME like '%" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND COLORMASTER.COLOR_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If

                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOLOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Enter And GRIDCOLOR.RowCount > 0 Then

                If GRIDCOLOR.SelectedRows.Count > 0 Then
                    TEMPNAME = GRIDCOLOR.Rows(GRIDCOLOR.SelectedRows(0).Index).Cells(0).Value
                Else
                    TEMPNAME = ""
                End If
                Me.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class