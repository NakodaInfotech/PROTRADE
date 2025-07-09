
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class ProformaInvoiceDetails

    Dim SALEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public multi As Boolean = False
    Public fromno, tono As Integer
    Public PARTYNAME As String

    Private Sub ProformaInvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
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
            'OG CODE ADDED RECDATE FOR KDFAB
            'Dim dt As DataTable = objclsCMST.search(" PROFORMAINVOICEMASTER.INVOICE_NO AS SRNO, PROFORMAINVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(PROFORMAINVOICEMASTER.INVOICE_REFNO, '') AS REFNO, ISNULL(LEDGER.Acc_cmpname, '') AS NAME, ISNULL(LEDGER.Acc_add, '') AS ADDRESS, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(LEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS,ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALDISCAMT, 0) AS TOTALDISC, ISNULL(PROFORMAINVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL, PROFORMAINVOICEMASTER.INVOICE_DISPUTE AS DISPUTED, PROFORMAINVOICEMASTER.INVOICE_CHECKED AS CHECKED, PROFORMAINVOICEMASTER.INVOICE_REMARKS AS REMARKS, ISNULL(LEDGER.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE,ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT , CASE WHEN ISNULL(PROFORMAINVOICEMASTER.INVOICE_SCREENTYPE, 'LINE GST') = 'LINE GST' THEN ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(PROFORMAINVOICEMASTER.INVOICE_SUBTOTAL, 0) END AS TOTALTAXABLEAMT,ISNULL(PROFORMAINVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_RETURN, 0) AS RETURNAMT ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_BALANCE, 0) AS BALANCEAMT ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_AMTREC, 0) + ISNULL(PROFORMAINVOICEMASTER.INVOICE_EXTRAAMT, 0)   AS RECDAMT,  ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_GDNNO, '') AS CHALLANNO, ISNULL(PROFORMAINVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS CHALLANDATE,ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING,ISNULL(PROFORMAINVOICEMASTER.INVOICE_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(TRANSNAME.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(INVOICE_LRNO,'') AS LRNO,PROFORMAINVOICEMASTER.INVOICE_LRDATE AS LRDATE, ISNULL(INVOICE_BALENOFROM,0) AS NOOFBALES, ISNULL(PURLEDGERS.ACC_CMPNAME,'') AS PURNAME , PROFORMAINVOICEMASTER.INVOICE_PONO AS SONO, ISNULL(PROFORMAINVOICEMASTER.INVOICE_CHARGES, 0) AS CHARGES ", " ", " PROFORMAINVOICEMASTER INNER JOIN LEDGERS AS LEDGER ON PROFORMAINVOICEMASTER.INVOICE_LEDGERID = LEDGER.Acc_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = LEDGER.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = LEDGER.Acc_locationid AND PROFORMAINVOICEMASTER.INVOICE_YEARID = LEDGER.Acc_yearid INNER JOIN REGISTERMASTER ON PROFORMAINVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = REGISTERMASTER.register_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = REGISTERMASTER.register_locationid AND PROFORMAINVOICEMASTER.INVOICE_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON PROFORMAINVOICEMASTER.INVOICE_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS ON PROFORMAINVOICEMASTER.INVOICE_YEARID = LEDGERS.Acc_yearid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = LEDGERS.Acc_locationid AND PROFORMAINVOICEMASTER.INVOICE_CMPID = LEDGERS.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_AGENTID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGER.Acc_yearid = CITYMASTER.city_yearid AND LEDGER.Acc_locationid = CITYMASTER.city_locationid AND LEDGER.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGER.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON PROFORMAINVOICEMASTER.INVOICE_TRANSID = TRANSNAME.Acc_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = TRANSNAME.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = TRANSNAME.Acc_locationid And PROFORMAINVOICEMASTER.INVOICE_YEARID = TRANSNAME.Acc_yearid LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON INVOICE_PURLEDGERID = PURLEDGERS.ACC_ID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND (PROFORMAINVOICEMASTER.INVOICE_YEARID = '" & YearId & "') ORDER BY PROFORMAINVOICEMASTER.INVOICE_NO")
            Dim dt As DataTable = objclsCMST.search(" PROFORMAINVOICEMASTER.INVOICE_NO AS SRNO, PROFORMAINVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(PROFORMAINVOICEMASTER.INVOICE_REFNO, '') AS REFNO, ISNULL(LEDGER.Acc_cmpname, '') AS NAME, ISNULL(LEDGER.Acc_add, '') AS ADDRESS, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(LEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS,ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALDISCAMT, 0) AS TOTALDISC,ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALSPDISCAMT, 0) AS TOTALSPDISCAMT ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL, PROFORMAINVOICEMASTER.INVOICE_DISPUTE AS DISPUTED, PROFORMAINVOICEMASTER.INVOICE_CHECKED AS CHECKED, PROFORMAINVOICEMASTER.INVOICE_REMARKS AS REMARKS, ISNULL(LEDGER.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE,ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT , CASE WHEN ISNULL(PROFORMAINVOICEMASTER.INVOICE_SCREENTYPE, 'LINE GST') = 'LINE GST' THEN ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(PROFORMAINVOICEMASTER.INVOICE_SUBTOTAL, 0) END AS TOTALTAXABLEAMT,ISNULL(PROFORMAINVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_RETURN, 0) AS RETURNAMT ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_BALANCE, 0) AS BALANCEAMT ,ISNULL(PROFORMAINVOICEMASTER.INVOICE_AMTREC, 0) + ISNULL(PROFORMAINVOICEMASTER.INVOICE_EXTRAAMT, 0)   AS RECDAMT,  ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(PROFORMAINVOICEMASTER.INVOICE_GDNNO, '') AS CHALLANNO, ISNULL(PROFORMAINVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS CHALLANDATE,ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING,ISNULL(PROFORMAINVOICEMASTER.INVOICE_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(TRANSNAME.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(INVOICE_LRNO,'') AS LRNO,PROFORMAINVOICEMASTER.INVOICE_LRDATE AS LRDATE, ISNULL(INVOICE_BALENOFROM,0) AS NOOFBALES, ISNULL(PURLEDGERS.ACC_CMPNAME,'') AS PURNAME , PROFORMAINVOICEMASTER.INVOICE_PONO AS SONO, ISNULL(PROFORMAINVOICEMASTER.INVOICE_CHARGES, 0) AS CHARGES, RECDATE.RECDATE, ISNULL(LOCALTRANSLEDGERS.ACC_CMPNAME,'') AS LOCALTRANSNAME, ISNULL(PROFORMAINVOICEMASTER.INVOICE_APPLYTCS,0) AS APPLYTCS, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TCSPER,0) AS TCSPER, ISNULL(PROFORMAINVOICEMASTER.INVOICE_TCSAMT,0) AS TCSAMT  ", " ", " PROFORMAINVOICEMASTER INNER JOIN LEDGERS AS LEDGER ON PROFORMAINVOICEMASTER.INVOICE_LEDGERID = LEDGER.Acc_id INNER JOIN REGISTERMASTER ON PROFORMAINVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON PROFORMAINVOICEMASTER.INVOICE_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS LOCALTRANSLEDGERS ON PROFORMAINVOICEMASTER.INVOICE_LOCALTRANSID = LOCALTRANSLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS ON PROFORMAINVOICEMASTER.INVOICE_YEARID = LEDGERS.Acc_yearid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = LEDGERS.Acc_locationid AND PROFORMAINVOICEMASTER.INVOICE_CMPID = LEDGERS.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_AGENTID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGER.Acc_yearid = CITYMASTER.city_yearid AND LEDGER.Acc_locationid = CITYMASTER.city_locationid AND LEDGER.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGER.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON PROFORMAINVOICEMASTER.INVOICE_TRANSID = TRANSNAME.Acc_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = TRANSNAME.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = TRANSNAME.Acc_locationid And PROFORMAINVOICEMASTER.INVOICE_YEARID = TRANSNAME.Acc_yearid LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON INVOICE_PURLEDGERID = PURLEDGERS.ACC_ID LEFT OUTER JOIN (SELECT PROFORMAINVOICEMASTER.INVOICE_INITIALS, REC.receipt_date AS RECDATE, INVOICE_YEARID FROM PROFORMAINVOICEMASTER  CROSS APPLY (SELECT TOP 1 RECEIPTMASTER.receipt_date FROM RECEIPTMASTER_DESC INNER JOIN RECEIPTMASTER ON RECEIPTMASTER_DESC.receipt_no = RECEIPTMASTER.RECEIPT_NO AND RECEIPTMASTER_DESC.receipt_registerid = RECEIPTMASTER.receipt_registerid AND RECEIPTMASTER_DESC.receipt_yearid = RECEIPTMASTER.receipt_yearid WHERE RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND PROFORMAINVOICEMASTER.INVOICE_YEARID = " & YearId & " AND receipt_paytype = 'Against Bill' AND PROFORMAINVOICEMASTER.INVOICE_INITIALS = RECEIPT_BILLINITIALS AND PROFORMAINVOICEMASTER.INVOICE_YEARID = RECEIPTMASTER.receipt_yearid ) AS REC) AS RECDATE  ON PROFORMAINVOICEMASTER.INVOICE_INITIALS = RECDATE.INVOICE_INITIALS AND PROFORMAINVOICEMASTER.INVOICE_YEARID = RECDATE.INVOICE_YEARID ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND (PROFORMAINVOICEMASTER.INVOICE_YEARID = '" & YearId & "') ORDER BY PROFORMAINVOICEMASTER.INVOICE_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBILL As New ProformaInvoice
                OBJBILL.MdiParent = MDIMain
                OBJBILL.EDIT = editval
                OBJBILL.TEMPINVOICENO = billno
                OBJBILL.TEMPREGNAME = cmbregister.Text.Trim
                OBJBILL.Show()
                '  Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
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
                    fillgrid(" and PROFORMAINVOICEMASTER.INVOICE_yearid = " & YearId & " AND PROFORMAINVOICEMASTER.INVOICE_registerid = " & SALEREGID & " order by dbo.PROFORMAINVOICEMASTER.INVOICE_no ")
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridINVOICE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProformaInvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillregister(cmbregister, " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
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

    Private Sub ProformaInvoiceDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "KDFAB" Then
                GRECDDATE.Visible = True
                GRECDDATE.VisibleIndex = GRECDAMT.VisibleIndex + 1
            End If
            If ClientName = "SAKARIA" Or ClientName = "NVAHAN" Then
                GSUPPLIERNAME.Visible = True
                GSUPPLIERNAME.VisibleIndex = 11
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class