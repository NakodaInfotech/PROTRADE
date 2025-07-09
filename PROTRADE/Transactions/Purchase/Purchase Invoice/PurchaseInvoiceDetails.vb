
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseInvoiceDetails

    Dim PURCHASEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub PURCHASEMASTERDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  PURCHASEMASTER.BILL_NO AS SRNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, LEDGERS.Acc_cmpname AS PARTYNAME, ISNULL(PURCHASEMASTER.BILL_PARTYBILLNO, '') AS PARTYBILLNO, ISNULL(PURCHASEMASTER.BILL_CHALLANNO, '') AS CHALLANNO, ISNULL(PURCHASEMASTER.BILL_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(PURCHASEMASTER.BILL_TOTALQTY, 0) AS TOTALQTY, ISNULL(PURCHASEMASTER.BILL_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(PURCHASEMASTER.BILL_CHECKED, 0) AS CHECKED, ISNULL(PURCHASEMASTER.BILL_DISPUTE, 0) AS DISPUTED, ISNULL(PURCHASEMASTER.BILL_REMARKS, '') AS REMARKS, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASEMASTER.BILL_RETURN, 0) AS PURRETURN, ISNULL(PURCHASEMASTER.BILL_CHARGES, 0) AS CHARGES, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, (CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TOTALTAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(AGENT.Acc_cmpname, '') AS AGENT,PURCHASEMASTER.BILL_LRNO AS LRNO,ISNULL(PURCHASEMASTER.BILL_TOTALDISCAMT, 0) AS TOTALDISCAMT, ISNULL(PURCHASEMASTER.BILL_TOTALSPDISCAMT, 0) AS TOTALSPDISCAMT, ISNULL(PURCHASEMASTER.BILL_PURTYPE,'GOODS PURCHASE') AS PURTYPE, ISNULL(PURCHASEMASTER.BILL_FOOTERDISC, 0) AS DISCPER, ISNULL(PURCHASEMASTER.BILL_FOOTERDISCAMT, 0) AS DISCAMT, PURCHASEMASTER.BILL_AMTPAID + PURCHASEMASTER.BILL_EXTRAAMT AS PAIDAMT, PURCHASEMASTER.BILL_RETURN AS PURRETURN,  PURCHASEMASTER.BILL_BALANCE AS BALANCEAMT , ISNULL(PURCHASEMASTER.BILL_BILLAMT, 0) AS BILLAMT, ISNULL(PURCHASEMASTER.BILL_APPLYTCS, 0) AS APPLYTCS, ISNULL(PURCHASEMASTER.BILL_TCSPER, 0) AS TCSPER, ISNULL(PURCHASEMASTER.BILL_TCSAMT, 0) AS TCSAMT ", " ", "   PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN LEDGERS AS AGENT ON PURCHASEMASTER.BILL_AGENTID = AGENT.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id  LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBILL As New PurchaseMaster
                OBJBILL.MdiParent = MDIMain
                OBJBILL.edit = editval
                OBJBILL.tempBILLno = billno
                OBJBILL.TEMPREGNAME = cmbregister.Text.Trim
                OBJBILL.Show()
                '  Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURCHASEREGID = dt.Rows(0).Item(0)
                    fillgrid(" AND PURCHASEMASTER.BILL_yearid = " & YearId & " AND PURCHASEMASTER.BILL_registerid = " & PURCHASEREGID & " order by dbo.PURCHASEMASTER.BILL_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJPUR As New PurchaseInvoiceGridDetails
            OBJPUR.MdiParent = MDIMain
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Purchase Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("PURRETURN")) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Plum
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
        If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Then
            GSPDISCAMT.Visible = True
            GDISAMT.Visible = True
        End If
        If ClientName = "NVAHAN" Then
            GFOOTERDISCPER.Visible = True
            GFOOTERDISCPER.VisibleIndex = GTOTALMTRS.VisibleIndex + 1
            GFOOTERDISCAMT.Visible = True
            GFOOTERDISCAMT.VisibleIndex = GFOOTERDISCPER.VisibleIndex + 1
        End If
    End Sub

End Class