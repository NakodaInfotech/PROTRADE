
Imports BL

Public Class SelectLot

    Public DT As New DataTable

    Sub fillgrid(ByVal WHERE As String)
        Try
            Dim JOBINQUERY As String = " UNION ALL SELECT DISTINCT CAST (0 AS BIT) AS CHK , JOBIN.JI_NO AS SRNO, JOBIN.JI_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, GODOWNMASTER.GODOWN_name AS GODOWN, JOBIN.JI_LOTNO AS LOTNO, JOBIN.JI_TOTALQTY AS TOTALPCS, JOBIN.JI_TOTALMTRS AS TOTALMTRS, 'JOBIN' AS TYPE FROM JOBIN INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON JOBIN.JI_GODOWNID = GODOWNMASTER.GODOWN_id inner join JOBIN_DESC ON JOBIN.JI_NO = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID WHERE JI_INHOUSECHECKDONE = 0 AND JOBIN.JI_YEARID = " & YearId

            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon()
            Dim DT As DataTable = OBJCMN.search(" * ", "", "(SELECT DISTINCT CAST (0 AS BIT) As CHK , MATERIALRECEIPT.MATREC_NO As SRNO, MATERIALRECEIPT.MATREC_DATE As Date, LEDGERS.Acc_cmpname As NAME, GODOWNMASTER.GODOWN_name As GODOWN, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO As LOTNO, MATERIALRECEIPT.MATREC_TOTALQTY As TOTALPCS, MATERIALRECEIPT.MATREC_TOTALRECDMTR As TOTALMTRS, 'MATREC' AS TYPE FROM MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON MATERIALRECEIPT.MATREC_GODOWNID = GODOWNMASTER.GODOWN_id inner join MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID WHERE MATREC_INHOUSECHECKDONE = 0 AND MATERIALRECEIPT.MATREC_YEARID = " & YearId & JOBINQUERY & " UNION ALL SELECT CAST (0 AS BIT) AS CHK , GRN.GRN_NO AS SRNO, GRN.GRN_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, GODOWNMASTER.GODOWN_name AS GODOWN, (CASE WHEN ISNULL(GRN.grn_PLOTNO,'') <> '' THEN ISNULL(GRN.GRN_PLOTNO,'') ELSE ISNULL(GRN.GRN_CHALLANNO,'') END) AS LOTNO, GRN.GRN_TOTALQTY AS TOTALPCS, GRN.GRN_TOTALMTRS AS TOTALMTRS, 'GRN' AS TYPE FROM GRN INNER JOIN LEDGERS ON GRN.GRN_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id WHERE GRN_TYPE = 'FANCY MATERIAL' and GRN.GRN_YEARID = " & YearId & " AND ISNULL(GRN.GRN_INHOUSECHECKDONE,0) = 0) AS T", "")
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
            Dim COUNT As Integer = 0
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next
            If COUNT > 1 Then
                MsgBox("You Can Select Only One Entry")
                Exit Sub
            End If


            DT.Columns.Add("MATRECNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("GODOWN")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("TYPE")
            
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("SRNO"), dtrow("NAME"), dtrow("GODOWN"), dtrow("LOTNO"), dtrow("TYPE"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectRolls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectRolls_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class