
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class YarnRecdFromDyeing

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPYARNNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        cmbname.Text = ""
        cmbname.Enabled = True
        CMBLOTNO.Text = ""
        CMBLOTNO.Enabled = True

        cmbtrans.Text = ""
        TXTCHALLANNO.Clear()
        txtlrno.Clear()
        CHALLANDATE.Value = Now.Date
        lrdate.Value = Now.Date
        YARNDATE.Text = Now.Date

        txtsrno.Clear()
        getmaxno()

        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        cmbcolor.DropDownStyle = ComboBoxStyle.DropDown
        TXTBAGS.Clear()
        TXTWT.Clear()
        GRIDMATREC.RowCount = 0

        LBLTOTALWT.Text = 0.0
        LBLTOTALBAGS.Text = 0
        TXTBALMTRS.Clear()

        If GRIDMATREC.RowCount > 0 Then
            txtsrno.Text = Val(GRIDMATREC.Rows(GRIDMATREC.RowCount - 1).Cells(0).Value) + 1
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
            LBLTOTALWT.Text = 0.0
            LBLTOTALBAGS.Text = 0

            For Each ROW As DataGridViewRow In GRIDMATREC.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALBAGS.Text = Format(Val(LBLTOTALBAGS.Text) + Val(ROW.Cells(GBAGS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbGodown.Focus()
    End Sub

    Private Sub YARNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub YARNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
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
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(YARNRECD_NO),0) + 1 ", " YARNRECDDYEING ", " AND YARNRECD_cmpid=" & CmpId & "  and YARNRECD_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTYARNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If TXTCHALLANNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTCHALLANNO, " Please Fill Challan No. ")
                bln = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Select Name ")
                bln = False
            End If

            If CMBLOTNO.Text.Trim.Length = 0 Then
                EP.SetError(CMBLOTNO, " Please Select Lot No")
                bln = False
            End If

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If


            If GRIDMATREC.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            For Each ROW As DataGridViewRow In GRIDMATREC.Rows
                If ROW.Cells(GWT.Index).Value = 0 Then
                    EP.SetError(TXTWT, "WT. Cannot be 0")
                    bln = False
                End If

            Next

            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" YARNRECD_challanno, LEDGERS.ACC_cmpname", "", " YARNRECDDYEING inner join LEDGERS on LEDGERS.ACC_id = YARNRECDDYEING.YARNRECD_ledgerid ", " and YARNRECDDYEING.YARNRECD_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND YARNRECD_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
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

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'THIS CODE IS OF NO USE NOW, COZ WE HAVE SAVED BARCODE ON SP
            'If Not CHECKBARCODE() Then
            '    bln = False
            '    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
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
            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBLOTNO.Text.Trim)

            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(CHALLANDATE.Value.Date)


            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(Val(LBLTOTALBAGS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)



            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BAGS As String = ""
            Dim WT As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDMATREC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        YARNQUALITY = row.Cells(gyarnquality.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BAGS = Val(row.Cells(GBAGS.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(gyarnquality.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BAGS = BAGS & "|" & Val(row.Cells(GBAGS.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BAGS)
            alParaval.Add(WT)


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

            Dim OBJYARN As New ClsYarnRecdFromDyeing()
            OBJYARN.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJYARN.SAVE()
                MsgBox("Details Added")
                TXTYARNNO.Text = DTTABLE.Rows(0).Item(0)
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPYARNNO)
                IntResult = OBJYARN.UPDATE()
                MsgBox("Details Updated")
            End If



            edit = False

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next

            clear()
            cmbGodown.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub YarnRecdFromDyeing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
            GRIDMATREC.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub MaterialReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJMATREC As New ClsYarnRecdFromDyeing()
                Dim dttable As New DataTable

                dttable = OBJMATREC.SELECTYARN(TEMPYARNNO, CmpId, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYARNNO.Text = TEMPYARNNO
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        cmbname.Enabled = False
                        CMBLOTNO.Text = dr("LOTNO")


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")

                        LBLTOTALBAGS.Text = Val(dr("TOTALBAGS"))
                        LBLTOTALWT.Text = Val(dr("TOTALWT"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)

                        'Item Grid
                        GRIDMATREC.Rows.Add(dr("GRIDSRNO").ToString, dr("YARNQUALITY").ToString, dr("MILLNAME").ToString, dr("DESIGN").ToString, dr("COLOR"), Val(dr("BAGS")), Format(Val(dr("WT")), "0.00"))


                    Next

                    total()
                Else
                    edit = False
                    clear()
                End If

                'UPLOAD
                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNRECD_GRIDSRNO AS GRIDSRNO, YARNRECD_REMARKS AS REMARKS, YARNRECD_NAME AS NAME, YARNRECD_IMGPATH AS IMGPATH, YARNRECD_NEWIMGPATH AS NEWIMGPATH", "", " YARNRECDDYEING_UPLOAD ", " AND YARNRECD_NO = " & TEMPYARNNO & " AND YARNRECD_CMPID = " & CmpId & " AND YARNRECD_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If



            End If

            If GRIDMATREC.RowCount > 0 Then
                txtsrno.Text = Val(GRIDMATREC.Rows(GRIDMATREC.RowCount - 1).Cells(0).Value) + 1
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
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, edit)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            fillmill(CMBMILL, EDIT)
            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            fillDESIGN(CMBDESIGN, "")
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

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDMATREC.RowCount = 0
                TEMPYARNNO = Val(tstxtbillno.Text)
                If TEMPYARNNO > 0 Then
                    EDIT = True
                    MaterialReceipt_Load(sender, e)
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

        GRIDMATREC.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDMATREC.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, Val(TXTBAGS.Text.Trim), Format(Val(TXTWT.Text.Trim), "0.00"))
            getsrno(GRIDMATREC)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDMATREC.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)

            GRIDMATREC.Item(gyarnquality.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDMATREC.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim
            GRIDMATREC.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDMATREC.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDMATREC.Item(GBAGS.Index, TEMPROW).Value = Val(TXTBAGS.Text.Trim)
            GRIDMATREC.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False
        End If

        total()

        GRIDMATREC.FirstDisplayedScrollingRowIndex = GRIDMATREC.RowCount - 1

        txtsrno.Text = GRIDMATREC.RowCount + 1

        'cmbitemname.Text = ""
        'CMBQUALITY.Text = ""
        'CMBDESIGN.Text = ""
        'cmbcolor.Text = ""
        TXTBAGS.Clear()

        TXTWT.Clear()
        'txtqty.Clear()
        'cmbqtyunit.Text = ""


        txtsrno.Focus()

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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTYARNNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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

    Private Sub GRIDMATREC_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMATREC.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDMATREC.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                MaterialReceipt_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDMATREC.RowCount = 0 And TEMPYARNNO > 1 Then
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
            GRIDMATREC.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTYARNNO.Text.Trim
            clear()
            If Val(TXTYARNNO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                MaterialReceipt_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDMATREC.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDMATREC.CurrentRow.Index >= 0 And GRIDMATREC.Item(gsrno.Index, GRIDMATREC.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True

                txtsrno.Text = GRIDMATREC.Item(gsrno.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDMATREC.Item(gyarnquality.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDMATREC.Item(GMILLNAME.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDMATREC.Item(GDESIGN.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDMATREC.Item(gcolor.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                TXTBAGS.Text = GRIDMATREC.Item(GBAGS.Index, GRIDMATREC.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDMATREC.Item(GWT.Index, GRIDMATREC.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDMATREC.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMATREC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMATREC.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDMATREC.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDMATREC.Rows.RemoveAt(GRIDMATREC.CurrentRow.Index)
                getsrno(GRIDMATREC)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, TXTWT, Me)
    End Sub


    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKSRNO() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDMATREC.Rows
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And ROW.Index <> TEMPROW) Then
                    'If ROW.Cells(GCHECKSRNO.Index).Value = CMBCHECKSRNO.Text.Trim Then
                    '    EP.SetError(CMBCHECKSRNO, "Sr Already Present in Grid Below")
                    '    BLN = False
                    'End If
                End If
            Next
            Return BLN
        Catch ex As Exception

        End Try
    End Function

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

    Private Sub TXTBAGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBAGS.KeyPress
        numkeypress(e, TXTBAGS, Me)
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, "")
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

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            CMBLOTNO.Items.Clear()
            If EDIT = False And cmbname.Text.Trim <> "" Then
                'FILLLOTNO
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT LOTNO ", "", " YARNLOTVIEW ", " AND ISNULL(BALWT,0) > 0 AND JOBBERNAME = '" & cmbname.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        CMBLOTNO.Items.Add(DTROW("LOTNO"))
                    Next
                    cmbname.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        Try
            If CMBLOTNO.Text.Trim <> "" Then
                'FILL CHECKSRNO

                Dim OBJCMN As New ClsCommon

                Dim DT1 As DataTable = OBJCMN.search(" ISNULL(YARNLOTVIEW.BALWT,0)  AS BALWT ", "", " YARNLOTVIEW ", " AND YARNLOTVIEW.LOTNO = '" & CMBLOTNO.Text.Trim & "' AND JOBBERNAME = '" & cmbname.Text.Trim & "' AND YEARID = " & YearId)
                If DT1.Rows.Count > 0 Then
                    TXTBALMTRS.Text = DT1.Rows(0).Item("BALWT")
                    CMBLOTNO.Enabled = False
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGodown.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
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

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
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
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then fillmill(CMBMILL, EDIT)
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

    Private Sub TXTWT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTWT.Validating

        If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) <> 0 Then
            fillgrid()
            total()
        Else
            If CMBYARNQUALITY.Text.Trim = "" Then
                MsgBox("Please Fill Yarn Name")
                CMBYARNQUALITY.Focus()
                Exit Sub
            End If

            If Val(TXTWT.Text.Trim) <= 0 Then
                MsgBox("Please Fill Wt.")
                TXTWT.Focus()
                Exit Sub
            End If

        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Yarn Recd...?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTYARNNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim OBJMATREC As New ClsYarnRecdFromDyeing()
                    OBJMATREC.alParaval = alParaval
                    IntResult = OBJMATREC.Delete()
                    MsgBox("Material Receipt Deleted")
                    clear()
                    edit = False

                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgrndetails As New YarnRecdFromDyeingDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub
End Class