
Imports BL

Public Class SelectChallanforTrans

    Public DT As New DataTable
    Public PARTYNAME As String = ""

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("TYPECHALLANNO")
            DT.Columns.Add("CHALLANNO")
            DT.Columns.Add("TOTALBALES")
            DT.Columns.Add("TOTALPCS")
            DT.Columns.Add("TOTALMTRS")
            DT.Columns.Add("TRANSNAME")
            DT.Columns.Add("DISPATCHTO")
            DT.Columns.Add("TOCITY")
            DT.Columns.Add("TOTALAMT")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("TYPECHALLANNO")), Val(dtrow("CHALLANNO")), Val(dtrow("TOTALBALES")), Val(dtrow("TOTALPCS")), Val(dtrow("TOTALMTRS")), dtrow("TRANSNAME"), dtrow("DISPATCHTO"), dtrow("TOCITY"), Val(dtrow("TOTALAMT")))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
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

    Private Sub SelectItemSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal tempcondition)
        Try
            If PARTYNAME <> "" Then tempcondition = tempcondition & " AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "'"
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If ClientName = "KDFAB" Or ClientName = "SANGHVI" Then
                dt = objclsCMST.search(" CAST (0 AS BIT) AS CHK , ISNULL(GDN.GDN_TYPENO, 0) AS TYPECHALLANNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(GDN.GDN_BALENOFROM, 0) AS TOTALBALES, ISNULL(GDN.GDN_TOTALPCS, 0) AS TOTALPCS, ISNULL(GDN.GDN_TOTALMTRS, 0) AS TOTALMTRS,ISNULL(GDN.GDN_NO, 0) AS CHALLANNO, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(DISPATCHLEDGERS.Acc_cmpname, '') AS DISPATCHTO, ISNULL(CITY_NAME, '') AS TOCITY, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT ", " ", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON TRANSLEDGERS.ACC_ID = GDN.GDN_TRANSID LEFT OUTER JOIN LEDGERS AS DISPATCHLEDGERS ON DISPATCHLEDGERS.ACC_ID = GDN.GDN_DISPATCHTOID LEFT OUTER JOIN CITYMASTER ON CITY_ID = GDN.GDN_CITYID ", " AND ISNULL(GDN_TRANSCHALLANDONE,0) = 'FALSE' " & tempcondition)
            ElseIf ClientName = "MANIBHADRA" Then
                dt = objclsCMST.search(" CAST(0 AS BIT) AS CHK, ISNULL(GDN.GDN_TYPENO, 0) AS TYPECHALLANNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(GDN.GDN_BALENOFROM, 0) AS TOTALBALES, SUM(ISNULL(GDN_DESC.GDN_PCS, 0)) AS TOTALPCS, SUM(ISNULL(GDN_DESC.GDN_MTRS, 0)) AS TOTALMTRS, ISNULL(GDN.GDN_NO, 0) AS CHALLANNO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(DISPATCHLEDGERS.Acc_cmpname, '') AS DISPATCHTO, ISNULL(CITYMASTER.city_name, '') AS TOCITY, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT ", " ", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON TRANSLEDGERS.Acc_id = GDN.GDN_transid LEFT OUTER JOIN LEDGERS AS DISPATCHLEDGERS ON DISPATCHLEDGERS.Acc_id = GDN.GDN_DISPATCHTOID LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = GDN.GDN_CITYid  ", tempcondition & " AND ISNULL(GDN_TRANSCHALLANDONE,0) = 'FALSE' GROUP BY ISNULL(GDN.GDN_TYPENO, 0), ISNULL(LEDGERS.Acc_cmpname, ''), ISNULL(GDN.GDN_date, GETDATE()), ISNULL(GDN.GDN_BALENOFROM, 0), ISNULL(GDN.GDN_NO, 0), ISNULL(TRANSLEDGERS.Acc_cmpname, ''), ISNULL(DISPATCHLEDGERS.Acc_cmpname, ''), ISNULL(CITYMASTER.city_name, ''), ISNULL(GDN.GDN_TOTALAMT, 0), GDN_DESC.GDN_ITEMID")
            Else
                dt = objclsCMST.search(" CAST (0 As BIT) As CHK , ISNULL(GDN.GDN_TYPENO, 0) As TYPECHALLANNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GDN.GDN_date, GETDATE()) AS DATE, ISNULL(GDN.GDN_TOTALBALES, 0) AS TOTALBALES, ISNULL(GDN.GDN_TOTALPCS, 0) AS TOTALPCS, ISNULL(GDN.GDN_TOTALMTRS, 0) AS TOTALMTRS,ISNULL(GDN.GDN_NO, 0) AS CHALLANNO, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(DISPATCHLEDGERS.ACC_CMPNAME,'') AS DISPATCHTO, ISNULL(CITY_NAME, '') AS TOCITY, ISNULL(GDN.GDN_TOTALAMT, 0) AS TOTALAMT ", " ", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON TRANSLEDGERS.ACC_ID = GDN.GDN_TRANSID LEFT OUTER JOIN LEDGERS AS DISPATCHLEDGERS ON DISPATCHLEDGERS.ACC_ID = GDN.GDN_DISPATCHTOID LEFT OUTER JOIN CITYMASTER ON CITY_ID = GDN.GDN_CITYID ", " AND ISNULL(GDN_TRANSCHALLANDONE,0) = 'FALSE' " & tempcondition)
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

    Private Sub ChallanTransportPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID(" and GDN.gdn_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SelectChallanforTrans_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName <> "SAFFRON" Then
                GTYPENO.Visible = False
                GCHALLANNO.VisibleIndex = 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class