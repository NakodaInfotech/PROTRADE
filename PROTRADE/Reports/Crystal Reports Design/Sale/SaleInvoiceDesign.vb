
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class SaleInvoiceDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public SELECTEDRATE As String
    Public PLREMARKS As String
    Public PLDESC As String
    Public PERIOD As String
    Public COMMISSIONONRECDAMT As Boolean
    Public FROMDATE As Date
    Public TODATE As Date
    Public RECDAMT As Decimal
    Public COMMPER As Double
    Public PENDINGSO As String
    Public NEWPAGE As Boolean
    Public BALERATE As Double = 0.0
    Public ROLLRATE As Double = 0.0

    Dim RPTPARTYDTLS As New InvoicePartyWiseDetails
    Dim RPTPARTYSUMM As New InvoicePartyWiseSummary
    Dim RPTJOBBERDTLS As New InvoiceAgentWiseDetails
    Dim RPTJOBBERSUMM As New InvoiceAgentWiseSummary
    Dim RPTITEMDTLS As New InvoiceItemWiseDetails
    Dim RPTITEMSUMM As New InvoiceItemWiseSummary
    Dim RPTQUALITYDTLS As New InvoiceQualityWiseDetails
    Dim RPTQUALITYSUMM As New InvoiceQualityWiseSummary
    Dim RPTDESIGNDTLS As New InvoiceDesignWiseDetails
    Dim RPTDESIGNSUMM As New InvoiceDesignWiseSummary
    Dim RPTSHADEDTLS As New InvoiceColorWiseDetails
    Dim RPTSHADESUMM As New InvoiceColorWiseSummary
    Dim RPTTRANSDTLS As New InvoiceTransWiseDetails
    Dim RPTTRANSSUMM As New InvoiceTransWiseSummary
    Dim RPTMONTHLY As New InvoiceMonthWise
    Dim RPTDOCDTLS As New InvoiceDocumentWiseDetails
    Dim RPTREFDTLS As New InvoiceRefNoWiseDetails
    Dim RPTCOMM As New InvoiceAgentCommReport
    Dim RPTCOMMSUMM As New InvoiceAgentCommSummReport
    Dim RPTCOMMOP As New InvoiceAgentCommOpeningReport
    Dim RPTCOMMOPSUMM As New InvoiceAgentCommSummOpeningReport
    Dim RPTTERMWISE As New InvoiceTermWiseDetails
    Dim RPTENTRYWISE As New InvoiceEntryWiseReport
    Dim RPTPARTYENTRYWISE As New InvoicePartyEntryWiseReport
    Dim RPTAGENTENTRYWISE As New InvoiceAgentPartyEntryWiseReport
    Dim RPTLOCALTRANS As New InvoiceLocalTransChgsReport
    Dim RPTTRANSWTCALC As New InvoiceTransWtCalcReport

    Dim RPTSOSTATUS As New SOStatusReport
    Dim RPTSOSTATUSDTLS As New SOStatusDetailsReport
    Dim RPTSOSTATUSDATE As New SOStatusDateWiseReport
    Dim RPTSOCUTDTLS As New SOCutWiseDetails
    Dim RPTORDERSTOCK As New SOVsStockReport


    Dim RPTPOSTATUS As New POStatusReport
    Dim RPTPOSTATUSDTLS As New POStatusDetailsReport
    Dim RPTPOSTATUSDATE As New POStatusDateWiseReport
    Dim RPTPOCUTDTLS As New POCutWiseDetails


    Dim RPTLOTREPORT As New LotStatus_Detail
    Dim RPTLOTREPORTSUMMARY As New LotStatus_Summary
    Dim RPTPENDING As New GRNPendingCheck

    Dim RPTCOVERNOTE As New CoverNoteReport
    Dim RPTLABEL As New StickerLabelReport
    Dim RPTPRICELIST As New ItemPriceListReport
    Public POSOFRMSTRING As String

    Private Sub SaleInvoiceDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            If POSOFRMSTRING = "PO" Then Me.Text = "Purchase Order"
            If POSOFRMSTRING = "SO" Then Me.Text = "Sale Order"

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

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables

            If FRMSTRING = "SOSTATUS" Then crTables = RPTSOSTATUS.Database.Tables
            If FRMSTRING = "SOSTATUSDTLS" Then crTables = RPTSOSTATUSDTLS.Database.Tables
            If FRMSTRING = "SOSTATUSDATE" Then crTables = RPTSOSTATUSDATE.Database.Tables
            If FRMSTRING = "CUTWISEDTLS" Then crTables = RPTSOCUTDTLS.Database.Tables
            If FRMSTRING = "ORDERVSSTOCK" Then crTables = RPTORDERSTOCK.Database.Tables

            If FRMSTRING = "POSTATUS" Then crTables = RPTPOSTATUS.Database.Tables
            If FRMSTRING = "POSTATUSDTLS" Then crTables = RPTPOSTATUSDTLS.Database.Tables
            If FRMSTRING = "POSTATUSDATE" Then crTables = RPTPOSTATUSDATE.Database.Tables
            If FRMSTRING = "POCUTWISEDTLS" Then crTables = RPTPOCUTDTLS.Database.Tables

            'OLD CODE
            'If FRMSTRING = "POPARTYWISEDTLS" Then crTables = RPTPOPARTYDTLS.Database.Tables
            'If FRMSTRING = "POPARTYWISESUMM" Then crTables = RPTPOPARTYSUMM.Database.Tables
            'If FRMSTRING = "POJOBBERWISEDTLS" Then crTables = RPTPOJOBBERDTLS.Database.Tables
            'If FRMSTRING = "POJOBBERWISESUMM" Then crTables = RPTPOJOBBERSUMM.Database.Tables

            If FRMSTRING = "DOCUMENT" Then crTables = RPTDOCDTLS.Database.Tables
            If FRMSTRING = "REFFNO" Then crTables = RPTREFDTLS.Database.Tables

            If FRMSTRING = "COMMISSION" Then crTables = RPTCOMM.Database.Tables
            If FRMSTRING = "COMMSUMM" Then crTables = RPTCOMMSUMM.Database.Tables
            If FRMSTRING = "COMMISSIONOP" Then crTables = RPTCOMMOP.Database.Tables
            If FRMSTRING = "COMMOPSUMM" Then crTables = RPTCOMMOPSUMM.Database.Tables

            If FRMSTRING = "COVERNOTE" Then crTables = RPTCOVERNOTE.Database.Tables
            If FRMSTRING = "LABEL" Then crTables = RPTLABEL.Database.Tables
            If FRMSTRING = "ENTRYWISE" Then crTables = RPTENTRYWISE.Database.Tables
            If FRMSTRING = "PARTYENTRYWISE" Then crTables = RPTPARTYENTRYWISE.Database.Tables
            If FRMSTRING = "AGENTENTRYWISE" Then crTables = RPTAGENTENTRYWISE.Database.Tables
            If FRMSTRING = "TERMWISE" Then crTables = RPTTERMWISE.Database.Tables

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "PENDING" Then crTables = RPTPENDING.Database.Tables
            If FRMSTRING = "FULL" Then crTables = RPTLOTREPORT.Database.Tables
            If FRMSTRING = "FULLSUMMARY" Then crTables = RPTLOTREPORTSUMMARY.Database.Tables

            If FRMSTRING = "PRICELIST" Then crTables = RPTPRICELIST.Database.Tables

            If FRMSTRING = "LOCALTRANS" Then crTables = RPTLOCALTRANS.Database.Tables
            If FRMSTRING = "TRANSWTCALC" Then crTables = RPTTRANSWTCALC.Database.Tables


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
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                crpo.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                crpo.ReportSource = RPTPARTYENTRYWISE
                RPTPARTYENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTPARTYENTRYWISE.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
            ElseIf FRMSTRING = "AGENTENTRYWISE" Then
                crpo.ReportSource = RPTAGENTENTRYWISE
                RPTAGENTENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTAGENTENTRYWISE.GroupFooterSection4.SectionFormat.EnableNewPageAfter = NEWPAGE
            ElseIf FRMSTRING = "TERMWISE" Then
                crpo.ReportSource = RPTTERMWISE
                RPTTERMWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PENDING" Then
                crpo.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "FULL" Then
                crpo.ReportSource = RPTLOTREPORT
                RPTLOTREPORT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "FULLSUMMARY" Then
                crpo.ReportSource = RPTLOTREPORTSUMMARY
                RPTLOTREPORTSUMMARY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "SOSTATUS" Then
                crpo.ReportSource = RPTSOSTATUS
                RPTSOSTATUS.DataDefinition.FormulaFields("TYPE").Text = "'" & PENDINGSO & "'"
            ElseIf FRMSTRING = "SOSTATUSDTLS" Then
                crpo.ReportSource = RPTSOSTATUSDTLS
            ElseIf FRMSTRING = "SOSTATUSDATE" Then
                crpo.ReportSource = RPTSOSTATUSDATE
                RPTSOSTATUSDATE.DataDefinition.FormulaFields("TYPE").Text = "'" & PENDINGSO & "'"
            ElseIf FRMSTRING = "CUTWISEDTLS" Then
                crpo.ReportSource = RPTSOCUTDTLS
                RPTSOCUTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ORDERVSSTOCK" Then
                crpo.ReportSource = RPTORDERSTOCK


            ElseIf FRMSTRING = "POSTATUS" Then
                crpo.ReportSource = RPTPOSTATUS
            ElseIf FRMSTRING = "POSTATUSDTLS" Then
                crpo.ReportSource = RPTPOSTATUSDTLS
            ElseIf FRMSTRING = "POSTATUSDATE" Then
                crpo.ReportSource = RPTPOSTATUSDATE
            ElseIf FRMSTRING = "POCUTWISEDTLS" Then
                crpo.ReportSource = RPTPOCUTDTLS
                RPTPOCUTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "DOCUMENT" Then
                crpo.ReportSource = RPTDOCDTLS
                RPTDOCDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "REFFNO" Then
                crpo.ReportSource = RPTREFDTLS
                RPTREFDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "COMMISSION" Then
                crpo.ReportSource = RPTCOMM
                RPTCOMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMM.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMSUMM" Then
                crpo.ReportSource = RPTCOMMSUMM
                RPTCOMMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMSUMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMSUMM.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMISSIONOP" Then
                crpo.ReportSource = RPTCOMMOP
                RPTCOMMOP.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMOP.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMOP.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMOPSUMM" Then
                crpo.ReportSource = RPTCOMMOPSUMM
                RPTCOMMOPSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMOPSUMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMOPSUMM.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If



            ElseIf FRMSTRING = "COVERNOTE" Then
                crpo.ReportSource = RPTCOVERNOTE
            ElseIf FRMSTRING = "LABEL" Then
                crpo.ReportSource = RPTLABEL

            ElseIf FRMSTRING = "PRICELIST" Then
                crpo.ReportSource = RPTPRICELIST
                RPTPRICELIST.DataDefinition.FormulaFields("HEADER").Text = "'" & PERIOD & "'"
                RPTPRICELIST.DataDefinition.FormulaFields("HEADERDESC").Text = "'" & PLDESC & "'"
                RPTPRICELIST.DataDefinition.FormulaFields("SELECTEDRATE").Text = "'" & SELECTEDRATE & "'"
                RPTPRICELIST.DataDefinition.FormulaFields("REMARKS").Text = "'" & PLREMARKS & "'"

            ElseIf FRMSTRING = "LOCALTRANS" Then
                crpo.ReportSource = RPTLOCALTRANS
                RPTLOCALTRANS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTLOCALTRANS.DataDefinition.FormulaFields("BALERATE").Text = BALERATE
                RPTLOCALTRANS.DataDefinition.FormulaFields("ROLLRATE").Text = ROLLRATE
            ElseIf FRMSTRING = "TRANSWTCALC" Then
                crpo.ReportSource = RPTTRANSWTCALC
                RPTTRANSWTCALC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTTRANSWTCALC.DataDefinition.FormulaFields("BALERATE").Text = BALERATE
                RPTTRANSWTCALC.DataDefinition.FormulaFields("ROLLRATE").Text = ROLLRATE
            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub SaleInvoiceDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "REPORT"
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\REPORT.pdf"

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
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                expo = RPTDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNDTLS.Export()
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                expo = RPTDESIGNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNSUMM.Export()
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
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                expo = RPTPARTYENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYENTRYWISE.Export()
            ElseIf FRMSTRING = "AGENTENTRYWISE" Then
                expo = RPTAGENTENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTENTRYWISE.Export()
            ElseIf FRMSTRING = "TERMWISE" Then
                expo = RPTTERMWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTERMWISE.Export()
            ElseIf FRMSTRING = "PENDING" Then
                expo = RPTPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDING.Export()
            ElseIf FRMSTRING = "FULL" Then
                expo = RPTLOTREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTREPORT.Export()
            ElseIf FRMSTRING = "FULLSUMMARY" Then
                expo = RPTLOTREPORTSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTREPORTSUMMARY.Export()

            ElseIf FRMSTRING = "SOSTATUS" Then
                expo = RPTSOSTATUS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUS.Export()
            ElseIf FRMSTRING = "SOSTATUSDTLS" Then
                expo = RPTSOSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUSDTLS.Export()
            ElseIf FRMSTRING = "SOSTATUSDATE" Then
                expo = RPTSOSTATUSDATE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUSDATE.Export()
            ElseIf FRMSTRING = "CUTWISEDTLS" Then
                expo = RPTSOCUTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOCUTDTLS.Export()
            ElseIf FRMSTRING = "ORDERVSSTOCK" Then
                expo = RPTORDERSTOCK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTORDERSTOCK.Export()

            ElseIf FRMSTRING = "POSTATUS" Then
                expo = RPTPOSTATUS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOSTATUS.Export()
            ElseIf FRMSTRING = "POSTATUSDTLS" Then
                expo = RPTPOSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOSTATUSDTLS.Export()
            ElseIf FRMSTRING = "POSTATUSDATE" Then
                expo = RPTPOSTATUSDATE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOSTATUSDATE.Export()
            ElseIf FRMSTRING = "POCUTWISEDTLS" Then
                expo = RPTPOCUTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOCUTDTLS.Export()


            ElseIf FRMSTRING = "DOCUMENT" Then
                expo = RPTDOCDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDOCDTLS.Export()
            ElseIf FRMSTRING = "REFFNO" Then
                expo = RPTREFDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREFDTLS.Export()

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


            ElseIf FRMSTRING = "PRICELIST" Then
                expo = RPTPRICELIST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPRICELIST.Export()

            ElseIf FRMSTRING = "LOCALTRANS" Then
                expo = RPTLOCALTRANS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOCALTRANS.Export()

            ElseIf FRMSTRING = "TRANSWTCALC" Then
                expo = RPTTRANSWTCALC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSWTCALC.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\REPORT.PDF")
            OBJWHATSAPP.FILENAME.Add("REPORT.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class