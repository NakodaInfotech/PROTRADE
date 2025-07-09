
Imports System.ComponentModel
Imports BL

Public Class YarnIssue

    Public EDIT As Boolean          'used for editing
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPYARNNO As Integer          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim PARTYCHALLANNO As String

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
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

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            'If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
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

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            'If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()


        EP.Clear()

        TXTYISSUENO.Clear()

        'If ALLOWMANUALJONO = True Then
        '    TXTJONO.ReadOnly = False
        '    TXTJONO.BackColor = Color.LemonChiffon
        'Else
        '    TXTJONO.ReadOnly = True
        '    TXTJONO.BackColor = Color.Linen
        'End If

        CMBNAME.Text = ""
        TXTCHALLANNO.Clear()
        CMBPROCESS.Text = ""
        CMBMACHINE.Text = ""

        TXTADD.Clear()
        YISSDATE.Text = Now.Date
        tstxtbillno.Clear()

        CMBTRANS.Text = ""
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        CMDSELECTSTOCK.Enabled = True
        LBLCLOSED.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False

        lbltotalqty.Text = 0.0
        LBLTOTALWT.Text = 0.0
        LBLTOTALCONES.Text = 0.0

        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        TXTLOTNO.Clear()
        txtqty.Clear()
        TXTCONES.Clear()
        cmbcolor.Text = ""
        TXTLRNO.Clear()
        TXTWT.Clear()

        GRIDYARN.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()


        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If
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
        CMBNAME.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARN_no),0) + 1 ", " YARNISSUE ", " AND YARN_cmpid=" & CmpId & " and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYISSUENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Name")
                bln = False
            End If

            If CMBPROCESS.Text.Trim.Length = 0 Then
                EP.SetError(CMBPROCESS, " Select Process Name")
                bln = False
            End If

            If LBLCLOSED.Visible = True Then
                EP.SetError(LBLCLOSED, " Issue Closed")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim DT As DataTable = objclscommon.search(" YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNISSUE inner join LEDGERS on LEDGERS.ACC_id = YARN_ledgerid ", " and YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND YARN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            If YISSDATE.Text = "__/__/____" Then
                EP.SetError(YISSDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YISSDATE.Text) Then
                    EP.SetError(YISSDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTYISSUENO.Text.Trim) = 0 Then
                EP.SetError(TXTYISSUENO, "Enter Job Out No")
                bln = False
            End If

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

            alParaval.Add(Format(Convert.ToDateTime(YISSDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBMACHINE.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


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
                        If row.Cells(GLRDATE.Index).Value <> "" Then LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy") Else LRDATE = Format(Now.Date, "MM/dd/yyyy")


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
                        If row.Cells(GLRDATE.Index).Value <> "" Then LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value).Date, "MM/dd/yyyy") Else LRDATE = LRDATE & "|" & Format(Now.Date, "MM/dd/yyyy")

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(qty)
            alParaval.Add(WT)

            alParaval.Add(CONES)
            alParaval.Add(LRNO)
            alParaval.Add(LRDATE)

            Dim objCUTTING As New ClsYarnIssue()
            objCUTTING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.SAVE()
                MsgBox("Details Added")

                TXTYISSUENO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPYARNNO)
                IntResult = objCUTTING.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPYARNNO)

                If gridupload.RowCount > 0 Then SAVEUPLOAD()
                EDIT = False
            End If

            'COPY SCANNED DOCS FILES 
            'For Each ROW As DataGridViewRow In gridupload.Rows
            '    If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
            '        FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
            '    End If
            '    If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
            '        System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
            '    End If
            'Next

            clear()
            YISSDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnIssue


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
                Dim OBJPUR As New YarnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "YARNISSUE"
                OBJPUR.WHERECLAUSE = "{YARNISSUE.YARN_NO}=" & Val(YARNNO) & " and {YARNISSUE.YARN_YEARID}=" & YearId
                OBJPUR.Show()
            End If
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
        ElseIf e.KeyCode = Keys.Oemcomma Then
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
        ElseIf e.KeyCode = Keys.F5 Then     'grid focus
            YarnRecd.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub JOBOUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub JOBOUT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'YARN ISSUE'")
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

                Dim objJO As New ClsYarnIssue()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPYARNNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.selectYARN(TEMPYARNNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYISSUENO.Text = TEMPYARNNO
                        YISSDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBMACHINE.Text = dr("MACHINE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBPROCESS.Text = Convert.ToString(dr("PROCESS").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        Dim TEMPLRDATE As String = ""
                        If dr("LRNO") <> "" Then TEMPLRDATE = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        GRIDYARN.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGNNO").ToString, dr("COLOR"), dr("LOTNO"), Format(dr("qty"), "0.00"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0.00"), dr("LRNO"), TEMPLRDATE)

                        If Convert.ToDecimal(dr("RECDWT")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next


                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" YARNISSUE_UPLOAD.YARN_SRNO AS GRIDSRNO, YARNISSUE_UPLOAD.YARN_REMARKS AS REMARKS, YARNISSUE_UPLOAD.YARN_NAME AS NAME, YARNISSUE_UPLOAD.YARN_PHOTO AS IMGPATH ", "", " YARNISSUE_UPLOAD ", " AND YARNISSUE_UPLOAD.YARN_NO = " & TEMPYARNNO & " AND YARN_YEARID = " & YearId & " ORDER BY YARNISSUE_UPLOAD.YARN_SRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    total()
                    GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
                    'chkchange.CheckState = CheckState.Checked
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

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLDESIGN(CMBDESIGN, "")
            FILLCOLOR(cmbcolor, "")
            FILLMACHINE(CMBMACHINE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTLRDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTLRDATE.Validated
        Try

            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then

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

    Sub fillgrid()

        GRIDYARN.Enabled = True

        Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
        Dim TEMPLRDATE As String = ""
        If TXTLRNO.Text.Trim <> "" Then TEMPLRDATE = Format(DTLRDATE.Value.Date, "dd/MM/yyyy")

        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0.00"), TXTLRNO.Text.Trim, TEMPLRDATE, 0, 0, 0, 0, 0)
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim

            GRIDYARN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim

            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")

            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0.00")
            GRIDYARN.Item(GLRNO.Index, TEMPROW).Value = TXTLRNO.Text.Trim
            GRIDYARN.Item(GLRDATE.Index, TEMPROW).Value = TEMPLRDATE


            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        TXTLRNO.Clear()
        DTLRDATE.Value = Now.Date

        'txtPartyMtrs.Clear()
        'txtCheckPcs.Clear()
        'TXTBARCODE.Clear()
        txtsrno.Text = Val(GRIDYARN.Rows(GRIDYARN.RowCount - 1).Cells(0).Value) + 1
        CMBYARNQUALITY.Focus()



    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJEMB As New YarnIssueDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        'Try
        '    'If edit = False Then
        '    Dim i As Integer = 0
        '    For Each row As DataGridViewRow In grid.Rows
        '        If row.Visible = True Then
        '            row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
        '            i = i + 1
        '        End If
        '    Next
        '    'End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTYARN As New DataTable
            Dim OBJSTOCK As New SelectYarnStock
            OBJSTOCK.GODOWN = CMBGODOWN.Text.Trim
            OBJSTOCK.ShowDialog()
            DTYARN = OBJSTOCK.DT
            If DTYARN.Rows.Count > 0 Then
                For Each DTROW As DataRow In DTYARN.Rows
                    GRIDYARN.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("MILLNAME"), DTROW("DESIGNNO"), DTROW("COLOR"), DTROW("LOTNO"), Format(Val(DTROW("BAGS")), "0"), Format(Val(DTROW("WT")), "0.00"), Format(Val(DTROW("CONES")), "0"), DTROW("LRNO"), Format(DTLRDATE.Value.Date, "dd/MM/yyyy"))
                Next
                getsrno(GRIDYARN)
                total()
                GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
            End If
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
                    JOBOUT_Load(sender, e)
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
            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYISSUENO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO > 1 Then
                TXTYISSUENO.Text = TEMPYARNNO
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
            TEMPYARNNO = Val(TXTYISSUENO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTYISSUENO.Text.Trim
            clear()
            If Val(TXTYISSUENO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYISSUENO.Text = TEMPYARNNO
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

    Private Sub GRIDYARN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
        Try
            Dim colNum As Integer = GRIDYARN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDYARN.CurrentCell.Value = Nothing Then GRIDYARN.CurrentCell.Value = "0.00"
                        GRIDYARN.CurrentCell.Value = Convert.ToDecimal(GRIDYARN.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDYARN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDYARN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPYARNNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        'Try
        '    If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
        '        MsgBox("Insufficient Rights")
        '        Exit Sub
        '    End If

        '    TEMPMSG = MsgBox("Wish to Close Yarn Issue?", MsgBoxStyle.YesNo)
        '    If TEMPMSG = vbYes Then
        '        TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
        '        If TEMPMSG = vbYes Then

        '            Dim alParaval As New ArrayList
        '            alParaval.Add(TXTYISSUENO.Text)
        '            alParaval.Add(1)
        '            alParaval.Add(CmpId)
        '            alParaval.Add(Locationid)
        '            alParaval.Add(YearId)

        '            Dim intresult As Integer
        '            Dim clsobjjo As New ClsCuttingIssue()
        '            clsobjjo.alParaval = alParaval
        '            intresult = clsobjjo.CLOSE()
        '            MsgBox("Yarn Issue Closed")
        '            clear()

        '        Else
        '            Exit Sub
        '        End If
        '        Exit Sub
        '    End If

        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Yarn Issue?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsYarnIssue

                ALPARAVAL.Add(TEMPYARNNO)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Yarn Issue Deleted Succesfully")
                clear()
                EDIT = False
                CMBNAME.Focus()
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

    Private Sub JODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YISSDATE.GotFocus
        YISSDATE.SelectAll()
    End Sub

    Private Sub JODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YISSDATE.Validating
        Try
            If YISSDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YISSDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    'Dim dt As DataTable = objclscommon.search(" JO_challanno, LEDGERS.ACC_cmpname", "", " JOBOUT inner join LEDGERS on LEDGERS.ACC_id = JO_ledgerid ", " and JO_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND JO_YEARID =" & YearId)
                    Dim dt As DataTable = objclscommon.search(" YARN_challanno, LEDGERS.ACC_cmpname", "", " YARNISSUE inner join LEDGERS on LEDGERS.ACC_id = YARN_ledgerid ", " and YARN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND YARN_YEARID =" & YearId)

                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "TEXTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YarnIssue_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "VAISHALI" Then
                GLRNO.HeaderText = "Machine"
                GLRDATE.HeaderText = "Date"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDYARN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
        EDITROW()
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
                TXTLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                txtqty.Text = GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTCONES.Text = GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLRNO.Text = GRIDYARN.Item(GLRNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                DTLRDATE.Text = GRIDYARN.Item(GLRDATE.Index, GRIDYARN.CurrentRow.Index).Value


                TEMPROW = GRIDYARN.CurrentRow.Index
                CMBYARNQUALITY.Focus()
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

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTCONES.KeyPress
        numkeypress(e, TXTCONES, Me)
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBMACHINE_Enter(sender As Object, e As EventArgs) Handles CMBMACHINE.Enter
        Try
            If CMBMACHINE.Text.Trim = "" Then FILLMACHINE(CMBMACHINE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINE_Validating(sender As Object, e As CancelEventArgs) Handles CMBMACHINE.Validating
        Try
            If CMBMACHINE.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validated(sender As Object, e As EventArgs) Handles txtqty.Validated
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM YARNQUALITYMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(txtqty.Text.Trim) <> 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_BOXTUBEWT,0) AS BOXWT", "", "YARNQUALITYMASTER ", " AND YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(txtqty.Text.Trim) * Val(DT.Rows(0).Item("BOXWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class