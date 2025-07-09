
Imports BL

Public Class HSNWiseDetails

    Public FRMSTRING As String = ""
    Public WHERECLAUSE As String = ""

    Private Sub HSNWiseDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNWiseDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As New DataTable
            If FRMSTRING = "SALE" Then
                DT = OBJCMN.search(" INITIALS, DATE,NAME, HSNCODE, SUM(QTY) AS QTY, SUM(TAXABLEAMT) AS TAXABLEAMT, SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(GRANDTOTAL) AS GRANDTOTAL ", "", " HSNSUMMARY ", WHERECLAUSE & " AND YEARID = " & YearId & " GROUP BY DATE,HSNSUMMARY.INITIALS, NAME, HSNCODE ")
            Else
                DT = OBJCMN.search(" INITIALS, DATE,NAME, HSNCODE, SUM(QTY) AS QTY, SUM(TAXABLEAMT) AS TAXABLEAMT, SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(GRANDTOTAL) AS GRANDTOTAL ", "", " HSNPURSUMMARY ", WHERECLAUSE & " AND YEARID = " & YearId & " GROUP BY DATE,INITIALS, NAME, HSNCODE ")
            End If
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXPORT_Click(sender As Object, e As EventArgs) Handles CMDEXPORT.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\HSN Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "HSN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "HSN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("HSN Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class