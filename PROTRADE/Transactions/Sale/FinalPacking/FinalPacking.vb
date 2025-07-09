
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class FinalPacking

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPFPNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        FPDATE.Text = Now.Date

        TXTSRNO.Text = 1
        CMBMERCHANT.Text = ""
        TXTPCS.Clear()
        TXTPCSMTRS.Clear()
        TXTMTRS.Clear()
        TXTBARCODE.Clear()
        GRIDFP.RowCount = 0
        GRIDITEMDESC.RowCount = 0

        lbllocked.Visible = False
        PBlock.Visible = False

        lbltotalqty.Text = 0
        LBLTOTALMTRS.Text = 0
        LBLTOTALITEMMTRS.Text = 0

        GRIDDOUBLECLICK = False
        getmaxno()

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            lbltotalqty.Text = 0
            LBLTOTALITEMMTRS.Text = 0.0
            GRIDITEMDESC.RowCount = 0

            For Each ROW As DataGridViewRow In GRIDFP.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If

                'CLEAR AND ADD ITEMS IN ITEMDESCGRID WITH RESPECT TO MERCHANT IN FPGRID
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME,  MERCHANTMASTER.CONFIG_MTRS AS MTRS", "", " MERCHANTMASTER INNER JOIN ITEMMASTER AS MERCHANTITEMMASTER ON MERCHANTMASTER.CONFIG_MERCHANTID = MERCHANTITEMMASTER.item_id INNER JOIN ITEMMASTER ON MERCHANTMASTER.CONFIG_ITEMID = ITEMMASTER.item_id ", " AND MERCHANTITEMMASTER.ITEM_NAME = '" & ROW.Cells(GMERCHANTNAME.Index).Value & "' AND CONFIG_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        'CHECK WHETHER SAME ITEM IS PRESENT IN GRID OR NOT
                        If GRIDITEMDESC.RowCount = 0 Then
                            GRIDITEMDESC.Rows.Add(DTROW("ITEMNAME"), Format(Val(DTROW("MTRS")) * Val(ROW.Cells(GPCS.Index).Value), "0.00"))
                        Else
                            For Each ITEMROW As DataGridViewRow In GRIDITEMDESC.Rows
                                If ITEMROW.Cells(GITEMNAME.Index).Value = DTROW("ITEMNAME") Then
                                    ITEMROW.Cells(GITEMMTRS.Index).Value = Val(ITEMROW.Cells(GITEMMTRS.Index).Value) + (Val(DTROW("MTRS")) * Val(ROW.Cells(GPCS.Index).Value))
                                    GoTo LINE1
                                End If
                            Next
                            GRIDITEMDESC.Rows.Add(DTROW("ITEMNAME"), Format(Val(DTROW("MTRS")) * Val(ROW.Cells(GPCS.Index).Value), "0.00"))
