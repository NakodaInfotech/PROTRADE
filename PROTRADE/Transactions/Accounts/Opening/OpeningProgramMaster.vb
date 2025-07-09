
Imports System.ComponentModel
Imports System.IO
Imports BL

Public Class OpeningProgramMaster

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

        TXTSRNO.Text = 1
        CMBLOTNO.Items.Clear()
        CMBLOTNO.Text = ""
        CMBLOTNO.Enabled = True
        CMBITEMNAME.Text = ""
        CMBDESIGNNO.Text = ""
        TXTTOTALPCS.Clear()
        TXTGRNNO.Clear()
        TXTGRNTYPE.Clear()
        CMBCOLOR.Text = ""
        TXTPCS.Clear()
        GRIDLOT.RowCount = 0
        LBLTOTALPCS.Text = 0
        TXTBARCODE.Clear()
        CHKURGENT.CheckState = CheckState.Unchecked

        txtremarks.Clear()

        GRIDDOUBLECLICK = False
        GETMAXNO()

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALPCS.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDLOT.Rows
                LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).Value), "0.00")
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

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If ClientName <> "AVIS" And CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Select Name ")
                bln = False
            End If

            If ClientName = "AVIS" Then
                If CARDRECDATE.Text = "__/__/____" And CMBNAME.Text.Trim <> "" Then
                    EP.SetError(CMBNAME, " Please Enter Card Rec Date First")
                    bln = False
                End If
            End If

            If Val(LBLTOTALPCS.Text.Trim) = 0 Then
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
            alParaval.Add(Val(LBLTOTALPCS.Text.Trim))
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

            For Each row As Windows.Forms.DataGridViewRow In GRIDLOT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value
                        TOTALPCS = Val(row.Cells(GTOTALPCS.Index).Value)
                        COLOR = row.Cells(GCOLOR.Index).Value
                        URGENT = row.Cells(GURGENT.Index).Value
                        PCS = Val(row.Cells(GPCS.Index).Value)
                        PROGISSDATE = row.Cells(GPROGISSDATE.Index).Value
                        STATUS = row.Cells(GSTATUS.Index).Value
                        PRODCUTTING = row.Cells(GCUTRECDDATE.Index).Value
                        FINISHCUTTING = row.Cells(GFINISHCUTTING.Index).Value
                        INWARDDATE = row.Cells(GINWARDDATE.Index).Value
                        GRNNO = Val(row.Cells(GGRNNO.Index).Value)
                        GRNTYPE = row.Cells(GGRNTYPE.Index).Value
                        RECDPCS = Val(row.Cells(GRECDPCS.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value
                        TOTALPCS = TOTALPCS & "|" & Val(row.Cells(GTOTALPCS.Index).Value)
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        URGENT = URGENT & "|" & row.Cells(GURGENT.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        PROGISSDATE = PROGISSDATE & "|" & row.Cells(GPROGISSDATE.Index).Value
                        STATUS = STATUS & "|" & row.Cells(GSTATUS.Index).Value
                        PRODCUTTING = PRODCUTTING & "|" & row.Cells(GCUTRECDDATE.Index).Value
                        FINISHCUTTING = FINISHCUTTING & "|" & row.Cells(GFINISHCUTTING.Index).Value
                        INWARDDATE = INWARDDATE & "|" & row.Cells(GINWARDDATE.Index).Value
                        GRNNO = GRNNO & "|" & Val(row.Cells(GGRNNO.Index).Value)
                        GRNTYPE = GRNTYPE & "|" & row.Cells(GGRNTYPE.Index).Value
                        RECDPCS = RECDPCS & "|" & Val(row.Cells(GRECDPCS.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
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


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim OBJPROGRAM As New ClsOpeningProgramMaster()
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

    Private Sub OpeningProgramMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
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

    Private Sub OpeningProgramMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Dim dttable As DataTable = OBJCMN.search(" OPENINGPROGRAMMASTER.OPPROGRAM_NO AS PROGRAMNO, OPENINGPROGRAMMASTER.OPPROGRAM_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(OPENINGPROGRAMMASTER.OPPROGRAM_CARDRECDATE,'') AS CARDRECDATE, OPENINGPROGRAMMASTER.OPPROGRAM_LBLTOTALPCS AS TOTALPCS, OPENINGPROGRAMMASTER.OPPROGRAM_REMARKS AS REMARKS, OPENINGPROGRAMMASTER.OPPROGRAM_DONE AS DONE, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRIDSRNO AS GRIDSRNO, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_LOTNO AS LOTNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_TOTALPCS AS GRIDTOTALPCS, COLORMASTER.COLOR_name AS COLOR, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_URGENT,0) AS URGENT, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PCS AS PCS, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PROGISSDATE,'') AS PROGISSDATE, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_STATUS,'') AS STATUS, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_PRODCUTTING,'') AS PRODCUTTING, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_FINISHCUTTING,'') AS FINISHCUTTING, ISNULL(OPENINGPROGRAMMASTER_DESC.OPPROGRAM_INWARDDATE,'') AS INWARDDATE, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRNNO AS GRNNO, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRNTYPE AS GRNTYPE, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_RECDPCS as RECDPCS, OPENINGPROGRAMMASTER_DESC.OPPROGRAM_BARCODE as BARCODE ", "", " OPENINGPROGRAMMASTER INNER JOIN OPENINGPROGRAMMASTER_DESC ON OPENINGPROGRAMMASTER.OPPROGRAM_NO = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_NO AND OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = OPENINGPROGRAMMASTER_DESC.OPPROGRAM_YEARID LEFT OUTER JOIN LEDGERS ON OPENINGPROGRAMMASTER.OPPROGRAM_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_ITEMID = ITEMMASTER.item_id INNER JOIN COLORMASTER ON OPENINGPROGRAMMASTER_DESC.OPPROGRAM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON OPPROGRAM_DESIGNID = DESIGN_ID", " AND OPENINGPROGRAMMASTER.OPPROGRAM_NO = " & PROGRAMNO & " AND OPENINGPROGRAMMASTER.OPPROGRAM_YEARID = " & YearId & " ORDER BY OPENINGPROGRAMMASTER_DESC.OPPROGRAM_GRIDSRNO")
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTPROGRAMNO.Text = Val(dr("PROGRAMNO"))
                        PROGRAMDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CARDRECDATE.Text = dr("CARDRECDATE")

                        CMBNAME.Text = dr("NAME")
                        If CMBNAME.Text.Trim <> "" Then CMBNAME.Enabled = False
                        txtremarks.Text = dr("REMARKS")

                        GRIDLOT.Rows.Add(Val(dr("GRIDSRNO")), dr("LOTNO"), dr("ITEMNAME"), dr("DESIGNNO"), Val(dr("GRIDTOTALPCS")), dr("COLOR"), dr("URGENT"), Val(dr("PCS")), dr("PROGISSDATE"), dr("STATUS"), dr("PRODCUTTING"), dr("FINISHCUTTING"), dr("INWARDDATE"), Val(dr("GRNNO")), dr("GRNTYPE"), Val(dr("RECDPCS")), dr("BARCODE"))

                        If Val(dr("RECDPCS")) > 0 Then GRIDLOT.Rows(GRIDLOT.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow

                    Next
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

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then

            If EDIT = True Then
                'GET LAST BARCODE SRNO
                Dim LSRNO As Integer = 0
                Dim RSRNO As Integer = 0
                Dim SNO As Integer = 0
                LSRNO = InStr(GRIDLOT.Rows(GRIDLOT.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                RSRNO = InStr(LSRNO + 1, GRIDLOT.Rows(GRIDLOT.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                SNO = GRIDLOT.Rows(GRIDLOT.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                TXTBARCODE.Text = "PG-" & Val(TXTPROGRAMNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
            Else
                TXTBARCODE.Text = "PG-" & Val(TXTPROGRAMNO.Text.Trim) & "/" & GRIDLOT.RowCount + 1 & "/" & YearId
            End If

            GRIDLOT.Rows.Add(Val(TXTSRNO.Text.Trim), CMBLOTNO.Text.Trim, CMBITEMNAME.Text.Trim, CMBDESIGNNO.Text.Trim, Val(TXTTOTALPCS.Text.Trim), CMBCOLOR.Text.Trim, CHKURGENT.Checked, Val(TXTPCS.Text.Trim), "", "", "", "", "", Val(TXTGRNNO.Text.Trim), TXTGRNTYPE.Text.Trim, 0, TXTBARCODE.Text.Trim)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDLOT.Item(GLOTNO.Index, TEMPROW).Value = CMBLOTNO.Text.Trim
            GRIDLOT.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDLOT.Item(GDESIGNNO.Index, TEMPROW).Value = CMBDESIGNNO.Text.Trim
            GRIDLOT.Item(GTOTALPCS.Index, TEMPROW).Value = Format(Val(TXTTOTALPCS.Text.Trim), "0")
            GRIDLOT.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDLOT.Item(GURGENT.Index, TEMPROW).Value = CHKURGENT.Checked
            GRIDLOT.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0")
            GRIDLOT.Item(GGRNNO.Index, TEMPROW).Value = Val(TXTGRNNO.Text.Trim)
            GRIDLOT.Item(GGRNTYPE.Index, TEMPROW).Value = TXTGRNTYPE.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        GRIDLOT.FirstDisplayedScrollingRowIndex = GRIDLOT.RowCount - 1

        If ClientName <> "AVIS" Then
            CMBITEMNAME.Text = ""
            CMBDESIGNNO.Text = ""
        End If
        CMBCOLOR.Text = ""
        TXTTOTALPCS.Clear()
        CHKURGENT.CheckState = CheckState.Unchecked
        TXTPCS.Clear()
        TXTGRNNO.Clear()
        TXTGRNTYPE.Clear()
        TXTBARCODE.Clear()
        TXTSRNO.Text = GRIDLOT.RowCount + 1
        CMBLOTNO.Focus()

    End Sub

    Private Sub GRIDLOT_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDLOT.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress
        If ClientName = "RUCHITA" Or ClientName = "AVIS" Then numdotkeypress(e, sender, Me) Else numkeypress(e, sender, Me)
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
                    If Val(ROW.Cells(GRECDPCS.Index).Value) > 0 Then
                        MsgBox("Unable to Delete Entry Locked", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                If MsgBox("Delete Program?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(PROGRAMNO)
                alParaval.Add(YearId)

                Dim OBJPROGRAM As New ClsOpeningProgramMaster()
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

                If Val(GRIDLOT.Item(GRECDPCS.Index, GRIDLOT.CurrentRow.Index).Value) > 0 Then
                    MsgBox("Unable to Modify Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDLOT.Item(GSRNO.Index, GRIDLOT.CurrentRow.Index).Value)
                CMBLOTNO.Text = GRIDLOT.Item(GLOTNO.Index, GRIDLOT.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDLOT.Item(GITEMNAME.Index, GRIDLOT.CurrentRow.Index).Value
                CMBDESIGNNO.Text = GRIDLOT.Item(GDESIGNNO.Index, GRIDLOT.CurrentRow.Index).Value
                TXTTOTALPCS.Text = Val(GRIDLOT.Item(GTOTALPCS.Index, GRIDLOT.CurrentRow.Index).Value)
                CMBCOLOR.Text = GRIDLOT.Item(GCOLOR.Index, GRIDLOT.CurrentRow.Index).Value
                CHKURGENT.CheckState = Convert.ToBoolean(GRIDLOT.Item(GURGENT.Index, GRIDLOT.CurrentRow.Index).Value)
                TXTPCS.Text = Val(GRIDLOT.Item(GPCS.Index, GRIDLOT.CurrentRow.Index).Value)
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

                If Val(GRIDLOT.Item(GRECDPCS.Index, GRIDLOT.CurrentRow.Index).Value) > 0 Then
                    MsgBox("Unable to Delete Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                'end of block
                GRIDLOT.Rows.RemoveAt(GRIDLOT.CurrentRow.Index)
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
                    If LOTSTATUSONMTRS = True Then TXTTOTALPCS.Text = Val(DT.Rows(0).Item("LOTMTRS")) Else TXTTOTALPCS.Text = Val(DT.Rows(0).Item("LOTPCS"))
                    If CMBITEMNAME.Text = "" Then CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    If CMBDESIGNNO.Text.Trim = "" Then CMBDESIGNNO.Text = DT.Rows(0).Item("DESIGNNO")
                    TXTGRNNO.Text = Val(DT.Rows(0).Item("GRNNO"))
                    TXTGRNTYPE.Text = DT.Rows(0).Item("GRNTYPE")
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
                OpeningProgramMaster_Load(sender, e)
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
                OpeningProgramMaster_Load(sender, e)
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

            Dim OBJPROGRAM As New OpeningProgramDetails
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
            If EDIT = True Then
                PRINTREPORT()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_Validated(sender As Object, e As EventArgs) Handles TXTPCS.Validated
        Try
            If ClientName = "AVIS" Then
                If CMBNAME.Text.Trim = "" And CMBLOTNO.Text.Trim <> "" Then CMBLOTNO.Text = ""
                If CMBITEMNAME.Text.Trim <> "" And CMBDESIGNNO.Text.Trim <> "" And CMBCOLOR.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then fillgrid()
            Else
                If Val(CMBLOTNO.Text.Trim) > 0 And Val(TXTTOTALPCS.Text) > 0 And CMBITEMNAME.Text.Trim <> "" And CMBCOLOR.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningProgramMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "RUCHITA" Or ClientName = "AVIS" Then
                GPCS.HeaderText = "Mtrs"
                GTOTALPCS.HeaderText = "Mtrs"
            End If

            If ClientName = "AVIS" Then
                LBLSRNO.Text = "Card No"
                CMBNAME.BackColor = Color.White
                CMBLOTNO.BackColor = Color.White
                CMBDESIGNNO.BackColor = Color.LemonChiffon
                CMBITEMNAME.Enabled = True
                CMBDESIGNNO.Enabled = True
                GPROGISSDATE.Visible = True
                GSTATUS.Visible = True
                GCUTRECDDATE.Visible = True
                GFINISHCUTTING.Visible = True
                GINWARDDATE.Visible = True
            End If
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

    Private Sub PROGRAMDATE_Validated(sender As Object, e As EventArgs) Handles PROGRAMDATE.Validated
        If ClientName = "AVIS" Then CMBDESIGNNO.Focus()
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

    Private Sub CMBDESIGNNO_Validated(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Validated
        Try
            'GET ITEMNAME AUTO
            If ClientName = "AVIS" And CMBDESIGNNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID", " AND DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
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

End Class