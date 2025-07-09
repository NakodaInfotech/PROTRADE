Imports BL


Public Class DeliveryOrderDetails
    Public edit As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub DeliveryOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.Enter Then
                cmdok_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Call TOOLREFRESH_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call TOOLEXCEL_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DeliveryOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" AND dbo.DELIVERYORDER.DO_yearid=" & YearId & " ORDER by dbo.DELIVERYORDER.DO_NO ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" DELIVERYORDER.DO_no AS SRNO, DELIVERYORDER.DO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, TRANSLEDGERS.Acc_cmpname AS TRANSNAME, ISNULL(GODOWNMASTER.GODOWN_NAME, '') AS OURGODOWN, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, QUALITYMASTER.QUALITY_NAME AS QUALITY, MILLLEDGERS.Acc_cmpname AS MILLNAME, WAREHOUSE.GODOWN_NAME AS WAREHOUSE, DELIVERYORDER_DESC.DO_BAGS AS BAGS, DELIVERYORDER_DESC.DO_WT AS WT, DELIVERYORDER_DESC.DO_LRNO AS LRNO, ISNULL(DELIVERYORDER_DESC.DO_LOTNO,'') AS LOTNO ", "", " GODOWNMASTER RIGHT OUTER JOIN LEDGERS AS MILLLEDGERS INNER JOIN DELIVERYORDER INNER JOIN DELIVERYORDER_DESC ON DELIVERYORDER.DO_no = DELIVERYORDER_DESC.DO_NO AND DELIVERYORDER.DO_yearid = DELIVERYORDER_DESC.DO_YEARID INNER JOIN LEDGERS AS TRANSLEDGERS ON DELIVERYORDER.DO_transledgerid = TRANSLEDGERS.Acc_id INNER JOIN QUALITYMASTER ON DELIVERYORDER_DESC.DO_QUALITYID = QUALITYMASTER.QUALITY_ID INNER JOIN GODOWNMASTER AS WAREHOUSE ON DELIVERYORDER_DESC.DO_GODOWNID = WAREHOUSE.GODOWN_ID ON  MILLLEDGERS.Acc_id = DELIVERYORDER_DESC.DO_MILLID LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON DELIVERYORDER.DO_JOBBERID = JOBBERLEDGERS.Acc_id ON GODOWNMASTER.GODOWN_ID = DELIVERYORDER.DO_OURGODOWNID LEFT OUTER JOIN LEDGERS ON DELIVERYORDER.DO_LEDGERID = LEDGERS.Acc_id  ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objDO As New DeliveryOrder
                objDO.MdiParent = MDIMain
                objDO.EDIT = editval
                objDO.TEMPDONO = DONO
                objDO.Show()
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

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
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

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Delivery Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Delivery Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Delivery Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid(" AND dbo.DELIVERYORDER.DO_yearid=" & YearId & " order by dbo.DELIVERYORDER.DO_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Then Exit Sub
            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Proper Delivery Order Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Wish to Print Delivery Order from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            ''serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), "", "DOREPORT", Val(TXTCOPIES.Text.Trim), PRINTDIALOG)
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
End Class