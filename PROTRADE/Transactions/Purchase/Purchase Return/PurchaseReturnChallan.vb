Imports BL
Imports System.ComponentModel


Public Class PurchaseReturnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPPRCHNO, TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        Ep.Clear()
        TXTBARCODE.Clear()

        PRCHDATE.Text = Now.Date
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
        GRIDPR.RowCount = 0

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
            For Each ROW As DataGridViewRow In GRIDPR.Rows
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

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(PRCH_no),0) + 1 ", " PURCHASERETURNCHALLAN ", " and PRCH_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTPRCHNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try

            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                Ep.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                Ep.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If


            If UserName <> "Admin" And lbllocked.Visible = True Then
                Ep.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDPR.RowCount = 0 Then
                Ep.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If ClientName <> "CC" And ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" Then
                For Each ROW As DataGridViewRow In GRIDPR.Rows
                    If ROW.Cells(GMTRS.Index).Value = 0 Then
                        Ep.SetError(TXTMTRS, "Mtrs Cannot be 0")
                        bln = False
                    End If
                Next
            End If


            If PRCHDATE.Text = "__/__/____" Then
                Ep.SetError(PRCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(PRCHDATE.Text) Then
                    Ep.SetError(PRCHDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(Format(Convert.ToDateTime(PRCHDATE.Text).Date, "MM/dd/yyyy"))
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
            Dim BARCODE As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim TYPE As String = ""
            Dim DONE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDPR.Rows
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
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        FROMNO = row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value
                        Else
                            FROMSRNO = 0
                        End If
                        TYPE = row.Cells(GTYPE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0

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
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        Else
                            FROMSRNO = FROMSRNO & "|" & " 0"
                        End If
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If

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
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(TYPE)
            alParaval.Add(DONE)


            Dim OBJSR As New ClsPurchaseReturnChallan()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.save()
                MsgBox("Details Added")
                TXTPRCHNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPPRCHNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRCHNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            PRINTREPORT(TEMPPRCHNO)

            EDIT = False
            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            If MsgBox("Wish to Print Purchase Return?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJPUR As New PurchaseInvoiceDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "PURRETURNCHALLAN"
                OBJPUR.PURRETNO = Val(SRNO)
                OBJPUR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturnChallan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDPR.Focus()
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

    Private Sub PurchaseReturnChallan_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PURCHASE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            clear()
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

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval.Add(TEMPPRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTPURCHASERETURNCHALLAN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPRCHNO.Text = TEMPPRCHNO
                        TXTPRCHNO.ReadOnly = True

                        PRCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        cmbGodown.Text = dr("GODOWN")
                        TXTLOTNO.Text = dr("LOTNO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        LBLTOTALMTRS.Text = Format(Val(dr("TOTALMTRS")), "0.00")

                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        GRIDPR.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("GRIDREMARKS").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("TYPE"), dr("GRIDDONE"))

                    Next

                    TOTAL()
                    GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If

            End If

            TXTSRNO.Text = GRIDPR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            fillunit(CMBQTYUNIT)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Enter(sender As Object, e As EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Validating(sender As Object, e As CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSR As New PurchaseReturnChallanDetail
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

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPR.RowCount = 0
                TEMPPRCHNO = Val(tstxtbillno.Text)
                If TEMPPRCHNO > 0 Then
                    EDIT = True
                    PurchaseReturnChallan_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDPR.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDPR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, TXTGRIDREMARKS.Text.Trim, CMBCOLOR.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, "", 0)
                getsrno(GRIDPR)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPR.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDPR.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDPR.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDPR.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDPR.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDPR.Item(gdesc.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim
                GRIDPR.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
                GRIDPR.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDPR.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDPR.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDPR.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim
                GRIDPR.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1

            TXTMTRS.Clear()
            TXTSRNO.Text = GRIDPR.RowCount + 1
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

    Private Sub GRIDPRBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPR.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) - 1
            If TEMPPRCHNO > 0 Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO > 1 Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTPRCHNO.Text.Trim
            clear()
            If Val(TXTPRCHNO.Text) - 1 >= TEMPPRCHNO Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO < MAXNO Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(sender As Object, e As EventArgs) Handles tooldelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Purchase Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTPRCHNO.Text.Trim))
                alParaval.Add(Userid)
                alParaval.Add(YearId)

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Purchase Return Challan Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Enter(sender As Object, e As EventArgs) Handles CMBQTYUNIT.Enter
        Try
            If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBQTYUNIT.Validating
        Try
            If CMBQTYUNIT.Text.Trim <> "" Then unitvalidate(CMBQTYUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPR.CellValidating
        Try
            Dim colNum As Integer = GRIDPR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, gcut.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPR.CurrentCell.Value = Nothing Then GRIDPR.CurrentCell.Value = "0.00"
                        GRIDPR.CurrentCell.Value = Convert.ToDecimal(GRIDPR.Item(colNum, e.RowIndex).Value)
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
            If GRIDPR.CurrentRow.Index >= 0 And GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDPR.Item(GPIECETYPE.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDPR.Item(gitemname.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPR.Item(GQUALITY.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDPR.Item(GDESIGN.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTGRIDREMARKS.Text = GRIDPR.Item(gdesc.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDPR.Item(gcolor.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDPR.Item(GBALENO.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDPR.Item(gcut.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPR.Item(gQty.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBQTYUNIT.Text = GRIDPR.Item(gqtyunit.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDPR.Item(GMTRS.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDPR.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPR.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDPR.Rows.RemoveAt(GRIDPR.CurrentRow.Index)
                getsrno(GRIDPR)
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

    Private Sub SRCHDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRCHDATE.GotFocus
        PRCHDATE.SelectAll()
    End Sub

    Private Sub SRCHDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PRCHDATE.Validating
        Try
            If PRCHDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PRCHDATE.Text, TEMP) Then
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
            Dim DT As DataTable = OBJCMN.search(" ISNULL(PRCH_BARCODE,'') AS BARCODE ", "", " PURCHASERETURNCHALLAN_DESC ", " AND PURCHASERETURNCHALLAN_DESC.PRCH_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As Windows.Forms.DataGridViewRow In GRIDPR.Rows
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
            PRINTREPORT(TEMPPRCHNO)
        End If
    End Sub




    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(sender As Object, e As EventArgs) Handles TXTMTRS.Validated
        Try
            If CMBPIECETYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPPRCHNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDWHATSAPP(SRNO As Integer)
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
            OBJSR.FRMSTRING = "PURCHASERETURNCHALLAN"
            OBJSR.DIRECTMAIL = True
            OBJSR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
            OBJSR.SALRETNO = SRNO
            OBJSR.NOOFCOPIES = 1
            OBJSR.Show()
            OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PURCHASERET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("PURCHASERET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(sender As Object, e As EventArgs) Handles CMBDESIGN.Validated
        Try
            'GET ITEMNAME AUTO
            If (ClientName = "AVIS" Or ClientName = "KRISHNA" Or ClientName = "NTC") And CMBDESIGN.Text.Trim <> "" Then
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

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTQTY.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = cmbGodown.Text.Trim
            If ALLOWPACKINGSLIP = True And ClientName <> "MARKIN" Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPR.Rows
                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                    Next

                    If ClientName = "BARKHA" Or ClientName = "SHUBHI" Or ClientName = "SUBHLAXMI" Then
                        GRIDPR.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), "", DTROWPS("COLOR"), DTROWPS("BALENO"), Val(DTROWPS("CUT")), Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), DTROWPS("TYPE"), 0)
                    Else
                        GRIDPR.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), "", DTROWPS("COLOR"), DTROWPS("BALENO"), 0, Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), DTROWPS("TYPE"), 0)
                    End If
                    If ClientName <> "AVIS" Then TXTLOTNO.Text = DTROWPS("LOTNO")
LINE1:
                Next
                getsrno(GRIDPR)
                TOTAL()
                GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                If cmbGodown.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> cmbGodown.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPR.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next


                    Dim PCS As Double = 0
                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    GRIDPR.Rows.Add(GRIDPR.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), "", DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), Format(Val(DT.Rows(0).Item("CUT")), "0.00"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
                    TOTAL()
                    GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1

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

    Private Sub TXTBARCODE_Validating(sender As Object, e As CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class