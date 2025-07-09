
Imports BL

Public Class GroupRegister

    Dim STRSEARCH As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub TOTAL()
        Try

            TXTDEBIT.Text = 0.0
            TXTCREDIT.Text = 0.0

            Dim DT As DataTable = griddetails.DataSource
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    TXTDEBIT.Text = Format(Val(TXTDEBIT.Text.Trim) + DTROW("DEBIT"), "0.00")
                    TXTCREDIT.Text = Format(Val(TXTCREDIT.Text.Trim) + DTROW("CREDIT"), "0.00")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsGroupRegister

        STRSEARCH = WHERECLAUSE

        ALPARAVAL.Add(WHERECLAUSE)
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        dt = objregister.GROUPSUMMARY
        griddetails.DataSource = dt

        TOTAL()

    End Sub

    Private Sub GroupRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
            cmbname.Text = "Name"
            TXTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        TOTAL()
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                Dim GROUPNAME As String = dtrow("GROUPNAME")
                If GROUPNAME <> "" Then
                    Dim objlb As New LedgerSummary
                    objlb.STRSEARCH = " AND TRIALBALANCE.GROUP_NAME = '" & GROUPNAME & "'"
                    objlb.MdiParent = MDIMain
                    objlb.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        fillgrid(" AND TRIALBALANCE.group_NAME = '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Main Group" Then
                        fillgrid(" AND TRIALBALANCE.secondary= '" & TXTNAME.Text.Trim & "'")
                    ElseIf cmbname.Text = "Under" Then
                        fillgrid(" AND TRIALBALANCE.UNDER= '" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Name" Then
                        fillgrid(" AND TRIALBALANCE.GROUP_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Main Group" Then
                        fillgrid(" AND TRIALBALANCE.SECONDARY LIKE '%" & TXTNAME.Text.Trim & "%'")
                    ElseIf cmbname.Text = "Under" Then
                        fillgrid(" AND TRIALBALANCE.UNDER  LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If

                End If
            Else
                'FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim OBJSUMM As New summarydesign
            OBJSUMM.MdiParent = MDIMain
            OBJSUMM.strsearch = STRSEARCH
            OBJSUMM.frmstring = "GROUPSUMMARY"
            OBJSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Group Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Group Register"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Group Register", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Group Register Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GroupRegister_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class