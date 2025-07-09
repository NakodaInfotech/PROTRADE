
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class receipt_advice

    Public recno As Integer
    Public recname As String
    Public REGNAME As String
    Public FRMSTRING As String = ""

    Dim obj_rectype As New recreport

    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public SHOWNARR As Integer = 0

    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1

    Private Sub receipt_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub receipt_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTADVICE()
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
            crTables = obj_rectype.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************


            strsearch = strsearch & "  {receiptmaster.receipt_no}= " & recno & " and {RECEIPT_REPORT.REGNAME}= '" & REGNAME & "' and {ledgermaster.Acc_cmpname} = '" & recname & "' and {receiptmaster.receipt_cmpid} = " & CmpId & " and {receiptmaster.receipt_LOCATIONid} = " & Locationid & " and {receiptmaster.receipt_YEARid} = " & YearId
            CRPO.SelectionFormula = strsearch
            CRPO.ReportSource = obj_rectype
            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions



            oDfDopt.DiskFileName = Application.StartupPath & "\RECEIPTREPORT.PDF"
            expo = obj_rectype.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            obj_rectype.Export()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Sub PRINTDIRECTADVICE()
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

            strsearch = " {receiptmaster.receipt_no}= " & recno & " and {RECEIPT_REPORT.REGNAME}= '" & REGNAME & "' and {receiptmaster.receipt_YEARid} = " & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As Object = New recreport
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
                oDfDopt.DiskFileName = Application.StartupPath & "\RECEIPT_" & recno & ".pdf"

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

    Private Sub sendmailtool_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        Dim objmail As New SendMail

        tempattachment = "RECEIPTREPORT"
        objmail.subject = "Receipt Voucher"

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
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

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\RECEIPTREPORT.PDF")
            OBJWHATSAPP.FILENAME.Add("RECEIPTREPORT.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class