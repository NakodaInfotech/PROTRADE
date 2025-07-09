
Imports BL

Public Class StoreInward

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPINWARDNO As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        INWARDDATE.Focus()
    End Sub

    Sub clear()

        INWARDDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBNAME.Text = ""
        CMBTRANS.Text = ""
        TXTCHALLANNO.Clear()
        CHALLANDATE.Clear()
        EP.Clear()
        txtremarks.Clear()

        TXTSRNO.Text = 1
        CMBSTOREITEMNAME.Text = ""
        TXTDESC.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        GRIDINWARD.RowCount = 0

        LBLTOTALQTY.Text = 0

        getmax_BILL_no()

    End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(STORE_NO),0) + 1 ", "  STOREINWARD ", " AND STORE_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTINWARDNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub STOREINWARD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDINWARD.Focus()
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
    End Sub

    Private Sub STOREINWARD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJINWARD As New ClsStoreInward
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPINWARDNO)
                ALPARAVAL.Add(YearId)
                OBJINWARD.alParaval = ALPARAVAL
                Dim dttable As DataTable = OBJINWARD.SELECTINWARD()

                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTINWARDNO.Text = TEMPINWARDNO
                        INWARDDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")

                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBTRANS.Text = dr("TRANSNAME").ToString

                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)

                        GRIDINWARD.Rows.Add(dr("GRIDSRNO"), dr("ITEMNAME"), dr("DESC"), Val(dr("QTY")), dr("UNIT"))
                    Next
                    total()
                Else
                    EDIT = False
                    clear()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(INWARDDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DESC As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDINWARD.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(DESC)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)

            Dim OBJINWARD As New ClsStoreInward
            OBJINWARD.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJINWARD.SAVE()
                TEMPINWARDNO = DTTABLE.Rows(0).Item(0)
                MessageBox.Show("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPINWARDNO)
                IntResult = OBJINWARD.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            clear()
            INWARDDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If INWARDDATE.Text = "__/__/____" Then
            EP.SetError(INWARDDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(INWARDDATE.Text) Then
                EP.SetError(INWARDDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If CHALLANDATE.Text = "__/__/____" Then
            EP.SetError(CHALLANDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(CHALLANDATE.Text) Then
                EP.SetError(CHALLANDATE, "Date not in Accounting Year")
                bln = False
            End If

            If Convert.ToDateTime(INWARDDATE.Text).Date < Convert.ToDateTime(CHALLANDATE.Text).Date Then
                EP.SetError(CHALLANDATE, " Please Enter Proper Challan Date")
                bln = False
            End If
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Supplier Name ")
            bln = False
        End If


        If GRIDINWARD.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Fill Item Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, cmbcode, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT' ", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' ")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, cmbcode, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDINWARD.RowCount = 0
LINE1:
            TEMPINWARDNO = Val(TXTINWARDNO.Text) - 1
            If TEMPINWARDNO > 0 Then
                EDIT = True
                STOREINWARD_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDINWARD.RowCount = 0 And TEMPINWARDNO > 1 Then
                TXTINWARDNO.Text = TEMPINWARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDINWARD.RowCount = 0
LINE1:
            TEMPINWARDNO = Val(TXTINWARDNO.Text) + 1
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTINWARDNO.Text.Trim
            clear()

            If Val(TXTINWARDNO.Text) - 1 >= TEMPINWARDNO Then
                EDIT = True
                STOREINWARD_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDINWARD.RowCount = 0 And TEMPINWARDNO < MAXNO Then
                TXTINWARDNO.Text = TEMPINWARDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDINWARD.RowCount = 0
                TEMPINWARDNO = Val(tstxtbillno.Text)
                If TEMPINWARDNO > 0 Then
                    EDIT = True
                    STOREINWARD_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJDTLS As New StoreInwardDetails
            OBJDTLS.MdiParent = MDIMain
            OBJDTLS.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete Store Inward?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTINWARDNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsDO As New ClsStoreInward
                    ClsDO.alParaval = alParaval
                    Dim IntResult As Integer = ClsDO.DELETE()
                    MsgBox("Entry Deleted Successfully")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub INWARDDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles INWARDDATE.GotFocus
        INWARDDATE.SelectAll()
    End Sub

    Private Sub INWARDDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles INWARDDATE.Validating
        Try
            If INWARDDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(INWARDDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHALLANDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHALLANDATE.GotFocus
        CHALLANDATE.SelectAll()
    End Sub

    Private Sub CHALLANDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHALLANDATE.Validating
        Try
            If CHALLANDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHALLANDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Sub total()
        Try
            LBLTOTALQTY.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDINWARD.Rows
                If ROW.Cells(GITEMNAME.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Val(LBLTOTALQTY.Text.Trim) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDINWARD.Rows.Add(0, CMBSTOREITEMNAME.Text.Trim, TXTDESC.Text.Trim, Val(TXTQTY.Text.Trim), CMBUNIT.Text.Trim)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDINWARD.Item(GITEMNAME.Index, TEMPROW).Value = CMBSTOREITEMNAME.Text.Trim
                GRIDINWARD.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDINWARD.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDINWARD.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            getsrno(GRIDINWARD)
            total()

            GRIDINWARD.FirstDisplayedScrollingRowIndex = GRIDINWARD.RowCount - 1


            CMBSTOREITEMNAME.Focus()

            CMBSTOREITEMNAME.Text = ""
            TXTDESC.Clear()
            TXTQTY.Clear()
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

    Private Sub CMBUNIT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUNIT.Validated
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINWARD_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDINWARD.CellDoubleClick
        Try
            If GRIDINWARD.CurrentRow.Index >= 0 And GRIDINWARD.Item(GITEMNAME.Index, GRIDINWARD.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                CMBSTOREITEMNAME.Text = GRIDINWARD.Item(GITEMNAME.Index, GRIDINWARD.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDINWARD.Item(GDESC.Index, GRIDINWARD.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDINWARD.Item(GQTY.Index, GRIDINWARD.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDINWARD.Item(GUNIT.Index, GRIDINWARD.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDINWARD.CurrentRow.Index
                CMBSTOREITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINWARD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDINWARD.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDINWARD.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDINWARD.Rows.RemoveAt(GRIDINWARD.CurrentRow.Index)
                total()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSTOREITEMNAME.Enter
        Try
            If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTOREITEMNAME.Validating
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class