Imports BL

Public Class SelectItem

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPNAME, TEMPCODE As String
    Public FRMSTRING As String
    Public STRSEARCH As String

    Private Sub CMDEXIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SelectItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            cmbname.Text = "Code"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  ISNULL(ITEM_name, '') AS [Item Name], ISNULL(ITEM_CODE,'') AS Code ", "", "  ITEMMASTER", STRSEARCH & WHERECLAUSE & " AND ITEMMASTER.ITEM_FRMSTRING ='" & FRMSTRING & "'  AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId & " order by ITEMMASTER.ITEM_name ")
            GRIDITEM.DataSource = DT

            GRIDITEM.Columns(0).Width = 330
            GRIDITEM.Columns(1).Width = 140

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDITEM.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDITEM.Rows(GRIDITEM.SelectedRows(0).Index).Cells(0).Value
                TEMPCODE = GRIDITEM.Rows(GRIDITEM.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPNAME = ""
                TEMPCODE = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GRIDITEM_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDITEM.CellDoubleClick
        Try
            If GRIDITEM.Rows.Count > 0 Then
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
            showform(True, GRIDITEM.CurrentRow.Cells(0).Value, GRIDITEM.CurrentRow.Cells(1).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal ITEMCODE As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDITEM.RowCount > 0) Then
                Dim OBJITEM As New ItemMaster
                OBJITEM.MdiParent = MDIMain
                OBJITEM.edit = editval
                OBJITEM.frmstring = FRMSTRING
                OBJITEM.tempItemName = name
                OBJITEM.tempItemCODE = ITEMCODE
                OBJITEM.Show()
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
                        FILLGRID(" AND ITEMMASTER.ITEM_name LIKE '" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND ITEMMASTER.ITEM_code LIKE '" & TXTNAME.Text.Trim & "%'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND ITEMMASTER.ITEM_name LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND ITEMMASTER.ITEM_code LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If
                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDITEM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDITEM.KeyDown
        Try
            If e.KeyCode = Keys.Enter And GRIDITEM.RowCount > 0 Then

                If GRIDITEM.SelectedRows.Count > 0 Then
                    TEMPNAME = GRIDITEM.Rows(GRIDITEM.SelectedRows(0).Index).Cells(0).Value
                Else
                    TEMPNAME = ""
                End If
                Me.Close()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectItem_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                rbstart.Checked = True
                rbpart.Checked = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class