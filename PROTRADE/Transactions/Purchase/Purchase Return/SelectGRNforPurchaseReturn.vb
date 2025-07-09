
Imports System.Windows.Forms
Imports BL

Public Class SelectGRNforPurchaseReturnReturn

    Dim addcol As Integer = 0
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public ENQname As String = ""  'for whereclause in fillgrid
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRNforPurchaseReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectGRNforPurchaseReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
        cmbselect.Text = "GRN No."
        txtsearch.Focus()
    End Sub

    Sub FILLGRID(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" * ", "", " (SELECT GRN.grn_no AS SRNO, GRN.grn_date AS Date, LEDGERS.Acc_cmpname AS Name, GRN.GRN_TYPE AS Type, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE FROM GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id where GRN.GRN_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND GRN.GRN_YEARID = " & YearId & " UNION ALL SELECT     MATERIALRECEIPT.MATREC_NO AS SRNO, MATERIALRECEIPT.MATREC_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'MATREC' AS TYPE, MATERIALRECEIPT.MATREC_CHALLANNO AS CHALLANNO, MATERIALRECEIPT.MATREC_CHALLANDATE AS CHALLANDATE FROM MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id where MaterialReceipt.MATREC_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & ENQname & "' AND MATERIALRECEIPT.MATREC_YEARID = " & YearId & ") AS T ", where & "  ORDER BY TYPE, SRNO")


            GRIDGRN.DataSource = DT
            If addcol = 0 Then
                GRIDGRN.Columns.Insert(0, col)
                addcol = 1
            End If
            If DT.Rows.Count > 0 Then

                Dim I As Integer = 0

                GRIDGRN.Columns(I).Width = 40     'Check Box
                I += 1
                GRIDGRN.Columns(I).Width = 60     'grnNO
                GRIDGRN.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                I += 1
                GRIDGRN.Columns(I).Width = 80   'DATE
                I += 1
                GRIDGRN.Columns(I).Width = 200    'NAME
                I += 1
                GRIDGRN.Columns(I).Width = 100    'TYPE
                I += 1
                GRIDGRN.Columns(I).Width = 90    'CHALLANNO
                I += 1
                GRIDGRN.Columns(I).Width = 80    'CHALLANDATE
                I += 1
               
                GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon

            DT.Columns.Add("SRNO")
            DT.Columns.Add("TYPE")

            For Each row As DataGridViewRow In GRIDGRN.Rows
                If row.Cells(0).Value = True Then
                    DT.Rows.Add(row.Cells(1).Value, row.Cells(4).Value)
                End If
            Next

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub GRIDGRN_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGRN.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDGRN.Rows(e.RowIndex).Cells(0)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True
                    End If
                End With
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If cmbselect.Text = "GRN No." And Val(txtsearch.Text.Trim) > 0 Then
                FILLGRID(" and T.SRNO = " & Val(txtsearch.Text))
            End If

            If cmbselect.Text = "Vendor Name" Then
                FILLGRID(" and T.NAME LIKE '%" & txtsearch.Text & "%'")
            End If

            If cmbselect.Text = "Challan No." Then
                FILLGRID(" and T.CHALLANNO = '" & txtsearch.Text & "'")
            End If
        Else
            FILLGRID()
        End If
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDgrn.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkselectall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkselectall.CheckedChanged
        If chkselectall.Checked = True Then
            For Each row As DataGridViewRow In GRIDgrn.Rows
                row.Cells(0).Value = True
            Next
        Else
            For Each row As DataGridViewRow In GRIDGRN.Rows
                row.Cells(0).Value = False
            Next
        End If
    End Sub
End Class