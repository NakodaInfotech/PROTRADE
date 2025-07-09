
Imports System.ComponentModel
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SaleAutoTDS

    Dim SALEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub InvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST(0 AS BIT) AS CHK, INVOICEMASTER.INVOICE_NO AS SRNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(INVOICEMASTER.INVOICE_REFNO, '') AS REFNO, ISNULL(LEDGER.Acc_cmpname, '') AS NAME, ISNULL(LEDGER.Acc_add, '') AS ADDRESS, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(LEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS,ISNULL(INVOICEMASTER.INVOICE_TOTALDISCAMT, 0) AS TOTALDISC,ISNULL(INVOICEMASTER.INVOICE_TOTALSPDISCAMT, 0) AS TOTALSPDISCAMT ,ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL, INVOICEMASTER.INVOICE_DISPUTE AS DISPUTED, INVOICEMASTER.INVOICE_CHECKED AS CHECKED, INVOICEMASTER.INVOICE_REMARKS AS REMARKS, ISNULL(LEDGER.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE,ISNULL(INVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT , CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE, 'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END AS TOTALTAXABLEAMT,ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ,ISNULL(INVOICEMASTER.INVOICE_RETURN, 0) AS RETURNAMT ,ISNULL(INVOICEMASTER.INVOICE_BALANCE, 0) AS BALANCEAMT ,ISNULL(INVOICEMASTER.INVOICE_AMTREC, 0) + ISNULL(INVOICEMASTER.INVOICE_EXTRAAMT, 0)   AS RECDAMT,  ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS CHALLANNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS CHALLANDATE,ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING,ISNULL(INVOICEMASTER.INVOICE_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(TRANSNAME.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(INVOICE_LRNO,'') AS LRNO,INVOICEMASTER.INVOICE_LRDATE AS LRDATE, ISNULL(INVOICE_BALENOFROM,0) AS NOOFBALES, ISNULL(PURLEDGERS.ACC_CMPNAME,'') AS PURNAME , INVOICEMASTER.INVOICE_PONO AS SONO, ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) AS CHARGES, RECDATE.RECDATE, ISNULL(LOCALTRANSLEDGERS.ACC_CMPNAME,'') AS LOCALTRANSNAME, ISNULL(INVOICEMASTER.INVOICE_APPLYTCS,0) AS APPLYTCS, ISNULL(INVOICEMASTER.INVOICE_TCSPER,0) AS TCSPER, ISNULL(INVOICEMASTER.INVOICE_TCSAMT,0) AS TCSAMT, ISNULL(INVOICE_IRNNO,'') AS IRNNO, ISNULL(INVOICE_DOCKETNO,'') AS DOCKETNO, ISNULL(INVOICE_DOCKETDATE, GETDATE()) AS DOCKETDATE, ISNULL(INVOICE_COURIER,'') AS COURIER, ISNULL(TOCITYMASTER.city_name, '') AS TOCITY , ISNULL(STUFF((SELECT ', ' + CHGSLEDGERS.ACC_CMPNAME + '  ' + CAST(INVOICE_PER AS VARCHAR(10)) [text()] FROM INVOICEMASTER_CHGS  AS A INNER JOIN LEDGERS AS CHGSLEDGERS ON A.INVOICE_CHARGESID = CHGSLEDGERS.ACC_ID WHERE A.INVOICE_no = INVOICEMASTER.INVOICE_NO AND A.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND A.INVOICE_yearid = INVOICEMASTER.INVOICE_YEARID  FOR XML PATH(''), TYPE) .value('.','NVARCHAR(MAX)'),1,2,' '),'') AS CHGSDTLS,  INVOICEMASTER.INVOICE_INITIALS AS INVINITIALS, 0.00 as POSTAMT, ISNULL((SELECT TOP 1 ISNULL(J.journal_DEBIT,0) AS TDSAMT FROM  JOURNALMASTER as J INNER JOIN LEDGERS AS JVLEDGERS ON J.journal_ledgerid = JVLEDGERS.Acc_id WHERE INVOICEMASTER.INVOICE_INITIALS = J.JOURNAL_REFNO AND INVOICEMASTER.INVOICE_YEARID = J.JOURNAL_YEARID  AND J.JOURNAL_YEARID = " & YearId & " AND JVLEDGERS.ACC_TDSAC = 'TRUE'),0) AS TDSAMT  ", " ", " INVOICEMASTER INNER JOIN LEDGERS AS LEDGER ON INVOICEMASTER.INVOICE_LEDGERID = LEDGER.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON INVOICEMASTER.INVOICE_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS LOCALTRANSLEDGERS ON INVOICEMASTER.INVOICE_LOCALTRANSID = LOCALTRANSLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS ON INVOICEMASTER.INVOICE_AGENTID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGER.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON INVOICEMASTER.INVOICE_TRANSID = TRANSNAME.Acc_id LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON INVOICE_PURLEDGERID = PURLEDGERS.ACC_ID LEFT OUTER JOIN (SELECT INVOICEMASTER.INVOICE_INITIALS, REC.receipt_date AS RECDATE, INVOICE_YEARID FROM INVOICEMASTER  CROSS APPLY (SELECT TOP 1 RECEIPTMASTER.receipt_date FROM RECEIPTMASTER_DESC INNER JOIN RECEIPTMASTER ON RECEIPTMASTER_DESC.receipt_no = RECEIPTMASTER.RECEIPT_NO AND RECEIPTMASTER_DESC.receipt_registerid = RECEIPTMASTER.receipt_registerid AND RECEIPTMASTER_DESC.receipt_yearid = RECEIPTMASTER.receipt_yearid WHERE RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " AND receipt_paytype = 'Against Bill' AND INVOICEMASTER.INVOICE_INITIALS = RECEIPT_BILLINITIALS AND INVOICEMASTER.INVOICE_YEARID = RECEIPTMASTER.receipt_yearid ) AS REC) AS RECDATE  ON INVOICEMASTER.INVOICE_INITIALS = RECDATE.INVOICE_INITIALS AND INVOICEMASTER.INVOICE_YEARID = RECDATE.INVOICE_YEARID LEFT OUTER JOIN CITYMASTER AS TOCITYMASTER ON INVOICEMASTER.INVOICE_TOCITYID = TOCITYMASTER.city_id", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND (INVOICEMASTER.INVOICE_YEARID = '" & YearId & "') ORDER BY INVOICEMASTER.INVOICE_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("TDSAMT"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    SALEREGID = dt.Rows(0).Item(0)
                    fillgrid(" and INVOICEMASTER.INVOICE_yearid = " & YearId & " AND INVOICEMASTER.INVOICE_registerid = " & SALEREGID & " order by dbo.INVOICEMASTER.INVOICE_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPOST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPOST.Click
        Try
            If CMBTDS.Text.Trim <> "" And Val(TXTTDSPER.Text.Trim) > 0 Then
                If MsgBox("Wish to Auto Post Journal Entries", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                For I As Integer = 0 To Val(gridbill.RowCount - 1)
                    Dim ROW As DataRow = gridbill.GetDataRow(I)
                    If ROW("CHK") = True And Val(ROW("POSTAMT")) > 0 Then


                        Dim alParaval As New ArrayList
                        alParaval.Add(0)
                        alParaval.Add("JOURNAL REGISTER")
                        alParaval.Add(Format(Convert.ToDateTime(POSTINGDATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add("Against Bill - " & ROW("INVINITIALS"))
                        alParaval.Add("Against Bill - " & ROW("INVINITIALS"))
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

                        type = "Dr" & "|" & "Cr"
                        name = CMBTDS.Text.Trim & "|" & ROW("NAME")
                        paytype = "On Account" & "|" & "Against Bill"
                        refno = ROW("INVINITIALS") & "|" & ROW("INVINITIALS")
                        debit = Val(ROW("POSTAMT")) & "|" & 0
                        credit = 0 & "|" & Val(ROW("POSTAMT"))
                        gridsrno = 1 & "|" & 2

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
                        Dim TEMPJVNO As Integer = DT.Rows(0).Item(0)
                        ACCOUNTSENTRY(DT.Rows(0).Item(0), ROW("NAME"), Val(ROW("POSTAMT")))

                    End If
                Next
                MsgBox("Posting Done Successfully")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDAPPLYTDS_Click(sender As Object, e As EventArgs) Handles CMDAPPLYTDS.Click
        Try
            If CMBTDS.Text.Trim <> "" And Val(TXTTDSPER.Text.Trim) > 0 Then
                For I As Integer = 0 To Val(gridbill.RowCount - 1)
                    Dim ROW As DataRow = gridbill.GetDataRow(I)
                    If ROW("CHK") = True Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_TDSONGTOTAL,0) AS TDSONGTOTAL", "", " LEDGERS ", " AND LEDGERS.ACC_CMPNAME = '" & CMBTDS.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                        If DT.Rows.Count > 0 AndAlso Convert.ToBoolean(DT.Rows(0).Item("TDSONGTOTAL")) = True Then
                            ROW("POSTAMT") = Format(Val(ROW("GRANDTOTAL")) * Val(TXTTDSPER.Text.Trim) / 100, "0")
                        Else
                            ROW("POSTAMT") = Format(Val(ROW("TOTALTAXABLEAMT")) * Val(TXTTDSPER.Text.Trim) / 100, "0")
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY(ByVal JVNO As Integer, CRNAME As String, AMOUNT As Double)
        Try
            Dim OBJJV As New ClsJournalMaster
            Dim INTRESULT As Integer
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(CRNAME)    'ADDING FROMIDNAME
            ALPARAVAL.Add(Val(AMOUNT))
            ALPARAVAL.Add(CMBTDS.Text.Trim)    'ADDING NAME TOID
            ALPARAVAL.Add(Val(JVNO))            'JOURNAL NO
            ALPARAVAL.Add(Format(Now.Date, "MM/dd/yyyy"))            'JOURNAL DATE
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

    Private Sub InvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            POSTINGDATE.Text = Now.Date
            fillregister(cmbregister, " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            fillname(CMBTDS, False, " AND LEDGERS.ACC_TDSAC = 1 and GROUPMASTER.GROUP_PRIMARY = 'Current Assets'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Sale Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Invoice Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub POSTINGDATE_Validating(sender As Object, e As CancelEventArgs) Handles POSTINGDATE.Validating
        Try
            If POSTINGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(POSTINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class


