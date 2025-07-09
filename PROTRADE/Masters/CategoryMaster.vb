Imports BL

Public Class CategoryMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public EDIT As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                    If frmString = "CATEGORY" Then
                        dt = objclscommon.search("category_name", "", "CategoryMaster", " and category_name = '" & txtname.Text.Trim & "' and category_cmpid =" & CmpId & " and category_Locationid =" & Locationid & " and category_Yearid =" & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Category Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "BASE" Then
                        dt = objclscommon.search("BASE_name", "", "BASEMaster", " and BASE_name = '" & txtname.Text.Trim & "' and BASE_cmpid =" & CmpId & " and BASE_Locationid =" & Locationid & " and BASE_Yearid =" & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("BASE Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "MATERIAL TYPE" Then
                        dt = objclscommon.search("material_name", "", "MaterialTypeMaster", " and material_name = '" & txtname.Text.Trim & "' and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Material Type Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "COLOR" Then
                        uppercase(txtname)
                        dt = objclscommon.search("COLOR_name", "", "COLORMaster", " and COLOR_name = '" & txtname.Text.Trim & "' and COLOR_cmpid = " & CmpId & " and COLOR_Locationid = " & Locationid & " and COLOR_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("COLOR Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "DEPARTMENT" Then
                        dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_name = '" & txtname.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("DEPARTMENT Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "PACKINGTYPE" Then
                        dt = objclscommon.search("PACKINGTYPE_name", "", "PACKINGTypeMaster", " and PACKINGTYPE_name = '" & txtname.Text.Trim & "' and PACKINGTYPE_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Packing Type Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "PIECE TYPE" Then
                        dt = objclscommon.search("PIECETYPE_name", "", "PIECETypeMaster", " and PIECETYPE_name = '" & txtname.Text.Trim & "' and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and PIECETYPE_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Piece Type Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "NARRATION" Then
                        dt = objclscommon.search("NARRATION_name", "", "NARRATIONMaster", " and NARRATION_name = '" & txtname.Text.Trim & "' and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("NARRATION Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "REASON" Then
                        dt = objclscommon.search("REASON_name", "", "REASONMaster", " and REASON_name = '" & txtname.Text.Trim & "' and REASON_cmpid = " & CmpId & " and REASON_Locationid = " & Locationid & " and REASON_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("REASON Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "PARTYBANK" Then
                        dt = objclscommon.search("PARTYBANK_name", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & txtname.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("PARTYBANK Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "PROCESS" Then
                        dt = objclscommon.search("PROCESS_name", "", "PROCESSMaster", " and PROCESS_name = '" & txtname.Text.Trim & "' and PROCESS_cmpid = " & CmpId & " and PROCESS_Locationid = " & Locationid & " and PROCESS_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("PROCESS Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "GODOWN" Then
                        dt = objclscommon.search("GODOWN_name", "", "GODOWNMaster", " and GODOWN_name = '" & txtname.Text.Trim & "' and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("GODOWN Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "CURRENCY" Then
                        dt = objclscommon.search("CURRENCY_name", "", "CURRENCYMaster", " and CURRENCY_name = '" & txtname.Text.Trim & "' and CURRENCY_cmpid = " & CmpId & " and CURRENCY_Locationid = " & Locationid & " and CURRENCY_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("CURRENCY Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    End If
                End If
                uppercase(txtname)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(txtname.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "CATEGORY" Then
                Dim objclscategorymaster As New ClsCategoryMaster
                objclscategorymaster.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclscategorymaster.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclscategorymaster.Update()
                    MsgBox("Details Updated")
                    EDIT = False

                End If

            ElseIf frmString = "DEPARTMENT" Then
                Dim OBJ As New ClsDepartmentMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.SAVE()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.UPDATE()
                    MsgBox("Details Updated")
                    EDIT = False

                End If

            ElseIf frmString = "BASE" Then
                Dim objclsBASEmaster As New ClsBaseMaster
                objclsBASEmaster.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsBASEmaster.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclsBASEmaster.Update()
                    MsgBox("Details Updated")
                    EDIT = False

                End If

            ElseIf frmString = "MATERIAL TYPE" Then
                Dim objclsMaterialTypeMaster As New ClsMaterialTypeMaster
                objclsMaterialTypeMaster.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsMaterialTypeMaster.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclsMaterialTypeMaster.Update()
                    MsgBox("Details Updated")
                    EDIT = False

                End If


            ElseIf frmString = "COLOR" Then
                Dim OBJ As New ClsColorMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PIECE TYPE" Then
                Dim OBJ As New ClsPieceTypeMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    EDIT = False

                End If

            ElseIf frmString = "PACKINGTYPE" Then
                Dim OBJ As New ClsPackingTypeMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    EDIT = False

                End If

            ElseIf frmString = "NARRATION" Then
                Dim OBJ As New ClsNarrationMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "REASON" Then
                Dim OBJ As New ClsReasonMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PARTYBANK" Then
                Dim OBJ As New ClsPARTYBANKMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PROCESS" Then
                Dim OBJ As New ClsProcessMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "GODOWN" Then
                Dim OBJ As New ClsGodownMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    EDIT = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "CURRENCY" Then
                Dim OBJ As New ClsCurrencyMaster
                OBJ.alParaval = alParaval

                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.SAVE()
                    MsgBox("Details Added")
                ElseIf EDIT = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.UPDATE()
                    EDIT = False
                    MsgBox("Details Updated")
                End If
            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Saving
            Call CMDDELETE_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If frmString = "CATEGORY" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Category Master"
                lblgroup.Text = "Category"
                lbl.Text = "Enter Category" & vbNewLine & "(e.g.  CHEMICAL,..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" category_name, CATEGORY_REMARKS", "", "CategoryMaster", " and category_id = " & TempID & " and category_cmpid = " & CmpId & " and category_locationid = " & Locationid & " and category_yearid = " & YearId)


            ElseIf frmString = "DEPARTMENT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "DEPARTMENT Master"
                lblgroup.Text = "DEPARTMENT"
                lbl.Text = "Enter DEPARTMENT" & vbNewLine & "(e.g.  CHEMICAL,..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" DEPARTMENT_name, DEPARTMENT_REMARKS", "", "DEPARTMENTMaster", " and DEPARTMENT_id = " & TempID & " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_locationid = " & Locationid & " and DEPARTMENT_yearid = " & YearId)


            ElseIf frmString = "BASE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "BASE Master"
                lblgroup.Text = "BASE"
                lbl.Text = "Enter BASE"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" BASE_name, BASE_REMARKS", "", "BASEMaster", " and BASE_id = " & TempID & " and BASE_cmpid = " & CmpId & " and BASE_locationid = " & Locationid & " and BASE_yearid = " & YearId)

            ElseIf frmString = "MATERIAL TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Material Master"
                lblgroup.Text = "Material"
                lbl.Text = "Enter Material Type " & vbNewLine & "(e.g.  Raw,Trading Material..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" material_name", "", "MaterialTypeMaster", " and material_id = " & TempID & " and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_yearid = " & YearId)

            ElseIf frmString = "COLOR" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Color Master"
                lblgroup.Text = "Color"
                lbl.Text = "Enter Color" & vbNewLine & "(e.g.  GREEN,BLUE..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" COLOR_name, COLOR_REMARKS", "", "COLORMaster", " and COLOR_id = " & TempID & " and COLOR_cmpid = " & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId)

            ElseIf frmString = "PACKINGTYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Packing Type Master"
                lblgroup.Text = "Packing Type"
                lbl.Text = "Enter Packing Type " & vbNewLine & "(e.g.  Double Fold, Roll Format..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" PACKINGTYPE_name", "", "PACKINGTYPEMaster", " and PACKINGTYPE_id = " & TempID & " and PACKINGTYPE_cmpid = " & CmpId & " and PACKINGTYPE_Locationid = " & Locationid & " and PACKINGTYPE_yearid = " & YearId)

            ElseIf frmString = "PIECE TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Piece Master"
                lblgroup.Text = "Piece Type"
                lbl.Text = "Enter Piece Type " & vbNewLine & "(e.g.  Fresh,GoodCut..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PIECETYPE_name", "", "PIECETypeMaster", " and PIECETYPE_id = " & TempID & " and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and pieceTYPE_yearid = " & YearId)


            ElseIf frmString = "NARRATION" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Narration Master"
                lblgroup.Text = "Narration"
                lbl.Text = "Enter Narration " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" NARRATION_name, NARRATION_REMARKS", "", "NARRATIONMaster", " and NARRATION_id = " & TempID & " and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_yearid = " & YearId)


            ElseIf frmString = "REASON" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE ORDER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "REASON Master"
                lblgroup.Text = "REASON"
                lbl.Text = "Enter REASON " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" REASON_name, REASON_REMARKS", "", "REASONMaster", " and REASON_id = " & TempID & " and REASON_cmpid = " & CmpId & " and REASON_Locationid = " & Locationid & " and REASON_yearid = " & YearId)


            ElseIf frmString = "PARTYBANK" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "PartyBank Master"
                lblgroup.Text = "Party Bank"
                lbl.Text = "Enter Party Bank " & vbNewLine & "(e.g.  SBI,Canara..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" PARTYBANK_name, PARTYBANK_REMARKS", "", "PARTYBANKMaster", " and PARTYBANK_id = " & TempID & " and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)

            ElseIf frmString = "PROCESS" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Process Master"
                lblgroup.Text = "Process Name"
                lbl.Text = "Enter Process Name"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" PROCESS_name, PROCESS_REMARKS ", "", "PROCESSMaster", " and PROCESS_id = " & TempID & " and PROCESS_cmpid = " & CmpId & " and PROCESS_Locationid = " & Locationid & " and PROCESS_yearid = " & YearId)


            ElseIf frmString = "GODOWN" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "GODOWN Master"
                lblgroup.Text = "Godown Name"
                lbl.Text = "Enter Godown Name"""
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" GODOWN_name, GODOWN_REMARKS ", "", "GODOWNMaster", " and GODOWN_id = " & TempID & " and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_yearid = " & YearId)

            ElseIf frmString = "CURRENCY" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "CURRENCY Master"
                lblgroup.Text = "CURRENCY Name"
                lbl.Text = "Enter CURRENCY Name"""
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If EDIT = True Then dttable = objCommon.search(" CURRENCY_name, CURRENCY_REMARKS ", "", "CURRENCYMaster", " and CURRENCY_id = " & TempID & " and CURRENCY_cmpid = " & CmpId & " and CURRENCY_Locationid = " & Locationid & " and CURRENCY_yearid = " & YearId)

            End If

            txtname.Text = TempName

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtremarks.Text = dttable.Rows(0).Item(1).ToString
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = False Then Exit Sub
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If MsgBox("Wish to Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If frmString = "GODOWN" Then
                    'FIRST CHECK WHETHER IT IS USED FURTHER OR NOT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("BARCODE", "", "BARCODESTOCK", " AND GODOWN = '" & TempName & "' AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Godown Used Further", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    DT = OBJCMN.search("BARCODE", "", "OUTBARCODESTOCK", " AND GODOWN = '" & TempName & "' AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Godown Used Further", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    DT = OBJCMN.search("CHALLANNO", "", "STOCKREGISTER", " AND GODOWN = '" & TempName & "' AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Godown Used Further", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    'IF NOT PRESENT IN ABOVE TABLES THEN DELETE THE ENTRY
                    DT = OBJCMN.Execute_Any_String("DELETE FROM GODOWNMASTER WHERE GODOWN_NAME = '" & TempName & "' AND GODOWN_YEARID= " & YearId, "", "")
                    MsgBox("Entry Deleted Successfully")
                    EDIT = False
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class