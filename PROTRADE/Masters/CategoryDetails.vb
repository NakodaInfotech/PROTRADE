
Imports BL

Public Class CategoryDetails

    Public frmstring As String      'Used for form Category or GRade

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.KeyCode = Windows.Forms.Keys.A) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CategoryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If frmstring = "CATEGORY" Then
                Me.Text = "Category Master"
            ElseIf frmstring = "BASE" Then
                Me.Text = "Base Master"
            ElseIf frmstring = "MATERIAL TYPE" Then
                Me.Text = "Material Type Master"
            ElseIf frmstring = "COLOR" Then
                Me.Text = "Color Master"
            ElseIf frmstring = "DEPARTMENT" Then
                Me.Text = "Department Master"
            ElseIf frmstring = "PIECE TYPE" Then
                Me.Text = "Piece Type Master"
            ElseIf frmstring = "RATE TYPE" Then
                Me.Text = "Rate Type Master"
            ElseIf frmstring = "NARRATION" Then
                Me.Text = "Narration Master"
            ElseIf frmstring = "PARTYBANK" Then
                Me.Text = "Bank Name Master"
            ElseIf frmstring = "PROCESS" Then
                Me.Text = "Process Master"
            ElseIf frmstring = "QUALITY" Then
                Me.Text = "Quality Master"
            ElseIf frmstring = "GODOWN" Then
                Me.Text = "Godown Master"
            ElseIf frmstring = "CURRENCY" Then
                Me.Text = "Currency Master"
            End If
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CATEGORY" Then
            dttable = objClsCommon.search(" category_name, category_id", "", "categorymaster", " and category_cmpid = " & CmpId & " and category_Locationid = " & Locationid & " and category_Yearid = " & YearId)
        ElseIf frmstring = "BASE" Then
            dttable = objClsCommon.search(" BASE_name, BASE_id", "", "BASEmaster", " and BASE_cmpid = " & CmpId & " and BASE_Locationid = " & Locationid & " and BASE_Yearid = " & YearId)
        ElseIf frmstring = "MATERIAL TYPE" Then
            dttable = objClsCommon.search(" material_name, material_id", "", "materialtypemaster", " and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_Yearid = " & YearId)
        ElseIf frmstring = "COLOR" Then
            dttable = objClsCommon.search(" COLOR_name, COLOR_id", "", "COLORmaster", " and COLOR_cmpid = " & CmpId & " and COLOR_Locationid = " & Locationid & " and COLOR_Yearid = " & YearId)
        ElseIf frmstring = "DEPARTMENT" Then
            dttable = objClsCommon.search(" DEPARTMENT_name, DEPARTMENT_id", "", "DEPARTMENTmaster", " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_Yearid = " & YearId)
        ElseIf frmstring = "PIECE TYPE" Then
            dttable = objClsCommon.search(" PIECETYPE_name, PIECETYPE_id", "", "PIECEtypemaster", " and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and PIECETYPE_Yearid = " & YearId)
        ElseIf frmstring = "NARRATION" Then
            dttable = objClsCommon.search(" NARRATION_name, NARRATION_id", "", "NARRATIONmaster", " and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_Yearid = " & YearId)
        ElseIf frmstring = "PARTYBANK" Then
            dttable = objClsCommon.search(" PARTYBANK_name, PARTYBANK_id", "", "PARTYBANKmaster", " and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_Yearid = " & YearId)
        ElseIf frmstring = "PROCESS" Then
            dttable = objClsCommon.search(" PROCESS_name, PROCESS_id", "", "PROCESSmaster", " and PROCESS_cmpid = " & CmpId & " and PROCESS_Locationid = " & Locationid & " and PROCESS_Yearid = " & YearId)
        ElseIf frmstring = "GODOWN" Then
            dttable = objClsCommon.search(" GODOWN_name, GODOWN_id", "", "GODOWNmaster", " and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_Yearid = " & YearId)
        ElseIf frmstring = "CURRENCY" Then
            dttable = objClsCommon.search(" CURRENCY_name, CURRENCY_id", "", "CURRENCYmaster", " and CURRENCY_cmpid = " & CmpId & " and CURRENCY_Locationid = " & Locationid & " and CURRENCY_Yearid = " & YearId)
        ElseIf frmstring = "QUALITY" Then
            dttable = objClsCommon.search(" QUALITY_name, QUALITY_id", "", "QUALITYmaster", " and QUALITY_cmpid = " & CmpId & " and QUALITY_Locationid = " & Locationid & " and QUALITY_Yearid = " & YearId)
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
            Dim objCategorymaster As New CategoryMaster
            objCategorymaster.edit = editval
            objCategorymaster.MdiParent = MDIMain
            objCategorymaster.frmString = frmstring
            objCategorymaster.TempName = name
            objCategorymaster.TempID = id
            objCategorymaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
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