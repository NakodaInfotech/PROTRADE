
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class payment_advice

    Public payno As Integer
    Public payname As String
    Public REGNAME As String
    Public FRMSTRING As String
    Public LEDGERSNAME As String
    Public NEFTRTGSNORMAL As String = "PARTY"
    Public FROMNO, TONO As Integer
    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public SHOWNARR As Integer = 0


    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1


    Dim obj_paytype As New Paymentreport
    Dim OBJPAYREG As New PaymentRegisterReport

    Dim OBJCHQPAY As New ChqPayment
    Dim OBJCHQPAY_UNION As New ChqPayment_UNION
    Dim OBJCHQPAY_INDUS As New ChqPayment_INDUS
    Dim OBJCHQPAY_KOTAK As New ChqPayment_KOTAK
    Dim OBJCHQPAY_CORP As New ChqPayment_CORPORATION
    Dim OBJCHQPAY_HDFC As New ChqPayment_HDFC
    Dim OBJCHQPAY_CITIBANK As New ChqPayment_CITIBANK
    Dim OBJCHQPAY_SKF As New ChqPaymentIDBI_SKF
    Dim OBJCHQPAY_SYNDICATE As New ChqPayment_Syndicate
    Dim OBJCHQPAY_CANARA As New ChqPayment_Canara
    Dim OBJCHQPAY_ICICI As New ChqPayment_ICICI
    Dim OBJCHQPAY_STANDARD As New ChqPayment_STANDARDCHAR
    Dim OBJCHQPAY_MAHESH As New ChqPayment_MAHESH

    Dim OBJENVELOPE As New EnvelopeReport
    Dim OBJENVELOPE_SMALL As New EnvelopeReport_SMALL

    Private Sub payment_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub payment_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try
            If DIRECTPRINT = True Then
                If FRMSTRING = "CHQPRINT" Then
                    PRINTDIRECTLYTOPRINTER()
                Else
                    PRINTDIRECTADVICE()
                End If
                Exit Sub
            End If


            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "CHQPRINT" Then
                If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SHREEVALLABH" Then
                    crTables = OBJCHQPAY_HDFC.Database.Tables
                ElseIf ClientName = "SAKARIA" Then
                    crTables = OBJCHQPAY_CITIBANK.Database.Tables
                ElseIf ClientName = "AXIS" Or ClientName = "SBA" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "SHUBHI" Then
                    crTables = OBJCHQPAY_UNION.Database.Tables
                ElseIf ClientName = "SPCORP" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Or ClientName = "MOHAN" Then
                    crTables = OBJCHQPAY_KOTAK.Database.Tables
                ElseIf ClientName = "CHANDRA" Then
                    crTables = OBJCHQPAY_SYNDICATE.Database.Tables
                ElseIf ClientName = "SKF" Then
                    crTables = OBJCHQPAY_SKF.Database.Tables
                ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                    crTables = OBJCHQPAY_CANARA.Database.Tables
                ElseIf ClientName = "MNARESH" Or ClientName = "SUPRIYA" Then
                    crTables = OBJCHQPAY_ICICI.Database.Tables
                ElseIf ClientName = "PARAS" Then
                    crTables = OBJCHQPAY_STANDARD.Database.Tables
                ElseIf ClientName = "DETLINE" Then
                    crTables = OBJCHQPAY_MAHESH.Database.Tables
                Else
                    crTables = OBJCHQPAY.Database.Tables
                End If
            ElseIf FRMSTRING = "PAYREGISTER" Then
                crTables = OBJPAYREG.Database.Tables
            ElseIf FRMSTRING = "ENVELOPE" Then
                If ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then
                    crTables = OBJENVELOPE_SMALL.Database.Tables
                Else
                    crTables = OBJENVELOPE.Database.Tables
                End If
            Else
                crTables = obj_paytype.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CHQPRINT" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SHREEVALLABH" Then
                    CRPO.ReportSource = OBJCHQPAY_HDFC
                ElseIf ClientName = "SAKARIA" Then
                    CRPO.ReportSource = OBJCHQPAY_CITIBANK
                ElseIf ClientName = "AXIS" Or ClientName = "SBA" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "SHUBHI" Then
                    CRPO.ReportSource = OBJCHQPAY_UNION
                ElseIf ClientName = "SPCORP" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Or ClientName = "MOHAN" Then
                    CRPO.ReportSource = OBJCHQPAY_KOTAK
                    OBJCHQPAY_KOTAK.DataDefinition.FormulaFields("NEFTRTGSPARTY").Text = "'" & NEFTRTGSNORMAL & "'"
                ElseIf ClientName = "CHANDRA" Then
                    CRPO.ReportSource = OBJCHQPAY_SYNDICATE
                ElseIf ClientName = "SKF" Then
                    CRPO.ReportSource = OBJCHQPAY_SKF
                ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                    CRPO.ReportSource = OBJCHQPAY_CANARA
                ElseIf ClientName = "MNARESH" Or ClientName = "SUPRIYA" Then
                    CRPO.ReportSource = OBJCHQPAY_ICICI
                ElseIf ClientName = "PARAS" Then
                    CRPO.ReportSource = OBJCHQPAY_STANDARD
                ElseIf ClientName = "DETLINE" Then
                    CRPO.ReportSource = OBJCHQPAY_MAHESH
                Else
                    CRPO.ReportSource = OBJCHQPAY
                End If

            ElseIf FRMSTRING = "PAYREGISTER" Then
                CRPO.SelectionFormula = WHERECLAUSE
                CRPO.ReportSource = OBJPAYREG
                OBJPAYREG.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                OBJPAYREG.DataDefinition.FormulaFields("SHOWNARR").Text = SHOWNARR

            ElseIf FRMSTRING = "ENVELOPE" Then
                CRPO.SelectionFormula = WHERECLAUSE
                If ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then
                    CRPO.ReportSource = OBJENVELOPE_SMALL
                Else
                    CRPO.ReportSource = OBJENVELOPE
                End If

            Else
                strsearch = strsearch & "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.CMPID} = " & CmpId & " and {PAYMENT_REPORT.LOCATIONID} = " & Locationid & " and {PAYMENT_REPORT.YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = obj_paytype
            End If


            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()

        For I As Integer = FROMNO To TONO

            Dim OBJ As Object
            If ClientName = "KCRAYON" Or ClientName = "PURVITEX" Or ClientName = "BARKHA" Or ClientName = "AVIS" Or ClientName = "CC" Or ClientName = "DILIP" Or ClientName = "SHREEVALLABH" Or ClientName = "MOOLTEX" Or ClientName = "SHREEVALLABH" Then
                OBJ = New ChqPayment_HDFC
            ElseIf ClientName = "MOHAN" Then
                OBJ = New ChqPayment_INDUS
            ElseIf ClientName = "SAKARIA" Then
                OBJ = New ChqPayment_CITIBANK
            ElseIf ClientName = "AXIS" Or ClientName = "SBA" Or ClientName = "SHUBHI" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then
                OBJ = New ChqPayment_UNION
            ElseIf ClientName = "SPCORP" Or ClientName = "NVAHAN" Or ClientName = "KDFAB" Or ClientName = "SOFTAS" Or ClientName = "MYCOT" Or ClientName = "DRDRAPES" Or ClientName = "YUMILONE" Then
                OBJ = New ChqPayment_KOTAK
            ElseIf ClientName = "CHANDRA" Then
                OBJ = New ChqPayment_Syndicate
            ElseIf ClientName = "SKF" Then
                OBJ = New ChqPaymentIDBI_SKF
            ElseIf ClientName = "DEVEN" Or ClientName = "ALENCOT" Then
                OBJ = New ChqPayment_Canara
            ElseIf ClientName = "MNARESH" Or ClientName = "SUPRIYA" Then
                OBJ = New ChqPayment_ICICI
            ElseIf ClientName = "PARAS" Then
                OBJ = New ChqPayment_STANDARDCHAR
            ElseIf ClientName = "DETLINE" Then
                OBJ = New ChqPayment_MAHESH
            Else
                OBJ = New ChqPayment
            End If


            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table

            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            crTables = OBJ.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = " {PAYMENTMASTER.PAYMENT_NO}= " & I & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
            OBJ.PrintToPrinter(1, True, 0, 0)

        Next
    End Sub

    Sub PRINTDIRECTADVICE()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            strsearch = "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {PAYMENT_REPORT.YEARID} = " & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As Object = New Paymentreport
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch


            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENT_" & payno & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        Dim objmail As New SendMail

        tempattachment = "PAYMENTREPORT"
        objmail.subject = "Payment Voucher"

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PAYMENTREPORT.PDF")
            OBJWHATSAPP.FILENAME.Add("PAYMENTREPORT.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENTREPORT.PDF"
            expo = obj_paytype.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            obj_paytype.Export()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class