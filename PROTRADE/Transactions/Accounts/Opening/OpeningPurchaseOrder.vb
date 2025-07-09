
Imports System.Windows.Forms
Imports BL

Public Class OpeningPurchaseOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public Shared dt_quot As New DataTable
    Public Shared dt_poamend As New DataTable
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPOPONO As Integer
    Dim tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETMAX_OPO_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(opo_no),0) + 1 ", "OPENINGPURCHASEORDER", " and opo_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTOPONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        cmbname.Text = ""
        cmbname.Enabled = True
        TXTMOBILENO.Clear()

        txtdiscount.Clear()
        txtquotation.Clear()
        quotationdate.Value = Now.Date
        cmb.Text = Now.Date
        txtRefno.Clear()
        TXTDELPERIOD.Clear()
        duedate.Value = Now.Date
        TXTCRDAYS.Clear()
        CMBTRANS.Text = ""
        CMBBROKER.Text = ""

        txtsrno.Text = 1
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        txtrate.Clear()
        TXTAMOUNT.Clear()
        cmbtoname.Text = ""
        EP.Clear()

        CMBDESIGN.Text = ""
        CHKVERIFY.CheckState = CheckState.Unchecked
        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()
        txtinwordedu.Clear()
        txtinwordexcise.Clear()
        txtinwordhse.Clear()
        txtinwords.Clear()
        txtadd.Clear()
        lbltotalamt.Text = "0.00"
        lbltotalqty.Text = "0.00"
        LBLTOTALMTRS.Text = 0
        gridpo.RowCount = 0
        GETMAX_OPO_NO()
        cmdselectQuot.Enabled = True
        GRIDDOUBLECLICK = False

        txtbillamt.Text = 0.0
        txtdisper.Text = 0.0
        txtdisamt.Text = 0.0
        txtpfper.Text = 0.0
        txtpfamt.Text = 0.0
        txttestchgs.Text = 0.0
        txtnett.Text = 0.0

        TXTEXCISE.Text = 0.0
        txtexciseAMT.Text = 0.0

        TXTEDUCESS.Text = 0.0
        txteducessAMT.Text = 0.0

        TXTHSECESS.Text = 0.0
        txthsecessAMT.Text = 0.0

        txtsubtotal.Text = 0.0

        cmbtax.Text = ""
        txttax.Text = 0.0

        cmbaddtax.Text = ""
        txtaddtax.Text = 0.0

        txtfrper.Text = 0.0
        txtfreight.Text = 0.0

        cmboctroi.Text = ""
        txtoctroi.Text = 0.0

        txtinspchgs.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        txtremarks.Clear()

        chkexcise.Checked = False
        getexcise()
        LBLSMS.Visible = False
        TXTPDESNO.Clear()
        TXTPSHADE.Clear()
        GrpAccount.Visible = False

        cmdselectQuot.Enabled = True
        CMBORDERTYPE.SelectedIndex = 0

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub PurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            'If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            '    Me.Close()
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                gridpo.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New OpeningPurchaseOrderDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call TOOLPREVIOUS_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call TOOLNEXT_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call TOOLPRINT_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If cmbtoname.Text.Trim = "" Then fillname(cmbtoname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBBROKER.Text.Trim = "" Then fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            fillQUALITY(CMBQUALITY, EDIT)
            fillunit(cmbqtyunit)
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim objclsPO As New ClsOpeningPurchaseOrder()
                Dim dt_opo As DataTable = objclsPO.selectopo(TEMPOPONO, CmpId, Locationid, YearId)


                If dt_opo.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_opo.Rows

                        TXTOPONO.Text = dr("OPONO")
                        cmb.Text = Format(Convert.ToDateTime(dr("OPODATE")), "dd/MM/yyyy")
                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        TXTDELPERIOD.Text = Val(dr("DELDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))


                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))
                        txtdiscount.Text = Convert.ToString(dr("DISCOUNT"))

                        txtquotation.Text = Convert.ToString(dr("QUOTNO"))
                        txtRefno.Text = Convert.ToString(dr("REFNO"))
                        quotationdate.Value = Convert.ToDateTime(dr("QUOTDATE"))

                        CMBTRANS.Text = Convert.ToString(dr("TRANSNAME"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        CMBBROKER.Text = Convert.ToString(dr("BROKER"))
                        CMBORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))

                        gridpo.Rows.Add(dr("POGRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("GRIDREMARKS").ToString, dr("QUALITY").ToString, dr("COUNT").ToString, dr("REED").ToString, dr("PICK").ToString, dr("WIDTH").ToString, dr("WT").ToString, dr("DESIGN").ToString, dr("COLORNAME").ToString, dr("PDESNO").ToString, dr("PSHADE").ToString, Format(Val(dr("POQTY")), "0.00"), dr("Unit").ToString, Val(dr("CUT")), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("rate")), "0.00"), dr("PER"), Format(Val(dr("amt")), "0.00"), dr("GRIDQUOTNO").ToString, dr("QUOTGRIDSRNO").ToString, Val(dr("RECDQTY")), dr("GRIDPODONE").ToString, dr("TONAME").ToString)

                        txtdisper.Text = dr("PO_DISPER")
                        txtdisamt.Text = dr("PO_DISAMT")
                        txtpfper.Text = dr("PO_PFPER")
                        txtpfamt.Text = dr("PO_PFAMT")
                        txttestchgs.Text = dr("PO_TESTCHGS")
                        txtnett.Text = dr("PO_NETT")

                        txtsubtotal.Text = dr("PO_SUBTOTAL")
                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("PO_TAXAMT")
                        cmbaddtax.Text = dr("ADDTAXNAME")
                        txtaddtax.Text = dr("PO_ADDTAXAMT")
                        txtfrper.Text = dr("PO_FRPER")
                        txtfreight.Text = dr("PO_FREIGHT")
                        cmboctroi.Text = dr("OCTROINAME")
                        txtoctroi.Text = dr("PO_OCTROIAMT")
                        txtinspchgs.Text = dr("PO_INSAMT")
                        txtroundoff.Text = dr("PO_ROUNDOFF")
                        txtgrandtotal.Text = dr("PO_GRANDTOTAL")

                        If Convert.ToBoolean(dr("VERIFIED")) = True Then CHKVERIFY.CheckState = CheckState.Checked
                        If Convert.ToBoolean(dr("SMSSEND")) = True Then LBLSMS.Visible = True


                        If Val(dr("RECDQTY")) > 0 Or Val(dr("RECDMTRS")) > 0 Then
                            gridpo.Rows(gridpo.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            cmbname.Enabled = False
                            cmdselectQuot.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            gridpo.Rows(gridpo.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1

                End If
                chkchange.CheckState = CheckState.Checked
                total()
            Else
                EDIT = False
                clear()
            End If

            If gridpo.RowCount > 0 Then
                txtsrno.Text = Val(gridpo.Rows(gridpo.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, cmbcode, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(cmb.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(duedate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(Val(TXTDELPERIOD.Text.Trim))
            alParaval.Add(txtRefno.Text.Trim)
            alParaval.Add(txtquotation.Text.Trim)
            alParaval.Add(quotationdate.Value)
            alParaval.Add(txtdiscount.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBORDERTYPE.Text.Trim)
            alParaval.Add(Val(lbltotalqty.Text.Trim))
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))


            alParaval.Add(txtdisper.Text.Trim)
            alParaval.Add(txtdisamt.Text.Trim)
            alParaval.Add(txtpfper.Text.Trim)
            alParaval.Add(txtpfamt.Text.Trim)
            alParaval.Add(txttestchgs.Text.Trim)
            alParaval.Add(txtnett.Text.Trim)
            alParaval.Add(Val(TXTEXCISEID.Text.Trim))
            alParaval.Add(TXTEXCISE.Text.Trim)
            alParaval.Add(txtexciseAMT.Text.Trim)
            alParaval.Add(TXTEDUCESS.Text.Trim)
            alParaval.Add(txteducessAMT.Text.Trim)
            alParaval.Add(TXTHSECESS.Text.Trim)
            alParaval.Add(txthsecessAMT.Text.Trim)
            alParaval.Add(txtsubtotal.Text.Trim)
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(txttax.Text.Trim)
            alParaval.Add(cmbaddtax.Text.Trim)
            alParaval.Add(txtaddtax.Text.Trim)
            alParaval.Add(txtfrper.Text.Trim)
            alParaval.Add(txtfreight.Text.Trim)
            alParaval.Add(cmboctroi.Text.Trim)
            alParaval.Add(txtoctroi.Text.Trim)
            alParaval.Add(txtinspchgs.Text.Trim)
            alParaval.Add(txtroundoff.Text.Trim)
            alParaval.Add(txtgrandtotal.Text.Trim)

            If lbllocked.Visible = False Then alParaval.Add(0) Else alParaval.Add(1) 'PO DONE

            If UserName = "Admin" Then
                alParaval.Add(CHKVERIFY.Checked)    'VERIFIED
            Else
                alParaval.Add(0)    'VERIFIED
            End If


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim QUALITY As String = ""
            Dim COUNT As String = ""
            Dim REED As String = ""
            Dim PICK As String = ""
            Dim WIDTH As String = ""
            Dim WT As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PDESNO As String = ""
            Dim PSHADE As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim rate As String = ""
            Dim PER As String = ""
            Dim amount As String = ""
            Dim QUOTNO As String = ""         'value of QUOTNO
            Dim QUOTgridsrno As String = ""   'value of QUOTGRIDSRNO
            Dim recdqty As String = ""      'Qty recd in GRN
            Dim GRNDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim TONAME As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim CLOSED As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridpo.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        COUNT = row.Cells(gcount.Index).Value.ToString
                        REED = row.Cells(GREED.Index).Value.ToString
                        PICK = row.Cells(GPICK.Index).Value.ToString
                        WIDTH = row.Cells(gwidth.Index).Value.ToString
                        WT = row.Cells(Gwt.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        PDESNO = row.Cells(GPDESNO.Index).Value.ToString
                        PSHADE = row.Cells(GPSHADE.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        rate = row.Cells(grate.Index).Value
                        PER = row.Cells(gper.Index).Value.ToString
                        amount = row.Cells(gamt.Index).Value

                        If row.Cells(gquotno.Index).Value <> Nothing Then
                            QUOTNO = row.Cells(gquotno.Index).Value
                        Else
                            QUOTNO = "0"
                        End If

                        If row.Cells(gquogridsrno.Index).Value <> Nothing Then
                            QUOTgridsrno = row.Cells(gquogridsrno.Index).Value
                        Else
                            QUOTgridsrno = 0
                        End If

                        recdqty = row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRNDONE = 1
                        Else
                            GRNDONE = 0
                        End If
                        TONAME = row.Cells(gtoname.Index).Value
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        COUNT = COUNT & "|" & row.Cells(GREED.Index).Value.ToString
                        REED = REED & "|" & row.Cells(GREED.Index).Value.ToString
                        PICK = PICK & "|" & row.Cells(GPICK.Index).Value.ToString
                        WIDTH = WIDTH & "|" & row.Cells(gwidth.Index).Value.ToString
                        WT = WT & "|" & row.Cells(Gwt.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        PDESNO = PDESNO & "|" & row.Cells(GPDESNO.Index).Value.ToString
                        PSHADE = PSHADE & "|" & row.Cells(GPSHADE.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        rate = rate & "|" & row.Cells(grate.Index).Value
                        PER = PER & "|" & row.Cells(gper.Index).Value.ToString
                        amount = amount & "|" & row.Cells(gamt.Index).Value

                        If row.Cells(gquotno.Index).Value <> Nothing Then
                            QUOTNO = QUOTNO & "|" & row.Cells(gquotno.Index).Value
                        Else
                            QUOTNO = QUOTNO & "|" & "0"
                        End If

                        If row.Cells(gquogridsrno.Index).Value <> Nothing Then
                            QUOTgridsrno = QUOTgridsrno & "|" & Val(row.Cells(gquogridsrno.Index).Value)
                        Else
                            QUOTgridsrno = QUOTgridsrno & "|" & "0"
                        End If

                        recdqty = recdqty & "|" & row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRNDONE = GRNDONE & "|" & "1"
                        Else
                            GRNDONE = GRNDONE & "|" & "0"
                        End If
                        TONAME = TONAME & "|" & row.Cells(gtoname.Index).Value
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(QUALITY)
            alParaval.Add(COUNT)
            alParaval.Add(REED)
            alParaval.Add(PICK)
            alParaval.Add(WIDTH)
            alParaval.Add(WT)
            alParaval.Add(CUT)
            alParaval.Add(PER)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PDESNO)
            alParaval.Add(PSHADE)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(QUOTNO)
            alParaval.Add(QUOTgridsrno)
            alParaval.Add(recdqty)
            alParaval.Add(GRNDONE)
            alParaval.Add(TONAME)
            alParaval.Add(CLOSED)

            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)

            Dim objclsPurord As New ClsOpeningPurchaseOrder()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.save()
                MessageBox.Show("Details Added")
                TXTOPONO.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPOPONO)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.Update()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                PRINTREPORT()
            End If

            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        'If gridpo.RowCount = 0 Then
        '    EP.SetError(txtamount, "Enter Item Details")
        '    bln = False
        'End If

        For Each row As DataGridViewRow In gridpo.Rows
            If row.Cells(gqtyunit.Index).Value.ToString = "" Then
                EP.SetError(cmbqtyunit, "Unit Cannot be Blank")
                bln = False
            End If

            If Val(row.Cells(gQty.Index).Value) = 0 Then
                EP.SetError(txtqty, "Qty Cannot be 0")
                bln = False
            End If
        Next

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If


        If cmb.Text = "__/__/____" Then
            EP.SetError(cmb, " Please Enter Proper Date")
            bln = False
            'DONT VALIDATE DATE HERE, COZ THIS DATE WILL BE OF LAST YEAR
            'Else
            '    If Not datecheck(cmb.Text) Then
            '        EP.SetError(cmb, "Date not in Accounting Year")
            '        bln = False
            '    End If
        End If

        Return bln
    End Function

    Sub total()

        If gridpo.RowCount > 0 Then
            Dim temptaxper As Double = 0
            Dim tempaddtaxper As Double = 0
            Dim tempoctroitaxper As Double = 0

            lbltotalqty.Text = "0.00"
            LBLTOTALMTRS.Text = 0
            lbltotalamt.Text = "0.00"

            txtbillamt.Text = 0.0
            txtdisamt.Text = 0.0
            txtpfamt.Text = 0.0
            txtnett.Text = 0.0

            txtexciseAMT.Text = 0.0
            txteducessAMT.Text = 0.0
            txthsecessAMT.Text = 0.0

            txtsubtotal.Text = 0.0

            txttax.Text = 0.0
            txtaddtax.Text = 0.0
            If Val(txtfrper.Text.Trim) > 0 Then txtfreight.Text = 0.0
            txtoctroi.Text = 0.0

            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0


            For Each row As DataGridViewRow In gridpo.Rows
                If Val(row.Cells(gQty.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
                If Val(row.Cells(GMTRS.Index).Value) <> 0 Then LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GMTRS.Index).Value), "0.00")
                If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value)
            Next

            txtbillamt.Text = Val(lbltotalamt.Text.Trim)
            txtdisamt.Text = (Val(txtdisper.Text) * Val(txtbillamt.Text)) / 100
            txtpfamt.Text = (Val(txtpfper.Text) * Val(txtbillamt.Text)) / 100

            txtnett.Text = (txtbillamt.Text) - Val(txtdisamt.Text) + Val(txtpfamt.Text) + Val(txttestchgs.Text)

            txtexciseAMT.Text = (Val(TXTEXCISE.Text) * Val(txtnett.Text)) / 100
            txteducessAMT.Text = Val((Val(TXTEDUCESS.Text) * Val(txtexciseAMT.Text)) / 100)
            txthsecessAMT.Text = (Val(TXTHSECESS.Text) * Val(txtexciseAMT.Text)) / 100

            txtsubtotal.Text = Val(txtnett.Text) + Val(txteducessAMT.Text) + Val(txtexciseAMT.Text) + Val(txthsecessAMT.Text)


            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then temptaxper = dt.Rows(0).Item(1)

            dt.Reset()
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbaddtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then tempaddtaxper = dt.Rows(0).Item(1)

            txttax.Text = (Val(temptaxper) * Val(txtsubtotal.Text)) / 100
            txtaddtax.Text = (Val(tempaddtaxper) * Val(txtsubtotal.Text)) / 100
            If Val(txtfrper.Text.Trim) > 0 Then txtfreight.Text = (Val(txtfrper.Text) * Val(txtbillamt.Text)) / 100

            dt.Reset()
            dt = objclscommon.search("OCTROI_NAME,OCTROI_octroi", "", "OCTROIMaster", " and OCTROI_NAME = '" & cmboctroi.Text.Trim & "' and OCTROI_cmpid = " & CmpId & " and OCTROI_Locationid = " & Locationid & " and OCTROI_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then tempoctroitaxper = dt.Rows(0).Item(1)

            txtoctroi.Text = (Val(tempoctroitaxper) * (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text))) / 100
            txtgrandtotal.Text = Format(Val(txtoctroi.Text) + Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtinspchgs.Text), "0")

            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtoctroi.Text) + Val(txtinspchgs.Text)), "0.00")
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
            If Val(txtexciseAMT.Text) > 0 Then txtinwordexcise.Text = CurrencyToWord(txtexciseAMT.Text)
            If Val(txteducessAMT.Text) > 0 Then txtinwordedu.Text = CurrencyToWord(txteducessAMT.Text)
            If Val(txthsecessAMT.Text) > 0 Then txtinwordhse.Text = CurrencyToWord(txthsecessAMT.Text)

        Else
            lbltotalqty.Text = "0.00"
            LBLTOTALMTRS.Text = 0
            lbltotalamt.Text = "0.00"
        End If
    End Sub

    Sub getexcise()
        'Try
        '    If chkexcise.CheckState = CheckState.Checked Then
        '        TXTEXCISEID.Text = 0
        '        TXTEXCISE.Text = 0.0
        '        TXTEDUCESS.Text = 0.0
        '        TXTHSECESS.Text = 0.0
        '        Dim objcmn As New ClsCommon
        '        Dim DT As DataTable = objcmn.search(" ISNULL(MAX(EXCISE_ID),0)", "", " EXCISEMASTER ", " AND EXCISE_wef <= '" & Format(podate.Value.Date, "MM/dd/yyyy") & "' AND EXCISE_CMPID = " & CmpId & " AND EXCISE_LOCATIONID = " & Locationid & " AND EXCISE_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then
        '            TXTEXCISEID.Text = DT.Rows(0).Item(0)
        '        End If

        '        DT.Reset()
        '        DT = objcmn.search(" EXCISE_NAME, EXCISE_EDU, EXCISE_HSE", "", " EXCISEMASTER", " AND EXCISE_ID = " & TXTEXCISEID.Text.Trim & "AND EXCISE_CMPID = " & CmpId & " AND EXCISE_LOCATIONID = " & Locationid & " AND EXCISE_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then
        '            TXTEXCISE.Text = DT.Rows(0).Item(0)
        '            TXTEDUCESS.Text = DT.Rows(0).Item(1)
        '            TXTHSECESS.Text = DT.Rows(0).Item(2)
        '            total()
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If gridpo.RowCount > 0 Then
                txtsrno.Text = Val(gridpo.Rows(gridpo.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
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

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
            If CMBQUALITY.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(UNITMASTER.unit_abbr,'') AS UNIT, ISNULL(QUALITYMASTER.QUALITY_REED,0) AS REED, ISNULL(QUALITYMASTER.QUALITY_PICK,0) AS PICK, ISNULL(QUALITYMASTER.QUALITY_COUNT,0) AS COUNT, ISNULL(QUALITYMASTER.QUALITY_WIDTH,0) AS WIDTH ", "", "   QUALITYMASTER LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_unitid = UNITMASTER.unit_id AND QUALITYMASTER.QUALITY_cmpid = UNITMASTER.unit_cmpid AND QUALITYMASTER.QUALITY_locationid = UNITMASTER.unit_locationid AND QUALITYMASTER.QUALITY_yearid = UNITMASTER.unit_yearid  ", " and QUALITYMASTER.QUALITY_Name = '" & CMBQUALITY.Text.Trim & "' and QUALITYMASTER.QUALITY_cmpid = " & CmpId & " and QUALITYMASTER.QUALITY_locationid = " & Locationid & " and QUALITYMASTER.QUALITY_yearid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If cmbqtyunit.Text.Trim = "" Then cmbqtyunit.Text = DT.Rows(0).Item("UNIT")
                    If TXTREED.Text.Trim = "" Then TXTREED.Text = DT.Rows(0).Item("REED")
                    If TXTPICK.Text.Trim = "" Then TXTPICK.Text = DT.Rows(0).Item("PICK")
                    If txtcount.Text.Trim = "" Then txtcount.Text = DT.Rows(0).Item("COUNT")
                    If txtwidth.Text.Trim = "" Then txtwidth.Text = DT.Rows(0).Item("WIDTH")
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Sub fillgrid()

        gridpo.Enabled = True
        If GRIDDOUBLECLICK = False Then
            gridpo.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, CMBQUALITY.Text.Trim, Val(txtcount.Text.Trim), Val(TXTREED.Text.Trim), Val(TXTPICK.Text.Trim), Val(txtwidth.Text.Trim), Val(txtwtg.Text.Trim), CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTPDESNO.Text.Trim, TXTPSHADE.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim, Val(TXTCUT.Text.Trim), Val(TXTMTRS.Text.Trim), Val(txtrate.Text.Trim), CMBPER.Text.Trim, Val(TXTAMOUNT.Text.Trim), 0, 0, 0, 0, cmbtoname.Text)
            getsrno(gridpo)
        ElseIf GRIDDOUBLECLICK = True Then
            gridpo.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            gridpo.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
            gridpo.Item(gdesc.Index, TEMPROW).Value = txtgridremarks.Text.Trim
            gridpo.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            gridpo.Item(gcount.Index, TEMPROW).Value = txtcount.Text.Trim
            gridpo.Item(GREED.Index, TEMPROW).Value = TXTREED.Text.Trim
            gridpo.Item(GPICK.Index, TEMPROW).Value = TXTPICK.Text.Trim
            gridpo.Item(gwidth.Index, TEMPROW).Value = txtwidth.Text.Trim
            gridpo.Item(Gwt.Index, TEMPROW).Value = txtwtg.Text.Trim
            gridpo.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            gridpo.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            gridpo.Item(GPDESNO.Index, TEMPROW).Value = TXTPDESNO.Text.Trim
            gridpo.Item(GPSHADE.Index, TEMPROW).Value = TXTPSHADE.Text.Trim
            gridpo.Item(gQty.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
            gridpo.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
            gridpo.Item(GCUT.Index, TEMPROW).Value = TXTCUT.Text.Trim
            gridpo.Item(GMTRS.Index, TEMPROW).Value = Val(TXTMTRS.Text.Trim)
            gridpo.Item(grate.Index, TEMPROW).Value = Val(txtrate.Text.Trim)
            gridpo.Item(gper.Index, TEMPROW).Value = CMBPER.Text
            gridpo.Item(gamt.Index, TEMPROW).Value = Val(TXTAMOUNT.Text.Trim)
            gridpo.Item(gtoname.Index, TEMPROW).Value = cmbtoname.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1

        txtsrno.Text = gridpo.RowCount + 1
        'cmbitemname.Text = ""
        'cmbtoname.Text = ""
        txtgridremarks.Clear()
        'CMBQUALITY.Text = ""
        'TXTREED.Clear()
        'TXTPICK.Clear()
        'txtwidth.Clear()
        'TXTCUT.Clear()
        'txtwtg.Clear()
        'txtcount.Clear()
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        txtqty.Clear()
        TXTPDESNO.Clear()
        TXTPSHADE.Clear()
        'cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        'txtrate.Clear()
        'TXTAMOUNT.Clear()

        cmbitemname.Focus()

    End Sub

    Private Sub gridpo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpo.CellDoubleClick
        If e.RowIndex >= 0 And gridpo.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(gridpo.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(gridpo.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            GRIDDOUBLECLICK = True
            txtsrno.Text = gridpo.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridpo.Item(gitemname.Index, e.RowIndex).Value.ToString
            txtgridremarks.Text = gridpo.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = gridpo.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            TXTREED.Text = gridpo.Item(GREED.Index, e.RowIndex).Value.ToString
            TXTPICK.Text = gridpo.Item(GPICK.Index, e.RowIndex).Value.ToString
            CMBDESIGN.Text = gridpo.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridpo.Item(gcolor.Index, e.RowIndex).Value.ToString
            TXTPDESNO.Text = gridpo.Item(GPDESNO.Index, e.RowIndex).Value.ToString
            TXTPSHADE.Text = gridpo.Item(GPSHADE.Index, e.RowIndex).Value.ToString
            txtqty.Text = gridpo.Item(gQty.Index, e.RowIndex).Value.ToString
            txtcount.Text = gridpo.Item(gcount.Index, e.RowIndex).Value.ToString
            txtwidth.Text = gridpo.Item(gwidth.Index, e.RowIndex).Value.ToString
            txtwtg.Text = gridpo.Item(Gwt.Index, e.RowIndex).Value.ToString
            TXTCUT.Text = gridpo.Item(GCUT.Index, e.RowIndex).Value.ToString
            cmbqtyunit.Text = gridpo.Item(gqtyunit.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = gridpo.Item(GMTRS.Index, e.RowIndex).Value.ToString
            txtrate.Text = gridpo.Item(grate.Index, e.RowIndex).Value.ToString
            CMBPER.Text = gridpo.Item(gper.Index, e.RowIndex).Value.ToString
            cmbtoname.Text = gridpo.Item(gtoname.Index, e.RowIndex).Value.ToString
            TXTAMOUNT.Text = gridpo.Item(gamt.Index, e.RowIndex).Value.ToString

            TEMPROW = e.RowIndex
            cmbitemname.Focus()
        End If
    End Sub

    Private Sub txtrate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        CALC()
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdot(e, txtrate, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb.GotFocus
        cmb.SelectAll()
    End Sub

    Private Sub PODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmb.Validating
        Try
            If cmb.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(cmb.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            Dim done As Boolean
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("OPO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Opening Purchase Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPOPONO)
                alParaval.Add(YearId)

                Dim clspo As New ClsOpeningPurchaseOrder()
                clspo.alParaval = alParaval
                IntResult = clspo.Delete()
                MsgBox("Opening Purchase Order Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS", CMBTRANS.Text.Trim, CMBBROKER.Text)
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_CRDAYS,0),  isnull(LEDGERS_1.Acc_cmpname,'') AS transport, isnull(LEDGERS_2.Acc_cmpname,'') AS agent, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(LEDGERS.ACC_EMAIL,'') AS EMAIL, ISNULL(LEDGERS.ACC_DISC,0) AS DISC ", "", "  LEDGERS LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid And LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid ", " AND ledgers.ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ledgers.ACC_CMPID = " & CmpId & " AND ledgers.ACC_LOCATIONID = " & Locationid & " AND ledgers.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(TXTCRDAYS.Text.Trim) = 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item(0))
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    TXTEMAILADD.Text = DT.Rows(0).Item("EMAIL")
                    If Val(txtdiscount.Text.Trim) = 0 Then txtdiscount.Text = Val(DT.Rows(0).Item("DISC"))
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.Enter
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridpo_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridpo.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = gridpo.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, gQty.Index, gamt.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridpo.CurrentCell.Value = Nothing Then gridpo.CurrentCell.Value = "0.00"
                    gridpo.CurrentCell.Value = Convert.ToDecimal(gridpo.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    gridpo.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridpo.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridpo.Rows(e.RowIndex).Cells(gQty.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If gridpo.CurrentRow.Index >= 0 And gridpo.Item(gsrno.Index, gridpo.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                txtsrno.Text = gridpo.Item(gsrno.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbitemname.Text = gridpo.Item(gitemname.Index, gridpo.CurrentRow.Index).Value.ToString
                txtgridremarks.Text = gridpo.Item(gdesc.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTREED.Text = gridpo.Item(GREED.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTPICK.Text = gridpo.Item(GPICK.Index, gridpo.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = gridpo.Item(GQUALITY.Index, gridpo.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = gridpo.Item(GDESIGN.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbcolor.Text = gridpo.Item(gcolor.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTPDESNO.Text = gridpo.Item(GPDESNO.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTPSHADE.Text = gridpo.Item(GPSHADE.Index, gridpo.CurrentRow.Index).Value.ToString
                txtqty.Text = gridpo.Item(gQty.Index, gridpo.CurrentRow.Index).Value.ToString
                txtcount.Text = gridpo.Item(gcount.Index, gridpo.CurrentRow.Index).Value.ToString
                txtwidth.Text = gridpo.Item(gwidth.Index, gridpo.CurrentRow.Index).Value.ToString
                txtwtg.Text = gridpo.Item(Gwt.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTCUT.Text = gridpo.Item(GCUT.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = gridpo.Item(gqtyunit.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = gridpo.Item(GMTRS.Index, gridpo.CurrentRow.Index).Value.ToString
                txtrate.Text = gridpo.Item(grate.Index, gridpo.CurrentRow.Index).Value.ToString
                CMBPER.Text = gridpo.Item(gper.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbtoname.Text = gridpo.Item(gtoname.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = gridpo.Item(gamt.Index, gridpo.CurrentRow.Index).Value.ToString

                TEMPROW = gridpo.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpo.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridpo.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridpo.Rows.RemoveAt(gridpo.CurrentRow.Index)
                total()
                getsrno(gridpo)
                total()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And gridpo.RowCount > 0 Then
                If gridpo.CurrentRow.Cells(gitemname.Index).Value <> "" Then gridpo.Rows.Add(CloneWithValues(gridpo.CurrentRow))
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridpo.RowCount = 0
                TEMPOPONO = Val(tstxtbillno.Text)
                If TEMPOPONO > 0 Then
                    EDIT = True
                    PurchaseOrder_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            Cursor.Current = Cursors.WaitCursor
            FILLCOLOR(cmbcolor, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtdisper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdisper.KeyPress
        Try
            numdotkeypress(e, txtdisper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtdisper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdisper.Validated
        total()
    End Sub

    Private Sub txtfrper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfrper.KeyPress
        Try
            numdotkeypress(e, txtfrper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfrper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfrper.Validated
        total()
    End Sub

    Private Sub txttestchgs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttestchgs.KeyPress
        Try
            numdotkeypress(e, txttestchgs, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txttestchgs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttestchgs.Validated
        total()
    End Sub

    Private Sub chkexcise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexcise.CheckedChanged
        If chkexcise.Checked = True Then
            TXTEXCISE.ReadOnly = True
            txtexciseAMT.ReadOnly = True
            TXTEDUCESS.ReadOnly = True
            txteducessAMT.ReadOnly = True
            TXTHSECESS.ReadOnly = True
            txthsecessAMT.ReadOnly = True
            getexcise()
        Else
            TXTEXCISEID.Text = 0
            TXTEXCISE.Text = 0.0
            txtexciseAMT.Text = 0.0
            TXTEDUCESS.Text = 0.0
            txteducessAMT.Text = 0.0
            TXTHSECESS.Text = 0.0
            txthsecessAMT.Text = 0.0
        End If
        total()
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaddtax.GotFocus
        Try
            If cmbaddtax.Text.Trim = "" Then filltax(cmbaddtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbaddtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaddtax.Validating
        Try
            If cmbaddtax.Text.Trim <> "" Then TAXvalidate(cmbaddtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtinspchgs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinspchgs.KeyPress
        Try
            numdotkeypress(e, txtinspchgs, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtinspchgs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinspchgs.Validated
        total()
    End Sub

    Private Sub txtpfper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpfper.KeyPress
        Try
            numdotkeypress(e, txtpfper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtpfper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpfper.Validated
        total()
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJPO As New PurchaseOrderDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.FRMSTRING = "POREPORT"
            OBJPO.FORMULA = "{PURCHASEORDER.PO_NO}=" & Val(TXTOPONO.Text) & " and {PURCHASEORDER.PO_yearid}=" & YearId
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            gridpo.RowCount = 0
LINE1:
            TEMPOPONO = Val(TXTOPONO.Text) - 1
            If TEMPOPONO > 0 Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridpo.RowCount = 0 And TEMPOPONO > 1 Then
                TXTOPONO.Text = TEMPOPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            gridpo.RowCount = 0
LINE1:
            TEMPOPONO = Val(TXTOPONO.Text) + 1
            GETMAX_OPO_NO()
            Dim MAXNO As Integer = TXTOPONO.Text.Trim
            clear()
            If Val(TXTOPONO.Text) - 1 >= TEMPOPONO Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridpo.RowCount = 0 And TEMPOPONO < MAXNO Then
                TXTOPONO.Text = TEMPOPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfreight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfreight.KeyPress
        Try
            numdotkeypress(e, txtfreight, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfreight_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfreight.Validated
        total()
    End Sub

    Private Sub txtqty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtqty.Validating
        CALC()
    End Sub

    Private Sub TXTREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmbtoname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtoname.Enter
        Try
            If cmbtoname.Text.Trim = "" Then fillname(cmbtoname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtoname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtoname.Validating
        Try
            If cmbtoname.Text.Trim <> "" Then namevalidate(cmbtoname, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtoname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtoname.Validated
        If cmbitemname.Text.Trim <> "" And Val(txtqty.Text) <> 0 And cmbqtyunit.Text.Trim <> "" Then
            fillgrid()
            total()
        Else
            If cmbitemname.Text.Trim = "" Then
                MsgBox("Please Fill Item Name ")
                cmbitemname.Focus()
                Exit Sub
            End If
            If cmbqtyunit.Text.Trim = "" Then
                MsgBox("Please Fill Quantity Unit ")
                cmbqtyunit.Focus()
                Exit Sub
            End If

            If Val(txtqty.Text.Trim) = 0 Then
                MsgBox("Please Fill Quantity ")
                txtqty.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmbcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.Enter
        Try
            If cmbcode.Text.Trim = "" Then fillACCCODE(cmbcode, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND  LEDGERS.ACC_TYPE='ACCOUNTS'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcode.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub cmbcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        Try
            If cmbcode.Text.Trim <> "" Then ACCCODEVALIDATE(cmbcode, cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")

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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDELPERIOD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELPERIOD.Validated
        Try
            If cmb.Text <> "__/__/____" Then
                If Val(TXTDELPERIOD.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(cmb.Text).Date.AddDays(Val(TXTDELPERIOD.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            'txtamount.Text = 0.0
            If Val(TXTCUT.Text.Trim) > 0 Then
                TXTMTRS.Text = 0.0
                TXTMTRS.Text = Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim)
            End If
            'If CMBPER.Text = "Pcs" Then txtamount.Text = Format(Val(txtqty.Text) * Val(txtrate.Text), "0.00") Else txtamount.Text = Format(Val(TXTMTRS.Text) * Val(txtrate.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUT.KeyPress
        numdot(e, TXTCUT, Me)
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated
        CALC()
    End Sub

    Private Sub txtcount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcount.KeyPress
        numdotkeypress(e, txtcount, Me)
    End Sub

    'Private Sub CMBPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CALC()
    'End Sub

    Private Sub CMBBROKER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBROKER.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtoname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtoname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtoname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
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

    Sub rateper()
        Try
            'If cmbitemname.Text.Trim <> "" Then
            '    Dim objclscommon As New ClsCommonMaster
            '    Dim dt As DataTable
            '    dt = objclscommon.search(" ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", "ITEMMASTER LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_yearid = UNITMASTER.unit_yearid AND ITEMMASTER.item_locationid = UNITMASTER.unit_locationid AND ITEMMASTER.item_cmpid = UNITMASTER.unit_cmpid AND ITEMMASTER.item_unitid = UNITMASTER.unit_id", " and ITEM_NAME = '" & cmbitemname.Text.Trim & "' and ITEM_cmpid = " & CmpId & " and ITEM_locationid = " & Locationid & " and ITEM_yearid = " & YearId)
            '    If dt.Rows.Count > 0 Then
            '        CMBPER.Text = dt.Rows(0).Item("UNIT")
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Validated
        If cmbitemname.Text.Trim <> "" Then rateper() Else cmdok.Focus()


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub duedate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles duedate.Validated
        Try
            If cmb.Text <> "__/__/____" And Val(TXTDELPERIOD.Text.Trim) = 0 Then TXTDELPERIOD.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(cmb.Text).Date, duedate.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If EDIT = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True And TXTMOBILENO.Text.Trim <> "" Then
            If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim MSG As String = "PONO-" & Val(TEMPOPONO) & "\n"
            For Each ROW As DataGridViewRow In gridpo.Rows
                MSG = MSG & Val(ROW.Cells(gsrno.Index).Value) & ") " & ROW.Cells(gitemname.Index).Value & "\n"
                MSG = MSG & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & " " & ROW.Cells(gqtyunit.Index).Value & "\n"
                MSG = MSG & "Rs:- " & Format(Val(ROW.Cells(grate.Index).Value), "0.00") & "/" & ROW.Cells(gqtyunit.Index).Value & "\n"
            Next
            MSG = MSG & "Del Dt:- " & Format(duedate.Value.Date, "dd/MM/yyyy") & "\n"
            MSG = MSG & txtremarks.Text.Trim
            If SENDMSG(MSG, TXTMOBILENO.Text.Trim) = "1701" Then
                MsgBox("Message Sent")
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER SET OPO_SMSSEND = 1 WHERE OPO_NO = " & TEMPOPONO & " AND OPO_YEARID = " & YearId, "", "")
                LBLSMS.Visible = True
            Else
                MsgBox("Error Sending Message")
            End If
        End If
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLOPEN.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New OpeningPurchaseOrderDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            ' Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
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

    Private Sub TOOLCLOSE_Click(sender As Object, e As EventArgs) Handles TOOLCLOSE.Click
        Try
            Dim OBJPO As New PurchaseOrderClose
            OBJPO.MdiParent = MDIMain
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" And GRIDDOUBLECLICK = False Then
                GETSTOCK(cmbitemname.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim)
                Dim DTITEM As New DataTable

                'OPEN THIS BOX IF SHADES ARE PRESENT FOR SELECTED DESIGN
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DESIGNMASTER_COLOR.DESIGN_SRNO", "", " DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID ", " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGNMASTER.DESIGN_YEARID = " & YearId)
                If FETCHITEMWISEDESIGN = True And DT.Rows.Count > 0 Then
                    Dim OBJ As New SelectItemSO
                    OBJ.ITEMNAME = cmbitemname.Text.Trim
                    OBJ.DESIGNNO = CMBDESIGN.Text.Trim
                    OBJ.ShowDialog()
                    DTITEM = OBJ.DT
                End If
                If DTITEM.Rows.Count > 0 Then
                    For Each DTROWPS As DataRow In DTITEM.Rows
                        gridpo.Rows.Add(0, cmbitemname.Text.Trim, "", CMBDESIGN.Text.Trim, txtgridremarks.Text.Trim, DTROWPS("COLOR"), Format(Val(DTROWPS("ORDERPCS")), "0.00"), cmbqtyunit.Text.Trim, Format(Val(DTROWPS("CUT")), "0.00"), Format(Val(DTROWPS("ORDERMTRS")), "0.00"), Val(txtrate.Text.Trim), "Mtrs", 0, 0, 0)
                    Next
                    gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1
                    getsrno(gridpo)

                    cmbitemname.Text = ""
                    CMBDESIGN.Text = ""
                    txtgridremarks.Clear()
                    cmbitemname.Focus()
                End If
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

    Sub GETSTOCK(ByVal ITEMNAME As String, ByVal DESIGNNO As String, ByVal COLOR As String)
        Try
            If EDIT = False And cmbitemname.Text.Trim <> "" Then

                Dim WHERECLAUSE As String = " AND YEARID = " & YearId & " AND ITEMNAME = '" & ITEMNAME & "'"
                If DESIGNNO <> "" Then WHERECLAUSE = WHERECLAUSE & " AND DESIGNNO = '" & DESIGNNO & "'"
                If COLOR <> "" Then WHERECLAUSE = WHERECLAUSE & " AND COLOR = '" & COLOR & "'"

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcolor.Validated
        If ClientName = "YASHVI" And cmbname.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And CMBDESIGN.Text.Trim <> "" And cmbcolor.Text.Trim <> "" And EDIT = False Then
            Dim dt As DataTable
            Dim OBJCMN As New ClsCommon
            dt = OBJCMN.search("ISNULL(OPENINGPURCHASEORDER_DESC.OPO_PDESNO, '') AS PDESNO, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_PSHADE, '') AS PSHADE", "", "COLORMASTER RIGHT OUTER JOIN OPENINGPURCHASEORDER_DESC INNER JOIN ITEMMASTER ON OPENINGPURCHASEORDER_DESC.OPO_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS INNER JOIN OPENINGPURCHASEORDER ON LEDGERS.Acc_id = OPENINGPURCHASEORDER.OPO_LEDGERID ON OPENINGPURCHASEORDER_DESC.OPO_NO = OPENINGPURCHASEORDER.OPO_NO AND  OPENINGPURCHASEORDER_DESC.OPO_YEARID = OPENINGPURCHASEORDER.OPO_YEARID LEFT OUTER JOIN DESIGNMASTER ON OPENINGPURCHASEORDER_DESC.OPO_DESIGNID = DESIGNMASTER.DESIGN_id ON  COLORMASTER.COLOR_id = OPENINGPURCHASEORDER_DESC.OPO_COLORID ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "'  AND  ISNULL(DESIGNMASTER.DESIGN_NO, '') = '" & CMBDESIGN.Text.Trim & "' and ISNULL(COLORMASTER.COLOR_name, '')='" & cmbcolor.Text.Trim & "' AND OPENINGPURCHASEORDER.OPO_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                For Each DTROW As DataRow In dt.Rows
                    TXTPDESNO.Text = dt.Rows(0).Item("PDESNO")
                    TXTPSHADE.Text = dt.Rows(0).Item("PSHADE")
                Next
            End If
        End If
    End Sub
End Class

