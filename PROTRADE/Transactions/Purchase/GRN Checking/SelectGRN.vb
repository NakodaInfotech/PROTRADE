
Imports BL
Imports System.Windows.Forms

Public Class SelectGRN

    Public GRNNO As Integer = 0
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectGRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
        cmbselect.SelectedIndex = (0)
        txtsearch.Focus()
    End Sub
   
    Sub fillgrid(Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = " AND (MATERIAL = 'Finished Goods' OR MATERIAL = 'Raw Material' OR MATERIAL = 'Semi Finished Goods')"
            'If GRNNO <> 0 Then where = where & " AND GRN.GRN_NO  = " & GRNNO
            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable
            dt = objclspreq.search(" * ", "", " GRN_VIEW ", " and CHECKDONE='A' AND YEARID = " & YearId & WHERECLAUSE & "  order by [Lot No.]")
            gridgrn.DataSource = dt
            If dt.Rows.Count > 0 Then

                'Dim col As New DataGridViewCheckBoxColumn
                If ADDCOL = False Then
                    gridgrn.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                'gridquotation.Columns(0).DataGridView. = 70
                gridgrn.Columns(0).Width = 50 'CHECK BOK
                gridgrn.Columns(1).Width = 70  'Lot No

                gridgrn.Columns(2).Width = 70 'qty
                gridgrn.Columns(3).Width = 70 'qtyunit
                gridgrn.Columns(4).Width = 70 'MTRS

                gridgrn.Columns(5).Width = 70  'Quality


                gridgrn.Columns(6).Width = 80  'DATE
                gridgrn.Columns(7).Width = 150  'TOLEDGER
                If ClientName = "AVIS" Then gridgrn.Columns(8).Visible = True Else gridgrn.Columns(8).Visible = False   'GRNNO
                gridgrn.Columns(9).Visible = False   'gridsrno
                gridgrn.Columns(10).Width = 150 'Item Name
                gridgrn.Columns(11).Width = 150  'desc
                gridgrn.Columns(12).Width = 60  'Reed
                gridgrn.Columns(13).Width = 60 'Pick
                gridgrn.Columns(14).Width = 70 'color
                gridgrn.Columns(15).Visible = True  'TYPE
                gridgrn.Columns(16).Visible = False  'BROKER
                gridgrn.Columns(17).Visible = False  'MATERIAL
                gridgrn.Columns(18).Visible = False  'CMPID
                gridgrn.Columns(19).Visible = False  'LOCATIONID
                gridgrn.Columns(20).Visible = False  'YARID
                gridgrn.Columns(21).Visible = False  'CHECKDONE
                gridgrn.Columns(22).Visible = False  'CHECKDATE
                gridgrn.Columns(23).Width = 150     'NAME
                gridgrn.Columns(24).Visible = False    'DYEINGTYPE
                gridgrn.Columns(25).Visible = False    'DESIGN
                gridgrn.Columns(26).Width = 150    'TRANSNAME
                gridgrn.Columns(27).Width = 80   'LRNO



                gridgrn.Columns(2).DefaultCellStyle.Format = "N2"
                gridgrn.Columns(4).DefaultCellStyle.Format = "N2"
                gridgrn.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridgrn.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridgrn.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridgrn.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1
                gridgrn.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" And txtsearch.Text <> "" Then
            If cmbselect.Text = "Lot No." Then
                fillgrid(" AND [LOT NO.] LIKE '" & txtsearch.Text & "%'")
            ElseIf cmbselect.Text = "Name" Then
                fillgrid(" AND  NAME LIKE '" & txtsearch.Text & "%'")
            ElseIf cmbselect.Text = "Dyeing Name" Then
                fillgrid(" AND  TOLEDGER LIKE '" & txtsearch.Text & "%'")
            End If
        Else
            fillgrid()
        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgrn.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To gridgrn.RowCount - 1
            With gridgrn.Rows(i).Cells(0)
                If .Value = True Then N = gridgrn.Item(1, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridgrn.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (gridgrn.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                        .Value = True
                        tempindex = e.RowIndex
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim dt As New DataTable
            dt.Columns.Add("LOTNO")
            dt.Columns.Add("qty")
            dt.Columns.Add("qtyunit")
            dt.Columns.Add("MTRS")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("GRNDATE")
            dt.Columns.Add("TOLEDGER")
            dt.Columns.Add("GRNNO")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("DESC")
            dt.Columns.Add("REED")
            dt.Columns.Add("PICK")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("TYPE")
            dt.Columns.Add("NAME")
            dt.Columns.Add("DYEINGTYPE")
            dt.Columns.Add("DESIGN")
            dt.Columns.Add("TRANSNAME")
            dt.Columns.Add("LRNO")

            For Each row As DataGridViewRow In gridgrn.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(23).Value, row.Cells(24).Value, row.Cells(25).Value, row.Cells(26).Value, row.Cells(27).Value)
                End If
            Next
            GRNChecking.selectGRNtable = dt
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgrn.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridgrn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridgrn.KeyDown
        If e.KeyCode = Keys.Space Then
            If gridgrn.Rows(gridgrn.CurrentRow.Index).Cells(0).Value = True Then
                cmdok_Click(sender, e)
            End If
        End If
    End Sub
End Class