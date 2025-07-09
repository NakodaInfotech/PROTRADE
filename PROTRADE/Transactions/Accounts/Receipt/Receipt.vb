
Imports BL

Public Class Receipt

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDDESCDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPRECEIPTNO As Integer
    Public TEMPREGNAME As String
    Dim recregabbr, recreginitial As String
    Dim recregid As Integer
    Dim TEMPROW, TEMPDESCROW As Integer
    Dim temprecodate As Date
    Dim CHQNO As String = ""
    Public Shared SELECTEDBILLNO As String

    'REQD FOR AUTO DATA POPULATION AS PER ELYSIUM'S REQUIREMENT
    Public TEMPAUTOENTRY As Boolean = False
    Public TEMPAMT As Double
    Public TEMPNAME As String
    Public TEMPBILLNO As String
    Dim ALLOWMANUALRECNO As Boolean = False



    'FOR ADDING NEW CHKCOL IN GRIDBILL
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Sub GETBALANCE()
        Try

            Dim USERACCOUNTSADD, USERACCOUNTSEDIT, USERACCOUNTSVIEW, USERACCOUNTSDELETE As Boolean
            Dim DTACCOUNTSROW() As DataRow
            DTACCOUNTSROW = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERACCOUNTSADD = DTACCOUNTSROW(0).Item(1)
            USERACCOUNTSEDIT = DTACCOUNTSROW(0).Item(2)
            USERACCOUNTSVIEW = DTACCOUNTSROW(0).Item(3)
            USERACCOUNTSDELETE = DTACCOUNTSROW(0).Item(4)


            LBLBAL.Text = "0.00"
            LBLACCBAL.Text = "0.00"
            If USERACCOUNTSVIEW = False Then
                LBLBAL.Visible = False
                LBLACCBAL.Visible = False
            End If


            'SALE BALANCE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS SALEBAL, isnull(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname AND TRIALBALANCE.acc_cmpid = LEDGERS.Acc_cmpid AND TRIALBALANCE.acc_locationid = LEDGERS.Acc_locationid AND TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & cmbaccname.Text.Trim & "' AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLACCBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("SALEBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLACCBAL.ForeColor = Color.Red
                Else
                    LBLACCBAL.ForeColor = Color.Green
                End If
            End If


            DT = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS SALEBAL, isnull(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname AND TRIALBALANCE.acc_cmpid = LEDGERS.Acc_cmpid AND TRIALBALANCE.acc_locationid = LEDGERS.Acc_locationid AND TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("SALEBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLBAL.ForeColor = Color.Red
                Else
                    LBLBAL.ForeColor = Color.Green
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        If ALLOWMANUALRECNO = True Then
            txtaccno.ReadOnly = False
            txtaccno.BackColor = Color.LemonChiffon
        Else
            txtaccno.ReadOnly = True
            txtaccno.BackColor = Color.Linen
        End If

        'clearing textboxes
        EP.Clear()
        txtchqamt.ReadOnly = False
        tstxtbillno.Clear()
        TXTMOBILENO.Clear()

        LBLACCBAL.Text = 0.0
        LBLBAL.Text = 0.0

        lblbilltotal.Text = ""
        cmbname.Text = ""
        cmbname.Enabled = True
        cmbaccname.Enabled = True
        RECODATE.Enabled = True
        'AS THEY WANT TO KEEP THE ACCOUNTNAME SAME
        'cmbaccname.Text = ""

        txtchqamt.Clear()
        txtchqno.Clear()
        txtcramt.Clear()
        txtledgerbal.Clear()
        txtchqbal.Clear()
        lblbaldrcr.Text = ""
        tstxtbillno.Clear()
        txtbillno.Clear()
        chkselectall.Checked = False
        CHKPDC.Checked = False
        TXTINVTOTAL.Clear()
        txttotal.Clear()
        txtdesctotal.Clear()
        txtremarks.Clear()
        TXTOURREMARKS.Clear()
        txtinwords.Clear()
        txtsrno.Clear()
        cmbpaytype.SelectedIndex = 0
        txtamt.Clear()
        cmbbillno.Text = ""
        txtnarr.Clear()
        cmbbillno.Items.Clear()
        cmbbillno.Enabled = False
        txtsrno.Clear()

        CHKRECO.CheckState = CheckState.Unchecked
        RECODATE.Value = Now.Date

        LBLRECO.Visible = False
        RECODATE.Visible = False
        CMDRECO.Visible = False

        txtdescsrno.Clear()
        cmbledgername.Text = ""
        txtdescnarr.Clear()
        txtdescamt.Clear()

        CMBPARTYBANK.Text = ""

        recregabbr = ""
        recreginitial = ""

        gridbill.DataSource = Nothing
        gridpayment.RowCount = 0

        Gbdesc.Enabled = False
        gridpaydesc.RowCount = 0
        gridpayment.RowCount = 0
        GRIDDESC.RowCount = 0
        getmaxno_receiptmaster()

        'AS THEY WANT TO KEEP THE DATE SAME
        'accdate.Value = now.date

        EDIT = False
        GRIDDOUBLECLICK = False
        GRIDDESCDOUBLECLICK = False

        lbllocked.Visible = False
        PBlock.Visible = False
        LBLSMS.Visible = False

    End Sub

    Sub getmaxno_receiptmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(RECEIPT_NO),0) + 1 ", "RECEIPTMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = RECEIPT_REGISTERID AND REGISTER_CMPID = RECEIPT_CMPID AND REGISTER_LOCATIONID = RECEIPT_LOCATIONID AND REGISTER_YEARID = RECEIPT_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'RECEIPT' AND RECEIPT_cmpid=" & CmpId & " AND RECEIPT_LOCATIONid=" & Locationid & " AND RECEIPT_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtaccno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and groupmaster.group_SECONDARY = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.GotFocus
        txtamt.SelectAll()
    End Sub

    Private Sub txtinwords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinwords.GotFocus
        txtinwords.SelectAll()
    End Sub

    Private Sub txttotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.GotFocus
        txttotal.SelectAll()
    End Sub

    Private Sub txtaccno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaccno.GotFocus
        txtaccno.SelectAll()
    End Sub

    Private Sub txtremarks_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.GotFocus
        txtremarks.SelectAll()
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        numdotkeypress(e, txtamt, Me)
    End Sub

    Private Sub txttotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        numdotkeypress(e, txttotal, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True


            'OPEN THIS LOCK AS USER CAN CHANGE THE NAME BUT NOT THE AMOUNT
            'DONE BY GULKIT
            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Reco Done, Receipt Locked")
            '    BLN = False
            'End If

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Select Register Name")
                BLN = False
            End If

            If ALLOWMANUALRECNO = True Then
                If txtaccno.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon

                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(RECEIPTMASTER.RECEIPT_no,0) AS PAYMENTNO, REGISTERMASTER.register_name AS REGNAME", "", " REGISTERMASTER INNER JOIN RECEIPTMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.RECEIPT_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.RECEIPT_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.RECEIPT_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.RECEIPT_yearid ", "  AND RECEIPTMASTER.RECEIPT_no=" & txtaccno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND RECEIPTMASTER.RECEIPT_cmpid = " & CmpId & " AND RECEIPTMASTER.RECEIPT_locationid = " & Locationid & " AND RECEIPTMASTER.RECEIPT_yearid = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(txtaccno, "Receipt No Already Exist")
                        BLN = False
                    End If
                End If
            End If


            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, "Select Name")
                BLN = False
            End If

            For Each ROW As DataGridViewRow In gridpayment.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" And ROW.Cells(gbillno.Index).Value = "" Then
                    EP.SetError(cmbregister, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    BLN = False
                End If

                If ROW.Cells(gpaytype.Index).Value = "New Ref" And ROW.Cells(gdesc.Index).Value = "" Then
                    EP.SetError(cmbregister, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    BLN = False
                End If
            Next

            If cmbaccname.Text.Trim.Length = 0 Then
                EP.SetError(cmbaccname, "Select Account Name")
                BLN = False
            End If

            If gridpayment.RowCount = 0 Then
                EP.SetError(txtchqno, "Enter Receipt Details")
                BLN = False
            End If

            If txtchqamt.Text.Trim.Length = 0 Then
                EP.SetError(txtchqamt, "Enter Specified Amt")
                BLN = False
            End If

            If Val(txtchqamt.Text.Trim) <> Val(txttotal.Text.Trim) Then
                EP.SetError(txttotal, "Total does not match Specified Amt")
                BLN = False
            End If

            Dim OBJCMN1 As New ClsCommon
            Dim DT As DataTable = OBJCMN1.search(" GROUP_SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Bank A/C" Or DT.Rows(0).Item(0) = "Bank OD A/C" Then
                    'DONT MANDATE CHQ NO AS THERE ARE RTGS ENTRIES AS WELL
                    'If txtchqno.Text.Trim.Length = 0 Then
                    '    EP.SetError(txtchqno, "Enter Chq No.")
                    '    BLN = False
                    'End If
                    If txtchqno.Text.Trim.Length = 0 Then
                        Dim TEMPMSG As Integer = MsgBox("Chq No. is Blank, Proceed?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbNo Then
                            EP.SetError(txtchqno, "Enter Chq No.")
                            BLN = False
                        End If
                    End If
                ElseIf DT.Rows(0).Item(0) = "Cash In Hand" Then
                    txtchqno.Clear()
                End If
            End If



            If ACCDATE.Text = "__/__/____" Then
                EP.SetError(ACCDATE, " Please Enter Proper Date")
                BLN = False
            Else
                If Not datecheck(ACCDATE.Text) Then
                    EP.SetError(ACCDATE, "Date not in Accounting Year")
                    BLN = False
                End If

                If CMDRECO.Visible = True Then
                    If Convert.ToDateTime(ACCDATE.Text).Date > RECODATE.Value.Date Then
                        EP.SetError(CMDRECO, "Date should be less than Reco Date!")
                        BLN = False
                    End If
                End If

            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Receipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Control = True And e.Shift = True And e.KeyCode = Windows.Forms.Keys.R Then       'for Copy Old Narration
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(RECEIPT_REMARKS,'') AS REMARKS", "", " RECEIPTMASTER ", "  AND RECEIPT_CMPID = " & CmpId & " AND RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPT_YEARID = " & YearId & "ORDER BY RECEIPT_NO DESC ")
            If DT.Rows.Count > 0 Then txtremarks.Text = DT.Rows(0).Item("REMARKS")
            txtremarks.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            tstxtbillno.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            gridpayment.Focus()
        ElseIf e.KeyCode = Keys.F8 Then
            gridbill.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub CMBPARTYBANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYBANK.Enter
        Try
            If CMBPARTYBANK.Text.Trim = "" Then FILLBANK(CMBPARTYBANK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYBANK.Validating
        Try
            If CMBPARTYBANK.Text.Trim <> "" Then PARTYBANKvalidate(CMBPARTYBANK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Receipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'RECEIPT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            'getmaxno_receiptmaster()
            fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            fillledger(cmbaccname, edit, " and (groupmaster.group_secondary = 'BANK A/C' OR groupmaster.group_secondary = 'BANK OD A/C' OR groupmaster.group_secondary = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            fillregister(cmbregister, " and register_type = 'RECEIPT'")
            If CMBPARTYBANK.Text = "" Then FILLBANK(CMBPARTYBANK)

            'GET DEFAULT BANK (FIRST ADD A NEW COLUMN OF DEFAULT IN ALL MASTERS AND IN LEDGERS VIEW)
            'Dim objcommon As New ClsCommonMaster
            'Dim dt As New DataTable
            'dt = objcommon.search(" acc_cmpname", "", " ledgers", " and acc_default = true and acc_cmpid = " & CmpId)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJCLRECEIPT As New ClsReceiptMaster()
                dt = OBJCLRECEIPT.selectbill_edit(TEMPRECEIPTNO, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then

                    gridpayment.RowCount = 0
                    gridpaydesc.RowCount = 0
                    GRIDDESC.RowCount = 0

                    For Each dr As DataRow In dt.Rows

                        txtaccno.Text = TEMPRECEIPTNO
                        txtaccno.ReadOnly = True

                        cmbregister.Text = Convert.ToString(dr("REGISTERNAME"))
                        ACCDATE.Text = Format(Convert.ToDateTime(dr("ACCDATE")).Date, "dd/MM/yyyy")
                        cmbaccname.Text = Convert.ToString(dr("ACCNAME"))
                        cmbname.Text = Convert.ToString(dr("LEDGERNAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))
                        CMBPARTYBANK.Text = Convert.ToString(dr("BANKNAME"))

                        txtchqamt.Text = Convert.ToString(Format(dr("CHQAMT"), "0.00"))
                        txtchqno.Text = Convert.ToString(dr("CHQNO"))
                        CHQNO = txtchqno.Text


                        If dr("CHECKPDC") = 0 Then CHKPDC.Checked = False Else CHKPDC.Checked = True

                        If dr("RECODATE") = "" Then
                            CHKRECO.CheckState = CheckState.Unchecked

                            LBLRECO.Visible = False
                            RECODATE.Visible = False
                            CMDRECO.Visible = False

                            txtchqamt.ReadOnly = False
                            lbllocked.Visible = False
                            PBlock.Visible = False

                        Else

                            CHKRECO.CheckState = CheckState.Checked

                            Dim MYSTR As String = dr("RECODATE")
                            If dr("RECODATE").ToString.Substring(2, 1) = "/" Then
                                MYSTR = dr("RECODATE").ToString.Substring(3, 2) & "-" & dr("RECODATE").ToString.Substring(0, 2) & "-" & dr("RECODATE").ToString.Substring(6, 4)
                                RECODATE.Value = Format(Convert.ToDateTime(MYSTR).Date, "dd/MM/yyyy")
                            Else
                                RECODATE.Value = Format(Convert.ToDateTime(dr("RECODATE")).Date, "dd/MM/yyyy")
                            End If

                            LBLRECO.Visible = True
                            RECODATE.Visible = True
                            CMDRECO.Visible = True
                            txtchqamt.ReadOnly = True
                            cmbaccname.Enabled = False
                            RECODATE.Enabled = False

                        End If
                        If Convert.ToBoolean(dr("SMSSEND")) = True Then LBLSMS.Visible = True

                        gridpayment.Rows.Add(0, dr("GRIDSRNO"), dr("PAYTYPE").ToString, dr("BILLINITIALS").ToString, dr("NARR").ToString, Format(dr("AMT"), "0.00"), Format(dr("AMTPAID"), "0.00"), Format(dr("EXTRAAMT"), "0.00"), Format(dr("RETURN"), "0.00"), Format(dr("BALANCE"), "0.00"))
                        If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Or Val(dr("RETURN")) > 0 Then
                            gridpayment.Rows(gridpayment.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next

                    Dim OBJCMN As New ClsCommon
                    Dim DT1 As DataTable = OBJCMN.search(" RECEIPTMASTER_GRIDDESC.RECEIPT_DESCGRIDSRNO AS DESCGRIDSRNO, LEDGERS.Acc_cmpname AS DESCLEDGERNAME, RECEIPTMASTER_GRIDDESC.RECEIPT_DESCGRIDREMARKS AS DESCNARR, RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT AS DESCAMT, RECEIPTMASTER_GRIDDESC.RECEIPT_PAYGRIDSRNO AS PAYGRIDSRNO, RECEIPT_PAYBILLINITIALS AS PAYBILLINITIALS ", "", "  RECEIPTMASTER_GRIDDESC INNER JOIN LEDGERS ON RECEIPTMASTER_GRIDDESC.RECEIPT_DESCLEDGERID = LEDGERS.Acc_id AND RECEIPTMASTER_GRIDDESC.RECEIPT_CMPID = LEDGERS.Acc_cmpid AND RECEIPTMASTER_GRIDDESC.RECEIPT_LOCATIONID = LEDGERS.Acc_locationid AND RECEIPTMASTER_GRIDDESC.RECEIPT_YEARID = LEDGERS.Acc_yearid INNER JOIN REGISTERMASTER ON RECEIPTMASTER_GRIDDESC.RECEIPT_REGISTERID = REGISTERMASTER.register_id AND RECEIPTMASTER_GRIDDESC.RECEIPT_CMPID = REGISTERMASTER.register_cmpid AND RECEIPTMASTER_GRIDDESC.RECEIPT_LOCATIONID = REGISTERMASTER.register_locationid AND RECEIPTMASTER_GRIDDESC.RECEIPT_YEARID = REGISTERMASTER.register_yearid", " AND (RECEIPTMASTER_GRIDDESC.receipt_no = " & TEMPRECEIPTNO & ") AND (REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "') AND (RECEIPTMASTER_GRIDDESC.RECEIPT_cmpid = " & CmpId & ") AND (RECEIPTMASTER_GRIDDESC.RECEIPT_locationid = " & Locationid & ") AND (RECEIPTMASTER_GRIDDESC.RECEIPT_YEARid = " & YearId & ")")
                    For Each DR1 As DataRow In DT1.Rows
                        GRIDDESC.Rows.Add(DR1("DESCGRIDSRNO").ToString, DR1("DESCLEDGERNAME").ToString, DR1("DESCNARR").ToString, Format(DR1("DESCAMT"), "0.00"), DR1("PAYGRIDSRNO"), DR1("PAYBILLINITIALS").ToString)
                        gridpayment.Rows(DR1("PAYGRIDSRNO") - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    Next


                    txtremarks.Text = Convert.ToString(dt.Rows(0).Item("remarks"))
                    TXTOURREMARKS.Text = Convert.ToString(dt.Rows(0).Item("OURREMARKS"))


                    'filling gridINVOICE
                    fillgridINVOICE()

                    cmbregister.Enabled = False
                    accdate.Focus()
                    chkchange.CheckState = CheckState.Checked
                    total()
                Else
                    edit = False
                    clear()
                End If
            End If
            gridpayment.ClearSelection()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" And edit = True Then
                gridpayment.DataSource = Nothing
                gridpaydesc.DataSource = Nothing
                gridpaydesc.RowCount = 0
                gridpayment.RowCount = 0
                GRIDDESC.RowCount = 0
                txttotal.Clear()
                txtdesctotal.Clear()

                If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                    fillgridINVOICE()
                    'Else
                    '    Call txtbillno_Validating(sender, e)
                End If
            End If
            If cmbname.Text.Trim <> "" Then
                GETBALANCE()
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(PARTYBANKMASTER.PARTYBANK_name, '') AS PARTYBANKNAME ,ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO", "", "PARTYBANKMASTER RIGHT OUTER JOIN LEDGERS ON PARTYBANKMASTER.PARTYBANK_id = LEDGERS.ACC_BANKID", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If CMBPARTYBANK.Text.Trim = "" Then CMBPARTYBANK.Text = DT.Rows(0).Item("PARTYBANKNAME")
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' or groupmaster.group_SECONDARY = 'Indirect Income' or groupmaster.group_SECONDARY = 'Direct Income') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                fillgridINVOICE()
                'Else
                '    Call txtbillno_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(descgridsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getpaysrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gridsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim DTTABLE As DataTable

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            'GET BILLREMARKS
            TXTBILLREMARKS.Clear()
            For Each ROW As DataGridViewRow In gridpayment.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" Then
                    If TXTBILLREMARKS.Text = "" Then
                        TXTBILLREMARKS.Text = "Against Bill - " & ROW.Cells(gbillno.Index).Value
                    Else
                        TXTBILLREMARKS.Text = TXTBILLREMARKS.Text & ", " & ROW.Cells(gbillno.Index).Value
                    End If
                ElseIf ROW.Cells(gpaytype.Index).Value = "" Then
                    ROW.Cells(gpaytype.Index).Value = "On Account"
                End If
            Next

            Dim alparaval As New ArrayList

            If txtaccno.ReadOnly = False Then
                alparaval.Add(Val(txtaccno.Text.Trim))
            Else
                alparaval.Add(0)
            End If

            alparaval.Add(cmbregister.Text.Trim)
            alparaval.Add(Format(Convert.ToDateTime(ACCDATE.Text).Date, "MM/dd/yyyy"))
            alparaval.Add(cmbaccname.Text.Trim)
            alparaval.Add(cmbname.Text.Trim)
            alparaval.Add(Val(txtchqamt.Text))
            alparaval.Add(txtchqno.Text.Trim)
            alparaval.Add(txtremarks.Text.Trim)
            alparaval.Add(TXTBILLREMARKS.Text.Trim)
            alparaval.Add(TXTOURREMARKS.Text.Trim)
            alparaval.Add(txtinwords.Text.Trim)

            If CHKPDC.Checked = True Then
                alparaval.Add(1)
            Else
                alparaval.Add(0)
            End If

            If CHKRECO.CheckState = CheckState.Checked Then
                alparaval.Add(Format(RECODATE.Value.Date, "MM/dd/yyyy"))
            Else
                alparaval.Add("")
            End If

            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim pgridsrno As String = ""
            Dim paytype As String = ""
            Dim billINITIALS As String = ""
            Dim narr As String = ""
            Dim amt As String = ""
            Dim AMTPAID As String = ""
            Dim EXTRAAMT As String = ""
            Dim RETURNAMT As String = ""
            Dim BALANCE As String = ""

            Dim dgridsrno As String = ""
            Dim descledgername As String = ""
            Dim descnarration As String = ""
            Dim descamount As String = ""
            Dim DESCPAYGRIDSRNO As String = ""
            Dim DESCPAYBILLINITIALS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridpayment.Rows
                If row.Cells(gridsrno.Index).Value <> Nothing Then
                    If pgridsrno = "" Then

                        pgridsrno = row.Cells(gridsrno.Index).Value.ToString
                        paytype = row.Cells(gpaytype.Index).Value
                        billINITIALS = row.Cells(gbillno.Index).Value.ToString
                        narr = row.Cells(gdesc.Index).Value
                        amt = Val(row.Cells(gamt.Index).Value)
                        AMTPAID = row.Cells(GAMTPAID.Index).Value
                        EXTRAAMT = row.Cells(GEXTRAAMT.Index).Value
                        RETURNAMT = row.Cells(GRETURN.Index).Value
                        BALANCE = row.Cells(GBALANCE.Index).Value


                    Else

                        pgridsrno = pgridsrno & "|" & row.Cells(gridsrno.Index).Value.ToString
                        paytype = paytype & "|" & row.Cells(gpaytype.Index).Value
                        billINITIALS = billINITIALS & "|" & row.Cells(gbillno.Index).Value.ToString
                        narr = narr & "|" & row.Cells(gdesc.Index).Value
                        amt = amt & "|" & Val(row.Cells(gamt.Index).Value)
                        AMTPAID = AMTPAID & "|" & row.Cells(GAMTPAID.Index).Value
                        EXTRAAMT = EXTRAAMT & "|" & row.Cells(GEXTRAAMT.Index).Value
                        RETURNAMT = RETURNAMT & "|" & row.Cells(GRETURN.Index).Value
                        BALANCE = BALANCE & "|" & row.Cells(GBALANCE.Index).Value
                    End If
                End If
            Next


            For Each row As Windows.Forms.DataGridViewRow In GRIDDESC.Rows
                If row.Cells(descgridsrno.Index).Value <> Nothing Then
                    If dgridsrno = "" Then

                        dgridsrno = row.Cells(DSRNO.Index).Value.ToString
                        descledgername = row.Cells(DNAME.Index).Value
                        descnarration = row.Cells(DNARR.Index).Value
                        descamount = row.Cells(DAMT.Index).Value.ToString
                        DESCPAYGRIDSRNO = row.Cells(DPAYGRIDSRNO.Index).Value.ToString
                        DESCPAYBILLINITIALS = row.Cells(DPAYBILLINITIALS.Index).Value.ToString

                    Else

                        dgridsrno = dgridsrno & "|" & row.Cells(DSRNO.Index).Value.ToString
                        descledgername = descledgername & "|" & row.Cells(DNAME.Index).Value.ToString
                        descnarration = descnarration & "|" & row.Cells(DNARR.Index).Value
                        descamount = descamount & "|" & row.Cells(DAMT.Index).Value.ToString
                        DESCPAYGRIDSRNO = DESCPAYGRIDSRNO & "|" & row.Cells(DPAYGRIDSRNO.Index).Value.ToString
                        DESCPAYBILLINITIALS = DESCPAYBILLINITIALS & "|" & row.Cells(DPAYBILLINITIALS.Index).Value.ToString

                    End If
                End If
            Next


            alparaval.Add(pgridsrno)
            alparaval.Add(paytype)
            alparaval.Add(billINITIALS)
            alparaval.Add(narr)
            alparaval.Add(amt)
            alparaval.Add(AMTPAID)
            alparaval.Add(EXTRAAMT)
            alparaval.Add(RETURNAMT)
            alparaval.Add(BALANCE)


            alparaval.Add(dgridsrno)
            alparaval.Add(descledgername)
            alparaval.Add(descnarration)
            alparaval.Add(descamount)
            alparaval.Add(DESCPAYGRIDSRNO)
            alparaval.Add(DESCPAYBILLINITIALS)
            alparaval.Add(CMBPARTYBANK.Text.Trim)


            Dim OBJCLRECEIPT As New ClsReceiptMaster
            OBJCLRECEIPT.alParaval = alparaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJCLRECEIPT.save()
                MessageBox.Show("Details Added")
                txtaccno.Text = Val(DTTABLE.Rows(0).Item(0))

                'Dim TEMPMSG As Integer = MsgBox("Print Receipt Voucher?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim objREC As New receipt_advice
                '    objREC.recno = Val(DTTABLE.Rows(0).Item(0))
                '    objREC.recname = cmbname.Text.Trim
                '    objREC.REGNAME = cmbregister.Text.Trim
                '    objREC.MdiParent = MDIMain
                '    objREC.Show()
                'End If

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPRECEIPTNO)
                Dim IntResult As Integer = OBJCLRECEIPT.update()
                MsgBox("Details Updated")
                EDIT = False
                'Dim TEMPMSG As Integer = MsgBox("Print Receipt Voucher?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim objREC As New receipt_advice
                '    objREC.recno = Val(TEMPRECEIPTNO)
                '    objREC.recname = cmbname.Text.Trim
                '    objREC.REGNAME = cmbregister.Text.Trim
                '    objREC.MdiParent = MDIMain
                '    objREC.Show()
                'End If

            End If

            If ClientName = "SAKARIA" Then SENDDIRECTMAIL()

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)
            If ClientName = "AVIS" Or ClientName = "MAHAVIR" Or ClientName = "SUPRIYA" Then ACCDATE.Focus() Else cmbaccname.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDDIRECTMAIL()
        Try

            If MsgBox("Wish To Mail Receipt Advice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'CHECK WHETHER EMAILID IS PRESENT IN LEDGER OR NOT, IF NOT THEN EXIT SUB WITH MESSAGE
            Dim OBJCMN As New ClsCommon
            Dim DTEMAIL As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", "AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DTEMAIL.Rows.Count > 0 AndAlso DTEMAIL.Rows(0).Item("EMAILID") <> "" Then

                Dim ALATTACHMENT As New ArrayList
                Dim OBJREC As New receipt_advice
                OBJREC.MdiParent = MDIMain
                OBJREC.DIRECTPRINT = True
                OBJREC.DIRECTMAIL = True
                OBJREC.REGNAME = cmbregister.Text.Trim
                OBJREC.PRINTSETTING = PRINTDIALOG
                OBJREC.recno = Val(txtaccno.Text.Trim)
                OBJREC.recname = cmbname.Text.Trim
                OBJREC.Show()
                OBJREC.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\RECEIPT_" & Val(txtaccno.Text.Trim) & ".pdf")

                sendemail(DTEMAIL.Rows(0).Item("EMAILID"), ALATTACHMENT(0), "", "Receipt", ALATTACHMENT, ALATTACHMENT.Count, "", "", "", "", "")
                MsgBox("Mail Sent")
            Else
                MsgBox("Add E-Mail id in Ledger")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellClick
        Try
            If e.RowIndex >= 0 Then
                With gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVBALAMT").Index).Value

                        Dim A As System.ComponentModel.CancelEventArgs
                        txtamt_Validating(sender, A)

                    End If
                    total()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        TXTINVTOTAL.Text = 0.0
        txtdesctotal.Text = 0.0
        txttotal.Text = 0.0
        txtchqbal.Text = 0.0

        For Each row As DataGridViewRow In gridpayment.Rows
            txttotal.Text = Format(Val(txttotal.Text) + row.Cells(gamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridpaydesc.Rows
            txtdesctotal.Text = Format(Val(txtdesctotal.Text) + row.Cells(descamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridbill.Rows
            If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(gridbill.Columns("INVBALAMT").Index).Value, "0.00")
        Next

        If Val(txtchqamt.Text) <> 0 Then
            txtchqbal.Text = Format(Val(txtchqamt.Text) - Val(txttotal.Text), "0.00")
            txtinwords.Text = CurrencyToWord(txtchqamt.Text)
        End If

    End Sub

    Sub fillcmbbillno()
        If cmbbillno.Items.Count > 0 Then cmbbillno.Items.Clear()
        For Each row As DataGridViewRow In gridbill.Rows
            If Convert.ToBoolean(row.Cells(gridbill.Columns("INVCHK").Index).Value) = True Then
                cmbbillno.Items.Add(row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value.ToString())
            End If
        Next
        If cmbbillno.Items.Count > 0 Then cmbbillno.SelectedIndex = (0)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If edit = False Then
                If GRIDDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, TEMPROW).Value)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If cmbpaytype.Text.Trim = "Against Bill" Then
                        Dim BALAMT As Double = 0
                        For Each ROW As DataGridViewRow In GRIDDESC.Rows
                            If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                                BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                            End If
                        Next

                        If Val(txtamt.Text) + Val(BALAMT) > Val(lblbilltotal.Text) Then
                            EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If

            ElseIf edit = True Then
                If GRIDDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
                    'If cmbpaytype.Text.Trim = "Against Bill" Then
                    '    Dim MAXALLOWEDVALUE As Double = 0
                    '    Dim OBJCMN As New ClsCommon
                    '    Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                    '    If DT.Rows.Count > 0 Then
                    '        MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                    '    End If

                    '    Dim BALAMT As Double = 0
                    '    For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    '        If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                    '            BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                    '        End If
                    '    Next

                    '    If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                    '        EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                    '        BLN = False
                    '    End If

                    'End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, TEMPROW).Value)) > Val(txtchqamt.Text) Then
                        EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If cmbpaytype.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                        End If

                        Dim BALAMT As Double = 0
                        For Each ROW As DataGridViewRow In GRIDDESC.Rows
                            If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                                BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                            End If
                        Next

                        If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                            EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
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

    Function DESCAMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim BALANCEAMT As Double = 0

            'checking WHETHER TOTAL OF AMT IS GREATER THEN BAL AMT OR NOT
            For Each ROW As DataGridViewRow In gridbill.Rows
                If ROW.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value = LBLPAYBILLINITIALS.Text.Trim Then
                    BALANCEAMT = ROW.Cells(gridbill.Columns("INVBALAMT").Index).Value
                End If
            Next


            If edit = False Then
                If GRIDDESCDOUBLECLICK = False Then
                    If (Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(txtdesctotal.Text)) > Val(BALANCEAMT) Then
                        EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                Else
                    If ((Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(txtdesctotal.Text)) - Val(gridpaydesc.Item(descamt.Index, TEMPDESCROW).Value)) > Val(BALANCEAMT) Then
                        EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                End If
            Else
                Dim MAXALLOWEDVALUE As Double = 0
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(RECEIPTMASTER_DESC.receipt_amt)  AS RECAMT, 0 AS DESCAMT, RECEIPT_BILLINITIALS AS BILLINITIALS, receipt_NO as RECNO, register_name AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  WHERE receipt_paytype = 'Against Bill' GROUP BY RECEIPT_BILLINITIALS, receipt_no, register_name , RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  UNION ALL SELECT 0 AS RECAMT, SUM(RECEIPTMASTER_GRIDDESC.RECEIPT_DESCAMT ), RECEIPT_PAYBILLINITIALS AS BILLINITIALS, RECEIPT_NO as RECNO, REGISTER_NAME AS REGNAME, receipt_cmpid AS CMPID, receipt_locationid AS LOCATIONID, receipt_yearid AS YEARID FROM RECEIPTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = receipt_registerid AND register_cmpid = receipt_cmpid AND register_locationid = receipt_locationid AND receipt_yearid = receipt_yearid  GROUP BY RECEIPT_PAYBILLINITIALS , RECEIPT_NO, register_name ,RECEIPT_CMPID , RECEIPT_LOCATIONID,RECEIPT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & LBLPAYBILLINITIALS.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MAXALLOWEDVALUE = Val(DT.Rows(0).Item("RECAMT")) + Val(DT.Rows(0).Item("DESCAMT")) + BALANCEAMT
                End If
                DT.Clear()

                MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(gridpayment.Rows(Val(LBLPAYGRIDSRNO.Text) - 1).Cells(gamt.Index).Value)
                If GRIDDESCDOUBLECLICK = True Then
                    MAXALLOWEDVALUE = MAXALLOWEDVALUE + Val(gridpaydesc.Rows(TEMPDESCROW).Cells(descamt.Index).Value)
                End If

                For Each ROW As DataGridViewRow In gridpaydesc.Rows
                    MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(ROW.Cells(descamt.Index).Value)
                Next

                If Val(txtdescamt.Text) > Val(MAXALLOWEDVALUE) Then
                    EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()
        Try
            EP.Clear()
            If Not AMOUNTVALIDATE() Then
                txtsrno.Focus()
                Exit Sub
            End If

            Dim AMT As Double = txtamt.Text

            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            If cmbpaytype.Text = "Against Bill" And Val(txtamt.Text) > Val(lblbilltotal.Text) And Val(lblbilltotal.Text) <> 0 Then
                    txtamt.Text = Val(lblbilltotal.Text)
                End If
            'End If
            If GRIDDOUBLECLICK = False Then

                gridpayment.Rows.Add(0, txtsrno.Text.Trim, cmbpaytype.Text.Trim, cmbbillno.Text.Trim, txtnarr.Text.Trim, Val(txtamt.Text.Trim), 0, 0, 0, Val(txtamt.Text.Trim))
                getpaysrno(gridpayment)
            Else
                gridpayment.Item(1, TEMPROW).Value = txtsrno.Text.Trim
                gridpayment.Item(2, TEMPROW).Value = cmbpaytype.Text.Trim
                gridpayment.Item(3, TEMPROW).Value = cmbbillno.Text.Trim
                gridpayment.Item(4, TEMPROW).Value = txtnarr.Text.Trim
                gridpayment.Item(5, TEMPROW).Value = Val(txtamt.Text.Trim)

                GRIDDOUBLECLICK = False
            End If


            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            txtamt.Text = Format(Val(AMT) - Val(txtamt.Text), "0.00")
            'Else
            '    txtamt.Clear()
            'End If

            total()
            gridpayment.FirstDisplayedScrollingRowIndex = gridpayment.RowCount - 1

            txtsrno.Clear()
            cmbpaytype.SelectedIndex = 0
            cmbbillno.Text = ""
            lblbilltotal.Text = ""
            cmbbillno.Enabled = False
            txtnarr.Clear()
            'txtamt.Clear() DONT CLEAR THE AMT COZ BAL AMT OF THE CHQ COMES AGAIN
            txtsrno.Focus()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridDESC()
        Try

            EP.Clear()
            If Not DESCAMOUNTVALIDATE() Then
                txtdescsrno.Focus()
                Exit Sub
            End If

            fillEXTRAGRID()
            If GRIDDESCDOUBLECLICK = False Then
                gridpaydesc.Rows.Add(txtdescsrno.Text.Trim, cmbledgername.Text.Trim, txtdescnarr.Text.Trim, Val(txtdescamt.Text.Trim), LBLPAYGRIDSRNO.Text, LBLPAYBILLINITIALS.Text)
                getsrno(gridpaydesc)
            Else
                gridpaydesc.Item(descgridsrno.Index, TEMPDESCROW).Value = txtdescsrno.Text.Trim
                gridpaydesc.Item(gname.Index, TEMPDESCROW).Value = cmbledgername.Text.Trim
                gridpaydesc.Item(descnarr.Index, TEMPDESCROW).Value = txtdescnarr.Text.Trim
                gridpaydesc.Item(descamt.Index, TEMPDESCROW).Value = Val(txtdescamt.Text.Trim)
                gridpaydesc.Item(PAYGRIDSRNO.Index, TEMPDESCROW).Value = LBLPAYGRIDSRNO.Text.Trim
                gridpaydesc.Item(PAYBILLINITIALS.Index, TEMPDESCROW).Value = LBLPAYBILLINITIALS.Text.Trim
                GRIDDESCDOUBLECLICK = False
            End If
            total()

            gridpaydesc.FirstDisplayedScrollingRowIndex = gridpaydesc.RowCount - 1

            txtdescsrno.Clear()
            cmbledgername.Text = ""
            txtdescnarr.Text = ""
            txtdescamt.Clear()
            txtdescsrno.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillEXTRAGRID()
        Try

            If GRIDDESCDOUBLECLICK = False Then
                GRIDDESC.Rows.Add(txtdescsrno.Text.Trim, cmbledgername.Text.Trim, txtdescnarr.Text.Trim, Val(txtdescamt.Text.Trim), LBLPAYGRIDSRNO.Text, LBLPAYBILLINITIALS.Text)
            Else

                'FIRST GETTING ROWNO WITH RESPECT TO GRIDPAYDESC'S SRNO AND PAYMENT'S GRIDSRNO
                Dim ROWNO As Integer = 0
                For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    If ROW.Cells(DSRNO.Index).Value = txtdescsrno.Text And ROW.Cells(DPAYGRIDSRNO.Index).Value = LBLPAYGRIDSRNO.Text Then
                        ROWNO = ROW.Index
                        Exit For
                    End If
                Next

                GRIDDESC.Item(DSRNO.Index, ROWNO).Value = txtdescsrno.Text.Trim
                GRIDDESC.Item(DNAME.Index, ROWNO).Value = cmbledgername.Text.Trim
                GRIDDESC.Item(DNARR.Index, ROWNO).Value = txtdescnarr.Text.Trim
                GRIDDESC.Item(DAMT.Index, ROWNO).Value = Val(txtdescamt.Text.Trim)
                GRIDDESC.Item(DPAYGRIDSRNO.Index, ROWNO).Value = LBLPAYGRIDSRNO.Text.Trim
                GRIDDESC.Item(DPAYBILLINITIALS.Index, ROWNO).Value = LBLPAYBILLINITIALS.Text.Trim
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaccname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaccname.Enter
        Try
            'OPEN BANK A/C AND BANK OD A/C
            If cmbaccname.Text.Trim = "" Then fillledger(cmbaccname, edit, " and (groupmaster.group_SECONDARY = 'BANK A/C' OR groupmaster.group_SECONDARY = 'BANK OD A/C' OR groupmaster.group_SECONDARY = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaccname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbaccname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Sub SETGRIDINVOICE(ByVal DT As DataTable)
        Try
            DT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
            gridbill.DataSource = DT
            If a = 0 Then
                gridbill.Columns.Insert(0, col)
                a = 1
            End If
            Dim i As Integer = 0

            gridbill.Columns(i).Width = 40
            gridbill.Columns(i).Name = "INVCHK"
            gridbill.Columns(i).HeaderText = ""
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Width = 80
            gridbill.Columns(i).Name = "INVBILLINITIALS"
            gridbill.Columns(i).HeaderText = "Bill No."
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Width = 80
            gridbill.Columns(i).Name = "REFNO"
            gridbill.Columns(i).HeaderText = "Ref No"
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Width = 80
            gridbill.Columns(i).Name = "INVBILLDATE"
            gridbill.Columns(i).HeaderText = "Bill Date"
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Width = 100
            gridbill.Columns(i).Name = "INVBALAMT"
            gridbill.Columns(i).HeaderText = "Bal. Amt"
            gridbill.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridbill.Columns(i).DefaultCellStyle.Format = "N2"
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Width = 100
            gridbill.Columns(i).Name = "INVBILLAMT"
            gridbill.Columns(i).HeaderText = "Bill Amt"
            gridbill.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridbill.Columns(i).DefaultCellStyle.Format = "N2"
            gridbill.Columns(i).ReadOnly = True
            i += 1

            gridbill.Columns(i).Visible = False
            gridbill.Columns(i).Name = "INVBILLTYPE"
            i += 1

            gridbill.Columns(i).Visible = False
            gridbill.Columns(i).Name = "INVBILLNO"
            i += 1

            gridbill.Columns(i).Visible = False
            gridbill.Columns(i).Name = "INVREGNAME"
            i += 1

            gridbill.Columns(i).Visible = False
            gridbill.Columns(i).Name = "INVCUSNAME"
            i += 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridINVOICE()

        gridbill.DataSource = Nothing
        TXTINVTOTAL.Clear()
        'getting from INVOICEMASTER

        Dim objpayment As New ClsReceiptMaster
        Dim DT As New DataTable
        DT = objpayment.GETBILLS(CmpId, cmbname.Text.Trim, Locationid, YearId)
        If DT.Rows.Count > 0 Then
            SETGRIDINVOICE(DT)

            'Dim DTROW As DataRow
            'For Each DTROW In DT.Rows
            '    gridbill.Rows.Add(0, DTROW("BILLINITIALS"), Format(DTROW("BILLDATE"), "dd/MM/yyyy"), Val(DTROW("BALAMT")), Val(DTROW("BILLAMT")), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
            'Next
        End If

    End Sub

    Private Sub gridpayment_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpayment.CellClick
        Try

            If e.RowIndex < 0 Then Exit Sub

            Dim N As Integer = 0

            'CHECKING SIMILAR Enquiry Numbers
            For i As Integer = 0 To gridpayment.RowCount - 1
                With gridpayment.Rows(i).Cells(GCHK.Index)
                    If .Value = True Then
                        N = gridpayment.Rows(i).Cells(gridsrno.Index).Value
                    End If
                End With
            Next


            'If e.RowIndex >= 0 And e.ColumnIndex = GCHK.Index And gridpayment.Rows(e.RowIndex).Cells(gpaytype.Index).Value = "Against Bill" Then
            If e.RowIndex >= 0 And e.ColumnIndex = GCHK.Index Then
                With gridpayment.Rows(e.RowIndex).Cells(GCHK.Index)
                    If Convert.ToBoolean(.Value) = True Then
                        .Value = False
                        Gbdesc.Enabled = False
                        txtdescsrno.Clear()
                        cmbledgername.Text = ""
                        txtdescnarr.Clear()
                        txtdescamt.Clear()
                        gridpaydesc.RowCount = 0

                    Else
                        If (gridpayment.Rows(e.RowIndex).Cells(gridsrno.Index).Value = N) Or N = 0 Then
                            .Value = True
                            Gbdesc.Enabled = True
                            LBLPAYGRIDSRNO.Text = gridpayment.Rows(e.RowIndex).Cells(gridsrno.Index).Value
                            LBLPAYBILLINITIALS.Text = gridpayment.Rows(e.RowIndex).Cells(gbillno.Index).Value
                            GETDESCDATA(LBLPAYGRIDSRNO.Text)
                            total()
                            txtdescsrno.Focus()
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDESCDATA(ByVal ROWNO As Integer)
        Try
            gridpaydesc.RowCount = 0
            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                If ROW.Cells(DPAYGRIDSRNO.Index).Value = ROWNO Then
                    gridpaydesc.Rows.Add(ROW.Cells(DSRNO.Index).Value, ROW.Cells(DNAME.Index).Value, ROW.Cells(DNARR.Index).Value, ROW.Cells(DAMT.Index).Value, ROWNO, ROW.Cells(DPAYBILLINITIALS.Index).Value)
                End If
            Next
            getsrno(gridpaydesc)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub EDITROW()
        Try
            If gridpayment.CurrentRow.Index >= 0 And gridpayment.Item(gridsrno.Index, gridpayment.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = gridpayment.CurrentRow.Index
                txtsrno.Text = gridpayment.Item(gridsrno.Index, gridpayment.CurrentRow.Index).Value.ToString
                cmbpaytype.Text = gridpayment.Item(gpaytype.Index, gridpayment.CurrentRow.Index).Value.ToString
                cmbbillno.Text = gridpayment.Item(gbillno.Index, gridpayment.CurrentRow.Index).Value.ToString
                txtnarr.Text = gridpayment.Item(gdesc.Index, gridpayment.CurrentRow.Index).Value.ToString
                txtamt.Text = gridpayment.Item(gamt.Index, gridpayment.CurrentRow.Index).Value.ToString
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub gridPAYMENT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpayment.CellDoubleClick
        Try

            'If e.RowIndex >= 0 And gridpayment.Item(gridsrno.Index, e.RowIndex).Value <> Nothing Then
            '    GRIDDOUBLECLICK = True
            '    txtsrno.Text = gridpayment.Item(gridsrno.Index, e.RowIndex).Value.ToString
            '    cmbpaytype.Text = gridpayment.Item(gpaytype.Index, e.RowIndex).Value.ToString
            '    cmbbillno.Text = gridpayment.Item(gbillno.Index, e.RowIndex).Value.ToString
            EDITROW()

            If cmbbillno.Text.Trim <> "" Then
                    cmbbillno.Enabled = True

                    'GETTING AMT OF THE SELECTED BILL
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALANCE", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID, INVOICE_LOCATIONID AS LOCATIONID, INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE  UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref') AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        lblbilltotal.Text = Format(DT.Rows(0).Item("BALANCE"), "0.00")
                    End If
                End If

            'txtnarr.Text = gridpayment.Item(gdesc.Index, e.RowIndex).Value.ToString
            'txtamt.Text = gridpayment.Item(gamt.Index, e.RowIndex).Value.ToString

            'TEMPROW = e.RowIndex
            'txtsrno.Focus()
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridRECEIPT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpayment.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            'REMOVE ROWS FROM GRIDDESC
            gridpaydesc.RowCount = 0
            cmbledgername.Text = ""
            txtdescnarr.Clear()
            txtdescamt.Clear()
            txtdescsrno.Clear()
            Gbdesc.Enabled = False
1:
            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                If ROW.Cells(DPAYGRIDSRNO.Index).Value = gridpayment.Rows(gridpayment.CurrentRow.Index).Cells(gridsrno.Index).Value Then
                    GRIDDESC.Rows.RemoveAt(ROW.Index)
                    GoTo 1
                ElseIf ROW.Cells(DPAYGRIDSRNO.Index).Value > gridpayment.Rows(gridpayment.CurrentRow.Index).Cells(gridsrno.Index).Value Then
                    ROW.Cells(DPAYGRIDSRNO.Index).Value = ROW.Cells(DPAYGRIDSRNO.Index).Value - 1
                End If
            Next

            gridpayment.Rows.RemoveAt(gridpayment.CurrentRow.Index)
            total()
            getpaysrno(gridpayment)
        ElseIf e.KeyCode = Keys.F5 Then
            EDITROW()
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
LINE1:
            TEMPRECEIPTNO = Val(txtaccno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_receiptmaster()
            Dim MAXNO As Integer = txtaccno.Text.Trim
            clear()
            If Val(txtaccno.Text) - 1 >= TEMPRECEIPTNO Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And GRIDDESC.RowCount = 0 And TEMPRECEIPTNO < MAXNO Then
                txtaccno.Text = TEMPRECEIPTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
LINE1:
            TEMPRECEIPTNO = Val(txtaccno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPRECEIPTNO > 0 Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And GRIDDESC.RowCount = 0 And TEMPRECEIPTNO > 1 Then
                txtaccno.Text = TEMPRECEIPTNO
                GoTo LINE1
            End If
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
            Dim OBJRECDTLS As New ReceiptDetails
            OBJRECDTLS.MdiParent = MDIMain
            OBJRECDTLS.Show()
            OBJRECDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Private Sub cmbaccname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaccname.Validating
        Try
            If cmbaccname.Text.Trim <> "" Then ledgervalidate(cmbaccname, CMBACCCODE, e, Me, txtadd, " AND (GROUPMASTER.group_SECONDARY = 'BANK A/C' OR GROUPMASTER.group_SECONDARY = 'BANK OD A/C' OR GROUPMASTER.group_SECONDARY = 'CASH IN HAND') AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbillno.Validating
        Try

            If txtbillno.Text.Trim <> "" Then

                txtbillno.Text = UCase(txtbillno.Text)
                'CHECKING WHETHER BILL IS ALREADY PRSENT IN GRID OR NOT
                'IF PRESENT THEN CHECK IT
                For Each row As DataGridViewRow In gridbill.Rows
                    If row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value.ToString = txtbillno.Text.Trim Then
                        row.Cells(gridbill.Columns("INVCHK").Index).Value = 1
                        txtbillno.Clear()
                        txtbillno.Focus()
                        total()

                        'DIRECTLY ADDING IN GRID (AS PRE DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = row.Cells(gridbill.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = row.Cells(gridbill.Columns("INVBALAMT").Index).Value
                        txtamt_Validating(sender, e)

                        Exit Sub
                    End If
                Next


                'IF BILL IS NOT PRESENT IN GRID THEN ADD THE BILL IN GRID
                Dim OBJCMN As New ClsCommon
                'CHECKING IN INVOICE
                Dim DT As DataTable = OBJCMN.search("INVOICEMASTER.invoice_initials AS BILLINITIALS, INVOICEMASTER.invoice_date AS BILLDATE, INVOICEMASTER.INVOICE_BALANCE AS BALAMT, INVOICEMASTER.INVOICE_GRANDTOTAL AS BILLAMT, 'INVOICE' AS BILLTYPE, INVOICEMASTER.INVOICE_NO AS BILLNO, REGISTERMASTER.REGISTER_NAME AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " INVOICEMASTER LEFT OUTER JOIN LEDGERS ON INVOICEMASTER.invoice_yearid = LEDGERS.Acc_yearid AND INVOICEMASTER.invoice_locationid = LEDGERS.Acc_locationid AND INVOICEMASTER.invoice_cmpid = LEDGERS.Acc_cmpid AND INVOICEMASTER.invoice_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON register_id  = INVOICEMASTER.INVOICE_REGISTERID AND register_cmpid = INVOICE_CMPID AND register_locationid = INVOICE_LOCATIONID AND register_yearid = INVOICE_YEARID ", " AND ( INVOICEMASTER.INVOICE_INITIALS = '" & txtbillno.Text.Trim & "') AND INVOICE_BALANCE > 0  AND (INVOICEMASTER.invoice_cmpid = " & CmpId & ") AND (INVOICEMASTER.invoice_locationid = " & Locationid & ") AND (INVOICEMASTER.invoice_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If


                'CHECKING IN OPENINGBILL
                DT = OBJCMN.search("BILL_INITIALS AS BILLINITIALS, BILL_DATE AS BILLDATE, BILL_BALANCE AS BALAMT, BILL_AMT AS BILLAMT, 'OPENING' AS BILLTYPE, BILL_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTERMASTER.register_id AND BILL_CMPID = REGISTERMASTER.register_cmpid AND BILL_LOCATIONID = REGISTERMASTER.register_locationid AND BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON BILL_LEDGERID = LEDGERS.Acc_id AND BILL_CMPID = LEDGERS.Acc_cmpid AND BILL_LOCATIONID = LEDGERS.Acc_locationid AND BILL_YEARID = LEDGERS.Acc_yearid ", " AND ( BILL_INITIALS = '" & txtbillno.Text.Trim & "') AND BILL_BALANCE > 0  AND (BILL_cmpid = " & CmpId & ") AND (BILL_locationid = " & Locationid & ") AND (BILL_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If




                'CHECKING IN JOURNAL
                DT = OBJCMN.search("JOURNALMASTER.journal_initials, JOURNALMASTER.journal_date, SUM(JOURNALMASTER.journal_debit) - (JOURNALMASTER.JOURNAL_AMT + JOURNALMASTER.journal_tds) AS BALAMT, SUM(JOURNALMASTER.journal_debit) AS BILLAMT, 'JOURNAL' AS BILLTYPE, JOURNALMASTER.journal_no AS BILLNO, REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " REGISTERMASTER INNER JOIN JOURNALMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.journal_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.journal_cmpid AND REGISTERMASTER.register_locationid = JOURNALMASTER.journal_locationid AND REGISTERMASTER.register_yearid = JOURNALMASTER.journal_yearid INNER JOIN LEDGERS ON JOURNALMASTER.journal_yearid = LEDGERS.Acc_yearid AND JOURNALMASTER.journal_locationid = LEDGERS.Acc_locationid AND JOURNALMASTER.journal_cmpid = LEDGERS.Acc_cmpid AND JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id ", " AND ( JOURNALMASTER.JOURNAL_INITIALS = '" & txtbillno.Text.Trim & "') AND ((JOURNALMASTER.journal_amt + JOURNALMASTER.journal_tds) < JOURNALMASTER.journal_debit)  AND (JOURNALMASTER.journal_cmpid = " & CmpId & ") AND (JOURNALMASTER.journal_locationid = " & Locationid & ") AND (JOURNALMASTER.journal_yearid = " & YearId & ") GROUP BY JOURNALMASTER.journal_initials, JOURNALMASTER.journal_date, JOURNALMASTER.journal_amt, JOURNALMASTER.journal_tds,  JOURNALMASTER.journal_no, REGISTERMASTER.register_name, LEDGERS.ACC_CMPNAME ")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If


                'CHECKING IN NONPURCHASE
                DT = OBJCMN.search("NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_BALANCE AS BALAMT, NONPURCHASE.NP_TOTALAMT AS BILLAMT, 'EXPENSE' AS BILLTYPE, NONPURCHASE.NP_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id AND NONPURCHASE.NP_CMPID = REGISTERMASTER.register_cmpid AND NONPURCHASE.NP_LOCATIONID = REGISTERMASTER.register_locationid AND NONPURCHASE.NP_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid AND NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid ", " AND ( NONPURCHASE.NP_INITIALS = '" & txtbillno.Text.Trim & "') AND NONPURCHASE.NP_BALANCE > 0  AND (NONPURCHASE.NP_cmpid = " & CmpId & ") AND (NONPURCHASE.NP_locationid = " & Locationid & ") AND (NONPURCHASE.NP_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If


                'CHECKING IN PAYMENT
                DT = OBJCMN.search(" CAST(PAYMENTMASTER_DESC.PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENTMASTER.PAYMENT_DATE AS BILLDATE, PAYMENTMASTER_DESC.PAYMENT_BALANCE AS BALAMT, PAYMENTMASTER_DESC.PAYMENT_AMT AS BILLAMT, 'PAYMENT' AS BILLTYPE, PAYMENTMASTER.PAYMENT_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME", "", " PAYMENTMASTER INNER JOIN PAYMENTMASTER_DESC ON PAYMENTMASTER.PAYMENT_NO =PAYMENTMASTER_DESC.PAYMENT_NO AND PAYMENTMASTER.PAYMENT_REGISTERID = PAYMENTMASTER_DESC.PAYMENT_REGISTERID AND PAYMENTMASTER.PAYMENT_YEARID = PAYMENTMASTER_DESC.PAYMENT_YEARID INNER JOIN REGISTERMASTER ON PAYMENTMASTER.PAYMENT_REGISTERID = REGISTERMASTER.register_id AND PAYMENTMASTER.PAYMENT_CMPID = REGISTERMASTER.register_cmpid AND PAYMENTMASTER.PAYMENT_LOCATIONID = REGISTERMASTER.register_locationid AND PAYMENTMASTER.PAYMENT_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON PAYMENTMASTER.PAYMENT_LEDGERID = LEDGERS.Acc_id AND PAYMENTMASTER.PAYMENT_CMPID = LEDGERS.Acc_cmpid AND PAYMENTMASTER.PAYMENT_LOCATIONID = LEDGERS.Acc_locationid AND PAYMENTMASTER.PAYMENT_YEARID = LEDGERS.Acc_yearid ", " AND ( CAST(PAYMENTMASTER_DESC.PAYMENT_GRIDREMARKS AS VARCHAR(100)) = '" & txtbillno.Text.Trim & "') AND PAYMENTMASTER_DESC.PAYMENT_PAYTYPE = 'New Ref' AND PAYMENTMASTER_DESC.PAYMENT_BALANCE > 0  AND (PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & ") AND (PAYMENTMASTER.PAYMENT_locationid = " & Locationid & ") AND (PAYMENTMASTER.PAYMENT_yearid = " & YearId & ")")
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        cmbname.Text = DT.Rows(0).Item("NAME")
                    ElseIf cmbname.Text.Trim <> DT.Rows(0).Item("NAME") Then
                        MsgBox("Bill does not belong to the same Customer")
                        txtbillno.Clear()
                        txtbillno.Focus()
                        Exit Sub
                    End If

                    'IF NO RECORDS ARE PRESENT IN GRID THEN SET DATASOURCE PROPERTY
                    If gridbill.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = gridbill.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"))
                        Next
                    End If
                End If


                For Each ROW As DataGridViewRow In gridbill.Rows
                    If ROW.Cells("INVBILLINITIALS").Value = txtbillno.Text.Trim Then ROW.Cells("INVCHK").Value = 1
                Next
                total()
                txtbillno.Clear()
                txtbillno.Focus()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbbillno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbillno.GotFocus
        fillcmbbillno()
    End Sub

    Private Sub chkselectall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkselectall.CheckedChanged
        For Each row As DataGridViewRow In gridbill.Rows
            row.Cells(gridbill.Columns("INVCHK").Index).Value = chkselectall.CheckState
        Next
        total()
    End Sub

    Private Sub cmbbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbillno.Validating
        Try

            lblbilltotal.Text = ""

            If cmbbillno.Text.Trim <> "" Then
                cmbbillno.Text = UCase(cmbbillno.Text)

                'CHECKING WHETHER THE BILL IS VALID OR NOT
                Dim BLN As Boolean = False
                For Each ITEMS As Object In cmbbillno.Items
                    If ITEMS.ToString = cmbbillno.Text.Trim Then
                        BLN = True
                    End If
                Next
                If Not BLN Then
                    MsgBox("Invalid Bill No.", MsgBoxStyle.Critical, "PROTRADE")
                    cmbbillno.Focus()
                    Exit Sub
                End If



                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID , INVOICE_LOCATIONID AS LOCATIONID , INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref' ) AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    lblbilltotal.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
                End If

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamt.Validating
        Try
            If txtsrno.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)

            If txtsrno.Text.Trim.Length > 0 And Val(txtamt.Text) > 0 Then
                If cmbpaytype.Text = "Against Bill" And cmbbillno.Text.Trim = "" Then
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "PROTRADE")
                    cmbpaytype.Focus()
                    Exit Sub
                End If

                If cmbbillno.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In gridpayment.Rows
                        If (ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And ROW.Index <> TEMPROW) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "PROTRADE")
                            cmbpaytype.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                fillgrid()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'RECEIPT'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_receiptmaster()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable = clscommon.search(" register_abbr, register_initials, register_id, ISNULL(ACC_CMPNAME,'') AS NAME ", "", " RegisterMaster LEFT OUTER JOIN LEDGERS ON REGISTER_LEDGERID = ACC_ID ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'RECEIPT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    recregabbr = dt.Rows(0).Item(0).ToString
                    recreginitial = dt.Rows(0).Item(1).ToString
                    recregid = dt.Rows(0).Item(2)
                    cmbaccname.Text = dt.Rows(0).Item("NAME")
                    getmaxno_receiptmaster()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            EP.Clear()
            If CMDRECO.Visible = True Then
                EP.SetError(CMDRECO, "Bank Reco Done !")
                MsgBox(" Bank Reco Done !")
            Else
                If EDIT = True Then
                    If USERDELETE = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    Dim tempmsg As Integer = MsgBox("Delete Receipt Entry Permanently?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then

                        Dim OBJREC As New ClsReceiptMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPRECEIPTNO)
                        ALPARAVAL.Add(TEMPREGNAME)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJREC.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJREC.Delete()
                        MsgBox(DT.Rows(0).Item(0).ToString)

                        clear()

                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                Dim objrec As New receipt_advice
                objrec.recno = Val(txtaccno.Text)
                objrec.recname = cmbname.Text.Trim
                objrec.REGNAME = cmbregister.Text.Trim
                objrec.MdiParent = MDIMain
                objrec.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchqno.Validating
        Try
            If ClientName <> "SAKARIA" And ClientName <> "SUNCOTT" And ClientName <> "AVIS" Then
                If txtchqno.Text.Trim <> "" And txtchqno.Text.Trim <> "RTGS" And txtchqno.Text.Trim <> "NEFT" Then
                    'checking whether CHQNO IS ALREADY PAID WITH THE SAME BANK OR NOT....
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" RECEIPT_INITIALS", "", " RECEIPTMASTER ", " AND RECEIPT_BANKNAME = '" & CMBPARTYBANK.Text.Trim & "' AND RECEIPT_CHQNO = '" & txtchqno.Text.Trim & "' AND RECEIPT_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If (EDIT = False) Or (EDIT = True And CHQNO <> txtchqno.Text.Trim) Then
                            MsgBox("Chq. No. Already Present with this Bank in Receipt No." & DT.Rows(0).Item(0), MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If gridpayment.RowCount > 0 Then
                txtsrno.Text = Val(gridpayment.Rows(gridpayment.RowCount - 1).Cells(gridsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtdescsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescsrno.GotFocus
        If GRIDDESCDOUBLECLICK = False Then
            If gridpaydesc.RowCount > 0 Then
                txtdescsrno.Text = Val(gridpaydesc.Rows(gridpaydesc.RowCount - 1).Cells(descgridsrno.Index).Value) + 1
            Else
                txtdescsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub cmbpaytype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.SelectedIndexChanged
        Try
            lblbilltotal.Text = ""
            cmbbillno.Text = ""
            If cmbpaytype.Text = "Against Bill" Then
                cmbbillno.Enabled = True
            Else
                cmbbillno.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbpaytype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.Validated
        Try
            If cmbpaytype.Text = "Against Bill" Then cmbbillno.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdescamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdescamt.Validating
        Try
            If txtdescsrno.Text.Trim.Length = 0 Then txtdescsrno_GotFocus(sender, e)

            If txtdescsrno.Text.Trim.Length > 0 And Val(txtdescamt.Text) > 0 And cmbledgername.Text.Trim <> "" Then
                fillgridDESC()
            Else
                MsgBox("Fill Details")
                cmbledgername.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpaydesc_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpaydesc.CellDoubleClick
        Try
            If e.RowIndex >= 0 And gridpaydesc.Item(gridsrno.Index, e.RowIndex).Value <> Nothing Then
                GRIDDESCDOUBLECLICK = True
                txtdescsrno.Text = gridpaydesc.Item(descgridsrno.Index, e.RowIndex).Value.ToString
                cmbledgername.Text = gridpaydesc.Item(gname.Index, e.RowIndex).Value.ToString
                txtdescnarr.Text = gridpaydesc.Item(descnarr.Index, e.RowIndex).Value.ToString
                txtdescamt.Text = gridpaydesc.Item(descamt.Index, e.RowIndex).Value.ToString
                LBLPAYGRIDSRNO.Text = gridpaydesc.Item(PAYGRIDSRNO.Index, e.RowIndex).Value.ToString
                LBLPAYBILLINITIALS.Text = gridpaydesc.Item(PAYBILLINITIALS.Index, e.RowIndex).Value.ToString

                TEMPDESCROW = e.RowIndex
                txtdescsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpaydesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpaydesc.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                'if LINE IS IN EDIT MODE (GRIDDESCDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
                If GRIDDESCDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'REMOVING ROWS FROM GRIDDESC
1:
                For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    If ROW.Cells(DPAYGRIDSRNO.Index).Value = gridpaydesc.Rows(gridpaydesc.CurrentRow.Index).Cells(PAYGRIDSRNO.Index).Value Then
                        GRIDDESC.Rows.RemoveAt(ROW.Index)
                        GoTo 1
                    End If
                Next

                gridpaydesc.Rows.RemoveAt(gridpaydesc.CurrentRow.Index)
                total()
                getsrno(gridpaydesc)
                txtdescsrno.Focus()

                'AGAIN INSERT THE COMPLETE GRIDPAYDESC IN GRIDDESC
                For Each ROW As DataGridViewRow In gridpaydesc.Rows
                    GRIDDESC.Rows.Add(ROW.Cells(descgridsrno.Index).Value, ROW.Cells(gname.Index).Value, ROW.Cells(descnarr.Index).Value, ROW.Cells(descamt.Index).Value, ROW.Cells(PAYGRIDSRNO.Index).Value, ROW.Cells(PAYBILLINITIALS.Index).Value)
                Next
                
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbledgername_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbledgername.Enter
        Try
            'OPEN ALL LEDGERS
            If cmbledgername.Text.Trim = "" Then fillledger(cmbledgername, EDIT, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbledgername_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbledgername.Validating
        Try
            If cmbledgername.Text.Trim <> "" Then ledgervalidate(cmbledgername, CMBACCCODE, e, Me, txtadd, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqamt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtchqamt.Validated
        Try
            If Val(txtamt.Text) = 0 Then txtamt.Text = Val(txtchqamt.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            Cursor.Current = Cursors.WaitCursor
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
            GRIDDESC.RowCount = 0
            TEMPRECEIPTNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            clear()
            If TEMPRECEIPTNO > 0 Then
                edit = True
                Receipt_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDRECO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDRECO.Click
        Try
            Dim objbankreco As New BankReco
            objbankreco.txtname.Text = cmbaccname.Text.Trim
            objbankreco.chkAll.CheckState = CheckState.Checked
            objbankreco.dtfrom.Value = getfirstdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.dtto.Value = getlastdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.MdiParent = MDIMain
            objbankreco.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaccname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbaccname.Validated
        If cmbaccname.Text.Trim <> "" Then
            GETBALANCE()
        End If
    End Sub

    Private Sub TXTBANKNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJPARTYBANK As New SelectPartyBank
                OBJPARTYBANK.FRMSTRING = "PARTYBANK"
                OBJPARTYBANK.ShowDialog()
                If OBJPARTYBANK.TEMPNAME <> "" Then CMBPARTYBANK.Text = OBJPARTYBANK.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Receipt_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
        If TEMPAUTOENTRY = True Then
            Dim A As System.ComponentModel.CancelEventArgs
            ACCDATE.Text = Now.Date

            cmbname.Focus()
            cmbaccname.Text = "Cash In Hand"
            cmbname.Text = TEMPNAME
            cmbname_Validating(sender, A)

            txtchqamt.Text = Format(Val(TEMPAMT), "0.00")
            txtamt.Text = Format(Val(TEMPAMT), "0.00")

            chkchange.CheckState = CheckState.Checked

            cmbpaytype.Text = "On Account"
            cmbbillno.Text = ""
            cmbbillno.Enabled = False

            txtnarr.Clear()
            txtamt_Validating(sender, A)

        End If
        'If ClientName = "CC" Or ClientName = "SHREEDEV" Then txtremarks.Text = TEMPBILLNO
        If ClientName = "MAHAVIR" Or ClientName = "PURVITEX" Or ClientName = "SOFTAS" Then ALLOWMANUALRECNO = True
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

    Private Sub cmbledgername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbledgername.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbledgername.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ACCDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACCDATE.GotFocus
        ACCDATE.SelectionStart = 0
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Call ToolStripdelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPRECEIPTNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(RECNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJREC As New receipt_advice
            OBJREC.MdiParent = MDIMain
            OBJREC.DIRECTPRINT = True
            OBJREC.FRMSTRING = "RECEIPT"
            OBJREC.DIRECTMAIL = False
            OBJREC.DIRECTWHATSAPP = True
            OBJREC.REGNAME = cmbregister.Text.Trim
            OBJREC.PRINTSETTING = PRINTDIALOG
            OBJREC.recno = Val(RECNO)
            OBJREC.NOOFCOPIES = 1
            OBJREC.Show()
            OBJREC.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.AGENTNAME = GETAGENTNAME(cmbname.Text.Trim)
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\RECEIPT_" & Val(RECNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("RECEIPT_" & Val(RECNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ACCDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ACCDATE.Validating
        Try
            If ACCDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(ACCDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If EDIT = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True And TXTMOBILENO.Text.Trim <> "" Then
            If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim MSG As String = ""
            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Bank A/C" Or DT.Rows(0).Item(0) = "Bank OD A/C" Then
                    If ClientName = "KOTHARI" Then
                        MSG = "PAYMENT RECEIVED " & "\n" & "Chq No - " & txtchqno.Text.Trim & "\n" & "Dt - " & ACCDATE.Text & "\n" & "Amt - " & Val(txtchqamt.Text.Trim) & "\n"
                        For Each ROW As DataGridViewRow In gridpayment.Rows
                            If DT.Rows.Count > 0 Then
                                MSG = MSG + "BN - " & ROW.Cells(gbillno.Index).Value & " = " & Val(ROW.Cells(gamt.Index).Value) & "\n"
                            End If
                        Next
                    Else
                        If ClientName = "NVAHAN" Then MSG = "PAYMENT RECEIVED " & vbCrLf & "Chq No - " & txtchqno.Text.Trim & vbCrLf & "Dt - " & ACCDATE.Text & vbCrLf & "Amt - " & Val(txtchqamt.Text.Trim) & vbCrLf & "Bank - " & CMBPARTYBANK.Text.Trim Else MSG = "Hi, Your Account is Credited by Chq for Rs. " & Val(txtchqamt.Text.Trim) & "\n" & "Chq No - " & txtchqno.Text.Trim & "\n" & "Bank - " & CMBPARTYBANK.Text.Trim & "\n" & "Dt-" & ACCDATE.Text
                    End If
                ElseIf DT.Rows(0).Item(0) = "Cash In Hand" Then
                    MSG = "Hi, Your Account is Credited by Cash for Rs. " & Val(txtchqamt.Text.Trim) & "\n" & "Dt-" & ACCDATE.Text
                End If
            End If
            If SENDMSG(MSG, TXTMOBILENO.Text.Trim) = "1701" Then
                MsgBox("Message Sent")
                DT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER SET RECEIPT_SMSSEND = 1 FROM RECEIPTMASTER INNER JOIN REGISTERMASTER ON RECEIPT_REGISTERID = REGISTER_ID WHERE RECEIPT_NO = " & TEMPRECEIPTNO & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND RECEIPT_YEARID = " & YearId, "", "")
                LBLSMS.Visible = True
            Else
                MsgBox("Error Sending Message")
            End If

        End If
    End Sub

    Private Sub txtaccno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtaccno.Validating
        Try
            If (Val(txtaccno.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPRECEIPTNO <> Val(txtaccno.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtaccno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(RECEIPTMASTER.RECEIPT_no,0) AS PAYMENTNO, REGISTERMASTER.register_name AS REGNAME", "", " REGISTERMASTER INNER JOIN RECEIPTMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.RECEIPT_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.RECEIPT_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.RECEIPT_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.RECEIPT_yearid ", "  AND RECEIPTMASTER.RECEIPT_no=" & txtaccno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND RECEIPTMASTER.RECEIPT_cmpid = " & CmpId & " AND RECEIPTMASTER.RECEIPT_locationid = " & Locationid & " AND RECEIPTMASTER.RECEIPT_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Receipt No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtaccno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaccno.KeyPress
        numkeypress(e, txtaccno, Me)
    End Sub

    Private Sub gridbill_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbill.KeyDown
        Dim ARGS As New DataGridViewCellEventArgs(gridbill.CurrentCell.ColumnIndex, gridbill.CurrentRow.Index)
        If e.KeyCode = Keys.F8 Then Call gridbill_CellClick(sender, ARGS)
    End Sub
End Class