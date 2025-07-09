
Imports BL
Imports System.ComponentModel

Public Class InterGodownTransfer
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPGODOWNNO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALJONO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTGODOWNNO.Clear()

        If ALLOWMANUALJONO = True Then
            TXTGODOWNNO.ReadOnly = False
            TXTGODOWNNO.BackColor = Color.LemonChiffon
        Else
            TXTGODOWNNO.ReadOnly = True
            TXTGODOWNNO.BackColor = Color.Linen
        End If
        'CMBFROMGODOWN.Text = ""
        'CMBTOGODOWN.Text = ""
        CMBTRANSPORTNAME.Text = ""
        TXTADD.Clear()
        TXTDATE.Text = Now.Date
        tstxtbillno.Clear()
        txtremarks.Clear()
        CMDSELECTSTOCK.Enabled = True
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLTOTALMTRS.Text = 0.0
        LBLTOTALPCS.Text = 0.0
        TXTREFRENCE.Clear()
        TXTISSUEBY.Clear()
        TXTBARCODE.Clear()
        GRIDJO.RowCount = 0
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()
        txtsrno.Clear()
        CMBPIECETYPE.Text = "FRESH"
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        TXTLOTNO.Clear()
        TXTBALENO.Clear()
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTPCS.Clear()
        TXTMTRS.Clear()

    End Sub

    'Sub total()
    '    Try
    '        LBLTOTALMTRS.Text = 0.0
    '        LBLTOTALPCS.Text = 0.0
    '        LBLRATE.Text = 0.0
    '        lbltotalwt.Text = 0.0

    '        Dim DONE As Boolean = False
    '        GRIDLOT.RowCount = 0


    '        For Each ROW As DataGridViewRow In GRIDJO.Rows
    '            If ROW.Cells(GSRNO.Index).Value <> Nothing Then
    '                If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(GPCS.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
    '                LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
    '                LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
    '                LBLRATE.Text = Format(Val(LBLRATE.Text) + Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
    '                lbltotalwt.Text = Format(Val(lbltotalwt.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
    '            End If

    '            DONE = False
    '            If Val(ROW.Cells(GMTRS.Index).EditedFormattedValue) > 0 Then
    '                If GRIDLOT.RowCount = 0 Then
    '                    GRIDLOT.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
    '                Else
    '                    For Each SUMMROW As DataGridViewRow In GRIDLOT.Rows
    '                        If SUMMROW.Cells(DLOTNO.Index).Value = ROW.Cells(GBALENO.Index).Value Then
    '                            SUMMROW.Cells(DPCS.Index).Value = Val(SUMMROW.Cells(DPCS.Index).Value) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue)
    '                            SUMMROW.Cells(DMTRS.Index).Value = Val(SUMMROW.Cells(DMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue)
    '                            DONE = True
    '                        End If
    '                    Next
    '                    If DONE = False Then GRIDLOT.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        'CMBFROMGODOWN.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(TRANSFER_no),0) + 1 ", " INTERGODOWNTRANSFER ", " AND TRANSFER_cmpid=" & CmpId & " and  TRANSFER_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTGODOWNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBFROMGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBFROMGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBTOGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBTOGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBFROMGODOWN.Text.Trim = CMBTOGODOWN.Text.Trim Then
                EP.SetError(CMBFROMGODOWN, " From && To Godown cannot be same")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDJO.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If TXTDATE.Text = "__/__/____" Then
                EP.SetError(TXTDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(TXTDATE.Text) Then
                    EP.SetError(TXTDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTGODOWNNO.Text.Trim) = 0 Then
                EP.SetError(TXTGODOWNNO, "Enter  Godown No")
                bln = False
            End If

            'If ALLOWMANUALJONO = True Then
            '    If TXTGODOWNNO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
            '        Dim OBJCMN As New ClsCommon
            '        Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBOUT.JO_NO,0)  AS JONO", "", " JOBOUT ", "  AND JOBOUT.JO_NO=" & TXTGODOWNNO.Text.Trim & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
            '        If dttable.Rows.Count > 0 Then
            '            EP.SetError(TXTGODOWNNO, "Job Out No Already Exist")
            '            bln = False
            '        End If
            '    End If
            'End If





            Return bln
        Catch ex As Exception
            Throw ex
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

            If TXTGODOWNNO.ReadOnly = False Then
                alParaval.Add(Val(TXTGODOWNNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(TXTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBFROMGODOWN.Text.Trim)
            alParaval.Add(CMBTOGODOWN.Text.Trim)
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
            alParaval.Add(TXTREFRENCE.Text.Trim)
            alParaval.Add(TXTISSUEBY.Text.Trim)

            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)




            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim BALENO As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDJO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value.ToString
                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(GPCS.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value.ToString
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(BALENO)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)
            alParaval.Add(BARCODE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim objCUTTING As New ClsInterGodownTransfer()
            objCUTTING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.save()
                MsgBox("Details Added")

                'If ClientName = "SVS" Then
                '    If MsgBox("Wish to Stock Reco Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '        RECOSAVE()
                '    End If
                'End If

                TXTGODOWNNO.Text = DTTABLE.Rows(0).Item(0)
                If ClientName <> "MJFABRIC" Then PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPGODOWNNO)
                IntResult = objCUTTING.Update()
                MsgBox("Details Updated")
                If ClientName <> "MJFABRIC" Then PRINTREPORT(TEMPGODOWNNO)
                EDIT = False
            End If
            clear()
            TXTDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    'Sub RECOSAVE()
    '    Try

    '        Dim alParaval As New ArrayList

    '        alParaval.Add(Format(Convert.ToDateTime(TXTDATE.Text).Date, "MM/dd/yyyy"))
    '        alParaval.Add(CMBFROMGODOWN.Text.Trim)
    '        alParaval.Add(CMBTOGODOWN.Text.Trim)
    '        alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
    '        alParaval.Add(TXTREFRENCE.Text.Trim)
    '        alParaval.Add(TXTISSUEBY.Text.Trim)
    '        alParaval.Add(TXTBARCODE.Text.Trim)
    '        alParaval.Add(Val(LBLTOTALPCS.Text))
    '        alParaval.Add(Val(LBLTOTALMTRS.Text))
    '        alParaval.Add(Val(lbltotalwt.Text))
    '        alParaval.Add(txtremarks.Text.Trim)
    '        alParaval.Add(CmpId)
    '        alParaval.Add(Locationid)
    '        alParaval.Add(Userid)
    '        alParaval.Add(YearId)
    '        alParaval.Add(0)

    '        Dim gridsrno As String = ""
    '        Dim PIECETYPE As String = ""
    '        Dim ITEMNAME As String = ""
    '        Dim QUALITY As String = ""
    '        Dim DESIGN As String = ""
    '        Dim COLOR As String = ""
    '        Dim PCS As String = ""
    '        Dim MTRS As String = ""
    '        Dim OUTPCS As String = ""
    '        Dim OUTMTRS As String = ""
    '        Dim BARCODE As String = "" 'BARCODE ADDED
    '        Dim FROMNO As String = ""
    '        Dim FROMSRNO As String = ""
    '        Dim FROMTYPE As String = ""

    '        Dim PRESENT As Boolean = False
    '        For Each row As Windows.Forms.DataGridViewRow In GRIDJO.Rows
    '            Dim objclscommon As New ClsCommonMaster
    '            Dim dt1 As DataTable = objclscommon.search(" ISNULL(MTRS,0) AS MTRS ", "", " BARCODESTOCK", " AND GODOWN='" & CMBFROMGODOWN.Text.Trim & "' AND FROMNO= " & Val(row.Cells(GFROMNO.Index).Value) & " AND FROMSRNO= " & Val(row.Cells(GFROMSRNO.Index).Value) & " AND TYPE='" & row.Cells(GFROMTYPE.Index).Value & "' AND Yearid = " & YearId)
    '            If dt1.Rows.Count > 0 Then
    '                If Val(dt1.Rows(0).Item(0)) <= 3 Then
    '                    PRESENT = True
    '                    TEMPMTRS = Val(dt1.Rows(0).Item(0))
    '                    If gridsrno = "" Then
    '                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
    '                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
    '                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
    '                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
    '                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
    '                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
    '                        PCS = row.Cells(GPCS.Index).Value.ToString
    '                        MTRS = row.Cells(GMTRS.Index).Value.ToString
    '                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
    '                        OUTPCS = row.Cells(GOUTPCS.Index).Value.ToString
    '                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value.ToString
    '                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
    '                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
    '                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

    '                    Else
    '                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
    '                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
    '                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
    '                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
    '                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
    '                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
    '                        PCS = PCS & "|" & row.Cells(GPCS.Index).Value.ToString
    '                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
    '                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
    '                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value.ToString
    '                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value.ToString
    '                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
    '                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString
    '                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

    '                    End If

    '                End If
    '            End If
    '        Next


    '        alParaval.Add(gridsrno)
    '        alParaval.Add(PIECETYPE)
    '        alParaval.Add(ITEMNAME)
    '        alParaval.Add(QUALITY)
    '        alParaval.Add(DESIGN)
    '        alParaval.Add(COLOR)
    '        alParaval.Add(PCS)
    '        alParaval.Add(MTRS)
    '        alParaval.Add(BARCODE)
    '        alParaval.Add(OUTPCS)
    '        alParaval.Add(OUTMTRS)
    '        alParaval.Add(FROMNO)
    '        alParaval.Add(FROMSRNO)
    '        alParaval.Add(FROMTYPE)



    '        Dim objclsPurord As New ClsStockAdjustment()
    '        objclsPurord.alParaval = alParaval

    '        If PRESENT = True Then Dim DT As DataTable = objclsPurord.SAVE()
    '        MsgBox("Reco done Successfully!")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub JOBOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D1) Then
            TabControl1.Focus()
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D2) Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDJO.Focus()
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub InterGodownTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If ClientName = "SVS" Then GPCS.ReadOnly = True

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objJO As New ClsInterGodownTransfer()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPGODOWNNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.SELECTGODOWN()

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTGODOWNNO.Text = TEMPGODOWNNO
                        TXTGODOWNNO.ReadOnly = True
                        TXTDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBFROMGODOWN.Text = Convert.ToString(dr("FROMGODOWN").ToString)
                        CMBTOGODOWN.Text = Convert.ToString(dr("TOGODOWN").ToString)
                        CMBTRANSPORTNAME.Text = Convert.ToString(dr("TRANSPORTNAME").ToString)
                        TXTREFRENCE.Text = dr("REFRENCE")
                        TXTISSUEBY.Text = dr("ISSUE")

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        LBLTOTALMTRS.Text = Val(dr("LBLTOTALMTRS"))
                        LBLTOTALPCS.Text = Val(dr("LBLTOTALPCS"))

                        'Item Grid


                        GRIDJO.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEM").ToString, dr("QUALITY").ToString, dr("LOTNO").ToString, dr("BALENO").ToString, dr("DESIGN").ToString, dr("COLORNAME").ToString, Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), dr("BARCODE").ToString, Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))


                    Next
                    total()
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    chkchange.CheckState = CheckState.Checked
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
            If CMBFROMGODOWN.Text.Trim = "" Then fillGODOWN(CMBFROMGODOWN, EDIT)
            If CMBTOGODOWN.Text.Trim = "" Then fillGODOWN(CMBTOGODOWN, EDIT)
            If CMBTRANSPORTNAME.Text.Trim = "" Then filltransname(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            FILLCOLOR(cmbcolor, cmbitemname.Text.Trim)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJEMB As New InterGodownTransferDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then fillname(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANSPORTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORTNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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



    '    Private Sub CMDSELECTDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
    '        Try
    '            Dim DTJO As New DataTable
    '            Dim OBJSELECTGDN As New SelectStockGDN
    '            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
    '            If ALLOWPACKINGSLIP = True Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
    '            OBJSELECTGDN.ShowDialog()
    '            DTJO = OBJSELECTGDN.DT
    '            If DTJO.Rows.Count > 0 Then
    '                For Each DTROWPS As DataRow In DTJO.Rows

    '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
    '                    For Each ROW As DataGridViewRow In GRIDJO.Rows
    '                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
    '                    Next

    '                    If ClientName = "KANVASU" Then
    '                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("LOTNO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", 0, Val(DTROWPS("PCS")), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
    '                    ElseIf ClientName = "BARKHA" Then
    '                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("BALENO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", DTROWPS("CUT"), Val(DTROWPS("PCS")), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
    '                    Else
    '                        GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("BALENO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", 0, Val(DTROWPS("PCS")), Format(Val(DTROWPS("MTRS")), "0.00"), 0, 0, DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
    '                    End If
    '                    TXTLOTNO.Text = DTROWPS("LOTNO")
    'LINE1:
    '                Next
    '                getsrno(GRIDJO)
    '                total()
    '                GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    'Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
    '    Try
    '        If Val(tstxtbillno.Text.Trim) > 0 Then
    '            GRIDJO.RowCount = 0
    '            TEMPGODOWNNO = Val(tstxtbillno.Text)
    '            If TEMPGODOWNNO > 0 Then
    '                EDIT = True
    '                JOBOUT_Load(sender, e)
    '            Else
    '                clear()
    '                EDIT = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Sub fillgrid()
        Try
            GRIDJO.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDJO.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, TXTBALENO.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), "", Format(Val(TXTMTRS.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, 0, 0, "")
                getsrno(GRIDJO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJO.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDJO.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDJO.Item(GMERCHANT.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDJO.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDJO.Item(GLOTNO.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
                GRIDJO.Item(GBALENO.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
                GRIDJO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDJO.Item(GCOLOR.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDJO.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
                GRIDJO.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False
            End If

            total()

            GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

            txtsrno.Clear()
            'cmbitemname.Text = ""
            'CMBQUALITY.Text = ""
            'CMBDESIGN.Text = ""
            'cmbcolor.Text = ""






            If GRIDJO.RowCount > 0 Then
                txtsrno.Text = Val(GRIDJO.Rows(GRIDJO.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            CMBPIECETYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Sub EDITROW()
        Try
            If GRIDJO.CurrentRow.Index >= 0 And GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDJO.Item(GPIECETYPE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDJO.Item(GMERCHANT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDJO.Item(GQUALITY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDJO.Item(GLOTNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDJO.Item(GBALENO.Index, GRIDJO.CurrentRow.Index).Value.ToString

                CMBDESIGN.Text = GRIDJO.Item(GDESIGN.Index, GRIDJO.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDJO.Item(GCOLOR.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDJO.Item(GPCS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDJO.Item(GMTRS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDJO.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDJO.RowCount = 0
LINE1:
            TEMPGODOWNNO = Val(TXTGODOWNNO.Text) - 1
            If TEMPGODOWNNO > 0 Then
                EDIT = True
                InterGodownTransfer_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPGODOWNNO > 1 Then
                TXTGODOWNNO.Text = TEMPGODOWNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPGODOWNNO = Val(TXTGODOWNNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTGODOWNNO.Text.Trim
            clear()
            If Val(TXTGODOWNNO.Text) - 1 >= TEMPGODOWNNO Then
                EDIT = True
                InterGodownTransfer_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPGODOWNNO < MAXNO Then
                TXTGODOWNNO.Text = TEMPGODOWNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMGODOWN.Enter
        Try
            If CMBFROMGODOWN.Text.Trim = "" Then fillGODOWN(CMBFROMGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMGODOWN.Validating
        Try
            If CMBFROMGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBFROMGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOGODOWN.Enter
        Try
            If CMBTOGODOWN.Text.Trim = "" Then fillGODOWN(CMBTOGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOGODOWN.Validating
        Try
            If CMBTOGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBTOGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDJO.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGODOWNNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub PRINTREPORT(ByVal GODOWNNO As Integer)
        Try
            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "GODOWNTRANSFER"
                OBJGDN.FORMULA = "{INTERGODOWNTRANSFER.TRANSFER_NO}=" & Val(GODOWNNO) & " and {INTERGODOWNTRANSFER.TRANSFER_yearid}=" & YearId
                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsInterGodownTransfer

                ALPARAVAL.Add(TEMPGODOWNNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Entry Deleted Succesfully")
                EDIT = False
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
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







    'Private Sub JODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDATE.GotFocus
    '    TXTDATE.SelectAll()
    'End Sub

    Private Sub JODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDATE.Validating
        Try
            If TXTDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TXTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTJONO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGODOWNNO.KeyPress
        numkeypress(e, TXTGODOWNNO, Me)
    End Sub

    'Private Sub TXTJONO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGODOWNNO.Validating
    '    Try
    '        If Val(TXTGODOWNNO.Text.Trim) <> 0 And EDIT = False Then
    '            Dim OBJCMN As New ClsCommon
    '            Dim dttable As DataTable = OBJCMN.search(" ISNULL(INTERGODOWNTRANSFER.TRANSFER_NO,0)  AS TRANSFERNO", "", " INTERGODOWNTRANSFER ", "  AND INTERGODOWNTRANSFER.TRANSFER_NO=" & TXTGODOWNNO.Text.Trim & " AND INTERGODOWNTRANSFER.TRANSFER_CMPID = " & CmpId & " AND INTERGODOWNTRANSFER.TRANSFER_LOCATIONID = " & Locationid & " AND INTERGODOWNTRANSFER.TRANSFER_YEARID = " & YearId)
    '            If dttable.Rows.Count > 0 Then
    '                MsgBox("Godown  No Already Exists")
    '                e.Cancel = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub GETMAXTYPEJONO()
    '    Try
    '        'GET MAX NO WITH RESPECT TO SELECTED JOBOUTTYPE
    '        Dim OBJCMN As New ClsCommon
    '        Dim DT As DataTable = OBJCMN.search("isnull(max(JO_TYPENO),0) + 1", "", "JOBOUT INNER JOIN  JOBOUTTYPEMASTER ON JO_TYPEID = JOTYPE_ID", " AND JOTYPE_NAME = '" & CMBTYPE.Text.Trim & "' AND JO_YEARID = " & YearId)
    '        If DT.Rows.Count > 0 Then TXTTYPEJONO.Text = Val(DT.Rows(0).Item(0))
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub



    'Private Sub JobOut_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    Try
    '        If ClientName = "MANINATH" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "MJFABRIC" Then
    '            ALLOWMANUALJONO = True
    '        End If

    '        'If ClientName = "BARKHA" Or ClientName = "BARKHA" Then
    '        '    = False
    '        'End If



    '        If ClientName = "KANVASU" Then
    '            GBALENO.HeaderText = "Lot No"
    '            GBALENO.ReadOnly = True
    '            GRIDLOT.Visible = True
    '        End If

    '        If ClientName = "MJFABRIC" Then
    '            CMBPARTYNAME.TabStop = False
    '            TXTBARCODE.TabStop = False
    '            TXTMOBILENO.TabStop = False
    '            TXTLOTNO.TabStop = False
    '            TXTCHALLANNO.TabStop = False
    '            TXTEWAYBILLNO.TabStop = False
    '            TXTBALENUMBER.TabStop = False
    '            txtsrno.TabStop = False
    '            TXTBALENO.TabStop = False
    '            CMBQUALITY.TabStop = False
    '            CMBDESIGN.TabStop = False
    '            cmbcolor.TabStop = False
    '            TXTDESCRIPTION.TabStop = False
    '            TXTCUT.TabStop = False
    '            TXTRATE.TabStop = True
    '            CMDSELECTSTOCK.TabStop = False
    '        End If

    '        If ClientName = "BARKHA" Or ClientName = "MJFABRIC" Then
    '            If ClientName = "BARKHA" Then
    '                LBLPARTYNAME.Text = "Dyeing Name"
    '                GDESCRIPTION.HeaderText = "Chart No"
    '            End If
    '            txtsrno.Visible = True
    '            CMBPIECETYPE.Visible = True
    '            TXTBALENO.Visible = True
    '            cmbitemname.Visible = True
    '            CMBQUALITY.Visible = True
    '            CMBDESIGN.Visible = True
    '            cmbcolor.Visible = True
    '            TXTDESCRIPTION.Visible = True
    '            TXTCUT.Visible = True
    '            TXTPCS.Visible = True
    '            TXTMTRS.Visible = True


    '        End If

    '        If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
    '            LBLTYPE.Visible = True
    '            CMBTYPE.Visible = True
    '            TXTTYPEJONO.Visible = True
    '            LBLSRNO.Visible = True
    '        Else
    '            LBLTYPE.Visible = False
    '            CMBTYPE.Visible = False
    '            TXTTYPEJONO.Visible = False
    '        End If

    '        If ClientName = "SUCCESS" Or ClientName = "MAHAVIR" Or ClientName = "RSONS" Or ClientName = "MJFABRIC" Or ClientName = "YASHVI" Or ClientName = "RMANILAL" Or ClientName = "MOHAN" Then
    '            GRATE.Visible = True
    '            If ClientName = "SUCCESS" Or ClientName = "MJFABRIC" Then TXTRATE.Visible = True
    '            LBLRATE.Visible = True
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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



    'Private Sub GRIDJO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDJO.CellValidating
    '    Try
    '        Dim colNum As Integer = GRIDJO.Columns(e.ColumnIndex).Index
    '        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

    '        Select Case colNum

    '            Case GPCS.Index, GMTRS.Index, gcut.Index, GRATE.Index
    '                Dim dDebit As Decimal
    '                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

    '                If bValid Then
    '                    If GRIDJO.CurrentCell.Value = Nothing Then GRIDJO.CurrentCell.Value = "0.00"
    '                    GRIDJO.CurrentCell.Value = Convert.ToDecimal(GRIDJO.Item(colNum, e.RowIndex).Value)
    '                    '' everything is good
    '                    total()
    '                Else
    '                    MessageBox.Show("Invalid Number Entered")
    '                    e.Cancel = True
    '                    Exit Sub
    '                End If

    '        End Select

    '        If EDIT = False And ClientName = "MANINATH" Then
    '            Dim TEMPITEM As String = ""
    '            For I As Integer = GRIDJO.CurrentRow.Index + 1 To GRIDJO.RowCount - 1
    '                If I = GRIDJO.CurrentRow.Index + 1 Then TEMPITEM = GRIDJO.Item(GMERCHANT.Index, I - 1).Value
    '                If GRIDJO.Item(GMERCHANT.Index, I).Value = TEMPITEM Then
    '                    GRIDJO.Item(GBALENO.Index, I).Value = GRIDJO.Item(GBALENO.Index, I - 1).EditedFormattedValue

    '                End If
    '            Next
    '        End If

    '    Catch ex As Exception

    '        Throw ex
    '    End Try
    'End Sub

    Private Sub GRIDJO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDJO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDJO.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDJO.Rows.RemoveAt(GRIDJO.CurrentRow.Index)
                getsrno(GRIDJO)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub





    'Sub CALC()
    '    Try
    '        If Val(TXTPCS.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTPCS.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        Try
            If ClientName = "MJFABRIC" Then Exit Sub
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 Then
                'If GRIDDOUBLECLICK = False Then
                '    If EDIT = True Then
                '        'GET LAST BARCODE SRNO
                '        Dim LSRNO As Integer = 0
                '        Dim RSRNO As Integer = 0
                '        Dim SNO As Integer = 0
                '        LSRNO = InStr(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                '        RSRNO = InStr(LSRNO + 1, GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                '        SNO = GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                '        TXTBARCODE.Text = "JI-" & Val(TXTJINO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                '    Else
                '        TXTBARCODE.Text = "JI-" & Val(TXTJINO.Text.Trim) & "/" & GRIDJOBIN.RowCount + 1 & "/" & YearId
                '    End If
                'End If
                fillgrid()

            Else
                'If CMBJONO.Text.Trim = "" Then
                '    MsgBox("Enter Job Out No.", MsgBoxStyle.Critical)
                '    CMBJONO.Focus()
                If CMBPIECETYPE.Text.Trim = "" Then
                    MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                    CMBPIECETYPE.Focus()
                ElseIf cmbitemname.Text.Trim = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                    cmbitemname.Focus()
                    'ElseIf CMBQUALITY.Text.Trim = "" Then
                    '    MsgBox("Enter Quality", MsgBoxStyle.Critical)
                    '    CMBQUALITY.Focus()
                    ''ElseIf CMBQUALITY.Text.Trim = "" And ClientName <> "KCRAYON" Then
                    ''    MsgBox("Enter Quality", MsgBoxStyle.Critical)
                    ''    CMBQUALITY.Focus()
                    ''ElseIf CMBDESIGN.Text.Trim = "" Then
                    ''    MsgBox("Enter Design", MsgBoxStyle.Critical)
                    ''    CMBDESIGN.Focus()
                    ''ElseIf CMBDESIGN.Text.Trim = "" And ClientName <> "KCRAYON" Then
                    ''    MsgBox("Enter Design", MsgBoxStyle.Critical)
                    ''    CMBDESIGN.Focus()
                    ''ElseIf Val(txtqty.Text.Trim) = 0 Then
                    ''    MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                    ''    txtqty.Focus()
                    ''ElseIf cmbqtyunit.Text.Trim = "" Then
                    ''    MsgBox("Enter Unit", MsgBoxStyle.Critical)
                    ''    cmbqtyunit.Focus()
                ElseIf Val(TXTMTRS.Text.Trim) = 0 Then
                    MsgBox("Enter Mtrs", MsgBoxStyle.Critical)
                    TXTMTRS.Focus()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(sender As Object, e As CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = CMBFROMGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDJO.Rows
                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                    Next

                    GRIDJO.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("LOTNO"), DTROWPS("BALENO"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
LINE1:
                Next
                getsrno(GRIDJO)
                'total()
                GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(sender As Object, e As EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                If CMBFROMGODOWN.Text.Trim = "" Then
        '                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
        '                    Exit Sub
        '                End If

        '                'GET DATA FROM BARCODE
        '                Dim OBJCMN As New ClsCommon
        '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    'VALIDATE GODOWN
        '                    If DT.Rows(0).Item("GODOWN") <> CMBFROMGODOWN.Text.Trim Then
        '                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
        '                        TXTBARCODE.Clear()
        '                        Exit Sub
        '                    End If

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '                    For Each ROW As DataGridViewRow In GRIDJO.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next


        '                    Dim PCS As Double = 0
        '                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

        '                    GRIDJO.Rows.Add(GRIDJO.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("LOTNO"), Format(Val(DT.Rows(0).Item("BALENO")), "0.00"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
        '                    total()
        '                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

        'LINE1:
        '                    TXTBARCODE.Clear()
        '                    'Else
        '                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
        '                    '    GoTo LINE1
        '                    '    Exit Sub
        '                End If
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(sender As Object, e As CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPGODOWNNO = Val(tstxtbillno.Text)
                If TEMPGODOWNNO > 0 Then
                    EDIT = True
                    InterGodownTransfer_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBFROMGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBFROMGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDJO.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next


                    Dim PCS As Double = 0
                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    GRIDJO.Rows.Add(GRIDJO.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("LOTNO"), Format(Val(DT.Rows(0).Item("BALENO")), "0.00"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
                    total()
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                    'Else
                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
                    '    GoTo LINE1
                    '    Exit Sub
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class