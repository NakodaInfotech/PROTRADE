Imports BL

Public Class SelectHSN

    Public STRSEARCH As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPCODE As String
    Public TEMPCODEDESC As String


    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectHSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(HSN_CODE, '') AS CODE, ISNULL(HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(HSN_CGST, 0) AS CGST, ISNULL(HSN_SGST, 0) AS SGST, ISNULL(HSN_IGST, 0) AS IGST ", "", " HSNMASTER ", STRSEARCH & WHERECLAUSE & " AND HSNMASTER.HSN_CMPID = " & CmpId & "  AND HSNMASTER.HSN_YEARID = " & YearId & " order by HSNMASTER.HSN_CODE")
            GRIDHSN.DataSource = DT

            GRIDHSN.Columns(0).HeaderText = "CODE"
            GRIDHSN.Columns(0).Width = 260

            GRIDHSN.Columns(1).HeaderText = "ITEMDESC"
            GRIDHSN.Columns(1).Width = 100

            GRIDHSN.Columns(2).HeaderText = "CGST"
            GRIDHSN.Columns(2).Width = 150

            GRIDHSN.Columns(3).HeaderText = "SGST"
            GRIDHSN.Columns(3).Width = 100

            GRIDHSN.Columns(4).HeaderText = "IGST"
            GRIDHSN.Columns(4).Width = 100


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'If GRIDHSN.SelectedRows.Count > 0 Then TEMPCODE = GRIDHSN.Rows(GRIDHSN.SelectedRows(0).Index).Cells(0).Value Else TEMPCODE = ""

            If GRIDHSN.SelectedRows.Count > 0 Then
                TEMPCODE = GRIDHSN.Rows(GRIDHSN.SelectedRows(0).Index).Cells(0).Value
                TEMPCODEDESC = GRIDHSN.Rows(GRIDHSN.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPCODE = ""
            End If

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHSN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHSN.CellDoubleClick
        Try
            If GRIDHSN.Rows.Count > 0 Then CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDHSN.Item(0, GRIDHSN.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDHSN.RowCount > 0) Then
                Dim OBJHSN As New HSNMaster
                OBJHSN.MdiParent = MDIMain
                OBJHSN.EDIT = editval
                OBJHSN.tempHSNCODE = TXTHSNCODE.Text.Trim()
                OBJHSN.Show()
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
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

    Private Sub TXTNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTHSNCODE.TextChanged
        Try
            If TXTHSNCODE.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Code" Then
                        FILLGRID(" AND HSNMASTER.HSN_CODE like '" & TXTHSNCODE.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Item Desc" Then
                        FILLGRID(" AND HSNMASTER.HSN_ITEMDESC like '" & TXTHSNCODE.Text.Trim & "%'")
                        'ElseIf cmbname.Text = "CGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_CGST like like '" & Val(TXTHSNCODE.Text.Trim) & "%'")
                        'ElseIf cmbname.Text = "SGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_SGST like  like '" & TXTHSNCODE.Text.Trim & "%'")
                        'ElseIf cmbname.Text = "IGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_IGST like  like '" & TXTHSNCODE.Text.Trim & "%'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Code" Then
                        FILLGRID(" AND HSNMASTER.HSN_CODE LIKE '%" & TXTHSNCODE.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Item Desc" Then
                        FILLGRID(" AND HSNMASTER.HSN_ITEMDESC LIKE '%" & TXTHSNCODE.Text.Trim & "%'")
                        'ElseIf cmbname.Text = "CGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_CGST LIKE '%" & Val(TXTHSNCODE.Text.Trim) & "%'")
                        'ElseIf cmbname.Text = "SGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_SGST  LIKE '%" & TXTHSNCODE.Text.Trim & "%'")
                        'ElseIf cmbname.Text = "IGST" Then
                        '    FILLGRID(" AND HSNMASTER.HSN_IGST  LIKE '%" & TXTHSNCODE.Text.Trim & "%'")
                    End If

                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectHSN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID("")
            cmbname.Text = "Code"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class