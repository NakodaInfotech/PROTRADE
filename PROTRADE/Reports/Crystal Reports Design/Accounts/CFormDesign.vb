
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class CFormDesign

    Dim RPTCFORMLETTER As New CFormLetterReport
    Dim RPTCFORMSALE As New CFormSalesReport
    Dim RPTCFORMPUR As New CFormPurchaseReport
    Dim RPTVATSALE As New VATSalesReport
    Dim RPTVATPUR As New VATPurchaseReport
    Dim RPTFORMPURSUMM As New PurchaseFormWiseSummary


    Public FORMNO As String
    Public STRSEARCH As String
    Public FRMSTRING As String

    Public FROMDATE As Date
    Public TODATE As Date
    Public CHECK As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

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

    Private Sub crpo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles crpo.Load
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

            If FRMSTRING = "Letter Format" Then
                crTables = RPTCFORMLETTER.Database.Tables
            ElseIf FRMSTRING = "CFORMSALE" Then
                crTables = RPTCFORMSALE.Database.Tables
            ElseIf FRMSTRING = "CFORMPURCHASE" Then
                crTables = RPTCFORMPUR.Database.Tables
            ElseIf FRMSTRING = "VATSALE" Then
                crTables = RPTVATSALE.Database.Tables
            ElseIf FRMSTRING = "VATPURCHASE" Then
                crTables = RPTVATPUR.Database.Tables
            ElseIf FRMSTRING = "FORMPURCHASESUMMARY" Then
                crTables = RPTFORMPURSUMM.Database.Tables
           
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************
            getFromToDate()

            If FRMSTRING = "Letter Format" Then
                RPTCFORMLETTER.DataDefinition.FormulaFields("FORMNO").Text = "'" & FORMNO & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                STRSEARCH = STRSEARCH & "  and {CFORMVIEW.CMPID}=" & CmpId & "  and {CFORMVIEW.LOCATIONID}=" & Locationid & "  and {CFORMVIEW.YEARID}=" & YearId
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTCFORMLETTER
            ElseIf FRMSTRING = "CFORMSALE" Then
                RPTCFORMSALE.DataDefinition.FormulaFields("PERIOD").Text = "'" & Format(FROMDATE.Date, "dd/MM/yyyy") & " - " & Format(TODATE.Date, "dd/MM/yyyy") & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                STRSEARCH = STRSEARCH & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.CMPID}=" & CmpId & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.LOCATIONID}=" & Locationid & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.YEARID}=" & YearId
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTCFORMSALE
            ElseIf FRMSTRING = "CFORMPURCHASE" Then
                RPTCFORMPUR.DataDefinition.FormulaFields("PERIOD").Text = "'" & Format(FROMDATE.Date, "dd/MM/yyyy") & " - " & Format(TODATE.Date, "dd/MM/yyyy") & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                STRSEARCH = STRSEARCH & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.CMPID}=" & CmpId & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.LOCATIONID}=" & Locationid & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.YEARID}=" & YearId
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTCFORMPUR
            ElseIf FRMSTRING = "VATSALE" Then
                RPTVATSALE.DataDefinition.FormulaFields("PERIOD").Text = "'" & Format(FROMDATE.Date, "dd/MM/yyyy") & " - " & Format(TODATE.Date, "dd/MM/yyyy") & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                STRSEARCH = STRSEARCH & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.CMPID}=" & CmpId & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.LOCATIONID}=" & Locationid & "  and {REPORT_SP_ACCOUNTS_INVOICESUMMARY.YEARID}=" & YearId
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTVATSALE
            ElseIf FRMSTRING = "VATPURCHASE" Then
                RPTVATPUR.DataDefinition.FormulaFields("PERIOD").Text = "'" & Format(FROMDATE.Date, "dd/MM/yyyy") & " - " & Format(TODATE.Date, "dd/MM/yyyy") & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                STRSEARCH = STRSEARCH & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.CMPID}=" & CmpId & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.LOCATIONID}=" & Locationid & "  and {REPORT_SP_ACCOUNTS_PURCHASESUMMARY.YEARID}=" & YearId
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTVATPUR
            ElseIf FRMSTRING = "FORMPURCHASESUMMARY" Then
                RPTFORMPURSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & Format(FROMDATE.Date, "dd/MM/yyyy") & " - " & Format(TODATE.Date, "dd/MM/yyyy") & "'"
                STRSEARCH = STRSEARCH & " AND {@DATE} in date " & fromD & " to date " & toD
                crpo.SelectionFormula = STRSEARCH
                crpo.ReportSource = RPTFORMPURSUMM
           
            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String = ""

        If FRMSTRING = "Letter Format" Then
            tempattachment = "Form Letter"
        ElseIf FRMSTRING = "CFORMSALE" Then
            tempattachment = "CFORM-SALE"
        ElseIf FRMSTRING = "CFORMPURCHASE" Then
            tempattachment = "CFORM-PURCHASE"
        ElseIf FRMSTRING = "VATSALE" Then
            tempattachment = "VAT-SALE"
        ElseIf FRMSTRING = "VATPURCHASE" Then
            tempattachment = "VAT-PURCHASE"
        ElseIf FRMSTRING = "FORMPURCHASESUMMARY" Then
            tempattachment = "FORM-PURCHASE"
        ElseIf FRMSTRING = "FORMSALESUMMARY" Then
            tempattachment = "FORM-SALE"
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

            If FRMSTRING = "Letter Format" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Form Letter.PDF"
                expo = RPTCFORMLETTER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCFORMLETTER.Export()
            ElseIf FRMSTRING = "CFORMSALE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\CFORM-SALE.PDF"
                expo = RPTCFORMSALE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCFORMSALE.Export()
            ElseIf FRMSTRING = "CFORMPURCHASE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\CFORM-PURCHASE.PDF"
                expo = RPTCFORMPUR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCFORMPUR.Export()
            ElseIf FRMSTRING = "VATSALE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\VAT-SALE.PDF"
                expo = RPTVATSALE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVATSALE.Export()
            ElseIf FRMSTRING = "VATPURCHASE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\VAT-PURCHASE.PDF"
                expo = RPTVATPUR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVATPUR.Export()
            ElseIf FRMSTRING = "FORMPURCHASESUMMARY" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\FORM-PURCHASE.PDF"
                expo = RPTFORMPURSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFORMPURSUMM.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class