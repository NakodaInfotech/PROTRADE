
Imports System.ComponentModel
Imports BL

Public Class YarnRecdFromJobber

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public tempYARNno As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        CMBNAME.Enabled = True
        CMBNAME.Text = ""
        CMBPROCESS.Text = ""

        CMBYARNQUALITY.Text = ""
        CMBDESIGN.Text = ""
        CMBGODOWN.Text = ""
        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        CMBJONO.Text = ""
        CMBJONO.Enabled = True

        TXTBALWT.Clear()

        TXTLOTNO.Clear()
        txtPartyMtrs.Clear()
        dtpchallan.Value = Now.Date
        txtchallan.Clear()
        'txtpono.Clear()
        'podate.Value = now.date

        txtadd.Clear()
        YARNDATE.Text = Now.Date
        'RECDATE.Text = now.date

        cmbtrans.Text = ""

        txttransref.Clear()
        txttransremarks.Clear()

        txtremarks.Clear()


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

        txtsrno.Text = 1
        txtgridremarks.Clear()
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        cmbcolor.Text = ""
        TXTJOBBERLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        GRIDYARN.RowCount = 0
        cmbtrans.Text = ""

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
        YARNDATE.Focus()
    End Sub

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
        Try
            If YARNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
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
        Dim DTTABLE As DataTable = getmax(" isnull(max(YARN_no),0) + 1 ", "YARNRECDJOBBER", " and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Company Name ")
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

            If txtchallan.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txtchallan.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    DT = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(txtchallan, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
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
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(Format(dtpchallan.Value.Date, "MM/dd/yyyy"))

            alParaval.Add(cmbtrans.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBJONO.Text.Trim)
            alParaval.Add(TXTBALWT.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim JOBBERLOTNO As String = ""
            Dim COLOR As String = ""
            Dim LOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        JOBBERLOTNO = row.Cells(GJOBBERLOTNO.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value

                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        JOBBERLOTNO = JOBBERLOTNO & "|" & row.Cells(GJOBBERLOTNO.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)
            alParaval.Add(JOBBERLOTNO)
            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(qty)
            alParaval.Add(WT)
            alParaval.Add(CONES)




            Dim objclsGRN As New ClsYarnRecdFromJobber()
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
                alParaval.Add(tempYARNno)

                IntResult = objclsGRN.UPDATE()
                MsgBox("Details Updated")

            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            EDIT = False

            clear()
            YARNDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnRecdFromJobber


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(tempYARNno)
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
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDYARN.Focus()
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOB IN'")
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

                Dim objclsYARN As New ClsYarnRecdFromJobber()
                Dim dttable As New DataTable

                dttable = objclsYARN.selectYARN(tempYARNno, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYARNNO.Text = tempYARNno
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("YARNDATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("TONAME").ToString)
                        CMBNAME.Enabled = False
                        CMBPROCESS.Text = dr("PROCESS")
                        CMBJONO.Text = Convert.ToString(dr("JONO").ToString)
                        CMBJONO.Enabled = False

                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTLOTNO.Text = Convert.ToString(dr("LOTNO").ToString)
                        txtchallan.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = txtchallan.Text.Trim

                        dtpchallan.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        GRIDYARN.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGNNO").ToString, dr("JOBBERLOTNO"), dr("COLOR"), dr("LOTNO"), Format(Val(dr("qty")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("CONES")), "0"))

                    Next
                    total()
                Else
                    EDIT = False
                    clear()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECDJOBBER_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNRECDJOBBER_UPLOAD.YARN_REMARKS AS REMARKS, YARNRECDJOBBER_UPLOAD.YARN_NAME AS NAME, YARNRECDJOBBER_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNRECDJOBBER_UPLOAD ", " AND YARNRECDJOBBER_UPLOAD.YARN_NO = " & tempYARNno & " AND YARN_YEARID = " & YearId & " ORDER BY YARNRECDJOBBER_UPLOAD.YARN_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLDESIGN(CMBDESIGN, "")
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectGodown
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBGODOWN.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
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

            Dim objgrndetails As New YarnRecdFromJobberDetails()
            objgrndetails.MdiParent = MDIMain
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

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchallan.Validating
        Try
            If txtchallan.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txtchallan.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
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

    Private Sub dtpchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpchallan.Validating
        If Not datecheck(dtpchallan.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDYARN.RowCount = 0
                tempYARNno = Val(tstxtbillno.Text)
                If tempYARNno > 0 Then
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

        Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, TXTJOBBERLOTNO.Text.Trim, cmbcolor.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0"))
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim
            GRIDYARN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDYARN.Item(GJOBBERLOTNO.Index, TEMPROW).Value = TXTJOBBERLOTNO.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0")

            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        txtgridremarks.Clear()
        'CMBYARNQUALITY.Text = ""
        TXTJOBBERLOTNO.Clear()
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()

        txtPartyMtrs.Clear()
        txtCheckPcs.Clear()
        TXTBARCODE.Clear()
        txtsrno.Text = Val(GRIDYARN.RowCount) + 1
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
                TXTJOBBERLOTNO.Text = GRIDYARN.Item(GJOBBERLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                txtqty.Text = Val(GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value)
                TXTWT.Text = Val(GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value)
                TXTCONES.Text = Val(GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value)

                TEMPROW = GRIDYARN.CurrentRow.Index
                txtsrno.Focus()
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
            tempYARNno = Val(TXTYARNNO.Text) - 1
            If tempYARNno > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And tempYARNno > 1 Then
                TXTYARNNO.Text = tempYARNno
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
            tempYARNno = Val(TXTYARNNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTYARNNO.Text.Trim
            clear()
            If Val(TXTYARNNO.Text) - 1 >= tempYARNno Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And tempYARNno < MAXNO Then
                TXTYARNNO.Text = tempYARNno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTCONES.KeyPress
        numkeypress(e, sender, Me)
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
                    MsgBox("Unable to Delete, Checking Done / Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Delete Yarn?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTYARNNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsYarnRecdFromJobber()
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
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, "")
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
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

    Private Sub CMBMILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCONES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCONES.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class