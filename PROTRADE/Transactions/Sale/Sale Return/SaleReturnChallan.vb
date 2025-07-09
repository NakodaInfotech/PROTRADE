
Imports BL

Public Class SaleReturnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPSRCHNO, TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        TXTFROM.Clear()
        TXTTO.Clear()
        tstxtbillno.Clear()
        EP.Clear()
        TXTBARCODE.Clear()

        SRCHDATE.Text = Now.Date
        CMBNAME.Text = ""
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        TXTLOTNO.Clear()
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date

        TXTBARCODE.Clear()

        TXTSRNO.Text = 1
        CMBPIECETYPE.Text = ""
        CMBITEMNAME.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        TXTGRIDREMARKS.Clear()
        CMBCOLOR.Text = ""
        TXTBALENO.Clear()
        TXTCUT.Clear()
        TXTQTY.Text = 1
        If ClientName = "YASHVI" Then
            CMBQTYUNIT.Text = "THAN"
        ElseIf ClientName = "YUMILONE" Or ClientName = "SOFTAS" Then
            CMBQTYUNIT.Text = "PCS"
        Else
            CMBQTYUNIT.Text = ""
        End If
        TXTMTRS.Clear()
        CMBRACK.Text = ""
        CMBSHELF.Text = ""
        GRIDSR.RowCount = 0

        TXTREMARKS.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        GRIDDOUBLECLICK = False

        GETMAXNO()
        LBLTOTALQTY.Text = 0
        LBLTOTALMTRS.Text = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALQTY.Text = 0
            For Each ROW As DataGridViewRow In GRIDSR.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(SRCH_no),0) + 1 ", " SALERETURNCHALLAN ", " and SRCH_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTSRCHNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try

            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If


            If UserName <> "Admin" And lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDSR.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If ClientName <> "CC" And ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" Then
                For Each ROW As DataGridViewRow In GRIDSR.Rows
                    If ROW.Cells(GMTRS.Index).Value = 0 Then
                        EP.SetError(TXTMTRS, "Mtrs Cannot be 0")
                        bln = False
                    End If
                Next
            End If


            If SRCHDATE.Text = "__/__/____" Then
                EP.SetError(SRCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(SRCHDATE.Text) Then
                    EP.SetError(SRCHDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(Format(Convert.ToDateTime(SRCHDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Value).Date, "MM/dd/yyyy"))

            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))

            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim gridremarks As String = ""
            Dim COLOR As String = ""
            Dim BALENO As String = ""
            Dim CUT As String = ""
            Dim QTY As String = ""
            Dim QTYUNIT As String = ""
            Dim MTRS As String = ""
            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        CUT = Val(row.Cells(gcut.Index).Value)
                        QTY = Val(row.Cells(gQty.Index).Value)
                        QTYUNIT = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        RACK = row.Cells(GRACK.Index).Value.ToString
                        SHELF = row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        CUT = CUT & "|" & Val(row.Cells(gcut.Index).Value)
                        QTY = QTY & "|" & Val(row.Cells(gQty.Index).Value)
                        QTYUNIT = QTYUNIT & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        RACK = RACK & "|" & row.Cells(GRACK.Index).Value.ToString
                        SHELF = SHELF & "|" & row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "|" & Val(row.Cells(GOUTMTRS.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(gridremarks)
            alParaval.Add(COLOR)
            alParaval.Add(BALENO)
            alParaval.Add(CUT)
            alParaval.Add(QTY)
            alParaval.Add(QTYUNIT)
            alParaval.Add(MTRS)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)

            Dim OBJSR As New ClsSaleReturnChallan()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.SAVE()
                MsgBox("Details Added")
                TXTSRCHNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPSRCHNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSRCHNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            PRINTREPORT(TEMPSRCHNO)
            PRINTBARCODE()
            EDIT = False
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            If MsgBox("Wish to Print Sale Return?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJPUR As New SaleReturnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "SALERETURNCHALLAN"
                OBJPUR.SALRETNO = Val(SRNO)
                OBJPUR.WHERECLAUSE = "{SALERETURNCHALLAN.SRCH_NO}=" & Val(SRNO) & " and {SALERETURNCHALLAN.SRCH_yearid}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'GET FRESH DATA FROM DATABASE (ONLY GRID)
                'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
                'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
                GRIDSR.RowCount = 0
                Dim OBJSR As New ClsSaleReturnChallan()
                OBJSR.alParaval.Add(TEMPSRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTSALERETURNCHALLAN()
                For Each dr As DataRow In dttable.Rows
                    GRIDSR.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("GRIDREMARKS").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"))
                Next


                Dim WHOLESALEBARCODE As Integer = 0
                If ClientName = "CC" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)


                Dim TEMPHEADER As String = ""
                If ClientName = "YASHVI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (M/N/O/P)")
                    If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "O" And TEMPHEADER <> "P" And TEMPHEADER <> "Y" Then Exit Sub
                    If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
                    If TEMPHEADER = "N" Or TEMPHEADER = "P" Then TEMPHEADER = ""
                    If TEMPHEADER = "O" Then TEMPHEADER = "ORGALIN"
                    If TEMPHEADER = "Y" Then TEMPHEADER = "PREPRINTED"
                End If

                If ClientName = "GELATO" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
                End If

                If ClientName = "MANALI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR PRE PRINTED")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "MANS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR SALVATROE" & Chr(13) & "2 FOR MANS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "AXIS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR PCS" & Chr(13) & "2 FOR MTRS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "KRISHNA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR BOX STICKER")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If


                Dim SUPRIYAHEADER As String = ""
                If ClientName = "SUPRIYA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
                    If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
                    If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
                    If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
                    If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
                    If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
                End If

                For Each ROW As DataGridViewRow In GRIDSR.Rows
                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If

                    BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(gitemname.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(gcolor.Index).Value, ROW.Cells(gqtyunit.Index).Value, TXTLOTNO.Text.Trim, ROW.Cells(GBALENO.Index).Value, ROW.Cells(gdesc.Index).Value, Val(ROW.Cells(GMTRS.Index).Value), Val(ROW.Cells(gQty.Index).Value), Val(ROW.Cells(gcut.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDSR.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
                TabControl1.SelectedIndex = (0)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
                TabControl1.SelectedIndex = (1)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            CMBNAME.Enabled = True

            If ClientName = "SVS" Then
                gQty.ReadOnly = True
                TXTQTY.ReadOnly = True
                TXTQTY.Text = 1
                TXTQTY.BackColor = Color.Linen
            End If

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSR As New ClsSaleReturnChallan()
                OBJSR.alParaval.Add(TEMPSRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTSALERETURNCHALLAN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSRCHNO.Text = TEMPSRCHNO
                        TXTSRCHNO.ReadOnly = True

                        SRCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        cmbGodown.Text = dr("GODOWN")
                        TXTLOTNO.Text = dr("LOTNO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        LBLTOTALMTRS.Text = Format(Val(dr("TOTALMTRS")), "0.00")

                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        GRIDSR.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("GRIDREMARKS").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), dr("GRIDDONE"), dr("OUTPCS"), dr("OUTMTRS"))

                        If Val(dr("OUTMTRS")) > 0 Then
                            GRIDSR.Rows(GRIDSR.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    TOTAL()
                    GRIDSR.FirstDisplayedScrollingRowIndex = GRIDSR.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            TXTSRNO.Text = GRIDSR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            fillunit(CMBQTYUNIT)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
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

            Dim OBJSR As New SaleReturnChallanDetails
            OBJSR.MdiParent = MDIMain
            OBJSR.Show()
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSR.RowCount = 0
                TEMPSRCHNO = Val(tstxtbillno.Text)
                If TEMPSRCHNO > 0 Then
                    EDIT = True
                    SaleReturnChallan_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDSR.Enabled = True

            If GRIDDOUBLECLICK = False Then

                If Val(TXTCUT.Text.Trim) > 0 Then 'And (ClientName = "SBA" Or ClientName = "MIDAS") Then
                    Dim TEMPQTY As Integer = Val(TXTQTY.Text.Trim)
                    TXTQTY.Text = 1
                    For I As Integer = 1 To TEMPQTY
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                LSRNO = InStr(GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                SNO = GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                                TXTBARCODE.Text = "R-" & Val(TXTSRCHNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTBARCODE.Text = "R-" & Val(TXTSRCHNO.Text.Trim) & "/" & GRIDSR.RowCount + 1 & "/" & YearId
                            End If
                        End If
                        GRIDSR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, TXTGRIDREMARKS.Text.Trim, CMBCOLOR.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0)
                    Next
                Else
                    GRIDSR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, TXTGRIDREMARKS.Text.Trim, CMBCOLOR.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0)
                End If
                getsrno(GRIDSR)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSR.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDSR.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDSR.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDSR.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDSR.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDSR.Item(gdesc.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim
                GRIDSR.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
                GRIDSR.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDSR.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDSR.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDSR.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim
                GRIDSR.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDSR.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
                GRIDSR.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDSR.FirstDisplayedScrollingRowIndex = GRIDSR.RowCount - 1

            TXTMTRS.Clear()
            CMBRACK.Text = ""
            CMBSHELF.Text = ""
            TXTSRNO.Text = GRIDSR.RowCount + 1
            If ClientName = "YASHVI" Then TXTCUT.Focus() Else CMBPIECETYPE.Focus()
            If ClientName = "KCRAYON" Then TXTGRIDREMARKS.Clear()
            If ClientName = "SUPRIYA" Then TXTCUT.Clear()
            If ClientName = "AVIS" Or ClientName = "SUPRIYA" Then
                TXTGRIDREMARKS.Clear()
                TXTMTRS.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSR.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSR.RowCount = 0
LINE1:
            TEMPSRCHNO = Val(TXTSRCHNO.Text) - 1
            If TEMPSRCHNO > 0 Then
                EDIT = True
                SaleReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSR.RowCount = 0 And TEMPSRCHNO > 1 Then
                TXTSRCHNO.Text = TEMPSRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDSR.RowCount = 0
LINE1:
            TEMPSRCHNO = Val(TXTSRCHNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTSRCHNO.Text.Trim
            CLEAR()
            If Val(TXTSRCHNO.Text) - 1 >= TEMPSRCHNO Then
                EDIT = True
                SaleReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSR.RowCount = 0 And TEMPSRCHNO < MAXNO Then
                TXTSRCHNO.Text = TEMPSRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Sale Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Sale Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTSRCHNO.Text.Trim))
                alParaval.Add(YearId)

                Dim OBJSR As New ClsSaleReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Sale Return Challan Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQTYUNIT.Enter
        Try
            If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQTYUNIT.Validating
        Try
            If CMBQTYUNIT.Text.Trim <> "" Then unitvalidate(CMBQTYUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSR.CellValidating
        Try
            Dim colNum As Integer = GRIDSR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, gcut.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSR.CurrentCell.Value = Nothing Then GRIDSR.CurrentCell.Value = "0.00"
                        GRIDSR.CurrentCell.Value = Convert.ToDecimal(GRIDSR.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDSR.CurrentRow.Index >= 0 And GRIDSR.Item(gsrno.Index, GRIDSR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDSR.Item(gsrno.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDSR.Item(GPIECETYPE.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSR.Item(gitemname.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDSR.Item(GQUALITY.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSR.Item(GDESIGN.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTGRIDREMARKS.Text = GRIDSR.Item(gdesc.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDSR.Item(gcolor.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDSR.Item(GBALENO.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDSR.Item(gcut.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSR.Item(gQty.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBQTYUNIT.Text = GRIDSR.Item(gqtyunit.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDSR.Item(GMTRS.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDSR.Item(GRACK.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDSR.Item(GSHELF.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDSR.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSR.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSR.Rows.RemoveAt(GRIDSR.CurrentRow.Index)
                getsrno(GRIDSR)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
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

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If CMBITEMNAME.Text.Trim <> "" And EDIT = False Then
                DT = OBJCMN.search(" ISNULL(PARTYITEMWISECHART.PAR_STAMPING, '') AS STAMPING", "", " PARTYITEMWISECHART INNER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id ", " AND ledgers.acc_cmpname = '" & CMBNAME.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & " ' AND PARTYITEMWISECHART.PAR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        TXTGRIDREMARKS.Text = (DT.Rows(0).Item("STAMPING"))
                    Next
                End If
            End If

            'GET CATEGORY
            DT = OBJCMN.search("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.GotFocus
        TXTCUT.SelectAll()
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated, TXTQTY.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(TXTQTY.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
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

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then
                If ClientName = "AVIS" Then DESIGNVALIDATE(CMBDESIGN, e, Me) Else DESIGNVALIDATE(CMBDESIGN, e, Me, CMBITEMNAME.Text.Trim)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGodown.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
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

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
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

    Private Sub CMBPIECETYPE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPIECETYPE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJPieceType As New SelectPieceType
                OBJPieceType.ShowDialog()
                If OBJPieceType.TEMPNAME <> "" Then CMBPIECETYPE.Text = OBJPieceType.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQUALITY As New SelectQuality
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQUALITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SRCHDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SRCHDATE.GotFocus
        SRCHDATE.SelectAll()
    End Sub

    Private Sub SRCHDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SRCHDATE.Validating
        Try
            If SRCHDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SRCHDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CHECKBARCODE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SRCH_BARCODE,'') AS BARCODE ", "", " SALERETURNCHALLAN_DESC ", " AND SALERETURNCHALLAN_DESC.SRCH_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As Windows.Forms.DataGridViewRow In GRIDSR.Rows
                        If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                            BLN = False
                            Exit Function
                        End If
                    Next
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBRACK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Validated
        Try
            If CMBPIECETYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub

                Dim TEMPQTY As Integer = Val(TXTQTY.Text.Trim)

                'THIS CODE IS DONE BY GULKIT
                'If Val(TXTCUT.Text.Trim) = 0 Then TEMPQTY = 1 Else txtqty.Text = 1
                If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim)
                For I As Integer = 1 To Val(TEMPQTY)
                    If GRIDDOUBLECLICK = False Then
                        If EDIT = True Then
                            'GET LAST BARCODE SRNO
                            Dim LSRNO As Integer = 0
                            Dim RSRNO As Integer = 0
                            Dim SNO As Integer = 0
                            LSRNO = InStr(GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            RSRNO = InStr(LSRNO + 1, GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            SNO = GRIDSR.Rows(GRIDSR.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                            TXTBARCODE.Text = "R-" & Val(TXTSRCHNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                        Else
                            TXTBARCODE.Text = "R-" & Val(TXTSRCHNO.Text.Trim) & "/" & GRIDSR.RowCount + 1 & "/" & YearId
                        End If
                    End If
                Next
                FILLGRID()
            Else
                If ClientName <> "AVIS" Then
                    If CMBPIECETYPE.Text.Trim = "" Then
                        MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                        CMBPIECETYPE.Focus()
                    ElseIf CMBITEMNAME.Text.Trim = "" Then
                        MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                        CMBITEMNAME.Focus()
                    ElseIf Val(TXTQTY.Text.Trim) = 0 Then
                        MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                        TXTQTY.Focus()
                    ElseIf CMBQTYUNIT.Text.Trim = "" Then
                        MsgBox("Enter Unit", MsgBoxStyle.Critical)
                        CMBQTYUNIT.Focus()
                    ElseIf Val(TXTMTRS.Text.Trim) = 0 Then
                        MsgBox("Enter Mtrs", MsgBoxStyle.Critical)
                        TXTMTRS.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtgridremarks_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGRIDREMARKS.Validated
        Try
            'MAKE THIS STAMPING DEFAULT FOR PARTY
            If TXTGRIDREMARKS.Text.Trim <> "" And CMBNAME.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" Then

                'FIRST CHECK WHETHER THIS STAMP FOR THIS PARTY AND ITEM IS PRESENT OR NOT, IF NOT THEN CREATE NEW OR ELSE UPDATE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("PAR_STAMPING AS STAMPING, PAR_NO AS PARNO", "", "PARTYITEMWISECHART INNER JOIN LEDGERS ON ACC_ID = PAR_LEDGERID INNER JOIN ITEMMASTER ON ITEM_ID = PAR_ITEMID", " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND PAR_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("STAMPING") <> TXTGRIDREMARKS.Text.Trim Then
                    If MsgBox("Wish to Make this Stamp Default for this Party & Item?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    DT = OBJCMN.Execute_Any_String("UPDATE PARTYITEMWISECHART SET PAR_STAMPING = '" & TXTGRIDREMARKS.Text.Trim & "' WHERE PAR_NO = " & Val(DT.Rows(0).Item("PARNO")) & " AND PAR_YEARID = " & YearId, "", "")
                Else
                    'ADD NEW STAMPING
                    Dim ALPARAVAL As New ArrayList
                    Dim OBJCONFIG As New ClsPartyItemWiseChart

                    ALPARAVAL.Add(0)
                    ALPARAVAL.Add(CMBNAME.Text.Trim)
                    ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
                    ALPARAVAL.Add(TXTGRIDREMARKS.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)

                    OBJCONFIG.alParaval = ALPARAVAL

                    Dim INT As Integer = OBJCONFIG.SAVE()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then
            PRINTREPORT(TEMPSRCHNO)
            PRINTBARCODE()
        End If
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(sender As Object, e As EventArgs) Handles TXTMTRS.Validated
        Try
            If ClientName = "AVIS" Then CMBSHELF_Validated(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            'If ClientName = "MIDAS" Or ClientName = "YASHVI" Or ClientName = "KCRAYON" Or ClientName = "SBA" Or ClientName = "AVIS" Or ClientName = "KARAN" Or ClientName = "SMS" Or ClientName = "SAKARIA" Or ClientName = "SUPRIYA" Then TXTQTY.ReadOnly = False
            If ClientName = "YASHVI" Then
                CMBPIECETYPE.TabStop = False
                CMBITEMNAME.TabStop = False
                CMBQUALITY.TabStop = False
                CMBDESIGN.TabStop = False
                TXTGRIDREMARKS.TabStop = False
                CMBCOLOR.TabStop = False
            End If

            If ClientName = "AVIS" Or ClientName = "KRISHNA" Then
                CMBITEMNAME.TabStop = False
                CMBQUALITY.TabStop = False
                TXTGRIDREMARKS.TabStop = False
                CMBQTYUNIT.Text = "LUMP"
                CMBRACK.TabStop = False
                CMBPIECETYPE.TabStop = False
                cmbGodown.TabStop = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPSRCHNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(SRNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJSR As New SaleReturnDesign
            OBJSR.MdiParent = MDIMain
            OBJSR.DIRECTPRINT = True
            OBJSR.FRMSTRING = "SALERETURNCHALLAN"
            OBJSR.DIRECTMAIL = True
            OBJSR.WHERECLAUSE = "{SALERETURNCHALLAN.SRCH_NO}=" & Val(SRNO) & " and {SALERETURNCHALLAN.SRCH_yearid}=" & YearId
            OBJSR.SALRETNO = SRNO
            OBJSR.NOOFCOPIES = 1
            OBJSR.Show()
            OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(sender As Object, e As EventArgs) Handles CMBDESIGN.Validated
        Try
            'GET ITEMNAME AUTO
            If (ClientName = "AVIS" Or ClientName = "KRISHNA") And CMBDESIGN.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validated(sender As Object, e As EventArgs) Handles CMBQTYUNIT.Validated
        Try
            If ClientName = "AVIS" Then
                If UCase(CMBQTYUNIT.Text.Trim) = "FENT" Then
                    CMBPIECETYPE.Text = "FENT"
                ElseIf UCase(CMBQTYUNIT.Text.Trim) = "2ND" Then
                    CMBPIECETYPE.Text = "SECOND"
                ElseIf UCase(CMBQTYUNIT.Text.Trim) = "2ND TP" Then
                    CMBPIECETYPE.Text = "SECOND"
                ElseIf UCase(CMBQTYUNIT.Text.Trim) = "SHORTAGE" Then
                    CMBPIECETYPE.Text = "SHORTAGE"
                ElseIf UCase(CMBQTYUNIT.Text.Trim) = "TP" Then
                    CMBPIECETYPE.Text = "TWOPART"
                ElseIf UCase(CMBQTYUNIT.Text.Trim) = "PCS" Then
                    CMBPIECETYPE.Text = "PIECES"
                Else
                    CMBPIECETYPE.Text = "FRESH"
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress, TXTQTY.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTOUTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTOUTBARCODE.Validated
        Try
            If TXTOUTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                'GET DATA FROM SAMPLE BARCODE
                'no need for yearid clause here as we need to fetch this barcode in all acccouting year
                DT = OBJCMN.search(" * ", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTOUTBARCODE.Text.Trim & "'")
                If DT.Rows.Count > 0 Then

                    GRIDSR.Rows.Add(GRIDSR.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), "", DT.Rows(0).Item("COLOR"), "", 0, 1, DT.Rows(0).Item("UNIT"), Val(DT.Rows(0).Item("MTRS")), "", "", "", 0, 0, 0)
                    GRIDSR.FirstDisplayedScrollingRowIndex = GRIDSR.RowCount - 1

LINE1:
                    TXTOUTBARCODE.Clear()
                    TXTOUTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTOUTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class