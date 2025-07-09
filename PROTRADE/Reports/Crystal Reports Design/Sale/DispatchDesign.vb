
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class DispatchDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String
    Dim RPTKPLDTLS As New DispatchDailyPartyRefWiseReport
    Dim RPTPARTYITEMSHADEDTLS As New DispatchPartyItemColorWiseReport
    Dim RPTPARTYDESIGNSHADEDTLS As New DispatchDesignPartyColorWiseReport
    Dim RPTPARTYITEMDESIGNSHADEDTLS As New DispatchPartyItemDesignColorWiseReport
    Dim RPTPARTYDESIGNDTLS As New DispatchPartyDesignWiseDetailReport
    Dim RPTPARTYDTLS As New DispatchPartyWiseDetailReport
    Dim RPTPARTYSUMM As New DispatchPartyWiseSummaryReport
    Dim RPTAGENTDTLS As New DispatchAgentWiseDetailReport
    Dim RPTAGENTSUMM As New DispatchAgentWiseSummaryReport
    Dim RPTITEMDTLS As New DispatchItemWiseDetailReport
    Dim RPTITEMSUMM As New DispatchItemWiseSummaryReport
    Dim RPTQUALITYDTLS As New DispatchQualityWiseDetailReport
    Dim RPTQUALITYSUMM As New DispatchQualityWiseSummaryReport
    Dim RPTDESIGNDTLS As New DispatchDesignWiseDetailReport
    Dim RPTDESIGNSUMM As New DispatchDesignWiseSummaryReport
    Dim RPTSHADEDTLS As New DispatchShadeWiseDetailReport
    Dim RPTSHADESUMM As New DispatchShadeWiseSummaryReport
    Dim RPTGODOWNDTLS As New DispatchGodownWiseDetailReport
    Dim RPTGODOWNSUMM As New DispatchGodownWiseSummaryReport
    Dim RPTITEMSHADEMONTHLY As New DispatchItemShadeMonthlyReport
    Dim RPTITEMPARTYMONTHLY As New DispatchItemPartyMonthlyReport
    Dim RPTITEMPARTYSUMM As New DispatchItemPartySummReport
    Dim RPTITEMSHADEPARTYMONTHLY As New DispatchItemShadePartyMonthlyReport
    Dim RPTPARTYITEMMONTHLY As New DispatchPartyItemMonthlyReport

    Dim rptdispatchpartywise As New DispatchReportPartywise
    Dim rptdispatchpartydetails As New DispatchReportPartywiseDetailed
    Dim rptdispatchdesignwise As New DispatchReportDesignwise
    Dim rptdispatchdesigndetails As New DispatchReportDesignwiseDetailed

    Private Sub DispatchDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub DispatchDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

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

            If FRMSTRING = "AGENTWISEDTLS" Then crTables = RPTAGENTDTLS.Database.Tables
            If FRMSTRING = "AGENTWISESUMM" Then crTables = RPTAGENTSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTGODOWNDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTGODOWNSUMM.Database.Tables

            If FRMSTRING = "PARTYDTLS" Then crTables = rptdispatchpartydetails.Database.Tables
            If FRMSTRING = "PARTYSUMM" Then crTables = rptdispatchpartywise.Database.Tables
            If FRMSTRING = "DESIGNDTLS" Then crTables = rptdispatchdesigndetails.Database.Tables
            If FRMSTRING = "DESIGNSUMM" Then crTables = rptdispatchdesignwise.Database.Tables
            If FRMSTRING = "PARTYITEMSHADEDTLS" Then crTables = RPTPARTYITEMSHADEDTLS.Database.Tables
            If FRMSTRING = "PARTYDESIGNDTLS" Then crTables = RPTPARTYDESIGNDTLS.Database.Tables
            If FRMSTRING = "PARTYDESIGNSHADEDTLS" Then crTables = RPTPARTYDESIGNSHADEDTLS.Database.Tables
            If FRMSTRING = "PARTYITEMDESIGNSHADEDTLS" Then crTables = RPTPARTYITEMDESIGNSHADEDTLS.Database.Tables
            If FRMSTRING = "ITEMSHADEMONTHLY" Then crTables = RPTITEMSHADEMONTHLY.Database.Tables
            If FRMSTRING = "ITEMPARTYSUMM" Then crTables = RPTITEMPARTYSUMM.Database.Tables
            If FRMSTRING = "ITEMPARTYMONTHLY" Then crTables = RPTITEMPARTYMONTHLY.Database.Tables
            If FRMSTRING = "ITEMSHADEPARTYMONTHLY" Then crTables = RPTITEMSHADEPARTYMONTHLY.Database.Tables
            If FRMSTRING = "PARTYITEMMONTHLY" Then crTables = RPTPARTYITEMMONTHLY.Database.Tables
            If FRMSTRING = "KPLDTLS" Then crTables = RPTKPLDTLS.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE


            If FRMSTRING = "PARTYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                crpo.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "AGENTWISEDTLS" Then
                crpo.ReportSource = RPTAGENTDTLS
                RPTAGENTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "AGENTWISESUMM" Then
                crpo.ReportSource = RPTAGENTSUMM
                RPTAGENTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                crpo.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                crpo.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                crpo.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                crpo.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                crpo.ReportSource = RPTGODOWNDTLS
                RPTGODOWNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                crpo.ReportSource = RPTGODOWNSUMM
                RPTGODOWNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYDTLS" Then
                crpo.ReportSource = rptdispatchpartydetails
                rptdispatchpartydetails.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYSUMM" Then
                crpo.ReportSource = rptdispatchpartywise
                rptdispatchpartywise.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNDTLS" Then
                crpo.ReportSource = rptdispatchdesigndetails
                rptdispatchdesigndetails.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNSUMM" Then
                crpo.ReportSource = rptdispatchdesignwise
                rptdispatchdesignwise.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYITEMSHADEDTLS" Then
                crpo.ReportSource = RPTPARTYITEMSHADEDTLS
                RPTPARTYITEMSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYDESIGNDTLS" Then
                crpo.ReportSource = RPTPARTYDESIGNDTLS
                RPTPARTYDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYDESIGNSHADEDTLS" Then
                crpo.ReportSource = RPTPARTYDESIGNSHADEDTLS
                RPTPARTYDESIGNSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYITEMDESIGNSHADEDTLS" Then
                crpo.ReportSource = RPTPARTYITEMDESIGNSHADEDTLS
                RPTPARTYITEMDESIGNSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMSHADEMONTHLY" Then
                crpo.ReportSource = RPTITEMSHADEMONTHLY
                RPTITEMSHADEMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMPARTYSUMM" Then
                crpo.ReportSource = RPTITEMPARTYSUMM
                RPTITEMPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMPARTYMONTHLY" Then
                crpo.ReportSource = RPTITEMPARTYMONTHLY
                RPTITEMPARTYMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMSHADEPARTYMONTHLY" Then
                crpo.ReportSource = RPTITEMSHADEPARTYMONTHLY
                RPTITEMSHADEPARTYMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYITEMMONTHLY" Then
                crpo.ReportSource = RPTPARTYITEMMONTHLY
                RPTPARTYITEMMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "KPLDTLS" Then
                crpo.ReportSource = RPTKPLDTLS
                RPTKPLDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            'crpo.Zoom(100)
            'crpo.Refresh()

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
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\DISPATCH.pdf"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\DISPATCH.pdf"

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
            ElseIf FRMSTRING = "AGENTWISEDTLS" Then
                expo = RPTAGENTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTDTLS.Export()
            ElseIf FRMSTRING = "AGENTWISESUMM" Then
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
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                expo = RPTGODOWNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNDTLS.Export()
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                expo = RPTGODOWNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNSUMM.Export()
            ElseIf FRMSTRING = "PARTYDTLS" Then
                expo = rptdispatchpartydetails.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptdispatchpartydetails.Export()
            ElseIf FRMSTRING = "PARTYSUMM" Then
                expo = rptdispatchpartywise.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptdispatchpartywise.Export()
            ElseIf FRMSTRING = "DESIGNDTLS" Then
                expo = rptdispatchdesigndetails.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptdispatchdesigndetails.Export()
            ElseIf FRMSTRING = "DESIGNSUMM" Then
                expo = rptdispatchpartydetails.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptdispatchpartydetails.Export()
            ElseIf FRMSTRING = "PARTYITEMSHADEDTLS" Then
                expo = RPTPARTYITEMSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYITEMSHADEDTLS.Export()
            ElseIf FRMSTRING = "PARTYDESIGNDTLS" Then
                expo = RPTPARTYDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDESIGNDTLS.Export()
            ElseIf FRMSTRING = "PARTYDESIGNSHADEDTLS" Then
                expo = RPTPARTYDESIGNSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDESIGNSHADEDTLS.Export()
            ElseIf FRMSTRING = "PARTYITEMDESIGNSHADEDTLS" Then
                expo = RPTPARTYITEMDESIGNSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYITEMDESIGNSHADEDTLS.Export()
            ElseIf FRMSTRING = "ITEMSHADEMONTHLY" Then
                expo = RPTITEMSHADEMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSHADEMONTHLY.Export()
            ElseIf FRMSTRING = "ITEMPARTYSUMM" Then
                expo = RPTITEMPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMPARTYSUMM.Export()
            ElseIf FRMSTRING = "ITEMPARTYMONTHLY" Then
                expo = RPTITEMPARTYMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMPARTYMONTHLY.Export()
            ElseIf FRMSTRING = "ITEMSHADEPARTYMONTHLY" Then
                expo = RPTITEMSHADEPARTYMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSHADEPARTYMONTHLY.Export()
            ElseIf FRMSTRING = "PARTYITEMMONTHLY" Then
                expo = RPTPARTYITEMMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYITEMMONTHLY.Export()
            ElseIf FRMSTRING = "KPLDTLS" Then
                expo = RPTKPLDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTKPLDTLS.Export()
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
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\DISPATCH.PDF")
            OBJWHATSAPP.FILENAME.Add("DISPATCH.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class