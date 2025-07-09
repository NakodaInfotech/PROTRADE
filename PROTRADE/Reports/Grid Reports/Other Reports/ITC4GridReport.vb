
Imports BL

Public Class ITC4GridReport

    Public WHERECLAUSE As String = " AND YEARID = " & YearId

    Private Sub ITC4GridReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            FILLGRID(" AND yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("GSTIN, STATE, JWTYPE,CHALLANNO,CHALLANDATE, GOODSDESC,UOM,TOTALQTY,ITEMNAME,TAXABLEAMT,IGST,CGST,SGST,CESS", "", "ITC4MFGTOJW", TEMPCONDITION & "GROUP BY GSTIN, STATE, JWTYPE,CHALLANNO,CHALLANDATE, GOODSDESC,UOM,TOTALQTY,ITEMNAME,TAXABLEAMT,IGST,CGST,SGST,CESS")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            Dim OBJCMN1 As New ClsCommon
            Dim DT1 As DataTable = OBJCMN1.search("GSTIN, STATE,CHALLANNO,CHALLANDATE,NATUREOFTRANS,OTHERCHNO,OTHERDATE,OTHERCGSTIN,OTHERSTATE,OTHERINVNO,OTHERINVDATE, GOODSDESC,UOM,TOTALQTY,TAXABLEAMT", "", "ITC4JWTOMFG", TEMPCONDITION & "GROUP BY GSTIN, STATE,CHALLANNO,CHALLANDATE,NATUREOFTRANS,OTHERCHNO,OTHERDATE,OTHERCGSTIN,OTHERSTATE,OTHERINVNO,OTHERINVDATE, GOODSDESC,UOM,TOTALQTY,TAXABLEAMT")
            gridbilldetails1.DataSource = DT1
            If DT1.Rows.Count > 0 Then
                gridbill1.FocusedRowHandle = gridbill1.RowCount - 1
                gridbill1.TopRowIndex = gridbill1.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\ITC4 MFG TO JW Grid Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "ITC4 MFG TO JW Grid Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "ITC4 MFG TO JW Grid Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)


            'For JW TO MFG
            Dim PATH1 As String = ""
            If FileIO.FileSystem.FileExists(PATH1) = True Then FileIO.FileSystem.DeleteFile(PATH1)
            PATH1 = Application.StartupPath & "\ITC4 JW TO MFG Grid Report.XLS"

            Dim opti1 As New DevExpress.XtraPrinting.XlsExportOptions
            opti1.ShowGridLines = True

            Dim PERIOD1 As String = AccFrom & " - " & AccTo

            opti1.SheetName = "ITC4 JW TO MFG Grid Report"
            gridbill1.ExportToXls(PATH1, opti1)
            EXCELCMPHEADER(PATH1, "ITC4 JW TO MFG Grid Report", gridbill1.VisibleColumns.Count + gridbill1.GroupCount, "", PERIOD1)

        Catch ex As Exception
            MsgBox("ITC4 Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ITC4GridReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLGRID(" AND yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class