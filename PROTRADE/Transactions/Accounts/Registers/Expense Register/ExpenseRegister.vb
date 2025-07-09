
Imports BL

Public Class ExpenseRegister

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ExpenseRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExpenseRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            gridregister.RowCount = 0

            Dim OBJJVREG As New ClsExpenseRegister
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

            ALPARAVAL.Add(cmbregister.Text.Trim)
            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(1)
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(0)
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJJVREG.alParaval = ALPARAVAL
            DT = OBJJVREG.getdata()

            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    gridregister.Rows.Add(MonthName(DTROW(0)), Val(DTROW(1).ToString))
                Next
            End If

            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            txtclosing.Text = "0.00"
            For Each row As DataGridViewRow In gridregister.Rows
                txtclosing.Text = Val(txtclosing.Text) + Val(row.Cells(1).Value)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dtto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtto.Validated
        Try
            If chkdate.CheckState = CheckState.Checked Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'EXPENSE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EXPENSE' and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Validated
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        SHOWFORM()
    End Sub

    Sub SHOWFORM()
        Try
            Dim OBJEXP As New ExpenseRegisterDetails
            OBJEXP.NPREGNAME = cmbregister.Text.Trim
            OBJEXP.FromDate = getfirstdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
            OBJEXP.ToDate = getlastdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
            OBJEXP.MdiParent = MDIMain
            OBJEXP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridregister.CellDoubleClick
        SHOWFORM()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign


            objreg.frmstring = "ExpenseRegisterMonthly"
            objreg.reg = cmbregister.Text.Trim

            If chkdate.CheckState = CheckState.Checked Then
                objreg.CHECK = 1
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
            Else
                objreg.CHECK = 0
                objreg.FROMDATE = AccFrom
                objreg.TODATE = AccTo
            End If
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class