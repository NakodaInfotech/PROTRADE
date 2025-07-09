
Imports BL

Public Class OpeningBalance

    Private Sub OpeningBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION As String)
        Try
            Dim objclsCOMMON As New ClsCommonMaster
            Dim dt As DataTable
            If cmbgroup.Text.Trim <> "" And RDBGROUP.Checked = True Then TEMPCONDITION = TEMPCONDITION & " AND GROUPMASTER.GROUP_NAME = '" & cmbgroup.Text.Trim & "'"
            TEMPCONDITION = TEMPCONDITION & " and dbo.LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_locationid = " & Locationid & " and LEDGERS.ACC_yearid = " & YearId
            dt = objclsCOMMON.search("   LEDGERS.Acc_cmpname AS NAME, ISNULL(LEDGERS.Acc_code, '') AS CODE, ISNULL(GROUPMASTER.group_name, '') AS [GROUP], (CASE WHEN ISNULL(LEDGERS.Acc_drcr, 'Dr.') = 'Dr.'  THEN ISNULL(LEDGERS.Acc_opbal, 0) ELSE 0 END) AS DEBIT, (CASE WHEN ISNULL(LEDGERS.Acc_drcr, 'Dr.') = 'Cr.'  THEN ISNULL(LEDGERS.Acc_opbal, 0) ELSE 0 END) AS CREDIT ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id", TEMPCONDITION)
            gridname.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridledger.FocusedRowHandle = gridledger.RowCount - 1
                gridledger.TopRowIndex = gridledger.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim.Length > 0 Then
                cmbgroup.Text = UCase(cmbgroup.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" group_id ", "", " GroupMaster ", " and group_name ='" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_locationid = " & Locationid & " and group_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    fillgrid("")
                Else
                    MsgBox("Group Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBALL.CheckedChanged
        Try
            If RDBALL.Checked = True Then
                cmbgroup.Text = ""
                cmbgroup.Enabled = False
                fillgrid("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLEDGER_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridledger.InvalidRowException
        Try
            e.ErrorText = "Debit & Credit both are not Allowed"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridledger.ValidateRow
        Try
            If gridledger.GetFocusedRowCellValue("DEBIT") > 0 And gridledger.GetFocusedRowCellValue("CREDIT") > 0 Then e.Valid = False
            gridledger.SetColumnError(gridledger.Columns("DEBIT"), "Debit & Credit both are not Allowed", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBGROUP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBGROUP.CheckedChanged
        Try
            If RDBGROUP.Checked = True Then cmbgroup.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If RDBALL.Checked = True Then
                EP.SetError(RDBALL, "Save Not Allowed for Ledger, Select Group wise for Saving")
                bln = False
            End If

            If gridledger.RowCount = 0 Then
                EP.SetError(gridname, "Select Ledger !")
                bln = False
            End If
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer = 0

            Dim alParaval As New ArrayList


            Dim NAME As String = ""
            Dim DEBIT As String = ""
            Dim CREDIT As String = ""


            For i As Integer = 0 To gridledger.RowCount - 1
                Dim dtrow As DataRow = gridledger.GetDataRow(i)
                If NAME = "" Then
                    NAME = (dtrow("NAME"))
                    DEBIT = Val(dtrow("DEBIT"))
                    CREDIT = Val(dtrow("CREDIT"))
                Else
                    NAME = NAME & "|" & (dtrow("NAME"))
                    DEBIT = DEBIT & "|" & Val(dtrow("DEBIT"))
                    CREDIT = CREDIT & "|" & Val(dtrow("CREDIT"))
                End If
            Next

            alParaval.Add(NAME)
            alParaval.Add(DEBIT)
            alParaval.Add(CREDIT)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim OBJMATCHING As New ClsOpening()
            OBJMATCHING.alParaval = alParaval

            IntResult = OBJMATCHING.OPENINGSAVE()
            MessageBox.Show("Details Added")
            RDBALL.Checked = True
            cmbgroup.Text = ""
            cmbgroup.Enabled = False

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub OpeningBalance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
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

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Opening Balance Details.XLS"

            '' Dim PATH As String = "D:\Opening Balance Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Opening Balance Details"
            gridledger.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Opening Balance Details", gridledger.VisibleColumns.Count + gridledger.GroupCount)

        Catch ex As Exception
            MsgBox("Opening Bal Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class