

Imports BL
Imports System.IO
Imports System.ComponentModel
Imports System.Net
Imports RestSharp
Imports TaxProEInvoice.API
Imports Newtonsoft.Json

Public Class SaleReturn

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDADJDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK, GRIDCHGSDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPSALRETNO As Integer     'used for poation no while editing
    Dim TEMPROW, TEMPCHGSROW, TEMPUPLOADROW, TEMPADJROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTFROM.Clear()
            TXTTO.Clear()

            If ALLOWMANUALCNDN = True Then
                TXTSALRETNO.ReadOnly = False
                TXTSALRETNO.BackColor = Color.LemonChiffon
            Else
                TXTSALRETNO.ReadOnly = True
                TXTSALRETNO.BackColor = Color.Linen
            End If
            'TXTSALRETNO.Clear()
            SALRETDATE.Text = Now.Date
            tstxtbillno.Clear()
            TXTCHALLANNO.Clear()
            CHALLANDATE.Value = Now.Date
            TXTACTUALINVNO.Clear()
            ACTUALINVDATE.Text = Now.Date
            TXTINVINITIALS.Clear()
            TXTINVNO.Clear()
            TXTINVREGNAME.Clear()
            INVDATE.Value = Now.Date
            TXTINVTYPE.Clear()
            If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
            CMBNAME.Enabled = True
            CMBNAME.Text = ""
            CMBPACKING.Text = ""

            CMBDEBITLEDGER.Text = ""

            TXTSTATECODE.Clear()
            TXTGSTIN.Clear()

            TXTPARTYREFNO.Clear()
            TXTSRCHNO.Clear()

            txtsrno.Clear()

            If ClientName = "SOFTAS" Then
                CMBPIECETYPE.Text = "FRESH"
            Else
                CMBPIECETYPE.Text = ""
            End If
            cmbitemname.Text = ""
            CMBQUALITY.Text = ""
            CMBDESIGN.Text = ""
            cmbcolor.Text = ""
            TXTBALENO.Clear()
            TXTCUT.Clear()
            TXTWT.Clear()
            txtqty.Text = 1
            If ClientName = "SOFTAS" Then
                cmbqtyunit.Text = "Pcs"
            Else
                cmbqtyunit.Text = ""
            End If


            TXTMTRS.Clear()
            CMBRACK.Text = ""
            CMBSHELF.Text = ""
            TXTRATE.Clear()
            CMBPER.Text = "Mtrs"
            TXTAMT.Clear()
            GRIDSALRET.RowCount = 0
            CMBAGENT.Text = ""
            txtadd.Clear()

            cmbtrans.Text = ""
            txtlrno.Clear()
            lrdate.Value = Now.Date
            txtremarks.Clear()
            TXTBILLREMARKS.Clear()

            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            gridupload.RowCount = 0
            txtimgpath.Clear()
            TXTNEWIMGPATH.Clear()
            TXTFILENAME.Clear()
            PBSoftCopy.ImageLocation = ""


            lbllocked.Visible = False
            PBlock.Visible = False

            GRIDDOUBLECLICK = False
            GRIDUPLOADDOUBLECLICK = False

            getmaxno()

            LBLTOTALWT.Text = 0
            lbltotalqty.Text = 0
            LBLTOTALMTRS.Text = 0
            LBLTOTALAMT.Text = 0

            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()

            CHKTCS.Checked = False
            TXTTOTALWITHGST.Clear()
            TXTTCSPER.Clear()
            TXTTCSAMT.Clear()

            txtbillamt.Clear()
            TXTCHARGES.Clear()
            TXTSUBTOTAL.Clear()
            txtroundoff.Clear()
            TXTGRANDTOTAL.Clear()
            CHKMANUAL.CheckState = CheckState.Unchecked

            If GRIDSALRET.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If

            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If

            TXTCHGSSRNO.Text = 1
            CMBCHARGES.Text = ""
            TXTCHGSPER.Clear()
            TXTCHGSAMT.Clear()
            GRIDCHGS.RowCount = 0

            TXTEWAYBILLNO.Clear()



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
            TXTACKNO.Clear()
            PBQRCODE.Image = Nothing


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            LBLTOTALAMT.Text = 0.0

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            txtroundoff.Text = 0
            TXTGRANDTOTAL.Text = 0

            TXTINVTOTAL.Text = 0.0
            TXTADJTOTAL.Text = 0.0
            TXTCHQBAL.Text = 0.0

            TXTTCSPER.Text = 0
            TXTTCSAMT.Text = 0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))


            For Each ROW As DataGridViewRow In GRIDSALRET.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If Val(ROW.Cells(GRATE.Index).EditedFormattedValue) > 0 Then
                        If ROW.Cells(GPER.Index).Value = "Mtrs" Then
                            ROW.Cells(GAMT.Index).Value = Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue * ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                        Else
                            ROW.Cells(GAMT.Index).Value = Format(Val(ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                        End If
                    End If
                    If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    If Val(ROW.Cells(GAMT.Index).Value) <> 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(ROW.Cells(GAMT.Index).EditedFormattedValue), "0.00")

                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(ROW.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                End If
            Next


            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows

                    If SALEAUTODISCOUNT = True Then
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
                        End If
                    End If

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

            TXTGRANDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0")
            If Val(TXTGRANDTOTAL.Text) > 0 Then txtinwords.Text = CurrencyToWord(TXTGRANDTOTAL.Text)

            txtroundoff.Text = Format(Val(TXTGRANDTOTAL.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")


            For Each row As DataGridViewRow In GRIDPAYMENT.Rows
                TXTADJTOTAL.Text = Format(Val(TXTADJTOTAL.Text) + row.Cells(GADJAMT.Index).Value, "0.00")
            Next

            For Each row As DataGridViewRow In GRIDBILL.Rows
                If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(GRIDBILL.Columns("INVBALAMT").Index).Value, "0.00")
            Next

            If Val(TXTGRANDTOTAL.Text) > 0 Then TXTCHQBAL.Text = Format(Val(TXTGRANDTOTAL.Text) - Val(TXTADJTOTAL.Text), "0.00")

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
            If EDIT = False Then
                If GRIDADJDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(TXTGRANDTOTAL.Text) Then
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
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If


                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If CMBPAYTYPE.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT", "", " (SELECT SUM(SALERETURN_BILLDESC.SALRET_amt)  AS RECAMT, SALRET_BILLINITIALS AS BILLINITIALS, SALRET_NO as RECNO, SALRET_cmpid AS CMPID, 0 AS LOCATIONID, SALRET_yearid AS YEARID FROM SALERETURN_BILLDESC WHERE SALRET_paytype = 'Against Bill' GROUP BY SALRET_BILLINITIALS, SALRET_no, SALRET_CMPID , SALRET_YEARID) AS T ", " AND T.RECNO =  " & TXTSALRETNO.Text.Trim & " AND T.BILLINITIALS ='" & CMBBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
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

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        CMBPAYTYPE.Text = "Against Bill"
                        CMBBILLNO.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        CMBBILLNO.Enabled = True
                        TXTNARR.Clear()
                        LBLBILLTOTAL.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBALAMT").Index).Value

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

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        TOTAL()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            EDIT = False
            cmbGodown.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(SALRET_no),0) + 1 ", " SaleReturn ", " AND SALRET_cmpid=" & CmpId & " and SALRET_locationid=" & Locationid & " and SALRET_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTSALRETNO.Text = DTTABLE.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        Try
            enterkeypress(e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try

            Dim bln As Boolean = True

            If ClientName = "SVS" And TXTCHALLANNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTCHALLANNO, " Please Fill Challan No. ")
                bln = False
            End If


            'IF BILL NOT ADJUSTED AND GRID IS BLANK THEN MAKE ON ACCOUNT ENTRY
            If TXTINVNO.Text.Trim = "" And GRIDPAYMENT.RowCount = 0 Then
                GRIDPAYMENT.Rows.Add(1, "On Account", "", "", Val(TXTGRANDTOTAL.Text.Trim), 0, 0, 0, Val(TXTGRANDTOTAL.Text.Trim))
                TOTAL()
            End If

            If TXTINVNO.Text.Trim <> "" And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(TXTINVNO, "Amount cannot be Adjusted against Multiple Bills")
                bln = False
            End If


            If Val(TXTGRANDTOTAL.Text.Trim) <> Val(TXTADJTOTAL.Text.Trim) And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(TXTGRANDTOTAL, "Total does not match Adjusted Amt")
                bln = False
            End If


            'GET DEFAULT SALEREGISTER IF INVOICENO IS BLANK
            If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" And Val(TXTINVNO.Text.Trim) = 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" register_name AS REGNAME ", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' AND REGISTER_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTINVREGNAME.Text = DT.Rows(0).Item("REGNAME")
                End If
            End If


            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Select Name ")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim.Length = 0 Then
                EP.SetError(CMBDEBITLEDGER, " Please Select Debit Ledger Name ")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim = CMBNAME.Text.Trim Then
                EP.SetError(CMBDEBITLEDGER, "Credit and Debit Ledger cannot be kept same")
                bln = False
            End If


            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used, Item Locked")
            '    bln = False
            'End If

            If GRIDSALRET.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            'IF INVOICENO IS NOT BLANK THEN CHECK THAT FIGURES CANNOT BE GREATER THEN BALANCEAMT
            If Val(TXTINVNO.Text.Trim) > 0 And ClientName <> "CC" Then
                Dim BALANCE As Double = 0
                Dim DT As New DataTable
                Dim OBJCMN As New ClsCommon
                If TXTINVTYPE.Text.Trim = "INVOICE" Then
                    DT = OBJCMN.search("INVOICE_BALANCE AS INVBAL", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_NO = " & Val(TXTINVNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
                Else
                    DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID INNER JOIN LEDGERS ON ACC_ID = BILL_LEDGERID", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_NO = " & Val(TXTINVNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
                End If
                BALANCE = Val(DT.Rows(0).Item("INVBAL"))
                If EDIT = True Then
                    Dim DT1 As DataTable = OBJCMN.search("SALRET_GRANDTOTAL AS RETTOTAL", "", "SALERETURN", " AND SALRET_NO = " & Val(TEMPSALRETNO) & " AND SALRET_YEARID = " & YearId)
                    BALANCE += Val(DT1.Rows(0).Item("RETTOTAL"))
                End If
                If Val(TXTGRANDTOTAL.Text.Trim) > Val(BALANCE) Then
                    EP.SetError(TXTGRANDTOTAL, "Amount Greater then Balance Amt, only " & Val(BALANCE) & " can be Used")
                    bln = False
                End If

            End If

            ''''by guklit sir 

            'If Val(TXTCHALLANNO.Text.Trim) > 0 Then
            '    If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
            '        'for search
            '        Dim objclscommon As New ClsCommon()
            '        Dim DT As DataTable = objclscommon.search(" SALRET_challanno, LEDGERS.ACC_cmpname", "", " SALERETURN inner join LEDGERS on LEDGERS.ACC_id = SALRET_ledgerid ", " and SALRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND SALRET_YEARID =" & YearId)
            '        If DT.Rows.Count > 0 Then
            '            EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
            '            bln = False
            '        End If
            '    End If
            'End If

            'DONE BY GULKIT
            'If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/02/2018" And txtgrandtotal.Text > 50000 Then
            '    If TXTEWAYBILLNO.Text.Trim.Length = 0 Then
            '        If MsgBox("E-Way No. Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '            EP.SetError(TXTEWAYBILLNO, " Please Enter E-Way No..... ")
            '            bln = False
            '        End If
            '    End If
            'End If


            If SALRETDATE.Text = "__/__/____" Then
                EP.SetError(SALRETDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(SALRETDATE.Text) Then
                    EP.SetError(SALRETDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(SALRETDATE.Text).Date < CNBLOCKDATE.Date Then
                    EP.SetError(SALRETDATE, "Date is Blocked, Please make entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            If ACTUALINVDATE.Text = "__/__/____" Then
                EP.SetError(ACTUALINVDATE, " Please Enter Proper Date")
                bln = False
                Return bln
                Exit Function
            End If

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            If TXTSRCHNO.Text.Trim = "" Then
                If Not CHECKBARCODE() Then
                    bln = False
                    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
                End If
            End If


            If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                If TXTSTATECODE.Text.Trim.Length = 0 Then
                    EP.SetError(TXTSTATECODE, "Please enter the state code")
                    bln = False
                End If

                If TXTGSTIN.Text.Trim.Length = 0 Then
                    If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        EP.SetError(CMBNAME, "Enter GSTIN in Party Master")
                        bln = False
                    End If
                End If

                If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(TXTCGSTAMT.Text) > 0 Or Val(TXTSGSTAMT.Text.Trim) > 0) Then
                    EP.SetError(CMBNAME, "Invaid Entry Done in CGST/SGST")
                    bln = False
                End If

                If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(TXTIGSTAMT.Text) > 0 Then
                    EP.SetError(CMBNAME, "Invaid Entry Done in IGST")
                    bln = False
                End If
            End If

            For Each row As DataGridViewRow In GRIDSALRET.Rows
                If ClientName <> "MOMAI" And ClientName <> "AXIS" Then
                    If row.Cells(GMTRS.Index).Value = 0 Then
                        EP.SetError(CMBNAME, "Mtrs Cannot be 0")
                        bln = False
                    End If
                End If
                If Val(row.Cells(GAMT.Index).Value) = 0 Then
                    EP.SetError(CMBNAME, "Amt Cannot be 0")
                    bln = False
                End If

                If ALLOWMANUALCNDN = True Then
                    If TXTSALRETNO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search(" ISNULL(SALERETURN.SALRET_no, 0) AS SALRETNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN SALERETURN ON REGISTERMASTER.register_id = SALERETURN.SALRET_INVOICEREGID AND REGISTERMASTER.register_cmpid = SALERETURN.SALRET_CMPID AND REGISTERMASTER.register_yearid = SALERETURN.SALRET_YEARID AND REGISTERMASTER.register_locationid = SALERETURN.SALRET_LOCATIONID", "  AND SALERETURN.SALRET_NO=" & TXTSALRETNO.Text.Trim & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND SALERETURN.SALRET_cmpid = " & CmpId & " AND SALERETURN.SALRET_yearid = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            EP.SetError(TXTSALRETNO, "Bill No Already Exist")
                            bln = False
                        End If
                    End If
                End If

            Next

            For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" And ROW.Cells(gbillno.Index).Value = "" Then
                    EP.SetError(CMBNAME, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    bln = False
                End If
            Next

            Return bln

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

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



            Dim alParaval As New ArrayList

            If ALLOWMANUALCNDN = True Then
                alParaval.Add(Val(TXTSALRETNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBDEBITLEDGER.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)

            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(CHALLANDATE.Value.Date)

            alParaval.Add(TXTACTUALINVNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTINVNO.Text.Trim)
            alParaval.Add(TXTINVREGNAME.Text.Trim)
            alParaval.Add(INVDATE.Value.Date)
            alParaval.Add(TXTINVTYPE.Text.Trim)
            alParaval.Add(TXTINVINITIALS.Text.Trim)

            alParaval.Add(TXTPARTYREFNO.Text.Trim)
            alParaval.Add(TXTSRCHNO.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)

            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALAMT.Text))

            If CHKMANUAL.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))

            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(TXTGRANDTOTAL.Text.Trim))

            alParaval.Add(txtinwords.Text)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBILLREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""

            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BALENO As String = ""
            Dim CUT As String = ""
            Dim WT As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim PER As String = ""
            Dim AMOUNT As String = ""         'value of AMT

            Dim RACK As String = ""
            Dim SHELF As String = ""
            Dim RECDMTRS As String = ""
            Dim DIFF As String = ""
            Dim BARCODE As String = ""
            Dim GDNBARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""

            'Dim FROMTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSALRET.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString

                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        CUT = row.Cells(gcut.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        RATE = row.Cells(GRATE.Index).Value
                        PER = row.Cells(GPER.Index).Value.ToString
                        AMOUNT = row.Cells(GAMT.Index).Value

                        RACK = row.Cells(GRACK.Index).Value.ToString
                        SHELF = row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        GDNBARCODE = row.Cells(GGDNBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTPCS = row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value
                        FROMNO = row.Cells(GFROMNO.Index).Value
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString

                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(gcut.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        PER = PER & "|" & row.Cells(GPER.Index).Value
                        AMOUNT = AMOUNT & "|" & row.Cells(GAMT.Index).Value

                        RACK = RACK & "|" & row.Cells(GRACK.Index).Value.ToString
                        SHELF = SHELF & "|" & row.Cells(GSHELF.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        GDNBARCODE = GDNBARCODE & "|" & row.Cells(GGDNBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & row.Cells(GOUTPCS.Index).Value
                        OUTMTRS = OUTMTRS & "|" & row.Cells(GOUTMTRS.Index).Value
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)

            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BALENO)
            alParaval.Add(CUT)
            alParaval.Add(WT)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)

            alParaval.Add(AMOUNT)
            alParaval.Add(RACK)
            alParaval.Add(SHELF)

            alParaval.Add(BARCODE)
            alParaval.Add(GDNBARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)


            'SAVING CHGS GRID
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


            Dim OBJSALRET As New ClsSaleReturn()
            OBJSALRET.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSALRET.SAVE()
                MsgBox("Details Added")
                TXTSALRETNO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSALRETNO)
                IntResult = OBJSALRET.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPSALRETNO)
            End If

            PRINTBARCODE()


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

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)

            cmbGodown.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If TXTSRCHNO.Text.Trim <> "" Then Exit Sub
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                GRIDSALRET.RowCount = 0
                Dim OBJSALRET As New ClsSaleReturn
                Dim DTTABLE As DataTable = OBJSALRET.SELECTSALRET(Val(TXTSALRETNO.Text.Trim), CmpId, Locationid, YearId)
                For Each dr As DataRow In DTTABLE.Rows
                    GRIDSALRET.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER").ToString, Format(Val(dr("AMT")), "0.00"), dr("RACK").ToString, dr("SHELF").ToString, dr("BARCODE"), dr("GDNBARCODE"), dr("GRIDDONE").ToString, dr("OUTPCS"), dr("OUTMTRS"), dr("FROMNO"), dr("FROMSRNO"))
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

                For Each ROW As DataGridViewRow In GRIDSALRET.Rows
                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If
                    Dim GRIDDESC As String = ""
                    If ClientName = "KCRAYON" Then GRIDDESC = ROW.Cells(GBALENO.Index).Value

                    BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(gitemname.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(gcolor.Index).Value, ROW.Cells(gqtyunit.Index).Value, "", ROW.Cells(GBALENO.Index).Value, GRIDDESC, Val(ROW.Cells(GMTRS.Index).Value), Val(ROW.Cells(gQty.Index).Value), Val(ROW.Cells(gcut.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If
            '                    Dim dirresults As String = ""

            '                    'Writing in file
            '                    Dim oWrite As System.IO.StreamWriter
            '                    'oWrite = File.CreateText(Application.StartupPath & "\Barcode.txt")
            '                    'oWrite = File.CreateText(Application.StartupPath & "\Barcode.txt")
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
            '                        oWrite.WriteLine("TEXT 498,285,""0"",180,14,14,""")
            '                        oWrite.WriteLine("TEXT 498, 227, ""0"", 180, 22, 22, """ & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BAR 43, 505, 695, 3")
            '                        oWrite.WriteLine("PRINT 1, 1")
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

            '                    ElseIf ClientName = "KCRAYON" Then

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
            '                        oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""""")
            '                        oWrite.WriteLine("TEXT 405,216,""2"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 783,216,""2"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("TEXT 265,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 672,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 631,283,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 603,283,""2"",180,2,2,""" & ROW.Cells(gcolor.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 631,216,""2"",180,2,2,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
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
            '                        oWrite.WriteLine("TEXT 600,249,""ROMAN.TTF"",180,1,14,""""")
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
            '                        oWrite.WriteLine("TEXT 233,242,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(GREMARKS.Index).Value & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
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
            '                        oWrite.WriteLine("A433,313,2,1,2,2,N,""")
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
            '                        oWrite.WriteLine("A432,206,2,1,3,3,N,""" & Val(ROW.Cells(GMTRS.Index).Value) & """")
            '                        oWrite.WriteLine("B583,142,2,1,3,6,89,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("A411,47,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("P1")
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
            '                        oWrite.WriteLine("TEXT 564,234,""0"",180,11,11,""""")
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

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

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

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

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

            '                    ElseIf ClientName = "MIDAS" Then

            '                        'If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

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
            '                        oWrite.WriteLine("1911C1400890141")
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SBA" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911A2401590067" & ROW.Cells(gitemname.Index).Value)
            '                        oWrite.WriteLine("1911A1001460011QUALITY")
            '                        oWrite.WriteLine("1911A1001460109:")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS, TEMPCMPSTAMP As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("1911A1001460119" & TEMPCATEGORY)
            '                        oWrite.WriteLine("1911A1001280119" & TEMPREMARKS)
            '                        oWrite.WriteLine("1911A1001090276" & TEMPWIDTH)

            '                        oWrite.WriteLine("1X1100001630008L375001")
            '                        oWrite.WriteLine("1911A1001090206WIDTH")
            '                        oWrite.WriteLine("1911A1001090267:")

            '                        oWrite.WriteLine("1911A1001090011DESIGN NO")
            '                        oWrite.WriteLine("1911A1001090109:")
            '                        oWrite.WriteLine("1911A1001090119" & ROW.Cells(GDESIGN.Index).Value)
            '                        oWrite.WriteLine("1e6304700360025B" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A0800220128" & ROW.Cells(GBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1000910011MTRS")
            '                        oWrite.WriteLine("1911A1000910109:")
            '                        oWrite.WriteLine("1911A1400880119" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911A1000910206SHADE")
            '                        oWrite.WriteLine("1911A1000910267:")
            '                        oWrite.WriteLine("1911A1000910276" & ROW.Cells(gcolor.Index).Value)
            '                        oWrite.WriteLine("1911A1000080140A PRODUCT OF ")
            '                        oWrite.WriteLine("1X1100000010253L108028")
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
            '                        oWrite.WriteLine("TEXT 187,258,""0"",180,16,16,""""")
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
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
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
            '                            'they dont need party name
            '                            'If DT.Rows.Count > 0 Then CPCODE = CPCODE & UCase(DT.Rows(0).Item("CODE")) & Format(Val(AccFrom.Date.Day), "00") & Format(Val(AccFrom.Date.Month), "00") & AccFrom.Date.Year.ToString.Substring(2, 2)
            '                            If DT.Rows.Count > 0 Then CPCODE = CPCODE & Format(Val(AccFrom.Date.Day), "00") & Format(Val(AccFrom.Date.Month), "00") & AccFrom.Date.Year.ToString.Substring(2, 2)

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
            '                        oWrite.WriteLine("A151,155,2,4,1,1,N,""")   'DESC
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

            '                    ElseIf ClientName = "KDFAB" Then

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
            '                        oWrite.WriteLine("A294,391,2,3,2,2,N,""" & ROW.Cells(GREMARKS.Index).Value & """")
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
            '                        oWrite.WriteLine("1911C1201600138" & TXTBALENO.Text.Trim)

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
            '                        oWrite.WriteLine("q863")
            '                        oWrite.WriteLine("rN")
            '                        oWrite.WriteLine("S5")
            '                        oWrite.WriteLine("D2")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("R152,0")
            '                        oWrite.WriteLine("f100")
            '                        oWrite.WriteLine("N")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCONTAIN As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(CATEGORYMASTER.category_remarks, '') AS WIDTH, ISNULL(ITEMMASTER.item_remarks, '') AS CONTAIN ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCONTAIN = DT.Rows(0).Item("CONTAIN")
            '                        End If

            '                        oWrite.WriteLine("A151,154,0,1,2,2,N,""" & TEMPWIDTH & """")    'GIVE ITEM CATEGORY'S REMARKS
            '                        oWrite.WriteLine("A133,102,0,1,3,3,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")    'MTRS
            '                        oWrite.WriteLine("A459,104,0,1,3,3,N,""" & ROW.Cells(gcolor.Index).Value & """")       'COLOR
            '                        oWrite.WriteLine("A8,6,0,1,3,3,N,""" & ROW.Cells(GQUALITY.Index).Value & """")       'QUALITY
            '                        oWrite.WriteLine("A171,199,0,1,2,2,N,""" & TEMPCONTAIN & """")        'ITEMREMARKS
            '                        oWrite.WriteLine("A231,57,0,1,3,3,N,""" & ROW.Cells(gitemname.Index).Value & """")      'ITEMNAME
            '                        oWrite.WriteLine("A11,200,0,1,2,2,N,""Contain:""")
            '                        oWrite.WriteLine("A318,111,0,1,2,2,N,""Shade :""")
            '                        oWrite.WriteLine("A11,153,0,1,2,2,N,""Width :""")
            '                        oWrite.WriteLine("A11,60,0,1,2,2,N,""Design No :""")
            '                        oWrite.WriteLine("A11,107,0,1,2,2,N,""Mtrs :""")
            '                        oWrite.WriteLine("B8,257,0,1,2,6,87,B,""" & ROW.Cells(GBARCODE.Index).Value & """")       'BARCODE
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

    Private Sub SaleReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
            TabControl1.SelectedIndex = 0
        ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
            TabControl1.SelectedIndex = 1
        ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
            TabControl1.SelectedIndex = 2
        ElseIf e.Alt = True And e.KeyCode = Keys.D4 Then
            TabControl1.SelectedIndex = 3
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDSALRET.Focus()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        End If
    End Sub

    Private Sub SaleReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSALRET As New ClsSaleReturn()
                Dim dttable As DataTable = OBJSALRET.SELECTSALRET(TEMPSALRETNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSALRETNO.Text = TEMPSALRETNO
                        TXTSALRETNO.ReadOnly = True
                        SALRETDATE.Text = Format(Convert.ToDateTime(dr("SALRETDATE")), "dd/MM/yyyy")

                        TXTINVNO.Text = dr("INVNO")
                        TXTINVREGNAME.Text = Convert.ToString(dr("INVREGNAME").ToString)
                        INVDATE.Text = Format(Convert.ToDateTime(dr("INVDATE")).Date, "dd/MM/yyyy")
                        TXTINVTYPE.Text = Convert.ToString(dr("INVTYPE").ToString)
                        TXTINVINITIALS.Text = Convert.ToString(dr("INVINITIALS").ToString)

                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim

                        ACTUALINVDATE.Text = Format(Convert.ToDateTime(dr("ACTUALINVDATE")), "dd/MM/yyyy")
                        TXTACTUALINVNO.Text = dr("ACTUALINVNO")

                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBDEBITLEDGER.Text = dr("DEBITNAME")
                        CMBPACKING.Text = dr("DELIVERYAT")

                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")

                        If TXTINVINITIALS.Text.Trim <> "" Then CMBNAME.Enabled = False

                        TXTPARTYREFNO.Text = dr("PARTYREFNO")
                        TXTSRCHNO.Text = dr("SRCHNO")
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        CMBAGENT.Text = dr("AGENT").ToString
                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        txtinwords.Text = Convert.ToString(dr("INWORDS").ToString)
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        TXTBILLREMARKS.Text = dr("BILLREMARKS")

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

                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))


                        'Item Grid
                        GRIDSALRET.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER").ToString, Format(Val(dr("AMT")), "0.00"), dr("RACK").ToString, dr("SHELF").ToString, dr("BARCODE"), dr("GDNBARCODE"), dr("GRIDDONE").ToString, dr("OUTPCS"), dr("OUTMTRS"), dr("FROMNO"), dr("FROMSRNO"))

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
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
                    Dim OBJCMN As New ClsCommon
                    Dim dttable1 As DataTable = OBJCMN.search(" SALERETURN_CHGS.SALRET_gridsrno AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, SALERETURN_CHGS.SALRET_PER AS PER, SALERETURN_CHGS.SALRET_AMT AS AMT, SALERETURN_CHGS.SALRET_TAXID AS TAXID ", "", " SALERETURN_CHGS INNER JOIN LEDGERS ON SALERETURN_CHGS.SALRET_CHARGESID = LEDGERS.Acc_id ", " AND SALERETURN_CHGS.SALRET_NO = " & TEMPSALRETNO & " AND SALERETURN_CHGS.SALRET_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If



                    dttable1 = OBJCMN.search(" SALERETURN_BILLDESC.SALRET_GRIDSRNO AS GRIDSRNO, SALERETURN_BILLDESC.SALRET_PAYTYPE AS PAYTYPE, SALERETURN_BILLDESC.SALRET_BILLINITIALS AS BILLINITIALS, SALERETURN_BILLDESC.SALRET_GRIDREMARKS AS NARR, SALERETURN_BILLDESC.SALRET_AMT AS AMT, SALERETURN_BILLDESC.SALRET_AMTPAID AS AMTPAID, SALERETURN_BILLDESC.SALRET_EXTRAAMT AS EXTRAAMT, SALERETURN_BILLDESC.SALRET_RETURN AS [RETURN], SALERETURN_BILLDESC.SALRET_BALANCE AS BALANCE ", "", " SALERETURN_BILLDESC ", " AND SALERETURN_BILLDESC.SALRET_NO = " & TEMPSALRETNO & " AND SALERETURN_BILLDESC.SALRET_YEARID = " & YearId)
                    For Each DR As DataRow In dttable1.Rows
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
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            If GRIDSALRET.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(0).Value) + 1
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If cmbtrans.Text.Trim = "" Then filltransname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            fillunit(cmbqtyunit)
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='Indirect Income' OR GROUPMASTER.GROUP_SECONDARY ='Sales A/C' OR GROUPMASTER.GROUP_SECONDARY ='Indirect Expenses' or GROUPMASTER.GROUP_SECONDARY ='Direct Income' OR GROUPMASTER.GROUP_SECONDARY ='Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY ='Duties & Taxes')")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, EDIT, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEBITLEDGER.Enter
        Try
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, EDIT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEBITLEDGER.Validating
        Try
            If CMBDEBITLEDGER.Text.Trim <> "" Then namevalidate(CMBDEBITLEDGER, CMBCODE, e, Me, txtadd, "")
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
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And cmbqtyunit.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub
                'CODE REMOVED BY GULKIT, AS WE HAVE STOPPED BARCODE FROM SALE RETURN AND WE NEED BARCODE TO BE GENERATED FROM SALE RETURN CHALLAN
                'If GRIDDOUBLECLICK = False Then
                '    If EDIT = True Then
                '        'GET LAST BARCODE SRNO
                '        Dim LSRNO As Integer = 0
                '        Dim RSRNO As Integer = 0
                '        Dim SNO As Integer = 0
                '        LSRNO = InStr(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                '        RSRNO = InStr(LSRNO + 1, GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                '        SNO = GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                '        TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                '    Else
                '        TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & GRIDSALRET.RowCount + 1 & "/" & YearId
                '    End If
                'End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
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

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSALRET As New SaleReturnDetails
            OBJSALRET.MdiParent = MDIMain
            OBJSALRET.Show()
            OBJSALRET.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then filltransname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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
                GRIDSALRET.RowCount = 0
                TEMPSALRETNO = Val(tstxtbillno.Text)
                If TEMPSALRETNO > 0 Then
                    EDIT = True
                    SaleReturn_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDSALRET.Enabled = True
        Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
        'If ClientName = "MOMAI" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Then
        '    If CMBPIECETYPE.Text.Trim = "FRESH" Then txtqty.Text = 1 Else TEMPQTY = 1
        'End If


        If GRIDDOUBLECLICK = False Then
            If ClientName = "MOMAI" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Then
                For I As Integer = 1 To TEMPQTY
                    If GRIDDOUBLECLICK = False Then
                        If EDIT = True Then
                            'GET LAST BARCODE SRNO
                            Dim LSRNO As Integer = 0
                            Dim RSRNO As Integer = 0
                            Dim SNO As Integer = 0
                            LSRNO = InStr(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            RSRNO = InStr(LSRNO + 1, GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                            SNO = GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                            TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                        Else
                            TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & GRIDSALRET.RowCount + 1 & "/" & YearId
                        End If
                    End If
                    GRIDSALRET.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0, 0, 0, 0)
                Next
            Else
                GRIDSALRET.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTBARCODE.Text.Trim, 0, 0, 0, 0, 0, 0)
            End If
            getsrno(GRIDSALRET)

        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSALRET.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDSALRET.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
            GRIDSALRET.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
            GRIDSALRET.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim

            GRIDSALRET.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDSALRET.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDSALRET.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDSALRET.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            GRIDSALRET.Item(gcut.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            GRIDSALRET.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDSALRET.Item(gQty.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            GRIDSALRET.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
            GRIDSALRET.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDSALRET.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDSALRET.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim

            GRIDSALRET.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
            GRIDSALRET.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
            GRIDSALRET.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        TOTAL()

        GRIDSALRET.FirstDisplayedScrollingRowIndex = GRIDSALRET.RowCount - 1

        If ClientName <> "SANGHVI" And ClientName <> "AVIS" Then
            txtsrno.Clear()
            CMBPIECETYPE.Text = ""
            cmbitemname.Text = ""
            TXTHSNCODE.Clear()
            CMBQUALITY.Text = ""
            CMBDESIGN.Text = ""
            cmbcolor.Text = ""
            TXTBALENO.Clear()
            TXTCUT.Clear()
            TXTWT.Clear()
            txtqty.Text = "1"
            cmbqtyunit.Text = ""
            TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBPER.Text = ""
            TXTAMT.Clear()
            CMBRACK.Text = ""
            CMBSHELF.Text = ""

        End If
        If ClientName = "SOFTAS" Then
            CMBPIECETYPE.Text = "FRESH"
            cmbqtyunit.Text = "Pcs"
        End If


        If GRIDSALRET.RowCount > 0 Then
            txtsrno.Text = Val(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        CMBPIECETYPE.Focus()
        If ClientName = "SANGHVI" Then cmbcolor.Focus()
        If ClientName = "AVIS" Then
            cmbitemname.Text = ""
            TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBDESIGN.Focus()
        End If
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTSALRETNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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

    Private Sub GRIDSALRET_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSALRET.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            GRIDSALRET.RowCount = 0
LINE1:
            TEMPSALRETNO = Val(TXTSALRETNO.Text) - 1
            If TEMPSALRETNO > 0 Then
                EDIT = True
                SaleReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSALRET.RowCount = 0 And TEMPSALRETNO > 1 Then
                TXTSALRETNO.Text = TEMPSALRETNO
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
            GRIDSALRET.RowCount = 0
LINE1:
            TEMPSALRETNO = Val(TXTSALRETNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTSALRETNO.Text.Trim
            CLEAR()
            If Val(TXTSALRETNO.Text) - 1 >= TEMPSALRETNO Then
                EDIT = True
                SaleReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSALRET.RowCount = 0 And TEMPSALRETNO < MAXNO Then
                TXTSALRETNO.Text = TEMPSALRETNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
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
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Return Receipt Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToDateTime(SALRETDATE.Text).Date < CNBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Return Receipt?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSALRETNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJSALRET As New ClsSaleReturn()
                    OBJSALRET.alParaval = alParaval
                    IntResult = OBJSALRET.Delete()
                    MsgBox("Return Receipt Deleted")
                    CLEAR()
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

    Private Sub GRIDSALRET_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSALRET.CellValidating
        Try
            Dim colNum As Integer = GRIDSALRET.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index, gcut.Index, GRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSALRET.CurrentCell.Value = Nothing Then GRIDSALRET.CurrentCell.Value = "0.00"
                        GRIDSALRET.CurrentCell.Value = Convert.ToDecimal(GRIDSALRET.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
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
            If lbllocked.Visible = True Then
                GRIDDOUBLECLICK = False
                Exit Sub
            End If


            If GRIDSALRET.CurrentRow.Index >= 0 And GRIDSALRET.Item(gsrno.Index, GRIDSALRET.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSALRET.Item(gsrno.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDSALRET.Item(GPIECETYPE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDSALRET.Item(gitemname.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDSALRET.Item(GHSNCODE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString

                CMBQUALITY.Text = GRIDSALRET.Item(GQUALITY.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSALRET.Item(GDESIGN.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDSALRET.Item(gcolor.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDSALRET.Item(GBALENO.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDSALRET.Item(gcut.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDSALRET.Item(GWT.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDSALRET.Item(gQty.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDSALRET.Item(gqtyunit.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDSALRET.Item(GMTRS.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDSALRET.Item(GRATE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDSALRET.Item(GPER.Index, GRIDSALRET.CurrentRow.Index).Value.ToString

                TXTAMT.Text = GRIDSALRET.Item(GAMT.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDSALRET.Item(GRACK.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDSALRET.Item(GSHELF.Index, GRIDSALRET.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSALRET.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSALRET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSALRET.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSALRET.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If e.KeyCode = Keys.Delete And Val(GRIDSALRET.CurrentRow.Cells(GOUTMTRS.Index).Value) > 0 Then
                    Exit Sub
                End If

                'end of block
                GRIDSALRET.Rows.RemoveAt(GRIDSALRET.CurrentRow.Index)
                getsrno(GRIDSALRET)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDSALRET.RowCount > 0 Then
                If GRIDSALRET.CurrentRow.Cells(gitemname.Index).Value <> "" Then GRIDSALRET.Rows.Add(CloneWithValues(GRIDSALRET.CurrentRow))

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

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, TXTWT, Me)
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If ClientName = "AVIS" Then
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND GROUP_NAME = 'HASTE DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, txtadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND GROUPMASTER.GROUP_NAME <> 'HASTE DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry debtors", "ACCOUNTS", cmbtrans.Text, CMBAGENT.Text)
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

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                'OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS"
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
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
            TXTAMT.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            If Val(txtqty.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
            If Val(TXTRATE.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMT.Text = Format(Val(TXTMTRS.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
                Else
                    TXTAMT.Text = Format(Val(txtqty.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
                End If
            End If
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub CMBPIECETYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        'Try
        '    If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And cmbqtyunit.Text.Trim <> "" And CMBDESIGN.Text.Trim <> "" And cmbcolor.Text.Trim <> "" And cmbqtyunit.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then

        '        If GRIDDOUBLECLICK = False Then
        '            If edit = True Then
        '                'GET LAST BARCODE SRNO
        '                Dim LSRNO As Integer = 0
        '                Dim RSRNO As Integer = 0
        '                Dim SNO As Integer = 0
        '                LSRNO = InStr(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
        '                RSRNO = InStr(LSRNO + 1, GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
        '                SNO = GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

        '                TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
        '            Else
        '                TXTBARCODE.Text = "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & GRIDSALRET.RowCount + 1 & "/" & YearId
        '            End If
        '        End If
        '        fillgrid()
        '    Else
        '        MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub cmbcolor_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUT.KeyPress
        numdotkeypress(e, TXTCUT, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, txtqty.KeyPress, TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress
        'AMOUNTNUMDOTKYEPRESS(e, sender, Me)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBPIECETYPE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPIECETYPE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBPIECETYPE As New SelectPieceType
                OBPIECETYPE.FRMSTRING = "PIECETYPE"
                OBPIECETYPE.ShowDialog()
                If OBPIECETYPE.TEMPNAME <> "" Then CMBPIECETYPE.Text = OBPIECETYPE.TEMPNAME
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
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
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

    Private Sub CMDSELECTRET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTRET.Click
        Try
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Party name First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTRET As New DataTable
            Dim OBJSELECTRET As New SelectInvoiceForReturn
            If ClientName <> "SVS" Then OBJSELECTRET.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTRET.ShowDialog()
            DTRET = OBJSELECTRET.DT

            If DTRET.Rows.Count > 0 Then

                Dim objclspreq As New ClsCommon()
                'Dim DT As DataTable = objclspreq.search(" DISTINCT  ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(INVOICEMASTER_DESC.INVOICE_PCS, 0) AS PCS, ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0) AS MTRS, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_PER, '') AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS ", "", " ITEMMASTER INNER JOIN INVOICEMASTER_DESC ON ITEMMASTER.item_id = INVOICEMASTER_DESC.INVOICE_ITEMID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN QUALITYMASTER ON INVOICEMASTER_DESC.INVOICE_QUALITYID = QUALITYMASTER.QUALITY_id INNER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN COLORMASTER ON INVOICEMASTER_DESC.INVOICE_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id ", "  AND INVOICEMASTER.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " AND INVOICEMASTER.INVOICE_RETURN = " & 0 & " ORDER BY INVNO")
                Dim DT As New DataTable

                If DTRET.Rows(0).Item("INVOICETYPE") = "INVOICE" Then
                    DT = objclspreq.search(" ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_INITIALS, 0) AS INVINITIALS, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(INVOICEMASTER_DESC.INVOICE_PCS, 0) AS PCS, ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0) AS MTRS, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_PER, '') AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER,  ISNULL(REGISTERMASTER.register_name, '') AS INVREGNAME,ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, ISNULL(INVOICEMASTER_DESC.INVOICE_BALENO,'') AS BALENO, REGLEDGERS.Acc_cmpname AS DEBITLEDGER ", "", " ITEMMASTER INNER JOIN INVOICEMASTER_DESC ON ITEMMASTER.item_id = INVOICEMASTER_DESC.INVOICE_ITEMID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON INVOICEMASTER_DESC.INVOICE_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON INVOICEMASTER_DESC.INVOICE_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id  INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.Acc_id ", "  AND INVOICEMASTER.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVNO")
                Else
                    DT = objclspreq.search(" ISNULL(OPENINGBILL.BILL_NO, 0) AS INVNO, ISNULL(OPENINGBILL.BILL_INITIALS, 0) AS INVINITIALS, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS INVDATE, 0 AS GDNNO, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS GDNDATE, '' AS ITEM, '' AS HSNCODE, '' AS QUALITY, '' AS DESIGN, '' AS COLOR, 0 AS PCS, 0 AS MTRS, 0 AS RATE, 'Mtrs' AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, 0 AS TOTALPCS, 0 AS TOTALMTRS, 0 AS CGSTPER, 0 AS SGSTPER, 0 AS IGSTPER,  ISNULL(REGISTERMASTER.register_name, '') AS INVREGNAME , ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, '' AS BALENO, REGLEDGERS.Acc_cmpname AS DEBITLEDGER ", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id  INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.Acc_id", "  AND OPENINGBILL.BILL_INITIALS = '" & DTRET.Rows(0).Item("INVINITIALS") & "' AND OPENINGBILL.BILL_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND OPENINGBILL.BILL_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND OPENINGBILL.BILL_YEARID = " & YearId & " ORDER BY INVNO")
                End If
                TXTINVNO.Text = DT.Rows(0).Item("INVNO")
                TXTINVINITIALS.Text = DT.Rows(0).Item("INVINITIALS")
                TXTINVREGNAME.Text = DT.Rows(0).Item("INVREGNAME")
                CMBDEBITLEDGER.Text = DT.Rows(0).Item("DEBITLEDGER")
                TXTINVTYPE.Text = DTRET.Rows(0).Item("INVOICETYPE")
                INVDATE.Text = DT.Rows(0).Item("INVDATE")
                TXTCHALLANNO.Text = DT.Rows(0).Item("GDNNO")
                CHALLANDATE.Text = DT.Rows(0).Item("GDNDATE")
                CMBAGENT.Text = DT.Rows(0).Item("AGENT")

                If TXTINVTYPE.Text.Trim = "INVOICE" And ClientName <> "AVIS" And ClientName <> "SUPRIYA" Then
                    Dim SNO As Integer = 0
                    For Each DTROWPS As DataRow In DT.Rows
                        If EDIT = False Then
                            'GRIDSALRET.Rows.Add(0, "", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Mtrs", Format(Val(DTROWPS("MTRS")), "0.00"), 0, DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId, DTROWPS("GDNBARCODE"), 0, 0, 0, DTROWPS("GDNNO"), DTROWPS("SRNO"))
                            GRIDSALRET.Rows.Add(0, "FRESH", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), DTROWPS("BALENO"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Pcs", Format(Val(DTROWPS("MTRS")), "0.00"), Val(DTROWPS("RATE")), DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId, "", 0, 0, 0, DTROWPS("INVNO"), "")

                        Else
                            GRIDSALRET.Rows.Add(0, "FRESH", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), DTROWPS("BALENO"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Pcs", Format(Val(DTROWPS("MTRS")), "0.00"), Val(DTROWPS("RATE")), DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & GRIDSALRET.RowCount + 1 & "/" & YearId, "", 0, 0, 0, DTROWPS("INVNO"), DTROWPS("INVNO"))
                        End If
                        SNO += 1

                        If DTROWPS("ITEM").ToString <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTCGSTPER.Text = Val(DTROWPS("CGSTPER"))
                                TXTSGSTPER.Text = Val(DTROWPS("SGSTPER"))
                                TXTIGSTPER.Text = 0
                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                TXTIGSTPER.Text = Val(DTROWPS("IGSTPER"))
                            End If
                        End If
                    Next
                    getsrno(GRIDSALRET)
                    TOTAL()
                End If


                'CHARGES GRID

                Dim dttable As DataTable = objclspreq.search(" INVOICEMASTER_CHGS.INVOICE_gridsrno AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, INVOICEMASTER_CHGS.INVOICE_PER AS PER, INVOICEMASTER_CHGS.INVOICE_AMT AS AMT, INVOICEMASTER_CHGS.INVOICE_TAXID AS TAXID ", "", " INVOICEMASTER_CHGS INNER JOIN LEDGERS ON INVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER_CHGS.INVOICE_REGISTERID = REGISTERMASTER.register_id ", " AND INVOICEMASTER_CHGS.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER_CHGS.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER_CHGS.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_CHGS.INVOICE_gridsrno")
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), 0, DTR("TAXID"))
                    Next
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Sale Return?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJPUR As New SaleReturnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "SALERETURN"
                OBJPUR.SALRETNO = Val(SRNO)
                OBJPUR.WHERECLAUSE = "{SALERETURN.SALRET_NO}=" & Val(SRNO) & " and {SALERETURN.SALRET_yearid}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(TEMPSALRETNO)
                PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        CALC()
        TOTAL()
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTADJAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub SALRETDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SALRETDATE.GotFocus
        SALRETDATE.SelectAll()
    End Sub

    Private Sub SALRETDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SALRETDATE.Validating
        Try
            If SALRETDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SALRETDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If Convert.ToDateTime(SALRETDATE.Text).Date < "01/07/2017" Then
                If TXTCHALLANNO.Text.Trim.Length > 0 Then
                    If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                        'for search
                        Dim objclscommon As New ClsCommon()
                        Dim dt As DataTable = objclscommon.search(" SALRET_challanno, LEDGERS.ACC_cmpname", "", " SALERETURN inner join LEDGERS on LEDGERS.ACC_id = SALRET_ledgerid ", " and SALRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND SALRET_YEARID =" & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                            e.Cancel = True
                        End If
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
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SALRET_BARCODE,'') AS BARCODE ", "", " SALERETURN_DESC ", " AND SALERETURN_DESC.SALRET_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As Windows.Forms.DataGridViewRow In GRIDSALRET.Rows
                        If ROW.Cells(GBARCODE.Index).Value <> "" Then
                            If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                                BLN = False
                                Exit Function
                            End If
                        End If
                    Next
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmbitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If cmbitemname.Text.Trim <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then GETHSNCODE()


            If (ClientName = "MAHAVIR" Or ClientName = "BARKHA" Or ClientName = "SHUBHI") And cmbitemname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search("  ISNULL(item_reorder, 0) AS CUT, ISNULL(ITEM_RATE, 0) AS RATE,ISNULL(ITEM_FOLD, '') AS [DESC],ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", " ITEMMASTER LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id ", " AND ITEMMASTER.item_name = '" & cmbitemname.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID='" & YearId & "' ")
                If DT1.Rows.Count > 0 Then
                    TXTCUT.Text = DT1.Rows(0).Item("CUT")
                    TXTRATE.Text = DT1.Rows(0).Item("RATE")
                    If DT1.Rows(0).Item("UNIT") = "Pcs" Then
                        CMBPER.Text = "Pcs"
                    Else
                        CMBPER.Text = "Mtrs"
                    End If
                End If
            End If


            'GET CATEGORY
            DT = OBJCMN.search("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try


            Dim OBJCMN As New ClsCommon
            'DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & cmbitemname.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
            Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & cmbitemname.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
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
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_DISC,0) AS DISCPER,  ISNULL(LEDGERS.ACC_CDPER,0) AS CDPER, ISNULL(LEDGERS.ACC_AGENTCOMM,'') AS AGENTCOMM ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    'CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")



                    If ClientName = "CC" Or ClientName = "SANGHVI" Then
                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "DISCOUNT GIVEN" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("DISCPER")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "DISCOUNT GIVEN", Val(DT.Rows(0).Item("DISCPER")) * -1, 0, 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "CASH DISCOUNT" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("CDPER")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "CASH DISCOUNT", Val(DT.Rows(0).Item("CDPER")) * -1, 0, 0)

                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "BROKERAGE" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("AGENTCOMM")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "BROKERAGE", Val(DT.Rows(0).Item("AGENTCOMM")) * -1, 0, 0)

                    End If

LINE1:

                End If

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

    Private Sub CMBCHARGES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
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

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' )")
        Catch ex As Exception
            Throw ex
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

    Sub EDITCHGSROW()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(gsrno.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(gsrno.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                TXTCHGSSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
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
            Dim dDebit As Decimal
            Dim bValid As Boolean = Decimal.TryParse(TXTCHGSPER.Text.Trim, dDebit)
            If bValid Then
                If Val(TXTCHGSPER.Text) = 0 Then TXTCHGSPER.Text = ""
                TXTCHGSPER.Text = Convert.ToDecimal(Val(TXTCHGSPER.Text))
                '' everything is good
                calchgs()
            ElseIf Val(TXTCHGSPER.Text.Trim) = 0 Then
                TXTCHGSAMT.ReadOnly = False
            Else
                MessageBox.Show("Invalid Number Entered")
                'e.Cancel = True
                TXTCHGSPER.Clear()
                TXTCHGSPER.Focus()
                Exit Sub
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
                Dim DT As DataTable = OBJCMN.search(" (CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
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
                    TXTCHGSAMT.Text = Format((Val(LBLTOTALMTRS.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        CALC()
        TOTAL()
    End Sub

    Private Sub CMBPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPER.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
            CALC()
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
                TOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "PARAS" Then LBLCATEGORY.Visible = True
            If ClientName = "AVIS" Then
                CMBQUALITY.TabStop = False
                TXTBALENO.TabStop = False
                CMBPIECETYPE.TabIndex = False
                cmbitemname.TabStop = False
                TXTAMT.TabStop = True
                txtqty.Text = 1
            End If
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

    Private Sub TXTAMT_Validated(sender As Object, e As EventArgs) Handles TXTAMT.Validated
        Try
            If ClientName = "AVIS" Then CMBSHELF_Validated(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validated(sender As Object, e As EventArgs) Handles cmbqtyunit.Validated
        Try
            If ClientName = "AVIS" Then
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        TOTAL()
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
            OBJSELECTPO.ShowDialog()

            DTTABLE = OBJSELECTPO.DT1

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SRCHNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTSRCHNO.Text.Trim = "" Then
                        TXTSRCHNO.Text = DTR("SRCHNO").ToString
                    Else
                        TXTSRCHNO.Text = TXTSRCHNO.Text & "," & DTR("SRCHNO").ToString
                    End If
                Next

                CMBNAME.Text = DTTABLE.Rows(0).Item("NAME")
                CMBNAME.Enabled = False
                TXTSTATECODE.Text = DTTABLE.Rows(0).Item("STATECODE")
                TXTGSTIN.Text = DTTABLE.Rows(0).Item("GSTIN")

                Dim DT1 As New DataTable
                If ClientName = "SANGHVI" Then
                    DT1 = OBJCMN.search(" SALERETURNCHALLAN.SRCH_NO AS SRCHNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_QTY, 0)) AS PCS, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_MTRS, 0)) AS MTRS , ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, 0 AS GDNSRNO, ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') AS BALENO,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, '') AS PRINTDESC, ISNULL(UNIT_ABBR,'') AS UNIT ", "", " SALERETURNCHALLAN INNER JOIN SALERETURNCHALLAN_DESC ON SALERETURNCHALLAN.SRCH_NO = SALERETURNCHALLAN_DESC.SRCH_NO AND SALERETURNCHALLAN.SRCH_YEARID = SALERETURNCHALLAN_DESC.SRCH_YEARID LEFT OUTER JOIN ITEMMASTER ON SALERETURNCHALLAN_DESC.SRCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON SALERETURNCHALLAN_DESC.SRCH_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON SALERETURNCHALLAN_DESC.SRCH_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON SALERETURNCHALLAN_DESC.SRCH_QUALITYID = QUALITYMASTER.QUALITY_ID LEFT OUTER JOIN PIECETYPEMASTER ON SALERETURNCHALLAN_DESC.SRCH_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON SRCH_QTYUNITID = UNIT_ID ", "  and SALERETURNCHALLAN.SRCH_NO IN(" & TXTSRCHNO.Text.Trim & ")  and SALERETURNCHALLAN.SRCH_YEARID = " & YearId & " GROUP BY SALERETURNCHALLAN.SRCH_NO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGN_NO,''), ISNULL(COLORMASTER.COLOR_name, '') , ISNULL(HSN_CODE,'') , ISNULL(HSN_CGST,0) , ISNULL(HSN_SGST,0) , ISNULL(HSN_IGST,0) ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, ''), ISNULL(UNIT_ABBR,'')  order by SALERETURNCHALLAN.SRCH_NO ")
                Else
                    DT1 = OBJCMN.search(" SALERETURNCHALLAN.SRCH_NO AS SRCHNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, '' AS QUALITY, ISNULL(DESIGN_NO,'') AS DESIGN, '' AS COLOR, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_QTY, 0)) AS PCS, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_MTRS, 0)) AS MTRS , ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, 0 AS GDNSRNO, ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') AS BALENO,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, '') AS PRINTDESC, ISNULL(UNIT_ABBR,'') AS UNIT ", "", " SALERETURNCHALLAN INNER JOIN SALERETURNCHALLAN_DESC ON SALERETURNCHALLAN.SRCH_NO = SALERETURNCHALLAN_DESC.SRCH_NO AND SALERETURNCHALLAN.SRCH_YEARID = SALERETURNCHALLAN_DESC.SRCH_YEARID LEFT OUTER JOIN ITEMMASTER ON SALERETURNCHALLAN_DESC.SRCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON SALERETURNCHALLAN_DESC.SRCH_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON SALERETURNCHALLAN_DESC.SRCH_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN PIECETYPEMASTER ON SALERETURNCHALLAN_DESC.SRCH_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON SRCH_QTYUNITID = UNIT_ID ", "  and SALERETURNCHALLAN.SRCH_NO IN(" & TXTSRCHNO.Text.Trim & ")  and SALERETURNCHALLAN.SRCH_YEARID = " & YearId & " GROUP BY SALERETURNCHALLAN.SRCH_NO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') , ISNULL(ITEMMASTER.item_name, '') ,ISNULL(DESIGN_NO,'') , ISNULL(HSN_CODE,'') , ISNULL(HSN_CGST,0) , ISNULL(HSN_SGST,0) , ISNULL(HSN_IGST,0) ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, ''), ISNULL(UNIT_ABBR,'')  order by SALERETURNCHALLAN.SRCH_NO ")
                End If
                If DT1.Rows.Count > 0 Then
                    For Each dr As DataRow In DT1.Rows

                        Dim PER As String = "Mtrs"
                        Dim INVRATE As Double = 0


                        'getting per from itemmaster
                        If ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "AXIS" Then
                            Dim DTPER As DataTable = OBJCMN.search("ISNULL(UNIT_ABBR,'Mtrs') AS PER", "", " ITEMMASTER LEFT OUTER JOIN UNITMASTER ON item_unitid = UNIT_ID ", " AND ITEMMASTER.ITEM_NAME = '" & dr("ITEM") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId)
                            If DTPER.Rows.Count > 0 Then
                                If DTPER.Rows(0).Item("PER") = "Pcs" Then PER = "Pcs"
                            End If
                        End If
                        If ClientName = "MOMAI" Then PER = "Pcs"


                        If ClientName = "SANGHVI" Then
                            Dim WHERECLAUSE As String = ""
                            If ClientName = "SANGHVI" AndAlso dr("QUALITY") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(QUALITYMASTER.QUALITY_NAME,'') = '" & dr("QUALITY") & "'"
                            If dr("DESIGN") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(DESIGNMASTER.DESIGN_NO,'') = '" & dr("DESIGN") & "'"
                            If ClientName = "SANGHVI" AndAlso dr("COLOR") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & dr("COLOR") & "'"
                            Dim DTRATE As DataTable = OBJCMN.search("PRICELISTMASTER.PL_RATE AS SALERATE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR ", "", "PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.ACC_ID ", " AND ISNULL(ITEMMASTER.ITEM_NAME,'') = '" & dr("ITEM") & "'" & WHERECLAUSE & " AND PL_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then INVRATE = DTRATE.Rows(0).Item("SALERATE")
                        End If


                        GRIDSALRET.Rows.Add(0, dr("PIECETYPE"), dr("ITEM"), dr("HSNCODE"), dr("QUALITY"), dr("DESIGN"), dr("COLOR"), dr("BALENO"), "0.00", "0.00", Format(Val(dr("PCS")), "0.00"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), INVRATE, PER, 0, "", "", "", "", 0, 0, 0, dr("SRCHNO"), "")


                        If dr("ITEM").ToString <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
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



                GRIDSALRET.FirstDisplayedScrollingRowIndex = GRIDSALRET.RowCount - 1
                If GRIDSALRET.RowCount > 0 Then
                    GRIDSALRET.Focus()
                    GRIDSALRET.CurrentCell = GRIDSALRET.Rows(0).Cells(GRATE.Index)
                End If
                getsrno(GRIDSALRET)
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
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
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPSALRETNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(SRNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJSR As New SaleReturnDesign
            OBJSR.MdiParent = MDIMain
            OBJSR.DIRECTPRINT = True
            OBJSR.FRMSTRING = "SALERETURN"
            OBJSR.DIRECTMAIL = True
            OBJSR.WHERECLAUSE = "{SALERETURN.SALRET_NO}=" & Val(SRNO) & " and {SALERETURN.SALRET_yearid}=" & YearId
            OBJSR.SALRETNO = SRNO
            OBJSR.NOOFCOPIES = 1
            OBJSR.Show()
            OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBREMOVEADJ_Click(sender As Object, e As EventArgs) Handles RBREMOVEADJ.Click
        Try
            If TXTINVINITIALS.Text.Trim <> "" Then
                If MsgBox("Wish to Remove the Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                TXTINVINITIALS.Clear()
                TXTINVNO.Clear()
                TXTINVREGNAME.Clear()
                TXTINVTYPE.Clear()
                MsgBox("After saving this entry please Reconcile Sale Data to get proper Results", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSALRETNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTSALRETNO.Validating
        Try
            If ALLOWMANUALCNDN = True Then
                If (Val(TXTSALRETNO.Text.Trim) <> 0 And TXTINVREGNAME.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPSALRETNO <> Val(TXTSALRETNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search("ISNULL(SALERETURN.SALRET_no, 0) AS SALRETNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN SALERETURN ON REGISTERMASTER.register_id = SALERETURN.SALRET_INVOICEREGID ", "  AND SALERETURN.SALRET_NO=" & TXTSALRETNO.Text.Trim & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND SALERETURN.SALRET_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("SalReTurn No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(sender As Object, e As EventArgs) Handles CMBDESIGN.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" And ClientName = "AVIS" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID ", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID =  " & YearId)
                If DT.Rows.Count > 0 Then cmbitemname.Text = DT.Rows(0).Item("ITEMNAME")
                cmbitemname_Validated(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

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
                MsgBox(" Company Details are Not filled properly ", MsgBoxStyle.Critical)
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
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or DT.Rows(0).Item("CITYNAME") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
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
                PARTYKMS = Val(DT.Rows(0).Item("KMS"))
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
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim DTINI As DataTable = OBJCMN.search("SALRET_PRINTINITIALS AS PRINTINITIALS", "", "SALERETURN", " AND SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND SALRET_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""CRN"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & SALRETDATE.Text & """" & "},"


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



                Dim TEMPLINEDISC As Double = 0
                Dim TEMPLINETAXABLEAMT As Double = 0
                Dim TEMPLINECGSTAMT As Double = 0
                Dim TEMPLINESGSTAMT As Double = 0
                Dim TEMPLINEIGSTAMT As Double = 0
                Dim TEMPLINEGRIDTOTALAMT As Double = 0
                Dim TEMPLINECHARGES As Double = 0
                Dim TEMPRATE As Double = 0
                If Val(TXTCHARGES.Text.Trim) < 0 Then
                    TEMPLINEDISC = Format(Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRS.Text.Trim), "0.0000")
                Else
                    If GRIDSALRET.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalqty.Text.Trim), "0.0000") Else TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRS.Text.Trim), "0.0000")
                End If


                Dim TEMPTOTALAMT As Double = 0
                Dim TEMPTOTALDISC As Double = 0
                Dim TEMPTOTALTAXABLEAMT As Double = 0
                Dim TEMPTOTALCGSTAMT As Double = 0
                Dim TEMPTOTALSGSTAMT As Double = 0
                Dim TEMPTOTALIGSTAMT As Double = 0
                Dim TEMPGTOTALAMT As Double = 0


                'WE NEED TO FETCH ALL ITEMS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT ISNULL(SALERETURN_DESC.SALRET_GRIDSRNO,0) AS SRNO, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, ISNULL(SALERETURN_DESC.SALRET_QTY,0) AS PCS, ISNULL(SALERETURN_DESC.SALRET_MTRS,0) AS MTRS, ISNULL(SALERETURN_DESC.SALRET_PER,'Mtrs') AS PER, ISNULL(SALERETURN_DESC.SALRET_RATE,0) AS RATE, ISNULL(SALERETURN_DESC.SALRET_AMT,0) AS TOTALAMT, 0 AS LINEDISC, 0 AS LINETAXABLEAMT, 0 AS LINECGSTAMT, 0 AS LINESGSTAMT, 0 AS LINEIGSTAMT, ISNULL(SALERETURN_DESC.SALRET_AMT,0) AS LINEGRIDDTOTAL, ISNULL(HSN_TYPE,'Goods') HSNTYPE FROM SALERETURN INNER JOIN SALERETURN_DESC ON SALERETURN.SALRET_NO = SALERETURN_DESC.SALRET_NO AND SALERETURN.SALRET_YEARID = SALERETURN_DESC.SALRET_YEARID INNER JOIN ITEMMASTER ON item_id = SALRET_ITEMID INNER JOIN HSNMASTER ON HSN_ID = SALRET_HSNCODEID WHERE SALERETURN.SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " and SALERETURN.SALRET_YEARID = " & YearId & " ORDER BY SALERETURN_DESC.SALRET_GRIDSRNO", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows

                    TEMPLINECHARGES = Format(Val(TEMPLINEDISC) * Val(DTROW("MTRS")), "0.00")
                    TEMPLINETAXABLEAMT = Format(Val(DTROW("TOTALAMT")) + Val(TEMPLINECHARGES), "0.00")
                    TEMPLINECGSTAMT = Format(Val(TXTCGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINESGSTAMT = Format(Val(TXTSGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                    If CURRROW > 0 Then j = j & ", {"
                    j = j & """SlNo"": """ & DTROW("SRNO") & """" & ","
                    j = j & """PrdDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    If DTROW("HSNTYPE") = "Goods" Then j = j & """IsServc"":""" & "N" & """" & "," Else j = j & """IsServc"":""" & "Y" & """" & ","
                    j = j & """HsnCd"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """Barcde"":""REC9999"","
                    If DTROW("PER") = "Pcs" Then j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                    j = j & """FreeQty"":" & "0" & "" & ","
                    j = j & """Unit"":""" & "MTR" & """" & ","


                    Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & DTROW("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")


                    If Val(TXTCHARGES.Text.Trim) <= 0 Then

                        j = j & """UnitPrice"":" & Val(DTROW("RATE")) & "" & ","
                        j = j & """TotAmt"":" & Format(Val(DTROW("TOTALAMT")), "0.00") & "" & ","

                        If INVOICESCREENTYPE = "LINE GST" Then
                            If Val(DTROW("LINEDISC")) < 0 Then j = j & """Discount"":" & Val(DTROW("LINEDISC")) * -1 & "" & "," Else j = j & """Discount"":" & Val(DTROW("LINEDISC")) & "" & ","
                        Else
                            If Val(TEMPLINECHARGES) < 0 Then j = j & """Discount"":" & Val(TEMPLINECHARGES) * -1 & "" & "," Else j = j & """Discount"":" & Val(TEMPLINECHARGES) & "" & ","
                        End If
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        If INVOICESCREENTYPE = "LINE GST" Then j = j & """AssAmt"":" & Val(DTROW("LINETAXABLEAMT")) & "" & "," Else j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","

                        j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                        j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                        j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","

                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","

                        If INVOICESCREENTYPE = "LINE GST" Then j = j & """TotItemVal"":" & Val(DTROW("LINEGRIDTOTAL")) & "" & "," Else j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & SALRETDATE.Text & """" & ","
                        j = j & """wrDt"":""" & SALRETDATE.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"

                    Else

                        j = j & """UnitPrice"":" & Format(Val(DTROW("RATE")) + TEMPRATE, "0.00") & "" & ","
                        If DTROW("PER") = "Pcs" Then TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("PCS")), "0.00") Else TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("MTRS")), "0.00")

                        TEMPLINECGSTAMT = Format(Val(TXTCGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINESGSTAMT = Format(Val(TXTSGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                        j = j & """TotAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """Discount"":" & "0" & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","
                        j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                        j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                        j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","
                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","
                        j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & SALRETDATE.Text & """" & ","
                        j = j & """wrDt"":""" & SALRETDATE.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"
                    End If



                    j = j & " }"
                    CURRROW += 1


                    'THESE VARIABLES ARE JUST FOR TESTING PURPOSE
                    TEMPTOTALAMT += Val(DTROW("TOTALAMT"))
                    TEMPTOTALDISC += Val(TEMPLINECHARGES)
                    TEMPTOTALTAXABLEAMT += Val(TEMPLINETAXABLEAMT)
                    TEMPTOTALCGSTAMT += Val(TEMPLINECGSTAMT)
                    TEMPTOTALSGSTAMT += Val(TEMPLINESGSTAMT)
                    TEMPTOTALIGSTAMT += Val(TEMPLINEIGSTAMT)
                    TEMPGTOTALAMT += Val(TEMPLINEGRIDTOTALAMT)


                Next

                j = j & " ],"



                j = j & """ValDtls"": {"
                j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TXTTCSAMT.Text.Trim) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(TXTGRANDTOTAL.Text.Trim) & "" & ","
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
                j = j & """Paymtdue"":" & Val(TXTGRANDTOTAL.Text.Trim) & "" & "},"


                'j = j & """RefDtls"": {"
                'j = j & """InvRm"":""TEST"","
                'j = j & """DocPerdDtls"": {"
                'j = j & """InvStDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """InvEndDt"":""" & SALRETDATE.Text & """" & "},"

                'j = j & """PrecDocDtls"": [{"
                'j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                'j = j & """InvDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """OthRefNo"":"" ""}],"

                'j = j & """ContrDtls"": [{"
                'j = j & """RecAdvRefr"":"" "","
                'j = j & """RecAdvDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """Tendrefr"":"" "","
                'j = j & """Contrrefr"":"" "","
                'j = j & """Extrefr"":"" "","
                'j = j & """Projrefr"":"" "","
                'j = j & """Porefr"":"" "","
                'j = j & """PoRefDt"":""" & SALRETDATE.Text & """" & "}]"
                'j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""DEBITNOTE"","
                j = j & """Info"":""DEBITNOTE""}],"

                j = j & """TransDocNo"":""   """ & ","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & SALRETDATE.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"




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
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_IRNNO = '" & TXTIRNNO.Text.Trim & "', SALRET_ACKNO = '" & TXTACKNO.Text.Trim & "', SALRET_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' WHERE SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND SALRET_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                bitmap1.Save(Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsSaleReturn
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTSALRETNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM SALERETURN INNER JOIN REGISTERMASTER ON SALRET_REGISTERID = REGISTER_ID WHERE SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND SALRET_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
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

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If EDIT = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                bitmap1.Save(Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsSaleReturn
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTSALRETNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                'cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
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

    Private Sub TXTADJSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADJSRNO.GotFocus
        If GRIDADJDOUBLECLICK = False Then TXTADJSRNO.Text = GRIDPAYMENT.RowCount + 1
    End Sub

    Private Sub TXTADJAMT_GotFocus(sender As Object, e As EventArgs) Handles TXTADJAMT.GotFocus
        TXTADJAMT.SelectAll()
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