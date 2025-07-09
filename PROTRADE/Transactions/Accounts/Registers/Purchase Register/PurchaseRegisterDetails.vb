
Imports BL

Public Class PurchaseRegisterDetails

    Public PURREGNAME As String
    Public FromDate As Date
    Public ToDate As Date

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseRegisterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegisterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtfrom.Enabled = False
            dtto.Enabled = False
            chkdate.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsPurchaseRegister

        ALPARAVAL.Add(PURREGNAME)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(FromDate)
            ALPARAVAL.Add(ToDate)
        End If
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        If chkdetails.CheckState = CheckState.Unchecked Then
            dt = objregister.getSUMMARY
        Else
            dt = objregister.getDETAILS
        End If
        griddetails.DataSource = dt


        ''getting opening balances
        'Dim OBJCOMMON As New ClsCommonMaster
        'If chkdate.CheckState = CheckState.Unchecked Then
        '    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CashName & "' and acc_billdate <='" & Format(FromDate, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId)
        'Else
        '    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CashName & "' and acc_billdate <='" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId)
        'End If
        'If dt.Rows.Count > 0 Then
        '    If Val(dt.Rows(0).Item(0).ToString) < 0 Then
        '        txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
        '        lbldrcropening.Text = "Cr"
        '    Else
        '        txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
        '        lbldrcropening.Text = "Dr"
        '    End If
        'End If

        total()
        txtopening.Text = Format(Val(txtopening.Text), "0.00")
    End Sub

    Sub total()
        Try
            txttotal.Text = 0.0
            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")


            'Dim dtrow As DataRow
            'Dim i As Integer

            'For i = 0 To gridregister.RowCount - 1
            '    dtrow = gridregister.GetDataRow(i)
            '    txtdrtotal.Text = Format(Val(txtdrtotal.Text) + Val(dtrow(4).ToString), "0.00")
            '    txtcrtotal.Text = Format(Val(txtcrtotal.Text) + Val(dtrow(5).ToString), "0.00")
            'Next

            'txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If

            'calculating total
            If Val(txttotal.Text) < 0 Then
                txttotal.Text = Format(Val(txttotal.Text) * (-1), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                lbldrcrclosing.Text = "Dr"
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

    Private Sub cmdshowdetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Private Sub chkdetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdetails.CheckedChanged
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
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
                VIEWFORM(dtrow("TYPE"), True, dtrow("BILL"), dtrow("REGTYPE"))
            End If
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign
            objreg.frmstring = "PurchaseRegister"
            If chkdate.Checked = True Then
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
                objreg.PERIOD = "PURCHASE REGISTER - " & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                objreg.FROMDATE = FromDate
                objreg.TODATE = ToDate
                objreg.PERIOD = "PURCHASE REGISTER - " & Format(FromDate.Date, "dd/MM/yyyy") & " - " & Format(ToDate.Date, "dd/MM/yyyy")
            End If
            objreg.reg = PURREGNAME
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegisterDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class