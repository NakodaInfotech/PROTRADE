
Imports BL
Imports System.IO

Public Class InHouseChecking

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPCHECKINGNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            EP.Clear()
            CMDSELECTLOT.Enabled = True

            tstxtbillno.Clear()
            TXTFROM.Clear()
            TXTTO.Clear()
            GRIDCHECKING.RowCount = 0

            TXTCHECKINGNO.Clear()
            CHECKINGDATE.Text = Now.Date
            TXTNAME.Clear()
            TXTGODOWN.Clear()
            TXTLOTNO.Clear()
            TXTMATRECNO.Clear()
            TXTTYPE.Clear()
            TXTCHECKEDBY.Clear()

            TXTTOTALGREYMTRS.Text = 0.0
            TXTTOTALRECDMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            LBLSHORTAGE.Text = "Shortage"
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTTOTALPCS.Text = 0
            txtremarks.Clear()

            lbllocked.Visible = False
            PBlock.Visible = False


            CMDSELECTLOT.Enabled = True
            GRIDDOUBLECLICK = False
            getmaxno()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            TXTTOTALGREYMTRS.Text = 0.0
            TXTTOTALRECDMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTSHRINKAGEPER.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALGREYMTRS.Text = Format(Val(TXTTOTALGREYMTRS.Text) + Val(ROW.Cells(GGREYMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALRECDMTRS.Text = Format(Val(TXTTOTALRECDMTRS.Text) + Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALCHECKEDMTRS.Text = Format(Val(TXTTOTALCHECKEDMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALDIFF.Text = Format(Val(TXTTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")
                    TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                End If
            Next
            TXTTOTALPCS.Text = Val(GRIDCHECKING.RowCount)
            If Val(TXTTOTALDIFF.Text.Trim) < 0 Then LBLSHORTAGE.Text = "Longation" Else LBLSHORTAGE.Text = "Shortage"
            TXTSHRINKAGEPER.Text = Format(((Val(TXTTOTALGREYMTRS.Text.Trim) - Val(TXTTOTALCHECKEDMTRS.Text.Trim)) / Val(TXTTOTALGREYMTRS.Text.Trim)) * 100, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            EDIT = False
            CHECKINGDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKINGDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHECKINGDATE.GotFocus
        CHECKINGDATE.SelectAll()
    End Sub

    Private Sub CHECKINGDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINGDATE.Validating
        Try
            If CHECKINGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHECKINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(CHECK_NO),0) + 1 ", " INHOUSECHECKING", " AND CHECK_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTCHECKINGNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If TXTNAME.Text.Trim.Length = 0 Then
                EP.SetError(TXTNAME, " Please Select Data ")
                bln = False
            End If

            'If TXTLOTNO.Text.Trim.Length = 0 Then
            '    EP.SetError(TXTLOTNO, "Please Select Lot No")
            '    bln = False
            'End If

            If TXTCHECKEDBY.Text.Trim.Length = 0 Then
                EP.SetError(TXTCHECKEDBY, "Please Enter Checked By")
                bln = False
            End If


            'WE DONT HAVE TO LOCK FULL ENTRY, WE WILL LOCK ONLY OUTMTRS ENTRY
            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
            '    bln = False
            'End If

            If GRIDCHECKING.RowCount = 0 Then
                EP.SetError(TXTLOTNO, "Fill Item Details")
                bln = False
            End If


            For Each row As DataGridViewRow In GRIDCHECKING.Rows
                If Val(row.Cells(GMTRS.Index).Value) = 0 And ClientName <> "PARAS" Then
                    EP.SetError(TXTLOTNO, "Checking Mtrs Cannot be kept Blank")
                    bln = False
                End If
            Next

            If CHECKINGDATE.Text = "__/__/____" Then
                EP.SetError(CHECKINGDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(CHECKINGDATE.Text) Then
                    EP.SetError(CHECKINGDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If


            'check WHETHER SAME LOT NO AND NAME IS SAVED BEFORE OR NOT
            If EDIT = False And TXTLOTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("CHECK_NO AS CHECKNO", "", " INHOUSECHECKING INNER JOIN LEDGERS ON CHECK_LEDGERID = LEDGERS.ACC_ID ", " AND LEDGERS.ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' AND CHECK_LOTNO = '" & TXTLOTNO.Text.Trim & "'  AND CHECK_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If MsgBox("Lot No already saved before, wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        EP.SetError(TXTNAME, "Lot No already saved before")
                        bln = False
                    End If
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Format(Convert.ToDateTime(CHECKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTGODOWN.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(Val(TXTMATRECNO.Text.Trim))
            alParaval.Add(TXTTYPE.Text.Trim)
            alParaval.Add(TXTCHECKEDBY.Text.Trim)


            alParaval.Add(Val(TXTTOTALGREYMTRS.Text))
            alParaval.Add(Val(TXTTOTALRECDMTRS.Text))
            alParaval.Add(Val(TXTTOTALCHECKEDMTRS.Text.Trim))
            alParaval.Add(Val(TXTSHRINKAGEPER.Text.Trim))
            alParaval.Add(Val(TXTTOTALDIFF.Text))
            alParaval.Add(Val(TXTTOTALWT.Text))
            alParaval.Add(Val(TXTTOTALPCS.Text))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim GREYMTRS As String = ""
            Dim RECDMTRS As String = ""
            Dim CHECKEDMTRS As String = ""
            Dim INBARCODE As String = ""
            Dim GRIDREMARKS As String = ""
            Dim PIECETYPE As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim WT As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BARCODE As String = ""
            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDCHECKING.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        GREYMTRS = Val(row.Cells(GGREYMTRS.Index).Value)
                        RECDMTRS = Val(row.Cells(GRECDMTRS.Index).Value)
                        CHECKEDMTRS = Val(row.Cells(GMTRS.Index).Value)
                        INBARCODE = row.Cells(GINBARCODE.Index).Value.ToString
                        If row.Cells(Gdesc.Index).Value <> Nothing Then GRIDREMARKS = row.Cells(Gdesc.Index).Value.ToString Else GRIDREMARKS = ""
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        DIFF = Val(row.Cells(GDIFF.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value
                        WT = Val(row.Cells(GWT.Index).Value)
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        RACK = row.Cells(GRACK.Index).Value.ToString
                        SHELF = row.Cells(GSHELF.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        GREYMTRS = GREYMTRS & "|" & Val(row.Cells(GGREYMTRS.Index).Value)
                        RECDMTRS = RECDMTRS & "|" & Val(row.Cells(GRECDMTRS.Index).Value)
                        CHECKEDMTRS = CHECKEDMTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        INBARCODE = INBARCODE & "|" & row.Cells(GINBARCODE.Index).Value.ToString
                        If row.Cells(Gdesc.Index).Value <> Nothing Then GRIDREMARKS = GRIDREMARKS & "|" & row.Cells(Gdesc.Index).Value.ToString Else GRIDREMARKS = GRIDREMARKS & "|" & ""
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        DIFF = DIFF & "|" & Val(row.Cells(GDIFF.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        RACK = RACK & "|" & row.Cells(GRACK.Index).Value.ToString
                        SHELF = SHELF & "|" & row.Cells(GSHELF.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
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
            alParaval.Add(GREYMTRS)
            alParaval.Add(RECDMTRS)
            alParaval.Add(CHECKEDMTRS)
            alParaval.Add(INBARCODE)
            alParaval.Add(GRIDREMARKS)
            alParaval.Add(PIECETYPE)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(WT)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BARCODE)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)


            Dim OBJCHECKING As New ClsInHouseChecking()
            OBJCHECKING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJCHECKING.SAVE()
                TEMPCHECKINGNO = DT.Rows(0).Item(0)
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCHECKINGNO)
                Dim IntResult As Integer = OBJCHECKING.UPDATE()
                MsgBox("Details Updated")
            End If
            PRINTREPORT()

            EDIT = False
            clear()
            CHECKINGDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim WHOLESALEBARCODE As Integer = 0
                If ClientName = "CC" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)

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

                Dim NARR As String = ""
                Dim OBJCHECKING As New ClsInHouseChecking()
                Dim dttable As DataTable = OBJCHECKING.SELECTCHECKING(TEMPCHECKINGNO, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        'TO PRINT BARCODE FROM SELECTED SRNO
                        If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                            If Val(dr("GRIDSRNO")) < Val(TXTFROM.Text.Trim) Or Val(dr("GRIDSRNO")) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                        End If
                        If ClientName = "YASHVI" Then NARR = "" Else NARR = dr("NARR")
                        BARCODEPRINTING(dr("BARCODE"), dr("PIECETYPE"), dr("ITEMNAME"), dr("QUALITY"), dr("DESIGN"), dr("COLOR"), dr("UNIT"), dr("LOTNO"), dr("NARR"), NARR, Val(dr("CHECKEDMTRS")), 1, 0, dr("RACK"), TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InHouseChecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'for Delete
            GRIDCHECKING.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
            tstxtbillno.Focus()
        ElseIf e.keycode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub InHouseChecking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
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

                Dim OBJCHECKING As New ClsInHouseChecking()
                Dim dttable As DataTable = OBJCHECKING.SELECTCHECKING(TEMPCHECKINGNO, YearId)
                If dttable.Rows.Count > 0 Then
                    CMDSELECTLOT.Enabled = False

                    For Each dr As DataRow In dttable.Rows
                        TXTCHECKINGNO.Text = TEMPCHECKINGNO
                        CHECKINGDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        TXTNAME.Text = Convert.ToString(dr("NAME").ToString)
                        TXTGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTLOTNO.Text = Val(dr("LOTNO"))
                        TXTMATRECNO.Text = Val(dr("MATRECNO"))
                        TXTTYPE.Text = dr("TYPE")
                        TXTCHECKEDBY.Text = Convert.ToString(dr("CHECKEDBY").ToString)

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        GRIDCHECKING.Rows.Add(dr("GRIDSRNO").ToString, Format(Val(dr("GREYMTRS")), "0.00"), Format(Val(dr("RECDMTRS")), "0.00"), Format(Val(dr("CHECKEDMTRS")), "0.00"), dr("INBARCODE"), dr("NARR").ToString, dr("PIECETYPE").ToString, Format(Val(dr("DIFF")), "0.00"), dr("UNIT").ToString, Format(Val(dr("WT")), "0.00"), dr("ITEMNAME"), dr("QUALITY"), dr("DESIGN"), dr("COLOR").ToString, dr("BARCODE"), dr("RACK"), dr("SHELF"), dr("DONE"), Val(dr("OUTPCS")), Val(dr("OUTMTRS")))

                        If Val(dr("OUTMTRS")) > 0 Then
                            GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).ReadOnly = True
                        End If

                    Next
                    total()
                    GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
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
            'FILL PIECETYPE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(PIECETYPE_NAME,'') AS PIECETYPE", "", " PIECETYPEMASTER ", " AND PIECETYPE_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GPIECETYPE.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GPIECETYPE.Items.Add(ROW("PIECETYPE"))
                Next
            End If

            DT = OBJCMN.search("ISNULL(UNIT_ABBR,'') AS UNIT", "", " UNITMASTER ", " AND UNIT_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GUNIT.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GUNIT.Items.Add(ROW("UNIT"))
                Next
            End If

            DT = OBJCMN.search("ISNULL(COLOR_NAME,'') AS COLOR", "", " COLORMASTER ", " AND COLOR_YEARID =" & YearId)
            If DT.Rows.Count > 0 Then
                GCOLOR.Items.Clear()
                For Each ROW As DataRow In DT.Rows
                    GCOLOR.Items.Add(ROW("COLOR"))
                Next
            End If

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
            Dim OBJCHECKING As New InHouseCheckingDetails
            OBJCHECKING.MdiParent = MDIMain
            OBJCHECKING.Show()
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

    Private Sub CMDSELECTLOT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSELECTLOT.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSELECTLOT As New SelectLot
            Dim DT As DataTable = OBJSELECTLOT.DT
            OBJSELECTLOT.ShowDialog()

            If DT.Rows.Count > 0 Then

                TXTNAME.Text = DT.Rows(0).Item("NAME")
                TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                TXTMATRECNO.Text = Val(DT.Rows(0).Item("MATRECNO"))
                If DT.Rows(0).Item("LOTNO") <> "0" Then TXTLOTNO.Text = DT.Rows(0).Item("LOTNO")
                TXTTYPE.Text = DT.Rows(0).Item("TYPE")

                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As New DataTable
                If TXTTYPE.Text = "MATREC" Then
                    DTTABLE = OBJCMN.search(" MATERIALRECEIPT_DESC.MATREC_MTRS AS GREYMTRS, MATERIALRECEIPT_DESC.MATREC_RECDMTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR , MATREC_GRIDSRNO AS FROMSRNO, ISNULL(UNIT_ABBR,'') AS UNIT, ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO,'') AS LOTNO, MATERIALRECEIPT_DESC.MATREC_BARCODE AS INBARCODE", "", " MATERIALRECEIPT_DESC INNER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON MATERIALRECEIPT_DESC.MATREC_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON MATERIALRECEIPT_DESC.MATREC_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.UNIT_id", " AND MATREC_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND MATREC_YEARID = " & YearId)
                ElseIf TXTTYPE.Text = "JOBIN" Then
                    DTTABLE = OBJCMN.search("  JOBIN_DESC.JI_MTRS AS GREYMTRS, JOBIN_DESC.JI_MTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, JOBIN_DESC.JI_GRIDSRNO AS FROMSRNO, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBIN.JI_LOTNO, '') AS LOTNO, JOBIN_DESC.JI_BARCODE AS INBARCODE", "", " JOBIN_DESC INNER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id INNER JOIN JOBIN ON JOBIN_DESC.JI_NO = JOBIN.JI_no AND JOBIN_DESC.JI_YEARID = JOBIN.JI_yearid LEFT OUTER JOIN COLORMASTER ON JOBIN_DESC.JI_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id ", " AND JOBIN.JI_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND JOBIN.JI_YEARID = " & YearId)
                Else
                    DTTABLE = OBJCMN.search(" GRN_DESC.GRN_MTRS AS GREYMTRS, GRN_DESC.GRN_MTRS AS RECDMTRS, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR , GRN_GRIDSRNO AS FROMSRNO, ISNULL(UNIT_ABBR,'') AS UNIT, '' AS LOTNO, GRN_DESC.GRN_BARCODE AS INBARCODE", "", " GRN_DESC INNER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GRN_DESC.GRN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_QTYUNITID = UNITMASTER.UNIT_id ", " AND GRN_GRIDTYPE = 'FANCY MATERIAL' AND GRN_NO = " & Val(DT.Rows(0).Item("MATRECNO")) & " AND GRN_YEARID = " & YearId)
                End If
                For Each ROW As DataRow In DTTABLE.Rows
                    Dim CHECKEDMTRS As Decimal = Val(ROW("RECDMTRS"))
                    If ClientName = "PARAS" Then CHECKEDMTRS = 0
                    If TXTLOTNO.Text.Trim = "" And ROW("LOTNO") <> "0" And ROW("LOTNO") <> "" Then TXTLOTNO.Text = ROW("LOTNO")
                    GRIDCHECKING.Rows.Add(0, Val(ROW("GREYMTRS")), Val(ROW("RECDMTRS")), Val(CHECKEDMTRS), ROW("INBARCODE"), "", "FRESH", 0, ROW("UNIT"), 0, ROW("ITEMNAME"), ROW("QUALITY"), ROW("DESIGN"), ROW("COLOR"), "", "", "", 0, 0, 0)
                Next
                CMDSELECTLOT.Enabled = False
                total()
                getsrno(GRIDCHECKING)
                CHECKINGDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDCHECKING.RowCount = 0
                TEMPCHECKINGNO = Val(tstxtbillno.Text)
                If TEMPCHECKINGNO > 0 Then
                    EDIT = True
                    InHouseChecking_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDCHECKING.RowCount = 0
LINE1:
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) - 1
            If TEMPCHECKINGNO > 0 Then
                EDIT = True
                InHouseChecking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDCHECKING.RowCount = 0 And TEMPCHECKINGNO > 1 Then
                TXTCHECKINGNO.Text = TEMPCHECKINGNO
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
            GRIDCHECKING.RowCount = 0
LINE1:
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTCHECKINGNO.Text.Trim
            clear()
            If Val(TXTCHECKINGNO.Text) - 1 >= TEMPCHECKINGNO Then
                EDIT = True
                InHouseChecking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDCHECKING.RowCount = 0 And TEMPCHECKINGNO < MAXNO Then
                TXTCHECKINGNO.Text = TEMPCHECKINGNO
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

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete, Checking Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Checking?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTCHECKINGNO.Text.Trim))
                alParaval.Add(TXTTYPE.Text.Trim)
                alParaval.Add(YearId)

                Dim ClsInHouseChecking As New ClsInHouseChecking()
                ClsInHouseChecking.alParaval = alParaval
                IntResult = ClsInHouseChecking.DELETE()
                MsgBox("Checking Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCHECKING_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCHECKING.CellValidating
        Try
            Dim colNum As Integer = GRIDCHECKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCHECKING.CurrentCell.Value = Nothing Then GRIDCHECKING.CurrentCell.Value = "0.00"
                        GRIDCHECKING.CurrentCell.Value = Format(Convert.ToDecimal(GRIDCHECKING.Item(colNum, e.RowIndex).Value), "0.00")
                        total()
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

    Private Sub GRIDCHECKING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHECKING.KeyDown
        Try
            If e.KeyCode = Keys.F12 And GRIDCHECKING.RowCount > 0 And EDIT = False Then
                If GRIDCHECKING.CurrentRow.Cells(GITEMNAME.Index).Value <> "" Then
                    GRIDCHECKING.Rows.Add(CloneWithValues(GRIDCHECKING.CurrentRow))
                    GRIDCHECKING.Item(GRECDMTRS.Index, GRIDCHECKING.RowCount - 1).Value = 0
                    getsrno(GRIDCHECKING)
                    total()
                End If
            ElseIf e.KeyCode = Keys.Delete And GRIDCHECKING.Item(GRECDMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value = 0 Then
                If GRIDCHECKING.Item(GOUTMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value > 0 Then
                    MsgBox("Unable To Delete, Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                GRIDCHECKING.Rows.RemoveAt(GRIDCHECKING.CurrentRow.Index)
                getsrno(GRIDCHECKING)
                total()
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

    Sub PRINTREPORT()
        Try
            If MsgBox("Print Checking Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJPRINT As New InHouseDesign
                OBJPRINT.MdiParent = MDIMain
                OBJPRINT.WHERECLAUSE = "{INHOUSECHECKING.CHECK_NO} = " & TEMPCHECKINGNO & " AND {INHOUSECHECKING.CHECK_YEARID} = " & YearId
                OBJPRINT.Show()
            End If

            PRINTBARCODE()
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT()
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub


End Class