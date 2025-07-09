
Imports BL

Public Class YarnWastage

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPUPLOADROW As Integer
    Public EDIT As Boolean
    Public TEMPWASTAGENO As Integer
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBOURGODOWN.Focus()
    End Sub

    Sub CLEAR()

        DTENTRYDATE.Text = Now.Date
        CMBNAME.Text = ""
        txtremarks.Clear()

        LBLTOTALWT.Text = 0.0

        TXTSRNO.Text = 1
        CMBTYPE.SelectedIndex = 0
        CMBQUALITY.Text = ""
        CMBMILLNAME.Text = ""
        TXTWT.Clear()
        TXTNARR.Clear()
        TXTLOTNO.Clear()
        TXTCONES.Clear()
        CMBSHADE.Text = ""
        CMBDESIGN.Text = ""
        LBLTOTALCONES.Text = 0

        EP.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False

        GRIDWASTAGE.RowCount = 0
        GETMAX_WASTAGE_NO()

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False


        TabControl1.SelectedIndex = 0

        PBSOFTCOPY.Image = Nothing
        TXTUPLOADSRNO.Text = 1
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0


    End Sub

    Sub GETMAX_WASTAGE_NO()
        Dim DTTABLE As New DataTable
       If FRMSTRING = "WASTAGEGODOWN" Then
            DTTABLE = getmax("ISNULL(MAX(YWASGODOWN_NO),0)+ 1", "YARNWASTAGEGODOWN", "AND YWASGODOWN_YEARID = " & YearId)
        ElseIf FRMSTRING = "WASTAGEJOBBER" Then
            DTTABLE = getmax("ISNULL(MAX(YWASJOBBER_NO),0)+ 1", "YARNWASTAGEJOBBER", "AND YWASJOBBER_YEARID = " & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then TXTWASTAGENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub YarnWastage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
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

        fillDESIGN(CMBDESIGN, "")
        FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
       If FRMSTRING = "WASTAGEJOBBER" Then
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'") ''''TYPE = JOBBER
        End If
        If CMBOURGODOWN.Text.Trim = "" Then fillGODOWN(CMBOURGODOWN, EDIT)
        If CMBMILLNAME.Text = "" Then fillmill(CMBMILLNAME, EDIT)
        If CMBQUALITY.Text = "" Then fillQUALITY(CMBQUALITY, EDIT)
    End Sub

    Private Sub YarnWastage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            If FRMSTRING = "WASTAGEGODOWN" Then
                LBLNAME.Visible = False
                CMBNAME.Visible = False
                LBLGODOWN.Visible = True
                CMBOURGODOWN.Visible = True
                Me.Text = "Yarn Wastage at Godown"
            ElseIf FRMSTRING = "WASTAGEJOBBER" Then
                LBLNAME.Text = "Jobber Name"
                Me.Text = "Yarn Wastage From Jobber"
            End If

            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                If FRMSTRING = "WASTAGEGODOWN" Then

                    Dim OBJWAS As New ClsYarnWastageGodown
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(TEMPWASTAGENO)
                    ALPARAVAL.Add(YearId)
                    OBJWAS.alParaval = ALPARAVAL
                    dttable = OBJWAS.SELECTYARNWASTAGE()

                    If dttable.Rows.Count > 0 Then

                        For Each dr As DataRow In dttable.Rows

                            TXTWASTAGENO.Text = TEMPWASTAGENO
                            DTENTRYDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                            CMBOURGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                            CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                            txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                            'Item Grid
                            GRIDWASTAGE.Rows.Add(dr("SRNO"), dr("TYPE"), dr("QUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGN").ToString, dr("COLOR").ToString, dr("LOTNO").ToString, Format(Val(dr("WT")), "0.000"), dr("CONES"), dr("NARRATION").ToString, Val(dr("OUTWT")))
                        Next
                        TOTAL()
                        getsrno(GRIDWASTAGE)
                        If GRIDWASTAGE.RowCount > 0 Then TXTSRNO.Text = Val(GRIDWASTAGE.RowCount) + 1 Else TXTSRNO.Text = 1


                        Dim OBJCMN As New ClsCommon
                        dttable = OBJCMN.search(" YWASGODOWN_SRNO AS GRIDSRNO, YWASGODOWN_REMARKS AS REMARKS, YWASGODOWN_NAME AS NAME, YWASGODOWN_PHOTO AS IMGPATH ", "", " YARNWASTAGEGODOWN_UPLOAD", " AND YWASGODOWN_NO = " & TEMPWASTAGENO & " AND YWASGODOWN_YEARID = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            For Each DTR As DataRow In dttable.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                            Next
                        End If
                    End If

                ElseIf FRMSTRING = "WASTAGEJOBBER" Then

                    Dim OBJWAS As New ClsYarnWastageJobber
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(TEMPWASTAGENO)
                    ALPARAVAL.Add(YearId)
                    OBJWAS.alParaval = ALPARAVAL
                    dttable = OBJWAS.SELECTYARNWASTAGE()

                    If dttable.Rows.Count > 0 Then

                        For Each dr As DataRow In dttable.Rows

                            TXTWASTAGENO.Text = TEMPWASTAGENO
                            DTENTRYDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                            CMBOURGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                            CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                            txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                            'Item Grid
                            GRIDWASTAGE.Rows.Add(dr("SRNO"), dr("TYPE"), dr("QUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGN").ToString, dr("COLOR").ToString, dr("LOTNO").ToString, Format(Val(dr("WT")), "0.000"), Val(dr("CONES")), dr("NARRATION").ToString, Val(dr("OUTWT")))
                        Next
                        TOTAL()
                        getsrno(GRIDWASTAGE)
                        If GRIDWASTAGE.RowCount > 0 Then TXTSRNO.Text = Val(GRIDWASTAGE.RowCount) + 1 Else TXTSRNO.Text = 1


                        Dim OBJCMN As New ClsCommon
                        dttable = OBJCMN.search(" YWASJOBBER_SRNO AS GRIDSRNO,YWASJOBBER_REMARKS AS REMARKS, YWASJOBBER_NAME AS NAME, YWASJOBBER_PHOTO AS IMGPATH ", "", " YARNWASTAGEJOBBER_UPLOAD", " AND YWASJOBBER_NO = " & TEMPWASTAGENO & " AND YWASJOBBER_YEARID = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            For Each DTR As DataRow In dttable.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                            Next
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(DTENTRYDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBOURGODOWN.Text.Trim)
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALCONES.Text))
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim TYPE As String = ""
            Dim QUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim LOTNO As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""
            Dim NARRATION As String = ""
            Dim OUTWT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDWASTAGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GSHADE.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        WT = Val(row.Cells(Gwt.Index).Value)
                        CONES = row.Cells(GCONES.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        OUTWT = Val(row.Cells(GOUTWT.Index).Value)



                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(gsrno.Index).Value
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GSHADE.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(Gwt.Index).Value)
                        CONES = CONES & "|" & row.Cells(GCONES.Index).Value
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        OUTWT = OUTWT & "|" & Val(row.Cells(GOUTWT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(TYPE)
            alParaval.Add(QUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(WT)
            alParaval.Add(CONES)
            alParaval.Add(NARRATION)
            alParaval.Add(OUTWT)



           If FRMSTRING = "WASTAGEJOBBER" Then
                Dim OBJWEAVER As New ClsYarnWastageJobber
                OBJWEAVER.alParaval = alParaval
                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    Dim DTTABLE As DataTable = OBJWEAVER.SAVE()
                    TEMPWASTAGENO = DTTABLE.Rows(0).Item(0)
                    MessageBox.Show("Details Added")

                Else
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TEMPWASTAGENO)
                    IntResult = OBJWEAVER.UPDATE()
                    MessageBox.Show("Details Updated")
                    EDIT = False
                End If

            ElseIf FRMSTRING = "WASTAGEGODOWN" Then
                Dim OBJWEAVER As New ClsYarnWastageGodown
                OBJWEAVER.alParaval = alParaval
                If EDIT = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    Dim DTTABLE As DataTable = OBJWEAVER.SAVE()
                    TEMPWASTAGENO = DTTABLE.Rows(0).Item(0)
                    MessageBox.Show("Details Added")

                Else
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TEMPWASTAGENO)
                    IntResult = OBJWEAVER.UPDATE()
                    MessageBox.Show("Details Updated")
                    EDIT = False
                End If

            End If

            'PRINTREPORT(TEMPISSUENO)
            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            CLEAR()
            CMBOURGODOWN.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If DTENTRYDATE.Text = "__/__/____" Then
            EP.SetError(DTENTRYDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTENTRYDATE.Text) Then
                EP.SetError(DTENTRYDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If FRMSTRING <> "WASTAGEGODOWN" Then
            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Please Select Name")
                bln = False
            End If
        Else
            If CMBOURGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBOURGODOWN, "Please Select Godown Name")
                bln = False
            End If
        End If


        If GRIDWASTAGE.RowCount = 0 Then
            EP.SetError(TXTNARR, "Enter Yarn Details")
            bln = False
        End If


        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If

        Return bln
    End Function

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

    Sub SAVEUPLOAD()
        Try
            If FRMSTRING = "WASTAGEJOBBER" Then
                Dim OBJWEAVER As New ClsYarnWastageJobber
                For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    If row.Cells(GUSRNO.Index).Value <> Nothing Then
                        ALPARAVAL.Add(TEMPWASTAGENO)
                        ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                        ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                        ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                        PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                        PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                        ALPARAVAL.Add(YearId)

                        OBJWEAVER.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJWEAVER.SAVEUPLOAD()
                    End If
                Next

            ElseIf FRMSTRING = "WASTAGEGODOWN" Then
                Dim OBJWEAVER As New ClsYarnWastageGodown
                For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    If row.Cells(GUSRNO.Index).Value <> Nothing Then
                        ALPARAVAL.Add(TEMPWASTAGENO)
                        ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                        ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                        ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                        PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                        PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                        ALPARAVAL.Add(YearId)

                        OBJWEAVER.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJWEAVER.SAVEUPLOAD()
                    End If
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOURGODOWN.Enter
        Try
            If CMBOURGODOWN.Text.Trim = "" Then fillGODOWN(CMBOURGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOURGODOWN.Validating
        Try
            If CMBOURGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBOURGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If FRMSTRING = "WASTAGEJOBBER" Then
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS' ") ''''TYPE = JOBBER
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If FRMSTRING = "WASTAGEJOBBER" Then
                If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, cmbcode, e, Me, TXTADD, "AND GROUPMASTER.GROUP_SECONDARY='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                If FRMSTRING = "WASTAGEJOBBER" Then
                    OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS'"
                End If
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then fillmill(CMBMILLNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
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

    Sub TOTAL()
        Try
            LBLTOTALWT.Text = 0.0
            LBLTOTALCONES.Text = 0
            For Each ROW As DataGridViewRow In GRIDWASTAGE.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(Gwt.Index).EditedFormattedValue), "0.000")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDWASTAGE.RowCount = 0
