
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class TrialBalanceDesign

    Dim rpttbdtls As New TrialBalancedetailreport
    Dim rptopclotbdtls As New TrialBalanceOPClosingReport
    Public frmstring As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public PERIOD As String

    Private Sub TrialBalanceDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub trialbalancedesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If frmstring = "TrialBalanceDetails" Then
                crTables = rpttbdtls.Database.Tables
            Else
                crTables = rptopclotbdtls.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************

            If frmstring = "TrialBalanceDetails" Then
                CRPO.SelectionFormula = strsearch
                rpttbdtls.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                CRPO.ReportSource = rpttbdtls
            Else
                rptopclotbdtls.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = rptopclotbdtls
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
        Dim tempattachment As String

        tempattachment = "TRIALBALANCE"

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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            oDfDopt.DiskFileName = Application.StartupPath & "\TRIALBALANCE.PDF"
            If frmstring = "TrialBalanceDetails" Then
                expo = rpttbdtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rpttbdtls.Export()
            Else
                expo = rptopclotbdtls.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptopclotbdtls.Export()
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
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\TRIALBALANCE.PDF")
            OBJWHATSAPP.FILENAME.Add("TRIALBALANCE.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class