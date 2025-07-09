
Imports BL
Imports System.Windows.Forms

Public Class SelectQuotation

    Public QUOTNO As Integer = 0
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectQuotation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SelectQuotation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Top = 100
        Me.Text = " Select Quotation "
        PurchaseOrder.dt_quot.Clear()
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = ""
            If QUOTNO <> 0 Then where = " AND PURCHASEQUOTATION.QUOTATION_NO  = " & QUOTNO
            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable
            dt = objclspreq.search(" PURCHASEQUOTATION.QUOTATION_NO AS [Sr No.], isnull(LEDGERS.Acc_cmpname,'') AS Name, PURCHASEQUOTATION.quotation_date AS Date, PURCHASEQUOTATION_DESC.QUOTATION_GRIDSRNO AS GRIDSRNO, isnull(ITEMMASTER.item_name,'') AS [Item Name], isnull(PURCHASEQUOTATION_DESC.QUOTATION_GRIDREMARKS,'') AS Description, isnull(QUALITYMASTER.QUALITY_name,'') AS Quality, isnull(PURCHASEQUOTATION_DESC.QUOTATION_REED,'') AS Reed, isnull(PURCHASEQUOTATION_DESC.QUOTATION_PICK,'') AS Pick, isnull(COLORMASTER.COLOR_name,'') AS Color, (PURCHASEQUOTATION_DESC.QUOTATION_QTY - PURCHASEQUOTATION_DESC.QUOTATION_RECDQTY) AS Qty, isnull(UNITMASTER.unit_abbr,'') AS [Qty Unit], PURCHASEQUOTATION_DESC.QUOTATION_RATE AS Rate, PURCHASEQUOTATION_DESC.QUOTATION_AMT AS Amount ", "", " PURCHASEQUOTATION INNER JOIN PURCHASEQUOTATION_DESC ON PURCHASEQUOTATION.quotation_cmpid = PURCHASEQUOTATION_DESC.QUOTATION_CMPID AND PURCHASEQUOTATION.quotation_locationid = PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID AND PURCHASEQUOTATION.quotation_yearid = PURCHASEQUOTATION_DESC.QUOTATION_YEARID AND PURCHASEQUOTATION.QUOTATION_NO = PURCHASEQUOTATION_DESC.QUOTATION_NO INNER JOIN LEDGERS ON PURCHASEQUOTATION.quotation_cmpid = LEDGERS.Acc_cmpid AND PURCHASEQUOTATION.quotation_locationid = LEDGERS.Acc_locationid AND PURCHASEQUOTATION.quotation_yearid = LEDGERS.Acc_yearid AND PURCHASEQUOTATION.quotation_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = UNITMASTER.unit_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = UNITMASTER.unit_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = UNITMASTER.unit_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = COLORMASTER.COLOR_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = COLORMASTER.COLOR_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = COLORMASTER.COLOR_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = QUALITYMASTER.QUALITY_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = QUALITYMASTER.QUALITY_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_ITEMID = ITEMMASTER.item_id AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = ITEMMASTER.item_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = ITEMMASTER.item_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_YEARID = ITEMMASTER.item_yearid ", " and PURCHASEQUOTATION_DESC.quotation_done='False'" & where & " AND PURCHASEQUOTATION.QUOTATION_CMPID = " & CmpId & " AND PURCHASEQUOTATION.QUOTATION_LOCATIONID = " & Locationid & " AND PURCHASEQUOTATION.QUOTATION_YEARID = " & YearId & "  order by PURCHASEQUOTATION.quotation_no")
            If dt.Rows.Count > 0 Then

                gridquotation.DataSource = dt
                'Dim col As New DataGridViewCheckBoxColumn
                If ADDCOL = False Then
                    gridquotation.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                'gridquotation.Columns(0).DataGridView. = 70
                gridquotation.Columns(0).Width = 50 'CHECK BOK
                gridquotation.Columns(1).Width = 70  'Sr
                gridquotation.Columns(2).Width = 150  'NAME
                gridquotation.Columns(3).Width = 80  'DATE
                gridquotation.Columns(4).Width = 10  'gridsrno
                gridquotation.Columns(5).Width = 150 'Item Name
                gridquotation.Columns(6).Width = 150  'desc
                gridquotation.Columns(7).Width = 70  'Quality
                gridquotation.Columns(8).Width = 60  'Reed
                gridquotation.Columns(9).Width = 60 'Pick
                gridquotation.Columns(10).Width = 70 'color
                gridquotation.Columns(11).Width = 70 'qty
                gridquotation.Columns(12).Width = 70 'qtyunit
                gridquotation.Columns(13).Width = 80 'RATE
                gridquotation.Columns(14).Width = 90 'AMT

                gridquotation.Columns(4).Visible = False 'Grid Sr No

                gridquotation.Columns(11).DefaultCellStyle.Format = "N2"
                gridquotation.Columns(13).DefaultCellStyle.Format = "N2"
                gridquotation.Columns(14).DefaultCellStyle.Format = "N2"
                gridquotation.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridquotation.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridquotation.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                gridquotation.FirstDisplayedScrollingRowIndex = gridquotation.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            Dim rowno, b As Integer
            gridquotation.Columns.Clear()
            fillgrid()
            rowno = 0
            For b = 1 To gridquotation.RowCount
                If cmbselect.Text = "Sr No." Then
                    txttempname.Text = gridquotation.Item(1, rowno).Value
                ElseIf cmbselect.Text = "Name" Then
                    txttempname.Text = gridquotation.Item(2, rowno).Value.ToString()
                End If

                'txttempname.Text = gridquotation.Item(0, rowno).Value.ToString()
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = txtsearch.TextLength
                If LCase(txtsearch.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                    gridquotation.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If
            Next

        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridquotation.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To gridquotation.RowCount - 1
            With gridquotation.Rows(i).Cells(0)
                If .Value = True Then N = gridquotation.Item(1, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridquotation.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (gridquotation.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
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
            dt.Columns.Add("QUOTNO")
            dt.Columns.Add("NAME")
            dt.Columns.Add("QUOTDATE")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("DESC")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("REED")
            dt.Columns.Add("PICK")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("qty")
            dt.Columns.Add("qtyunit")
            dt.Columns.Add("RATE")
            dt.Columns.Add("AMT")

            For Each row As DataGridViewRow In gridquotation.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value)
                End If
            Next
            PurchaseOrder.dt_quot = dt
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridquotation.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class
