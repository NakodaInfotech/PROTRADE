
Imports BL

Public Class SelectLedger

    Public STRSEARCH As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPNAME, TEMPCODE, TEMPTRANS, TEMPAGENT As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectLedger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectLedger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID("")
            cmbname.Text = "Name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("  ISNULL(LEDGERS.Acc_cmpname,'') AS LEDGERNAME, ISNULL(LEDGERS.Acc_code,'') AS CODE, ISNULL(GROUPMASTER.group_secondary,'') AS [GROUP], ISNULL(CITYMASTER.city_name,'') AS CITY, ISNULL(LEDGERS_1.Acc_cmpname,'') AS TRANSNAME, ISNULL(LEDGERS_2.Acc_cmpname,'') AS AGENT ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_yearid = CITYMASTER.city_yearid ", STRSEARCH & WHERECLAUSE & " AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId & " order by LEDGERS.Acc_cmpname")
            Dim DT As DataTable = OBJCMN.search("  ISNULL(LEDGERS.Acc_cmpname, '') AS LEDGERNAME, ISNULL(LEDGERS.Acc_code, '') AS CODE, ISNULL(GROUPMASTER.group_NAME, '') AS [GROUP], ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(LEDGERS_1.Acc_cmpname, '') AS TRANSNAME, ISNULL(LEDGERS_2.Acc_cmpname, '') AS AGENT, ISNULL(AREAMASTER.area_name, '') AS AREA, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN AREAMASTER ON LEDGERS.Acc_areaid = AREAMASTER.area_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND  LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_yearid = CITYMASTER.city_yearid ", STRSEARCH & WHERECLAUSE & " AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId & " order by LEDGERS.Acc_cmpname")

            GRIDHOTEL.DataSource = DT

            GRIDHOTEL.Columns(0).HeaderText = "Name"
            GRIDHOTEL.Columns(0).Width = 260

            GRIDHOTEL.Columns(1).HeaderText = "Code"
            GRIDHOTEL.Columns(1).Width = 100

            GRIDHOTEL.Columns(2).HeaderText = "Group"
            GRIDHOTEL.Columns(2).Width = 150

            GRIDHOTEL.Columns(3).HeaderText = "City"
            GRIDHOTEL.Columns(3).Width = 100
            GRIDHOTEL.Columns(4).Visible = False
            GRIDHOTEL.Columns(5).Visible = False

            GRIDHOTEL.Columns(6).HeaderText = "Area"
            GRIDHOTEL.Columns(6).Width = 100

            GRIDHOTEL.Columns(7).HeaderText = "Address"
            GRIDHOTEL.Columns(7).Width = 340

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDHOTEL.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
                TEMPTRANS = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(4).Value
                TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(5).Value
            Else
                TEMPNAME = ""
                TEMPCODE = ""
                TEMPTRANS = ""
                TEMPAGENT = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.CellDoubleClick
        Try
            If GRIDHOTEL.Rows.Count > 0 Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDHOTEL.Item(0, GRIDHOTEL.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDHOTEL.RowCount > 0) Then
                Dim objaccountsmaster As New AccountsMaster
                objaccountsmaster.MdiParent = MDIMain
                objaccountsmaster.edit = editval
                objaccountsmaster.tempAccountsName = TXTNAME.Text.Trim()
                objaccountsmaster.tempAccountsCode = TEMPCODE
                objaccountsmaster.frmstring = "ACCOUNTS"
                'objaccountsmaster.tempAccountsName = name
                objaccountsmaster.Show()
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNAME.TextChanged
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND LEDGERS.ACC_CMPNAME like '%" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND LEDGERS.ACC_CODE like '%" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Group" Then
                        FILLGRID(" AND GROUPMASTER.GROUP_NAME like '%" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "City" Then
                        FILLGRID(" AND CITYMASTER.CITY_NAME  like '%" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        FILLGRID(" AND LEDGERS.ACC_CMPNAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Code" Then
                        FILLGRID(" AND LEDGERS.ACC_CODE LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Group" Then
                        FILLGRID(" AND GROUPMASTER.GROUP_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "City" Then
                        FILLGRID(" AND CITYMASTER.CITY_NAME  LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If

                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOTEL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDHOTEL.KeyDown
        Try
            If e.KeyCode = Keys.Enter And GRIDHOTEL.RowCount > 0 Then

                If GRIDHOTEL.SelectedRows.Count > 0 Then
                    TEMPNAME = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(0).Value
                    TEMPCODE = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(1).Value
                    TEMPTRANS = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(4).Value
                    TEMPAGENT = GRIDHOTEL.Rows(GRIDHOTEL.SelectedRows(0).Index).Cells(5).Value
                Else
                    TEMPNAME = ""
                    TEMPCODE = ""
                    TEMPTRANS = ""
                    TEMPAGENT = ""
                End If
                Me.Close()
           
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class