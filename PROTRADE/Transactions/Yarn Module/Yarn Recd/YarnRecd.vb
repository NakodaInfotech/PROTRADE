
Imports System.ComponentModel
Imports BL

Public Class YarnRecd

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPYARNNO As Integer     'used for poation no while editing
    Public temptypename As String 'used for poation no while editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING, TYPE As String
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""

        CMBYARNQUALITY.Text = ""
        CMBDESIGN.Text = ""
        cmbGodown.Text = ""
        TXTGRIDLOTNO.Clear()
        txtPartyMtrs.Clear()
        txtPartyMtrs.Clear()
        CHALLANDATE.Text = Now.Date
        TXTCHALLANNO.Clear()
        txtpono.Clear()
        podate.Value = Now.Date

        txtadd.Clear()
        YARNDATE.Text = Now.Date

        cmbtrans.Text = ""

        txttransref.Clear()
        txttransremarks.Clear()

        txtremarks.Clear()
        TXTGODOWNNO.Clear()
        TXTGODOWNRECDATE.Text = Now.Date
        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.Image = Nothing
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0



        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos
        txtsrno.Text = 1
        txtgridremarks.Clear()
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""

        cmbcolor.Text = ""
        TXTLRNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        LRDATE.Text = Now.Date
        TXTNARRATION.Clear()
        GRIDYARN.RowCount = 0
        GRIDORDER.RowCount = 0

        cmdselectPO.Enabled = True
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        getmaxno()


        LBLTOTALCONES.Text = 0
        lbltotalqty.Text = 0
        LBLTOTALWT.Text = 0

    End Sub

    Sub total()
        Try
            LBLTOTALCONES.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDYARN.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0.00")
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

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
        Try
            If YARNDATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YARNDATE.Text, TEMP) Then
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
        Dim DTTABLE As DataTable = getmax(" isnull(max(YARN_no),0) + 1 ", "YARNRECD", "  and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYARNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Fill Godown Name ")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            'coz if it it other item type then mtrs will be blank
            'if want to enable then check for materialtype
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    DT = objclscommon.search(" YARNRECD.YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNRECD inner join LEDGERS on LEDGERS.ACC_id = YARNRECD.YARN_ledgerid ", " and YARNRECD.YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND YARNRECD.YARN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(ORECDBAGS.Index).Value = 0
                    ORDROW.Cells(ORECDWT.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                txtpono.Clear()
                For Each a As String In MULTISONO
                    If txtpono.Text = "" Then
                        txtpono.Text = a
                    Else
                        txtpono.Text = txtpono.Text & "," & a
                    End If
                Next

                For Each ROW As DataGridViewRow In GRIDYARN.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(GYARNQUALITY.Index).Value = ORDROW.Cells(OYARNQUALITY.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(ORECDWT.Index).Value) >= Val(ORDROW.Cells(OWT.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If
                            ORDROW.Cells(ORECDBAGS.Index).Value = Val(ORDROW.Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                            ORDROW.Cells(ORECDWT.Index).Value = Val(ORDROW.Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                            bln = False
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next
            End If


            If YARNDATE.Text = "__/__/____" Then
                EP.SetError(YARNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YARNDATE.Text) Then
                    EP.SetError(YARNDATE, "Date not in Accounting Year")
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

            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)

            alParaval.Add("")   'TONAME
            ' alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy")) 'RECDDATE
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(Format(podate.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(cmbtrans.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTGODOWNNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(TXTGODOWNRECDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim GRIDLOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim LRNO As String = ""
            Dim LRDATE As String = ""
            Dim NARRATION As String = ""
            Dim DONE As String = ""
            Dim PONO As String = ""
            Dim POGRIDSRNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        GRIDLOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0
                        PONO = Val(row.Cells(GPONO.Index).Value)
                        POGRIDSRNO = Val(row.Cells(GGRIDSRNO.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        GRIDLOTNO = GRIDLOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then DONE = DONE & "|" & "1" Else DONE = DONE & "|" & "0"
                        PONO = PONO & "|" & Val(row.Cells(GPONO.Index).Value)
                        POGRIDSRNO = POGRIDSRNO & "|" & Val(row.Cells(GGRIDSRNO.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(GRIDLOTNO)
            alParaval.Add(qty)
            alParaval.Add(WT)
            alParaval.Add(CONES)
            alParaval.Add(LRNO)
            alParaval.Add(LRDATE)
            alParaval.Add(NARRATION)
            alParaval.Add(DONE)
            alParaval.Add(PONO)
            alParaval.Add(POGRIDSRNO)


            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERYARNQUALITY As String = ""
            Dim ORDERDESIGN As String = ""
            Dim ORDERCOLOR As String = ""
            Dim ORDERBAGS As String = ""
            Dim ORDERWT As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERRECDBAGS As String = ""
            Dim ORDERRECDWT As String = ""
            Dim ORDERRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(ORECDBAGS.Index).Value) > 0 Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERDESIGN = row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = ORDERYARNQUALITY & "|" & row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERDESIGN = ORDERDESIGN & "|" & row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = ORDERCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = ORDERBAGS & "|" & Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = ORDERWT & "|" & Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = ORDERRECDBAGS & "|" & Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = ORDERRECDWT & "|" & Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERYARNQUALITY)
            alParaval.Add(ORDERDESIGN)
            alParaval.Add(ORDERCOLOR)
            alParaval.Add(ORDERBAGS)
            alParaval.Add(ORDERWT)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERRECDBAGS)
            alParaval.Add(ORDERRECDWT)
            alParaval.Add(ORDERRATE)


            Dim objclsGRN As New ClsYarnRecd()
            objclsGRN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
                MsgBox("Details Added")


            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPYARNNO)

                IntResult = objclsGRN.UPDATE()
                MsgBox("Details Updated")

            End If
            PRINTREPORT(Val(TXTYARNNO.Text.Trim))


            'DIRECTLY ISSUE TO YARNISSUE
            If EDIT = False Then
                If MsgBox("Issue Yarn Directly to Jobber?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJISSUE As New YarnDirectIssueJobber
                    OBJISSUE.ShowDialog()
                    If OBJISSUE.CMBJOBBER.Text.Trim = "" Then GoTo LINE1
                    DIRECTISSUEJOBBER(OBJISSUE.CMBJOBBER.Text.Trim, OBJISSUE.CMBPROCESS.Text.Trim, OBJISSUE.txtremarks.Text.Trim)
                End If
            End If


LINE1:
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            EDIT = False

            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DIRECTISSUEJOBBER(ByVal JOBBERNAME As String, PROCESSNAME As String, REMARKS As String)
        Try
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(cmbGodown.Text.Trim)
            ALPARAVAL.Add(JOBBERNAME)
            ALPARAVAL.Add("")   'MACHINENO
            ALPARAVAL.Add(PROCESSNAME)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)

            ALPARAVAL.Add(cmbtrans.Text.Trim)

            ALPARAVAL.Add(Val(lbltotalqty.Text))
            ALPARAVAL.Add(Val(LBLTOTALWT.Text))
            ALPARAVAL.Add(Val(LBLTOTALCONES.Text))

            ALPARAVAL.Add(REMARKS)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim LOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim LRNO As String = ""
            Dim LRDATE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = row.Cells(GQTY.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value
                        CONES = row.Cells(GCONES.Index).Value.ToString
                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value

                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & row.Cells(GQTY.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value

                        CONES = CONES & "|" & row.Cells(GCONES.Index).Value
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy")
                    End If
                End If
            Next

            ALPARAVAL.Add(gridsrno)
            ALPARAVAL.Add(YARNQUALITY)
            ALPARAVAL.Add(MILLNAME)
            ALPARAVAL.Add(DESIGN)

            ALPARAVAL.Add(COLOR)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(qty)
            ALPARAVAL.Add(WT)

            ALPARAVAL.Add(CONES)
            ALPARAVAL.Add(LRNO)
            ALPARAVAL.Add(LRDATE)


            Dim OBJYAARNISSUE As New ClsYarnIssue
            OBJYAARNISSUE.alParaval = ALPARAVAL
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim DT As DataTable = OBJYAARNISSUE.SAVE()
            MsgBox("Yarn Issued To Dyeing")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnRecd


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPYARNNO)
                    'ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSoftCopy.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSoftCopy.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(FRMSTRING)

                    OBJBILL.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBILL.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDYARN.Focus()
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()
            ''  If TYPE = "" Then TYPE = "FINISH"

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsYARN As New ClsYarnRecd()
                Dim dttable As New DataTable

                dttable = objclsYARN.selectYARN(TEMPYARNNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        ''Me.Text = "Yarn Recd (" & dr("GREYFINISH") & ")"

                        TXTYARNNO.Text = TEMPYARNNO
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("YARNDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        TXTGODOWNNO.Text = Convert.ToString(dr("GODOWNNO")).ToString
                        TXTGODOWNRECDATE.Text = Format(Convert.ToDateTime(dr("GODOWNDATE")).Date, "dd/MM/yyyy")
                        CHALLANDATE.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        ''  TXTGODOWNRECDATE.Text =
                        CHALLANDATE.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        podate.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        GRIDYARN.Rows.Add(Val(dr("GRIDSRNO")), dr("YARNNAME"), dr("MILLNAME"), dr("DESIGNNO"), dr("COLORNAME"), dr("GRIDLOTNO"), Format(Val(dr("QTY")), "0.00"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0.00"), dr("LRNO"), Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy"), dr("NARRATION").ToString, dr("GRIDDONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDPONO").ToString, dr("POGRIDSRNO").ToString)

                    Next
                    total()
                    Validate()
                Else
                    EDIT = False
                    clear()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECD_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNRECD_UPLOAD.YARN_REMARKS AS REMARKS, YARNRECD_UPLOAD.YARN_NAME AS NAME, YARNRECD_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNRECD_UPLOAD ", " AND YARNRECD_UPLOAD.YARN_NO = " & TEMPYARNNO & " AND YARN_YEARID = " & YearId & " ORDER BY YARNRECD_UPLOAD.YARN_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If

                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECD_PODETAILS.YARN_GRIDSRNO AS GRIDSRNO, YARNQUALITYMASTER.YARN_name AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, YARNRECD_PODETAILS.YARN_ORDERBAGS AS ORDERBAGS, ISNULL(YARNRECD_PODETAILS.YARN_ORDERWT,0) AS ORDERWT, YARNRECD_PODETAILS.YARN_FROMNO AS FROMNO, YARNRECD_PODETAILS.YARN_FROMSRNO AS FROMSRNO, YARNRECD_PODETAILS.YARN_FROMTYPE AS FROMTYPE, YARNRECD_PODETAILS.YARN_BAGS AS RECDBAGS, ISNULL(YARNRECD_PODETAILS.YARN_WT,0) AS RECDWT, ISNULL(YARNRECD_PODETAILS.YARN_RATE,0) AS RATE ", "", " YARNRECD_PODETAILS INNER JOIN YARNQUALITYMASTER ON YARNRECD_PODETAILS.YARN_YARNQUALITYID= YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN COLORMASTER ON YARNRECD_PODETAILS.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON YARNRECD_PODETAILS.YARN_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND YARNRECD_PODETAILS.YARN_NO = " & TEMPYARNNO & " AND YARNRECD_PODETAILS.YARN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("YARNQUALITY"), DTR("DESIGNNO"), DTR("COLOR"), Val(DTR("ORDERBAGS")), Val(DTR("ORDERWT")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("RECDBAGS")), Val(DTR("RECDWT")), Val(DTR("RATE")))
                    Next
                End If
                getsrno(GRIDORDER)

                If txtpono.Text.Trim.Trim.Length = 0 Then
                    cmdselectPO.Enabled = False
                    cmbname.Enabled = True
                Else
                    cmdselectPO.Enabled = True
                    cmbname.Enabled = False
                End If

                chkchange.CheckState = CheckState.Checked
            End If

            If GRIDYARN.RowCount > 0 Then
                txtsrno.Text = Val(GRIDYARN.Rows(GRIDYARN.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBCODE.Text.Trim = "" Then fillACCCODE(CMBCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBTOCODE.Text.Trim = "" Then fillACCCODE(CMBTOCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")

            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLDESIGN(CMBDESIGN, "")
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGodown.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectGodown
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbGodown.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
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

            Dim objgrndetails As New YarnRecdDetails
            objgrndetails.MdiParent = MDIMain
            'objgrndetails.FRMSTRING = FRMSTRING
            'objgrndetails.TYPE = TYPE
            objgrndetails.Show()
            objgrndetails.BringToFront()
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectPO.Click
        Try
            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJSELECTPO As New SelectYarnPO
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.FRMSTRING = TYPE
            OBJSELECTPO.ShowDialog()
            DTPO = OBJSELECTPO.DT

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If txtpono.Text.Trim = "" Then
                        txtpono.Text = DTR("PONO").ToString
                    Else
                        txtpono.Text = txtpono.Text & "," & DTR("PONO").ToString
                    End If
                Next

                fillledger(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = '" & DTPO.Rows(0).Item("GROUPNAME") & "' ")
                cmbname.Text = DTPO.Rows(0).Item("NAME")
                podate.Value = DTPO.Rows(0).Item("PODATE")
                txtpono.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    GRIDORDER.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("DESIGNNO"), DTROW("COLOR"), Val(DTROW("BAGS")), Val(DTROW("WT")), DTROW("PONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))
NEXTLINE:
                Next
                getsrno(GRIDORDER)

            End If

            cmdselectPO.Enabled = True
            total()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDYARN.RowCount = 0
                TEMPYARNNO = Val(tstxtbillno.Text)
                If TEMPYARNNO > 0 Then
                    EDIT = True
                    GRN_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDYARN.Enabled = True
        'GULKIT HAS REMOVED THIS CODE
        'If ClientName <> "VAISHALI" Then TXTGRIDLOTNO.Text = TXTLOTNO.Text.Trim

        Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTGRIDLOTNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0.00"), TXTLRNO.Text.Trim, Format(Convert.ToDateTime(LRDATE.Text).Date, "dd/MM/yyyy"), TXTNARRATION.Text.Trim, 0, 0, 0, 0, 0)
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim

            GRIDYARN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTGRIDLOTNO.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")

            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0.00")
            GRIDYARN.Item(GLRNO.Index, TEMPROW).Value = TXTLRNO.Text.Trim
            GRIDYARN.Item(GLRDATE.Index, TEMPROW).Value = Format(Convert.ToDateTime(LRDATE.Text).Date, "dd/MM/yyyy")
            GRIDYARN.Item(GNARRATION.Index, TEMPROW).Value = TXTNARRATION.Text.Trim

            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        txtgridremarks.Clear()
        If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTGRIDLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        LRDATE.Text = Now.Date
        TXTNARRATION.Clear()

        txtPartyMtrs.Clear()
        txtCheckPcs.Clear()
        TXTBARCODE.Clear()
        txtsrno.Text = Val(GRIDYARN.Rows(GRIDYARN.RowCount - 1).Cells(0).Value) + 1
        CMBYARNQUALITY.Focus()


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

    Sub EDITROW()
        Try
            If GRIDYARN.CurrentRow.Index >= 0 And GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDYARN.Item(GYARNQUALITY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDYARN.Item(GMILLNAME.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                CMBDESIGN.Text = GRIDYARN.Item(GDESIGN.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTGRIDLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTCONES.Text = GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLRNO.Text = GRIDYARN.Item(GLRNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                LRDATE.Text = GRIDYARN.Item(GLRDATE.Index, GRIDYARN.CurrentRow.Index).Value
                TXTNARRATION.Text = GRIDYARN.Item(GNARRATION.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDYARN.CurrentRow.Index
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            GRIDYARN.RowCount = 0
LINE1:
            '' temptypename = FRMSTRING
            TEMPYARNNO = Val(TXTYARNNO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO > 1 Then
                TXTYARNNO.Text = TEMPYARNNO
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
            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) + 1
            ''temptypename = FRMSTRING
            getmaxno()
            Dim MAXNO As Integer = TXTYARNNO.Text.Trim
            clear()
            If Val(TXTYARNNO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub podate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles podate.Validating
        If Not datecheck(podate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
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
                    MsgBox("Unable to Delete, Checking Done / Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTYARNNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsYarnRecd()
                    Clsgrn.alParaval = alParaval
                    IntResult = Clsgrn.Delete()
                    MsgBox("Yarn Deleted")
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

    Private Sub gridgrn_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
        Try

            Dim colNum As Integer = GRIDYARN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index, GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDYARN.CurrentCell.Value = Nothing Then GRIDYARN.CurrentCell.Value = "0.00"
                        GRIDYARN.CurrentCell.Value = Convert.ToDecimal(GRIDYARN.Item(colNum, e.RowIndex).Value)
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

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDYARN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDYARN.RowCount > 0 Then
                'If gridgrn.CurrentRow.Cells(gitemname.Index).Value <> "" Then
                '    gridgrn.Rows.Add(CloneWithValues(gridgrn.CurrentRow))
                '    getsrno(gridgrn)
                '    total()
                'End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, CMBBROKER.Text)
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, "")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Validated
        Try
            If CMBYARNQUALITY.Text = "" Then cmdok.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPYARNNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtPartyMtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartyMtrs.Validated
        If Val(TXTLRNO.Text) <> 0 And Val(txtPartyMtrs.Text) <> 0 Then
            txtCheckPcs.Text = Format(Val(TXTLRNO.Text) - Val(txtPartyMtrs.Text), "0.00")
        End If
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLRNO.Validating
        If Val(TXTLRNO.Text) > 0 Then
            txtPartyMtrs.Text = Val(TXTLRNO.Text)
        End If
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then fillACCCODE(CMBCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBCODE, cmbname, e, Me, TXTTRANSADD, "", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLOTNO.Validating
        Try
            If TXTLOTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(YARN_NO,0) AS YARNRECDNO ", "", " YARNRECD INNER JOIN LEDGERS ON YARN_LEDGERID = ACC_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND YARN_PLOTNO = '" & TXTLOTNO.Text.Trim & "' AND YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If (EDIT = False) Or (EDIT = True And Val(DT.Rows(0).Item(0)) <> Val(TXTYARNNO.Text.Trim)) Then
                        MsgBox("Lot No Already Exists in Inward No " & Val(DT.Rows(0).Item("YARNRECDNO")), MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me)
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
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
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

    Sub PRINTREPORT(ByVal INVOICENO As Integer)
        Try
            If MsgBox("Wish To Print?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJGRN As New YarnDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "YARNRECD"
                OBJGRN.WHERECLAUSE = " {YARNRECD.YARN_NO}= " & INVOICENO & "  AND {YARNRECD.YARN_YEARID}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "VAISHALI" Then
                TXTLOTNO.Visible = False
                ''  LBLLOTNO.Visible = False
            Else
                TXTGRIDLOTNO.TabStop = True
                TXTGRIDLOTNO.ReadOnly = False
                TXTGRIDLOTNO.BackColor = Color.White
            End If



            ''Me.Text = "Yarn Recd (" & TYPE & ")"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub CMBMILL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then FILLMILL(CMBMILL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPSHADE_Validated(sender As Object, e As EventArgs)
        Try
            If cmbname.Text.Trim <> "" And cmbcolor.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.search(" ISNULL(COLORMASTER.COLOR_NAME,'') AS COLOR", "", "COLORTAGGING INNER JOIN COLORMASTER ON COLORTAGGING.TAG_COLORID = COLORMASTER.COLOR_ID INNER JOIN LEDGERS ON LEDGERS.Acc_id = COLORTAGGING.TAG_LEDGERID ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND COLORTAGGING.TAG_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then cmbcolor.Text = dt.Rows(0).Item("COLOR")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_Validated(sender As Object, e As EventArgs) Handles TXTCONES.Validated
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM MILLMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(TXTCONES.Text.Trim) <> 0 And CMBMILL.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(MILL_REMARK,0) AS CONEWT", "", "MILLMASTER ", " AND MILL_NAME = '" & CMBMILL.Text.Trim & "' AND MILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(TXTCONES.Text.Trim) * Val(DT.Rows(0).Item("CONEWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCONES_Click(sender As Object, e As EventArgs) Handles CMDCONES.Click
        'Try
        '    '' Dim OBJCONES As New pendingConeDetails
        '    OBJCONES.MdiParent = MDIMain
        '    OBJCONES.Show()
        'Catch ex As Exception
        '    Throw ex
        '' End Try
    End Sub

    Private Sub DTLRDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                'If ClientName <> "VAISHALI" Then TXTGRIDLOTNO.Text = TXTLOTNO.Text.Trim

                'check whether same quality and shade is present in grid or not
                If ClientName = "VAISHALI" And cmbcolor.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDYARN.Rows
                        If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And ROW.Index <> TEMPROW) Then
                            If ROW.Cells(GYARNQUALITY.Index).Value = CMBYARNQUALITY.Text.Trim And ROW.Cells(gcolor.Index).Value = cmbcolor.Text.Trim Then
                                If MsgBox("Quality with same Shade already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                            End If
                        End If
                    Next
                End If

                fillgrid()
            ElseIf CMBYARNQUALITY.Text.Trim = "" Then
                MsgBox("Enter Yarn Quality Name", MsgBoxStyle.Critical)
                CMBYARNQUALITY.Focus()
                Exit Sub
            ElseIf Val(TXTWT.Text.Trim) <= 0 Then
                MsgBox("Enter Weight", MsgBoxStyle.Critical)
                TXTWT.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCONES.KeyPress
        numkeypress(e, TXTCONES, Me)
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
    End Sub

    Private Sub CHALLANDATE_Validating(sender As Object, e As CancelEventArgs) Handles CHALLANDATE.Validating
        Try
            If CHALLANDATE.Text.Trim <> "__/__/____" Then
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

    Private Sub TXTNARRATION_Validating(sender As Object, e As CancelEventArgs) Handles TXTNARRATION.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                'If ClientName <> "VAISHALI" Then TXTGRIDLOTNO.Text = TXTLOTNO.Text.Trim

                'check whether same quality and shade is present in grid or not
                If ClientName = "VAISHALI" And cmbcolor.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDYARN.Rows
                        If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And ROW.Index <> TEMPROW) Then
                            If ROW.Cells(GYARNQUALITY.Index).Value = CMBYARNQUALITY.Text.Trim And ROW.Cells(gcolor.Index).Value = cmbcolor.Text.Trim Then
                                If MsgBox("Quality with same Shade already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                            End If
                        End If
                    Next
                End If

                fillgrid()
            ElseIf CMBYARNQUALITY.Text.Trim = "" Then
                MsgBox("Enter Yarn Quality Name", MsgBoxStyle.Critical)
                CMBYARNQUALITY.Focus()
                Exit Sub
            ElseIf Val(TXTWT.Text.Trim) <= 0 Then
                MsgBox("Enter Weight", MsgBoxStyle.Critical)
                TXTWT.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class