
Imports BL
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class CrDrNoteDesign

    Public BILLNO As Integer
    Public REGNAME As String
    Public FRMSTRING As String
    Dim OBJCRNOTE As New CreditNoteReport
    Dim OBJCRNOTEA5 As New CreditNoteReportA5
    Dim OBJDRNOTE As New DebitNoteReport
    Dim OBJDRNOTEA5 As New DebitNoteReportA5
    Dim OBJPROFORMACRNOTE As New ProformaCreditNoteReport
    Dim OBJPROFORMADRNOTE As New ProformaDebitNoteReport
    Public printst As Boolean
    Public printot As Boolean

    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing
    Dim tempattachment As String
    Public PARTYNAME As String
    Public AGENTNAME As String

    Private Sub CrDrNoteDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

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

            'RPTINVOICE_AKS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "CREDIT" Then
                If CNDNA5 = True Then crTables = OBJCRNOTEA5.Database.Tables Else crTables = OBJCRNOTE.Database.Tables
            ElseIf FRMSTRING = "DEBIT" Then
                If CNDNA5 = True Then crTables = OBJDRNOTEA5.Database.Tables Else crTables = OBJDRNOTE.Database.Tables
            ElseIf FRMSTRING = "PROFORMACREDIT" Then
                crTables = OBJPROFORMACRNOTE.Database.Tables
            ElseIf FRMSTRING = "PROFORMADEBIT" Then
                crTables = OBJPROFORMADRNOTE.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CREDIT" Then
                strsearch = strsearch & "  {CREDITNOTEMASTER.CN_NO}= " & BILLNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {CREDITNOTEMASTER.CN_CMPID} = " & CmpId & " and {CREDITNOTEMASTER.CN_LOCATIONID} = " & Locationid & " and {CREDITNOTEMASTER.CN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If CNDNA5 = True Then
                    CRPO.ReportSource = OBJCRNOTEA5
                    If ClientName = "ALENCOT" Then OBJCRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                Else
                    CRPO.ReportSource = OBJCRNOTE
                    If ClientName = "ALENCOT" Then OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                End If

            ElseIf FRMSTRING = "DEBIT" Then
                strsearch = strsearch & "  {DEBITNOTEMASTER.DN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {DEBITNOTEMASTER.DN_CMPID} = " & CmpId & " and {DEBITNOTEMASTER.DN_LOCATIONID} = " & Locationid & " and {DEBITNOTEMASTER.DN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If CNDNA5 = True Then
                    CRPO.ReportSource = OBJDRNOTEA5
                    If ClientName = "ALENCOT" Then OBJDRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                Else
                    CRPO.ReportSource = OBJDRNOTE
                    If ClientName = "ALENCOT" Then OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                End If

            ElseIf FRMSTRING = "PROFORMACREDIT" Then
                strsearch = strsearch & "  {PROFORMACREDITNOTEMASTER.CN_NO}= " & BILLNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PROFORMACREDITNOTEMASTER.CN_CMPID} = " & CmpId & " and {PROFORMACREDITNOTEMASTER.CN_LOCATIONID} = " & Locationid & " and {PROFORMACREDITNOTEMASTER.CN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJPROFORMACRNOTE
            ElseIf FRMSTRING = "PROFORMADEBIT" Then
                strsearch = strsearch & "  {PROFORMADEBITNOTEMASTER.DN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {PROFORMADEBITNOTEMASTER.DN_CMPID} = " & CmpId & " and {PROFORMADEBITNOTEMASTER.DN_LOCATIONID} = " & Locationid & " and {PROFORMADEBITNOTEMASTER.DN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJPROFORMADRNOTE
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

            If FRMSTRING = "CREDIT" Then
                strsearch = "  {CREDITNOTEMASTER.CN_NO}= " & BILLNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {CREDITNOTEMASTER.CN_CMPID} = " & CmpId & " and {CREDITNOTEMASTER.CN_LOCATIONID} = " & Locationid & " and {CREDITNOTEMASTER.CN_YEARID} = " & YearId
            ElseIf FRMSTRING = "DEBIT" Then
                strsearch = "  {DEBITNOTEMASTER.DN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {DEBITNOTEMASTER.DN_CMPID} = " & CmpId & " and {DEBITNOTEMASTER.DN_LOCATIONID} = " & Locationid & " and {DEBITNOTEMASTER.DN_YEARID} = " & YearId
            ElseIf FRMSTRING = "PROFORMACREDIT" Then
                strsearch = "  {PROFORMACREDITNOTEMASTER.CN_NO}= " & BILLNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PROFORMACREDITNOTEMASTER.CN_CMPID} = " & CmpId & " and {PROFORMACREDITNOTEMASTER.CN_LOCATIONID} = " & Locationid & " and {PROFORMACREDITNOTEMASTER.CN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
            ElseIf FRMSTRING = "PROFORMADEBIT" Then
                strsearch = "  {PROFORMADEBITNOTEMASTER.DN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {PROFORMADEBITNOTEMASTER.DN_CMPID} = " & CmpId & " and {PROFORMADEBITNOTEMASTER.DN_LOCATIONID} = " & Locationid & " and {PROFORMADEBITNOTEMASTER.DN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
            End If
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            If FRMSTRING = "CREDIT" Then
                If CNDNA5 = True Then OBJ = New CreditNoteReportA5 Else OBJ = New CreditNoteReport
            ElseIf FRMSTRING = "DEBIT" Then
                If CNDNA5 = True Then OBJ = New DebitNoteReportA5 Else OBJ = New DebitNoteReport
            ElseIf FRMSTRING = "PROFORMACREDIT" Then
                OBJ = New ProformaCreditNoteReport
            ElseIf FRMSTRING = "PROFORMADEBIT" Then
                OBJ = New ProformaDebitNoteReport
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
                If FRMSTRING = "CREDIT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\CN_" & BILLNO & ".pdf"
                ElseIf FRMSTRING = "DEBIT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\DN_" & BILLNO & ".pdf"
                ElseIf FRMSTRING = "PROFORMACREDIT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\CN_" & BILLNO & ".pdf"
                ElseIf FRMSTRING = "PROFORMADEBIT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\DN_" & BILLNO & ".pdf"
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Dim emailid1 As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()

        Dim objmail As New SendMail

        If FRMSTRING = "CREDIT" Or FRMSTRING = "PROFORMACREDIT" Then
            tempattachment = "CREDIT NOTE"
            objmail.subject = "Credit Note"

        ElseIf FRMSTRING = "DEBIT" Or FRMSTRING = "PROFORMADEBIT" Then
            tempattachment = "DEBIT NOTE"
            objmail.subject = "Debit Note"

        End If

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


        Try
            'Dim objmail As New SendMail
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

            If FRMSTRING = "CREDIT" Then
                If CNDNA5 = True Then
                    OBJCRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    oDfDopt.DiskFileName = Application.StartupPath & "\CREDIT NOTE.PDF"
                    expo = OBJCRNOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJCRNOTEA5.Export()
                    OBJCRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                Else
                    OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    oDfDopt.DiskFileName = Application.StartupPath & "\CREDIT NOTE.PDF"
                    expo = OBJCRNOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJCRNOTE.Export()
                    OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                End If


            ElseIf FRMSTRING = "DEBIT" Then
                If CNDNA5 = True Then
                    OBJDRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    oDfDopt.DiskFileName = Application.StartupPath & "\DEBIT NOTE.PDF"
                    expo = OBJDRNOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJDRNOTEA5.Export()
                    OBJDRNOTEA5.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                Else
                    OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    oDfDopt.DiskFileName = Application.StartupPath & "\DEBIT NOTE.PDF"
                    expo = OBJDRNOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJDRNOTE.Export()
                    OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
                End If

            ElseIf FRMSTRING = "PROFORMACREDIT" Then
                OBJPROFORMACRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\CREDIT NOTE.PDF"
                expo = OBJPROFORMACRNOTE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJPROFORMACRNOTE.Export()
                OBJPROFORMACRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

            ElseIf FRMSTRING = "PROFORMADEBIT" Then
                OBJPROFORMADRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\DEBIT NOTE.PDF"
                expo = OBJPROFORMADRNOTE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJPROFORMADRNOTE.Export()
                OBJPROFORMADRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()

            If FRMSTRING = "CREDIT" Or FRMSTRING = "PROFORMACREDIT" Then
                tempattachment = "CREDIT NOTE"

            ElseIf FRMSTRING = "DEBIT" Or FRMSTRING = "PROFORMADEBIT" Then
                tempattachment = "DEBIT NOTE"

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
End Class