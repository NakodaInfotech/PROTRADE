
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class PurchaseMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK, GRIDEXTRADBLCLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPCHGSROW, TEMPEXTRAROW, TEMPUPLOADROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO As String
    Public EDIT As Boolean
    Public TEMPBILLNO, TEMPREGNAME As String
    Dim PURREGABBR, PURREGINITIAL As String
    Public Shared selectGRNtable As New DataTable
    'Dim ALLOWMANUALBILLNO As Boolean = False
    Public AUTOPURCHASE As Boolean = False
    Public TEMPGRNNO As Integer = 0

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub CLEAR()

        CMBSCREENTYPE.Text = PURCHASESCREENTYPE
        HIDEVIEW()
        LBLCATEGORY.Text = ""
        CMBSERVICETYPE.Enabled = True

        If ClientName <> "KCRAYON" Then BILLDATE.Text = Now.Date
        tstxtbillno.Clear()

        If ALLOWMANUALBILLNO = True Then
            TXTBILLNO.ReadOnly = False
            TXTBILLNO.BackColor = Color.LemonChiffon
        Else
            TXTBILLNO.ReadOnly = True
            TXTBILLNO.BackColor = Color.Linen
        End If

        TXTSACCODE.Clear()
        CMBSACDESC.Enabled = True

        cmbname.Text = ""
        cmbname.Enabled = True
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        TXTPARTYBILLNO.Clear()
        If ClientName <> "KCRAYON" Then DTPARTYBILLDATE.Text = Now.Date

        CMBAGENT.Text = ""
        TXTDESCRIPTION.Clear()
        CMBTRANSPORT.Text = ""
        TXTCRDAYS.Clear()
        DUEDATE.Value = Now.Date
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date
        TXTREFNO.Clear()
        txtlrno.Clear()
        lrdate.Value = Now.Date
        TXTVEHICLENO.Clear()
        CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        txtadd.Clear()
        txtremarks.Clear()
        TXTMULTIPONO.Clear()
        PODATE.Clear()
        If ClientName = "NVAHAN" Then TXTNOOFBALES.Text = 1 Else TXTNOOFBALES.Clear()
        CMBDYEINGNAME.Text = ""
        CHKBILLCHECKED.Checked = False
        CHKBILLDISPUTE.Checked = False

        CHKTDS.CheckState = CheckState.Unchecked
        CHKRCM.CheckState = CheckState.Unchecked
        If ClientName = "MIDAS" Then CHKMANUAL.CheckState = CheckState.Checked Else CHKMANUAL.CheckState = CheckState.Unchecked
        CHKMANUALROUND.CheckState = CheckState.Unchecked


        For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
            Dim DTR As DataRowView = CHKFORMBOX.Items(I)
            CHKFORMBOX.SetItemCheckState(I, CheckState.Unchecked)
        Next
        CHKFORMBOX.SetItemChecked(CHKFORMBOX.FindStringExact("GST"), True)

        EP.Clear()
        PBDN.Visible = False
        PBPAID.Visible = False
        PBTDS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSHOWDETAILS.Visible = False
        CMDSELECTGRN.Enabled = True

        TXTSRNO.Text = 1
        CMBITEM.Text = ""
        TXTHSNCODE.Clear()
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTLOTNO.Clear()
        TXTBALENO.Clear()

        TXTQTY.Clear()
        If ClientName = "SOFTAS" Then CMBQTYUNIT.Text = "PCS" Else CMBQTYUNIT.Text = ""
        TXTMTRS.Clear()
        TXTRATE.Clear()
        If ClientName = "CC" Or ClientName = "SHREEDEV" Or ClientName = "MAHAVIR" Or ClientName = "NVAHAN" Or ClientName = "DETLINE" Then CMBPER.Text = "Qty" Else CMBPER.Text = "Mtrs"
        TXTAMT.Clear()
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()
        TXTSPDISCAMT.Clear()
        TXTSPDISCAMT.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        GRIDBILL.RowCount = 0

        TXTCHGSSRNO.Text = 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTNETT.Clear()
        TXTTDSAMT.Clear()
        TXTBAL.Clear()
        GRIDCHGS.RowCount = 0
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.Image = Nothing
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        getmax_BILL_no()

        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        txtbillamt.Text = 0.0
        TXTTOTALTAXAMT.Clear()
        TXTTOTALOTHERCHGSAMT.Clear()
        TXTCHARGES.Text = 0.0
        TXTSUBTOTAL.Text = 0.0
        txtgrandtotal.Text = 0.0
        TXTROUNDOFF.Text = 0.0

        lbltotalqty.Text = 0.0
        lbltotalmtrs.Text = 0.0
        LBLTOTALAMT.Text = 0.0
        LBLTOTALDISCAMT.Text = 0.0
        LBLTOTALSPDISCAMT.Text = 0.0
        LBLTOTALOTHERAMT.Text = 0.0
        LBLTOTALTAXABLEAMT.Text = 0.0
        LBLTOTALCGSTAMT.Text = 0.0
        LBLTOTALSGSTAMT.Text = 0.0
        LBLTOTALIGSTAMT.Text = 0.0
        TXTCGSTPER1.Clear()
        TXTCGSTAMT1.Clear()
        TXTSGSTPER1.Clear()
        TXTSGSTAMT1.Clear()
        TXTIGSTPER1.Clear()
        TXTIGSTAMT1.Clear()
        LBLACCEPTEDMTRS.Text = 0

        CHKMANUALTCS.Checked = False
        CHKTCS.Checked = False
        TXTTOTALWITHGST.Clear()
        TXTTCSPER.Clear()
        TXTTCSAMT.Clear()

        TXTFOOTERDISC.Clear()
        TXTFOOTERDISCAMT.Clear()

        txtinwords.Clear()
        TXTEWAYBILLNO.Clear()
        TXTCHADTI.Clear()

        GRIDORDER.RowCount = 0
        TabControl1.SelectedIndex = 0

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

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsPurchaseMaster


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPBILLNO)
                    ALPARAVAL.Add(cmbregister.Text.Trim)
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

    Sub getmax_BILL_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(BILL_NO),0) + 1 ", "  PURCHASEMaster INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND BILL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTBILLNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub PurchaseMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3) Then       'for CLEAR
                TabControl1.SelectedIndex = (2)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4) Then       'for CLEAR
                TabControl1.SelectedIndex = (3)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D5) Then       'for CLEAR
                TabControl1.SelectedIndex = (4)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDBILL.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for DIRECT CURSOR ON BILLNO
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then
                TabControl1.SelectedIndex = 1
                CMBCHARGES.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        fillregister(cmbregister, " and register_type = 'PURCHASE'")
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBDYEINGNAME.Text.Trim = "" Then fillname(CMBDYEINGNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Sale A/C' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' )")
        If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        fillCITY(CMBFROMCITY, EDIT)
        fillCITY(CMBTOCITY, EDIT)
        fillform(CHKFORMBOX, EDIT)
        If CMBSACDESC.Text.Trim = "" Then FILLSACCODE(CMBSACDESC, EDIT)

        If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, "")
        If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, False)
        If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
        If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)
    End Sub

    Private Sub PurchaseMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
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

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList
                Dim objclsINV As New ClsPurchaseMaster

                ALPARAVAL.Add(TEMPBILLNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsINV.alParaval = ALPARAVAL
                dt = objclsINV.selectpurchase()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        CMBSCREENTYPE.Text = dr("SCREENTYPE")
                        TXTBILLNO.Text = TEMPBILLNO
                        TXTBILLNO.ReadOnly = True

                        If Convert.ToBoolean(dr("RCM")) = False Then CHKRCM.Checked = False Else CHKRCM.Checked = True

                        cmbregister.Text = Convert.ToString(dr("REGNAME"))
                        CMBSERVICETYPE.Text = Convert.ToString(dr("PURTYPE"))
                        CMBSACDESC.Text = dr("SACDESC")
                        TXTSACCODE.Text = dr("SACCODE")
                        HIDEVIEW()
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")


                        BILLDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTPARTYBILLNO.Text = Convert.ToString(dr("PARTYBILLNO"))
                        TEMPPARTYBILLNO = Convert.ToString(dr("PARTYBILLNO"))
                        DTPARTYBILLDATE.Text = Format(Convert.ToDateTime(dr("PARTYBILLDATE")).Date, "dd/MM/yyyy")

                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBTRANSPORT.Text = dr("TRANSNAME")
                        TXTCRDAYS.Text = Convert.ToString(dr("CRDAYS"))
                        DUEDATE.Value = Convert.ToDateTime(dr("DUEDATE"))

                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        TXTREFNO.Text = Convert.ToString(dr("REFNO"))
                        txtlrno.Text = dr("LRNO")
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        CMBFROMCITY.Text = dr("FROMCITY")
                        CMBTOCITY.Text = dr("TOCITY")

                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        TXTNOOFBALES.Text = Val(dr("NOOFBALES"))
                        CMBDYEINGNAME.Text = dr("DYEINGNAME")
                        If dr("BILLCHECKED") = 0 Then CHKBILLCHECKED.Checked = False Else CHKBILLCHECKED.Checked = True
                        If dr("BILLDISPUTE") = 0 Then CHKBILLDISPUTE.Checked = False Else CHKBILLDISPUTE.Checked = True
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If Convert.ToBoolean(dr("MANUALROUNDOFF")) = False Then CHKMANUALROUND.Checked = False Else CHKMANUALROUND.Checked = True


                        TXTCGSTPER1.Text = Val(dr("TOTALCGSTPER"))
                        TXTSGSTPER1.Text = Val(dr("TOTALSGSTPER"))
                        TXTIGSTPER1.Text = Val(dr("TOTALIGSTPER"))

                        If CMBSCREENTYPE.Text = "TOTAL GST" And CHKMANUAL.Checked = True Then
                            TXTCGSTAMT1.Text = Format(Val(dr("TOTALCGSTAMT")), "0.00")
                            TXTSGSTAMT1.Text = Format(Val(dr("TOTALSGSTAMT")), "0.00")
                            TXTIGSTAMT1.Text = Format(Val(dr("TOTALIGSTAMT")), "0.00")

                        End If

                        If dr("MANUALTCS") = 0 Then CHKMANUALTCS.Checked = False Else CHKMANUALTCS.Checked = True
                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))


                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        txtinwords.Text = Convert.ToString(dr("INWORDS"))

                        TXTFOOTERDISC.Text = Val(dr("FOOTERDISC"))
                        TXTFOOTERDISCAMT.Text = Val(dr("FOOTERDISCAMT"))

                        txtbillamt.Text = Val(dr("BILLAMT"))
                        TXTCHARGES.Text = Val(dr("CHARGES"))
                        TXTROUNDOFF.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))

                        TXTAMTPAID.Text = Val(dr("AMTPAID"))
                        TXTEXTRAAMT.Text = Val(dr("EXTRAAMT"))
                        TXTRETURN.Text = Val(dr("BILLRETURN"))
                        TXTBAL.Text = Val(dr("BALANCE"))

                        TXTCHADTI.Text = Val(dr("CHADTI"))


                        'Item Grid
                        GRIDBILL.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("DESIGNNO"), dr("COLOR"), dr("PRINTDESC"), dr("LOTNO"), dr("BALENO").ToString, Val(dr("QTY")), dr("UNIT").ToString, Val(dr("CUT")), Val(dr("MTRS")), Val(dr("WT")), Val(dr("RATE")), dr("PER").ToString, Val(dr("AMT")), Val(dr("DISCPER")), Val(dr("DISCAMT")), Val(dr("SPDISCPER")), Val(dr("SPDISCAMT")), Val(dr("OTHERAMT")), Val(dr("TAXABLEAMT")), Val(dr("CGSTPER")), Val(dr("CGSTAMT")), Val(dr("SGSTPER")), Val(dr("SGSTAMT")), Val(dr("IGSTPER")), Val(dr("IGSTAMT")), Val(dr("GRIDTOTAL")), dr("GRNNO"), dr("GRNGRIDSRNO"), dr("GRIDTYPE"), dr("GRIDDONE"), Val(dr("OUTPCS")), Val(dr("OUTMTRS")))
                        TXTGRNNO.Text = Val(dr("GRNNO"))

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = False
                            GRIDBILL.Rows(GRIDBILL.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            If ClientName <> "DAKSH" And ClientName <> "SHALIBHADRA" Then cmbname.Enabled = False
                        End If
                        TabControl1.SelectedIndex = (0)


                        'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        Dim OBJCMNTDS As New ClsCommon
                        Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(SUM(JOURNALMASTER.journal_credit),0) AS TDS", "", " JOURNALMASTER INNER JOIN PURCHASEMASTER ON JOURNALMASTER.journal_refno = PURCHASEMASTER.BILL_INITIALS AND  JOURNALMASTER.journal_yearid = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id ", " AND (LEDGERS.ACC_TDSAC = 'True') AND BILL_NO = " & TEMPBILLNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND BILL_YEARID = " & YearId)
                        If DTTDS.Rows.Count > 0 Then
                            If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                                TXTTDSAMT.Text = Format(Val(DTTDS.Rows(0).Item("TDS")), "0.00")
                                CMDSHOWDETAILS.Visible = True
                                PBTDS.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If PBTDS.Visible = False Then
                            If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBPAID.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If Val(dr("BILLRETURN")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" PURCHASEMASTER_CHGS.BILL_gridsrno AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT, ISNULL(TAXMASTER.TAX_ID, 0) AS TAXID ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN PURCHASEMASTER_CHGS LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID LEFT OUTER JOIN LEDGERS ON PURCHASEMASTER_CHGS.BILL_CHARGESID = LEDGERS.Acc_id", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_CHGS.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_CHGS.BILL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If



                    'UPLOAD(GRID)
                    dt = OBJCMN.search(" PURCHASEMASTER_UPLOAD.BILL_SRNO AS GRIDSRNO, PURCHASEMASTER_UPLOAD.BILL_REMARKS AS REMARKS, PURCHASEMASTER_UPLOAD.BILL_NAME AS NAME, PURCHASEMASTER_UPLOAD.BILL_PHOTO AS IMGPATH ", "", " PURCHASEMASTER_UPLOAD ", " AND PURCHASEMASTER_UPLOAD.BILL_NO = " & TEMPBILLNO & " AND BILL_YEARID = " & YearId & " ORDER BY PURCHASEMASTER_UPLOAD.BILL_SRNO")
                    If dt.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If



                    'ORDER GRID
                    'Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" PURCHASEMASTER_PODETAILS.BILL_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, PURCHASEMASTER_PODETAILS.BILL_ORDERPCS AS ORDERQTY, ISNULL(PURCHASEMASTER_PODETAILS.BILL_ORDERMTRS,0) AS ORDERMTRS, PURCHASEMASTER_PODETAILS.BILL_FROMNO AS FROMNO, PURCHASEMASTER_PODETAILS.BILL_FROMSRNO AS FROMSRNO, PURCHASEMASTER_PODETAILS.BILL_FROMTYPE AS FROMTYPE, PURCHASEMASTER_PODETAILS.BILL_PCS AS GRNQTY, ISNULL(PURCHASEMASTER_PODETAILS.BILL_MTRS,0) AS GRNMTRS, ISNULL(PURCHASEMASTER_PODETAILS.BILL_RATE,0) AS RATE ", "", " PURCHASEMASTER_PODETAILS INNER JOIN ITEMMASTER ON PURCHASEMASTER_PODETAILS.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PURCHASEMASTER_PODETAILS.BILL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PURCHASEMASTER_PODETAILS.BILL_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER_PODETAILS.BILL_REGISTERID = REGISTERMASTER.register_id ", " AND PURCHASEMASTER_PODETAILS.BILL_NO = " & TEMPBILLNO & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "'  AND PURCHASEMASTER_PODETAILS.BILL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt.Rows
                            GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("ITEMNAME"), DTR("DESIGNNO"), DTR("COLOR"), Val(DTR("ORDERQTY")), Val(DTR("ORDERMTRS")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("GRNQTY")), Val(DTR("GRNMTRS")), Val(DTR("RATE")))
                        Next
                    End If



                    dt = OBJCMN.search(" ISNULL(FORMTYPE.FORM_NAME, '') AS FORMNAME", "", "  PURCHASEMASTER_FORMTYPE INNER JOIN REGISTERMASTER ON PURCHASEMASTER_FORMTYPE.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_FORMTYPE.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_FORMTYPE.BILL_YEARID= " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each ROW As DataRow In dt.Rows
                            For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
                                Dim DTR As DataRowView = CHKFORMBOX.Items(I)
                                If ROW("FORMNAME") = DTR.Item(0) Then
                                    CHKFORMBOX.SetItemCheckState(I, CheckState.Checked)
                                End If
                            Next
                        Next
                    End If


                    dt = OBJCMN.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        PURREGABBR = dt.Rows(0).Item(0).ToString
                        PURREGINITIAL = dt.Rows(0).Item(1).ToString
                        PURREGID = dt.Rows(0).Item(2)
                    End If
                    GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

                End If

                cmbregister.Enabled = False
                CMBSERVICETYPE.Enabled = False
                If ClientName <> "DAKSH" Then CMDSELECTGRN.Enabled = False
                'cmbname.Enabled = False
                total()
            Else
                EDIT = False
            End If
            'clear()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        'Dim IntResult As Integer
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If ALLOWMANUALBILLNO = True Then
                alParaval.Add(Val(TXTBILLNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSCREENTYPE.Text.Trim)

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(CMBSERVICETYPE.Text.Trim)
            alParaval.Add(TXTSACCODE.Text.Trim)
            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(BILLDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text)
            alParaval.Add(CHALLANDATE.Value)
            alParaval.Add(TXTREFNO.Text)

            alParaval.Add(TXTCRDAYS.Text)
            alParaval.Add(DUEDATE.Value.Date)

            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(Val(TXTNOOFBALES.Text.Trim))
            alParaval.Add(CMBDYEINGNAME.Text.Trim)
            If CHKBILLCHECKED.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKBILLDISPUTE.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUALROUND.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(Val(TXTFOOTERDISC.Text.Trim))
            alParaval.Add(Val(TXTFOOTERDISCAMT.Text.Trim))

            alParaval.Add(Val(lbltotalqty.Text.Trim))
            alParaval.Add(Val(lbltotalmtrs.Text.Trim))
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALDISCAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALSPDISCAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALOTHERAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALTAXABLEAMT.Text.Trim))


            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                alParaval.Add(Val(TXTCGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTCGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTSGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTIGSTAMT1.Text.Trim))
            Else
                alParaval.Add(Val(TXTCGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALCGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALSGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALIGSTAMT.Text.Trim))
            End If


            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKMANUALTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))



            alParaval.Add(txtinwords.Text)

            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Format(Val(TXTTOTALTAXAMT.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTTOTALOTHERCHGSAMT.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTCHARGES.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTSUBTOTAL.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTROUNDOFF.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtgrandtotal.Text.Trim), "0.00"))

            alParaval.Add(Val(TXTAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))

            alParaval.Add(Val(TXTCHADTI.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            'ADDING FORMTYPE
            Dim FORMTYPE As String = ""
            For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                If FORMTYPE = "" Then
                    FORMTYPE = DTROW.Item(0)
                Else
                    FORMTYPE = FORMTYPE & "|" & DTROW.Item(0)
                End If
            Next
            alParaval.Add(FORMTYPE)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim QUALITY As String = ""
            Dim DESIGNNO As String = ""
            Dim COLOR As String = ""
            Dim PRINTDESC As String = ""
            Dim LOTNO As String = ""
            Dim BALENO As String = ""

            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim CUT As String = ""

            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim PER As String = ""
            Dim AMT As String = ""          'value of AMT
            Dim DISCPER As String = ""
            Dim DISCAMT As String = ""
            Dim SPDISCPER As String = ""
            Dim SPDISCAMT As String = ""
            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""

            Dim GRNNO As String = ""        'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNGRIDSRNO As String = ""   'value of GRNGRIDSRNO
            Dim GRIDTYPE As String = ""     'value of TYPE
            Dim BILLDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBILL.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value.ToString

                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then PRINTDESC = row.Cells(GDESCRIPTION.Index).Value.ToString Else PRINTDESC = ""
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString

                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value

                        MTRS = row.Cells(GMTRS.Index).Value
                        WT = row.Cells(GCHECKMTRS.Index).Value
                        RATE = row.Cells(GRATE.Index).Value
                        PER = row.Cells(GPER.Index).Value.ToString
                        If row.Cells(GAMT.Index).Value <> Nothing Then AMT = row.Cells(GAMT.Index).Value Else AMT = 0
                        If row.Cells(GDISCPER.Index).Value <> Nothing Then DISCPER = row.Cells(GDISCPER.Index).Value Else DISCPER = 0
                        If row.Cells(GDISCAMT.Index).Value <> Nothing Then DISCAMT = row.Cells(GDISCAMT.Index).Value Else DISCAMT = 0
                        If row.Cells(GSPDISCPER.Index).Value <> Nothing Then SPDISCPER = row.Cells(GSPDISCPER.Index).Value Else SPDISCPER = 0
                        If row.Cells(GSPDISCAMT.Index).Value <> Nothing Then SPDISCAMT = row.Cells(GSPDISCAMT.Index).Value Else SPDISCAMT = 0
                        If row.Cells(GOTHERAMT.Index).Value <> Nothing Then OTHERAMT = row.Cells(GOTHERAMT.Index).Value Else OTHERAMT = 0

                        TAXABLEAMT = row.Cells(GTAXABLEAMT.Index).Value
                        CGSTPER = row.Cells(GCGSTPER.Index).Value
                        CGSTAMT = row.Cells(GCGSTAMT.Index).Value
                        SGSTPER = row.Cells(GSGSTPER.Index).Value
                        SGSTAMT = row.Cells(GSGSTAMT.Index).Value
                        IGSTPER = row.Cells(GIGSTPER.Index).Value
                        IGSTAMT = row.Cells(GIGSTAMT.Index).Value
                        GRIDTOTAL = row.Cells(GGRIDTOTAL.Index).Value
                        GRNNO = row.Cells(GGRNNO.Index).Value
                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = row.Cells(GGRNSRNO.Index).Value
                        Else
                            GRNGRIDSRNO = 0
                        End If
                        GRIDTYPE = row.Cells(GTYPE.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = "1"
                        Else
                            BILLDONE = "0"
                        End If
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value

                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value.ToString

                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then PRINTDESC = PRINTDESC & "|" & row.Cells(GDESCRIPTION.Index).Value.ToString Else PRINTDESC = PRINTDESC & "|" & ""
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString

                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value

                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        WT = WT & "|" & row.Cells(GCHECKMTRS.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        PER = PER & "|" & row.Cells(GPER.Index).Value
                        If row.Cells(GAMT.Index).Value <> Nothing Then AMT = AMT & "|" & row.Cells(GAMT.Index).Value Else AMT = AMT & "|" & "0"
                        DISCPER = DISCPER & "|" & Val(row.Cells(GDISCPER.Index).Value)
                        DISCAMT = DISCAMT & "|" & Val(row.Cells(GDISCAMT.Index).Value)
                        SPDISCPER = SPDISCPER & "|" & Val(row.Cells(GSPDISCPER.Index).Value)
                        SPDISCAMT = SPDISCAMT & "|" & Val(row.Cells(GSPDISCAMT.Index).Value)
                        OTHERAMT = OTHERAMT & "|" & Val(row.Cells(GOTHERAMT.Index).Value)

                        TAXABLEAMT = TAXABLEAMT & "|" & Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = CGSTAMT & "|" & Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = SGSTAMT & "|" & Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = IGSTAMT & "|" & Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(row.Cells(GGRIDTOTAL.Index).Value)

                        GRNNO = GRNNO & "|" & row.Cells(GGRNNO.Index).Value
                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & Val(row.Cells(GGRNSRNO.Index).Value)
                        Else
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & " 0"
                        End If
                        GRIDTYPE = GRIDTYPE & "|" & row.Cells(GTYPE.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = BILLDONE & "|" & "1"
                        Else
                            BILLDONE = BILLDONE & "|" & "0"
                        End If

                        OUTPCS = OUTPCS & "|" & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "|" & Val(row.Cells(GOUTMTRS.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)

            alParaval.Add(QUALITY)
            alParaval.Add(DESIGNNO)

            alParaval.Add(COLOR)
            alParaval.Add(PRINTDESC)
            alParaval.Add(LOTNO)
            alParaval.Add(BALENO)

            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(CUT)

            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMT)
            alParaval.Add(DISCPER)
            alParaval.Add(DISCAMT)
            alParaval.Add(SPDISCPER)
            alParaval.Add(SPDISCAMT)
            alParaval.Add(OTHERAMT)
            alParaval.Add(TAXABLEAMT)
            alParaval.Add(CGSTPER)
            alParaval.Add(CGSTAMT)
            alParaval.Add(SGSTPER)
            alParaval.Add(SGSTAMT)
            alParaval.Add(IGSTPER)
            alParaval.Add(IGSTAMT)
            alParaval.Add(GRIDTOTAL)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNGRIDSRNO)
            alParaval.Add(GRIDTYPE)
            alParaval.Add(BILLDONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)


            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = Val(row.Cells(ESRNO.Index).Value)
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CPER = Val(row.Cells(EPER.Index).Value)
                        CAMT = Val(row.Cells(EAMT.Index).Value)
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)

                    Else
                        CSRNO = CSRNO & "|" & Val(row.Cells(ESRNO.Index).Value)
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & Val(row.Cells(EPER.Index).Value)
                        CAMT = CAMT & "|" & Val(row.Cells(EAMT.Index).Value)
                        CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)

            alParaval.Add(ClientName)



            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERITEMNAME As String = ""
            Dim ORDERDESIGN As String = ""
            Dim ORDERCOLOR As String = ""
            Dim ORDERPCS As String = ""
            Dim ORDERMTRS As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERGRNPCS As String = ""
            Dim ORDERGRNMTRS As String = ""
            Dim ORDERRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(OGRNQTY.Index).Value) > 0 Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERDESIGN = row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        ORDERPCS = Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGRNPCS = Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERGRNMTRS = Val(row.Cells(OGRNMTRS.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = ORDERITEMNAME & "|" & row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERDESIGN = ORDERDESIGN & "|" & row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = ORDERCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        ORDERPCS = ORDERPCS & "|" & Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = ORDERMTRS & "|" & Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGRNPCS = ORDERGRNPCS & "|" & Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERGRNMTRS = ORDERGRNMTRS & "|" & Val(row.Cells(OGRNMTRS.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERITEMNAME)
            alParaval.Add(ORDERDESIGN)
            alParaval.Add(ORDERCOLOR)
            alParaval.Add(ORDERPCS)
            alParaval.Add(ORDERMTRS)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERGRNPCS)
            alParaval.Add(ORDERGRNMTRS)
            alParaval.Add(ORDERRATE)

            Dim OBJINV As New ClsPurchaseMaster
            OBJINV.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJINV.SAVE()
                TEMPBILLNO = DTTABLE.Rows(0).Item(0)
                MessageBox.Show("Details Added")

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                    OBJTDS.REGISTER = cmbregister.Text.Trim
                    OBJTDS.ShowDialog()
                End If

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBILLNO)
                IntResult = OBJINV.UPDATE()
                MessageBox.Show("Details Updated")
            End If

            'ADD DATA IN PURCHASEORDER DATATABLE AND THEN SAVE IN DATABASE
            If TXTMULTIPONO.Text.Trim <> "" Then SETPURCHASEORDER()

            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            'DRECTLY CREATE SALE INVOICE
            If (ClientName = "NVAHAN" Or ClientName = "SAKARIA") And EDIT = False Then
                If MsgBox("Wish to create Sale Invoice Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    EDIT = False
                    clear()
                    Exit Sub
                End If
                Dim OBJSALE As New DirectInvoiceParty
                OBJSALE.ShowDialog()
                Dim TEMPNAME As String = OBJSALE.CMBNAME.Text.Trim

                Dim OBJSALEINV As New InvoiceMaster
                OBJSALEINV.MdiParent = MDIMain
                OBJSALEINV.TEMPPURNO = TEMPBILLNO
                OBJSALEINV.TEMPPURREGNAME = cmbregister.Text.Trim
                OBJSALEINV.DIRECTINVOICE = True
                OBJSALEINV.TEMPPARTYNAME = TEMPNAME
                OBJSALEINV.Show()
            End If


            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            EDIT = False
            Call toolnext_Click(sender, e)

            If CMBSERVICETYPE.Visible = True Then CMBSERVICETYPE.Focus() Else BILLDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub SETPURCHASEORDER()
        Try
            'IF EDIT = TRUE THEN REVERSE DATA IN PURCHASEORDER DESC AND DELETE DATA AND REINSERT
            Dim ALLOWEDPCS As Decimal = 0.0
            Dim POSRNO As Integer = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim PODT As New DataTable

            PODT.Columns.Add("BILLNO")
            PODT.Columns.Add("REGNAME")
            PODT.Columns.Add("SRNO")
            PODT.Columns.Add("PONO")
            PODT.Columns.Add("POSRNO")
            PODT.Columns.Add("QTY")


            'FIRST WE WILL CHECK PODESC WITH RESPECT TO ITEMNAME AND GET ALLOWEDPCS AND POSRNO
            For Each ROW As DataGridViewRow In GRIDBILL.Rows
                DT = OBJCMN.search("ROUND((PO_QTY - PO_RECDQTY),2) AS ALLOWEDQTY, PO_NO AS PONO, PO_GRIDSRNO AS POSRNO", "", "PURCHASEORDER_DESC INNER JOIN ITEMMASTER ON ITEM_ID = PO_ITEMID ", " AND ROUND((PO_QTY - PO_RECDQTY),2) > 0 AND PO_NO IN (" & TXTMULTIPONO.Text.Trim & ") AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND PO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    ALLOWEDPCS = Val(DT.Rows(0).Item("ALLOWEDQTY"))
                    POSRNO = Val(DT.Rows(0).Item("POSRNO"))

                    If Format((ALLOWEDPCS - Val(ROW.Cells(gQty.Index).Value)), 2) >= 0 Then ALLOWEDPCS -= Val(ROW.Cells(gQty.Index).Value)

                    PODT.Rows.Add(TEMPBILLNO, cmbregister.Text.Trim, ROW.Index, Val(DT.Rows(0).Item("PONO")), POSRNO, Val(ROW.Cells(gQty.Index).Value))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            TXTGRIDTOTAL.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCAMT.Clear()
            If Val(TXTSPDISCPER.Text.Trim) > 0 Then TXTSPDISCAMT.Clear()
            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = 0.0
                TXTSGSTAMT.Text = 0.0
                TXTIGSTAMT.Text = 0.0

                TXTCGSTAMT1.Text = 0.0
                TXTSGSTAMT1.Text = 0.0
                TXTIGSTAMT1.Text = 0.0
            End If
            If Val(TXTRATE.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")
                End If
            End If

            If Val(TXTDISCPER.Text.Trim) > 0 And Val(TXTDISCAMT.Text.Trim) = 0 Then TXTDISCAMT.Text = Format(Val(TXTAMT.Text.Trim) * (Val(TXTDISCPER.Text.Trim) / 100), "0.00")
            If Val(TXTSPDISCPER.Text.Trim) > 0 And Val(TXTSPDISCAMT.Text.Trim) = 0 Then TXTSPDISCAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim)) * (Val(TXTSPDISCPER.Text.Trim) / 100), "0.00")
            TXTTAXABLEAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim) - Val(TXTSPDISCPER.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")
            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")

                TXTCGSTAMT1.Text = Format(Val(TXTCGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
                TXTSGSTAMT1.Text = Format(Val(TXTSGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
                TXTIGSTAMT1.Text = Format(Val(TXTIGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")

            End If
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

            'If CMBSCREENTYPE.Text = "TOTAL GST" Then TXTGRIDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text) + Val(TXTSGSTAMT1.Text) + Val(TXTIGSTAMT1.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        If ALLOWMANUALBILLNO = True Then
            If TXTBILLNO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(CONTRA.CONTRA_no,0) AS CONTRANO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CONTRA ON REGISTERMASTER.register_id = CONTRA.CONTRA_registerid AND REGISTERMASTER.register_cmpid = CONTRA.CONTRA_cmpid AND REGISTERMASTER.register_yearid = CONTRA.CONTRA_yearid AND REGISTERMASTER.register_locationid = CONTRA.CONTRA_locationid ", "  AND CONTRA.CONTRA_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CONTRA.CONTRA_CMPID = " & CmpId & " AND CONTRA.CONTRA_LOCATIONID = " & Locationid & " AND CONTRA.CONTRA_YEARID = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER.BILL_NO, 0) AS BILLNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PURCHASEMASTER ON REGISTERMASTER.register_id = PURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_cmpid = PURCHASEMASTER.BILL_CMPID AND REGISTERMASTER.register_yearid = PURCHASEMASTER.BILL_YEARID AND REGISTERMASTER.register_locationid = PURCHASEMASTER.BILL_LOCATIONID ", "  AND PURCHASEMASTER.BILL_NO=" & TXTBILLNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PURCHASEMASTER.BILL_cmpid = " & CmpId & " AND PURCHASEMASTER.BILL_locationid = " & Locationid & " AND PURCHASEMASTER.BILL_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTBILLNO, "Bill No Already Exist")
                    bln = False
                End If
            End If
        End If


        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
            bln = False
        End If


        If ClientName = "ALENCOT" And txtremarks.Text.Trim.Length = 0 Then
            EP.SetError(txtremarks, "Enter Remarks...")
            bln = False
        End If


        If ClientName = "YASHVI" And Val(TXTCRDAYS.Text.Trim) = 0 Then
            If MsgBox("Cr Days is 0, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                EP.SetError(cmbname, "Enter Cr Days")
                bln = False
            End If
        End If

        'DONE BY GULKIT
        'If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/02/2018" And txtgrandtotal.Text > 50000 Then
        '    If TXTEWAYBILLNO.Text.Trim.Length = 0 Then
        '        If MsgBox("E-Way No. Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '            EP.SetError(TXTEWAYBILLNO, " Please Enter E-Way No..... ")
        '            bln = False
        '        End If
        '    End If
        'End If



        'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
        If ClientName = "NVAHAN" Then
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(OGRNQTY.Index).Value = 0
                    ORDROW.Cells(OGRNMTRS.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                TXTMULTIPONO.Clear()
                For Each a As String In MULTISONO
                    If TXTMULTIPONO.Text = "" Then
                        TXTMULTIPONO.Text = a
                    Else
                        TXTMULTIPONO.Text = TXTMULTIPONO.Text & "," & a
                    End If
                Next

                For Each ROW As DataGridViewRow In GRIDBILL.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(gitemname.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And ROW.Cells(GDESIGNNO.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(OGRNMTRS.Index).Value) >= Val(ORDROW.Cells(OMTRS.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If
                            ORDROW.Cells(OGRNQTY.Index).Value = Val(ORDROW.Cells(OGRNQTY.Index).Value) + Val(ROW.Cells(gQty.Index).Value)
                            ORDROW.Cells(OGRNMTRS.Index).Value = Val(ORDROW.Cells(OGRNMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).Value)
                            'ROW.Cells(GRATE.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value) + Val(ROW.Cells(gQty.Index).Value)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).Value)
                        'ROW.Cells(GRATE.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
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
        End If




        If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then
            If TXTSTATECODE.Text.Trim.Length = 0 Then
                EP.SetError(TXTSTATECODE, "Please enter the state code")
                bln = False
            End If

            If TXTGSTIN.Text.Trim.Length = 0 Then
                If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    EP.SetError(TXTSTATECODE, "Enter GSTIN in Party Master")
                    bln = False
                End If
            End If

            'AS PER KUMAR BHAI WE NEED TO ENTER 0 IN GST
            If CMBSCREENTYPE.Text = "TOTAL GST" And ClientName <> "ALENCOT" And ClientName <> "YASHVI" Then
                If Val(TXTCGSTAMT1.Text.Trim) = 0 And Val(TXTSGSTAMT1.Text.Trim) = 0 And Val(TXTIGSTAMT1.Text.Trim) = 0 Then
                    EP.SetError(TXTCGSTAMT1, "Enter CGST/SGST/IGST")
                    bln = False
                End If
            End If

            If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(LBLTOTALCGSTAMT.Text) > 0 Or Val(LBLTOTALSGSTAMT.Text.Trim) > 0) Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                bln = False
            End If

            If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(LBLTOTALIGSTAMT.Text) > 0 Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                bln = False
            End If
        End If

        If CMBAGENT.Text.Trim.Length = 0 And ClientName <> "NVAHAN" And ClientName <> "SAKARIA" And ClientName <> "MOMAI" Then
            EP.SetError(CMBAGENT, " Please Enter Agent Name ")
            bln = False
        End If

        If GRIDBILL.RowCount = 0 Then
            EP.SetError(cmbname, "Select grn")
            bln = False
        End If

        If ClientName <> "BARKHA" And ClientName <> "PARAS" And ClientName <> "MOMAI" And ClientName <> "SHUBHI" Then
            For Each row As DataGridViewRow In GRIDBILL.Rows
                If Val(row.Cells(GAMT.Index).Value) = 0 Then
                    EP.SetError(cmbname, "Amt Cannot be 0")
                    bln = False
                End If
            Next
        End If


        'CHECK WHETHER PURCHASER HAS CROSSED 50LAKHS OR NOT
        Dim DT As New DataTable
        If CHKTDS.CheckState = CheckState.Unchecked Then
            Dim TEMPTDSTOTAL As Double = Val(txtgrandtotal.Text.Trim)
            DT = OBJCMN.Execute_Any_String("SELECT ISNULL(SUM(BILL_GRANDTOTAL),0) AS GTOTAL FROM PURCHASEMASTER INNER JOIN LEDGERS ON BILL_LEDGERID = LEDGERS.ACC_ID WHERE BILL_YEARID = " & YearId & " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "'", "", "")
            If DT.Rows.Count > 0 Then TEMPTDSTOTAL += Val(DT.Rows(0).Item("GTOTAL"))
            If TEMPTDSTOTAL > 5000000 Then
                If MsgBox("Amount Exceeds 5000000, and TDS is not Applied, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    EP.SetError(cmbname, "Apply TDS")
                    bln = False
                End If
            End If
        End If


        Dim FORMTYPE As String = ""
        For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
            FORMTYPE = DTROW.Item(0)
        Next
        If FORMTYPE = Nothing Then
            EP.SetError(CHKFORMBOX, "Pls Select Form Type")
            bln = False
        End If

        If UserName <> "Admin" Then
            If (ClientName <> "DAKSH" And ClientName <> "RSONS") And lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Rec/Pay/TDS Made, Delete Rec/Pay/TDS First")
                bln = False
            End If
        End If

        If BILLDATE.Text = "__/__/____" Then
            EP.SetError(BILLDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BILLDATE.Text) Then
                EP.SetError(BILLDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If DTPARTYBILLDATE.Text = "__/__/____" Then
            EP.SetError(DTPARTYBILLDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTPARTYBILLDATE.Text) Then
                EP.SetError(DTPARTYBILLDATE, "Date not in Accounting Year")
                bln = False
            End If

            If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date < PURBLOCKDATE.Date Then
                EP.SetError(DTPARTYBILLDATE, "Date is Blocked, Please make entries after " & Format(PURBLOCKDATE.Date, "dd/MM/yyyy"))
                bln = False
            End If
        End If

        If TXTPARTYBILLNO.Text.Trim <> "" Then
            If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then

                'IF SAME BILLNO, DATE AND PARTYNAME IS PRESENT IN ANY COMPANY THEN INTIMATE
                If ClientName = "NVAHAN" Then
                    DT = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_PARTYBILLDATE = '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "'")
                Else
                    DT = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then
                    MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                    bln = False
                End If
            End If
        End If

        Return bln
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try

            TXTTCSPER.Text = 0
            If CHKMANUALTCS.Checked = False Then TXTTCSAMT.Text = 0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))



            lbltotalqty.Text = "0.0"
            lbltotalmtrs.Text = "0.0"
            LBLTOTALCHKMTRS.Text = 0.0
            LBLTOTALAMT.Text = "0.0"
            LBLTOTALDISCAMT.Text = 0.0
            LBLTOTALSPDISCAMT.Text = 0.0
            LBLTOTALOTHERAMT.Text = "0.0"
            LBLTOTALTAXABLEAMT.Text = "0.0"
            LBLTOTALCGSTAMT.Text = "0.0"
            LBLTOTALSGSTAMT.Text = "0.0"
            LBLTOTALIGSTAMT.Text = "0.0"

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            If CHKMANUALROUND.CheckState = CheckState.Unchecked Then TXTROUNDOFF.Text = 0
            txtgrandtotal.Text = 0

            If GRIDBILL.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDBILL.Rows
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(GMTRS.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Qty" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(gQty.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    End If
                    If Val(row.Cells(GDISCPER.Index).EditedFormattedValue) <> 0 Then row.Cells(GDISCAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).Value) * (Val(row.Cells(GDISCPER.Index).EditedFormattedValue) / 100), "0.00")
                    If Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) <> 0 Then
                        'CALC ON RUNNING TOTAL FOR EVERYONE
                        row.Cells(GSPDISCAMT.Index).Value = Format((Val(row.Cells(GAMT.Index).Value) - Val(row.Cells(GDISCAMT.Index).Value)) * (Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) / 100), "0.00")

                        'IF ANY CLIENT DONT WANT ABOVE MENTIONED CODE ENABLE BELOW CODE
                        If ClientName = "" Then
                            row.Cells(GSPDISCAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).Value) * (Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) / 100), "0.00")
                        End If
                    End If
                    row.Cells(GTAXABLEAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).EditedFormattedValue) - Val(row.Cells(GDISCAMT.Index).EditedFormattedValue) - Val(row.Cells(GSPDISCAMT.Index).EditedFormattedValue) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")

                    If CHKMANUAL.CheckState = CheckState.Unchecked And PURCHASESCREENTYPE = "LINE GST" Then
                        row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                    End If
                    row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(gQty.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0")
                    If Val(row.Cells(GMTRS.Index).Value) <> 0 Then lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GCHECKMTRS.Index).Value) <> 0 Then LBLTOTALCHKMTRS.Text = Format(Val(LBLTOTALCHKMTRS.Text) + Val(row.Cells(GCHECKMTRS.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GAMT.Index).Value) <> 0 Then LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(GDISCAMT.Index).Value) <> 0 Then LBLTOTALDISCAMT.Text = Format(Val(LBLTOTALDISCAMT.Text) + Val(row.Cells(GDISCAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GSPDISCAMT.Index).Value) <> 0 Then LBLTOTALSPDISCAMT.Text = Format(Val(LBLTOTALSPDISCAMT.Text) + Val(row.Cells(GSPDISCAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GOTHERAMT.Index).Value) <> 0 Then LBLTOTALOTHERAMT.Text = Format(Val(LBLTOTALOTHERAMT.Text) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GTAXABLEAMT.Index).Value) <> 0 Then LBLTOTALTAXABLEAMT.Text = Format(Val(LBLTOTALTAXABLEAMT.Text) + Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(GCGSTAMT.Index).Value) <> 0 Then LBLTOTALCGSTAMT.Text = Format(Val(LBLTOTALCGSTAMT.Text) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GSGSTAMT.Index).Value) <> 0 Then LBLTOTALSGSTAMT.Text = Format(Val(LBLTOTALSGSTAMT.Text) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GIGSTAMT.Index).Value) <> 0 Then LBLTOTALIGSTAMT.Text = Format(Val(LBLTOTALIGSTAMT.Text) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GGRIDTOTAL.Index).Value) <> 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

                Next
            End If



            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    'If ClientName = "SBA" Then
                    '    'IF PERCENT IS > 0 THEN GETAUTO CHARGES
                    '    Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & row.Cells(ECHARGES.Index).Value & "' AND ACC_YEARID = " & YearId)

                    '    If DT.Rows(0).Item("CALC") = "GROSS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                    '        row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                    '    ElseIf DT.Rows(0).Item("CALC") = "NETT" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                    '        TXTNETT.Text = Val(txtbillamt.Text.Trim)
                    '        For I As Integer = 0 To row.Index - 1
                    '            TXTNETT.Text = Format(Val(TXTNETT.Text) + Val(GRIDCHGS.Rows(I).Cells(EAMT.Index).Value), "0.00")
                    '        Next
                    '        row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(TXTNETT.Text.Trim)) / 100, "0.00")
                    '        'TXTCHGSAMT.Text = Format((Val(TXTNETT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                    '    End If
                    'End If
                    If ClientName = "SOFTAS" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then  'ClientName = "NVAHAN" Or ClientName = "SAKARIA" Or ClientName = "SBA" Or ClientName = "KCRAYON" Or ClientName = "SOFTAS" Or ClientName = "ALENCOT" Then
                        'IF PERCENT IS > 0 THEN GETAUTO CHARGES
                        Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & row.Cells(ECHARGES.Index).Value & "' AND ACC_YEARID = " & YearId)

                        If DT.Rows(0).Item("CALC") = "GROSS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                            row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                        ElseIf DT.Rows(0).Item("CALC") = "NETT" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                            TXTNETT.Text = Val(txtbillamt.Text.Trim)
                            For I As Integer = 0 To row.Index - 1
                                TXTNETT.Text = Format(Val(TXTNETT.Text) + Val(GRIDCHGS.Rows(I).Cells(EAMT.Index).Value), "0.00")
                            Next
                            row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(TXTNETT.Text.Trim)) / 100, "0.00")
                            'TXTCHGSAMT.Text = Format((Val(TXTNETT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                        End If
                    End If
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                    If Val(row.Cells(ETAXID.Index).Value) > 0 Then TXTTOTALTAXAMT.Text = Format(Val(TXTTOTALTAXAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00") Else TXTTOTALOTHERCHGSAMT.Text = Format(Val(TXTTOTALOTHERCHGSAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If


            If ClientName = "NVAHAN" Then
                If Val(TXTFOOTERDISCAMT.Text.Trim) = 0 Then TXTFOOTERDISCAMT.Text = Format((Val(TXTFOOTERDISC.Text.Trim) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) - Val(TXTFOOTERDISCAMT.Text), "0.00")
            End If


            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    TXTCGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER1.Text.Trim)) / 100, "0.00")
                    LBLTOTALCGSTAMT.Text = Val(TXTCGSTAMT1.Text.Trim)
                    TXTSGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER1.Text.Trim)) / 100, "0.00")
                    LBLTOTALSGSTAMT.Text = Val(TXTSGSTAMT1.Text.Trim)
                    TXTIGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER1.Text.Trim)) / 100, "0.00")
                    LBLTOTALIGSTAMT.Text = Val(TXTIGSTAMT1.Text.Trim)
                End If


                TXTTOTALWITHGST.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim), "0.00")
                If CHKTCS.CheckState = CheckState.Checked And CHKMANUALTCS.CheckState = CheckState.Unchecked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")

                If CHKMANUALROUND.Checked = False Then
                    txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0")
                    TXTROUNDOFF.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")
                Else
                    txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim) + Val(TXTTCSAMT.Text.Trim) + Val(TXTROUNDOFF.Text.Trim), "0.00")
                End If

            Else

                TXTTOTALWITHGST.Text = Format(Val(TXTSUBTOTAL.Text.Trim), "0.00")
                If CHKTCS.CheckState = CheckState.Checked And CHKMANUALTCS.CheckState = CheckState.Unchecked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")

                If CHKMANUALROUND.Checked = False Then
                    txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTTCSAMT.Text.Trim), "0")
                    TXTROUNDOFF.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTTCSAMT.Text.Trim)), "0.00")
                Else
                    txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(TXTTCSAMT.Text.Trim)) + Val(TXTROUNDOFF.Text.Trim), "0.00")
                End If
            End If

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then
                If lbllocked.Visible = True Then
                    MsgBox("Invoice Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'CHECKING WHETHER CFORM OR ANY OTHER FORM HAS BEEN RECD OR NOT, IF RECD THEN LOCK IT, CHECK IN CFORMVIEW WITH THIS INVOICENO
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("FORMNO", "", " CFORMVIEW ", " AND BILL = " & TEMPBILLNO & " AND REGTYPE = '" & TEMPREGNAME & "' AND TYPE = 'PURCHASE' AND FORMNO <> '' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Form Recd, Delete Form First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date < PURBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(PURBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If


                Dim intresult As Integer
                Dim objcls As New ClsPurchaseMaster()
                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPBILLNO)
                    alParaval.Add(TEMPREGNAME)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)
                    objcls.alParaval = alParaval
                    intresult = objcls.DELETE()
                    MsgBox("Purchase Invoice Delete Successfully")
                    clear()
                    EDIT = False

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO > 1 Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTBILLNO.Text.Trim
            clear()
            If Val(TXTBILLNO.Text) - 1 >= TEMPBILLNO Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO < MAXNO Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
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

            Dim objINVDTLS As New PurchaseInvoiceDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            '  Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, isnull(LEDGERS.ACC_CRDAYS,0) AS CRDAYS , isnull(LEDGERS.ACC_DISC,0) AS DISC, isnull(LEDGERS.ACC_CDPER,0) AS CDPER, isnull(LEDGERS.ACC_AGENTCOMM,0) AS AGENTCOMM, isnull(LEDGERS.ACC_RCM,0) AS RCM", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)


                If DT.Rows.Count > 0 Then
                    If CMBTRANSPORT.Text = "" Then CMBTRANSPORT.Text = DT.Rows(0).Item("TRANSNAME")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                    If EDIT = False Then CHKRCM.Checked = Convert.ToBoolean(DT.Rows(0).Item("RCM"))

                    If Val(TXTCRDAYS.Text.Trim) = 0 Then
                        If Val(DT.Rows(0).Item("CRDAYS")) > 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item("CRDAYS"))
                        If Val(TXTCRDAYS.Text) > 0 And DTPARTYBILLDATE.Text <> "__/__/____" Then Call TXTCRDAYS_Validated(sender, e)
                    End If

                    If CMBSCREENTYPE.Text = "LINE GST" And (ClientName = "CC" Or ClientName = "KOTHARI") Then
                        TXTDISCPER.Text = Val(DT.Rows(0).Item("DISC"))
                        TXTSPDISCPER.Text = Val(DT.Rows(0).Item("CDPER"))
                    End If


                    If (ClientName = "SAKARIA" Or ClientName = "SBA" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "SOFTAS" Or ClientName = "YASHVI") And Val(DT.Rows(0).Item("DISC")) > 0 Then
                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "DISCOUNT RECD" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("DISC")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "DISCOUNT RECD", Val(DT.Rows(0).Item("DISC")) * -1, Format((Val(DT.Rows(0).Item("DISC")) * Val(txtbillamt.Text.Trim) / 100) * -1, "0.00"), 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "CASH DISCOUNT" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("CDPER")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "CASH DISCOUNT", Val(DT.Rows(0).Item("CDPER")) * -1, 0, 0)


                        If ClientName = "SBA" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "YASHVI" Then
                            For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                                If DTROW.Cells(ECHARGES.Index).Value = "BROKERAGE" Then GoTo LINE1
                            Next
                            GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "BROKERAGE", Val(DT.Rows(0).Item("AGENTCOMM")) * -1, 0, 0)
                        End If
                        TOTAL()
                    End If

