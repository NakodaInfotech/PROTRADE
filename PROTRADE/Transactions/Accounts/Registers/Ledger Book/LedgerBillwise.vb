
Imports BL
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.GridControl
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class LedgerBillwise

    Dim AB As BaseView

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        gridregister.OptionsDetail.EnableMasterViewMode = True
        fillgrid()
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsLedgerBook

        ALPARAVAL.Add(cmbname.Text.Trim)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(AccFrom)
            ALPARAVAL.Add(AccTo)
        End If

        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        If chkpaid.CheckState = CheckState.Checked Then
            dt = objregister.GETPAID
        ElseIf chkall.Checked = True Then
            dt = objregister.getSUMMARY
        ElseIf chkall.Checked = False Then
            dt = objregister.GETOUTSTANDING
        End If


        Dim OBJCMN As New ClsCommon
        'Dim DT1 As DataTable = OBJCMN.search(" RECEIPTMASTER.RECEIPT_INITIALS AS RECINITIALS, RECEIPTMASTER.RECEIPT_DATE AS RECDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  RECEIPTMASTER.RECEIPT_REMARKS AS RECREMARKS, USERMASTER.USER_NAME AS RECUSERNAME,  RECEIPTMASTER.RECEIPT_NO AS RECNO,  REGISTER_NAME AS RECREGTYPE, RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS AS INVNO, 'RECEIPT' AS RECTYPE ", "", "  RECEIPTMASTER INNER JOIN RECEIPTMASTER_DESC ON RECEIPTMASTER.receipt_no = RECEIPTMASTER_DESC.receipt_no AND RECEIPTMASTER.receipt_registerid = RECEIPTMASTER_DESC.receipt_registerid AND RECEIPTMASTER.receipt_cmpid = RECEIPTMASTER_DESC.receipt_cmpid AND RECEIPTMASTER.receipt_locationid = RECEIPTMASTER_DESC.receipt_locationid AND RECEIPTMASTER.receipt_yearid = RECEIPTMASTER_DESC.receipt_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = RECEIPTMASTER.receipt_accid AND BANKLEDGER.Acc_cmpid = RECEIPTMASTER.receipt_cmpid AND BANKLEDGER.Acc_locationid = RECEIPTMASTER.receipt_locationid AND BANKLEDGER.Acc_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = RECEIPTMASTER.receipt_userid AND USERMASTER.User_cmpid = RECEIPTMASTER.receipt_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.receipt_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.receipt_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.receipt_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid ", " AND RECEIPTMASTER.RECEIPT_CMPID = " & CmpId & " AND RECEIPTMASTER.RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND RECEIPTMASTER_DESC.RECEIPT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "'")
        Dim DT1 As DataTable = OBJCMN.search("*", "", " (SELECT RECEIPTMASTER.RECEIPT_INITIALS AS RECINITIALS, RECEIPTMASTER.RECEIPT_DATE AS RECDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  RECEIPTMASTER.RECEIPT_REMARKS AS RECREMARKS, USERMASTER.USER_NAME AS RECUSERNAME,  RECEIPTMASTER.RECEIPT_NO AS RECNO,  REGISTER_NAME AS RECREGTYPE, RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS AS INVNO, 'RECEIPT' AS RECTYPE, RECEIPTMASTER_DESC.RECEIPT_AMT AS AMOUNT FROM  RECEIPTMASTER INNER JOIN RECEIPTMASTER_DESC ON RECEIPTMASTER.receipt_no = RECEIPTMASTER_DESC.receipt_no AND RECEIPTMASTER.receipt_registerid = RECEIPTMASTER_DESC.receipt_registerid AND RECEIPTMASTER.receipt_cmpid = RECEIPTMASTER_DESC.receipt_cmpid AND RECEIPTMASTER.receipt_locationid = RECEIPTMASTER_DESC.receipt_locationid AND RECEIPTMASTER.receipt_yearid = RECEIPTMASTER_DESC.receipt_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = RECEIPTMASTER.receipt_accid AND BANKLEDGER.Acc_cmpid = RECEIPTMASTER.receipt_cmpid AND BANKLEDGER.Acc_locationid = RECEIPTMASTER.receipt_locationid AND BANKLEDGER.Acc_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = RECEIPTMASTER.receipt_userid AND USERMASTER.User_cmpid = RECEIPTMASTER.receipt_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.receipt_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.receipt_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.receipt_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid WHERE RECEIPTMASTER.RECEIPT_CMPID = " & CmpId & " AND RECEIPTMASTER.RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND RECEIPTMASTER_DESC.RECEIPT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "' UNION ALL  SELECT PAYMENTMASTER.PAYMENT_INITIALS AS PAYINITIALS, PAYMENTMASTER.PAYMENT_DATE AS PAYDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  PAYMENTMASTER.PAYMENT_REMARKS AS PAYREMARKS, USERMASTER.USER_NAME AS PAYUSERNAME,  PAYMENTMASTER.PAYMENT_NO AS PAYNO,  REGISTER_NAME AS PAYREGTYPE, PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS AS INVNO, 'PAYMENT' AS PAYTYPE, PAYMENTMASTER_DESC.PAYMENT_AMT AS AMOUNT FROM  PAYMENTMASTER INNER JOIN PAYMENTMASTER_DESC ON PAYMENTMASTER.PAYMENT_no = PAYMENTMASTER_DESC.PAYMENT_no AND PAYMENTMASTER.PAYMENT_registerid = PAYMENTMASTER_DESC.PAYMENT_registerid AND PAYMENTMASTER.PAYMENT_cmpid = PAYMENTMASTER_DESC.PAYMENT_cmpid AND PAYMENTMASTER.PAYMENT_locationid = PAYMENTMASTER_DESC.PAYMENT_locationid AND PAYMENTMASTER.PAYMENT_yearid = PAYMENTMASTER_DESC.PAYMENT_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = PAYMENTMASTER.PAYMENT_accid AND BANKLEDGER.Acc_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND BANKLEDGER.Acc_locationid = PAYMENTMASTER.PAYMENT_locationid AND BANKLEDGER.Acc_yearid = PAYMENTMASTER.PAYMENT_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = PAYMENTMASTER.PAYMENT_userid AND USERMASTER.User_cmpid = PAYMENTMASTER.PAYMENT_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid INNER JOIN LEDGERS ON PAYMENTMASTER.PAYMENT_ledgerid = LEDGERS.Acc_id AND PAYMENTMASTER.PAYMENT_cmpid = LEDGERS.Acc_cmpid AND PAYMENTMASTER.PAYMENT_locationid = LEDGERS.Acc_locationid AND PAYMENTMASTER.PAYMENT_yearid = LEDGERS.Acc_yearid WHERE PAYMENTMASTER.PAYMENT_CMPID = " & CmpId & " AND PAYMENTMASTER.PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENTMASTER.PAYMENT_YEARID = " & YearId & " AND PAYMENTMASTER_DESC.PAYMENT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "' UNION ALL  SELECT JOURNALMASTER.JOURNAL_INITIALS AS PAYINITIALS, JOURNALMASTER.JOURNAL_DATE AS PAYDATE, '' as BANKNAME ,  JOURNALMASTER.JOURNAL_REMARKS AS PAYREMARKS, USERMASTER.USER_NAME AS PAYUSERNAME,  JOURNALMASTER.JOURNAL_NO AS PAYNO,  REGISTER_NAME AS PAYREGTYPE, JOURNALMASTER.journal_refno AS INVNO, 'JOURNAL' AS PAYTYPE, (CASE WHEN JOURNAL_DEBIT > 0 THEN JOURNAL_DEBIT ELSE JOURNAL_CREDIT END) AS AMOUNT FROM  JOURNALMASTER INNER JOIN USERMASTER ON USERMASTER.User_id = JOURNALMASTER.JOURNAL_userid AND USERMASTER.User_cmpid = JOURNALMASTER.JOURNAL_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.JOURNAL_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.JOURNAL_cmpid AND REGISTERMASTER.register_locationid = JOURNALMASTER.JOURNAL_locationid AND REGISTERMASTER.register_yearid = JOURNALMASTER.JOURNAL_yearid INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_ledgerid = LEDGERS.Acc_id AND JOURNALMASTER.JOURNAL_cmpid = LEDGERS.Acc_cmpid AND JOURNALMASTER.JOURNAL_locationid = LEDGERS.Acc_locationid AND JOURNALMASTER.JOURNAL_yearid = LEDGERS.Acc_yearid WHERE JOURNALMASTER.JOURNAL_CMPID = " & CmpId & " AND JOURNALMASTER.JOURNAL_LOCATIONID = " & Locationid & " AND JOURNALMASTER.JOURNAL_YEARID = " & YearId & " AND JOURNALMASTER.JOURNAL_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "') AS T  ", "")

        Dim DTSET As New DataSet
        DTSET.Tables.Add(dt.Copy)
        DTSET.Tables(0).TableName = "PAID"
        DTSET.Tables.Add(DT1.Copy)
        DTSET.Tables(1).TableName = "RECEIPT"

        DTSET.Relations.Add("BILLDETAILS", DTSET.Tables("PAID").Columns("Bill No"), DTSET.Tables("RECEIPT").Columns("INVNO"), False)

        griddetails.DataSource = DTSET.Tables("PAID")

        'griddetails.DataSource = dt



        '***********************************************************************
        'NO NEED OF OPENING BALANCE HERE ONLY REQUIRED WHEN ALL BILLS IS CHECKED
        'COZ IT CAUSES DOUBLE ENTRY, AS WE ARE GETTING OPENING BILLS FROM TABLE
        '***********************************************************************
        'getting opening balances

        lblopbal.Visible = chkall.Checked
        txtopening.Visible = chkall.Checked
        lbldrcropening.Visible = chkall.Checked

        If chkall.CheckState = CheckState.Checked Then
            Dim OBJCOMMON As New ClsCommonMaster
            If chkdate.CheckState = CheckState.Unchecked Then
                dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(AccFrom, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
            Else
                dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
            End If
            If dt.Rows.Count > 0 Then
                If Val(dt.Rows(0).Item(0).ToString) < 0 Then
                    txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
                    lbldrcropening.Text = "Cr"
                Else
                    txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                    lbldrcropening.Text = "Dr"
                End If
            End If


            'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
            'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
            If Val(txtopening.Text.Trim) = 0 Then
                dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                    If dt.Rows(0).Item(1).ToString = "Dr." Then
                        lbldrcropening.Text = "Dr"
                    Else
                        lbldrcropening.Text = "Cr"
                    End If
                End If
            End If
        Else
            txtopening.Clear()
        End If
        '***********************************************************************


        total()

    End Sub

    Sub total()
        Try

            txttotal.Text = 0.0
            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")


            'If chkdate.CheckState = CheckState.Checked Then
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If
            'End If

            'calculating total
            If Val(txttotal.Text) < 0 Then
                txttotal.Text = Format(Val(txttotal.Text) * (-1), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                lbldrcrclosing.Text = "Dr"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and ledgers.acc_cmpname = '" & cmbname.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBillwise_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                Dim objlb As New REgisterDetails
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F6 Then
                Dim objlb As New LedgerDaily
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F7 Then
                Dim objlb As New LedgerMonthly
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBillwise_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call cmdshowdetails_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            Call cmdshowdetails_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Call cmdshowdetails_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                VIEWFORM(dtrow("TYPE"), True, dtrow("BILL"), dtrow("REGTYPE"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            PATH = Application.StartupPath & "\Ledger Book (Bill Wise).XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Ledger Book (Bill Wise)"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Book (Bill Wise)", gridregister.VisibleColumns.Count + gridregister.GroupCount)
        Catch ex As Exception
            MsgBox("Ledger Bill Wise Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub chkpaid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpaid.CheckedChanged
        Try
           Call cmdshowdetails_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDPAID()
        Try
            txttotal.Text = "0.00"

            Dim dt As New DataTable()
            Dim ALPARAVAL As New ArrayList

            Dim objregister As New ClsLedgerBook

            ALPARAVAL.Add(cmbname.Text.Trim)
            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                'COZ DATE WONT BE IN ACCOUNTING YEAR
                If CmpName = "TRANSFER DATA" Then
                    ALPARAVAL.Add(Now.Date)
                Else
                    ALPARAVAL.Add(AccTo)
                End If
            End If

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            objregister.alParaval = ALPARAVAL
            If chkpaid.CheckState = CheckState.Checked Then
                dt = objregister.GETPAID
            ElseIf chkall.Checked = True Then
                dt = objregister.getSUMMARY
            ElseIf chkall.Checked = False Then
                dt = objregister.GETOUTSTANDING
            End If


            Dim OBJCMN As New ClsCommon
            'Dim DT1 As DataTable = OBJCMN.search(" RECEIPTMASTER.RECEIPT_INITIALS AS RECINITIALS, RECEIPTMASTER.RECEIPT_DATE AS RECDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  RECEIPTMASTER.RECEIPT_REMARKS AS RECREMARKS, USERMASTER.USER_NAME AS RECUSERNAME,  RECEIPTMASTER.RECEIPT_NO AS RECNO,  REGISTER_NAME AS RECREGTYPE, RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS AS INVNO, 'RECEIPT' AS RECTYPE ", "", "  RECEIPTMASTER INNER JOIN RECEIPTMASTER_DESC ON RECEIPTMASTER.receipt_no = RECEIPTMASTER_DESC.receipt_no AND RECEIPTMASTER.receipt_registerid = RECEIPTMASTER_DESC.receipt_registerid AND RECEIPTMASTER.receipt_cmpid = RECEIPTMASTER_DESC.receipt_cmpid AND RECEIPTMASTER.receipt_locationid = RECEIPTMASTER_DESC.receipt_locationid AND RECEIPTMASTER.receipt_yearid = RECEIPTMASTER_DESC.receipt_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = RECEIPTMASTER.receipt_accid AND BANKLEDGER.Acc_cmpid = RECEIPTMASTER.receipt_cmpid AND BANKLEDGER.Acc_locationid = RECEIPTMASTER.receipt_locationid AND BANKLEDGER.Acc_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = RECEIPTMASTER.receipt_userid AND USERMASTER.User_cmpid = RECEIPTMASTER.receipt_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.receipt_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.receipt_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.receipt_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid ", " AND RECEIPTMASTER.RECEIPT_CMPID = " & CmpId & " AND RECEIPTMASTER.RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND RECEIPTMASTER_DESC.RECEIPT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "'")
            Dim DT1 As DataTable = OBJCMN.search("*", "", " (SELECT RECEIPTMASTER.RECEIPT_INITIALS AS RECINITIALS, RECEIPTMASTER.RECEIPT_DATE AS RECDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  RECEIPTMASTER.RECEIPT_REMARKS AS RECREMARKS, USERMASTER.USER_NAME AS RECUSERNAME,  RECEIPTMASTER.RECEIPT_NO AS RECNO,  REGISTER_NAME AS RECREGTYPE, RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS AS INVNO, 'RECEIPT' AS RECTYPE, RECEIPTMASTER_DESC.RECEIPT_AMT AS AMOUNT FROM  RECEIPTMASTER INNER JOIN RECEIPTMASTER_DESC ON RECEIPTMASTER.receipt_no = RECEIPTMASTER_DESC.receipt_no AND RECEIPTMASTER.receipt_registerid = RECEIPTMASTER_DESC.receipt_registerid AND RECEIPTMASTER.receipt_cmpid = RECEIPTMASTER_DESC.receipt_cmpid AND RECEIPTMASTER.receipt_locationid = RECEIPTMASTER_DESC.receipt_locationid AND RECEIPTMASTER.receipt_yearid = RECEIPTMASTER_DESC.receipt_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = RECEIPTMASTER.receipt_accid AND BANKLEDGER.Acc_cmpid = RECEIPTMASTER.receipt_cmpid AND BANKLEDGER.Acc_locationid = RECEIPTMASTER.receipt_locationid AND BANKLEDGER.Acc_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = RECEIPTMASTER.receipt_userid AND USERMASTER.User_cmpid = RECEIPTMASTER.receipt_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = RECEIPTMASTER.receipt_registerid AND REGISTERMASTER.register_cmpid = RECEIPTMASTER.receipt_cmpid AND REGISTERMASTER.register_locationid = RECEIPTMASTER.receipt_locationid AND REGISTERMASTER.register_yearid = RECEIPTMASTER.receipt_yearid INNER JOIN LEDGERS ON RECEIPTMASTER.receipt_ledgerid = LEDGERS.Acc_id AND RECEIPTMASTER.receipt_cmpid = LEDGERS.Acc_cmpid AND RECEIPTMASTER.receipt_locationid = LEDGERS.Acc_locationid AND RECEIPTMASTER.receipt_yearid = LEDGERS.Acc_yearid WHERE RECEIPTMASTER.RECEIPT_CMPID = " & CmpId & " AND RECEIPTMASTER.RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND RECEIPTMASTER_DESC.RECEIPT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "' UNION ALL  SELECT PAYMENTMASTER.PAYMENT_INITIALS AS PAYINITIALS, PAYMENTMASTER.PAYMENT_DATE AS PAYDATE, BANKLEDGER.ACC_CMPNAME as BANKNAME ,  PAYMENTMASTER.PAYMENT_REMARKS AS PAYREMARKS, USERMASTER.USER_NAME AS PAYUSERNAME,  PAYMENTMASTER.PAYMENT_NO AS PAYNO,  REGISTER_NAME AS PAYREGTYPE, PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS AS INVNO, 'PAYMENT' AS PAYTYPE, PAYMENTMASTER_DESC.PAYMENT_AMT AS AMOUNT FROM  PAYMENTMASTER INNER JOIN PAYMENTMASTER_DESC ON PAYMENTMASTER.PAYMENT_no = PAYMENTMASTER_DESC.PAYMENT_no AND PAYMENTMASTER.PAYMENT_registerid = PAYMENTMASTER_DESC.PAYMENT_registerid AND PAYMENTMASTER.PAYMENT_cmpid = PAYMENTMASTER_DESC.PAYMENT_cmpid AND PAYMENTMASTER.PAYMENT_locationid = PAYMENTMASTER_DESC.PAYMENT_locationid AND PAYMENTMASTER.PAYMENT_yearid = PAYMENTMASTER_DESC.PAYMENT_yearid INNER JOIN LEDGERS AS BANKLEDGER ON BANKLEDGER.Acc_id = PAYMENTMASTER.PAYMENT_accid AND BANKLEDGER.Acc_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND BANKLEDGER.Acc_locationid = PAYMENTMASTER.PAYMENT_locationid AND BANKLEDGER.Acc_yearid = PAYMENTMASTER.PAYMENT_yearid INNER JOIN USERMASTER ON USERMASTER.User_id = PAYMENTMASTER.PAYMENT_userid AND USERMASTER.User_cmpid = PAYMENTMASTER.PAYMENT_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid INNER JOIN LEDGERS ON PAYMENTMASTER.PAYMENT_ledgerid = LEDGERS.Acc_id AND PAYMENTMASTER.PAYMENT_cmpid = LEDGERS.Acc_cmpid AND PAYMENTMASTER.PAYMENT_locationid = LEDGERS.Acc_locationid AND PAYMENTMASTER.PAYMENT_yearid = LEDGERS.Acc_yearid WHERE PAYMENTMASTER.PAYMENT_CMPID = " & CmpId & " AND PAYMENTMASTER.PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENTMASTER.PAYMENT_YEARID = " & YearId & " AND PAYMENTMASTER_DESC.PAYMENT_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "' UNION ALL  SELECT JOURNALMASTER.JOURNAL_INITIALS AS PAYINITIALS, JOURNALMASTER.JOURNAL_DATE AS PAYDATE, '' as BANKNAME ,  JOURNALMASTER.JOURNAL_REMARKS AS PAYREMARKS, USERMASTER.USER_NAME AS PAYUSERNAME,  JOURNALMASTER.JOURNAL_NO AS PAYNO,  REGISTER_NAME AS PAYREGTYPE, JOURNALMASTER.journal_refno AS INVNO, 'JOURNAL' AS PAYTYPE, (CASE WHEN JOURNAL_DEBIT > 0 THEN JOURNAL_DEBIT ELSE JOURNAL_CREDIT END) AS AMOUNT FROM  JOURNALMASTER INNER JOIN USERMASTER ON USERMASTER.User_id = JOURNALMASTER.JOURNAL_userid AND USERMASTER.User_cmpid = JOURNALMASTER.JOURNAL_cmpid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.JOURNAL_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.JOURNAL_cmpid AND REGISTERMASTER.register_locationid = JOURNALMASTER.JOURNAL_locationid AND REGISTERMASTER.register_yearid = JOURNALMASTER.JOURNAL_yearid INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_ledgerid = LEDGERS.Acc_id AND JOURNALMASTER.JOURNAL_cmpid = LEDGERS.Acc_cmpid AND JOURNALMASTER.JOURNAL_locationid = LEDGERS.Acc_locationid AND JOURNALMASTER.JOURNAL_yearid = LEDGERS.Acc_yearid WHERE JOURNALMASTER.JOURNAL_CMPID = " & CmpId & " AND JOURNALMASTER.JOURNAL_LOCATIONID = " & Locationid & " AND JOURNALMASTER.JOURNAL_YEARID = " & YearId & " AND JOURNALMASTER.JOURNAL_PAYTYPE = 'Against Bill' AND LEDGERS.ACC_CMPNAME ='" & cmbname.Text.Trim & "') AS T  ", "")

            Dim DTSET As New DataSet
            DTSET.Tables.Add(dt.Copy)
            DTSET.Tables(0).TableName = "PAID"
            DTSET.Tables.Add(DT1.Copy)
            DTSET.Tables(1).TableName = "RECEIPT"

            DTSET.Relations.Add("BILLDETAILS", DTSET.Tables("PAID").Columns("Bill No"), DTSET.Tables("RECEIPT").Columns("INVNO"), False)

            griddetails.DataSource = DTSET.Tables("PAID")




            '***********************************************************************
            'NO NEED OF OPENING BALANCE HERE ONLY REQUIRED WHEN ALL BILLS IS CHECKED
            'COZ IT CAUSES DOUBLE ENTRY, AS WE ARE GETTING OPENING BILLS FROM TABLE
            '***********************************************************************
            'getting opening balances

            lblopbal.Visible = chkall.Checked
            txtopening.Visible = chkall.Checked
            lbldrcropening.Visible = chkall.Checked

            If chkall.CheckState = CheckState.Checked Then
                Dim OBJCOMMON As New ClsCommonMaster
                If chkdate.CheckState = CheckState.Unchecked Then
                    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(AccFrom, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
                Else
                    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
                End If
                If dt.Rows.Count > 0 Then
                    If Val(dt.Rows(0).Item(0).ToString) < 0 Then
                        txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
                        lbldrcropening.Text = "Cr"
                    Else
                        txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                        lbldrcropening.Text = "Dr"
                    End If
                End If


                'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
                'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
                If Val(txtopening.Text.Trim) = 0 Then
                    dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                        If dt.Rows(0).Item(1).ToString = "Dr." Then
                            lbldrcropening.Text = "Dr"
                        Else
                            lbldrcropening.Text = "Cr"
                        End If
                    End If
                End If
            Else
                txtopening.Clear()
            End If
            '***********************************************************************


            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ledger (Bill Wise).XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If


            opti.SheetName = "Ledger (Bill Wise)"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger (Bill Wise)", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

        Catch ex As Exception
            MsgBox("Ledger Bill Wise Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLDAILY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDAILY.Click
        Try
            Dim objlb As New LedgerDaily
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMONTHLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMONTHLY.Click
        Try
            Dim objlb As New LedgerMonthly
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDETAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDETAIL.Click
        Try
            Dim objlb As New REgisterDetails
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDREC.DoubleClick
        Try

            If AB.RowCount > 0 Then

                Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                Dim point As Point = Me.griddetails.PointToClient(Control.MousePosition)
                Dim gridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = gridView.CalcHitInfo(point)
                If gridHitInfo.RowHandle = GridControl.InvalidRowHandle Then
                    Return
                End If
                System.Diagnostics.Debug.WriteLine(gridView.SourceRowHandle)



                Dim dtrow As DataRowView = AB.GetRow(gridHitInfo.RowHandle)
                If dtrow("RECTYPE").ToString = "RECEIPT" Then

                    Dim OBJREC As New Receipt
                    OBJREC.MdiParent = MDIMain
                    OBJREC.edit = True
                    OBJREC.TEMPRECEIPTNO = dtrow("RECNO").ToString
                    OBJREC.TEMPREGNAME = dtrow("RECREGTYPE").ToString
                    OBJREC.Show()

                ElseIf dtrow("RECTYPE").ToString = "PAYMENT" Then

                    Dim OBJPAY As New PaymentMaster
                    OBJPAY.MdiParent = MDIMain
                    OBJPAY.edit = True
                    OBJPAY.TEMPPAYMENTNO = dtrow("RECNO").ToString
                    OBJPAY.TEMPREGNAME = dtrow("RECREGTYPE").ToString
                    OBJPAY.Show()

                ElseIf dtrow("RECTYPE").ToString = "JOURNAL" Then

                    Dim OBJJV As New journal
                    OBJJV.MdiParent = MDIMain
                    OBJJV.edit = True
                    OBJJV.tempjvno = dtrow("RECNO").ToString
                    OBJJV.TEMPREGNAME = dtrow("RECREGTYPE").ToString
                    OBJJV.Show()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles gridregister.MasterRowExpanded
        Try
            AB = gridregister.GetDetailView(e.RowHandle, e.RelationIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_MasterRowGetChildList(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles gridregister.MasterRowGetChildList
        'Try
        '    MsgBox(gridregister.GetChildRowHandle(e.RowHandle, 0))
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub LedgerBillwise_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

End Class