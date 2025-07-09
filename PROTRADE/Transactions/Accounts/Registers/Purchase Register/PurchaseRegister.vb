
Imports BL

Public Class PurchaseRegister

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            gridregister.RowCount = 0

            Dim OBJPURREG As New ClsPurchaseRegister
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

            OBJPURREG.alParaval = ALPARAVAL
            DT = OBJPURREG.getdata()

            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    gridregister.Rows.Add(MonthName(DTROW(0)), Format(Val(DTROW("DEBIT").ToString), "0.00"), Format(Val(DTROW("CREDIT").ToString), "0.00"), "0.00")
                Next
            End If

            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            'txtdr.Text = "0.00"
            'txtcr.Text = "0.00"
            'txtclosing.Text = "0.00"
            'lbldrcr.Text = "Dr"

            'For Each row As DataGridViewRow In gridregister.Rows
            '    txtclosing.Text = Format(Val(txtclosing.Text) + Val(row.Cells(1).Value), "0.00")
            '    row.Cells(3).Value = Format(Val(txtclosing.Text), "0.00") & " Dr"
            'Next
            'txtdr.Text = Format(Val(txtclosing.Text), "0.00")


            txtdr.Text = "0.00"
            txtcr.Text = "0.00"
            txtclosing.Text = "0.00"
            lbldrcr.Text = "Cr"

            'For Each row As DataGridViewRow In gridregister.Rows
            '    txtclosing.Text = Format(Val(txtclosing.Text) + Val(row.Cells(2).Value), "0.00")
            '    row.Cells(3).Value = Format(Val(txtclosing.Text), "0.00") & " Cr"
            'Next

            For Each row As DataGridViewRow In gridregister.Rows
                txtdr.Text = Format(Val(txtdr.Text) + Val(row.Cells(1).Value), "0.00")
                txtcr.Text = Format(Val(txtcr.Text) + Val(row.Cells(2).Value), "0.00")


                txtclosing.Text = Format(Val(txtclosing.Text) + Val(Val(row.Cells(1).Value) - Val(row.Cells(2).Value)), "0.00")

                If Val(txtclosing.Text) >= 0 Then
                    If Val(Val(row.Cells(1).Value) - Val(row.Cells(2).Value)) < 0 Then
                        row.Cells(3).Value = Format(Val(txtclosing.Text), "0.00") & " Dr"
                    Else
                        row.Cells(3).Value = Format(Val(txtclosing.Text), "0.00") & " Dr"
                    End If
                ElseIf Val(txtclosing.Text) < 0 Then
                    If Val(Val(row.Cells(1).Value) - Val(row.Cells(2).Value)) >= 0 Then
                        row.Cells(3).Value = Format(Val(txtclosing.Text) * (-1), "0.00") & " Cr"
                    Else
                        row.Cells(3).Value = Format(Val(txtclosing.Text) * (-1), "0.00") & " Cr"
                    End If
                End If
            Next

            'txtcr.Text = Format(Val(txtclosing.Text), "0.00")
            If Val(txtclosing.Text) < 0 Then
                txtclosing.Text = Format(Val(txtclosing.Text) * (-1), "0.00")
                lbldrcr.Text = "Cr"
            Else
                lbldrcr.Text = "Dr"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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

    Private Sub gridregister_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridregister.CellDoubleClick
        SHOWFORM()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        SHOWFORM()
    End Sub

    Sub SHOWFORM()
        Try
            Dim objPURdetails As New PurchaseRegisterDetails
            objPURdetails.PURREGNAME = cmbregister.Text.Trim
            objPURdetails.FromDate = getfirstdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
            objPURdetails.ToDate = getlastdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
            objPURdetails.MdiParent = MDIMain
            objPURdetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign
            objreg.frmstring = "PurchaseRegisterMonthly"
            objreg.reg = cmbregister.Text.Trim
            If chkdate.Checked = True Then
                objreg.CHECK = 1
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
                objreg.PERIOD = "PURCHASE REGISTER MONTHLY - " & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                objreg.CHECK = 0
                objreg.FROMDATE = AccFrom
                objreg.TODATE = AccTo
                objreg.PERIOD = "PURCHASE REGISTER MONTHLY - " & Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy")
            End If
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegister_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub RDBREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class