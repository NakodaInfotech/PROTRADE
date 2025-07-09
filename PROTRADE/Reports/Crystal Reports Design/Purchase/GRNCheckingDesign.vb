
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GRNCheckingDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    'PARTY WISE REPORTS
    Dim RPTPARTYDTLS As New CheckPartyWiseDetails
    Dim RPTPARTYSUMM As New CheckPartyWiseSummary
    Dim RPTPARTYDESIGNDTLS As New CheckPartyWiseDesignDetails
    Dim RPTPARTYQUALITYDTLS As New CheckPartyWiseQualityDetails
    Dim RPTPARTYMONTHLY As New CheckPartyWiseMonthly

    'DESIGN WISE REPORTS
    Dim RPTDESIGNDTLS As New CheckDesignWiseDetails
    Dim RPTDESIGNSUMM As New CheckDesignWiseSummary
    Dim RPTDESIGNPARTYDTLS As New CheckDesignWisePartyDetails
    Dim RPTDESIGNMONTHLY As New CheckDesignWiseMonthly


    'QUALITY WISE REPORTS
    Dim RPTQUALITYDTLS As New CheckQualityWiseDetails
    Dim RPTQUALITYSUMM As New CheckQualityWiseSummary
    Dim RPTQUALITYPARTYDTLS As New CheckQualityWisePartyDetails
    Dim RPTQUALITYMONTHLY As New CheckQualityWiseMonthly


    'SHADE WISE REPORTS
    Dim RPTSHADEDTLS As New CheckShadeWiseDetails
    Dim RPTSHADESUMM As New CheckShadeWiseSummary
    Dim RPTSHADEMONTHLY As New CheckShadeWiseMonthly


    'ITEM WISE REPOIRTS
    Dim RPTITEMDTLS As New CheckItemWiseDetails
    Dim RPTITEMSUMM As New CheckItemWiseSummary
    Dim RPTITEMMONTHLY As New CheckItemWiseMonthly


    'JOBBER WISE REPORTS
    Dim RPTJOBBERDTLS As New CheckJobberWiseDetails
    Dim RPTJOBBERSUMM As New CheckJobberWiseSummary
    Dim RPTJOBBERMONTHLY As New CheckJobberWiseMonthly


    'OTHER REPORTS
    Dim RPTLOTDTLS As New CheckLotWiseDetails
    Dim RPTLOTSUMM As New CheckLotWiseSummary

    Dim RPTMONTHLY As New CheckMonthWise

    Private Sub GDNDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNCheckingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If FRMSTRING = "PARTYDESIGNWISEDTLS" Then crTables = RPTPARTYDESIGNDTLS.Database.Tables
            If FRMSTRING = "PARTYWISEMONTHLY" Then crTables = RPTPARTYMONTHLY.Database.Tables
            If FRMSTRING = "PARTYQUALITYWISEDTLS" Then crTables = RPTPARTYQUALITYDTLS.Database.Tables


            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTJOBBERDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTJOBBERSUMM.Database.Tables
            If FRMSTRING = "JOBBERWISEMONTHLY" Then crTables = RPTJOBBERMONTHLY.Database.Tables


            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables
            If FRMSTRING = "ITEMWISEMONTHLY" Then crTables = RPTITEMMONTHLY.Database.Tables


            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables
            If FRMSTRING = "QUALITYPARTYWISEDTLS" Then crTables = RPTQUALITYPARTYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISEMONTHLY" Then crTables = RPTQUALITYMONTHLY.Database.Tables



            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables
            If FRMSTRING = "DESIGNPARTYWISEDTLS" Then crTables = RPTDESIGNPARTYDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISEMONTHLY" Then crTables = RPTDESIGNMONTHLY.Database.Tables



            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables
            If FRMSTRING = "SHADEWISEMONTHLY" Then crTables = RPTSHADEMONTHLY.Database.Tables


            If FRMSTRING = "LOTWISEDTLS" Then crTables = RPTLOTDTLS.Database.Tables
            If FRMSTRING = "LOTWISESUMM" Then crTables = RPTLOTDTLS.Database.Tables


            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables

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
            ElseIf FRMSTRING = "PARTYDESIGNWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDESIGNDTLS
                RPTPARTYDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISEMONTHLY" Then
                crpo.ReportSource = RPTPARTYMONTHLY
                RPTPARTYMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYQUALITYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYQUALITYDTLS
                RPTPARTYQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                crpo.ReportSource = RPTJOBBERDTLS
                RPTJOBBERDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                crpo.ReportSource = RPTJOBBERSUMM
                RPTJOBBERSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEMONTHLY" Then
                crpo.ReportSource = RPTJOBBERMONTHLY
                RPTJOBBERMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEMONTHLY" Then
                crpo.ReportSource = RPTITEMMONTHLY
                RPTITEMMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                crpo.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYPARTYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYPARTYDTLS
                RPTQUALITYPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEMONTHLY" Then
                crpo.ReportSource = RPTQUALITYMONTHLY
                RPTQUALITYMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                crpo.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNPARTYWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNPARTYDTLS
                RPTDESIGNPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEMONTHLY" Then
                crpo.ReportSource = RPTDESIGNMONTHLY
                RPTDESIGNMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                crpo.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                crpo.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEMONTHLY" Then
                crpo.ReportSource = RPTSHADEMONTHLY
                RPTSHADEMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "LOTWISEDTLS" Then
                crpo.ReportSource = RPTLOTDTLS
                RPTLOTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "LOTWISESUMM" Then
                crpo.ReportSource = RPTLOTSUMM
                RPTLOTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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
            Dim TEMPATTACHMENT As String = "GRN"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN.pdf"

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
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                expo = RPTJOBBERDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTJOBBERSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSUMM.Export()
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
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class