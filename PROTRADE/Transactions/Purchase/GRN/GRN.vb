
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class GRN

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDMTRSDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public tempgrnno As Integer     'used for poation no while editing
    Public temptypename, TEMPPARTYBILLNO As String 'used for poation no while editing
    Dim TEMPROW, TEMPMTRSROW As Integer
    Dim TEMPUPLOADROW As Integer
    Public Shared selectPOtable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public FRMSTRING As String
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALGRNNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        TXTFROM.Clear()
        TXTTO.Clear()
        LBLCATEGORY.Text = ""
        EP.Clear()
        GRIDBALESUMM.RowCount = 0
        GRIDORDER.RowCount = 0

        CHK30.CheckState = CheckState.Unchecked
        CHK32.CheckState = CheckState.Unchecked
        CHK34.CheckState = CheckState.Unchecked
        CHK36.CheckState = CheckState.Unchecked
        CHK38.CheckState = CheckState.Unchecked
        CHK40.CheckState = CheckState.Unchecked
        CHK42.CheckState = CheckState.Unchecked
        CHK44.CheckState = CheckState.Unchecked
        CHK46.CheckState = CheckState.Unchecked
        CHK48.CheckState = CheckState.Unchecked
        CHK50.CheckState = CheckState.Unchecked
        CHK52.CheckState = CheckState.Unchecked
        CHK54.CheckState = CheckState.Unchecked
        CHK56.CheckState = CheckState.Unchecked
        CHK58.CheckState = CheckState.Unchecked

        If ALLOWMANUALGRNNO = True Then
            txtgrnno.ReadOnly = False
            txtgrnno.BackColor = Color.LemonChiffon
        Else
            txtgrnno.ReadOnly = True
            txtgrnno.BackColor = Color.Linen
        End If

        cmbname.Enabled = True
        cmbname.Text = ""
        CMBCMPNAME.Text = ""
        TXTCHNO.Clear()
        CMBWEAVER.Text = ""
        CMBBROKER.Text = ""
        CMBSENDER.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        CMBTONAME.Text = ""
        cmbprocess.Text = ""
        TXTLOTNO.Clear()
        txtPartyMtrs.Clear()
        txtPartyMtrs.Clear()
        CHALLANDATE.Text = Now.Date
        txtchallan.Clear()
        txtpono.Clear()
        podate.Value = Now.Date
        If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = (0)
        CHKLOTREADY.CheckState = CheckState.Unchecked

        TXTDMTRS.Clear()
        GRIDMTRS.RowCount = 0
        GBMTRS.Visible = False

        CMBDYEINGTYPE.SelectedIndex = 0

        txtadd.Clear()
        GRNDATE.Text = Now.Date
        RECDATE.Text = Now.Date

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Now.Date
        txttransref.Clear()
        txttransremarks.Clear()

        TXTPARTYBILLNO.Clear()
        PARTYBILLDATE.Value = Now.Date

        txtremarks.Clear()

        txtuploadsrno.Text = 1
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""


        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos
        txtsrno.Text = 1
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        TXTBALENO.Clear()
        CMBQUALITY.Text = ""
        CMBRACK.Text = ""
        CMBSHELF.Text = ""

        cmbcolor.Text = ""
        If ClientName = "MSANCHITKUMAR" Or ClientName = "KEMLINO" Or ClientName = "MOHATUL" Then txtqty.Clear()
        If ClientName = "YASHVI" Or ClientName = "REAL" Then cmbqtyunit.Text = "LUMP" Else cmbqtyunit.Text = ""
        If ClientName = "AVIS" Then cmbqtyunit.Text = "Mtrs"
        If ClientName = "RMANILAL" Or ClientName = "INDRANI" Then cmbqtyunit.Text = "Pcs"
        If ClientName = "MNIKHIL" Then cmbqtyunit.Text = "ROLL"

        TXTCUT.Clear()
        If ClientName = "INDRANI" Then TXTMTRS.Text = 1 Else TXTMTRS.Clear()
        TXTWT.Clear()
        gridgrn.RowCount = 0
        cmbtrans.Text = ""
        txtlrno.Clear()
        TXTPURRATE.Clear()
        TXTSALERATE.Clear()
        TXTWHOLESALERATE.Clear()

        cmdselectPO.Enabled = True
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        If FRMSTRING = "GRN" Then
            cmbtype.Text = "G.R.N"
            txtsrno.Visible = False
            CMBQUALITY.Visible = False
            cmbitemname.Visible = False
            txtgridremarks.Visible = False

            txtqty.Visible = False
            cmbqtyunit.Visible = False
            TXTCUT.Visible = False
            TXTMTRS.Visible = False
            TXTWT.Visible = False
            GRNDATE.Visible = False
            lblgrndate.Visible = False

        ElseIf FRMSTRING = "GRNJOB" Then

            If ClientName = "CC" Or ClientName = "SHREEDEV" Then cmbtype.Text = "FANCY MATERIAL" Else cmbtype.Text = "Job Work"

            If ClientName = "MSANCHITKUMAR" Then
                Me.Text = "Grey Rec Note"
                LBLGRN.Text = "Grey Rec Note"
            End If

        ElseIf FRMSTRING = "GRN FANCY" Then
            cmbtype.Text = "Fancy Material"

            Me.Text = "Finish Inward"
            LBLGRN.Text = "Finish Inward"

            gitemname.HeaderText = "Item Name"
            txtPartyMtrs.Visible = False

        Else
            cmbtype.Text = "Inwards"
            gdesc.Width = 300
            txtgridremarks.Width = 300
            gqtyunit.Width = 120
            cmbitemname.Left = 30
            txtgridremarks.Left = 180
            cmbqtyunit.Width = 120
            TabControl1.Width = 800
            gridgrn.Width = 800
            CMBQUALITY.Visible = False
            TXTMTRS.Visible = False
            txtPartyMtrs.Visible = False
            GQUALITY.Visible = False
            GMTRS.Visible = False
            LBLWEAVER.Visible = False
            CMBWEAVER.Visible = False
            LBLBROKER.Visible = False
            CMBBROKER.Visible = False
            LBLSENDER.Visible = False
            CMBSENDER.Visible = False
            LBLBALES.Visible = False
            LBLTOTALMTRS.Visible = False
            LBLTOTALWT.Visible = False
            TXTTOTALBALES.Visible = False
        End If
        getmaxno()
        HIDEVIEW()

        'If GODOWNNAME <> "HEAD OFFICE" Then
        '    cmbGodown.Enabled = False
        'Else
        '    cmbGodown.Enabled = True
        'End If

        LBLTOTALMTRS.Text = 0
        LBLTOTALMTRS.Text = 0
        TXTTOTALBALES.Clear()
        lbltotalqty.Text = 0
        LBLTOTALWT.Text = 0
        TXTBALEWT.Clear()
        CMBPIECETYPE.Text = "FRESH"

    End Sub

    Sub HIDEVIEW()
        Try
            If FRMSTRING = "GRNJOB" Then
                LBLDYEINGNAME.Visible = True
                CMBTONAME.Visible = True
                LBLLOTNO.Visible = True
                TXTLOTNO.Visible = True
                LBLLOTDATE.Visible = True
                RECDATE.Visible = True
            ElseIf FRMSTRING = "GRN FANCY" Then
                LBLGODOWN.Visible = True
                cmbGodown.Visible = True
                LBLLOTNO.Visible = True
                TXTLOTNO.Visible = True
                LBLBROKER.Visible = True
                CMBBROKER.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            Dim DONE As Boolean = False
            GRIDBALESUMM.RowCount = 0

            For Each ROW As DataGridViewRow In gridgrn.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = Val(ROW.Cells(gQty.Index).EditedFormattedValue) * Val(ROW.Cells(gcut.Index).EditedFormattedValue)
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")

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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        'cmbtype.Enabled = True
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub RECDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RECDATE.GotFocus
        RECDATE.SelectAll()
    End Sub

    Private Sub CHALLANDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHALLANDATE.GotFocus
        CHALLANDATE.SelectAll()
    End Sub

    Private Sub RECDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RECDATE.Validating
        Try
            If RECDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(RECDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRNDATE.GotFocus
        GRNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GRNDATE.Validating
        Try
            If GRNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(GRNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    'SAME DATE FOR CHALLANDATE / LRDATE 
                    If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Then
                        CHALLANDATE.Text = GRNDATE.Text
                        lrdate.Value = Convert.ToDateTime(GRNDATE.Text).Date
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PARTYBILLDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PARTYBILLDATE.Validating
        If Not datecheck(PARTYBILLDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" GRN_NO AS GRNNO", "", " GRN INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id ", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND GRN_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND GRN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("GRNNO"))
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(grn_no),0) + 1 ", "GRN", " AND GRN_TYPE='" & cmbtype.Text & "' AND grn_cmpid=" & CmpId & " and grn_locationid=" & Locationid & " and grn_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtgrnno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If cmbtype.Text.Trim.Length = 0 Then
                EP.SetError(cmbtype, "Enter Register Name")
                bln = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If FRMSTRING = "GRN" Or FRMSTRING = "GRNJOB" Then
                If ClientName <> "AVIS" And ClientName <> "KENCOT" And CMBTONAME.Text.Trim.Length = 0 Then
                    EP.SetError(CMBTONAME, " Please Fill Company Name ")
                    bln = False
                End If
                If ClientName = "SOFTAS" And TXTLOTNO.Text.Trim = "" Then
                    EP.SetError(TXTLOTNO, " Please Enter Lot No")
                    bln = False
                End If
            Else
                If cmbGodown.Text.Trim.Length = 0 Then
                    EP.SetError(cmbGodown, " Please Select Godown")
                    bln = False
                End If
                CMBTONAME.Text = ""
            End If

            If lbllocked.Visible = True And UserName <> "Admin" Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If gridgrn.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            'coz if it it other item type then mtrs will be blank
            'if want to enable then check for materialtype
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            If ClientName <> "CC" And ClientName <> "GELATO" And ClientName <> "MOMAI" And ClientName <> "AXIS" Then
                For Each row As DataGridViewRow In gridgrn.Rows
                    DT = OBJCMN.search("MATERIAL_NAME", "", "  ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id AND ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid ", " AND ITEMMASTER.ITEM_NAME = '" & row.Cells(gitemname.Index).Value & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                    If Val(row.Cells(GMTRS.Index).Value) = 0 And (DT.Rows(0).Item(0) = "Raw Material" Or DT.Rows(0).Item(0) = "Semi Finished Goods" Or DT.Rows(0).Item(0) = "Finished Goods") Then
                        EP.SetError(TabControl1, "MTRS Cannot be kept Blank")
                        bln = False
                    End If
                Next
            End If

            If ALLOWMANUALGRNNO = True Then
                If Val(txtgrnno.Text.Trim) <> 0 And EDIT = False Then
                    Dim OBJCMNn As New ClsCommon
                    Dim dttable As DataTable = OBJCMNn.search(" ISNULL(GRN.GRN_NO,0)  AS GRNNO", "", " GRN ", "  AND GRN.GRN_NO=" & txtgrnno.Text.Trim & " AND GRN.GRN_TYPE = '" & cmbtype.Text.Trim & "' AND GRN.GRN_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("GRN No Already Exist")
                        bln = False
                    End If
                End If
            End If

            If txtchallan.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txtchallan.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    DT = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(txtchallan, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If



            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(OGRNQTY.Index).Value = 0
                    ORDROW.Cells(OGRNMTRS.Index).Value = 0
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

                For Each ROW As DataGridViewRow In gridgrn.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(gitemname.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
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
                            ROW.Cells(GPURRATE.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value) + Val(ROW.Cells(gQty.Index).Value)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value) + Val(ROW.Cells(GMTRS.Index).Value)
                        ROW.Cells(GPURRATE.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen

                        If ClientName = "REAL" Then
                            EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                            bln = False
                        Else
                            If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                bln = False
                            End If
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next
            End If

            If (ClientName = "REAL") And GRIDORDER.RowCount = 0 And CHALLANWITHOUTSO = True Then
                EP.SetError(cmbname, "Please Select Purchase Order")
                bln = False
            End If

            'lock challan for excess of 20% ON EDIT = FALSE 
            If EDIT = False Then
                For Each ROW As DataGridViewRow In GRIDORDER.Rows
                    ROW.DefaultCellStyle.BackColor = Color.Empty
                    'GET TOTAL PO MTRS AND ADD 20% OF THAT MTRS AND SUBTRACT RECD MTRS, THIS WILL GIVE ALLOWED MTRS
                    'IF OGRNMTRS > ALLOWED MTRS THEN VALIDATE
                    Dim ALLOWEDMTRS As Double = 0.0
                    Dim DTPO As DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(MTRS,0) AS MTRS, ISNULL(BALMTRS,0) AS BALMTRS FROM (SELECT PURCHASEORDER_DESC.PO_MTRS AS MTRS, ROUND(PURCHASEORDER_DESC.PO_MTRS - PURCHASEORDER_DESC.PO_RECDMTRS, 2) AS BALMTRS FROM PURCHASEORDER_DESC WHERE PURCHASEORDER_DESC.PO_NO = " & Val(ROW.Cells(OFROMNO.Index).Value) & " AND PURCHASEORDER_DESC.PO_GRIDSRNO = " & Val(ROW.Cells(OFROMSRNO.Index).Value) & " AND '" & ROW.Cells(OFROMTYPE.Index).Value & "' = 'PURCHASEORDER' AND PURCHASEORDER_DESC.PO_YEARID = " & YearId & " UNION ALL SELECT OPENINGPURCHASEORDER_DESC.OPO_MTRS AS MTRS, ROUND(OPENINGPURCHASEORDER_DESC.OPO_MTRS - OPENINGPURCHASEORDER_DESC.OPO_RECDMTRS, 2) AS BALMTRS FROM OPENINGPURCHASEORDER_DESC WHERE OPENINGPURCHASEORDER_DESC.OPO_NO = " & Val(ROW.Cells(OFROMNO.Index).Value) & " AND OPENINGPURCHASEORDER_DESC.OPO_GRIDSRNO = " & Val(ROW.Cells(OFROMSRNO.Index).Value) & " AND '" & ROW.Cells(OFROMTYPE.Index).Value & "' = 'OPENING' AND OPENINGPURCHASEORDER_DESC.OPO_YEARID = " & YearId & ") AS T", "", "")
                    If DTPO.Rows.Count > 0 Then ALLOWEDMTRS = Format(((Val(DTPO.Rows(0).Item("MTRS")) * 20) / 100) + Val(DTPO.Rows(0).Item("BALMTRS")), "0.00")
                    'If Val(ROW.Cells(OGRNMTRS.Index).Value) > 0 And ((Val(ROW.Cells(OGRNMTRS.Index).Value) - Val(ROW.Cells(OMTRS.Index).Value)) / Val(ROW.Cells(OMTRS.Index).Value)) * 100 > 20 Then
                    If Val(ROW.Cells(OGRNMTRS.Index).Value) > ALLOWEDMTRS Then
                        ROW.DefaultCellStyle.BackColor = Color.LightPink
                        EP.SetError(cmbname, "Inward Greater then Allowed Ordered Mtrs")
                        bln = False
                    End If
                Next
            End If


            If FRMSTRING = "GRN FANCY" And txtchallan.Text.Trim = "" And ClientName = "SBA" Then
                EP.SetError(txtchallan, "Enter Challan No.")
                bln = False
            End If


            If FRMSTRING = "GRNJOB" Then
                If RECDATE.Text = "__/__/____" Then
                    EP.SetError(RECDATE, " Please Enter Proper Date")
                    bln = False
                End If
            End If


            If GRNDATE.Text = "__/__/____" Then
                EP.SetError(GRNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(GRNDATE.Text) Then
                    EP.SetError(GRNDATE, "Date not in Accounting Year")
                    bln = False
                End If

                'GRN DATE CANNOT BE LESS THEN PODATE
                If Val(txtpono.Text.Trim) > 0 And Convert.ToDateTime(GRNDATE.Text).Date < podate.Value.Date Then
                    EP.SetError(RECDATE, "Date Cannot be before PO Date")
                    bln = False
                End If
            End If

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'THIS CODE IS OF NO USE, COZ WE HAVE ENTERED BARCODE IN SP
            'If Not CHECKBARCODE() Then
            '    bln = False
            '    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            'End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Function CHECKBARCODE() As Boolean
        Try
            Dim BLN As Boolean = True
            If FRMSTRING = "GRN FANCY" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(GRN_BARCODE,'') AS BARCODE ", "", " GRN_DESC ", " AND GRN_DESC.GRN_YEARID =  " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTR As DataRow In DT.Rows
                        For Each ROW As Windows.Forms.DataGridViewRow In gridgrn.Rows
                            If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                                BLN = False
                                Exit Function
                            End If
                        Next
                    Next
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If

            ' If CMBTONAME.Text.Trim <> "" Then ADDPOUT(TXTPOUTNO)
            Dim alParaval As New ArrayList

            If txtgrnno.ReadOnly = False Then
                alParaval.Add(Val(txtgrnno.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(cmbtype.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(GRNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)
            alParaval.Add(CMBSENDER.Text.Trim)
            alParaval.Add(CMBTONAME.Text.Trim)
            alParaval.Add(TXTPOUTNO.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(RECDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbprocess.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(Format(podate.Value.Date, "MM/dd/yyyy"))

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)

            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)

            alParaval.Add(Val(TXTBALEWT.Text.Trim))

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(TXTTOTALBALES.Text.Trim)

            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))

            alParaval.Add(CMBDYEINGTYPE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(Format(PARTYBILLDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CHKLOTREADY.Checked)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim QUALITY As String = ""
            Dim BALENO As String = ""
            Dim DESIGN As String = ""

            Dim COLOR As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim CUT As String = ""
            Dim MTRS As String = ""
            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim WT As String = ""
            Dim PURRATE As String = ""
            Dim SALERATE As String = ""
            Dim WHOLESALERATE As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim PONO As String = ""
            Dim POGRIDSRNO As String = ""
            Dim CHECKDONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridgrn.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        CUT = row.Cells(gcut.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        RACK = row.Cells(GRACK.Index).Value.ToString
                        SHELF = row.Cells(GSHELF.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value
                        PURRATE = row.Cells(GPURRATE.Index).Value
                        SALERATE = row.Cells(GSALERATE.Index).Value
                        WHOLESALERATE = row.Cells(GWHOLESALERATE.Index).Value
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                        PONO = row.Cells(GPONO.Index).Value.ToString
                        POGRIDSRNO = row.Cells(GGRIDSRNO.Index).Value.ToString
                        If row.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = 1
                        Else
                            CHECKDONE = 0
                        End If

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value.ToString
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        CUT = CUT & "|" & row.Cells(gcut.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        RACK = RACK & "|" & row.Cells(GRACK.Index).Value.ToString
                        SHELF = SHELF & "|" & row.Cells(GSHELF.Index).Value.ToString
                        WT = WT & "|" & row.Cells(GWT.Index).Value
                        PURRATE = PURRATE & "|" & row.Cells(GPURRATE.Index).Value
                        SALERATE = SALERATE & "|" & row.Cells(GSALERATE.Index).Value
                        WHOLESALERATE = WHOLESALERATE & "|" & row.Cells(GWHOLESALERATE.Index).Value
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "|" & Val(row.Cells(GOUTMTRS.Index).Value)
                        PONO = PONO & "|" & row.Cells(GPONO.Index).Value.ToString
                        POGRIDSRNO = POGRIDSRNO & "|" & row.Cells(GGRIDSRNO.Index).Value.ToString
                        If row.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = CHECKDONE & "|" & "1"
                        Else
                            CHECKDONE = CHECKDONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(QUALITY)
            alParaval.Add(BALENO)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(CUT)
            alParaval.Add(MTRS)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)
            alParaval.Add(WT)
            alParaval.Add(PURRATE)
            alParaval.Add(SALERATE)
            alParaval.Add(WHOLESALERATE)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(PONO)
            alParaval.Add(POGRIDSRNO)
            alParaval.Add(CHECKDONE)

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


            Dim objclsGRN As New ClsGrn()
            objclsGRN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                txtgrnno.Text = Val(DTTABLE.Rows(0).Item(0))
                MsgBox("Details Added")

                If FRMSTRING = "GRNJOB" And (ClientName = "SOFTAS" Or ClientName = "BRILLANTO" Or ClientName = "SBA") Then
                    If MsgBox("Wish to Create GRN Checking", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo SKIPLINE

                    Dim OBJCHECKNIG As New GRNChecking
                    OBJCHECKNIG.AUTOCHECKING = True
                    OBJCHECKNIG.TEMPGRNNO = Val(txtgrnno.Text)
                    OBJCHECKNIG.MdiParent = MDIMain
                    OBJCHECKNIG.Show()
                End If

                If ClientName = "SOFTAS" Then
                    If MsgBox("Wish to Create Purchase Invoice....", MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo SKIPLINE

                    Dim OBJCHECKNIG As New PurchaseMaster
                    OBJCHECKNIG.AUTOPURCHASE = True
                    OBJCHECKNIG.TEMPGRNNO = Val(txtgrnno.Text)
                    OBJCHECKNIG.MdiParent = MDIMain
                    OBJCHECKNIG.Show()
                    OBJCHECKNIG.cmbname.Focus()
                End If

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempgrnno)
                IntResult = objclsGRN.UPDATE()
                MsgBox("Details Updated")

            End If
SKIPLINE:
            If FRMSTRING = "GRN FANCY" Then
                PRINTBARCODE()
                If ClientName <> "YAMUNESH" Then
                    PRINTREPORT(Val(txtgrnno.Text.Trim))
                End If
            End If

            If ClientName = "BRILLANTO" Or ClientName = "DAKSH" Then PRINTREPORT(Val(txtgrnno.Text.Trim))


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

            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'GET FRESH DATA FROM DATABASE (ONLY GRID)
                'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
                'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
                gridgrn.RowCount = 0
                Dim OBJGRN As New ClsGrn
                Dim dttable As DataTable = OBJGRN.selectGRN(Val(txtgrnno.Text.Trim), CmpId, Locationid, YearId, cmbtype.Text)
                For Each dr As DataRow In dttable.Rows
                    gridgrn.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("DESIGNNO").ToString, dr("DESC").ToString, dr("COLOR"), Format(dr("qty"), "0.00"), dr("QTYUNIT").ToString, Format(dr("CUT"), "0.00"), Format(dr("MTRS"), "0.00"), dr("RACK"), dr("SHELF"), Format(dr("WT"), "0.00"), Format(dr("PURRATE"), "0.00"), Format(dr("SALERATE"), "0.00"), Format(dr("WHOLESALERATE"), "0.00"), dr("BARCODE").ToString, dr("DONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDPONO").ToString, dr("POGRIDSRNO").ToString)
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

                For Each ROW As DataGridViewRow In gridgrn.Rows

                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If

                    BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(gitemname.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(gcolor.Index).Value, ROW.Cells(gqtyunit.Index).Value, TXTLOTNO.Text.Trim, ROW.Cells(GBALENO.Index).Value, ROW.Cells(gdesc.Index).Value, Val(ROW.Cells(GMTRS.Index).Value), Val(ROW.Cells(gQty.Index).Value), Val(ROW.Cells(gcut.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If
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
        ElseIf e.KeyCode = Keys.F5 Then
            gridgrn.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = (0)
            If ClientName = "PURVITEX" Then ALLOWMANUALGRNNO = True

            fillcmb()
            clear()

            'DONE BY GULKIT
            'If ClientName = "MABHAY" Or ClientName = "SVS" Then
            '    txtqty.Text = "1"
            '    txtqty.BackColor = Color.Linen
            '    txtqty.ReadOnly = True
            'End If
            If ClientName = "SVS" Or ClientName = "BRILLANTO" Then
                txtqty.Text = "1"
                txtqty.BackColor = Color.Linen
                txtqty.ReadOnly = True
            End If

            cmbqtyunit.Text = "Pcs"

            If ClientName = "PURVITEX" Then
                txtgrnno.BackColor = Color.LemonChiffon
            End If

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsGRN As New ClsGrn()
                Dim dttable As New DataTable

                dttable = objclsGRN.selectGRN(tempgrnno, CmpId, Locationid, YearId, cmbtype.Text)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        cmbtype.Text = Convert.ToString(dr("TYPE"))

                        txtgrnno.Text = tempgrnno
                        txtgrnno.ReadOnly = True

                        GRNDATE.Text = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        CMBTONAME.Text = Convert.ToString(dr("TONAME").ToString)
                        '  CMBWEAVER.Text = Convert.ToString(dr("WEAVER").ToString)
                        CMBBROKER.Text = Convert.ToString(dr("BROKER").ToString)
                        CMBSENDER.Text = Convert.ToString(dr("SENDER").ToString)
                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbprocess.Text = Convert.ToString(dr("PROCESS").ToString)
                        TXTLOTNO.Text = Convert.ToString(dr("LOTNO").ToString)
                        RECDATE.Text = Format(Convert.ToDateTime(dr("RECDATE")).Date, "dd/MM/yyyy")
                        TXTPOUTNO.Text = dr("POUTNO").ToString

                        txtchallan.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        PARTYCHALLANNO = txtchallan.Text.Trim

                        CHALLANDATE.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        podate.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString
                        TXTBALEWT.Text = Val(dr("BALEWT"))

                        TXTTOTALBALES.Text = Format(Val(dr("TOTALBALES")), "0.00")
                        CMBDYEINGTYPE.Text = dr("DYEINGTYPE")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        TXTPARTYBILLNO.Text = dr("PARTYBILLNO")
                        TEMPPARTYBILLNO = dr("PARTYBILLNO")
                        PARTYBILLDATE.Value = Format(Convert.ToDateTime(dr("PARTYBILLDATE")).Date, "dd/MM/yyyy")


                        'Item Grid
                        gridgrn.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("DESIGNNO").ToString, dr("DESC").ToString, dr("COLOR"), Format(dr("qty"), "0.00"), dr("QTYUNIT").ToString, Format(dr("CUT"), "0.00"), Format(dr("MTRS"), "0.00"), dr("RACK"), dr("SHELF"), Format(dr("WT"), "0.00"), Format(dr("PURRATE"), "0.00"), Format(dr("SALERATE"), "0.00"), Format(dr("WHOLESALERATE"), "0.00"), dr("BARCODE").ToString, dr("DONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDPONO").ToString, dr("POGRIDSRNO").ToString, dr("CHECKDONE"))

                        If Convert.ToBoolean(dr("CHECKDONE")) = True Or Convert.ToBoolean(dr("INHOUSECHECKDONE")) = True Or Convert.ToBoolean(dr("DONE")) = True Or Convert.ToBoolean(dr("PROGRAMDONE")) = True Or Val(dr("OUTMTRS")) > 0 Then
                            gridgrn.Rows(gridgrn.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    cmbtype.Enabled = False

                    total()
                    Validate()
                Else
                    EDIT = False
                    clear()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" GRN_GRIDSRNO AS GRIDSRNO, GRN_REMARKS AS REMARKS, GRN_NAME AS NAME, GRN_IMGPATH AS IMGPATH, GRN_NEWIMGPATH AS NEWIMGPATH", "", " GRN_UPLOAD", " AND GRN_NO = " & tempgrnno & " AND GRN_CMPID = " & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If


                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" GRN_PODETAILS.GRN_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, GRN_PODETAILS.GRN_ORDERPCS AS ORDERQTY, ISNULL(GRN_PODETAILS.GRN_ORDERMTRS,0) AS ORDERMTRS, GRN_PODETAILS.GRN_FROMNO AS FROMNO, GRN_PODETAILS.GRN_FROMSRNO AS FROMSRNO, GRN_PODETAILS.GRN_FROMTYPE AS FROMTYPE, GRN_PODETAILS.GRN_PCS AS GRNQTY, ISNULL(GRN_PODETAILS.GRN_MTRS,0) AS GRNMTRS, ISNULL(GRN_PODETAILS.GRN_RATE,0) AS RATE ", "", " GRN_PODETAILS INNER JOIN ITEMMASTER ON GRN_PODETAILS.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GRN_PODETAILS.GRN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GRN_PODETAILS.GRN_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND GRN_PODETAILS.GRN_NO = " & tempgrnno & " AND GRN_PODETAILS.GRN_TYPE = '" & cmbtype.Text.Trim & "'  AND GRN_PODETAILS.GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("ITEMNAME"), DTR("DESIGNNO"), DTR("COLOR"), Val(DTR("ORDERQTY")), Val(DTR("ORDERMTRS")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("GRNQTY")), Val(DTR("GRNMTRS")), Val(DTR("RATE")))
                    Next
                End If
                getsrno(GRIDORDER)

                chkchange.CheckState = CheckState.Checked
            End If

            If gridgrn.RowCount > 0 Then
                txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
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
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'AGENT'")
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess)
            If CMBCODE.Text.Trim = "" Then fillACCCODE(CMBCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBTOCODE.Text.Trim = "" Then fillACCCODE(CMBTOCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")

            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")
            If FRMSTRING = "Inwards" Then
                fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            Else
                fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            End If
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            fillunit(cmbqtyunit)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("CMP_NAME AS CMPNAME", "", "CMPMASTER", " AND CMP_ID <> " & CmpId)
            For Each ROW As DataRow In DT.Rows
                CMBCMPNAME.Items.Add(ROW("CMPNAME"))
            Next

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

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgrndetails As New GRNDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.FRMSTRING = FRMSTRING
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Enter
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchallan.Validating
        Try
            If txtchallan.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txtchallan.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
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
            Dim OBJSELECTPO As New SelectPO
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.FRMSTRING = FRMSTRING
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

                TXTPOGRIDSRNO.Text = DTPO.Rows(0).Item("GRIDSRNO")
                podate.Value = DTPO.Rows(0).Item("PODATE")

                CMBTONAME.Text = DTPO.Rows(0).Item("TONAME")
                DUEDATE.Value = DTPO.Rows(0).Item("DUEDATE")
                txtpono.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    'for AVIS GET THIS ITEMNAME AND OTHER DETAILS IN GRID COMBO BOX
                    If ClientName = "AVIS" Then
                        cmbitemname.Text = DTROW("ITEMNAME")
                        CMBDESIGN.Text = DTROW("DESIGNNO")
                        cmbcolor.Text = DTROW("COLOR")
                    End If


                    GRIDORDER.Rows.Add(0, DTROW("ITEMNAME"), DTROW("DESIGNNO"), DTROW("COLOR"), Val(DTROW("QTY")), Val(DTROW("MTRS")), DTROW("PONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))

NEXTLINE:
                Next
                getsrno(GRIDORDER)
                getsrno(gridgrn)

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
                gridgrn.RowCount = 0
                tempgrnno = Val(tstxtbillno.Text)
                If tempgrnno > 0 Then
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

        gridgrn.Enabled = True
        Dim TEMPQTY As Integer
        'Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)

        If FRMSTRING = "GRN FANCY" Then
            TEMPQTY = Val(txtqty.Text.Trim)
        Else
            TEMPQTY = "1"
        End If

        If ClientName = "SVS" Or ClientName = "CC" Or ClientName = "GELATO" Or ClientName = "INDRANI" Then txtqty.Text = "1"
        If ClientName = "MOMAI" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Then
            If CMBPIECETYPE.Text.Trim = "FRESH" Then txtqty.Text = 1 Else TEMPQTY = 1
        End If

        If FRMSTRING = "GRN FANCY" And Val(TXTCUT.Text.Trim) > 0 Then
            If (ClientName = "MIDAS" And cmbqtyunit.Text.Trim = "Mtrs") Or ClientName = "SBA" Or ClientName = "POOJA" Or ClientName = "KARAN" Or ClientName = "AVIS" Or ClientName = "MOHATUL" Or ClientName = "GELATO" Then txtqty.Text = "1"
        End If


        If GRIDDOUBLECLICK = False Then
            If ClientName = "CC" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Or ClientName = "POOJA" Or ClientName = "SBA" Or ClientName = "MOMAI" Or ClientName = "INDRANI" Or ClientName = "GELATO" Or ClientName = "KARAN" Or ClientName = "AVIS" Or ClientName = "MOHATUL" Or ClientName = "MNARESH" Then
                For I As Integer = 1 To TEMPQTY
                    If FRMSTRING = "GRN FANCY" Then
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                LSRNO = InStr(gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                SNO = gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                                TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & gridgrn.RowCount + 1 & "/" & YearId
                            End If
                        End If
                    End If


                    'FETCH RATE FROM DESIGNMASTER
                    If ClientName = "GELATO" And (CHK30.Checked = True Or CHK32.Checked = True Or CHK34.Checked = True Or CHK36.Checked = True Or CHK38.Checked = True Or CHK40.Checked = True Or CHK42.Checked = True Or CHK44.Checked = True Or CHK46.Checked = True Or CHK48.Checked = True Or CHK50.Checked = True Or CHK52.Checked = True Or CHK54.Checked = True Or CHK56.Checked = True Or CHK58.Checked = True) Then
                        Dim TEMPSIZE As String = ""
                        'WE HAVE INSERT THE RECORDS OF ALL THE SIZES SELECTED FOR GELATO
                        For K As Integer = 1 To 15
                            If K = 1 And CHK30.CheckState = CheckState.Checked Then
                                TEMPSIZE = "30"
                                GoTo INSERTDATA
                            End If
                            If K = 2 And CHK32.CheckState = CheckState.Checked Then
                                TEMPSIZE = "32"
                                GoTo INSERTDATA
                            End If
                            If K = 3 And CHK34.CheckState = CheckState.Checked Then
                                TEMPSIZE = "34"
                                GoTo INSERTDATA
                            End If
                            If K = 4 And CHK36.CheckState = CheckState.Checked Then
                                TEMPSIZE = "36"
                                GoTo INSERTDATA
                            End If
                            If K = 5 And CHK38.CheckState = CheckState.Checked Then
                                TEMPSIZE = "38"
                                GoTo INSERTDATA
                            End If
                            If K = 6 And CHK40.CheckState = CheckState.Checked Then
                                TEMPSIZE = "40"
                                GoTo INSERTDATA
                            End If
                            If K = 7 And CHK42.CheckState = CheckState.Checked Then
                                TEMPSIZE = "42"
                                GoTo INSERTDATA
                            End If
                            If K = 8 And CHK44.CheckState = CheckState.Checked Then
                                TEMPSIZE = "44"
                                GoTo INSERTDATA
                            End If
                            If K = 9 And CHK46.CheckState = CheckState.Checked Then
                                TEMPSIZE = "46"
                                GoTo INSERTDATA
                            End If
                            If K = 10 And CHK48.CheckState = CheckState.Checked Then
                                TEMPSIZE = "48"
                                GoTo INSERTDATA
                            End If
                            If K = 11 And CHK50.CheckState = CheckState.Checked Then
                                TEMPSIZE = "50"
                                GoTo INSERTDATA
                            End If
                            If K = 12 And CHK52.CheckState = CheckState.Checked Then
                                TEMPSIZE = "52"
                                GoTo INSERTDATA
                            End If
                            If K = 13 And CHK54.CheckState = CheckState.Checked Then
                                TEMPSIZE = "54"
                                GoTo INSERTDATA
                            End If
                            If K = 14 And CHK56.CheckState = CheckState.Checked Then
                                TEMPSIZE = "56"
                                GoTo INSERTDATA
                            End If
                            If K = 15 And CHK58.CheckState = CheckState.Checked Then
                                TEMPSIZE = "58"
                                GoTo INSERTDATA
                            End If


INSERTDATA:
                            If TEMPSIZE <> "" Then gridgrn.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, CMBDESIGN.Text.Trim, txtgridremarks.Text.Trim, TEMPSIZE, Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTPURRATE.Text.Trim), "0.00"), Format(Val(TXTSALERATE.Text.Trim), "0.00"), Format(Val(TXTWHOLESALERATE.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, 0, 0, 0, 0)
                            TEMPSIZE = ""
                        Next
                        GoTo LINE1
                    End If


                    gridgrn.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, CMBDESIGN.Text.Trim, txtgridremarks.Text.Trim, cmbcolor.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTPURRATE.Text.Trim), "0.00"), Format(Val(TXTSALERATE.Text.Trim), "0.00"), Format(Val(TXTWHOLESALERATE.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, 0, 0, 0, 0)
LINE1:
                Next
            Else
                gridgrn.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, CMBDESIGN.Text.Trim, txtgridremarks.Text.Trim, cmbcolor.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTPURRATE.Text.Trim), "0.00"), Format(Val(TXTSALERATE.Text.Trim), "0.00"), Format(Val(TXTWHOLESALERATE.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, 0, 0, 0, 0)
            End If
            getsrno(gridgrn)
        ElseIf GRIDDOUBLECLICK = True Then
            gridgrn.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            gridgrn.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim

            gridgrn.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
            gridgrn.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            gridgrn.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            gridgrn.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            gridgrn.Item(gdesc.Index, TEMPROW).Value = txtgridremarks.Text.Trim
            gridgrn.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            gridgrn.Item(gQty.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            gridgrn.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
            gridgrn.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            gridgrn.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridgrn.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
            gridgrn.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim
            gridgrn.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            gridgrn.Item(GPURRATE.Index, TEMPROW).Value = Format(Val(TXTPURRATE.Text.Trim), "0.00")
            gridgrn.Item(GSALERATE.Index, TEMPROW).Value = Format(Val(TXTSALERATE.Text.Trim), "0.00")
            gridgrn.Item(GWHOLESALERATE.Index, TEMPROW).Value = Format(Val(TXTWHOLESALERATE.Text.Trim), "0.00")
            gridgrn.Item(GBARCODE.Index, TEMPROW).Value = TXTBARCODE.Text.Trim
            GRIDDOUBLECLICK = False

        End If

        total()

        gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1

        If ClientName = "SANGHVI" Or ClientName = "BRILLANTO" Or ClientName = "INDRANI" Then TXTBALENO.Clear()

        txtgridremarks.Clear()
        TXTCUT.Clear()
        TXTMTRS.Clear()
        TXTPURRATE.Clear()
        TXTSALERATE.Clear()
        TXTWHOLESALERATE.Clear()
        TXTWT.Clear()
        txtPartyMtrs.Clear()
        txtCheckPcs.Clear()
        TXTBARCODE.Clear()
        txtsrno.Text = gridgrn.RowCount + 1

        TXTBALENO.Text = Val(TXTBALENO.Text.Trim) + 1
        TXTMTRS.Focus()

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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtgrnno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish To Proceed?", MsgBoxStyle.YesNo)
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

    Sub EDITROW()
        Try

            If Convert.ToBoolean(gridgrn.CurrentRow.Cells(GDONE.Index).Value) = True Or Val(gridgrn.CurrentRow.Cells(GOUTPCS.Index).Value) > 0 Or Val(gridgrn.CurrentRow.Cells(GOUTMTRS.Index).Value) > 0 Then
                MessageBox.Show("Row Locked, You Cannot Edit This Row")
                Exit Sub
            End If

            If gridgrn.CurrentRow.Index >= 0 And gridgrn.Item(gsrno.Index, gridgrn.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = gridgrn.Item(gsrno.Index, gridgrn.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = gridgrn.Item(GPIECETYPE.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbitemname.Text = gridgrn.Item(gitemname.Index, gridgrn.CurrentRow.Index).Value.ToString
                txtgridremarks.Text = gridgrn.Item(gdesc.Index, gridgrn.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = gridgrn.Item(GQUALITY.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = gridgrn.Item(GBALENO.Index, gridgrn.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = gridgrn.Item(GDESIGN.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbcolor.Text = gridgrn.Item(gcolor.Index, gridgrn.CurrentRow.Index).Value.ToString
                txtqty.Text = gridgrn.Item(gQty.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = gridgrn.Item(gqtyunit.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTCUT.Text = gridgrn.Item(gcut.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = gridgrn.Item(GMTRS.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTWT.Text = gridgrn.Item(GWT.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTPURRATE.Text = gridgrn.Item(GPURRATE.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTSALERATE.Text = gridgrn.Item(GSALERATE.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTWHOLESALERATE.Text = gridgrn.Item(GWHOLESALERATE.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTBARCODE.Text = gridgrn.Item(GBARCODE.Index, gridgrn.CurrentRow.Index).Value.ToString

                TEMPROW = gridgrn.CurrentRow.Index
                CMBPIECETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgrn.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            gridgrn.RowCount = 0
LINE1:
            temptypename = cmbtype.Text.Trim
            tempgrnno = Val(txtgrnno.Text) - 1
            If tempgrnno > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridgrn.RowCount = 0 And tempgrnno > 1 Then
                txtgrnno.Text = tempgrnno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbtype_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Enter
        Try
            getmaxno()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            If cmbtype.Text.Trim.Length > 0 And EDIT = False Then
                getmaxno()
                cmbtype.Enabled = False
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
            gridgrn.RowCount = 0
LINE1:
            tempgrnno = Val(txtgrnno.Text) + 1
            temptypename = cmbtype.Text.Trim
            getmaxno()
            Dim MAXNO As Integer = txtgrnno.Text.Trim
            clear()
            If Val(txtgrnno.Text) - 1 >= tempgrnno Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridgrn.RowCount = 0 And tempgrnno < MAXNO Then
                txtgrnno.Text = tempgrnno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtTOTALBALES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTALBALES.KeyPress, txtqty.KeyPress
        numdot(e, sender, Me)
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
            MsgBox("Date Not In Current Accounting Year")
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
                    MsgBox("Unable To Delete, Checking Done / Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If ClientName = "AVIS" And CMBTONAME.Text.Trim <> "" Then
                    MsgBox("Unable To Delete, Lot Issued To Dyeing", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete GRN?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(txtgrnno.Text.Trim)
                    alParaval.Add(cmbtype.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsGrn()
                    Clsgrn.alParaval = alParaval
                    IntResult = Clsgrn.Delete()
                    MsgBox("GRN Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete Is only In Edit Mode")
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

    Private Sub gridgrn_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridgrn.CellValidating
        Try
            If ClientName <> "MSANCHITKUMAR" Then Exit Sub

            Dim colNum As Integer = gridgrn.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, gcut.Index, gQty.Index, GWT.Index, GPURRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridgrn.CurrentCell.Value = Nothing Then gridgrn.CurrentCell.Value = "0.00"
                        gridgrn.CurrentCell.Value = Convert.ToDecimal(gridgrn.Item(colNum, e.RowIndex).Value)
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

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridgrn.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridgrn.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row Is In Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Convert.ToBoolean(gridgrn.CurrentRow.Cells(GDONE.Index).Value) = True Or Val(gridgrn.CurrentRow.Cells(GOUTPCS.Index).Value) > 0 Or Val(gridgrn.CurrentRow.Cells(GOUTMTRS.Index).Value) > 0 Then
                    MessageBox.Show("Row Locked, You Cannot Delete This Row")
                    Exit Sub
                End If


                'end of block
                gridgrn.Rows.RemoveAt(gridgrn.CurrentRow.Index)
                getsrno(gridgrn)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And gridgrn.RowCount > 0 Then
                If gridgrn.CurrentRow.Cells(gitemname.Index).Value <> "" Then
                    gridgrn.Rows.Add(CloneWithValues(gridgrn.CurrentRow))
                    getsrno(gridgrn)
                    total()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            If index = GBARCODE.Index Then
                If EDIT = True Then
                    'GET LAST BARCODE SRNO
                    Dim LSRNO As Integer = 0
                    Dim RSRNO As Integer = 0
                    Dim SNO As Integer = 0
                    LSRNO = InStr(gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    RSRNO = InStr(LSRNO + 1, gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    SNO = gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                    CloneWithValues.Cells(index).Value = "G-" & Val(txtgrnno.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                Else
                    CloneWithValues.Cells(index).Value = "G-" & Val(txtgrnno.Text.Trim) & "/" & gridgrn.RowCount + 1 & "/" & YearId
                End If
            Else
                CloneWithValues.Cells(index).Value = row.Cells(index).Value
            End If
        Next
    End Function

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

    Sub ADDPOUT(ByRef POOUT As TextBox)
        Dim alParaval As New ArrayList
        alParaval.Add("JTOJ")
        alParaval.Add("JTOJ-" & TXTPOUTNO.Text)
        alParaval.Add("")

        alParaval.Add(Format(Convert.ToDateTime(GRNDATE.Text).Date, "MM/dd/yyyy"))
        alParaval.Add(cmbname.Text.Trim)
        alParaval.Add(CMBTONAME.Text.Trim)
        alParaval.Add("Bleach")
        alParaval.Add(cmbtrans.Text.Trim)
        alParaval.Add(txtlrno.Text.Trim)
        alParaval.Add(lrdate.Value)
        alParaval.Add(txttransref.Text.Trim)
        alParaval.Add(txttransremarks.Text.Trim)

        'alParaval.Add(Val(TXTBALEWT.Text.Trim))

        alParaval.Add(Val(lbltotalqty.Text))
        alParaval.Add(Val(LBLTOTALMTRS.Text))

        alParaval.Add(0)
        alParaval.Add(0)


        alParaval.Add(cmbprocess.Text.Trim)
        alParaval.Add("JOBBER")
        alParaval.Add("JOBBER")
        alParaval.Add(0)
        alParaval.Add(0)
        alParaval.Add("")
        alParaval.Add("")

        alParaval.Add(txtremarks.Text.Trim)
        alParaval.Add(1)
        alParaval.Add(0)
        alParaval.Add(CmpId)
        alParaval.Add(Locationid)
        alParaval.Add(Userid)
        alParaval.Add(YearId)
        alParaval.Add(0)


        Dim gridsrno As String = ""
        Dim LOTNO As String = ""
        Dim PIECETYPE As String = ""
        Dim BALENO As String = ""
        Dim ITEMNAME As String = ""
        Dim QUALITY As String = ""
        Dim PROCESS As String = ""
        Dim DYEINGNO As String = ""
        Dim DESIGNNO As String = ""
        Dim COLOR As String = ""
        Dim RECDATE As String = ""
        Dim CUT As String = ""
        Dim APPRPCS As String = ""
        Dim APPRMTRS As String = ""
        Dim OUTPCS As String = ""
        Dim OUTMTRS As String = ""
        Dim FROMNO As String = ""
        Dim FROMSRNO As String = ""
        Dim FROMTYPE As String = ""
        Dim GRNNO As String = ""
        Dim GRNSRNO As String = ""
        Dim GRNTYPE As String = ""



        For Each row As Windows.Forms.DataGridViewRow In gridgrn.Rows
            If row.Cells(0).Value <> Nothing Then
                If gridsrno = "" Then
                    gridsrno = row.Cells(gsrno.Index).Value.ToString
                    LOTNO = TXTLOTNO.Text
                    PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                    ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                    QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                    PROCESS = cmbprocess.Text

                    OUTPCS = 0
                    OUTMTRS = 0
                    FROMNO = txtgrnno.Text
                    FROMSRNO = row.Cells(gsrno.Index).Value.ToString
                    FROMTYPE = "GRN"
                    GRNNO = txtgrnno.Text
                    GRNSRNO = row.Cells(gsrno.Index).Value.ToString
                    GRNTYPE = cmbtype.Text

                Else

                    gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                    QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                    PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value

                    ITEMNAME = ITEMNAME & "," & row.Cells(gitemname.Index).Value
                    LOTNO = LOTNO & "," & TXTLOTNO.Text
                    PROCESS = PROCESS & "," & cmbprocess.Text

                    OUTPCS = OUTPCS & "," & "0"
                    OUTMTRS = OUTMTRS & "," & "0"
                    FROMNO = FROMNO & "," & txtgrnno.Text
                    FROMSRNO = FROMSRNO & "," & row.Cells(gsrno.Index).Value
                    FROMTYPE = FROMTYPE & "," & "GRN"
                    GRNNO = GRNNO & "," & txtgrnno.Text
                    GRNSRNO = GRNSRNO & "," & row.Cells(gsrno.Index).Value
                    GRNTYPE = GRNTYPE & "," & cmbtype.Text

                End If
            End If
        Next

        alParaval.Add(gridsrno)
        alParaval.Add(LOTNO)
        alParaval.Add(PIECETYPE)
        alParaval.Add(BALENO)
        alParaval.Add(ITEMNAME)
        alParaval.Add(QUALITY)
        alParaval.Add(PROCESS)
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")

        alParaval.Add(APPRPCS)
        alParaval.Add(APPRMTRS)
        alParaval.Add(OUTPCS)
        alParaval.Add(OUTMTRS)
        alParaval.Add(FROMNO)
        alParaval.Add(FROMSRNO)
        alParaval.Add(FROMTYPE)
        alParaval.Add(GRNNO)
        alParaval.Add(GRNSRNO)
        alParaval.Add(GRNTYPE)

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
                    griduploadsrno = griduploadsrno & "," & row.Cells(0).Value.ToString
                    uploadremarks = uploadremarks & "," & row.Cells(1).Value.ToString
                    name = name & "," & row.Cells(2).Value.ToString
                    imgpath = imgpath & "," & row.Cells(3).Value.ToString
                    NEWIMGPATH = NEWIMGPATH & "," & row.Cells(GNEWIMGPATH.Index).Value.ToString

                End If
            End If
        Next

        alParaval.Add(griduploadsrno)
        alParaval.Add(uploadremarks)
        alParaval.Add(name)
        alParaval.Add(imgpath)
        alParaval.Add(NEWIMGPATH)
        alParaval.Add(FILENAME)


        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")

        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")

        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")

        Dim objCLSPROCESSOUT As New ClsProcessOut()
        objCLSPROCESSOUT.alParaval = alParaval
        If EDIT = False Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim DTTABLE As DataTable = objCLSPROCESSOUT.save()

            POOUT.Text = DTTABLE.Rows(0).Item(0)

        Else
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            alParaval.Add(TXTPOUTNO.Text)

            IntResult = objCLSPROCESSOUT.Update()
        End If
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, EDIT, " And GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBROKER.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' and LEDGERS.ACC_TYPE = 'AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, CMBCODE, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'AGENT'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTWT.KeyPress, TXTDMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
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
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, CMBBROKER.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTONAME.Enter
        Try
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTONAME.Validating
        Try
            If CMBTONAME.Text.Trim <> "" Then namevalidate(CMBTONAME, CMBTOCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.Validated
        Try
            If ClientName = "YAMUNESH" Then
                If cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" And TXTBALENO.Text.Trim.Length <> 0 Then
                    If FRMSTRING = "GRN FANCY" Then
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                LSRNO = InStr(gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                                SNO = gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                                TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & gridgrn.RowCount + 1 & "/" & YearId
                            End If
                        End If
                    End If
                    fillgrid()

                ElseIf CMBPIECETYPE.Text.Trim = "" Then
                    MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                    CMBPIECETYPE.Focus()
                    Exit Sub

                ElseIf cmbitemname.Text.Trim = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                    cmbitemname.Focus()
                    Exit Sub
                ElseIf cmbqtyunit.Text.Trim = "" Then
                    MsgBox("Enter Quantity Unit", MsgBoxStyle.Critical)
                    cmbqtyunit.Focus()
                    Exit Sub
                ElseIf Val(txtqty.Text.Trim) <= 0 Then
                    MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                    txtqty.Focus()
                    Exit Sub
                ElseIf TXTBALENO.Text.Trim = "" Then
                    MsgBox("Enter Desc", MsgBoxStyle.Critical)
                    TXTBALENO.Focus()
                    Exit Sub
                End If


            ElseIf ClientName = "AVIS" And cmbqtyunit.Text.Trim <> "" Then
                If UCase(cmbqtyunit.Text.Trim) = "FENT" Then
                    CMBPIECETYPE.Text = "FENT"
                ElseIf UCase(cmbqtyunit.Text.Trim) = "2ND" Then
                    CMBPIECETYPE.Text = "SECOND"
                ElseIf UCase(cmbqtyunit.Text.Trim) = "2ND TP" Then
                    CMBPIECETYPE.Text = "SECOND"
                ElseIf UCase(cmbqtyunit.Text.Trim) = "SHORTAGE" Then
                    CMBPIECETYPE.Text = "SHORTAGE"
                ElseIf UCase(cmbqtyunit.Text.Trim) = "TP" Then
                    CMBPIECETYPE.Text = "TWOPART"
                ElseIf UCase(cmbqtyunit.Text.Trim) = "PCS" Then
                    CMBPIECETYPE.Text = "PIECES"
                Else
                    CMBPIECETYPE.Text = "FRESH"
                End If

            ElseIf ClientName = "MOMAI" Then
                TXTWT_Validated(sender, e)
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

    Private Sub CMBQUALITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
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

    Private Sub CMBSENDER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSENDER.Enter
        Try
            If CMBSENDER.Text.Trim = "" Then fillname(CMBSENDER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENDER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSENDER.Validating
        Try
            If CMBSENDER.Text.Trim <> "" Then namevalidate(CMBSENDER, CMBCODE, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If FRMSTRING = "Inwards" Then
                If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            Else
                If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            End If
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

    Private Sub txtPartyMtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartyMtrs.Validated
        If Val(TXTMTRS.Text) <> 0 And Val(txtPartyMtrs.Text) <> 0 Then
            txtCheckPcs.Text = Format(Val(TXTMTRS.Text) - Val(txtPartyMtrs.Text), "0.00")
        End If
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        CALC()
        If ClientName = "REAL" Then TXTWT_Validated(sender, e)
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        If Val(TXTMTRS.Text) > 0 Then txtPartyMtrs.Text = Val(TXTMTRS.Text)
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
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
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
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCODE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTOCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTONAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
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

    Private Sub CMBTOCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCODE.Validating
        Try
            If CMBTOCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBTOCODE, CMBTONAME, e, Me, TXTTRANSADD, "", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLOTNO.Validating
        Try
            If CMBTONAME.Text.Trim <> "" And Val(TXTLOTNO.Text.Trim) <> 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GRN_NO AS GRNNO ", "", " GRN INNER JOIN LEDGERS ON GRN_TOLEDGERID = ACC_ID AND ACC_CMPID = GRN_CMPID AND ACC_LOCATIONID = GRN_LOCATIONID AND ACC_YEARID = GRN_YEARID ", " AND GRN_TYPE = '" & cmbtype.Text.Trim & "' AND ACC_CMPNAME = '" & CMBTONAME.Text.Trim & "' AND GRN_PLOTNO = '" & TXTLOTNO.Text.Trim & "' AND GRN_CMPID = " & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If (EDIT = False) Or (EDIT = True And Val(DT.Rows(0).Item(0)) <> Val(txtgrnno.Text.Trim)) Then
                        MsgBox("Lot No Already Exists in Inward No " & DT.Rows(0).Item(0), MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If Val(txtqty.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
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

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me, cmbitemname.Text.Trim)
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
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
                'If OBJLEDGER.TEMPAGENT <> "" Then cmbtrans.Text = OBJLEDGER.TEMPAGENT
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

    Sub PRINTREPORT(ByVal GRNNO As Integer)
        Try
            If MsgBox("Wish to Print GRN...?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJGDN As New GRNDesign
                OBJGDN.MdiParent = MDIMain
                If ClientName = "BRILLANTO" Then
                    If cmbtype.Text.Trim = "GRN FANCY" Then OBJGDN.FRMSTRING = "FINISHGRN" Else OBJGDN.FRMSTRING = "GRN"
                Else
                    OBJGDN.FRMSTRING = "GRN"
                End If
                OBJGDN.WHERECLAUSE = "{GRN.GRN_no}=" & Val(GRNNO) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "'  and {GRN.GRN_yearid}=" & YearId
                OBJGDN.Show()
            End If

            If ClientName = "AVIS" Then
                If MsgBox("Wish to Print Mill Letter ?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJGDN As New GRNDesign
                    OBJGDN.MdiParent = MDIMain
                    OBJGDN.FRMSTRING = "LETTER"
                    OBJGDN.WHERECLAUSE = "{GRN.GRN_no}=" & Val(GRNNO) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "'  and {GRN.GRN_yearid}=" & YearId
                    OBJGDN.Show()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(tempgrnno)
                If cmbtype.Text.Trim = "FANCY MATERIAL" Then PRINTBARCODE()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRN_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "PARAS" Then LBLCATEGORY.Visible = True
            If ClientName = "CC" Or ClientName = "SHREEDEV" Or ClientName = "YAMUNESH" Then
                CHKBARCODE.Visible = True
                GBALENO.HeaderText = "Desc"

                gcut.Visible = False
                TXTCUT.Visible = False
                If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                    GWT.Visible = False
                    TXTWT.Visible = False
                End If
                LBLTOTALWT.Visible = False
                GPURRATE.Visible = True
                TXTPURRATE.Visible = True
                GSALERATE.Visible = True
                TXTSALERATE.Visible = True
                GWHOLESALERATE.Visible = True
                TXTWHOLESALERATE.Visible = True

                TXTMTRS.Left = TXTMTRS.Left - 50
                CMBRACK.Left = CMBRACK.Left - 50
                CMBSHELF.Left = CMBSHELF.Left - 50
                TXTPURRATE.Left = TXTPURRATE.Left - 110
                TXTSALERATE.Left = TXTSALERATE.Left - 110
                TXTWHOLESALERATE.Left = TXTWHOLESALERATE.Left - 110
                TXTWT.Left = CMBSHELF.Left + CMBSHELF.Width

            ElseIf ClientName = "MSANCHITKUMAR" Or ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Then
                LBLDYEINGTYPE.Visible = True
                CMBDYEINGTYPE.Visible = True
                If ClientName = "MSANCHITKUMAR" Then
                    LBLPARTYBILLNO.Visible = True
                    LBLPARTYBILLDATE.Visible = True
                    PARTYBILLDATE.Visible = True
                    TXTPARTYBILLNO.Visible = True
                End If
            End If

            If ClientName = "BRILLANTO" Then
                CMBQUALITY.TabStop = False
                CMBDESIGN.TabStop = False
                cmbcolor.TabStop = False
                txtqty.TabStop = False
                cmbqtyunit.TabStop = False
                TXTCUT.TabStop = False
                CMBRACK.TabStop = False
                CMBSHELF.TabStop = False
                GBALENO.HeaderText = "Piece No"
            End If

            If ClientName = "KOCHAR" Then
                TXTCUT.TabStop = False
                If FRMSTRING = "GRN FANCY" Then GRIDBALESUMM.Visible = True
            End If

            If ClientName <> "CC" And ClientName <> "SHREEDEV" And ClientName <> "YAMUNESH" Then
                GPURRATE.Visible = False
                TXTPURRATE.Visible = False
                GSALERATE.Visible = False
                TXTSALERATE.Visible = False
                GWHOLESALERATE.Visible = False
                TXTWHOLESALERATE.Visible = False
            End If

            If ClientName = "SANGHVI" Or ClientName = "RSONS" Then GBALENO.HeaderText = "Description"

            If ClientName = "INDRANI" Or ClientName = "MNIKHIL" Then
                If ClientName = "INDRANI" Then GBALENO.HeaderText = "SO No" Else TXTBALENO.TabStop = False
                CMBQUALITY.TabStop = False
                cmbqtyunit.TabStop = False
                TXTCUT.TabStop = False
                CMBRACK.TabStop = False
                CMBSHELF.TabStop = False
            End If


            If ClientName = "AXIS" Then
                TXTBALEWT.Visible = True
                LBLBALEWT.Visible = True
            End If

            If ClientName = "YASHVI" Or ClientName = "KRISHNA" Then
                LBLCMPNAME.Visible = True
                CMBCMPNAME.Visible = True
                LBLCHNO.Visible = True
                TXTCHNO.Visible = True
            End If

            If ClientName = "AVIS" Then
                CMBTONAME.BackColor = Color.White
                LBLDYEINGTYPE.Visible = False
                CMBDYEINGTYPE.Visible = False
                CMBQUALITY.TabStop = False
                TXTBALENO.TabStop = False
                txtqty.Text = 1

                If cmbtype.Text = "Job Work" Then
                    CMBDESIGN.TabStop = False
                    cmbcolor.TabStop = False
                    CMBRACK.TabStop = False
                    CMBSHELF.TabStop = False
                    cmbtrans.TabStop = True
                    txtlrno.TabStop = True
                    lrdate.TabStop = True
                    'AS PER KUSHALJI 
                    'txtqty.TabStop = False
                End If

                GPURRATE.Visible = True
                GPURRATE.ReadOnly = False

                LBLBALES.Visible = True
                TXTTOTALBALES.Visible = True
                TXTTOTALBALES.TabStop = True

                cmbqtyunit.Text = "Mtrs"
                CMBPIECETYPE.TabStop = False

            End If

            If ClientName = "RMANILAL" Then TXTCUT.TabStop = False

            If ClientName = "SBA" Then
                CMBRACK.TabStop = False
                CMBSHELF.TabStop = False
            End If

            If ClientName = "MOMAI" Then
                CMBQUALITY.TabStop = False
                TXTBALENO.TabStop = False
            End If

            If ClientName = "DILIP" Then
                CMBQUALITY.TabStop = False
                TXTBALENO.TabStop = False
                CMBDESIGN.TabStop = False
                cmbcolor.TabStop = False
                TXTCUT.TabStop = False
            End If

            If ClientName = "KRISHNA" Then CHKLOTREADY.Visible = True

            If ClientName = "GELATO" Then
                gcolor.HeaderText = "Size"
                CMBQUALITY.TabStop = False
                TXTBALENO.TabStop = False
                TXTCUT.TabStop = False
                CMBRACK.TabStop = False
                CMBSHELF.TabStop = False
                PANELSIZE.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURRATE.KeyPress
        Try
            numdot(e, TXTPURRATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSALERATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSALERATE.KeyPress
        Try
            numdot(e, TXTSALERATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWHOLESALERATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTWHOLESALERATE.Validating
        Try
            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" And (Val(TXTPURRATE.Text.Trim) > 0 Or Val(TXTSALERATE.Text.Trim) > 0) Then
                    fillgrid()
                ElseIf CMBPIECETYPE.Text.Trim = "" Then
                    MsgBox("Enter Proper Data", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWHOLESALERATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWHOLESALERATE.KeyPress
        Try
            numdot(e, TXTWHOLESALERATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub CMBDESIGN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID ", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID =  " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPURRATE.Text = Val(DT.Rows(0).Item("PURRATE"))
                    TXTSALERATE.Text = Val(DT.Rows(0).Item("SALERATE"))
                    TXTWHOLESALERATE.Text = Val(DT.Rows(0).Item("WRATE"))
                    If (ClientName = "AVIS" Or ClientName = "KRISHNA") Then cmbitemname.Text = DT.Rows(0).Item("ITEMNAME")
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

    Private Sub CMBSHELF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALENO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALENO.KeyPress
        Try
            If ClientName = "INDRANI" Then numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTWT.Validated
        Try
            'MTRS NOT MANDATORY FOR MOMAI
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub

                If GRIDDOUBLECLICK = False Then
                    If EDIT = True Then
                        'GET LAST BARCODE SRNO
                        Dim LSRNO As Integer = 0
                        Dim RSRNO As Integer = 0
                        Dim SNO As Integer = 0
                        LSRNO = InStr(gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        RSRNO = InStr(LSRNO + 1, gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        SNO = gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                        TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                    Else
                        TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & gridgrn.RowCount + 1 & "/" & YearId
                    End If
                End If



                'CHANGES DONE AS PER CHINTAN BHAI ON 1-9-22
                Dim TEMPORDERMATCH = False
                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    If cmbitemname.Text.Trim = ORDROW.Cells(OITEMNAME.Index).Value And CMBDESIGN.Text.Trim = ORDROW.Cells(ODESIGN.Index).Value And cmbcolor.Text.Trim = ORDROW.Cells(OCOLOR.Index).Value Then
                        TEMPORDERMATCH = True
                    End If
                Next
                If TEMPORDERMATCH = False And GRIDORDER.RowCount > 0 Then
                    MsgBox("Items not Present in Selected Order", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                TEMPORDERMATCH = False



                fillgrid()

            ElseIf CMBPIECETYPE.Text.Trim = "" Then
                MsgBox("Enter Piece Type", MsgBoxStyle.Critical)
                cmbitemname.Focus()
                Exit Sub
            ElseIf cmbitemname.Text.Trim = "" Then
                MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                cmbitemname.Focus()
                Exit Sub
            ElseIf cmbqtyunit.Text.Trim = "" Then
                MsgBox("Enter Quantity Unit", MsgBoxStyle.Critical)
                cmbqtyunit.Focus()
                Exit Sub
            ElseIf Val(txtqty.Text.Trim) <= 0 Then
                MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                txtqty.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALEWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALEWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTDMTRS_Validated(sender As Object, e As EventArgs) Handles TXTDMTRS.Validated
        Try
            If Val(TXTDMTRS.Text.Trim) > 0 Then
                FILLMTRSGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
                    LSRNO = InStr(gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    RSRNO = InStr(LSRNO + 1, gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    SNO = gridgrn.Rows(gridgrn.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)
                    TXTBARCODE.Text = "G-" & Val(txtgrnno.Text.Trim) & "/" & SNO + 1 & "/" & YearId
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

    Private Sub txtgrnno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrnno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtgrnno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtgrnno.Validating
        Try
            If Val(txtgrnno.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GRN.GRN_NO,0)  AS GRNNO", "", " GRN ", "  AND GRN.GRN_NO=" & txtgrnno.Text.Trim & " AND GRN.GRN_TYPE = '" & cmbtype.Text.Trim & "' AND GRN.GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("GRN No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCHNO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCHNO.Validated
        Try
            If (ClientName = "YASHVI" Or ClientName = "KRISHNA") And CMBCMPNAME.Text.Trim <> "" And Val(TXTCHNO.Text.Trim) > 0 And EDIT = False And FRMSTRING = "GRN FANCY" Then
                'GET YEARID FROM SELECTED CMP 
                Dim TEMPYEARID As Integer = 0
                Dim TEMPCMPID As Integer = 0
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("YEAR_ID AS YEARID, YEAR_CMPID AS CMPID", "", "YEARMASTER INNER JOIN CMPMASTER ON YEAR_CMPID = CMP_ID", " AND CMP_NAME = '" & CMBCMPNAME.Text.Trim & "' AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'")
                If DT.Rows.Count > 0 Then
                    TEMPYEARID = DT.Rows(0).Item("YEARID")
                    TEMPCMPID = DT.Rows(0).Item("CMPID")
                End If



                'NOW FETCH CHALLAN DATA
                Dim ALPARAVAL As New ArrayList
                Dim objclsGDN As New ClsGDN()
                Dim dttable As DataTable = objclsGDN.SELECTGDN(Val(TXTCHNO.Text.Trim), TEMPCMPID, 0, TEMPYEARID)
                If dttable.Rows.Count > 0 Then

                    If MsgBox("Fetch data from Entry No " & TXTCHNO.Text.Trim & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                    For Each dr As DataRow In dttable.Rows

                        'CHECKING WHETHER ITEM IS PRESENT IN CURRENT YEAR OR NOT, IF NOT PRESENT THEN ADD NEW ITEM
                        If dr("ITEMNAME") <> "" Then
                            DT = OBJCMN.search("ITEM_ID AS ITEMID", "", " ITEMMASTER ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DT.Rows.Count = 0 Then
                                'ADD NEW ITEMNAME 
                                ALPARAVAL.Clear()


                                ALPARAVAL.Add("Finished Goods")
                                ALPARAVAL.Add("")   'CATEGORY
                                ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'DISPLAYNAME
                                ALPARAVAL.Add(UCase(dr("ITEMNAME"))) 'ITEMNAME

                                ALPARAVAL.Add("")   'DEPARTMENT
                                ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'CODE
                                ALPARAVAL.Add(dr("UNIT"))
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

                                Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_ID, 0) AS HSNCODEID", "", " HSNMASTER", " AND HSN_CODE = '" & dr("HSNCODE") & "' AND HSN_YEARID = " & YearId)
                                If DTHSN.Rows.Count > 0 Then ALPARAVAL.Add(dr("HSNCODE")) Else ALPARAVAL.Add("") 'HSNCODEID

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

                                ALPARAVAL.Add("")   'STORESRNO
                                ALPARAVAL.Add("")   'STOREITEMNAME
                                ALPARAVAL.Add("")   'STOREQTY


                                ALPARAVAL.Add("")   'NATCHSRNO
                                ALPARAVAL.Add("")   'NATCHING


                                ALPARAVAL.Add("")   'WARPSRNO
                                ALPARAVAL.Add("")   'WARPQUALITY
                                ALPARAVAL.Add("")   'WARPSHADE
                                ALPARAVAL.Add("")   'WARPENDS
                                ALPARAVAL.Add("")   'WARPWT
                                ALPARAVAL.Add("")   'WARPMATCHGRIDNO


                                ALPARAVAL.Add("")   'WEFTSRNO
                                ALPARAVAL.Add("")   'WEFTQUALITY
                                ALPARAVAL.Add("")   'WEFTSHADE
                                ALPARAVAL.Add("")   'WEFTPICK
                                ALPARAVAL.Add("")   'WEFTWT
                                ALPARAVAL.Add("")   'WEFTMATCHGRIDNO

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
                        End If


                        If dr("DESIGN") <> "" Then
                            dttable = OBJCMN.search("DESIGN_ID AS DESIGNID", "", "DESIGNMASTER", " AND DESIGN_NO = '" & dr("DESIGN") & "' AND DESIGN_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW DESIGN
                                Dim OBJDESIGN As New ClsDesignMaster
                                OBJDESIGN.alParaval.Add(UCase(dr("DESIGN")))
                                OBJDESIGN.alParaval.Add("") 'MILLNAME
                                OBJDESIGN.alParaval.Add("") 'CADNO
                                OBJDESIGN.alParaval.Add(0)  'PURRATE
                                OBJDESIGN.alParaval.Add(0)  'SALERATE
                                OBJDESIGN.alParaval.Add(0)  'WRATE
                                OBJDESIGN.alParaval.Add("") 'REMARKS

                                OBJDESIGN.alParaval.Add(0)  'FABRIC
                                OBJDESIGN.alParaval.Add(0)  'DYEING
                                OBJDESIGN.alParaval.Add(0)  'JOBWORK
                                OBJDESIGN.alParaval.Add(0)  'FINISHING
                                OBJDESIGN.alParaval.Add(0)  'EXTRA
                                OBJDESIGN.alParaval.Add(0)  'TOTAL

                                OBJDESIGN.alParaval.Add("") 'ITEM
                                OBJDESIGN.alParaval.Add(0)  'BLOCKED

                                OBJDESIGN.alParaval.Add(CmpId)
                                OBJDESIGN.alParaval.Add(Locationid)
                                OBJDESIGN.alParaval.Add(Userid)
                                OBJDESIGN.alParaval.Add(YearId)
                                OBJDESIGN.alParaval.Add(0)

                                OBJDESIGN.alParaval.Add(DBNull.Value)

                                OBJDESIGN.alParaval.Add("") 'GRIDSRNO
                                OBJDESIGN.alParaval.Add("") 'BASE
                                OBJDESIGN.alParaval.Add("") 'PRINT
                                OBJDESIGN.alParaval.Add("") 'COLOR

                                Dim INTRESCAT As Integer = OBJDESIGN.SAVE()
                            End If
                        End If



                        'COLOR SAVE
                        If dr("COLOR") <> "" Then
                            dttable = OBJCMN.search("COLOR_ID AS COLORID", "", "COLORMASTER", " AND COLOR_NAME = '" & dr("COLOR") & "' AND COLOR_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW DESIGN
                                Dim OBJCOLOR As New ClsColorMaster
                                OBJCOLOR.alParaval.Add(UCase(dr("COLOR")))
                                OBJCOLOR.alParaval.Add("")
                                OBJCOLOR.alParaval.Add(CmpId)
                                OBJCOLOR.alParaval.Add(Locationid)
                                OBJCOLOR.alParaval.Add(Userid)
                                OBJCOLOR.alParaval.Add(YearId)
                                OBJCOLOR.alParaval.Add(0)

                                Dim INTRESCAT As Integer = OBJCOLOR.save()
                            End If
                        End If



                        'QUALITY SAVE
                        If dr("QUALITY") <> "" Then
                            dttable = OBJCMN.search("QUALITY_ID AS QUALITYID", "", "QUALITYMASTER", " AND QUALITY_NAME = '" & dr("QUALITY") & "' AND QUALITY_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW QUALITY
                                Dim OBJQUALITY As New ClsQualityMaster
                                OBJQUALITY.alParaval.Add(UCase(dr("QUALITY")))
                                OBJQUALITY.alParaval.Add("")  'PROCECSS
                                OBJQUALITY.alParaval.Add("")  'UNIT
                                OBJQUALITY.alParaval.Add("")  'ITEMNAME
                                OBJQUALITY.alParaval.Add(0) 'REED
                                OBJQUALITY.alParaval.Add(0)  'PIK
                                OBJQUALITY.alParaval.Add("")  'COUNT
                                OBJQUALITY.alParaval.Add(0)  'WIDTH
                                OBJQUALITY.alParaval.Add("") 'REMAKS

                                OBJQUALITY.alParaval.Add("") 'WARP
                                OBJQUALITY.alParaval.Add("") 'WEFT
                                OBJQUALITY.alParaval.Add("") 'SELVEDGE


                                OBJQUALITY.alParaval.Add(CmpId)
                                OBJQUALITY.alParaval.Add(Locationid)
                                OBJQUALITY.alParaval.Add(Userid)
                                OBJQUALITY.alParaval.Add(YearId)
                                OBJQUALITY.alParaval.Add(0)
                                Dim INTRESCAT As Integer = OBJQUALITY.save()
                            End If
                        End If

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        gridgrn.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("BALENO"), dr("DESIGN"), dr("PRINTDESC"), dr("COLOR"), Format(Val(dr("PCS")), "0"), dr("UNIT"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), "", "", 0, 0, 0, 0, "", 0, 0, 0, 0, 0)
                    Next
                    total()
                    gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1
                End If

            End If
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

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(tempgrnno)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(GRNNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJGRN As New GRNDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.DIRECTPRINT = True
            If ClientName = "BRILLANTO" Then
                If cmbtype.Text.Trim = "GRN FANCY" Then OBJGRN.FRMSTRING = "FINISHGRN" Else OBJGRN.FRMSTRING = "GRN"
            Else
                OBJGRN.FRMSTRING = "GRN"
            End If
            OBJGRN.DIRECTMAIL = False
            OBJGRN.DIRECTWHATSAPP = True
            OBJGRN.PRINTSETTING = PRINTDIALOG
            OBJGRN.WHERECLAUSE = "{GRN.GRN_no}=" & Val(GRNNO) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "'  and {GRN.GRN_yearid}=" & YearId
            OBJGRN.GRNNO = Val(GRNNO)
            OBJGRN.NOOFCOPIES = 1
            OBJGRN.Show()
            OBJGRN.Close()


            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\GRN_" & Val(GRNNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("GRN_" & Val(GRNNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
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

    Private Sub TXTMTRS_Enter(sender As Object, e As EventArgs) Handles TXTMTRS.Enter
        If ClientName = "KOCHAR" And GRIDDOUBLECLICK = False And FRMSTRING = "GRN FANCY" And CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
            GBMTRS.Visible = True
            TXTDMTRS.Focus()
        End If
    End Sub

    Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
        Try
            'GET CATEGORY
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
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

    Private Sub CHALLANDATE_Validated(sender As Object, e As EventArgs) Handles CHALLANDATE.Validated
        Try
            If CHALLANDATE.Text.Trim <> "__/__/____" And ClientName = "MOHATUL" Then
                GRNDATE.Text = CHALLANDATE.Text
                RECDATE.Text = CHALLANDATE.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class