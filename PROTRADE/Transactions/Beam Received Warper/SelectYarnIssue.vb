Imports BL

Public Class SelectYarnIssue

    Public SIZERNAME As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectYarnIssue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectYarnIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID(" ")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If SIZERNAME <> "" Then WHERE = WHERE & " AND LEDGERS.ACC_CMPNAME = '" & SIZERNAME & "'"

            Dim objcmn As New ClsCommon
            ' Dim dt As DataTable = objcmn.search(" CAST(0 AS BIT) AS CHK,  YARNISSUEADDA.YISSUEADDA_no AS ENTRYNO, YARNISSUEADDA.YISSUEADDA_date AS DATE, 'YARNISSUEADDA'  AS TYPE, YARNISSUEADDA.YISSUEADDA_TOTALBAGS AS BAGS, YARNISSUEADDA.YISSUEADDA_TOTALWT AS WT, ISNULL(YARNISSUEADDA.YISSUEADDA_ADDANO,0) AS ADDANO, ADDADESC.QUALITY, ADDADESC.MILLNAME ", "", "  YARNISSUEADDA INNER JOIN LEDGERS ON YARNISSUEADDA.YISSUEADDA_ledgerid = LEDGERS.Acc_id  CROSS APPLY (SELECT TOP 1 ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITY, ISNULL(MILLLEDGERS.ACC_CMPNAME,'') AS MILLNAME  FROM YARNISSUEADDA_DESC INNER JOIN QUALITYMASTER ON YARNISSUEADDA_DESC.YISSUEADDA_QUALITYID = QUALITY_ID LEFT OUTER JOIN LEDGERS AS MILLLEDGERS ON YARNISSUEADDA_DESC.YISSUEADDA_MILLID = MILLLEDGERS.ACC_ID WHERE  YARNISSUEADDA.YISSUEADDA_no = YARNISSUEADDA_DESC.YISSUEADDA_NO AND YARNISSUEADDA.YISSUEADDA_yearid = YARNISSUEADDA_DESC.YISSUEADDA_YEARID ) AS ADDADESC ", WHERE & " AND ISNULL(YARNISSUEADDA.YISSUEADDA_ADDARECD,0) = 0 AND YARNISSUEADDA.YISSUEADDA_YEARID = " & YearId)
            Dim DT As DataTable = objcmn.search(" CAST(0 AS BIT) AS CHK , NO, DATE,YARNQUALITY, MILLNAME, NAME, DESIGNNO, COLOR, LOTNO, CONES, BAGS, WT, RECDCONES, RECDBAGS, RECDWT, TYPE", "", " JOBBERYARNSTOCKREGISTER ", " AND YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
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

            DT.Columns.Add("NO")
            DT.Columns.Add("TYPE")
            ' DT.Columns.Add("ADDANO")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then

                    'DT.Rows.Add(dtrow("ENTRYNO"), dtrow("TYPE"), Val(dtrow("ADDANO")))
                    DT.Rows.Add(dtrow("NO"), dtrow("TYPE"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class