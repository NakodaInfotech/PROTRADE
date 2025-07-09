
Imports System.ComponentModel
Imports BL

Public Class ProformaDebitNote

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim DNREGABBR, DNREGINITIAL As String
    Dim DNREGID As Integer

    Dim TYPE As String  'USED FOR FORMTYPE WHILE RETRIVING DATA FROM GETDATE FUNCTION AND PASSING IN TO SP
    Public TEMPDNNO As Integer
    Public BILLNO As String
    Public TEMPREGNAME As String
    Dim GRIDCHGSDOUBLECLICK As Boolean
    Dim TEMPCHGSROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            edit = False
            cmbregister.Enabled = True
            cmbregister.Focus()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub clear()
        Try
            tstxtbillno.Clear()

            If ALLOWMANUALCNDN = True Then
                TXTDNNO.ReadOnly = False
                TXTDNNO.BackColor = Color.LemonChiffon
            Else
                TXTDNNO.ReadOnly = True
                TXTDNNO.BackColor = Color.Linen
            End If

            EP.Clear()

            TXTBILLNO.Enabled = True
            TXTBILLNO.Clear()

            CMBNAME.Text = ""
            CMBNAME.Enabled = True
            TXTSTATECODE.Clear()
            CMBAGENT.Text = ""
            TXTPARTYBILLNO.Clear()
            TXTPARTYBILLDATE.Clear()

            CMBSACDESC.Text = ""
            TXTSACCODE.Clear()
            TXTSALEREFNO.Clear()

            CMBCREDITLEDGER.Text = ""
            CMBCREDITLEDGER.Enabled = True

            txtremarks.Clear()
            txtinwords.Clear()

            DNREGABBR = ""
            DNREGINITIAL = ""

            TXTTOTALTAXAMT.Clear()
            TXTTOTALOTHERCHGSAMT.Clear()
            TXTCHARGES.Text = 0.0
            DNDATE.Text = Now.Date

            TXTTOTALPURAMT.Text = 0.0
            TXTSUBTOTAL.Text = 0.0

            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0

            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            PBlock.Visible = False
            PBRECD.Visible = False
            lbllocked.Visible = False
            CMDSHOWDETAILS.Visible = False

            TXTAMTREC.Clear()
            TXTEXTRAAMT.Clear()
            TXTRETURN.Clear()
            TXTBAL.Clear()

            GRIDCHGS.RowCount = 0

            getmaxno_DN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PURCHASETOTAL()
        Try
            TXTSUBTOTAL.Text = 0.0
            If CHKMANUALROUND.CheckState = CheckState.Unchecked Then txtroundoff.Text = 0
            txtgrandtotal.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTTOTALTAXAMT.Clear()
            TXTTOTALOTHERCHGSAMT.Clear()


            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    If Val(row.Cells(EPER.Index).Value) <> 0 Then row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value * Val(TXTTOTALPURAMT.Text.Trim)) / 100), "0.00")
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                    If Val(row.Cells(ETAXID.Index).Value) > 0 Then TXTTOTALTAXAMT.Text = Format(Val(TXTTOTALTAXAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00") Else TXTTOTALOTHERCHGSAMT.Text = Format(Val(TXTTOTALOTHERCHGSAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If


            TXTSUBTOTAL.Text = Format(Val(TXTTOTALPURAMT.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")
            End If


            If CHKMANUALROUND.Checked = False Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)), "0.00")
            Else
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(txtroundoff.Text.Trim), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno_DN()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(DN_NO),0) + 1 ", "PROFORMADEBITNOTEMASTER INNER JOIN REGISTERMASTER ON DN_REGISTERID =REGISTER_ID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND DN_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTDNNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITNOTEdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DNDATE.Validating
        Try
            If DNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'DEBITNOTE' and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_DN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If TXTBILLNO.Text.Trim <> "" And TYPE = Nothing Then TYPE = "PURCHASE"

            Dim alParaval As New ArrayList

            If ALLOWMANUALCNDN = True Then
                alParaval.Add(Val(TXTDNNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(cmbregister.Text.Trim)
            If TYPE = Nothing Then TYPE = ""
            alParaval.Add(TYPE)
            alParaval.Add(Format(Convert.ToDateTime(DNDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTSACCODE.Text.Trim)
            alParaval.Add(TXTSALEREFNO.Text.Trim)
            alParaval.Add(CMBCREDITLEDGER.Text.Trim)

            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALTAXAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALOTHERCHGSAMT.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUALROUND.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKGSTR1.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)


            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            'alParaval.Add(Val(TXTBROKERAGE.Text.Trim))


            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(TXTPARTYBILLDATE.Text)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

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


            Dim objclsDNmaster As New ClsProformaDebitNote()
            objclsDNmaster.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = objclsDNmaster.SAVE()
                MessageBox.Show("Details Added")
                PRINTREPORT(DT.Rows(0).Item(0))
                TXTDNNO.Text = Val(DT.Rows(0).Item(0))

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDNNO)
                Dim INTRES As Integer = objclsDNmaster.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPDNNO)
                edit = False
            End If

            If ClientName = "SAKARIA" Then SENDDIRECTMAIL()

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)
            TXTBILLNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDDIRECTMAIL()
        Try
            If MsgBox("Wish To Mail Debit Note?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim ALATTACHMENT As New ArrayList

            'CHECK WHETHER EMAILID IS PRESENT IN LEDGER OR NOT, IF NOT THEN EXIT SUB WITH MESSAGE
            Dim OBJCMN As New ClsCommon
            Dim DTEMAIL As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", "AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DTEMAIL.Rows.Count > 0 AndAlso DTEMAIL.Rows(0).Item("EMAILID") <> "" Then

                Dim OBJDN As New CrDrNoteDesign
                OBJDN.MdiParent = MDIMain
                OBJDN.DIRECTPRINT = True
                OBJDN.FRMSTRING = "PROFORMADEBIT"
                OBJDN.DIRECTMAIL = True
                OBJDN.REGNAME = cmbregister.Text.Trim
                OBJDN.PRINTSETTING = PRINTDIALOG
                OBJDN.BILLNO = Val(TXTDNNO.Text.Trim)
                OBJDN.NOOFCOPIES = 1
                OBJDN.Show()
                OBJDN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\DN_" & Val(TXTDNNO.Text.Trim) & ".pdf")
                sendemail(DTEMAIL.Rows(0).Item("EMAILID"), ALATTACHMENT(0), "", "Debit Note", ALATTACHMENT, ALATTACHMENT.Count, "", "", "", "", "")
                MsgBox("Mail Sent")
            Else
                MsgBox("Add E-Mail id in Ledger")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        'THIS CODE WONT ALLOW MULTIPLE DEBITNOTES
        'REMOVED THIS CODE BY GULKIT, AS USER CAN ADD MULTIPLE DEBITNOTES AGAINST SINGLE PURCHASE
        'If TXTBILLNO.Text.Trim <> "" And edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As DataTable = OBJCMN.search("*", "", "(SELECT BILL_RETURN AS PURRETURN FROM PURCHASEMASTER WHERE BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId & " UNION ALL SELECT BILL_RETURN FROM OPENINGBILL WHERE OPENINGBILL.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId & ") AS T", "")
        '    If DT.Rows.Count > 0 Then
        '        If Val(DT.Rows(0).Item("PURRETURN")) > 0 Then
        '            EP.SetError(TXTBILLNO, "Debit Note Already Raised")
        '            bln = False
        '        End If
        '    End If
        'End If


        'IF INVOICENO IS NOT BLANK THEN CHECK THAT FIGURES CANNOT BE GREATER THEN BALANCEAMT
        If TYPE <> "INVOICE" Then
            If TXTBILLNO.Text.Trim <> "" Then
                Dim BALANCE As Double = 0
                Dim DT As New DataTable
                Dim OBJCMN As New ClsCommon
                If TYPE = "PURCHASE" Then
                    DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID", " AND BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                ElseIf TYPE = "EXPENSE" Then
                    DT = OBJCMN.search("NP_BALANCE AS INVBAL", "", "NONPURCHASE INNER JOIN REGISTERMASTER ON NP_REGISTERID = REGISTER_ID", " AND NP_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND NP_YEARID = " & YearId)
                Else
                    DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID", " AND BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then BALANCE = Val(DT.Rows(0).Item("INVBAL")) Else BALANCE = 0
                If edit = True Then
                    Dim DT1 As DataTable = OBJCMN.search("DN_GTOTAL AS RETTOTAL", "", "PROFORMADEBITNOTEMASTER", " AND DN_NO = " & Val(TEMPDNNO) & " AND DN_YEARID = " & YearId)
                    BALANCE += Val(DT1.Rows(0).Item("RETTOTAL"))
                End If
                If Val(txtgrandtotal.Text.Trim) > Val(BALANCE) Then
                    EP.SetError(txtgrandtotal, "Amount Greater then Balance Amt, only " & Val(BALANCE) & " can be Used")
                    bln = False
                End If
            End If
        End If



        If CMBNAME.Text.Trim = "" Then
            EP.SetError(CMBNAME, "Select Invoice")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Rec Made, Entry Locked")
            bln = False
        End If


        If CMBCREDITLEDGER.Text.Trim = "" Then
            EP.SetError(CMBCREDITLEDGER, "Select Credit Ledger")
            bln = False
        End If

        If txtgrandtotal.Text.Trim = "" Then
            EP.SetError(txtgrandtotal, "Enter Amount")
            bln = False
        End If


        If DNDATE.Text = "__/__/____" Then
            EP.SetError(DNDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DNDATE.Text) Then
                EP.SetError(DNDATE, "Date not in Accounting Year")
                bln = False
            End If

            If Convert.ToDateTime(DNDATE.Text).Date < DNBLOCKDATE.Date Then
                EP.SetError(DNDATE, "Date is Blocked, Please make entries after " & Format(DNBLOCKDATE.Date, "dd/MM/yyyy"))
                bln = False
            End If
        End If


        If ALLOWMANUALCNDN = True Then
            If TXTDNNO.Text <> "" And CMBNAME.Text.Trim <> "" And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PROFORMADEBITNOTEMASTER.DN_no, 0) AS BILLNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PROFORMADEBITNOTEMASTER ON REGISTERMASTER.register_id = PROFORMADEBITNOTEMASTER.DN_REGISTERID AND REGISTERMASTER.register_cmpid = PROFORMADEBITNOTEMASTER.DN_CMPID AND REGISTERMASTER.register_yearid = PROFORMADEBITNOTEMASTER.DN_YEARID AND REGISTERMASTER.register_locationid = PROFORMADEBITNOTEMASTER.DN_LOCATIONID", "  AND PROFORMADEBITNOTEMASTER.DN_NO=" & TXTDNNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PROFORMADEBITNOTEMASTER.DN_cmpid = " & CmpId & " AND PROFORMADEBITNOTEMASTER.DN_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTDNNO, "Bill No Already Exist")
                    bln = False
                End If
            End If
        End If

        Return bln

    End Function

    Private Sub ProformaDebitNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F12 Then
                SendKeys.Send("+{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    DNREGABBR = dt.Rows(0).Item(0).ToString
                    DNREGINITIAL = dt.Rows(0).Item(1).ToString
                    DNREGID = dt.Rows(0).Item(2)
                    getmaxno_DN()
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

    Sub FILLCMB()
        Try
            fillregister(cmbregister, " and register_type = 'DEBITNOTE'  ")
            fillname(CMBNAME, edit, "  AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
            If CMBCREDITLEDGER.Text.Trim = "" Then fillname(CMBCREDITLEDGER, edit, "")
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, edit, " AND (GROUPMASTER.GROUP_SECONDARY ='Indirect Income' OR GROUPMASTER.GROUP_SECONDARY ='Indirect Expenses' or GROUPMASTER.GROUP_SECONDARY ='Direct Income' OR GROUPMASTER.GROUP_SECONDARY ='Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY ='Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' or GROUPMASTER.GROUP_SECONDARY = 'Sales A/C')")
            If CMBSACDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBSACDESC)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
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
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_DISC,0) AS DISCPER ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS') and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                End If
                CMBNAME.Enabled = False
                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCREDITLEDGER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCREDITLEDGER.Enter
        Try
            If CMBCREDITLEDGER.Text.Trim = "" Then fillname(CMBCREDITLEDGER, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCREDITLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCREDITLEDGER.Validating
        Try
            If CMBCREDITLEDGER.Text.Trim <> "" Then namevalidate(CMBCREDITLEDGER, CMBACCCODE, e, Me, TXTOTHERCHGSADD, "", "Purchase A/C")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProformaDebitNote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            clear()

            If BILLNO <> "" And edit = False Then
                TXTBILLNO.Text = BILLNO
                TXTBILLNO.Enabled = False
                GETDATA()
            End If


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsDN As New ClsProformaDebitNote()
                dt = objclsDN.SELECTDEBITNOTE_EDIT(TEMPDNNO, TEMPREGNAME, CmpId, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        CMBNAME.Enabled = False

                        TXTDNNO.Text = TEMPDNNO
                        cmbregister.Text = TEMPREGNAME
                        TYPE = dt.Rows(0).Item("TYPE")
                        DNDATE.Text = Format(Convert.ToDateTime(dr("DNDATE")), "dd/MM/yyyy")
                        TXTBILLNO.Text = dt.Rows(0).Item("BILLNO")
                        If TXTBILLNO.Text.Trim <> "" Then TXTBILLNO.Enabled = False
                        CMBNAME.Text = dt.Rows(0).Item("NAME")
                        TXTSTATECODE.Text = dt.Rows(0).Item("STATECODE")
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))

                        CMBSACDESC.Text = dt.Rows(0).Item("HSNITEMDESC")
                        TXTSACCODE.Text = dt.Rows(0).Item("HSNCODE")
                        TXTSALEREFNO.Text = dt.Rows(0).Item("SALEREFNO")

                        TXTPARTYBILLNO.Text = dt.Rows(0).Item("PARTYBILLNO")
                        TXTPARTYBILLDATE.Text = dt.Rows(0).Item("PARTYBILLDATE")

                        CMBCREDITLEDGER.Text = dt.Rows(0).Item("CREDITNAME")
                        TXTTOTALPURAMT.Text = dt.Rows(0).Item("PURAMT")

                        TXTTOTALTAXAMT.Text = dt.Rows(0).Item("TOTALTAXAMT")
                        TXTTOTALOTHERCHGSAMT.Text = dt.Rows(0).Item("TOTALOTHERCHGSAMT")
                        TXTCHARGES.Text = dt.Rows(0).Item("TOTALCHARGES")

                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If Convert.ToBoolean(dr("MANUALROUNDOFF")) = False Then CHKMANUALROUND.Checked = False Else CHKMANUALROUND.Checked = True
                        If Convert.ToBoolean(dr("GSTR1")) = False Then CHKGSTR1.Checked = False Else CHKGSTR1.Checked = True

                        TXTCGSTPER.Text = dt.Rows(0).Item("TOTALCGSTPER")
                        TXTCGSTAMT.Text = dt.Rows(0).Item("TOTALCGSTAMT")
                        TXTSGSTPER.Text = dt.Rows(0).Item("TOTALSGSTPER")
                        TXTSGSTAMT.Text = dt.Rows(0).Item("TOTALSGSTAMT")
                        TXTIGSTPER.Text = dt.Rows(0).Item("TOTALIGSTPER")
                        TXTIGSTAMT.Text = dt.Rows(0).Item("TOTALIGSTAMT")

                        txtroundoff.Text = dt.Rows(0).Item("ROUNDOFF")
                        txtgrandtotal.Text = dt.Rows(0).Item("GTOTAL")

                        TXTAMTREC.Text = Val(dr("AMTREC"))
                        TXTEXTRAAMT.Text = Val(dr("EXTRAAMT"))
                        TXTRETURN.Text = Val(dr("RETURN"))
                        TXTBAL.Text = Val(dr("BALANCE"))

                        If Val(dr("AMTREC")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBRECD.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        txtinwords.Text = Convert.ToString(dr("INWORDS"))


                    Next

                    'CHARGES GRID
                    Dim OBJCM2 As New ClsCommon
                    Dim dt2 As DataTable = OBJCM2.search("  PROFORMADEBITNOTEMASTER_CHGS.DN_gridsrno AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(PROFORMADEBITNOTEMASTER_CHGS.DN_PER, 0) AS PER, ISNULL(PROFORMADEBITNOTEMASTER_CHGS.DN_AMT, 0) AS AMT, ISNULL(TAXMASTER.tax_id, 0) AS TAXID", "", " PROFORMADEBITNOTEMASTER INNER JOIN PROFORMADEBITNOTEMASTER_CHGS ON PROFORMADEBITNOTEMASTER.DN_no = PROFORMADEBITNOTEMASTER_CHGS.DN_no AND PROFORMADEBITNOTEMASTER.DN_registerid = PROFORMADEBITNOTEMASTER_CHGS.DN_REGISTERID AND PROFORMADEBITNOTEMASTER.DN_yearid = PROFORMADEBITNOTEMASTER_CHGS.DN_yearid INNER JOIN REGISTERMASTER ON PROFORMADEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id AND PROFORMADEBITNOTEMASTER.DN_yearid = REGISTERMASTER.register_yearid LEFT OUTER JOIN TAXMASTER ON PROFORMADEBITNOTEMASTER_CHGS.DN_TAXID = TAXMASTER.tax_id AND PROFORMADEBITNOTEMASTER_CHGS.DN_yearid = TAXMASTER.tax_yearid LEFT OUTER JOIN LEDGERS ON PROFORMADEBITNOTEMASTER_CHGS.DN_CHARGESID = LEDGERS.Acc_id AND PROFORMADEBITNOTEMASTER_CHGS.DN_yearid = LEDGERS.Acc_yearid", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'DEBITNOTE' AND PROFORMADEBITNOTEMASTER_CHGS.DN_NO = " & TEMPDNNO & " AND PROFORMADEBITNOTEMASTER_CHGS.DN_YEARID = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    dt2 = OBJCM2.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE' and register_YEARid = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        DNREGABBR = dt2.Rows(0).Item(0).ToString
                        DNREGINITIAL = dt2.Rows(0).Item(1).ToString
                        DNREGID = dt2.Rows(0).Item(2)
                    End If

                    PURCHASETOTAL()
                    cmbregister.Enabled = False
                    TXTTOTALPURAMT.Focus()
                Else
                    edit = False
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = DNREGINITIAL & "-" & TEMPDNNO
            OBJRECPAY.SALEBILLINITIALS = DNREGINITIAL & "-" & TEMPDNNO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating

    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            'If TXTBILLNO.Text.Trim <> "" And edit = False Then
            If TXTBILLNO.Text.Trim <> "" Then
                GETDATA()
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Invoice No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTBILLNO.Enabled = False
            Else
                If edit = True Then TXTBILLNO.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCMN As New ClsCommon
            ''Dim DT As DataTable = OBJCMN.search(" BILL_AMTPAID AS PAIDAMT, BILL_NO AS BILL, BILL_INITIALS AS BILLNO, BILL_CMPID, BILL_LOCATIONID, BILL_YEARID , LEDGERS.Acc_cmpname AS NAME, BILL_BILLAMT AS PURAMT, BILL_DISPER AS DISCPER, BILL_DISAMT AS DISCRS , BILL_PFPER AS PFPER, BILL_PFAMT AS PFAMT, ISNULL(TAXMASTER.tax_name,'') AS TAXNAME, ISNULL(BILL_taxAMT,0) AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name,'') AS ADDTAXNAME, BILL_ADDtaxAMT AS ADDTAXAMT, ISNULL(OTHERCHGSLEDGER.Acc_cmpname,'') AS OTHERCHGSNAME, PURCHASEMASTER.BILL_OTHERCHGS AS OTHERCHGS, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL AS GTOTAL, 'PURCHASE' AS TYPE ", "", "  TAXMASTER AS ADDTAXMASTER RIGHT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER RIGHT OUTER JOIN LEDGERS RIGHT OUTER JOIN PURCHASEMASTER ON LEDGERS.Acc_yearid = PURCHASEMASTER.BILL_YEARID AND LEDGERS.Acc_locationid = PURCHASEMASTER.BILL_LOCATIONID AND LEDGERS.Acc_cmpid = PURCHASEMASTER.BILL_CMPID AND LEDGERS.Acc_id = PURCHASEMASTER.BILL_LEDGERID ON OTHERCHGSLEDGER.Acc_yearid = PURCHASEMASTER.BILL_YEARID AND OTHERCHGSLEDGER.Acc_locationid = PURCHASEMASTER.BILL_LOCATIONID AND OTHERCHGSLEDGER.Acc_cmpid = PURCHASEMASTER.BILL_CMPID AND OTHERCHGSLEDGER.Acc_id = PURCHASEMASTER.BILL_OTHERCHGSID ON ADDTAXMASTER.tax_id = PURCHASEMASTER.BILL_ADDTAXID AND ADDTAXMASTER.tax_yearid = PURCHASEMASTER.BILL_YEARID AND ADDTAXMASTER.tax_locationid = PURCHASEMASTER.BILL_LOCATIONID AND ADDTAXMASTER.tax_cmpid = PURCHASEMASTER.BILL_CMPID LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER.BILL_YEARID = TAXMASTER.tax_yearid AND PURCHASEMASTER.BILL_LOCATIONID = TAXMASTER.tax_locationid AND PURCHASEMASTER.BILL_CMPID = TAXMASTER.tax_cmpid AND PURCHASEMASTER.BILL_TAXID = TAXMASTER.tax_id ", " AND BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId)
            'THIS QUERY RETRIEVES DATA FROM INVOICEMASTER ONLY, NEW QUERY WILL RETRIEVE DATA DATA FROM OPENING ALSO
            'Dim DT As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER.BILL_AMTPAID, 0) AS PAIDAMT, PURCHASEMASTER.BILL_NO AS BILL, PURCHASEMASTER.BILL_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(PURCHASEMASTER.BILL_REMARKS, '') AS REMARKS,ISNULL(PURCHASEMASTER.BILL_BILLAMT, 0) AS BILLAMT,ISNULL(PURCHASEMASTER.BILL_TOTALTAXAMT, 0) AS TOTALTAXAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCHGSAMT, 0) AS TOTALCHGSAMT,ISNULL(PURCHASEMASTER.BILL_CHARGES, 0) AS TOTALCHARGES, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASEMASTER_CHGS.BILL_gridsrno, 0) AS SRNO, ISNULL(CHARGES.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT,'PURCHASE' AS TYPE ", "", "  PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid LEFT OUTER JOIN LEDGERS AS CHARGES ON PURCHASEMASTER_CHGS.BILL_CHARGESID = CHARGES.Acc_id AND PURCHASEMASTER_CHGS.BILL_yearid = CHARGES.Acc_yearid ", " AND PURCHASEMASTER.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND PURCHASEMASTER.BILL_CMPID = " & CmpId & " AND PURCHASEMASTER.BILL_YEARID = " & YearId)
            'Dim DT As DataTable = OBJCMN.search("*", "", "(SELECT ISNULL(PURCHASEMASTER.BILL_AMTPAID, 0) AS PAIDAMT, PURCHASEMASTER.BILL_NO AS BILL, PURCHASEMASTER.BILL_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(PURCHASEMASTER.BILL_REMARKS, '') AS REMARKS,ISNULL(PURCHASEMASTER.BILL_BILLAMT, 0) AS BILLAMT,ISNULL(PURCHASEMASTER.BILL_TOTALTAXAMT, 0) AS TOTALTAXAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCHGSAMT, 0) AS TOTALCHGSAMT,ISNULL(PURCHASEMASTER.BILL_CHARGES, 0) AS TOTALCHARGES, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASEMASTER_CHGS.BILL_gridsrno, 0) AS SRNO, ISNULL(CHARGES.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT,'PURCHASE' AS TYPE, REGLEDGERS.ACC_CMPNAME AS CREDITLEDGER FROM PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS CHARGES ON PURCHASEMASTER_CHGS.BILL_CHARGESID = CHARGES.Acc_id AND PURCHASEMASTER_CHGS.BILL_yearid = CHARGES.Acc_yearid WHERE PURCHASEMASTER.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND PURCHASEMASTER.BILL_YEARID = " & YearId & " UNION ALL SELECT ISNULL(OPENINGBILL.BILL_AMTPAIDREC, 0) AS PAIDAMT, OPENINGBILL.BILL_NO AS BILL, OPENINGBILL.BILL_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(OPENINGBILL.BILL_NARRATION, '') AS REMARKS,ISNULL(OPENINGBILL.BILL_AMT, 0) AS BILLAMT,0 AS TOTALTAXAMT, 0 AS TOTALCHGSAMT,'' AS TOTALCHARGES, 0 AS ROUNDOFF, ISNULL(OPENINGBILL.BILL_AMT, 0) AS GRANDTOTAL, 0 AS SRNO, '' AS CHARGES, 0 AS PER, 0 AS AMT,'OPENING' AS TYPE, REGLEDGERS.ACC_CMPNAME AS CREDITLEDGER FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid WHERE OPENINGBILL.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND OPENINGBILL.BILL_YEARID = " & YearId & ") AS T", "")
            Dim DT As DataTable = OBJCMN.search("*", "", "(SELECT ISNULL(PURCHASEMASTER.BILL_AMTPAID, 0) AS PAIDAMT, PURCHASEMASTER.BILL_NO AS BILL, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE,   PURCHASEMASTER.BILL_PURTYPE AS PURTYPE, PURCHASEMASTER.BILL_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, ISNULL(PURCHASEMASTER.BILL_REMARKS, '') AS REMARKS, ISNULL(PURCHASEMASTER.BILL_BILLAMT, 0) AS BILLAMT, ISNULL(PURCHASEMASTER.BILL_TOTALTAXAMT, 0) AS TOTALTAXAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCHGSAMT, 0) AS TOTALCHGSAMT, ISNULL(PURCHASEMASTER.BILL_CHARGES, 0) AS TOTALCHARGES, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASEMASTER_CHGS.BILL_gridsrno, 0) AS SRNO, ISNULL(CHARGES.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT, 'PURCHASE' AS TYPE, REGLEDGERS.Acc_cmpname AS CREDITLEDGER, ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNITEMDESC, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE FROM PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS CHARGES ON PURCHASEMASTER_CHGS.BILL_CHARGESID = CHARGES.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON PURCHASEMASTER.BILL_SACCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.ACC_ID WHERE PURCHASEMASTER.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND PURCHASEMASTER.BILL_YEARID = " & YearId & " UNION ALL SELECT INVOICEMASTER.INVOICE_AMTREC AS RECDAMT, INVOICEMASTER.INVOICE_NO AS BILL, INVOICEMASTER.INVOICE_DATE AS DATE, '' AS PURTYPE, INVOICEMASTER.INVOICE_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, INVOICE_REMARKS AS REMARKS, INVOICEMASTER.INVOICE_AMOUNT AS SALEAMT, 0 AS TOTALTAXAMT, 0 AS TOTALCHGSAMT, ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) AS TOTALCHARGES, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS GTOTAL, 0 AS SRNO, '' AS CHARGES, 0 AS PER, 0 AS AMT, 'INVOICE' AS TYPE, REGLEDGERS.Acc_cmpname AS DEBITLEDGER, (CASE WHEN INVOICE_SCREENTYPE = 'LINE GST' THEN INVOICE_SCREENTYPE ELSE INVOICE_SUBTOTAL END) AS TOTALTAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, '' AS HSNITEMDESC, '' AS HSNCODE FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.ACC_ID WHERE INVOICEMASTER.INVOICE_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " UNION ALL SELECT ISNULL(NONPURCHASE.NP_AMTPAID, 0) AS PAIDAMT, NONPURCHASE.NP_NO AS BILL, NONPURCHASE.NP_PARTYBILLDATE AS PARTYBILLDATE, '' AS PURTYPE,NONPURCHASE.NP_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, '' AS AGENTNAME, ISNULL(NONPURCHASE.NP_REMARKS, '') AS REMARKS, ISNULL(NONPURCHASE.NP_TOTALBILLAMT, 0) AS BILLAMT, 0 AS TOTALTAXAMT, 0 AS TOTALCHGSAMT, 0 AS TOTALCHARGES, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL, 0 AS SRNO,'' AS CHARGES, 0 AS PER, 0 AS AMT, 'EXPENSE' AS TYPE, ISNULL(REGLEDGERS.Acc_cmpname,'') AS CREDITLEDGER, ISNULL(NONPURCHASE.NP_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNITEMDESC, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE FROM STATEMASTER RIGHT OUTER JOIN LEDGERS AS REGLEDGERS INNER JOIN REGISTERMASTER ON REGLEDGERS.Acc_cmpname = REGISTERMASTER.register_abbr AND REGLEDGERS.Acc_yearid = REGISTERMASTER.register_yearid RIGHT OUTER JOIN NONPURCHASE_DESC INNER JOIN NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid ON NONPURCHASE_DESC.NP_NO = NONPURCHASE.NP_NO AND NONPURCHASE_DESC.NP_YEARID = NONPURCHASE.NP_YEARID AND NONPURCHASE_DESC.NP_REGISTERID = NONPURCHASE.NP_REGISTERID LEFT OUTER JOIN HSNMASTER ON NONPURCHASE_DESC.NP_HSNCODEID = HSNMASTER.HSN_ID ON REGISTERMASTER.register_id = NONPURCHASE.NP_REGISTERID ON STATEMASTER.state_id = LEDGERS.Acc_stateid WHERE NONPURCHASE.NP_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND NONPURCHASE.NP_YEARID = " & YearId & " UNION ALL SELECT ISNULL(OPENINGBILL.BILL_AMTPAIDREC, 0) AS PAIDAMT, OPENINGBILL.BILL_NO AS BILL, OPENINGBILL.BILL_DATE AS PARTYBILLDATE, 'GOODS PURCHASE' AS PURTYPE, OPENINGBILL.BILL_INITIALS AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(OPENINGBILL.BILL_NARRATION, '') AS REMARKS, ISNULL(OPENINGBILL.BILL_AMT, 0) AS BILLAMT,0 AS TOTALTAXAMT, 0 AS TOTALCHGSAMT,'' AS TOTALCHARGES, 0 AS ROUNDOFF, ISNULL(OPENINGBILL.BILL_AMT, 0) AS GRANDTOTAL, 0 AS SRNO, '' AS CHARGES, 0 AS PER, 0 AS AMT,'OPENING' AS TYPE, ISNULL(REGLEDGERS.ACC_CMPNAME,'') AS CREDITLEDGER, BILL_AMT AS TOTALTAXABLEAMT, 0 AS TOTALCGSTAMT, 0 AS TOTALSGSTAMT, 0 AS TOTALIGSTAMT, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, '' AS HSNITEMDESC,  '' AS HSNCODE FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.ACC_ID WHERE OPENINGBILL.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND OPENINGBILL.BILL_YEARID = " & YearId & ") AS T", "")

            If DT.Rows.Count > 0 Then
                For Each dr As DataRow In DT.Rows

                    'If Convert.ToDateTime(DT.Rows(0).Item("PARTYBILLDATE")).Date >= "01/07/2017" And DT.Rows(0).Item("PURTYPE") = "GOODS PURCHASE" Then
                    '    MsgBox("Debit Note Cannot be Raised for This Invoice, Create Purchase Return", MsgBoxStyle.Critical)
                    '    Exit Sub
                    'End If

                    'IF PAYMENT IS MADE THEN TOO ALLOW TO CREATE DEBIT NOTE
                    'BY GULKIT
                    'If DT.Rows(0).Item("PAIDAMT") > 0 Then
                    '    MsgBox("Payment Made, Delete Payment First", MsgBoxStyle.Critical)
                    '    Exit Sub
                    'End If

                    TYPE = dr("TYPE")
                    If TYPE = "INVOICE" Then CHKGSTR1.CheckState = CheckState.Checked

                    CMBNAME.Text = dr("NAME")
                    CMBAGENT.Text = dr("AGENTNAME")
                    TXTSTATECODE.Text = dr("STATECODE")
                    CMBSACDESC.Text = DT.Rows(0).Item("HSNITEMDESC")
                    TXTSACCODE.Text = DT.Rows(0).Item("HSNCODE")
                    GETHSNCODE()

                    CMBCREDITLEDGER.Text = DT.Rows(0).Item("CREDITLEDGER")
                    TXTTOTALPURAMT.Text = Val(dr("TOTALTAXABLEAMT"))

                    TXTTOTALTAXAMT.Text = dr("TOTALTAXAMT")
                    TXTTOTALOTHERCHGSAMT.Text = dr("TOTALCHGSAMT")
                    TXTCHARGES.Text = dr("TOTALCHARGES")

                    TXTCGSTAMT.Text = DT.Rows(0).Item("TOTALCGSTAMT")
                    TXTSGSTAMT.Text = DT.Rows(0).Item("TOTALSGSTAMT")
                    TXTIGSTAMT.Text = DT.Rows(0).Item("TOTALIGSTAMT")

                    txtroundoff.Text = dr("ROUNDOFF")
                    txtgrandtotal.Text = dr("GRANDTOTAL")
                    If txtremarks.Text = "" Then txtremarks.Text = dr("BILLNO")


                    'GRIDCHGS.Rows.Add(dr("SRNO"), dr("CHARGES"), dr("PER"), dr("AMT"))

                Next

                CMBNAME.Enabled = False

            End If

            'CHARGES GRID
            If TYPE = "PURCHASE" And ClientName <> "SOFTAS" Then
                Dim OBJCM2 As New ClsCommon
                Dim dt2 As DataTable = OBJCM2.search(" isnull(PURCHASEMASTER_CHGS.BILL_gridsrno,0) AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT, ISNULL(TAXMASTER.TAX_ID, 0) AS TAXID ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER.BILL_CMPID = REGISTERMASTER.register_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = REGISTERMASTER.register_locationid AND PURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN PURCHASEMASTER_CHGS LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_yearid = TAXMASTER.tax_yearid AND PURCHASEMASTER_CHGS.BILL_locationid = TAXMASTER.tax_locationid AND PURCHASEMASTER_CHGS.BILL_cmpid = TAXMASTER.tax_cmpid AND PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID LEFT OUTER JOIN LEDGERS ON PURCHASEMASTER_CHGS.BILL_yearid = LEDGERS.Acc_yearid AND PURCHASEMASTER_CHGS.BILL_locationid = LEDGERS.Acc_locationid AND PURCHASEMASTER_CHGS.BILL_cmpid = LEDGERS.Acc_cmpid AND PURCHASEMASTER_CHGS.BILL_CHARGESID = LEDGERS.Acc_id", " AND PURCHASEMASTER.BILL_INITIALS  = '" & TXTBILLNO.Text.Trim & "' AND PURCHASEMASTER.BILL_CMPID = " & CmpId & " AND PURCHASEMASTER.BILL_YEARID = " & YearId)
                If dt2.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt2.Rows
                        GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                    Next
                End If
            End If
            PURCHASETOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOTALPURAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTALPURAMT.Validated
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BILLNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Debit Note?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJCN As New CrDrNoteDesign
                OBJCN.BILLNO = BILLNO
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.PARTYNAME = CMBNAME.Text.Trim
                OBJCN.AGENTNAME = CMBAGENT.Text.Trim
                OBJCN.MdiParent = MDIMain
                OBJCN.FRMSTRING = "PROFORMADEBIT"
                OBJCN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Rec Made, Delete Rec First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToDateTime(DNDATE.Text).Date < DNBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(DNBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Debit Note Permanently?", MsgBoxStyle.YesNo, "PROTRADE")
                If tempmsg = vbYes Then

                    Dim OBJDN As New ClsProformaDebitNote
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TYPE)
                    ALPARAVAL.Add(TEMPDNNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)

                    OBJDN.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJDN.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    edit = False
                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHARGES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHARGES.Validating
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, edit, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' or GROUPMASTER.GROUP_SECONDARY = 'Sales A/C')")
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
                OBJLEDGER.STRSEARCH = " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' or GROUPMASTER.GROUP_SECONDARY = 'Sales A/C')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBCHARGES.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
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
            Else
                TXTCHGSPER.Clear()
                TXTCHGSAMT.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBACCCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' or GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' )")
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

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    'CHECK WHETHER IT IS ALREADY PRESENT IN GRID OR NOT
                    If Not CHECKVALIDATE() Then
                        MsgBox("Charges Already Present Below", MsgBoxStyle.Critical)
                        CMBCHARGES.Focus()
                        Exit Sub
                    End If
                    fillchgsgrid()
                    PURCHASETOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")
                    CMBCHARGES.Focus()
                    Exit Sub
                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                If GRIDCHGSDOUBLECLICK = False Or (GRIDCHGSDOUBLECLICK = True And TEMPCHGSROW <> ROW.Index) Then
                    If CMBCHARGES.Text.Trim = ROW.Cells(ECHARGES.Index).Value Then
                        BLN = False
                    End If
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillchgsgrid()
        Try
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
            PURCHASETOTAL()

            GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

            TXTCHGSSRNO.Text = GRIDCHGS.RowCount + 1
            CMBCHARGES.Text = ""
            TXTCHGSPER.Clear()
            TXTCHGSAMT.Clear()
            If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False
            CMBCHARGES.Focus()
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

    Private Sub ProformaDebitNote_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            If ClientName = "SVS" Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPDNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPDNNO > 0 Then
                edit = True
                ProformaDebitNote_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            'If TEMPDNNO > 1 Then
            '    TXTDNNO.Text = TEMPDNNO
            '    GoTo LINE1
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_DN()
            Dim MAXNO As Integer = TXTDNNO.Text.Trim
            clear()
            If Val(TXTDNNO.Text) - 1 >= TEMPDNNO Then
                edit = True
                ProformaDebitNote_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            'If TEMPDNNO < MAXNO Then
            '    TXTDNNO.Text = TEMPDNNO
            '    GoTo LINE1
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objDNdtls As New ProformaDebitNoteDetails
            objDNdtls.MdiParent = MDIMain
            objDNdtls.Show()
            objDNdtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Sub EDITCHGSROW()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                CMBCHARGES.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                PURCHASETOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCHGSPER.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSPER.Text.Trim) <> 0 Then
                TXTCHGSAMT.Text = ((Val(TXTTOTALPURAMT.Text.Trim) * Val(TXTCHGSPER.Text.Trim)) / 100)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSACDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Enter
        Try
            If CMBSACDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBSACDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            TXTSACCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()

            If CMBSACDESC.Text.Trim <> "" And Convert.ToDateTime(DNDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTSACCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
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
                End If
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSACDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNITEMDESC As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_ITEMDESC, '') AS HSNITEMDESC ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNITEMDESC"
                CMBHSNITEMDESC.DataSource = dt
                CMBHSNITEMDESC.DisplayMember = "HSNITEMDESC"
            End If
            CMBSACDESC.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(sender As Object, e As EventArgs) Handles CMDVIEW.Click
        Try
            If CMBNAME.Text.Trim <> "" Then

                Dim OBJSELECTBILL As New SelectBills
                OBJSELECTBILL.CMPNAME = CMBNAME.Text.Trim
                OBJSELECTBILL.ShowDialog()
                If OBJSELECTBILL.BILLNO <> "" Then
                    TXTBILLNO.Text = OBJSELECTBILL.BILLNO
                    TXTPARTYBILLNO.Text = OBJSELECTBILL.REFNO
                    TXTPARTYBILLDATE.Text = OBJSELECTBILL.BILLDATE.ToString
                    TXTBILLNO.Focus()
                End If

            Else
                MsgBox("Select Name")
                CMBNAME.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALROUND_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALROUND.CheckedChanged
        Try
            If CHKMANUALROUND.Checked = True Then
                txtroundoff.ReadOnly = False
                txtroundoff.TabStop = True
            Else
                txtroundoff.ReadOnly = True
                txtroundoff.TabStop = False
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtroundoff.KeyPress, TXTCHGSPER.KeyPress, TXTCHGSAMT.KeyPress
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

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTCGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSGSTAMT.Validated, txtroundoff.Validated, TXTIGSTAMT.Validated, TXTCGSTAMT.Validated
        PURCHASETOTAL()
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
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPARTYBILLDATE_Validating(sender As Object, e As CancelEventArgs) Handles TXTPARTYBILLDATE.Validating
        Try
            If TXTPARTYBILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TXTPARTYBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDNNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTDNNO.Validating
        Try
            If ALLOWMANUALCNDN = True Then
                If (Val(TXTDNNO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And edit = False) Or (edit = True And TEMPDNNO <> Val(TXTDNNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(PROFORMADEBITNOTEMASTER.DN_no, 0) AS CNNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PROFORMADEBITNOTEMASTER ON REGISTERMASTER.register_id = PROFORMADEBITNOTEMASTER.DN_REGISTERID ", "  AND PROFORMADEBITNOTEMASTER.DN_NO=" & TXTDNNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PROFORMADEBITNOTEMASTER.DN_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("DebitNote No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If edit = True Then SENDWHATSAPP(TEMPDNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(DNNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJCN As New CrDrNoteDesign
            OBJCN.MdiParent = MDIMain
            OBJCN.DIRECTPRINT = True
            OBJCN.FRMSTRING = "PROFORMADEBIT"
            OBJCN.DIRECTMAIL = False
            OBJCN.DIRECTWHATSAPP = True
            OBJCN.REGNAME = cmbregister.Text.Trim
            OBJCN.PRINTSETTING = PRINTDIALOG
            OBJCN.BILLNO = Val(DNNO)
            OBJCN.NOOFCOPIES = 1
            OBJCN.Show()
            OBJCN.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\DN_" & Val(DNNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("DN_" & Val(DNNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTDNNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTDNNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class