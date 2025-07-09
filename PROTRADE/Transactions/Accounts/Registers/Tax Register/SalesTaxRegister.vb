
Imports BL

Public Class SalesTaxRegister

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SalesTaxRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SalesTaxRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJSALESTAX As New ClsSalesTaxRegister
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(CmpId)

            OBJSALESTAX.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJSALESTAX.getdata()
            gridregister.DataSource = DT

            gridregister.Columns(0).Width = 150

            Dim COL As New DataGridViewTextBoxColumn
            gridregister.Columns.Insert(1, COL)

            gridregister.Columns(1).Width = 100
            gridregister.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            gridregister.Columns(1).DefaultCellStyle.Format = "N2"


            gridregister.Columns(0).HeaderText = "Month"
            gridregister.Columns(1).HeaderText = "Total"

            Dim i As Integer
            Dim TOT As Double
            For Each row As DataGridViewRow In gridregister.Rows
                TOT = 0
                For i = 3 To gridregister.Columns.Count - 1
                    'gridregister.Item(2, row.Index).Value = Val(gridregister.Item(2, row.Index).Value) + Val(gridregister.Item(i, row.Index).Value.ToString)
                    gridregister.Columns(i).DefaultCellStyle.Format = "N2"
                    gridregister.Item(1, row.Index).Value = 0.0
                    If IsDBNull(gridregister.Item(i, row.Index).Value) = True Then gridregister.Item(i, row.Index).Value = 0.0
                    TOT = Val(TOT) + Val(gridregister.Item(i, row.Index).Value.ToString)
                Next
                row.Cells(1).Value = TOT
            Next

            gridregister.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            gridregister.Columns(2).Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        'Try
        '    Dim objSALETAXdetails As New SalesTaxRegisterDetails
        '    objSALETAXdetails.SALEREGNAME = cmbregister.Text.Trim
        '    objSALETAXdetails.FromDate = getfirstdate(CmpId, gridregister.CurrentRow.Cells(1).Value.ToString)
        '    objSALETAXdetails.ToDate = getlastdate(CmpId, gridregister.CurrentRow.Cells(1).Value.ToString)
        '    objSALETAXdetails.MdiParent = MDIMain
        '    objSALETAXdetails.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        SHOWFORM()
    End Sub

    Private Sub gridregister_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridregister.CellDoubleClick
        SHOWFORM()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign


            objreg.frmstring = "saletax"
            'objreg.reg = cmbregister.Text.Trim

            'If chkdate.CheckState = CheckState.Checked Then
            '    objreg.CHECK = 1
            '    objreg.FROMDATE = dtfrom.Value.Date
            '    objreg.TODATE = dtto.Value.Date
            'Else
            '    objreg.CHECK = 0
            '    objreg.FROMDATE = AccFrom
            '    objreg.TODATE = AccTo
            'End If
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class