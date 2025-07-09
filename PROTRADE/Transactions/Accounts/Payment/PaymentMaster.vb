
Imports BL
Imports System.Windows.Forms

Public Class PaymentMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDDESCDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPPAYMENTNO As Integer
    Public TEMPREGNAME As String
    Dim payregabbr, payreginitial As String
    Dim payregid As Integer
    Dim TEMPROW, tempdescrow As Integer
    Dim temprecodate As Date
    Dim CHQNO As String = ""
    Dim ALLOWMANUALPAYNO As Boolean = False

    'THIS VARIABLE IS USED TO FETCH PARTYNAME ON EDIT MODE
    'ON NAME VALIDATING IF TEMPNAME <> CMBNAME THEN CLEAR THE BELOW GRID, ELSE DO NOT CLEAR
    Dim TEMPPARTYNAME As String = ""


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

        If ALLOWMANUALPAYNO = True Then
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
        cmbaccname.Enabled = True
        RECODATE.Enabled = True
        'AS THEY WANT TO KEEP THE ACCOUNTNAME SAME
        'cmbaccname.Text = ""

        txtchqamt.Clear()
        txtchqno.Clear()
        txtcramt.Clear()
        txtledgerbal.Clear()
        txtChqbal.Clear()
        lblbaldrcr.Text = ""
        tstxtbillno.Clear()
        txtbillno.Clear()
        chkselectall.Checked = False
        TXTINVTOTAL.Clear()
        txttotal.Clear()
        TXTDESCTOTAL.Clear()
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


        payregabbr = ""
        payreginitial = ""

        GRIDBILL.DataSource = Nothing
        gridpayment.RowCount = 0

        GPDESC.Enabled = False
        gridpaydesc.RowCount = 0
        GRIDDESC.RowCount = 0
        gridpayment.RowCount = 0
        getmaxno_PAYMENTmaster()

        'AS THEY WANT TO KEEP THE DATE SAME
        'ACCDATE.Value = now.date

        EDIT = False
        GRIDDOUBLECLICK = False
        GRIDDESCDOUBLECLICK = False

        lbllocked.Visible = False
        PBlock.Visible = False
        LBLSMS.Visible = False

    End Sub

    Sub getmaxno_PAYMENTmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PAYMENT_NO),0) + 1 ", "PAYMENTMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = PAYMENT_REGISTERID AND REGISTER_CMPID = PAYMENT_CMPID AND REGISTER_LOCATIONID = PAYMENT_LOCATIONID AND REGISTER_YEARID = PAYMENT_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PAYMENT' AND PAYMENT_cmpid=" & CmpId & " AND PAYMENT_LOCATIONid=" & Locationid & " AND PAYMENT_YEARid=" & YearId)
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
            'If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and (groupmaster.group_SECONDARY = 'Sundry Creditors' or groupmaster.group_SECONDARY = 'Indirect Expenses' or groupmaster.group_SECONDARY = 'Direct Expenses') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
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

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Reco Done, Payment Locked")
                BLN = False
            End If

            If ALLOWMANUALPAYNO = True Then
                If txtaccno.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon

                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0) AS PAYMENTNO, REGISTERMASTER.register_name AS REGNAME", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtaccno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(txtaccno, "Payment No Already Exist")
                        BLN = False
                    End If
                End If
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

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Select Register Name")
                BLN = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, "Select Name")
                BLN = False
            End If

            If cmbaccname.Text.Trim.Length = 0 Then
                EP.SetError(cmbaccname, "Select Account Name")
                BLN = False
            End If

            If gridpayment.RowCount = 0 Then
                EP.SetError(TXTCHQNO, "Enter Payment Details")
                BLN = False
            End If

            If txtchqamt.Text.Trim.Length = 0 Then
                EP.SetError(txtchqamt, "Enter Amount")
                BLN = False
            End If

            If Val(txtchqamt.Text.Trim) <> Val(txttotal.Text.Trim) Then
                EP.SetError(txttotal, "Total does not match Amount")
                BLN = False
            End If



            If ClientName <> "ALENCOT" Then
                Dim OBJCMN1 As New ClsCommon
            Dim DT As DataTable = OBJCMN1.search(" GROUP_SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Bank A/C" Or DT.Rows(0).Item(0) = "Bank OD A/C" Then
                        'DONT MANDATE CHQ NO AS THERE ARE RTGS ENTRIES AS WELL
                        'If txtchqno.Text.Trim.Length = 0 Then
                        '    EP.SetError(txtchqno, "Enter Chq No.")
                        '    BLN = False
                        'End If

                        If TXTCHQNO.Text.Trim.Length = 0 Then
                            Dim TEMPMSG As Integer = MsgBox("Chq No. is Blank, Proceed?", MsgBoxStyle.YesNo)
                            If TEMPMSG = vbNo Then
                                EP.SetError(TXTCHQNO, "Enter Chq No.")
                                BLN = False
                            End If
                        End If
                    ElseIf DT.Rows(0).Item(0) = "Cash In Hand" Then
                        TXTCHQNO.Clear()
                    End If
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

    Private Sub PaymentMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.Control = True And e.Shift = True And e.KeyCode = Windows.Forms.Keys.R Then       'for Copy Old Narration
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(PAYMENT_REMARKS,'') AS REMARKS", "", " PAYMENTMASTER ", "  AND PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId & "ORDER BY PAYMENT_NO DESC ")
            If DT.Rows.Count > 0 Then txtremarks.Text = DT.Rows(0).Item("REMARKS")
            txtremarks.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F2 Then
            tstxtbillno.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            gridpayment.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then
            GRIDBILL.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub PaymentMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYMENT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            'getmaxno_PAYMENTmaster()
            fillledger(cmbname, EDIT, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            fillledger(cmbaccname, edit, " and (groupmaster.group_secondary = 'BANK A/C' OR groupmaster.group_secondary = 'BANK OD A/C' OR groupmaster.group_secondary = 'CASH IN HAND') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            fillregister(cmbregister, " and register_type = 'PAYMENT'")

            LBLSMS.Visible = False

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
                Dim OBJCLPAYMENT As New ClsPaymentMaster()
                dt = OBJCLPAYMENT.selectbill_edit(TEMPPAYMENTNO, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then

                    gridpayment.RowCount = 0
                    gridpaydesc.RowCount = 0
                    GRIDDESC.RowCount = 0

                    For Each dr As DataRow In dt.Rows

                        txtaccno.Text = TEMPPAYMENTNO
                        txtaccno.ReadOnly = True

                        cmbregister.Text = Convert.ToString(dr("REGISTERNAME"))
                        ACCDATE.Text = Format(Convert.ToDateTime(dr("ACCDATE")).Date, "dd/MM/yyyy")
                        cmbaccname.Text = Convert.ToString(dr("ACCNAME"))
                        cmbname.Text = Convert.ToString(dr("LEDGERNAME"))

                        TEMPPARTYNAME = cmbname.Text.Trim

                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))
                        txtchqamt.Text = Convert.ToString(Format(dr("CHQAMT"), "0.00"))
                        TXTCHQNO.Text = Convert.ToString(dr("CHQNO"))
                        CHQNO = TXTCHQNO.Text
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        TXTOURREMARKS.Text = Convert.ToString(dr("OURREMARKS"))

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

                        gridpayment.Rows.Add(0, dr("GRIDSRNO"), dr("PAYTYPE").ToString, dr("BILLINITIALS").ToString, dr("NARR").ToString, Format(dr("AMT"), "0.00"), Format(Val(dr("AMTREC")), "0.00"), Format(dr("EXTRAAMT"), "0.00"), Format(dr("RETURN"), "0.00"), Format(dr("BALANCE"), "0.00"))
                        If Val(dr("AMTREC")) > 0 Or Val(dr("EXTRAAMT")) > 0 Or Val(dr("RETURN")) > 0 Then
                            gridpayment.Rows(gridpayment.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    Dim OBJCMN As New ClsCommon
                    Dim DT1 As DataTable = OBJCMN.search(" PAYMENTMASTER_GRIDDESC.PAYMENT_DESCGRIDSRNO AS DESCGRIDSRNO, LEDGERS.Acc_cmpname AS DESCLEDGERNAME, PAYMENTMASTER_GRIDDESC.PAYMENT_DESCGRIDREMARKS AS DESCNARR, PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT AS DESCAMT, PAYMENTMASTER_GRIDDESC.PAYMENT_PAYGRIDSRNO AS PAYGRIDSRNO, PAYMENT_PAYBILLINITIALS AS PAYBILLINITIALS ", "", "  PAYMENTMASTER_GRIDDESC INNER JOIN LEDGERS ON PAYMENTMASTER_GRIDDESC.PAYMENT_DESCLEDGERID = LEDGERS.Acc_id AND PAYMENTMASTER_GRIDDESC.PAYMENT_CMPID = LEDGERS.Acc_cmpid AND PAYMENTMASTER_GRIDDESC.PAYMENT_LOCATIONID = LEDGERS.Acc_locationid AND PAYMENTMASTER_GRIDDESC.PAYMENT_YEARID = LEDGERS.Acc_yearid INNER JOIN REGISTERMASTER ON PAYMENTMASTER_GRIDDESC.PAYMENT_REGISTERID = REGISTERMASTER.register_id AND PAYMENTMASTER_GRIDDESC.PAYMENT_CMPID = REGISTERMASTER.register_cmpid AND PAYMENTMASTER_GRIDDESC.PAYMENT_LOCATIONID = REGISTERMASTER.register_locationid AND PAYMENTMASTER_GRIDDESC.PAYMENT_YEARID = REGISTERMASTER.register_yearid", " AND (PAYMENTMASTER_GRIDDESC.PAYMENT_no = " & TEMPPAYMENTNO & ") AND (REGISTERMASTER.register_name = '" & cmbregister.Text.Trim & "') AND (PAYMENTMASTER_GRIDDESC.PAYMENT_cmpid = " & CmpId & ") AND (PAYMENTMASTER_GRIDDESC.PAYMENT_locationid = " & Locationid & ") AND (PAYMENTMASTER_GRIDDESC.PAYMENT_YEARid = " & YearId & ")")
                    For Each DR1 As DataRow In DT1.Rows
                        GRIDDESC.Rows.Add(DR1("DESCGRIDSRNO").ToString, DR1("DESCLEDGERNAME").ToString, DR1("DESCNARR").ToString, Format(DR1("DESCAMT"), "0.00"), DR1("PAYGRIDSRNO"), DR1("PAYBILLINITIALS").ToString)
                        gridpayment.Rows(DR1("PAYGRIDSRNO") - 1).DefaultCellStyle.BackColor = Drawing.Color.LightGreen
                    Next

                    'filling gridPURCHASE
                    fillgridPURCHASE()

                    cmbregister.Enabled = False
                    ACCDATE.Focus()
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
            If cmbname.Text.Trim <> "" And EDIT = True Then
                GRIDBILL.DataSource = Nothing
                gridpayment.RowCount = 0
                GPDESC.Enabled = False
                gridpaydesc.RowCount = 0
                GRIDDESC.RowCount = 0
                txttotal.Clear()
                TXTDESCTOTAL.Clear()
                If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                    fillgridPURCHASE()
                End If
            End If


            If cmbname.Text.Trim <> "" Then
                GETBALANCE()
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'Sundry Creditors' or groupmaster.group_SECONDARY = 'Indirect Expenses' or groupmaster.group_SECONDARY = 'Direct Expenses') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                fillgridPURCHASE()
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
            Dim DTTABLE As DataTable

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            'GET BILLREMARKS
            TXTBILLREMARKS.Clear()
            For Each ROW As DataGridViewRow In gridpayment.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" Then
                    'GET PARTYBILLNO
                    Dim TEMPPBILLNO As String = ""
                    Dim OBJCMN As New ClsCommon
                    Dim DTBILL As DataTable = OBJCMN.search("PARTYBILLNO ", "", "PAYMENTBILLDETAILS", " AND INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND YEARID = " & YearId)
                    If DTBILL.Rows.Count > 0 Then TEMPPBILLNO = DTBILL.Rows(0).Item("PARTYBILLNO")
                    If TXTBILLREMARKS.Text = "" Then
                        TXTBILLREMARKS.Text = "Against Bill - " & TEMPPBILLNO
                    Else
                        TXTBILLREMARKS.Text = TXTBILLREMARKS.Text & ", " & TEMPPBILLNO
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
            alparaval.Add(TXTCHQNO.Text.Trim)
            alparaval.Add(txtremarks.Text.Trim)
            alparaval.Add(TXTBILLREMARKS.Text.Trim)
            alparaval.Add(TXTOURREMARKS.Text.Trim)
            alparaval.Add(txtinwords.Text.Trim)

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
            Dim AMTREC As String = ""
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
                        amt = row.Cells(gamt.Index).Value
                        AMTREC = row.Cells(GAMTREC.Index).Value
                        EXTRAAMT = row.Cells(GEXTRAAMT.Index).Value
                        RETURNAMT = row.Cells(GRETURN.Index).Value
                        BALANCE = row.Cells(gBALANCE.Index).Value
                    Else

                        pgridsrno = pgridsrno & "|" & row.Cells(gridsrno.Index).Value.ToString
                        paytype = paytype & "|" & row.Cells(gpaytype.Index).Value
                        billINITIALS = billINITIALS & "|" & row.Cells(gbillno.Index).Value.ToString
                        narr = narr & "|" & row.Cells(gdesc.Index).Value
                        amt = amt & "|" & row.Cells(gamt.Index).Value
                        AMTREC = AMTREC & "|" & row.Cells(GAMTREC.Index).Value
                        EXTRAAMT = EXTRAAMT & "|" & row.Cells(gEXTRAAMT.Index).Value
                        RETURNAMT = RETURNAMT & "|" & row.Cells(GRETURN.Index).Value
                        BALANCE = BALANCE & "|" & row.Cells(gBALANCE.Index).Value

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
            alparaval.Add(AMTREC)
            alparaval.Add(EXTRAAMT)
            alparaval.Add(RETURNAMT)
            alparaval.Add(BALANCE)

            alparaval.Add(dgridsrno)
            alparaval.Add(descledgername)
            alparaval.Add(descnarration)
            alparaval.Add(descamount)
            alparaval.Add(DESCPAYGRIDSRNO)
            alparaval.Add(DESCPAYBILLINITIALS)


            Dim OBJpayment As New ClsPaymentMaster
            OBJpayment.alParaval = alparaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJpayment.save()
                MessageBox.Show("Details Added")
                'Dim TEMPMSG As Integer = MsgBox("Print Payment Voucher?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim objPAY As New payment_advice
                '    objPAY.payno = Val(DTTABLE.Rows(0).Item(0))
                '    objPAY.payname = cmbname.Text.Trim
                '    objPAY.REGNAME = cmbregister.Text.Trim
                '    objPAY.MdiParent = MDIMain
                '    objPAY.Show()
                'End If

                'TEMPMSG = MsgBox("Wish to Print Chq?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim OBJCHQPRINT As New payment_advice
                '    OBJCHQPRINT.payno = Val(DTTABLE.Rows(0).Item(0))
                '    OBJCHQPRINT.FRMSTRING = "CHQPRINT"
                '    OBJCHQPRINT.REGNAME = cmbregister.Text.Trim
                '    OBJCHQPRINT.MdiParent = MDIMain
                '    OBJCHQPRINT.Show()
                'End If

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPPAYMENTNO)
                Dim IntResult As Integer = OBJpayment.update()
                MsgBox("Details Updated")
                EDIT = False

                'Dim TEMPMSG As Integer = MsgBox("Print Payment Voucher?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim objPAY As New payment_advice
                '    objPAY.payno = Val(TEMPPAYMENTNO)
                '    objPAY.payname = cmbname.Text.Trim
                '    objPAY.REGNAME = cmbregister.Text.Trim
                '    objPAY.MdiParent = MDIMain
                '    objPAY.Show()
                'End If


                'TEMPMSG = MsgBox("Wish to Print Chq?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then
                '    Dim OBJCHQPRINT As New payment_advice
                '    OBJCHQPRINT.payno = Val(TEMPPAYMENTNO)
                '    OBJCHQPRINT.REGNAME = cmbregister.Text.Trim
                '    OBJCHQPRINT.FRMSTRING = "CHQPRINT"
                '    OBJCHQPRINT.MdiParent = MDIMain
                '    OBJCHQPRINT.Show()
                'End If

            End If
            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            If ClientName = "NVAHAN" Or ClientName = "SAKARIA" Then SENDDIRECTMAIL()
            If ClientName <> "REAL" Then PRINTREPORT()
            Call toolnext_Click(sender, e)
            If ClientName = "AVIS" Or ClientName = "MAHAVIR" Then ACCDATE.Focus() Else cmbaccname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDDIRECTMAIL()
        Try

            If MsgBox("Wish To Mail Payment Advice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'CHECK WHETHER EMAILID IS PRESENT IN LEDGER OR NOT, IF NOT THEN EXIT SUB WITH MESSAGE
            Dim OBJCMN As New ClsCommon
            Dim DTEMAIL As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", "AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DTEMAIL.Rows.Count > 0 AndAlso DTEMAIL.Rows(0).Item("EMAILID") <> "" Then

                Dim ALATTACHMENT As New ArrayList
                Dim OBJPAY As New payment_advice
                OBJPAY.MdiParent = MDIMain
                OBJPAY.DIRECTPRINT = True
                OBJPAY.DIRECTMAIL = True
                OBJPAY.REGNAME = cmbregister.Text.Trim
                OBJPAY.PRINTSETTING = PRINTDIALOG
                OBJPAY.payno = Val(txtaccno.Text.Trim)
                OBJPAY.payname = cmbname.Text.Trim
                OBJPAY.Show()
                OBJPAY.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PAYMENT_" & Val(txtaccno.Text.Trim) & ".pdf")

                sendemail(DTEMAIL.Rows(0).Item("EMAILID"), ALATTACHMENT(0), "", "Payment", ALATTACHMENT, ALATTACHMENT.Count, "", "", "", "", "")
                MsgBox("Mail Sent")
            Else
                MsgBox("Add E-Mail id in Ledger")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellClick
        Try
            If e.RowIndex >= 0 Then
                With gridbill.Rows(e.RowIndex).Cells(gridbill.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBALAMT").Index).Value

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
        TXTDESCTOTAL.Text = 0.0
        txttotal.Text = 0.0
        txtChqbal.Text = 0.0

        For Each row As DataGridViewRow In gridpayment.Rows
            txttotal.Text = Format(Val(txttotal.Text) + row.Cells(gamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridpaydesc.Rows
            TXTDESCTOTAL.Text = Format(Val(TXTDESCTOTAL.Text) + row.Cells(descamt.Index).Value, "0.00")
        Next

        For Each row As DataGridViewRow In gridbill.Rows
            If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(gridbill.Columns("INVBALAMT").Index).Value, "0.00")
        Next

        If Val(txtchqamt.Text) > 0 Then
            txtChqbal.Text = Format(Val(txtchqamt.Text) - Val(txttotal.Text), "0.00")
            txtinwords.Text = CurrencyToWord(txtchqamt.Text)
        End If

    End Sub

    Sub fillcmbbillno()
        cmbbillno.Items.Clear()
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
                    '    Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                    '    If DT.Rows.Count > 0 Then
                    '        MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                    '    End If

                    '    Dim BALAMT As Double = 0
                    '    For Each ROW As DataGridViewRow In GRIDDESC.Rows
                    '        If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                    '            BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                    '        End If
                    '    Next

                    '    If Val(txtamt.Text) > Val(MAXALLOWEDVALUE) Then
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
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
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

            If gridpayment.Rows(Val(LBLPAYGRIDSRNO.Text) - 1).Cells(gpaytype.Index).Value = "Against Bill" Then
                If edit = False Then
                    If GRIDDESCDOUBLECLICK = False Then
                        If (Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(TXTDESCTOTAL.Text)) > Val(BALANCEAMT) Then
                            EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If
                    Else
                        If ((Val(gridpayment.Rows(LBLPAYGRIDSRNO.Text - 1).Cells(gamt.Index).Value) + Val(txtdescamt.Text) + Val(TXTDESCTOTAL.Text)) - Val(gridpaydesc.Item(descamt.Index, tempdescrow).Value)) > Val(BALANCEAMT) Then
                            EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If
                    End If
                Else
                    Dim MAXALLOWEDVALUE As Double = 0
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & LBLPAYBILLINITIALS.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MAXALLOWEDVALUE = Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT")) + BALANCEAMT
                    End If
                    DT.Clear()

                    MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(gridpayment.Rows(Val(LBLPAYGRIDSRNO.Text) - 1).Cells(gamt.Index).Value)
                    If GRIDDESCDOUBLECLICK = True Then
                        MAXALLOWEDVALUE = MAXALLOWEDVALUE + Val(gridpaydesc.Rows(tempdescrow).Cells(descamt.Index).Value)
                    End If

                    For Each ROW As DataGridViewRow In gridpaydesc.Rows
                        MAXALLOWEDVALUE = MAXALLOWEDVALUE - Val(ROW.Cells(descamt.Index).Value)
                    Next

                    If Val(txtdescamt.Text) > Val(MAXALLOWEDVALUE) Then
                        EP.SetError(txtdescamt, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
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

            'done by gul temporarily
            txtamt.Text = Format(Val(AMT) - Val(txtamt.Text), "0.00")
            'If edit = False Then
            '    txtamt.Text = Format(Val(AMT) - Val(txtamt.Text), "0.00")
            'Else
            '    txtamt.Clear()
            'End If
            '******************

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

    Sub fillgridPURCHASE()

        GRIDBILL.DataSource = Nothing
        TXTINVTOTAL.Clear()
        'getting from INVOICEMASTER

        Dim objpayment As New ClsPaymentMaster
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
                        GPDESC.Enabled = False
                        txtdescsrno.Clear()
                        cmbledgername.Text = ""
                        txtdescnarr.Clear()
                        txtdescamt.Clear()
                        gridpaydesc.RowCount = 0

                    Else
                        If (gridpayment.Rows(e.RowIndex).Cells(gridsrno.Index).Value = N) Or N = 0 Then
                            .Value = True
                            GPDESC.Enabled = True
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
                    Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL  UNION ALL SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_BALANCE AS BALANCE, PURCHASEMASTER.BILL_CMPID AS CMPID , PURCHASEMASTER.BILL_LOCATIONID AS LOCATIONID , PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE UNION ALL SELECT CREDITNOTEMASTER.CN_INITIALS AS BILLINITIALS, CREDITNOTEMASTER.CN_BALANCE AS BALANCE, CN_CMPID AS CMPID, 0 AS LOCATIONID, CN_YEARID AS YEARID FROM CREDITNOTEMASTER WHERE CN_date >= '07/01/2017' UNION ALL SELECT CAST(RECEIPTMASTER_DESC.RECEIPT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, RECEIPTMASTER_DESC.RECEIPT_BALANCE AS BALANCE, RECEIPT_CMPID AS CMPID , 0 AS LOCATIONID , RECEIPT_YEARID AS YEARID FROM RECEIPTMASTER_DESC WHERE RECEIPT_paytype = 'New Ref') AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        lblbilltotal.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
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

    Private Sub gridPAYMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpayment.KeyDown
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
            GPDESC.Enabled = False
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
LINE1:
            TEMPPAYMENTNO = Val(txtaccno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_PAYMENTmaster()
            Dim MAXNO As Integer = txtaccno.Text.Trim
            clear()
            If Val(txtaccno.Text) - 1 >= TEMPPAYMENTNO Then
                edit = True
                PaymentMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And TEMPPAYMENTNO < MAXNO Then
                txtaccno.Text = TEMPPAYMENTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
        'Try
        '    gridpayment.RowCount = 0
        '    gridpaydesc.RowCount = 0
        '    TEMPREGNAME = cmbregister.Text.Trim
        '    TEMPPAYMENTNO = Val(txtaccno.Text) + 1
        '    clear()
        '    If Val(txtaccno.Text) - 1 >= TEMPPAYMENTNO Then
        '        edit = True
        '        PaymentMaster_Load(sender, e)
        '    Else
        '        clear()
        '        edit = False
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridpayment.RowCount = 0
            gridpaydesc.RowCount = 0
LINE1:
            TEMPPAYMENTNO = Val(txtaccno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPPAYMENTNO > 0 Then
                edit = True
                PaymentMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridpayment.RowCount = 0 And gridpaydesc.RowCount = 0 And TEMPPAYMENTNO > 1 Then
                txtaccno.Text = TEMPPAYMENTNO
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
            Dim OBJPAYDTLS As New PaymentDetails
            OBJPAYDTLS.MdiParent = MDIMain
            OBJPAYDTLS.Show()
            OBJPAYDTLS.BringToFront()
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

    Private Sub cmbaccname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaccname.Validated

        If EDIT = False Then
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If ClientName = "SAKARIA" Or ClientName = "BARKHA" Or ClientName = "SHUBHI" Then
                DT = OBJCMN.search(" ISNULL(MAX(CAST(PAYMENT_CHQNO AS BIGINT)),0), GROUP_SECONDARY", "", " PAYMENTMASTER INNER JOIN LEDGERS ON ACC_ID = PAYMENT_ACCID AND ACC_CMPID = PAYMENT_CMPID AND ACC_LOCATIONID = PAYMENT_LOCATIONID AND ACC_YEARID = PAYMENT_YEARID INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID INNER JOIN REGISTERMASTER ON REGISTER_ID = PAYMENT_REGISTERID AND REGISTER_CMPID = PAYMENT_CMPID AND REGISTER_LOCATIONID = PAYMENT_LOCATIONID AND REGISTER_YEARID = PAYMENT_YEARID", " AND ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENT_NO = " & Val(txtaccno.Text.Trim) - 1 & " AND PAYMENT_YEARID = " & YearId & " AND (GROUP_SECONDARY = 'BANK A/C' OR GROUP_SECONDARY = 'BANK OD A/C') GROUP BY GROUP_SECONDARY")
            ElseIf ClientName = "MAHAVIR" Or ClientName = "KCRAYON" Or ClientName = "SONAL" Then
                DT = OBJCMN.search(" ISNULL(MAX(CAST(PAYMENT_CHQNO AS BIGINT)),0), GROUP_SECONDARY", "", " PAYMENTMASTER INNER JOIN LEDGERS ON ACC_ID = PAYMENT_ACCID AND ACC_CMPID = PAYMENT_CMPID AND ACC_LOCATIONID = PAYMENT_LOCATIONID AND ACC_YEARID = PAYMENT_YEARID INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID INNER JOIN REGISTERMASTER ON REGISTER_ID = PAYMENT_REGISTERID AND REGISTER_CMPID = PAYMENT_CMPID AND REGISTER_LOCATIONID = PAYMENT_LOCATIONID AND REGISTER_YEARID = PAYMENT_YEARID", " AND ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId & " AND (GROUP_SECONDARY = 'BANK A/C' OR GROUP_SECONDARY = 'BANK OD A/C') AND ISNULL(PAYMENT_CHQNO,'') <> '' GROUP BY GROUP_SECONDARY")
            Else
                DT = OBJCMN.search(" ISNULL(MAX(CAST(PAYMENT_CHQNO AS VARCHAR)),0), GROUP_SECONDARY", "", " PAYMENTMASTER INNER JOIN LEDGERS ON ACC_ID = PAYMENT_ACCID AND ACC_CMPID = PAYMENT_CMPID AND ACC_LOCATIONID = PAYMENT_LOCATIONID AND ACC_YEARID = PAYMENT_YEARID INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID INNER JOIN REGISTERMASTER ON REGISTER_ID = PAYMENT_REGISTERID AND REGISTER_CMPID = PAYMENT_CMPID AND REGISTER_LOCATIONID = PAYMENT_LOCATIONID AND REGISTER_YEARID = PAYMENT_YEARID", " AND ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId & " AND (GROUP_SECONDARY = 'BANK A/C' OR GROUP_SECONDARY = 'BANK OD A/C') GROUP BY GROUP_SECONDARY")
            End If
            If DT.Rows.Count > 0 Then
                On Error Resume Next
                TXTCHQNO.Text = DT.Rows(0).Item(0) + 1
            End If
        End If

        'If edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT1 As DataTable = OBJCMN.search(" TOP 1 PAYMENTMASTER.PAYMENT_CHQNO AS CHQNO ", "", " PAYMENTMASTER INNER JOIN LEDGERS ON PAYMENTMASTER.PAYMENT_accid = LEDGERS.Acc_id AND PAYMENTMASTER.PAYMENT_cmpid = LEDGERS.Acc_cmpid AND PAYMENTMASTER.PAYMENT_locationid = LEDGERS.Acc_locationid AND PAYMENTMASTER.PAYMENT_yearid = LEDGERS.Acc_yearid", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId & " ORDER BY PAYMENT_no DESC")

        '    If DT1.Rows.Count > 0 Then
        '        On Error Resume Next
        '        TXTCHQNO.Text = DT1.Rows(0).Item(0) + 1
        '    Else
        '        TXTCHQNO.Text = "000001"
        '    End If
        'End If

        If cmbaccname.Text.Trim <> "" Then GETBALANCE()
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
                For Each row As DataGridViewRow In GRIDBILL.Rows
                    If row.Cells(GRIDBILL.Columns("REFNO").Index).Value.ToString = txtbillno.Text.Trim Then
                        row.Cells(GRIDBILL.Columns("INVCHK").Index).Value = 1
                        txtbillno.Clear()
                        txtbillno.Focus()
                        total()

                        'DIRECTLY ADDING IN GRID (AS PRE DHARMESH BHAI'S REQ)
                        cmbpaytype.Text = "Against Bill"
                        cmbbillno.Text = row.Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        cmbbillno.Enabled = True
                        txtnarr.Clear()
                        lblbilltotal.Text = row.Cells(GRIDBILL.Columns("INVBALAMT").Index).Value
                        txtamt_Validating(sender, e)

                        Exit Sub
                    End If
                Next


                'IF BILL IS NOT PRESENT IN GRID THEN ADD THE BILL IN GRID
                Dim OBJCMN As New ClsCommon
                'CHECKING IN PURCHASE
                Dim DT As DataTable = OBJCMN.search("PURCHASEMASTER.BILL_initials AS BILLINITIALS, PURCHASEMASTER.BILL_date AS BILLDATE, PURCHASEMASTER.BILL_BALANCE AS BALAMT, PURCHASEMASTER.BILL_GRANDTOTAL AS BILLAMT, 'PURCHASE' AS BILLTYPE, PURCHASEMASTER.BILL_NO AS BILLNO, REGISTERMASTER.REGISTER_NAME AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME, PURCHASEMASTER.BILL_PARTYBILLNO AS REFNO ", "", " PURCHASEMASTER LEFT OUTER JOIN LEDGERS ON PURCHASEMASTER.BILL_yearid = LEDGERS.Acc_yearid AND PURCHASEMASTER.BILL_locationid = LEDGERS.Acc_locationid AND PURCHASEMASTER.BILL_cmpid = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON register_id  = PURCHASEMASTER.BILL_REGISTERID AND register_cmpid = BILL_CMPID AND register_locationid = BILL_LOCATIONID AND register_yearid = BILL_YEARID ", " AND ( PURCHASEMASTER.BILL_PARTYBILLNO = '" & txtbillno.Text.Trim & "') AND BILL_BALANCE > 0  AND (PURCHASEMASTER.BILL_cmpid = " & CmpId & ") AND (PURCHASEMASTER.BILL_locationid = " & Locationid & ") AND (PURCHASEMASTER.BILL_yearid = " & YearId & ")")
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"), DTROW("NAME"), DTROW("REFNO"))
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"), DTROW("NAME"), DTROW("BILLINITIALS"))
                        Next
                    End If
                End If


                'CHECKING IN NONPURCHASE
                DT = OBJCMN.search("NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_BALANCE AS BALAMT, NONPURCHASE.NP_TOTALAMT AS BILLAMT, 'EXPENSE' AS BILLTYPE, NONPURCHASE.NP_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME, NONPURCHASE.NP_REFNO AS REFNO", "", " NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id AND NONPURCHASE.NP_CMPID = REGISTERMASTER.register_cmpid AND NONPURCHASE.NP_LOCATIONID = REGISTERMASTER.register_locationid AND NONPURCHASE.NP_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid AND NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid ", " AND ( NONPURCHASE.NP_INITIALS = '" & txtbillno.Text.Trim & "') AND NONPURCHASE.NP_BALANCE > 0  AND (NONPURCHASE.NP_cmpid = " & CmpId & ") AND (NONPURCHASE.NP_locationid = " & Locationid & ") AND (NONPURCHASE.NP_yearid = " & YearId & ")")
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"), DTROW("NAME"), DTROW("REFNO"))
                        Next
                    End If
                End If


                'CHECKING IN CREDITNOTE
                DT = OBJCMN.search("CN_INITIALS AS BILLINITIALS, CN_DATE AS BILLDATE, CN_BALANCE AS BALAMT, (CASE WHEN ISNULL(CN_RCM,0) = 'FALSE' THEN CREDITNOTEMASTER.CN_GTOTAL ELSE CREDITNOTEMASTER.CN_SUBTOTAL END) AS BILLAMT, 'CREDITNOTE' AS BILLTYPE, CN_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME, CREDITNOTEMASTER.CN_PARTYREFNO AS REFNO", "", " CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id ", " AND (CN_INITIALS = '" & txtbillno.Text.Trim & "') AND CN_BALANCE > 0 AND CN_date >= '07/01/2017' AND (CN_yearid = " & YearId & ")")
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"), DTROW("NAME"), DTROW("REFNO"))
                        Next
                    End If
                End If



                'CHECKING IN RECEIPT
                DT = OBJCMN.search("CAST(RECEIPTMASTER_DESC.RECEIPT_GRIDREMARKS AS VARCHAR(50)) AS BILLINITIALS, RECEIPT_DATE AS BILLDATE, RECEIPTMASTER_DESC.RECEIPT_BALANCE AS BALAMT, RECEIPTMASTER_DESC.RECEIPT_AMT AS BILLAMT, 'RECEIPT' AS BILLTYPE, RECEIPTMASTER_DESC.RECEIPT_NO AS BILLNO,  REGISTERMASTER.register_name AS REGTYPE, LEDGERS.ACC_CMPNAME AS NAME, '' AS REFNO", "", " RECEIPTMASTER INNER JOIN REGISTERMASTER ON RECEIPTMASTER.RECEIPT_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON RECEIPT_LEDGERID = LEDGERS.Acc_id INNER JOIN RECEIPTMASTER_DESC ON RECEIPTMASTER.RECEIPT_no = RECEIPTMASTER_DESC.RECEIPT_no AND RECEIPTMASTER.RECEIPT_registerid = RECEIPTMASTER_DESC.RECEIPT_registerid AND RECEIPTMASTER.RECEIPT_yearid = RECEIPTMASTER_DESC.RECEIPT_yearid ", " AND (CAST(RECEIPTMASTER_DESC.RECEIPT_GRIDREMARKS AS VARCHAR(50)) = '" & txtbillno.Text.Trim & "') AND RECEIPT_BALANCE > 0 AND RECEIPT_date >= '07/01/2017' AND (RECEIPTMASTER.RECEIPT_yearid = " & YearId & ")")
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
                    If GRIDBILL.RowCount = 0 Then
                        SETGRIDINVOICE(DT)
                    Else
                        Dim GRIDINVDT As DataTable = GRIDBILL.DataSource
                        GRIDINVDT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
                        For Each DTROW As DataRow In DT.Rows
                            GRIDINVDT.Rows.Add(DTROW("BILLINITIALS"), DTROW("BILLDATE"), DTROW("BALAMT"), DTROW("BILLAMT"), DTROW("BILLTYPE"), DTROW("BILLNO"), DTROW("REGTYPE"), DTROW("NAME"), DTROW("REFNO"))
                        Next
                    End If
                End If


                For Each ROW As DataGridViewRow In GRIDBILL.Rows
                    If ROW.Cells("REFNO").Value = txtbillno.Text.Trim Then ROW.Cells("INVCHK").Value = 1
                Next
                total()
                txtbillno.Clear()
                txtbillno.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbbillno_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbillno.Enter
        fillcmbbillno()
    End Sub

    Private Sub chkselectall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkselectall.CheckedChanged
        For Each row As DataGridViewRow In GRIDBILL.Rows
            row.Cells(GRIDBILL.Columns("INVCHK").Index).Value = chkselectall.CheckState
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
                    MsgBox("Invalid Bill No.", MsgBoxStyle.Critical, "TEXPRO")
                    cmbbillno.Focus()
                    Exit Sub
                End If



                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_BALANCE AS BALANCE, PURCHASEMASTER.BILL_CMPID AS CMPID , PURCHASEMASTER.BILL_LOCATIONID AS LOCATIONID , PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE  UNION ALL SELECT CREDITNOTEMASTER.CN_INITIALS AS BILLINITIALS, CREDITNOTEMASTER.CN_BALANCE AS BALANCE, CN_CMPID AS CMPID, 0 AS LOCATIONID, CN_YEARID AS YEARID FROM CREDITNOTEMASTER WHERE CN_date >= '07/01/2017' UNION ALL SELECT CAST(RECEIPTMASTER_DESC.RECEIPT_GRIDREMARKS AS VARCHAR(50)) AS BILLINITIALS, RECEIPTMASTER_DESC.RECEIPT_BALANCE AS BALANCE, RECEIPT_CMPID AS CMPID , 0 AS LOCATIONID , RECEIPT_YEARID AS YEARID FROM RECEIPTMASTER_DESC WHERE RECEIPT_paytype = 'New Ref') AS T", " AND T.BILLINITIALS = '" & cmbbillno.Text.Trim & "' AND T.YEARID = " & YearId)
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
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "TEXPRO")
                    cmbpaytype.Focus()
                    Exit Sub
                End If

                If cmbbillno.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In gridpayment.Rows
                        If (ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = cmbbillno.Text.Trim And ROW.Index <> TEMPROW) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "TEXPRO")
                            cmbpaytype.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                If cmbpaytype.Text = "" Then cmbpaytype.Text = "On Account"
                fillgrid()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PAYMENT'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PAYMENT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_PAYMENTmaster()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable = clscommon.search(" register_abbr, register_initials, register_id, ISNULL(ACC_CMPNAME,'') AS NAME ", "", " RegisterMaster LEFT OUTER JOIN LEDGERS ON REGISTER_LEDGERID = ACC_ID ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PAYMENT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    payregabbr = dt.Rows(0).Item(0).ToString
                    payreginitial = dt.Rows(0).Item(1).ToString
                    payregid = dt.Rows(0).Item(2)
                    cmbaccname.Text = dt.Rows(0).Item("NAME")
                    getmaxno_PAYMENTmaster()
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
                If edit = True Then
                    If USERDELETE = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    Dim tempmsg As Integer = MsgBox("Delete Payment Entry Permanently?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then

                        Dim OBJPAY As New ClsPaymentMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPPAYMENTNO)
                        ALPARAVAL.Add(TEMPREGNAME)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJPAY.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJPAY.Delete()
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
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Advice?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim objPAY As New payment_advice
                objPAY.payno = Val(txtaccno.Text)
                objPAY.payname = cmbname.Text.Trim
                objPAY.REGNAME = cmbregister.Text.Trim
                objPAY.MdiParent = MDIMain
                objPAY.Show()
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish to Print Chq?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJCHQPRINT As New payment_advice
                OBJCHQPRINT.payno = Val(txtaccno.Text.Trim)
                OBJCHQPRINT.REGNAME = cmbregister.Text.Trim
                OBJCHQPRINT.FRMSTRING = "CHQPRINT"
                If RBNEFT.Checked = True Then OBJCHQPRINT.NEFTRTGSNORMAL = "NEFT"
                If RBRTGS.Checked = True Then OBJCHQPRINT.NEFTRTGSNORMAL = "RTGS"
                If RBNORMAL.Checked = True Then OBJCHQPRINT.NEFTRTGSNORMAL = "PARTY"
                OBJCHQPRINT.MdiParent = MDIMain
                OBJCHQPRINT.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHQNO.KeyPress
        Try
            If ClientName <> "AVIS" And ClientName <> "SUPRIYA" Then numkeypress(e, TXTCHQNO, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchqno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHQNO.Validating
        Try
            If ClientName <> "SUNCOTT" And ClientName <> "AVIS" Then
                If TXTCHQNO.Text.Trim <> "" And TXTCHQNO.Text.Trim <> "RTGS" And TXTCHQNO.Text.Trim <> "NEFT" Then
                    'checking whether CHQNO IS ALREADY PAID WITH THE SAME BANK OR NOT....
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" PAYMENT_INITIALS", "", " PAYMENTMASTER INNER JOIN LEDGERS ON ACC_CMPID = PAYMENT_CMPID AND ACC_LOCATIONID = PAYMENT_LOCATIONID AND ACC_YEARID = PAYMENT_YEARID AND ACC_ID = PAYMENT_ACCID", " AND PAYMENT_CHQNO = '" & TXTCHQNO.Text.Trim & "' AND ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND PAYMENT_CMPID = " & CmpId & " AND PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENT_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If (EDIT = False) Or (EDIT = True And CHQNO <> TXTCHQNO.Text.Trim) Then
                            MsgBox("Chq. No. Already Present with this Bank in Payment No." & DT.Rows(0).Item(0), MsgBoxStyle.Critical, "TEXPRO")
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
            Throw ex
        End Try
    End Sub

    Private Sub txtdescamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdescamt.Validating
        Try
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

                tempdescrow = e.RowIndex
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

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                'OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
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
            GRIDDESC.RowCount = 0
            TEMPPAYMENTNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            clear()
            If TEMPPAYMENTNO > 0 Then
                edit = True
                PaymentMaster_Load(sender, e)
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

    Private Sub PaymentMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
        If ClientName = "MAHAVIR" Or ClientName = "PURVITEX" Then ALLOWMANUALPAYNO = True
        If ClientName = "MOHAN" Then GPPRINT.Visible = True
        If ClientName = "MAHAVIR" Then
            GPPAYMENT.Height = 195
            GRIDBILL.Height = 175
            LBLDESCTOTAL.Visible = True
            TXTDESCTOTAL.Visible = True
            GPDESC.Visible = True
            TXTINVTOTAL.Left = cmdexit.Left
            TXTINVTOTAL.Top = GPDESC.Top + 15
        End If
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

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPPAYMENTNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(PAYNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJPAY As New payment_advice
            OBJPAY.MdiParent = MDIMain
            OBJPAY.DIRECTPRINT = True
            OBJPAY.FRMSTRING = "PAYMENT"
            OBJPAY.DIRECTMAIL = False
            OBJPAY.DIRECTWHATSAPP = True
            OBJPAY.REGNAME = cmbregister.Text.Trim
            OBJPAY.PRINTSETTING = PRINTDIALOG
            OBJPAY.payno = Val(PAYNO)
            OBJPAY.NOOFCOPIES = 1
            OBJPAY.Show()
            OBJPAY.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.AGENTNAME = GETAGENTNAME(cmbname.Text.Trim)
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PAYMENT_" & Val(PAYNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("PAYMENT_" & Val(PAYNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

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
            Dim OBJCMN As New ClsCommon
            Dim MSG As String = ""
            If ClientName = "NVAHAN" Then MSG = "Payment Issued" & vbCrLf Else MSG = "Payment Issued" & "\n"
            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND LEDGERS.ACC_CMPNAME = '" & cmbaccname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Bank A/C" Or DT.Rows(0).Item(0) = "Bank OD A/C" Then
                    If ClientName = "NVAHAN" Then MSG = MSG + "Chq No - " & TXTCHQNO.Text.Trim & vbCrLf & " - " & ACCDATE.Text & vbCrLf Else MSG = MSG + "Chq No - " & TXTCHQNO.Text.Trim & "\n" & " - " & ACCDATE.Text & "\n"
                End If
                If ClientName = "NVAHAN" Then MSG = MSG + "Rs " & Val(txtchqamt.Text.Trim) & vbCrLf Else MSG = MSG + "Rs " & Val(txtchqamt.Text.Trim) & "\n"

                'for bill nos
                For Each ROW As DataGridViewRow In gridpayment.Rows
                    'get partybill no with respect to OUR INITIALS AND YEARID
                    DT = OBJCMN.search("*", "", " (SELECT BILL_NARRATION AS BILLINITIALS FROM OPENINGBILL WHERE BILL_INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND BILL_YEARID = " & YearId & " UNION ALL SELECT PURCHASEMASTER.BILL_PARTYBILLNO AS BILLINITIALS FROM PURCHASEMASTER  WHERE BILL_INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND BILL_YEARID = " & YearId & " UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS FROM JOURNALMASTER  WHERE JOURNAL_INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND JOURNAL_YEARID = " & YearId & " UNION ALL	SELECT NONPURCHASE.NP_REFNO AS BILLINITIALS FROM NONPURCHASE  WHERE NP_INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND NP_YEARID = " & YearId & " UNION ALL	SELECT CN_PARTYREFNO AS BILLINITIALS FROM CREDITNOTEMASTER  WHERE CN_INITIALS = '" & ROW.Cells(gbillno.Index).Value & "' AND CN_YEARID = " & YearId & " AND CN_date >= '07/01/2017') AS T ", "")
                    If DT.Rows.Count > 0 Then
                        If ClientName = "NVAHAN" Then MSG = MSG + "BN - " & DT.Rows(0).Item("BILLINITIALS") & " = " & Val(ROW.Cells(gamt.Index).Value) & vbCrLf Else MSG = MSG + "BN - " & DT.Rows(0).Item("BILLINITIALS") & " = " & Val(ROW.Cells(gamt.Index).Value) & "\n"
                    End If
                Next
                'MSG = MSG + "Thank You"
            End If

            If SENDMSG(MSG, TXTMOBILENO.Text.Trim) = "1701" Then
                MsgBox("Message Sent")
                DT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER SET PAYMENT_SMSSEND = 1 FROM PAYMENTMASTER INNER JOIN REGISTERMASTER ON PAYMENT_REGISTERID = REGISTER_ID WHERE PAYMENT_NO = " & TEMPPAYMENTNO & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENT_YEARID = " & YearId, "", "")
                LBLSMS.Visible = True
            Else
                MsgBox("Error Sending Message")
            End If

        End If
    End Sub

    Private Sub txtaccno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtaccno.Validating
        Try
            If (Val(txtaccno.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPPAYMENTNO <> Val(txtaccno.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtaccno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Payment No Already Exist")
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

    Private Sub GRIDBILL_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBILL.KeyDown
        Dim ARGS As New DataGridViewCellEventArgs(GRIDBILL.CurrentCell.ColumnIndex, GRIDBILL.CurrentRow.Index)
        If e.KeyCode = Keys.F8 Then Call GRIDBILL_CellClick(sender, ARGS)
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Call ToolStripdelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class