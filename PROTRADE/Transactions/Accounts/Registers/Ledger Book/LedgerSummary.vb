
Imports BL
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid


Public Class LedgerSummary

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public STRSEARCH As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        TXTDEBIT.Clear()
        TXTCREDIT.Clear()

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsLedgerBook

        STRSEARCH = WHERECLAUSE + STRSEARCH

        ALPARAVAL.Add(STRSEARCH)
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        dt = objregister.LEDGERSUMMARY
        griddetails.DataSource = dt

        TOTAL()
    End Sub

    Private Sub LedgerSummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                fillgrid(STRSEARCH)
            ElseIf e.KeyCode = Keys.Enter Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid(STRSEARCH)
            cmbname.Text = "Name"
            TXTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            Dim DT As DataTable = griddetails.DataSource
            TXTDEBIT.Clear()
            TXTCREDIT.Clear()

            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    TXTDEBIT.Text = Format(Val(TXTDEBIT.Text.Trim) + DTROW("DEBIT"), "0.00")
                    TXTCREDIT.Text = Format(Val(TXTCREDIT.Text.Trim) + DTROW("CREDIT"), "0.00")
                Next
                TXTCLOSING.Text = Format(Val(TXTDEBIT.Text.Trim) - Val(TXTCREDIT.Text.Trim), "0.00")
                If Val(TXTCLOSING.Text.Trim) < 0 Then TXTCLOSING.Text = Format(Val(TXTCLOSING.Text.Trim) * (-1), "0.00")
            End If
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
                Dim NAME As String = dtrow("NAME")
                If NAME <> "" Then
                    If rbdetailed.Checked = True Then
                        Dim objlb As New RegisterDetails
                        objlb.cmbname.Text = NAME
                        objlb.fillgrid()
                        objlb.MdiParent = MDIMain
                        objlb.Show()
                    ElseIf rbmonthly.Checked = True Then
                        Dim objlb As New LedgerMonthly
                        objlb.cmbname.Text = NAME
                        objlb.fillgrid()
                        objlb.MdiParent = MDIMain
                        objlb.Show()
                    ElseIf rbdaily.Checked = True Then
                        Dim objlb As New LedgerDaily
                        objlb.cmbname.Text = NAME
                        objlb.fillgrid()
                        objlb.MdiParent = MDIMain
                        objlb.Show()
                    ElseIf rbbillwise.Checked = True Then
                        Dim objlb As New LedgerBillwise
                        objlb.cmbname.Text = NAME
                        objlb.fillgrid()
                        objlb.MdiParent = MDIMain
                        objlb.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNAME.KeyPress
        Try
            'If cmbname.Text = "Name" Then
            '    gridregister.FocusedColumn = gridregister.Columns("NAME")
            'ElseIf cmbname.Text = "Group" Then
            '    gridregister.FocusedColumn = gridregister.Columns("GROUPNAME")
            'ElseIf cmbname.Text = "City" Then
            '    gridregister.FocusedColumn = gridregister.Columns("CITY")
            'End If


            'gridregister.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
            'gridregister.ShowEditor()
            'gridregister.ActiveEditor.Text = TXTNAME.Text.Trim & e.KeyChar

            'gridregister.FocusedColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
            'gridregister.FocusedColumn.FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(TXTNAME.Text.Trim & e.KeyChar)

            'gridregister.StartIncrementalSearch(TXTNAME.Text.Trim & e.KeyChar)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Try
            'If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
            '    If rbstart.Checked = True Then
            '        If cmbname.Text = "Name" Then
            '            fillgrid(" AND TRIALBALANCE.NAME = '" & TXTNAME.Text.Trim & "'")
            '        ElseIf cmbname.Text = "Group" Then
            '            fillgrid(" AND TRIALBALANCE.GROUP_NAME= '" & TXTNAME.Text.Trim & "'")
            '        ElseIf cmbname.Text = "City" Then
            '            fillgrid(" AND CITYMASTER.CITY_NAME  = '" & TXTNAME.Text.Trim & "'")
            '        End If
            '    ElseIf rbpart.Checked = True Then
            '        If cmbname.Text = "Name" Then
            '            fillgrid(" AND TRIALBALANCE.NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
            '        ElseIf cmbname.Text = "Group" Then
            '            fillgrid(" AND TRIALBALANCE.GROUP_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
            '        ElseIf cmbname.Text = "City" Then
            '            fillgrid(" AND CITYMASTER.CITY_NAME  LIKE '%" & TXTNAME.Text.Trim & "%'")
            '        End If

            '    End If
            'Else
            '    fillgrid(STRSEARCH)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim OBJSUMM As New summarydesign
            OBJSUMM.MdiParent = MDIMain
            OBJSUMM.strsearch = STRSEARCH
            OBJSUMM.frmstring = "LEDGERSUMMARY"
            OBJSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ledger Summary.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Ledger Summary"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Summary", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Ledger Summary Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LedgerSummary_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid(STRSEARCH)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class