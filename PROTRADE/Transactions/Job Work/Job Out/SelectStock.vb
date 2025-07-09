
Imports BL

Public Class SelectStock

    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public FRMSTRING As String
    Public GODOWN As String = ""
    Public WHERECLAUSE As String = ""
    Public DTNEW As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        Me.Text = " Select Stock"
        fillgrid(WHERECLAUSE)
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor


            Dim DT As New DataTable
            Dim objclspreq As New ClsCommon()
            DT = objclspreq.search(" No AS SRNO, INITIALS AS No, [Party Name] , GRIDSRNO, Type, [Piece Type] , [Item Name] AS [Bleach Quality], Color , Cut , Pcs , Mtrs, CMPID, LOCATIONID, YEARID,REMARKS, [Bale No],[Printer Name] AS [Print/Emb Name] ", "", " STOCKONHAND ", where & " and CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " order by No")

            gridmfg.DataSource = DT
            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                Dim I As Integer = 0
                gridmfg.Columns(I).Width = 40 'CHECK BOK
                I += 1
                gridmfg.Columns(I).Visible = False  'RECNO
                I += 1
                gridmfg.Columns(I).Width = 60 'INITIALS
                I += 1
                gridmfg.Columns(I).Width = 175 'NAME
                I += 1
                gridmfg.Columns(I).Visible = False 'GRIDSRNO
                I += 1
                gridmfg.Columns(I).Width = 80 'TYPE
                I += 1
                gridmfg.Columns(I).Width = 100 'PIECETYPE
                I += 1
                gridmfg.Columns(I).Width = 130 'BLEACH QUALITY
                I += 1
                gridmfg.Columns(I).Visible = False 'COLOR
                I += 1
                gridmfg.Columns(I).Width = 40 'CUT
                gridmfg.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  'CUT
                I += 1
                gridmfg.Columns(I).Width = 50 'PCS
                gridmfg.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  'PCS
                I += 1
                gridmfg.Columns(I).Width = 70 'MTRS
                gridmfg.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight  'MTRS
                gridmfg.Columns(I).DefaultCellStyle.Format = "N2"
                I += 1
                gridmfg.Columns(I).Visible = False 'CMPID
                I += 1
                gridmfg.Columns(I).Visible = False 'LOCATIONID
                I += 1
                gridmfg.Columns(I).Visible = False 'YEARID
                I += 1
                gridmfg.Columns(I).Visible = False 'REMARKS
                I += 1
                gridmfg.Columns(I).Width = 75 'BALENO
                I += 1
                gridmfg.Columns(I).Width = 200 'PRINTERNAME
                I += 1

                gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If txtsearch.Text <> "" Then
                If cmbselect.Text = "Party Name" Then
                    fillgrid(" AND [Party Name] LIKE '" & txtsearch.Text & "%'") ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                ElseIf cmbselect.Text = "Piece Type" Then
                    fillgrid(" AND [Piece Type] LIKE '" & txtsearch.Text & "%'") ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                ElseIf cmbselect.Text = "Item Name" Then
                    fillgrid(" AND [Item Name] LIKE '" & txtsearch.Text & "%'") ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                End If
            Else
                fillgrid()
            End If

        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        For i = 0 To gridmfg.RowCount - 1
            With gridmfg.Rows(i).Cells(0)
                If .Value = True Then N = gridmfg.Item(3, i).Value.ToString
            End With
        Next
        If e.RowIndex >= 0 Then
            With gridmfg.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (((gridmfg.Item(3, e.RowIndex).Value.ToString = N) Or N = Nothing) And FRMSTRING <> "PACKINGSLIP") Or (FRMSTRING = "PACKINGSLIP") Then
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

            dt.Columns.Add("NO")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("TYPE")
            dt.Columns.Add("NAME")
            dt.Columns.Add("PIECETYPE")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("CUT")
            dt.Columns.Add("PCS")
            dt.Columns.Add("MTRS")
            dt.Columns.Add("REMARKS")
            dt.Columns.Add("BALENO")
            dt.Columns.Add("PRINTERNAME")

            For Each row As DataGridViewRow In gridmfg.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(1).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(3).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, Format(Val(row.Cells(9).Value), "0.00"), Format(Val(row.Cells(10).Value), "0.00"), Format(Val(row.Cells(11).Value), "0.00"), row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value)
                End If
            Next
            DTNEW = dt
            
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim N As String = ""
            Dim M As String = ""
            Dim tempindex As Integer
            Dim i As Integer

            If gridmfg.RowCount > 0 Then
                If chkall.Checked = True And gridmfg.RowCount > 110 Then
                    MsgBox("Too Many Rows to Select")
                    Exit Sub
                End If
                For i = 0 To gridmfg.RowCount - 1
                    With gridmfg.Rows(i).Cells(0)
                        If .Value = True Then N = gridmfg.Item(3, i).Value.ToString
                    End With
                Next

                If chkall.Checked = True Then
                    For i = 0 To gridmfg.RowCount - 1
                        With gridmfg.Rows(i).Cells(0)
                            If ((gridmfg.Item(3, i).Value.ToString = N) Or N = Nothing) Then
                                .Value = True
                                N = gridmfg.Item(3, i).Value.ToString
                                tempindex = i
                            End If
                        End With
                    Next
                Else
                    For i = 0 To gridmfg.RowCount - 1
                        'If Val(gridmfg.CurrentRow.Index) >= 0 Then
                        With gridmfg.Rows(i).Cells(0)
                            .Value = False
                        End With
                        'End If
                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class