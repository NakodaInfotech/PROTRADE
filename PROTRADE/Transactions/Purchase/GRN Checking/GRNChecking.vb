
Imports BL

Public Class GRNChecking

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPCHECKINGNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Public Shared selectGRNtable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public AUTOCHECKING As Boolean = False
    Public TEMPGRNNO As Integer = 0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        cmdselectGRN.Enabled = True

        tstxtbillno.Clear()

        TXTTOTALPARTYMTRS.Text = 0.0
        TXTTOTALCHECKEDMTRS.Text = 0.0
        TXTTOTALDIFF.Text = 0.0
        TXTTOTALWT.Text = 0.0

        TXTLOTNO.ReadOnly = True
        TXTLOTNO.BackColor = Color.Linen

        TXTCOPYLINES.Clear()
        txttslotno.Clear()
        TXTCHECKINGNO.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""
        txtadd.Clear()
        TXTSUPPNAME.Clear()
        CHECKINGDATE.Text = Now.Date
        CMBQUALITY.Text = ""

        TXTCOUNT.Clear()
        TXTWIDTH.Clear()

        TXTLOTNO.Text = 0.0
        GRNDATE.Value = Now.Date
        TXTTYPE.Clear()
        TXTGRNQTY.Text = 0.0
        TXTGRNMTRS.Clear()

        txtremarks.Clear()


        lbllocked.Visible = False
        PBlock.Visible = False

        TXTITEMNAME.Clear()
        TXTQUALITY.Clear()
        TXTREED.Clear()
        TXTPICK.Clear()
        TXTCOLOR.Clear()
        TXTDESIGN.Clear()


        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        txtgridremarks.Clear()
        TXTPARTYMTRS.Clear()
        TXTCHECKEDMTRS.Clear()
        CMBAPPOROVED.SelectedIndex = 0
        TXTDIFF.Text = 0.0
        TXTWT.Clear()

        GRIDCHECKING.RowCount = 0

        TXTRECPCS.Text = 0.0
        TXTRECMTRS.Text = 0.0
        TXTREJPCS.Text = 0.0
        TXTREJMTRS.Text = 0.0
        TXTBALPCS.Text = 0.0
        TXTBALMTRS.Text = 0.0
        txtshortage.Text = 0.0

        cmdselectGRN.Enabled = True
        GRIDDOUBLECLICK = False
        getmaxno()
        txtlrno.Clear()
        cmbtrans.Text = ""

        TXTTOTALPARTYMTRS.Text = 0.0
        TXTTOTALCHECKEDMTRS.Text = 0.0
        TXTTOTALDIFF.Text = 0.0
        TXTTOTALWT.Text = 0.0


        If GRIDCHECKING.RowCount > 0 Then
            txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            TXTTOTALPARTYMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0

            TXTRECPCS.Text = 0.0
            TXTRECMTRS.Text = 0.0
            TXTREJPCS.Text = 0.0
            TXTREJMTRS.Text = 0.0
            TXTBALPCS.Text = 0.0
            TXTBALMTRS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    TXTTOTALPARTYMTRS.Text = Format(Val(TXTTOTALPARTYMTRS.Text) + Val(ROW.Cells(GPARTYMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALCHECKEDMTRS.Text = Format(Val(TXTTOTALCHECKEDMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALDIFF.Text = Format(Val(TXTTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")

                    TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")

                    TXTRECPCS.Text = Format(Val(TXTRECPCS.Text.Trim) + 1, "0.00")
                    TXTRECMTRS.Text = Format(Val(TXTRECMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")

                    If ROW.Cells(GAPPROVED.Index).Value = "No" Then
                        TXTREJPCS.Text = Format(Val(TXTREJPCS.Text.Trim) + 1, "0.00")
                        TXTREJMTRS.Text = Format(Val(TXTREJMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    End If

                    If ROW.Cells(GAPPROVED.Index).Value = "No" Then ROW.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

            'FOR THESE CLIENTS CHECKING IS NOT IMPORTANT
            'SO WE NEED TO FETCH SAME DESTAILS FROM GRN IN CHECKING
            If FETCHGRNINCHECKING = True Then TXTRECPCS.Text = Val(TXTGRNQTY.Text.Trim)

            TXTBALPCS.Text = Format(Val(TXTRECPCS.Text.Trim) - Val(TXTREJPCS.Text.Trim), "0.00")
            TXTBALMTRS.Text = Format(Val(TXTRECMTRS.Text.Trim) - Val(TXTREJMTRS.Text.Trim), "0.00")
            txtshortage.Text = Format(Val(TXTTOTALPARTYMTRS.Text) - Val(TXTTOTALCHECKEDMTRS.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbname.Focus()
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
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CHECK_NO),0) + 1 ", " CHECKINGMASTER", " AND CHECK_cmpid=" & CmpId & " and CHECK_locationid=" & Locationid & " and CHECK_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCHECKINGNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            'If CMBQUALITY.Text.Trim.Length = 0 Then
            '    EP.SetError(CMBQUALITY, "Please Select Quality")
            '    bln = False
            'End If

            If TXTLOTNO.Text.Trim = "" Then
                EP.SetError(TXTLOTNO, "Please Enter Lot No")
                bln = False
            End If


            'If TXTLOTNO.ReadOnly = False And TXTLOTNO.Text.Trim <> "" Then
            '    If MsgBox("Wish to Update Lot No?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        EP.SetError(TXTLOTNO, "Please Update Lot No")
            '        bln = False
            '    End If
            '    Dim objcmn As New ClsCommon
            '    Dim DT As DataTable = objcmn.Execute_Any_String(" UPDATE GRN SET GRN.GRN_PLOTNO = '" & TXTLOTNO.Text.Trim & "' WHERE GRN.GRN_NO = " & Val(TXTGRNNO.Text.Trim) & " And GRN.GRN_TYPE = 'Job Work' AND GRN.GRN_YEARID = " & YearId, "", "")
            'End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
                bln = False
            End If

            
            If GRIDCHECKING.RowCount = 0 Then
                EP.SetError(TXTWT, "Fill Item Details")
                bln = False
            End If

            Dim wt, n As Double
            n = 0
            For Each row As DataGridViewRow In GRIDCHECKING.Rows
                If Val(row.Cells(GPARTYMTRS.Index).Value) = 0 Then
                    EP.SetError(TXTWT, "Party MTRS Cannot be kept Blank")
                    bln = False
                End If
                If Val(row.Cells(GMTRS.Index).Value) = 0 Then
                    EP.SetError(TXTWT, "MTRS Cannot be kept Blank")
                    bln = False
                End If
                If Convert.ToString(row.Cells(Gdesc.Index).Value) = Nothing Then
                    row.Cells(Gdesc.Index).Value = " "
                End If
                If Val(row.Cells(GWT.Index).Value) <> 0 And Convert.ToBoolean(row.Cells(GDONE.Index).Value) = False Then
                    wt = wt + Val(row.Cells(GWT.Index).Value)
                    n = n + 1
                End If
            Next
            If n > 0 And wt > 0 Then
                wt = Val(wt / n)
                For Each row As DataGridViewRow In GRIDCHECKING.Rows
                    If Val(row.Cells(GWT.Index).Value) = 0 And Convert.ToBoolean(row.Cells(GDONE.Index).Value) = False Then
                        row.Cells(GWT.Index).Value = wt
                    End If
                Next

            End If


            If CHECKINGDATE.Text = "__/__/____" Then
                EP.SetError(CHECKINGDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(CHECKINGDATE.Text) Then
                    EP.SetError(CHECKINGDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(GRNDATE.Text).Date > Convert.ToDateTime(CHECKINGDATE.Text).Date Then
                    EP.SetError(GRNDATE, "Checking Date cannot be before Receiveing Date")
                    bln = False
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
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(TXTSUPPNAME.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTGRNNO.Text.Trim)
            alParaval.Add(TXTGRNGRIDSRNO.Text.Trim)
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(TXTCOUNT.Text.Trim)
            alParaval.Add(TXTWIDTH.Text.Trim)
            alParaval.Add(CMBDYEINGTYPE.Text.Trim)

            alParaval.Add(TXTITEMNAME.Text.Trim)
            alParaval.Add(TXTQUALITY.Text.Trim)
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(TXTPICK.Text.Trim)
            alParaval.Add(TXTDESIGN.Text.Trim)
            alParaval.Add(TXTCOLOR.Text.Trim)


            alParaval.Add(Val(TXTTOTALPARTYMTRS.Text))
            alParaval.Add(TXTTOTALCHECKEDMTRS.Text.Trim)

            alParaval.Add(Val(TXTTOTALDIFF.Text))
            alParaval.Add(Val(TXTTOTALWT.Text))
            alParaval.Add(Val(TXTRECPCS.Text))
            alParaval.Add(Val(TXTRECMTRS.Text))
            alParaval.Add(Val(TXTREJPCS.Text))
            alParaval.Add(Val(TXTBALPCS.Text))
            alParaval.Add(Val(TXTREJMTRS.Text))
            alParaval.Add(Val(TXTBALMTRS.Text))
            alParaval.Add(0)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim gridremarks As String = ""
            Dim PARTYMTRS As String = ""
            Dim CHECKEDMTRS As String = ""
            Dim DIFF As String = ""
            Dim WT As String = ""
            Dim CHECKINGDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim APPROVED As String = ""      'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDCHECKING.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        gridremarks = row.Cells(Gdesc.Index).Value.ToString
                        PARTYMTRS = row.Cells(GPARTYMTRS.Index).Value.ToString
                        CHECKEDMTRS = row.Cells(GMTRS.Index).Value.ToString
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = 1
                        Else
                            APPROVED = 0
                        End If
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            CHECKINGDONE = 1
                        Else
                            CHECKINGDONE = 0
                        End If

                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        gridremarks = gridremarks & "," & row.Cells(Gdesc.Index).Value.ToString
                        PARTYMTRS = PARTYMTRS & "," & row.Cells(GPARTYMTRS.Index).Value.ToString
                        CHECKEDMTRS = CHECKEDMTRS & "," & row.Cells(GMTRS.Index).Value.ToString
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = APPROVED & "," & "1"
                        Else
                            APPROVED = APPROVED & "," & "0"

                        End If
                        DIFF = DIFF & "," & row.Cells(GDIFF.Index).Value
                        WT = WT & "," & row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            CHECKINGDONE = CHECKINGDONE & "," & "1"
                        Else
                            CHECKINGDONE = CHECKINGDONE & "," & "0"
                        End If



                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(gridremarks)
            alParaval.Add(PARTYMTRS)
            alParaval.Add(CHECKEDMTRS)
            alParaval.Add(APPROVED)
            alParaval.Add(DIFF)
            alParaval.Add(WT)
            alParaval.Add(CHECKINGDONE)
            alParaval.Add(TXTTYPE.Text)


            Dim OBJCHECKING As New ClsGRNChecking()
            OBJCHECKING.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJCHECKING.SAVE()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCHECKINGNO)

                IntResult = OBJCHECKING.UPDATE()
                MsgBox("Details Updated")
            End If
            edit = False

            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRNChecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'for Delete
            GRIDCHECKING.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.P Then       'for CLEAR
            Call CheckingReportToolStripMenuItem_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDCHECKING.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
            tstxtbillno.Focus()
        End If
    End Sub

    Private Sub GRNChecking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            'FETCH THE DATA AUTO
            If AUTOCHECKING = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" NAME, [Item Name] AS ITEMNAME, [Description] AS [DESC], QUALITY, DESIGN, COLOR,QTY, MTRS, [Lot No.] AS LOTNO, GRNNO, GRIDSRNO, TYPE, [Date] AS GRNDATE , TOLEDGER, DYEINGTYPE, TRANSNAME, LRNO  ", "", " GRN_VIEW ", " AND GRNNO = " & Val(TEMPGRNNO) & " and CHECKDONE='A' AND YEARID = " & YearId & "  order by [Lot No.]")
                If DT.Rows.Count > 0 Then
                    TXTSUPPNAME.Text = DT.Rows(0).Item("NAME")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    txtremarks.Text = DT.Rows(0).Item("DESC")
                    TXTQUALITY.Text = DT.Rows(0).Item("QUALITY")
                    CMBQUALITY.Text = DT.Rows(0).Item("QUALITY")
                    TXTDESIGN.Text = DT.Rows(0).Item("DESIGN")
                    TXTCOLOR.Text = DT.Rows(0).Item("COLOR")
                    TXTGRNQTY.Text = Format(Val(DT.Rows(0).Item("QTY")), "0.00")
                    TXTGRNMTRS.Text = Format(Val(DT.Rows(0).Item("MTRS")), "0.00")
                    TXTLOTNO.Text = DT.Rows(0).Item("LOTNO")
                    TXTGRNNO.Text = DT.Rows(0).Item("GRNNO")
                    TXTGRNGRIDSRNO.Text = DT.Rows(0).Item("GRIDSRNO")
                    TXTTYPE.Text = DT.Rows(0).Item("TYPE")
                    GRNDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("GRNDATE")).Date, "dd/MM/yyyy")
                    CHECKINGDATE.Text = Format(Convert.ToDateTime(DT.Rows(0).Item("GRNDATE")).Date, "dd/MM/yyyy")
                    cmbname.Text = DT.Rows(0).Item("TOLEDGER")
                    CMBDYEINGTYPE.Text = DT.Rows(0).Item("DYEINGTYPE")
                    cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    txtlrno.Text = DT.Rows(0).Item("LRNO")

                    'FETCH ALL THE GRIDSRNO DETAILS IN CHECKINGGRID HERE
                    If FETCHGRNINCHECKING = True Then
                        GRIDCHECKING.RowCount = 0
                        DT = OBJCMN.search("GRN_MTRS AS MTRS, GRN_BALENO AS BALENO", "", "  GRN_DESC ", " AND GRN_NO = " & Val(TEMPGRNNO) & " AND GRN_GRIDTYPE = '" & TXTTYPE.Text.Trim & "' AND GRN_YEARID = " & YearId)
                        For Each ROW As DataRow In DT.Rows
                            GRIDCHECKING.Rows.Add(GRIDCHECKING.RowCount + 1, Format(Val(ROW("MTRS")), "0.00"), Format(Val(ROW("MTRS")), "0.00"), ROW("BALENO"), "Yes", 0.0, 0.0, 0)
                        Next
                    End If
                    total()
                End If
            End If


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsGRNChecking()
                Dim dttable As New DataTable

                dttable = OBJCHECKING.selectCHECKING(TEMPCHECKINGNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then
                    CMDSELECTGRN.Enabled = False

                    For Each dr As DataRow In dttable.Rows
                        cmbname.Enabled = False
                        TXTCHECKINGNO.Text = TEMPCHECKINGNO
                        'GRNDATE.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        CHECKINGDATE.Text = Format(Convert.ToDateTime(dr("CHECKDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        TXTSUPPNAME.Text = Convert.ToString(dr("SUPPNAME").ToString)
                        txtadd.Text = Convert.ToString(dr("ADD").ToString)
                        CMBQUALITY.Text = Convert.ToString(dr("NEWQUALITY").ToString)
                        TXTCOUNT.Text = Convert.ToString(dr("COUNT").ToString)
                        TXTWIDTH.Text = Convert.ToString(dr("WIDTH").ToString)
                        CMBDYEINGTYPE.Text = dr("DYEINGTYPE")

                        'GRN DETAILS
                        TXTLOTNO.Text = Convert.ToString(dr("LOTNO").ToString)
                        TXTGRNNO.Text = Convert.ToString(dr("GRNNO").ToString)
                        TXTGRNGRIDSRNO.Text = Convert.ToString(dr("GRNGRIDSRNO").ToString)
                        'GRNDATE.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        'TXTGRNQTY.Text = Convert.ToString(dr("GRNQTY").ToString)

                        'ITEM DETAILS
                        TXTITEMNAME.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        TXTQUALITY.Text = Convert.ToString(dr("QUALITY").ToString)
                        TXTREED.Text = Convert.ToString(dr("REED").ToString)
                        TXTPICK.Text = Convert.ToString(dr("PICK").ToString)
                        TXTCOLOR.Text = Convert.ToString(dr("COLOR").ToString)
                        TXTDESIGN.Text = Convert.ToString(dr("DESIGNNO").ToString)
                        TXTTYPE.Text = Convert.ToString(dr("TYPE").ToString)

                        cmbtrans.Text = Convert.ToString(dr("TRANSNAME").ToString)
                        txtlrno.Text = Convert.ToString(dr("LRNO").ToString)
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        GRIDCHECKING.Rows.Add(dr("GRIDSRNO").ToString, Format(dr("PARTYMTRS"), "0.00"), Format(dr("CHECKEDMTRS"), "0.00"), dr("GRIDREMARKS").ToString, dr("APPROVED"), Format(dr("DIFF"), "0.00"), Format(dr("WT"), "0.00"), dr("DONE").ToString)

                        If Convert.ToBoolean(dr("DONE")) = True Then GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow

                    Next
                    GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If


                Dim OBJ As New ClsCommon()
                Dim dt As New DataTable
                dt = OBJ.search(" grn_TOTALqty,GRN_DATE,GRN_TOTALMTRS ", "", " GRN ", " AND GRN_TYPE = '" & TXTTYPE.Text.Trim & "' and grn_no=" & Val(TXTGRNNO.Text.Trim) & " and grn_yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    TXTGRNQTY.Text = dt.Rows(0).Item(0)
                    GRNDATE.Value = dt.Rows(0).Item(1)
                    TXTGRNMTRS.Text = dt.Rows(0).Item(2)
                End If
                total()

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

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
            Dim OBJCHECKING As New GRNCheckingDetails
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

    Private Sub cmdselectGRN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSELECTGRN.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJ As New ClsCommon()
            Dim dt As New DataTable

            selectGRNtable.Clear()
            Dim OBJSELECTGRN As New SelectGRN
            OBJSELECTGRN.ShowDialog()


            Dim i As Integer = 0
            If selectGRNtable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then GRIDCHECKING.RowCount = 0
                Dim POGRIDSRNO As String = ""
                Dim tempno As Integer = 0

                For i = 0 To selectGRNtable.Rows.Count - 1
                    TXTSUPPNAME.Text = selectGRNtable.Rows(i).Item("NAME")
                    TXTITEMNAME.Text = selectGRNtable.Rows(i).Item("ITEMNAME")
                    txtremarks.Text = selectGRNtable.Rows(i).Item("DESC")
                    TXTQUALITY.Text = selectGRNtable.Rows(i).Item("QUALITY")
                    CMBQUALITY.Text = selectGRNtable.Rows(i).Item("QUALITY")
                    TXTDESIGN.Text = selectGRNtable.Rows(i).Item("DESIGN")
                    TXTCOLOR.Text = selectGRNtable.Rows(i).Item("COLOR")
                    TXTGRNQTY.Text = Format(Val(selectGRNtable.Rows(i).Item("QTY")), "0.00")
                    TXTGRNMTRS.Text = Format(Val(selectGRNtable.Rows(i).Item("MTRS")), "0.00")
                    TXTLOTNO.Text = selectGRNtable.Rows(i).Item("LOTNO")
                    If Val(TXTLOTNO.Text.Trim) = 0 And ClientName = "AVIS" Then
                        TXTLOTNO.ReadOnly = False
                        TXTLOTNO.BackColor = Color.LemonChiffon
                    Else
                        TXTLOTNO.ReadOnly = True
                        TXTLOTNO.BackColor = Color.Linen
                    End If
                    TXTGRNNO.Text = selectGRNtable.Rows(i).Item("GRNNO")
                    TXTGRNGRIDSRNO.Text = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    TXTTYPE.Text = selectGRNtable.Rows(i).Item("TYPE")
                    GRNDATE.Value = Format(Convert.ToDateTime(selectGRNtable.Rows(i).Item("GRNDATE")).Date, "dd/MM/yyyy")
                    CHECKINGDATE.Text = Format(Convert.ToDateTime(selectGRNtable.Rows(i).Item("GRNDATE")).Date, "dd/MM/yyyy")
                    cmbname.Text = selectGRNtable.Rows(i).Item("TOLEDGER")
                    CMBDYEINGTYPE.Text = selectGRNtable.Rows(i).Item("DYEINGTYPE")
                    cmbtrans.Text = selectGRNtable.Rows(i).Item("TRANSNAME")
                    txtlrno.Text = selectGRNtable.Rows(i).Item("LRNO")

                    cmbname.Enabled = False

                    If POGRIDSRNO = "" Then
                        POGRIDSRNO = selectGRNtable.Rows(i).Item("GRIDSRNO")
                        tempno = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    Else
                        If tempno <> selectGRNtable.Rows(i).Item("GRIDSRNO") Then
                            POGRIDSRNO = POGRIDSRNO & "," & selectGRNtable.Rows(i).Item("GRIDSRNO")
                            tempno = selectGRNtable.Rows(i).Item("GRIDSRNO")
                        End If
                    End If


                    'FETCH ALL THE GRIDSRNO DETAILS IN CHECKINGGRID HERE
                    If FETCHGRNINCHECKING = True Then
                        GRIDCHECKING.RowCount = 0
                        dt = OBJ.search("GRN_MTRS AS MTRS, GRN_BALENO AS BALENO", "", "  GRN_DESC ", " AND GRN_NO = " & Val(selectGRNtable.Rows(i).Item("GRNNO")) & " AND GRN_GRIDTYPE = '" & selectGRNtable.Rows(i).Item("TYPE") & "' AND GRN_YEARID = " & YearId)
                        For Each ROW As DataRow In dt.Rows
                            GRIDCHECKING.Rows.Add(GRIDCHECKING.RowCount + 1, Format(Val(ROW("MTRS")), "0.00"), Format(Val(ROW("MTRS")), "0.00"), ROW("BALENO"), "Yes", 0.0, 0.0, 0)
                        Next
                    End If

                Next

                dt = OBJ.search(" grn_TOTALqty,GRN_DATE,GRN_TOTALMTRS ", "", " grn ", " and grn_no=" & Val(TXTGRNNO.Text.Trim) & " and grn_yearid=" & YearId & " and grn_type='Job Work'")
                If dt.Rows.Count > 0 Then
                    TXTGRNQTY.Text = dt.Rows(0).Item(0)
                    GRNDATE.Value = dt.Rows(0).Item(1)
                    TXTGRNMTRS.Text = dt.Rows(0).Item(2)
                    CHECKINGDATE.Text = dt.Rows(0).Item(1)
                End If
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
                    edit = True
                    GRNChecking_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDCHECKING.Enabled = True
        If CMBAPPOROVED.Text = "No" Then TXTDIFF.Text = 0
        If GRIDDOUBLECLICK = False Then

            GRIDCHECKING.Rows.Add(Val(txtsrno.Text.Trim), Format(Val(TXTPARTYMTRS.Text.Trim), "0.00"), Format(Val(TXTCHECKEDMTRS.Text.Trim), "0.00"), TXTGRIDREMARKS.Text.Trim, CMBAPPOROVED.Text.Trim, Format(Val(TXTDIFF.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), 0)
            getsrno(GRIDCHECKING)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCHECKING.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDCHECKING.Item(GPARTYMTRS.Index, TEMPROW).Value = TXTPARTYMTRS.Text.Trim
            GRIDCHECKING.Item(GMTRS.Index, TEMPROW).Value = TXTCHECKEDMTRS.Text.Trim
            GRIDCHECKING.Item(Gdesc.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim
            GRIDCHECKING.Item(GAPPROVED.Index, TEMPROW).Value = CMBAPPOROVED.Text.Trim
            GRIDCHECKING.Item(GDIFF.Index, TEMPROW).Value = Format(Val(TXTDIFF.Text.Trim), "0.00")
            GRIDCHECKING.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False
        End If

        total()

        GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
        If GRIDDOUBLECLICK = False Then
            If GRIDCHECKING.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If

        TXTGRIDREMARKS.Clear()
        TXTPARTYMTRS.Clear()
        TXTCHECKEDMTRS.Clear()
        TXTDIFF.Clear()
        TXTWT.Clear()


        TXTPARTYMTRS.Focus()

    End Sub

    Sub EDITROW()
        If GRIDCHECKING.CurrentRow.Index >= 0 And GRIDCHECKING.Item(gsrno.Index, GRIDCHECKING.CurrentRow.Index).Value <> Nothing Then

            If Convert.ToBoolean(GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from MFG")
                Exit Sub
            End If

            GRIDDOUBLECLICK = True
            txtsrno.Text = GRIDCHECKING.Item(gsrno.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            TXTGRIDREMARKS.Text = GRIDCHECKING.Item(Gdesc.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            TXTPARTYMTRS.Text = GRIDCHECKING.Item(GPARTYMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            TXTCHECKEDMTRS.Text = GRIDCHECKING.Item(GMTRS.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            CMBAPPOROVED.Text = GRIDCHECKING.Item(GAPPROVED.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            TXTDIFF.Text = GRIDCHECKING.Item(GDIFF.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString
            TXTWT.Text = GRIDCHECKING.Item(GWT.Index, GRIDCHECKING.CurrentRow.Index).Value.ToString

            TEMPROW = GRIDCHECKING.CurrentRow.Index
            TXTPARTYMTRS.Focus()

        End If
    End Sub

    Private Sub GRIDCHECKING_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHECKING.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDCHECKING.RowCount = 0
LINE1:
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) - 1
            If TEMPCHECKINGNO > 0 Then
                EDIT = True
                GRNChecking_Load(sender, e)
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
                edit = True
                GRNChecking_Load(sender, e)
            Else
                clear()
                edit = False
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

            Dim done As Boolean
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                'Dim DTTABLE As New DataTable
                'DTTABLE = getmax(" CHECK_done ", " CHECKINGMASTER_DESC", " and CHECK_no=" & TXTCHECKINGNO.Text.Trim & " AND CHECK_DONE='TRUE' AND GRN_cmpid=" & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                'If DTTABLE.Rows.Count > 0 Then
                '    done = DTTABLE.Rows(0).Item(0)
                'End If
                If done = True Then
                    MsgBox("Checking Raised Delete Checking First", MsgBoxStyle.Critical)
                Else

                    TEMPMSG = MsgBox("Delete CHECKING?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTCHECKINGNO.Text.Trim)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)
                        alParaval.Add(TXTTYPE.Text)

                        Dim ClsGRNChecking As New ClsGRNChecking()
                        ClsGRNChecking.alParaval = alParaval
                        IntResult = ClsGRNChecking.Delete()
                        MsgBox("CHECKING Deleted")
                        clear()
                        edit = False

                    End If
                End If
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

                Case GMTRS.Index, GWT.Index, GPARTYMTRS.Index, GDIFF.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCHECKING.CurrentCell.Value = Nothing Then GRIDCHECKING.CurrentCell.Value = "0.00"
                        GRIDCHECKING.CurrentCell.Value = Format(Convert.ToDecimal(GRIDCHECKING.Item(colNum, e.RowIndex).Value), "0.00")
                        GRIDCHECKING.Rows(e.RowIndex).Cells(GDIFF.Index).Value = Format(Val(GRIDCHECKING.Rows(e.RowIndex).Cells(GPARTYMTRS.Index).EditedFormattedValue - GRIDCHECKING.Rows(e.RowIndex).Cells(GMTRS.Index).EditedFormattedValue), "0.00")
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
            If e.KeyCode = Keys.Delete And GRIDCHECKING.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                'For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                'If Convert.ToBoolean(ROW.Cells(GDONE.Index).Value) = True And (ROW.Cells(GAPPROVED.Index).Value) = "Yes" Then
                '    MessageBox.Show("Some Item has been locked, You Cannot Delete This Row")
                '    Exit Sub
                '    End If
                'Next
                If Convert.ToBoolean(GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GDONE.Index).Value) = True Then
                    MessageBox.Show(" Item has been locked, You Cannot Delete This Row")
                    Exit Sub
                End If
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHECKING.Rows.RemoveAt(GRIDCHECKING.CurrentRow.Index)
                getsrno(GRIDCHECKING)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTWT.Validated
        Try
            If TXTLOTNO.Text.Trim = "" Or Val(TXTGRNGRIDSRNO.Text.Trim) = 0 Then
                MsgBox("Select GRN Properly", MsgBoxStyle.Critical)
                Exit Sub
                cmbname.Focus()
            End If

            If Val(GRIDCHECKING.RowCount) + 1 > Val(TXTGRNQTY.Text.Trim) And GRIDDOUBLECLICK = False Then
                MsgBox("Extra Pcs Not Allowed, All Pcs Entered", MsgBoxStyle.Critical)
                Exit Sub
                cmbname.Focus()
            End If

            If Val(TXTPARTYMTRS.Text.Trim) > 0 And Val(TXTCHECKEDMTRS.Text.Trim) > 0 Then

                'IF APPROVED = NO THEN PARTY MTRS AND CHECKED MTRS SHOULD BE SAME
                If CMBAPPOROVED.Text = "No" Then TXTCHECKEDMTRS.Text = Val(TXTPARTYMTRS.Text)

                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPARTYMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPARTYMTRS.KeyPress
        numdot(e, TXTPARTYMTRS, Me)
    End Sub

    Private Sub TXTCHECKEDMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHECKEDMTRS.KeyPress
        numdot(e, TXTCHECKEDMTRS, Me)
    End Sub

    Private Sub TXTCHECKEDMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCHECKEDMTRS.Validated
        TXTDIFF.Text = Format(Val(TXTPARTYMTRS.Text) - Val(TXTCHECKEDMTRS.Text), "0.00")
    End Sub

    Private Sub TXTPARTYMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPARTYMTRS.Validated
        TXTDIFF.Text = Format(Val(TXTPARTYMTRS.Text) - Val(TXTCHECKEDMTRS.Text), "0.00")
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
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

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDCHECKING.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        Try
            If Val(TXTCOPYLINES.Text.Trim) > 0 And GRIDCHECKING.RowCount > 0 Then
                TEMPMSG = MsgBox("Wish To Copy Line", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    For I As Integer = 1 To Val(TXTCOPYLINES.Text.Trim) - 1
                        Dim ROW As DataGridViewRow = GRIDCHECKING.Rows(0).Clone()
                        GRIDCHECKING.Rows.Add(0, GRIDCHECKING.Rows(0).Cells(GPARTYMTRS.Index).Value, GRIDCHECKING.Rows(0).Cells(GMTRS.Index).Value, GRIDCHECKING.Rows(0).Cells(Gdesc.Index).Value, GRIDCHECKING.Rows(0).Cells(GAPPROVED.Index).Value, GRIDCHECKING.Rows(0).Cells(GDIFF.Index).Value, GRIDCHECKING.Rows(0).Cells(GWT.Index).Value, 0)
                    Next
                    getsrno(GRIDCHECKING)
                    total()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
    Private Sub CheckingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckingReportToolStripMenuItem.Click
        Try
            'If edit = True Then
            '    Dim OBJGRN As New GRNCheckingDesign
            '    OBJGRN.GRNCHECKINGNO = TEMPCHECKINGNO
            '    OBJGRN.rtn = False
            '    OBJGRN.MdiParent = MDIMain
            '    OBJGRN.selfor_po = "{CHECKINGMASTER.CHECK_no}=" & TEMPCHECKINGNO & " and {CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
            '    OBJGRN.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOReportToolStripMenuItem.Click
        Try
            If edit = True Then
                If TXTREJPCS.Text <> 0 Then
                    serverprop()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        'Dim objgp As New GRNCheckingDesign
        'Dim rptreturnGRNCHECKING As New RETURNGRNCheckingreport
        ''**************** SET SERVER ************************
        'Dim crtableLogonInfo As New TableLogOnInfo
        'Dim crConnecttionInfo As New ConnectionInfo
        'Dim crTables As Tables
        'Dim crTable As Table

        'With crConnecttionInfo
        '    .ServerName = SERVERNAME
        '    .DatabaseName = DatabaseName
        '    .UserID = DBUSERNAME
        '    .Password = Dbpassword
        '    .IntegratedSecurity = Dbsecurity
        'End With

        'crTables = rptreturnGRNCHECKING.Database.Tables
        'For Each crTable In crTables
        '    crtableLogonInfo = crTable.LogOnInfo
        '    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
        '    crTable.ApplyLogOnInfo(crtableLogonInfo)
        'Next

        ''************************ END *******************


        'objgp.MdiParent = MDIMain

        'rptreturnGRNCHECKING.RecordSelectionFormula = "{CHECKINGMASTER.CHECK_no}=" & TXTCHECKINGNO.Text & " and {CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
        'rptreturnGRNCHECKING.PrintToPrinter(1, True, 0, 0)
    End Sub

    Private Sub cmdAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAuto.Click
        If GRIDCHECKING.RowCount = 0 Then
            For i As Integer = 0 To Val(TXTGRNQTY.Text) - 1
                GRIDCHECKING.Rows.Add(i + 1, Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), "", "Yes", 0.0, 0.0, 0)
            Next
            total()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GRIDCHECKING.RowCount = 0 Then
            For i As Integer = 0 To Val(TXTGRNQTY.Text) - 1
                GRIDCHECKING.Rows.Add(i + 1, Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), "", "No", 0.0, 0.0, 0)
            Next
            total()
        End If
    End Sub

    Private Sub CMBAPPOROVED_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAPPOROVED.Validating
        If CMBAPPOROVED.Text = "NO" Then TXTDIFF.Text = 0 Else TXTDIFF.Text = Format(Val(TXTPARTYMTRS.Text) - Val(TXTCHECKEDMTRS.Text), "0.00")
    End Sub

    Private Sub txttslotno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttslotno.Validating
        Try
            If Val(txttslotno.Text) > 0 Then
                GRIDCHECKING.RowCount = 0
                Dim dt As DataTable
                Dim objcls As New ClsCommon()
                dt = objcls.search(" CHECKINGMASTER.CHECK_NO ", "", " CHECKINGMASTER ", " and CHECKINGMASTER.CHECK_LOTNO=" & Val(txttslotno.Text) & " and CHECKINGMASTER.CHECK_CMPID=" & CmpId & "  and CHECKINGMASTER.CHECK_LOCATIONID=" & Locationid & " and CHECKINGMASTER.CHECK_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPCHECKINGNO = Val(dt.Rows(0).Item(0))
                    If TEMPCHECKINGNO > 0 Then
                        edit = True
                        GRNChecking_Load(sender, e)
                    End If
                Else
                    MsgBox("NO RECORD FOUND")
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTWT.Validating
        'Try
        '    If (TXTWT.Text.Trim) > 20 Then
        '        MsgBox("Wt/Pcs cannot be so much")
        '        e.Cancel = True
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try

    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
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
                OBJQUALITY.FRMSTRING = "QUALITY"
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQUALITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Sub GRNChecking_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MSANCHITKUMAR" Then
                LBLDYEINGTYPE.Visible = True
                CMBDYEINGTYPE.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then cmbtrans.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTLOTNO.KeyPress
        If ClientName <> "AVIS" Then numkeypress(e, sender, Me)
    End Sub
End Class