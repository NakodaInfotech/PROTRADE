Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class PurchaseInvoiceDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public COMMISSIONONRECDAMT As Boolean
    Public PERIOD As String
    Public COMMISSIONONPAIDAMT As Boolean
    Public PAIDAMT As Decimal
    Public COMMPER As Double
    Public SHOWNARRATION As Boolean
    Public PARTYNAME As String = ""
    Public AGENTNAME As String = ""


    Public PURRETNO As Integer = 0
    Public DIRECTPRINT As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Dim RPTPARTYDTLS As New PurchasePartyWiseDetails
    Dim RPTPARTYSUMM As New PurchasePartyWiseSummary
    Dim RPTJOBBERDTLS As New PurchaseBrokerWiseDetails
    Dim RPTJOBBERSUMM As New PurchaseBrokerWiseSummary
    Dim RPTITEMDTLS As New PurchaseItemWiseDetails
    Dim RPTITEMSUMM As New PurchaseItemWiseSummary
    Dim RPTQUALITYDTLS As New PurchaseQualityWiseDetails
    Dim RPTQUALITYSUMM As New PurchaseQualityWiseSummary
    Dim RPTSHADEDTLS As New PurchaseColorWiseDetails
    Dim RPTSHADESUMM As New PurchaseColorWiseSummary
    Dim RPTTRANSDTLS As New PurchaseTransWiseDetails
    Dim RPTTRANSSUMM As New PurchaseTransWiseSummary
    Dim RPTMONTHLY As New PurchaseInvoiceMonthWise
    Dim RPTENTRYWISE As New PurchaseEntryWiseDetails
    Dim RPTPURCHASEWISE As New PurchaseWiseDetailsReport
    Dim RPTPARTYENTRYWISE As New PurchasePartyEntryWiseReport

    Dim RPTPURRETURN As New PurchaseReturnReport
    Dim RPTPURRETURNCHALLAN As New PurchaseReturnChallanReport

    Dim RPTCOMM As New PurchaseAgentCommReport
    Dim RPTCOMMSUMM As New PurchaseAgentCommSummReport
    Dim RPTCOMMOP As New PurchaseAgentCommOpeningReport
    Dim RPTCOMMOPSUMM As New PurchaseAgentCommSummOpeningReport

    Private Sub PurchaseInvoiceDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor


            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
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

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTJOBBERDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTJOBBERSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables

         

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "ENTRYWISE" Then crTables = RPTENTRYWISE.Database.Tables
            If FRMSTRING = "PURCHASEWISE" Then crTables = RPTPURCHASEWISE.Database.Tables
            If FRMSTRING = "PARTYENTRYWISE" Then crTables = RPTPARTYENTRYWISE.Database.Tables

            If FRMSTRING = "COMMISSION" Then crTables = RPTCOMM.Database.Tables
            If FRMSTRING = "COMMSUMM" Then crTables = RPTCOMMSUMM.Database.Tables
            If FRMSTRING = "COMMISSIONOP" Then crTables = RPTCOMMOP.Database.Tables
            If FRMSTRING = "COMMOPSUMM" Then crTables = RPTCOMMOPSUMM.Database.Tables


            If FRMSTRING = "PURRETURN" Then
                crTables = RPTPURRETURN.Database.Tables
            End If

            If FRMSTRING = "PURRETURNCHALLAN" Then crTables = RPTPURRETURNCHALLAN.Database.Tables




            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "PARTYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                crpo.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                crpo.ReportSource = RPTJOBBERDTLS
                RPTJOBBERDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                crpo.ReportSource = RPTJOBBERSUMM
                RPTJOBBERSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                crpo.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                crpo.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                crpo.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                crpo.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                crpo.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
            ElseIf FRMSTRING = "ENTRYWISE" Then
                crpo.ReportSource = RPTENTRYWISE
                RPTENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PURCHASEWISE" Then
                crpo.ReportSource = RPTPURCHASEWISE
                RPTPURCHASEWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                crpo.ReportSource = RPTPARTYENTRYWISE
                RPTPARTYENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWNARRATION = True Then RPTPARTYENTRYWISE.DataDefinition.FormulaFields("SHOWNARRATION").Text = "1"
            ElseIf FRMSTRING = "COMMISSION" Then
                crpo.ReportSource = RPTCOMM
                RPTCOMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMM.DataDefinition.FormulaFields("CALCON").Text = "'" & PAIDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMSUMM" Then
                crpo.ReportSource = RPTCOMMSUMM
                RPTCOMMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMSUMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMSUMM.DataDefinition.FormulaFields("CALCON").Text = "'" & PAIDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMISSIONOP" Then
                crpo.ReportSource = RPTCOMMOP
                RPTCOMMOP.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMOP.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMOP.DataDefinition.FormulaFields("CALCON").Text = "'" & PAIDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMOPSUMM" Then
                crpo.ReportSource = RPTCOMMOPSUMM
                RPTCOMMOPSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMOPSUMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMOPSUMM.DataDefinition.FormulaFields("CALCON").Text = "'" & PAIDAMT & "'"
                End If

            ElseIf FRMSTRING = "PURRETURN" Then
                crpo.ReportSource = RPTPURRETURN
            ElseIf FRMSTRING = "PURRETURNCHALLAN" Then
                crpo.ReportSource = RPTPURRETURNCHALLAN
            End If




            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub PurchaseInvoiceDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\PurchaseReport.pdf"

            If FRMSTRING = "PARTYWISEDTLS" Then
                expo = RPTPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDTLS.Export()
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                expo = RPTJOBBERDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTJOBBERSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSUMM.Export()
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                expo = RPTTRANSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSDTLS.Export()
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                expo = RPTTRANSSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSSUMM.Export()
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                expo = RPTITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSUMM.Export()
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                expo = RPTQUALITYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYDTLS.Export()
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                expo = RPTQUALITYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYSUMM.Export()
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                expo = RPTSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADEDTLS.Export()
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                expo = RPTSHADESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADESUMM.Export()
            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            ElseIf FRMSTRING = "ENTRYWISE" Then
                expo = RPTENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTENTRYWISE.Export()
            ElseIf FRMSTRING = "PURCHASEWISE" Then
                expo = RPTPURCHASEWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPURCHASEWISE.Export()
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                expo = RPTPARTYENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYENTRYWISE.Export()
            ElseIf FRMSTRING = "PURRETURN" Then
                RPTPURRETURN.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = RPTPURRETURN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPURRETURN.Export()
                RPTPURRETURN.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

            ElseIf FRMSTRING = "PURRETURNCHALLAN" Then
                RPTPURRETURNCHALLAN.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = RPTPURRETURNCHALLAN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPURRETURNCHALLAN.Export()
                RPTPURRETURNCHALLAN.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

            ElseIf FRMSTRING = "COMMISSION" Then
                expo = RPTCOMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMM.Export()
            ElseIf FRMSTRING = "COMMSUMM" Then
                expo = RPTCOMMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMMSUMM.Export()
            ElseIf FRMSTRING = "COMMISSIONOP" Then
                expo = RPTCOMMOP.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMMOP.Export()
            ElseIf FRMSTRING = "COMMOPSUMM" Then
                expo = RPTCOMMOPSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMMOPSUMM.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "PurchaseReport.pdf"
            Dim objmail As New SendMail
            objmail.attachment = TEMPATTACHMENT
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
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

            strsearch = "{PURCHASERETURN.PR_NO}=" & Val(PURRETNO) & " and {PURCHASERETURN.PR_yearid}=" & YearId
            crpo.SelectionFormula = strsearch

            Dim OBJ As New Object
            If FRMSTRING = "PURRETURN" Then
                OBJ = New PurchaseReturnReport
            End If


SKIPINVOICE:
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
                oDfDopt.DiskFileName = Application.StartupPath & "\PURRET_" & PURRETNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)

                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PurchaseReport.PDF")
            OBJWHATSAPP.FILENAME.Add("PurchaseReport.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class