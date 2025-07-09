
Imports System.ComponentModel
Imports BL

Public Class YarnSaleOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSONO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub getmax_YSO_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(YSO_no),0) + 1 ", "YARNSALEORDER", " and YSO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then txtSONO.Text = DTTABLE.Rows(0).Item(0)
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
        SODATE.Text = Now.Date
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

        txtsrno.Text = 1
        CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBAGS.Clear()
        CMBUNIT.Text = ""
        TXTWT.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        GRIDSO.RowCount = 0

        LBLTOTALBAGS.Text = 0
        LBLTOTALWT.Text = 0
        lbltotalamt.Text = 0

        EP.Clear()

        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()

        txtinwords.Clear()
        getmax_YSO_no()
        GRIDDOUBLECLICK = False

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub YarnSaleOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                GRIDSO.Focus()
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
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

    Private Sub YarnSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
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


                Dim objclsPO As New ClsYarnSaleOrder()
                Dim dt_po As DataTable = objclsPO.SELECTSO(TEMPSONO, CmpId, Locationid, YearId)
                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows

                        TXTSONO.Text = dr("SONO")
                        SODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))

                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        TXTDELPERIOD.Text = Val(dr("DELDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))
                        txtdiscount.Text = Convert.ToString(dr("DISCOUNT"))
                        txtRefno.Text = Convert.ToString(dr("REFNO"))

                        CMBBROKER.Text = Convert.ToString(dr("BROKER"))
                        CMBTRANS.Text = Convert.ToString(dr("TRANSNAME"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        GRIDSO.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("DESC").ToString, dr("DESIGN").ToString, dr("SHADE").ToString, Format(Val(dr("BAGS")), "0.00"), dr("UNIT").ToString, Format(Val(dr("WT")), "0.00"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMT")), "0.00"), Val(dr("RECDBAGS")), Val(dr("RECDWT")), dr("DONE").ToString, dr("CLOSED"))


                        If Val(dr("RECDBAGS")) > 0 Or Val(dr("RECDWT")) > 0 Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            cmbname.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

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

            alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(duedate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(Val(TXTDELPERIOD.Text.Trim))
            alParaval.Add(txtRefno.Text.Trim)

            alParaval.Add(txtdiscount.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(Val(LBLTOTALBAGS.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim yarnquality As String = ""
            Dim desc As String = ""
            Dim DESIGN As String = ""
            Dim SHADE As String = ""
            Dim BAGS As String = ""
            Dim UNIT As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        yarnquality = row.Cells(GYARNQUALITY.Index).Value.ToString
                        desc = row.Cells(gdesc.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        SHADE = row.Cells(gcolor.Index).Value.ToString
                        BAGS = Val(row.Cells(GBAGS.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        WT = Val(row.Cells(GWT.Index).Value)
                        RATE = Val(row.Cells(grate.Index).Value)
                        AMT = Val(row.Cells(gamt.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        yarnquality = yarnquality & "|" & row.Cells(GYARNQUALITY.Index).Value
                        desc = desc & "|" & row.Cells(gdesc.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        SHADE = SHADE & "|" & row.Cells(gcolor.Index).Value.ToString
                        BAGS = BAGS & "|" & Val(row.Cells(GBAGS.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(grate.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(gamt.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(yarnquality)
            alParaval.Add(desc)
            alParaval.Add(DESIGN)
            alParaval.Add(SHADE)
            alParaval.Add(BAGS)
            alParaval.Add(UNIT)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(AMT)

            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)

            Dim objclsPurord As New ClsYarnSaleOrder()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTSONO.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPSONO)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.UPDATE()
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

        If SODATE.Text = "__/__/____" Then
            EP.SetError(SODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(SODATE.Text) Then
                EP.SetError(SODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()
        LBLTOTALBAGS.Text = "0"
        LBLTOTALWT.Text = "0.00"
        lbltotalamt.Text = "0.00"
        If GRIDSO.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDSO.Rows
                row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(GWT.Index).Value), "0.00")
                If Val(row.Cells(GBAGS.Index).Value) <> 0 Then LBLTOTALBAGS.Text = Val(LBLTOTALBAGS.Text) + Val(row.Cells(GBAGS.Index).Value)
                If Val(row.Cells(GWT.Index).Value) <> 0 Then LBLTOTALWT.Text = Val(LBLTOTALWT.Text) + Val(row.Cells(GWT.Index).Value)
                If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value)
            Next
        End If
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDSO.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSO.Rows(GRIDSO.RowCount - 1).Cells(gsrno.Index).Value) + 1
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

        GRIDSO.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDSO.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, TXTDESC.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, Val(TXTBAGS.Text.Trim), CMBUNIT.Text.Trim, Val(TXTWT.Text.Trim), Val(TXTRATE.Text.Trim), 0, 0, 0, 0, 0)
            getsrno(GRIDSO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSO.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDSO.Item(gdesc.Index, TEMPROW).Value = TXTDESC.Text.Trim
            GRIDSO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDSO.Item(gcolor.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDSO.Item(GBAGS.Index, TEMPROW).Value = Val(TXTBAGS.Text.Trim)
            GRIDSO.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDSO.Item(GWT.Index, TEMPROW).Value = Val(TXTWT.Text.Trim)
            GRIDSO.Item(grate.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

        txtsrno.Text = GRIDSO.RowCount + 1
        If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
        TXTDESC.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBAGS.Clear()
        TXTWT.Clear()
        TXTRATE.Clear()

        total()
        CMBCOLOR.Focus()

    End Sub

    Private Sub GRIDSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSO.CellDoubleClick
        If e.RowIndex >= 0 And GRIDSO.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(GRIDSO.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDSO.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            GRIDDOUBLECLICK = True
            txtsrno.Text = Val(GRIDSO.Item(gsrno.Index, e.RowIndex).Value)
            CMBYARNQUALITY.Text = GRIDSO.Item(GYARNQUALITY.Index, e.RowIndex).Value.ToString
            TXTDESC.Text = GRIDSO.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBDESIGN.Text = GRIDSO.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            CMBCOLOR.Text = GRIDSO.Item(gcolor.Index, e.RowIndex).Value.ToString
            TXTBAGS.Text = Val(GRIDSO.Item(GBAGS.Index, e.RowIndex).Value)
            CMBUNIT.Text = GRIDSO.Item(GUNIT.Index, e.RowIndex).Value.ToString
            TXTWT.Text = Val(GRIDSO.Item(GWT.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(GRIDSO.Item(grate.Index, e.RowIndex).Value)

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

    Private Sub SODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SODATE.GotFocus
        SODATE.SelectAll()
    End Sub

    Private Sub SODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SODATE.Validating
        Try
            If SODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SODATE.Text, TEMP) Then
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
                    MsgBox("SO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Sale Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPSONO)
                alParaval.Add(YearId)

                Dim clspo As New ClsYarnSaleOrder()
                clspo.alParaval = alParaval
                IntResult = clspo.DELETE()
                MsgBox("Sale Order Deleted")
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
                namevalidate(cmbname, cmbcode, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'", "Sundry Debtors", "ACCOUNTS", CMBTRANS.Text.Trim, CMBBROKER.Text)
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

    Private Sub GRIDSO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDSO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, GBAGS.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDSO.CurrentCell.Value = Nothing Then GRIDSO.CurrentCell.Value = "0.00"
                    GRIDSO.CurrentCell.Value = Convert.ToDecimal(GRIDSO.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    GRIDSO.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(GRIDSO.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(GRIDSO.Rows(e.RowIndex).Cells(GWT.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If GRIDSO.CurrentRow.Index >= 0 And GRIDSO.Item(gsrno.Index, GRIDSO.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                txtsrno.Text = Val(GRIDSO.Item(gsrno.Index, GRIDSO.CurrentRow.Index).Value)
                CMBYARNQUALITY.Text = GRIDSO.Item(GYARNQUALITY.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDSO.Item(gdesc.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSO.Item(GDESIGN.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDSO.Item(gcolor.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTBAGS.Text = Val(GRIDSO.Item(GBAGS.Index, GRIDSO.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDSO.Item(GUNIT.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTWT.Text = Val(GRIDSO.Item(GWT.Index, GRIDSO.CurrentRow.Index).Value)
                TXTRATE.Text = Val(GRIDSO.Item(grate.Index, GRIDSO.CurrentRow.Index).Value)

                TEMPROW = GRIDSO.CurrentRow.Index
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSO.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSO.RowCount > 0 Then

                If Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDSO.Rows.RemoveAt(GRIDSO.CurrentRow.Index)
                total()
                getsrno(GRIDSO)
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
                GRIDSO.RowCount = 0
                TEMPSONO = Val(tstxtbillno.Text)
                If TEMPSONO > 0 Then
                    EDIT = True
                    YarnSaleOrder_Load(sender, e)
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
            If MsgBox("Wish to Print Sale Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPO As New YarnDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.PARTYNAME = cmbname.Text.Trim
            OBJPO.AGENTNAME = CMBBROKER.Text.Trim
            OBJPO.FRMSTRING = "YARNSO"
            OBJPO.WHERECLAUSE = "{YARNSALEORDER.YSO_NO}=" & Val(TXTSONO.Text) & " and {YARNSALEORDER.YSO_yearid}=" & YearId
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
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) - 1
            If TEMPSONO > 0 Then
                EDIT = True
                YarnSaleOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSONO > 1 Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) + 1
            getmax_YSO_no()
            Dim MAXNO As Integer = TXTSONO.Text.Trim
            clear()
            If Val(TXTSONO.Text) - 1 >= TEMPSONO Then
                EDIT = True
                YarnSaleOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSONO < MAXNO Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTDELPERIOD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELPERIOD.Validated
        Try
            If SODATE.Text <> "__/__/____" Then
                If Val(TXTDELPERIOD.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(SODATE.Text).Date.AddDays(Val(TXTDELPERIOD.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub duedate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles duedate.Validated
        Try
            If SODATE.Text <> "__/__/____" And Val(TXTDELPERIOD.Text.Trim) = 0 Then TXTDELPERIOD.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(SODATE.Text).Date, duedate.Value.Date)
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

            Dim objINVDTLS As New YarnSaleOrderDetails
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
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then

                'check whether same quality and shade is present in grid or not
                If ClientName = "VAISHALI" And CMBCOLOR.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDSO.Rows
                        If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And ROW.Index <> TEMPROW) Then
                            If ROW.Cells(GYARNQUALITY.Index).Value = CMBYARNQUALITY.Text.Trim And ROW.Cells(gcolor.Index).Value = CMBCOLOR.Text.Trim Then
                                If MsgBox("Quality with same Shade already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                            End If
                        End If
                    Next
                End If


                fillgrid()
            End If
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

    Private Sub YarnSaleOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "VAISHALI" Then
                GBAGS.HeaderText = "Box/Tube"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBAGS_Validated(sender As Object, e As EventArgs) Handles TXTBAGS.Validated
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM YARNQUALITYMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(TXTBAGS.Text.Trim) <> 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_BOXTUBEWT,0) AS BOXWT", "", "YARNQUALITYMASTER ", " AND YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(TXTBAGS.Text.Trim) * Val(DT.Rows(0).Item("BOXWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class