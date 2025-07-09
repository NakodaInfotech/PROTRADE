
Imports BL

Public Class OpeningStoreStock

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public edit As Boolean
    Public FRMSTRING As String

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            For Each ROW As DataGridViewRow In gridstock.Rows
                If ROW.Cells(GOPSTOCKNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CHECKGRID() As Boolean
        Dim bln As Boolean = True
        For Each ROW As DataGridViewRow In gridstock.Rows
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Then
                If ROW.Cells(GITEMNAME.Index).Value = CMBITEMNAME.Text.Trim Then
                    EP.SetError(TXTQTY, "Item Name Already Present in Grid Below")
                    bln = False
                End If
            End If
        Next
        Return bln
    End Function

    Sub CLEAR()
        CMBITEMNAME.Text = ""
        TXTOPSTOCKNO.Clear()
        TXTQTY.Clear()
    End Sub

    Private Sub OpeningPipes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        FILLSTOREITEMNAME(CMBITEMNAME)
    End Sub

    Sub FILLGRID()
        Try
            Dim dttable As New DataTable
            Dim OBJOPSTOCK As New ClsOpeningStoreStock

            OBJOPSTOCK.alParaval.Add(0)
            OBJOPSTOCK.alParaval.Add(YearId)
            dttable = OBJOPSTOCK.GETSTOCK()

            If dttable.Rows.Count > 0 Then
                'ITEM GRID
                For Each ROW As DataRow In dttable.Rows
                    GRIDSTOCK.Rows.Add(Val(ROW("OPSTOCKNO")), ROW("ITEMNAME"), Val(ROW("QTY")), Val(ROW("OUTQTY")))
                    If Val(ROW("OUTQTY")) > 0 Then GRIDSTOCK.Rows(GRIDSTOCK.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
            End If
            TOTAL()
            CMBITEMNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TXTQTY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQTY.Validating

        If CMBITEMNAME.Text.Trim = "" Or Val(TXTQTY.Text.Trim) = 0 Then
            MsgBox("Enter Proper Details")
            Exit Sub
        End If

        If USERADD = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        EP.Clear()
        If Not CHECKGRID() Then
            Exit Sub
        End If

        Dim ALPARAVAL As New ArrayList

        ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
        ALPARAVAL.Add(Val(TXTQTY.Text.Trim))
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Userid)
        ALPARAVAL.Add(YearId)


        Dim OBJOPENSTOCK As New ClsOpeningStoreStock
        OBJOPENSTOCK.alParaval = ALPARAVAL

        If edit = False Then
            Dim DT As DataTable = OBJOPENSTOCK.SAVE()
        Else
            ALPARAVAL.Add(Val(TXTOPSTOCKNO.Text))
            Dim INTRES As Integer = OBJOPENSTOCK.UPDATE()
            GRIDDOUBLECLICK = False
            edit = False
        End If

        GRIDSTOCK.RowCount = 0
        FILLGRID()
        CLEAR()

    End Sub

    Private Sub OpeningPipes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        Dim OBJSEARCH As New ClsCommon
        Dim dttable As New DataTable

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        CLEAR()
        FILLCMB()
        FILLGRID()
    End Sub

    Private Sub gridstock_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCK.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDSTOCK.Item(GOUTQTY.Index, e.RowIndex).Value > 0 Then
                MsgBox("Pipe Locked, it is used further", MsgBoxStyle.Critical)
                Exit Sub
            End If

            TXTOPSTOCKNO.Text = GRIDSTOCK.Item(GOPSTOCKNO.Index, e.RowIndex).Value
            CMBITEMNAME.Text = GRIDSTOCK.Item(GITEMNAME.Index, e.RowIndex).Value
            TXTQTY.Text = Val(GRIDSTOCK.Item(GQTY.Index, e.RowIndex).Value)

            GRIDDOUBLECLICK = True
            edit = True
            TEMPROW = e.RowIndex
            CMBITEMNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDSTOCK.SelectedRows.Count > 0 Then

                    If USERDELETE = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    If GRIDDOUBLECLICK = True Then
                        MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                        Exit Sub
                    End If

                    If GRIDSTOCK.Item(GOUTQTY.Index, GRIDSTOCK.CurrentRow.Index).Value > 0 Then
                        MsgBox("Item Locked, it is used further", MsgBoxStyle.Critical)
                        Exit Sub
                    End If


                    Dim TEMPMSG As Integer = MsgBox("Delete Details", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim ALPARAVAL As New ArrayList
                        Dim OBJNO As New ClsOpeningStoreStock

                        OBJNO.alParaval = ALPARAVAL
                        ALPARAVAL.Add(GRIDSTOCK.CurrentRow.Cells(GOPSTOCKNO.Index).Value)
                        ALPARAVAL.Add(YearId)

                        Dim INTRES As DataTable = OBJNO.DELETE()
                        GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                    End If
                    TOTAL()

                End If
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBITEMNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numkeypress(e, TXTQTY, Me)
    End Sub

    Private Sub CMBITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBITEMNAME.Validated
        Try
            If CMBITEMNAME.Text.Trim = "" Then cmdexit.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class