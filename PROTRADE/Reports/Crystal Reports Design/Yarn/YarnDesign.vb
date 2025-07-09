
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class YarnDesign

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""
    Public PERIOD As String = ""
    Public FROMDATE As Date
    Public TODATE As Date
    Public PARTYNAME As String
    Public AGENTNAME As String

    Dim RPTYARNISSUEKNITTING As New YarnIssueKnittingReport
    Dim RPTYARNISSUE As New YarnIssueReport

    Dim RPTYARNRECD As New YarnRecdReport

    Dim RPTCHALLAN As New YarnChallanReport

    Dim RPTYARNSO As New YarnSOReport

    Private Sub StockDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub BeamIssueDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "YARNISSUEKNITTING" Then crTables = RPTYARNISSUEKNITTING.Database.Tables
            If FRMSTRING = "YARNISSUE" Then crTables = RPTYARNISSUE.Database.Tables
            If FRMSTRING = "YARNRECD" Then crTables = RPTYARNRECD.Database.Tables
            If FRMSTRING = "YARNCHALLAN" Then crTables = RPTCHALLAN.Database.Tables
            If FRMSTRING = "YARNSO" Then crTables = RPTYARNSO.Database.Tables



            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "YARNISSUEKNITTING" Then
                crpo.ReportSource = RPTYARNISSUEKNITTING

            ElseIf FRMSTRING = "YARNISSUE" Then
                crpo.ReportSource = RPTYARNISSUE

            ElseIf FRMSTRING = "YARNRECD" Then
                crpo.ReportSource = RPTYARNRECD

            ElseIf FRMSTRING = "YARNCHALLAN" Then
                crpo.ReportSource = RPTCHALLAN

            ElseIf FRMSTRING = "YARNSO" Then
                crpo.ReportSource = RPTYARNSO
            End If


            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = ""
            If FRMSTRING = "YARNISSUEKNITTING" Or FRMSTRING = "YARNISSUE" Then
                TEMPATTACHMENT = "YARN ISSUE"
            ElseIf FRMSTRING = "YARNRECD" Then
                TEMPATTACHMENT = "YARN RECD"
            ElseIf FRMSTRING = "YARNCHALLAN" Then
                TEMPATTACHMENT = "YARN CHALLAN"
            ElseIf FRMSTRING = "YARNSO" Then
                TEMPATTACHMENT = "YARN SO"
            End If
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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "YARNISSUEKNITTING" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\YARN ISSUE.pdf"
                expo = RPTYARNISSUEKNITTING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNISSUEKNITTING.Export()

            ElseIf FRMSTRING = "YARNISSUE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\YARN ISSUE.pdf"
                expo = RPTYARNISSUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNISSUE.Export()

            ElseIf FRMSTRING = "YARNRECD" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\YARN RECD.pdf"
                expo = RPTYARNRECD.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNRECD.Export()

            ElseIf FRMSTRING = "YARNCHALLAN" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\YARN CHALLAN.pdf"
                expo = RPTCHALLAN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHALLAN.Export()

            ElseIf FRMSTRING = "YARNSO" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\YARN SO.pdf"
                expo = RPTYARNSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTYARNSO.Export()

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
            If FRMSTRING = "YARNISSUEKNITTING" Or FRMSTRING = "YARNISSUE" Then
                OBJWHATSAPP.PATH.Add(Application.StartupPath & "\YARN ISSUE.PDF")
                OBJWHATSAPP.FILENAME.Add("YARN ISSUE.pdf")
            ElseIf FRMSTRING = "YARNRECD" Then
                OBJWHATSAPP.PATH.Add(Application.StartupPath & "\YARN RECD.PDF")
                OBJWHATSAPP.FILENAME.Add("YARN RECD.pdf")
            ElseIf FRMSTRING = "YARNCHALLAN" Then
                OBJWHATSAPP.PATH.Add(Application.StartupPath & "\YARN CHALLAN.PDF")
                OBJWHATSAPP.FILENAME.Add("YARN CHALLAN.pdf")
            ElseIf FRMSTRING = "YARNSO" Then
                OBJWHATSAPP.PATH.Add(Application.StartupPath & "\YARN SO.PDF")
                OBJWHATSAPP.FILENAME.Add("YARN SO.pdf")
            End If
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class