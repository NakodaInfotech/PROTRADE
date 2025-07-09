
Imports System.ComponentModel
Imports BL

Public Class UnusedLedgers
    Private Sub UnusedLedgers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "Group_name"
                cmbgroup.DataSource = dt
                cmbgroup.DisplayMember = "group_name"
                cmbgroup.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim WHERECLAUSE As String = " AND LEDGERS.ACC_ID NOT IN (SELECT DISTINCT ISNULL(USEDLEDGERS.LEDGERID,0) FROM USEDLEDGERS WHERE YEARID = " & YearId & ")"
            If cmbgroup.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPMASTER.GROUP_NAME = '" & cmbgroup.Text.Trim & "'"
            Dim objclsCOMMON As New ClsCommonMaster
            Dim dt As DataTable = objclsCOMMON.search(" CAST(0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, LEDGERS.ACC_ID AS ACCID ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id", " AND LEDGERS.ACC_YEARID = " & YearId & WHERECLAUSE & " ORDER BY LEDGERS.ACC_CMPNAME ")
            gridname.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridledger.FocusedRowHandle = gridledger.RowCount - 1
                gridledger.TopRowIndex = gridledger.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(sender As Object, e As CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim.Length > 0 Then
                cmbgroup.Text = UCase(cmbgroup.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable = clscommon.search(" group_id ", "", " GroupMaster ", " and group_name ='" & cmbgroup.Text.Trim & "' and group_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    MsgBox("Group Not Present, Add New from Master Module")
                    e.Cancel = True
                    Exit Sub
                End If
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try

            If MsgBox("Wish To Delete Selected Ledgers?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            For I As Integer = 0 To gridledger.RowCount - 1
                Dim DTROW As DataRow = gridledger.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CHK")) = True Then
                    Dim OBJACC As New ClsAccountsMaster
                    OBJACC.alParaval.Add(DTROW("NAME"))
                    OBJACC.alParaval.Add(CmpId)
                    OBJACC.alParaval.Add(Locationid)
                    OBJACC.alParaval.Add(YearId)
                    Dim DT As DataTable = OBJACC.DELETE()
                End If
            Next
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            For i As Integer = 0 To gridledger.RowCount - 1
                Dim dtrow As DataRow = gridledger.GetDataRow(i)
                dtrow("CHK") = CHKSELECTALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class