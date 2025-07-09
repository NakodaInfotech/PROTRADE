Imports System.Windows.Forms
Imports BL

Public Class PaymentDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PAYREGID As Integer

    Private Sub PaymentDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" PAYMENTMASTER.PAYMENT_no AS [SRNO], LEDGERS.Acc_cmpname AS Name, PAYMENTMASTER.PAYMENT_date AS Date, PAYMENTMASTER.PAYMENT_total AS Total, PAYMENTMASTER.PAYMENT_CHQNO AS [Chq. No.], PAYMENTMASTER.PAYMENT_registerid AS Registerid, PAYMENTMASTER.PAYMENT_remarks AS Remarks, BANKLEDGERS.Acc_cmpname AS BankName, PAYMENTMASTER.PAYMENT_BILLREMARKS AS BILLREMARKS, ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME , ISNULL(PARTYBANKMASTER.PARTYBANK_name, '') AS PARTYBANK,  ISNULL(LEDGERS.ACC_ACCOUNTTYPE, '') AS ACCTYPE, ISNULL(LEDGERS.ACC_ACCOUNTNO, '') AS ACCOUNTNO, ISNULL(LEDGERS.ACC_IFSC, '') AS IFSCCODE, ISNULL(LEDGERS.ACC_BRANCH,'') AS BRANCH,  ISNULL(CITYMASTER.city_name, '') AS BANKCITY", "", "  PAYMENTMASTER INNER JOIN LEDGERS ON PAYMENTMASTER.PAYMENT_ledgerid = LEDGERS.Acc_id INNER JOIN LEDGERS AS BANKLEDGERS ON PAYMENTMASTER.PAYMENT_accid = BANKLEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_BANKCITYID = CITYMASTER.city_id LEFT OUTER JOIN PARTYBANKMASTER ON LEDGERS.ACC_BANKID = PARTYBANKMASTER.PARTYBANK_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON LEDGERS.ACC_AGENTID = AGENTLEDGERS.Acc_id ", TEMPCONDITION)
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridpayment.FocusedRowHandle = gridpayment.RowCount - 1
                gridpayment.TopRowIndex = gridpayment.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridpayment.RowCount > 0) Then
                Dim objpaymaster As New PaymentMaster
                objpaymaster.MdiParent = MDIMain
                objpaymaster.edit = editval
                objpaymaster.TEMPREGNAME = cmbregister.Text.Trim
                objpaymaster.TEMPPAYMENTNO = billno
                objpaymaster.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridpayment.DoubleClick
        Try
            showform(True, gridpayment.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PAYMENT'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PAYMENT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PAYMENT' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    PAYREGID = dt.Rows(0).Item(0)
                    'cmbregister.Enabled = False
                    fillgrid(" and dbo.PaymentMaster.payment_cmpid=" & CmpId & " and dbo.PaymentMaster.payment_LOCATIONid=" & Locationid & " and dbo.PaymentMaster.payment_YEARid=" & YearId & " AND PaymentMaster.payment_registerid = " & PAYREGID & " order by dbo.PaymentMaster.payment_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaymentDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYMENT'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridpayment.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Payment Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Payment Details"
            gridpayment.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Payment Details", gridpayment.VisibleColumns.Count + gridpayment.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Payment Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub PaymentDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridpayment.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Payment Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Payment from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Payment ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridpayment.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Payment Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp Payment from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected Payment ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHQPRINTTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHQPRINTTOOL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridpayment.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Payment Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                If MsgBox("Print Chq from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJPAY As New payment_advice
                    OBJPAY.MdiParent = MDIMain
                    OBJPAY.DIRECTPRINT = True
                    OBJPAY.FROMNO = Val(TXTFROM.Text.Trim)
                    OBJPAY.TONO = Val(TXTTO.Text.Trim)
                    OBJPAY.REGNAME = cmbregister.Text.Trim
                    OBJPAY.FRMSTRING = "CHQPAY"
                    OBJPAY.Show()
                    OBJPAY.Close()
                End If


                If MsgBox("Wish to Print Payment from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Payment Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJPAY As New payment_advice
                OBJPAY.MdiParent = MDIMain
                OBJPAY.DIRECTPRINT = True
                OBJPAY.FRMSTRING = "PAYMENT"
                OBJPAY.DIRECTMAIL = INVOICEMAIL
                OBJPAY.DIRECTWHATSAPP = WHATSAPP
                OBJPAY.REGNAME = cmbregister.Text.Trim
                OBJPAY.PRINTSETTING = PRINTDIALOG
                OBJPAY.payno = Val(I)
                OBJPAY.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPAY.Show()
                OBJPAY.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PAYMENT_" & I & ".pdf")
                FILENAME.Add("PAYMENT_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Payment"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList

            If INVOICEMAIL = False And WHATSAPP = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridpayment.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridpayment.GetDataRow(SELECTEDROWS(I))

                Dim OBJPAY As New payment_advice
                OBJPAY.MdiParent = MDIMain
                OBJPAY.DIRECTPRINT = True
                OBJPAY.FRMSTRING = "PAYMENT"
                OBJPAY.DIRECTMAIL = INVOICEMAIL
                OBJPAY.DIRECTWHATSAPP = WHATSAPP
                OBJPAY.REGNAME = cmbregister.Text.Trim
                OBJPAY.PRINTSETTING = PRINTDIALOG
                OBJPAY.payno = Val(ROW("SRNO"))
                OBJPAY.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPAY.Show()
                OBJPAY.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PAYMENT_" & Val(ROW("SRNO")) & ".pdf")
                FILENAME.Add("PAYMENT_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Payment"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class