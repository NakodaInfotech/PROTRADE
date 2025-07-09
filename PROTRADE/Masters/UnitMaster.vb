
Imports BL

Public Class UnitMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String      'Used for all Unit form
    Public Tempname As String       'Used for edit name
    Public Tempabbr As String       'Used for validating abbr
    Public tempid As Integer        'Used for id
    Public EDIT As Boolean          'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If txtabbr.Text.Trim.Length = 0 Then
            Ep.SetError(txtabbr, "Fill Abbr")
            bln = False
        End If

        If Tempabbr = "in" Or Tempabbr = "mm" Then
            Ep.SetError(txtabbr, "Build In Unit Cannot edit")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(txtname.Text.Trim))
            alParaval.Add(UCase(txtabbr.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "UNIT" Then

                Dim objclsUnitMaster As New ClsUnitMaster
                objclsUnitMaster.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsUnitMaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclsUnitMaster.update()
                    MsgBox("Details Updated")
                    edit = False

                End If

                'ElseIf frmString = "PACKINGUNIT" Then

                '    Dim objclsPackingUnitMaster As New ClsPackingUnitMaster
                '    objclsPackingUnitMaster.alParaval = alParaval
                '    If edit = False Then
                '        If USERADD = False Then
                '            MsgBox("Insufficient Rights")
                '            Exit Sub
                '        End If
                '        IntResult = objclsPackingUnitMaster.save()
                '        MsgBox("Details Added")
                '    ElseIf edit = True Then
                '        If USEREDIT = False Then
                '            MsgBox("Insufficient Rights")
                '            Exit Sub
                '        End If
                '        alParaval.Add(tempid)
                '        IntResult = objclsPackingUnitMaster.update()
                '        MsgBox("Details Updated")
                '        edit = False

                '    End If

            ElseIf frmString = "TAXMASTER" Then

                Dim objclstaxmaster As New ClsTaxMaster
                objclstaxmaster.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclstaxmaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclstaxmaster.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If
            ElseIf frmString = "OCTROIMASTER" Then

                'Dim objclsOCTROImaster As New ClsoctroiMaster
                'objclsOCTROImaster.alParaval = alParaval
                'If edit = False Then
                '    If USERADD = False Then
                '        MsgBox("Insufficient Rights")
                '        Exit Sub
                '    End If
                '    IntResult = objclsOCTROImaster.save()
                '    MsgBox("Details Added")
                'ElseIf edit = True Then
                '    If USEREDIT = False Then
                '        MsgBox("Insufficient Rights")
                '        Exit Sub
                '    End If
                '    alParaval.Add(tempid)
                '    IntResult = objclsOCTROImaster.Update()
                '    MsgBox("Details Updated")
                '    edit = False

                'End If

            End If
            clear()
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        txtname.Clear()
        txtabbr.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub cmbpackingunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpackingunit.Enter
        Try
            If cmbpackingunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("packingunit_name", "", "PackingUnitMaster", " and PackingUnit_cmpid = " & CmpId & " and PackingUnit_locationid = " & Locationid & " and PackingUnit_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "packingunit_name"
                    cmbpackingunit.DataSource = dt
                    cmbpackingunit.DisplayMember = "packingunit_name"
                    cmbpackingunit.Text = ""
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempname) <> LCase(txtname.Text.Trim)) Then
                If frmString = "UNIT" Then
                    dt = objclscommon.search("unit_name", "", "unitMaster", " and unit_name = '" & txtname.Text.Trim & "' And Unit_cmpid = " & CmpId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Unit Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "TAXMASTER" Then
                    dt = objclscommon.search("tax_name", "", "TaxMaster", " and tax_name = '" & txtname.Text.Trim & "' And tax_cmpid = " & CmpId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Tax Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "OCTROIMASTER" Then
                    dt = objclscommon.search("OCTROI_name", "", "OCTROIMaster", " and OCTROI_name = '" & txtname.Text.Trim & "' And OCTROI_cmpid = " & CmpId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("OCTROI Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PACKINGUNIT" Then
                    dt = objclscommon.search("packingunit_name", "", "packingunitMaster", " and packingunit_name = '" & txtname.Text.Trim & "' and PackingUnit_cmpid = " & CmpId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Packing Unit Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                ElseIf frmString = "SUBPACKINGUNIT" Then
                    dt = objclscommon.search("subpackingunit_name", "", "subpackingunitMaster", " and subpackingunit_name = '" & txtname.Text.Trim & "' and SubPackingUnit_cmpid = " & CmpId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Sub Packing Unit Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
            uppercase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub UnitMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'fOR sAVE
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            Me.Close()
        End If
    End Sub

    Private Sub UnitMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If frmString = "UNIT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)


                Me.Text = "Unit Master"
                lblgroup.Text = "Unit"
                lblabbr.Text = "Abbr."
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If EDIT = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" unit_name, unit_abbr, unit_remarks", "", "UnitMaster", " and unit_id = " & tempid)

                End If

            ElseIf frmString = "TAXMASTER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Tax Master"
                lblgroup.Text = "Tax Name"
                lblabbr.Text = "Tax"
                lbl.Text = "Enter Tax " & vbNewLine & "(e.g.  VAT,CST..., etc. )"
                If EDIT = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" tax_name, tax_abbr, tax_remarks", "", "TaxMaster", " and tax_id = " & tempid)
                End If
            ElseIf frmString = "OCTROIMASTER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TAX MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "OCTROI Master"
                lblgroup.Text = "Octroi Name"
                lblabbr.Text = "Octroi %"
                lbl.Text = "Enter OCTROI " & vbNewLine & "(e.g.  OCTROI,..., etc. )"
                If EDIT = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" OCTROI_name, octroi_octroi, OCTROI_remarks", "", "OCTROIMaster", " and OCTROI_id = " & tempid)
                End If

            ElseIf frmString = "PACKINGUNIT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Packing Unit Master"
                lblgroup.Text = "Packing Unit"
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If EDIT = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" packingunit_name, packingunit_abbr, packingunit_remarks", "", "PackingUnitMaster", " and packingunit_id = " & tempid)
                End If

            ElseIf frmString = "SUBPACKINGUNIT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Sub Packing Unit Master"
                lblgroup.Text = "Sub Packing Unit"
                lblcmb.Visible = True
                cmbpackingunit.Visible = True
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If EDIT = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" subpackingunit_name, subpackingunit_abbr, subpackingunit_remarks", "", "subpackingunitMaster", " and subpackingunit_id = " & tempid)
                End If

            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtabbr.Text = dttable.Rows(0).Item(1).ToString
                txtremarks.Text = dttable.Rows(0).Item(2).ToString
                Tempabbr = txtabbr.Text.Trim
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtabbr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtabbr.KeyPress
        If frmString = "TAXMASTER" Or frmString = "OCTROIMASTER" Then
            numdot(e, txtabbr, Me)
        End If
    End Sub

    Private Sub txtabbr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtabbr.Validating
        Try
            If txtabbr.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                If (EDIT = False) Or (EDIT = True And LCase(Tempabbr) <> LCase(txtabbr.Text.Trim)) Then
                    If frmString = "UNIT" Then
                        dt = objclscommon.search("unit_abbr", "", "unitMaster", " and unit_abbr = '" & txtabbr.Text.Trim & "' And Unit_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Unit Abbr Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "TAXMASTER" Then
                        dt = objclscommon.search("tax_abbr", "", "TaxMaster", " and tax_abbr = '" & txtabbr.Text.Trim & "' And tax_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Tax Abbr Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "OCTROIMASTER" Then
                        dt = objclscommon.search("octroi_octroi", "", "OCTROIMaster", " and octroi_octroi = '" & txtabbr.Text.Trim & "' And OCTROI_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("OCTROI Abbr Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "PACKINGUNIT" Then
                        dt = objclscommon.search("packingunit_abbr", "", "packingunitMaster", " and packingunit_abbr = '" & txtabbr.Text.Trim & "' and PackingUnit_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Packing Unit Abbr Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    ElseIf frmString = "SUBPACKINGUNIT" Then
                        dt = objclscommon.search("subpackingunit_abbr", "", "subpackingunitMaster", " and subpackingunit_abbr = '" & txtabbr.Text.Trim & "' and SubPackingUnit_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Sub Packing Unit Abbr Already Exists", MsgBoxStyle.Critical, "PROTRADE")
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

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        ' looking for in SalesOrder_Desc Table if Item master Name is Exists OR Not 
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("grade_name", "", " dbo.GRADEMASTER RIGHT OUTER JOIN  dbo.SALEORDER_DESC ON dbo.GRADEMASTER.grade_id = dbo.SALEORDER_DESC.so_gradeid ", " and Grade_name = '" & txtname.Text.Trim & "' and grade_cmpid = " & CmpId & " and grade_Locationid = " & Locationid & " and grade_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Size Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If

        End If
        '*** Searching in GRN Table ..******
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("grade_name", "", "  dbo.GRADEMASTER RIGHT OUTER JOIN  dbo.GRN_ITEMDESC ON dbo.GRADEMASTER.grade_id = dbo.GRN_ITEMDESC.grn_gradeid", " and Grade_name = '" & txtname.Text.Trim & "' and grade_cmpid = " & CmpId & " and grade_Locationid = " & Locationid & " and grade_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Grade Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If

        End If

        '********* Searching in Purchase ORder table
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("grade_name", "", "  dbo.GRADEMASTER RIGHT OUTER JOIN dbo.PURCHASEORDER_DESC ON dbo.GRADEMASTER.grade_id = dbo.PURCHASEORDER_DESC.po_gradeid ", " and Grade_name = '" & txtname.Text.Trim & "' and grade_cmpid = " & CmpId & " and grade_Locationid = " & Locationid & " and grade_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Grade Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If
        End If


        '** Searching in Purchase Quotation Table ********
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("grade_name", "", "  dbo.GRADEMASTER RIGHT OUTER JOIN dbo.PURCHASEQUOTATION_DESC ON dbo.GRADEMASTER.grade_id = dbo.PURCHASEQUOTATION_DESC.quotation_gradeid ", " and Grade_name = '" & txtname.Text.Trim & "' and grade_cmpid = " & CmpId & " and grade_Locationid = " & Locationid & " and grade_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Grade Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If
        End If


        '** Searching in Purchase requisition Table ********
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("grade_name", "", "   dbo.GRADEMASTER RIGHT OUTER JOIN dbo.PURCHASEREQUEST_GRIDSET ON dbo.GRADEMASTER.grade_id = dbo.PURCHASEREQUEST_GRIDSET.gradeid ", " and Grade_name = '" & txtname.Text.Trim & "' and grade_cmpid = " & CmpId & " and grade_Locationid = " & Locationid & " and grade_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Grade Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If
        End If


    End Sub
End Class