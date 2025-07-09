
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class PackingSlipDetails

    Public EDIT As Boolean
    'Dim TEMPPSNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub


    Private Sub PackingSlipDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub PackingSlipDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid(" and DBO.PACKINGSLIP.PS_CMPID=" & CmpId & " and DBO.PACKINGSLIP.PS_locationid=" & Locationid & " and DBO.PACKINGSLIP.PS_yearid=" & YearId & " order by DBO.PACKINGSLIP.PS_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsPackingslip
            ''Dim objclsCMST As New ClsCommonMaster
            Dim DT As DataTable = objclsCMST.selectPACKINGSLIP(0, CmpId, 0, YearId)
            '' Dim dt As DataTable = objclsCMST.search(" PACKINGSLIP.PS_NO AS SRNO,PACKINGSLIP.PS_date AS DATE, LEDGERS.Acc_cmpname AS CMPNAME,ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, SUM(PACKINGSLIP_DESC.PS_PCS) AS PCS, SUM(PACKINGSLIP_DESC.PS_MTRS) AS MTRS, ISNULL(PACKINGSLIP.PACKINGSLIP_TRANSREMARKS,'') AS PARTYPONO  ", "", " PACKINGSLIP INNER JOIN LEDGERS ON PACKINGSLIP.PACKINGSLIP_ledgerid = LEDGERS.Acc_id INNER JOIN PACKINGSLIP_DESC ON PACKINGSLIP.PS_NO = PACKINGSLIP_DESC.PS_NO AND PACKINGSLIP.PS_YEARID = PACKINGSLIP_DESC.PS_YEARID  LEFT OUTER JOIN DESIGNMASTER ON PACKINGSLIP_DESC.PS_DESIGNID = DESIGNMASTER.DESIGN_id", TEMPCONDITION & " GROUP BY PACKINGSLIP.PS_NO,  PACKINGSLIP.PS_date, LEDGERS.Acc_cmpname,ISNULL(DESIGNMASTER.DESIGN_NO,''), ISNULL(PACKINGSLIP.PS_REMARKS,'')")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PACKINGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJPACKINGNO As New PackingSlip
                OBJPACKINGNO.MdiParent = MDIMain
                OBJPACKINGNO.EDIT = editval
                OBJPACKINGNO.TEMPPACKINGNO = PACKINGNO
                OBJPACKINGNO.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PSNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PSNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
    '    Try
    '        If e.RowHandle >= 0 Then
    '            Dim View As GridView = sender
    '            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "True" Then
    '                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
    '                e.Appearance.BackColor = Color.LightGreen
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub




    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TXTCOPIES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPIES.Validating
        If Val(TXTCOPIES.Text.Trim) <= 0 Then TXTCOPIES.Text = 1
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress, TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub PrintToolStripButton2_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton2.Click
        Try
            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub

            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Propoer Packing Nos", MsgBoxStyle.Critical)
                Exit Sub
            Else
                If MsgBox("Wish to Print Packingslip from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1, Optional ByVal FRMSTRING As String = "PRINT")
        Try
            Dim ALATTACHMENT As New ArrayList
            For I As Integer = fromno To tono

                '**************** SET SERVER ************************
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue

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

                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions


                Dim OBJ As New Object
                OBJ = New PackingSlipReport
                If CHKWHITELABEL.Checked = True Then OBJ.DataDefinition.FormulaFields("WHITELABEL").Text = 1


                crTables = OBJ.Database.Tables
                For Each crTable In crTables
                    crtableLogonInfo = crTable.LogOnInfo
                    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                    crTable.ApplyLogOnInfo(crtableLogonInfo)
                Next

                OBJ.RecordSelectionFormula = "{PACKINGLIP.PS_no}=" & Val(I) & " and {PACKINGLIP.PS_yearid}=" & YearId
                OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
                OBJ.PrintToPrinter(NOOFCOPIES, True, 0, 0)

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = "D:\PackingSlip Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "PackingSlip Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PackingSlip Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("PackingSlip Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub PackingslipDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            gsrno.Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
