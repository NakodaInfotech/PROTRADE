
Imports System.ComponentModel
Imports BL

Public Class StoreConsumption

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPCONSUMENO As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CONSUMEDATE.Focus()
    End Sub

    Sub clear()

        CONSUMEDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBDEPARTMENT.Text = ""
        TXTISSUEDTO.Clear()
        TXTCHALLANNO.Clear()
        EP.Clear()
        TXTREMARKS.Clear()

        TXTSRNO.Text = 1
        CMBSTOREITEMNAME.Text = ""
        TXTDESC.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        GRIDCONSUME.RowCount = 0

        LBLTOTALQTY.Text = 0

        getmax_BILL_no()

    End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(CONSUME_NO),0) + 1 ", "  CONSUMPTION ", " AND CONSUME_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTCONSUMENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub StoreConsumption_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                GRIDCONSUME.Focus()
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
        If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, EDIT)
        If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
    End Sub

    Private Sub StoreConsumption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

                Dim OBJCONSUME As New ClsStoreConsumption
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPCONSUMENO)
                ALPARAVAL.Add(YearId)
                OBJCONSUME.alParaval = ALPARAVAL
                Dim dttable As DataTable = OBJCONSUME.SELECTCONSUME()

                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTCONSUMENO.Text = TEMPCONSUMENO
                        CONSUMEDATE.Text = Format(Convert.ToDateTime(dr("CONSUMEDATE")).Date, "dd/MM/yyyy")

                        CMBDEPARTMENT.Text = Convert.ToString(dr("DEPARTMENT").ToString)
                        TXTISSUEDTO.Text = dr("ISSUETO").ToString

                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS").ToString)

                        GRIDCONSUME.Rows.Add(dr("GRIDSRNO"), dr("ITEMNAME"), dr("DESC"), Val(dr("QTY")), dr("QTYUNIT"))
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(CONSUMEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(TXTISSUEDTO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text)
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DESC As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUME.Rows
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

            Dim OBJCONSUME As New ClsStoreConsumption
            OBJCONSUME.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJCONSUME.SAVE()
                TEMPCONSUMENO = DTTABLE.Rows(0).Item(0)
                MessageBox.Show("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCONSUMENO)
                IntResult = OBJCONSUME.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            clear()
            CONSUMEDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CONSUMEDATE.Text = "__/__/____" Then
            EP.SetError(CONSUMEDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(CONSUMEDATE.Text) Then
                EP.SetError(CONSUMEDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If CMBDEPARTMENT.Text.Trim.Length = 0 Then
            EP.SetError(CMBDEPARTMENT, " Please Fill Department")
            bln = False
        End If

        If GRIDCONSUME.RowCount = 0 Then
            EP.SetError(CMBDEPARTMENT, " Please Fill Item Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
LINE1:
            TEMPCONSUMENO = Val(TXTCONSUMENO.Text) - 1
Line2:
            If TEMPCONSUMENO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" CONSUME_NO ", "", "  CONSUMPTION ", " AND CONSUME_NO = '" & TEMPCONSUMENO & "' AND CONSUMPTION.CONSUME_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    StoreConsumption_Load(sender, e)
                Else
                    TEMPCONSUMENO = Val(TEMPCONSUMENO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                EDIT = False
            End If

            If Val(TXTQTY.Text.Trim) = 0 And TEMPCONSUMENO > 1 Then
                TXTCONSUMENO.Text = TEMPCONSUMENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPCONSUMENO = Val(TXTCONSUMENO.Text) + 1
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTCONSUMENO.Text.Trim
            clear()
            If Val(TXTCONSUMENO.Text) - 1 >= TEMPCONSUMENO Then
                EDIT = True
                StoreConsumption_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If Val(TXTQTY.Text.Trim) = 0 And TEMPCONSUMENO < MAXNO Then
                TXTCONSUMENO.Text = TEMPCONSUMENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                TEMPCONSUMENO = Val(tstxtbillno.Text)
                If TEMPCONSUMENO > 0 Then
                    EDIT = True
                    StoreConsumption_Load(sender, e)
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
            Dim OBJDTLS As New StoreConsumptionDetails
            OBJDTLS.MdiParent = MDIMain
            OBJDTLS.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete Consumption?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTCONSUMENO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsDO As New ClsStoreConsumption
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

    Private Sub CONSUMEDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CONSUMEDATE.GotFocus
        CONSUMEDATE.SelectAll()
    End Sub

    Private Sub CONSUMEDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CONSUMEDATE.Validating
        Try
            If CONSUMEDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CONSUMEDATE.Text, TEMP) Then
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
            For Each ROW As DataGridViewRow In GRIDCONSUME.Rows
                If ROW.Cells(GITEMNAME.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text += Val(ROW.Cells(GQTY.Index).EditedFormattedValue)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDCONSUME.Rows.Add(0, CMBSTOREITEMNAME.Text.Trim, TXTDESC.Text.Trim, Val(TXTQTY.Text.Trim), CMBUNIT.Text.Trim)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDCONSUME.Item(GITEMNAME.Index, TEMPROW).Value = CMBSTOREITEMNAME.Text.Trim
                GRIDCONSUME.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDCONSUME.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDCONSUME.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            getsrno(GRIDCONSUME)
            total()

            GRIDCONSUME.FirstDisplayedScrollingRowIndex = GRIDCONSUME.RowCount - 1


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

    Private Sub GRIDCONSUME_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONSUME.CellDoubleClick
        Try
            If GRIDCONSUME.CurrentRow.Index >= 0 And GRIDCONSUME.Item(GITEMNAME.Index, GRIDCONSUME.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                CMBSTOREITEMNAME.Text = GRIDCONSUME.Item(GITEMNAME.Index, GRIDCONSUME.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDCONSUME.Item(GDESC.Index, GRIDCONSUME.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDCONSUME.Item(GQTY.Index, GRIDCONSUME.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDCONSUME.Item(GUNIT.Index, GRIDCONSUME.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDCONSUME.CurrentRow.Index
                CMBSTOREITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCONSUME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONSUME.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCONSUME.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDCONSUME.Rows.RemoveAt(GRIDCONSUME.CurrentRow.Index)
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

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class