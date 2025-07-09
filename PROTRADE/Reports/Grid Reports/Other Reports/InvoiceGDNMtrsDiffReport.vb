
Imports BL

Public Class InvoiceGDNMtrsDiffReport

    Private Sub InvoiceGDNMtrsDiffReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.Execute_Any_String(" SELECT INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_INITIALS AS INVINITIALS, LEDGERS.ACC_CMPNAME AS NAME, INVOICEMASTER.INVOICE_GDNNO AS CHALLANNO, INVOICE_TOTALMTRS AS INVMTRS, ISNULL(SUM(GDN.GDN_TOTALMTRS),0) AS CHALLANMTRS FROM (SELECT DISTINCT INVOICEMASTER_DESC.INVOICE_NO, INVOICEMASTER_DESC.INVOICE_REGISTERID, INVOICEMASTER_DESC.INVOICE_YEARID, INVOICEMASTER_DESC.INVOICE_FROMNO FROM INVOICEMASTER_DESC INNER JOIN REGISTERMASTER ON INVOICEMASTER_DESC.INVOICE_REGISTERID = REGISTERMASTER.REGISTER_ID WHERE (INVOICE_FROMTYPE = 'GDN' OR INVOICE_FROMTYPE = '') AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER_DESC.INVOICE_YEARID = " & YearId & ") AS INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.REGISTER_ID LEFT OUTER JOIN GDN ON INVOICEMASTER_DESC.INVOICE_FROMNO = GDN.GDN_NO AND INVOICEMASTER_DESC.INVOICE_YEARID = GDN.GDN_YEARID WHERE INVOICEMASTER.INVOICE_YEARID = " & YearId & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_INITIALS, LEDGERS.Acc_cmpname, INVOICEMASTER.INVOICE_TOTALMTRS, INVOICEMASTER.INVOICE_GDNNO HAVING ROUND(ISNULL(SUM(GDN.GDN_TOTALMTRS),0),2)<> ROUND(INVOICEMASTER.INVOICE_TOTALMTRS,2) ORDER BY INVOICEMASTER.INVOICE_NO ", "", "")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    fillgrid()
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

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Missing Invoice No.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Missing Invoice No"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Missing Invoice No", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Missing Invoice No Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub InvoiceGDNMtrsDiffReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillregister(cmbregister, " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class