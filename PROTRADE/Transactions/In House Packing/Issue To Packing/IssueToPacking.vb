
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class IssueToPacking

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public TEMPISSUENO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        CHKSLTP.CheckState = CheckState.Unchecked
        ISSUEDATE.Text = Now.Date
        TXTREFNO.Clear()
        tstxtbillno.Clear()
        txtremarks.Clear()
        CMBCONTRACTOR.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        txtuploadsrno.Text = 1
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        CMBWEAVERNAME.Text = ""
        TXTWEAVERCHNO.Clear()
        TXTCHALLANNO.Clear()

        CMDSELECTSTOCK.Enabled = True
        lbllocked.Visible = False
        PBlock.Visible = False

        LBLTOTALMTRS.Text = 0.0
        LBLTOTALPCS.Text = 0.0
        TXTBARCODE.Clear()

        GRIDISSUE.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        getmaxno()

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDISSUE.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
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
        TXTBARCODE.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ISS_no),0) + 1 ", " ISSUEPACKING ", " and ISS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True
            total()

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDISSUE.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If (ClientName = "AVIS" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "SONU") And CMBCONTRACTOR.Text.Trim = "" Then
                EP.SetError(CMBCONTRACTOR, "Select Contractor")
                bln = False
            End If

            If ISSUEDATE.Text = "__/__/____" Then
                EP.SetError(ISSUEDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(ISSUEDATE.Text) Then
                    EP.SetError(ISSUEDATE, "Date not in Accounting Year")
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
            alParaval.Add(Format(Convert.ToDateTime(ISSUEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBCONTRACTOR.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(CHKSLTP.Checked)

            alParaval.Add(CMBWEAVERNAME.Text.Trim)
            alParaval.Add(TXTWEAVERCHNO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)

            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            Dim LOTNO As String = ""
            Dim QUALITY As String = ""
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
            Dim GREYMTRS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDISSUE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        OUTPCS = row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value.ToString
                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        GREYMTRS = Val(row.Cells(GGREYMTRS.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
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
                        GREYMTRS = GREYMTRS & "|" & Val(row.Cells(GGREYMTRS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(BALENO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(LOTNO)
            alParaval.Add(QUALITY)
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
            alParaval.Add(GREYMTRS)

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            Dim OBJISSUE As New ClsIssueToPacking()
            OBJISSUE.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJISSUE.SAVE()
                MsgBox("Details Added")
                TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPISSUENO)
                IntResult = OBJISSUE.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If

            PRINTREPORT()

            clear()
            ISSUEDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Issue Report...?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJMATREC As New MATRECDesign
                OBJMATREC.MdiParent = MDIMain
                OBJMATREC.FRMSTRING = "ISSUETOPACK"
                OBJMATREC.WHERECLAUSE = "{ISSUEPACKING.ISS_no}=" & Val(TXTISSUENO.Text.Trim) & " AND {ISSUEPACKING.ISS_yearid}=" & YearId
                OBJMATREC.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IssueToPacking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        End If
    End Sub

    Private Sub IssueToPacking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB OUT'")
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

                Dim OBJISSUE As New ClsIssueToPacking()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPISSUENO)
                ALPARAVAL.Add(YearId)
                OBJISSUE.alParaval = ALPARAVAL
                Dim dttable As DataTable = OBJISSUE.SELECTJO()

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTISSUENO.Text = TEMPISSUENO
                        ISSUEDATE.Text = Format(Convert.ToDateTime(dr("ISSUEDATE")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBCONTRACTOR.Text = Convert.ToString(dr("CONTRACTOR").ToString)
                        TXTREFNO.Text = dr("REFNO")
                        CHKSLTP.Checked = Convert.ToBoolean(dr("SLTP"))
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)


                        CMBWEAVERNAME.Text = dr("WEAVERNAME")
                        TXTWEAVERCHNO.Text = dr("WEAVERCHNO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")


                        LBLTOTALPCS.Text = Format(dr("TOTALPCS"), "0.00")
                        LBLTOTALMTRS.Text = Format(dr("TOTALMTRS"), "0.00")

                        'Item Grid
                        GRIDISSUE.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("BALENO").ToString, dr("ITEM").ToString, dr("LOTNO").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR").ToString, Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), dr("BARCODE").ToString, Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), Val(dr("GREYMTRS")))

                        'If Convert.ToDecimal(dr("RECDMTRS")) > 0 Then
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If


                        If Val(dr("OUTMTRS")) > 0 Then
                            GRIDISSUE.Rows(GRIDISSUE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            'lbllocked.Visible = True
                            'PBlock.Visible = True
                        End If

                    Next



                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" ISS_GRIDSRNO AS GRIDSRNO, ISS_REMARKS AS REMARKS, ISS_NAME AS NAME, ISS_IMGPATH AS IMGPATH, ISS_NEWIMGPATH AS NEWIMGPATH", "", " ISSUEPACKING_UPLOAD", " AND ISS_NO = " & TEMPISSUENO & " AND ISS_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                        Next
                    End If
                    total()
                    GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1
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
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBCONTRACTOR.Text.Trim = "" Then FILLCONTRACT(CMBCONTRACTOR)
            If CMBWEAVERNAME.Text.Trim = "" Then fillname(CMBWEAVERNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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

            Dim OBJISSUE As New IssueToPackingDetails
            OBJISSUE.MdiParent = MDIMain
            OBJISSUE.Show()
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            Dim GREYMTRS As Double = 0.0
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'GET GREYMTRS FOR KARAN
                    If ClientName = "KARAN" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DTGREY As New DataTable
                        If DTROWPS("TYPE") = "MATREC" Then
                            DTGREY = OBJCMN.search("ISNULL(MATREC_MTRS,0) AS GREYMTRS", "", " MATERIALRECEIPT_DESC ", " AND MATREC_BARCODE = '" & DTROWPS("BARCODE") & "' AND MATREC_YEARID = " & YearId)
                        ElseIf DTROWPS("TYPE") = "JOBIN" Then
                            DTGREY = OBJCMN.search("ISNULL(JI_JOMTRS,0) AS GREYMTRS", "", " JOBIN_DESC ", " AND JI_BARCODE = '" & DTROWPS("BARCODE") & "' AND JI_YEARID = " & YearId)
                        End If
                        If DTGREY.Rows.Count > 0 Then GREYMTRS = Val(DTGREY.Rows(0).Item("GREYMTRS"))
                    End If

                    GRIDISSUE.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("BALENO"), DTROWPS("ITEMNAME"), DTROWPS("LOTNO"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), 0, 0, DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), GREYMTRS)
                Next
                getsrno(GRIDISSUE)
                total()
                GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDISSUE.RowCount = 0
                TEMPISSUENO = Val(tstxtbillno.Text)
                If TEMPISSUENO > 0 Then
                    EDIT = True
                    IssueToPacking_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgridscan()
        Try
            If GRIDUPLOADDOUBLECLICK = False Then
                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)
            ElseIf GRIDUPLOADDOUBLECLICK = True Then
                gridupload.Item(0, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
                gridupload.Item(3, TEMPUPLOADROW).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, TEMPUPLOADROW).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, TEMPUPLOADROW).Value = TXTFILENAME.Text.Trim

                GRIDUPLOADDOUBLECLICK = False
            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTISSUENO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                GRIDUPLOADDOUBLECLICK = True
                TEMPUPLOADROW = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDISSUE.RowCount = 0
LINE1:
            TEMPISSUENO = Val(TXTISSUENO.Text) - 1
            If TEMPISSUENO > 0 Then
                EDIT = True
                IssueToPacking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDISSUE.RowCount = 0 And TEMPISSUENO > 1 Then
                TXTISSUENO.Text = TEMPISSUENO
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
            TEMPISSUENO = Val(TXTISSUENO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTISSUENO.Text.Trim
            clear()
            If Val(TXTISSUENO.Text) - 1 >= TEMPISSUENO Then
                EDIT = True
                IssueToPacking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDISSUE.RowCount = 0 And TEMPISSUENO < MAXNO Then
                TXTISSUENO.Text = TEMPISSUENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

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

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDISSUE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDISSUE.RowCount > 0 Then
                If Val(GRIDISSUE.CurrentRow.Cells(GOUTMTRS.Index).Value) > 0 Then
                    MessageBox.Show("Row is in Locked, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDISSUE.Rows.RemoveAt(GRIDISSUE.CurrentRow.Index)
                getsrno(GRIDISSUE)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDISSUE_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDISSUE.CellValidating
        Try
            Dim colNum As Integer = GRIDISSUE.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPCS.Index, GMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDISSUE.CurrentCell.Value = Nothing Then GRIDISSUE.CurrentCell.Value = "0.00"
                        GRIDISSUE.CurrentCell.Value = Convert.ToDecimal(GRIDISSUE.Item(colNum, e.RowIndex).Value)
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

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If lbllocked.Visible = True Then
                    MsgBox("Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJISSUE As New ClsIssueToPacking

                ALPARAVAL.Add(TEMPISSUENO)
                ALPARAVAL.Add(YearId)
                OBJISSUE.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJISSUE.Delete()
                MsgBox("Issue Entry Deleted Succesfully")
                clear()
                EDIT = False
                TXTBARCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                If CMBGODOWN.Text.Trim = "" Then
        '                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
        '                    Exit Sub
        '                End If

        '                'GET DATA FROM BARCODE
        '                Dim GREYMTRS As Double = 0.0
        '                Dim OBJCMN As New ClsCommon
        '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    'VALIDATE GODOWN
        '                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
        '                        MsgBox("Item Not in Selected Godown ", MsgBoxStyle.Critical)
        '                        TXTBARCODE.Clear()
        '                        Exit Sub
        '                    End If

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '                    For Each ROW As DataGridViewRow In GRIDISSUE.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next


        '                    'GET GREYMTRS FOR KARAN
        '                    If ClientName = "KARAN" Then
        '                        Dim DTGREY As New DataTable
        '                        If DT.Rows(0).Item("TYPE") = "MATREC" Then
        '                            DTGREY = OBJCMN.search("ISNULL(MATREC_MTRS,0) AS GREYMTRS", "", " MATERIALRECEIPT_DESC ", " AND MATREC_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND MATREC_YEARID = " & YearId)
        '                        ElseIf DT.Rows(0).Item("TYPE") = "JOBIN" Then
        '                            DTGREY = OBJCMN.search("ISNULL(JI_MTRS,0) AS GREYMTRS", "", " JOBIN_DESC ", " AND JI_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND JI_YEARID = " & YearId)
        '                        End If
        '                        If DTGREY.Rows.Count > 0 Then GREYMTRS = Val(DTGREY.Rows(0).Item("GREYMTRS"))
        '                    End If

        '                    GRIDISSUE.Rows.Add(GRIDISSUE.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("LOTNO"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), 1, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), GREYMTRS)
        '                    total()
        '                    GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1

        'LINE1:
        '                    TXTBARCODE.Clear()

        '                End If
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId)
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

    Private Sub ISSUEDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ISSUEDATE.GotFocus
        ISSUEDATE.SelectAll()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT()
    End Sub

    Private Sub ISSUEDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ISSUEDATE.Validating
        Try
            If ISSUEDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(ISSUEDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcontractor_Enter(sender As Object, e As EventArgs) Handles CMBCONTRACTOR.Enter
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then FILLCONTRACT(CMBCONTRACTOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcontractor_Validating(sender As Object, e As CancelEventArgs) Handles CMBCONTRACTOR.Validating
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then CONTRACTVALIDATE(CMBCONTRACTOR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IssueToPacking_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "AVIS" Then CHKSLTP.Visible = True
            If ClientName = "KARAN" Then
                LBLWEAVERNAME.Visible = True
                CMBWEAVERNAME.Visible = True
                LBLWEAVERCHNO.Visible = True
                TXTWEAVERCHNO.Visible = True
                LBLCHALLANNO.Visible = True
                TXTCHALLANNO.Visible = True
                GGREYMTRS.Visible = True
                TabControl1.Width += 80
                GRIDISSUE.Width += 80
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVERNAME_Enter(sender As Object, e As EventArgs) Handles CMBWEAVERNAME.Enter
        Try
            If CMBWEAVERNAME.Text.Trim = "" Then fillname(CMBWEAVERNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVERNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBWEAVERNAME.Validating
        Try
            If CMBWEAVERNAME.Text.Trim <> "" Then namevalidate(CMBWEAVERNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                Dim GREYMTRS As Double = 0.0
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown ", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDISSUE.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next


                    'GET GREYMTRS FOR KARAN
                    If ClientName = "KARAN" Then
                        Dim DTGREY As New DataTable
                        If DT.Rows(0).Item("TYPE") = "MATREC" Then
                            DTGREY = OBJCMN.search("ISNULL(MATREC_MTRS,0) AS GREYMTRS", "", " MATERIALRECEIPT_DESC ", " AND MATREC_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND MATREC_YEARID = " & YearId)
                        ElseIf DT.Rows(0).Item("TYPE") = "JOBIN" Then
                            DTGREY = OBJCMN.search("ISNULL(JI_MTRS,0) AS GREYMTRS", "", " JOBIN_DESC ", " AND JI_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND JI_YEARID = " & YearId)
                        End If
                        If DTGREY.Rows.Count > 0 Then GREYMTRS = Val(DTGREY.Rows(0).Item("GREYMTRS"))
                    End If

                    GRIDISSUE.Rows.Add(GRIDISSUE.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("LOTNO"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), 1, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), 0, 0, DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), GREYMTRS)
                    total()
                    GRIDISSUE.FirstDisplayedScrollingRowIndex = GRIDISSUE.RowCount - 1

LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
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