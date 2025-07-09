
Imports BL

Public Class TaxDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal tax As String, ByVal id As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objtaxmaster As New Taxmaster
            objtaxmaster.edit = editval
            objtaxmaster.MdiParent = MDIMain
            objtaxmaster.tempname = name
            objtaxmaster.txttax.Text = tax
            objtaxmaster.tempid = id
            objtaxmaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaxDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then               'FOR new
            showform(False, "", "", 0)
        End If
    End Sub

    Private Sub TaxDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        dttable = objClsCommon.search(" tax_id, tax_name,tax_tax ", "", "taxmaster", " and tax_YEARid=" & YearId)
        If dttable.Rows.Count > 0 Then
            gridgroup.DataSource = dttable
            gridgroup.Columns(0).Visible = False
            gridgroup.Columns(1).Width = 150
            gridgroup.Columns(1).HeaderText = "Tax Name"
            gridgroup.Columns(2).Width = 100
            gridgroup.Columns(2).HeaderText = "Tax"

            gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
            gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1
        End If

    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated

        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(1, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridgroup.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub
End Class