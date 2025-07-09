
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class GreyRecdKnitting

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPGREYNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
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

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            'If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            'If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
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

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(GREY_NO),0) + 1 ", " GREYRECDKNITTING ", " AND GREY_cmpid=" & CmpId & " and GREY_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTGREYNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Fill Godown")
                bln = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Name")
                bln = False
            End If

            If GRIDGREY.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If GREYDATE.Text = "__/__/____" Then
                EP.SetError(GREYDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(GREYDATE.Text) Then
                    EP.SetError(GREYDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDGREY.Rows
                If ROW.Cells(GWT.Index).Value = 0 Then
                    EP.SetError(TXTWT, "WT Cannot be 0")
                    bln = False
                End If
            Next
            'If ALLOWMANUALJONO = True Then
            '    If TXTJONO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
            '        Dim OBJCMN As New ClsCommon
            '        Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBOUT.JO_NO,0)  AS JONO", "", " JOBOUT ", "  AND JOBOUT.JO_NO=" & TXTJONO.Text.Trim & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
            '        If dttable.Rows.Count > 0 Then
            '            EP.SetError(TXTJONO, "Job Out No Already Exist")
            '            bln = False
            '        End If
            '    End If
            'End If

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

            alParaval.Add(Format(Convert.ToDateTime(GREYDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)

            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(dtpchallan.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(lrdate.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim ROLLNO As String = ""
            Dim qty As String = ""
            Dim QTYUNIT As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDGREY.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString

                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        ROLLNO = row.Cells(GROLLNO.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        QTYUNIT = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        WT = row.Cells(GWT.Index).Value
                        RACK = row.Cells(GRACK.Index).Value.ToString
                        SHELF = row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTPCS = row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value


                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GROLLNO.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        QTYUNIT = QTYUNIT & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value
                        RACK = RACK & "|" & row.Cells(GRACK.Index).Value.ToString
                        SHELF = SHELF & "|" & row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(ROLLNO)
            alParaval.Add(qty)
            alParaval.Add(QTYUNIT)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)



            Dim objCUTTING As New ClsGreyRecdKnitting()
            objCUTTING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.SAVE()
                MsgBox("Details Added")
                TXTGREYNO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPGREYNO)
                IntResult = objCUTTING.UPDATE()
                MsgBox("Details Updated")

                If gridupload.RowCount > 0 Then SAVEUPLOAD()
                EDIT = False
            End If



            If EDIT = False Then
                If MsgBox("Issue Grey Directly to Jobber?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJISSUE As New YarnDirectIssueJobber
                    OBJISSUE.ShowDialog()
                    If OBJISSUE.CMBJOBBER.Text.Trim = "" Then GoTo LINE1
                    DIRECTISSUEJOBBER(OBJISSUE.CMBJOBBER.Text.Trim, OBJISSUE.CMBPROCESS.Text.Trim)
                End If
            End If
LINE1:

            clear()
            GREYDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DIRECTISSUEJOBBER(ByVal JOBBERNAME As String, PROCESSNAME As String)
        Try


            GRIDGREY.RowCount = 0
            Dim objJO As New ClsGreyRecdKnitting()
            Dim dttable As DataTable = objJO.selectGREY(TEMPGREYNO, CmpId, YearId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    GRIDGREY.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("DESIGNNO").ToString, dr("COLOR").ToString, dr("ROLLNO"), Format(dr("qty"), "0.00"), dr("UNIT").ToString, Format(dr("MTRS"), "0.00"), Format(dr("WT"), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), dr("DONE").ToString, dr("OUTPCS"), dr("OUTMTRS"))
                Next
            End If



            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(0)    'JONO
            ALPARAVAL.Add(Format(Convert.ToDateTime(GREYDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(cmbGodown.Text.Trim)
            ALPARAVAL.Add(JOBBERNAME)
            ALPARAVAL.Add(PROCESSNAME)
            ALPARAVAL.Add(cmbname.Text.Trim)   'PARTYNAME (add WEAVER NAME FOR KARAN)
            ALPARAVAL.Add("")   'LOTNO
            ALPARAVAL.Add(txtchallan.Text.Trim)
            ALPARAVAL.Add(cmbtrans.Text.Trim)
            ALPARAVAL.Add("")   'LRNO
            ALPARAVAL.Add(lrdate.Value)
            ALPARAVAL.Add("")   'VEHICLENO
            ALPARAVAL.Add("")   'FROMCITY
            ALPARAVAL.Add("")   'TOCITY
            ALPARAVAL.Add(JOBBERNAME)   'PACKING
            ALPARAVAL.Add("")   'EWAYBILLNO
            ALPARAVAL.Add(0)    'NOOFBALES
            ALPARAVAL.Add(Val(lbltotalqty.Text))
            ALPARAVAL.Add(Val(LBLTOTALMTRS.Text))
            ALPARAVAL.Add(Val(LBLTOTALWT.Text))
            ALPARAVAL.Add(0)    'RATE
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(0)    'CHKLOTREADY
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)




            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim DESCRIPTION As String = ""
            Dim CUT As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED

            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim FRAMES As String = ""
            Dim EMBPRODDONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDGREY.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = "FRESH"
                        If row.Cells(GROLLNO.Index).Value <> Nothing Then BALENO = row.Cells(GROLLNO.Index).Value.ToString Else BALENO = ""
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        DESCRIPTION = ""
                        CUT = 0
                        PCS = Val(row.Cells(gQty.Index).Value)
                        UNIT = row.Cells(gqtyunit.Index).Value
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        RATE = 0
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = 0
                        OUTMTRS = 0
                        FROMNO = Val(TXTGREYNO.Text.Trim)
                        FROMSRNO = Val(row.Cells(gsrno.Index).Value)
                        FROMTYPE = "KNITTING"
                        FRAMES = 0
                        EMBPRODDONE = 0

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & "FRESH"
                        If row.Cells(GROLLNO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GROLLNO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        DESCRIPTION = DESCRIPTION & "|" & ""
                        CUT = CUT & "|" & 0
                        PCS = PCS & "|" & Val(row.Cells(gQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        RATE = RATE & "|" & 0
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = OUTPCS & "|" & 0
                        OUTMTRS = OUTMTRS & "|" & 0
                        FROMNO = FROMNO & "|" & Val(TXTGREYNO.Text.Trim)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & "KNITTING"
                        FRAMES = FRAMES & "|" & 0
                        EMBPRODDONE = EMBPRODDONE & "|" & 0

                    End If
                End If
            Next

            ALPARAVAL.Add(gridsrno)
            ALPARAVAL.Add(PIECETYPE)
            ALPARAVAL.Add(BALENO)
            ALPARAVAL.Add(ITEMNAME)
            ALPARAVAL.Add(QUALITY)
            ALPARAVAL.Add(DESIGN)
            ALPARAVAL.Add(COLOR)
            ALPARAVAL.Add(DESCRIPTION)
            ALPARAVAL.Add(CUT)
            ALPARAVAL.Add(PCS)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(MTRS)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(BARCODE)
            ALPARAVAL.Add(OUTPCS)
            ALPARAVAL.Add(OUTMTRS)
            ALPARAVAL.Add(FROMNO)
            ALPARAVAL.Add(FROMSRNO)
            ALPARAVAL.Add(FROMTYPE)
            ALPARAVAL.Add(FRAMES)
            ALPARAVAL.Add(EMBPRODDONE)

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            ''Saving Upload Grid
            'For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
            '    If row.Cells(0).Value <> Nothing Then
            '        If griduploadsrno = "" Then
            '            griduploadsrno = row.Cells(0).Value.ToString
            '            uploadremarks = row.Cells(1).Value.ToString
            '            name = row.Cells(2).Value.ToString
            '            imgpath = row.Cells(3).Value.ToString
            '            NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

            '        Else
            '            griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
            '            uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
            '            name = name & "|" & row.Cells(2).Value.ToString
            '            imgpath = imgpath & "|" & row.Cells(3).Value.ToString
            '            NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

            '        End If
            '    End If
            'Next

            ALPARAVAL.Add(griduploadsrno)
            ALPARAVAL.Add(uploadremarks)
            ALPARAVAL.Add(name)
            ALPARAVAL.Add(imgpath)
            ALPARAVAL.Add(NEWIMGPATH)
            ALPARAVAL.Add(FILENAME)

            ALPARAVAL.Add("")   'JOTYPE
            ALPARAVAL.Add(0)    'JOYPENO

            Dim OBJYAARNISSUE As New ClsCuttingIssue
            OBJYAARNISSUE.alParaval = ALPARAVAL
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim DT As DataTable = OBJYAARNISSUE.SAVE()
            MsgBox("Grey Issued To Dyeing")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsGreyRecdKnitting


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPGREYNO)
                    'ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSoftCopy.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSoftCopy.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJBILL.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBILL.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal YARNNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Yarn Issue?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "JOBOUT"
                'OBJGDN.FORMULA = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
                OBJGDN.Show()
            End If

            'If ClientName = "KCRAYON" Then
            '    If MsgBox("Wish to Print Job Sheet?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '        Dim OBJJO As New JobOutDesign
            '        OBJJO.MdiParent = MDIMain
            '        OBJJO.FRMSTRING = "JOBSHEET"
            '        'OBJJO.WHERECLAUSE = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
            '        OBJJO.Show()
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then     'grid focus
            YarnRecd.Focus()
        End If
    End Sub

    Sub clear()
        EP.Clear()
        cmbname.Text = ""
        txtchallan.Clear()

        txtadd.Clear()
        GREYDATE.Text = Now.Date
        tstxtbillno.Clear()

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Now.Date
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.Image = Nothing
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0


        lbltotalqty.Text = 0.0
        LBLTOTALWT.Text = 0.0
        LBLTOTALMTRS.Text = 0.0

        txtsrno.Clear()

        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTROLLNO.Clear()
        TXTWT.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        CMBRACK.Text = ""
        CMBSHELF.Text = ""
        txtqty.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        GRIDGREY.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()

        If GRIDGREY.RowCount > 0 Then
            txtsrno.Text = Val(GRIDGREY.Rows(GRIDGREY.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If
    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDGREY.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGREYNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Grey Recd...?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsGreyRecdKnitting

                ALPARAVAL.Add(TEMPGREYNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Grey Recd Deleted Succesfully")
                clear()
                EDIT = False
                cmbname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Sub fillcmb()
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            fillunit(cmbqtyunit)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GreyRecdKnitting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
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

                Dim objJO As New ClsGreyRecdKnitting()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPGREYNO)
                ALPARAVAL.Add(CmpId)
                'ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.selectGREY(TEMPGREYNO, CmpId, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTGREYNO.Text = TEMPGREYNO
                        GREYDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)

                        txtchallan.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        dtpchallan.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)


                        GRIDGREY.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("DESIGNNO").ToString, dr("COLOR").ToString, dr("ROLLNO"), Format(dr("qty"), "0.00"), dr("UNIT").ToString, Format(dr("MTRS"), "0.00"), Format(dr("WT"), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), dr("DONE").ToString, dr("OUTPCS"), dr("OUTMTRS"))

                        If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTMTRS")) > 0 Then
                            GRIDGREY.Rows(GRIDGREY.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                    Next


                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" GREYRECDKNITTING_UPLOAD.GREY_SRNO AS GRIDSRNO, GREYRECDKNITTING_UPLOAD.GREY_REMARKS AS REMARKS, GREYRECDKNITTING_UPLOAD.GREY_NAME AS NAME, GREYRECDKNITTING_UPLOAD.GREY_PHOTO AS IMGPATH ", "", " GREYRECDKNITTING_UPLOAD ", " AND GREYRECDKNITTING_UPLOAD.GREY_NO = " & TEMPGREYNO & " AND GREY_YEARID = " & YearId & " ORDER BY GREYRECDKNITTING_UPLOAD.GREY_SRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    total()
                    GRIDGREY.FirstDisplayedScrollingRowIndex = GRIDGREY.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
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

    Private Sub GREYDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GREYDATE.GotFocus
        GREYDATE.SelectAll()
    End Sub

    Private Sub GREYDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GREYDATE.Validating
        Try
            If GREYDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(GREYDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGREY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGREY.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDGREY.CurrentRow.Index >= 0 And GRIDGREY.Item(gsrno.Index, GRIDGREY.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDGREY.Item(gsrno.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDGREY.Item(gitemname.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDGREY.Item(GQUALITY.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDGREY.Item(GDESIGN.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDGREY.Item(gcolor.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                TXTROLLNO.Text = GRIDGREY.Item(GROLLNO.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDGREY.Item(gQty.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDGREY.Item(gqtyunit.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDGREY.Item(GMTRS.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDGREY.Item(GWT.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDGREY.Item(GRACK.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDGREY.Item(GSHELF.Index, GRIDGREY.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDGREY.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSoftCopy.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUPLOAD()

        If GRIDUPLOADDOUBLECLICK = False Then
            gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSoftCopy.Image)
            getsrno(gridupload)
        ElseIf GRIDUPLOADDOUBLECLICK = True Then

            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSoftCopy.Image

            GRIDUPLOADDOUBLECLICK = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        txtuploadsrno.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSoftCopy.Image = Nothing
        txtimgpath.Clear()

        txtuploadremarks.Focus()

    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                txtuploadsrno.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSoftCopy.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSoftCopy.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GUSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDGREY.RowCount = 0
                TEMPGREYNO = Val(tstxtbillno.Text)
                If TEMPGREYNO > 0 Then
                    EDIT = True
                    GreyRecdKnitting_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
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
            GRIDGREY.RowCount = 0
LINE1:
            TEMPGREYNO = Val(TXTGREYNO.Text) - 1
            If TEMPGREYNO > 0 Then
                EDIT = True
                GreyRecdKnitting_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDGREY.RowCount = 0 And TEMPGREYNO > 1 Then
                TXTGREYNO.Text = TEMPGREYNO
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
            TEMPGREYNO = Val(TXTGREYNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTGREYNO.Text.Trim
            clear()
            If Val(TXTGREYNO.Text) - 1 >= TEMPGREYNO Then
                EDIT = True
                GreyRecdKnitting_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDGREY.RowCount = 0 And TEMPGREYNO < MAXNO Then
                TXTGREYNO.Text = TEMPGREYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        'Try
        '    If txtimgpath.Text.Trim <> "" Then
        '        If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
        '            System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
        '        Else
        '            Dim objVIEW As New ViewImage
        '            objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
        '            objVIEW.ShowDialog()
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSoftCopy.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGREY_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDGREY.CellValidating
        Try
            Dim colNum As Integer = GRIDGREY.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDGREY.CurrentCell.Value = Nothing Then GRIDGREY.CurrentCell.Value = "0.00"
                        GRIDGREY.CurrentCell.Value = Convert.ToDecimal(GRIDGREY.Item(colNum, e.RowIndex).Value)
                        '' everything is good
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

    Private Sub GRIDGREY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGREY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDGREY.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDGREY.Rows.RemoveAt(GRIDGREY.CurrentRow.Index)
                getsrno(GRIDGREY)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GUSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDGREY.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDGREY.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTROLLNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0)
                getsrno(GRIDGREY)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDGREY.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)

                GRIDGREY.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDGREY.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim

                GRIDGREY.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDGREY.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDGREY.Item(GROLLNO.Index, TEMPROW).Value = TXTROLLNO.Text.Trim

                GRIDGREY.Item(gQty.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
                GRIDGREY.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
                GRIDGREY.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDGREY.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
                GRIDGREY.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
                GRIDGREY.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            total()

            GRIDGREY.FirstDisplayedScrollingRowIndex = GRIDGREY.RowCount - 1

            txtsrno.Clear()
            'cmbitemname.Text = ""
            ' CMBQUALITY.Text = ""
            ' CMBDESIGN.Text = ""
            ' cmbcolor.Text = ""


            TXTWT.Clear()
            'TXTROLLNO.Clear()
            'txtqty.Clear()
            'cmbqtyunit.Text = ""
            TXTMTRS.Clear()

            CMBRACK.Text = ""
            CMBSHELF.Text = ""
            If GRIDGREY.RowCount > 0 Then
                txtsrno.Text = Val(GRIDGREY.Rows(GRIDGREY.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            TXTROLLNO.Text = Val(TXTROLLNO.Text.Trim) + 1
            cmbitemname.Focus()
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

            Dim OBJEMB As New GreyRecdKnittingDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
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

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcolor.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then cmbcolor.Text = OBJCOLOR.TEMPNAME
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

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.GotFocus
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                If GRIDDOUBLECLICK = False Then
                    If EDIT = True Then
                        'GET LAST BARCODE SRNO
                        Dim LSRNO As Integer = 0
                        Dim RSRNO As Integer = 0
                        Dim SNO As Integer = 0
                        LSRNO = InStr(GRIDGREY.Rows(GRIDGREY.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        RSRNO = InStr(LSRNO + 1, GRIDGREY.Rows(GRIDGREY.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        SNO = GRIDGREY.Rows(GRIDGREY.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                        TXTBARCODE.Text = "GRK-" & Val(TXTGREYNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                    Else
                        TXTBARCODE.Text = "GRK-" & Val(TXTGREYNO.Text.Trim) & "/" & GRIDGREY.RowCount + 1 & "/" & YearId
                    End If
                End If
                fillgrid()
            Else

                If cmbitemname.Text.Trim = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                    cmbitemname.Focus()
                ElseIf Val(txtqty.Text.Trim) = 0 Then
                    MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                    txtqty.Focus()
                ElseIf cmbqtyunit.Text.Trim = "" Then
                    MsgBox("Enter Unit", MsgBoxStyle.Critical)
                    cmbqtyunit.Focus()
                ElseIf Val(TXTWT.Text.Trim) = 0 Then
                    MsgBox("Enter Wt.", MsgBoxStyle.Critical)
                    TXTWT.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyRecdKnitting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "MARKIN" Then Me.Text = "Grey Recd From Jobber"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class