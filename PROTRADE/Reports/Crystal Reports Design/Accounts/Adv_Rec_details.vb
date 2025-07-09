
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports PROTRADE
Imports BL

Public Class Adv_Rec_details

    'Dim rpts As New saledetails
    Dim rptpayment_details As New payment_details
    Dim rptpayment_dtls_paytype As New payment_detail_paytype
    Dim rptreceipt_details As New receipt_details
    Dim rptrec_dtls_paytype As New receivable_details_paytype
    Dim RPTPAYBILLWISE As New PaymentBillWise
    Dim RPTRECBILLWISE As New ReceiptBillWise
    Dim RPTRECMONTHLYADJ As New RecMonthlyAdjustedReport
    Dim RPTPAYMONTHLYADJ As New PayMonthlyAdjustedReport

    Public x As String ' variable X is For To Distinguish What type of Report is to be Open In Current Report Form
    Public strsearch As String
    Dim tempattachment As String
    Public PERIOD As String = ""

    Private Sub Adv_Rec_details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With
            If x = "open_PaymentDetails" Then
                crTables = rptpayment_details.Database.Tables
            ElseIf x = "open_AdvancesPaidReport" Then
                crTables = rptpayment_dtls_paytype.Database.Tables
            ElseIf x = "open_AdvancesReceiveReport" Then
                crTables = rptrec_dtls_paytype.Database.Tables
            ElseIf x = "open_ReceiptDetails" Then
                crTables = rptreceipt_details.Database.Tables
            ElseIf x = "PAYMENTBILLWISE" Then
                crTables = RPTPAYBILLWISE.Database.Tables
            ElseIf x = "RECEIPTBILLWISE" Then
                crTables = RPTRECBILLWISE.Database.Tables
            ElseIf x = "RECEIPTMONTHLYADJ" Then
                crTables = RPTRECMONTHLYADJ.Database.Tables
            ElseIf x = "PAYMENTMONTHLYADJ" Then
                crTables = RPTPAYMONTHLYADJ.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            CRPO.SelectionFormula = strsearch
            If x = "open_PaymentDetails" Then
                CRPO.ReportSource = rptpayment_details
            ElseIf x = "open_AdvancesPaidReport" Then
                CRPO.ReportSource = rptpayment_dtls_paytype
            ElseIf x = "open_AdvancesReceiveReport" Then
                CRPO.ReportSource = rptrec_dtls_paytype
            ElseIf x = "open_ReceiptDetails" Then
                CRPO.ReportSource = rptreceipt_details
            ElseIf x = "PAYMENTBILLWISE" Then
                CRPO.ReportSource = RPTPAYBILLWISE
            ElseIf x = "RECEIPTBILLWISE" Then
                CRPO.ReportSource = RPTRECBILLWISE
            ElseIf x = "RECEIPTMONTHLYADJ" Then
                CRPO.ReportSource = RPTRECMONTHLYADJ
                RPTRECMONTHLYADJ.DataDefinition.FormulaFields("PERIOD").Text = "' RECEIPT MONTHLY ADJUSTMENT SUMMARY - " & PERIOD & "'"
            ElseIf x = "PAYMENTMONTHLYADJ" Then
                CRPO.ReportSource = RPTPAYMONTHLYADJ
                RPTPAYMONTHLYADJ.DataDefinition.FormulaFields("PERIOD").Text = "' PAYMENT MONTHLY ADJUSTMENT SUMMARY - " & PERIOD & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try

            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()

            If x = "open_PaymentDetails" Then
                tempattachment = "PAYMENTDETAILS"
            ElseIf x = "open_AdvancesPaidReport" Then
                tempattachment = "ADVANCEPAID"
            ElseIf x = "open_AdvancesReceiveReport" Then
                tempattachment = "ADVANCERECEIVED"
            ElseIf x = "open_ReceiptDetails" Then
                tempattachment = "RECEIPTDETAILS"
            ElseIf x = "PAYMENTBILLWISE" Then
                tempattachment = "PAYMENTBILLWISE"
            ElseIf x = "RECEIPTBILLWISE" Then
                tempattachment = "RECEIPTBILLWISE"
            ElseIf x = "RECEIPTMONTHLYADJ" Or x = "PAYMENTMONTHLYADJ" Then
                tempattachment = x
            End If


            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If x = "open_PaymentDetails" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENTDETAILS.PDF"
            ElseIf x = "open_AdvancesPaidReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\ADVANCEPAID.PDF"
            ElseIf x = "open_AdvancesReceiveReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\ADVANCERECEIVED.PDF"
            ElseIf x = "open_ReceiptDetails" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RECEIPTDETAILS.PDF"
            ElseIf x = "PAYMENTBILLWISE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENTBILLWISE.PDF"
            ElseIf x = "RECEIPTBILLWISE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\RECEIPTBILLWISE.PDF"
            ElseIf x = "RECEIPTMONTHLYADJ" Or x = "PAYMENTMONTHLYADJ" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\" & x & ".PDF"
            End If



            If x = "open_PaymentDetails" Then

                expo = rptpayment_details.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptpayment_details.Export()
            ElseIf x = "open_AdvancesPaidReport" Then

                expo = rptpayment_dtls_paytype.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptpayment_dtls_paytype.Export()
            ElseIf x = "open_AdvancesReceiveReport" Then

                expo = rptrec_dtls_paytype.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptrec_dtls_paytype.Export()
            ElseIf x = "open_ReceiptDetails" Then

                expo = rptreceipt_details.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptreceipt_details.Export()

            ElseIf x = "PAYMENTBILLWISE" Then

                expo = RPTPAYBILLWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYBILLWISE.Export()

            ElseIf x = "RECEIPTBILLWISE" Then

                expo = RPTRECBILLWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRECBILLWISE.Export()

            ElseIf x = "RECEIPTMONTHLYADJ" Then

                expo = RPTRECMONTHLYADJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRECMONTHLYADJ.Export()

            ElseIf x = "PAYMENTMONTHLYADJ" Then

                expo = RPTPAYMONTHLYADJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYMONTHLYADJ.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            If x = "open_PaymentDetails" Then
                tempattachment = "PAYMENTDETAILS"
            ElseIf x = "open_AdvancesPaidReport" Then
                tempattachment = "ADVANCEPAID"
            ElseIf x = "open_AdvancesReceiveReport" Then
                tempattachment = "ADVANCERECEIVED"
            ElseIf x = "open_ReceiptDetails" Then
                tempattachment = "RECEIPTDETAILS"
            ElseIf x = "PAYMENTBILLWISE" Then
                tempattachment = "PAYMENTBILLWISE"
            ElseIf x = "RECEIPTBILLWISE" Then
                tempattachment = "RECEIPTBILLWISE"
            ElseIf x = "RECEIPTMONTHLYADJ" Or x = "PAYMENTMONTHLYADJ" Then
                tempattachment = x
            End If

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\" & tempattachment & ".PDF")
            OBJWHATSAPP.FILENAME.Add(tempattachment & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class