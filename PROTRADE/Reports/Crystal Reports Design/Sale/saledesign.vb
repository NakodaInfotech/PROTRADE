
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO


Public Class saledesign

    Dim RPTPROFORMAINVOICE As New ProformaInvoiceReport_TOTALLEFT


    Dim RPTINVOICE_BUYER As New InvoiceReport_Export_Buyer
    Dim RPTINVOICE_CUSTOM As New InvoiceReport_Export_Custom
    Dim RPTINVOICE_EXPGST As New InvoiceReport_Export_GST

    Dim RPTINVOICE_TOTALTRANS As New InvoiceReport_TOTALTRANS
    Dim RPTINVOICE_TOTALTRANSA4 As New InvoiceReport_TOTALTRANSA4
    Dim RPTINVOICE_TOTALLEFT As New InvoiceReport_TOTALLEFT


    Dim RPTPARTYDTLS As New InvoicePartyWiseDetails
    Dim RPTPARTYSUMM As New InvoicePartyWiseSummary
    Dim RPTAGENTDTLS As New InvoiceAgentWiseDetails
    Dim RPTAGENTSUMM As New InvoiceAgentWiseSummary
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

    Public WHERECLAUSE As String
    Public IGSTFORMAT As Boolean = False
    Public BLANKPAPER As Boolean = False
    Public PERIOD As String
    Public strsumm As String
    Public FRMSTRING As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public PARTYNAME As String
    Public AGENTNAME As String
    Public INVOICECOPYNAME As String
    Public INVOICETRANS As Boolean
    Public INVNO As Integer
    Public COMM As Double
    Public PRINTSETTING As Object = Nothing
    Public PARTYCHANGEADD As String = ""
    Public EFFECTIVERATE As Boolean = False

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Dim tempattachment As String
    Public NOOFCOPIES As Integer = 1

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()

            If FRMSTRING = "" Then
                tempattachment = "SALEDETAILS"
            ElseIf FRMSTRING = "INVOICE" Then
                tempattachment = "INVOICE"
            ElseIf FRMSTRING = "PROFORMAINVOICE" Then
                tempattachment = "PROFORMA"
            Else
                tempattachment = "SALESUMMARY"
            End If

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = PARTYNAME
            OBJWHATSAPP.AGENTNAME = AGENTNAME
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\" & tempattachment & ".PDF")
            OBJWHATSAPP.FILENAME.Add(tempattachment & ".pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, FROMDATE)
        a2 = DatePart(DateInterval.Month, FROMDATE)
        a3 = DatePart(DateInterval.Year, FROMDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TODATE)
        a12 = DatePart(DateInterval.Month, TODATE)
        a13 = DatePart(DateInterval.Year, TODATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub saledesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If


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


            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTAGENTDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTAGENTSUMM.Database.Tables

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


            If FRMSTRING = "EXPBUYER" Then
                crTables = RPTINVOICE_BUYER.Database.Tables
                Me.Text = "Buyer Invoice"
            End If
            If FRMSTRING = "EXPCUSTOM" Then
                crTables = RPTINVOICE_CUSTOM.Database.Tables
                Me.Text = "Custom Invoice"
            End If
            If FRMSTRING = "EXPGST" Then
                crTables = RPTINVOICE_EXPGST.Database.Tables
                Me.Text = "GST Invoice"
            End If

            If FRMSTRING = "PROFORMAINVOICE" Then crTables = RPTPROFORMAINVOICE.Database.Tables


            If FRMSTRING = "INVOICE" Then

                'CODE DONE BY GULKIT
                If INVOICETRANS = True Then
                    If TRANSPORTCOPYA4 Then
                        crTables = RPTINVOICE_TOTALTRANSA4.Database.Tables
                    Else
                        crTables = RPTINVOICE_TOTALTRANS.Database.Tables
                    End If
                    GoTo SKIPINVOICE
                End If

                crTables = RPTINVOICE_TOTALLEFT.Database.Tables
            End If

SKIPINVOICE:

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            getFromToDate()

            If FRMSTRING <> "INVOICE" And FRMSTRING <> "EXPBUYER" And FRMSTRING <> "EXPCUSTOM" And FRMSTRING <> "EXPGST" And FRMSTRING <> "PROFORMAINVOICE" Then
                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues

                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = Locationid
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = YearId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "INVOICE" Then

                'CODE DONE BY GULKIT
                If INVOICETRANS = True Then
                    If TRANSPORTCOPYA4 Then
                        CRPO.ReportSource = RPTINVOICE_TOTALTRANSA4
                    Else
                        CRPO.ReportSource = RPTINVOICE_TOTALTRANS
                    End If
                    CRPO.Zoom(100)
                    CRPO.Refresh()
                    Exit Sub
                End If


                CRPO.ReportSource = RPTINVOICE_TOTALLEFT
                RPTINVOICE_TOTALLEFT.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then RPTINVOICE_TOTALLEFT.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_TOTALLEFT.DataDefinition.FormulaFields("WHITELABEL").Text = 0


            ElseIf FRMSTRING = "PROFORMAINVOICE" Then
                CRPO.ReportSource = RPTPROFORMAINVOICE
                RPTPROFORMAINVOICE.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then RPTPROFORMAINVOICE.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTPROFORMAINVOICE.DataDefinition.FormulaFields("WHITELABEL").Text = 0

            ElseIf FRMSTRING = "EXPBUYER" Then
                CRPO.ReportSource = RPTINVOICE_BUYER
                RPTINVOICE_BUYER.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then RPTINVOICE_BUYER.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_BUYER.DataDefinition.FormulaFields("WHITELABEL").Text = 0
            ElseIf FRMSTRING = "EXPCUSTOM" Then
                CRPO.ReportSource = RPTINVOICE_CUSTOM
                RPTINVOICE_CUSTOM.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then RPTINVOICE_CUSTOM.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_CUSTOM.DataDefinition.FormulaFields("WHITELABEL").Text = 0
            ElseIf FRMSTRING = "EXPGST" Then
                CRPO.ReportSource = RPTINVOICE_EXPGST
                RPTINVOICE_EXPGST.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then RPTINVOICE_EXPGST.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_EXPGST.DataDefinition.FormulaFields("WHITELABEL").Text = 0


            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                CRPO.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                CRPO.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                CRPO.ReportSource = RPTAGENTDTLS
                RPTAGENTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                CRPO.ReportSource = RPTAGENTDTLS
                RPTAGENTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                CRPO.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                CRPO.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                CRPO.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                CRPO.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                CRPO.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                CRPO.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                CRPO.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                CRPO.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

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


            Dim OBJ As New Object
            If FRMSTRING = "INVOICE" Then

                strsearch = strsearch & " {INVOICEMASTER.INVOICE_no}= " & INVNO & " AND {REGISTERMASTER.REGISTER_NAME} = '" & registername & "' AND {INVOICEMASTER.INVOICE_cmpid} = " & CmpId & " AND {INVOICEMASTER.INVOICE_locationid} = " & Locationid & " AND {INVOICEMASTER.INVOICE_yearid} = " & YearId
                CRPO.SelectionFormula = strsearch

                If INVOICETRANS = True Then
                    If TRANSPORTCOPYA4 Then
                        OBJ = New InvoiceReport_TOTALTRANSA4
                    Else
                        OBJ = New InvoiceReport_TOTALTRANS
                    End If
                    GoTo SKIPINVOICE
                End If

                'FOR COMMON REPORTS
                OBJ = New InvoiceReport_TOTALLEFT
                OBJ.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"


            ElseIf FRMSTRING = "PROFORMAINVOICE" Then
                OBJ = New ProformaInvoiceReport_TOTALLEFT
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
                If FRMSTRING = "INVOICE" Then oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE_" & INVNO & ".pdf" Else oDfDopt.DiskFileName = Application.StartupPath & "\PROFORMA_" & INVNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)

                expo = OBJ.ExportOptions
                If ClientName <> "KCRAYON" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                If ClientName <> "KCRAYON" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try

            Dim emailid As String = ""
            Dim emailid1 As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()

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


            Dim objmail As New SendMail

            If FRMSTRING = "" Then
                tempattachment = "SALEDETAILS"
                objmail.subject = "Invoice Details"

            ElseIf FRMSTRING = "INVOICE" Then
                tempattachment = "INVOICE"
                objmail.subject = "Invoice"

            ElseIf FRMSTRING = "PROFORMAINVOICE" Then
                tempattachment = "PROFORMA"
                objmail.subject = "Proforma Invoice"

            Else
                tempattachment = "SALESUMMARY"
                objmail.subject = "Invoice Summary"


            End If

            'Dim OBJCMN As New ClsCommon
            'Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
            'If dt.Rows.Count > 0 Then objmail.cmbfirstadd.Text = dt.Rows(0).Item("EMAILID")


            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"


            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            If emailid1 <> "" Then
                objmail.cmbsecondadd.Text = emailid1
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SALEDETAILS.PDF"
                '   expo = rpts.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                '   rpts.Export()
            ElseIf FRMSTRING = "INVOICE" Then


                If INVOICETRANS = True Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.PDF"
                    If TRANSPORTCOPYA4 Then
                        expo = RPTINVOICE_TOTALTRANSA4.ExportOptions
                        RPTINVOICE_TOTALTRANSA4.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTINVOICE_TOTALTRANSA4.Export()
                        RPTINVOICE_TOTALTRANSA4.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                    Else
                        expo = RPTINVOICE_TOTALTRANS.ExportOptions
                        RPTINVOICE_TOTALTRANS.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTINVOICE_TOTALTRANS.Export()
                        RPTINVOICE_TOTALTRANS.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                    End If
                    Exit Sub
                End If

                RPTINVOICE_TOTALLEFT.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.PDF"
                expo = RPTINVOICE_TOTALLEFT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_TOTALLEFT.Export()
                RPTINVOICE_TOTALLEFT.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

            ElseIf FRMSTRING = "PROFORMAINVOICE" Then
                RPTPROFORMAINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\PROFORMA.PDF"
                expo = RPTPROFORMAINVOICE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPROFORMAINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                RPTPROFORMAINVOICE.Export()

            ElseIf FRMSTRING = "EXPBUYER" Then
                expo = RPTINVOICE_BUYER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_BUYER.Export()

            ElseIf FRMSTRING = "EXPCUSTOM" Then
                expo = RPTINVOICE_CUSTOM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_CUSTOM.Export()

            ElseIf FRMSTRING = "EXPGST" Then
                expo = RPTINVOICE_EXPGST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_EXPGST.Export()

            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\SALESUMMARY.PDF"
                '  expo = rptssum.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                'rptssum.Export()
            End If

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
                expo = RPTAGENTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTAGENTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTSUMM.Export()
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
                'ElseIf FRMSTRING = "MONTHLY" Then
                '    expo = RPTMONTHLY.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTMONTHLY.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
End Class