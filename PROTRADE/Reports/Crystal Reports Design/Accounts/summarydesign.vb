
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class summarydesign

    Dim rptjsum As New Journalsummary
    Dim rptcsum As New contrasummary
    ' Dim rptledsum As New LedgerSummaryReport
    Dim rptGROUPsum As New GroupSummaryReport
    Public frmstring As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String

    Private Sub summarydesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If frmstring = "Contra-Summary" Then
                crTables = rptcsum.Database.Tables
            ElseIf frmstring = "LEDGERSUMMARY" Then
                'crTables = rptledsum.Database.Tables
            ElseIf frmstring = "GROUPSUMMARY" Then
                crTables = rptGROUPsum.Database.Tables
            Else
                crTables = rptjsum.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************

            If frmstring = "Contra-Summary" Then
                strsearch = strsearch & " and  ({CONTRA.CONTRA_cmpid}=" & CmpId & " AND {CONTRA.CONTRA_LOCATIONid}=" & Locationid & " AND {CONTRA.CONTRA_YEARid}=" & YearId & ")"
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = rptcsum
            ElseIf frmstring = "LEDGERSUMMARY" Then

                'crParameterFieldDefinitions = rptledsum.DataDefinition.ParameterFields

                'crParameterDiscreteValue.Value = strsearch
                'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@WHERECLAUSE")
                'crParameterValues = crParameterFieldDefinition.CurrentValues
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crParameterDiscreteValue.Value = CmpId
                'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                'crParameterValues = crParameterFieldDefinition.CurrentValues
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crParameterDiscreteValue.Value = Locationid
                'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                'crParameterValues = crParameterFieldDefinition.CurrentValues
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'crParameterDiscreteValue.Value = YearId
                'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                'crParameterValues = crParameterFieldDefinition.CurrentValues
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'CRPO.ReportSource = rptledsum

            ElseIf frmstring = "GROUPSUMMARY" Then

                crParameterFieldDefinitions = rptGROUPsum.DataDefinition.ParameterFields

                crParameterDiscreteValue.Value = strsearch
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@WHERECLAUSE")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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

                CRPO.ReportSource = rptGROUPsum

            Else
                strsearch = strsearch & " and  ({JOURNAL.JOURNAL_cmpid}=" & CmpId & " AND {JOURNAL.JOURNAL_LOCATIONid}=" & Locationid & " AND {JOURNAL.JOURNAL_YEARid}=" & YearId & ")"
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = rptjsum
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
End Class