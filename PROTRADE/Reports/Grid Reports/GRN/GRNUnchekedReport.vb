
Imports BL

Public Class GRNUnchekedReport

    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNUnchekedReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNUnchekedReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "UNCHECKED" Then
                RBUNCHECKED.Checked = True
            ElseIf FRMSTRING = "CHECKED" Then
                RBCHECKED.Checked = True
            ElseIf FRMSTRING = "PENDING" Then
                RBPENDING.Checked = True
            End If
            fillgrid(" and dbo.GRN.GRN_CMPID=" & CmpId & " and dbo.GRN.GRN_locationid=" & Locationid & " and dbo.GRN.GRN_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE)
        Try
            If RBUNCHECKED.Checked = True Then
                WHERECLAUSE = WHERECLAUSE & " AND GRN_DESC.GRN_CHECKDONE = 'False' AND GRN.GRN_TYPE = 'Job Work'"
            ElseIf RBCHECKED.Checked = True Then
                WHERECLAUSE = WHERECLAUSE & " AND GRN_DESC.GRN_CHECKDONE = 'True' AND GRN.GRN_TYPE = 'Job Work'"
            ElseIf RBPENDING.Checked = True Then
                WHERECLAUSE = WHERECLAUSE & " AND GRN.GRN_DONE = 'False' "
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" GRN.grn_no AS GRNNO, GRN.grn_pono AS CHALLANNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME,  ISNULL(GODOWNMASTER.GODOWN_NAME, '') AS GODOWN, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, GRN.GRN_TOTALQTY AS QTY, GRN.GRN_TOTALMTRS AS MTRS, GRN.GRN_PLOTNO AS LOTNO,  ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME ", "", "  GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id AND GRN.grn_cmpid = LEDGERS.Acc_cmpid AND GRN.grn_locationid = LEDGERS.Acc_locationid AND GRN.grn_yearid = LEDGERS.Acc_yearid INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.grn_cmpid = GRN_DESC.GRN_CMPID AND GRN.grn_locationid = GRN_DESC.GRN_LOCATIONID AND  GRN.grn_yearid = GRN_DESC.GRN_YEARID LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.grn_yearid = BROKERLEDGERS.Acc_yearid AND GRN.grn_locationid = BROKERLEDGERS.Acc_locationid AND GRN.grn_cmpid = BROKERLEDGERS.Acc_cmpid AND GRN.GRN_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GRN.grn_yearid = JOBBERLEDGERS.Acc_yearid AND GRN.grn_locationid = JOBBERLEDGERS.Acc_locationid AND GRN.grn_cmpid = JOBBERLEDGERS.Acc_cmpid AND  GRN.GRN_TOLEDGERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON GRN.grn_yearid = GODOWNMASTER.GODOWN_YEARID AND GRN.grn_locationid = GODOWNMASTER.GODOWN_LOCATIONID AND GRN.grn_cmpid = GODOWNMASTER.GODOWN_CMPID AND GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_ID ", WHERECLAUSE & " GROUP BY GRN.grn_no, GRN.grn_pono, GRN.grn_date, LEDGERS.Acc_cmpname, ISNULL(JOBBERLEDGERS.Acc_cmpname, ''), ISNULL(GODOWNMASTER.GODOWN_NAME, ''), ISNULL(BROKERLEDGERS.Acc_cmpname, ''), GRN.GRN_TOTALQTY, GRN.GRN_TOTALMTRS, GRN.GRN_PLOTNO, GRN.GRN_TYPE, ISNULL(ITEMMASTER.item_name, '') ORDER BY GRN.grn_no ")
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

            Dim PATH As String = Application.StartupPath & "\GRN Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("GRN Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            fillgrid(" and dbo.GRN.GRN_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class