LINE1:

                    If ClientName = "NVAHAN" AndAlso Val(DT.Rows(0).Item("DISC")) > 0 And Val(TXTFOOTERDISC.Text.Trim) = 0 And EDIT = False Then
                        TXTFOOTERDISC.Text = Val(DT.Rows(0).Item("DISC"))
                        TXTFOOTERDISCAMT.Text = Format((Val(DT.Rows(0).Item("DISC")) * Val(txtbillamt.Text.Trim) / 100), "0.00")
                        total()
                    End If


                    If DT.Rows(0).Item("REGISTERNAME") <> cmbregister.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
                        Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then
                            cmbregister.Text = DT.Rows(0).Item("REGISTERNAME")
                            getmax_BILL_no()
                        End If
                    End If
                End If

                'GET TDSAPPLICABLE
                DT = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TDSPER")) > 0 Then CHKTDS.CheckState = CheckState.Checked
                End If

                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub cmdselectgrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTGRN.Click
        Try
            If cmbname.Text.Trim = "" And ClientName <> "YASHVI" Then
                MsgBox("Please Select Party Name First")
                cmbname.Focus()
                Exit Sub
            End If

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Dim OBJGRN As New SelectGRNforPurchase
            OBJGRN.ENQname = cmbname.Text.Trim
            Dim DT As DataTable = OBJGRN.DT
            OBJGRN.ShowDialog()

            Dim PER As String = "Mtrs"
            If ClientName = "JITUBHAI" Or ClientName = "MOMAI" Then PER = "Qty"
            Dim CHKMTRS As Double = 0

            Dim CGSTPER As Double = 0
            Dim SGSTPER As Double = 0
            Dim IGSTPER As Double = 0
            Dim HSNCODE As String = ""

            If DT.Rows.Count > 0 Then


                ''  GETTING DISTINCT SRNO NO 
                Dim TEMPSRNO As String = ""
                Dim DV As DataView = DT.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SRNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TEMPSRNO.Trim = "" Then
                        TEMPSRNO = DTR("SRNO").ToString
                    Else
                        TEMPSRNO = TEMPSRNO & "," & DTR("SRNO").ToString
                    End If
                Next

                Dim objclscmn As New ClsCommon()
                Dim DT1 As New DataTable
                If DT.Rows(0).Item("TYPE") = "MATREC" Then
                    If ClientName = "AVIS" Or ClientName = "YASHVI" Or ClientName = "KOTHARI" Then
                        DT1 = objclscmn.search(" MATERIALRECEIPT.MATREC_NO AS SRNO, 0 AS GRIDSRNO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME,'') AS COLOR, SUM(MATERIALRECEIPT_DESC.MATREC_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS) AS MTRS, 'MATREC' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, '') AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') AS LRNO ", "", " MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON MATERIALRECEIPT_DESC.MATREC_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON MATERIALRECEIPT_DESC.MATREC_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND MaterialReceipt.MATREC_DONE = 0 AND MaterialReceipt.MATREC_NO IN (" & TEMPSRNO & ") AND  MaterialReceipt.MATREC_YEARID = " & YearId & " GROUP BY MATERIALRECEIPT.MATREC_NO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_NAME,''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') ")

                        'REMOVE BALENO
                    ElseIf ClientName = "PARAS" Then
                        DT1 = objclscmn.search(" MATERIALRECEIPT.MATREC_NO AS SRNO, 0 AS GRIDSRNO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, '' AS DESIGNNO, '' AS COLOR, SUM(MATERIALRECEIPT_DESC.MATREC_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS) AS MTRS, 'MATREC' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , '' AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') AS LRNO ", "", " MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND MaterialReceipt.MATREC_DONE = 0 AND MaterialReceipt.MATREC_NO IN (" & TEMPSRNO & ") AND  MaterialReceipt.MATREC_YEARID = " & YearId & " GROUP BY MATERIALRECEIPT.MATREC_NO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') ")
                    Else
                        DT1 = objclscmn.search(" MATERIALRECEIPT.MATREC_NO AS SRNO, 0 AS GRIDSRNO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, '' AS DESIGNNO, '' AS COLOR, SUM(MATERIALRECEIPT_DESC.MATREC_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS) AS MTRS, 'MATREC' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, '') AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') AS LRNO ", "", " MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND MaterialReceipt.MATREC_DONE = 0 AND MaterialReceipt.MATREC_NO IN (" & TEMPSRNO & ") AND  MaterialReceipt.MATREC_YEARID = " & YearId & " GROUP BY MATERIALRECEIPT.MATREC_NO, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') ")
                    End If
                    If DT1.Rows.Count > 0 Then
                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("LOTNO")

                        For Each dr As DataRow In DT1.Rows
                            If dr("ITEMNAME").ToString <> "" And Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then

                                'GET CHKMTRS WITH RESPECT TO ITEM
                                Dim TEMPMTRS As DataTable = objclscmn.search("ISNULL(SUM(CHECK_CHECKEDMTRS),0) AS CHKMTRS", "", "INHOUSECHECKING_DESC INNER JOIN INHOUSECHECKING ON INHOUSECHECKING.CHECK_NO = INHOUSECHECKING_DESC.CHECK_NO AND INHOUSECHECKING.CHECK_YEARID = INHOUSECHECKING_DESC.CHECK_YEARID INNER JOIN ITEMMASTER ON ITEM_ID = INHOUSECHECKING_DESC.CHECK_ITEMID LEFT OUTER JOIN QUALITYMASTER ON QUALITY_ID = INHOUSECHECKING_DESC.CHECK_QUALITYID LEFT OUTER JOIN COLORMASTER ON INHOUSECHECKING_DESC.CHECK_COLORID = COLORMASTER.COLOR_ID", " AND CHECK_TYPE = 'MATREC' AND CHECK_MATRECNO = " & Val(dr("SRNO")) & " AND ISNULL(ITEMMASTER.ITEM_NAME,'') = '" & dr("ITEMNAME") & "' AND INHOUSECHECKING.CHECK_YEARID = " & YearId)
                                If TEMPMTRS.Rows.Count > 0 Then CHKMTRS = TEMPMTRS.Rows(0).Item("CHKMTRS") Else CHKMTRS = 0


                                HSNCODE = dr("HSNCODE")
                                Dim DTHSN As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")

                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If

                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " And HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    HSNCODE = TXTSACCODE.Text.Trim
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If
                                If HSNCODE = "" Then HSNCODE = dr("HSNCODE")
                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = CGSTPER
                                        TXTSGSTPER1.Text = SGSTPER
                                        TXTIGSTPER1.Text = 0
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = 0
                                        TXTSGSTPER1.Text = 0
                                        TXTIGSTPER1.Text = IGSTPER
                                    End If

                                End If

                            Else
                                GRIDBILL.Rows.Add(0, dr("ITEMNAME"), "", dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                            End If
                        Next
                    End If

                ElseIf DT.Rows(0).item("TYPE") = "JOBIN" Then
                    If ClientName = "AVIS" Then
                        DT1 = objclscmn.search(" JOBIN.JI_NO AS SRNO, 0 AS GRIDSRNO, 0 AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGN_NO,'') AS DESIGNNO, ISNULL(COLOR_NAME,'') AS COLOR, SUM(JOBIN_DESC.JI_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(JOBIN_DESC.JI_MTRS) AS MTRS, 'JOBIN' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , ISNULL(JOBIN_DESC.JI_BALENO, '') AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(JOBIN.JI_LRNO, '') AS LRNO, 0 AS RATE ", "", " JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id INNER JOIN JOBIN_DESC ON JOBIN.JI_NO = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBIN.JI_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_ID LEFT OUTER JOIN COLORMASTER ON JOBIN_DESC.JI_COLORID = COLORMASTER.COLOR_ID", " AND JOBIN.JI_DONE = 0 AND JOBIN.JI_NO IN (" & TEMPSRNO & ") AND  JOBIN.JI_YEARID = " & YearId & "  GROUP BY JOBIN.JI_NO,  ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(JOBIN_DESC.JI_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(JOBIN.JI_LRNO, '') , ISNULL(DESIGN_NO,''), ISNULL(COLOR_NAME,'')")
                    ElseIf ClientName = "CC" Then
                        DT1 = objclscmn.search(" JOBIN.JI_NO AS SRNO, 0 AS GRIDSRNO, 0 AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGN_NO,'') AS DESIGNNO, '' AS COLOR, SUM(JOBIN_DESC.JI_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(JOBIN_DESC.JI_MTRS) AS MTRS, 'JOBIN' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , ISNULL(JOBIN_DESC.JI_BALENO, '') AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(JOBIN.JI_LRNO, '') AS LRNO, ISNULL(JOBIN_DESC.JI_RATE,0) AS RATE ", "", " JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id INNER JOIN JOBIN_DESC ON JOBIN.JI_NO = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBIN.JI_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_ID ", " AND JOBIN.JI_DONE = 0 AND JOBIN.JI_NO IN (" & TEMPSRNO & ") AND  JOBIN.JI_YEARID = " & YearId & "  GROUP BY JOBIN.JI_NO,  ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(JOBIN_DESC.JI_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(JOBIN.JI_LRNO, '') , ISNULL(DESIGN_NO,''),  ISNULL(JOBIN_DESC.JI_RATE,0)")
                    Else
                        DT1 = objclscmn.search(" JOBIN.JI_NO AS SRNO, 0 AS GRIDSRNO, 0 AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, '' AS DESIGNNO, '' AS COLOR, SUM(JOBIN_DESC.JI_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(JOBIN_DESC.JI_MTRS) AS MTRS, 'JOBIN' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER , ISNULL(JOBIN_DESC.JI_BALENO, '') AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(JOBIN.JI_LRNO, '') AS LRNO, 0 AS RATE ", "", " JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id INNER JOIN JOBIN_DESC ON JOBIN.JI_NO = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBIN.JI_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND JOBIN.JI_DONE = 0 AND JOBIN.JI_NO IN (" & TEMPSRNO & ") AND  JOBIN.JI_YEARID = " & YearId & "  GROUP BY JOBIN.JI_NO,  ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0), ISNULL(JOBIN_DESC.JI_BALENO, ''),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(JOBIN.JI_LRNO, '') ")
                    End If
                    If DT1.Rows.Count > 0 Then
                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("LOTNO")
                        Dim RATE As Double = 0.0


                        For Each dr As DataRow In DT1.Rows
                            If dr("ITEMNAME").ToString <> "" And Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then

                                CHKMTRS = 0
                                If ClientName = "CC" Then RATE = Val(dr("RATE"))

                                HSNCODE = dr("HSNCODE")
                                Dim DTHSN As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")

                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If

                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " And HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    HSNCODE = TXTSACCODE.Text.Trim
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If

                                If HSNCODE = "" Then HSNCODE = dr("HSNCODE")
                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), RATE, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), RATE, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), RATE, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = CGSTPER
                                        TXTSGSTPER1.Text = SGSTPER
                                        TXTIGSTPER1.Text = 0
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), RATE, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = 0
                                        TXTSGSTPER1.Text = 0
                                        TXTIGSTPER1.Text = IGSTPER
                                    End If

                                End If

                            Else
                                GRIDBILL.Rows.Add(0, dr("ITEMNAME"), "", dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), RATE, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                            End If
                        Next
                    End If

                ElseIf DT.Rows(0).Item("TYPE") = "GREY" Then
                    DT1 = objclscmn.search("GREYRECDKNITTING.GREY_NO AS SRNO, 0 AS GRIDSRNO,0 AS LOTNO, GREYRECDKNITTING.GREY_challanno AS CHALLANNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, '' AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, GREYRECDKNITTING_DESC.GREY_QTY AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, GREYRECDKNITTING_DESC.GREY_WT AS MTRS, 0 AS RATE, 'GREY' AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER,'' AS BALENO , ISNULL(LEDGERS_1.Acc_cmpname, '') AS TRANSNAME, ISNULL(GREYRECDKNITTING.GREY_LRNO, '') AS LRNO ", "", " GREYRECDKNITTING INNER JOIN LEDGERS ON GREYRECDKNITTING.GREY_LEDGERID = LEDGERS.Acc_id INNER JOIN GREYRECDKNITTING_DESC ON GREYRECDKNITTING.GREY_NO = GREYRECDKNITTING_DESC.GREY_NO AND GREYRECDKNITTING.GREY_yearid = GREYRECDKNITTING_DESC.GREY_YEARID LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON GREYRECDKNITTING.GREY_transledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN UNITMASTER ON GREYRECDKNITTING_DESC.GREY_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON GREYRECDKNITTING_DESC.GREY_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON GREYRECDKNITTING_DESC.GREY_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER ON GREYRECDKNITTING_DESC.GREY_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND GREYRECDKNITTING.Grey_DONE = 0 AND GREYRECDKNITTING.GREY_NO IN (" & TEMPSRNO & ")  AND GREYRECDKNITTING.GREY_YEARID = " & YearId)
                    If DT1.Rows.Count > 0 Then
                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("LOTNO")
                        txtlrno.Text = DT1.Rows(0).Item("LRNO")
                        CMBTRANSPORT.Text = DT1.Rows(0).Item("TRANSNAME")
                        For Each dr As DataRow In DT1.Rows
                            If dr("ITEMNAME").ToString <> "" And Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then

                                HSNCODE = dr("HSNCODE")
                                Dim DTHSN As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")

                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If

                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " AND HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    HSNCODE = TXTSACCODE.Text.Trim
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If

                                If HSNCODE = "" Then HSNCODE = dr("HSNCODE")
                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = CGSTPER
                                        TXTSGSTPER1.Text = SGSTPER
                                        TXTIGSTPER1.Text = 0
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), HSNCODE, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                        TXTCGSTPER1.Text = 0
                                        TXTSGSTPER1.Text = 0
                                        TXTIGSTPER1.Text = IGSTPER
                                    End If

                                End If

                            Else
                                GRIDBILL.Rows.Add(0, dr("ITEMNAME"), "", dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                            End If
                        Next
                    End If


                ElseIf DT.Rows(0).Item("TYPE") = "YARNRECD" Then
                    DT1 = objclscmn.search("YARNRECD.YARN_no AS SRNO, 0 AS GRIDSRNO, ISNULL(YARNRECD_DESC.YARN_GRIDLOTNO, '') AS LOTNO, ISNULL(YARNRECD.YARN_challanno, '') AS CHALLANNO, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS ITEMNAME, '' AS QUALITY, '' AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(YARNRECD_DESC.YARN_QTY) AS QTY, 'Bags' AS UNIT, SUM(YARNRECD_DESC.YARN_WT) AS MTRS, 0 AS RATE, 'YARNRECD' AS GRIDTYPE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, '' AS BALENO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNRECD_DESC.YARN_LRNO, '') AS LRNO ", "", " YARNRECD INNER JOIN LEDGERS ON YARNRECD.YARN_ledgerid = LEDGERS.Acc_id INNER JOIN YARNRECD_DESC ON YARNRECD.YARN_no = YARNRECD_DESC.YARN_NO AND YARNRECD.YARN_yearid = YARNRECD_DESC.YARN_YEARID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNRECD.YARN_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN YARNQUALITYMASTER ON YARNRECD_DESC.YARN_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN COLORMASTER ON YARNRECD_DESC.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID ", " AND YARNRECD.YARN_DONE = 0 AND YARNRECD.YARN_NO IN (" & TEMPSRNO & ")  AND YARNRECD.YARN_YEARID = " & YearId & " GROUP BY YARNRECD.YARN_no, ISNULL(YARNRECD.YARN_challanno, ''), ISNULL(YARNQUALITYMASTER.YARN_NAME, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(HSNMASTER.HSN_CODE, ''), ISNULL(HSNMASTER.HSN_CGST, 0), ISNULL(HSNMASTER.HSN_SGST, 0), ISNULL(HSNMASTER.HSN_IGST, 0), ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(YARNRECD_DESC.YARN_LRNO, ''), ISNULL(YARNRECD_DESC.YARN_GRIDLOTNO, '')")
                    If DT1.Rows.Count > 0 Then

                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("CHALLANNO")
                        txtlrno.Text = DT1.Rows(0).Item("LRNO")
                        CMBTRANSPORT.Text = DT1.Rows(0).Item("TRANSNAME")

                        Dim DTHSN As New DataTable

                        For Each dr As DataRow In DT1.Rows
                            If dr("ITEMNAME").ToString <> "" Then

                                'ADD YARNQUALITY IN ITEMMASTER IF NOT PRESENT
                                Dim OBJCMN As New ClsCommon
                                Dim DTITEM = OBJCMN.search("ITEM_ID AS ITEMID", "", " ITEMMASTER ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                                If DTITEM.Rows.Count = 0 Then

                                    'ADD NEW ITEMNAME 
                                    Dim ALPARAVAL As New ArrayList
                                    ALPARAVAL.Clear()


                                    ALPARAVAL.Add("Finished Goods")

                                    Dim DTCATEGORY As DataTable = OBJCMN.search("ISNULL(CATEGORY_NAME, '') AS CATEGORY", "", " CATEGORYMASTER INNER JOIN YARNQUALITYMASTER ON YARNQUALITYMASTER.YARN_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " AND YARNQUALITYMASTER.YARN_NAME = '" & dr("ITEMNAME") & "' AND CATEGORY_YEARID = " & YearId)
                                    If DTCATEGORY.Rows.Count > 0 Then ALPARAVAL.Add(DTCATEGORY.Rows(0).Item("CATEGORY")) Else ALPARAVAL.Add("") 'CATEGORY

                                    ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'DISPLAYNAME
                                    ALPARAVAL.Add(UCase(dr("ITEMNAME"))) 'ITEMNAME

                                    ALPARAVAL.Add("")   'DEPARTMENT
                                    ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'CODE
                                    ALPARAVAL.Add("")   'UNIT
                                    ALPARAVAL.Add("")   'FOLD
                                    ALPARAVAL.Add(0)    'RATE
                                    ALPARAVAL.Add(0)    'VALUATIONRATE   
                                    ALPARAVAL.Add(0)    'TRANSRATE
                                    ALPARAVAL.Add(0)    'CHCKINGRATE
                                    ALPARAVAL.Add(0)    'PACKINGRATE
                                    ALPARAVAL.Add(0)    'DESIGNRATE
                                    ALPARAVAL.Add(0)    'REORDER
                                    ALPARAVAL.Add(0)    'UPPER
                                    ALPARAVAL.Add(0)    'LOWER

                                    DTHSN = OBJCMN.search("ISNULL(HSN_CODE, '') AS HSNCODE", "", " HSNMASTER INNER JOIN YARNQUALITYMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID", " AND YARNQUALITYMASTER.YARN_NAME = '" & dr("ITEMNAME") & "' AND HSN_YEARID = " & YearId)
                                    If DTHSN.Rows.Count > 0 Then ALPARAVAL.Add(DTHSN.Rows(0).Item("HSNCODE")) Else ALPARAVAL.Add("") 'HSNCODE

                                    ALPARAVAL.Add(0)    'BLOCKED
                                    ALPARAVAL.Add(0)    'HIDEINDESIGN

                                    ALPARAVAL.Add("")    'WIDTH
                                    ALPARAVAL.Add("")    'GREYWIDTH
                                    ALPARAVAL.Add(0)    'SHRINKFROM
                                    ALPARAVAL.Add(0)    'SHRINKTO
                                    ALPARAVAL.Add("")   'SELVEDGE

                                    ALPARAVAL.Add("")   'RATETYPE
                                    ALPARAVAL.Add("")   'RATE

                                    ALPARAVAL.Add("")   'YARNQUALITY
                                    ALPARAVAL.Add("")   'PER


                                    ALPARAVAL.Add("")   'GRIDSRNO
                                    ALPARAVAL.Add("")   'PROCESS

                                    ALPARAVAL.Add("")   'REMARKS
                                    ALPARAVAL.Add("MERCHANT")

                                    ALPARAVAL.Add(DBNull.Value)
                                    ALPARAVAL.Add("")   'WARP
                                    ALPARAVAL.Add("")   'WEFT

                                    ALPARAVAL.Add(CmpId)
                                    ALPARAVAL.Add(Locationid)
                                    ALPARAVAL.Add(Userid)
                                    ALPARAVAL.Add(YearId)
                                    ALPARAVAL.Add(0)

                                    ALPARAVAL.Add("")   'GREYQUALITY
                                    ALPARAVAL.Add("")   'BEAMNAME
                                    ALPARAVAL.Add("")   'ENDS
                                    ALPARAVAL.Add("")   'TL
                                    ALPARAVAL.Add("")   'BEAMWT
                                    ALPARAVAL.Add("")   'MTRS
                                    ALPARAVAL.Add("")   'QUALITY
                                    ALPARAVAL.Add("")   'WTMTRS
                                    ALPARAVAL.Add("")   'REEDSPACE
                                    ALPARAVAL.Add("")   'REED
                                    ALPARAVAL.Add("")   'QUALITYWT


                                    ALPARAVAL.Add("")   'WEFTSRNO
                                    ALPARAVAL.Add("")   'WEFTCHANGE


                                    ALPARAVAL.Add("")   'SRNO
                                    ALPARAVAL.Add("")   'GRIDQUALITY
                                    ALPARAVAL.Add("")   'GRIDSHADE
                                    ALPARAVAL.Add("")   'PICK
                                    ALPARAVAL.Add("")   'GRIDWT
                                    ALPARAVAL.Add("")   'WEFTGRIDSRNO

                                    ALPARAVAL.Add(0.00)   'totalbeamends
                                    ALPARAVAL.Add(0.00)   'TOTTALBEAMWT

                                    ALPARAVAL.Add("")   'BEAMSRNO
                                    ALPARAVAL.Add("")   'BEAMNAME
                                    ALPARAVAL.Add("")   'BEAMENS
                                    ALPARAVAL.Add("")   'BEAMTL
                                    ALPARAVAL.Add("")   'BEAMWT

                                    ALPARAVAL.Add(0.00)   'TOTALPICKS
                                    ALPARAVAL.Add(0.00)   'WEFTTL

                                    Dim objclsItemMaster As New clsItemmaster
                                    objclsItemMaster.alParaval = ALPARAVAL
                                    Dim IntResult As Integer = objclsItemMaster.SAVE()

                                End If


                                DTHSN = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If


                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " AND HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If

                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = CGSTPER
                                    TXTSGSTPER1.Text = SGSTPER
                                    TXTIGSTPER1.Text = IGSTPER
                                End If
                            End If
                        Next
                    End If


                ElseIf DT.Rows(0).Item("TYPE") = "BEAMRECEIVED" Then
                    DT1 = objclscmn.search("BEAMRECEIVEDWARPER.BEAMREC_NO AS SRNO, 0 AS GRIDSRNO, '' AS LOTNO, ISNULL(BEAMRECEIVEDWARPER.BEAMREC_challanno, '') AS CHALLANNO, ISNULL(BEAMMASTER.BEAM_NAME, '') AS ITEMNAME, '' AS QUALITY, '' AS DESIGNNO, '' AS COLOR, SUM(BEAMRECEIVEDWARPER_DESC.BEAMREC_CUT) AS QTY, 'Kgs' AS UNIT, SUM(BEAMRECEIVEDWARPER_DESC.BEAMREC_WT) AS MTRS, 0 AS RATE, 'BEAMRECEIVED' AS GRIDTYPE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, '' AS BALENO, '' AS TRANSNAME, '' AS LRNO ", "", " BEAMRECEIVEDWARPER INNER JOIN LEDGERS ON BEAMRECEIVEDWARPER.BEAMREC_ledgerid = LEDGERS.Acc_id INNER JOIN BEAMRECEIVEDWARPER_DESC ON BEAMRECEIVEDWARPER.BEAMREC_no = BEAMRECEIVEDWARPER_DESC.BEAMREC_NO AND BEAMRECEIVEDWARPER.BEAMREC_yearid = BEAMRECEIVEDWARPER_DESC.BEAMREC_YEARID LEFT OUTER JOIN BEAMMASTER ON BEAMRECEIVEDWARPER_DESC.BEAMREC_BEAMID = BEAMMASTER.BEAM_ID LEFT OUTER JOIN HSNMASTER ON BEAMMASTER.BEAM_HSNCODEID = HSNMASTER.HSN_ID ", " AND BEAMRECEIVEDWARPER.BEAMREC_DONE = 0 AND BEAMRECEIVEDWARPER.BEAMREC_NO IN (" & TEMPSRNO & ")  AND BEAMRECEIVEDWARPER.BEAMREC_YEARID = " & YearId & " GROUP BY BEAMRECEIVEDWARPER.BEAMREC_no, ISNULL(BEAMRECEIVEDWARPER.BEAMREC_challanno, ''), ISNULL(BEAMMASTER.BEAM_NAME, ''), ISNULL(HSNMASTER.HSN_CODE, ''), ISNULL(HSNMASTER.HSN_CGST, 0), ISNULL(HSNMASTER.HSN_SGST, 0), ISNULL(HSNMASTER.HSN_IGST, 0)")
                    If DT1.Rows.Count > 0 Then

                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("CHALLANNO")
                        txtlrno.Text = DT1.Rows(0).Item("LRNO")
                        CMBTRANSPORT.Text = DT1.Rows(0).Item("TRANSNAME")

                        Dim DTHSN As New DataTable

                        For Each dr As DataRow In DT1.Rows
                            If dr("ITEMNAME").ToString <> "" Then

                                'ADD YARNQUALITY IN ITEMMASTER IF NOT PRESENT
                                Dim OBJCMN As New ClsCommon
                                Dim DTITEM = OBJCMN.search("ITEM_ID AS ITEMID", "", " ITEMMASTER ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                                If DTITEM.Rows.Count = 0 Then

                                    'ADD NEW ITEMNAME 
                                    Dim ALPARAVAL As New ArrayList
                                    ALPARAVAL.Clear()


                                    ALPARAVAL.Add("Finished Goods")

                                    ALPARAVAL.Add("") 'CATEGORY
                                    ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'DISPLAYNAME
                                    ALPARAVAL.Add(UCase(dr("ITEMNAME"))) 'ITEMNAME

                                    ALPARAVAL.Add("")   'DEPARTMENT
                                    ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'CODE
                                    ALPARAVAL.Add("")   'UNIT
                                    ALPARAVAL.Add("")   'FOLD
                                    ALPARAVAL.Add(0)    'RATE
                                    ALPARAVAL.Add(0)    'VALUATIONRATE   
                                    ALPARAVAL.Add(0)    'TRANSRATE
                                    ALPARAVAL.Add(0)    'CHCKINGRATE
                                    ALPARAVAL.Add(0)    'PACKINGRATE
                                    ALPARAVAL.Add(0)    'DESIGNRATE
                                    ALPARAVAL.Add(0)    'REORDER
                                    ALPARAVAL.Add(0)    'UPPER
                                    ALPARAVAL.Add(0)    'LOWER

                                    DTHSN = OBJCMN.search("ISNULL(HSN_CODE, '') AS HSNCODE", "", " HSNMASTER INNER JOIN YARNQUALITYMASTER ON YARNQUALITYMASTER.YARN_HSNCODEID = HSNMASTER.HSN_ID", " AND YARNQUALITYMASTER.YARN_NAME = '" & dr("ITEMNAME") & "' AND HSN_YEARID = " & YearId)
                                    If DTHSN.Rows.Count > 0 Then ALPARAVAL.Add(DTHSN.Rows(0).Item("HSNCODE")) Else ALPARAVAL.Add("") 'HSNCODE

                                    ALPARAVAL.Add(0)    'BLOCKED
                                    ALPARAVAL.Add(0)    'HIDEINDESIGN

                                    ALPARAVAL.Add("")    'WIDTH
                                    ALPARAVAL.Add("")    'GREYWIDTH
                                    ALPARAVAL.Add(0)    'SHRINKFROM
                                    ALPARAVAL.Add(0)    'SHRINKTO
                                    ALPARAVAL.Add("")   'SELVEDGE

                                    ALPARAVAL.Add("")   'RATETYPE
                                    ALPARAVAL.Add("")   'RATE

                                    ALPARAVAL.Add("")   'YARNQUALITY
                                    ALPARAVAL.Add("")   'PER


                                    ALPARAVAL.Add("")   'GRIDSRNO
                                    ALPARAVAL.Add("")   'PROCESS

                                    ALPARAVAL.Add("")   'REMARKS
                                    ALPARAVAL.Add("MERCHANT")

                                    ALPARAVAL.Add(DBNull.Value)
                                    ALPARAVAL.Add("")   'WARP
                                    ALPARAVAL.Add("")   'WEFT

                                    ALPARAVAL.Add(CmpId)
                                    ALPARAVAL.Add(Locationid)
                                    ALPARAVAL.Add(Userid)
                                    ALPARAVAL.Add(YearId)
                                    ALPARAVAL.Add(0)

                                    ALPARAVAL.Add("")   'GREYQUALITY
                                    ALPARAVAL.Add("")   'BEAMNAME
                                    ALPARAVAL.Add("")   'ENDS
                                    ALPARAVAL.Add("")   'TL
                                    ALPARAVAL.Add("")   'BEAMWT
                                    ALPARAVAL.Add("")   'MTRS
                                    ALPARAVAL.Add("")   'QUALITY
                                    ALPARAVAL.Add("")   'WTMTRS
                                    ALPARAVAL.Add("")   'REEDSPACE
                                    ALPARAVAL.Add("")   'REED
                                    ALPARAVAL.Add("")   'QUALITYWT


                                    ALPARAVAL.Add("")   'WEFTSRNO
                                    ALPARAVAL.Add("")   'WEFTCHANGE


                                    ALPARAVAL.Add("")   'SRNO
                                    ALPARAVAL.Add("")   'GRIDQUALITY
                                    ALPARAVAL.Add("")   'GRIDSHADE
                                    ALPARAVAL.Add("")   'PICK
                                    ALPARAVAL.Add("")   'GRIDWT
                                    ALPARAVAL.Add("")   'WEFTGRIDSRNO

                                    ALPARAVAL.Add(0.00)   'totalbeamends
                                    ALPARAVAL.Add(0.00)   'TOTTALBEAMWT

                                    ALPARAVAL.Add("")   'BEAMSRNO
                                    ALPARAVAL.Add("")   'BEAMNAME
                                    ALPARAVAL.Add("")   'BEAMENS
                                    ALPARAVAL.Add("")   'BEAMTL
                                    ALPARAVAL.Add("")   'BEAMWT

                                    ALPARAVAL.Add(0.00)   'TOTALPICKS
                                    ALPARAVAL.Add(0.00)   'WEFTTL

                                    Dim objclsItemMaster As New clsItemmaster
                                    objclsItemMaster.alParaval = ALPARAVAL
                                    Dim IntResult As Integer = objclsItemMaster.SAVE()

                                End If


                                DTHSN = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If


                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " AND HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If

                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = CGSTPER
                                    TXTSGSTPER1.Text = SGSTPER
                                    TXTIGSTPER1.Text = IGSTPER
                                End If
                            End If
                        Next
                    End If


                Else

                    'CC NEEDS ALL THE DETAILS FROM GRN SO DO NOT SUM THE DETAISL FOR CC
                    DT1 = objclscmn.search(" GRN.GRN_NO AS SRNO, 0 AS GRIDSRNO, GRN.GRN_CHALLANNO AS CHALLANNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(GRN_DESC.GRN_QTY) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, SUM(GRN_DESC.GRN_MTRS) AS MTRS, ISNULL(GRN_DESC.GRN_PURRATE,0) AS RATE, GRN_DESC.GRN_GRIDTYPE AS GRIDTYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER,  '' AS BALENO,ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(GRN.grn_lrno, '') AS LRNO, ISNULL(GRN.GRN_PLOTNO, 0) AS LOTNO, ISNULL(DYEINGLEDGERS.Acc_cmpname, '') AS DYEINGNAME ", "", " GRN INNER JOIN LEDGERS ON GRN.GRN_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON GRN_DESC.GRN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id  LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GRN.grn_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID LEFT OUTER JOIN LEDGERS AS DYEINGLEDGERS ON GRN.grn_toledgerid = DYEINGLEDGERS.Acc_id ", " AND GRN.GRN_DONE = 0 AND GRN.GRN_NO IN (" & TEMPSRNO & ") AND GRN.GRN_TYPE= '" & DT.Rows(0).Item("TYPE") & "' AND GRN.GRN_YEARID = " & YearId & " GROUP BY GRN.GRN_NO, GRN.GRN_CHALLANNO, ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(UNITMASTER.unit_abbr, ''), ISNULL(GRN_DESC.GRN_PURRATE,0), GRN_DESC.GRN_GRIDTYPE, ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0),ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(GRN.GRN_LRNO, ''), ISNULL(GRN.GRN_PLOTNO, 0),  ISNULL(DYEINGLEDGERS.Acc_cmpname, '') ")
                    If DT1.Rows.Count > 0 Then

                        TXTGRNNO.Text = TEMPSRNO
                        TXTCHALLANNO.Text = DT1.Rows(0).Item("CHALLANNO")
                        If ClientName = "MANALI" Then TXTPARTYBILLNO.Text = DT1.Rows(0).Item("CHALLANNO")
                        txtlrno.Text = DT1.Rows(0).Item("LRNO")
                        CMBTRANSPORT.Text = DT1.Rows(0).Item("TRANSNAME")
                        CMBDYEINGNAME.Text = DT1.Rows(0).Item("DYEINGNAME")

                        For Each dr As DataRow In DT1.Rows
                            If ClientName = "CC" Or ClientName = "SHREEDEV" Or ClientName = "MOMAI" Then
                                If dr("UNIT") = "Pcs" Then PER = "Qty"
                            End If


                            'GET CHKMTRS WITH RESPECT TO ITEM 
                            'OPEN THIS ONLY FOR FINISH AS PER SANJAY SIR
                            Dim TEMPMTRS As DataTable = objclscmn.search(" ISNULL (SUM(CHECK_CHECKEDMTRS),0) AS CHKMTRS", "", "INHOUSECHECKING_DESC INNER JOIN INHOUSECHECKING ON INHOUSECHECKING.CHECK_NO = INHOUSECHECKING_DESC.CHECK_NO AND INHOUSECHECKING.CHECK_YEARID = INHOUSECHECKING_DESC.CHECK_YEARID INNER JOIN ITEMMASTER ON ITEM_ID = INHOUSECHECKING_DESC.CHECK_ITEMID LEFT OUTER JOIN QUALITYMASTER ON QUALITY_ID = INHOUSECHECKING_DESC.CHECK_QUALITYID LEFT OUTER JOIN COLORMASTER ON INHOUSECHECKING_DESC.CHECK_COLORID = COLORMASTER.COLOR_ID", " AND CHECK_TYPE = 'GRN' AND CHECK_MATRECNO = " & Val(dr("SRNO")) & " AND ISNULL(ITEMMASTER.ITEM_NAME,'') = '" & dr("ITEMNAME") & "' AND INHOUSECHECKING.CHECK_YEARID = " & YearId)
                            If TEMPMTRS.Rows.Count > 0 Then CHKMTRS = TEMPMTRS.Rows(0).Item("CHKMTRS") Else CHKMTRS = 0

                            If dr("ITEMNAME").ToString <> "" And Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then

                                Dim DTHSN As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                End If


                                'IF JOBCHARGES IS SELECTED THEN GET % OF SELECTED SERVICE
                                If TXTSACCODE.Text.Trim <> "" Then
                                    'Dim DTHSNPER As DataTable = objclscmn.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "HSNMASTER ", " AND HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                                    Dim DTHSNPER As DataTable = objclscmn.search(" TOP 1 ISNULL(HSNMASTER_DESC.HSN_CGST,0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST,0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS IGSTPER", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' And HSNMASTER.HSN_CODE = '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID = " & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                                    CGSTPER = Val(DTHSNPER.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTHSNPER.Rows(0).Item("SGSTPER"))
                                    IGSTPER = Val(DTHSNPER.Rows(0).Item("IGSTPER"))
                                End If

                                If PURCHASESCREENTYPE = "LINE GST" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", CGSTPER, "0.00", SGSTPER, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", IGSTPER, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = 0
                                Else
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", 0, "0.00", 0, "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    Else
                                        GRIDBILL.Rows.Add(0, dr("ITEMNAME"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), Format(Val(dr("RATE")), "0.00"), PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", 0, "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                                    End If
                                    TXTCGSTPER1.Text = CGSTPER
                                    TXTSGSTPER1.Text = SGSTPER
                                    TXTIGSTPER1.Text = IGSTPER
                                End If
                            Else
                                GRIDBILL.Rows.Add(0, dr("ITEMNAME"), "", dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), "", dr("LOTNO"), dr("BALENO"), Format(Val(dr("Qty")), "0.00"), dr("UNIT"), "0.00", Format(Val(dr("MTRS")), "0.00"), Format(Val(CHKMTRS), "0.00"), 0, PER, "0.00", 0, 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", dr("SRNO"), dr("GRIDSRNO"), dr("GRIDTYPE"), 0, 0, 0)
                            End If
                        Next
                    End If
                End If

                TOTAL()
                GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1
                getsrno(GRIDBILL)
                If GRIDBILL.RowCount > 0 Then
                    GRIDBILL.Focus()
                    GRIDBILL.CurrentCell = GRIDBILL.Rows(0).Cells(GRATE.Index)
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmax_BILL_no()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Validated
        Try
            'GET DEFAUKLT SCREENTYPE
            If EDIT = False And cmbregister.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(DTYPE_PURSCREENTYPE,'GOODS PURCHASE') AS SERVICETYPE", "", " DEFAULTPURSCREENTYPE INNER JOIN REGISTERMASTER ON DTYPE_PURREGID = REGISTER_ID ", " AND REGISTER_NAME = '" & cmbregister.Text & "' AND DTYPE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBSERVICETYPE.Text = DT.Rows(0).Item("SERVICETYPE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURREGABBR = dt.Rows(0).Item(0).ToString
                    PURREGINITIAL = dt.Rows(0).Item(1).ToString
                    PURREGID = dt.Rows(0).Item(2)
                    getmax_BILL_no()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridinv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDBILL.CellValidating
        Dim colNum As Integer = GRIDBILL.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GRATE.Index, gQty.Index, GMTRS.Index, GDISCPER.Index, GDISCAMT.Index, GSPDISCPER.Index, GSPDISCAMT.Index, GOTHERAMT.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDBILL.CurrentCell.Value = Nothing Then GRIDBILL.CurrentCell.Value = "0.00"
                    GRIDBILL.CurrentCell.Value = Convert.ToDecimal(GRIDBILL.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
            Case GPER.Index
                total()
        End Select

        If EDIT = False And ClientName = "REAL" Then
            Dim TEMPITEM As String = GRIDBILL.CurrentRow.Cells(gitemname.Index).Value
            Dim TEMPGRNNO As String = GRIDBILL.CurrentRow.Cells(GGRNNO.Index).Value
            For I As Integer = GRIDBILL.CurrentRow.Index + 1 To GRIDBILL.RowCount - 1
                If TEMPITEM = GRIDBILL.Rows(I).Cells(gitemname.Index).Value And TEMPGRNNO = GRIDBILL.Rows(I).Cells(GGRNNO.Index).Value Then
                    GRIDBILL.Item(GRATE.Index, I).Value = GRIDBILL.Item(GRATE.Index, I - 1).EditedFormattedValue
                    GRIDBILL.Item(GPER.Index, I).Value = GRIDBILL.Item(GPER.Index, I - 1).EditedFormattedValue
                End If
            Next
            TOTAL()
        End If
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDBILL.RowCount = 0

                TEMPBILLNO = Val(tstxtbillno.Text)
                TEMPREGNAME = cmbregister.Text.Trim
                If TEMPBILLNO > 0 Then
                    EDIT = True
                    PurchaseMaster_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Sub fillgrid()

        GRIDBILL.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDBILL.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEM.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTDESCRIPTION.Text.Trim, TXTLOTNO.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), 0.0, Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.00"), Format(Val(TXTDISCPER.Text.Trim), "0.00"), Format(Val(TXTDISCAMT.Text.Trim), "0.00"), Format(Val(TXTSPDISCPER.Text.Trim), "0.00"), Format(Val(TXTSPDISCAMT.Text.Trim), "0.00"), Format(Val(TXTOTHERAMT.Text.Trim), "0.00"), Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00"), Format(Val(TXTCGSTPER.Text.Trim), "0.00"), Format(Val(TXTCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTSGSTPER.Text.Trim), "0.00"), Format(Val(TXTSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTIGSTPER.Text.Trim), "0.00"), Format(Val(TXTIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00"), 0, 0, "", 0, 0, 0)
            getsrno(GRIDBILL)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDBILL.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDBILL.Item(gitemname.Index, TEMPROW).Value = CMBITEM.Text.Trim
            GRIDBILL.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim

            GRIDBILL.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDBILL.Item(GDESIGNNO.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDBILL.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDBILL.Item(GDESCRIPTION.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
            GRIDBILL.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDBILL.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim

            GRIDBILL.Item(gQty.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDBILL.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim
            GRIDBILL.Item(GCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")

            GRIDBILL.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDBILL.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBILL.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDBILL.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GDISCPER.Index, TEMPROW).Value = Format(Val(TXTDISCPER.Text.Trim), "0.00")
            GRIDBILL.Item(GDISCAMT.Index, TEMPROW).Value = Format(Val(TXTDISCAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GSPDISCPER.Index, TEMPROW).Value = Format(Val(TXTSPDISCPER.Text.Trim), "0.00")
            GRIDBILL.Item(GSPDISCAMT.Index, TEMPROW).Value = Format(Val(TXTSPDISCAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GOTHERAMT.Index, TEMPROW).Value = Format(Val(TXTOTHERAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GTAXABLEAMT.Index, TEMPROW).Value = Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GCGSTPER.Index, TEMPROW).Value = Format(Val(TXTCGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GCGSTAMT.Index, TEMPROW).Value = Format(Val(TXTCGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GSGSTPER.Index, TEMPROW).Value = Format(Val(TXTSGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GSGSTAMT.Index, TEMPROW).Value = Format(Val(TXTSGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GIGSTPER.Index, TEMPROW).Value = Format(Val(TXTIGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GIGSTAMT.Index, TEMPROW).Value = Format(Val(TXTIGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GGRIDTOTAL.Index, TEMPROW).Value = Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00")


            GRIDDOUBLECLICK = False

        End If
        If ClientName <> "SKF" Then TXTAMT.ReadOnly = True
        total()
        GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

        TXTSRNO.Text = GRIDBILL.RowCount + 1
        TXTDESCRIPTION.Clear()
        TXTQTY.Clear()
        TXTLOTNO.Clear()
        TXTBALENO.Clear()
        TXTCUT.Clear()

        TXTMTRS.Clear()
        TXTRATE.Clear()
        TXTAMT.Clear()
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()
        TXTSPDISCPER.Clear()
        TXTSPDISCAMT.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        If ClientName = "SOFTAS" Then TXTLOTNO.Focus() Else CMBITEM.Focus()

    End Sub

    Sub fillchgsgrid()

        If GRIDCHGSDOUBLECLICK = False Then
            GRIDCHGS.Rows.Add(Val(TXTCHGSSRNO.Text.Trim), CMBCHARGES.Text.Trim, Val(TXTCHGSPER.Text.Trim), Val(TXTCHGSAMT.Text.Trim), Val(TXTTAXID.Text.Trim))
            getsrno(GRIDCHGS)
        ElseIf GRIDCHGSDOUBLECLICK = True Then
            GRIDCHGS.Item(ESRNO.Index, TEMPCHGSROW).Value = Val(TXTCHGSSRNO.Text.Trim)
            GRIDCHGS.Item(ECHARGES.Index, TEMPCHGSROW).Value = CMBCHARGES.Text.Trim
            GRIDCHGS.Item(EPER.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSPER.Text.Trim), "0.00")
            GRIDCHGS.Item(EAMT.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSAMT.Text.Trim), "0.00")
            GRIDCHGS.Item(ETAXID.Index, TEMPCHGSROW).Value = Format(Val(TXTTAXID.Text.Trim))

            GRIDCHGSDOUBLECLICK = False

        End If
        total()
        TXTCHGSPER.ReadOnly = False
        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Text = Val(GRIDCHGS.RowCount - 1) + 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()

        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        CMBCHARGES.Focus()
    End Sub

    'Private Sub TXTAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTAMT.Validated
    '    If ClientName = "SKF" And Val(TXTAMT.Text.Trim) > 0 Then
    '        'GET RATE AUTO IF RATE IS NOT PRESENT
    '        If CMBPER.Text = "Mtrs" Then TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTMTRS.Text.Trim), "0.00") Else TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTQTY.Text.Trim), "0.00")
    '    End If

    '    If CMBITEM.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And CMBPER.Text.Trim <> "" And Val(TXTAMT.Text.Trim) > 0 Then
    '        fillgrid()
    '        total()
    '    Else
    '        If CMBITEM.Text.Trim = "" Then
    '            MsgBox("Please Fill Item Name ")
    '            CMBITEM.Focus()
    '            Exit Sub
    '        End If

    '        If Val(TXTQTY.Text.Trim) = 0 Then
    '            MsgBox("Please Fill Quantity ")
    '            TXTQTY.Focus()
    '            Exit Sub
    '        End If
    '        If CMBQTYUNIT.Text.Trim = "" Then
    '            MsgBox("Please Fill Quantity Unit ")
    '            CMBQTYUNIT.Focus()
    '            Exit Sub
    '        End If
    '        If TXTMTRS.Text.Trim = "" Then
    '            MsgBox("Please Fill Mtrs ")
    '            TXTMTRS.Focus()
    '            Exit Sub
    '        End If
    '        If Val(TXTRATE.Text.Trim) <= 0 Then
    '            MsgBox("Please Fill Rate")
    '            TXTRATE.Focus()
    '            Exit Sub
    '        End If
    '        If CMBPER.Text.Trim = "" Then
    '            MsgBox("Please Fill Per ")
    '            CMBPER.Focus()
    '            Exit Sub
    '        End If

    '    End If

    'End Sub

    Sub EDITROW()
        Try
            If GRIDBILL.CurrentRow.Index >= 0 And GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBITEM.Text = GRIDBILL.Item(gitemname.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDBILL.Item(GHSNCODE.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDBILL.Item(GQUALITY.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDBILL.Item(GDESIGNNO.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDBILL.Item(gcolor.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDBILL.Item(GDESCRIPTION.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDBILL.Item(GLOTNO.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDBILL.Item(GBALENO.Index, GRIDBILL.CurrentRow.Index).Value.ToString

                TXTQTY.Text = Val(GRIDBILL.Item(gQty.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBQTYUNIT.Text = GRIDBILL.Item(gqtyunit.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTCUT.Text = Val(GRIDBILL.Item(GCUT.Index, GRIDBILL.CurrentRow.Index).Value)

                TXTMTRS.Text = Val(GRIDBILL.Item(GMTRS.Index, GRIDBILL.CurrentRow.Index).Value)

                TXTRATE.Text = Val(GRIDBILL.Item(GRATE.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBPER.Text = GRIDBILL.Item(GPER.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTAMT.Text = Val(GRIDBILL.Item(GAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTDISCPER.Text = Val(GRIDBILL.Item(GDISCPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTDISCAMT.Text = Val(GRIDBILL.Item(GDISCAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSPDISCPER.Text = Val(GRIDBILL.Item(GSPDISCPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSPDISCAMT.Text = Val(GRIDBILL.Item(GSPDISCAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTOTHERAMT.Text = Val(GRIDBILL.Item(GOTHERAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTTAXABLEAMT.Text = Val(GRIDBILL.Item(GTAXABLEAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTCGSTPER.Text = Val(GRIDBILL.Item(GCGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTCGSTAMT.Text = Val(GRIDBILL.Item(GCGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSGSTPER.Text = Val(GRIDBILL.Item(GSGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSGSTAMT.Text = Val(GRIDBILL.Item(GSGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)

                TXTIGSTPER.Text = Val(GRIDBILL.Item(GIGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTIGSTAMT.Text = Val(GRIDBILL.Item(GIGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTGRIDTOTAL.Text = Val(GRIDBILL.Item(GGRIDTOTAL.Index, GRIDBILL.CurrentRow.Index).Value)

                TEMPROW = GRIDBILL.CurrentRow.Index
                CMBITEM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub GRIDBILL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDBILL.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDBILL.Rows.RemoveAt(GRIDBILL.CurrentRow.Index)
                getsrno(GRIDBILL)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDBILL.RowCount > 0 Then
                If GRIDBILL.CurrentRow.Cells(gitemname.Index).Value <> "" Then GRIDBILL.Rows.Add(CloneWithValues(GRIDBILL.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated, TXTMTRS.Validated, TXTQTY.Validated, CMBPER.Validated, TXTDISCPER.Validated, TXTDISCAMT.Validated, TXTSPDISCAMT.Validated, TXTSPDISCPER.Validated, TXTOTHERAMT.Validated, TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated, TXTROUNDOFF.Validated, TXTTCSAMT.Validated
        CALC()
        total()
    End Sub

    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        Try
            If CMBITEM.Text.Trim <> "" Then itemvalidate(CMBITEM, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQTYUNIT.Validating
        Try
            If CMBQTYUNIT.Text.Trim <> "" Then unitvalidate(CMBQTYUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTMTRS.KeyPress, TXTRATE.KeyPress, TXTDISCAMT.KeyPress, TXTDISCPER.KeyPress, TXTSPDISCPER.KeyPress, TXTSPDISCAMT.KeyPress, TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTFOOTERDISC.KeyPress, TXTFOOTERDISCAMT.KeyPress, TXTTCSAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.SALEBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDN.Click
        Try
            If (Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" And CMBSERVICETYPE.Text.Trim = "GOODS PURCHASE") Then
                MsgBox("Debit Note Cannot be Raised for This Invoice, Create Purchase Return", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If PBPAID.Visible = True Then
                MsgBox("Pay made, Delete Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME  = '" & cmbregister.Text.Trim & "' AND REGISTER_CMPID = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    OBJdN.BILLNO = DT.Rows(0).Item("INITIALS") & "-" & Val(TXTBILLNO.Text.Trim)
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses'  or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        Try
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                CMBCHARGES.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                getsrno(GRIDCHGS)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress, TXTOTHERAMT.KeyPress, TXTROUNDOFF.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    fillchgsgrid()
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    'TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")

                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                End If
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

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANSPORT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORT.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then cmbtrans.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        Try
            If Val(TXTCRDAYS.Text.Trim) > 0 Then
                If ClientName = "SAKARIA" Then DUEDATE.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), Convert.ToDateTime(BILLDATE.Text).Date) Else DUEDATE.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), Convert.ToDateTime(DTPARTYBILLDATE.Text).Date)
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTs'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBFROMCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBFROMCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTOCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBTOCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEM.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEM.Text = OBJItem.TEMPNAME
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
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then
                'before CALC CHECK HOW TO CALC CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("(CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Then
                    TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "NETT" Then
                    'FIRST CALC NETT THEN ADD CHARGES ON THAT NETT TOTAL
                    TXTNETT.Text = Val(txtbillamt.Text.Trim)
                    For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                        If GRIDCHGSDOUBLECLICK = True And ROW.Index >= TEMPCHGSROW Then Exit For
                        TXTNETT.Text = Format(Val(TXTNETT.Text) + Val(ROW.Cells(EAMT.Index).Value), "0.00")
                    Next
                    TXTCHGSAMT.Text = Format((Val(TXTNETT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalqty.Text) * Val(TXTCHGSPER.Text)), "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "MTRS" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalmtrs.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSPER.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSPER, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSPER.Validating
        Try
            calchgs()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            TXTTAXID.Text = 0
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" ISNULL(tax_tax, 0) as TAX, TAX_ID AS TAXID ", "", " TAXMASTER", " AND tax_name = '" & CMBCHARGES.Text & "'  AND tax_cmpid=" & CmpId & " AND tax_LOCATIONID = " & Locationid & " AND tax_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                TXTCHGSPER.Text = dt.Rows(0).Item("TAX")
                TXTTAXID.Text = Val(dt.Rows(0).Item("TAXID"))
                If ClientName <> "SKF" And Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" Then
                filltax()

                'GET ADDLESS DONE BY GULKIT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_ADDLESS,'ADD') AS ADDLESS , ISNULL(LEDGERS.ACC_DISC,0) AS DISCPER ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("ADDLESS") = "LESS" Then
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then TXTCHGSPER.Text = "-"
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then
                            TXTCHGSPER.Text = "-"
                            If ClientName = "SOFTAS" And Val(DT.Rows(0).Item("DISCPER")) > 0 Then TXTCHGSPER.Text = Val(DT.Rows(0).Item("DISCPER")) * -1
                        End If
                        If Val(TXTCHGSAMT.Text.Trim) = 0 Then TXTCHGSAMT.Text = "-"
                        TXTCHGSPER.Select(TXTCHGSPER.Text.Length, 0)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "PARAS" Then LBLCATEGORY.Visible = True
        CMBSCREENTYPE.Text = PURCHASESCREENTYPE
        TXTBILLNO.TabStop = ALLOWMANUALBILLNO

        'CMBSERVICETYPE.Enabled = True
        'CMBSERVICETYPE.SelectedIndex = 0
        HIDEVIEW()

        If ALLOWBILLCHECKDISPUTE = False Then
            CHKBILLCHECKED.Enabled = False
            CHKBILLDISPUTE.Enabled = False
        End If


        If ClientName = "SVS" Or ClientName = "MSANCHITKUMAR" Then Me.Close()
        If ClientName = "SKF" Then
            gQty.HeaderText = "Qty/Bags"
            GMTRS.HeaderText = "Mtrs/Kgs"
            TXTAMT.ReadOnly = False
        End If
        If ClientName = "SAFFRONOFF" Or ClientName = "SAFFRON" Then GBALENO.HeaderText = "SSF No"
        If ClientName = "SAKARIA" Or ClientName = "NVAHAN" Then
            If ClientName = "NVAHAN" Then
                TXTFOOTERDISC.Visible = True
                TXTFOOTERDISCAMT.Visible = True
            End If
        End If


        If ClientName = "SOFTAS" Then
            CMBTRANSPORT.TabStop = False
            TXTCRDAYS.TabStop = False
            CHKRCM.TabStop = False
            CMBQUALITY.TabStop = False
            TXTDESCRIPTION.TabStop = False
            TXTBALENO.TabStop = False
            TXTCUT.TabStop = False
        End If

        If ClientName = "ALENCOT" Then
            TXTBALENO.BackColor = Color.LemonChiffon
            txtremarks.BackColor = Color.LemonChiffon
        End If

        If ClientName = "SONAL" Then
            CMBQUALITY.TabStop = False
            TXTDESCRIPTION.TabStop = False
            TXTBALENO.TabStop = False
            TXTCUT.TabStop = False
        End If

        If ClientName = "DRDRAPES" Then
            TXTCHKMTRS.ReadOnly = False
        End If

        If ClientName = "DILIP" Then
            CMBQUALITY.TabStop = False
            CMBDESIGN.TabStop = False
            cmbcolor.TabStop = False
            TXTDESCRIPTION.TabStop = False
            TXTLOTNO.TabStop = False
            TXTBALENO.TabStop = False
            TXTCUT.TabStop = False
        End If


        If ClientName = "SOFTAS" Then
            CMBQUALITY.TabStop = False
            CMBDESIGN.TabStop = False
            cmbcolor.TabStop = False
            TXTDESCRIPTION.TabStop = False
            TXTBALENO.TabStop = False
            TXTCUT.TabStop = False
        End If

    End Sub

    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCHARGES.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBCHARGES.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTPARTYBILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPARTYBILLDATE.GotFocus
        DTPARTYBILLDATE.SelectAll()
    End Sub

    Private Sub DTPARTYBILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTPARTYBILLDATE.Validating
        Try
            If DTPARTYBILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTPARTYBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If EDIT = False Then DUEDATE.Value = DTPARTYBILLDATE.Text
                    If ClientName = "MOHATUL" Then
                        BILLDATE.Text = BILLDATE.Text
                        lrdate.Value = Convert.ToDateTime(BILLDATE.Text).Date
                        CHALLANDATE.Value = Convert.ToDateTime(BILLDATE.Text).Date
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BILLDATE.GotFocus
        BILLDATE.SelectAll()
    End Sub

    Private Sub BILLDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BILLDATE.Validating
        Try
            If BILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If Val(TXTCRDAYS.Text) = 0 Then DUEDATE.Text = BILLDATE.Text
                    'SAME DATE FOR CHALLANDATE / LRDATE 
                    If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Or ClientName = "SAFFRONOFF" Or ClientName = "SAFFRON" Or ClientName = "SOFTAS" Then
                        DTPARTYBILLDATE.Text = BILLDATE.Text
                        lrdate.Value = Convert.ToDateTime(BILLDATE.Text).Date
                        CHALLANDATE.Value = Convert.ToDateTime(BILLDATE.Text).Date
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSoftCopy.Image = Nothing
            txtimgpath.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEM.Validated
        Try
            GETHSNCODE()

            'GET CATEGORY
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("isnull(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & CMBITEM.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If

            If ClientName = "MAHAVIR" And CMBITEM.Text.Trim <> "" And EDIT = False Then
                Dim DT1 As DataTable = OBJCMN.search("  ISNULL(item_reorder, 0) AS CUT, ISNULL(ITEM_RATE, 0) AS RATE,ISNULL(ITEM_FOLD, '') AS [DESC],ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", " ITEMMASTER LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id ", " AND ITEMMASTER.item_name = '" & CMBITEM.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID='" & YearId & "' ")
                If DT1.Rows.Count > 0 Then
                    TXTCUT.Text = DT1.Rows(0).Item("CUT")
                    'dont need sale rate in purchase as per sanjay bhai
                    'TXTRATE.Text = DT1.Rows(0).Item("RATE")
                    If DT1.Rows(0).Item("UNIT") = "Pcs" Then
                        CMBPER.Text = "Qty"
                    Else
                        CMBPER.Text = "Mtrs"
                    End If

                    If ClientName = "MAHAVIR" Then TXTDESCRIPTION.Text = DT1.Rows(0).Item("DESC")
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDTOTAL.Validating
        If ClientName = "SKF" And Val(TXTAMT.Text.Trim) > 0 Then
            'GET RATE AUTO IF RATE IS NOT PRESENT
            If CMBPER.Text = "Mtrs" Then TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTMTRS.Text.Trim), "0.00") Else TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTQTY.Text.Trim), "0.00")
        End If

        If ClientName = "ALENCOT" And CMBITEM.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And CMBPER.Text.Trim <> "" And Val(TXTAMT.Text.Trim) > 0 And Val(TXTTAXABLEAMT.Text.Trim) <> 0 And Val(TXTGRIDTOTAL.Text.Trim) <> 0 Then
            fillgrid()
            total()
            If ClientName = "ALENCOT" Then
                If TXTBALENO.Text.Trim = "" Then
                    MsgBox("Please Fill Bale No. ")
                    TXTBALENO.Focus()
                    Exit Sub
                End If
            End If
        ElseIf CMBITEM.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 And CMBPER.Text.Trim <> "" And Val(TXTAMT.Text.Trim) > 0 And Val(TXTTAXABLEAMT.Text.Trim) <> 0 And Val(TXTGRIDTOTAL.Text.Trim) <> 0 Then
            fillgrid()
            total()
        Else
            If CMBITEM.Text.Trim = "" Then
                MsgBox("Please Fill Item Name ")
                CMBITEM.Focus()
                Exit Sub
            End If

            If Val(TXTQTY.Text.Trim) = 0 Then
                MsgBox("Please Fill Quantity ")
                TXTQTY.Focus()
                Exit Sub
            End If
            If CMBQTYUNIT.Text.Trim = "" Then
                MsgBox("Please Fill Quantity Unit ")
                CMBQTYUNIT.Focus()
                Exit Sub
            End If
            If Val(TXTRATE.Text.Trim) <= 0 Then
                MsgBox("Please Fill Rate")
                TXTRATE.Focus()
                Exit Sub
            End If
            If CMBPER.Text.Trim = "" Then
                MsgBox("Please Fill Per ")
                CMBPER.Focus()
                Exit Sub
            End If


        End If

    End Sub

    Sub HIDEVIEW()
        Try
            If CMBSERVICETYPE.Text = "GOODS PURCHASE" Then
                CMBSACDESC.Visible = False
                LBLSACDESC.Visible = False
                LBLSACCODE.Visible = False
                TXTSACCODE.Visible = False
                TXTOTHERAMT.Visible = True
                GOTHERAMT.Visible = True
                LBLTOTALOTHERAMT.Visible = True
            Else
                CMBSACDESC.Visible = True
                LBLSACDESC.Visible = True
                LBLSACCODE.Visible = True
                TXTSACCODE.Visible = True
            End If


            If CMBSCREENTYPE.Text = "LINE GST" Then

                TXTDISCPER.Visible = True
                GDISCPER.Visible = True
                TXTDISCAMT.Visible = True
                GDISCAMT.Visible = True
                LBLTOTALDISCAMT.Visible = True

                TXTSPDISCPER.Visible = True
                GSPDISCPER.Visible = True
                TXTSPDISCAMT.Visible = True
                GSPDISCAMT.Visible = True
                LBLTOTALSPDISCAMT.Visible = True

                TXTOTHERAMT.Visible = True
                GOTHERAMT.Visible = True

                TXTTAXABLEAMT.Visible = True
                GTAXABLEAMT.Visible = True
                LBLTOTALTAXABLEAMT.Visible = True

                TXTCGSTPER.Visible = True
                GCGSTPER.Visible = True

                TXTCGSTAMT.Visible = True
                GCGSTAMT.Visible = True
                LBLTOTALCGSTAMT.Visible = True

                TXTSGSTPER.Visible = True
                GSGSTPER.Visible = True
                TXTSGSTAMT.Visible = True
                GSGSTAMT.Visible = True
                LBLTOTALSGSTAMT.Visible = True

                TXTIGSTPER.Visible = True
                GIGSTPER.Visible = True
                TXTIGSTAMT.Visible = True
                GIGSTAMT.Visible = True
                LBLTOTALIGSTAMT.Visible = True

                TXTGRIDTOTAL.Visible = True
                GGRIDTOTAL.Visible = True

                GRIDBILL.Width = 2175

                LBLCGST.Visible = False
                TXTCGSTPER1.Visible = False
                TXTCGSTAMT1.Visible = False

                LBLSGST.Visible = False
                TXTSGSTPER1.Visible = False
                TXTSGSTAMT1.Visible = False

                LBLIGST.Visible = False
                TXTIGSTPER1.Visible = False
                TXTIGSTAMT1.Visible = False

                TXTAMT.TabStop = False
            Else
                TXTDISCPER.Visible = False
                GDISCPER.Visible = False
                TXTDISCAMT.Visible = False
                GDISCAMT.Visible = False
                LBLTOTALDISCAMT.Visible = False
                TXTSPDISCPER.Visible = False
                GSPDISCPER.Visible = False
                TXTSPDISCAMT.Visible = False
                GSPDISCAMT.Visible = False
                LBLTOTALSPDISCAMT.Visible = False
                TXTOTHERAMT.Visible = False
                GOTHERAMT.Visible = False
                LBLTOTALOTHERAMT.Visible = False
                TXTTAXABLEAMT.Visible = False
                GTAXABLEAMT.Visible = False
                LBLTOTALTAXABLEAMT.Visible = False
                TXTCGSTPER.Visible = False
                GCGSTPER.Visible = False
                TXTCGSTAMT.Visible = False
                GCGSTAMT.Visible = False
                LBLTOTALCGSTAMT.Visible = False
                TXTSGSTPER.Visible = False
                GSGSTPER.Visible = False
                TXTSGSTAMT.Visible = False
                GSGSTAMT.Visible = False
                LBLTOTALSGSTAMT.Visible = False
                TXTIGSTPER.Visible = False
                GIGSTPER.Visible = False
                TXTIGSTAMT.Visible = False
                GIGSTAMT.Visible = False
                LBLTOTALIGSTAMT.Visible = False
                TXTGRIDTOTAL.Visible = False
                GGRIDTOTAL.Visible = False
                GRIDBILL.Width = 1250
                LBLCGST.Visible = True
                TXTCGSTPER1.Visible = True
                TXTCGSTAMT1.Visible = True
                LBLSGST.Visible = True
                TXTSGSTPER1.Visible = True
                TXTSGSTAMT1.Visible = True
                LBLIGST.Visible = True
                TXTIGSTPER1.Visible = True
                TXTIGSTAMT1.Visible = True
                TXTAMT.TabStop = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSERVICETYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSERVICETYPE.Validated
        Try
            HIDEVIEW()
            CMBSERVICETYPE.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon

                TXTCGSTAMT1.ReadOnly = False
                TXTCGSTAMT1.TabStop = True
                TXTCGSTAMT1.BackColor = Color.LemonChiffon
                TXTSGSTAMT1.ReadOnly = False
                TXTSGSTAMT1.TabStop = True
                TXTSGSTAMT1.BackColor = Color.LemonChiffon
                TXTIGSTAMT1.ReadOnly = False
                TXTIGSTAMT1.TabStop = True
                TXTIGSTAMT1.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen

                TXTCGSTAMT1.ReadOnly = True
                TXTCGSTAMT1.TabStop = False
                TXTCGSTAMT1.BackColor = Color.Linen
                TXTSGSTAMT1.ReadOnly = True
                TXTSGSTAMT1.TabStop = False
                TXTSGSTAMT1.BackColor = Color.Linen
                TXTIGSTAMT1.ReadOnly = True
                TXTIGSTAMT1.TabStop = False
                TXTIGSTAMT1.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSACDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Validated
        Try
            If CMBSACDESC.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then TXTSACCODE.Text = DT.Rows(0).Item("HSNCODE")
                CMBSACDESC.Enabled = False
                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALROUND_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALROUND.CheckedChanged
        Try
            If CHKMANUALROUND.Checked = True Then
                TXTROUNDOFF.ReadOnly = False
                TXTROUNDOFF.TabStop = True
            Else
                TXTROUNDOFF.ReadOnly = True
                TXTROUNDOFF.TabStop = False
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try

            If DTPARTYBILLDATE.Text = "__/__/____" Then Exit Sub

            If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If CMBSERVICETYPE.Text = "GOODS PURCHASE" Then
                    'DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & CMBITEM.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                    DT = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & CMBITEM.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                Else
                    'DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSN_CODE= '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                    DT = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND HSNMASTER.HSN_CODE= '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                End If
                If DT.Rows.Count > 0 Then


                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()

                    If CHKMANUAL.CheckState = CheckState.Unchecked Then
                        TXTCGSTPER1.Clear()
                        TXTCGSTAMT1.Clear()
                        TXTSGSTPER1.Clear()
                        TXTSGSTAMT1.Clear()
                        TXTIGSTPER1.Clear()
                        TXTIGSTAMT1.Clear()
                    End If

                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                        If PURCHASESCREENTYPE = "LINE GST" Then
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTIGSTPER.Text = 0
                                TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                                TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                            End If
                        Else
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTIGSTPER1.Text = 0
                                TXTCGSTPER1.Text = Val(DT.Rows(0).Item("CGSTPER"))
                                TXTSGSTPER1.Text = Val(DT.Rows(0).Item("SGSTPER"))
                            Else
                                TXTCGSTPER1.Text = 0
                                TXTSGSTPER1.Text = 0
                                TXTIGSTPER1.Text = Val(DT.Rows(0).Item("IGSTPER"))
                            End If
                        End If
                    End If
                    CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim) * Val(TXTQTY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        If CHKTCS.Checked = False Then
            CHKMANUALTCS.Checked = False
            TXTTCSAMT.Text = 0.0
        End If
        TOTAL()
    End Sub

    Private Sub CHKMANUALTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALTCS.CheckedChanged
        If CHKMANUALTCS.Checked = True Then
            TXTTCSAMT.ReadOnly = False
            TXTTCSAMT.BackColor = Color.LemonChiffon
        Else
            TXTTCSAMT.ReadOnly = True
            TXTTCSAMT.BackColor = Color.Linen
            total()
        End If
    End Sub

    Private Sub CMBSCREENTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSCREENTYPE.Validated
        Try
            HIDEVIEW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CMDSELECTPO.Click
        Try

            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJSELECTPO As New SelectPO
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.FRMSTRING = "GRN FANCY"
            OBJSELECTPO.ShowDialog()
            DTPO = OBJSELECTPO.DT

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTMULTIPONO.Text.Trim = "" Then
                        TXTMULTIPONO.Text = DTR("PONO").ToString
                    Else
                        TXTMULTIPONO.Text = TXTMULTIPONO.Text & "," & DTR("PONO").ToString
                    End If
                Next

                TXTPOGRIDSRNO.Text = DTPO.Rows(0).Item("GRIDSRNO")
                PODATE.Text = DTPO.Rows(0).Item("PODATE")

                DUEDATE.Value = DTPO.Rows(0).Item("DUEDATE")
                TXTMULTIPONO.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    GRIDORDER.Rows.Add(0, DTROW("ITEMNAME"), DTROW("DESIGNNO"), DTROW("COLOR"), Val(DTROW("QTY")), Val(DTROW("MTRS")), DTROW("PONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))
                    'FILL SAME DATA IN BILLGRID
                    'GET HSNCODE
                    Dim HSNCODE As String = ""
                    Dim OBJCMN As New ClsCommon
                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER INNER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", " AND ITEM_NAME = '" & DTROW("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                    If DTHSN.Rows.Count > 0 Then HSNCODE = DTHSN.Rows(0).Item("HSNCODE")
                    GRIDBILL.Rows.Add(0, DTROW("ITEMNAME"), HSNCODE, "", DTROW("DESIGNNO"), DTROW("COLOR"), "", "", "", Val(DTROW("QTY")), "Pcs", 0, Val(DTROW("MTRS")), 0, Val(DTROW("RATE")), "Qty", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
NEXTLINE:
                Next
                getsrno(GRIDORDER)
                getsrno(GRIDBILL)

            End If

            CMDSELECTPO.Enabled = True
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                Call TXTGRIDTOTAL_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        numdot(e, TXTAMT, Me)
    End Sub

    Private Sub TXTCGSTAMT1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT1.Validated, TXTSGSTAMT1.Validated, TXTIGSTAMT1.Validated
        Try
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBILLNO.KeyPress, TXTNOOFBALES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            If ALLOWMANUALBILLNO = True Then
                If (Val(TXTBILLNO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPBILLNO <> Val(TXTBILLNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER.BILL_NO, 0) AS BILLNO", "", " REGISTERMASTER INNER JOIN PURCHASEMASTER ON REGISTERMASTER.register_id = PURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_cmpid = PURCHASEMASTER.BILL_CMPID AND REGISTERMASTER.register_yearid = PURCHASEMASTER.BILL_YEARID AND REGISTERMASTER.register_locationid = PURCHASEMASTER.BILL_LOCATIONID ", "  AND PURCHASEMASTER.BILL_NO=" & TXTBILLNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PURCHASEMASTER.BILL_cmpid = " & CmpId & " AND PURCHASEMASTER.BILL_locationid = " & Locationid & " AND PURCHASEMASTER.BILL_yearid = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        MsgBox("Purchase Invoice No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDAUTOPOST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDAUTOPOST.Click
        Try
            'GET INVOICENOS FROM PURCHASEMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("MAX(BILL_NO) AS BILLNO", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BILL_YEARID = " & YearId)
            For I As Integer = 1 To Val(DT.Rows(0).Item("BILLNO"))
                GRIDBILL.RowCount = 0
                TEMPBILLNO = Val(I)
                TEMPREGNAME = cmbregister.Text.Trim
                EDIT = True
                PurchaseMaster_Load(sender, e)
                If GRIDBILL.RowCount = 0 Then GoTo NEXTLINE
                cmdok_Click(sender, e)
NEXTLINE:
                clear()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFOOTERDISC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFOOTERDISC.Validating, TXTFOOTERDISCAMT.Validating
        total()
    End Sub

    Private Sub CMBDYEINGNAME_Enter(sender As Object, e As EventArgs) Handles CMBDYEINGNAME.Enter
        Try
            If CMBDYEINGNAME.Text.Trim = "" Then fillname(CMBDYEINGNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEINGNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBDYEINGNAME.Validating
        Try
            If CMBDYEINGNAME.Text.Trim <> "" Then namevalidate(CMBDYEINGNAME, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(sender As Object, e As EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me, CMBITEM.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREFNO_Validated(sender As Object, e As EventArgs) Handles TXTREFNO.Validated
        Try
            'FETCH DATA FROM PACKINGSLIP
            If ClientName = "SAKARIA" And EDIT = False And TXTREFNO.Text.Trim <> "" Then
                Dim PER As String = "Mtrs"
                Dim OBJBILL As New ClsPurchaseMaster
                OBJBILL.alParaval.Add(TXTREFNO.Text.Trim)
                OBJBILL.alParaval.Add(AccFrom)
                OBJBILL.alParaval.Add(CmpName)
                Dim DT As DataTable = OBJBILL.PACKINGSLIPDATA()
                GRIDBILL.RowCount = 0
                For Each DR As DataRow In DT.Rows
                    If DR("PER") = "Pcs" Then PER = "Qty"
                    GRIDBILL.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME").ToString, DR("HSNCODE").ToString, DR("QUALITY").ToString, DR("DESIGN"), DR("COLOR"), DR("PRINTDESC"), "", DR("BALENO").ToString, Val(DR("PCS")), DR("QTYUNIT").ToString, Val(DR("CUT")), Val(DR("MTRS")), 0, Val(DR("RATE")), PER, Val(DR("AMOUNT")), 0, 0, 0, 0, 0, 0, Val(DR("CGSTPER")), 0, Val(DR("SGSTPER")), 0, Val(DR("IGSTPER")), 0, Val(DR("AMOUNT")), 0, 0, "", 0, 0, 0)
                    TXTCGSTPER1.Text = Val(DR("CGSTPER"))
                    TXTSGSTPER1.Text = Val(DR("SGSTPER"))
                    TXTIGSTPER1.Text = Val(DR("IGSTPER"))
                Next
                GETHSNCODE()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBILL.CellClick
        Try
            LBLACCEPTEDMTRS.Text = 0
            Dim OBJCMN As New ClsCommon
            Dim TEMPMTRS As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(CHECK_BALMTRS,0) AS MTRS FROM CHECKINGMASTER WHERE CHECK_GRNNO = " & Val(GRIDBILL.CurrentRow.Cells(GGRNNO.Index).Value) & " AND CHECK_LOTNO = '" & GRIDBILL.CurrentRow.Cells(GLOTNO.Index).Value & "' AND CHECK_YEARID = " & YearId, "", "")
            If TEMPMTRS.Rows.Count > 0 Then LBLACCEPTEDMTRS.Text = Val(TEMPMTRS.Rows(0).Item("MTRS"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTPARTYBILLDATE_Validated(sender As Object, e As EventArgs) Handles DTPARTYBILLDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class