Imports BL

Public Class DeductTDS

    Public BILLNO As Integer = 0
    Public REGISTER As String = ""
    Dim DEDUCTONCR As Boolean

    Private Sub DeductTDS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeductTDS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillname(CMBTDS, "False", " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTREGISTER.Clear()
            TXTINITIALS.Clear()
            TXTADD.Clear()
            TXTJVNO.Clear()
            TXTBILLNO.Clear()
            TXTPARTYBILLNO.Clear()
            BILLDATE.Value = Now.Date
            PARTYBILLDATE.Clear()
            TXTNAME.Clear()
            CMBTDS.Text = ""
            TXTTAXABLEAMT.Clear()
            TXTTDSPER.Clear()
            TXTTDSAMT.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeductTDS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            'GET DATA FROM PURCHASENASRE 
            If BILLNO <> 0 And REGISTER <> "" Then
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" * ", "", "(SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_DATE AS BILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO AS PARTYBILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS TOTAL, PURCHASEMASTER.BILL_TOTALTAXABLEAMT AS TAXABLEAMT, PURCHASEMASTER.BILL_SUBTOTAL AS SUBTOTAL FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER.BILL_CMPID = REGISTERMASTER.register_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = REGISTERMASTER.register_locationid AND PURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_CMPID = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = LEDGERS.Acc_locationid AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid WHERE BILL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId & " UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, JOURNALMASTER.JOURNAL_DATE AS BILLDATE, JOURNALMASTER.JOURNAL_REFNO AS PARTYBILLNO, JOURNALMASTER.JOURNAL_DATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, JOURNALMASTER.JOURNAL_CREDIT AS TOTAL, JOURNALMASTER.JOURNAL_CREDIT AS TAXABLEAMT, JOURNALMASTER.JOURNAL_CREDIT AS SUBTOTAL FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.JOURNAL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_LEDGERID = LEDGERS.Acc_id WHERE JOURNALMASTER.JOURNAL_CREDIT > 0 AND JOURNALMASTER.JOURNAL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND JOURNAL_YEARID = " & YearId & " UNION ALL SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_REFNO AS PARTYBILLNO, NONPURCHASE.NP_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, NONPURCHASE.NP_GRANDTOTAL AS TOTAL, NONPURCHASE.NP_TOTALTAXABLEAMT AS TAXABLEAMT, NONPURCHASE.NP_TOTALTAXABLEAMT AS SUBTOTAL FROM NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id WHERE NP_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND NP_YEARID = " & YearId & " UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS BILLINITIALS, CREDITNOTEMASTER.CN_date AS BILLDATE, CREDITNOTEMASTER.CN_PARTYREFNO AS PARTYBILLNO, CREDITNOTEMASTER.CN_date AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, CREDITNOTEMASTER.cn_GTOTAL AS TOTAL, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT, CREDITNOTEMASTER.CN_SUBTOTAL AS SUBTOTAL FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id WHERE CN_no = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND CN_yearid = " & YearId & ") AS T")
                Dim DT As DataTable = OBJCMN.search(" * ", "", "(SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_DATE AS BILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO AS PARTYBILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS TOTAL, (case when ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST')='LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT,0)  ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL,0)END) AS TAXABLEAMT, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER.BILL_CMPID = REGISTERMASTER.register_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = REGISTERMASTER.register_locationid AND PURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_CMPID = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = LEDGERS.Acc_locationid AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid WHERE BILL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId & " UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, JOURNALMASTER.JOURNAL_DATE AS BILLDATE, JOURNALMASTER.JOURNAL_REFNO AS PARTYBILLNO, JOURNALMASTER.JOURNAL_DATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, JOURNALMASTER.JOURNAL_CREDIT AS TOTAL, JOURNALMASTER.JOURNAL_CREDIT AS TAXABLEAMT, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.JOURNAL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_LEDGERID = LEDGERS.Acc_id WHERE JOURNALMASTER.JOURNAL_CREDIT > 0 AND JOURNALMASTER.JOURNAL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND JOURNAL_YEARID = " & YearId & " UNION ALL SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_REFNO AS PARTYBILLNO, NONPURCHASE.NP_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, NONPURCHASE.NP_GRANDTOTAL AS TOTAL, NONPURCHASE.NP_TOTALTAXABLEAMT AS TAXABLEAMT, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC FROM NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id WHERE NP_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND NP_YEARID = " & YearId & " UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS BILLINITIALS, CREDITNOTEMASTER.CN_date AS BILLDATE, CREDITNOTEMASTER.CN_PARTYREFNO AS PARTYBILLNO, CREDITNOTEMASTER.CN_date AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, CREDITNOTEMASTER.cn_GTOTAL AS TOTAL, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id WHERE CN_no = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND CN_yearid = " & YearId & ") AS T")

                'CHECK WHETHER TXTNAME IS OF LIABILITIS OR ASSETS ACCOUNT IF IT IS EXPENE OR INCOME ACCOUNT THEN USER BELOW CODE
                If DT.Rows.Count > 0 Then

                    Dim DT1 As DataTable = OBJCMN.search(" GROUP_HEAD ", "", " GROUPMASTER INNER JOIN LEDGERS ON LEDGERS.ACC_GROUPID = GROUP_ID ", " AND ACC_CMPNAME = '" & DT.Rows(0).Item("NAME") & "' AND LEDGERS.ACC_YEARID = " & YearId)
                    If (DT1.Rows(0).Item(0) = "Assets" Or DT1.Rows(0).Item(0) = "Liability") Then

                        DEDUCTONCR = True

                        TXTREGISTER.Text = REGISTER
                        TXTBILLNO.Text = BILLNO
                        TXTINITIALS.Text = DT.Rows(0).Item("BILLINITIALS")
                        BILLDATE.Value = Format(DT.Rows(0).Item("BILLDATE"), "dd/MM/yyyy")
                        TXTPARTYBILLNO.Text = DT.Rows(0).Item("PARTYBILLNO")
                        PARTYBILLDATE.Text = DT.Rows(0).Item("PARTYBILLDATE")
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        CMBTDS.Text = DT.Rows(0).Item("TDSDEDUCTEDAC")
                        TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TAXABLEAMT"))
                        TXTGTOTAL.Text = Val(DT.Rows(0).Item("TOTAL"))

                        'DONE BY GULKIT, SPECIAL REQUIREMENT OF SURESH BHAI
                        If (ClientName = "SAFFRONOFF" Or ClientName = "SAFFRON") Then TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TOTAL")) Else TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TAXABLEAMT"))

                        'DONE BY GULKIT, SPECIAL REQUIREMENT OF YASHVI
                        'If ClientName = "YASHVI" Or ClientName = "SOFTAS" Or ClientName = "DETLINE" Or ClientName = "ALENCOT" Then txtgrandtotal.Text = Val(DT.Rows(0).Item("SUBTOTAL"))
                    Else
                        DT = OBJCMN.search(" * ", "", "(SELECT PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, PURCHASEMASTER.BILL_DATE AS BILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO AS PARTYBILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS TOTAL, PURCHASEMASTER.BILL_TOTALTAXABLEAMT AS TAXABLEAMT, PURCHASEMASTER.BILL_SUBTOTAL AS SUBTOTAL, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER.BILL_CMPID = REGISTERMASTER.register_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = REGISTERMASTER.register_locationid AND PURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_CMPID = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = LEDGERS.Acc_locationid AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid WHERE BILL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId & " UNION ALL SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BILLDATE, NONPURCHASE.NP_REFNO AS PARTYBILLNO, NONPURCHASE.NP_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, NONPURCHASE.NP_GRANDTOTAL AS TOTAL, NONPURCHASE.NP_TOTALTAXABLEAMT AS TAXABLEAMT, NONPURCHASE.NP_TOTALTAXABLEAMT AS SUBTOTAL, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC  FROM NONPURCHASE INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id WHERE NP_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND NP_YEARID = " & YearId & " UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, JOURNALMASTER.JOURNAL_DATE AS BILLDATE, JOURNALMASTER.JOURNAL_REFNO AS PARTYBILLNO, JOURNALMASTER.JOURNAL_DATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, JOURNALMASTER.JOURNAL_DEBIT AS TOTAL, JOURNALMASTER.JOURNAL_DEBIT AS TAXABLEAMT, JOURNALMASTER.JOURNAL_DEBIT AS SUBTOTAL, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC  FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.JOURNAL_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_LEDGERID = LEDGERS.Acc_id WHERE JOURNALMASTER.JOURNAL_DEBIT > 0 AND JOURNALMASTER.JOURNAL_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND JOURNAL_YEARID = " & YearId & " UNION ALL SELECT CREDITNOTEMASTER.CN_INITIALS AS BILLINITIALS, CREDITNOTEMASTER.CN_DATE AS BILLDATE, CREDITNOTEMASTER.CN_PARTYREFNO AS PARTYBILLNO, CREDITNOTEMASTER.CN_DATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS NAME, CREDITNOTEMASTER.CN_GTOTAL AS TOTAL, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT, CREDITNOTEMASTER.CN_SUBTOTAL AS SUBTOTAL, ISNULL(LEDGERS.ACC_TDSDEDUCTEDAC,'') AS TDSDEDUCTEDAC  FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_REGISTERID = REGISTERMASTER.register_id INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id WHERE CN_NO = " & BILLNO & " AND REGISTER_NAME = '" & REGISTER & "' AND CN_YEARID = " & YearId & ") AS T")
                        DEDUCTONCR = False

                        TXTREGISTER.Text = REGISTER
                        TXTBILLNO.Text = BILLNO
                        TXTINITIALS.Text = DT.Rows(0).Item("BILLINITIALS")
                        BILLDATE.Value = Format(DT.Rows(0).Item("BILLDATE"), "dd/MM/yyyy")
                        TXTPARTYBILLNO.Text = DT.Rows(0).Item("PARTYBILLNO")
                        If REGISTER = "FREIGHT REGISTER" Then PARTYBILLDATE.Text = Format(DT.Rows(0).Item("PARTYBILLDATE"), "MM/dd/yyyy") Else PARTYBILLDATE.Text = DT.Rows(0).Item("PARTYBILLDATE")
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        CMBTDS.Text = DT.Rows(0).Item("TDSDEDUCTEDAC")
                        TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TAXABLEAMT"))
                        TXTGTOTAL.Text = Val(DT.Rows(0).Item("TOTAL"))

                        'DONE BY GULKIT, SPECIAL REQUIREMENT OF SURESH BHAI
                        If (ClientName = "SAFFRONOFF" Or ClientName = "SAFFRON") Then TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TOTAL")) Else TXTTAXABLEAMT.Text = Val(DT.Rows(0).Item("TAXABLEAMT"))

                        'DONE BY GULKIT, SPECIAL REQUIREMENT OF YASHVI
                        'If ClientName = "YASHVI" Or ClientName = "SOFTAS" Or ClientName = "DETLINE" Then txtgrandtotal.Text = Val(DT.Rows(0).Item("SUBTOTAL"))
                    End If

                End If

                'GET TDS PERCENT
                DT = OBJCMN.search(" ISNULL(ACCOUNTSMASTER_TDS.ACC_TDSPER,0) AS TDSPER, ISNULL(ACCOUNTSMASTER_TDS.ACC_TDSRATE,0) AS TDSRATE, ISNULL(ACCOUNTSMASTER_TDS.ACC_LIMIT,0) AS LIMIT ", "", " ACCOUNTSMASTER INNER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.Acc_id = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' AND ACCOUNTSMASTER.ACC_YEARID  = " & YearId)
                If DT.Rows.Count > 0 Then
                    'FIRST CHECK WHETHER LOWER TDSRATE IS APPLICABE OR NOT 
                    'IF APPLICABLE THEN CHECK PARTY'S CURRENT YEAR'S TOTAL TRANSACTION DONE, 
                    'IF TOTAL TRANS OF THE YEAR EXCEEDS LIMIT THEN TDSPER WILL BE APPLIED OR ELSE TDSRATE WILL BE APPLIED
                    Dim TDSPER As Double = Val(DT.Rows(0).Item("TDSPER"))
                    If Val(DT.Rows(0).Item("LIMIT")) > 0 And Val(DT.Rows(0).Item("TDSRATE")) > 0 Then
                        Dim DTTDS As DataTable = OBJCMN.search(" ISNULL(SUM(T.TOTALAMT),0) AS TOTALAMT ", "", " (SELECT ISNULL(SUM(BILL_SUBTOTAL),0) AS TOTALAMT FROM PURCHASEMASTER INNER JOIN LEDGERS ON BILL_LEDGERID = LEDGERS.ACC_ID WHERE LEDGERS.ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' AND BILL_YEARID = " & YearId & " UNION ALL SELECT ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TOTALAMT FROM NONPURCHASE INNER JOIN LEDGERS ON NP_LEDGERID = LEDGERS.ACC_ID WHERE LEDGERS.ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' AND NP_YEARID = " & YearId & ") AS T ", "")
                        If DTTDS.Rows.Count > 0 AndAlso Val(DTTDS.Rows(0).Item("TOTALAMT")) < Val(DT.Rows(0).Item("LIMIT")) Then TDSPER = Val(DT.Rows(0).Item("TDSRATE"))
                    End If
                    TXTTDSPER.Text = Val(TDSPER)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTDS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTDS.Enter
        Try
            If CMBTDS.Text.Trim = "" Then fillname(CMBTDS, "FALSE", " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTDS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTDS.Validating
        Try
            If CMBTDS.Text.Trim <> "" Then namevalidate(CMBTDS, CMBTDS, e, Me, TXTADD, " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTDSPER.KeyPress
        numdotkeypress(e, TXTTDSPER, Me)
    End Sub

    Private Sub TXTTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTDSPER.Validated
        If Val(TXTTDSPER.Text.Trim) > 0 And CMBTDS.Text.Trim <> "" And (Val(TXTTAXABLEAMT.Text.Trim) > 0 Or Val(TXTGTOTAL.Text.Trim) > 0) Then

            'CHECK WHETHER WE HAVE TO DEDUCT ON GRANDTOTAL OR TAXABLEAMT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_TDSONGTOTAL,0) AS TDSONGTOTAL", "", " LEDGERS", " AND LEDGERS.ACC_CMPNAME = '" & CMBTDS.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Convert.ToBoolean(DT.Rows(0).Item("TDSONGTOTAL")) = False Then
                    TXTTDSAMT.Text = Format((Val(TXTTDSPER.Text.Trim) * Val(TXTTAXABLEAMT.Text.Trim)) / 100, "0.00")
                    TXTTDSROUNDOFF.Text = Format((Val(TXTTDSPER.Text.Trim) * Val(TXTTAXABLEAMT.Text.Trim)) / 100, "0")
                Else
                    TXTTDSAMT.Text = Format((Val(TXTTDSPER.Text.Trim) * Val(TXTGTOTAL.Text.Trim)) / 100, "0.00")
                    TXTTDSROUNDOFF.Text = Format((Val(TXTTDSPER.Text.Trim) * Val(TXTGTOTAL.Text.Trim)) / 100, "0")
                End If
                TXTTDSROUNDOFF.Enabled = False
            End If

        ElseIf Val(TXTTDSPER.Text.Trim) = 0 Then
            TXTTDSROUNDOFF.Enabled = True
        End If
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTREGISTER.Text.Trim.Length = 0 Then
            EP.SetError(TXTREGISTER, "Enter Register Name")
            bln = False
        End If

        If TXTBILLNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTBILLNO, "Enter Bill No")
            bln = False
        End If

        'If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
        '    bln = False
        'End If

        If TXTNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTNAME, " Please Fill Company Name ")
            bln = False
        End If

        If Val(TXTTAXABLEAMT.Text.Trim) = 0 Then
            EP.SetError(TXTTAXABLEAMT, "Total Amt Cannot be 0")
            bln = False
        End If

        If Val(TXTTDSAMT.Text.Trim) = 0 And Val(TXTTDSROUNDOFF.Text.Trim) = 0 Then
            EP.SetError(TXTTDSAMT, "TDS Amt Cannot be 0")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            'save entry in journal
            Dim alParaval As New ArrayList
            alParaval.Add(0)
            alParaval.Add("JOURNAL REGISTER")
            alParaval.Add(Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add("Against Bill No " & TXTINITIALS.Text.Trim & "/" & TXTPARTYBILLNO.Text.Trim & " Bill Dt. " & Format(BILLDATE.Value.Date, "dd/MM/yyy"))   'FOR REMARKS
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                alParaval.Add("Against Bill No " & TXTPARTYBILLNO.Text.Trim & " Bill Dt. " & PARTYBILLDATE.Text)
            Else
                alParaval.Add("Against Bill No " & TXTINITIALS.Text.Trim & " Bill Dt. " & PARTYBILLDATE.Text)
            End If
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim type As String = ""
            Dim name As String = ""
            Dim paytype As String = ""
            Dim refno As String = ""
            Dim debit As String = ""
            Dim credit As String = ""
            Dim gridsrno As String = ""

            If DEDUCTONCR = True Then
                For I As Integer = 0 To 1
                    If type = "" Then
                        type = "Dr"
                        name = TXTNAME.Text.Trim
                        paytype = "Against Bill"
                        refno = TXTINITIALS.Text.Trim
                        If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                            debit = Val(TXTTDSROUNDOFF.Text.Trim)
                        Else
                            debit = Val(TXTTDSAMT.Text.Trim)
                        End If
                        credit = 0
                        gridsrno = 1
                    Else
                        type = type & "|" & "Cr"
                        name = name & "|" & CMBTDS.Text.Trim
                        paytype = paytype & "|" & "On Account"
                        refno = refno & "|" & TXTINITIALS.Text.Trim
                        debit = debit & "|" & 0
                        If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                            credit = credit & "|" & Val(TXTTDSROUNDOFF.Text.Trim)
                        Else
                            credit = credit & "|" & Val(TXTTDSAMT.Text.Trim)
                        End If
                        gridsrno = gridsrno & "|" & 2
                    End If
                Next
            Else
                For I As Integer = 0 To 1
                    If type = "" Then
                        type = "Dr"
                        name = CMBTDS.Text.Trim
                        paytype = "On Account"
                        refno = TXTINITIALS.Text.Trim
                        If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                            debit = Val(TXTTDSROUNDOFF.Text.Trim)
                        Else
                            debit = Val(TXTTDSAMT.Text.Trim)
                        End If
                        credit = 0
                        gridsrno = 1
                    Else
                        type = type & "|" & "Cr"
                        name = name & "|" & TXTNAME.Text.Trim
                        paytype = paytype & "|" & "Against Bill"
                        refno = refno & "|" & TXTINITIALS.Text.Trim
                        debit = debit & "|" & 0
                        If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                            credit = credit & "|" & Val(TXTTDSROUNDOFF.Text.Trim)
                        Else
                            credit = credit & "|" & Val(TXTTDSAMT.Text.Trim)
                        End If
                        gridsrno = gridsrno & "|" & 2
                    End If
                Next
            End If

            alParaval.Add(type)
            alParaval.Add(name)
            alParaval.Add(paytype)
            alParaval.Add(refno)
            alParaval.Add(debit)
            alParaval.Add(credit)
            alParaval.Add(gridsrno)

            Dim objclsjvmaster As New ClsJournalMaster()
            objclsjvmaster.alParaval = alParaval
            Dim DT As DataTable = objclsjvmaster.save()

            'ACCOUNTS ENTRY TO BE DONE HERE COZ LOOP IS NOT POSSIBLE IN SP
            TXTJVNO.Text = DT.Rows(0).Item(0)
            ACCOUNTSENTRY(DT.Rows(0).Item(0))
            CLEAR()
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY(ByVal JVNO As Integer)
        Try
            Dim OBJJV As New ClsJournalMaster
            Dim INTRESULT As Integer
            Dim ALPARAVAL As New ArrayList

            'CREDIT ENTRY
            If DEDUCTONCR = True Then
                ALPARAVAL.Add(CMBTDS.Text.Trim)    'ADDING NAME TOID
                If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                    ALPARAVAL.Add(Val(TXTTDSROUNDOFF.Text.Trim))    'ADDING NAME TOID
                Else
                    ALPARAVAL.Add(Val(TXTTDSAMT.Text.Trim))    'ADDING NAME TOID
                End If
                ALPARAVAL.Add(TXTNAME.Text.Trim)    'ADDING NAME TOID
            Else
                ALPARAVAL.Add(TXTNAME.Text.Trim)    'ADDING NAME TOID
                If Val(TXTTDSROUNDOFF.Text.Trim) > 0 Then
                    ALPARAVAL.Add(Val(TXTTDSROUNDOFF.Text.Trim))    'ADDING NAME TOID
                Else
                    ALPARAVAL.Add(Val(TXTTDSAMT.Text.Trim))    'ADDING NAME TOID
                End If
                ALPARAVAL.Add(CMBTDS.Text.Trim)    'ADDING NAME TOID
            End If
            ALPARAVAL.Add(Val(TXTJVNO.Text))            'JOURNAL NO
            ALPARAVAL.Add(Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy"))            'JOURNAL DATE
            ALPARAVAL.Add("")        'REMARKS
            ALPARAVAL.Add("JOURNAL REGISTER")        'REGISTER
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJJV.alParaval = ALPARAVAL
            INTRESULT = OBJJV.ACCOUNTS()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TXTTDSROUNDOFF_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTDSROUNDOFF.KeyPress
        numdotkeypress(e, TXTTDSROUNDOFF, Me)
    End Sub

    Private Sub TXTTDSROUNDOFF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTDSROUNDOFF.Validating
        Try
            If Val(TXTTDSROUNDOFF.Text.Trim) = 0 Then Exit Sub
            If Val(TXTTDSPER.Text.Trim) = 0 Then Exit Sub
            If Val(TXTTDSROUNDOFF.Text.Trim) - Val(TXTTDSAMT.Text.Trim) > 1 Or Val(TXTTDSAMT.Text.Trim) - Val(TXTTDSROUNDOFF.Text.Trim) > 1 Then
                MsgBox("Amount Diff. Cannot be greater or less then 1 Rs.", MsgBoxStyle.Critical)
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class