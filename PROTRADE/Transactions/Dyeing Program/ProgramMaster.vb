
Imports System.ComponentModel
Imports System.IO
Imports BL

Public Class ProgramMaster

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public PROGRAMNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()

        PROGRAMDATE.Value = Now.Date
        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        CARDRECDATE.Clear()
        CARDISSUEDATE.Clear()

        TXTSRNO.Text = 1
        CMBLOTNO.Items.Clear()
        CMBLOTNO.Text = ""
        CMBLOTNO.Enabled = True
        CMBITEMNAME.Text = ""
        CMBDESIGNNO.Text = ""
        TXTTOTALMTRS.Clear()
        TXTGRNNO.Clear()
        TXTGRNTYPE.Clear()
        CMBCOLOR.Text = ""
        TXTMTRS.Clear()
        GRIDLOT.RowCount = 0
        LBLTOTALMTRS.Text = 0
        TXTBARCODE.Clear()
        CHKURGENT.CheckState = CheckState.Unchecked

        txtremarks.Clear()

        GRIDDOUBLECLICK = False
        GETMAXNO()
        TXTPROCESSNAME.Clear()
        TXTFOLD.Clear()
        TXTFINISHTYPE.Clear()
        GRIDSUMM.RowCount = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            GRIDSUMM.RowCount = 0
            Dim DONE As Boolean = False
            For Each ROW As DataGridViewRow In GRIDLOT.Rows
                LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                DONE = False
                If Val(ROW.Cells(GMTRS.Index).EditedFormattedValue) > 0 Then
                    If GRIDSUMM.RowCount = 0 Then
                        GRIDSUMM.Rows.Add(ROW.Cells(GLOTNO.Index).Value, Format(Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"), Format(Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00"))
                    Else
                        For Each SUMMROW As DataGridViewRow In GRIDSUMM.Rows
                            If SUMMROW.Cells(SLOTNO.Index).Value = ROW.Cells(GLOTNO.Index).Value Then
                                SUMMROW.Cells(SPRGMTRS.Index).Value = Format(Val(SUMMROW.Cells(SPRGMTRS.Index).EditedFormattedValue) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                                SUMMROW.Cells(SBALMTRS.Index).Value = Format(Val(SUMMROW.Cells(SMTRS.Index).EditedFormattedValue) - Val(SUMMROW.Cells(SPRGMTRS.Index).EditedFormattedValue), "0.00")
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDSUMM.Rows.Add(ROW.Cells(GLOTNO.Index).Value, Format(Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00"), Format(Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00"), Format(Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        PROGRAMDATE.Focus()
    End Sub

    Private Sub PROGRAMDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PROGRAMDATE.Validating
        If Not datecheck(PROGRAMDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PROGRAM_no),0) + 1 ", " PROGRAMMASTER ", " AND PROGRAM_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPROGRAMNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Select Name ")
                bln = False
            End If

            If Val(LBLTOTALMTRS.Text.Trim) = 0 Then
                EP.SetError(CMBLOTNO, " Please Select Lot No")
                bln = False
            End If

            If Val(GRIDLOT.RowCount) = 0 Then
                EP.SetError(GRIDLOT, " Please Select Lot")
                bln = False
            End If

            If Not datecheck(PROGRAMDATE.Value) Then
                EP.SetError(PROGRAMDATE, "Date Not in Current Accounting Year")
                bln = False
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

            alParaval.Add(PROGRAMDATE.Value.Date)
            alParaval.Add(CMBNAME.Text.Trim)
            If CARDRECDATE.Text = "__/__/____" Then alParaval.Add("") Else alParaval.Add(CARDRECDATE.Text)
            If CARDISSUEDATE.Text = "__/__/____" Then alParaval.Add("") Else alParaval.Add(CARDISSUEDATE.Text)
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)


            Dim GRIDSRNO As String = ""
            Dim LOTNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DESIGNNO As String = ""
            Dim TOTALPCS As String = ""
            Dim COLOR As String = ""
            Dim URGENT As String = ""
            Dim PCS As String = ""
            Dim PROGISSDATE As String = ""
            Dim STATUS As String = ""
            Dim PRODCUTTING As String = ""
            Dim FINISHCUTTING As String = ""
            Dim INWARDDATE As String = ""
            Dim GRNNO As String = ""
            Dim GRNTYPE As String = ""
            Dim RECDPCS As String = ""
            Dim BARCODE As String = ""
            Dim RATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDLOT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value
                        TOTALPCS = Val(row.Cells(GTOTALMTRS.Index).Value)
                        COLOR = row.Cells(GCOLOR.Index).Value
                        URGENT = row.Cells(GURGENT.Index).Value
                        PCS = Val(row.Cells(GMTRS.Index).Value)
                        PROGISSDATE = row.Cells(GPROGISSDATE.Index).Value
                        STATUS = row.Cells(GSTATUS.Index).Value
                        PRODCUTTING = row.Cells(GCUTRECDDATE.Index).Value
                        FINISHCUTTING = row.Cells(GFINISHCUTTING.Index).Value
                        INWARDDATE = row.Cells(GINWARDDATE.Index).Value
                        GRNNO = Val(row.Cells(GGRNNO.Index).Value)
                        GRNTYPE = row.Cells(GGRNTYPE.Index).Value
                        RECDPCS = Val(row.Cells(GRECDMTRS.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        RATE = Val(row.Cells(GRATE.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value
                        TOTALPCS = TOTALPCS & "|" & Val(row.Cells(GTOTALMTRS.Index).Value)
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        URGENT = URGENT & "|" & row.Cells(GURGENT.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        PROGISSDATE = PROGISSDATE & "|" & row.Cells(GPROGISSDATE.Index).Value
                        STATUS = STATUS & "|" & row.Cells(GSTATUS.Index).Value
                        PRODCUTTING = PRODCUTTING & "|" & row.Cells(GCUTRECDDATE.Index).Value
                        FINISHCUTTING = FINISHCUTTING & "|" & row.Cells(GFINISHCUTTING.Index).Value
                        INWARDDATE = INWARDDATE & "|" & row.Cells(GINWARDDATE.Index).Value
                        GRNNO = GRNNO & "|" & Val(row.Cells(GGRNNO.Index).Value)
                        GRNTYPE = GRNTYPE & "|" & row.Cells(GGRNTYPE.Index).Value
                        RECDPCS = RECDPCS & "|" & Val(row.Cells(GRECDMTRS.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                    End If
                End If
            Next
            alParaval.Add(GRIDSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(DESIGNNO)
            alParaval.Add(TOTALPCS)
            alParaval.Add(COLOR)
            alParaval.Add(URGENT)
            alParaval.Add(PCS)
            alParaval.Add(PROGISSDATE)
            alParaval.Add(STATUS)
            alParaval.Add(PRODCUTTING)
            alParaval.Add(FINISHCUTTING)
            alParaval.Add(INWARDDATE)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNTYPE)
            alParaval.Add(RECDPCS)
            alParaval.Add(BARCODE)
            alParaval.Add(RATE)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(TXTPROCESSNAME.Text.Trim)
            alParaval.Add(TXTFINISHTYPE.Text.Trim)
            alParaval.Add(TXTFOLD.Text.Trim)


            Dim OBJPROGRAM As New ClsProgramMaster()
            OBJPROGRAM.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJPROGRAM.SAVE()
                MsgBox("Details Added")
                TXTPROGRAMNO.Text = DTTABLE.Rows(0).Item(0)
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(PROGRAMNO)
                Dim IntResult As Integer = OBJPROGRAM.UPDATE()
                MsgBox("Details Updated")
            End If

            PRINTREPORT()

            EDIT = False
            clear()
            PROGRAMDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Program?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJPROG As New ProgramDesign
                OBJPROG.MdiParent = MDIMain
                OBJPROG.WHERECLAUSE = "{PROGRAMMASTER.PROGRAM_YEARID} = " & YearId & " AND {PROGRAMMASTER.PROGRAM_no} = " & Val(TXTPROGRAMNO.Text.Trim)
                OBJPROG.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROGRAMMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            TOOLPREVIOUS_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PROGRAMMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
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

                Dim OBJCMN As New ClsCommon()
                Dim dttable As DataTable = OBJCMN.search(" PROGRAMMASTER.PROGRAM_NO AS PROGRAMNO, PROGRAMMASTER.PROGRAM_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PROGRAMMASTER.PROGRAM_CARDRECDATE, '') AS CARDRECDATE, ISNULL(PROGRAMMASTER.PROGRAM_CARDISSUEDATE, '') AS CARDISSUEDATE, PROGRAMMASTER.PROGRAM_LBLTOTALPCS AS TOTALPCS, PROGRAMMASTER.PROGRAM_REMARKS AS REMARKS, PROGRAMMASTER.PROGRAM_DONE AS DONE, PROGRAMMASTER_DESC.PROGRAM_GRIDSRNO AS GRIDSRNO, PROGRAMMASTER_DESC.PROGRAM_LOTNO AS LOTNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, PROGRAMMASTER_DESC.PROGRAM_TOTALPCS AS GRIDTOTALPCS, COLORMASTER.COLOR_name AS COLOR, ISNULL(PROGRAMMASTER_DESC.PROGRAM_URGENT, 0) AS URGENT, PROGRAMMASTER_DESC.PROGRAM_PCS AS PCS, ISNULL(PROGRAMMASTER_DESC.PROGRAM_PROGISSDATE, '') AS PROGISSDATE, ISNULL(PROGRAMMASTER_DESC.PROGRAM_STATUS, '') AS STATUS, ISNULL(PROGRAMMASTER_DESC.PROGRAM_PRODCUTTING, '') AS PRODCUTTING, ISNULL(PROGRAMMASTER_DESC.PROGRAM_FINISHCUTTING, '') AS FINISHCUTTING, ISNULL(PROGRAMMASTER_DESC.PROGRAM_INWARDDATE, '') AS INWARDDATE, PROGRAMMASTER_DESC.PROGRAM_GRNNO AS GRNNO, PROGRAMMASTER_DESC.PROGRAM_GRNTYPE AS GRNTYPE, PROGRAMMASTER_DESC.PROGRAM_RECDPCS AS RECDPCS, PROGRAMMASTER_DESC.PROGRAM_BARCODE AS BARCODE, ISNULL(PROGRAMMASTER_DESC.PROGRAM_RATE, '') AS RATE, ISNULL(PROGRAMMASTER.PROGRAM_PROCESSNAME, '') AS PROCESSNAME, ISNULL(PROGRAMMASTER.PROGRAM_FINISHTYPE, '') AS FINISHTYPE, ISNULL(PROGRAMMASTER.PROGRAM_FOLD, '') AS FOLD ", "", "  PROGRAMMASTER INNER JOIN PROGRAMMASTER_DESC ON PROGRAMMASTER.PROGRAM_NO = PROGRAMMASTER_DESC.PROGRAM_NO AND PROGRAMMASTER.PROGRAM_YEARID = PROGRAMMASTER_DESC.PROGRAM_YEARID LEFT OUTER JOIN LEDGERS ON PROGRAMMASTER.PROGRAM_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PROGRAMMASTER_DESC.PROGRAM_ITEMID = ITEMMASTER.item_id INNER JOIN COLORMASTER ON PROGRAMMASTER_DESC.PROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PROGRAMMASTER_DESC.PROGRAM_DESIGNID = DESIGNMASTER.DESIGN_id", " AND PROGRAMMASTER.PROGRAM_NO = " & PROGRAMNO & " AND PROGRAMMASTER.PROGRAM_YEARID = " & YearId & " ORDER BY PROGRAMMASTER_DESC.PROGRAM_GRIDSRNO")
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTPROGRAMNO.Text = Val(dr("PROGRAMNO"))
                        PROGRAMDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CARDRECDATE.Text = dr("CARDRECDATE")
                        CARDISSUEDATE.Text = dr("CARDISSUEDATE")


                        CMBNAME.Text = dr("NAME")
                        If CMBNAME.Text.Trim <> "" Then CMBNAME.Enabled = False
                        txtremarks.Text = dr("REMARKS")
                        TXTPROCESSNAME.Text = dr("PROCESSNAME")
                        TXTFINISHTYPE.Text = dr("FINISHTYPE")
                        TXTFOLD.Text = dr("FOLD")

                        GRIDLOT.Rows.Add(Val(dr("GRIDSRNO")), dr("LOTNO"), dr("ITEMNAME"), dr("DESIGNNO"), Val(dr("GRIDTOTALPCS")), dr("COLOR"), dr("URGENT"), Val(dr("PCS")), dr("PROGISSDATE"), dr("STATUS"), dr("PRODCUTTING"), dr("FINISHCUTTING"), dr("INWARDDATE"), Val(dr("GRNNO")), dr("GRNTYPE"), Val(dr("RECDPCS")), dr("BARCODE"), Val(dr("RATE")))

                        If Val(dr("RECDPCS")) > 0 Then GRIDLOT.Rows(GRIDLOT.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow

                    Next
                    GETSRNO(GRIDLOT)
                    TOTAL()
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

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " And GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            fillitemname(CMBITEMNAME, "")
            FILLDESIGN(CMBDESIGNNO, CMBITEMNAME.Text)
            FILLCOLOR(CMBCOLOR, CMBDESIGNNO.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDLOT.Rows.Add(Val(TXTSRNO.Text.Trim), CMBLOTNO.Text.Trim, CMBITEMNAME.Text.Trim, CMBDESIGNNO.Text.Trim, Val(TXTTOTALMTRS.Text.Trim), CMBCOLOR.Text.Trim, CHKURGENT.Checked, Val(TXTMTRS.Text.Trim), "", "", "", "", "", Val(TXTGRNNO.Text.Trim), TXTGRNTYPE.Text.Trim, 0, TXTBARCODE.Text.Trim)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDLOT.Item(GLOTNO.Index, TEMPROW).Value = CMBLOTNO.Text.Trim
            GRIDLOT.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDLOT.Item(GDESIGNNO.Index, TEMPROW).Value = CMBDESIGNNO.Text.Trim
            GRIDLOT.Item(GTOTALMTRS.Index, TEMPROW).Value = Format(Val(TXTTOTALMTRS.Text.Trim), "0")
            GRIDLOT.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDLOT.Item(GURGENT.Index, TEMPROW).Value = CHKURGENT.Checked
            GRIDLOT.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0")
            GRIDLOT.Item(GGRNNO.Index, TEMPROW).Value = Val(TXTGRNNO.Text.Trim)
            GRIDLOT.Item(GGRNTYPE.Index, TEMPROW).Value = TXTGRNTYPE.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        GETSRNO(GRIDLOT)
        TOTAL()
        GRIDLOT.FirstDisplayedScrollingRowIndex = GRIDLOT.RowCount - 1

        CMBITEMNAME.Text = ""
        CMBDESIGNNO.Text = ""
        CMBCOLOR.Text = ""
        TXTTOTALMTRS.Clear()
        CHKURGENT.CheckState = CheckState.Unchecked
        TXTMTRS.Clear()
        TXTGRNNO.Clear()
        TXTGRNTYPE.Clear()
        TXTBARCODE.Clear()
        TXTSRNO.Text = GRIDLOT.RowCount + 1
        CMBLOTNO.Focus()

    End Sub

    Private Sub GRIDLOT_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDLOT.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Dim IntResult As Integer
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                For Each ROW As DataGridViewRow In GRIDLOT.Rows
                    If Val(ROW.Cells(GRECDMTRS.Index).Value) > 0 Then
                        MsgBox("Unable to Delete Entry Locked", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                If MsgBox("Delete Program?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(PROGRAMNO)
                alParaval.Add(YearId)

                Dim OBJPROGRAM As New ClsProgramMaster()
                OBJPROGRAM.alParaval = alParaval
                IntResult = OBJPROGRAM.DELETE()
                MsgBox("Program Deleted")
                EDIT = False
                clear()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDLOT.CurrentRow.Index >= 0 And GRIDLOT.Item(GITEMNAME.Index, GRIDLOT.CurrentRow.Index).Value <> Nothing Then

                If Val(GRIDLOT.Item(GRECDMTRS.Index, GRIDLOT.CurrentRow.Index).Value) > 0 Then
                    MsgBox("Unable to Modify Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDLOT.Item(GSRNO.Index, GRIDLOT.CurrentRow.Index).Value)
                CMBLOTNO.Text = GRIDLOT.Item(GLOTNO.Index, GRIDLOT.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDLOT.Item(GITEMNAME.Index, GRIDLOT.CurrentRow.Index).Value
                CMBDESIGNNO.Text = GRIDLOT.Item(GDESIGNNO.Index, GRIDLOT.CurrentRow.Index).Value
                TXTTOTALMTRS.Text = Val(GRIDLOT.Item(GTOTALMTRS.Index, GRIDLOT.CurrentRow.Index).Value)
                CMBCOLOR.Text = GRIDLOT.Item(GCOLOR.Index, GRIDLOT.CurrentRow.Index).Value
                CHKURGENT.CheckState = Convert.ToBoolean(GRIDLOT.Item(GURGENT.Index, GRIDLOT.CurrentRow.Index).Value)
                TXTMTRS.Text = Val(GRIDLOT.Item(GMTRS.Index, GRIDLOT.CurrentRow.Index).Value)
                TXTGRNNO.Text = Val(GRIDLOT.Item(GGRNNO.Index, GRIDLOT.CurrentRow.Index).Value)
                TXTGRNTYPE.Text = GRIDLOT.Item(GGRNTYPE.Index, GRIDLOT.CurrentRow.Index).Value

                TEMPROW = GRIDLOT.CurrentRow.Index
                CMBLOTNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDLOT.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDLOT.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Val(GRIDLOT.Item(GRECDMTRS.Index, GRIDLOT.CurrentRow.Index).Value) > 0 Then
                    MsgBox("Unable to Delete Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                'end of block
                GRIDLOT.Rows.RemoveAt(GRIDLOT.CurrentRow.Index)
                GETSRNO(GRIDLOT)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            FILLCOLOR(CMBCOLOR, CMBDESIGNNO.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, CMBDESIGNNO.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            CMBLOTNO.Items.Clear()
            If CMBNAME.Text.Trim <> "" Then
                ''FILLLOTNO
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" CHECKINGMASTER.CHECK_LOTNO AS LOTNO ", "", " CHECKINGMASTER INNER JOIN LEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = LEDGERS.Acc_id INNER JOIN GRN ON GRN.GRN_NO = CHECKINGMASTER.CHECK_GRNNO AND GRN.GRN_TYPE = CHECKINGMASTER.CHECK_TYPE AND GRN.GRN_YEARID = CHECKINGMASTER.CHECK_YEARID ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ISNULL(GRN.GRN_PROGRAMDONE,0) = 0 AND GRN.GRN_PLOTNO <> '' AND GRN.GRN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        CMBLOTNO.Items.Add(DTROW("LOTNO"))
                    Next
                    CMBNAME.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        Try
            If CMBLOTNO.Text.Trim <> "" And CMBNAME.Text.Trim <> "" Then
                'GET LOT DETAILS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" CHECKINGMASTER.CHECK_BALPCS AS LOTPCS, CHECKINGMASTER.CHECK_BALMTRS AS LOTMTRS, ITEMMASTER.ITEM_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, CHECKINGMASTER.CHECK_GRNNO AS GRNNO, CHECKINGMASTER.CHECK_TYPE AS GRNTYPE  ", "", " CHECKINGMASTER INNER JOIN ITEMMASTER ON CHECKINGMASTER.CHECK_ITEMID = ITEMMASTER.ITEM_id INNER JOIN LEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON CHECK_DESIGNID = DESIGN_ID ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'  AND CHECK_LOTNO = '" & CMBLOTNO.Text.Trim & "' AND CHECK_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If LOTSTATUSONMTRS = True Then TXTTOTALMTRS.Text = Val(DT.Rows(0).Item("LOTMTRS")) Else TXTTOTALMTRS.Text = Val(DT.Rows(0).Item("LOTPCS"))
                    If CMBITEMNAME.Text = "" Then CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    If CMBDESIGNNO.Text.Trim = "" Then CMBDESIGNNO.Text = DT.Rows(0).Item("DESIGNNO")
                    TXTGRNNO.Text = Val(DT.Rows(0).Item("GRNNO"))
                    TXTGRNTYPE.Text = DT.Rows(0).Item("GRNTYPE")


                    'FETCH PROCESS NAMES FROM ITEMMASTER_PROCESS
                    DT = OBJCMN.search("ISNULL(PROCESS_NAME,'') AS PROCESSNAME ", "", " ITEMMASTER_PROCESS INNER JOIN ITEMMASTER ON ITEMMASTER.ITEM_ID = ITEMMASTER_PROCESS.ITEM_ID INNER JOIN PROCESSMASTER ON ITEMMASTER_PROCESS.ITEM_PROCESSID = PROCESS_ID ", " AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTPROCESSNAME.Clear()
                    For Each DTROW As DataRow In DT.Rows
                        TXTPROCESSNAME.Text = TXTPROCESSNAME.Text & DTROW("PROCESSNAME") & vbCrLf
                    Next


                Else
                    MsgBox("Invalid Lot No", MsgBoxStyle.Critical)
                    e.Cancel = True
                    Exit Sub
                End If
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

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDLOT.RowCount = 0
            PROGRAMNO = Val(TXTPROGRAMNO.Text) - 1
            If PROGRAMNO > 0 Then
                EDIT = True
                PROGRAMMASTER_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            PROGRAMNO = Val(TXTPROGRAMNO.Text) + 1
            GETMAXNO()
            clear()
            If Val(TXTPROGRAMNO.Text) - 1 >= PROGRAMNO Then
                EDIT = True
                PROGRAMMASTER_Load(sender, e)
            Else
                clear()
                EDIT = False
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

            Dim OBJPROGRAM As New ProgramDetails
            OBJPROGRAM.MdiParent = MDIMain
            OBJPROGRAM.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub PRINTTOOLSTRIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOLSTRIP.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_Validated(sender As Object, e As EventArgs) Handles TXTMTRS.Validated
        Try
            If CMBLOTNO.Text.Trim <> "" And Val(TXTTOTALMTRS.Text) > 0 And CMBITEMNAME.Text.Trim <> "" And CMBCOLOR.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARDRECDATE_Validating(sender As Object, e As CancelEventArgs) Handles CARDRECDATE.Validating
        Try
            If CARDRECDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CARDRECDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then
                    If txtremarks.Text = "" Then txtremarks.Text = OBJREMARKS.TEMPNAME Else txtremarks.Text = txtremarks.Text & vbCrLf & OBJREMARKS.TEMPNAME
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CARDISSUEDATE_Validating(sender As Object, e As CancelEventArgs) Handles CARDISSUEDATE.Validating
        Try
            If CARDISSUEDATE.Text.Trim <> "__/__/____" Then
                Dim temp1 As DateTime
                If Not DateTime.TryParse(CARDISSUEDATE.Text, temp1) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class