LINE1:
            TEMPWASTAGENO = Val(TXTWASTAGENO.Text) - 1
Line2:
            If TEMPWASTAGENO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If FRMSTRING = "WASTAGEJOBBER" Then
                    DT = OBJCMN.search("YWASJOBBER_NO ", "", "  YARNWASTAGEJOBBER ", " AND YWASJOBBER_NO = '" & TEMPWASTAGENO & "' AND YARNWASTAGEJOBBER.YWASJOBBER_YEARID = " & YearId)
                ElseIf FRMSTRING = "WASTAGEGODOWN" Then
                    DT = OBJCMN.search("YWASGODOWN_NO ", "", "  YARNWASTAGEGODOWN ", " AND YWASGODOWN_NO = '" & TEMPWASTAGENO & "' AND YARNWASTAGEGODOWN.YWASGODOWN_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    YarnWastage_Load(sender, e)
                Else
                    TEMPWASTAGENO = Val(TEMPWASTAGENO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDWASTAGE.RowCount = 0 And TEMPWASTAGENO > 1 Then
                TXTWASTAGENO.Text = TEMPWASTAGENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDWASTAGE.RowCount = 0
LINE1:
            TEMPWASTAGENO = Val(TXTWASTAGENO.Text) + 1
            GETMAX_WASTAGE_NO()
            Dim MAXNO As Integer = TXTWASTAGENO.Text.Trim
            CLEAR()
            If Val(TXTWASTAGENO.Text) - 1 >= TEMPWASTAGENO Then
                EDIT = True
                YarnWastage_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDWASTAGE.RowCount = 0 And TEMPWASTAGENO < MAXNO Then
                TXTWASTAGENO.Text = TEMPWASTAGENO
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
                GRIDWASTAGE.RowCount = 0
                TEMPWASTAGENO = Val(tstxtbillno.Text)
                If TEMPWASTAGENO > 0 Then
                    EDIT = True
                    YarnWastage_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
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

    Private Sub gridupload_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
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

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWASTAGE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDWASTAGE.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDWASTAGE.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDWASTAGE.Item(gsrno.Index, e.RowIndex).Value
                CMBTYPE.Text = GRIDWASTAGE.Item(GTYPE.Index, e.RowIndex).Value
                CMBQUALITY.Text = GRIDWASTAGE.Item(GQUALITY.Index, e.RowIndex).Value
                CMBMILLNAME.Text = GRIDWASTAGE.Item(GMILLNAME.Index, e.RowIndex).Value
                CMBDESIGN.Text = GRIDWASTAGE.Item(GDESIGN.Index, e.RowIndex).Value.ToString
                CMBSHADE.Text = GRIDWASTAGE.Item(GSHADE.Index, e.RowIndex).Value.ToString
                TXTLOTNO.Text = GRIDWASTAGE.Item(GLOTNO.Index, e.RowIndex).Value.ToString

                TXTWT.Text = Format(Val(GRIDWASTAGE.Item(Gwt.Index, e.RowIndex).Value), "0.000")
                TXTCONES.Text = GRIDWASTAGE.Item(GCONES.Index, e.RowIndex).Value.ToString

                TXTNARR.Text = GRIDWASTAGE.Item(GNARRATION.Index, e.RowIndex).Value

                TEMPROW = e.RowIndex
                CMBQUALITY.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWASTAGE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDWASTAGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDWASTAGE.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDWASTAGE.Rows.RemoveAt(GRIDWASTAGE.CurrentRow.Index)
                getsrno(GRIDWASTAGE)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJYARN As New YarnWastageDetails
            OBJYARN.MdiParent = MDIMain
            OBJYARN.FRMSTRING = FRMSTRING
            OBJYARN.Show()
        Catch EX As Exception
            Throw EX
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
                    MsgBox("Unable to Delete, Checking Done / Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Delete Yarn Return?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPWASTAGENO)
                    alParaval.Add(YearId)

                    If FRMSTRING = "WASTAGEJOBBER" Then
                        Dim ClsDO As New ClsYarnWastageJobber
                        ClsDO.alParaval = alParaval
                        IntResult = ClsDO.Delete()
                    ElseIf FRMSTRING = "WASTAGEGODOWN" Then
                        Dim ClsDO As New ClsYarnWastageGodown
                        ClsDO.alParaval = alParaval
                        IntResult = ClsDO.Delete()
                    End If

                    MsgBox("Yarn Wastage Deleted")
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

    Private Sub DTENTRYDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTENTRYDATE.GotFocus
        DTENTRYDATE.SelectAll()
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTCONES.KeyPress
        numdot3(e, TXTWT, Me)
    End Sub

    Private Sub TXTNARR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNARR.Validating
        If CMBQUALITY.Text.Trim <> "" And CMBTYPE.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then FILLGRID() Else MsgBox("Please Enter proper details")
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDWASTAGE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBTYPE.Text.Trim, CMBQUALITY.Text.Trim, CMBMILLNAME.Text.Trim, CMBDESIGN.Text.Trim, CMBSHADE.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.000"), Val(TXTCONES.Text.Trim), TXTNARR.Text.Trim, 0)
            Else
                GRIDWASTAGE.Item(gsrno.Index, TEMPROW).Value = TXTSRNO.Text.Trim
                GRIDWASTAGE.Item(GTYPE.Index, TEMPROW).Value = CMBTYPE.Text.Trim
                GRIDWASTAGE.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDWASTAGE.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILLNAME.Text.Trim
                GRIDWASTAGE.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDWASTAGE.Item(GSHADE.Index, TEMPROW).Value = CMBSHADE.Text.Trim
                GRIDWASTAGE.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
                GRIDWASTAGE.Item(Gwt.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.000")
                GRIDWASTAGE.Item(GCONES.Index, TEMPROW).Value = Val(TXTCONES.Text.Trim)
                GRIDWASTAGE.Item(GNARRATION.Index, TEMPROW).Value = TXTNARR.Text.Trim

                GRIDDOUBLECLICK = False
            End If
            'TXTSRNO.Clear()
            If ClientName <> "VAISHALI" Then CMBQUALITY.Text = ""
            CMBMILLNAME.Text = ""
            CMBDESIGN.Text = ""
            CMBSHADE.Text = ""
            TXTCONES.Clear()
            TXTWT.Clear()
            TXTNARR.Clear()
            getsrno(GRIDWASTAGE)
            TOTAL()
            CMBQUALITY.Focus()
            If GRIDWASTAGE.RowCount > 0 Then TXTSRNO.Text = Val(GRIDWASTAGE.RowCount) + 1 Else TXTSRNO.Text = 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTENTRYDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTENTRYDATE.Validating
        Try
            If DTENTRYDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTENTRYDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_Validated(sender As Object, e As EventArgs) Handles TXTCONES.Validated
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM MILLMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(TXTCONES.Text.Trim) <> 0 And CMBMILLNAME.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(MILL_REMARK,0) AS CONEWT", "", "MILLMASTER ", " AND MILL_NAME = '" & CMBMILLNAME.Text.Trim & "' AND MILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(TXTCONES.Text.Trim) * Val(DT.Rows(0).Item("CONEWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class