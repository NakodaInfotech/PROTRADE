
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class StoreStockDesign

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""
    Public PERIOD As String = ""
    Public FROMDATE As Date
    Public TODATE As Date

    Dim RPTSTOREITEMSTOCKSUMM As New StoreItemWiseStockReport
    Dim RPTSTOREITEMSTOCKDTLS As New StoreItemWiseStockDetailReport

    Private Sub StoreStockDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub StoreStockDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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



            If FRMSTRING = "STOREITEMSTOCKSUMM" Then crTables = RPTSTOREITEMSTOCKSUMM.Database.Tables
            If FRMSTRING = "STOREITEMSTOCKDTLS" Then crTables = RPTSTOREITEMSTOCKDTLS.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "STOREITEMSTOCKSUMM" Then
                RPTSTOREITEMSTOCKSUMM.DataDefinition.FormulaFields("PERIOD").Text = "' STORE ITEM STOCK SUMMARY - " & PERIOD & "'"
                RPTSTOREITEMSTOCKSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSTOREITEMSTOCKSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTSTOREITEMSTOCKSUMM
            ElseIf FRMSTRING = "STOREITEMSTOCKDTLS" Then
                RPTSTOREITEMSTOCKDTLS.DataDefinition.FormulaFields("PERIOD").Text = "' STORE ITEM STOCK SUMMARY - " & PERIOD & "'"
                RPTSTOREITEMSTOCKDTLS.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSTOREITEMSTOCKDTLS.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                crpo.ReportSource = RPTSTOREITEMSTOCKDTLS
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
            Dim TEMPATTACHMENT As String = "STORESTOCK"
            Dim objmail As New SendMail
            objmail.subject = "STORESTOCK"
            objmail.attachment = TEMPATTACHMENT
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If

            objmail.attachment = TEMPATTACHMENT
            objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"

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
            oDfDopt.DiskFileName = Application.StartupPath & "\STORESTOCK.pdf"

            If FRMSTRING = "STOREITEMSTOCKSUMM" Then
                expo = RPTSTOREITEMSTOCKSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOREITEMSTOCKSUMM.Export()
            ElseIf FRMSTRING = "STOREITEMSTOCKDTLS" Then
                expo = RPTSTOREITEMSTOCKDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOREITEMSTOCKDTLS.Export()
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
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\STORESTOCK.PDF")
            OBJWHATSAPP.FILENAME.Add("STORESTOCK.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class