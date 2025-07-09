
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class PurchaseReturn

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK, GRIDEXTRADBLCLICK, GRIDUPLOADDOUBLECLICK, GRIDADJDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPCHGSROW, TEMPEXTRAROW, TEMPUPLOADROW, PURREGID, TEMPADJROW As Integer
    Public TEMPPRNO As Integer          'used for editing
    Public TEMPREGNAME As String
    Public EDIT As Boolean          'used for editing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim ALLOWMANUALBILLNO As Boolean = False
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()
        EP.Clear()

        If ALLOWMANUALCNDN = True Then
            TXTPRNO.ReadOnly = False
            TXTPRNO.BackColor = Color.LemonChiffon
        Else
            TXTPRNO.ReadOnly = True
            TXTPRNO.BackColor = Color.Linen
        End If

        CMBNAME.Text = ""
        CMBCREDITLEDGER.Text = ""
        TXTADD.Clear()
        PRDATE.Text = Now.Date
        ACTUALINVDATE.Text = Now.Date

        tstxtbillno.Clear()
        TXTBARCODE.Clear()
        TXTSTATECODE.Clear()
        TXTBALENO.Clear()
        CMBAGENT.Text = ""
        CMBTRANS.Text = ""
        CMBFORMNO.Text = ""
        TXTREFNO.Clear()
        TXTPARTYREFNO.Clear()
        TXTAGENTADD.Clear()
        TXTLRNO.Clear()
        LRDATE.Value = Now.Date
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        TXTBILLNO.Clear()
        TXTPARTYBILLNO.Clear()
        BILLDATE.Text = Now.Date
        PARTYBILLDATE.Text = Now.Date
        TXTINVREGNAME.Clear()
        TXTINVTYPE.Clear()

        tstxtbillno.Clear()

        CMBNAME.Text = ""
        CMBCODE.Text = ""

        txtremarks.Clear()
        TXTPRCHNO.Clear()
        TXTSRNO.Text = 1
        CMBITEM.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTQTY.Clear()
        TXTMTRS.Clear()
        TXTRATE.Clear()
        CMBPER.Text = "Mtrs"
        If ClientName = "SOFTAS" Then CMBQTYUNIT.Text = "PCS"
        TXTAMT.Clear()
        GRIDPURRET.RowCount = 0

        TXTCHGSSRNO.Text = 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        GRIDCHGS.RowCount = 0

        txtuploadsrno.Text = 1
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.Image = Nothing
        gridupload.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        CHKRCM.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked

        txtbillamt.Text = 0.0
        TXTCHARGES.Text = 0.0
        TXTSUBTOTAL.Text = 0.0

        CHKTCS.Checked = False
        TXTTOTALWITHGST.Clear()
        TXTTCSPER.Clear()
        TXTTCSAMT.Clear()

        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        txtremarks.Clear()

        LBLTOTALPCS.Text = 0.0
        LBLTOTALMTRS.Text = 0.0
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTHSNCODE.Clear()
        TXTEWAYBILLNO.Clear()
        TabControl1.SelectedIndex = 0
        getmaxno()

        TXTADJSRNO.Text = 1
        TXTBILLREMARKS.Clear()

        TXTCHQBAL.Clear()
        CMBPAYTYPE.SelectedIndex = 0
        CMBBILLNO.Text = ""
        LBLBILLTOTAL.Text = ""
        TXTNARR.Clear()
        TXTADJAMT.Clear()
        TXTADJTOTAL.Clear()
        TXTINVTOTAL.Clear()

        GRIDPAYMENT.RowCount = 0
        GRIDPURRET.DataSource = Nothing
        TXTGSTIN.Clear()


    End Sub

    Sub total()
        Try
            LBLTOTALPCS.Text = "0.0"
            LBLTOTALMTRS.Text = "0.0"

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0

            TXTINVTOTAL.Text = 0.0
            TXTADJTOTAL.Text = 0.0
            TXTCHQBAL.Text = 0.0

            TXTTCSPER.Text = 0
            TXTTCSAMT.Text = 0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(PRDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))

            If GRIDPURRET.RowCount > 0 Then

                For Each row As DataGridViewRow In GRIDPURRET.Rows
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(GMTRS.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Qty" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(gQty.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    End If
                    If Val(row.Cells(gQty.Index).Value) > 0 Then LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0")
                    If Val(row.Cells(GMTRS.Index).Value) > 0 Then LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GAMT.Index).Value) > 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                Next
            End If

            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If

            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")
            End If

            TXTTOTALWITHGST.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0.00")
            If CHKTCS.CheckState = CheckState.Checked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")

            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)


            For Each row As DataGridViewRow In GRIDPAYMENT.Rows
                TXTADJTOTAL.Text = Format(Val(TXTADJTOTAL.Text) + row.Cells(GADJAMT.Index).Value, "0.00")
            Next

            For Each row As DataGridViewRow In GRIDBILL.Rows
                If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(GRIDBILL.Columns("INVBALAMT").Index).Value, "0.00")
            Next

            If Val(txtgrandtotal.Text) > 0 Then TXTCHQBAL.Text = Format(Val(txtgrandtotal.Text) - Val(TXTADJTOTAL.Text), "0.00")

            'GET ADJAMT
            TXTADJAMT.Text = Val(TXTCHQBAL.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        total()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PR_NO),0) + 1 ", "  PURCHASERETURN ", " AND PURCHASERETURN.PR_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPRNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
        Dim bln As Boolean = True




        'IF BILL NOT ADJUSTED AND GRID IS BLANK THEN MAKE ON ACCOUNT ENTRY
        If Val(TXTBILLNO.Text.Trim) = 0 And GRIDPAYMENT.RowCount = 0 Then
            GRIDPAYMENT.Rows.Add(1, "On Account", "", "", Val(txtgrandtotal.Text.Trim), 0, 0, 0, Val(txtgrandtotal.Text.Trim))
            total()
        End If

        If Val(TXTBILLNO.Text.Trim) <> 0 And GRIDPAYMENT.RowCount > 0 Then
            EP.SetError(TXTBILLNO, "Amount cannot be Adjusted against Multiple Bills")
            bln = False
        End If


        If Val(txtgrandtotal.Text.Trim) <> Val(TXTADJTOTAL.Text.Trim) And GRIDPAYMENT.RowCount > 0 Then
            EP.SetError(txtgrandtotal, "Total does not match Adjusted Amt")
            bln = False
        End If



        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Company Name ")
            bln = False
        End If

        If cmbGodown.Text.Trim.Length = 0 Then
            EP.SetError(cmbGodown, " Please Select Godown")
            bln = False
        End If

        If CMBCREDITLEDGER.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Select Credit Ledger")
            bln = False
        End If

        If CMBCREDITLEDGER.Text.Trim = CMBNAME.Text.Trim Then
            EP.SetError(CMBCREDITLEDGER, "Credit and Debit Ledger cannot be kept same")
            bln = False
        End If

        'If Convert.ToDateTime(PRDATE.Text).Date >= "01/07/2017" And ClientName <> "MAHAVIR" And ClientName <> "SUPRIYA" And ClientName <> "SAFFRON" And ClientName <> "SONU" Then
        '    If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
        '        EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
        '        bln = False
        '    End If
        'End If



        If GRIDPURRET.RowCount = 0 Then
            EP.SetError(CMBNAME, "Select grn")
            bln = False
        End If

        If PRDATE.Text = "__/__/____" Then
            EP.SetError(PRDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PRDATE.Text) Then
                EP.SetError(PRDATE, "Date not in Accounting Year")
                bln = False
            End If

            If Convert.ToDateTime(PRDATE.Text).Date < CNBLOCKDATE.Date Then
                EP.SetError(PRDATE, "Date is Blocked, Please make entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"))
                bln = False
            End If
        End If

        If ACTUALINVDATE.Text = "__/__/____" Then
            EP.SetError(ACTUALINVDATE, " Please Enter Proper Date")
            bln = False
            Return bln
            Exit Function
        End If


        If Convert.ToDateTime(PRDATE.Text).Date >= "01/07/2017" Then
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

            If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(TXTCGSTAMT.Text) > 0 Or Val(TXTSGSTAMT.Text.Trim) > 0) Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                bln = False
            End If

            If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(TXTIGSTAMT.Text) > 0 Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                bln = False
            End If
        End If


        For Each row As DataGridViewRow In GRIDPURRET.Rows
            If ClientName <> "MOMAI" And ClientName <> "AXIS" Then
                If Val(row.Cells(GMTRS.Index).Value) = 0 Then
                    EP.SetError(CMBNAME, "Mtrs Cannot be 0")
                    bln = False
                End If
            End If

            If Val(row.Cells(GAMT.Index).Value) = 0 And ClientName <> "MAHAVIR" Then
                EP.SetError(CMBNAME, "Amt Cannot be 0")
                bln = False
            End If
        Next


        'IF INVOICENO IS NOT BLANK THEN CHECK THAT FIGURES CANNOT BE GREATER THEN BALANCEAMT
        If Val(TXTBILLNO.Text.Trim) > 0 Then
            Dim BALANCE As Double = 0
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            If TXTINVTYPE.Text.Trim = "PURCHASE" Then
                DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID", " AND BILL_NO = " & Val(TXTBILLNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
            Else
                DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID", " AND BILL_NO = " & Val(TXTBILLNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
            End If
            BALANCE = Val(DT.Rows(0).Item("INVBAL"))
            If EDIT = True Then
                Dim DT1 As DataTable = OBJCMN.search("PR_GRANDTOTAL AS RETTOTAL", "", "PURCHASERETURN", " AND PR_NO = " & Val(TEMPPRNO) & " AND PR_YEARID = " & YearId)
                BALANCE += Val(DT1.Rows(0).Item("RETTOTAL"))
            End If
            If Val(txtgrandtotal.Text.Trim) > Val(BALANCE) Then
                EP.SetError(txtgrandtotal, "Amount Greater then Balance Amt, only " & Val(BALANCE) & " can be Used")
                bln = False
            End If
        End If



        'DONE BY GULKIT
        'If Convert.ToDateTime(PRDATE.Text).Date >= "01/02/2018" And txtgrandtotal.Text > 50000 Then
        '    If TXTEWAYBILLNO.Text.Trim.Length = 0 Then
        '        If MsgBox("E-Way No. Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '            EP.SetError(TXTEWAYBILLNO, " Please Enter E-Way No..... ")
        '            bln = False
        '        End If
        '    End If
        'End If

        If ALLOWMANUALCNDN = True Then
            If TXTBILLNO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon

                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(CONTRA.CONTRA_no,0) AS CONTRANO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CONTRA ON REGISTERMASTER.register_id = CONTRA.CONTRA_registerid AND REGISTERMASTER.register_cmpid = CONTRA.CONTRA_cmpid AND REGISTERMASTER.register_yearid = CONTRA.CONTRA_yearid AND REGISTERMASTER.register_locationid = CONTRA.CONTRA_locationid ", "  AND CONTRA.CONTRA_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CONTRA.CONTRA_CMPID = " & CmpId & " AND CONTRA.CONTRA_LOCATIONID = " & Locationid & " AND CONTRA.CONTRA_YEARID = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASERETURN.PR_no, 0) AS BILLNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PURCHASERETURN ON REGISTERMASTER.register_id = PURCHASERETURN.PR_PURREGID AND REGISTERMASTER.register_cmpid = PURCHASERETURN.PR_CMPID AND REGISTERMASTER.register_yearid = PURCHASERETURN.PR_YEARID AND REGISTERMASTER.register_locationid = PURCHASERETURN.PR_LOCATIONID", "  AND PURCHASERETURN.PR_NO=" & TXTPRNO.Text.Trim & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND PURCHASERETURN.PR_cmpid = " & CmpId & " AND PURCHASERETURN.PR_locationid = " & Locationid & " AND PURCHASERETURN.PR_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTBILLNO, "Bill No Already Exist")
                    bln = False
                End If
            End If
        End If

        For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
            If ROW.Cells(gpaytype.Index).Value = "Against Bill" And ROW.Cells(gbillno.Index).Value = "" Then
                EP.SetError(CMBNAME, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                bln = False
            End If
        Next

        Return bln
    End Function

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
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If ALLOWMANUALCNDN = True Then
                alParaval.Add(Val(TXTPRNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(PRDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBCREDITLEDGER.Text.Trim)
            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(BILLDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTINVREGNAME.Text.Trim)
            alParaval.Add(TXTINVTYPE.Text.Trim)


            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTAGENTADD.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(TXTPARTYREFNO.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)

            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(LRDATE.Value)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)

            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))

            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))
            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(TXTPRCHNO.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)



            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim QUALITY As String = ""
            Dim DESIGNNO As String = ""
            Dim COLOR As String = ""
            Dim BALENO As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim PER As String = ""
            Dim AMT As String = ""          'value of AMT
            Dim BARCODE As String = ""
            Dim GRNNO As String = ""        'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNGRIDSRNO As String = ""   'value of GRNGRIDSRNO
            Dim GRIDTYPE As String = ""     'value of TYPE
            Dim BILLDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURRET.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGNNO = row.Cells(GDESIGNNO.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        qty = Val(row.Cells(gQty.Index).Value)
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        PER = row.Cells(GPER.Index).Value.ToString
                        If row.Cells(GAMT.Index).Value <> Nothing Then
                            AMT = Val(row.Cells(GAMT.Index).Value)
                        Else
                            AMT = 0
                        End If
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        GRNNO = row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = row.Cells(GFROMSRNO.Index).Value
                        Else
                            GRNGRIDSRNO = 0
                        End If
                        GRIDTYPE = row.Cells(GTYPE.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = "1"
                        Else
                            BILLDONE = "0"
                        End If

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGNNO.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(gQty.Index).Value)
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        PER = PER & "|" & row.Cells(GPER.Index).Value
                        If row.Cells(GAMT.Index).Value <> Nothing Then
                            AMT = AMT & "|" & Val(row.Cells(GAMT.Index).Value)
                        Else
                            AMT = AMT & "|" & 0
                        End If
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        GRNNO = GRNNO & "|" & row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        Else
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & " 0"
                        End If
                        GRIDTYPE = GRIDTYPE & "|" & row.Cells(GTYPE.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = BILLDONE & "|" & "1"
                        Else
                            BILLDONE = BILLDONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGNNO)
            alParaval.Add(COLOR)
            alParaval.Add(BALENO)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMT)
            alParaval.Add(BARCODE)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNGRIDSRNO)
            alParaval.Add(GRIDTYPE)
            alParaval.Add(BILLDONE)


            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CPER = row.Cells(EPER.Index).Value.ToString
                        CAMT = row.Cells(EAMT.Index).Value.ToString
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)

                    Else
                        CSRNO = CSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & row.Cells(EPER.Index).Value.ToString
                        CAMT = CAMT & "|" & row.Cells(EAMT.Index).Value.ToString
                        CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)

            Dim pgridsrno As String = ""
            Dim paytype As String = ""
            Dim billINITIALS As String = ""
            Dim narr As String = ""
            Dim ADJAMT As String = ""
            Dim AMTPAID As String = ""
            Dim EXTRAAMT As String = ""
            Dim RETURNAMT As String = ""
            Dim BALANCE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPAYMENT.Rows
                If row.Cells(GADJSRNO.Index).Value <> Nothing Then
                    If pgridsrno = "" Then

                        pgridsrno = row.Cells(GADJSRNO.Index).Value.ToString
                        paytype = row.Cells(gpaytype.Index).Value
                        billINITIALS = row.Cells(gbillno.Index).Value.ToString
                        narr = row.Cells(gdesc.Index).Value
                        ADJAMT = Val(row.Cells(GADJAMT.Index).Value)
                        AMTPAID = Val(row.Cells(GAMTPAID.Index).Value)
                        EXTRAAMT = Val(row.Cells(GEXTRAAMT.Index).Value)
                        RETURNAMT = Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = Val(row.Cells(GBALANCE.Index).Value)


                    Else

                        pgridsrno = pgridsrno & "|" & row.Cells(GADJSRNO.Index).Value.ToString
                        paytype = paytype & "|" & row.Cells(gpaytype.Index).Value
                        billINITIALS = billINITIALS & "|" & row.Cells(gbillno.Index).Value.ToString
                        narr = narr & "|" & row.Cells(gdesc.Index).Value
                        ADJAMT = ADJAMT & "|" & Val(row.Cells(GADJAMT.Index).Value)
                        AMTPAID = AMTPAID & "|" & Val(row.Cells(GAMTPAID.Index).Value)
                        EXTRAAMT = EXTRAAMT & "|" & Val(row.Cells(GEXTRAAMT.Index).Value)
                        RETURNAMT = RETURNAMT & "|" & Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = BALANCE & "|" & Val(row.Cells(GBALANCE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(pgridsrno)
            alParaval.Add(paytype)
            alParaval.Add(billINITIALS)
            alParaval.Add(narr)
            alParaval.Add(ADJAMT)
            alParaval.Add(AMTPAID)
            alParaval.Add(EXTRAAMT)
            alParaval.Add(RETURNAMT)
            alParaval.Add(BALANCE)

            Dim objPurchaseReturn As New ClsPurchaseReturn()
            objPurchaseReturn.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objPurchaseReturn.SAVE()
                MsgBox("Details Added")
                TEMPPRNO = DTTABLE.Rows(0).Item(0)

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPPRNO)
                IntResult = objPurchaseReturn.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If

            If ClientName = "SVS" Or ClientName = "KEMLINO" Then PRINTREPORT(TEMPPRNO)
            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)

            PRDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJBILL As New ClsPurchaseReturn


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPPRNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    If row.Cells(GUIMGPATH.Index).Value IsNot Nothing Then
                        PBSoftCopy.Image = row.Cells(GUIMGPATH.Index).Value
                        PBSoftCopy.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                    Else
                        ALPARAVAL.Add(DBNull.Value)
                    End If

                    ALPARAVAL.Add(YearId)

                    OBJBILL.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBILL.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3) Then       'for CLEAR
                TabControl1.SelectedIndex = (2)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4) Then       'for CLEAR
                TabControl1.SelectedIndex = (3)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDPURRET.Focus()
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

    Private Sub PurchaseReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE RETURN'")
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

                'If ALLOWMANUALBILLNO = True Then
                '    TXTBILLNO.ReadOnly = False
                '    TXTBILLNO.BackColor = Color.LemonChiffon
                'Else
                '    TXTBILLNO.ReadOnly = True
                '    TXTBILLNO.BackColor = Color.Linen
                'End If

                Dim objJO As New ClsPurchaseReturn()
                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPPRNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                objJO.alParaval = ALPARAVAL

                dt = objJO.SELECTPR()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTPRNO.Text = TEMPPRNO
                        TXTPRNO.ReadOnly = True

                        If Convert.ToBoolean(dr("RCM")) = False Then CHKRCM.Checked = False Else CHKRCM.Checked = True
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True

                        CMBNAME.Text = Convert.ToString(dr("NAME"))

                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")

                        PRDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        ACTUALINVDATE.Text = Format(Convert.ToDateTime(dr("ACTUALINVDATE")), "dd/MM/yyyy")
                        TXTBILLNO.Text = Convert.ToString(dr("BILLNO"))
                        BILLDATE.Text = Format(Convert.ToDateTime(dr("BILLDATE")), "dd/MM/yyyy")

                        TXTPARTYBILLNO.Text = Convert.ToString(dr("PARTYBILL"))
                        PARTYBILLDATE.Text = Format(Convert.ToDateTime(dr("PARTYDATE")), "dd/MM/yyyy")
                        TXTINVREGNAME.Text = Convert.ToString(dr("PURREGNAME"))
                        TXTINVTYPE.Text = Convert.ToString(dr("INVOICETYPE"))

                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        TXTAGENTADD.Text = Convert.ToString(dr("AGENTADD"))
                        TXTREFNO.Text = Convert.ToString(dr("REFFNO"))
                        TXTPARTYREFNO.Text = Convert.ToString(dr("PARTYREFNO"))

                        CMBTRANS.Text = dr("TRANS")
                        cmbGodown.Text = dr("GODOWN")
                        CMBCREDITLEDGER.Text = dr("CREDITNAME")

                        TXTLRNO.Text = dr("LRNO")
                        LRDATE.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        LBLTOTALPCS.Text = dr("TOTALPCS")

                        If dr("MANUALGST") = 0 Then
                            CHKMANUAL.Checked = False
                        Else
                            CHKMANUAL.Checked = True
                        End If

                        TXTCGSTPER.Text = Val(dr("TOTALCGSTPER"))
                        TXTSGSTPER.Text = Val(dr("TOTALSGSTPER"))
                        TXTIGSTPER.Text = Val(dr("TOTALIGSTPER"))
                        TXTCGSTAMT.Text = Val(dr("TOTALCGSTAMT"))
                        TXTSGSTAMT.Text = Val(dr("TOTALSGSTAMT"))
                        TXTIGSTAMT.Text = Val(dr("TOTALIGSTAMT"))


                        LBLTOTALMTRS.Text = dr("TOTALMTRS")
                        txtinwords.Text = Convert.ToString(dr("INWORDS"))

                        txtbillamt.Text = Val(dr("BILLAMT"))
                        TXTCHARGES.Text = Val(dr("CHARGES"))
                        TXTCHARGES.Text = Val(dr("SUBTOTAL"))

                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))

                        txtroundoff.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))
                        TXTPRCHNO.Text = Val(dr("PRCHNO"))

                        'Item Grid
                        GRIDPURRET.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEM").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("DESIGNNO"), dr("COLOR"), dr("BALENO").ToString, dr("PCS").ToString, dr("UNIT").ToString, dr("MTRS").ToString, dr("WT").ToString, dr("RATE").ToString, dr("PER").ToString, dr("AMT").ToString, dr("BARCODE"), dr("GRNNO"), dr("GRNSRNO"), dr("TYPE"), dr("DONE"))

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            GRIDPURRET.Rows(GRIDPURRET.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            CMBNAME.Enabled = False
                        End If

                        TabControl1.SelectedIndex = (0)

                    Next

                    'CHARGES GRID
                    Dim OBJCM2 As New ClsCommon
                    Dim dt2 As DataTable = OBJCM2.search(" PURCHASERETURN_CHGS.PR_gridsrno AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASERETURN_CHGS.PR_PER, 0) AS PER, ISNULL(PURCHASERETURN_CHGS.PR_AMT, 0) AS AMT, ISNULL(TAXMASTER.TAX_ID, 0) AS TAXID ", "", " PURCHASERETURN LEFT OUTER JOIN PURCHASERETURN_CHGS LEFT OUTER JOIN TAXMASTER ON PURCHASERETURN_CHGS.PR_TAXID = TAXMASTER.tax_id ON PURCHASERETURN.PR_NO = PURCHASERETURN_CHGS.PR_no AND PURCHASERETURN.PR_YEARID = PURCHASERETURN_CHGS.PR_YEARID LEFT OUTER JOIN LEDGERS ON PURCHASERETURN_CHGS.PR_CHARGESID = LEDGERS.Acc_id", " AND PURCHASERETURN_CHGS.PR_NO = " & TEMPPRNO & " AND PURCHASERETURN_CHGS.PR_YEARID = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    'UPLOAD(GRID)
                    Dim dt3 As DataTable = OBJCM2.search(" PURCHASERETURN_UPLOAD.PR_SRNO AS GRIDSRNO, PURCHASERETURN_UPLOAD.PR_REMARKS AS REMARKS, PURCHASERETURN_UPLOAD.PR_NAME AS NAME, PURCHASERETURN_UPLOAD.PR_PHOTO AS IMGPATH ", "", " PURCHASERETURN_UPLOAD ", " AND PURCHASERETURN_UPLOAD.PR_NO = " & TEMPPRNO & " AND PR_YEARID = " & YearId & " ORDER BY PURCHASERETURN_UPLOAD.PR_SRNO")
                    If dt3.Rows.Count > 0 Then
                        For Each DTR2 As DataRow In dt3.Rows
                            gridupload.Rows.Add(DTR2("GRIDSRNO"), DTR2("REMARKS"), DTR2("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR2("IMGPATH"), Byte()))))
                        Next
                    End If

                    Dim dttable1 As DataTable = OBJCM2.search(" PURCHASERETURN_BILLDESC.PR_GRIDSRNO AS GRIDSRNO, PURCHASERETURN_BILLDESC.PR_PAYTYPE AS PAYTYPE, PURCHASERETURN_BILLDESC.PR_BILLINITIALS AS BILLINITIALS, PURCHASERETURN_BILLDESC.PR_GRIDREMARKS AS NARR, PURCHASERETURN_BILLDESC.PR_AMT AS AMT, PURCHASERETURN_BILLDESC.PR_AMTPAID AS AMTPAID, PURCHASERETURN_BILLDESC.PR_EXTRAAMT AS EXTRAAMT, PURCHASERETURN_BILLDESC.PR_RETURN AS [RETURN], PURCHASERETURN_BILLDESC.PR_BALANCE AS BALANCE ", "", " PURCHASERETURN_BILLDESC ", " AND PURCHASERETURN_BILLDESC.PR_NO = " & TEMPPRNO & " AND PURCHASERETURN_BILLDESC.PR_YEARID = " & YearId)
                    For Each DR As DataRow In dttable1.Rows
                        GRIDPAYMENT.Rows.Add(DR("GRIDSRNO"), DR("PAYTYPE").ToString, DR("BILLINITIALS").ToString, DR("NARR").ToString, Format(DR("AMT"), "0.00"), Format(DR("AMTPAID"), "0.00"), Format(DR("EXTRAAMT"), "0.00"), Format(DR("RETURN"), "0.00"), Format(DR("BALANCE"), "0.00"))
                        If Val(DR("AMTPAID")) > 0 Or Val(DR("EXTRAAMT")) > 0 Or Val(DR("RETURN")) > 0 Then
                            GRIDPAYMENT.Rows(GRIDPAYMENT.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                        End If
                    Next
                    FILLGRIDINVOICE()
                    GRIDPAYMENT.ClearSelection()
                    total()


                    GRIDPURRET.FirstDisplayedScrollingRowIndex = GRIDPURRET.RowCount - 1

                End If


            Else
                EDIT = False
                clear()
            End If

            total()


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
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
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_ADDLESS,'ADD') AS ADDLESS ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("ADDLESS") = "LESS" Then
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then TXTCHGSPER.Text = "-"
                        If Val(TXTCHGSAMT.Text.Trim) = 0 Then TXTCHGSAMT.Text = "-"
                        TXTCHGSPER.Select(TXTCHGSPER.Text.Length, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Sale A/C' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' )")
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, "")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, False)
            If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)

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

            Dim OBJEMB As New PurchaseReturnDetails
            OBJEMB.MdiParent = MDIMain
            OBJEMB.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT' ")
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
                '  If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "SUNDRY CREDITORS", "TRANSPORT")
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

    Private Sub CMDSELECTDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTINVOICE.Click
        Try
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Party First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectPurchaseReturn
            OBJSELECTGDN.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTGDN.ShowDialog()

            DTTABLE = OBJSELECTGDN.DT

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then


                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTTABLE.DefaultView
                Dim DT As DataTable = DV.ToTable(True, "BILLNO")
                For Each DTR As DataRow In DT.Rows
                    If TXTBILLNO.Text.Trim = "" Then
                        TXTBILLNO.Text = DTR("BILLNO").ToString
                    Else
                        TXTBILLNO.Text = TXTBILLNO.Text & "," & DTR("BILLNO").ToString
                    End If
                Next


                For i = 0 To DTTABLE.Rows.Count - 1
                    Dim objclspreq As New ClsCommon()

                    If DTTABLE.Rows(0).Item("INVOICETYPE") = "PURCHASE" Then
                        DT = objclspreq.search("  LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, ISNULL(PURCHASEMASTER.BILL_PARTYBILLNO, '') AS PARTYBILL, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYDATE, ISNULL(AGENT.Acc_cmpname, '') AS AGENT, ISNULL(PURCHASEMASTER.BILL_REFNO, '') AS REFNO, ISNULL(FORMTYPE.FORM_NAME, '') AS FORM, ISNULL(TRANS.Acc_cmpname, '') AS TRANS, ISNULL(PURCHASEMASTER.BILL_LRNO, '') AS LRNO, PURCHASEMASTER.BILL_LRDATE AS LRDATE, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, ISNULL(PURCHASEMASTER_DESC.BILL_gridsrno, 0) AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(PURCHASEMASTER_DESC.BILL_BALENO, '') AS BALENO, ISNULL(PURCHASEMASTER_DESC.BILL_QTY, 0) AS PCS, ISNULL(UNITMASTER.unit_ABBR, '') AS UNIT, ISNULL(PURCHASEMASTER_DESC.BILL_MTRS, 0) AS MTRS, ISNULL(PURCHASEMASTER_DESC.BILL_WT, 0) AS WT, ISNULL(PURCHASEMASTER_DESC.BILL_rate, 0) AS RATE, ISNULL(PURCHASEMASTER_DESC.BILL_PER, '') AS PER, ISNULL(PURCHASEMASTER_DESC.BILL_amt, 0) AS AMT, ISNULL(PURCHASEMASTER_DESC.BILL_GRNNO, 0) AS GRNNO, ISNULL(PURCHASEMASTER_DESC.BILL_GRNGRIDSRNO, 0) AS GRNGRIDSRNO, ISNULL(PURCHASEMASTER_DESC.BILL_TYPE, '') AS TYPE, ISNULL(PURCHASEMASTER_DESC.BILL_GRIDDONE, 0) AS GRIDDONE, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, REGLEDGERS.Acc_cmpname AS CREDITLEDGER", "", "HSNMASTER RIGHT OUTER JOIN PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id ON HSNMASTER.HSN_ID = PURCHASEMASTER_DESC.BILL_HSNCODEID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN FORMTYPE RIGHT OUTER JOIN PURCHASEMASTER_FORMTYPE ON FORMTYPE.FORM_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID AND FORMTYPE.FORM_ID = PURCHASEMASTER_FORMTYPE.BILL_FORMID ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID LEFT OUTER JOIN UNITMASTER ON PURCHASEMASTER_DESC.BILL_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER ON PURCHASEMASTER_DESC.BILL_DESIGNID = DESIGNMASTER.DESIGN_ID LEFT OUTER JOIN COLORMASTER ON PURCHASEMASTER_DESC.BILL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PURCHASEMASTER_DESC.BILL_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANS ON PURCHASEMASTER.BILL_TRANSNAMEID = TRANS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENT ON PURCHASEMASTER.BILL_AGENTID = AGENT.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.REGISTER_ID INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid ", "  and PURCHASEMASTER.BILL_NO='" & DTTABLE.Rows(i).Item("BILLNO") & "' and REGISTERMASTER.REGISTER_NAME='" & DTTABLE.Rows(i).Item("PURREGNAME") & "' AND PURCHASEMASTER.BILL_YEARID = " & YearId)
                    Else
                        DT = objclspreq.search("  LEDGERS.Acc_cmpname AS NAME, OPENINGBILL.BILL_NO AS BILLNO, OPENINGBILL.BILL_DATE AS DATE, ISNULL(OPENINGBILL.BILL_NARRATION, '') AS PARTYBILL, OPENINGBILL.BILL_DATE AS PARTYDATE, ISNULL(AGENT.Acc_cmpname, '') AS AGENT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, REGLEDGERS.Acc_cmpname AS CREDITLEDGER", "", "OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id  INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS AGENT ON OPENINGBILL.BILL_AGENTID = AGENT.Acc_id ", " and OPENINGBILL.BILL_INITIALS = '" & DTTABLE.Rows(0).Item("BILLINITIALS") & "' and OPENINGBILL.BILL_NO='" & DTTABLE.Rows(i).Item("BILLNO") & "' and REGISTERMASTER.REGISTER_NAME='" & DTTABLE.Rows(i).Item("PURREGNAME") & "' AND OPENINGBILL.BILL_YEARID = " & YearId)
                    End If

                    TXTBILLNO.Text = DT.Rows(0).Item("BILLNO")
                    BILLDATE.Text = Format(Convert.ToDateTime(DT.Rows(0).Item("DATE")), "dd/MM/yyyy")
                    TXTPARTYBILLNO.Text = DT.Rows(0).Item("PARTYBILL")
                    PARTYBILLDATE.Text = Format(Convert.ToDateTime(DT.Rows(0).Item("PARTYDATE")), "dd/MM/yyyy")
                    TXTINVREGNAME.Text = DTTABLE.Rows(0).Item("PURREGNAME")
                    CMBCREDITLEDGER.Text = DT.Rows(0).Item("CREDITLEDGER")
                    TXTINVTYPE.Text = DTTABLE.Rows(0).Item("INVOICETYPE")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENT")


                    If TXTINVTYPE.Text.Trim = "PURCHASE" Then

                        TXTREFNO.Text = DT.Rows(0).Item("REFNO")
                        CMBFORMNO.Text = DT.Rows(0).Item("FORM")
                        CMBTRANS.Text = DT.Rows(0).Item("TRANS")
                        TXTAGENTADD.Text = DT.Rows(0).Item("ADDRESS")

                        'FET BARCODE FROM GRN / MATREC WITH RESPECT TO FROMNO, FROMSRNO AND GRIDTYPE
                        'Dim DT1 As New DataTable
                        If DT.Rows(0).Item("TYPE") = "" Then
                            For Each dr As DataRow In DT.Rows
                                GRIDPURRET.Rows.Add(i, dr("ITEM"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), dr("BALENO"), Format(Val(dr("PCS")), "0.00"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), dr("AMT"), "", Val(dr("BILLNO")), Val(dr("GRIDSRNO")), "PURCHASE", 0)
                            Next
                        ElseIf DT.Rows(0).Item("TYPE") = "MATREC" Then
                            Dim DTMATREC As DataTable = objclspreq.search(" MATERIALRECEIPT.MATREC_NO AS SRNO, MATERIALRECEIPT_DESC.MATREC_GRIDSRNO AS GRIDSRNO, MATERIALRECEIPT.MATREC_LOTNO AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO,'') AS BALENO,ISNULL(MATERIALRECEIPT_DESC.MATREC_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(MATERIALRECEIPT_DESC.MATREC_RECDMTRS, 0) AS MTRS, ISNULL(MATERIALRECEIPT_DESC.MATREC_BARCODE,'') AS BARCODE, 'MATREC' AS GRIDTYPE,ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE,ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN ", "", "  COLORMASTER RIGHT OUTER JOIN MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN GODOWNMASTER ON MATERIALRECEIPT.MATREC_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN UNITMASTER ON MATERIALRECEIPT_DESC.MATREC_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON MATERIALRECEIPT_DESC.MATREC_QUALITYID = QUALITYMASTER.QUALITY_id ON COLORMASTER.COLOR_id = MATERIALRECEIPT_DESC.MATREC_COLORID LEFT OUTER JOIN DESIGNMASTER ON MATERIALRECEIPT_DESC.MATREC_DESIGNID = DESIGNMASTER.DESIGN_ID LEFT OUTER JOIN HSNMASTER RIGHT OUTER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id ", " AND MaterialReceipt.MATREC_NO = " & DT.Rows(0).Item("GRNNO") & " AND  MaterialReceipt.MATREC_YEARID = " & YearId & " ORDER BY MATERIALRECEIPT_DESC.MATREC_GRIDSRNO ")
                            If DTMATREC.Rows.Count > 0 Then
                                For Each dr1 As DataRow In DTMATREC.Rows
                                    GRIDPURRET.Rows.Add(i, dr1("ITEMNAME"), dr1("HSNCODE"), dr1("QUALITY"), dr1("DESIGNNO"), dr1("COLOR"), dr1("BALENO"), Format(Val(dr1("QTY")), "0.00"), dr1("UNIT"), Format(Val(dr1("MTRS")), "0.00"), Format(Val(DT.Rows(0).Item("WT")), "0.00"), Format(Val(DT.Rows(0).Item("RATE")), "0.00"), DT.Rows(0).Item("PER"), DT.Rows(0).Item("AMT"), dr1("BARCODE"), Val(DT.Rows(0).Item("BILLNO")), Val(DT.Rows(0).Item("GRIDSRNO")), "PURCHASE", 0)
                                Next
                            End If
                        Else
                            Dim DTGRN As DataTable = objclspreq.search(" GRN.GRN_NO AS SRNO, GRN_DESC.GRN_GRIDSRNO AS GRIDSRNO, GRN.GRN_CHALLANNO AS CHALLANNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(GRN_DESC.GRN_BALENO, '') AS BALENO, ISNULL(GRN_DESC.GRN_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(GRN_DESC.GRN_MTRS, 0) AS MTRS, ISNULL(GRN_DESC.GRN_BARCODE,'') AS BARCODE, GRN_DESC.GRN_GRIDTYPE AS GRIDTYPE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN_DESC.GRN_PURRATE,0) AS CCPURRATE ", "", "COLORMASTER RIGHT OUTER JOIN GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id ON COLORMASTER.COLOR_id = GRN_DESC.GRN_COLORID LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGN_ID LEFT OUTER JOIN HSNMASTER RIGHT OUTER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GRN.grn_transledgerid = TRANSLEDGERS.Acc_id", " AND GRN.GRN_NO = " & DT.Rows(0).Item("GRNNO") & " AND GRN.GRN_TYPE= '" & DT.Rows(0).Item("TYPE") & "' AND GRN.GRN_YEARID = " & YearId & " ORDER BY GRN_DESC.GRN_GRIDSRNO ")
                            If DTGRN.Rows.Count > 0 Then
                                Dim RATE As Double = 0
                                For Each dr1 As DataRow In DTGRN.Rows
                                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then RATE = Val(dr1("CCPURRATE")) Else RATE = Val(DT.Rows(0).Item("RATE"))
                                    GRIDPURRET.Rows.Add(i, dr1("ITEMNAME"), dr1("HSNCODE"), dr1("QUALITY"), dr1("DESIGNNO"), dr1("COLOR"), dr1("BALENO"), Format(Val(dr1("QTY")), "0.00"), dr1("UNIT"), Format(Val(dr1("MTRS")), "0.00"), Format(Val(DT.Rows(0).Item("WT")), "0.00"), Format(Val(RATE), "0.00"), DT.Rows(0).Item("PER"), DT.Rows(0).Item("AMT"), dr1("BARCODE"), Val(DT.Rows(0).Item("BILLNO")), Val(DT.Rows(0).Item("GRIDSRNO")), "PURCHASE", 0)
                                Next
                                cmbGodown.Text = DTGRN.Rows(0).Item("GODOWN")
                            End If
                        End If

                        i += 1

                        If DT.Rows(0).Item("ITEM").ToString <> "" And Convert.ToDateTime(PRDATE.Text).Date >= "01/07/2017" Then
                            Dim DTHSN As DataTable = objclspreq.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & DT.Rows(0).Item("ITEM") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")

                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                                TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                                TXTIGSTPER.Text = 0
                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                            End If
                        End If

                        GRIDPURRET.FirstDisplayedScrollingRowIndex = GRIDPURRET.RowCount - 1
                        getsrno(GRIDPURRET)
                        total()
                    End If

                Next


                CMBNAME.Focus()

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPURRET.RowCount = 0
                TEMPPRNO = Val(tstxtbillno.Text)
                If TEMPPRNO > 0 Then
                    EDIT = True
                    PurchaseReturn_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            GRIDPURRET.RowCount = 0
LINE1:
            TEMPPRNO = Val(TXTPRNO.Text) - 1
            If TEMPPRNO > 0 Then
                EDIT = True
                PurchaseReturn_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPURRET.RowCount = 0 And TEMPPRNO > 1 Then
                TXTPRNO.Text = TEMPPRNO
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
            GRIDPURRET.RowCount = 0
LINE1:
            TEMPPRNO = Val(TXTPRNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTPRNO.Text.Trim
            clear()
            If Val(TXTPRNO.Text) - 1 >= TEMPPRNO Then
                EDIT = True
                PurchaseReturn_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPURRET.RowCount = 0 And TEMPPRNO < MAXNO Then
                TXTPRNO.Text = TEMPPRNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE = 'ACCOUNTS' and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                End If
                GETHSNCODE()
                FILLGRIDINVOICE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try


            If ACTUALINVDATE.Text = "__/__/____" Then Exit Sub
            Dim ITEMNAME As String = ""

            If CMBITEM.Text.Trim <> "" Then
                ITEMNAME = CMBITEM.Text.Trim
            ElseIf GRIDPURRET.RowCount > 0 Then
                ITEMNAME = GRIDPURRET.Rows(0).Cells(gitemname.Index).Value
            End If

            If Convert.ToDateTime(ACTUALINVDATE.Text).Date >= "01/07/2017" And ITEMNAME <> "" Then
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID ", " AND ITEMMASTER.ITEM_NAME= '" & GRIDPURRET.Rows(0).Cells(gitemname.Index).Value & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & ITEMNAME & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If DT.Rows.Count > 0 Then

                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()

                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                        TXTIGSTPER.Text = 0
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    Else
                        TXTCGSTPER.Text = 0
                        TXTSGSTPER.Text = 0
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    End If
                End If
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE = 'ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPPRNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub PRINTREPORT(ByVal PRNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Purchase Return?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJPUR As New PurchaseInvoiceDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "PURRETURN"
                OBJPUR.WHERECLAUSE = "{PURCHASERETURN.PR_NO}=" & Val(PRNO) & " and {PURCHASERETURN.PR_yearid}=" & YearId
                OBJPUR.Show()
            End If
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

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If Convert.ToDateTime(PRDATE.Text).Date < DNBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(DNBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Purchase Return?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJEMB As New ClsPurchaseReturn

                ALPARAVAL.Add(TEMPPRNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(TXTINVREGNAME.Text.Trim)

                OBJEMB.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJEMB.Delete()
                MsgBox("Purchase Return Deleted Succesfully")
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

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdot(e, TXTMTRS, Me)
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTRATE, Me)
    End Sub

    Sub fillgrid()

        GRIDPURRET.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDPURRET.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEM.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), 0.0, Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.00"), TXTBARCODE.Text.Trim, 0, 0, "", 0)
            getsrno(GRIDPURRET)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPURRET.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDPURRET.Item(gitemname.Index, TEMPROW).Value = CMBITEM.Text.Trim
            GRIDPURRET.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim

            GRIDPURRET.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDPURRET.Item(GDESIGNNO.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDPURRET.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDPURRET.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            GRIDPURRET.Item(gQty.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDPURRET.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim
            GRIDPURRET.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDPURRET.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDPURRET.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDPURRET.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False

        End If

        total()
        GRIDPURRET.FirstDisplayedScrollingRowIndex = GRIDPURRET.RowCount - 1

        TXTSRNO.Clear()
        CMBITEM.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTQTY.Clear()
        CMBQTYUNIT.Text = ""
        TXTMTRS.Clear()
        TXTRATE.Clear()
        CMBPER.Text = ""
        TXTAMT.Clear()
        TXTHSNCODE.Clear()

        If GRIDPURRET.RowCount > 0 Then
            TXTSRNO.Text = Val(GRIDPURRET.Rows(GRIDPURRET.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If
        TXTSRNO.Focus()

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

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()

        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If
        TXTCHGSSRNO.Focus()
    End Sub

    Private Sub TXTAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTAMT.Validated
        If CMBITEM.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And Val(TXTAMT.Text.Trim) > 0 Then

            If GRIDDOUBLECLICK = False Then
                If EDIT = True Then
                    'GET LAST BARCODE SRNO
                    Dim LSRNO As Integer = 0
                    Dim RSRNO As Integer = 0
                    Dim SNO As Integer = 0
                    LSRNO = InStr(GRIDPURRET.Rows(GRIDPURRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    RSRNO = InStr(LSRNO + 1, GRIDPURRET.Rows(GRIDPURRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                    SNO = GRIDPURRET.Rows(GRIDPURRET.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                    TXTBARCODE.Text = "PR-" & Val(TXTPRNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                Else
                    TXTBARCODE.Text = "PR-" & Val(TXTPRNO.Text.Trim) & "/" & GRIDPURRET.RowCount + 1 & "/" & YearId
                End If
            End If

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

            If Val(TXTRATE.Text.Trim) <= 0 Then
                MsgBox("Please Fill Rate")
                TXTRATE.Focus()
                Exit Sub
            End If

        End If
        'MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
        'Exit Sub
    End Sub

    Sub EDITROW()
        Try
            If ClientName = "SVS" Then Exit Sub
            If GRIDPURRET.CurrentRow.Index >= 0 And GRIDPURRET.Item(gsrno.Index, GRIDPURRET.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPURRET.Item(gsrno.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                CMBITEM.Text = GRIDPURRET.Item(gitemname.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDPURRET.Item(GHSNCODE.Index, GRIDPURRET.CurrentRow.Index).Value.ToString

                CMBQUALITY.Text = GRIDPURRET.Item(GQUALITY.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDPURRET.Item(GDESIGNNO.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDPURRET.Item(gcolor.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDPURRET.Item(GBALENO.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPURRET.Item(gQty.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                CMBQTYUNIT.Text = GRIDPURRET.Item(gqtyunit.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDPURRET.Item(GMTRS.Index, GRIDPURRET.CurrentRow.Index).Value.ToString

                TXTRATE.Text = GRIDPURRET.Item(GRATE.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDPURRET.Item(GPER.Index, GRIDPURRET.CurrentRow.Index).Value.ToString
                TXTAMT.Text = GRIDPURRET.Item(GAMT.Index, GRIDPURRET.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDPURRET.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURRET_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURRET.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub CMBPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPER.Validating
        Try
            If CMBPER.Text = "Mtrs" Then
                TXTAMT.Text = Val(TXTMTRS.Text) * Val(TXTRATE.Text)
            Else
                TXTAMT.Text = Val(TXTQTY.Text) * Val(TXTRATE.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURRET_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPURRET.CellValidating
        Dim colNum As Integer = GRIDPURRET.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GRATE.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPURRET.CurrentCell.Value = Nothing Then GRIDPURRET.CurrentCell.Value = "0.00"
                    GRIDPURRET.CurrentCell.Value = Convert.ToDecimal(GRIDPURRET.Item(colNum, e.RowIndex).Value)
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
    End Sub

    Private Sub GRIDPURRET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURRET.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURRET.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDPURRET.Rows.RemoveAt(GRIDPURRET.CurrentRow.Index)
                getsrno(GRIDPURRET)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated, TXTMTRS.Validated, TXTQTY.Validated
        total()
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
                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
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

    Private Sub TXTBARCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                Dim OBJCMN As New ClsCommon
        '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND MTRS > 0 AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    cmbGodown.Text = DT.Rows(0).Item("GODOWN")

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
        '                    For Each ROW As DataGridViewRow In GRIDPURRET.Rows
        '                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
        '                    Next

        '                    'GET HSN
        '                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER LEFT OUTER JOIN HSNMASTER ON HSN_ID = ITEM_HSNCODEID ", " AND ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)


        '                    GRIDPURRET.Rows.Add(GRIDPURRET.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), Format(Val(DT.Rows(0).Item("PCS")), "0"), DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), 0, 0, "Mtrs", 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
        '                    total()
        'LINE1:
        '                    TXTBARCODE.Clear()
        '                End If
        '            End If


        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub PurchaseReturn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'If ClientName = "MAHAVIR" Or ClientName = "PURVITEX" Or ClientName = "CC" Or ClientName = "SHREEDEV" Then ALLOWMANUALBILLNO = True
        If ClientName = "MSANCHITKUMAR" Then Me.Close()
        If ClientName = "SVS" Or ClientName = "SAFFRON" Then
            TXTPARTYBILLNO.ReadOnly = False
            TXTPARTYBILLNO.BackColor = Color.LemonChiffon
            PARTYBILLDATE.ReadOnly = False
            PARTYBILLDATE.BackColor = Color.LemonChiffon
        End If

        'KEEP IT OPEN FOR SVS
    End Sub

    Private Sub PARTYBILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PARTYBILLDATE.GotFocus
        PARTYBILLDATE.SelectAll()
    End Sub

    Private Sub PARTYBILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PARTYBILLDATE.Validating
        Try
            If PARTYBILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PARTYBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
                BILLDATE.Text = PARTYBILLDATE.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BILLDATE.GotFocus
        BILLDATE.SelectAll()
    End Sub

    Private Sub BILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BILLDATE.Validating
        Try
            If BILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRDATE.GotFocus
        PRDATE.SelectAll()
    End Sub

    Private Sub PRDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PRDATE.Validating
        Try
            If PRDATE.Text = "__/__/____" Then
                EP.SetError(PRDATE, " Please Enter Proper Date")
                e.Cancel = True
                Exit Sub
            Else
                If Not datecheck(PRDATE.Text) Then
                    EP.SetError(PRDATE, "Date not in Accounting Year")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
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
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSAMT, Me)
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

    Private Sub TXTBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPRNO.KeyPress
        numkeypress(e, TXTPRNO, Me)
    End Sub

    Private Sub TXTPRNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPRNO.Validating
        Try
            If (Val(TXTPRNO.Text.Trim) <> 0 And EDIT = False) Or (EDIT = True And TEMPPRNO <> Val(TXTPRNO.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASERETURN.PR_no, 0) AS PRNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PURCHASERETURN ON REGISTERMASTER.register_id = PURCHASERETURN.PR_PURREGID AND REGISTERMASTER.register_cmpid = PURCHASERETURN.PR_CMPID AND REGISTERMASTER.register_yearid = PURCHASERETURN.PR_YEARID AND REGISTERMASTER.register_locationid = PURCHASERETURN.PR_LOCATIONID", "  AND PURCHASERETURN.PR_NO=" & TXTPRNO.Text.Trim & " AND PURCHASERETURN.PR_cmpid = " & CmpId & " AND PURCHASERETURN.PR_locationid = " & Locationid & " AND PURCHASERETURN.PR_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    MsgBox("Purchase Return No Already Exist")
                    e.Cancel = True
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

    Private Sub CMBITEM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Validated
        Try
            If CMBITEM.Text.Trim <> "" And Convert.ToDateTime(ACTUALINVDATE.Text).Date >= "01/07/2017" Then
                GETHSNCODE()
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            'If Val(TXTQTY.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
            If Val(TXTRATE.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")
                End If

            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPPRNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(PRNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJPR As New PurchaseInvoiceDesign
            OBJPR.MdiParent = MDIMain
            OBJPR.DIRECTPRINT = True
            OBJPR.FRMSTRING = "PURRETURN"
            OBJPR.DIRECTMAIL = True
            OBJPR.PARTYNAME = CMBNAME.Text.Trim
            OBJPR.AGENTNAME = CMBAGENT.Text.Trim
            OBJPR.WHERECLAUSE = "{PURCHASERETURN.PR_NO}=" & Val(PRNO) & " and {PURCHASERETURN.PR_yearid}=" & YearId
            OBJPR.PURRETNO = PRNO
            OBJPR.NOOFCOPIES = 1
            OBJPR.Show()
            OBJPR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PURRET_" & Val(PRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("PURRET_" & Val(PRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        total()
    End Sub

    Private Sub CMBCREDITLEDGER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCREDITLEDGER.Enter
        Try
            If CMBCREDITLEDGER.Text.Trim = "" Then fillname(CMBCREDITLEDGER, EDIT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCREDITLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCREDITLEDGER.Validating
        Try
            If CMBCREDITLEDGER.Text.Trim <> "" Then namevalidate(CMBCREDITLEDGER, CMBCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            Throw ex
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

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(sender As Object, e As CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(sender As Object, e As CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
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

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND MTRS > 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    cmbGodown.Text = DT.Rows(0).Item("GODOWN")

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDPURRET.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    'GET HSN
                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_CODE,'') AS HSNCODE", "", "ITEMMASTER LEFT OUTER JOIN HSNMASTER ON HSN_ID = ITEM_HSNCODEID ", " AND ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)


                    GRIDPURRET.Rows.Add(GRIDPURRET.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), Format(Val(DT.Rows(0).Item("PCS")), "0"), DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), 0, 0, "Mtrs", 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
                    total()
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

    Private Sub ACTUALINVDATE_Validating(sender As Object, e As CancelEventArgs) Handles ACTUALINVDATE.Validating
        Try
            If ACTUALINVDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(ACTUALINVDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ACTUALINVDATE_Validated(sender As Object, e As EventArgs) Handles ACTUALINVDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTCHALLAN_Click(sender As Object, e As EventArgs) Handles CMDSELECTCHALLAN.Click
        Try
            Dim OBJCMN As New ClsCommon
            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If ClientName <> "KCRAYON" And ClientName <> "YASHVI" And ClientName <> "SUPRIYA" Then
                If CMBNAME.Text = "" Then
                    MsgBox("Select Party Name First !", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            Dim DTTABLE As DataTable
            Dim OBJSELECTPO As New SelectReturnChallan
            OBJSELECTPO.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTPO.FRMSTRING = "PURRETURN"
            OBJSELECTPO.ShowDialog()

            DTTABLE = OBJSELECTPO.DT1

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "PRCHNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTPRCHNO.Text.Trim = "" Then
                        TXTPRCHNO.Text = DTR("PRCHNO").ToString
                    Else
                        TXTPRCHNO.Text = TXTPRCHNO.Text & "," & DTR("PRCHNO").ToString
                    End If
                Next

                CMBNAME.Text = DTTABLE.Rows(0).Item("NAME")
                CMBNAME.Enabled = False
                TXTSTATECODE.Text = DTTABLE.Rows(0).Item("STATECODE")
                TXTGSTIN.Text = DTTABLE.Rows(0).Item("GSTIN")

                Dim DT1 As DataTable = OBJCMN.search(" PURCHASERETURNCHALLAN.PRCH_NO AS PRCHNO, ISNULL(ITEMMASTER.item_name, '') AS ITEM, '' AS QUALITY, ISNULL(DESIGN_NO,'') AS DESIGN, '' AS COLOR, SUM(ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_QTY, 0)) AS PCS, SUM(ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_MTRS, 0)) AS MTRS , ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, 0 AS GDNSRNO, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_BALENO, '') AS BALENO,ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_GRIDREMARKS, '') AS PRINTDESC, ISNULL(UNIT_ABBR,'') AS UNIT ", "", " PURCHASERETURNCHALLAN INNER JOIN PURCHASERETURNCHALLAN_DESC ON PURCHASERETURNCHALLAN.PRCH_NO = PURCHASERETURNCHALLAN_DESC.PRCH_NO AND PURCHASERETURNCHALLAN.PRCH_YEARID = PURCHASERETURNCHALLAN_DESC.PRCH_YEARID LEFT OUTER JOIN ITEMMASTER ON PURCHASERETURNCHALLAN_DESC.PRCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON PURCHASERETURNCHALLAN_DESC.PRCH_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON PURCHASERETURNCHALLAN_DESC.PRCH_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN PIECETYPEMASTER ON PURCHASERETURNCHALLAN_DESC.PRCH_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON PRCH_QTYUNITID = UNIT_ID ", " AND PURCHASERETURNCHALLAN.PRCH_NO IN(" & TXTPRCHNO.Text.Trim & ")  and PURCHASERETURNCHALLAN.PRCH_YEARID = " & YearId & " GROUP BY PURCHASERETURNCHALLAN.PRCH_NO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') , ISNULL(ITEMMASTER.item_name, '') ,ISNULL(DESIGN_NO,'') , ISNULL(HSN_CODE,'') , ISNULL(HSN_CGST,0) , ISNULL(HSN_SGST,0) , ISNULL(HSN_IGST,0) ,ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_BALENO, '') ,ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_GRIDREMARKS, ''), ISNULL(UNIT_ABBR,'')  order by PURCHASERETURNCHALLAN.PRCH_NO ")
                If DT1.Rows.Count > 0 Then
                    For Each dr As DataRow In DT1.Rows

                        GRIDPURRET.Rows.Add(0, dr("ITEM"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGN"), dr("COLOR"), dr("BALENO"), Format(Val(dr("PCS")), "0.00"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), 0, 0, "Mtrs", 0, "", dr("PRCHNO"), 0, "", 0)

                        If dr("ITEM").ToString <> "" And Convert.ToDateTime(PRDATE.Text).Date >= "01/07/2017" Then
                            Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEM") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTCGSTPER.Text = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                TXTSGSTPER.Text = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                TXTIGSTPER.Text = 0
                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                TXTIGSTPER.Text = Val(DTHSN.Rows(0).Item("IGSTPER"))
                            End If
                        End If
                    Next

                End If

                GRIDPURRET.FirstDisplayedScrollingRowIndex = GRIDPURRET.RowCount - 1
                If GRIDPURRET.RowCount > 0 Then
                    GRIDPURRET.Focus()
                    GRIDPURRET.CurrentCell = GRIDPURRET.Rows(0).Cells(GRATE.Index)
                End If
                getsrno(GRIDPURRET)
                total()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLADJGRID()
        Try
            EP.Clear()
            If Not AMOUNTVALIDATE() Then
                TXTADJSRNO.Focus()
                Exit Sub
            End If

            Dim AMT As Double = TXTADJAMT.Text

            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            If CMBPAYTYPE.Text = "Against Bill" And Val(TXTADJAMT.Text) > Val(LBLBILLTOTAL.Text) And Val(LBLBILLTOTAL.Text) <> 0 Then
                TXTADJAMT.Text = Val(LBLBILLTOTAL.Text)
            End If
            'End If
            If GRIDADJDOUBLECLICK = False Then
                GRIDPAYMENT.Rows.Add(TXTADJSRNO.Text.Trim, CMBPAYTYPE.Text.Trim, CMBBILLNO.Text.Trim, TXTNARR.Text.Trim, Val(TXTADJAMT.Text.Trim), 0, 0, 0, Val(TXTADJAMT.Text.Trim))
                getsrno(GRIDPAYMENT)
            Else
                GRIDPAYMENT.Item(GADJSRNO.Index, TEMPADJROW).Value = TXTADJSRNO.Text.Trim
                GRIDPAYMENT.Item(gpaytype.Index, TEMPADJROW).Value = CMBPAYTYPE.Text.Trim
                GRIDPAYMENT.Item(gbillno.Index, TEMPADJROW).Value = CMBBILLNO.Text.Trim
                GRIDPAYMENT.Item(gdesc.Index, TEMPADJROW).Value = TXTNARR.Text.Trim
                GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value = Val(TXTADJAMT.Text.Trim)

                GRIDADJDOUBLECLICK = False
            End If


            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            TXTADJAMT.Text = Format(Val(AMT) - Val(TXTADJAMT.Text), "0.00")
            'Else
            '    TXTADJAMT.Clear()
            'End If

            total()
            GRIDPAYMENT.FirstDisplayedScrollingRowIndex = GRIDPAYMENT.RowCount - 1

            TXTADJSRNO.Text = GRIDPAYMENT.RowCount + 1
            CMBPAYTYPE.SelectedIndex = 0
            CMBBILLNO.Text = ""
            LBLBILLTOTAL.Text = ""
            CMBBILLNO.Enabled = False
            TXTNARR.Clear()
            'TXTADJAMT.Clear() DONT CLEAR THE AMT COZ BAL AMT OF THE CHQ COMES AGAIN
            TXTADJSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If EDIT = False Then
                If GRIDADJDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(txtgrandtotal.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(txtgrandtotal.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If CMBPAYTYPE.Text.Trim = "Against Bill" Then
                        If Val(TXTADJAMT.Text) > Val(LBLBILLTOTAL.Text) Then
                            EP.SetError(TXTADJAMT, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If

            ElseIf EDIT = True Then
                If GRIDADJDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(txtgrandtotal.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If


                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(txtgrandtotal.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If CMBPAYTYPE.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT", "", " (SELECT SUM(PURCHASERETURN_BILLDESC.PR_amt)  AS PAYAMT, PR_BILLINITIALS AS BILLINITIALS, PR_NO as PAYNO, PR_cmpid AS CMPID, 0 AS LOCATIONID, PR_yearid AS YEARID FROM PURCHASERETURN_BILLDESC WHERE PR_paytype = 'Against Bill' GROUP BY PR_BILLINITIALS, PR_no, PR_CMPID , PR_YEARID) AS T ", " AND T.PAYNO =  " & TXTPRNO.Text.Trim & " AND T.BILLINITIALS ='" & CMBBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(LBLBILLTOTAL.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT"))
                        End If

                        If Val(TXTADJAMT.Text) > Val(MAXALLOWEDVALUE) Then
                            EP.SetError(TXTADJAMT, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDPAYMENT_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPAYMENT.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDADJDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If
            GRIDPAYMENT.Rows.RemoveAt(GRIDPAYMENT.CurrentRow.Index)
            total()
            getsrno(GRIDPAYMENT)
        ElseIf e.KeyCode = Keys.F5 Then
            EDITADJROW()
        End If
    End Sub

    Sub EDITADJROW()
        Try
            If GRIDPAYMENT.CurrentRow.Index >= 0 And GRIDPAYMENT.Item(GADJSRNO.Index, GRIDPAYMENT.CurrentRow.Index).Value <> Nothing Then
                GRIDADJDOUBLECLICK = True
                TEMPADJROW = GRIDPAYMENT.CurrentRow.Index
                TXTADJSRNO.Text = GRIDPAYMENT.Item(GADJSRNO.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                CMBPAYTYPE.Text = GRIDPAYMENT.Item(gpaytype.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                CMBBILLNO.Text = GRIDPAYMENT.Item(gbillno.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTNARR.Text = GRIDPAYMENT.Item(gdesc.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTADJAMT.Text = GRIDPAYMENT.Item(GADJAMT.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTADJSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAYMENT_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPAYMENT.CellDoubleClick
        Try

            EDITADJROW()

            If CMBBILLNO.Text.Trim <> "" Then
                CMBBILLNO.Enabled = True

                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL  UNION ALL SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_BALANCE AS BALANCE, PURCHASEMASTER.BILL_CMPID AS CMPID , PURCHASEMASTER.BILL_LOCATIONID AS LOCATIONID , PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE UNION ALL SELECT CREDITNOTEMASTER.CN_INITIALS AS BILLINITIALS, CREDITNOTEMASTER.CN_BALANCE AS BALANCE, CN_CMPID AS CMPID, 0 AS LOCATIONID, CN_YEARID AS YEARID FROM CREDITNOTEMASTER WHERE CN_date >= '07/01/2017' UNION ALL SELECT CAST(RECEIPTMASTER_DESC.RECEIPT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, RECEIPTMASTER_DESC.RECEIPT_BALANCE AS BALANCE, RECEIPT_CMPID AS CMPID , 0 AS LOCATIONID , RECEIPT_YEARID AS YEARID FROM RECEIPTMASTER_DESC WHERE RECEIPT_paytype = 'New Ref') AS T", " AND T.BILLINITIALS = '" & CMBBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    LBLBILLTOTAL.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADJAMT_Validating(sender As Object, e As CancelEventArgs) Handles TXTADJAMT.Validating
        Try
            If TXTADJSRNO.Text.Trim.Length = 0 Then TXTADJSRNO_GotFocus(sender, e)

            If TXTADJSRNO.Text.Trim.Length > 0 And Val(TXTADJAMT.Text) > 0 Then
                If CMBPAYTYPE.Text = "Against Bill" And CMBBILLNO.Text.Trim = "" Then
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "TEXTRADE")
                    CMBPAYTYPE.Focus()
                    Exit Sub
                End If

                If CMBBILLNO.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                        If (ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And GRIDADJDOUBLECLICK = False) Or (GRIDADJDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And ROW.Index <> TEMPADJROW) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "TEXTRADE")
                            CMBPAYTYPE.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                FILLADJGRID()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADJSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADJSRNO.GotFocus
        If GRIDADJDOUBLECLICK = False Then TXTADJSRNO.Text = GRIDPAYMENT.RowCount + 1
    End Sub

    Private Sub TXTADJAMT_GotFocus(sender As Object, e As EventArgs) Handles TXTADJAMT.GotFocus
        TXTADJAMT.SelectAll()
    End Sub

    Private Sub GRIDBILL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBILL.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        CMBPAYTYPE.Text = "Against Bill"
                        CMBBILLNO.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        CMBBILLNO.Enabled = True
                        TXTNARR.Clear()
                        LBLBILLTOTAL.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBALAMT").Index).Value

                        Dim A As System.ComponentModel.CancelEventArgs
                        TXTADJAMT_Validating(sender, A)

                    End If
                    total()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDINVOICE()
        Try
            GRIDBILL.DataSource = Nothing
            TXTINVTOTAL.Clear()
            Dim objpayment As New ClsPaymentMaster
            Dim DT As New DataTable
            DT = objpayment.GETBILLS(CmpId, CMBNAME.Text.Trim, Locationid, YearId)
            If DT.Rows.Count > 0 Then SETGRIDINVOICE(DT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SETGRIDINVOICE(ByVal DT As DataTable)
        Try
            'DT.DefaultView.Sort = "BILLDATE, BILLNO ASC"
            GRIDBILL.DataSource = DT
            If a = 0 Then
                GRIDBILL.Columns.Insert(0, col)
                a = 1
            End If

            GRIDBILL.Columns(0).Width = 40
            GRIDBILL.Columns(0).Name = "INVCHK"
            GRIDBILL.Columns(0).HeaderText = ""
            GRIDBILL.Columns(0).ReadOnly = True

            GRIDBILL.Columns(1).Width = 100
            GRIDBILL.Columns(1).Name = "INVBILLINITIALS"
            GRIDBILL.Columns(1).HeaderText = "Bill No."
            GRIDBILL.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GRIDBILL.Columns(1).ReadOnly = True

            GRIDBILL.Columns(2).Width = 80
            GRIDBILL.Columns(2).Name = "REFNO"
            GRIDBILL.Columns(2).HeaderText = "Party Bill"
            GRIDBILL.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            GRIDBILL.Columns(2).ReadOnly = True

            GRIDBILL.Columns(3).Width = 80
            GRIDBILL.Columns(3).Name = "INVBILLDATE"
            GRIDBILL.Columns(3).HeaderText = "Bill Date"
            GRIDBILL.Columns(3).ReadOnly = True

            GRIDBILL.Columns(4).Width = 100
            GRIDBILL.Columns(4).Name = "INVBALAMT"
            GRIDBILL.Columns(4).HeaderText = "Bal. Amt"
            GRIDBILL.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(4).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(3).ReadOnly = True

            GRIDBILL.Columns(5).Width = 100
            GRIDBILL.Columns(5).Name = "INVBILLAMT"
            GRIDBILL.Columns(5).HeaderText = "Bill Amt"
            GRIDBILL.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(5).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(5).ReadOnly = True

            GRIDBILL.Columns(6).Visible = False
            GRIDBILL.Columns(6).Name = "INVBILLTYPE"

            GRIDBILL.Columns(7).Visible = False
            GRIDBILL.Columns(7).Name = "INVBILLNO"

            GRIDBILL.Columns(8).Visible = False
            GRIDBILL.Columns(8).Name = "INVREGNAME"

            GRIDBILL.Columns(9).Visible = False
            GRIDBILL.Columns(9).Name = "INVCUSNAME"

            GRIDBILL.Columns(10).Width = 60
            GRIDBILL.Columns(10).Name = "INVTDSAMT"
            GRIDBILL.Columns(10).HeaderText = "TDS"
            GRIDBILL.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(10).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(10).ReadOnly = True

            GRIDBILL.Columns(11).Visible = False
            GRIDBILL.Columns(11).Name = "DISPUTE"

            GRIDBILL.Columns(12).Width = 60
            GRIDBILL.Columns(12).Name = "DISCAMT"
            GRIDBILL.Columns(12).HeaderText = "Disc"
            GRIDBILL.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(12).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(12).ReadOnly = True


            GRIDBILL.Columns(13).Width = 80
            GRIDBILL.Columns(13).Name = "ENTRYDATE"
            GRIDBILL.Columns(13).HeaderText = "Entry Dt"
            GRIDBILL.Columns(13).ReadOnly = True
            If ClientName = "NVAHAN" Then GRIDBILL.Columns(13).Visible = True Else GRIDBILL.Columns(13).Visible = False


            For Each ROW As DataGridViewRow In GRIDBILL.Rows
                If ClientName = "NVAHAN" AndAlso IsDBNull(ROW.Cells(12).Value) = False AndAlso Val(ROW.Cells(12).Value) = 0 Then ROW.DefaultCellStyle.BackColor = Color.Yellow
                If Convert.ToBoolean(ROW.Cells(11).Value) = True Then ROW.DefaultCellStyle.BackColor = Color.LightGreen
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMBBILLNO()
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.Items.Clear()
        For Each row As DataGridViewRow In GRIDBILL.Rows
            If Convert.ToBoolean(row.Cells(GRIDBILL.Columns("INVCHK").Index).Value) = True Then
                CMBBILLNO.Items.Add(row.Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value.ToString())
            End If
        Next
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.SelectedIndex = (0)
    End Sub

    Private Sub GRIDBILL_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBILL.KeyDown
        Dim ARGS As New DataGridViewCellEventArgs(GRIDBILL.CurrentCell.ColumnIndex, GRIDBILL.CurrentRow.Index)
        If e.KeyCode = Keys.F8 Then Call GRIDBILL_CellClick(sender, ARGS)
    End Sub


End Class