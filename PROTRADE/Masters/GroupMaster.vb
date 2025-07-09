
Imports BL

Public Class GroupMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public EDIT As Boolean
    Public tempGroupname As String
    Dim tempGroupId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbunder.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objclsGroupMaster As New ClsGroupMaster
            objclsGroupMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsGroupMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempGroupId)
                IntResult = objclsGroupMaster.update()
                MsgBox("Details Updated")

            End If
            edit = False


            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Group Name")
            bln = False
        End If

        If cmbunder.Text.Trim.Length = 0 Then
            Ep.SetError(cmbunder, "Select Under Group")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub cmbunder_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunder.Enter
        Try
            If cmbunder.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "group_name"
                    cmbunder.DataSource = dt
                    cmbunder.DisplayMember = "group_name"
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            pcase(txtname)
            If (edit = False) Or (edit = True And tempGroupname <> txtname.Text.Trim) Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_name = '" & txtname.Text.Trim & "' and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Group Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GroupMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            Me.Close()
        End If
    End Sub

    Private Sub txtremarks_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.Validated
        pcase(txtremarks)
    End Sub

    Private Sub GroupMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        fillcombos()
        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            dttable = objCommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                dttable.DefaultView.Sort = "group_name"
                cmbunder.DataSource = dttable
                cmbunder.DisplayMember = "group_name"
            End If


            dttable = objCommon.search(" group_id, group_name, group_under", "", "GroupMaster", " and group_name = '" & tempGroupname & "' and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                tempGroupId = dttable.Rows(0).Item(0)
                txtname.Text = dttable.Rows(0).Item(1)
                cmbunder.Text = dttable.Rows(0).Item(2)
            End If
        End If
    End Sub

    Sub fillcombos()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "group_name"
            cmbunder.DataSource = dt
            cmbunder.DisplayMember = "group_name"
            cmbunder.Text = ""
        End If

    End Sub
End Class