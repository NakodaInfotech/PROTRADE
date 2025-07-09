

Imports System.ComponentModel
Imports BL

Public Class Proforma
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPPRONO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim DTNEW As New DataTable
    Dim PRESENT As Boolean = False
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        'txtPROno.ReadOnly = False
        TXTPRONO.Clear()
        PRODATE.Text = Now.Date
        If ALLOWMANUALGDNNO = True Then
            TXTPRONO.ReadOnly = False
            TXTPRONO.BackColor = Color.LemonChiffon
        Else
            TXTPRONO.ReadOnly = True
            TXTPRONO.BackColor = Color.Linen
        End If

        TabControl1.SelectedIndex = 0
        tstxtbillno.Clear()
        TXTMERCHANT.Clear()
        cmbname.Text = ""
        cmbname.Enabled = True
        cmbcity.Text = ""

        txtadd.Clear()
        CMBDISPATCHTO.Text = ""

        CMBPIECETYPE.Text = ""
        txtremarks.Clear()

        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos
        GRIDPROFORMA.RowCount = 0

        GRIDDOUBLECLICK = False
        getmaxno()

        LBLTOTALBALES.Text = 0
        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0
        LBLAMOUNT.Text = 0

        txtsrno.Clear()
        CMBITEMNAME.Text = ""
        TXTHSNCODE.Clear()
        CMBQUALITY.Text = ""
        TXTDESCRIPTION.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        TXTBALENO.Clear()
        TXTPCS.Clear()
        TXTCUT.Clear()
        TXTMTRS.Clear()
        TXTRATE.Clear()
        CMBPER.SelectedIndex = 0
        TXTAMOUNT.Clear()
        TXTCOPIES.Text = 2
        'TXTMOBILENO.Clear()

        txtinwords.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()

        txtroundoff.Clear()
        txtgrandtotal.Clear()
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()


    End Sub

    Sub total()
        Try
            GETHSNCODE()
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLAMOUNT.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTAMT.Text = 0.0

            If GRIDPROFORMA.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDPROFORMA.Rows
                    If Val(row.Cells(GCUT.Index).EditedFormattedValue) > 0 And Val(row.Cells(Gpcs.Index).EditedFormattedValue) > 0 Then row.Cells(Gmtrs.Index).Value = Format(Val(row.Cells(Gpcs.Index).EditedFormattedValue) * Val(row.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Or row.Cells(GPER.Index).EditedFormattedValue = "Yards" Then
                        row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(Gmtrs.Index).EditedFormattedValue))
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Pcs" Then
                        row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(Gpcs.Index).EditedFormattedValue))
                    End If
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                    LBLAMOUNT.Text = Format(Val(LBLAMOUNT.Text) + Val(row.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                Next
            End If
            TXTCGSTAMT.Text = Format((Val(LBLAMOUNT.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
            TXTSGSTAMT.Text = Format((Val(LBLAMOUNT.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
            TXTIGSTAMT.Text = Format((Val(LBLAMOUNT.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")

            txtgrandtotal.Text = Format(Val(LBLAMOUNT.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(LBLAMOUNT.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)), "0.00")

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)




            BALECOUNT()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BALECOUNT()
        Try
            LBLTOTALBALES.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDPROFORMA.Rows.Count - 1
                If Not GRIDPROFORMA.Rows(i).IsNewRow Then
                    cellValue = GRIDPROFORMA(GBALENO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALBALES.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    'Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If GDNDATE.Text = "__/__/____" Then
    '        EP.SetError(GDNDATE, " Please Enter Proper Date")
    '        e.Cancel = True
    '    Else
    '        If Not datecheck(GDNDATE.Text) Then
    '            EP.SetError(GDNDATE, "Date not in Accounting Year")
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PRO_no),0) + 1 ", " PROFORMA ", " and PRO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPRONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True



            'IF ALLOWPACKINGSLIP IS TRUE THEN FETCH NOOFBALES AUTO FROM LBLTOTALBALES\


            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Party Name ")
                bln = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Select Godown")
                bln = False
            End If




            If Val(TXTPRONO.Text.Trim) = 0 Then
                EP.SetError(cmbname, "Invalid Challan No")
                bln = False
            End If

            If ClientName <> "SANGHVI" And ClientName <> "KDFAB" And ALLOWMANUALGDNNO = True Then
                If Val(TXTPRONO.Text.Trim) <> 0 And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PROFORMA.PRO_NO,0)  AS PRONO", "", "PROFORMA", "  AND PROFORMA.PRO_NO=" & TXTPRONO.Text.Trim & " AND PROFORMA.PRO_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTPRONO, "Proforma No Already Exists")
                        bln = False
                    End If
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Entry Locked")
                bln = False
            End If

            If GRIDPROFORMA.RowCount = 0 Then
                EP.SetError(cmbname, "Fill Packing Slip Details")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDPROFORMA.Rows
                'ALLOW USER TO KEEP PCS 0 COZ, THIS WILL HELP THEM TO MAINTAIN PCS WISE STOCK
                'If Val(ROW.Cells(Gpcs.Index).Value) = 0 Then
                '    EP.SetError(cmbname, "Pcs Cannot be 0")
                '    bln = False
                'End If

                'CLEAR THE BACKCOLOR
                ROW.DefaultCellStyle.BackColor = Color.Empty

                If Val(ROW.Cells(Gmtrs.Index).Value) = 0 Then
                    EP.SetError(cmbname, "Mtrs Cannot be 0")
                    bln = False
                End If

                If Val(ROW.Cells(GSALEDONE.Index).Value) = 1 Then
                    lbllocked.Visible = True
                    EP.SetError(lbllocked, "Sale Return Raised, Delete Sale Return First")
                    bln = False
                End If

                If ClientName = "MSANCHITKUMAR" And ROW.Cells(GBALENO.Index).Value = "" Then
                    TXTBALENO.BackColor = Color.LemonChiffon
                    EP.SetError(TXTBALENO, "Enter Bale No.")
                    bln = False
                End If
            Next




            '            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            '            Dim TEMPORDERROWNO As Integer = -1
            '            Dim TEMPORDERMATCH As Boolean = False
            '            If GRIDORDER.RowCount > 0 Then

            '                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
            '                    ORDROW.Cells(OGDNQTY.Index).Value = 0
            '                Next

            '                'GET MULTISONO



            '                For Each ROW As DataGridViewRow In GRIDGDN.Rows
            '                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
            '                        If ROW.Cells(GITEMNAME.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(GSHADE.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
            '                            TEMPORDERMATCH = True
            '                            'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
            '                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
            '                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
            '                            If Val(ORDROW.Cells(OGDNQTY.Index).Value) >= Val(ORDROW.Cells(OPCS.Index).Value) Then
            '                                TEMPORDERROWNO = ORDROW.Index
            '                                GoTo CHECKNEXTLINE
            '                            End If
            '                            ORDROW.Cells(OGDNQTY.Index).Value = Val(ORDROW.Cells(OGDNQTY.Index).Value) + Val(ROW.Cells(Gpcs.Index).Value)
            '                            ROW.Cells(GRATE.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
            '                            TEMPORDERROWNO = -1
            '                            Exit For
            'CHECKNEXTLINE:
            ''                        End If
            'Next
            '        'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
            '        If TEMPORDERROWNO >= 0 Then
            '            GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNQTY.Index).Value) + Val(ROW.Cells(Gpcs.Index).Value)
            '            ROW.Cells(GRATE.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
            '            TEMPORDERROWNO = -1
            '        End If
            '        If TEMPORDERMATCH = False Then
            '            ROW.DefaultCellStyle.BackColor = Color.LightGreen
            '            If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '                EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
            '                bln = False
            '            End If
            '        End If
            '        TEMPORDERMATCH = False
            '    Next
            'End If





            If PRODATE.Text = "__/__/____" Then
                EP.SetError(PRODATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(PRODATE.Text) Then
                    EP.SetError(PRODATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If ALLOWMANUALGDNNO = True Then
                If TXTPRONO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PROFORMA.PRO_NO,0)  AS PRONO", "", "PROFORMA", "  AND PROFORMA.PRO_NO=" & TXTPRONO.Text.Trim & " AND PROFORMA.PRO_YEARID = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTPRONO, "Challan No Already Exist")
                        bln = False
                    End If
                End If
            End If



            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Sub RECOSAVE()
        Try

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(PRODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDPROFORMA.Rows
                Dim objclscommon As New ClsCommonMaster
                Dim dt1 As DataTable = objclscommon.search(" ISNULL(MTRS,0) AS MTRS ", "", " BARCODESTOCK", " AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND FROMNO= " & Val(row.Cells(GFROMNO.Index).Value) & " AND FROMSRNO= " & Val(row.Cells(GFROMSRNO.Index).Value) & " AND TYPE='" & row.Cells(GFROMTYPE.Index).Value & "' AND Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    If Val(dt1.Rows(0).Item(0)) <= 3 Then
                        PRESENT = True
                        TEMPMTRS = Val(dt1.Rows(0).Item(0))
                        If gridsrno = "" Then
                            gridsrno = row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                            HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                            QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = row.Cells(GSHADE.Index).Value.ToString
                            PCS = row.Cells(Gpcs.Index).Value.ToString
                            MTRS = TEMPMTRS
                            BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        Else
                            gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value.ToString
                            HSNCODE = HSNCODE & "," & row.Cells(GHSNCODE.Index).Value.ToString
                            QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = COLOR & "," & row.Cells(GSHADE.Index).Value.ToString
                            PCS = PCS & "," & row.Cells(Gpcs.Index).Value.ToString
                            MTRS = MTRS & "," & TEMPMTRS
                            BARCODE = BARCODE & "," & row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = FROMNO & "," & row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = FROMSRNO & "," & row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = FROMTYPE & "," & row.Cells(GFROMTYPE.Index).Value.ToString
                        End If

                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim objclsPurord As New ClsStockAdjustment()
            objclsPurord.alParaval = alParaval

            If PRESENT = True Then Dim DT As DataTable = objclsPurord.SAVE()
            MsgBox("Reco done Successfully!")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDPROFORMA.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
                TabControl1.SelectedIndex = 2
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)

            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")


            'GRID COMBO FIELDS
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
            fillPIECETYPE(CMBPIECETYPE)
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, EDIT)

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_NO,'') AS DESIGN ", "", " DESIGNMASTER ", " AND DESIGN_CMPID = " & CmpId & " AND DESIGN_LOCATIONID = " & Locationid & " AND DESIGN_YEARID = " & YearId & " ORDER BY DESIGN_NO ")
            If DT.Rows.Count > 0 Then
                GDESIGN.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GDESIGN.Items.Add(ROW("DESIGN"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'GDN'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor


            FILLCMB()
            clear()

            If ClientName = "MABHAY" Or ClientName = "SVS" Then Gpcs.ReadOnly = True


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim OBJCLSPROFORMA As New ClsProforma()
                Dim dttable As New DataTable

                dttable = OBJCLSPROFORMA.SELECTPROFORMA(TEMPPRONO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPRONO.Text = TEMPPRONO
                        TXTPRONO.ReadOnly = True
                        'TXTTYPECHALLANNO.Text = Val(dr("TYPECHALLANNO"))
                        PRODATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        'TXTMOBILENO.Text = dr("MOBILENO")
                        CMBDISPATCHTO.Text = dr("DISPATCHTO").ToString
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)
                        TXTMERCHANT.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        txtinwords.Text = Convert.ToString(dr("INWORDS").ToString)
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")
                        TXTCGSTPER.Text = Val(dr("CGSTPER"))
                        TXTSGSTPER.Text = Val(dr("SGSTPER"))
                        TXTIGSTPER.Text = Val(dr("IGSTPER"))
                        txtroundoff.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))

                        GRIDPROFORMA.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("HSNCODE"), dr("QUALITY"), dr("PRINTDESC"), dr("DESIGN"), dr("COLOR"), dr("BALENO"), Format(Val(dr("PCS")), "0"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), dr("SALEDONE"))

                        If Convert.ToBoolean(dr("DONE")) = True Or Convert.ToBoolean(dr("SALERETURN")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next

                    total()
                    GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
                chkchange.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTPRONO.ReadOnly = False Then
                alParaval.Add(Val(TXTPRONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(PRODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBDISPATCHTO.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLAMOUNT.Text))
            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(ClientName)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim QUALITY As String = ""
            Dim PRINTDESC As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BALENO As String = ""

            Dim PCS As String = ""
            Dim CUT As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""
            Dim PER As String = ""
            Dim AMOUNT As String = ""
            Dim BARCODE As String = ""

            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim SALEDONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPROFORMA.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = ""
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GSHADE.Index).Value.ToString
                        If ClientName = "RMANILAL" Or ClientName = "SUNCOTT" Then
                            BALENO = Val(TXTPRONO.Text.Trim)
                        Else
                            If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        End If
                        PCS = Val(row.Cells(Gpcs.Index).Value)
                        If ClientName <> "PURVITEX" Then
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = Val(row.Cells(GCUT.Index).Value)
                        Else
                            CUT = 0
                        End If
                        MTRS = Val(row.Cells(Gmtrs.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        PER = row.Cells(GPER.Index).Value.ToString
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        SALEDONE = row.Cells(GSALEDONE.Index).Value.ToString

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = PRINTDESC & "|" & row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = PRINTDESC & "|" & ""
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GSHADE.Index).Value.ToString
                        If ClientName = "RMANILAL" Or ClientName = "SUNCOTT" Then
                            BALENO = BALENO & "|" & Val(TXTPRONO.Text.Trim)
                        Else
                            If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        End If
                        PCS = PCS & "|" & Val(row.Cells(Gpcs.Index).Value)
                        If ClientName <> "PURVITEX" Then
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = CUT & "|" & Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        Else
                            CUT = CUT & "|" & 0
                        End If
                        MTRS = MTRS & "|" & Val(row.Cells(Gmtrs.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        PER = PER & "|" & row.Cells(GPER.Index).Value.ToString
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString
                        SALEDONE = SALEDONE & "|" & row.Cells(GSALEDONE.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)
            alParaval.Add(QUALITY)
            alParaval.Add(PRINTDESC)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BALENO)
            alParaval.Add(PCS)
            alParaval.Add(CUT)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMOUNT)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(SALEDONE)



            alParaval.Add(Val(TXTTYPECHALLANNO.Text.Trim))


            Dim OBJCLSPROFORMA As New ClsProforma()
            OBJCLSPROFORMA.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTT As DataTable = OBJCLSPROFORMA.SAVE()
                TXTPRONO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

                If ClientName = "SVS" Then
                    If MsgBox("Wish to Stock Reco Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        RECOSAVE()
                    End If
                End If


            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                If ClientName = "SAFFRON" Then
                    Dim OBJCMN As New ClsCommon
                    Dim LOOPTABLE As DataTable = OBJCMN.search("  PROFORMA.PRO_ledgerid AS LEDGERID, PROFORMA_DESC.PRO_ITEMID AS ITEMID, PROFORMA_DESC.PRO_COLORID AS COLORID, PROFORMA_DESC.PRO_PCS AS PCS ", "", " PROFORMA_DESC INNER JOIN PROFORMA ON PROFORMA_DESC.PRO_NO = PROFORMA.PRO_NO AND PROFORMA_DESC.PRO_YEARID = PROFORMA.PRO_YEARID ", " AND PROFORMA.PRO_NO = " & TEMPPRONO & " AND PROFORMA.PRO_YEARID = " & YearId)
                    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " AND LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " AND ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " AND ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " AND SCH_YEARID = " & YearId & " AND  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                        If DTTEMP.Rows.Count > 0 Then
                            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
                        End If
                    Next
                End If

                alParaval.Add(TEMPPRONO)
                IntResult = OBJCLSPROFORMA.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            PRINTREPORT(TXTPRONO.Text.Trim)

            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDPROFORMA.RowCount = 0
LINE1:
            TEMPPRONO = Val(TXTPRONO.Text) - 1

            'IF WE DONT HAVE ANY PREVIOUS RECORDS THEN EXIT
            If ClientName = "MIDAS" Then
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("PRO_NO AS PRONO", "", "PROFORMA", " AND PRO_NO <" & Val(TXTPRONO.Text.Trim) & " AND PRO_YEARID =" & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    clear()
                    EDIT = False
                    Exit Sub
                End If
            End If


            If TEMPPRONO > 0 Then
                EDIT = True
                PROFORMA_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPROFORMA.RowCount = 0 And TEMPPRONO > 1 Then
                TXTPRONO.Text = TEMPPRONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPROFORMA.RowCount = 0
LINE1:
            TEMPPRONO = Val(TXTPRONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTPRONO.Text.Trim
            clear()



            If Val(TXTPRONO.Text) - 1 >= TEMPPRONO Then
                EDIT = True
                PROFORMA_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPROFORMA.RowCount = 0 And TEMPPRONO < MAXNO Then
                TXTPRONO.Text = TEMPPRONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPROFORMA.RowCount = 0
                TEMPPRONO = Val(tstxtbillno.Text)
                If TEMPPRONO > 0 Then
                    EDIT = True
                    PROFORMA_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PRONO As Integer)
        Try
            If MsgBox("Wish to Print Proforma?", MsgBoxStyle.YesNo) = vbYes Then

                Dim OBJPRO As New GDNDESIGN
                OBJPRO.MdiParent = MDIMain
                OBJPRO.FRMSTRING = "PROFORMA"
                OBJPRO.FORMULA = "{PROFORMA.PRO_no}=" & Val(PRONO) & " and {PROFORMA.PRO_yearid}=" & YearId
                OBJPRO.vendorname = cmbname.Text.Trim

                OBJPRO.WHITELABEL = CHKWHITELABEL.Checked
                OBJPRO.HIDEPCSDETAILS = CHKHIDEPCS.Checked

                OBJPRO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPPRONO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND GROUPMASTER.GROUP_NAME <> 'HASTE DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS")
                'Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_TINNO,'') AS TINNO", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                'If DT.Rows.Count > 0 Then LBLTINNO.Text = DT.Rows(0).Item("TINNO")
                'If ClientName <> "KOTHARI" Then TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GRIDGDN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPROFORMA.CellValidating
        Try
            Dim colNum As Integer = GRIDPROFORMA.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum
                Case Gpcs.Index, Gmtrs.Index, GRATE.Index, GCUT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    If bValid Then
                        If GRIDPROFORMA.CurrentCell.Value = Nothing Then GRIDPROFORMA.CurrentCell.Value = "0.00"
                        GRIDPROFORMA.CurrentCell.Value = Convert.ToDecimal(GRIDPROFORMA.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case GPER.Index
                    total()
                Case GBALENO.Index
                    BALECOUNT()
            End Select

            If EDIT = False And ClientName = "KANVASU" Then
                Dim TEMPITEM As String = ""
                For I As Integer = GRIDPROFORMA.CurrentRow.Index + 1 To GRIDPROFORMA.RowCount - 1
                    If I = GRIDPROFORMA.CurrentRow.Index + 1 Then TEMPITEM = GRIDPROFORMA.Item(GITEMNAME.Index, I - 1).Value
                    If GRIDPROFORMA.Item(GITEMNAME.Index, I).Value = TEMPITEM Then
                        GRIDPROFORMA.Item(GPRINTDESC.Index, I).Value = GRIDPROFORMA.Item(GPRINTDESC.Index, I - 1).EditedFormattedValue
                        GRIDPROFORMA.Item(GBALENO.Index, I).Value = GRIDPROFORMA.Item(GBALENO.Index, I - 1).EditedFormattedValue
                    End If
                Next
            End If

            If ClientName = "SBA" Then
                Dim TEMPITEM As String = ""
                For I As Integer = GRIDPROFORMA.CurrentRow.Index + 1 To GRIDPROFORMA.RowCount - 1
                    If I = GRIDPROFORMA.CurrentRow.Index + 1 Then TEMPITEM = GRIDPROFORMA.Item(GITEMNAME.Index, I - 1).Value
                    If GRIDPROFORMA.Item(GITEMNAME.Index, I).Value = TEMPITEM Then GRIDPROFORMA.Item(GRATE.Index, I).Value = GRIDPROFORMA.Item(GRATE.Index, I - 1).EditedFormattedValue
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROFORMA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROFORMA.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPROFORMA.RowCount > 0 Then GRIDPROFORMA.Rows.RemoveAt(GRIDPROFORMA.CurrentRow.Index) ''Removing Row From Grid
            'If GRIDPROFORMA.CurrentRow.Index > 0 Then If e.KeyCode = Keys.F12 Then If GRIDPROFORMA.Rows(GRIDPROFORMA.CurrentRow.Index - 1).Cells(GLRNO.Index).Value <> "" Then GRIDPROFORMA.Rows(GRIDPROFORMA.CurrentRow.Index).Cells(GLRNO.Index).Value = GRIDPROFORMA.Rows(GRIDPROFORMA.CurrentRow.Index - 1).Cells(GLRNO.Index).Value
            If e.KeyCode = Keys.F12 And GRIDPROFORMA.RowCount > 0 Then
                'THIS IS DONE FOR DAKSH, COZ WHEN WE FETCH DATA FROM PACKING WE DONT HAVE BARCODE AND WE NEED TO RUN THIS CODE
                'If GRIDPROFORMA.CurrentRow.Cells(GBARCODE.Index).Value <> "" Then GRIDPROFORMA.Rows.Insert(GRIDPROFORMA.CurrentRow.Index, CloneWithValues(GRIDPROFORMA.CurrentRow))
                GRIDPROFORMA.Rows.Insert(GRIDPROFORMA.CurrentRow.Index, CloneWithValues(GRIDPROFORMA.CurrentRow))
                GRIDPROFORMA.Rows(GRIDPROFORMA.RowCount - 1).Selected = True
            End If

            getsrno(GRIDPROFORMA)
            total()
            If e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F8 Then
                If GRIDPROFORMA.CurrentRow.DefaultCellStyle.BackColor = Color.Linen Then GRIDPROFORMA.CurrentRow.DefaultCellStyle.BackColor = Color.Empty Else GRIDPROFORMA.CurrentRow.DefaultCellStyle.BackColor = Color.Linen
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Sale Invoice / Sale Return Made, Delete it First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Delete Proforma?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                If ClientName = "SAFFRON" Then
                    Dim OBJCMN As New ClsCommon
                    Dim LOOPTABLE As DataTable = OBJCMN.search("  PROFORMA.PRO_ledgerid AS LEDGERID, PROFORMA_DESC.PRO_ITEMID AS ITEMID, PROFORMA_DESC.PRO_COLORID AS COLORID, PROFORMA_DESC.PRO_PCS AS PCS ", "", " PROFORMA_DESC INNER JOIN PROFORMA ON PROFORMA_DESC.PRO_NO = PROFORMA.PRO_NO AND PROFORMA_DESC._YEARID = PROFORMA.PRO_YEARID ", " AND PROFORMA.PRO_NO = " & TEMPPRONO & " AND PROFORMA.PRO_YEARID = " & YearId)
                    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " AND LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " AND ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " AND ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " AND SCH_YEARID = " & YearId & " AND  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                        If DTTEMP.Rows.Count > 0 Then
                            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
                        End If
                    Next
                End If

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPPRONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(ClientName)

                Dim OBJPRO As New ClsProforma
                OBJPRO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJPRO.Delete
                MsgBox("Proforma Deleted")

                clear()
                EDIT = False
                cmbname.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            FILLCMB()



            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                CHKRETAIL.Visible = True
            End If
            If ClientName = "MSANCHITKUMAR" Or ClientName = "SKF" Or ClientName = "PURVITEX" Or ClientName = "SAFFRONOFF" Or ClientName = "MANIBHADRA" Or ClientName = "DEMO" Or ClientName = "SOFTAS" Or ClientName = "ALENCOT" Or ClientName = "MNARESH" Or ClientName = "SUPRIYA" Then
                LBLSRNO.Text = "Bale No"
                txtsrno.Visible = True
                CMBPIECETYPE.Visible = True
                CMBITEMNAME.Visible = True
                CMBQUALITY.Visible = True
                TXTDESCRIPTION.Visible = True
                CMBDESIGN.Visible = True
                CMBCOLOR.Visible = True
                TXTBALENO.Visible = True
                TXTPCS.Visible = True
                TXTCUT.Visible = True
                TXTMTRS.Visible = True
                TXTRATE.Visible = True
                CMBPER.Visible = True
                TXTAMOUNT.Visible = True
                GQUALITY.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                If CMBGODOWN.Text.Trim = "" Then
        '                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
        '                    Exit Sub
        '                End If

        '                Dim OBJCMN As New ClsCommon
        '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    'VALIDATE GODOWN
        '                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim And ClientName <> "SANGHVI" Then
        '                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
        '                        TXTBARCODE.Clear()
        '                        Exit Sub
        '                    End If

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '                    For Each ROW As DataGridViewRow In GRIDPROFORMA.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next

        '                    Dim PER As String = "Mtrs"
        '                    Dim GRIDREMARKS As String = ""
        '                    Dim RATE As Double = 0
        '                    Dim PCS As Double = 0

        '                    If ClientName = "TCOT" Or ClientName = "KCRAYON" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

        '                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
        '                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
        '                        If CHKRETAIL.CheckState = CheckState.Checked Then RATE = DTRATE.Rows(0).Item("SALERATE") Else RATE = DTRATE.Rows(0).Item("WRATE")
        '                        PER = "Pcs"
        '                    End If


        '                    'GET RATE
        '                    'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
        '                    If ClientName = "SBA" Then
        '                        Dim DTRATE As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
        '                        If DTRATE.Rows.Count > 0 AndAlso DTRATE.Rows(0).Item("COLNAME") <> "" Then
        '                            DTRATE = OBJCMN.search(DTRATE.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
        '                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
        '                        End If
        '                    End If

        '                    If ClientName = "KENCOT" Then GRIDREMARKS = DT.Rows(0).Item("GRIDREMARKS")


        '                    'GET HSNCODE
        '                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", " AND ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
        '                    GRIDPROFORMA.Rows.Add(GRIDPROFORMA.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), GRIDREMARKS, DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), PCS, Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), RATE, PER, 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
        '                    total()
        '                    GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1


        'LINE1:
        '                    TXTBARCODE.Clear()
        '                    TXTBARCODE.Focus()
        '                End If
        '            End If

        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTGDN As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            If ClientName <> "SANGHVI" Then OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            If ALLOWPACKINGSLIP = True Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
            OBJSELECTGDN.ShowDialog()
            DTGDN = OBJSELECTGDN.DT

            If DTGDN.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTGDN.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPROFORMA.Rows
                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                    Next

                    If Val(DTROWPS("PCS")) = 0 Then DTROWPS("PCS") = 1
                    If (ClientName <> "SAKARIA" And ClientName <> "ALENCOT") AndAlso Val(DTROWPS("CUT")) = 0 Then DTROWPS("CUT") = Val(DTROWPS("MTRS"))

                    Dim PER As String = "Mtrs"
                    Dim CCRATE As Double = 0
                    Dim CUT As Double = 0

                    If ClientName = "SOFTAS" Or ClientName = "DEVEN" Or ClientName = "RSONS" Then CUT = 0 Else CUT = Format(Val(DTROWPS("CUT")), "0.00")

                    Dim OBJCMN As New ClsCommon
                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DTROWPS("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        If CHKRETAIL.CheckState = CheckState.Checked Then CCRATE = DTRATE.Rows(0).Item("SALERATE") Else CCRATE = DTRATE.Rows(0).Item("WRATE")
                        PER = "Pcs"
                    End If

                    'GET HSNCODE
                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", " AND ITEM_NAME = '" & DTROWPS("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                    GRIDPROFORMA.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DTROWPS("QUALITY"), "", DTROWPS("DESIGNNO"), DTROWPS("COLOR"), DTROWPS("BALENO"), Val(DTROWPS("PCS")), CUT, Format(Val(DTROWPS("MTRS")), "0.00"), CCRATE, PER, 0, DTROWPS("BARCODE"), DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0)


LINE1:
                Next
                CMDSELECTSTOCK.Enabled = True
                getsrno(GRIDPROFORMA)
                total()
                GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRODATE.GotFocus
        PRODATE.SelectAll()
    End Sub

    Private Sub PRODATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PRODATE.Validating
        Try
            If PRODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PRODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then CITYVALIDATE(cmbcity, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcity.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then cmbcity.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If ClientName = "SKF" And CMBQUALITY.Text.Trim = "" Then
                MsgBox("Enter Proper Details")
                Exit Sub
            End If

            If ClientName = "PURVITEX" And CMBCOLOR.Text.Trim = "" Then
                MsgBox("Enter Shade Details")
                Exit Sub
            End If

            If CMBPIECETYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
                FILLGRID()
                total()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        GRIDPROFORMA.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPROFORMA.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, TXTDESCRIPTION.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMOUNT.Text.Trim), "0.00"), "", 0, 0, 0, 0)
            getsrno(GRIDPROFORMA)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPROFORMA.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDPROFORMA.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
            GRIDPROFORMA.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDPROFORMA.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim
            GRIDPROFORMA.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDPROFORMA.Item(GPRINTDESC.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
            GRIDPROFORMA.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDPROFORMA.Item(GSHADE.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDPROFORMA.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            GRIDPROFORMA.Item(Gpcs.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDPROFORMA.Item(GCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            GRIDPROFORMA.Item(Gmtrs.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDPROFORMA.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDPROFORMA.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDPROFORMA.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False

        End If

        CALC()
        total()

        GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1

        If ClientName <> "SKF" And ClientName <> "MANIBHADRA" And ClientName <> "ALENCOT" And ClientName <> "MNARESH" And ClientName <> "SOFTAS" Then
            CMBPIECETYPE.Text = ""
            CMBITEMNAME.Text = ""
            TXTHSNCODE.Clear()
            CMBQUALITY.Text = ""
            TXTDESCRIPTION.Clear()
            CMBDESIGN.Text = ""
            CMBCOLOR.Text = ""
            TXTBALENO.Clear()
            TXTPCS.Clear()
            TXTCUT.Clear()
            TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBPER.SelectedItem = Nothing
            TXTAMOUNT.Clear()
            CMBPIECETYPE.Focus()
        Else
            If ClientName <> "SKF" Then TXTMTRS.Clear()
            TXTMTRS.Focus()
        End If
        txtsrno.Text = Val(GRIDPROFORMA.RowCount) + 1

    End Sub

    Private Sub GRIDPROFORMA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROFORMA.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDPROFORMA.CurrentRow.Index >= 0 And GRIDPROFORMA.Item(GSRNO.Index, GRIDPROFORMA.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True

                txtsrno.Text = GRIDPROFORMA.Item(GSRNO.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDPROFORMA.Item(GPIECETYPE.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDPROFORMA.Item(GITEMNAME.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDPROFORMA.Item(GHSNCODE.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPROFORMA.Item(GQUALITY.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDPROFORMA.Item(GPRINTDESC.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDPROFORMA.Item(GDESIGN.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDPROFORMA.Item(GSHADE.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDPROFORMA.Item(GBALENO.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDPROFORMA.Item(Gpcs.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString

                TXTCUT.Text = GRIDPROFORMA.Item(GCUT.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDPROFORMA.Item(Gmtrs.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDPROFORMA.Item(GRATE.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDPROFORMA.Item(GPER.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDPROFORMA.Item(GAMOUNT.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDPROFORMA.CurrentRow.Index
                CMBPIECETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress, TXTMTRS.KeyPress, TXTRATE.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = 0.0
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTPCS.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMOUNT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMOUNT.Text = Format(Val(TXTPCS.Text) * Val(TXTRATE.Text), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPER.Validated
        Try
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtPROno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPRONO.KeyPress
        numkeypress(e, TXTPRONO, Me)
    End Sub

    Private Sub txtPROno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPRONO.Validating
        Try
            If Val(TXTPRONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PROFORMA.PRO_NO,0)  AS PRONO", "", " PROFORMA ", "  AND PROFORMA.PRO_NO=" & TXTPRONO.Text.Trim & " AND PROFORMA.PRO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Proforma No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBDISPATCHTO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDISPATCHTO.Enter
        Try
            If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        Try
            If ClientName = "MANIBHADRA" Then TXTAMOUNT_Validating(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(sender As Object, e As EventArgs) Handles TXTCUT.Validated, TXTPCS.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 And Val(TXTPCS.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTPCS.Text.Trim) * Val(TXTCUT.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try

            If GRIDPROFORMA.RowCount > 0 Then

                TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()


                If Convert.ToDateTime(PRODATE.Text).Date >= "01/07/2017" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As New DataTable
                    DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & GRIDPROFORMA.Rows(0).Cells(GITEMNAME.Index).Value & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                    If DT.Rows.Count > 0 Then
                        TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")

                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If
                    CALC()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" And Convert.ToDateTime(PRODATE.Text).Date >= "01/07/2017" Then GETHSNCODE()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" And CMBDISPATCHTO.Text.Trim = "" Then CMBDISPATCHTO.Text = cmbname.Text.Trim

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN,  ISNULL(CITYMASTER.city_name, '') AS CITY ", "", "STATEMASTER LEFT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_DELIVERYATID = CITYMASTER.city_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' and LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If cmbname.Text.Trim = CMBDISPATCHTO.Text.Trim Then cmbcity.Text = DT.Rows(0).Item("CITY")
                TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
            End If

            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDRECO_Click(sender As Object, e As EventArgs) Handles CMDRECO.Click
        Try
            If EDIT = True Then
                Dim OBJRECO As New StockReco
                OBJRECO.TEMPPROFORMANO = Val(TXTPRONO.Text.Trim)
                OBJRECO.MdiParent = MDIMain
                OBJRECO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCHALLAN_Click(sender As Object, e As EventArgs) Handles CMDCHALLAN.Click
        Try
            If EDIT = True Then
                Dim OBJGDN As New GDN
                OBJGDN.TEMPPROFORMANO = Val(TXTPRONO.Text.Trim)
                OBJGDN.MdiParent = MDIMain
                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New ProformaDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBDISPATCHTO.Validating
        Try
            If CMBDISPATCHTO.Text.Trim <> "" Then namevalidate(CMBDISPATCHTO, CMBCODE, e, Me, txtadd, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(sender As Object, e As EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim And ClientName <> "SANGHVI" Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPROFORMA.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PER As String = "Mtrs"
                    Dim GRIDREMARKS As String = ""
                    Dim RATE As Double = 0
                    Dim PCS As Double = 0

                    If ClientName = "TCOT" Or ClientName = "KCRAYON" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        If CHKRETAIL.CheckState = CheckState.Checked Then RATE = DTRATE.Rows(0).Item("SALERATE") Else RATE = DTRATE.Rows(0).Item("WRATE")
                        PER = "Pcs"
                    End If


                    'GET RATE
                    'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
                    If ClientName = "SBA" Then
                        Dim DTRATE As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                        If DTRATE.Rows.Count > 0 AndAlso DTRATE.Rows(0).Item("COLNAME") <> "" Then
                            DTRATE = OBJCMN.search(DTRATE.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
                        End If
                    End If

                    If ClientName = "KENCOT" Then GRIDREMARKS = DT.Rows(0).Item("GRIDREMARKS")


                    'GET HSNCODE
                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", " AND ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                    GRIDPROFORMA.Rows.Add(GRIDPROFORMA.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), GRIDREMARKS, DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), PCS, Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), RATE, PER, 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
                    total()
                    GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1


LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

