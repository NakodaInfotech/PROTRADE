
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PendingChallanForInvoice

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PendingChallanForInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PendingChallanForInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            Dim WHERECLAUSE As String = ""
            If ClientName = "GELATO" Or ClientName = "AXIS" Then
                WHERECLAUSE = WHERECLAUSE & " AND ROUND(ISNULL(GDN.GDN_OUTPCS,0),0) = 0"
            Else
                WHERECLAUSE = WHERECLAUSE & " AND ROUND(ISNULL(GDN.GDN_OUTMTRS,0),0) = 0"
            End If

            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                dt = objclsCMST.search(" GDN.GDN_NO AS SRNO, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(GDN.GDN_TOTALBALES, 0) AS TOTALBALES, ISNULL(GDN.GDN_TOTALPCS, 0) AS TOTALPCS, ISNULL(GDN.GDN_TOTALMTRS, 0) AS MTRS, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT, ISNULL(GDN.GDN_TRANSREFNO, '') AS CHALLANNO, ISNULL(GDN.GDN_HOLDFORAPPROVAL, 0) AS HOLDFORAPPROVAL  ", "", "   GDN INNER JOIN GODOWNMASTER ON GDN.GDN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON GDN.GDN_DISPATCHTOID = PACKINGLEDGERS.Acc_id ", " AND ROUND((GDN.GDN_TOTALMTRS - GDN.GDN_OUTMTRS),0) > 0 AND GDN.GDN_YEARID = " & YearId)
            Else
                dt = objclsCMST.search(" GDN.GDN_NO AS SRNO, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(GDN.GDN_TOTALBALES, 0) AS TOTALBALES, ISNULL(GDN.GDN_TOTALPCS, 0) AS TOTALPCS, ISNULL(GDN.GDN_TOTALMTRS, 0) AS MTRS, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT, ISNULL(GDN.GDN_TRANSREFNO, '') AS CHALLANNO, ISNULL(GDN.GDN_HOLDFORAPPROVAL, 0) AS HOLDFORAPPROVAL  ", "", "   GDN INNER JOIN GODOWNMASTER ON GDN.GDN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON GDN.GDN_DISPATCHTOID = PACKINGLEDGERS.Acc_id ", WHERECLAUSE & " AND GDN.GDN_YEARID = " & YearId)
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Challan Pending For Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Challan Pending For Invoice"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Pending For Invoice", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Challan Pending Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("HOLDFORAPPROVAL")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightCoral
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(sender As Object, e As EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJCPENDING As New PendingChallanForInvoiceDetails
            OBJCPENDING.MdiParent = MDIMain
            OBJCPENDING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class