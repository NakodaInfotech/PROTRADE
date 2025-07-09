
Imports BL

Public Class MerchantMaster

    Dim GRIDDOUBLECLICK, GRIDSTOREDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPMERCHANTID As Integer     'used for poation no while editing
    Dim TEMPROW, TEMPSTOREROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()

        CMBMERCHANT.Text = ""
        CMBITEMNAME.Text = ""
        TXTMTRS.Clear()
        CMBSTOREITEMNAME.Text = ""
        TXTPCS.Clear()
        LBLTOTALMTRS.Text = 0.0
        GRIDITEM.RowCount = 0
        GRIDSTORE.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDSTOREDOUBLECLICK = False

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0
            For Each ROW As DataGridViewRow In GRIDITEM.Rows
                If ROW.Cells(GITEMNAME.Index).Value <> Nothing Then
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBMERCHANT.Focus()
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBMERCHANT.Text.Trim.Length = 0 Then
                EP.SetError(CMBMERCHANT, " Please Enter Merchant Name")
                bln = False
            End If

            If Val(GRIDITEM.RowCount) = 0 Then
                EP.SetError(CMBMERCHANT, " Please Enter Item Details")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(CMBMERCHANT.Text.Trim)

            Dim ITEMNAME As String = ""
            Dim MTRS As String = ""
            Dim STOREITEMNAME As String = ""
            Dim PCS As String = ""
            
            For Each row As Windows.Forms.DataGridViewRow In GRIDITEM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If ITEMNAME = "" Then
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                    Else
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ITEMNAME)
            alParaval.Add(MTRS)


            For Each row As Windows.Forms.DataGridViewRow In GRIDSTORE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If STOREITEMNAME = "" Then
                        STOREITEMNAME = row.Cells(GSTOREITEMNAME.Index).Value.ToString
                        PCS = Val(row.Cells(GPCS.Index).Value)
                    Else
                        STOREITEMNAME = STOREITEMNAME & "|" & row.Cells(GSTOREITEMNAME.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(STOREITEMNAME)
            alParaval.Add(PCS)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim OBJMERCHANT As New ClsMerchantMaster()
            OBJMERCHANT.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim INTRES As Integer = OBJMERCHANT.SAVE()
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPMERCHANTID)
                Dim IntResult As Integer = OBJMERCHANT.UPDATE()
                MsgBox("Details Updated")
            End If

            EDIT = False
            clear()
            CMBMERCHANT.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub PROGRAMMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PROGRAMMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        GRIDITEM.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDITEM.Rows.Add(CMBITEMNAME.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDITEM.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDITEM.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False
        End If

        total()
        GRIDITEM.FirstDisplayedScrollingRowIndex = GRIDITEM.RowCount - 1

        CMBITEMNAME.Text = ""
        TXTMTRS.Clear()
        CMBITEMNAME.Focus()

    End Sub

    Sub FILLSTOREGRID()

        GRIDSTORE.Enabled = True
        If GRIDSTOREDOUBLECLICK = False Then
            GRIDSTORE.Rows.Add(CMBSTOREITEMNAME.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0"))
        ElseIf GRIDSTOREDOUBLECLICK = True Then
            GRIDSTORE.Item(GITEMNAME.Index, TEMPSTOREROW).Value = CMBSTOREITEMNAME.Text.Trim
            GRIDSTORE.Item(GPCS.Index, TEMPSTOREROW).Value = Format(Val(TXTPCS.Text.Trim), "0")
            GRIDSTOREDOUBLECLICK = False
        End If

        GRIDSTORE.FirstDisplayedScrollingRowIndex = GRIDSTORE.RowCount - 1

        CMBSTOREITEMNAME.Text = ""
        TXTPCS.Clear()
        CMBSTOREITEMNAME.Focus()

    End Sub

    Private Sub GRIDITEM_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDITEM.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub GRIDSTORE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTORE.CellDoubleClick
        EDITSTOREROW()
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete Merchant?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPMERCHANTID)

                Dim OBJMERCHANT As New ClsMerchantMaster()
                OBJMERCHANT.alParaval = alParaval
                Dim DTTABLE As DataTable = OBJMERCHANT.DELETE()
                MsgBox(DTTABLE.Rows(0).Item(0))
                EDIT = False
                clear()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDITEM.CurrentRow.Index >= 0 And GRIDITEM.Item(GITEMNAME.Index, GRIDITEM.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                CMBITEMNAME.Text = GRIDITEM.Item(GITEMNAME.Index, GRIDITEM.CurrentRow.Index).Value
                TXTMTRS.Text = Val(GRIDITEM.Item(GMTRS.Index, GRIDITEM.CurrentRow.Index).Value)
                
                TEMPROW = GRIDITEM.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITSTOREROW()
        Try
            If GRIDSTORE.CurrentRow.Index >= 0 And GRIDSTORE.Item(GSTOREITEMNAME.Index, GRIDSTORE.CurrentRow.Index).Value <> Nothing Then

                GRIDSTOREDOUBLECLICK = True
                CMBSTOREITEMNAME.Text = GRIDSTORE.Item(GSTOREITEMNAME.Index, GRIDSTORE.CurrentRow.Index).Value
                TXTPCS.Text = Val(GRIDSTORE.Item(GPCS.Index, GRIDSTORE.CurrentRow.Index).Value)

                TEMPSTOREROW = GRIDSTORE.CurrentRow.Index
                CMBSTOREITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDITEM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDITEM.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDITEM.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDITEM.Rows.RemoveAt(GRIDITEM.CurrentRow.Index)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSTORE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTORE.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSTORE.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSTORE.Rows.RemoveAt(GRIDSTORE.CurrentRow.Index)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSTOREITEMNAME.Enter
        Try
            If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) > 0 Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPCS.Validating
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then
                FILLSTOREGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Validated
        Try
            If CMBMERCHANT.Text.Trim = "" Then Exit Sub

            Dim OBJCMN As New ClsCommon()
            Dim dttable As DataTable = OBJCMN.search("MERCHANTITEMMASTER.item_ID AS MERCHANTID, MERCHANTITEMMASTER.item_name AS MERCHANTNAME, ITEMMASTER.item_name AS ITEMNAME, MERCHANTMASTER.CONFIG_MTRS AS MTRS", "", " MERCHANTMASTER INNER JOIN ITEMMASTER AS MERCHANTITEMMASTER ON MERCHANTMASTER.CONFIG_MERCHANTID = MERCHANTITEMMASTER.item_id INNER JOIN ITEMMASTER ON MERCHANTMASTER.CONFIG_ITEMID = ITEMMASTER.item_id ", " AND MERCHANTITEMMASTER.ITEM_NAME = '" & CMBMERCHANT.Text.Trim & "' AND CONFIG_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                EDIT = True
                For Each dr As DataRow In dttable.Rows
                    CMBMERCHANT.Text = Convert.ToString(dr("MERCHANTNAME").ToString)
                    TEMPMERCHANTID = Val(dr("MERCHANTID"))
                    'Item Grid
                    GRIDITEM.Rows.Add(dr("ITEMNAME"), Val(dr("MTRS")))
                Next

                dttable = OBJCMN.search(" DISTINCT STOREITEMMASTER.STOREITEM_NAME AS STOREITEMNAME, MERCHANTMASTER_STOREDESC.CONFIG_PCS AS PCS ", "", " MERCHANTMASTER INNER JOIN MERCHANTMASTER_STOREDESC ON MERCHANTMASTER.CONFIG_MERCHANTID = MERCHANTMASTER_STOREDESC.CONFIG_MERCHANTID INNER JOIN STOREITEMMASTER ON MERCHANTMASTER_STOREDESC.CONFIG_STOREITEMID = STOREITEMMASTER.STOREITEM_ID ", " AND CONFIG_YEARID = " & YearId & " AND MERCHANTMASTER.CONFIG_MERCHANTID = " & TEMPMERCHANTID)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        GRIDSTORE.Rows.Add(dr("STOREITEMNAME"), Val(dr("PCS")))
                    Next
                End If
                total()
            Else
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTOREITEMNAME.Validating
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class