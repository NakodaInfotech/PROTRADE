Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports PROTRADE

Public Class Journal_Contra_Design

    Dim rptJVDtls As New Journal_Details_Report
    Dim RPTJV As New JournalReport
    Dim rptContraDtls As New Contra_Detail_Report

    Public strsearch As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public FRMSTRING As String
    Dim tempattachment As String

    Public BILLNO As Integer
    Public REGNAME As String

    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing
    Public PARTYNAME As String
    Public AGENTNAME As String

    Private Sub Journal_Contra_Details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

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
                .IntegratedSecurity = False
            End With

            If FRMSTRING = "Open-ContraPartyReport" Then
                crTables = rptContraDtls.Database.Tables
            ElseIf FRMSTRING = "Open-JournalPartyReport" Then
                crTables = rptJVDtls.Database.Tables
            ElseIf FRMSTRING = "JOURNAL" Then
                crTables = RPTJV.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "Open-ContraPartyReport" Then
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                crParameterFieldDefinitions = rptContraDtls.DataDefinition.ParameterFields

                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
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


                crParameterDiscreteValue.Value = FROMDATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = TODATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                CRPO.ReportSource = rptContraDtls


            ElseIf FRMSTRING = "Open-JournalPartyReport" Then

                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

                crParameterFieldDefinitions = rptJVDtls.DataDefinition.ParameterFields

                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
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


                crParameterDiscreteValue.Value = FROMDATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = TODATE.Date
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                CRPO.ReportSource = rptJVDtls

            ElseIf FRMSTRING = "JOURNAL" Then
                CRPO.ReportSource = RPTJV
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()

        If FRMSTRING = "Open-JournalPartyReport" Then
            tempattachment = "JOURNALREPORT"
        ElseIf FRMSTRING = "Open-ContraPartyReport" Then
            tempattachment = "CONTRAREPORT"
        ElseIf FRMSTRING = "JOURNAL" Then
            tempattachment = "JOURNALREPORT"
        End If


        Try
            Dim objmail As New SendMail
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

            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            If FRMSTRING = "JOURNAL" Then
                OBJ = New JournalReport
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
                If FRMSTRING = "JOURNAL" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\JV_" & BILLNO & ".pdf"
                End If


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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "Open-JournalPartyReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOURNALREPORT.PDF"
                expo = rptJVDtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptJVDtls.Export()

            ElseIf FRMSTRING = "Open-ContraPartyReport" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\CONTRAREPORT.PDF"
                expo = rptContraDtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptContraDtls.Export()

            ElseIf FRMSTRING = "JOURNAL" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\JOURNALREPORT.PDF"
                expo = RPTJV.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJV.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()

            If FRMSTRING = "Open-JournalPartyReport" Then
                tempattachment = "JOURNALREPORT"
            ElseIf FRMSTRING = "Open-ContraPartyReport" Then
                tempattachment = "CONTRAREPORT"
            ElseIf FRMSTRING = "JOURNAL" Then
                tempattachment = "JOURNALREPORT"
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