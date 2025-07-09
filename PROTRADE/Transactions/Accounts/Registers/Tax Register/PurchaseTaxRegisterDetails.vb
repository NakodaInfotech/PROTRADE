
Imports BL

Public Class PurchaseTaxRegisterDetails

    Public PURREGNAME As String
    Public FromDate As Date
    Public ToDate As Date

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseTaxRegisterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTaxRegisterDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtfrom.Value = FromDate
            dtto.Value = ToDate
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJPURTAX As New ClsPurchaseTaxRegister
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(CmpId)

            OBJPURTAX.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJPURTAX.getdetails()
            

          
            'gridregister.DataSource = DT

            Dim dv_co As New DataView(DT)
            dv_co.RowFilter = "bill_date >= '" & dtfrom.Value & "' and bill_date < ='" & dtto.Value & "'"
            gridregister.DataSource = dv_co

            gridregister.Columns(0).HeaderText = "Date"
            gridregister.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            gridregister.Columns(0).Width = 80


            gridregister.Columns(1).HeaderText = "Name"
            gridregister.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            gridregister.Columns(1).Width = 200

            gridregister.Columns(2).Visible = False

            gridregister.Columns(3).HeaderText = "Bill No"
            gridregister.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            gridregister.Columns(3).Width = 80

            gridregister.Columns("BILLNO").Visible = False

            'Dim COL As New DataGridViewTextBoxColumn
            'gridregister.Columns.Insert(1, COL)

            'gridregister.Columns(1).Width = 100
            'gridregister.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'gridregister.Columns(1).DefaultCellStyle.Format = "N2"



            'gridregister.Columns(1).HeaderText = "Total"

            Dim i As Integer
            Dim TOT As Double
            For Each row As DataGridViewRow In gridregister.Rows
                TOT = 0
                For i = 4 To gridregister.Columns.Count - 1
                    'gridregister.Item(2, row.Index).Value = Val(gridregister.Item(2, row.Index).Value) + Val(gridregister.Item(i, row.Index).Value.ToString)
                    gridregister.Columns(i).DefaultCellStyle.Format = "N2"
                    gridregister.Columns(i).Width = 130
                    'gridregister.Item(1, row.Index).Value = 0.0
                    If IsDBNull(gridregister.Item(i, row.Index).Value) = True Then gridregister.Item(i, row.Index).Value = 0.0
                    TOT = Val(TOT) + Val(gridregister.Item(i, row.Index).Value.ToString)
                Next
                'row.Cells(1).Value = TOT
            Next

            'gridregister.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'gridregister.Columns(2).Visible = False

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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        FILLGRID()
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim OBJPUR As New Purchasemaster
                OBJPUR.MdiParent = MDIMain
                OBJPUR.edit = True
                OBJPUR.tempbillno = gridregister.CurrentRow.Cells(gridregister.Columns("BILLNO").Index).Value
                OBJPUR.TEMPREGNAME = gridregister.CurrentRow.Cells(2).Value
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridregister.CellDoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign


            objreg.frmstring = "purchasetaxdetail"
            
            'If chkdate.CheckState = CheckState.Checked Then

            objreg.FROMDATE = dtfrom.Value.Date
            objreg.TODATE = dtto.Value.Date
            'Else

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