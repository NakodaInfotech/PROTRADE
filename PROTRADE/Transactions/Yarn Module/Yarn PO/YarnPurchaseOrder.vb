
Imports System.ComponentModel
Imports BL

Public Class YarnPurchaseOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPONO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub getmax_YPO_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(YPO_no),0) + 1 ", "YARNPURCHASEORDER", " and YPO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then txtpono.Text = DTTABLE.Rows(0).Item(0)
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

    Sub CLEAR()

        tstxtbillno.Clear()
        PODATE.Text = Now.Date
        cmbname.Text = ""
        cmbname.Enabled = True
        TXTMOBILENO.Clear()
        TXTEMAILADD.Clear()

        TXTCRDAYS.Clear()
        txtdiscount.Clear()
        TXTDELPERIOD.Clear()
        txtRefno.Clear()
        duedate.Value = Now.Date

        CMBBROKER.Text = ""
        CMBTRANS.Text = ""
        CMBORDERTYPE.SelectedIndex = 0

        txtsrno.Text = 1
        CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBMILLNAME.Text = ""
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTPSHADE.Clear()
        TXTBAGS.Clear()
        CMBUNIT.Text = ""
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        GRIDPO.RowCount = 0

        LBLTOTALBAGS.Text = 0
        LBLTOTALWT.Text = 0
        LBLTOTALCONES.Text = 0
        lbltotalamt.Text = 0

        EP.Clear()

        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()

        txtinwords.Clear()
        getmax_YPO_no()
        GRIDDOUBLECLICK = False

        CMBORDERTYPE.SelectedIndex = 0

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub PurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                GRIDPO.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
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
            If CMBBROKER.Text.Trim = "" Then fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            fillunit(CMBUNIT)
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBYARNQUALITY.Text.Trim)
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, "")
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


                Dim objclsPO As New ClsYarnPurchaseOrder()
                Dim dt_po As DataTable = objclsPO.selectpo(tempono, CmpId, Locationid, YearId)
                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows

                        txtpono.Text = dr("PONO")
                        PODATE.Text = Format(Convert.ToDateTime(dr("PODATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))
                        TXTEMAILADD.Text = Convert.ToString(dr("EMAILADD"))

                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        TXTDELPERIOD.Text = Val(dr("DELDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))
                        txtdiscount.Text = Convert.ToString(dr("DISCOUNT"))
                        txtRefno.Text = Convert.ToString(dr("REFNO"))

                        CMBBROKER.Text = Convert.ToString(dr("BROKER"))
                        CMBTRANS.Text = Convert.ToString(dr("TRANSNAME"))
                        CMBORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        GRIDPO.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("DESC").ToString, dr("MILLNAME").ToString, dr("DESIGN").ToString, dr("SHADE").ToString, dr("PSHADE").ToString, Format(Val(dr("BAGS")), "0.00"), dr("UNIT").ToString, Format(Val(dr("WT")), "0.00"), Val(dr("CONES")), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMT")), "0.00"), Val(dr("RECDBAGS")), Val(dr("RECDWT")), dr("DONE").ToString, dr("CLOSED"))


                        If Val(dr("RECDBAGS")) > 0 Or Val(dr("RECDWT")) > 0 Then
                            GRIDPO.Rows(GRIDPO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            cmbname.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDPO.Rows(GRIDPO.RowCount - 1).DefaultCellStyle.BackColor = Color.LightSkyBlue
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1

                End If
                total()
            Else
                EDIT = False
                clear()
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

            alParaval.Add(Format(Convert.ToDateTime(PODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(duedate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(Val(TXTDELPERIOD.Text.Trim))
            alParaval.Add(txtRefno.Text.Trim)

            alParaval.Add(txtdiscount.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBORDERTYPE.Text.Trim)

            alParaval.Add(Val(LBLTOTALBAGS.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALCONES.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim yarnquality As String = ""
            Dim desc As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim SHADE As String = ""
            Dim PCOLOR As String = ""
            Dim BAGS As String = ""
            Dim UNIT As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        yarnquality = row.Cells(GYARNQUALITY.Index).Value.ToString
                        desc = row.Cells(gdesc.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        SHADE = row.Cells(gcolor.Index).Value.ToString
                        PCOLOR = row.Cells(GPCOLOR.Index).Value.ToString
                        BAGS = Val(row.Cells(GBAGS.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        RATE = Val(row.Cells(grate.Index).Value)
                        AMT = Val(row.Cells(gamt.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        yarnquality = yarnquality & "|" & row.Cells(GYARNQUALITY.Index).Value
                        desc = desc & "|" & row.Cells(gdesc.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        SHADE = SHADE & "|" & row.Cells(gcolor.Index).Value.ToString
                        PCOLOR = PCOLOR & "|" & row.Cells(GPCOLOR.Index).Value.ToString
                        BAGS = BAGS & "|" & Val(row.Cells(GBAGS.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(grate.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(gamt.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(yarnquality)
            alParaval.Add(desc)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)
            alParaval.Add(SHADE)
            alParaval.Add(PCOLOR)
            alParaval.Add(BAGS)
            alParaval.Add(UNIT)
            alParaval.Add(WT)
            alParaval.Add(CONES)
            alParaval.Add(RATE)
            alParaval.Add(AMT)

            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)

            Dim objclsPurord As New ClsYarnPurchaseOrder()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                txtpono.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(tempono)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.Update()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT()

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

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If

        If PODATE.Text = "__/__/____" Then
            EP.SetError(PODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PODATE.Text) Then
                EP.SetError(PODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub TOTAL()
        LBLTOTALBAGS.Text = "0"
        LBLTOTALWT.Text = "0.00"
        LBLTOTALCONES.Text = 0
        lbltotalamt.Text = "0.00"
        If GRIDPO.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDPO.Rows
                row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(GWT.Index).Value), "0.00")
                If Val(row.Cells(GBAGS.Index).Value) <> 0 Then LBLTOTALBAGS.Text = Val(LBLTOTALBAGS.Text) + Val(row.Cells(GBAGS.Index).Value)
                If Val(row.Cells(GWT.Index).Value) <> 0 Then LBLTOTALWT.Text = Val(LBLTOTALWT.Text) + Val(row.Cells(GWT.Index).Value)
                If Val(row.Cells(GCONES.Index).Value) <> 0 Then LBLTOTALCONES.Text = Val(LBLTOTALCONES.Text) + Val(row.Cells(GCONES.Index).Value)
                If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value)
            Next
        End If
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
            If GRIDPO.RowCount > 0 Then
                txtsrno.Text = Val(GRIDPO.Rows(GRIDPO.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
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

        GRIDPO.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPO.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, TXTDESC.Text.Trim, CMBMILLNAME.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, TXTPSHADE.Text.Trim, Val(TXTBAGS.Text.Trim), CMBUNIT.Text.Trim, Val(TXTWT.Text.Trim), Val(TXTCONES.Text.Trim), Val(TXTRATE.Text.Trim), 0, 0, 0, 0, 0)
            getsrno(GRIDPO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPO.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDPO.Item(gdesc.Index, TEMPROW).Value = TXTDESC.Text.Trim
            GRIDPO.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILLNAME.Text.Trim
            GRIDPO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDPO.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDPO.Item(GPCOLOR.Index, TEMPROW).Value = TXTPSHADE.Text.Trim
            GRIDPO.Item(GBAGS.Index, TEMPROW).Value = Val(TXTBAGS.Text.Trim)
            GRIDPO.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDPO.Item(GWT.Index, TEMPROW).Value = Val(TXTWT.Text.Trim)
            GRIDPO.Item(GCONES.Index, TEMPROW).Value = Val(TXTCONES.Text.Trim)
            GRIDPO.Item(grate.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1

        txtsrno.Text = GRIDPO.RowCount + 1
        If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBMILLNAME.Text = ""
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTPSHADE.Clear()
        TXTBAGS.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTRATE.Clear()

        total()
        CMBYARNQUALITY.Focus()

    End Sub

    Private Sub GRIDPO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPO.CellDoubleClick
        If e.RowIndex >= 0 And GRIDPO.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(GRIDPO.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            GRIDDOUBLECLICK = True
            txtsrno.Text = Val(GRIDPO.Item(gsrno.Index, e.RowIndex).Value)
            CMBYARNQUALITY.Text = GRIDPO.Item(GYARNQUALITY.Index, e.RowIndex).Value.ToString
            TXTDESC.Text = GRIDPO.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBMILLNAME.Text = GRIDPO.Item(GMILLNAME.Index, e.RowIndex).Value.ToString
            CMBDESIGN.Text = GRIDPO.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            CMBCOLOR.Text = GRIDPO.Item(gcolor.Index, e.RowIndex).Value.ToString
            TXTPSHADE.Text = GRIDPO.Item(GPCOLOR.Index, e.RowIndex).Value.ToString
            TXTBAGS.Text = Val(GRIDPO.Item(GBAGS.Index, e.RowIndex).Value)
            CMBUNIT.Text = GRIDPO.Item(GUNIT.Index, e.RowIndex).Value.ToString
            TXTWT.Text = Val(GRIDPO.Item(GWT.Index, e.RowIndex).Value)
            TXTCONES.Text = Val(GRIDPO.Item(GCONES.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(GRIDPO.Item(grate.Index, e.RowIndex).Value)

            TEMPROW = e.RowIndex
            CMBYARNQUALITY.Focus()
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PODATE.GotFocus
        PODATE.SelectAll()
    End Sub

    Private Sub PODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PODATE.Validating
        Try
            If PODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PODATE.Text, TEMP) Then
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

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("PO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(tempono)
                alParaval.Add(YearId)

                Dim clspo As New ClsYarnPurchaseOrder()
                clspo.alParaval = alParaval
                IntResult = clspo.Delete()
                MsgBox("Purchase Order Deleted")
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

    Private Sub cmbqtyunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
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

    Private Sub GRIDPO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDPO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, GBAGS.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPO.CurrentCell.Value = Nothing Then GRIDPO.CurrentCell.Value = "0.00"
                    GRIDPO.CurrentCell.Value = Convert.ToDecimal(GRIDPO.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    GRIDPO.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(GRIDPO.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(GRIDPO.Rows(e.RowIndex).Cells(GWT.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If GRIDPO.CurrentRow.Index >= 0 And GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                txtsrno.Text = Val(GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value)
                CMBYARNQUALITY.Text = GRIDPO.Item(GYARNQUALITY.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDPO.Item(gdesc.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBMILLNAME.Text = GRIDPO.Item(GMILLNAME.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDPO.Item(GDESIGN.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDPO.Item(gcolor.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTPSHADE.Text = GRIDPO.Item(GPCOLOR.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTBAGS.Text = Val(GRIDPO.Item(GBAGS.Index, GRIDPO.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDPO.Item(GUNIT.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTWT.Text = Val(GRIDPO.Item(GWT.Index, GRIDPO.CurrentRow.Index).Value)
                TXTCONES.Text = Val(GRIDPO.Item(GCONES.Index, GRIDPO.CurrentRow.Index).Value)
                TXTRATE.Text = Val(GRIDPO.Item(grate.Index, GRIDPO.CurrentRow.Index).Value)

                TEMPROW = GRIDPO.CurrentRow.Index
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPO.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDPO.RowCount > 0 Then

                If Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPO.Rows.RemoveAt(GRIDPO.CurrentRow.Index)
                total()
                getsrno(GRIDPO)
                total()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPO.RowCount = 0
                tempono = Val(tstxtbillno.Text)
                If tempono > 0 Then
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

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles CMBCOLOR.Enter
        Try
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPO As New PurchaseOrderDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.PARTYNAME = cmbname.Text.Trim
            OBJPO.AGENTNAME = CMBBROKER.Text.Trim
            OBJPO.FRMSTRING = "YARNPOREPORT"
            OBJPO.FORMULA = "{YARNPURCHASEORDER.YPO_NO}=" & Val(txtpono.Text) & " and {YARNPURCHASEORDER.YPO_yearid}=" & YearId
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            tempono = Val(txtpono.Text) - 1
            If tempono > 0 Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And tempono > 1 Then
                txtpono.Text = tempono
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            tempono = Val(txtpono.Text) + 1
            getmax_YPO_no()
            Dim MAXNO As Integer = txtpono.Text.Trim
            clear()
            If Val(txtpono.Text) - 1 >= tempono Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And tempono < MAXNO Then
                txtpono.Text = tempono
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTDELPERIOD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELPERIOD.Validated
        Try
            If PODATE.Text <> "__/__/____" Then
                If Val(TXTDELPERIOD.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(PODATE.Text).Date.AddDays(Val(TXTDELPERIOD.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub duedate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles duedate.Validated
        Try
            If PODATE.Text <> "__/__/____" And Val(TXTDELPERIOD.Text.Trim) = 0 Then TXTDELPERIOD.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(PODATE.Text).Date, duedate.Value.Date)
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

            Dim objINVDTLS As New YarnPurchaseOrderDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "")
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

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then fillgrid()
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

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Validated
        If cmbname.Text.Trim <> "" And CMBCOLOR.Text.Trim <> "" And EDIT = False Then
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" ISNULL(COLORTAGGING.TAG_PCOLOR,'') AS PSHADE", "", "COLORTAGGING INNER JOIN COLORMASTER ON COLORTAGGING.TAG_COLORID = COLORMASTER.COLOR_ID INNER JOIN LEDGERS ON LEDGERS.Acc_id = COLORTAGGING.TAG_LEDGERID ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' and ISNULL(COLORMASTER.COLOR_name, '')='" & CMBCOLOR.Text.Trim & "' AND COLORTAGGING.TAG_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then TXTPSHADE.Text = dt.Rows(0).Item("PSHADE")
        End If
    End Sub

    Private Sub CMBMILLNAME_Enter(sender As Object, e As EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then FILLMILL(CMBMILLNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCONES.KeyPress, TXTBAGS.KeyPress
        numkeypress(e, sender, Me)
    End Sub


End Class

