Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class purchasedesign

    Dim rptp As New PurchaseDetails
    Dim rptpsum As New purchasesummary

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Public strsumm As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim tempattachment As String

            If strsumm = "" Then tempattachment = "PURCHASEDETAILS" Else tempattachment = "PURCHASESUMMARY"
            Dim OBJWHATSAPP As New SendWhatsapp
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

    Private Sub purchasedesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If strsumm = "" Then
                crTables = rptp.Database.Tables
            Else
                crTables = rptpsum.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            'Dim crParameterFieldDefinition As ParameterFieldDefinition
            'Dim crParameterValues As New ParameterValues
            'Dim crParameterDiscreteValue As New ParameterDiscreteValue
            'If strsumm = "" Then
            '    crParameterFieldDefinitions = rptp.DataDefinition.ParameterFields
            'Else
            '    crParameterFieldDefinitions = rptpsum.DataDefinition.ParameterFields
            'End If
            'crParameterDiscreteValue.Value = CmpId
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
            'crParameterValues = crParameterFieldDefinition.CurrentValues

            'crParameterValues.Clear()
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'crParameterDiscreteValue.Value = FROMDATE.Date
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FROMDATE")
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'crParameterDiscreteValue.Value = TODATE.Date
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TODATE")
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            getFromToDate()
            '{REPORT_SP_INVOICESUMMARY.INVOICE_date}>='" & Format(FROMDATE, "MM/dd/yyyy") & "' and {REPORT_SP_INVOICESUMMARY.INVOICE_date}<='" & Format(TODATE, "MM/dd/yyyy") & "'
            'strsearch = "(" & strsearch & ")"
            strsearch = strsearch & "  and {REPORT_SP_PURCHASESUMMARY.CMPID}=" & CmpId & " and {REPORT_SP_PURCHASESUMMARY.LOCATIONID}=" & Locationid & " and {REPORT_SP_PURCHASESUMMARY.YEARID}=" & YearId
            strsearch = strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
            CRPO.SelectionFormula = strsearch

            If strsumm = "" Then
                CRPO.ReportSource = rptp
            Else
                CRPO.ReportSource = rptpsum
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

        If strsumm = "" Then
            tempattachment = "PURCHASEDETAILS"
        Else
            tempattachment = "PURCHASESUMMARY"
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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If strsumm = "" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\PURCHASEDETAILS.PDF"
                expo = rptp.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptp.Export()
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\PURCHASESUMMARY.PDF"
                expo = rptpsum.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptpsum.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class