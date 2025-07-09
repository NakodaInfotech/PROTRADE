
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class TDSDesign


    Public WHERECLAUSE As String
    Public PERIOD As String
    Public FRMSTRING As String

    Public Bankname As String
    Public NEWPAGE As Boolean
    Public ADDRESS As Integer

    Dim RPTPARTY As New TDSPartyWiseReport
    Dim RPTPARTYSUMM As New TDSPartyWiseSummReport

    Dim RPTTCSPARTY As New TCSPartyWiseReport
    Dim RPTTCSPARTYSUMM As New TCSPartyWiseSummReport

    Private Sub TDSDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "TDSPARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables
            If FRMSTRING = "TDSPARTYWISE" Then crTables = RPTPARTY.Database.Tables
            If FRMSTRING = "TCSPARTYWISESUMM" Then crTables = RPTTCSPARTYSUMM.Database.Tables
            If FRMSTRING = "TCSPARTYWISE" Then crTables = RPTTCSPARTY.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "TDSPARTYWISESUMM" Then
                CRPO.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.GroupFooterSection2.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTPARTYSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TDSPARTYWISE" Then
                CRPO.ReportSource = RPTPARTY
                RPTPARTY.GroupFooterSection2.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTPARTY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "TCSPARTYWISESUMM" Then
                CRPO.ReportSource = RPTTCSPARTYSUMM
                RPTTCSPARTYSUMM.GroupFooterSection2.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTTCSPARTYSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTTCSPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TCSPARTYWISE" Then
                CRPO.ReportSource = RPTTCSPARTY
                RPTTCSPARTY.GroupFooterSection2.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTTCSPARTY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTTCSPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\TDS Challan.PDF"
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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\TDS Challan.PDF"

            If FRMSTRING = "TDSPARTYWISESUMM" Then
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()

            ElseIf FRMSTRING = "TDSPARTYWISE" Then
                expo = RPTPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTY.Export()

            ElseIf FRMSTRING = "TCSPARTYWISESUMM" Then
                expo = RPTTCSPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTCSPARTYSUMM.Export()

            ElseIf FRMSTRING = "TCSPARTYWISE" Then
                expo = RPTTCSPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTCSPARTY.Export()

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
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\TDS Challan.PDF")
            OBJWHATSAPP.FILENAME.Add("TDS Challan.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class