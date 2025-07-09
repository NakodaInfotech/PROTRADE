
Imports System.ComponentModel
Imports BL

Public Class EmbProduction

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPPRODNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALPRODNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTEMBPRODNO.Clear()
        EMBPRODDATE.Text = Now.Date
        CMDSELECTJOB.Enabled = True
        GRIDTHREAD.RowCount = 0


        If ALLOWMANUALPRODNO = True Then
            TXTEMBPRODNO.ReadOnly = False
            TXTEMBPRODNO.BackColor = Color.LemonChiffon
        Else
            TXTEMBPRODNO.ReadOnly = True
            TXTEMBPRODNO.BackColor = Color.Linen
        End If

        tstxtbillno.Clear()

        CMBLABOUR.Text = ""
        CMBSHIFT.SelectedIndex = 0
        CMBMACHINENO.Text = ""
        CMBITEMNAME.Text = ""
        CMBSHADE.Text = ""
        TXTMTRS.Clear()
        TXTSTITCHES.Clear()
        TXTFRAMES.Clear()
        TXTRUNFRAMES.Clear()
        TXTTOTALPROD.Clear()
        TXTEXPFRAMES.Clear()
        TXTACTUALPROD.Clear()
        TXTDIFF.Clear()
        txtremarks.Clear()
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date
        TXTJONO.Clear()
        TXTJOSRNO.Clear()


        txtsrno.Clear()
        CMBSTOREITEM.Text = ""
        TXTCONES.Clear()
        TXTTHREADMTRS.Clear()


        GRIDDOUBLECLICK = False
        getmaxno()
        LBLTOTALMTRS.Text = 0
        LBLTOTALCONES.Text = 0

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALCONES.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDTHREAD.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBLABOUR.Focus()
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(PROD_no),0) + 1 ", " EMBPRODUCTION ", " and PROD_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTEMBPRODNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If CMBLABOUR.Text.Trim.Length = 0 Then
                EP.SetError(CMBLABOUR, " Please Select Labour Name")
                bln = False
            End If

            If Val(TXTJOSRNO.Text.Trim) = 0 Then
                EP.SetError(TXTJONO, " Please Select Job Out Entry")
                bln = False
            End If

            If CMBMACHINENO.Text.Trim.Length = 0 Then
                EP.SetError(CMBMACHINENO, " Please Select Machine")
                bln = False
            End If

            If CMBITEMNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBITEMNAME, " Please Select Item Name")
                bln = False
            End If

            If Val(TXTMTRS.Text.Trim) = 0 Then
                EP.SetError(TXTMTRS, " Please Enter Mtrs")
                bln = False
            End If

            If Val(TXTFRAMES.Text.Trim) = 0 And Val(TXTRUNFRAMES.Text.Trim) = 0 Then
                EP.SetError(TXTFRAMES, " Please Enter Frames")
                bln = False
            End If

            'DIFF CANNOT BE GREATER THAN STITCHED (PER FRAME)
            If Val(TXTSTITCHES.Text.Trim) > 0 And Val(TXTDIFF.Text.Trim) > Val(TXTSTITCHES.Text.Trim) Then
                EP.SetError(TXTDIFF, " Diff Greater than Stitches")
                bln = False
            End If

            'DIFF CANNOT BE GREATER THAN STITCHED (PER FRAME)
            If Val(TXTSTITCHES.Text.Trim) < 0 And Val(TXTDIFF.Text.Trim) > (Val(TXTSTITCHES.Text.Trim) * -1) Then
                EP.SetError(TXTDIFF, " Diff Greater than Stitches")
                bln = False
            End If



            If Val(TXTACTUALPROD.Text.Trim) = 0 Then
                EP.SetError(TXTACTUALPROD, " Please Enter Prod")
                bln = False
            End If

            If Val(TXTEMBPRODNO.Text.Trim) = 0 Then
                EP.SetError(TXTEMBPRODNO, "Enter Prod No")
                bln = False
            End If


            If TXTCHALLANNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" PROD_challanno, LEDGERS.ACC_cmpname", "", " EMBPRODUCTION inner join LEDGERS on LEDGERS.ACC_id = PROD_ledgerid ", " and PROD_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBLABOUR.Text.Trim & "' AND PROD_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If

            If EMBPRODDATE.Text = "__/__/____" Then
                EP.SetError(EMBPRODDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(EMBPRODDATE.Text) Then
                    EP.SetError(EMBPRODDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'THIS CODE IS OF NO USE NOW, COZ WE HAVE SAVED BARCODE ON SP
            'If Not CHECKBARCODE() Then
            '    bln = False
            '    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            'End If

            If ALLOWMANUALPRODNO = True Then
                If TXTEMBPRODNO.Text <> "" And CMBLABOUR.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(EMBPRODUCTION.PROD_NO,0)  AS JINO", "", " EMBPRODUCTION ", "  AND EMBPRODUCTION.PROD_NO=" & TXTEMBPRODNO.Text.Trim & " AND EMBPRODUCTION.PROD_CMPID = " & CmpId & " AND EMBPRODUCTION.PROD_LOCATIONID = " & Locationid & " AND EMBPRODUCTION.PROD_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTEMBPRODNO, "Prod No Already Exist")
                        bln = False
                    End If
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTEMBPRODNO.ReadOnly = False Then
                alParaval.Add(Val(TXTEMBPRODNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(EMBPRODDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBLABOUR.Text.Trim)
            alParaval.Add(CMBSHIFT.Text.Trim)
            alParaval.Add(CMBMACHINENO.Text.Trim)
            alParaval.Add(CMBITEMNAME.Text.Trim)
            alParaval.Add(CMBSHADE.Text.Trim)
            alParaval.Add(Val(TXTMTRS.Text.Trim))
            alParaval.Add(Val(TXTSTITCHES.Text.Trim))
            alParaval.Add(Val(TXTFRAMES.Text.Trim))
            alParaval.Add(Val(TXTRUNFRAMES.Text.Trim))
            alParaval.Add(Val(TXTTOTALPROD.Text.Trim))
            alParaval.Add(Val(TXTACTUALPROD.Text.Trim))
            alParaval.Add(Val(TXTDIFF.Text.Trim))

            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(CHALLANDATE.Value.Date)
            alParaval.Add(TXTJONO.Text.Trim)
            alParaval.Add(TXTJOSRNO.Text.Trim)


            alParaval.Add(Val(LBLTOTALCONES.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim THREAD As String = ""
            Dim CONES As String = ""
            Dim THREADMTRS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTHREAD.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        THREAD = row.Cells(GTHREAD.Index).Value.ToString
                        CONES = Val(row.Cells(GCONES.Index).Value)
                        THREADMTRS = Val(row.Cells(GMTRS.Index).Value)
                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        THREAD = THREAD & "|" & row.Cells(GTHREAD.Index).Value.ToString
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)
                        THREADMTRS = THREADMTRS & "|" & Val(row.Cells(GMTRS.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(THREAD)
            alParaval.Add(CONES)
            alParaval.Add(THREADMTRS)


            Dim OBJPROD As New ClsEmbProduction()
            OBJPROD.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJPROD.SAVE()
                MsgBox("Details Added")
                TXTEMBPRODNO.Text = DTTABLE.Rows(0).Item(0)

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRODNO)
                Dim IntResult As Integer = OBJPROD.UPDATE()
                MsgBox("Details Updated")
            End If

            EDIT = False

            clear()
            CMBLABOUR.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub EmbProduction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDTHREAD.Focus()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EmbProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOB IN'")
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

                Dim OBJPROD As New ClsEmbProduction()
                Dim dttable As DataTable = OBJPROD.SELECTEMBPROD(TEMPPRODNO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTEMBPRODNO.Text = TEMPPRODNO
                        TXTEMBPRODNO.ReadOnly = True
                        CMDSELECTJOB.Enabled = False

                        EMBPRODDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBLABOUR.Text = dr("LABOUR")
                        CMBSHIFT.Text = dr("SHIFT")
                        CMBMACHINENO.Text = dr("MACHINENO")
                        CMBITEMNAME.Text = dr("ITEMNAME")
                        CMBSHADE.Text = dr("SHADE")
                        TXTMTRS.Text = Val(dr("MTRS"))
                        TXTSTITCHES.Text = Val(dr("STITCHES"))
                        TXTFRAMES.Text = Val(dr("FRAMES"))
                        TXTRUNFRAMES.Text = Val(dr("RUNFRAMES"))
                        TXTTOTALPROD.Text = Val(dr("TOTALPROD"))
                        TXTACTUALPROD.Text = Val(dr("ACTUALPROD"))
                        TXTDIFF.Text = Val(dr("DIFF"))

                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        TXTJONO.Text = dr("JONO")
                        TXTJOSRNO.Text = dr("JOSRNO")


                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'THREAD Grid
                        GRIDTHREAD.Rows.Add(dr("GRIDSRNO").ToString, dr("THREAD"), Val(dr("CONES")), Val(dr("THREADMTRS")))

                    Next

                    total()
                    GRIDTHREAD.FirstDisplayedScrollingRowIndex = GRIDTHREAD.RowCount - 1
                Else
                    EDIT = False
                    clear()
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
            If CMBLABOUR.Text.Trim = "" Then FILLCONTRACT(CMBLABOUR)
            FILLMACHINE(CMBMACHINENO)
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            FILLCOLOR(CMBSHADE, "")

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

            Dim OBJPRODDetails As New EmbProductionDetails
            OBJPRODDetails.MdiParent = MDIMain
            OBJPRODDetails.Show()
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
                GRIDTHREAD.RowCount = 0
                TEMPPRODNO = Val(tstxtbillno.Text)
                If TEMPPRODNO > 0 Then
                    EDIT = True
                    EmbProduction_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDTHREAD.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDTHREAD.Rows.Add(Val(txtsrno.Text.Trim), CMBSTOREITEM.Text.Trim, Val(TXTCONES.Text.Trim), Val(TXTTHREADMTRS.Text.Trim))
                getsrno(GRIDTHREAD)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDTHREAD.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDTHREAD.Item(GTHREAD.Index, TEMPROW).Value = CMBSTOREITEM.Text.Trim
                GRIDTHREAD.Item(GCONES.Index, TEMPROW).Value = Val(TXTCONES.Text.Trim)
                GRIDTHREAD.Item(GMTRS.Index, TEMPROW).Value = Val(TXTTHREADMTRS.Text.Trim)

                GRIDDOUBLECLICK = False
            End If

            total()

            GRIDTHREAD.FirstDisplayedScrollingRowIndex = GRIDTHREAD.RowCount - 1

            txtsrno.Text = GRIDTHREAD.RowCount + 1
            CMBSTOREITEM.Text = ""
            TXTCONES.Clear()
            TXTTHREADMTRS.Clear()
            CMBSTOREITEM.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTHREAD.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDTHREAD.RowCount = 0
LINE1:
            TEMPPRODNO = Val(TXTEMBPRODNO.Text) - 1
            If TEMPPRODNO > 0 Then
                EDIT = True
                EmbProduction_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDTHREAD.RowCount = 0 And TEMPPRODNO > 1 Then
                TXTEMBPRODNO.Text = TEMPPRODNO
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
            GRIDTHREAD.RowCount = 0
LINE1:
            TEMPPRODNO = Val(TXTEMBPRODNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTEMBPRODNO.Text.Trim
            clear()
            If Val(TXTEMBPRODNO.Text) - 1 >= TEMPPRODNO Then
                EDIT = True
                EmbProduction_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDTHREAD.RowCount = 0 And TEMPPRODNO < MAXNO Then
                TXTEMBPRODNO.Text = TEMPPRODNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCONES.KeyPress, TXTFRAMES.KeyPress, TXTRUNFRAMES.KeyPress, TXTEMBPRODNO.KeyPress
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
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete EMBPRODUCTION Receipt?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(TXTEMBPRODNO.Text.Trim)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)

                Dim OBJMATREC As New ClsEmbProduction()
                OBJMATREC.alParaval = alParaval
                IntResult = OBJMATREC.DELETE()
                MsgBox("EMBPRODUCTION Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDTHREAD.CurrentRow.Index >= 0 And GRIDTHREAD.Item(gsrno.Index, GRIDTHREAD.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDTHREAD.Item(gsrno.Index, GRIDTHREAD.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDTHREAD.Item(GTHREAD.Index, GRIDTHREAD.CurrentRow.Index).Value.ToString
                TXTCONES.Text = Val(GRIDTHREAD.Item(GCONES.Index, GRIDTHREAD.CurrentRow.Index).Value)
                TXTTHREADMTRS.Text = Val(GRIDTHREAD.Item(GMTRS.Index, GRIDTHREAD.CurrentRow.Index).Value)

                TEMPROW = GRIDTHREAD.CurrentRow.Index
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTHREAD.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTHREAD.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDTHREAD.Rows.RemoveAt(GRIDTHREAD.CurrentRow.Index)
                getsrno(GRIDTHREAD)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORVALIDATE(CMBSHADE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTHREADMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTHREADMTRS.KeyPress, TXTMTRS.KeyPress, TXTACTUALPROD.KeyPress
        numdotkeypress(e, TXTTHREADMTRS, Me)
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPPRODNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal JINO As Integer)
        Try
            'If MsgBox("Wish to Print Job In?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            'Dim OBJGDN As New GDNDESIGN
            'OBJGDN.MdiParent = MDIMain
            'OBJGDN.FRMSTRING = "EMBPRODUCTION"
            'OBJGDN.FORMULA = "{EMBPRODUCTION.PROD_NO}=" & Val(JINO) & " and {EMBPRODUCTION.PROD_yearid}=" & YearId
            'OBJGDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EMBPRODDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EMBPRODDATE.GotFocus
        EMBPRODDATE.SelectAll()
    End Sub

    Private Sub EMBPRODDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EMBPRODDATE.Validating
        Try
            If EMBPRODDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(EMBPRODDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As DataTable = objclscommon.search(" PROD_challanno, CONTRACT_name", "", " EMBPRODUCTION inner join CONRACTMASTER on CONRACTMASTER.CONTRACT_id = PROD_CONRACTID ", " and PROD_challanno = '" & TXTCHALLANNO.Text.Trim & "' and CONRACTMASTER.CONTRACT_NAME = '" & CMBLABOUR.Text.Trim & "' AND PROD_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTEMBPRODNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEMBPRODNO.Validating
        Try
            If Val(TXTEMBPRODNO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(EMBPRODUCTION.PROD_NO,0)  AS JINO", "", " EMBPRODUCTION ", "  AND EMBPRODUCTION.PROD_NO=" & TXTEMBPRODNO.Text.Trim & " AND EMBPRODUCTION.PROD_CMPID = " & CmpId & " AND EMBPRODUCTION.PROD_LOCATIONID = " & Locationid & " AND EMBPRODUCTION.PROD_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Job In No Already Exists")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTHREAD_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDTHREAD.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTHREAD.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDTHREAD.Rows.RemoveAt(GRIDTHREAD.CurrentRow.Index)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTTHREADMTRS_Validated(sender As Object, e As EventArgs) Handles TXTTHREADMTRS.Validated
        Try
            If CMBSTOREITEM.Text.Trim <> "" And Val(TXTTHREADMTRS.Text.Trim) > 0 Then FILLGRID() Else MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBITEMNAME.Validated
        Try
            If ClientName = "KARAN" And CMBITEMNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_FOLD,0) AS STITCHES", "", "ITEMMASTER", " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTSTITCHES.Text = Val(DT.Rows(0).Item("STITCHES"))
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFRAMES_Validated(sender As Object, e As EventArgs) Handles TXTFRAMES.Validated, TXTRUNFRAMES.Validated, TXTACTUALPROD.Validated, TXTMTRS.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If CMBMACHINENO.Text.Trim <> "" Then

                'GET EXP FRAMES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("MACHINE_LENGTH AS LENGTH", "", "MACHINEMASTER ", " AND MACHINE_NAME = '" & CMBMACHINENO.Text.Trim & "' AND MACHINE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTEXPFRAMES.Text = Math.Ceiling(Val(TXTMTRS.Text.Trim) / Val(DT.Rows(0).Item("LENGTH")))

                TXTTOTALPROD.Text = Val(TXTFRAMES.Text.Trim) * Val(TXTSTITCHES.Text.Trim)
                TXTDIFF.Text = Val(TXTACTUALPROD.Text.Trim) - Val(TXTTOTALPROD.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLABOUR_Enter(sender As Object, e As EventArgs) Handles CMBLABOUR.Enter
        Try
            If CMBLABOUR.Text.Trim = "" Then FILLCONTRACT(CMBLABOUR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLABOUR_Validating(sender As Object, e As CancelEventArgs) Handles CMBLABOUR.Validating
        Try
            If CMBLABOUR.Text.Trim <> "" Then CONTRACTVALIDATE(CMBLABOUR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTJOB_Click(sender As Object, e As EventArgs) Handles CMDSELECTJOB.Click
        Try
            Dim OBJSELECT As New SelectJobOut
            OBJSELECT.ShowDialog()
            Dim DT As DataTable = OBJSELECT.DT
            If DT.Rows.Count > 0 Then
                TXTJONO.Text = Val(DT.Rows(0).Item("JONO"))
                TXTJOSRNO.Text = Val(DT.Rows(0).Item("GRIDSRNO"))
                CMBITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                CMBSHADE.Text = DT.Rows(0).Item("SHADE")
                TXTMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
                TXTSTITCHES.Text = Val(DT.Rows(0).Item("STITCHES"))
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINENO_Enter(sender As Object, e As EventArgs) Handles CMBMACHINENO.Enter
        Try
            If CMBMACHINENO.Text.Trim = "" Then FILLMACHINE(CMBMACHINENO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINENO_Validating(sender As Object, e As CancelEventArgs) Handles CMBMACHINENO.Validating
        Try
            If CMBMACHINENO.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINENO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINENO_Validated(sender As Object, e As EventArgs) Handles CMBMACHINENO.Validated
        CALC()
    End Sub
End Class