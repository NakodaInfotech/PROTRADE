
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class YarnReturnKnitting

    Public EDIT As Boolean          'used for editing
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPYARNKNITTINGRETNO As Integer          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim PARTYCHALLANNO As String

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
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
            fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
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

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTKNITTINGRETURN.Clear()

        TXTCHALLANNO.Clear()
        CMBNAME.Text = ""
        TXTADD.Clear()
        YRETDATE.Text = Now.Date
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
        CMBGODOWN.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARNRET_NO),0) + 1 ", " YARNKNITTINGRETURN ", " AND YARNRET_cmpid=" & CmpId & " and YARNRET_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTKNITTINGRETURN.Text = DTTABLE.Rows(0).Item(0)
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

            'If LBLCLOSED.Visible = True Then
            '    EP.SetError(LBLCLOSED, " Issue Closed")
            '    bln = False
            'End If

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
                    Dim DT As DataTable = objclscommon.search(" YARNRET_challanno", "", " YARNKNITTINGRETURN ", " and YARNRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' AND YARNRET_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            If YRETDATE.Text = "__/__/____" Then
                EP.SetError(YRETDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YRETDATE.Text) Then
                    EP.SetError(YRETDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTKNITTINGRETURN.Text.Trim) = 0 Then
                EP.SetError(TXTKNITTINGRETURN, "Enter Job Out No")
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

            alParaval.Add(Format(Convert.ToDateTime(YRETDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(CMBNAME.Text.Trim)
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
                        'LRDATE = row.Cells(GLRDATE.Index).Value.ToString
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

            'Dim griduploadsrno As String = ""
            'Dim imgpath As String = ""
            'Dim uploadremarks As String = ""
            'Dim name As String = ""
            'Dim NEWIMGPATH As String = ""
            'Dim FILENAME As String = ""


            ' ''Saving Upload Grid

            'For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
            '    If row.Cells(0).Value <> Nothing Then
            '        If griduploadsrno = "" Then
            '            griduploadsrno = row.Cells(0).Value.ToString
            '            uploadremarks = row.Cells(1).Value.ToString
            '            name = row.Cells(2).Value.ToString
            '            imgpath = row.Cells(3).Value.ToString
            '            NEWIMGPATH = row.Cells(GUNEWIMGPATH.Index).Value.ToString

            '        Else
            '            griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
            '            uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
            '            name = name & "|" & row.Cells(2).Value.ToString
            '            imgpath = imgpath & "|" & row.Cells(3).Value.ToString
            '            NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GUNEWIMGPATH.Index).Value.ToString

            '        End If
            '    End If
            'Next

            'alParaval.Add(griduploadsrno)
            'alParaval.Add(uploadremarks)
            'alParaval.Add(name)
            'alParaval.Add(imgpath)
            'alParaval.Add(NEWIMGPATH)
            'alParaval.Add(FILENAME)

            Dim objCUTTING As New ClsYarnReturnKnitting()
            objCUTTING.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCUTTING.SAVE()
                MsgBox("Details Added")
                TXTKNITTINGRETURN.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPYARNKNITTINGRETNO)
                IntResult = objCUTTING.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPYARNKNITTINGRETNO)

                If gridupload.RowCount > 0 Then SAVEUPLOAD()
                EDIT = False
            End If

            ' '' COPY SCANNED DOCS FILES 
            'For Each ROW As DataGridViewRow In gridupload.Rows
            '    If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
            '        FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
            '    End If
            '    If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
            '        System.IO.File.Copy(ROW.Cells(GUIMGPATH.Index).Value, ROW.Cells(GUNEWIMGPATH.Index).Value, True)
            '    End If
            'Next

            clear()
            YRETDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsYarnReturnKnitting


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPYARNKNITTINGRETNO)
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
        'Try
        '    TEMPMSG = MsgBox("Wish to Print Yarn Issue?", MsgBoxStyle.YesNo)
        '    If TEMPMSG = vbYes Then
        '        Dim OBJGDN As New GDNDESIGN
        '        OBJGDN.MdiParent = MDIMain
        '        OBJGDN.FRMSTRING = "JOBOUT"
        '        'OBJGDN.FORMULA = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
        '        OBJGDN.Show()
        '    End If

        '    If ClientName = "KCRAYON" Then
        '        If MsgBox("Wish to Print Job Sheet?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '            Dim OBJJO As New JobOutDesign
        '            OBJJO.MdiParent = MDIMain
        '            OBJJO.FRMSTRING = "JOBSHEET"
        '            'OBJJO.WHERECLAUSE = "{JOBOUT.JO_NO}=" & Val(JONO) & " and {JOBOUT.JO_yearid}=" & YearId
        '            OBJJO.Show()
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
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

    Private Sub JOBOUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub JOBOUT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'YARN RECD'")
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

                Dim objJO As New ClsYarnReturnKnitting()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPYARNKNITTINGRETNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objJO.selectYARNKNITTING(TEMPYARNKNITTINGRETNO, CmpId, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTKNITTINGRETURN.Text = TEMPYARNKNITTINGRETNO
                        YRETDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBPROCESS.Text = Convert.ToString(dr("PROCESS").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        GRIDYARN.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGNNO").ToString, dr("COLOR"), dr("LOTNO"), Format(dr("qty"), "0.00"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0.00"), dr("LRNO"), Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy"))

                        If Convert.ToDecimal(dr("RECDMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" YARNKNITTINGRETURN_UPLOAD.YARNRET_SRNO AS GRIDSRNO, YARNKNITTINGRETURN_UPLOAD.YARNRET_REMARKS AS REMARKS, YARNKNITTINGRETURN_UPLOAD.YARNRET_NAME AS NAME, YARNKNITTINGRETURN_UPLOAD.YARNRET_PHOTO AS IMGPATH ", "", " YARNKNITTINGRETURN_UPLOAD ", " AND YARNKNITTINGRETURN_UPLOAD.YARNRET_NO = " & TEMPYARNKNITTINGRETNO & " AND YARNRET_YEARID = " & YearId & " ORDER BY YARNKNITTINGRETURN_UPLOAD.YARNRET_SRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    'Dim OBJCMN As New ClsCommon
                    'dttable = OBJCMN.search(" YARNKNITTINGRETURN_UPLOAD.YARNRET_GRIDSRNO AS GRIDSRNO, YARNKNITTINGRETURN_UPLOAD.YARNRET_REMARKS AS REMARKS, YARNKNITTINGRETURN_UPLOAD.YARNRET_NAME AS NAME, YARNKNITTINGRETURN_UPLOAD.YARNRET_IMGPATH AS IMGPATH ,YARNRET_NEWIMGPATH AS NEWIMGPATH", "", " YARNKNITTINGRETURN_UPLOAD ", " AND YARNKNITTINGRETURN_UPLOAD.YARNRET_NO = " & TEMPYARNKNITTINGRETNO & " AND YARNRET_YEARID = " & YearId & " ORDER BY YARNKNITTINGRETURN_UPLOAD.YARNRET_GRIDSRNO")
                    'If dttable.Rows.Count > 0 Then
                    '    For Each DTR As DataRow In dttable.Rows
                    '        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))), DTR("NEWIMGPATH"))
                    '    Next
                    'End If

                    total()
                    GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
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
            'If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLDESIGN(CMBDESIGN, "")
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)

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

    Private Sub DTLRDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTLRDATE.Validated
        Try

            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                fillgrid()
            ElseIf CMBYARNQUALITY.Text.Trim = "" Then
                MsgBox("Enter Yarn Quality Name", MsgBoxStyle.Critical)
                CMBYARNQUALITY.Focus()
                Exit Sub
            ElseIf CMBMILL.Text.Trim = "" Then
                MsgBox("Enter Mill Name", MsgBoxStyle.Critical)
                CMBMILL.Focus()
                Exit Sub
            ElseIf Val(TXTCONES.Text.Trim) <= 0 Then
                MsgBox("Enter Cones....", MsgBoxStyle.Critical)
                txtqty.Focus()
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
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0.00"), TXTLRNO.Text.Trim, Format(DTLRDATE.Value.Date, "dd/MM/yyyy"), 0, 0, 0, 0, 0)
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
            GRIDYARN.Item(GLRDATE.Index, TEMPROW).Value = Format(DTLRDATE.Value.Date, "dd/MM/yyyy")


            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        CMBYARNQUALITY.Text = ""
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



    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJEMB As New YarnReturnKnittingDetails
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

    'Private Sub CMDSELECTDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
    '    Try
    '        Dim DTJO As New DataTable
    '        Dim OBJSELECTGDN As New SelectStockGDN
    '        OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
    '        OBJSELECTGDN.ShowDialog()
    '        DTJO = OBJSELECTGDN.DT
    '        If DTJO.Rows.Count > 0 Then
    '            For Each DTROWPS As DataRow In DTJO.Rows
    '                GRIDYARN.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("LOTNO"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), 1, Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
    '            Next
    '            getsrno(GRIDYARN)
    '            total()
    '            GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDYARN.RowCount = 0
                TEMPYARNKNITTINGRETNO = Val(tstxtbillno.Text)
                If TEMPYARNKNITTINGRETNO > 0 Then
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
            TEMPYARNKNITTINGRETNO = Val(TXTKNITTINGRETURN.Text) - 1
            If TEMPYARNKNITTINGRETNO > 0 Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNKNITTINGRETNO > 1 Then
                TXTKNITTINGRETURN.Text = TEMPYARNKNITTINGRETNO
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
            TEMPYARNKNITTINGRETNO = Val(TXTKNITTINGRETURN.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTKNITTINGRETURN.Text.Trim
            clear()
            If Val(TXTKNITTINGRETURN.Text) - 1 >= TEMPYARNKNITTINGRETNO Then
                EDIT = True
                JOBOUT_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNKNITTINGRETNO < MAXNO Then
                TXTKNITTINGRETURN.Text = TEMPYARNKNITTINGRETNO
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

    Private Sub GRIDPRODRET_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
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

    Private Sub GRIDPRODRET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown
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
            If EDIT = True Then PRINTREPORT(TEMPYARNKNITTINGRETNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Yarn Return.....?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsYarnReturnKnitting

                ALPARAVAL.Add(TEMPYARNKNITTINGRETNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Yarn Return Deleted Succesfully")
                clear()
                EDIT = False
                CMBGODOWN.Focus()
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

    Private Sub JODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YRETDATE.GotFocus
        YRETDATE.SelectAll()
    End Sub

    Private Sub JODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YRETDATE.Validating
        Try
            If YRETDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YRETDATE.Text, TEMP) Then
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
                    Dim dt As DataTable = objclscommon.search(" YARNRET_challanno", "", " YARNKNITTINGRETURN  ", " and YARNRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' AND YARNRET_YEARID =" & YearId)

                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPRODRET_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
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

                txtqty.Text = GRIDYARN.Item(gQty.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTCONES.Text = GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLRNO.Text = GRIDYARN.Item(GLRNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                DTLRDATE.Text = GRIDYARN.Item(GLRDATE.Index, GRIDYARN.CurrentRow.Index).Value


                TEMPROW = GRIDYARN.CurrentRow.Index
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
        numdotkeypress(e, TXTWT, Me)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
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
End Class