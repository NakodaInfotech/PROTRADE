
Imports BL
Imports System.IO

Public Class JobIn

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDMTRSDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPJOBINNO As Integer     'used for poation no while editing
    Dim TEMPROW, TEMPMTRSROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALJINO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        TXTFROM.Clear()
        TXTTO.Clear()

        EP.Clear()
        TXTJINO.Clear()
        JOBINDATE.Text = Now.Date
        GRIDBALESUMM.RowCount = 0
        TXTDMTRS.Clear()
        GRIDMTRS.RowCount = 0
        GBMTRS.Visible = False


        If ALLOWMANUALJINO = True Then
            TXTJINO.ReadOnly = False
            TXTJINO.BackColor = Color.LemonChiffon
        Else
            TXTJINO.ReadOnly = True
            TXTJINO.BackColor = Color.Linen
        End If

        tstxtbillno.Clear()
        CMBJONO.Items.Clear()
        TXTLOTNO.Clear()
        CMBBARCODE.Text = ""
        CMBBARCODE.Items.Clear()

        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        cmbname.Enabled = True
        cmbname.Text = ""
        CMBJONO.Text = ""
        CMBJONO.Enabled = True
        TXTCHALLAN.Clear()
        CHALLANDATE.Value = Now.Date
        TXTBALMTRS.Clear()
        TXTOUTMTRS.Clear()
        TXTRUNNINGBAL.Clear()
        TXTFROMNO.Clear()
        TXTFROMTYPE.Clear()
        TXTBALEWT.Clear()

        txtsrno.Clear()
        CMBPIECETYPE.Text = ""
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        TXTBALENO.Clear()
        CMBJOSRNO.Text = ""
        TXTJOMTRS.Clear()
        CMBOLDDESIGN.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTCUT.Clear()
        TXTWT.Clear()
        If ClientName = "DETLINE" Or ClientName = "KCRAYON" Then
            txtqty.Clear()
        Else
            txtqty.Text = 1
        End If
        If ClientName = "YASHVI" Or ClientName = "AVIS" Or ClientName = "KEMLINO" Then
            cmbqtyunit.Text = "LUMP"
        ElseIf ClientName = "INDRANI" Then
            cmbqtyunit.Text = "Pcs"
        Else
            cmbqtyunit.Text = ""
        End If
        TXTNOOFENTRIES.Clear()
        If ClientName = "INDRANI" Then TXTMTRS.Text = 1 Else TXTMTRS.Clear()
        CMBRACK.Text = ""
        CMBSHELF.Text = ""
        GRIDJOBIN.RowCount = 0

        txtadd.Clear()

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Now.Date
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        TXTRATE.Clear()
        LBLTOTALRATE.Text = 0.0
        CMBPROCESS.Text = ""


        lbllocked.Visible = False
        PBlock.Visible = False

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        getmaxno()
        LBLTOTALWT.Text = 0
        lbltotalqty.Text = 0
        LBLTOTALMTRS.Text = 0

        If GRIDJOBIN.RowCount > 0 Then
            txtsrno.Text = Val(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

        CMBPARTYNAME.Text = ""

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0
            LBLTOTALRATE.Text = 0.0

            Dim DONE As Boolean = False
            GRIDBALESUMM.RowCount = 0

            For Each ROW As DataGridViewRow In GRIDJOBIN.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRATE.Text = Format(Val(LBLTOTALRATE.Text) + Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")

                    DONE = False
                    If Val(ROW.Cells(gQty.Index).EditedFormattedValue) > 0 And ClientName = "KOCHAR" Then
                        If GRIDBALESUMM.RowCount = 0 Then
                            GRIDBALESUMM.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                        Else
                            For Each SUMMROW As DataGridViewRow In GRIDBALESUMM.Rows
                                If SUMMROW.Cells(DEBALENO.Index).Value = ROW.Cells(GBALENO.Index).Value Then
                                    SUMMROW.Cells(DEPCS.Index).Value = Val(SUMMROW.Cells(DEPCS.Index).Value) + Val(ROW.Cells(gQty.Index).EditedFormattedValue)
                                    SUMMROW.Cells(DEMTRS.Index).Value = Val(SUMMROW.Cells(DEMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue)
                                    DONE = True
                                End If
                            Next
                            If DONE = False Then GRIDBALESUMM.Rows.Add(ROW.Cells(GBALENO.Index).Value, Format(Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0"), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                        End If
                        GRIDBALESUMM.FirstDisplayedScrollingRowIndex = GRIDBALESUMM.RowCount - 1
                    End If
                End If
            Next
            TXTRUNNINGBAL.Text = Format(Val(TXTBALMTRS.Text.Trim) - Val(LBLTOTALMTRS.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbGodown.Focus()
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(JI_no),0) + 1 ", " JobIn ", " and JI_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTJINO.Text = DTTABLE.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True
            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Select Name ")
                bln = False
            End If

            If Val(TXTJINO.Text.Trim) = 0 Then
                EP.SetError(TXTJINO, "Enter Job In No")
                bln = False
            End If


            If ClientName = "KARAN" And TXTLOTNO.Text.Trim = "" And CMBPARTYNAME.Text.Trim <> "" Then
                EP.SetError(TXTLOTNO, "Please Enter Lot No in Job Out Entry First, Then make Job In Entry")
                bln = False
            End If


            If Val(CMBJONO.Text.Trim) = 0 Then
                EP.SetError(CMBJONO, " Please Select Job No")
                bln = False
            End If

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDJOBIN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If TXTCHALLAN.Text.Trim = "" And ClientName = "SBA" Then
                EP.SetError(TXTCHALLAN, "Enter Challan No.")
                bln = False
            End If

            If ClientName <> "AXIS" And ClientName <> "MOMAI" And ClientName <> "GELATO" Then
                For Each ROW As DataGridViewRow In GRIDJOBIN.Rows
                    If ROW.Cells(GMTRS.Index).Value = 0 Then
                        EP.SetError(TXTMTRS, "Mtrs Cannot be 0")
                        bln = False
                    End If
                Next
            End If


            If TXTCHALLAN.Text.Trim <> "" And ClientName <> "AXIS" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLAN.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" JI_challanno, LEDGERS.ACC_cmpname", "", " JOBIN inner join LEDGERS on LEDGERS.ACC_id = JI_ledgerid ", " and JI_challanno = '" & TXTCHALLAN.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND JI_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLAN, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If

            If JOBINDATE.Text = "__/__/____" Then
                EP.SetError(JOBINDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(JOBINDATE.Text) Then
                    EP.SetError(JOBINDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'THIS CODE IS OF NO USE NOW, COZ WE HAVE SAVED BARCODE ON SP
            'If Not CHECKBARCODE() Then
            '    bln = False
            '    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            'End If

            If ALLOWMANUALJINO = True Then
                If TXTJINO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBIN.JI_NO,0)  AS JINO", "", " JOBIN ", "  AND JOBIN.JI_NO=" & TXTJINO.Text.Trim & " AND JOBIN.JI_CMPID = " & CmpId & " AND JOBIN.JI_LOCATIONID = " & Locationid & " AND JOBIN.JI_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTJINO, "Job In No Already Exist")
                        bln = False
                    End If
                End If
            End If

            If ClientName = "PURVITEX" Then
                If CMBPARTYNAME.Text.Trim.Length = 0 Then
                    If MsgBox("Party Name Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        EP.SetError(CMBPARTYNAME, "Enter Party Name.....")
                        bln = False
                    End If
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

            If TXTJINO.ReadOnly = False Then
                alParaval.Add(Val(TXTJINO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(JOBINDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBPARTYNAME.Text.Trim)
            alParaval.Add(TXTCHALLAN.Text.Trim)
            alParaval.Add(CHALLANDATE.Value.Date)
            alParaval.Add(TXTWEAVERCHNO.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(TXTBALMTRS.Text.Trim)
            alParaval.Add(TXTOUTMTRS.Text.Trim)

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(TXTBALEWT.Text.Trim)
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALRATE.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBJONO.Text.Trim)
            alParaval.Add(TXTTYPE.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim BALENO As String = ""
            Dim JOSRNO As String = ""
            Dim JOMTRS As String = ""
            Dim OLDDESIGN As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim CUT As String = ""
            Dim WT As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""
            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDJOBIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        JOSRNO = Val(row.Cells(GJOGRIDSRNO.Index).Value)
                        JOMTRS = Val(row.Cells(GJOMTRS.Index).Value)
                        OLDDESIGN = row.Cells(GOLDDESIGN.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        CUT = row.Cells(gcut.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        RATE = row.Cells(GRATE.Index).Value
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
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        JOSRNO = JOSRNO & "|" & Val(row.Cells(GJOGRIDSRNO.Index).Value)
                        JOMTRS = JOMTRS & "|" & Val(row.Cells(GJOMTRS.Index).Value)
                        OLDDESIGN = OLDDESIGN & "|" & row.Cells(GOLDDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(gcut.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
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
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(BALENO)
            alParaval.Add(JOSRNO)
            alParaval.Add(JOMTRS)
            alParaval.Add(OLDDESIGN)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(CUT)
            alParaval.Add(WT)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)

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

            Dim OBJJobIn As New ClsJobIn()
            OBJJobIn.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJJobIn.SAVE()
                MsgBox("Details Added")
                TXTJINO.Text = DTTABLE.Rows(0).Item(0)
                If ClientName <> "MJFABRIC" Then PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPJOBINNO)
                IntResult = OBJJobIn.Update()
                MsgBox("Details Updated")
                If ClientName <> "MJFABRIC" Then PRINTREPORT(TEMPJOBINNO)
            End If

            If ClientName <> "MJFABRIC" Then PRINTBARCODE()

            EDIT = False

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next



            'DIRECTLY ISSUE TO PACKING
            If EDIT = False And (ClientName = "KARAN") Then
                If MsgBox("Issue Grey Directly to Packing?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then DIRECTISSUEPACKING()
            End If


            'DIRECTLY ISSUE TO JOBOUT
            If EDIT = False And (ClientName = "KRISHNA" Or ClientName = "REAL") Then
                If MsgBox("Issue Directly to Jobber?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJISSUE As New YarnDirectIssueJobber
                    OBJISSUE.ShowDialog()
                    If OBJISSUE.CMBJOBBER.Text.Trim = "" Then GoTo LINE1
                    DIRECTJOBOUT(OBJISSUE.CMBJOBBER.Text.Trim, OBJISSUE.CMBPROCESS.Text.Trim, OBJISSUE.txtremarks.Text.Trim)
                End If
            End If
LINE1:

            clear()
            cmbGodown.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DIRECTJOBOUT(JOBBERNAME As String, PROCESS As String, REMARKS As String)
        Try

            'GET FRESH DATA FROM DATABASE (ONLY GRID)
            'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
            'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
            GRIDJOBIN.RowCount = 0
            Dim OBJJobin As New ClsJobIn()
            Dim dttable As New DataTable
            dttable = OBJJobin.SELECTJobin(Val(TXTJINO.Text.Trim), CmpId, Locationid, YearId)
            For Each dr As DataRow In dttable.Rows
                'GRIDJOBIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("JOSRNO"), dr("JOMTRS"), dr("OLDDESIGN").ToString, dr("DESIGN").ToString, dr("COLOR"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"), 0, 0, 0)
                GRIDJOBIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("JOSRNO"), dr("JOMTRS"), dr("OLDDESIGN").ToString, dr("DESIGN").ToString, dr("COLOR"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"), 0, 0, 0)

            Next



            Dim alParaval As New ArrayList
            alParaval.Add(0)       'JONO
            alParaval.Add(Format(Convert.ToDateTime(JOBINDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(JOBBERNAME)
            alParaval.Add(PROCESS)
            alParaval.Add("")       'PARTYNAME
            alParaval.Add(TXTLOTNO.Text.Trim) 'LOTNO
            alParaval.Add(TXTCHALLAN.Text.Trim) 'CHALLANNO
            alParaval.Add(cmbtrans.Text.Trim) 'TRANSPORT
            alParaval.Add("")       'LRNO
            alParaval.Add(Format(Convert.ToDateTime(JOBINDATE.Text).Date, "MM/dd/yyyy"))    'LR DATE
            alParaval.Add("")       'VEHICLENO
            alParaval.Add("")       'FROMCITY
            alParaval.Add("")       'TOCITY
            alParaval.Add("")       'PACKING
            alParaval.Add("")       'EWAYBILLNO
            alParaval.Add(0)        'NOOFBALES
            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALRATE.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(0)        'LOTREADY
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            'Dim LOTNO As String = ""
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
            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim GREYMTRS As String = ""
            Dim FRAMES As String = ""
            Dim EMBPRODDONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDJOBIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        'LOTNO = TXTLOTNO.Text.Trim
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString

                        DESCRIPTION = ""
                        CUT = row.Cells(gcut.Index).Value.ToString

                        PCS = row.Cells(gQty.Index).Value
                        UNIT = row.Cells(gqtyunit.Index).Value
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value.ToString
                        RATE = row.Cells(GRATE.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        OUTPCS = 0
                        OUTMTRS = 0
                        FROMNO = TXTJINO.Text.Trim
                        FROMSRNO = row.Cells(gsrno.Index).Value.ToString
                        FROMTYPE = "JOBIN"
                        GREYMTRS = Val(row.Cells(GJOMTRS.Index).Value)
                        FRAMES = 0
                        EMBPRODDONE = 0

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value.ToString
                        'LOTNO = LOTNO & "|" & TXTLOTNO.Text.Trim
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        DESCRIPTION = DESCRIPTION & "|" & ""
                        CUT = CUT & "|" & row.Cells(gcut.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(gQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        WT = WT & "|" & row.Cells(GWT.Index).Value.ToString
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(TXTJINO.Text.Trim)
                        FROMSRNO = FROMSRNO & "|" & row.Cells(gsrno.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & "JOBIN"
                        GREYMTRS = GREYMTRS & "|" & Val(row.Cells(GJOMTRS.Index).Value)
                        FRAMES = FRAMES & "|" & 0
                        EMBPRODDONE = EMBPRODDONE & "|" & 0
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(BALENO)
            alParaval.Add(ITEMNAME)
            'alParaval.Add(LOTNO)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(DESCRIPTION)
            alParaval.Add(CUT)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(BARCODE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(GREYMTRS)

            alParaval.Add(FRAMES)
            alParaval.Add(EMBPRODDONE)

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            alParaval.Add("")       'CMBTYPE
            alParaval.Add(0)        'TXTTYPEJONO

            Dim OBJJO As New ClsCuttingIssue()
            OBJJO.alParaval = alParaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            dttable = OBJJO.SAVE()
            MsgBox("Entry Issued to Jobber")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub DIRECTISSUEPACKING()
        Try


            'GET FRESH DATA FROM DATABASE (ONLY GRID)
            'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
            'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
            GRIDJOBIN.RowCount = 0
            Dim OBJJobin As New ClsJobIn()
            Dim dttable As New DataTable
            dttable = OBJJobin.SELECTJobin(Val(TXTJINO.Text.Trim), CmpId, Locationid, YearId)
            For Each dr As DataRow In dttable.Rows
                GRIDJOBIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("JOSRNO"), dr("JOMTRS"), dr("OLDDESIGN").ToString, dr("DESIGN").ToString, dr("COLOR"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"), 0, 0, 0)
            Next



            Dim alParaval As New ArrayList
            alParaval.Add(Format(Convert.ToDateTime(JOBINDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add("")       'CONTRACTOR
            alParaval.Add(TXTCHALLAN.Text.Trim) 'REFNO
            alParaval.Add(0)        'SLTP


            alParaval.Add(CMBPARTYNAME.Text.Trim) 'WEAVERNAME
            alParaval.Add(TXTWEAVERCHNO.Text.Trim) 'WEAVERCHNO
            alParaval.Add(TXTCHALLAN.Text.Trim) 'CHALLANNO


            alParaval.Add(Val(lbltotalqty.Text))
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

            For Each row As Windows.Forms.DataGridViewRow In GRIDJOBIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString

                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        LOTNO = TXTLOTNO.Text.Trim
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        PCS = row.Cells(gQty.Index).Value.ToString
                        UNIT = row.Cells(gqtyunit.Index).Value
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        OUTPCS = 0
                        OUTMTRS = 0
                        FROMNO = TXTJINO.Text.Trim
                        FROMSRNO = row.Cells(gsrno.Index).Value.ToString
                        FROMTYPE = "JOBIN"
                        GREYMTRS = Val(row.Cells(GJOMTRS.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value.ToString

                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value.ToString
                        LOTNO = LOTNO & "|" & TXTLOTNO.Text.Trim
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(gQty.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(TXTJINO.Text.Trim)
                        FROMSRNO = FROMSRNO & "|" & row.Cells(gsrno.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & "JOBIN"
                        GREYMTRS = GREYMTRS & "|" & Val(row.Cells(GJOMTRS.Index).Value)

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

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            Dim OBJISSUE As New ClsIssueToPacking()
            OBJISSUE.alParaval = alParaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            dttable = OBJISSUE.SAVE()
            MsgBox("Grey Issued to Packing")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then


                If ClientName = "PARAS" And UserName <> "Admin" Then Exit Sub

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'GET FRESH DATA FROM DATABASE (ONLY GRID)
                'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
                'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
                GRIDJOBIN.RowCount = 0
                Dim OBJJobin As New ClsJobIn()
                Dim dttable As DataTable = OBJJobin.SELECTJobin(Val(TXTJINO.Text.Trim), CmpId, Locationid, YearId)
                For Each dr As DataRow In dttable.Rows
                    GRIDJOBIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("JOSRNO"), dr("JOMTRS"), dr("OLDDESIGN").ToString, dr("DESIGN").ToString, dr("COLOR"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"), 0, 0, 0)
                Next

                Dim WHOLESALEBARCODE As Integer = 0
                If ClientName = "CC" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)


                Dim TEMPHEADER As String = ""
                If ClientName = "YASHVI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (M/N/O/P)")
                    If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "O" And TEMPHEADER <> "P" And TEMPHEADER <> "Y" Then Exit Sub
                    If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
                    If TEMPHEADER = "N" Or TEMPHEADER = "P" Then TEMPHEADER = ""
                    If TEMPHEADER = "O" Then TEMPHEADER = "ORGALIN"
                    If TEMPHEADER = "Y" Then TEMPHEADER = "PREPRINTED"
                End If

                If ClientName = "GELATO" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
                End If

                If ClientName = "MANALI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR PRE PRINTED")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "MANS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR SALVATROE" & Chr(13) & "2 FOR MANS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If


                If ClientName = "AXIS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR PCS" & Chr(13) & "2 FOR MTRS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "KRISHNA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR BOX STICKER")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                Dim SUPRIYAHEADER As String = ""
                If ClientName = "SUPRIYA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
                    If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
                    If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
                    If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
                    If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
                    If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
                End If


                For Each ROW As DataGridViewRow In GRIDJOBIN.Rows
                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If
                    Dim GRIDDESC As String = ""
                    If ClientName = "KCRAYON" Then GRIDDESC = ROW.Cells(GBALENO.Index).Value
                    'FOR DAKSH WE ARE PASSING REMARKS IN GRIDDESC AS WE WANT TO PRINT THIS REMARKS IN BARCODE
                    If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Then GRIDDESC = txtremarks.Text.Trim

                    BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(gitemname.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(gcolor.Index).Value, ROW.Cells(gqtyunit.Index).Value, TXTLOTNO.Text.Trim, ROW.Cells(GBALENO.Index).Value, GRIDDESC, Val(ROW.Cells(GMTRS.Index).Value), Val(ROW.Cells(gQty.Index).Value), Val(ROW.Cells(gcut.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If

            '                    Dim dirresults As String = ""
            '                    'Writing in file
            '                    Dim oWrite As System.IO.StreamWriter
            '                    oWrite = File.CreateText("D:\Barcode.txt")

            '                    'TO PRINT BARCODE FROM SELECTED SRNO
            '                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
            '                        If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
            '                    End If



            '                    If ClientName = "SVS" Then
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q400")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q200,25")
            '                        oWrite.WriteLine("KI80")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>N")
            '                        oWrite.WriteLine("A376,160,2,2,1,1,N,""QUALITY""")
            '                        oWrite.WriteLine("A376,114,2,2,1,1,N,""D.NO""")
            '                        oWrite.WriteLine("A376,136,2,2,1,1,N,""SHADE""")
            '                        oWrite.WriteLine("B384,91,2,1,2,4,61,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A279,24,2,2,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A197,114,2,2,1,1,N,""QTY""")
            '                        oWrite.WriteLine("A376,183,2,2,1,1,N,""" & CmpName & """")    'cmpname
            '                        oWrite.WriteLine("A277,114,2,2,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A291,114,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A291,136,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A277,136,2,2,1,1,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A291,162,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A277,162,2,2,1,1,N,""" & ROW.Cells(GQUALITY.Index).Value & """")
            '                        oWrite.WriteLine("A157,114,2,2,1,1,N,"":""")
            '                        'oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & " MTR""")
            '                        oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & " " & ROW.Cells(gqtyunit.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MNARESH" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q799")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q400,25")
            '                        oWrite.WriteLine("Arglabel 500 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A770,367,2,2,2,2,N,""ITEM""")
            '                        oWrite.WriteLine("B776,132,2,1,4,8,78,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A538,48,2,1,2,2,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A770,200,2,2,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A651,367,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A651,200,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,367,2,2,2,2,N,""" & ROW.Cells(gitemname.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A625,200,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A289,214,2,3,3,3,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A421,200,2,2,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A318,200,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A770,256,2,2,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A651,256,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,256,2,2,2,2,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A770,312,2,2,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A651,312,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,312,2,2,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MANINATH" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q812")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q406,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A772,386,2,4,2,2,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A772,310,2,3,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A772,243,2,3,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A772,174,2,3,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("B772,110,2,1,3,6,67,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A592,37,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A367,174,2,3,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A608,310,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A608,243,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A608,174,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A219,174,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A580,310,2,3,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A580,243,2,3,2,2,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A580,174,2,3,2,2,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A184,174,2,3,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DEVEN" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q609")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q426,25")
            '                        oWrite.WriteLine("Arglabel 533 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A562,385,2,2,3,3,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A563,313,2,1,2,2,N,""LOT""")
            '                        oWrite.WriteLine("A456,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A433,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A202,313,2,1,2,2,N,""CMS""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A105,313,2,1,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A133,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A563,259,2,1,2,2,N,""D NO""")
            '                        oWrite.WriteLine("A455,259,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A432,259,2,1,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A223,259,2,1,2,2,N,""S NO""")
            '                        oWrite.WriteLine("A104,259,2,1,2,2,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A132,259,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A563,206,2,1,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A455,206,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A432,206,2,1,3,3,N,""" & ROW.Cells(GMTRS.Index).Value & """")
            '                        oWrite.WriteLine("B583,142,2,1,3,6,89,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("A411,47,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RSONS" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("q629")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("WN")
            '                        oWrite.WriteLine("D9")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q305,25")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>N")
            '                        oWrite.WriteLine("A618,234,2,4,1,1,N,""DESIGN""")
            '                        oWrite.WriteLine("B618,107,2,1,3,6,73,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A433,28,2,3,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A618,271,2,4,1,1,N,""QUALITY""")
            '                        oWrite.WriteLine("A334,234,2,4,1,1,N,""COLOR""")
            '                        oWrite.WriteLine("A618,159,2,4,1,1,N,""WIDTH""")
            '                        oWrite.WriteLine("A507,271,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A507,234,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A246,234,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A506,159,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A478,271,2,4,1,1,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A478,234,2,4,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A229,234,2,4,1,1,N,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A478,159,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A318,159,2,4,1,1,N,""MTRS""")
            '                        oWrite.WriteLine("A246,159,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A233,167,2,3,2,2,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A618,197,2,4,1,1,N,""FABRIC""")
            '                        oWrite.WriteLine("A507,197,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A478,197,2,4,1,1,N,""" & ROW.Cells(GQUALITY.Index).Value & """")
            '                        oWrite.WriteLine("A67,167,2,3,2,2,N,""" & ROW.Cells(GBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SANGHVI" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q406")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q305,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A386,197,2,4,1,1,N,""COLOR""")
            '                        oWrite.WriteLine("A386,155,2,4,1,1,N,""MTRS""")
            '                        oWrite.WriteLine("A300,197,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A300,155,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A362,280,2,4,1,1,N,""TINU MINU EMBROIDERY""")
            '                        oWrite.WriteLine("A151,239,2,4,1,1,N,""WIDTH""")
            '                        oWrite.WriteLine("A277,197,2,4,1,1,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A277,155,2,4,1,1,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A51,239,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A67,239,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("B390,112,2,1,2,4,63,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A313,43,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A386,239,2,4,1,1,N,""D.NO""")
            '                        oWrite.WriteLine("A300,239,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A278,239,2,4,1,1,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A151,155,2,4,1,1,N,""" & ROW.Cells(GBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MJFABRIC" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q799")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q400,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A774,312,2,2,2,2,N,""QUALITY""")
            '                        oWrite.WriteLine("A774,365,2,2,2,2,N,""DESIGN""")
            '                        oWrite.WriteLine("A774,252,2,2,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A774,193,2,2,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A355,193,2,2,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("B782,141,2,1,4,8,90,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A543,45,2,1,2,2,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A598,365,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,312,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,252,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,193,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A247,193,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A558,365,2,2,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A558,314,2,2,2,2,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A558,254,2,2,2,2,N,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A558,193,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A213,205,2,4,2,2,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KCRAYON" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 783,377,""2"",180,3,3,""" & ROW.Cells(GDESIGN.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 783,283,""2"",180,2,2,""SHADE""")
            '                        If ROW.Cells(GBALENO.Index).Value <> "" Then oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""TP""") Else oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""""")
            '                        oWrite.WriteLine("TEXT 405,216,""2"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 783,216,""2"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("TEXT 265,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 672,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 631,283,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 603,283,""2"",180,2,2,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 631,216,""2"",180,2,2,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 237,216,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("BARCODE 783,161,""128M"",95,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 601,55,""2"",180,2,2,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KDFAB" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='101.6 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q792")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q812,25")
            '                        oWrite.WriteLine("Arglabel 1016 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='101.6 mm'></xpml>N")
            '                        oWrite.WriteLine("B761,309,2,1,3,6,161,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A717,134,2,4,2,2,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A754,563,2,3,2,2,N,""NAME""")
            '                        oWrite.WriteLine("A754,477,2,3,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A754,391,2,3,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A637,563,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A637,477,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A637,391,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A606,563,2,3,2,2,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A606,477,2,3,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A595,400,2,2,4,4,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")

            '                        oWrite.WriteLine("A113,477,2,3,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A294,391,2,3,2,2,N,""" & ROW.Cells(GBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "BRILLANTO" Then

            '                        oWrite.WriteLine("I8,A,001")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("Q384,024")
            '                        oWrite.WriteLine("q863")
            '                        oWrite.WriteLine("rN")
            '                        oWrite.WriteLine("S3")
            '                        oWrite.WriteLine("D14")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("R253,0")
            '                        oWrite.WriteLine("f100")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A341,164,2,3,1,1,N,""Grade""")
            '                        oWrite.WriteLine("A342,202,2,3,1,1,N,""Shade No.""")
            '                        oWrite.WriteLine("A344,238,2,3,1,1,N,""Width""")
            '                        oWrite.WriteLine("A344,274,2,3,1,1,N,""Mtrs""")
            '                        oWrite.WriteLine("A342,309,2,3,1,1,N,""M. Name""")
            '                        oWrite.WriteLine("A213,164,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,202,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,238,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,274,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,309,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,345,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A198,164,2,3,1,1,N,""" & ROW.Cells(GPIECETYPE.Index).Value & """")
            '                        oWrite.WriteLine("A198,202,2,3,1,1,N,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        oWrite.WriteLine("A198,238,2,3,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A111,273,2,3,1,1,N,""" & ROW.Cells(gqtyunit.Index).Value & """")

            '                        oWrite.WriteLine("A198,274,2,3,1,1,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A198,309,2,3,1,1,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A198,345,2,3,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A342,345,2,3,1,1,N,""Design No""")
            '                        oWrite.WriteLine("B352,122,2,1,2,6,81,B,""" & ROW.Cells(GBARCODE.Index).Value & """")

            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MIDAS" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1401220034" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911A1001000012D. NO")
            '                        oWrite.WriteLine("1X1100001190011L226001")
            '                        oWrite.WriteLine("1911A1000800012SHADE")
            '                        oWrite.WriteLine("1911A1000600012MTRS")
            '                        oWrite.WriteLine("1e4203200240011B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A0800100062" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1001000074:")
            '                        oWrite.WriteLine("1911A1000800074:")
            '                        oWrite.WriteLine("1911A1000600074:")
            '                        oWrite.WriteLine("1911A1001000086" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911A1000800086" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911C1200590086" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911A1000600164PCS-" & Format(Val(ROW.Cells(gQty.Index).Value), "0"))
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "TCOT" Then

            '                        oWrite.WriteLine("G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0690")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1202480037QLTY")
            '                        oWrite.WriteLine("1911C1202250037DSGN.NO")
            '                        oWrite.WriteLine("1911C1202040037CH.NO.")
            '                        oWrite.WriteLine("1911C1201820037SHD.NO.")
            '                        oWrite.WriteLine("1911C1201600037LOT NO")
            '                        oWrite.WriteLine("1911C1201380037WIDTH")
            '                        oWrite.WriteLine("1911C1201160037MTRS")
            '                        oWrite.WriteLine("1911C1200940037GRADE")
            '                        oWrite.WriteLine("1911C1200710037RACK")
            '                        oWrite.WriteLine("1911C1202480124:")
            '                        oWrite.WriteLine("1911C1202250124:")
            '                        oWrite.WriteLine("1911C1202040124:")
            '                        oWrite.WriteLine("1911C1201820124:")
            '                        oWrite.WriteLine("1911C1201600124:")
            '                        oWrite.WriteLine("1911C1200940124:")
            '                        oWrite.WriteLine("1911C1201160124:")
            '                        oWrite.WriteLine("1911C1201380124:")
            '                        oWrite.WriteLine("1911C1200710124:")
            '                        oWrite.WriteLine("1e6303300310036B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1200110114" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1202480138" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911C1202250138" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1202040138" & ROW.Cells(GBALENO.Index).Value)
            '                        oWrite.WriteLine("1911C1201820138" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911C1201600138")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")


            '                        oWrite.WriteLine("1911C1201380138" & TEMPWIDTH)
            '                        oWrite.WriteLine("1911C1201160138" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911C1200710138" & ROW.Cells(GRACK.Index).Value)
            '                        oWrite.WriteLine("1911C1200940138" & ROW.Cells(GPIECETYPE.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SAFFRON" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("I8,A,001")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("Q400,024")
            '                        oWrite.WriteLine("q831")
            '                        oWrite.WriteLine("rN")
            '                        oWrite.WriteLine("S5")
            '                        oWrite.WriteLine("D2")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("R136,0")
            '                        oWrite.WriteLine("f100")
            '                        oWrite.WriteLine("N")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCONTAIN As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(CATEGORYMASTER.category_remarks, '') AS WIDTH, ISNULL(ITEMMASTER.item_remarks, '') AS CONTAIN , ISNULL(ITEMMASTER.item_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(HSN_CODE,'') AS HSNCODE ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCONTAIN = DT.Rows(0).Item("CONTAIN")
            '                        End If

            '                        oWrite.WriteLine("A419,146,0,1,3,3,N,""" & DT.Rows(0).Item("HSNCODE") & """")    'HSNCODE
            '                        oWrite.WriteLine("A151,154,0,1,2,2,N,""" & TEMPWIDTH & """")    'GIVE ITEM CATEGORY'S REMARKS
            '                        oWrite.WriteLine("A133,102,0,1,3,3,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")    'MTRS
            '                        oWrite.WriteLine("A459,104,0,1,3,3,N,""" & ROW.Cells(gcolor.Index).Value & """")       'COLOR
            '                        oWrite.WriteLine("A8,6,0,1,3,3,N,""" & DT.Rows(0).Item("DISPLAYNAME") & """")       'QUALITY
            '                        oWrite.WriteLine("A171,199,0,1,2,2,N,""" & TEMPCONTAIN & """")        'ITEMREMARKS
            '                        oWrite.WriteLine("A231,57,0,1,3,3,N,""" & ROW.Cells(gitemname.Index).Value & """")      'ITEMNAME
            '                        oWrite.WriteLine("A11,200,0,1,2,2,N,""Contain:""")
            '                        oWrite.WriteLine("A318,154,0,1,2,2,N,""HSN :""")
            '                        oWrite.WriteLine("A318,111,0,1,2,2,N,""Shade :""")
            '                        oWrite.WriteLine("A11,153,0,1,2,2,N,""Width :""")
            '                        oWrite.WriteLine("A11,60,0,1,2,2,N,""Design No :""")
            '                        oWrite.WriteLine("A11,107,0,1,2,2,N,""Mtrs :""")
            '                        oWrite.WriteLine("B8,257,0,1,2,6,87,B,""" & ROW.Cells(GBARCODE.Index).Value & """")       'BARCODE
            '                        oWrite.WriteLine("P1")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MARKIN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='75.1 mm'></xpml>SIZE 97.5 mm, 75.1 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='75.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 709,566,""0"",180,16,16,""" & CmpName & """")
            '                        oWrite.WriteLine("TEXT 738,421,""0"",180,14,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 738,353,""0"",180,14,14,""COLOR""")
            '                        oWrite.WriteLine("TEXT 738,285,""0"",180,14,14,""LOTNO""")
            '                        oWrite.WriteLine("TEXT 738,488,""0"",180,14,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 738,216,""0"",180,14,14,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 738,160,""128M"",74,0,180,3,6,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 597,79,""0"",180,16,16,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 527,488,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,421,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,353,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,285,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,216,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 498,488,""0"",180,14,14,""" & ROW.Cells(gitemname.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 498,421,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 498,353,""0"",180,14,14,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 498,285,""0"",180,14,14,""" & TXTLOTNO.Text.Trim & """")
            '                        oWrite.WriteLine("TEXT 498,227,""0"",180,22,22,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BAR 43,505, 695, 3")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MOMAI" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>SIZE 47.5 mm, 25 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 365,188,""0"",180,14,14,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 365,146,""0"",180,14,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 365,102,""0"",180,9,9,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 172,101,""0"",180,8,8,""MRP""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPMRP As Double
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search("ISNULL(PL_RATE,0) AS RATE", "", "PRICELISTMASTER LEFT OUTER JOIN ITEMMASTER ON PL_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON PL_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON PL_COLORID = COLORMASTER.COLOR_ID", " AND ITEMMASTER.ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND DESIGNMASTER.DESIGN_NO = '" & ROW.Cells(GDESIGN.Index).Value & "' AND PL_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPMRP = Val(DT.Rows(0).Item("RATE"))
            '                        End If

            '                        oWrite.WriteLine("TEXT 119,107,""0"",180,13,13, """ & TEMPMRP & """")
            '                        oWrite.WriteLine("TEXT 98,71,""0"",180,4,4,""(Inc. of all Taxes)""")
            '                        oWrite.WriteLine("TEXT 68,138,""0"",180,7,7,""1PCS""")
            '                        oWrite.WriteLine("BARCODE 365,72,""128M"",52,0,180,1,2, """ & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 325,17,""0"",180,6,6, """ & ROW.Cells(GBARCODE.Index).Value & """")

            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SHALIBHADRA" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.4 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q406")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q203,25")
            '                        oWrite.WriteLine("KI80")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.4 mm'></xpml>N")
            '                        oWrite.WriteLine("B369,101,2,1,2,4,51,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A295,43,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A380,179,2,4,1,1,N,""Lot""")
            '                        oWrite.WriteLine("A380,138,2,4,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A309,179,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A292,179,2,4,1,1,N,""""")
            '                        oWrite.WriteLine("A308,138,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A292,138,2,4,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A124,186,2,4,1,1,N,""Mtrs""")
            '                        oWrite.WriteLine("A176,150,2,3,2,2,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DAKSH" Then

            '                        oWrite.WriteLine("G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C2401560027LINEN VENZO")
            '                        oWrite.WriteLine("1X1100001550005L263001")
            '                        oWrite.WriteLine("1e4203600230043B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1000060084" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1401280011" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911C1001090012SHADE")
            '                        oWrite.WriteLine("1911C1000610012QUALITY")
            '                        oWrite.WriteLine("1911C1001090077:")
            '                        oWrite.WriteLine("1911C1000610077:")
            '                        oWrite.WriteLine("1911C1401060086" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911C1000610086" & ROW.Cells(GQUALITY.Index).Value)
            '                        oWrite.WriteLine("1911C1000840012MTRS")
            '                        oWrite.WriteLine("1911C1000840077:")
            '                        oWrite.WriteLine("1911C1400810086" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911C1001090162D. NO")
            '                        oWrite.WriteLine("1911C1001090204:")
            '                        oWrite.WriteLine("1911C1201080212" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1000840162LOT")
            '                        oWrite.WriteLine("1911C1000840204:")
            '                        oWrite.WriteLine("1911C1000840213" & TXTLOTNO.Text.Trim)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "PARAS" Then

            '                        oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 620,371,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 600,374,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 782,371,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 782,310,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 600,310,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 620,310,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 360,310,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 237,310,""ROMAN.TTF"",180,1,14,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 211,310,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                        oWrite.WriteLine("TEXT 782,249,""ROMAN.TTF"",180,1,14,""LOTNO""")
            '                        oWrite.WriteLine("TEXT 620,249,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 600,249,""ROMAN.TTF"",180,1,14,""" & TXTLOTNO.Text.Trim & """")
            '                        oWrite.WriteLine("TEXT 363,249,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 231,249,""ROMAN.TTF"",180,1,14,"": """)
            '                        oWrite.WriteLine("TEXT 211,249,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 782,187,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 620,187,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("BARCODE 776,134,""128M"",83,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 499,47,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 600,192,""ROMAN.TTF"",180,1,18,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "ARIHANT" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("BARCODE 508,154,""128M"",106,0,180,2,4,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 408,42,""0"",180,10,10,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 508,378,""0"",180,16,16,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 508,316,""0"",180,12,12,""D.NO""")
            '                        oWrite.WriteLine("TEXT 508,265,""0"",180,12,12,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 166,316,""0"",180,12,12,""" & TXTLOTNO.Text.Trim & """")
            '                        oWrite.WriteLine("TEXT 508,210,""0"",180,12,12,""MTRS""")
            '                        oWrite.WriteLine("TEXT 405,316,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 405,265,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 405,210,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 377,316,""0"",180,12,12,""" & ROW.Cells(GDESIGN.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 377,265,""0"",180,12,12,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 377,217,""0"",180,18,18,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KEMLINO" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 581,354,""ROMAN.TTF"",180,1,19,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 738,282,""ROMAN.TTF"",180,1,14,""D.NO""")
            '                        oWrite.WriteLine("TEXT 738,228,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 738,172,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 738,119,""ROMAN.TTF"",180,1,14,""UNIT""")
            '                        oWrite.WriteLine("QRCODE 237,280,L,10,A,180,M2,S7,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 237,65,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,282,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,228,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,172,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,119,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 581,282,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 581,228,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 581,176,""ROMAN.TTF"",180,1,18,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 581,67,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                        oWrite.WriteLine("TEXT 738,67,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 609,67,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 581,119,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(gqtyunit.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 738,348,""ROMAN.TTF"",180,1,14,""PROD""")
            '                        oWrite.WriteLine("TEXT 609,348,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("BAR 29,297, 708, 3")
            '                        oWrite.WriteLine("TEXT 410,119,""ROMAN.TTF"",180,1,14,""" & TXTLOTNO.Text.Trim & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "PURVITEX" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("BARCODE 790,113,""128M"",68,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 506,40,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 794,384,""ROMAN.TTF"",180,1,16,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 793,313,""ROMAN.TTF"",180,1,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 789,171,""ROMAN.TTF"",180,1,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 794,242,""ROMAN.TTF"",180,1,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 588,384,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 614,384,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 614,313,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 588,313,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 614,171,""ROMAN.TTF"",180,1,16,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 588,171,""ROMAN.TTF"",180,1,16,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 614,243,""0"",180,16,17,"":""")
            '                        oWrite.WriteLine("TEXT 588,252,""ROMAN.TTF"",180,1,24,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 233,171,""ROMAN.TTF"",180,1,16,"" """)
            '                        oWrite.WriteLine("TEXT 255,171,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 412,171,""ROMAN.TTF"",180,1,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 372,242,""ROMAN.TTF"",180,1,16,""DESC""")
            '                        oWrite.WriteLine("TEXT 255,242,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 233,242,""ROMAN.TTF"",180,1,16,"" """)
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DJIMPEX" Then

            '                        oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 768,362,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 768,303,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 768,244,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 768,185,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 271,232,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 614,362,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,303,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,244,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,185,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 170,235,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 593,362,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 593,303,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 593,244,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 593,185,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 149,235,""ROMAN.TTF"",180,1,16,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 768,133,""128M"",76,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 768,51,""ROMAN.TTF"",180,1,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 253,51,""ROMAN.TTF"",180,1,11,""WWW.DJIMPEX.IN""")
            '                        oWrite.WriteLine("TEXT 270,185,""ROMAN.TTF"",180,1,14,""YDS""")
            '                        oWrite.WriteLine("TEXT 170,185,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 149,189,""ROMAN.TTF"",180,1,16,""" & Format(Val(ROW.Cells(GMTRS.Index).Value) * 1.094, "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RATAN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 745,378,""0"",180,11,11,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 745,330,""0"",180,11,11,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 745,282,""0"",180,11,11,""SHADE""")
            '                        oWrite.WriteLine("TEXT 308,186,""0"",180,11,11,""MTRS""")
            '                        oWrite.WriteLine("TEXT 745,186,""0"",180,13,13,""WIDTH""")
            '                        oWrite.WriteLine("BARCODE 745,126,""128M"",70,0,180,3,6,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 567,50,""0"",180,12,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 590,378,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,330,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,282,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,186,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 216,186,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 564,382,""0"",180,15,15,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,331,""0"",180,13,13,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,282,""0"",180,11,11,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,186,""0"",180,11,11,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 188,193,""0"",180,18,18,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 745,234,""0"",180,11,11,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 590,234,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 564,234,""0"",180,11,11,""" & TXTLOTNO.Text.Trim & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KENCOT" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("SPEED 4")
            '                        oWrite.WriteLine("DENSITY 10")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 506,377,""ROMAN.TTF"",180,1,17,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 780,140,""128M"",85,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 484,50,""ROMAN.TTF"",180,1,9,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 780,298,""ROMAN.TTF"",180,1,14,""DESIGN NO""")
            '                        oWrite.WriteLine("TEXT 321,298,""ROMAN.TTF"",180,1,14,""SHADE NO""")
            '                        oWrite.WriteLine("TEXT 585,302,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 125,302,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 555,311,""ROMAN.TTF"",180,1,24,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 95,305,""ROMAN.TTF"",180,1,17,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 382,209,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 266,214,""ROMAN.TTF"",180,1,17,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 243,213,""0"",180,17,17,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 677,214,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 780,209,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 625,223,""ROMAN.TTF"",180,1,24,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 780,373,""ROMAN.TTF"",180,1,14,""MERCHANT NO :""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DRDRAPES" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 734,287,""0"",180,13,13,""Quality""")
            '                        oWrite.WriteLine("TEXT 734,242,""0"",180,13,13,""Design""")
            '                        oWrite.WriteLine("TEXT 735,197,""0"",180,13,13,""Shade""")
            '                        oWrite.WriteLine("TEXT 734,151,""0"",180,13,13,""Mtrs""")
            '                        oWrite.WriteLine("TEXT 615,286,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,241,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,195,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,150,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 595,286,""0"",180,13,13,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,241,""0"",180,14,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,196,""0"",180,14,14,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,151,""0"",180,14,14,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 726,107,""128M"",55,0,180,3,6,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 537,47,""0"",180,10,10,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SUCCESS" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 99.10 mm, 100.1 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 767,429,""0"",180,24,24,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 682,578,""128M"",89,0,180,3,6,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 491,483,""0"",180,10,10,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 767,339,""0"",180,16,16,""D. NO""")
            '                        oWrite.WriteLine("TEXT 610,339,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 583,339,""0"",180,16,16,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 340,339,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 190,339,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 167,339,""0"",180,16,16,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 767,272,""0"",180,16,16,""GRADE""")
            '                        oWrite.WriteLine("TEXT 610,272,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 583,272,""0"",180,16,16,""" & ROW.Cells(GPIECETYPE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 340,272,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 190,272,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 167,272,""0"",180,16,16,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 750,183,""0"",180,12,12,""FAST TO NORMAL WASHING. BLENDED FABRIC""")
            '                        oWrite.WriteLine("TEXT 652,137,""0"",180,12,12,""POLYSTER - 65%     VISCOSE - 35%""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "YASHVI" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE
            '                        oWrite.WriteLine("SIZE 72.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 526,255,""ROMAN.TTF"",180,1,11,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 526,220,""ROMAN.TTF"",180,1,11,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 526,185,""ROMAN.TTF"",180,1,11,""SHADE NO""")
            '                        oWrite.WriteLine("TEXT 526,150,""ROMAN.TTF"",180,1,11,""MTRS""")
            '                        oWrite.WriteLine("TEXT 526,115,""ROMAN.TTF"",180,1,11,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 357,255,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,220,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,185,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,150,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,115,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 337,255,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,220,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,185,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,150,""ROMAN.TTF"",180,1,11,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 218,150,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(gqtyunit.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 337,115,""ROMAN.TTF"",180,1,11,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 526,311,""ROMAN.TTF"",180,1,15,""" & TEMPHEADER & """")
            '                        oWrite.WriteLine("TEXT 30,259,""ROMAN.TTF"",270,1,8,""" & TEMPREMARKS & """")
            '                        oWrite.WriteLine("BARCODE 522,82,""128M"",50,0,180,2,4,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 422,27,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "TARUN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 755,241,""0"",180,14,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 299,241,""0"",180,14,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 755,184,""0"",180,14,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 755,352,""0"",180,14,14,""MERCHANT""")
            '                        oWrite.WriteLine("TEXT 755,299,""0"",180,14,14,""QUALITY""")
            '                        oWrite.WriteLine("BARCODE 767,136,""128M"",55,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,75,""0"",180,12,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 544,352,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,299,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,241,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,184,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 163,241,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 299,184,""0"",180,14,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 163,184,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 516,352,""0"",180,14,14,""" & ROW.Cells(gitemname.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 516,299,""0"",180,14,14,""" & TEMPCATEGORY & """")
            '                        oWrite.WriteLine("TEXT 516,241,""0"",180,14,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 516,184,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 139,241,""0"",180,14,14,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 139,184,""0"",180,14,14,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "YUMILONE" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 760,375,""0"",180,16,16,""MERCHANT""")
            '                        oWrite.WriteLine("TEXT 760,320,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 760,265,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 760,210,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 311,210,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 767,143,""128M"",88,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,49,""0"",180,12,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 539,375,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,320,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,265,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,210,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 190,210,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 518,375,""0"",180,16,16,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 518,320,""0"",180,16,16,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 518,265,""0"",180,16,16,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 518,210,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 167,215,""0"",180,20,20,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "ALENCOT" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("1911C1401710016" & TEMPREMARKS)
            '                        oWrite.WriteLine("1911C1200750149" & TEMPWIDTH)
            '                        oWrite.WriteLine("1911C1201440070" & TEMPCATEGORY)

            '                        oWrite.WriteLine("1911C1201440007Quality")
            '                        oWrite.WriteLine("1911C1201210007Design")
            '                        oWrite.WriteLine("1911C1001450063:")
            '                        oWrite.WriteLine("1911C1201210070" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911C1001210063:")
            '                        oWrite.WriteLine("1911C1200750007Mtrs")
            '                        oWrite.WriteLine("1911C1000760063:")
            '                        oWrite.WriteLine("1911C1200750070" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1e4204000300000B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1200110028" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1X1100101710011P0010001016900110169017701710177")
            '                        oWrite.WriteLine("1911C1200980007Shade")
            '                        oWrite.WriteLine("1911C1000990063:")
            '                        oWrite.WriteLine("1911C1200980070" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "AVIS" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0739")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1402500039Quality")
            '                        oWrite.WriteLine("1911C1402230039D. No")
            '                        oWrite.WriteLine("1911C1401950039Shade")
            '                        oWrite.WriteLine("1911C1401670039Grade")
            '                        oWrite.WriteLine("1911C1401390039Mtrs")
            '                        oWrite.WriteLine("1e6303800410038B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1200220120" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1402500118:")
            '                        oWrite.WriteLine("1911C1402230118:")
            '                        oWrite.WriteLine("1911C1401950118:")
            '                        oWrite.WriteLine("1911C1401670118:")
            '                        oWrite.WriteLine("1911C1401390118:")
            '                        oWrite.WriteLine("1911C1402500141" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911C1402230141" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1401950141" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911C1401670141" & ROW.Cells(gqtyunit.Index).Value)
            '                        oWrite.WriteLine("1911C1401390141" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911C1001180141")
            '                        oWrite.WriteLine("1911C1400890039Lot No")
            '                        oWrite.WriteLine("1911C1400890118:")
            '                        oWrite.WriteLine("1911C1400890141" & TXTLOTNO.Text.Trim)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SBA" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911A2401590067" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911A1001430011QUALITY")
            '                        oWrite.WriteLine("1911A1001430079:")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS, TEMPCMPSTAMP As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("1911A1001430090" & TEMPCATEGORY)
            '                        oWrite.WriteLine("1911A1001240090" & TEMPREMARKS)
            '                        oWrite.WriteLine("1911A1001070090" & TEMPWIDTH)

            '                        oWrite.WriteLine("1911A1001070011WIDTH")
            '                        oWrite.WriteLine("1911A1001070079:")

            '                        oWrite.WriteLine("1911A1001070185DESIGN NO")
            '                        oWrite.WriteLine("1911A1001070267:")
            '                        oWrite.WriteLine("1911A1001070276" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1e6304700360025B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A0800220128" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1000880011MTRS")
            '                        oWrite.WriteLine("1911A1000880079:")
            '                        oWrite.WriteLine("1911A1400850090" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911A1000880185SHADE")
            '                        oWrite.WriteLine("1911A1000880267:")
            '                        oWrite.WriteLine("1911A1000880276" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911A1000080140A PRODUCT OF ")
            '                        oWrite.WriteLine("1X1100000010253L117028")
            '                        oWrite.WriteLine("A1")
            '                        DT = OBJCMN.search(" ISNULL(CMPMASTER.CMP_BUSINESSLINE, '') AS CMPSTAMP", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            '                        If DT.Rows.Count > 0 Then TEMPCMPSTAMP = DT.Rows(0).Item("CMPSTAMP")
            '                        oWrite.WriteLine("1911A1800010255" & TEMPCMPSTAMP)

            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1X1100001610007L376003")

            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "POOJA" Then

            '                        oWrite.WriteLine("SIZE 98.5 mm, 37.5 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,267,""1"",180,2,2,""ITEM""")
            '                        oWrite.WriteLine("TEXT 637,267,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("BARCODE 762,103,""39"",65,0,180,3,8,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 473,30,""1"",180,1,1,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 754,204,""1"",180,2,2,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 637,204,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 750,141,""1"",180,2,2,""COLOR""")
            '                        oWrite.WriteLine("TEXT 637,141,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 352,141,""1"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("TEXT 263,141,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 243,162,""3"",180,2,2,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 609,274,""1"",180,3,3,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,204,""1"",180,2,2,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,141,""1"",180,2,2,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 372,200,""1"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 263,200,""1"",180,2,2,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 239,200,""1"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("BAR 37, 219, 719, 3")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DETLINE" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("q792")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q406,25")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>N")
            '                        oWrite.WriteLine("A762,304,2,1,3,3,N,""D. NO""")
            '                        oWrite.WriteLine("A595,304,2,1,3,3,N,"":""")

            '                        oWrite.WriteLine("A554,304,2,1,3,3,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A762,237,2,1,3,3,N,""SHADE""")
            '                        oWrite.WriteLine("A595,237,2,1,3,3,N,"":""")
            '                        oWrite.WriteLine("A554,237,2,1,3,3,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("A762,173,2,1,3,3,N,""WIDTH""")
            '                        oWrite.WriteLine("A595,173,2,1,3,3,N,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A554,173,2,1,3,3,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A423,239,2,1,3,3,N,""MTRS""")
            '                        oWrite.WriteLine("A303,237,2,1,3,3,N,"":""")
            '                        oWrite.WriteLine("A266,241,2,2,3,3,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("B762,119,2,1,3,6,65,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("A647,50,2,2,2,2,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        'oWrite.WriteLine("A521,381,2,2,3,3,N,""")
            '                        oWrite.WriteLine("LO246,326,298,3")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()


            '                    ElseIf ClientName = "MYCOT" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 97.5 mm, 100.1 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 757,509,""2"",180,2,2,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 757,436,""2"",180,2,2,""SHADE""")
            '                        oWrite.WriteLine("TEXT 757,366,""2"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 366,366,""2"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 767,294,""128M"",96,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 529,188,""1"",180,2,2,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 588,509,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 588,436,""2"",180,2,2,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 559,366,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 244,366,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 559,509,""2"",180,2,2,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 559,436,""2"",180,2,2,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 588,366,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 211,372,""3"",180,2,2,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RMANILAL" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 757,377,""0"",180,16,16,""ITEM NAME""")
            '                        oWrite.WriteLine("TEXT 757,313,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 757,248,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 526,377,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 526,315,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 526,251,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 505,377,""0"",180,16,16,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 504,315,""0"",180,16,16,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 504,251,""0"",180,16,16,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 767,126,""128M"",77,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,44,""0"",180,16,16,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 757,184,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 348,184,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 526,184,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 218,184,""0"",180,16,16,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 504,184,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,189,""0"",180,20,20,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SUNCOTT" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,375,""0"",180,16,16,""ITEM""")
            '                        oWrite.WriteLine("TEXT 754,316,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 754,258,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 754,197,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 338,197,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 592,375,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,316,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,258,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,197,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 210,197,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 564,380,""0"",180,20,20,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,316,""0"",180,16,16,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,258,""0"",180,16,16,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,197,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,201,""0"",180,20,20,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 503,55,""0"",180,12,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 376,258,""0"",180,16,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 210,258,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 187,258,""0"",180,16,16,""" & TXTLOTNO.Text.Trim & """")

            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MANMANDIR" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,375,""ROMAN.TTF"",180,16,16,""ITEM""")
            '                        oWrite.WriteLine("TEXT 754,318,""ROMAN.TTF"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 754,258,""ROMAN.TTF"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 754,197,""ROMAN.TTF"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 338,197,""ROMAN.TTF"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 592,375,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,318,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,258,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,197,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 210,197,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 564,380,""ROMAN.TTF"",180,20,20,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,318,""ROMAN.TTF"",180,16,16,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,258,""ROMAN.TTF"",180,16,16,""" & ROW.Cells(gcolor.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,197,""ROMAN.TTF"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,201,""ROMAN.TTF"",180,20,20,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 503,55,""ROMAN.TTF"",180,12,12,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 358,318,""ROMAN.TTF"",180,16,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 192,318,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 160,318,""ROMAN.TTF"",180,16,16,""""")
            '                        oWrite.WriteLine("PRINT 1, 1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><End/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "CC" Or ClientName = "SHREEDEV" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q418")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q203,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("B397,102,2,1,2,4,65,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A306,30,2,3,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE

            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & ROW.Cells(GDESIGN.Index).Value & "' AND DESIGN_YEARID =  " & YearId)

            '                        If DT.Rows.Count > 0 Then
            '                            If WHOLESALEBARCODE = 7 Then oWrite.WriteLine("A147,179,2,4,1,1,N,""" & Val(DT.Rows(0).Item("SALERATE")) & "/-""") Else oWrite.WriteLine("A147,179,2,4,1,1,N,""" & Val(DT.Rows(0).Item("WRATE")) / 10 & """")
            '                        Else
            '                            oWrite.WriteLine("A147,179,2,4,1,1,N,""")    'SALERATE
            '                        End If

            '                        oWrite.WriteLine("A401,175,2,2,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A351,175,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A339,179,2,3,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A401,134,2,2,1,1,N,""Item""")
            '                        oWrite.WriteLine("A351,134,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A339,139,2,3,1,1,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()


            '                    ElseIf ClientName = "PURPLE" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q401")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q304,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("B389,114,2,1,2,4,80,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A298,28,2,3,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A380,286,2,4,1,1,N,""Item""")
            '                        oWrite.WriteLine("A311,286,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A283,286,2,4,1,1,N,""" & ROW.Cells(gitemname.Index).Value & """")
            '                        oWrite.WriteLine("A380,243,2,4,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A311,243,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A283,243,2,4,1,1,N,""" & ROW.Cells(GDESIGN.Index).Value & """")


            '                        Dim CPCODE As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE, ISNULL(DESIGN_PURRATE,0) AS PRATE", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & ROW.Cells(GDESIGN.Index).Value & "' AND DESIGN_YEARID =  " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            oWrite.WriteLine("A283,200,2,4,1,1,N,""" & Val(DT.Rows(0).Item("SALERATE")) & "/-""")
            '                            oWrite.WriteLine("A117,200,2,4,1,1,N,""19" & Val(DT.Rows(0).Item("WRATE")) & "67""")

            '                            'CODE FOR PURRATE (LOTUSDAIRY)
            '                            For POS As Integer = 0 To Len(Format(Val(DT.Rows(0).Item("PRATE")), "0")) - 1
            '                                Select Case DT.Rows(0).Item("PRATE").ToString.Substring(POS, 1)
            '                                    Case "1"
            '                                        CPCODE = CPCODE & "L"
            '                                    Case "2"
            '                                        CPCODE = CPCODE & "O"
            '                                    Case "3"
            '                                        CPCODE = CPCODE & "T"
            '                                    Case "4"
            '                                        CPCODE = CPCODE & "U"
            '                                    Case "5"
            '                                        CPCODE = CPCODE & "S"
            '                                    Case "6"
            '                                        CPCODE = CPCODE & "D"
            '                                    Case "7"
            '                                        CPCODE = CPCODE & "A"
            '                                    Case "8"
            '                                        CPCODE = CPCODE & "I"
            '                                    Case "9"
            '                                        CPCODE = CPCODE & "R"
            '                                    Case "0"
            '                                        CPCODE = CPCODE & "Y"
            '                                End Select
            '                            Next
            '                            DT = OBJCMN.search("ISNULL(ACC_CODE,'') AS CODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '                            If DT.Rows.Count > 0 Then CPCODE = CPCODE & UCase(DT.Rows(0).Item("CODE")) & Format(Val(AccFrom.Date.Day), "00") & Format(Val(AccFrom.Date.Month), "00") & AccFrom.Date.Year.ToString.Substring(2, 2)

            '                            oWrite.WriteLine("A380,157,2,4,1,1,N,""" & CPCODE & """")

            '                        Else
            '                            oWrite.WriteLine("A283,200,2,4,1,1,N,""")    'SALERATE
            '                            oWrite.WriteLine("A117,200,2,4,1,1,N,""")    'WHOLESALERATE
            '                            oWrite.WriteLine("A380,157,2,4,1,1,N,""")    'PURRATE
            '                        End If

            '                        oWrite.WriteLine("A380,200,2,4,1,1,N,""MRP""")
            '                        oWrite.WriteLine("A311,200,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A149,243,2,4,1,1,N,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    End If

            '                    'Printing Barcode
            '                    Dim psi As New ProcessStartInfo()
            '                    psi.FileName = "cmd.exe"
            '                    psi.RedirectStandardInput = False
            '                    psi.RedirectStandardOutput = True
            '                    'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
            '                    psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
            '                    psi.UseShellExecute = False

            '                    Dim proc As Process
            '                    proc = Process.Start(psi)
            '                    dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
            '                    '// do something with result stream
            '                    proc.WaitForExit()
            '                    proc.Dispose()
            'NEXTLINE:
            '                    'THIS LINE IS WRITTEN TO DISPOSE THE BARCODE NOTEPAD OBJECT, WHEN CURSOR COMES DIRECTLY ON NEXTLINE CODE
            '                    oWrite.Dispose()
            '                Next
            '            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobIn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDJOBIN.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
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
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOB IN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If ClientName = "MABHAY" Or ClientName = "SVS" Then
                gQty.ReadOnly = True
                txtqty.ReadOnly = True
                txtqty.Text = 1
                txtqty.BackColor = Color.Linen
            End If

            If ALLOWBARCODEPRINT = False Then
                txtqty.ReadOnly = False
                txtqty.Text = ""
            End If

            'If ClientName = "RPRAKASH" Or ClientName = "AXIS" Then
            '    txtqty.ReadOnly = False
            '    txtqty.Text = ""
            'End If

            If ClientName = "SVS" Then
                LBL.Text = "Jobber Rec"
                Me.Text = "Jobber Rec"
            End If

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJJobin As New ClsJobIn()
                Dim dttable As New DataTable
                dttable = OBJJobin.SELECTJobin(TEMPJOBINNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTJINO.Text = TEMPJOBINNO
                        TXTJINO.ReadOnly = True


                        JOBINDATE.Text = Format(Convert.ToDateTime(dr("JIDATE")).Date, "dd/MM/yyyy")
                        cmbGodown.Text = dr("GODOWN")
                        cmbname.Text = dr("NAME")
                        cmbname.Enabled = False
                        CMBPARTYNAME.Text = dr("PURNAME")
                        CMBJONO.Text = dr("JOBOUTNO").ToString
                        TXTTYPE.Text = dr("JOTYPE").ToString
                        CMBJONO.Enabled = False
                        TXTLOTNO.Text = dr("LOTNO")

                        TXTCHALLAN.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLAN.Text.Trim
                        TXTWEAVERCHNO.Text = dr("WEAVERCHNO")

                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        CMBPROCESS.Text = dr("PROCESS").ToString
                        TXTBALMTRS.Text = dr("BALMTRS")
                        TXTOUTMTRS.Text = dr("TOTALOUTMTRS")

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTBALEWT.Text = Val(dr("BALEWT"))
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        GRIDJOBIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEM").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("JOSRNO"), dr("JOMTRS"), dr("OLDDESIGN").ToString, dr("DESIGN").ToString, dr("COLOR"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("RACK"), dr("SHELF"), dr("BARCODE"), 0, dr("OUTPCS"), dr("OUTMTRS"), 0, 0, 0)

                        If Val(dr("OUTMTRS")) > 0 Then
                            GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    total()
                    GRIDJOBIN.FirstDisplayedScrollingRowIndex = GRIDJOBIN.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If

                'UPLOAD()
                Dim OBJCMN As New ClsCommon
                'dttable = OBJCMN.search(" MATREC_GRIDSRNO AS GRIDSRNO, MATREC_REMARKS AS REMARKS, MATREC_NAME AS NAME, MATREC_IMGPATH AS IMGPATH, MATREC_NEWIMGPATH AS NEWIMGPATH", "", " MATERIAL_UPLOAD", " AND MATREC_NO = " & TEMPJOBINNO & " AND MATREC_CMPID = " & CmpId & " AND MATREC_LOCATIONID = " & Locationid & " AND MATREC_YEARID = " & YearId)
                dttable = OBJCMN.search(" JI_GRIDSRNO AS GRIDSRNO, JI_REMARKS AS REMARKS, JI_NAME AS NAME, JI_IMGPATH AS IMGPATH, JI_NEWIMGPATH AS NEWIMGPATH", "", " JOBIN_UPLOAD", " AND JI_NO = " & TEMPJOBINNO & " AND JI_CMPID = " & CmpId & " AND JI_LOCATIONID = " & Locationid & " AND JI_YEARID = " & YearId)

                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If


            End If

            If GRIDJOBIN.RowCount > 0 Then
                txtsrno.Text = Val(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(0).Value) + 1
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            fillunit(cmbqtyunit)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
            FILLPROCESS(CMBPROCESS)

            If ClientName = "PURVITEX" Then
                If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            Else
                If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            End If

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

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJJobinDetails As New JobInDetails
            OBJJobinDetails.MdiParent = MDIMain
            OBJJobinDetails.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
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
                GRIDJOBIN.RowCount = 0
                TEMPJOBINNO = Val(tstxtbillno.Text)
                If TEMPJOBINNO > 0 Then
                    EDIT = True
                    JobIn_Load(sender, e)
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
        Try
            GRIDJOBIN.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDJOBIN.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, Val(CMBJOSRNO.Text.Trim), Val(TXTJOMTRS.Text.Trim), CMBOLDDESIGN.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0, Val(TXTFROMNO.Text.Trim), Val(TXTFROMSRNO.Text.Trim), TXTFROMTYPE.Text.Trim)
                getsrno(GRIDJOBIN)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJOBIN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDJOBIN.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDJOBIN.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDJOBIN.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDJOBIN.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDJOBIN.Item(GJOGRIDSRNO.Index, TEMPROW).Value = Val(CMBJOSRNO.Text.Trim)
                GRIDJOBIN.Item(GJOMTRS.Index, TEMPROW).Value = Val(TXTJOMTRS.Text.Trim)
                GRIDJOBIN.Item(GOLDDESIGN.Index, TEMPROW).Value = CMBOLDDESIGN.Text.Trim
                GRIDJOBIN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDJOBIN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDJOBIN.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDJOBIN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
                GRIDJOBIN.Item(gQty.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
                GRIDJOBIN.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
                GRIDJOBIN.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDJOBIN.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDJOBIN.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
                GRIDJOBIN.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim
                GRIDDOUBLECLICK = False
            End If

            total()

            GRIDJOBIN.FirstDisplayedScrollingRowIndex = GRIDJOBIN.RowCount - 1

            txtsrno.Text = GRIDJOBIN.RowCount + 1
            'cmbitemname.Text = ""
            ' CMBQUALITY.Text = ""
            ' CMBDESIGN.Text = ""
            ' cmbcolor.Text = ""
            'TXTCUT.Clear()
            If ClientName <> "AVIS" Then TXTBALENO.Clear()
            TXTWT.Clear()
            If ClientName = "RPRAKASH" Or ClientName = "DETLINE" Or ClientName = "KCRAYON" Then txtqty.Clear()
            'txtqty.Clear()
            'cmbqtyunit.Text = ""
            If ClientName <> "SBA" And ClientName <> "INDRANI" Then TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBRACK.Text = ""
            CMBSHELF.Text = ""
            CMBJOSRNO.Text = ""
            TXTJOMTRS.Clear()

            If ClientName = "AVIS" Or ClientName = "SMS" Then TXTMTRS.Focus() Else CMBPIECETYPE.Focus()

        Catch ex As Exception
            Throw ex
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTJINO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDJOBIN.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDJOBIN.RowCount = 0
LINE1:
            TEMPJOBINNO = Val(TXTJINO.Text) - 1
            If TEMPJOBINNO > 0 Then
                EDIT = True
                JobIn_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJOBIN.RowCount = 0 And TEMPJOBINNO > 1 Then
                TXTJINO.Text = TEMPJOBINNO
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
            GRIDJOBIN.RowCount = 0
LINE1:
            TEMPJOBINNO = Val(TXTJINO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTJINO.Text.Trim
            clear()
            If Val(TXTJINO.Text) - 1 >= TEMPJOBINNO Then
                EDIT = True
                JobIn_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJOBIN.RowCount = 0 And TEMPJOBINNO < MAXNO Then
                TXTJINO.Text = TEMPJOBINNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTNOOFENTRIES.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("JobIn Receipt Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete JobIn Receipt?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTJINO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMATREC As New ClsJobIn()
                    OBJMATREC.alParaval = alParaval
                    IntResult = OBJMATREC.Delete()
                    MsgBox("JobIn Receipt Deleted")
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

    Private Sub GRIDJOBIN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDJOBIN.CellValidating
        Try
            Dim colNum As Integer = GRIDJOBIN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index, gcut.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDJOBIN.CurrentCell.Value = Nothing Then GRIDJOBIN.CurrentCell.Value = "0.00"
                        GRIDJOBIN.CurrentCell.Value = Convert.ToDecimal(GRIDJOBIN.Item(colNum, e.RowIndex).Value)
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

    Sub EDITROW()
        Try
            If GRIDJOBIN.CurrentRow.Index >= 0 And GRIDJOBIN.Item(gsrno.Index, GRIDJOBIN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDJOBIN.Item(gsrno.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDJOBIN.Item(GPIECETYPE.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDJOBIN.Item(gitemname.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDJOBIN.Item(GQUALITY.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDJOBIN.Item(GBALENO.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBJOSRNO.Text = Val(GRIDJOBIN.Item(GJOGRIDSRNO.Index, GRIDJOBIN.CurrentRow.Index).Value)
                TXTJOMTRS.Text = Val(GRIDJOBIN.Item(GJOMTRS.Index, GRIDJOBIN.CurrentRow.Index).Value)
                CMBOLDDESIGN.Text = GRIDJOBIN.Item(GOLDDESIGN.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDJOBIN.Item(GDESIGN.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDJOBIN.Item(gcolor.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDJOBIN.Item(gcut.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDJOBIN.Item(GWT.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDJOBIN.Item(gQty.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDJOBIN.Item(gqtyunit.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDJOBIN.Item(GMTRS.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDJOBIN.Item(GRATE.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDJOBIN.Item(GRACK.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDJOBIN.Item(GSHELF.Index, GRIDJOBIN.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDJOBIN.CurrentRow.Index

                If ClientName = "AVIS" Then TXTMTRS.Focus() Else CMBPIECETYPE.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDJOBIN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDJOBIN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDJOBIN.Rows.RemoveAt(GRIDJOBIN.CurrentRow.Index)
                getsrno(GRIDJOBIN)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
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

    Private Sub CMBPARTYNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.Enter
        Try
            If ClientName = "PURVITEX" Or ClientName = "KARAN" Then
                If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            Else
                If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try
            If ClientName = "PURVITEX" Or ClientName = "KARAN" Then
                If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text)
            Else
                If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text)
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown, CMBPARTYNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
            If ClientName = "PURVITEX" Or ClientName = "KARAN" Then
                If e.KeyCode = Keys.F1 Then
                    Dim OBJLEDGER As New SelectLedger
                    OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                    OBJLEDGER.ShowDialog()
                    If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                    If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                End If
            Else
                If e.KeyCode = Keys.F1 Then
                    Dim OBJLEDGER As New SelectLedger
                    OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                    OBJLEDGER.ShowDialog()
                    If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                    If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated
        CALC()
    End Sub

    Private Sub txtqty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(txtqty.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
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
            If CMBDESIGN.Text.Trim <> "" Then
                If ClientName = "AVIS" Then DESIGNVALIDATE(CMBDESIGN, e, Me) Else DESIGNVALIDATE(CMBDESIGN, e, Me, cmbitemname.Text.Trim)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If EDIT = False And cmbname.Text.Trim <> "" Then
                CMBJONO.Items.Clear()
                'FILL JOBOUT NO
                'IF USER HAS NOT WRITTEN BILLNO THEN IT WONT BE SHOWN HERE
                'IF USER HAS WRITTEN LOTNO THEN IT WONT BE SHOWN HERE
                Dim OBJCMN As New ClsCommon

                'WE HAVE CHANGED THE CODE FOR OPENING BY GULKIT, COZ WHEN WE TRANSFER STOCK FROM LAST YEAR WE WILL NEED JOBOUT LOTNO IN THIS YEAR'S OPENING
                'AND IF WE KEEP LOTNO BLANK THEN IT WONT BE FETCHED IN JOBIN
                'Dim DT As DataTable = OBJCMN.search(" JONO ", "", " (SELECT JOBOUT.JO_no AS JONO FROM JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id WHERE LEDGERS.Acc_CMPNAME='" & cmbname.Text.Trim & "' AND ROUND((JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS),2) > 0 AND JOBOUT.JO_CLOSE=0 AND JOBOUT.JO_YEARID = " & YearId & " UNION ALL SELECT DISTINCT SM_BILLNO AS JONO FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO= LEDGERS.Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ROUND((SM_MTRS - SM_OUTMTRS),2) > 0 AND SM_BILLNO <> 0 AND (SM_LOTNO = '' or SM_LOTNO = 0) AND SM_YEARID = " & YearId & ") AS T", "")
                Dim DT As DataTable = OBJCMN.search(" JONO ", "", " (SELECT JOBOUT.JO_no AS JONO FROM JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id WHERE LEDGERS.Acc_CMPNAME='" & cmbname.Text.Trim & "' AND ROUND((JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS),2) > 0 AND JOBOUT.JO_CLOSE=0 AND ISNULL(JOBOUT.JO_LOTCOMPLETED,0)=0 AND JOBOUT.JO_YEARID = " & YearId & " UNION ALL SELECT DISTINCT SM_BILLNO AS JONO FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO= LEDGERS.Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ROUND((SM_MTRS - SM_OUTMTRS),2) > 0 AND SM_BILLNO <> 0 AND ISNULL(SM_LOTCOMPLETED,0)=0 AND SM_YEARID = " & YearId & ") AS T", "")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        CMBJONO.Items.Add(DTROW("JONO"))
                    Next
                    cmbname.Enabled = False
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

    Sub fillolddesign(ByRef cmbDESIGN As ComboBox)
        Try
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" JOBOUT_DESC.JO_GRIDSRNO AS GRIDSRNO, (SELECT DISTINCT PIECETYPEMASTER.PIECETYPE_name) AS PIECETYPE, JOBOUT_DESC.JO_BALENO AS BALENO, ITEMMASTER.item_name AS ITEM, (SELECT DISTINCT QUALITYMASTER.QUALITY_name) AS QUALITY, (SELECT DISTINCT DESIGNMASTER.DESIGN_NO) AS DESIGN, (SELECT DISTINCT COLORMASTER.COLOR_name) AS COLOR, JOBOUT_DESC.JO_BARCODE AS BARCODE, (JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS) AS BALANCEMTRS, JOBOUT.JO_TOTALMTRS AS OUTMTRS , JOBOUT_DESC.JO_FROMNO AS FROMNO, JOBOUT_DESC.JO_FROMSRNO AS FROMSRNO, JOBOUT_DESC.JO_FROMTYPE AS FROMTYPE", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_cmpid = JOBOUT_DESC.JO_CMPID AND JOBOUT.JO_locationid = JOBOUT_DESC.JO_LOCATIONID AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_YEARID = COLORMASTER.COLOR_yearid AND JOBOUT_DESC.JO_LOCATIONID = COLORMASTER.COLOR_locationid AND JOBOUT_DESC.JO_CMPID = COLORMASTER.COLOR_cmpid AND JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_YEARID = DESIGNMASTER.DESIGN_yearid AND JOBOUT_DESC.JO_LOCATIONID = DESIGNMASTER.DESIGN_locationid AND JOBOUT_DESC.JO_CMPID = DESIGNMASTER.DESIGN_cmpid AND JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_YEARID = QUALITYMASTER.QUALITY_yearid AND JOBOUT_DESC.JO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND JOBOUT_DESC.JO_CMPID = QUALITYMASTER.QUALITY_cmpid AND JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_YEARID = ITEMMASTER.item_yearid AND JOBOUT_DESC.JO_LOCATIONID = ITEMMASTER.item_locationid AND JOBOUT_DESC.JO_CMPID = ITEMMASTER.item_cmpid AND JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_YEARID = PIECETYPEMASTER.PIECETYPE_yearid AND JOBOUT_DESC.JO_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND JOBOUT_DESC.JO_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id", " AND JOBOUT.JO_no=" & Val(CMBJONO.Text.Trim) & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
            Dim DT As DataTable = OBJCMN.search(" (SELECT DISTINCT DESIGNMASTER.DESIGN_NO) AS DESIGN ", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_cmpid = JOBOUT_DESC.JO_CMPID AND JOBOUT.JO_locationid = JOBOUT_DESC.JO_LOCATIONID AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_YEARID = COLORMASTER.COLOR_yearid AND JOBOUT_DESC.JO_LOCATIONID = COLORMASTER.COLOR_locationid AND JOBOUT_DESC.JO_CMPID = COLORMASTER.COLOR_cmpid AND JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_YEARID = DESIGNMASTER.DESIGN_yearid AND JOBOUT_DESC.JO_LOCATIONID = DESIGNMASTER.DESIGN_locationid AND JOBOUT_DESC.JO_CMPID = DESIGNMASTER.DESIGN_cmpid AND JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_YEARID = QUALITYMASTER.QUALITY_yearid AND JOBOUT_DESC.JO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND JOBOUT_DESC.JO_CMPID = QUALITYMASTER.QUALITY_cmpid AND JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_YEARID = ITEMMASTER.item_yearid AND JOBOUT_DESC.JO_LOCATIONID = ITEMMASTER.item_locationid AND JOBOUT_DESC.JO_CMPID = ITEMMASTER.item_cmpid AND JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_YEARID = PIECETYPEMASTER.PIECETYPE_yearid AND JOBOUT_DESC.JO_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND JOBOUT_DESC.JO_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id", " AND JOBOUT.JO_no=" & Val(CMBJONO.Text.Trim) & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "DESIGN"
                CMBOLDDESIGN.DataSource = DT
                CMBOLDDESIGN.DisplayMember = "DESIGN"
                CMBOLDDESIGN.Text = ""
            End If
            CMBOLDDESIGN.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJONO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJONO.Validating
        Try
            If Val(CMBJONO.Text) > 0 Then

                Dim OBJCMN As New ClsCommon
                'FILL COMBO WHICH HAS BEEN OUT

                'FOR OPENING
                'IF USER HAS NOT WRITTEN BILLNO THEN IT WONT BE SHOWN HERE
                'IF USER HAS WRITTEN LOTNO THEN IT WONT BE SHOWN HERE

                'Dim DT As DataTable = OBJCMN.search(" JOBOUT_DESC.JO_GRIDSRNO AS GRIDSRNO, (SELECT DISTINCT PIECETYPEMASTER.PIECETYPE_name) AS PIECETYPE, JOBOUT_DESC.JO_BALENO AS BALENO, ITEMMASTER.item_name AS ITEM, (SELECT DISTINCT QUALITYMASTER.QUALITY_name) AS QUALITY, (SELECT DISTINCT DESIGNMASTER.DESIGN_NO) AS DESIGN, (SELECT DISTINCT COLORMASTER.COLOR_name) AS COLOR, JOBOUT_DESC.JO_BARCODE AS BARCODE, (JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS) AS BALANCEMTRS, JOBOUT.JO_TOTALMTRS AS OUTMTRS , JOBOUT_DESC.JO_FROMNO AS FROMNO, JOBOUT_DESC.JO_FROMSRNO AS FROMSRNO, JOBOUT_DESC.JO_FROMTYPE AS FROMTYPE", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_cmpid = JOBOUT_DESC.JO_CMPID AND JOBOUT.JO_locationid = JOBOUT_DESC.JO_LOCATIONID AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_YEARID = COLORMASTER.COLOR_yearid AND JOBOUT_DESC.JO_LOCATIONID = COLORMASTER.COLOR_locationid AND JOBOUT_DESC.JO_CMPID = COLORMASTER.COLOR_cmpid AND JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_YEARID = DESIGNMASTER.DESIGN_yearid AND JOBOUT_DESC.JO_LOCATIONID = DESIGNMASTER.DESIGN_locationid AND JOBOUT_DESC.JO_CMPID = DESIGNMASTER.DESIGN_cmpid AND JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_YEARID = QUALITYMASTER.QUALITY_yearid AND JOBOUT_DESC.JO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND JOBOUT_DESC.JO_CMPID = QUALITYMASTER.QUALITY_cmpid AND JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_YEARID = ITEMMASTER.item_yearid AND JOBOUT_DESC.JO_LOCATIONID = ITEMMASTER.item_locationid AND JOBOUT_DESC.JO_CMPID = ITEMMASTER.item_cmpid AND JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_YEARID = PIECETYPEMASTER.PIECETYPE_yearid AND JOBOUT_DESC.JO_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND JOBOUT_DESC.JO_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id", " AND JOBOUT.JO_no=" & Val(CMBJONO.Text.Trim) & " AND JOBOUT.JO_CMPID = " & CmpId & " AND JOBOUT.JO_LOCATIONID = " & Locationid & " AND JOBOUT.JO_YEARID = " & YearId)
                Dim DT As DataTable = OBJCMN.search(" SUM(BALANCEMTRS) AS BALANCEMTRS, SUM(OUTMTRS) AS OUTMTRS, TYPE ", "", " (SELECT SUM((JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS)) AS BALANCEMTRS, SUM(JOBOUT.JO_RECDMTRS) AS OUTMTRS, 'JOBOUT' AS TYPE FROM JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id WHERE LEDGERS.Acc_CMPNAME='" & cmbname.Text.Trim & "' AND ROUND((JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS),2) > 0 AND JOBOUT.JO_CLOSE=0 AND JOBOUT.JO_NO = " & Val(CMBJONO.Text.Trim) & " AND JOBOUT.JO_YEARID = " & YearId & " UNION ALL SELECT  (SUM(SM_MTRS) -SUM( SM_OUTMTRS)) AS BALANCEMTRS, SUM(SM_MTRS)  AS OUTMTRS, 'OPENING' AS TYPE FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO= LEDGERS.Acc_id WHERE LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND SM_BILLNO <> 0 AND SM_YEARID = " & YearId & " AND SM_BILLNO = " & Val(CMBJONO.Text.Trim) & ") AS T", " GROUP BY TYPE HAVING ISNULL(SUM(BALANCEMTRS),0) > 0")
                If DT.Rows.Count > 0 Then

                    Dim DTR As New DataTable
                    If DT.Rows(0).Item("TYPE") = "JOBOUT" Then
                        DTR = OBJCMN.search(" isnull(PIECETYPEMASTER.PIECETYPE_name,'FRESH') AS PIECETYPE, ISNULL(ITEMMASTER.item_name,'') AS ITEM,ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, JO_BARCODE AS BARCODE, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(JOBOUT.JO_LOTNO,'') AS LOTNO, ISNULL(JOBOUT.JO_CHALLANNO,'') AS WEAVERCHNO, ISNULL(WEAVERLEDGERS.ACC_CMPNAME,'') AS WEAVERNAME, JOBOUT_DESC.JO_GRIDSRNO AS GRIDSRNO ", "", "  JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN PROCESSMASTER ON JOBOUT.JO_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN LEDGERS AS WEAVERLEDGERS ON JOBOUT.JO_PARTYLEDGERID = WEAVERLEDGERS.ACC_ID", " AND JOBOUT.JO_no=" & Val(CMBJONO.Text.Trim) & " AND (JO_MTRS - ROUND(JO_OUTMTRS,0)) > 0 AND JOBOUT.JO_YEARID = " & YearId & " ORDER BY JO_GRIDSRNO")
                    Else
                        DTR = OBJCMN.search(" isnull(PIECETYPEMASTER.PIECETYPE_name,'FRESH') AS PIECETYPE, ISNULL(ITEMMASTER.item_name,'') AS ITEM, '' AS PROCESS, SM_BARCODE AS BARCODE, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(STOCKMASTER.SM_LOTNO,'') AS LOTNO, ISNULL(STOCKMASTER.SM_REMARKS,'') AS WEAVERCHNO, ISNULL(WEAVERLEDGERS.ACC_CMPNAME,'') AS WEAVERNAME, STOCKMASTER.SM_GRIDSRNO AS GRIDSRNO ", "", "  STOCKMASTER LEFT OUTER JOIN COLORMASTER ON SM_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SM_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON SM_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON SM_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON SM_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN LEDGERS AS WEAVERLEDGERS ON SM_LEDGERID = WEAVERLEDGERS.ACC_ID INNER JOIN LEDGERS AS JOBBERLEDGERS ON SM_LEDGERIDTO = JOBBERLEDGERS.ACC_ID", " AND SM_BILLNO =" & Val(CMBJONO.Text.Trim) & " AND JOBBERLEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND SM_TYPE = 'JOBBERSTOCK' AND (SM_MTRS - ROUND(SM_OUTMTRS,0)) > 0 AND SM_YEARID = " & YearId & " ORDER BY SM_GRIDSRNO")
                    End If

                    If DTR.Rows.Count > 0 Then

                        'FOR INDRANI FETCH ALL GRID DATA FROM JOBOUT
                        If ClientName = "INDRANI" And DT.Rows(0).Item("TYPE") = "JOBOUT" Then
                            Dim objJO As New ClsCuttingIssue()
                            Dim ALPARAVAL As New ArrayList
                            ALPARAVAL.Add(CMBJONO.Text.Trim)
                            ALPARAVAL.Add(CmpId)
                            ALPARAVAL.Add(Locationid)
                            ALPARAVAL.Add(YearId)
                            objJO.alParaval = ALPARAVAL
                            Dim dttable As DataTable = objJO.SELECTJO()
                            If dttable.Rows.Count > 0 Then
                                For Each dr As DataRow In dttable.Rows
                                    GRIDJOBIN.Rows.Add(Val(dr("GRIDSRNO")), dr("PIECETYPE"), dr("ITEM"), dr("QUALITY"), dr("BALENO"), 0, 0, "", dr("DESIGN"), dr("COLOR"), Format(Val(dr("CUT")), "0.00"), 0, Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), 0, "", "", "", 0, 0, 0, 0, 0, "")
                                Next
                            End If
                        End If

                        CMBPIECETYPE.Text = DTR.Rows(0).Item("PIECETYPE")
                        cmbitemname.Text = DTR.Rows(0).Item("ITEM")
                        CMBDESIGN.Text = DTR.Rows(0).Item("DESIGNNO")
                        CMBPROCESS.Text = DTR.Rows(0).Item("PROCESS")
                        TXTLOTNO.Text = DTR.Rows(0).Item("LOTNO")
                        TXTWEAVERCHNO.Text = DTR.Rows(0).Item("WEAVERCHNO")
                        CMBPARTYNAME.Text = DTR.Rows(0).Item("WEAVERNAME")

                        'DONT ALLOW TO ENTER DATA IF LOT NO IS NOT ENTERED IN JOBOUT
                        If ClientName = "KARAN" And TXTLOTNO.Text.Trim = "" And CMBPARTYNAME.Text.Trim <> "" Then
                            MsgBox("Please Enter Lot No in Job Out Entry First, Then make Job In Entry", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        If ClientName = "KDFAB" Then
                            CMBBARCODE.Items.Clear()
                            For Each ROW As DataRow In DTR.Rows
                                CMBBARCODE.Items.Add(ROW("BARCODE"))
                            Next
                        End If


                        If ClientName = "KARAN" Then
                            CMBJOSRNO.Items.Clear()
                            For Each ROW As DataRow In DTR.Rows
                                CMBJOSRNO.Items.Add(ROW("GRIDSRNO"))
                            Next
                        End If

                    End If
                    If DT.Rows(0).Item("BALANCEMTRS") > 0 Then
                        CMBJONO.Enabled = False
                        TXTTYPE.Text = DT.Rows(0).Item("TYPE")
                        TXTBALMTRS.Text = Format(Val(DT.Rows(0).Item("BALANCEMTRS")), "0.00")
                        TXTOUTMTRS.Text = Format(Val(DT.Rows(0).Item("OUTMTRS")), "0.00")
                        fillolddesign(CMBOLDDESIGN)
                    Else
                        MsgBox("Challan Already Cleared", MsgBoxStyle.Critical)
                        e.Cancel = True
                        CMBJONO.Text = ""
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid Challan No !", MsgBoxStyle.Critical)
                    e.Cancel = True
                    CMBJONO.Text = ""
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(TEMPJOBINNO)
                PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal JINO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Job In?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "JOBIN"
                OBJGDN.FORMULA = "{JOBIN.JI_NO}=" & Val(JINO) & " and {JOBIN.JI_yearid}=" & YearId
                OBJGDN.Show()
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

    Private Sub JobIn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If ALLOWBARCODEPRINT = False Then txtqty.ReadOnly = False
        If ClientName = "SANGHVI" Or ClientName = "KDFAB" Or ClientName = "KCRAYON" Then GBALENO.HeaderText = "Description"

        If ClientName = "KOCHAR" Then
            TXTCUT.TabStop = False
            GRIDBALESUMM.Visible = True
        End If

        If ClientName = "MANINATH" Then GBALENO.HeaderText = "Lot No"

        If ClientName = "PURVITEX" Or ClientName = "KARAN" Then
            CMBPARTYNAME.Visible = True
            LBLPARTYNAME.Visible = True
        End If

        If ClientName = "AXIS" Then
            CMBPARTYNAME.Visible = True
            LBLPARTYNAME.Visible = True
            LBLPARTYNAME.Text = "CUSTOMER NAME"
            TXTBALEWT.Visible = True
            LBLBALEWT.Visible = True
            txtqty.ReadOnly = False
        End If
        If ClientName = "DETLINE" Or ClientName = "KCRAYON" Or ClientName = "DRDRAPES" Or ClientName = "MJFABRIC" Or ClientName = "SBA" Or ClientName = "KARAN" Or ClientName = "SMS" Then txtqty.ReadOnly = False
        If ClientName = "MJFABRIC" Then
            CMBBARCODE.TabStop = False
            CMBQUALITY.TabStop = False
            TXTBALENO.TabStop = False
            CMBOLDDESIGN.TabStop = False
            CMBDESIGN.TabStop = False
            cmbcolor.TabStop = False
            TXTCUT.TabStop = False
            TXTWT.TabStop = False
            cmbqtyunit.Text = "Pcs"
            CMBRACK.TabStop = False
        End If

        If ClientName = "AVIS" Or ClientName = "KRISHNA" Then
            cmbitemname.TabStop = False
            CMBQUALITY.TabStop = False
            TXTBALENO.TabStop = False
            CMBOLDDESIGN.TabStop = False
            TXTCUT.TabStop = False
            TXTWT.TabStop = False
            txtqty.TabStop = False
            txtqty.Text = 1
            cmbqtyunit.TabStop = False
            cmbqtyunit.Text = "LUMP"
            TXTRATE.TabStop = False
            CMBRACK.TabStop = False
        End If

        If ClientName = "KDFAB" Then
            LBLBARCODE.Visible = True
            CMBBARCODE.Visible = True
        End If

        If ClientName = "KARAN" Then
            LBLWEAVERCHNO.Visible = True
            TXTWEAVERCHNO.Visible = True

            CMBOLDDESIGN.Visible = False
            GOLDDESIGN.Visible = False
            CMBJOSRNO.Visible = True
            TXTJOMTRS.Visible = True
            GJOGRIDSRNO.Visible = True
            GJOMTRS.Visible = True
        End If

        If ClientName = "INDRANI" Then
            GBALENO.HeaderText = "SO No"
            CMBQUALITY.TabStop = False
            CMBOLDDESIGN.TabStop = False
            TXTCUT.TabStop = False
            TXTWT.TabStop = False
            cmbqtyunit.TabStop = False
            TXTRATE.TabStop = False
            CMBRACK.TabStop = False
        End If

        If ClientName = "SBA" Then TXTNOOFENTRIES.Visible = True

    End Sub

    Private Sub JOBINDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles JOBINDATE.GotFocus
        JOBINDATE.SelectAll()
    End Sub

    Private Sub JOBINDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JOBINDATE.Validating
        Try
            If JOBINDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(JOBINDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                ElseIf ClientName = "MJFABRIC" Then
                    CHALLANDATE.Value = JOBINDATE.Text
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLAN.Validating
        Try
            If TXTCHALLAN.Text.Trim.Length > 0 And ClientName <> "AXIS" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLAN.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" JI_challanno, LEDGERS.ACC_cmpname", "", " JOBIN inner join LEDGERS on LEDGERS.ACC_id = JI_ledgerid ", " and JI_challanno = '" & TXTCHALLAN.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND JI_YEARID =" & YearId)
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

    Private Function CHECKBARCODE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(JI_BARCODE,'') AS BARCODE ", "", " JOBIN_DESC ", " AND JOBIN_DESC.JI_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As Windows.Forms.DataGridViewRow In GRIDJOBIN.Rows
                        If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                            BLN = False
                            Exit Function
                        End If
                    Next
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBBARCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBARCODE.Validated
        Try
            If CMBBARCODE.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DTR As DataTable = OBJCMN.search("T.JONO, T.MTRS AS MTRS, T.FROMNO AS FROMNO, T.FROMSRNO AS FROMSRNO, T.GRIDTYPE AS GRIDTYPE", "", " (SELECT JO_NO AS JONO, JO_MTRS AS MTRS, JO_NO AS FROMNO, JO_GRIDSRNO AS FROMSRNO, 'JOBOUT' AS GRIDTYPE FROM JOBOUT_DESC WHERE JO_BARCODE='" & CMBBARCODE.Text.Trim & "' AND JO_YEARID = " & YearId & " UNION ALL SELECT SM_BILLNO AS BILLNO,  SM_MTRS AS MTRS, SM_NO AS FROMNO, SM_NO AS FROMSRNO, 'OPENING' AS GRIDTYPE FROM STOCKMASTER WHERE SM_BARCODE = '" & CMBBARCODE.Text.Trim & "' AND SM_YEARID = " & YearId & ") AS T", "")
                If DTR.Rows.Count > 0 Then
                    If CMBJONO.Text.Trim = "" Then
                        CMBJONO.Text = Val(DTR.Rows(0).Item("JONO"))
                        CMBJONO.Enabled = False
                    End If
                    TXTBALMTRS.Text = Format(Val(DTR.Rows(0).Item("MTRS")), "0.00")
                    TXTFROMNO.Text = Val(DTR.Rows(0).Item("FROMNO"))
                    TXTFROMSRNO.Text = Val(DTR.Rows(0).Item("FROMSRNO"))
                    TXTFROMTYPE.Text = DTR.Rows(0).Item("GRIDTYPE")
                    TXTTYPE.Text = DTR.Rows(0).Item("GRIDTYPE")

                    'GET ITEMDETAILS FROM OUTBARCODESTOCK WITH RESPECT TO SELECTED BARCODE
                    DTR = OBJCMN.search("*", "", "OUTBARCODESTOCK", " AND BARCODE = '" & CMBBARCODE.Text.Trim & "' AND YEARID = " & YearId)
                    If DTR.Rows.Count > 0 Then
                        CMBPIECETYPE.Text = DTR.Rows(0).Item("PIECETYPE")
                        cmbitemname.Text = DTR.Rows(0).Item("ITEMNAME")
                        CMBQUALITY.Text = DTR.Rows(0).Item("QUALITY")
                        CMBDESIGN.Text = DTR.Rows(0).Item("DESIGNNO")
                        cmbcolor.Text = DTR.Rows(0).Item("COLOR")

                        If ClientName = "KDFAB" And txtremarks.Text.Trim = "" Then txtremarks.Text = CMBBARCODE.Text.Trim
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
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
            If CMBJONO.Text.Trim <> "" And CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub
                If ClientName = "SBA" Or ClientName = "KARAN" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Then
                    Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
                    If Val(TXTNOOFENTRIES.Text.Trim) = 0 Then txtqty.Text = 1 Else txtqty.Text = Val(TXTNOOFENTRIES.Text.Trim)
                    If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim)
                    For I As Integer = 1 To Val(TEMPQTY)
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                LSRNO = InStr(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                SNO = GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                                TXTBARCODE.Text = "J-" & Val(TXTJINO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTBARCODE.Text = "J-" & Val(TXTJINO.Text.Trim) & "/" & GRIDJOBIN.RowCount + 1 & "/" & YearId
                            End If
                        End If
                        fillgrid()
                    Next
                Else
                    If GRIDDOUBLECLICK = False Then
                        If EDIT = True Then
                            'GET LAST BARCODE SRNO
                            Dim LSRNO As Integer = 0
                            Dim RSRNO As Integer = 0
                            Dim SNO As Integer = 0
                            LSRNO = InStr(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            RSRNO = InStr(LSRNO + 1, GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            SNO = GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                            TXTBARCODE.Text = "J-" & Val(TXTJINO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                        Else
                            TXTBARCODE.Text = "J-" & Val(TXTJINO.Text.Trim) & "/" & GRIDJOBIN.RowCount + 1 & "/" & YearId
                        End If
                    End If
                    fillgrid()
                End If

                If ClientName = "KCRAYON" Then TXTMTRS.Focus()

            Else
                If CMBJONO.Text.Trim = "" Then
                    MsgBox("Enter Job Out No.", MsgBoxStyle.Critical)
                    CMBJONO.Focus()
                ElseIf CMBPIECETYPE.Text.Trim = "" Then
                    MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                    CMBPIECETYPE.Focus()
                ElseIf cmbitemname.Text.Trim = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                    cmbitemname.Focus()
                    'ElseIf CMBQUALITY.Text.Trim = "" Then
                    '    MsgBox("Enter Quality", MsgBoxStyle.Critical)
                    '    CMBQUALITY.Focus()
                ElseIf CMBQUALITY.Text.Trim = "" And ClientName <> "KCRAYON" Then
                    MsgBox("Enter Quality", MsgBoxStyle.Critical)
                    CMBQUALITY.Focus()
                    'ElseIf CMBDESIGN.Text.Trim = "" Then
                    '    MsgBox("Enter Design", MsgBoxStyle.Critical)
                    '    CMBDESIGN.Focus()
                ElseIf CMBDESIGN.Text.Trim = "" And ClientName <> "KCRAYON" Then
                    MsgBox("Enter Design", MsgBoxStyle.Critical)
                    CMBDESIGN.Focus()
                ElseIf Val(txtqty.Text.Trim) = 0 Then
                    MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                    txtqty.Focus()
                ElseIf cmbqtyunit.Text.Trim = "" Then
                    MsgBox("Enter Unit", MsgBoxStyle.Critical)
                    cmbqtyunit.Focus()
                ElseIf Val(TXTMTRS.Text.Trim) = 0 Then
                    MsgBox("Enter Mtrs", MsgBoxStyle.Critical)
                    TXTMTRS.Focus()
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

    Private Sub TXTJINO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTJINO.Validating
        Try
            If Val(TXTJINO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBIN.JI_NO,0)  AS JINO", "", " JOBIN ", "  AND JOBIN.JI_NO=" & TXTJINO.Text.Trim & " AND JOBIN.JI_CMPID = " & CmpId & " AND JOBIN.JI_LOCATIONID = " & Locationid & " AND JOBIN.JI_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Job In No Already Exists")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTJINO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTJINO.KeyPress
        numkeypress(e, TXTJINO, Me)
    End Sub

    Private Sub CMBDESIGN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGNPROCESSWISERATECHART.DES_RATE,0)  AS RATE ", "", " DESIGNPROCESSWISERATECHART INNER JOIN DESIGNMASTER ON DESIGNPROCESSWISERATECHART.DES_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN PROCESSMASTER ON DESIGNPROCESSWISERATECHART.DES_PROCESSID = PROCESSMASTER.PROCESS_ID ", " AND DESIGNMASTER.DESIGN_NO='" & CMBDESIGN.Text.Trim & "' AND PROCESSMASTER.PROCESS_NAME = '" & CMBPROCESS.Text.Trim & " ' AND DESIGNPROCESSWISERATECHART.DES_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        TXTRATE.Text = Val(DT.Rows(0).Item("RATE"))
                    Next
                End If
            End If

            'GET ITEMNAME AUTO
            If (ClientName = "AVIS" Or ClientName = "KRISHNA") And CMBDESIGN.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then cmbitemname.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALEWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALEWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_Enter(sender As Object, e As EventArgs) Handles TXTMTRS.Enter
        If ClientName = "KOCHAR" And GRIDDOUBLECLICK = False And CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
            GBMTRS.Visible = True
            TXTDMTRS.Focus()
        End If
    End Sub

    Private Sub TXTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTDMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Sub FILLMTRSGRID()
        Try
            If GRIDMTRSDOUBLECLICK = False Then
                GRIDMTRS.Rows.Add(Val(TXTDMTRS.Text.Trim))
            ElseIf GRIDMTRSDOUBLECLICK = True Then
                GRIDMTRS.Item(DMTRS.Index, TEMPMTRSROW).Value = Val(TXTDMTRS.Text.Trim)
                GRIDMTRSDOUBLECLICK = False
            End If
            TXTDMTRS.Clear()
            TXTDMTRS.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(sender As Object, e As EventArgs) Handles CMDCLOSE.Click
        Try
            For Each ROW As DataGridViewRow In GRIDMTRS.Rows
                TXTMTRS.Text = ROW.Cells(DMTRS.Index).Value

                If GRIDDOUBLECLICK = False And EDIT = True Then
                    'GET LAST BARCODE SRNO
                    Dim LSRNO As Integer = 0
                    Dim RSRNO As Integer = 0
                    Dim SNO As Integer = 0
                    LSRNO = InStr(GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    RSRNO = InStr(LSRNO + 1, GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    SNO = GRIDJOBIN.Rows(GRIDJOBIN.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                    TXTBARCODE.Text = "J-" & Val(TXTJINO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                End If

                fillgrid()
            Next
            TXTBALENO.Text = Val(TXTBALENO.Text) + 1
            GRIDMTRS.RowCount = 0
            TXTDMTRS.Clear()
            GBMTRS.Visible = False
            TXTBALENO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPJOBINNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(JINO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJJO As New GDNDESIGN
            OBJJO.MdiParent = MDIMain
            OBJJO.DIRECTPRINT = True
            OBJJO.FRMSTRING = "JOBIN"
            OBJJO.DIRECTMAIL = False
            OBJJO.DIRECTWHATSAPP = True
            OBJJO.PRINTSETTING = PRINTDIALOG
            OBJJO.FORMULA = "{JOBIN.JI_NO}=" & Val(JINO) & " and {JOBIN.JI_yearid}=" & YearId
            OBJJO.JONO = Val(JINO)
            OBJJO.NOOFCOPIES = 1
            OBJJO.Show()
            OBJJO.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\JOBIN_" & Val(JINO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("JOBIN_" & Val(JINO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMTRS_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDMTRS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMTRS.RowCount > 0 Then
                If GRIDMTRSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDMTRS.Rows.RemoveAt(GRIDMTRS.CurrentRow.Index)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDMTRS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDMTRS.CellDoubleClick
        Try
            If GRIDMTRS.CurrentRow.Index >= 0 And GRIDMTRS.Item(DMTRS.Index, GRIDMTRS.CurrentRow.Index).Value <> Nothing Then
                GRIDMTRSDOUBLECLICK = True
                TXTDMTRS.Text = GRIDMTRS.Item(DMTRS.Index, GRIDMTRS.CurrentRow.Index).Value.ToString
                TEMPMTRSROW = GRIDMTRS.CurrentRow.Index
                TXTDMTRS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(sender As Object, e As EventArgs) Handles TXTMTRS.Validated
        If ClientName = "AVIS" Or ClientName = "SMS" And Val(TXTMTRS.Text.Trim) > 0 Then CMBSHELF_Validated(sender, e)
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBJOSRNO_Validated(sender As Object, e As EventArgs) Handles CMBJOSRNO.Validated
        Try
            If ClientName = "KARAN" And Val(CMBJOSRNO.Text.Trim) > 0 And Val(CMBJONO.Text.Trim) > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(JO_MTRS,0) AS MTRS", "", "JOBOUT_DESC", " AND JO_NO = " & Val(CMBJONO.Text.Trim) & " AND JO_GRIDSRNO = " & Val(CMBJOSRNO.Text.Trim) & " AND JO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTJOMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class