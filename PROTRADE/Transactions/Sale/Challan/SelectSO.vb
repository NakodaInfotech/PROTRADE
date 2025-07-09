
Imports BL

Public Class SelectSO

    Public PARTYNAME As String = ""
    Public FRMSTRING As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfgforPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfgforPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Dim OPWHERE As String = ""
            Cursor.Current = Cursors.WaitCursor

            If PARTYNAME <> "" Then
                WHERE = WHERE & " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & PARTYNAME & "'"
                OPWHERE = OPWHERE & " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & PARTYNAME & "'"
            End If
            If FRMSTRING = "" Then
                If SALEORDERONMTRS = False Then WHERE = WHERE & " and (SALEORDER_DESC.SO_QTY - SALEORDER_DESC.SO_RECDQTY) > 0 AND SALEORDER_DESC.SO_CLOSED=0 " Else WHERE = WHERE & " and (SALEORDER_DESC.SO_MTRS - SALEORDER_DESC.SO_RECDMTRS) > 0 AND SALEORDER_DESC.SO_CLOSED=0 "
                If SALEORDERONMTRS = False Then OPWHERE = OPWHERE & " and (OPENINGSALEORDER_DESC.OPSO_QTY - OPENINGSALEORDER_DESC.OPSO_RECDQTY) > 0 AND OPENINGSALEORDER_DESC.OPSO_CLOSED=0 " Else OPWHERE = OPWHERE & " and (OPENINGSALEORDER_DESC.OPSO_MTRS - OPENINGSALEORDER_DESC.OPSO_RECDMTRS) > 0 AND OPENINGSALEORDER_DESC.OPSO_CLOSED=0 "
            End If

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search("CAST (0 AS BIT) AS CHK,*", "", " (SELECT SALEORDER.so_no AS SONO, SALEORDER.so_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGER.Acc_cmpname, '') AS AGENTNAME, SALEORDER.so_pono AS [PONO], ISNULL(ITEMMASTER.item_name,'') AS [ITEMNAME], (SALEORDER_DESC.SO_QTY - SALEORDER_DESC.SO_RECDQTY) AS [QTY], (SALEORDER_DESC.SO_MTRS - SALEORDER_DESC.SO_RECDMTRS) AS [MTRS], SALEORDER.so_remarks AS REMARKS, SALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(DESIGN_NO,'') AS DESIGNNO, ISNULL(COLOR_NAME,'') AS COLOR, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(SALEORDER.SO_REFNO,'') AS REFNO, SALEORDER_DESC.SO_RATE AS RATE, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME, 'SALEORDER' AS TYPE, ISNULL(SALEORDER_DESC.SO_PARTYPONO,'') AS GRIDPARTYPONO FROM SALEORDER INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id INNER JOIN SALEORDER_DESC ON SALEORDER.so_no = SALEORDER_DESC.SO_NO AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON SALEORDER.SO_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGER ON SALEORDER.so_Agentid = AGENTLEDGER.Acc_id LEFT OUTER JOIN ADDRESSMASTER ON SALEORDER.so_HASTEID = ADDRESSMASTER.ADDRESS_ID LEFT OUTER JOIN DESIGNMASTER ON SALEORDER_DESC.SO_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLOR_ID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON SALEORDER.SO_TRANSID = TRANSLEDGERS.ACC_ID LEFT OUTER JOIN CITYMASTER ON SALEORDER.SO_CITYID = CITYMASTER.CITY_ID WHERE SALEORDER.so_YEARID = " & YearId & WHERE & " UNION ALL SELECT OPENINGSALEORDER.OPSO_no AS SONO, OPENINGSALEORDER.OPSO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGER.Acc_cmpname, '') AS AGENTNAME, OPENINGSALEORDER.OPSO_pono AS [PONO], ISNULL(ITEMMASTER.item_name,'') AS [ITEMNAME], (OPENINGSALEORDER_DESC.OPSO_QTY - OPENINGSALEORDER_DESC.OPSO_RECDQTY) AS [QTY], (OPENINGSALEORDER_DESC.OPSO_MTRS - OPENINGSALEORDER_DESC.OPSO_RECDMTRS) AS [MTRS], OPENINGSALEORDER.OPSO_remarks AS REMARKS, OPENINGSALEORDER_DESC.OPSO_GRIDSRNO AS GRIDSRNO, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(DESIGN_NO,'') AS DESIGNNO, ISNULL(COLOR_NAME,'') AS COLOR, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(OPENINGSALEORDER.OPSO_REFNO,'') AS REFNO, OPENINGSALEORDER_DESC.OPSO_RATE AS RATE, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME, 'OPENING' AS TYPE, ISNULL(OPENINGSALEORDER_DESC.OPSO_PARTYPONO,'') AS GRIDPARTYPONO FROM OPENINGSALEORDER INNER JOIN LEDGERS ON OPENINGSALEORDER.OPSO_ledgerid = LEDGERS.Acc_id INNER JOIN OPENINGSALEORDER_DESC ON OPENINGSALEORDER.OPSO_no = OPENINGSALEORDER_DESC.OPSO_NO AND OPENINGSALEORDER.OPSO_YEARID = OPENINGSALEORDER_DESC.OPSO_YEARID LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON OPENINGSALEORDER.OPSO_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON OPENINGSALEORDER_DESC.OPSO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGER ON OPENINGSALEORDER.OPSO_Agentid = AGENTLEDGER.Acc_id LEFT OUTER JOIN ADDRESSMASTER ON OPENINGSALEORDER.OPSO_HASTEID = ADDRESSMASTER.ADDRESS_ID LEFT OUTER JOIN DESIGNMASTER ON OPENINGSALEORDER_DESC.OPSO_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON OPENINGSALEORDER_DESC.OPSO_COLORID = COLOR_ID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON OPENINGSALEORDER.OPSO_TRANSID = TRANSLEDGERS.ACC_ID LEFT OUTER JOIN CITYMASTER ON OPENINGSALEORDER.OPSO_CITYID = CITYMASTER.CITY_ID WHERE OPENINGSALEORDER.OPSO_YEARID = " & YearId & OPWHERE & ") AS T", " ORDER BY T.DATE, T.SONO, T.GRIDSRNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("DATE")
            DT.Columns.Add("NAME")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("DESIGN")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("QTY")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("PONO")
            DT.Columns.Add("AGENTNAME")
            DT.Columns.Add("TRANSNAME")
            DT.Columns.Add("CITYNAME")
            DT.Columns.Add("DELIVERYAT")
            DT.Columns.Add("REFNO")
            DT.Columns.Add("RATE")
            DT.Columns.Add("SONO")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("TYPE")
            DT.Columns.Add("GRIDPARTYPONO")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("DATE"), dtrow("NAME"), dtrow("ITEMNAME"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("QTY")), Val(dtrow("MTRS")), dtrow("PONO"), dtrow("AGENTNAME"), dtrow("TRANSNAME"), dtrow("CITYNAME"), dtrow("DELIVERYAT"), dtrow("REFNO"), Val(dtrow("RATE")), Val(dtrow("SONO")), Val(dtrow("GRIDSRNO")), dtrow("TYPE"), dtrow("GRIDPARTYPONO"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class