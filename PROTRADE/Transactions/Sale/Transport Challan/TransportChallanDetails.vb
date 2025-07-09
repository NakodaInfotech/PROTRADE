
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class TransportChallanDetails

    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TRANSPORTCHALLANDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSPORTCHALLANDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            'FILLCHALLANTYPE(CMBTYPE)
            'If ClientName <> "SAFFRON" Then
            fillgrid(" and dbo.TRANSPORTCHALLAN.TRANS_yearid=" & YearId & " ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" ISNULL(TRANSPORTCHALLAN.TRANS_NO, 0) AS TRANSNO, ISNULL(TRANSPORTCHALLAN.TRANS_DATE, GETDATE()) AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(CITYMASTER.city_name, '') AS FROMCITY, ISNULL(TOCITY.city_name, '') AS TOCITY, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALBALES, 0) AS TOTALBALES, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALPCS, 0) AS TOTALPCS, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALAMT, 0) AS TOTALAMT, ISNULL(TRANSPORTCHALLAN.TRANS_REMARKS, '') AS REMARKS, ISNULL(TRANSPORTCHALLAN_DESC.TRANS_TYPECHALLANNO, 0) AS TYPECHALLANNO  ", "", "  LEDGERS AS TRANSLEDGERS INNER JOIN CITYMASTER AS TOCITY INNER JOIN CITYMASTER INNER JOIN TRANSPORTCHALLAN INNER JOIN LEDGERS ON TRANSPORTCHALLAN.TRANS_LEDGERID = LEDGERS.Acc_id ON CITYMASTER.city_id = TRANSPORTCHALLAN.TRANS_FROMCITYID ON TOCITY.city_id = TRANSPORTCHALLAN.TRANS_TOCITYID ON TRANSLEDGERS.Acc_id = TRANSPORTCHALLAN.TRANS_TRANSID INNER JOIN TRANSPORTCHALLAN_DESC ON TRANSPORTCHALLAN.TRANS_NO = TRANSPORTCHALLAN_DESC.TRANS_NO AND TRANSPORTCHALLAN.TRANS_YEARID = TRANSPORTCHALLAN_DESC.TRANS_YEARID ", TEMPCONDITION & " GROUP BY TRANSPORTCHALLAN.TRANS_NO, TRANSPORTCHALLAN.TRANS_date, LEDGERS.Acc_cmpname, TRANSPORTCHALLAN.TRANS_TOTALBALES")
            dt = objclsCMST.search("ISNULL(TRANSPORTCHALLAN.TRANS_NO, 0) AS SRNO, ISNULL(TRANSPORTCHALLAN.TRANS_DATE, GETDATE()) AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(CITYMASTER.city_name, '') AS FROMCITY, ISNULL(TOCITY.city_name, '') AS TOCITY, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALBALES, 0) AS TOTALBALES, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALPCS, 0) AS TOTALPCS, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(TRANSPORTCHALLAN.TRANS_TOTALAMT, 0) AS TOTALAMOUNT, ISNULL(TRANSPORTCHALLAN.TRANS_REMARKS, '') AS REMARKS  ", "", "  LEDGERS AS TRANSLEDGERS INNER JOIN CITYMASTER AS TOCITY INNER JOIN CITYMASTER INNER JOIN TRANSPORTCHALLAN INNER JOIN LEDGERS ON TRANSPORTCHALLAN.TRANS_LEDGERID = LEDGERS.Acc_id ON CITYMASTER.city_id = TRANSPORTCHALLAN.TRANS_FROMCITYID ON TOCITY.city_id = TRANSPORTCHALLAN.TRANS_TOCITYID ON TRANSLEDGERS.Acc_id = TRANSPORTCHALLAN.TRANS_TRANSID ", TEMPCONDITION & "ORDER BY SRNO")

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal TRANSGDNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New TransportChallan
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPTRANSNO = TRANSGDNNO
                objgdn.Show()
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TXTCOPIES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPIES.Validating
        If Val(TXTCOPIES.Text.Trim) <= 0 Then TXTCOPIES.Text = 1
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress, TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub

            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Proper Trans Challan Nos", MsgBoxStyle.Critical)
                Exit Sub
            Else
                If MsgBox("Wish to Print  Trans Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1)

        For I As Integer = fromno To tono
            Dim OBJINV As New GDNDESIGN
            Dim RPTTRANSGDN As New GDNTransReport

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

            crTables = RPTTRANSGDN.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJINV.MdiParent = MDIMain

            RPTTRANSGDN.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            RPTTRANSGDN.RecordSelectionFormula = "{TRANSPORTCHALLAN.TRANS_no}=" & Val(I) & " and {TRANSPORTCHALLAN.TRANS_YEARID}=" & YearId
            RPTTRANSGDN.PrintToPrinter(NOOFCOPIES, True, 0, 0)


        Next
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Transport Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Transport Challan Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Transport Challan Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Transport Challan Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class