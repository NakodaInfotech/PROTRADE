
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL
Imports Newtonsoft.Json
Imports RestSharp
Imports TaxProEInvoice.API

Public Class CREDITNOTE

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim temprefno As String
    Dim CNREGABBR, CNREGINITIAL As String
    Dim CNREGID As Integer

    Dim TYPE As String  'USED FOR FORMTYPE WHILE RETRIVING DATA FROM GETDATA FUNCTION AND PASSING IN TO SP
    Public FRMSTRING As String  ' USER FOR BOOKTYPE 
    Public TEMPCNNO As Integer
    Public BILLNO As String
    Dim TEMPPARTYBILLNO As String
    Public TEMPREGNAME As String
    Dim GRIDCHGSDOUBLECLICK, GRIDADJDOUBLECLICK As Boolean
    Dim TEMPCHGSROW, TEMPADJROW As Integer
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            edit = False
            cmbregister.Enabled = True
            cmbregister.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            tstxtbillno.Clear()

            If ALLOWMANUALCNDN = True Then
                TXTCNNO.ReadOnly = False
                TXTCNNO.BackColor = Color.LemonChiffon
            Else
                TXTCNNO.ReadOnly = True
                TXTCNNO.BackColor = Color.Linen
            End If

            EP.Clear()

            TXTBILLNO.Enabled = True
            TXTBILLNO.Clear()

            TXTINVPRINTINITIALS.Clear()
            TXTTOTALPCS.Clear()
            TXTTOTALMTRS.Clear()
            TXTACTUALINVAMT.Clear()
            TXTDISCPER.Clear()

            CMBNAME.Text = ""
            CMBNAME.Enabled = True
            CMBAGENT.Text = ""
            TXTSTATECODE.Clear()
            TXTPARTYBILLNO.Clear()
            CMBDEBITLEDGER.Text = ""
            CMBDEBITLEDGER.Enabled = True
            CMBPACKING.Text = ""

            txtremarks.Clear()
            TXTBILLREMARKS.Clear()
            txtinwords.Clear()

            CNREGABBR = ""
            CNREGINITIAL = ""
            TXTCHARGES.Text = 0.0
            TXTTOTALTAXAMT.Clear()
            TXTTOTALOTHERCHGSAMT.Clear()
            CNDATE.Text = Now.Date
            ACTUALINVDATE.Text = Now.Date

            CHKTDS.CheckState = CheckState.Unchecked
            CHKRCM.CheckState = CheckState.Unchecked
            CHKMANUAL.CheckState = CheckState.Unchecked

            TXTCHGSSRNO.Clear()
            CMBCHARGES.Text = ""
            TXTCHGSPER.Clear()
            TXTCHGSAMT.Clear()
            GRIDCHGS.RowCount = 0


            TXTAMTREC.Clear()
            TXTRETURN.Clear()
            TXTEXTRAAMT.Clear()
            TXTBAL.Clear()
            TXTTDSAMT.Clear()

            TXTTOTALSALEAMT.Text = 0.0
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0

            txtsubtotal.Text = 0.0

            CHKTCS.Checked = False
            TXTTOTALWITHGST.Clear()
            TXTTCSPER.Clear()
            TXTTCSAMT.Clear()

            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            lbllocked.Visible = False
            PBlock.Visible = False
            PBPAID.Visible = False
            PBTDS.Visible = False
            CMDSHOWDETAILS.Visible = False


            TXTCHQBAL.Clear()
            CMBPAYTYPE.SelectedIndex = 0
            CMBBILLNO.Text = ""
            LBLBILLTOTAL.Text = ""
            TXTNARR.Clear()
            TXTADJAMT.Clear()
            TXTADJTOTAL.Clear()
            TXTINVTOTAL.Clear()

            GRIDPAYMENT.RowCount = 0
            GRIDBILL.DataSource = Nothing

            TXTADJSRNO.Text = 1
            TXTIRNNO.Clear()
            PBQRCODE.Image = Nothing
            TXTACKNO.Clear()
            getmaxno_CN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            txtsubtotal.Text = 0.0
            If CHKMANUALROUND.CheckState = CheckState.Unchecked Then txtroundoff.Text = 0
            txtgrandtotal.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTTOTALTAXAMT.Clear()
            TXTTOTALOTHERCHGSAMT.Clear()

            TXTTCSPER.Text = 0
            TXTTCSAMT.Text = 0

            TXTINVTOTAL.Text = 0.0
            TXTADJTOTAL.Text = 0.0
            TXTCHQBAL.Text = 0.0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(CNDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))

            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    If Val(row.Cells(EPER.Index).Value) Then row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value * Val(TXTTOTALSALEAMT.Text.Trim)) / 100), "0.00")
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                    If Val(row.Cells(ETAXID.Index).Value) > 0 Then TXTTOTALTAXAMT.Text = Format(Val(TXTTOTALTAXAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00") Else TXTTOTALOTHERCHGSAMT.Text = Format(Val(TXTTOTALOTHERCHGSAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If
            txtsubtotal.Text = Format(Val(TXTTOTALSALEAMT.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")
            End If


            TXTTOTALWITHGST.Text = Format(Val(txtsubtotal.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0.00")
            If CHKTCS.CheckState = CheckState.Checked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")


            If CHKMANUALROUND.Checked = False Then
                txtgrandtotal.Text = Format(Val(txtsubtotal.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtsubtotal.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")
            Else
                txtgrandtotal.Text = Format(Val(txtsubtotal.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim) + Val(txtroundoff.Text.Trim), "0.00")
            End If
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

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

    Sub FILLCMBBILLNO()
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.Items.Clear()
        For Each row As DataGridViewRow In GRIDBILL.Rows
            If Convert.ToBoolean(row.Cells(GRIDBILL.Columns("INVCHK").Index).Value) = True Then
                CMBBILLNO.Items.Add(row.Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value.ToString())
            End If
        Next
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.SelectedIndex = (0)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If edit = False Then
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

            ElseIf edit = True Then
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
                        Dim DT As DataTable = OBJCMN.search("ISNULL(SUM(T.RECAMT),0) AS RECAMT ", "", " (SELECT SUM(CREDITNOTEMASTER_BILLDESC.CN_amt)  AS RECAMT, CN_BILLINITIALS AS BILLINITIALS, CN_NO as RECNO, register_name AS REGNAME, CN_cmpid AS CMPID, 0 AS LOCATIONID, CN_yearid AS YEARID FROM CREDITNOTEMASTER_BILLDESC INNER JOIN REGISTERMASTER ON register_id = CN_registerid WHERE CN_paytype = 'Against Bill' GROUP BY CN_BILLINITIALS, CN_no, register_name , CN_CMPID , CN_YEARID ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.RECNO =  " & TXTCNNO.Text.Trim & " AND T.BILLINITIALS ='" & CMBBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(LBLBILLTOTAL.Text.Trim) + Val(DT.Rows(0).Item("RECAMT"))
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

            TOTAL()
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

    Private Sub GRIDPAYMENT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPAYMENT.CellDoubleClick
        Try

            EDITADJROW()

            If CMBBILLNO.Text.Trim <> "" Then
                CMBBILLNO.Enabled = True

                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALANCE", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID, INVOICE_LOCATIONID AS LOCATIONID, INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE  UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref') AS T", " AND T.BILLINITIALS = '" & CMBBILLNO.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    LBLBILLTOTAL.Text = Format(DT.Rows(0).Item("BALANCE"), "0.00")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAYMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPAYMENT.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDADJDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If
            GRIDPAYMENT.Rows.RemoveAt(GRIDPAYMENT.CurrentRow.Index)
            TOTAL()
            getsrno(GRIDPAYMENT)
        ElseIf e.KeyCode = Keys.F5 Then
            EDITADJROW()
        End If
    End Sub

    Private Sub GRIDBILL_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBILL.KeyDown
        Dim ARGS As New DataGridViewCellEventArgs(GRIDBILL.CurrentCell.ColumnIndex, GRIDBILL.CurrentRow.Index)
        If e.KeyCode = Keys.F8 Then Call GRIDBILL_CellClick(sender, ARGS)
    End Sub

    Private Sub CMBBILLNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBILLNO.GotFocus
        FILLCMBBILLNO()
    End Sub

    Private Sub CMBBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBILLNO.Validating
        Try

            LBLBILLTOTAL.Text = ""

            If CMBBILLNO.Text.Trim <> "" Then
                CMBBILLNO.Text = UCase(CMBBILLNO.Text)

                'CHECKING WHETHER THE BILL IS VALID OR NOT
                Dim BLN As Boolean = False
                For Each ITEMS As Object In CMBBILLNO.Items
                    If ITEMS.ToString = CMBBILLNO.Text.Trim Then
                        BLN = True
                    End If
                Next
                If Not BLN Then
                    MsgBox("Invalid Bill No.", MsgBoxStyle.Critical, "PROTRADE")
                    CMBBILLNO.Focus()
                    Exit Sub
                End If



                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID , INVOICE_LOCATIONID AS LOCATIONID , INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref' ) AS T", " AND T.BILLINITIALS = '" & CMBBILLNO.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    LBLBILLTOTAL.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
                End If

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        CMBPAYTYPE.Text = "Against Bill"
                        CMBBILLNO.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        CMBBILLNO.Enabled = True
                        TXTNARR.Clear()
                        LBLBILLTOTAL.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBALAMT").Index).Value

                        'GET INVPRINTTINITIALS | PCS | MTRS | BILLAMT
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search("*", "", " (SELECT INVOICEMASTER.INVOICE_AMTREC AS RECDAMT, INVOICEMASTER.INVOICE_NO AS BILL, INVOICEMASTER.INVOICE_DATE AS DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLNO, INVOICEMASTER.INVOICE_CMPID, INVOICEMASTER.INVOICE_LOCATIONID, INVOICEMASTER.INVOICE_YEARID, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME, INVOICEMASTER.INVOICE_AMOUNT AS SALEAMT, INVOICE_SUBTOTAL AS TAXABLEAMT, 0 AS TOTALCHGSAMT, ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) AS TOTALCHARGES, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS GTOTAL, 'INVOICE' AS TYPE, ISNULL(REGLEDGERS.Acc_cmpname,'') AS DEBITLEDGER, ISNULL(INVOICEMASTER.INVOICE_CGSTPER, 0) AS CGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGSTAMT, ISNULL(INVOICEMASTER.INVOICE_SGSTPER, 0) AS SGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGSTAMT, ISNULL(INVOICEMASTER.INVOICE_IGSTPER, 0) AS IGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(DELIVERYLEDGERS.ACC_CMPNAME,'') AS DELIVERYAT, ISNULL(INVOICE_PRINTINITIALS,'') AS INVPRINTINITIALS, ISNULL(INVOICE_TOTALPCS,0) AS TOTALPCS, ISNULL(INVOICE_TOTALMTRS,0) AS TOTALMTRS,  INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS DELIVERYLEDGERS ON INVOICEMASTER.INVOICE_PACKINGID = DELIVERYLEDGERS.Acc_id  INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.ACC_ID WHERE INVOICEMASTER.INVOICE_INITIALS = '" & GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " UNION ALL SELECT OPENINGBILL.BILL_AMTPAIDREC AS RECDAMT, OPENINGBILL.BILL_NO AS BILL, OPENINGBILL.BILL_DATE AS DATE, OPENINGBILL.BILL_INITIALS AS BILLNO, OPENINGBILL.BILL_CMPID, OPENINGBILL.BILL_LOCATIONID, OPENINGBILL.BILL_YEARID, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME, OPENINGBILL.BILL_AMT AS SALEAMT, OPENINGBILL.BILL_AMT AS TAXABLEAMT, 0 AS TOTALCHGSAMT, 0 AS TOTALCHARGES, 0 AS ROUNDOFF, OPENINGBILL.BILL_AMT AS GTOTAL, 'OPENING' AS TYPE, ISNULL(REGLEDGERS.Acc_cmpname,'') AS DEBITLEDGER, 0 AS CGSTPER, 0 AS CGSTAMT, 0 AS SGSTPER, 0 AS SGSTAMT, 0 AS IGSTPER, 0 AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, '' AS DELIVERYAT, ISNULL(BILL_PRINTINITIALS,'') AS INVPRINTINITIALS, ISNULL(BILL_PCS,0) AS TOTALPCS, ISNULL(BILL_MTRS,0) AS TOTALMTRS,  ISNULL(OPENINGBILL.BILL_TOTALAMT,0) AS GROSSAMT FROM  OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.ACC_ID WHERE OPENINGBILL.BILL_INITIALS = '" & GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value & "' AND OPENINGBILL.BILL_YEARID = " & YearId & ") AS T", "")
                        If DT.Rows.Count > 0 Then
                            TXTINVPRINTINITIALS.Text = DT.Rows(0).Item("INVPRINTINITIALS")
                            TXTTOTALPCS.Text = Val(DT.Rows(0).Item("TOTALPCS"))
                            TXTTOTALMTRS.Text = Val(DT.Rows(0).Item("TOTALMTRS"))
                            TXTACTUALINVAMT.Text = Val(DT.Rows(0).Item("GROSSAMT"))
                            If ClientName = "SUPRIYA" Then CMBDEBITLEDGER.Focus()
                        End If

                        Dim A As System.ComponentModel.CancelEventArgs
                        TXTADJAMT_Validating(sender, A)

                    End If
                    TOTAL()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno_CN()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(CN_NO),0) + 1 ", "CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = REGISTER_ID ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CN_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTCNNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITNOTEdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CNDATE.Validating
        Try
            If CNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CNDATE.Text, TEMP) Then
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CREDITNOTE'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CREDITNOTE' and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_CN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

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
            For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
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


            If TXTBILLNO.Text.Trim <> "" And TYPE = Nothing Then
                TYPE = "INVOICE"
            ElseIf TXTBILLNO.Text.Trim = "" Then
                TYPE = ""
            End If



            Dim alParaval As New ArrayList

            If ALLOWMANUALCNDN = True Then
                alParaval.Add(Val(TXTCNNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(TYPE)
            alParaval.Add(Format(Convert.ToDateTime(CNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTSACCODE.Text.Trim)
            alParaval.Add(CMBDEBITLEDGER.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)

            alParaval.Add(TXTINVPRINTINITIALS.Text.Trim)
            alParaval.Add(Val(TXTTOTALPCS.Text.Trim))
            alParaval.Add(Val(TXTTOTALMTRS.Text.Trim))
            alParaval.Add(Val(TXTACTUALINVAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))


            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALTAXAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALOTHERCHGSAMT.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))

            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUALROUND.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKNOGSTR1.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(txtsubtotal.Text.Trim))

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBILLREMARKS.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

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
                        CAMT = Val(row.Cells(EAMT.Index).Value)
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)
                    Else
                        CSRNO = CSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & row.Cells(EPER.Index).Value.ToString
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

            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            Dim objclsCNmaster As New ClsCreditNote()
            objclsCNmaster.alParaval = alParaval
            Dim DTTABLE As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                DTTABLE = objclsCNmaster.SAVE()
                MessageBox.Show("Details Added")
                PRINTREPORT(DTTABLE.Rows(0).Item(0))
                TXTCNNO.Text = Val(DTTABLE.Rows(0).Item(0))

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = Val(DTTABLE.Rows(0).Item(0))
                    OBJTDS.REGISTER = cmbregister.Text.Trim
                    OBJTDS.ShowDialog()
                End If

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCNNO)
                Dim INTRES As Integer = objclsCNmaster.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPCNNO)
                edit = False
            End If



            If ClientName = "SAKARIA" Then SENDDIRECTMAIL()


            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)
            CNDATE.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDDIRECTMAIL()
        Try
            If MsgBox("Wish To Mail Credit Note?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim ALATTACHMENT As New ArrayList

            'CHECK WHETHER EMAILID IS PRESENT IN LEDGER OR NOT, IF NOT THEN EXIT SUB WITH MESSAGE
            Dim OBJCMN As New ClsCommon
            Dim DTEMAIL As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", "AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DTEMAIL.Rows.Count > 0 AndAlso DTEMAIL.Rows(0).Item("EMAILID") <> "" Then

                Dim OBJCN As New CrDrNoteDesign
                OBJCN.MdiParent = MDIMain
                OBJCN.DIRECTPRINT = True
                OBJCN.FRMSTRING = "CREDIT"
                OBJCN.DIRECTMAIL = True
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.PRINTSETTING = PRINTDIALOG
                OBJCN.BILLNO = Val(TXTCNNO.Text.Trim)
                OBJCN.NOOFCOPIES = 1
                OBJCN.Show()
                OBJCN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\CN_" & Val(TXTCNNO.Text.Trim) & ".pdf")
                sendemail(DTEMAIL.Rows(0).Item("EMAILID"), ALATTACHMENT(0), "", "Credit Note", ALATTACHMENT, ALATTACHMENT.Count, "", "", "", "", "")
                MsgBox("Mail Sent")
            Else
                MsgBox("Add E-Mail id in Ledger")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CNDATE.Text = "__/__/____" Then
                EP.SetError(CNDATE, " Please Enter Proper Date")
                bln = False
                Return bln
                Exit Function
            Else
                If Not datecheck(CNDATE.Text) Then
                    EP.SetError(CNDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(CNDATE.Text).Date < CNBLOCKDATE.Date Then
                    EP.SetError(CNDATE, "Date is Blocked, Please make entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            If ACTUALINVDATE.Text = "__/__/____" Then
                EP.SetError(ACTUALINVDATE, " Please Enter Proper Date")
                bln = False
                Return bln
                Exit Function
            End If


            'IF BILL NOT ADJUSTED AND GRID IS BLANK THEN MAKE ON ACCOUNT ENTRY
            If TXTBILLNO.Text.Trim = "" And GRIDPAYMENT.RowCount = 0 Then
                GRIDPAYMENT.Rows.Add(1, "On Account", "", "", Val(txtgrandtotal.Text.Trim), 0, 0, 0, Val(txtgrandtotal.Text.Trim))
                TOTAL()
            End If

            If TXTBILLNO.Text.Trim <> "" And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(TXTBILLNO, "Amount cannot be Adjusted against Multiple Bills")
                bln = False
            End If


            If Val(txtgrandtotal.Text.Trim) <> Val(TXTADJTOTAL.Text.Trim) And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(txtgrandtotal, "Total does not match Adjusted Amt")
                bln = False
            End If


            If Convert.ToDateTime(CNDATE.Text).Date >= "01/07/2017" Then
                If TXTSTATECODE.Text.Trim.Length = 0 Then
                    EP.SetError(TXTSTATECODE, "Please enter the state code")
                    bln = False
                End If
            End If

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Select Register Name")
                bln = False
            End If


            'IF INVOICENO IS NOT BLANK THEN CHECK THAT FIGURES CANNOT BE GREATER THEN BALANCEAMT
            If TXTBILLNO.Text.Trim <> "" Then
                Dim BALANCE As Double = 0
                Dim DT As New DataTable
                Dim OBJCMN As New ClsCommon
                If TYPE = "INVOICE" Then
                    DT = OBJCMN.search("ISNULL(INVOICE_BALANCE,0) AS INVBAL", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
                Else
                    DT = OBJCMN.search("ISNULL(BILL_BALANCE,0) AS INVBAL", "", "OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID", " AND BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then BALANCE = Val(DT.Rows(0).Item("INVBAL"))
                If edit = True Then
                    Dim DT1 As DataTable = OBJCMN.search("CN_GTOTAL AS RETTOTAL", "", "CREDITNOTEMASTER", " AND CN_NO = " & Val(TEMPCNNO) & " AND CN_YEARID = " & YearId)
                    If DT1.Rows.Count > 0 Then BALANCE += Val(DT1.Rows(0).Item("RETTOTAL"))
                End If
                If Val(txtgrandtotal.Text.Trim) > Val(BALANCE) Then
                    EP.SetError(txtgrandtotal, "Amount Greater then Balance Amt, only " & Val(BALANCE) & " can be Used")
                    bln = False
                End If
            End If


            For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" And ROW.Cells(gbillno.Index).Value = "" Then
                    EP.SetError(cmbregister, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    bln = False
                End If

                If ROW.Cells(gpaytype.Index).Value = "New Ref" And ROW.Cells(gdesc.Index).Value = "" Then
                    EP.SetError(cmbregister, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    bln = False
                End If
            Next



            If CMBNAME.Text.Trim = "" Then
                EP.SetError(CMBNAME, "Select Invoice")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim = "" Then
                EP.SetError(CMBDEBITLEDGER, "Select Debit Ledger")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim = CMBNAME.Text.Trim Then
                EP.SetError(CMBDEBITLEDGER, "Credit and Debit Ledger cannot be kept same")
                bln = False
            End If

            If txtgrandtotal.Text.Trim = "" Then
                EP.SetError(txtgrandtotal, "Enter Amount")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Sale Return Made , Delete Sale Return First")
                bln = False
            End If

            If Not datecheck(CNDATE.Text) Then
                EP.SetError(CNDATE, "Date Not in Current Accounting Year")
                bln = False
            End If

            If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
                bln = False
            End If

            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (edit = False) Or (edit = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" CN_INITIALS AS BILLNO", "", " CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND CN_PARTYREFNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND CN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                        bln = False
                    End If
                End If
            End If



            If ALLOWMANUALCNDN = True Then
                If TXTCNNO.Text <> "" And CMBNAME.Text.Trim <> "" And edit = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(CREDITNOTEMASTER.CN_no, 0) AS BILLNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CREDITNOTEMASTER ON REGISTERMASTER.register_id = CREDITNOTEMASTER.CN_REGISTERID AND REGISTERMASTER.register_cmpid = CREDITNOTEMASTER.CN_CMPID AND REGISTERMASTER.register_yearid = CREDITNOTEMASTER.CN_YEARID AND REGISTERMASTER.register_locationid = CREDITNOTEMASTER.CN_LOCATIONID", "  AND CREDITNOTEMASTER.CN_NO=" & TXTCNNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CREDITNOTEMASTER.CN_cmpid = " & CmpId & " AND CREDITNOTEMASTER.CN_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTCNNO, "Bill No Already Exist")
                        bln = False
                    End If
                End If
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
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

    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (edit = False) Or (edit = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" CN_INITIALS AS BILLNO", "", " CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND CN_PARTYREFNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND CN_YEARID = " & YearId)
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

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CREDITNOTE' and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    CNREGABBR = dt.Rows(0).Item(0).ToString
                    CNREGINITIAL = dt.Rows(0).Item(1).ToString
                    CNREGID = dt.Rows(0).Item(2)
                    getmaxno_CN()
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
            fillregister(cmbregister, " and register_type = 'CREDITNOTE' ")
            If ClientName = "AVIS" Then
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, edit, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND GROUP_NAME = 'HASTE DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS') AND GROUP_NAME <> 'HASTE DEBTORS'  AND ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, edit, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "  AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
            End If
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, edit, "")
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, edit, " AND (GROUPMASTER.GROUP_SECONDARY ='Indirect Income' OR GROUPMASTER.GROUP_SECONDARY ='Indirect Expenses' or GROUPMASTER.GROUP_SECONDARY ='Direct Income' OR GROUPMASTER.GROUP_SECONDARY ='Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY ='Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' or GROUPMASTER.GROUP_SECONDARY = 'Sales A/C')")
            If CMBSACDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBSACDESC)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If ClientName = "AVIS" Then
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, edit, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND GROUP_NAME = 'HASTE DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, edit, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, TXTADD, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
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

                'GET TDSAPPLICABLE
                DT = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TDSPER")) > 0 Then CHKTDS.CheckState = CheckState.Checked
                End If


                CMBNAME.Enabled = False
                GETHSNCODE()
                FILLGRIDINVOICE()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDINVOICE()
        Try
            GRIDBILL.DataSource = Nothing
            TXTINVTOTAL.Clear()
            Dim objpayment As New ClsReceiptMaster
            Dim DT As New DataTable
            DT = objpayment.GETBILLS(CmpId, CMBNAME.Text.Trim, Locationid, YearId)
            If DT.Rows.Count > 0 Then SETGRIDINVOICE(DT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SETGRIDINVOICE(ByVal DT As DataTable)
        Try
            'FOR ADDING NEW CHKCOL IN GRIDBILL

            DT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
            GRIDBILL.DataSource = DT
            If a = 0 Then
                GRIDBILL.Columns.Insert(0, col)
                a = 1
            End If
            Dim i As Integer = 0

            GRIDBILL.Columns(i).Width = 40
            GRIDBILL.Columns(i).Name = "INVCHK"
            GRIDBILL.Columns(i).HeaderText = ""
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBILLINITIALS"
            GRIDBILL.Columns(i).HeaderText = "Bill No."
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 80
            GRIDBILL.Columns(i).Name = "REFNO"
            GRIDBILL.Columns(i).HeaderText = "Ref No"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 80
            GRIDBILL.Columns(i).Name = "INVBILLDATE"
            GRIDBILL.Columns(i).HeaderText = "Bill Date"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBALAMT"
            GRIDBILL.Columns(i).HeaderText = "Bal. Amt"
            GRIDBILL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(i).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBILLAMT"
            GRIDBILL.Columns(i).HeaderText = "Bill Amt"
            GRIDBILL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(i).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVBILLTYPE"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVBILLNO"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVREGNAME"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVCUSNAME"
            i += 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')", "SUNDRY DEBTORS", "ACCOUNTS", "", CMBAGENT.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEBITLEDGER.Enter
        Try
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEBITLEDGER.Validating
        Try
            If CMBDEBITLEDGER.Text.Trim <> "" Then namevalidate(CMBDEBITLEDGER, CMBACCCODE, e, Me, TXTOTHERCHGSADD, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        TOTAL()
    End Sub

    Private Sub CREDITNOTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CREDIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

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
                Dim objclsCN As New ClsCreditNote()
                dt = objclsCN.selectCREDITNOTE_edit(TEMPCNNO, TEMPREGNAME, CmpId, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTCNNO.Text = TEMPCNNO
                        TXTCNNO.ReadOnly = True
                        CMBNAME.Enabled = False


                        cmbregister.Text = TEMPREGNAME
                        TYPE = dt.Rows(0).Item("TYPE")
                        TXTSTATECODE.Text = dt.Rows(0).Item("STATECODE")
                        CNDATE.Text = Format(Convert.ToDateTime(dr("CNDATE")), "dd/MM/yyyy")
                        ACTUALINVDATE.Text = Format(Convert.ToDateTime(dr("ACTUALINVDATE")), "dd/MM/yyyy")
                        TXTBILLNO.Text = dt.Rows(0).Item("BILLNO")
                        If TXTBILLNO.Text.Trim <> "" Then TXTBILLNO.Enabled = False
                        TXTPARTYBILLNO.Text = Convert.ToString(dr("PARTYREFNO"))
                        TEMPPARTYBILLNO = Convert.ToString(dr("PARTYREFNO"))

                        TXTINVPRINTINITIALS.Text = Convert.ToString(dr("INVPRINTINITIALS"))
                        TXTTOTALPCS.Text = dt.Rows(0).Item("TOTALPCS")
                        TXTTOTALMTRS.Text = dt.Rows(0).Item("TOTALMTRS")
                        TXTACTUALINVAMT.Text = dt.Rows(0).Item("ACTUALINVAMT")
                        TXTDISCPER.Text = dt.Rows(0).Item("DISCPER")


                        CMBNAME.Text = dt.Rows(0).Item("NAME")
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBSACDESC.Text = dt.Rows(0).Item("ITEMDESC")
                        TXTSACCODE.Text = dt.Rows(0).Item("HSNCODE")
                        CMBDEBITLEDGER.Text = dt.Rows(0).Item("DEBITNAME")
                        CMBPACKING.Text = dt.Rows(0).Item("DELIVERYAT")

                        TXTTOTALSALEAMT.Text = dt.Rows(0).Item("PURAMT")
                        TXTTOTALTAXAMT.Text = dt.Rows(0).Item("TOTALTAXAMT")
                        TXTTOTALOTHERCHGSAMT.Text = dt.Rows(0).Item("TOTALOTHERCHGSAMT")
                        TXTCHARGES.Text = dt.Rows(0).Item("TOTALCHARGES")

                        If Convert.ToBoolean(dr("RCM")) = False Then CHKRCM.Checked = False Else CHKRCM.Checked = True
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If Convert.ToBoolean(dr("MANUALROUNDOFF")) = False Then CHKMANUALROUND.Checked = False Else CHKMANUALROUND.Checked = True
                        If Convert.ToBoolean(dr("NOGSTR1")) = False Then CHKNOGSTR1.Checked = False Else CHKNOGSTR1.Checked = True


                        txtsubtotal.Text = dt.Rows(0).Item("SUBTOTAL")
                        TXTCGSTPER.Text = dt.Rows(0).Item("CGSTPER")
                        TXTCGSTAMT.Text = dt.Rows(0).Item("CGSTAMT")
                        TXTSGSTPER.Text = dt.Rows(0).Item("SGSTPER")
                        TXTSGSTAMT.Text = dt.Rows(0).Item("SGSTAMT")
                        TXTIGSTPER.Text = dt.Rows(0).Item("IGSTPER")
                        TXTIGSTAMT.Text = dt.Rows(0).Item("IGSTAMT")

                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))

                        txtroundoff.Text = dt.Rows(0).Item("ROUNDOFF")
                        txtgrandtotal.Text = dt.Rows(0).Item("GTOTAL")

                        TXTAMTREC.Text = Val(dr("AMTREC"))
                        TXTEXTRAAMT.Text = Val(dr("EXTRAAMT"))
                        TXTRETURN.Text = Val(dr("CNRETURN"))
                        TXTBAL.Text = Val(dr("BALANCE"))

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTBILLREMARKS.Text = dr("BILLREMARKS")
                        txtinwords.Text = Convert.ToString(dr("INWORDS"))


                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        Dim OBJCMNTDS As New ClsCommon
                        Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(SUM(JOURNALMASTER.journal_credit),0) AS TDS", "", " JOURNALMASTER INNER JOIN CREDITNOTEMASTER ON JOURNALMASTER.journal_refno = CREDITNOTEMASTER.CN_INITIALS AND  JOURNALMASTER.journal_yearid = CREDITNOTEMASTER.CN_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_REGISTERID = REGISTERMASTER.register_id ", " AND (LEDGERS.ACC_TDSAC = 'True') AND CN_NO = " & TEMPCNNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND CN_YEARID = " & YearId)
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
                            If Val(dr("AMTREC")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBPAID.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                    Next

                    'CHARGES GRID
                    Dim OBJCM2 As New ClsCommon
                    Dim dt2 As DataTable = OBJCM2.search("  CREDITNOTEMASTER_CHGS.CN_gridsrno AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(CREDITNOTEMASTER_CHGS.CN_PER, 0) AS PER, ISNULL(CREDITNOTEMASTER_CHGS.CN_AMT, 0) AS AMT, ISNULL(TAXMASTER.tax_id, 0) AS TAXID", "", "  CREDITNOTEMASTER INNER JOIN CREDITNOTEMASTER_CHGS ON CREDITNOTEMASTER.CN_no = CREDITNOTEMASTER_CHGS.CN_no AND CREDITNOTEMASTER.CN_registerid = CREDITNOTEMASTER_CHGS.CN_REGISTERID AND CREDITNOTEMASTER.CN_yearid = CREDITNOTEMASTER_CHGS.CN_yearid INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id AND CREDITNOTEMASTER.CN_yearid = REGISTERMASTER.register_yearid LEFT OUTER JOIN TAXMASTER ON CREDITNOTEMASTER_CHGS.CN_TAXID = TAXMASTER.tax_id AND CREDITNOTEMASTER_CHGS.CN_yearid = TAXMASTER.tax_yearid LEFT OUTER JOIN LEDGERS ON CREDITNOTEMASTER_CHGS.CN_CHARGESID = LEDGERS.Acc_id AND CREDITNOTEMASTER_CHGS.CN_yearid = LEDGERS.Acc_yearid", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'CREDITNOTE' AND CREDITNOTEMASTER_CHGS.CN_NO = " & TEMPCNNO & " AND CREDITNOTEMASTER_CHGS.CN_YEARID = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If


                    dt2 = OBJCM2.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CREDITNOTE' and register_YEARid = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        CNREGABBR = dt2.Rows(0).Item(0).ToString
                        CNREGINITIAL = dt2.Rows(0).Item(1).ToString
                        CNREGID = dt2.Rows(0).Item(2)
                    End If


                    dt2 = OBJCM2.search(" CREDITNOTEMASTER_BILLDESC.CN_GRIDSRNO AS GRIDSRNO, CREDITNOTEMASTER_BILLDESC.CN_PAYTYPE AS PAYTYPE, CREDITNOTEMASTER_BILLDESC.CN_BILLINITIALS AS BILLINITIALS, CREDITNOTEMASTER_BILLDESC.CN_GRIDREMARKS AS NARR, CREDITNOTEMASTER_BILLDESC.CN_AMT AS AMT, CREDITNOTEMASTER_BILLDESC.CN_AMTPAID AS AMTPAID, CREDITNOTEMASTER_BILLDESC.CN_EXTRAAMT AS EXTRAAMT, CREDITNOTEMASTER_BILLDESC.CN_RETURN AS [RETURN], CREDITNOTEMASTER_BILLDESC.CN_BALANCE AS BALANCE ", "", " CREDITNOTEMASTER_BILLDESC INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER_BILLDESC.CN_registerid = REGISTERMASTER.register_id", " AND CREDITNOTEMASTER_BILLDESC.CN_NO = " & TEMPCNNO & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CREDITNOTEMASTER_BILLDESC.CN_YEARID = " & YearId)
                    For Each DR As DataRow In dt2.Rows
                        GRIDPAYMENT.Rows.Add(DR("GRIDSRNO"), DR("PAYTYPE").ToString, DR("BILLINITIALS").ToString, DR("NARR").ToString, Format(DR("AMT"), "0.00"), Format(DR("AMTPAID"), "0.00"), Format(DR("EXTRAAMT"), "0.00"), Format(DR("RETURN"), "0.00"), Format(DR("BALANCE"), "0.00"))
                        If Val(DR("AMTPAID")) > 0 Or Val(DR("EXTRAAMT")) > 0 Or Val(DR("RETURN")) > 0 Then
                            GRIDPAYMENT.Rows(GRIDPAYMENT.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    FILLGRIDINVOICE()
                    GRIDPAYMENT.ClearSelection()


                    TOTAL()
                    cmbregister.Enabled = False
                    TXTTOTALSALEAMT.Focus()
                Else
                    edit = False
                    CLEAR()
                    TXTCNNO.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            TEMPCNNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPCNNO > 0 Then
                edit = True
                CREDITNOTE_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            'NOW WE HAVE CHANGED THE FORMAT SO NO NEED OF THIS CODE
            ''If TXTBILLNO.Text.Trim <> "" And edit = False Then
            'If TXTBILLNO.Text.Trim <> "" Then
            '    GETDATA()
            '    If Val(txtgrandtotal.Text.Trim) = 0 Then
            '        MsgBox("Invalid Voucher No")
            '        e.Cancel = True
            '        Exit Sub
            '    End If
            '    TXTBILLNO.Enabled = False
            'Else
            '    If edit = True Then TXTBILLNO.Enabled = False
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("*", "", " (SELECT INVOICEMASTER.INVOICE_AMTREC AS RECDAMT, INVOICEMASTER.INVOICE_NO AS BILL, INVOICEMASTER.INVOICE_DATE AS DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLNO, INVOICEMASTER.INVOICE_CMPID, INVOICEMASTER.INVOICE_LOCATIONID, INVOICEMASTER.INVOICE_YEARID, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME, INVOICEMASTER.INVOICE_AMOUNT AS SALEAMT, INVOICE_SUBTOTAL AS TAXABLEAMT, 0 AS TOTALCHGSAMT, ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) AS TOTALCHARGES, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS GTOTAL, 'INVOICE' AS TYPE, ISNULL(REGLEDGERS.Acc_cmpname,'') AS DEBITLEDGER, ISNULL(INVOICEMASTER.INVOICE_CGSTPER, 0) AS CGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGSTAMT, ISNULL(INVOICEMASTER.INVOICE_SGSTPER, 0) AS SGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGSTAMT, ISNULL(INVOICEMASTER.INVOICE_IGSTPER, 0) AS IGSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(DELIVERYLEDGERS.ACC_CMPNAME,'') AS DELIVERYAT, ISNULL(INVOICE_PRINTINITIALS,'') AS INVPRINTINITIALS, ISNULL(INVOICE_TOTALPCS,0) AS TOTALPCS, ISNULL(INVOICE_TOTALMTRS,0) AS TOTALMTRS,  INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS DELIVERYLEDGERS ON INVOICEMASTER.INVOICE_PACKINGID = DELIVERYLEDGERS.Acc_id  INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.ACC_ID WHERE INVOICEMASTER.INVOICE_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " UNION ALL SELECT OPENINGBILL.BILL_AMTPAIDREC AS RECDAMT, OPENINGBILL.BILL_NO AS BILL, OPENINGBILL.BILL_DATE AS DATE, OPENINGBILL.BILL_INITIALS AS BILLNO, OPENINGBILL.BILL_CMPID, OPENINGBILL.BILL_LOCATIONID, OPENINGBILL.BILL_YEARID, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') AS AGENTNAME, OPENINGBILL.BILL_AMT AS SALEAMT, OPENINGBILL.BILL_AMT AS TAXABLEAMT, 0 AS TOTALCHGSAMT, 0 AS TOTALCHARGES, 0 AS ROUNDOFF, OPENINGBILL.BILL_AMT AS GTOTAL, 'OPENING' AS TYPE, ISNULL(REGLEDGERS.Acc_cmpname,'') AS DEBITLEDGER, 0 AS CGSTPER, 0 AS CGSTAMT, 0 AS SGSTPER, 0 AS SGSTAMT, 0 AS IGSTPER, 0 AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, '' AS DELIVERYAT, ISNULL(BILL_PRINTINITIALS,'') AS INVPRINTINITIALS, ISNULL(BILL_PCS,0) AS TOTALPCS, ISNULL(BILL_MTRS,0) AS TOTALMTRS,  ISNULL(OPENINGBILL.BILL_TOTALAMT,0) AS GROSSAMT FROM  OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.ACC_ID WHERE OPENINGBILL.BILL_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND OPENINGBILL.BILL_YEARID = " & YearId & ") AS T", "")
            If DT.Rows.Count > 0 Then

                For Each dr As DataRow In DT.Rows

                    BILLNO = DT.Rows(0).Item("BILL")
                    TYPE = DT.Rows(0).Item("TYPE")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")

                    TXTINVPRINTINITIALS.Text = DT.Rows(0).Item("INVPRINTINITIALS")
                    TXTTOTALPCS.Text = Val(DT.Rows(0).Item("TOTALPCS"))
                    TXTTOTALMTRS.Text = Val(DT.Rows(0).Item("TOTALMTRS"))
                    TXTACTUALINVAMT.Text = Val(DT.Rows(0).Item("GROSSAMT"))


                    'GET TOP HSN FROM INVOICEMASTER_DESC
                    If TYPE = "INVOICE" Then
                        Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNITEMDESC, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE ", "", " INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ", " AND INVOICEMASTER.INVOICE_INITIALS = '" & TXTBILLNO.Text.Trim & "' AND INVOICEMASTER_DESC.INVOICE_YEARID = " & YearId)
                        If DTHSN.Rows.Count > 0 Then
                            CMBSACDESC.Text = DTHSN.Rows(0).Item("HSNITEMDESC")
                            TXTSACCODE.Text = DTHSN.Rows(0).Item("HSNCODE")
                            GETHSNCODE()
                        End If
                    End If

                    CMBNAME.Text = DT.Rows(0).Item("NAME")
                    If DT.Rows(0).Item("AGENTNAME") <> "" Then CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    CMBDEBITLEDGER.Text = DT.Rows(0).Item("DEBITLEDGER")
                    CMBPACKING.Text = DT.Rows(0).Item("DELIVERYAT")

                    TXTTOTALSALEAMT.Text = DT.Rows(0).Item("SALEAMT")
                    TXTTOTALOTHERCHGSAMT.Text = DT.Rows(0).Item("TOTALCHGSAMT")
                    TXTCHARGES.Text = DT.Rows(0).Item("TOTALCHARGES")
                    TXTCGSTPER.Text = DT.Rows(0).Item("CGSTPER")
                    TXTCGSTAMT.Text = DT.Rows(0).Item("CGSTAMT")
                    TXTSGSTPER.Text = DT.Rows(0).Item("SGSTPER")
                    TXTSGSTAMT.Text = DT.Rows(0).Item("SGSTAMT")
                    TXTIGSTPER.Text = DT.Rows(0).Item("IGSTPER")
                    TXTIGSTAMT.Text = DT.Rows(0).Item("IGSTAMT")
                    txtroundoff.Text = DT.Rows(0).Item("ROUNDOFF")
                    txtgrandtotal.Text = DT.Rows(0).Item("GTOTAL")
                    If txtremarks.Text = "" Then txtremarks.Text = DT.Rows(0).Item("BILLNO")

                Next

                CMBNAME.Enabled = False

            End If


            'CHARGES GRID
            'Dim OBJCMN As New ClsCommon
            If TYPE = "INVOICE" And ClientName <> "SOFTAS" And ClientName <> "MOHATUL" Then
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER_CHGS.INVOICE_GRIDSRNO,0) AS GRIDSRNO, ISNULL(LEDGERS.Acc_CMPname, '') AS CHARGES, ISNULL(INVOICEMASTER_CHGS.INVOICE_PER, 0) AS PER, ISNULL(INVOICEMASTER_CHGS.INVOICE_AMT, 0) AS AMT, ISNULL(TAXMASTER.TAX_ID, 0) AS TAXID ", "", " LEDGERS RIGHT OUTER JOIN INVOICEMASTER_CHGS LEFT OUTER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_yearid = TAXMASTER.tax_yearid AND INVOICEMASTER_CHGS.INVOICE_locationid = TAXMASTER.tax_locationid AND INVOICEMASTER_CHGS.INVOICE_cmpid = TAXMASTER.tax_cmpid AND INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id ON LEDGERS.Acc_yearid = INVOICEMASTER_CHGS.INVOICE_yearid AND LEDGERS.Acc_locationid = INVOICEMASTER_CHGS.INVOICE_locationid AND LEDGERS.Acc_cmpid = INVOICEMASTER_CHGS.INVOICE_cmpid AND LEDGERS.Acc_id = INVOICEMASTER_CHGS.INVOICE_CHARGESID RIGHT OUTER JOIN REGISTERMASTER INNER JOIN INVOICEMASTER ON REGISTERMASTER.register_id = INVOICEMASTER.INVOICE_REGISTERID AND REGISTERMASTER.register_cmpid = INVOICEMASTER.INVOICE_CMPID AND REGISTERMASTER.register_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND REGISTERMASTER.register_yearid = INVOICEMASTER.INVOICE_YEARID ON INVOICEMASTER_CHGS.INVOICE_no = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_CHGS.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_CHGS.INVOICE_cmpid = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_CHGS.INVOICE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_CHGS.INVOICE_yearid = INVOICEMASTER.INVOICE_YEARID", " AND INVOICEMASTER.INVOICE_INITIALS = '" & TXTBILLNO.Text.Trim & "'  AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        If DTR("CHARGES") <> "" Then GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                    Next
                End If
            End If

            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTTOTALSALEAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTALSALEAMT.Validated
        TOTAL()
    End Sub

    Sub PRINTREPORT(ByVal BILLNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Credit Note?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJCN As New CrDrNoteDesign
                OBJCN.BILLNO = BILLNO
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.MdiParent = MDIMain
                OBJCN.PARTYNAME = CMBNAME.Text.Trim
                OBJCN.AGENTNAME = CMBAGENT.Text.Trim
                OBJCN.FRMSTRING = "CREDIT"
                OBJCN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = CNREGINITIAL & "-" & TEMPCNNO
            OBJRECPAY.SALEBILLINITIALS = CNREGINITIAL & "-" & TEMPCNNO
            OBJRECPAY.Show()

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

            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Sale Return Made , Delete Sale Return First")
                    Exit Sub
                End If

                If Convert.ToDateTime(CNDATE.Text).Date < CNBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Credit Note Permanently?", MsgBoxStyle.YesNo, "TEXPRO")
                If tempmsg = vbYes Then

                    Dim OBJCN As New ClsCreditNote
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TYPE)
                    ALPARAVAL.Add(TEMPCNNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)

                    OBJCN.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJCN.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    edit = False
                    CLEAR()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
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
                TOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Private Sub TXTCHARGES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHARGES.Validating
        TOTAL()
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

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress, TXTCHGSPER.KeyPress, txtroundoff.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, sender, Me)
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
                    TOTAL()
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
            TOTAL()

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

    Private Sub CREDITNOTE_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SVS" Then Me.Close()
            TXTCNNO.TabStop = ALLOWMANUALINVNO

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

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objCNdtls As New CreditNoteDetails
            objCNdtls.MdiParent = MDIMain
            objCNdtls.Show()
            objCNdtls.BringToFront()
            'Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPCNNO = Val(TXTCNNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_CN()
            Dim MAXNO As Integer = TXTCNNO.Text.Trim
            CLEAR()
            If Val(TXTCNNO.Text) - 1 >= TEMPCNNO Then
                edit = True
                CREDITNOTE_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            'If txtgrandtotal.Text > 0 And TEMPCNNO < MAXNO Then
            '    TXTCNNO.Text = TEMPCNNO
            '    ' GoTo LINE1
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
LINE1:
            TEMPCNNO = Val(TXTCNNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPCNNO > 0 Then
                edit = True
                CREDITNOTE_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

            'If txtgrandtotal.Text > 0 And TEMPCNNO > 1 Then
            '    TXTCNNO.Text = TEMPCNNO
            '    ' GoTo LINE1
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPCNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCHGSPER.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSPER.Text.Trim) <> 0 Then
                TXTCHGSAMT.Text = ((Val(TXTTOTALSALEAMT.Text.Trim) * Val(TXTCHGSPER.Text.Trim)) / 100)
            End If
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

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Enter
        Try
            If CMBSACDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBSACDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try


            If CMBSACDESC.Text.Trim <> "" And Convert.ToDateTime(CNDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND HSNMASTER.HSN_ITEMDESC = '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If DT.Rows.Count > 0 Then

                    TXTSACCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()

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
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Validated
        Try
            GETHSNCODE()
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
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTTOTALMTRS.KeyPress, TXTDISCPER.KeyPress, TXTTOTALSALEAMT.KeyPress, TXTADJAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated, txtroundoff.Validated
        TOTAL()
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
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCNNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCNNO.Validating
        Try
            If ALLOWMANUALCNDN = True Then
                If (Val(TXTCNNO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And edit = False) Or (edit = True And TEMPCNNO <> Val(TXTCNNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(CREDITNOTEMASTER.CN_no, 0) AS CNNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CREDITNOTEMASTER ON REGISTERMASTER.register_id = CREDITNOTEMASTER.CN_REGISTERID ", "  AND CREDITNOTEMASTER.CN_NO=" & TXTCNNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CREDITNOTEMASTER.CN_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("CreditNote No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
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

    Private Sub TXTTOTALPCS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTOTALPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If edit = True Then SENDWHATSAPP(TEMPCNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(CNNO As Integer)
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
            OBJCN.FRMSTRING = "CREDIT"
            OBJCN.DIRECTMAIL = False
            OBJCN.DIRECTWHATSAPP = True
            OBJCN.REGNAME = cmbregister.Text.Trim
            OBJCN.PRINTSETTING = PRINTDIALOG
            OBJCN.BILLNO = Val(CNNO)
            OBJCN.NOOFCOPIES = 1
            OBJCN.Show()
            OBJCN.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\CN_" & Val(CNNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("CN_" & Val(CNNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBREMOVEADJ_Click(sender As Object, e As EventArgs) Handles RBREMOVEADJ.Click
        Try
            If TXTBILLNO.Text.Trim <> "" Then
                If MsgBox("Wish to Remove the Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                TXTBILLNO.Clear()
                MsgBox("After saving this entry please Reconcile Purchase/Sale Data to get proper Results", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDISCPER_Validated(sender As Object, e As EventArgs) Handles TXTDISCPER.Validated
        Try
            If Val(TXTDISCPER.Text.Trim) > 0 Then
                'IF PERCENT IS > 0 THEN GETAUTO CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & CMBDEBITLEDGER.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Or DT.Rows(0).Item("CALC") = "NETT" Then
                    TXTTOTALSALEAMT.Text = Format((Val(TXTDISCPER.Text.Trim) * Val(TXTACTUALINVAMT.Text.Trim)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "MTRS" Then
                    TXTTOTALSALEAMT.Text = Format((Val(TXTDISCPER.Text.Trim) * Val(TXTTOTALMTRS.Text.Trim)), "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTTOTALSALEAMT.Text = Format((Val(TXTDISCPER.Text.Trim) * Val(TXTTOTALPCS.Text.Trim)), "0.00")
                End If
                TOTAL()
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

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub
            If CHKNOGSTR1.CheckState = CheckState.Checked Then
                MsgBox("E-Invoice only Valid for Sales Credit Note", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYCITYNAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or DT.Rows(0).Item("CITYNAME") = "" Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYCITYNAME = DT.Rows(0).Item("CITYNAME")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'DELIVERYAT IS NOT PRESENT IN DEBIT NOTE
            ''FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            'If CMBPACKING.Text.Trim <> "" AndAlso CMBNAME.Text.Trim <> CMBPACKING.Text.Trim Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_RANGE,'') AS KOTHARIPLACE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBPACKING.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
            '        MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
            '        Exit Sub
            '    Else
            '        SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
            '        SHIPTOPINCODE = DT.Rows(0).Item("PINCODE")
            '        PARTYKMS = Val(DT.Rows(0).Item("KMS"))
            '        SHIPTOADD1 = DT.Rows(0).Item("ADD1")
            '        SHIPTOADD2 = DT.Rows(0).Item("ADD2")
            '        SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
            '        SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
            '        KOTHARIPLACE = DT.Rows(0).Item("KOTHARIPLACE")
            '    End If
            'End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            'If cmbtrans.Text.Trim <> "" Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
            '    'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            '    'If TRANSGSTIN = "" Then
            '    '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
            '    '    Exit Sub
            '    'End If
            'End If



            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","
                j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("CN_PRINTINITIALS AS PRINTINITIALS", "", "CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = REGISTER_ID", " AND CN_NO = " & Val(TXTCNNO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CN_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""CRN"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & CNDATE.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & PARTYCITYNAME & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & PARTYCITYNAME & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"


                j = j & """ItemList"":[{"
                j = j & """SlNo"":""1""" & ","
                j = j & """PrdDesc"":""FABRIC""" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_TYPE, '') AS HSNTYPE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(CNDATE.Text).Date, "MM/dd/yyyy") & "' AND HSNMASTER.HSN_ITEMDESC= '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If DTHSN.Rows(0).Item("HSNTYPE") = "Goods" Then j = j & """IsServc"":""" & "N" & """" & "," Else j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & Val(DTHSN.Rows(0).Item("HSNCODE")) & """" & ","
                j = j & """Barcde"":""REC9999"","
                j = j & """Qty"":" & "0" & "" & ","
                j = j & """FreeQty"":" & "0" & "" & ","
                j = j & """Unit"":""" & "MTR" & """" & ","
                j = j & """UnitPrice"":" & Val(txtsubtotal.Text.Trim) & "" & ","
                j = j & """TotAmt"":" & Format(Val(txtsubtotal.Text.Trim), "0.00") & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """PreTaxVal"":" & "1" & "" & ","
                j = j & """AssAmt"":" & Val(txtsubtotal.Text.Trim) & "" & ","
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","
                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """CesRt"":" & "0" & "" & ","
                j = j & """CesAmt"":" & "0" & "" & ","
                j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """StateCesRt"":" & "0" & "" & ","
                j = j & """StateCesAmt"":" & "0" & "" & ","
                j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """OthChrg"":" & "0" & "" & ","
                j = j & """TotItemVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """OrdLineRef"":"" "","
                j = j & """OrgCntry"":""IN"","
                j = j & """PrdSlNo"":""123"","

                j = j & """BchDtls"": {"
                j = j & """Nm"":""123"","
                j = j & """Expdt"":""" & CNDATE.Text & """" & ","
                j = j & """wrDt"":""" & CNDATE.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""FABRIC"","
                j = j & """Val"":""" & Val(txtgrandtotal.Text.Trim) & """" & "}]"
                j = j & " }],"



                j = j & """ValDtls"": {"
                j = j & """AssVal"":" & Val(txtsubtotal.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TXTTCSAMT.Text.Trim) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & "0" & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & CNDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & CNDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & CNDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & CNDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & CNDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""CREDITNOTE"","
                j = j & """Info"":""CREDITNOTE""}],"

                j = j & """TransDocNo"":""   """ & ","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & CNDATE.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"




                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                'If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10


                'If TXTVEHICLENO.Text.Trim <> "" Then
                '    j = j & ","
                '    j = j & """EwbDtls"": {"
                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                '    j = j & """Distance"":" & PARTYKMS & "" & ","
                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                '    j = j & """VehType"":""" & "R" & """" & ","
                '    j = j & """TransMode"":""1""" & "}"
                'End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()



            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO


            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER SET CN_IRNNO = '" & TXTIRNNO.Text.Trim & "', CN_ACKNO = '" & TXTACKNO.Text.Trim & "', CN_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "'  FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = REGISTER_ID WHERE CN_NO = " & Val(TXTCNNO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CN_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)
                bitmap1.Save(Application.StartupPath & "\CN" & Val(TXTCNNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\CN" & Val(TXTCNNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsCreditNote
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTCNNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)
                bitmap1.Save(Application.StartupPath & "\CN" & Val(TXTCNNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\CN" & Val(TXTCNNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsCreditNote
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TEMPCNNO)
                    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTCNNO.Text.Trim) & ",'CREDITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Sub CMBPAYTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPAYTYPE.SelectedIndexChanged
        Try
            LBLBILLTOTAL.Text = ""
            CMBBILLNO.Text = ""
            If CMBPAYTYPE.Text = "Against Bill" Then
                CMBBILLNO.Enabled = True
            Else
                CMBBILLNO.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAYTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPAYTYPE.Validated
        Try
            If CMBPAYTYPE.Text = "Against Bill" Then CMBBILLNO.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTADJAMT_Validating(sender As Object, e As CancelEventArgs) Handles TXTADJAMT.Validating
        Try
            If TXTADJSRNO.Text.Trim.Length = 0 Then TXTADJSRNO_GotFocus(sender, e)

            If TXTADJSRNO.Text.Trim.Length > 0 And Val(TXTADJAMT.Text) > 0 Then
                If CMBPAYTYPE.Text = "Against Bill" And CMBBILLNO.Text.Trim = "" Then
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "PROTRADE")
                    CMBPAYTYPE.Focus()
                    Exit Sub
                End If

                If CMBBILLNO.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                        If (ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And GRIDADJDOUBLECLICK = False) Or (GRIDADJDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And ROW.Index <> TEMPADJROW) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "PROTRADE")
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
End Class