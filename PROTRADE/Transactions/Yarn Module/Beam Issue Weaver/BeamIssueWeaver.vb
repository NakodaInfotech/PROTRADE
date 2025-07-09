Imports BL

Public Class BeamIssueWeaver

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPUPLOADROW, PURREGID As Integer
    Public EDIT As Boolean
    Public TEMPBEAMISSUENO As Integer
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBOURGODOWN.Focus()
    End Sub

    Sub CLEAR()

        TXTSERIES.Clear()
        TXTISSUENO.Clear()
        DTISSUEDATE.Text = Mydate
        cmbname.Text = ""
        CMBOURGODOWN.Text = GETDEFAULTGODOWN()
        cmbtrans.Text = ""
        TXTVEHICALNO.Clear()
        TXTEWBNO.Clear()
        TXTREMARKS.Clear()

        EP.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False

        TXTREMARKS.Clear()

        CMBBEAMNAME.Text = ""
        CMBLOOMNO.Text = ""
        TXTSCHSRNO.Text = 1

        GRIDSCHEDULE.RowCount = 0
        GRIDBEAMISSUE.RowCount = 0

        GETMAX_BEAMISSUE_NO()
        LBLTOTALCUT.Text = 0.0
        LBLTOTALWT.Text = 0.0


        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        CMDSELECTBEAMSTOCK.Enabled = True

        TabControl1.SelectedIndex = 0

        PBSOFTCOPY.Image = Nothing
        TXTUPLOADSRNO.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0

        If gridupload.RowCount > 0 Then
            TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTUPLOADSRNO.Text = 1
        End If
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALWT.Text = 0.0
            LBLTOTALCUT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDBEAMISSUE.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALCUT.Text = Format(Val(LBLTOTALCUT.Text) + Val(ROW.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.000")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_BEAMISSUE_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax("ISNULL(MAX(BEAMISSUE_NO),0)+1", "BEAMISSUETOWEAVER", "AND BEAMISSUE_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)
        End If
        GETMAXSERIES(TXTSERIES)
    End Sub

    Private Sub BEAMISSUEWEAVER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for scheduling
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for ITEM DETAILS
                TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
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
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBOURGODOWN.Text.Trim = "" Then fillGODOWN(CMBOURGODOWN, EDIT, " AND GODOWN_ISOUR='TRUE'")
        If cmbtrans.Text = "" Then fillname(cmbtrans, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        FILLBEAM(CMBBEAMNAME, False)
    End Sub

    Private Sub BEAMISSUEWEAVER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            CMBOURGODOWN.Text = GETDEFAULTGODOWN()

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJBEAMISSUE As New ClsBeamIssueWeaver

                OBJBEAMISSUE.alParaval.Add(TEMPBEAMISSUENO)
                OBJBEAMISSUE.alParaval.Add(YearId)
                dttable = OBJBEAMISSUE.selectBEAMISSUE()

                If dttable.Rows.Count > 0 Then
                    cmbname.Focus()

                    TXTSERIES.Text = Val(dttable.Rows(0).Item("SERIES"))
                    TXTISSUENO.Text = TEMPBEAMISSUENO
                    DTISSUEDATE.Text = dttable.Rows(0).Item("ISSUEDATE")
                    CMBOURGODOWN.Text = dttable.Rows(0).Item("GODOWN").ToString
                    cmbname.Text = dttable.Rows(0).Item("NAME").ToString
                    cmbtrans.Text = dttable.Rows(0).Item("TRANSPORT").ToString
                    TXTVEHICALNO.Text = dttable.Rows(0).Item("VEHICALNO").ToString
                    TXTEWBNO.Text = dttable.Rows(0).Item("EWBNO").ToString
                    TXTREMARKS.Text = dttable.Rows(0).Item("REMARKS").ToString

                    'ITEM GRID
                    For Each ROW As DataRow In dttable.Rows
                        GRIDBEAMISSUE.Rows.Add(Val(ROW("SRNO")), ROW("BEAMNAME"), ROW("BEAMNO"), Val(ROW("ENDS")), Val(ROW("TAPLINE")), Format(Val(ROW("CUT")), "0.00"), Format(Val(ROW("WT")), "0.000"), Format(Val(ROW("WTCUT")), "0.000"), ROW("NARR"), Val(ROW("FROMNO")), Val(ROW("FROMSRNO")), ROW("TYPE"), ROW("OUTCUT"), ROW("DONE"), ROW("SIZERNAME"), ROW("LOOMNO"), ROW("UPLOADDATE"))

                        If Val(ROW("OUTCUT")) > 0 Or Convert.ToBoolean(ROW("DONE")) = True Then
                            GRIDBEAMISSUE.Rows(GRIDBEAMISSUE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        'ALLOW USER TO ADD NEW BEAMS ALSO
                        'If ROW("BEAMNAME") <> "" Then CMDSELECTBEAMSTOCK.Enabled = False
                    Next

                    'UPLOAD(GRID)
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_SRNO AS GRIDSRNO, BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_REMARKS AS REMARKS, BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_NAME AS NAME, BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_PHOTO AS IMGPATH ", "", " BEAMISSUETOWEAVER_UPLOAD ", " AND BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_NO = " & TEMPBEAMISSUENO & " AND BEAMISSUE_YEARID = " & YearId & " ORDER BY BEAMISSUETOWEAVER_UPLOAD.BEAMISSUE_SRNO")
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If


                    'SCHEDULE(GRID)
                    DT = OBJCMN.search(" BEAMMASTER.BEAM_NAME AS BEAMNAME, BEAMISSUETOWEAVER_SCHEDULE.BEAMISSUE_LOOMNO AS LOOMNO ", "", " BEAMISSUETOWEAVER_SCHEDULE INNER JOIN BEAMMASTER ON BEAMISSUETOWEAVER_SCHEDULE.BEAMISSUE_BEAMID = BEAMMASTER.BEAM_ID  ", " AND BEAMISSUETOWEAVER_SCHEDULE.BEAMISSUE_NO = " & TEMPBEAMISSUENO & " AND BEAMISSUETOWEAVER_SCHEDULE.BEAMISSUE_YEARID = " & YearId & " ORDER BY BEAMISSUETOWEAVER_SCHEDULE.BEAMISSUE_GRIDSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDSCHEDULE.Rows.Add(0, DTR("BEAMNAME"), Val(DTR("LOOMNO")))
                        Next
                        getsrno(GRIDSCHEDULE)
                    End If


                    TOTAL()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(DTISSUEDATE.Text.Trim).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBOURGODOWN.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(TXTVEHICALNO.Text.Trim)
            alParaval.Add(TXTEWBNO.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(LBLTOTALCUT.Text.Trim)
            alParaval.Add(LBLTOTALWT.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim SCHSRNO As String = ""
            Dim SCHBEAMNAME As String = ""
            Dim SCHLOOMNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSCHEDULE.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If SCHSRNO = "" Then
                        SCHSRNO = Val(row.Cells(GSCHSRNO.Index).Value)
                        SCHBEAMNAME = row.Cells(GSCHBEAMNAME.Index).Value.ToString
                        SCHLOOMNO = Val(row.Cells(GSCHLOOMNO.Index).Value.ToString)
                    Else

                        SCHSRNO = SCHSRNO & "|" & Val(row.Cells(GSCHSRNO.Index).Value)
                        SCHBEAMNAME = SCHBEAMNAME & "|" & row.Cells(GSCHBEAMNAME.Index).Value.ToString
                        SCHLOOMNO = SCHLOOMNO & "|" & Val(row.Cells(GSCHLOOMNO.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(SCHSRNO)
            alParaval.Add(SCHBEAMNAME)
            alParaval.Add(SCHLOOMNO)

            Dim SRNO As String = ""
            Dim BEAMNAME As String = ""
            Dim BEAMNO As String = ""
            Dim ENDS As String = ""
            Dim TL As String = ""
            Dim CUT As String = ""
            Dim WT As String = ""
            Dim WTCUT As String = ""
            Dim NARR As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim TYPE As String = ""
            Dim OUTCUT As String = ""
            Dim GRIDDONE As String = ""
            Dim SIZERNAME As String = ""
            Dim LOOMNO As String = ""
            Dim UPLOADDATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBEAMISSUE.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(row.Cells(gsrno.Index).Value)
                        BEAMNAME = row.Cells(GBEAMNAME.Index).Value.ToString
                        BEAMNO = row.Cells(GBEAMNO.Index).Value.ToString
                        ENDS = Val(row.Cells(GENDS.Index).Value)
                        TL = Val(row.Cells(GTAPLINE.Index).Value)
                        CUT = Format(Val(row.Cells(GCUT.Index).Value), "0.00")
                        WT = Format(Val(row.Cells(GWT.Index).Value), "0.000")
                        WTCUT = Format(Val(row.Cells(GWTCUT.Index).Value), "0.000")
                        If row.Cells(GNARR.Index).Value = Nothing Then NARR = "" Else NARR = row.Cells(GNARR.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        OUTCUT = Val(row.Cells(GOUTCUT.Index).Value)
                        If row.Cells(GDONE.Index).Value = True Then
                            GRIDDONE = 1
                        Else
                            GRIDDONE = 0
                        End If
                        SIZERNAME = row.Cells(GSIZERNAME.Index).Value
                        LOOMNO = Val(row.Cells(GLOOMNO.Index).Value)
                        If row.Cells(GUPLOADDATE.Index).Value.ToString <> "" Then UPLOADDATE = Format(Convert.ToDateTime(row.Cells(GUPLOADDATE.Index).Value).Date, "MM/dd/yyyy") Else UPLOADDATE = ""

                    Else

                        SRNO = SRNO & "|" & row.Cells(gsrno.Index).Value
                        BEAMNAME = BEAMNAME & "|" & row.Cells(GBEAMNAME.Index).Value.ToString
                        BEAMNO = BEAMNO & "|" & row.Cells(GBEAMNO.Index).Value.ToString
                        ENDS = ENDS & "|" & Val(row.Cells(GENDS.Index).Value)
                        TL = TL & "|" & Val(row.Cells(GTAPLINE.Index).Value)
                        CUT = CUT & "|" & Format(Val(row.Cells(GCUT.Index).Value), "0.00")
                        WT = WT & "|" & Format(Val(row.Cells(GWT.Index).Value), "0.000")
                        WTCUT = WTCUT & "|" & Format(Val(row.Cells(GWTCUT.Index).Value), "0.000")
                        If row.Cells(GNARR.Index).Value = Nothing Then NARR = NARR & "|" & "" Else NARR = NARR & "|" & row.Cells(GNARR.Index).Value
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value
                        OUTCUT = OUTCUT & "|" & Val(row.Cells(GOUTCUT.Index).Value)
                        If row.Cells(GDONE.Index).Value = True Then
                            GRIDDONE = GRIDDONE & "|" & "1"
                        Else
                            GRIDDONE = GRIDDONE & "|" & "0"
                        End If
                        SIZERNAME = SIZERNAME & "|" & row.Cells(GSIZERNAME.Index).Value
                        LOOMNO = LOOMNO & "|" & Val(row.Cells(GLOOMNO.Index).Value)
                        If row.Cells(GUPLOADDATE.Index).Value.ToString <> "" Then UPLOADDATE = UPLOADDATE & "|" & Format(Convert.ToDateTime(row.Cells(GUPLOADDATE.Index).Value).Date, "MM/dd/yyyy") Else UPLOADDATE = UPLOADDATE & "|" & ""
                    End If
                End If
            Next

            alParaval.Add(SRNO)
            alParaval.Add(BEAMNAME)
            alParaval.Add(BEAMNO)
            alParaval.Add(ENDS)
            alParaval.Add(TL)
            alParaval.Add(CUT)
            alParaval.Add(WT)
            alParaval.Add(WTCUT)
            alParaval.Add(NARR)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(TYPE)
            alParaval.Add(OUTCUT)
            alParaval.Add(GRIDDONE)
            alParaval.Add(SIZERNAME)
            alParaval.Add(LOOMNO)
            alParaval.Add(UPLOADDATE)


            Dim OBJBEAMISSUE As New ClsBeamIssueWeaver
            OBJBEAMISSUE.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJBEAMISSUE.SAVE()
                TEMPBEAMISSUENO = DT.Rows(0).Item(0)
                MsgBox("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBEAMISSUENO)
                IntResult = OBJBEAMISSUE.UPDATE()
                EDIT = False
                MsgBox("Details Updated")

            End If

            PRINTREPORT()
            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            'CLEAR()
            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            Call toolnext_Click(sender, e)
            DTISSUEDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBEAMISSUE As New ClsBeamIssueWeaver


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPBEAMISSUENO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJBEAMISSUE.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBEAMISSUE.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUPLOAD()

        If GRIDUPLOADDOUBLECLICK = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf GRIDUPLOADDOUBLECLICK = True Then

            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = TXTUPLOADSRNO.Text.Trim
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSOFTCOPY.Image

            GRIDUPLOADDOUBLECLICK = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Clear()
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If DTISSUEDATE.Text = "__/__/____" Then
            EP.SetError(DTISSUEDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTISSUEDATE.Text) Then
                EP.SetError(DTISSUEDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, "Please Fill Jobber Name")
            bln = False
        End If

        'NOT MANDATORY COZ WE CAN GET BEAMS FROM SIZER ALSO
        'IN THAT CASE GODOWN IS NOT MANDATORY
        'If CMBOURGODOWN.Text.Trim.Length = 0 Then
        '    EP.SetError(CMBOURGODOWN, " Please Fill Our Godown Name ")
        '    bln = False
        'End If

        If ClientName <> "SONU" Then
            If cmbtrans.Text.Trim.Length = 0 Then
                EP.SetError(cmbtrans, " Please Select Transport")
                bln = False
            End If
        End If

        'DONE TEMPORARILY
        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Unable to Modify, entry Locked")
        '    bln = False
        'End If

        If GRIDSCHEDULE.RowCount = 0 And ClientName = "SASHWINKUMAR" Then
            EP.SetError(cmbname, "Please Fill Schedule Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub DTISSUEDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTISSUEDATE.GotFocus
        DTISSUEDATE.Select(0, 0)
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

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'AND LEDGERS.ACC_TYPE= 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, cmbcode, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
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

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, cmbcode, e, Me, TXTADD, "AND GROUPMASTER.GROUP_SECONDARY='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS' ", "SUNDRY CREDITORS", "ACCOUNTS", "", "", "WARPER")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOURGODOWN.Enter
        Try
            If CMBOURGODOWN.Text.Trim = "" Then fillGODOWN(CMBOURGODOWN, EDIT, " AND GODOWN_ISOUR='TRUE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOURGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.SEARCH = " AND GODOWN_ISOUR = 'True'"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then CMBOURGODOWN.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOURGODOWN.Validating
        Try
            If CMBOURGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBOURGODOWN, e, Me, " AND GODOWN_ISOUR='TRUE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBEAMISSUE.RowCount = 0
LINE1:
            TEMPBEAMISSUENO = Val(TXTISSUENO.Text) - 1
Line2:
            If TEMPBEAMISSUENO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BEAMISSUE_NO ", "", "  BEAMISSUETOWEAVER", " AND BEAMISSUE_NO = '" & TEMPBEAMISSUENO & "' AND BEAMISSUETOWEAVER.BEAMISSUE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    BEAMISSUEWEAVER_Load(sender, e)
                Else
                    TEMPBEAMISSUENO = Val(TEMPBEAMISSUENO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If cmbname.Text = "" And TEMPBEAMISSUENO > 1 Then
                TXTISSUENO.Text = TEMPBEAMISSUENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBEAMISSUE.RowCount = 0
LINE1:
            TEMPBEAMISSUENO = Val(TXTISSUENO.Text) + 1
            GETMAX_BEAMISSUE_NO()
            Dim MAXNO As Integer = TXTISSUENO.Text.Trim
            CLEAR()
            If Val(TXTISSUENO.Text) - 1 >= TEMPBEAMISSUENO Then
                EDIT = True
                BEAMISSUEWEAVER_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDBEAMISSUE.RowCount = 0 And TEMPBEAMISSUENO < MAXNO Then
                TXTISSUENO.Text = TEMPBEAMISSUENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, tstxtbillno, Me)
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDBEAMISSUE.RowCount = 0
                TEMPBEAMISSUENO = Val(tstxtbillno.Text)
                If TEMPBEAMISSUENO > 0 Then
                    EDIT = True
                    BEAMISSUEWEAVER_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

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

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
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
                    MsgBox("Unable to Delete, Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Entry?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTISSUENO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim OBJDEL As New ClsBeamIssueWeaver
                    OBJDEL.alParaval = alParaval
                    IntResult = OBJDEL.Delete()
                    MsgBox("Entry Deleted")
                    CLEAR()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTBEAMSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTBEAMSTOCK.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDSCHEDULE.RowCount = 0 And ClientName = "SASHWINKUMAR" Then
                MsgBox("First Schedule Beams", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'IT IS NOT MANDATE TO SELECT GODOWN HERE,
            'IF USER SELECTS GODOWN THEN WE WILL ADD THAT IN WHERE CLAUE OR ELSE SHOW ALL BEAMS WHICH ARE PRESENT WITH SIZER OR INHOUSE BOTH


            'SHOW ONLY THOSE BEAMS IN STOCK WHICH WE HAVE SELECTED IN SCHEDULING
            Dim WHERECLAUSE As String = ""
            For Each ROW As DataGridViewRow In GRIDSCHEDULE.Rows
                If WHERECLAUSE = "" Then
                    WHERECLAUSE = " AND BEAMNAME IN ('" & ROW.Cells(GBEAMNAME.Index).Value & "'"
                Else
                    WHERECLAUSE = WHERECLAUSE & ",'" & ROW.Cells(GBEAMNAME.Index).Value & "'"
                End If
            Next
            If WHERECLAUSE <> "" Then WHERECLAUSE = WHERECLAUSE & ")"
            WHERECLAUSE = WHERECLAUSE & " AND DATE <= '" & Format(Convert.ToDateTime(DTISSUEDATE.Text).Date, "MM/dd/yyyy") & "'"


            Dim OBJSELECTSTOCK As New SelectBeamStock
            OBJSELECTSTOCK.TEMPGODOWNNAME = CMBOURGODOWN.Text.Trim
            Dim DTBEAMSTOCK As DataTable = OBJSELECTSTOCK.DT
            OBJSELECTSTOCK.WHERECLAUSE = WHERECLAUSE
            OBJSELECTSTOCK.ALLOWEDBEAMS = GRIDSCHEDULE.RowCount
            OBJSELECTSTOCK.ShowDialog()
            If DTBEAMSTOCK.Rows.Count > 0 Then

                'CHECK IF 1ST BEAM HAS 0 IN SRNO THEN CLEAR THE GRID
                'NEED TO CHECK WHETHER ANY ROW IS PRESENT OR NOT ELSE IT GIVES ERROR
                If GRIDBEAMISSUE.RowCount <> 0 Then
                    If Val(GRIDBEAMISSUE.Rows(0).Cells(gsrno.Index).Value) = 0 Then GRIDBEAMISSUE.RowCount = 0
                End If

                For Each ROW As DataRow In DTBEAMSTOCK.Rows
                    GRIDBEAMISSUE.Rows.Add(0, ROW("BEAMNAME"), ROW("BEAMNO"), Val(ROW("ENDS")), Val(ROW("TAPLINE")), Format(Val(ROW("CUT")), "0.00"), Format(Val(ROW("WT")), "0.000"), Format(Val(ROW("WTCUT")), "0.000"), "", Val(ROW("FROMNO")), Val(ROW("FROMSRNO")), ROW("TYPE"), 0, 0, ROW("SIZERNAME"), 0, "")
                Next
                TOTAL()
                getsrno(GRIDBEAMISSUE)
                CMDSELECTBEAMSTOCK.Enabled = False
            End If

            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBEAMISSUE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBEAMISSUE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBEAMISSUE.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDBEAMISSUE.Rows.RemoveAt(GRIDBEAMISSUE.CurrentRow.Index)
                getsrno(GRIDBEAMISSUE)
                TOTAL()

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJBEAM As New BeamIssueWeaverDetails
            OBJBEAM.MdiParent = MDIMain
            OBJBEAM.Show()
        Catch EX As Exception
            Throw EX
        End Try
    End Sub

    Private Sub DTISSUEDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTISSUEDATE.Validating
        Try
            If DTISSUEDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTISSUEDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBEAMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBEAMNAME.Enter
        Try
            If CMBBEAMNAME.Text.Trim <> "" Then FILLBEAM(CMBBEAMNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBEAMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBEAMNAME.Validating
        Try
            If CMBBEAMNAME.Text.Trim <> "" Then BEAMVALIDATE(CMBBEAMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOOMNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBLOOMNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDSCHEDULE.Rows.Add(0, CMBBEAMNAME.Text.Trim, Val(CMBLOOMNO.Text.Trim))
            Else
                GRIDSCHEDULE.Item(GSCHBEAMNAME.Index, TEMPROW).Value = CMBBEAMNAME.Text.Trim
                GRIDSCHEDULE.Item(GSCHLOOMNO.Index, TEMPROW).Value = Val(CMBLOOMNO.Text.Trim)
                GRIDDOUBLECLICK = False
                TEMPROW = 0
            End If
            CMBBEAMNAME.Text = ""
            CMBLOOMNO.Text = ""
            getsrno(GRIDSCHEDULE)
            CMBBEAMNAME.Focus()
            If GRIDSCHEDULE.RowCount > 0 Then TXTSCHSRNO.Text = Val(GRIDSCHEDULE.RowCount) + 1 Else TXTSCHSRNO.Text = 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSCHEDULE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSCHEDULE.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDSCHEDULE.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSCHSRNO.Text = GRIDSCHEDULE.Item(GSCHSRNO.Index, e.RowIndex).Value
                CMBBEAMNAME.Text = GRIDSCHEDULE.Item(GSCHBEAMNAME.Index, e.RowIndex).Value
                CMBLOOMNO.Text = GRIDSCHEDULE.Item(GSCHLOOMNO.Index, e.RowIndex).Value

                TEMPROW = e.RowIndex
                CMBBEAMNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSCHEDULE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSCHEDULE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSCHEDULE.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSCHEDULE.Rows.RemoveAt(GRIDSCHEDULE.CurrentRow.Index)
                getsrno(GRIDSCHEDULE)
                TXTSCHSRNO.Text = GRIDSCHEDULE.RowCount + 1
                TOTAL()

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBLOOMNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLOOMNO.Enter
        Try
            If cmbname.Text.Trim <> "" And CMBLOOMNO.Text.Trim = "" Then FILLLOOMNO(CMBLOOMNO, cmbname.Text.Trim, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOOMNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLOOMNO.Validated
        Try
            If CMBBEAMNAME.Text.Trim <> "" And Val(CMBLOOMNO.Text.Trim) > 0 Then FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOOMNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOOMNO.Validating
        Try
            If cmbname.Text.Trim <> "" And CMBLOOMNO.Text.Trim <> "" Then LOOMVALIDATE(CMBLOOMNO, cmbname.Text.Trim, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish To Print Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJYARNISSUE As New BeamIssueDesign
            OBJYARNISSUE.MdiParent = MDIMain
            '   If Val(LBLTOTALCUT.Text) > 0 Then OBJYARNISSUE.FRMSTRING = "BEAMISSUEBEAMNO" Else OBJYARNISSUE.FRMSTRING = "BEAMISSUE"
            OBJYARNISSUE.WHERECLAUSE = "{BEAMISSUETOWEAVER.BEAMISSUE_NO} = " & TEMPBEAMISSUENO & " AND {BEAMISSUETOWEAVER.BEAMISSUE_YEARID} = " & YearId
            OBJYARNISSUE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT()
    End Sub

    Private Sub BeamIssue_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ALLOWMFG = False Then Exit Sub
    End Sub

    Private Sub TXTISSUE_Validated(sender As Object, e As EventArgs) Handles TXTISSUE.Validated
        Try
            If Val(TXTISSUE.Text.Trim) > 0 Then
                GRIDBEAMISSUE.RowCount = 0
                TEMPBEAMISSUENO = Val(TXTISSUE.Text)
                'If TEMPSONO > 0 Then
                '    EDIT = True
                '    SALEORDER_Load(sender, e)
                'Else
                '    CLEAR()
                '    EDIT = False
                'End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class