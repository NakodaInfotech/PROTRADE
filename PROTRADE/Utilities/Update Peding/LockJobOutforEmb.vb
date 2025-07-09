
Imports BL

Public Class LockJobOutforEmb

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LockJobOutforEmb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LockJobOutforEmb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If RBPENDING.Checked = True Then
                dt = objclsCMST.search(" JOBOUT_DESC.JO_NO AS JONO, JOBOUT.JO_date AS DATE, JOBOUT_DESC.JO_GRIDSRNO AS JOSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(JOBOUT_DESC.JO_BARCODE, '') AS BARCODE, ISNULL(JOBOUT_DESC.JO_PCS, 0) AS PCS, ISNULL(JOBOUT_DESC.JO_MTRS, 0) AS MTRS, ISNULL(JOBOUT_DESC.JO_RECDFRAMES, 0) AS RECDFRAMES ", "", " JOBOUT_DESC INNER JOIN JOBOUT ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id", " AND ISNULL(JOBOUT_DESC.JO_EMBPRODDONE,0) = 0 AND JOBOUT.JO_YEARID=" & YearId & " ORDER BY JOBOUT_DESC.JO_NO, JOBOUT_DESC.JO_GRIDSRNO")
            Else
                dt = objclsCMST.search(" JOBOUT_DESC.JO_NO AS JONO, JOBOUT.JO_date AS DATE, JOBOUT_DESC.JO_GRIDSRNO AS JOSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(JOBOUT_DESC.JO_BARCODE, '') AS BARCODE, ISNULL(JOBOUT_DESC.JO_PCS, 0) AS PCS, ISNULL(JOBOUT_DESC.JO_MTRS, 0) AS MTRS, ISNULL(JOBOUT_DESC.JO_RECDFRAMES, 0) AS RECDFRAMES ", "", " JOBOUT_DESC INNER JOIN JOBOUT ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id", " AND ISNULL(JOBOUT_DESC.JO_EMBPRODDONE,0) = 1 AND JOBOUT.JO_YEARID=" & YearId & " ORDER BY JOBOUT_DESC.JO_NO, JOBOUT_DESC.JO_GRIDSRNO")
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
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Lock-Unlock Job Out Entries.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Lock-Unlock Job Out Entries"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lock-Unlock Job Out Entries", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Job Out Entries Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBOUT_DESC SET JO_EMBPRODDONE = 1 WHERE JO_NO = " & DTROW("JONO") & " AND JO_GRIDSRNO = " & DTROW("JOSRNO") & " AND JO_YEARID = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBOUT_DESC SET JO_EMBPRODDONE = 0 WHERE JO_NO = " & DTROW("JONO") & " And JO_GRIDSRNO = " & DTROW("JOSRNO") & " And JO_YEARID = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class