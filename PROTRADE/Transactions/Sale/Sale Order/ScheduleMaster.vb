
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class ScheduleMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSCHNO As Integer

    Private Sub cmdEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            tstxtbillno.Clear()
            SCHDATE.Text = Now.Date
            GRIDSO.RowCount = 0
            LBLTOTALMTRS.Text = "0.0"
            lbltotalqty.Text = "0"

            txtremarks.Clear()
            getmax_SCH_no()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmax_SCH_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SCH_no),0) + 1 ", " SCHEDULEMASTER ", " AND SCH_cmpid=" & CmpId & "  and SCH_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSCHNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If SCHDATE.Text = "__/__/____" Then
                EP.SetError(SCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(SCHDATE.Text) Then
                    EP.SetError(SCHDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Challan Raised, Delete Challan First")
                bln = False
            End If
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ScheduleMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            clear()
            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim OBJFP As New ClsScheduleMaster()
                OBJFP.alParaval.Add(TEMPSCHNO)
                OBJFP.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJFP.SELECTSCHEDULE()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSCHNO.Text = TEMPSCHNO
                        SCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        lbltotalqty.Text = Convert.ToString(dr("TOTALQTY"))
                        LBLTOTALMTRS.Text = Convert.ToString(dr("TOTALMTRS"))
                        'dttable = OBJCMN.search("   ISNULL(SCHEDULEMASTER_DESC.SCH_NO, 0) AS SCHNO, ISNULL(SCHEDULEMASTER_DESC.SCH_SONO, 0) AS SONO, ISNULL(LEDGERS.Acc_cmpname, '')  AS NAME, ISNULL(SCHEDULEMASTER_DESC.SCH_GRIDSONO, 0) AS GRIDSONO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(SCHEDULEMASTER_DESC.SCH_QTY, 0) AS QTY, ISNULL(SCHEDULEMASTER_DESC.SCH_MTRS, 0) AS MTRS, ISNULL(SCHEDULEMASTER_DESC.SCH_RECDQTY, 0) AS RECDQTY, ISNULL(SCHEDULEMASTER_DESC.SCH_GRIDSCHNO, 0) AS GRIDSCHNO ", "", "  SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id INNER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id ", " AND SCH_NO = " & TEMPSCHNO & " AND SCH_YEARID = " & YearId)
                        GRIDSO.Rows.Add(Val(dr("GRIDSCHNO")), Val(dr("SONO")), Val(dr("GRIDSONO")), dr("NAME"), dr("ITEMNAME"), dr("COLOR"), Val(dr("QTY")), Val(dr("MTRS")), Val(dr("RECDQTY")), dr("Type"))

                        If Val(dr("RECDQTY")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                Else
                    EDIT = False
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSO.RowCount = 0
                TEMPSCHNO = Val(tstxtbillno.Text)
                If TEMPSCHNO > 0 Then
                    EDIT = True
                    ScheduleMaster_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolPREVIOUS.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSO.RowCount = 0
LINE1:
            TEMPSCHNO = Val(TXTSCHNO.Text) - 1
            If TEMPSCHNO > 0 Then
                EDIT = True
                ScheduleMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSCHNO > 1 Then
                TXTSCHNO.Text = TEMPSCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDSO.RowCount = 0
LINE1:
            TEMPSCHNO = Val(TXTSCHNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTSCHNO.Text.Trim
            clear()
            If Val(TXTSCHNO.Text) - 1 >= TEMPSCHNO Then
                EDIT = True
                ScheduleMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSCHNO < MAXNO Then
                TXTSCHNO.Text = TEMPSCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SCHEDULEMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Dim OBJTRNDTLS As New ScheduleMasterDetails
            OBJTRNDTLS.MdiParent = MDIMain
            OBJTRNDTLS.Show()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDSO.Focus()
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SCH_no),0) + 1 ", "SCHEDULEMASTER", " AND SCH_YEARID =" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSCHNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Challan Made, Delete Challan First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Schedule?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


                Dim alParaval As New ArrayList
                alParaval.Add(TXTSCHNO.Text.Trim)
                alParaval.Add(YearId)

                Dim CLSSCH As New ClsScheduleMaster()
                CLSSCH.alParaval = alParaval
                Dim IntResult As Integer = CLSSCH.DELETE()
                MsgBox("Schedule Deleted")
                clear()
                EDIT = False
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()

            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Format(Convert.ToDateTime(SCHDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Val(lbltotalqty.Text.Trim))
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSCHNO As String = ""
            Dim SONO As String = ""
            Dim GRIDSONO As String = ""
            Dim NAME As String = ""
            Dim ITEMNAME As String = ""
            Dim COLOR As String = ""
            Dim QTY As String = ""
            Dim MTRS As String = ""
            Dim RECQTY As String = ""
            Dim TYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSCHNO = "" Then
                        GRIDSCHNO = Val(row.Cells(gsrno.Index).Value.ToString)
                        SONO = Val(row.Cells(GSONO.Index).Value.ToString)
                        GRIDSONO = Val(row.Cells(GGRIDSONO.Index).Value.ToString)
                        NAME = row.Cells(GPARTYNAME.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        QTY = Val(row.Cells(gQty.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        RECQTY = Val(row.Cells(GRECDQTY.Index).Value)
                        TYPE = row.Cells(GTYPE.Index).Value.ToString

                    Else
                        GRIDSCHNO = GRIDSCHNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        SONO = SONO & "|" & Val(row.Cells(GSONO.Index).Value)
                        GRIDSONO = GRIDSONO & "|" & Val(row.Cells(GGRIDSONO.Index).Value)
                        NAME = NAME & "|" & row.Cells(GPARTYNAME.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value
                        QTY = QTY & "|" & Val(row.Cells(gQty.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        RECQTY = RECQTY & "|" & row.Cells(GRECDQTY.Index).Value
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSCHNO)
            alParaval.Add(SONO)
            alParaval.Add(GRIDSONO)
            alParaval.Add(NAME)
            alParaval.Add(ITEMNAME)
            alParaval.Add(COLOR)
            alParaval.Add(QTY)
            alParaval.Add(MTRS)
            alParaval.Add(RECQTY)
            alParaval.Add(TYPE)


            Dim OBJSO As New ClsScheduleMaster()
            OBJSO.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSO.SAVE()
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSCHNO)
                alParaval.Add(YearId)
                Dim IntResult As Integer = OBJSO.UPDATE()
                MsgBox("Details Updated")
            End If

            EDIT = False
            clear()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub total()

        If GRIDSO.RowCount > 0 Then
            lbltotalqty.Text = 0.0
            LBLTOTALMTRS.Text = 0.0
            For Each row As DataGridViewRow In GRIDSO.Rows
                If Val(row.Cells(gQty.Index).EditedFormattedValue) > 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GMTRS.Index).EditedFormattedValue) > 0 Then LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
            Next
        Else
            lbltotalqty.Text = "0.00"
            LBLTOTALMTRS.Text = "0.00"
        End If
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            Dim DTSO As New DataTable
            Dim OBJSELECTSO As New SelectSOforScheduling
            OBJSELECTSO.ShowDialog()
            DTSO = OBJSELECTSO.DT

            If DTSO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTSO.Rows
                    GRIDSO.Rows.Add(0, Val(DTROWPS("SONO")), Val(DTROWPS("GRIDSRNO")), DTROWPS("NAME"), DTROWPS("ITEM"), DTROWPS("COLOR"), Val(DTROWPS("QTY")), Format(Val(DTROWPS("MTRS")), "0.00"), 0, DTROWPS("TYPE"))
                Next
            End If
            getsrno(GRIDSO)
            total()

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

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function


    Private Sub gridSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSO.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSO.Rows.RemoveAt(GRIDSO.CurrentRow.Index)
                total()
                getsrno(GRIDSO)
            ElseIf e.KeyCode = Keys.F12 And GRIDSO.RowCount > 0 Then
                If GRIDSO.CurrentRow.Cells(gitemname.Index).Value <> "" Then GRIDSO.Rows.Add(CloneWithValues(GRIDSO.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDSO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case gQty.Index, GMTRS.Index

                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDSO.CurrentCell.Value = Nothing Then GRIDSO.CurrentCell.Value = "0.00"
                    GRIDSO.CurrentCell.Value = Convert.ToDecimal(GRIDSO.Item(colNum, e.RowIndex).Value)
                    '' everything is good

                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
                total()

        End Select
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New ScheduleMasterDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
            objpodtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJsaleOrder As New SaleOrderDesign
            OBJsaleOrder.MdiParent = MDIMain
            OBJsaleOrder.FRMSTRING = "SCHEDULEREPORT"
            OBJsaleOrder.FORMULA = "{SCHEDULEMASTER.SCH_NO} = " & Val(TXTSCHNO.Text) & " AND {SCHEDULEMASTER.SCH_YEARID} = " & YearId
            OBJsaleOrder.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class