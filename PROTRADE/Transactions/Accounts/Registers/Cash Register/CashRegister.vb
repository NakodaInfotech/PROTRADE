
Imports BL
Imports System.Windows.Forms

Public Class cashregister1

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillgrid()
        Try
            gridregister.RowCount = 0

            Dim OBJCASHREG As New ClsCashRegister
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

            ALPARAVAL.Add(cmbbank.Text.Trim)
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

            OBJCASHREG.alParaval = ALPARAVAL
            DT = OBJCASHREG.getdata()

            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    gridregister.Rows.Add(MonthName(DTROW(0)), Format(Val(DTROW(1).ToString) + Val(DTROW(3).ToString) + Val(DTROW(5).ToString) + Val(DTROW(7).ToString) + Val(DTROW(9).ToString), "0.00"), Format(Val(DTROW(2).ToString) + Val(DTROW(4).ToString) + Val(DTROW(6).ToString) + Val(DTROW(8).ToString) + Val(DTROW(10).ToString), "0.00"), "0.00")
                Next
            End If

            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            txtdr.Text = "0.00"
            txtcr.Text = "0.00"
            txtclosing.Text = "0.00"
            txtopening.Text = "0.00"

            'GETTING OP BAL
            Dim objcommon As New ClsCommon
            Dim dt As New DataTable
            dt = objcommon.search("acc_opbal, acc_drcr", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbbank.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                txtopening.Text = Format(Val(dt.Rows(0).Item(0).ToString), "0.00")
                txtclosing.Text = Format(Val(txtopening.Text), "0.00")
                lbldrcr.Text = dt.Rows(0).Item(1).ToString
                lblopdrcr.Text = dt.Rows(0).Item(1).ToString
            End If

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

    Private Sub cmbbank_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbank.Enter
        Try
            'OPEN CASH IN HAND
            If cmbbank.Text.Trim = "" Then fillledger(cmbbank, False, " and groupmaster.group_SECONDARY = 'CASH IN HAND' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            cmbbank.Text = "Cash In Hand"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbbank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbbank.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and groupmaster.group_SECONDARY = 'CASH IN HAND' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbbank.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbbank_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbank.Validating
        Try
            If cmbbank.Text.Trim <> "" Then ledgervalidate(cmbbank, CMBACCCODE, e, Me, txtadd, " and groupmaster.group_SECONDARY = 'CASH IN HAND' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign

            objreg.frmstring = "CashRegister"
            objreg.reg = cmbbank.Text.Trim

            If chkdate.CheckState = CheckState.Checked Then
                objreg.CHECK = 1
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
            Else
                objreg.CHECK = 0
                objreg.FROMDATE = AccFrom
                objreg.TODATE = AccTo
            End If
            If lblopdrcr.Text = "Dr." Then
                objreg.OPENING = Val(txtopening.Text)
            Else
                objreg.OPENING = -1 * Val(txtopening.Text)
            End If
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        showform()
    End Sub

    Sub showform()
        Try
            Dim objCASHdetails As New CashRegisterDetails
            objCASHdetails.CashName = cmbbank.Text.Trim
            If chkdate.CheckState = CheckState.Checked Then
                objCASHdetails.FromDate = dtfrom.Value.Date
                objCASHdetails.ToDate = dtto.Value.Date
            Else
                objCASHdetails.FromDate = getfirstdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
                objCASHdetails.ToDate = getlastdate(CmpId, gridregister.CurrentRow.Cells(0).Value.ToString)
            End If
            objCASHdetails.MdiParent = MDIMain
            objCASHdetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridregister.CellDoubleClick
        showform()
    End Sub

    Private Sub cashregister1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cashregister1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class