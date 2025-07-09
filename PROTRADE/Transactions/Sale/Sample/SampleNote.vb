
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class SampleNote

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSMPNO As String
    Dim tempMsg As Integer

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim OBJSMP As New ClsSampleNote()

            OBJSMP.ALPARAVAL.Add(Format(Convert.ToDateTime(SMPDATE.Text).Date, "MM/dd/yyyy"))
            OBJSMP.ALPARAVAL.Add(CMBPARTYNAME.Text.Trim)
            OBJSMP.ALPARAVAL.Add(Val(TXTSONO.Text.Trim))
            OBJSMP.ALPARAVAL.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
            OBJSMP.ALPARAVAL.Add(TXTMODEOFSHIPMENT.Text.Trim)
            OBJSMP.ALPARAVAL.Add(CMBSHIPTO.Text.Trim)
            OBJSMP.ALPARAVAL.Add(TXTDOCKETNO.Text.Trim)
            OBJSMP.ALPARAVAL.Add(txtremarks.Text.Trim)


            OBJSMP.ALPARAVAL.Add(CmpId)
            OBJSMP.ALPARAVAL.Add(Userid)
            OBJSMP.ALPARAVAL.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim GRIDDESC As String = ""
            Dim GRIDREMARKS As String = ""
            Dim GRIDSONO As String = ""
            Dim GRIDSOSRNO As String = ""


            For Each ROW As DataGridViewRow In GRIDSMP.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(gsrno.Index).Value)
                        ITEMNAME = ROW.Cells(gitemname.Index).Value
                        GRIDDESC = ROW.Cells(GDESCRIPTION.Index).Value
                        GRIDREMARKS = ROW.Cells(GGRIDREMARKS.Index).Value
                        GRIDSONO = Val(ROW.Cells(GSONO.Index).Value)
                        GRIDSOSRNO = Val(ROW.Cells(GSOSRNO.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(gsrno.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & ROW.Cells(gitemname.Index).Value
                        GRIDDESC = GRIDDESC & "|" & ROW.Cells(GDESCRIPTION.Index).Value
                        GRIDREMARKS = GRIDREMARKS & "|" & ROW.Cells(GGRIDREMARKS.Index).Value
                        GRIDSONO = GRIDSONO & "|" & Val(ROW.Cells(GSONO.Index).Value)
                        GRIDSOSRNO = GRIDSOSRNO & "|" & Val(ROW.Cells(GSOSRNO.Index).Value)

                    End If
                End If
            Next

            OBJSMP.ALPARAVAL.Add(GRIDSRNO)
            OBJSMP.ALPARAVAL.Add(ITEMNAME)
            OBJSMP.ALPARAVAL.Add(GRIDDESC)
            OBJSMP.ALPARAVAL.Add(GRIDREMARKS)
            OBJSMP.ALPARAVAL.Add(GRIDSONO)
            OBJSMP.ALPARAVAL.Add(GRIDSOSRNO)


            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJSMP.SAVE()
                MessageBox.Show("Details Added")
                TXTSMPNO.Text = DT.Rows(0).Item(0)
            Else
                OBJSMP.ALPARAVAL.Add(TEMPSMPNO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim IntResult As Integer = OBJSMP.UPDATE()
                MessageBox.Show("Details Updated")
            End If

            PRINTREPORT()

            EDIT = False
            clear()
            CMBPARTYNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBPARTYNAME.Text.Trim = "" Then
            EP.SetError(CMBPARTYNAME, " Please Fill Party Name ")
            bln = False
        End If

        If GRIDSMP.RowCount = 0 Then
            EP.SetError(TXTGRIDREMARKS, " Please Enter Data in grid")
            bln = False
        End If

        If SMPDATE.Text = "__/__/____" Then
            EP.SetError(SMPDATE, " Please Enter Proper Date")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMBPARTYNAME_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.GotFocus
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDSMP.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTDESC.Text.Trim, TXTGRIDREMARKS.Text.Trim)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSMP.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDSMP.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDSMP.Item(GDESCRIPTION.Index, TEMPROW).Value = TXTDESC.Text.Trim
            GRIDSMP.Item(GGRIDREMARKS.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        GRIDSMP.FirstDisplayedScrollingRowIndex = GRIDSMP.RowCount - 1

        TXTSRNO.Text = GRIDSMP.RowCount + 1
        CMBITEMNAME.Text = ""
        TXTDESC.Clear()
        TXTGRIDREMARKS.Clear()
        CMBITEMNAME.Focus()

    End Sub

    Sub clear()
        Try
            CMBPARTYNAME.Text = ""
            TXTSONO.Clear()
            SODATE.Text = Now.Date
            SMPDATE.Text = Now.Date
            TXTMODEOFSHIPMENT.Clear()
            CMBSHIPTO.Text = ""
            TXTDOCKETNO.Clear()

            CMBITEMNAME.Text = ""
            TXTDESC.Clear()
            TXTGRIDREMARKS.Clear()
            GRIDSMP.RowCount = 0
            txtremarks.Clear()

            EP.Clear()
            GETMAX_SMPNO()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_SMPNO()
        Dim DTTABLE As DataTable = getmax(" isnull(max(SMP_no),0) + 1 ", "SAMPLENOTEMASTER", " AND SMP_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSMPNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub SampleNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsSMP As New ClsSampleNote()
                Dim dt_po As DataTable = objclsSMP.selectSMP(TEMPSMPNO, CmpId, Locationid, YearId)

                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows
                        TXTSMPNO.Text = TEMPSMPNO
                        SMPDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBPARTYNAME.Text = Convert.ToString(dr("PARTYNAME"))
                        TXTSONO.Text = dr("SONO")
                        SODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTMODEOFSHIPMENT.Text = Convert.ToString(dr("MODE"))
                        CMBSHIPTO.Text = Convert.ToString(dr("SHIPTO"))
                        TXTDOCKETNO.Text = Convert.ToString(dr("DOCKETNO"))

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        GRIDSMP.Rows.Add(Val(dr("GRIDSRNO")), dr("ITEMNAME"), dr("GRIDDESC").ToString, dr("GRIDREMARKS").ToString, Val(dr("GRIDSONO")), Val(dr("GRIDSOSRNO")))

                    Next
                    GRIDSMP.FirstDisplayedScrollingRowIndex = GRIDSMP.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
            End If

            TXTSRNO.Text = Val(GRIDSMP.RowCount + 1)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors')")
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors')")
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBPARTYNAME.Focus()
    End Sub

    Private Sub SampleNote_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'for grid foucs
                GRIDSMP.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                ToolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                Toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripButton3_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSMP_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSMP.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                tempMsg = MsgBox("Delete Sample Note ?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPSMPNO)
                    alParaval.Add(YearId)

                    Dim clspo As New ClsSampleNote()
                    clspo.ALPARAVAL = alParaval
                    IntResult = clspo.Delete()
                    MsgBox("sample note Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDSMP.CurrentRow.Index >= 0 And GRIDSMP.Item(gsrno.Index, GRIDSMP.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = GRIDSMP.CurrentRow.Index
                TXTSRNO.Text = GRIDSMP.Item(gsrno.Index, GRIDSMP.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSMP.Item(gitemname.Index, GRIDSMP.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDSMP.Item(GDESCRIPTION.Index, GRIDSMP.CurrentRow.Index).Value.ToString
                TXTGRIDREMARKS.Text = GRIDSMP.Item(GGRIDREMARKS.Index, GRIDSMP.CurrentRow.Index).Value.ToString

                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSMP.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSMP.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSMP.Rows.RemoveAt(GRIDSMP.CurrentRow.Index)
                getsrno(GRIDSMP)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New SampleNoteDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdOK_Click(sender, e)
    End Sub

    Private Sub ToolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPREVIOUS.Click
        Try
            GRIDSMP.RowCount = 0
LINE1:
            TEMPSMPNO = Val(TXTSMPNO.Text) - 1
            If TEMPSMPNO > 0 Then
                EDIT = True
                SampleNote_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSMP.RowCount = 0 And TEMPSMPNO > 1 Then
                TXTSMPNO.Text = TEMPSMPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolnext.Click
        Try
            GRIDSMP.RowCount = 0
LINE1:
            TEMPSMPNO = Val(TXTSMPNO.Text) + 1
            GETMAX_SMPNO()
            Dim MAXNO As Integer = TXTSMPNO.Text.Trim
            clear()
            If Val(TXTSMPNO.Text) - 1 >= TEMPSMPNO Then
                EDIT = True
                SampleNote_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSMP.RowCount = 0 And TEMPSMPNO < MAXNO Then
                TXTSMPNO.Text = TEMPSMPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJSMP As New SaleOrderDesign
            OBJSMP.MdiParent = MDIMain
            OBJSMP.FRMSTRING = "SAMPLENOTE"
            OBJSMP.FORMULA = "{SAMPLENOTEMASTER.SMP_no}=" & Val(TXTSMPNO.Text.Trim) & " and {SAMPLENOTEMASTER.SMP_yearid}=" & YearId
            OBJSMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtgridremarks_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGRIDREMARKS.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try
            If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, CMBCODE, e, Me, TXTADD, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') ", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSO_Click(sender As Object, e As EventArgs) Handles CMDSELECTSO.Click
        Try
            Dim OBJSO As New SelectSO
            OBJSO.PARTYNAME = CMBPARTYNAME.Text.Trim
            OBJSO.FRMSTRING = "SAMPLENOTE"
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 Then
                'FETCH DATA FROM SALEORDER_DESC WITH RESPECT TO SELECTED SONO
                CMBPARTYNAME.Text = DT.Rows(0).Item("NAME")
                TXTSONO.Text = Val(DT.Rows(0).Item("SONO"))
                SODATE.Text = DT.Rows(0).Item("DATE")
                CMBSHIPTO.Text = DT.Rows(0).Item("DELIVERYAT")

                If CMBSHIPTO.Text.Trim <> "" Then CMBSHIPTO_Validated(sender, e)

                Dim OBJCMN As New ClsCommon
                Dim DTSO As DataTable = OBJCMN.search("ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(SO_GRIDREMARKS ,'') AS GRIDDESC, SO_NO AS SONO, SO_GRIDSRNO AS SOSRNO", "", " SALEORDER_DESC INNER JOIN ITEMMASTER ON SO_ITEMID = ITEM_ID ", " AND SO_NO = " & Val(TXTSONO.Text.Trim) & " AND SO_YEARID = " & YearId)
                For Each DTROW As DataRow In DTSO.Rows
                    GRIDSMP.Rows.Add(0, DTROW("ITEMNAME"), DTROW("GRIDDESC"), "", Val(DTROW("SONO")), Val(DTROW("SOSRNO")))
                Next
                getsrno(GRIDSMP)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, CMBCODE, e, Me, TXTADD, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') ", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_GotFocus(sender As Object, e As EventArgs) Handles CMBSHIPTO.GotFocus
        Try
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SMPDATE_Validating(sender As Object, e As CancelEventArgs) Handles SMPDATE.Validating
        Try
            If SMPDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SMPDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validated(sender As Object, e As EventArgs) Handles CMBSHIPTO.Validated
        Try
            'GET MODEOF SHIPMENT FROM EXCEISE COLUMN
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(Acc_exciseno,'') AS MODEOFSHIP", "", "LEDGERS ", " AND ACC_CMPNAME = '" & CMBSHIPTO.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("MODEOFSHIP") <> "" Then
                TXTMODEOFSHIPMENT.Text = DT.Rows(0).Item("MODEOFSHIP")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SampleNote_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then
                TXTSONO.ReadOnly = False
                SODATE.ReadOnly = False
                TXTSONO.BackColor = Color.White
                SODATE.BackColor = Color.White
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class