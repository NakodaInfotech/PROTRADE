
Imports BL

Public Class ItemPackingMaterial

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True
        gridbill.ClearColumnsFilter()

        If CMBITEMNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEMNAME, "Select Item Name")
            bln = False
        End If

        If CMBUNIT.Text.Trim.Length = 0 Then
            EP.SetError(CMBUNIT, "Select Unit")
            bln = False
        End If

        If gridbill.RowCount = 0 Then
            EP.SetError(CMBITEMNAME, "Enter Proper Details")
            bln = False
        End If

        Return bln
    End Function

    Sub FILLGRID()

        If GRIDDOUBLECLICK = False Then
            Dim DT As DataTable = gridbilldetails.DataSource
            DT.Rows.Add(CMBSTOREITEMNAME.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"))
        ElseIf GRIDDOUBLECLICK = True Then
            Dim DTROW As DataRow = gridbill.GetDataRow(TEMPROW)
            DTROW("STOREITEMNAME") = CMBSTOREITEMNAME.Text.Trim
            DTROW("QTY") = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False
        End If

        CMBSTOREITEMNAME.Text = ""
        TXTQTY.Clear()
        CMBSTOREITEMNAME.Focus()

    End Sub

    Private Sub ContractorItemConfig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()
        Try
            fillitemname(CMBITEMNAME, "")
            fillunit(CMBUNIT)
            FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            CMBITEMNAME.Text = ""
            CMBUNIT.Text = ""
            CMBSTOREITEMNAME.Text = ""
            TXTQTY.Clear()
            gridbilldetails.DataSource = Nothing

            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContractorItemConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKGRID() As Boolean
        Try
            Dim BLN As Boolean = True
            gridbill.ClearColumnsFilter()
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If (GRIDDOUBLECLICK = False And ROW("STOREITEMNAME") = CMBSTOREITEMNAME.Text.Trim) Or (GRIDDOUBLECLICK = True And I <> TEMPROW And ROW("STOREITEMNAME") = CMBSTOREITEMNAME.Text.Trim) Then
                    BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTQTY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTQTY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTQTY.Validated
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 Then
                If Not CHECKGRID() Then
                    MsgBox("Item Already Exist in Grid below", MsgBoxStyle.Critical)
                    CMBSTOREITEMNAME.Focus()
                    Exit Sub
                End If
                FILLGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
            CMBSTOREITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            CMBITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            Dim OBJCONFIG As New clsItemmaster

            ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
            ALPARAVAL.Add(CMBUNIT.Text.Trim)

            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim QTY As String = ""

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If ITEMNAME = "" Then
                    GRIDSRNO = I + 1
                    ITEMNAME = ROW("STOREITEMNAME")
                    QTY = Val(ROW("QTY"))
                Else
                    GRIDSRNO = GRIDSRNO & "|" & I + 1
                    ITEMNAME = ITEMNAME & "|" & ROW("STOREITEMNAME")
                    QTY = QTY & "|" & Val(ROW("QTY"))
                End If
            Next

            ALPARAVAL.Add(GRIDSRNO)
            ALPARAVAL.Add(ITEMNAME)
            ALPARAVAL.Add(QTY)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            OBJCONFIG.alParaval = ALPARAVAL
            Dim INT As Integer = OBJCONFIG.SAVESTORE()
            MsgBox("Details Added")
            CLEAR()
            CMBITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If gridbill.RowCount > 0 Then
                Dim TEMPMSG As Integer = MsgBox("Wish To Delete All Entries For Selected Unit?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE T FROM ITEMMASTER_STORES T INNER JOIN ITEMMASTER ON ITEMMASTER.ITEM_ID = T.ITEM_ID INNER JOIN UNITMASTER ON T.ITEM_UNITID = UNIT_ID WHERE ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND UNITMASTER.UNIT_ABBR = '" & CMBUNIT.Text.Trim & "' AND T.ITEM_YEARID = " & YearId, "", "")
                MsgBox("Entries Deleted Successfully !")
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            If gridbill.GetFocusedRowCellValue("STOREITEMNAME") <> "" Then
                GRIDDOUBLECLICK = True
                CMBSTOREITEMNAME.Text = gridbill.GetFocusedRowCellValue("STOREITEMNAME")
                TXTQTY.Text = Val(gridbill.GetFocusedRowCellValue("QTY"))
                TEMPROW = gridbill.GetFocusedDataSourceRowIndex
                CMBSTOREITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim DT As DataTable = gridbilldetails.DataSource
                DT.Rows.RemoveAt(gridbill.FocusedRowHandle)

            End If
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

    Private Sub CMBSTOREITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTOREITEMNAME.Validating
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" STOREITEMMASTER.STOREITEM_NAME AS STOREITEMNAME, ITEMMASTER_STORES.ITEM_QTY AS QTY ", "", " ITEMMASTER_STORES INNER JOIN ITEMMASTER ON ITEMMASTER_STORES.ITEM_ID = ITEMMASTER.item_id INNER JOIN UNITMASTER ON ITEMMASTER_STORES.ITEM_UNITID = UNITMASTER.unit_id INNER JOIN STOREITEMMASTER ON ITEMMASTER_STORES.ITEM_STOREITEMID = STOREITEMMASTER.STOREITEM_ID ", " AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND UNITMASTER.UNIT_ABBR = '" & CMBUNIT.Text.Trim & "' AND ITEMMASTER_STORES.ITEM_YEARID = " & YearId & " ORDER BY ITEMMASTER_STORES.ITEM_SRNO ")
                gridbilldetails.DataSource = DT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class