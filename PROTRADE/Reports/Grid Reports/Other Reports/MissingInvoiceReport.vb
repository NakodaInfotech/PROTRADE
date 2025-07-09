
Imports BL

Public Class MissingInvoiceReport

    Private Sub InvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim dt As DataTable = OBJCMN.Execute_Any_String("CREATE TABLE #TEMP (ID INT) DECLARE @I INT, @MAXNO INT   SET @I = 1  SELECT @MAXNO = MAX(INVOICE_NO) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = register_id WHERE INVOICE_YEARID = " & YearId & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "'  WHILE @I <= @MAXNO  BEGIN 	INSERT INTO #TEMP VALUES (@I) 	SET @I+=1  END   SELECT #TEMP.ID AS SRNO FROM #TEMP WHERE ID NOT IN (SELECT INVOICE_NO FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = register_id WHERE INVOICE_YEARID = " & YearId & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "')  DROP TABLE #TEMP ", "", "")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
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

    Private Sub InvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillregister(cmbregister, " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class