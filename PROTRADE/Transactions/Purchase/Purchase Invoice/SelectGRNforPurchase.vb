
Imports System.Windows.Forms
Imports BL

Public Class SelectGRNforPurchase

    Public ENQname As String = ""  'for whereclause in fillgrid
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRNforPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectGRNforPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
        gridbilldetails.ForceInitialize()
        gridbill.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
    End Sub

    Sub FILLGRID(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" T.*, '' AS DESIGNNO, '' AS SHADE ", "", " (SELECT CAST (0 AS BIT) AS CHK, GRN.grn_no AS SRNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.GRN_TYPE AS TYPE, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE, GRN.GRN_TOTALQTY AS TOTALPCS, GRN.GRN_TOTALMTRS AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(GRN.grn_lrno, '') AS LRNO, ISNULL(GRN.grn_PLOTNO, '') AS LOTNO FROM GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GRN.grn_transledgerid = TRANSLEDGERS.Acc_id where GRN.GRN_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND GRN.GRN_YEARID = " & YearId & " UNION ALL SELECT  DISTINCT CAST(0 AS BIT) AS CHK, MATERIALRECEIPT.MATREC_NO AS SRNO, MATERIALRECEIPT.MATREC_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'MATREC' AS TYPE, MATERIALRECEIPT.MATREC_CHALLANNO AS CHALLANNO, MATERIALRECEIPT.MATREC_CHALLANDATE AS CHALLANDATE, SUM(MATERIALRECEIPT_DESC.MATREC_QTY) AS TOTALPCS, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS) AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(MATERIALRECEIPT.MATREC_LRNO, '') AS LRNO, ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, '') AS LOTNO FROM MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id WHERE (MATERIALRECEIPT.MATREC_DONE = 0) AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND MATERIALRECEIPT.MATREC_YEARID = " & YearId & " GROUP BY MATERIALRECEIPT.MATREC_NO, MATERIALRECEIPT.MATREC_DATE, LEDGERS.Acc_cmpname, MATERIALRECEIPT.MATREC_CHALLANNO, MATERIALRECEIPT.MATREC_CHALLANDATE, ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(MATERIALRECEIPT.MATREC_LRNO, ''), ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, '')   UNION ALL  SELECT CAST (0 AS BIT) AS CHK, JOBIN.JI_NO AS SRNO, JOBIN.JI_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'JOBIN' AS TYPE, JOBIN.JI_CHALLANNO AS CHALLANNO, JOBIN.JI_CHALLANDATE AS CHALLANDATE, JOBIN.JI_TOTALQTY AS TOTALPCS, JOBIN.JI_TOTALMTRS AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(JOBIN.JI_LRNO, '') AS LRNO, ISNULL(JOBIN.JI_LOTNO,'') AS LOTNO FROM JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBIN.JI_transledgerid = TRANSLEDGERS.Acc_id where JOBIN.JI_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND JOBIN.JI_YEARID = " & YearId & " UNION ALL SELECT CAST (0 AS BIT) AS CHK, GREYRECDKNITTING.GREY_NO AS SRNO, GREYRECDKNITTING.GREY_date AS DATE, LEDGERS.Acc_cmpname AS NAME, 'GREY' AS TYPE, GREYRECDKNITTING.GREY_challanno AS CHALLANNO, GREYRECDKNITTING.GREY_CHALLANDATE AS CHALLANDATE, GREYRECDKNITTING.GREY_TOTALQTY AS TOTALPCS, GREYRECDKNITTING.GREY_TOTALWT AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(GREYRECDKNITTING.GREY_LRNO, '') AS LRNO, '' AS LOTNO FROM  GREYRECDKNITTING INNER JOIN LEDGERS ON GREYRECDKNITTING.GREY_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GREYRECDKNITTING.GREY_transledgerid = TRANSLEDGERS.Acc_id where GREYRECDKNITTING.GREY_DONE = 0 AND  LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND GREYRECDKNITTING.GREY_YEARID = " & YearId & " UNION ALL SELECT CAST (0 AS BIT) AS CHK, YARNRECD.YARN_NO AS SRNO, YARNRECD.YARN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, 'YARNRECD' AS TYPE, YARNRECD.YARN_challanno AS CHALLANNO, YARNRECD.YARN_challandt AS CHALLANDATE, YARNRECD.YARN_TOTALQTY AS TOTALPCS, YARNRECD.YARN_TOTALWT AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, '' AS LRNO, '' AS LOTNO FROM  YARNRECD INNER JOIN LEDGERS ON YARNRECD.YARN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNRECD.YARN_transledgerid = TRANSLEDGERS.Acc_id where YARNRECD.YARN_DONE = 0 AND  LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND YARNRECD.YARN_YEARID = " & YearId & " UNION ALL SELECT CAST (0 AS BIT) AS CHK, YARNRECDJOBBER.YARN_NO AS SRNO, YARNRECDJOBBER.YARN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, 'YARNRECDJOBBER' AS TYPE, YARNRECDJOBBER.YARN_challanno AS CHALLANNO, YARNRECDJOBBER.YARN_challandt AS CHALLANDATE, YARNRECDJOBBER.YARN_TOTALQTY AS TOTALPCS, YARNRECDJOBBER.YARN_TOTALWT AS TOTALMTRS, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, '' AS LRNO, '' AS LOTNO FROM  YARNRECDJOBBER INNER JOIN LEDGERS ON YARNRECDJOBBER.YARN_TOLEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNRECDJOBBER.YARN_transledgerid = TRANSLEDGERS.Acc_id where YARNRECDJOBBER.YARN_DONE = 0 AND  LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND YARNRECDJOBBER.YARN_YEARID = " & YearId & " UNION ALL SELECT CAST (0 AS BIT) AS CHK, BEAMRECEIVEDWARPER.BEAMREC_no AS SRNO, BEAMRECEIVEDWARPER.BEAMREC_date AS DATE, LEDGERS.Acc_cmpname AS NAME, 'BEAMRECEIVED' AS TYPE, BEAMRECEIVEDWARPER.BEAMREC_challanno AS CHALLANNO, BEAMRECEIVEDWARPER.BEAMREC_date AS CHALLANDATE, BEAMRECEIVEDWARPER.BEAMREC_TOTALBEAM AS TOTALPCS, BEAMRECEIVEDWARPER.BEAMREC_TOTALWT AS TOTALMTRS, '' AS TRANSNAME, '' AS LRNO, '' AS LOTNO FROM BEAMRECEIVEDWARPER INNER JOIN LEDGERS ON BEAMRECEIVEDWARPER.BEAMREC_ledgerid = LEDGERS.Acc_id where BEAMRECEIVEDWARPER.BEAMREC_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND BEAMRECEIVEDWARPER.BEAMREC_YEARID = " & YearId & ") AS T ", where & "  ORDER BY TYPE, SRNO")
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
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon

            DT.Columns.Add("SRNO")
            DT.Columns.Add("TYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("SRNO"), dtrow("TYPE"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = CHKALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectGRNforPurchase_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "AVIS" Then
                GDESIGNNO.Visible = False
                GSHADE.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class