LINE1:
                        End If
                    Next
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDITEMDESC.Rows
                If ROW.Cells(GITEMNAME.Index).Value <> Nothing Then
                    LBLTOTALITEMMTRS.Text = Format(Val(LBLTOTALITEMMTRS.Text) + Val(ROW.Cells(GITEMMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBGODOWN.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(FP_no),0) + 1 ", "FINALPACKING", " AND FP_YEARID =" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTFPNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, "Please Select Godown Name")
                BLN = False
            End If

            If GRIDFP.RowCount = 0 Then
                EP.SetError(CMBGODOWN, "Fill Item Details")
                BLN = False
            End If

            If FPDATE.Text = "__/__/____" Then
                EP.SetError(FPDATE, " Please Enter Proper Date")
                BLN = False
            Else
                If Not datecheck(FPDATE.Text) Then
                    EP.SetError(FPDATE, "Date not in Accounting Year")
                    BLN = False
                End If
            End If

            Return BLN
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

            ' If CMBTONAME.Text.Trim <> "" Then ADDPOUT(TXTPOUTNO)
            Dim alParaval As New ArrayList
            alParaval.Add(Format(Convert.ToDateTime(FPDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALITEMMTRS.Text))


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            

            Dim GRIDSRNO As String = ""
            Dim MERCHANTNAME As String = ""
            Dim PCS As String = ""
            Dim PCSMTRS As String = ""
            Dim MTRS As String = ""
            Dim BARCODE As String = ""
            
            For Each row As Windows.Forms.DataGridViewRow In GRIDFP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value.ToString)
                        MERCHANTNAME = row.Cells(GMERCHANTNAME.Index).Value.ToString
                        PCS = Val(row.Cells(GPCS.Index).Value)
                        PCSMTRS = Val(row.Cells(GPCSMTRS.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        MERCHANTNAME = MERCHANTNAME & "|" & row.Cells(GMERCHANTNAME.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        PCSMTRS = PCSMTRS & "|" & Val(row.Cells(GPCSMTRS.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(MERCHANTNAME)
            alParaval.Add(PCS)
            alParaval.Add(PCSMTRS)
            alParaval.Add(MTRS)
            alParaval.Add(BARCODE)


            Dim ITEMNAME As String = ""
            Dim ITEMMTRS As String = ""
            
            For Each row As Windows.Forms.DataGridViewRow In GRIDITEMDESC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If ITEMNAME = "" Then
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        ITEMMTRS = Val(row.Cells(GITEMMTRS.Index).Value)
                    Else
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        ITEMMTRS = ITEMMTRS & "|" & Val(row.Cells(GITEMMTRS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ITEMNAME)
            alParaval.Add(ITEMMTRS)

            Dim OBJFP As New ClsFinalPacking()
            OBJFP.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJFP.SAVE()
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPFPNO)

                Dim IntResult As Integer = OBJFP.UPDATE()
                MsgBox("Details Updated")
            End If

            EDIT = False
            clear()
            CMBGODOWN.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FinalPacking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Dim OBJINVDTLS As New FinalPackingDetails
            OBJINVDTLS.MdiParent = MDIMain
            OBJINVDTLS.Show()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDFP.Focus()
        End If
    End Sub

    Private Sub FinalPacking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
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

                Dim OBJFP As New ClsFinalPacking()
                OBJFP.alParaval.Add(TEMPFPNO)
                OBJFP.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJFP.SELECTFINALPACKING()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTFPNO.Text = TEMPFPNO
                        FPDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        
                        'Item Grid
                        GRIDFP.Rows.Add(dr("GRIDSRNO").ToString, dr("MERCHANTNAME").ToString, Format(Val(dr("PCS")), "0"), Format(Val(dr("PCSMTRS")), "0.00"), Format(Val(dr("MTRS")), "0.00"))

                        If Val(dr("OUTPCS")) > 0 Or Val(dr("OUTMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                Else
                    EDIT = False
                    clear()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" ITEM_NAME AS ITEMNAME, FP_MTRS AS ITEMMTRS ", "", " FINALPACKING_ITEMDESC INNER JOIN ITEMMASTER ON FP_ITEMID = ITEM_ID ", " AND FP_NO = " & TEMPFPNO & " AND FP_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDITEMDESC.Rows.Add(DTR("ITEMNAME"), Val(DTR("ITEMMTRS")))
                    Next
                    total()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectGodown
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBGODOWN.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJFP As New FinalPackingDetails
            OBJFP.MdiParent = MDIMain
            OBJFP.Show()
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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDFP.RowCount = 0
                TEMPFPNO = Val(tstxtbillno.Text)
                If TEMPFPNO > 0 Then
                    EDIT = True
                    FinalPacking_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDFP.Rows.Add(Val(TXTSRNO.Text.Trim), CMBMERCHANT.Text.Trim, Val(TXTPCS.Text.Trim), Val(TXTPCSMTRS.Text.Trim), Val(TXTMTRS.Text.Trim), TXTBARCODE.Text.Trim, 0, 0)
            getsrno(GRIDFP)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDFP.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDFP.Item(GMERCHANTNAME.Index, TEMPROW).Value = CMBMERCHANT.Text.Trim
            GRIDFP.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0")
            GRIDFP.Item(GPCSMTRS.Index, TEMPROW).Value = Format(Val(TXTPCSMTRS.Text.Trim), "0.00")
            GRIDFP.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False
        End If


        total()

        GRIDFP.FirstDisplayedScrollingRowIndex = GRIDFP.RowCount - 1

        CMBMERCHANT.Text = ""
        TXTPCS.Clear()
        TXTPCSMTRS.Clear()
        TXTMTRS.Clear()
        CMBMERCHANT.Focus()

    End Sub

    Sub EDITROW()
        Try
            If GRIDFP.CurrentRow.Index >= 0 And GRIDFP.Item(gsrno.Index, GRIDFP.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDFP.Item(gsrno.Index, GRIDFP.CurrentRow.Index).Value.ToString
                CMBMERCHANT.Text = GRIDFP.Item(GMERCHANTNAME.Index, GRIDFP.CurrentRow.Index).Value.ToString
                TXTPCS.Text = Val(GRIDFP.Item(GPCS.Index, GRIDFP.CurrentRow.Index).Value)
                TXTPCSMTRS.Text = Val(GRIDFP.Item(GPCSMTRS.Index, GRIDFP.CurrentRow.Index).Value)
                TXTMTRS.Text = Val(GRIDFP.Item(GMTRS.Index, GRIDFP.CurrentRow.Index).Value)

                TEMPROW = GRIDFP.CurrentRow.Index
                CMBMERCHANT.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFP_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFP.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDFP.RowCount = 0
LINE1:
            TEMPFPNO = Val(TXTFPNO.Text) - 1
            If TEMPFPNO > 0 Then
                EDIT = True
                FinalPacking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDFP.RowCount = 0 And TEMPFPNO > 1 Then
                TXTFPNO.Text = TEMPFPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDFP.RowCount = 0
LINE1:
            TEMPFPNO = Val(TXTFPNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTFPNO.Text.Trim
            clear()
            If Val(TXTFPNO.Text) - 1 >= TEMPFPNO Then
                EDIT = True
                FinalPacking_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDFP.RowCount = 0 And TEMPFPNO < MAXNO Then
                TXTFPNO.Text = TEMPFPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Delete Final Packing?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


                Dim alParaval As New ArrayList
                alParaval.Add(TXTFPNO.Text.Trim)
                alParaval.Add(YearId)

                Dim CLSFINALPACKING As New ClsFinalPacking()
                CLSFINALPACKING.alParaval = alParaval
                Dim IntResult As Integer = CLSFINALPACKING.DELETE()
                MsgBox("Final Packing Deleted")
                clear()
                EDIT = False
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDFP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFP.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFP.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'CMBMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDFP.Rows.RemoveAt(GRIDFP.CurrentRow.Index)
                getsrno(GRIDFP)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        Try
            If CMBMERCHANT.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
                If GRIDDOUBLECLICK = False Then
                    If EDIT = True Then
                        'GET LAST BARCODE SRNO
                        Dim LSRNO As Integer = 0
                        Dim RSRNO As Integer = 0
                        Dim SNO As Integer = 0
                        LSRNO = InStr(GRIDFP.Rows(GRIDFP.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        RSRNO = InStr(LSRNO + 1, GRIDFP.Rows(GRIDFP.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        SNO = GRIDFP.Rows(GRIDFP.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                        TXTBARCODE.Text = "FP-" & Val(TXTFPNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                    Else
                        TXTBARCODE.Text = "FP-" & Val(TXTFPNO.Text.Trim) & "/" & GRIDFP.RowCount + 1 & "/" & YearId
                    End If
                End If
                fillgrid()
            ElseIf CMBMERCHANT.Text.Trim = "" Then
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPCS.Validated
        CALC()
    End Sub

    Private Sub CMBMERCHANT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBMERCHANT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBMERCHANT.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Sub CALC()
        Try
            TXTMTRS.Text = Format(Val(TXTPCS.Text.Trim) * Val(TXTPCSMTRS.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Validated
        Try
            If CMBMERCHANT.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL( SUM(MERCHANTMASTER.CONFIG_MTRS),0) AS PCSMTRS", "", " MERCHANTMASTER INNER JOIN ITEMMASTER ON MERCHANTMASTER.CONFIG_MERCHANTID = ITEMMASTER.item_id ", " AND ITEM_NAME = '" & CMBMERCHANT.Text.Trim & "' AND CONFIG_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPCSMTRS.Text = Val(DT.Rows(0).Item("PCSMTRS"))
                    CALC()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FPDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FPDATE.GotFocus
        FPDATE.SelectAll()
    End Sub

    Private Sub FPDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FPDATE.Validating
        If FPDATE.Text = "__/__/____" Then
            EP.SetError(FPDATE, " Please Enter Proper Date")
            e.Cancel = True
            Exit Sub
        Else
            If Not datecheck(FPDATE.Text) Then
                EP.SetError(FPDATE, "Date not in Accounting Year")
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub
End Class