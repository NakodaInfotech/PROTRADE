
Imports BL

Public Class UnHoldChallan

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnHoldChallan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub UnHoldChallan_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" GDN.GDN_NO AS GDNNO, GDN.GDN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, DELIVERYLEDGERS.Acc_cmpname AS PACKING, SUM(GDN_DESC.GDN_PCS) AS TOTALPCS,  SUM(GDN_DESC.GDN_MTRS) AS TOTALMTRS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLOR_NAME,'') AS SHADE ", "", "  GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN LEDGERS AS DELIVERYLEDGERS ON GDN.GDN_DISPATCHTOID = DELIVERYLEDGERS.Acc_id INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID INNER JOIN ITEMMASTER ON GDN_DESC.GDN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON GDN_DESC.GDN_COLORID = COLOR_ID ", " AND GDN.GDN_YEARID=" & YearId & " AND ISNULL(GDN.GDN_HOLDFORAPPROVAL,0) = 1 GROUP BY GDN.GDN_NO, GDN.GDN_date, LEDGERS.Acc_cmpname, DELIVERYLEDGERS.Acc_cmpname, ISNULL(ITEMMASTER.item_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLOR_NAME,'')")
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
            PATH = Application.StartupPath & "\Un-Hold Challans.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Un-Hold Challans"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Un-Hold Challans", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Un Hold Challan Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon


            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" UPDATE GDN SET GDN_HOLDFORAPPROVAL= 0 WHERE GDN_NO = " & DTROW("GDNNO") & " AND GDN_YEARID = " & YearId, "", "")
            Next
            MsgBox("Details Updated Successfully")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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