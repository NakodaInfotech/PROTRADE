
Imports BL

Public Class addressdetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub addressDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
            showform(False, "")
        End If
    End Sub

    Private Sub addressDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search(" ADDRESS_ID, ADDRESS_ALIAS AS Consignee, ADDRESS_FULL AS [Del. Add.] ", "", "ADDRESSMASTER ", " and address_cmpid = " & CmpId & " and address_locationid = " & Locationid & " and address_yearid = " & YearId)
        If dttable.Rows.Count > 0 Then
            gridaddress.DataSource = dttable

            gridaddress.Columns(1).HeaderText = "Buyer"
            gridaddress.Columns(2).HeaderText = "Consignee"
            gridaddress.Columns(0).Visible = False

            gridaddress.Columns(1).Width = 180
            gridaddress.Columns(2).Width = 180
            ''            gridaddress.Columns(3).Width = 180
            gridaddress.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic

            gridaddress.FirstDisplayedScrollingRowIndex = gridaddress.RowCount - 1
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridaddress.Item(0, gridaddress.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal id As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objaddressmaster As New addressMaster
            objaddressmaster.edit = editval
            objaddressmaster.MdiParent = MDIMain
            objaddressmaster.TempID = id
            objaddressmaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridaddress_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridaddress.CellDoubleClick
        Try
            showform(True, gridaddress.Item(0, gridaddress.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtaddress_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtledger.Validated
        Dim rowno, b As Integer
        fillgrid()
        rowno = 0
        For b = 1 To gridaddress.RowCount
            txttempname.Text = gridaddress.Item(1, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtledger.TextLength
            If LCase(txtledger.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridaddress.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

  
End Class