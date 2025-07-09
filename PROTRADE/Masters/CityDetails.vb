
Imports BL

Public Class CityDetails

    Public frmstring As String      'Used for form Category or GRade
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CityDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.KeyCode = Windows.Forms.Keys.A) Then   'for New
            showform(False, "", 0)
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CityDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If
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

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CITYMASTER" Then
            dttable = objClsCommon.search(" city_name, city_id", "", "citymaster", " and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
        ElseIf frmstring = "AREAMASTER" Then
            dttable = objClsCommon.search(" area_name, area_id", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_locationid = " & Locationid & " and area_yearid = " & YearId)
        ElseIf frmstring = "FORMTYPE" Then
            dttable = objClsCommon.search(" FORm_name, FORm_id", "", "formtype", " and FORm_cmpid = " & CmpId & " and FORm_locationid = " & Locationid & " and FORm_yearid = " & YearId)
        ElseIf frmstring = "STATEMASTER" Then
            dttable = objClsCommon.search(" state_name, state_id", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
        ElseIf frmstring = "COUNTRYMASTER" Then
            dttable = objClsCommon.search(" country_name, country_id", "", "Countrymaster", " and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"

        gridgroup.Columns(0).Width = 250
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objcitymaster As New citymaster
            objcitymaster.edit = editval
            objcitymaster.MdiParent = MDIMain
            objcitymaster.frmstring = frmstring
            objcitymaster.tempname = name
            objcitymaster.tempid = id
            objcitymaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(0, rowno).Value.ToString()
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