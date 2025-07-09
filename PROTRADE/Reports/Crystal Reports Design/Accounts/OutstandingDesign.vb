
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class OutstandingDesign

    Dim RPTOUTSTANDINGALLSUMMREC As New OutstandingReport_All_Summary_Rec
    Dim RPTOUTSTANDINGALLSUMMPAY As New OutstandingReport_All_Summary_Pay
    Dim RPTOUTSTANDINGALLDTLS As New OutstandingReport_All_Details

    Dim RPTOUTSTANDINGPAYSUMM As New OutstandingReport_Summary_Pay
    Dim RPTOUTSTANDINGRECSUMM As New OutstandingReport_Summary_Rec
    Dim RPTOUTSTANDINGPAYDTLS As New OutstandingReport_Details_Pay
    Dim RPTOUTSTANDINGRECDTLS As New OutstandingReport_Details_Rec

    Dim RPTBROKEROUTSTANDINGPAYSUMM As New OutstandingReport_Broker_Summary_Pay
    Dim RPTBROKEROUTSTANDINGRECSUMM As New OutstandingReport_Broker_Summary_Rec
    Dim RPTBROKEROUTSTANDINGPAYDTLS As New OutstandingReport_Broker_Details_Pay
    Dim RPTBROKEROUTSTANDINGRECDTLS As New OutstandingReport_Broker_Details_Rec
    Dim RPTBROKEROUTSTANDINGRECDTLSSHORT As New OutstandingReport_Broker_Details_Rec

    Dim RPTINTOUTSTANDINGREC As New OutstandingInterestReport_Rec
    Dim RPTINTOUTSTANDINGPAY As New OutstandingInterestReport_Pay

    Dim RPTOUTSTANDINGRECRUNBAL As New OutstandingReport_RunBal_Rec
    Dim RPTOUTSTANDINGPAYRUNBAL As New OutstandingReport_RunBal_Pay


    Dim RPTRECITEMOUTSTANDING As New OutstandingReport_Inventory_Details_Rec
    Dim RPTPAYITEMOUTSTANDING As New OutstandingReport_Inventory_Details_Pay


    Dim RPTRECBROKERITEMOUTSTANDING As New OutstandingReport_Broker_Inventory_Details_Rec
    Dim RPTPAYBROKERITEMOUTSTANDING As New OutstandingReport_Broker_Inventory_Details_Pay


    Dim RPTALLOUTSTANDINGREC As New OutstandingReport_AllBills_Summary_Rec
    Dim RPTALLOUTSTANDINGPAY As New OutstandingReport_AllBills_Summary_Pay

    Dim RPTONLYOUTSTANDINGREC As New OutstandingReport_AllBills_Summary_Rec
    Dim RPTONLYOUTSTANDINGPAY As New OutstandingReport_AllBills_Summary_Pay

    Dim RPTREMINDERLETTERREC As New OutstandingReport_Letter_Rec
    Dim RPTREMINDERLETTERPAY As New OutstandingReport_Letter_Pay

    Dim RPTOLDNEWREC As New MonthlyOldNew_Rec
    Dim RPTOLDNEWPAY As New MonthlyOldNew_Pay

    'NEWLY ADDED
    Public REPORTNAME As String
    Public DAYS As String
    Public TODATE As Date
    Public ADDRESS As Integer
    Public NEWPAGE As Boolean
    Public FRMSTRING As String
    Public PARTYNAME As String = ""
    Public AGENTNAME As String = ""
    Public selfor_ss As String
    Public PERIOD As String
    Public INTEREST As Double
    Public INTDAYS As Integer
    Public SHOWPRINTDATE As Integer
    Public SHOWREMARKS As Integer
    Public SHOWDETAILS As Integer
    Public MULTICMP As Integer

    Private Sub OutstandingDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

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

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then crTables = RPTOUTSTANDINGALLSUMMREC.Database.Tables
            If FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then crTables = RPTOUTSTANDINGALLSUMMPAY.Database.Tables
            If FRMSTRING = "OUTSTANDINGALLDTLS" Then crTables = RPTOUTSTANDINGALLDTLS.Database.Tables

            If FRMSTRING = "OUTSTANDINGPAYSUMM" Then crTables = RPTOUTSTANDINGPAYSUMM.Database.Tables
            If FRMSTRING = "OUTSTANDINGRECSUMM" Then crTables = RPTOUTSTANDINGRECSUMM.Database.Tables
            If FRMSTRING = "OUTSTANDINGPAYDTLS" Then crTables = RPTOUTSTANDINGPAYDTLS.Database.Tables
            If FRMSTRING = "OUTSTANDINGRECDTLS" Then crTables = RPTOUTSTANDINGRECDTLS.Database.Tables

            If FRMSTRING = "BROKEROUTSTANDINGPAYSUMM" Then crTables = RPTBROKEROUTSTANDINGPAYSUMM.Database.Tables
            If FRMSTRING = "BROKEROUTSTANDINGRECSUMM" Then crTables = RPTBROKEROUTSTANDINGRECSUMM.Database.Tables
            If FRMSTRING = "BROKEROUTSTANDINGPAYDTLS" Then crTables = RPTBROKEROUTSTANDINGPAYDTLS.Database.Tables
            If FRMSTRING = "BROKEROUTSTANDINGRECDTLS" Then crTables = RPTBROKEROUTSTANDINGRECDTLS.Database.Tables

            If FRMSTRING = "INTOUTSTANDINGREC" Then crTables = RPTINTOUTSTANDINGREC.Database.Tables
            If FRMSTRING = "INTOUTSTANDINGPAY" Then crTables = RPTINTOUTSTANDINGPAY.Database.Tables

            If FRMSTRING = "OUTSTANDINGRECRUNBALDTLS" Then crTables = RPTOUTSTANDINGRECRUNBAL.Database.Tables
            If FRMSTRING = "OUTSTANDINGPAYRUNBALDTLS" Then crTables = RPTOUTSTANDINGPAYRUNBAL.Database.Tables

            If FRMSTRING = "RECINVENTORYOUTSTANDING" Then crTables = RPTRECITEMOUTSTANDING.Database.Tables
            If FRMSTRING = "PAYINVENTORYOUTSTANDING" Then crTables = RPTPAYITEMOUTSTANDING.Database.Tables

            If FRMSTRING = "RECBROKERINVENTORYOUTSTANDING" Then crTables = RPTRECBROKERITEMOUTSTANDING.Database.Tables
            If FRMSTRING = "PAYBROKERINVENTORYOUTSTANDING" Then crTables = RPTPAYBROKERITEMOUTSTANDING.Database.Tables

            If FRMSTRING = "ALLBILLOUTSTANDINGREC" Then crTables = RPTALLOUTSTANDINGREC.Database.Tables
            If FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then crTables = RPTALLOUTSTANDINGPAY.Database.Tables

            If FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then crTables = RPTONLYOUTSTANDINGREC.Database.Tables
            If FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then crTables = RPTONLYOUTSTANDINGPAY.Database.Tables

            If FRMSTRING = "REMINDERLETTERREC" Then crTables = RPTREMINDERLETTERREC.Database.Tables
            If FRMSTRING = "REMINDERLETTERPAY" Then crTables = RPTREMINDERLETTERPAY.Database.Tables


            If FRMSTRING = "OLDNEWREC" Then crTables = RPTOLDNEWREC.Database.Tables
            If FRMSTRING = "OLDNEWPAY" Then crTables = RPTOLDNEWPAY.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMREC
                RPTOUTSTANDINGALLSUMMREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLSUMMREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLSUMMREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTOUTSTANDINGALLSUMMREC.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLSUMMREC.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMPAY
                RPTOUTSTANDINGALLSUMMPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLSUMMPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLSUMMPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTOUTSTANDINGALLSUMMPAY.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLSUMMPAY.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLDTLS
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGALLDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLDTLS.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then

                CRPO.ReportSource = RPTOUTSTANDINGPAYSUMM
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGPAYSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTOUTSTANDINGPAYSUMM.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then

                CRPO.ReportSource = RPTOUTSTANDINGRECSUMM
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGRECSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTOUTSTANDINGRECSUMM.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGPAYDTLS
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGPAYDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 0
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTOUTSTANDINGPAYDTLS.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGRECDTLS
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGRECDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 0
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("MULTICMP").Text = MULTICMP
                crTables = RPTOUTSTANDINGRECDTLS.Database.Tables

            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYSUMM" Then

                CRPO.ReportSource = RPTBROKEROUTSTANDINGPAYSUMM
                RPTBROKEROUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTBROKEROUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTBROKEROUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTBROKEROUTSTANDINGPAYSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTBROKEROUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTBROKEROUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTBROKEROUTSTANDINGPAYSUMM.Database.Tables

            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECSUMM" Then

                CRPO.ReportSource = RPTBROKEROUTSTANDINGRECSUMM
                RPTBROKEROUTSTANDINGRECSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTBROKEROUTSTANDINGRECSUMM.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTBROKEROUTSTANDINGRECSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTBROKEROUTSTANDINGRECSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTBROKEROUTSTANDINGRECSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTBROKEROUTSTANDINGRECSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTBROKEROUTSTANDINGRECSUMM.Database.Tables

            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYDTLS" Then

                CRPO.ReportSource = RPTBROKEROUTSTANDINGPAYDTLS
                RPTBROKEROUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTBROKEROUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTBROKEROUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTBROKEROUTSTANDINGPAYDTLS.GroupFooterSection4.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTBROKEROUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTBROKEROUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTBROKEROUTSTANDINGPAYDTLS.Database.Tables

            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECDTLS" Then

                CRPO.ReportSource = RPTBROKEROUTSTANDINGRECDTLS
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTBROKEROUTSTANDINGRECDTLS.GroupFooterSection4.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTBROKEROUTSTANDINGRECDTLS.DataDefinition.FormulaFields("MULTICMP").Text = MULTICMP
                crTables = RPTBROKEROUTSTANDINGRECDTLS.Database.Tables

            ElseIf FRMSTRING = "INTOUTSTANDINGREC" Then

                CRPO.ReportSource = RPTINTOUTSTANDINGREC
                'RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                'RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                'RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                'RPTOUTSTANDINGRECDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                'RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                'crTables = RPTOUTSTANDINGRECDTLS.Database.Tables
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("INTDAYS").Text = INTDAYS
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("INTEREST").Text = INTEREST
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTINTOUTSTANDINGREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTINTOUTSTANDINGREC.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTINTOUTSTANDINGREC.Database.Tables

            ElseIf FRMSTRING = "INTOUTSTANDINGPAY" Then

                CRPO.ReportSource = RPTINTOUTSTANDINGPAY
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("INTDAYS").Text = INTDAYS
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("INTREST").Text = INTEREST
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTINTOUTSTANDINGPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTINTOUTSTANDINGPAY.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTINTOUTSTANDINGPAY.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGRECRUNBALDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGRECRUNBAL
                RPTOUTSTANDINGRECRUNBAL.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGRECRUNBAL.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGRECRUNBAL.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGRECRUNBAL.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGRECRUNBAL.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGRECRUNBAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTOUTSTANDINGRECRUNBAL.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGPAYRUNBALDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGPAYRUNBAL
                RPTOUTSTANDINGPAYRUNBAL.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGPAYRUNBAL.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTOUTSTANDINGPAYRUNBAL.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGPAYRUNBAL.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGPAYRUNBAL.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTOUTSTANDINGPAYRUNBAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTOUTSTANDINGPAYRUNBAL.Database.Tables

            ElseIf FRMSTRING = "RECINVENTORYOUTSTANDING" Then

                CRPO.ReportSource = RPTRECITEMOUTSTANDING
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTRECITEMOUTSTANDING.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 1
                RPTRECITEMOUTSTANDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTRECITEMOUTSTANDING.Database.Tables

            ElseIf FRMSTRING = "PAYINVENTORYOUTSTANDING" Then

                CRPO.ReportSource = RPTPAYITEMOUTSTANDING
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTPAYITEMOUTSTANDING.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 1
                RPTPAYITEMOUTSTANDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTPAYITEMOUTSTANDING.Database.Tables

            ElseIf FRMSTRING = "RECBROKERINVENTORYOUTSTANDING" Then

                CRPO.ReportSource = RPTRECBROKERITEMOUTSTANDING
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTRECBROKERITEMOUTSTANDING.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 1
                RPTRECBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTRECBROKERITEMOUTSTANDING.Database.Tables

            ElseIf FRMSTRING = "PAYBROKERINVENTORYOUTSTANDING" Then

                CRPO.ReportSource = RPTPAYBROKERITEMOUTSTANDING
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTPAYBROKERITEMOUTSTANDING.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 1
                RPTPAYBROKERITEMOUTSTANDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTPAYBROKERITEMOUTSTANDING.Database.Tables

            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then

                CRPO.ReportSource = RPTALLOUTSTANDINGREC
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTALLOUTSTANDINGREC.Database.Tables

            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then

                CRPO.ReportSource = RPTALLOUTSTANDINGPAY
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTALLOUTSTANDINGPAY.Database.Tables


            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then

                CRPO.ReportSource = RPTONLYOUTSTANDINGREC
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTONLYOUTSTANDINGREC.Database.Tables

            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then

                CRPO.ReportSource = RPTONLYOUTSTANDINGPAY
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTONLYOUTSTANDINGPAY.Database.Tables

            ElseIf FRMSTRING = "REMINDERLETTERREC" Then

                CRPO.ReportSource = RPTREMINDERLETTERREC
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTREMINDERLETTERREC.GroupFooterSection7.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 0
                RPTREMINDERLETTERREC.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTREMINDERLETTERREC.Database.Tables

            ElseIf FRMSTRING = "REMINDERLETTERPAY" Then

                CRPO.ReportSource = RPTREMINDERLETTERPAY
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("TODATE").Text = "#" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "#"
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTREMINDERLETTERPAY.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("SHOWREMARKS").Text = SHOWREMARKS
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("SHOWITEMDTLS").Text = 0
                RPTREMINDERLETTERPAY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crTables = RPTREMINDERLETTERPAY.Database.Tables

            ElseIf FRMSTRING = "OLDNEWPAY" Then

                CRPO.ReportSource = RPTOLDNEWPAY
                RPTOLDNEWPAY.DataDefinition.FormulaFields("SHOWDETAILS").Text = SHOWDETAILS
                RPTOLDNEWPAY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOLDNEWPAY.Database.Tables

            ElseIf FRMSTRING = "OLDNEWREC" Then

                CRPO.ReportSource = RPTOLDNEWREC
                RPTOLDNEWREC.DataDefinition.FormulaFields("SHOWDETAILS").Text = SHOWDETAILS
                RPTOLDNEWREC.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOLDNEWREC.Database.Tables
            End If

            CRPO.SelectionFormula = selfor_ss

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMREC
            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMPAY
            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLDTLS
            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then
                CRPO.ReportSource = RPTOUTSTANDINGPAYSUMM
            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then
                CRPO.ReportSource = RPTOUTSTANDINGRECSUMM
            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGPAYDTLS
            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGRECDTLS
            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYSUMM" Then
                CRPO.ReportSource = RPTBROKEROUTSTANDINGPAYSUMM
            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECSUMM" Then
                CRPO.ReportSource = RPTBROKEROUTSTANDINGRECSUMM
            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYDTLS" Then
                CRPO.ReportSource = RPTBROKEROUTSTANDINGPAYDTLS
            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECDTLS" Then
                CRPO.ReportSource = RPTBROKEROUTSTANDINGRECDTLS
            ElseIf FRMSTRING = "INTOUTSTANDINGREC" Then
                CRPO.ReportSource = RPTINTOUTSTANDINGREC
            ElseIf FRMSTRING = "INTOUTSTANDINGPAY" Then
                CRPO.ReportSource = RPTINTOUTSTANDINGPAY
            ElseIf FRMSTRING = "OUTSTANDINGRECRUNBALDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGRECRUNBAL
            ElseIf FRMSTRING = "OUTSTANDINGPAYRUNBALDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGPAYRUNBAL
            ElseIf FRMSTRING = "RECINVENTORYOUTSTANDING" Then
                CRPO.ReportSource = RPTRECITEMOUTSTANDING
            ElseIf FRMSTRING = "PAYINVENTORYOUTSTANDING" Then
                CRPO.ReportSource = RPTPAYITEMOUTSTANDING
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then
                CRPO.ReportSource = RPTALLOUTSTANDINGREC
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then
                CRPO.ReportSource = RPTALLOUTSTANDINGPAY
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then
                CRPO.ReportSource = RPTONLYOUTSTANDINGREC
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then
                CRPO.ReportSource = RPTONLYOUTSTANDINGPAY
            ElseIf FRMSTRING = "REMINDERLETTERREC" Then
                CRPO.ReportSource = RPTREMINDERLETTERREC
            ElseIf FRMSTRING = "REMINDERLETTERPAY" Then
                CRPO.ReportSource = RPTREMINDERLETTERPAY
            ElseIf FRMSTRING = "OLDNEWREC" Then
                CRPO.ReportSource = RPTOLDNEWREC
            ElseIf FRMSTRING = "OLDNEWPAY" Then
                CRPO.ReportSource = RPTOLDNEWPAY
            End If
            '************************ END *******************

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Dim emailid1 As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            Transfer()
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\Outstanding Report.PDF"

            If PARTYNAME <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            If AGENTNAME <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & AGENTNAME & "' AND ACC_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid1 = dt.Rows(0).Item(0).ToString
                End If
            End If


            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            If emailid1 <> "" Then objmail.cmbsecondadd.Text = emailid1
            objmail.subject = "OUTSTANDING"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\Outstanding Report.pdf"


            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then
                expo = RPTOUTSTANDINGALLSUMMREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLSUMMREC.Export()
            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then
                expo = RPTOUTSTANDINGALLSUMMPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLSUMMPAY.Export()
            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then
                expo = RPTOUTSTANDINGALLDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLDTLS.Export()
            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then
                expo = RPTOUTSTANDINGPAYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGPAYSUMM.Export()
            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then
                expo = RPTOUTSTANDINGRECSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGRECSUMM.Export()
            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then
                expo = RPTOUTSTANDINGPAYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGPAYDTLS.Export()
            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then
                expo = RPTOUTSTANDINGRECDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGRECDTLS.Export()
            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYSUMM" Then
                expo = RPTBROKEROUTSTANDINGPAYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBROKEROUTSTANDINGPAYSUMM.Export()
            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECSUMM" Then
                expo = RPTBROKEROUTSTANDINGRECSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBROKEROUTSTANDINGRECSUMM.Export()
            ElseIf FRMSTRING = "BROKEROUTSTANDINGPAYDTLS" Then
                expo = RPTBROKEROUTSTANDINGPAYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBROKEROUTSTANDINGPAYDTLS.Export()
            ElseIf FRMSTRING = "BROKEROUTSTANDINGRECDTLS" Then
                expo = RPTBROKEROUTSTANDINGRECDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBROKEROUTSTANDINGRECDTLS.Export()
            ElseIf FRMSTRING = "INTOUTSTANDINGREC" Then
                expo = RPTINTOUTSTANDINGREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINTOUTSTANDINGREC.Export()
            ElseIf FRMSTRING = "INTOUTSTANDINGPAY" Then
                expo = RPTINTOUTSTANDINGPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINTOUTSTANDINGPAY.Export()
            ElseIf FRMSTRING = "OUTSTANDINGRECRUNBALDTLS" Then
                expo = RPTOUTSTANDINGRECRUNBAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGRECRUNBAL.Export()
            ElseIf FRMSTRING = "OUTSTANDINGPAYRUNBALDTLS" Then
                expo = RPTOUTSTANDINGPAYRUNBAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGPAYRUNBAL.Export()
            ElseIf FRMSTRING = "RECINVENTORYOUTSTANDING" Then
                expo = RPTRECITEMOUTSTANDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRECITEMOUTSTANDING.Export()
            ElseIf FRMSTRING = "PAYINVENTORYOUTSTANDING" Then
                expo = RPTPAYITEMOUTSTANDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYITEMOUTSTANDING.Export()
            ElseIf FRMSTRING = "RECBROKERINVENTORYOUTSTANDING" Then
                expo = RPTRECBROKERITEMOUTSTANDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRECBROKERITEMOUTSTANDING.Export()
            ElseIf FRMSTRING = "PAYBROKERINVENTORYOUTSTANDING" Then
                expo = RPTPAYBROKERITEMOUTSTANDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYBROKERITEMOUTSTANDING.Export()
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then
                expo = RPTALLOUTSTANDINGREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALLOUTSTANDINGREC.Export()
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then
                expo = RPTALLOUTSTANDINGPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALLOUTSTANDINGPAY.Export()
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then
                expo = RPTONLYOUTSTANDINGREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTONLYOUTSTANDINGREC.Export()
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then
                expo = RPTONLYOUTSTANDINGPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTONLYOUTSTANDINGPAY.Export()
            ElseIf FRMSTRING = "REMINDERLETTERREC" Then
                expo = RPTREMINDERLETTERREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREMINDERLETTERREC.Export()
            ElseIf FRMSTRING = "REMINDERLETTERPAY" Then
                expo = RPTREMINDERLETTERPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREMINDERLETTERPAY.Export()
            ElseIf FRMSTRING = "OLDNEWREC" Then
                expo = RPTOLDNEWREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOLDNEWREC.Export()
            ElseIf FRMSTRING = "OLDNEWPAY" Then
                expo = RPTOLDNEWPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOLDNEWPAY.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub OutstandingDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = PARTYNAME
            OBJWHATSAPP.AGENTNAME = AGENTNAME
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\Outstanding Report" & ".PDF")
            OBJWHATSAPP.FILENAME.Add("Outstanding Report.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class