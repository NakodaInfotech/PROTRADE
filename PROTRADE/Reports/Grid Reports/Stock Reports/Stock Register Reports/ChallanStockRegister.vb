
Imports BL

Public Class ChallanStockRegister

    Public TILLDATE As Date = Now.Date

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CMDREFRESH_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.Execute_Any_String(" SELECT DISTINCT GDN_NO AS GDNNO,  GDN_TOTALMTRS AS MTRS from GDN LEFT OUTER JOIN INVOICEMASTER_DESC ON GDN.GDN_NO = INVOICE_FROMNO AND GDN.GDN_YEARID = INVOICE_YEARID LEFT JOIN INVOICEMASTER ON INVOICEMASTER.INVOICE_NO =INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID =INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID =INVOICEMASTER_DESC.INVOICE_YEARID WHERE ((GDN.GDN_DATE <= '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE > '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "') OR (ISNULL(ROUND(GDN.GDN_OUTMTRS,0),0) = 0  AND GDN.GDN_DATE <= '" & Format(TILLDATE.Date, "MM/dd/yyyy") & "')) AND GDN_YEARID = " & YearId & " ORDER BY GDN_NO ", "", "")
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
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Challan Stock Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo
            opti.SheetName = "Challan Stock Register"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Stock Register", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class