
Imports BL


Public Class PackingSlip

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPPACKINGNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim DTNEW As New DataTable
    Dim PRESENT As Boolean = False
    Dim PARTYPACKINGNO As String


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTPACKINGNO.ReadOnly = False
        TXTPACKINGNO.Clear()
        PACKINGDATE.Text = Now.Date

        If ALLOWMANUALPSNO = True Then
            TXTPACKINGNO.ReadOnly = False
            TXTPACKINGNO.BackColor = Color.LemonChiffon
        Else
            TXTPACKINGNO.ReadOnly = True
            TXTPACKINGNO.BackColor = Color.Linen
        End If

        TabControl1.SelectedIndex = 0

        tstxtbillno.Clear()

        cmbname.Text = ""
        cmbname.Enabled = True
        txtadd.Clear()
        txtremarks.Clear()
        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False
        SALELOCK.Visible = False

        'clearing itemgrid textboxes and combos
        GRIDPACKING.RowCount = 0

        GRIDDOUBLECLICK = False
        getmaxno()

        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0

        txtsrno.Clear()
        CMBPIECETYPE.Text = ""
        CMBITEMNAME.Text = ""
        CMBQUALITY.Text = ""
        TXTDESCRIPTION.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTPCS.Clear()
        CMBUNIT.Text = ""
        TXTCUT.Clear()
        TXTMTRS.Clear()
        TXTCOPIES.Text = 2
        If ClientName <> "PURVITEX" Then CHKHIDEPCS.CheckState = CheckState.Unchecked


    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0

            If GRIDPACKING.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDPACKING.Rows
                    If Val(row.Cells(GCUT.Index).EditedFormattedValue) > 0 And Val(row.Cells(Gpcs.Index).EditedFormattedValue) > 0 Then row.Cells(Gmtrs.Index).Value = Format(Val(row.Cells(Gpcs.Index).EditedFormattedValue) * Val(row.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBGODOWN.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PS_no),0) + 1 ", " PACKINGSLIP ", " and PS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPACKINGNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub


    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True


            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Select Godown")
                bln = False
            End If

            If Val(TXTPACKINGNO.Text.Trim) = 0 Then
                EP.SetError(cmbname, "Invalid Packing Slip No")
                bln = False
            End If

            'If ClientName <> "SANGHVI" And ClientName <> "KDFAB" And ALLOWMANUALPSNO = True Then
            '    If Val(TXTPACKINGNO.Text.Trim) <> 0 And EDIT = False Then
            '        Dim OBJCMN As New ClsCommon
            '        Dim dttable As DataTable = OBJCMN.search(" ISNULL(PACKING.PS_NO,0)  AS PACKINGNO", "", " PACKINGSLIP ", "  AND PACKINGSLIP.PS_NO=" & TXTPACKINGNO.Text.Trim & " AND PACKINGSLIP.PS_YEARID = " & YearId)
            '        If dttable.Rows.Count > 0 Then
            '            EP.SetError(TXTPACKINGNO, "Challan No Already Exists")
            '            bln = False
            '        End If
            '    End If
            'End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Challan Raised, Delete Challan First")
                bln = False
            End If

            If GRIDPACKING.RowCount = 0 Then
                EP.SetError(TXTPACKINGNO, "Fill Packing Slip Details")
                bln = False
            End If
            For Each ROW As DataGridViewRow In GRIDPACKING.Rows
                ROW.DefaultCellStyle.BackColor = Color.Empty
                If Val(ROW.Cells(Gmtrs.Index).Value) = 0 Then
                    EP.SetError(cmbname, "Mtrs Cannot be 0")
                    bln = False
                End If
            Next
            If PACKINGDATE.Text = "__/__/____" Then
                EP.SetError(PACKINGDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(PACKINGDATE.Text) Then
                    EP.SetError(PACKINGDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If ALLOWMANUALPSNO = True Then
                If TXTPACKINGNO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PACKINGSLIP.PS_NO,0)  AS PACKINGNO", "", " PACKINGSLIP ", "  AND PACKINGSLIP.PS_NO=" & TXTPACKINGNO.Text.Trim & " AND PACKINGSLIP.PS_YEARID = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTPACKINGNO, "Packing Slip No Already Exist")
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

            alParaval.Add(Format(Convert.ToDateTime(PACKINGDATE.Text).Date, "MM/dd/yyyy"))
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
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDPACKING.Rows
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
                            QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = row.Cells(GSHADE.Index).Value.ToString
                            PCS = row.Cells(Gpcs.Index).Value.ToString
                            UNIT = row.Cells(Gunit.Index).Value.ToString
                            MTRS = TEMPMTRS
                            BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        Else
                            gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value.ToString
                            QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = COLOR & "," & row.Cells(GSHADE.Index).Value.ToString
                            PCS = PCS & "," & row.Cells(Gpcs.Index).Value.ToString
                            UNIT = UNIT & "|" & row.Cells(Gunit.Index).Value
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
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
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

    Private Sub PACKINGSLIP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDPACKING.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')")


            'GRID COMBO FIELDS
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
            fillPIECETYPE(CMBPIECETYPE)
            fillunit(CMBUNIT)

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

    Private Sub PACKINGSLIP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

                Dim objclsPS As New ClsPackingslip()
                Dim dttable As New DataTable

                dttable = objclsPS.selectPACKINGSLIP(TEMPPACKINGNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPACKINGNO.Text = TEMPPACKINGNO
                        PACKINGDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)

                        GRIDPACKING.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("PRINTDESC"), dr("DESIGN"), dr("COLOR"), Format(Val(dr("PCS")), "0"), dr("UNIT").ToString, Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("OUTPCS"), dr("OUTMTRS"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))

                        If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next

                    total()
                    GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
            End If

            txtsrno.Text = Val(GRIDPACKING.RowCount + 1)

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


            alParaval.Add(Format(Convert.ToDateTime(PACKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
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
            Dim QUALITY As String = ""
            Dim PRINTDESC As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""

            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim CUT As String = ""
            Dim MTRS As String = ""
            Dim BARCODE As String = ""


            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""

            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPACKING.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = ""
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GSHADE.Index).Value.ToString
                        PCS = Val(row.Cells(Gpcs.Index).Value)
                        UNIT = row.Cells(Gunit.Index).Value.ToString

                        If ClientName = "PURVITEX" Then
                            CUT = 0
                        ElseIf ClientName = "MARKIN" Then
                            CUT = Val(row.Cells(GCUT.Index).Value)
                        Else
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = Val(row.Cells(GCUT.Index).Value)
                        End If

                        MTRS = Val(row.Cells(Gmtrs.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        OUTPCS = row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = PRINTDESC & "|" & row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = PRINTDESC & "|" & ""
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GSHADE.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(Gpcs.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(Gunit.Index).Value
                        If ClientName = "PURVITEX" Then
                            CUT = CUT & "|" & 0
                        ElseIf ClientName = "MARKIN" Then
                            CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        Else
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = CUT & "|" & Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        End If
                        MTRS = MTRS & "|" & Val(row.Cells(Gmtrs.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString

                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(PRINTDESC)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(CUT)
            alParaval.Add(MTRS)
            alParaval.Add(BARCODE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim objclsgdn As New ClsPackingslip()
            objclsgdn.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTT As DataTable = objclsgdn.SAVE()
                TXTPACKINGNO.Text = DTT.Rows(0).Item(0)
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
                    Dim LOOPTABLE As DataTable = OBJCMN.search(" PACKINGSLIP.PACKINGSLIP_ledgerid AS LEDGERID, PACKINGSLIP_DESC.PACKINHSLIP_ITEMID AS ITEMID, PACKINGSLIP_DESC.PACKINGSLIP_COLORID AS COLORID, PACKINGSLIP_DESC.PACKINGSLIP_PCS AS PCS ", "", " PACKINGSLIP_DESC INNER JOIN PACKINGSLIP ON PACKINGSLIP_DESC.PACKINGSLIP_NO = PACKINGSLIP.PACKINGSLIP_NO AND PACKINGSLIP_DESC.PACKINGSLIP_YEARID = PACKINGSLIP.PACKINGSLIP_YEARID ", " AND PACKINGSLIP.PACKINGSLIP_NO = " & TEMPPACKINGNO & " AND PACKINGSLIP.PACKINGSLIP_YEARID = " & YearId)
                    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " AND LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " AND ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " AND ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " AND SCH_YEARID = " & YearId & " AND  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                        If DTTEMP.Rows.Count > 0 Then
                            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
                        End If
                    Next
                End If

                alParaval.Add(TEMPPACKINGNO)
                IntResult = objclsgdn.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            PRINTREPORT(TXTPACKINGNO.Text.Trim)

            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDPACKING.RowCount = 0
LINE1:
            TEMPPACKINGNO = Val(TXTPACKINGNO.Text) - 1
            If TEMPPACKINGNO > 0 Then
                EDIT = True
                PACKINGSLIP_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPACKING.RowCount = 0 And TEMPPACKINGNO > 1 Then
                TXTPACKINGNO.Text = TEMPPACKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPACKING.RowCount = 0
LINE1:
            TEMPPACKINGNO = Val(TXTPACKINGNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTPACKINGNO.Text.Trim
            clear()
            If Val(TXTPACKINGNO.Text) - 1 >= TEMPPACKINGNO Then
                EDIT = True
                PACKINGSLIP_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPACKING.RowCount = 0 And TEMPPACKINGNO < MAXNO Then
                TXTPACKINGNO.Text = TEMPPACKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPACKING.RowCount = 0
                TEMPPACKINGNO = Val(tstxtbillno.Text)
                If TEMPPACKINGNO > 0 Then
                    EDIT = True
                    PACKINGSLIP_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PACKINGNO As Integer)
        Try
            If MsgBox("Wish to Print Packing Slip?", MsgBoxStyle.YesNo) = vbYes Then

                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "PACKINGSLIP"
                OBJGDN.FORMULA = "{PACKINGSLIP.PS_no}=" & Val(PACKINGNO) & " and {PACKINGSLIP.PS_yearid}=" & YearId
                OBJGDN.vendorname = cmbname.Text.Trim
                OBJGDN.WHITELABEL = CHKWHITELABEL.Checked
                OBJGDN.HIDEPCSDETAILS = CHKHIDEPCS.Checked
                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPPACKINGNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim PSDTLS As New PackingSlipDetails
            PSDTLS.MdiParent = MDIMain
            PSDTLS.Show()
            PSDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry debtors", "ACCOUNTS")
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_TINNO,'') AS TINNO", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                'If DT.Rows.Count > 0 Then LBLTINNO.Text = DT.Rows(0).Item("TINNO")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPACKING_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPACKING.CellValidating
        Try
            Dim colNum As Integer = GRIDPACKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum
                Case Gpcs.Index, Gmtrs.Index, GCUT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    If bValid Then
                        If GRIDPACKING.CurrentCell.Value = Nothing Then GRIDPACKING.CurrentCell.Value = "0.00"
                        GRIDPACKING.CurrentCell.Value = Convert.ToDecimal(GRIDPACKING.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                    total()
            End Select

            If EDIT = False And ClientName = "KANVASU" Then
                Dim TEMPITEM As String = ""
                For I As Integer = GRIDPACKING.CurrentRow.Index + 1 To GRIDPACKING.RowCount - 1
                    If I = GRIDPACKING.CurrentRow.Index + 1 Then TEMPITEM = GRIDPACKING.Item(GITEMNAME.Index, I - 1).Value
                    If GRIDPACKING.Item(GITEMNAME.Index, I).Value = TEMPITEM Then
                        GRIDPACKING.Item(GPRINTDESC.Index, I).Value = GRIDPACKING.Item(GPRINTDESC.Index, I - 1).EditedFormattedValue
                    End If
                Next
            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPACKING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPACKING.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPACKING.RowCount > 0 Then GRIDPACKING.Rows.RemoveAt(GRIDPACKING.CurrentRow.Index) ''Removing Row From Grid
            'If GRIDPACKING.CurrentRow.Index > 0 Then If e.KeyCode = Keys.F12 Then If GRIDPACKING.Rows(GRIDPACKING.CurrentRow.Index - 1).Cells(GLRNO.Index).Value <> "" Then GRIDPACKING.Rows(GRIDPACKING.CurrentRow.Index).Cells(GLRNO.Index).Value = GRIDPACKING.Rows(GRIDPACKING.CurrentRow.Index - 1).Cells(GLRNO.Index).Value
            If e.KeyCode = Keys.F12 And GRIDPACKING.RowCount > 0 Then
                'THIS IS DONE FOR DAKSH, COZ WHEN WE FETCH DATA FROM PACKING WE DONT HAVE BARCODE AND WE NEED TO RUN THIS CODE
                'If GRIDPACKING.CurrentRow.Cells(GBARCODE.Index).Value <> "" Then GRIDPACKING.Rows.Insert(GRIDPACKING.CurrentRow.Index, CloneWithValues(GRIDPACKING.CurrentRow))
                GRIDPACKING.Rows.Insert(GRIDPACKING.CurrentRow.Index, CloneWithValues(GRIDPACKING.CurrentRow))
                GRIDPACKING.Rows(GRIDPACKING.RowCount - 1).Selected = True
            End If

            getsrno(GRIDPACKING)
            total()
            If e.KeyCode = Keys.F5 Then
                EDITROW()
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

                TEMPMSG = MsgBox("Wish to Delete Packing Slip?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                If ClientName = "SAFFRON" Then
                    Dim OBJCMN As New ClsCommon
                    Dim LOOPTABLE As DataTable = OBJCMN.search("  PACKINGSLIP.PS_ledgerid AS LEDGERID, PACKINGSLIP_DESC.PS_ITEMID AS ITEMID, PACKINGSLIP_DESC.PS_COLORID AS COLORID, PACKINGSLIP_DESC.PS_PCS AS PCS ", "", " PACKINGSLIP_DESC INNER JOIN PACKINGSLIP ON PACKINGSLIP_DESC.PS_NO = PACKINGSLIP.PS_NO AND PACKINGSLIP_DESC.PS_YEARID = PACKINGSLIP.PS_YEARID ", " AND PACKINGSLIP.PS_NO = " & TEMPPACKINGNO & " AND PACKINGSLIP.PS_YEARID = " & YearId)
                    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " AND LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " AND ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " AND ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " AND SCH_YEARID = " & YearId & " AND  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                        If DTTEMP.Rows.Count > 0 Then
                            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
                        End If
                    Next
                End If

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPPACKINGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(ClientName)

                Dim OBJGDN As New ClsPackingslip
                OBJGDN.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJGDN.Delete
                MsgBox("GDN Deleted")

                clear()
                EDIT = False
                cmbname.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub GDN_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            FILLCMB()
            If ClientName <> "SVS" Then
                GQUALITY.Visible = False
                GITEMNAME.Visible = True
                GCUT.Visible = True
            End If

            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
            End If
            If ClientName = "MSANCHITKUMAR" Or ClientName = "SKF" Or ClientName = "PURVITEX" Or ClientName = "SAFFRONOFF" Or ClientName = "MANIBHADRA" Or ClientName = "DEMO" Or ClientName = "SOFTAS" Or ClientName = "ALENCOT" Then
                LBLSRNO.Text = "Bale No"
                txtsrno.Visible = True
                CMBPIECETYPE.Visible = True
                CMBITEMNAME.Visible = True
                CMBQUALITY.Visible = True
                TXTDESCRIPTION.Visible = True
                CMBDESIGN.Visible = True
                CMBCOLOR.Visible = True
                TXTPCS.Visible = True
                TXTCUT.Visible = True
                TXTMTRS.Visible = True
                GQUALITY.Visible = True
            End If


            If ClientName = "SVS" Then
                GPRINTDESC.Visible = False
                GBARCODE.Visible = False
            End If

            If ClientName = "PURVITEX" Then CHKHIDEPCS.CheckState = CheckState.Checked

            If ClientName = "SBA" Then
                GQUALITY.Visible = True
                'CMBQUALITY.Visible = True
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
                OBJLEDGER.STRSEARCH = " and (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')"
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
        '                    For Each ROW As DataGridViewRow In GRIDPACKING.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next

        '                    Dim PER As String = "Mtrs"
        '                    Dim GRIDREMARKS As String = ""
        '                    Dim RATE As Double = 0
        '                    Dim PCS As Double = 0

        '                    If ClientName = "TCOT" Or ClientName = "KCRAYON" Or ClientName = "MARKIN" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1




        '                    'GET RATE
        '                    'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
        '                    If ClientName = "SBA" Then
        '                        Dim DTRATE As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
        '                        If DTRATE.Rows.Count > 0 AndAlso DTRATE.Rows(0).Item("COLNAME") <> "" Then
        '                            DTRATE = OBJCMN.search(DTRATE.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
        '                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
        '                        End If
        '                    End If

        '                    If ClientName = "RSONS" Then GRIDREMARKS = DT.Rows(0).Item("GRIDREMARKS")


        '                    GRIDPACKING.Rows.Add(GRIDPACKING.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), GRIDREMARKS, DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
        '                    total()
        '                    GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1


        'LINE1:
        '                    TXTBARCODE.Clear()
        '                    TXTBARCODE.Focus()
        '                End If
        '            End If

        '            'OLDCODE
        '            '            If Len(TXTBARCODE.Text.Trim) > 7 Then

        '            '                'GET DATA FROM BARCODE
        '            '                Dim OBJCMN As New ClsCommon
        '            '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
        '            '                If DT.Rows.Count > 0 Then
        '            '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '            '                    For Each ROW As DataGridViewRow In GRIDPACKING.Rows
        '            '                        If ROW.Cells(GBARCODE.Index).Value = TXTBARCODE.Text.Trim Then GoTo LINE1
        '            '                    Next
        '            '                    GRIDPACKING.Rows.Add(GRIDPACKING.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", 1, Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
        '            '                    total()
        '            '                    GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1

        '            'LINE1:
        '            '                    TXTBARCODE.Clear()
        '            '                Else
        '            '                    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
        '            '                    GoTo LINE1
        '            '                    Exit Sub
        '            '                End If
        '            '            End If
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
            Dim OBJSELECTPACKING As New SelectStockGDN
            OBJSELECTPACKING.GODOWN = CMBGODOWN.Text.Trim
            If ALLOWPACKINGSLIP = True Then OBJSELECTPACKING.FILTER = " AND BARCODE <> ''"
            OBJSELECTPACKING.FRMSTRING = "PACKINGSLIP"
            OBJSELECTPACKING.ShowDialog()
            DTGDN = OBJSELECTPACKING.DT

            If DTGDN.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTGDN.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPACKING.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                    Next

                    If Val(DTROWPS("PCS")) = 0 Then DTROWPS("PCS") = 1
                    If (ClientName <> "SAKARIA" And ClientName <> "ALENCOT" And ClientName <> "MARKIN") AndAlso Val(DTROWPS("CUT")) = 0 Then DTROWPS("CUT") = Val(DTROWPS("MTRS"))

                    Dim PER As String = "Mtrs"
                    Dim CCRATE As Double = 0
                    Dim CUT As Double = 0

                    If ClientName = "SOFTAS" Or ClientName = "DEVEN" Then CUT = 0 Else CUT = Format(Val(DTROWPS("CUT")), "0.00")

                    Dim OBJCMN As New ClsCommon
                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DTROWPS("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        PER = "Pcs"
                    End If

                    GRIDPACKING.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), "", DTROWPS("DESIGNNO"), DTROWPS("COLOR"), Val(DTROWPS("PCS")), DTROWPS("UNIT"), CUT, Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))

LINE1:
                Next
                CMDSELECTSTOCK.Enabled = True
                getsrno(GRIDPACKING)
                total()
                GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1
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

    Private Sub PACKINGDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PACKINGDATE.GotFocus
        PACKINGDATE.SelectAll()
    End Sub

    Private Sub PACKINGDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKINGDATE.Validating
        Try
            If PACKINGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PACKINGDATE.Text, TEMP) Then
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



    Sub FILLGRID()

        GRIDPACKING.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPACKING.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, TXTDESCRIPTION.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), "", 0, 0)
            getsrno(GRIDPACKING)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPACKING.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDPACKING.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
            GRIDPACKING.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDPACKING.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDPACKING.Item(GPRINTDESC.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
            GRIDPACKING.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDPACKING.Item(GSHADE.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDPACKING.Item(Gpcs.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDPACKING.Item(Gunit.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDPACKING.Item(GCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            GRIDPACKING.Item(Gmtrs.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1

        If ClientName <> "SKF" And ClientName <> "MANIBHADRA" And ClientName <> "ALENCOT" Then
            CMBPIECETYPE.Text = ""
            CMBITEMNAME.Text = ""
            CMBQUALITY.Text = ""
            TXTDESCRIPTION.Clear()
            CMBDESIGN.Text = ""
            CMBCOLOR.Text = ""
            TXTPCS.Clear()
            CMBUNIT.Text = ""
            TXTCUT.Clear()
            TXTMTRS.Clear()
            CMBPIECETYPE.Focus()
        Else
            If ClientName = "MANIBHADRA" Or ClientName = "ALENCOT" Then TXTMTRS.Clear()
            TXTMTRS.Focus()
        End If
        txtsrno.Text = Val(GRIDPACKING.RowCount) + 1

    End Sub

    Private Sub GRIDPACKING_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPACKING.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDPACKING.CurrentRow.Index >= 0 And GRIDPACKING.Item(GSRNO.Index, GRIDPACKING.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True

                txtsrno.Text = GRIDPACKING.Item(GSRNO.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDPACKING.Item(GPIECETYPE.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDPACKING.Item(GITEMNAME.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPACKING.Item(GQUALITY.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDPACKING.Item(GPRINTDESC.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDPACKING.Item(GDESIGN.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDPACKING.Item(GSHADE.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDPACKING.Item(Gpcs.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDPACKING.Item(Gunit.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDPACKING.Item(GCUT.Index, GRIDPACKING.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDPACKING.Item(Gmtrs.Index, GRIDPACKING.CurrentRow.Index).Value.ToString


                TEMPROW = GRIDPACKING.CurrentRow.Index
                CMBPIECETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUNIT.GotFocus
        Try
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress, TXTMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPACKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPACKINGNO.KeyPress
        numkeypress(e, TXTPACKINGNO, Me)
    End Sub

    Private Sub TXTPACKINGNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPACKINGNO.Validating
        Try
            If Val(TXTPACKINGNO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PACKINGSLIP.PS_NO,0)  AS PACKINGNO", "", " PACKINGSLIP ", "  AND PACKINGSLIP.PS_NO=" & TXTPACKINGNO.Text.Trim & " AND PACKINGSLIP.PS_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Challan No Already Exist")
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

    Private Sub TXTCUT_Validated(sender As Object, e As EventArgs) Handles TXTCUT.Validated, TXTPCS.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 And Val(TXTPCS.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTPCS.Text.Trim) * Val(TXTCUT.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
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
                    For Each ROW As DataGridViewRow In GRIDPACKING.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PER As String = "Mtrs"
                    Dim GRIDREMARKS As String = ""
                    Dim RATE As Double = 0
                    Dim PCS As Double = 0

                    If ClientName = "TCOT" Or ClientName = "KCRAYON" Or ClientName = "MARKIN" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1




                    'GET RATE
                    'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
                    If ClientName = "SBA" Then
                        Dim DTRATE As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                        If DTRATE.Rows.Count > 0 AndAlso DTRATE.Rows(0).Item("COLNAME") <> "" Then
                            DTRATE = OBJCMN.search(DTRATE.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
                        End If
                    End If

                    If ClientName = "RSONS" Then GRIDREMARKS = DT.Rows(0).Item("GRIDREMARKS")


                    GRIDPACKING.Rows.Add(GRIDPACKING.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), GRIDREMARKS, DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
                    total()
                    GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1


LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If

            'OLDCODE
            '            If Len(TXTBARCODE.Text.Trim) > 7 Then

            '                'GET DATA FROM BARCODE
            '                Dim OBJCMN As New ClsCommon
            '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            '                If DT.Rows.Count > 0 Then
            '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
            '                    For Each ROW As DataGridViewRow In GRIDPACKING.Rows
            '                        If ROW.Cells(GBARCODE.Index).Value = TXTBARCODE.Text.Trim Then GoTo LINE1
            '                    Next
            '                    GRIDPACKING.Rows.Add(GRIDPACKING.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", 1, Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
            '                    total()
            '                    GRIDPACKING.FirstDisplayedScrollingRowIndex = GRIDPACKING.RowCount - 1

            'LINE1:
            '                    TXTBARCODE.Clear()
            '                Else
            '                    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
            '                    GoTo LINE1
            '                    Exit Sub
            '                End If
            '            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class




