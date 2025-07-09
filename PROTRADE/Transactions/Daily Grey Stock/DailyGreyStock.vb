Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class DailyGreyStock

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPSTOCKNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim TEMPUPLOADROW As Integer
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String
    Dim ALLOWMANUALJINO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub


    Sub clear()
        LBLTOTALPCS.Text = 0.0
        LBLTOTALCLOSINGPCS.Text = 0.0
        EP.Clear()
        CMBITEMNAME.Text = ""
        TXTPCS.Clear()
        TXTCLOSINGPCS.Clear()
        TXTSTOCKNO.Clear()
        GRIDPROGRAM.RowCount = 0
        DTSTOCKDATE.Text = Now.Date

        getmaxno()
        GRIDPROGRAM.DataSource = Nothing

        GRIDDOUBLECLICK = False

    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If GRIDPROGRAM.RowCount = 0 Then
                EP.SetError(CMBITEMNAME, "Enter Bill Details")
                bln = False
            End If



            If DTSTOCKDATE.Text = "__/__/____" Then
                EP.SetError(DTSTOCKDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(DTSTOCKDATE.Text) Then
                    EP.SetError(DTSTOCKDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                'If USERDELETE = False Then
                '    MsgBox("Insufficient Rights")
                '    Exit Sub
                'End If


                TEMPMSG = MsgBox("Delete Stock?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSTOCKNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim OBJMATREC As New ClsDailyGreyStock()
                    OBJMATREC.alParaval = alParaval
                    IntResult = OBJMATREC.Delete()
                    MsgBox("Stock Receipt Deleted")
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTSTOCKNO.ReadOnly = False Then
                alParaval.Add(Val(TXTSTOCKNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(DTSTOCKDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(LBLTOTALPCS.Text.Trim)
            alParaval.Add(LBLTOTALCLOSINGPCS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)



            Dim ITEMNAME As String = ""
            Dim PCS As String = ""
            Dim CLOSINGPCS As String = ""
            


            For Each row As Windows.Forms.DataGridViewRow In GRIDPROGRAM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If ITEMNAME = "" Then
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        PCS = Val(row.Cells(GPCS.Index).Value.ToString)
                        CLOSINGPCS = Val(row.Cells(GCLOSING.Index).Value.ToString)


                    Else
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        CLOSINGPCS = CLOSINGPCS & "|" & VAL(row.Cells(GCLOSING.Index).Value.ToString)

                    End If
                End If
            Next

            alParaval.Add(ITEMNAME)
            alParaval.Add(PCS)
            alParaval.Add(CLOSINGPCS)
           

            Dim OBJDailyGreyStock As New ClsDailyGreyStock()
            OBJDailyGreyStock.alParaval = alParaval


            If EDIT = False Then
                Dim DTTABLE As DataTable = OBJDailyGreyStock.save()
                MsgBox("Details Added")
                TXTSTOCKNO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))

            Else
                alParaval.Add(TEMPSTOCKNO)
                IntResult = OBJDailyGreyStock.Update()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPSTOCKNO)
                EDIT = False
            End If
            clear()
            CMBITEMNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub PRINTREPORT(ByVal STOCKNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Daily Grey Stock?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "DailyGreyStock"
                OBJGDN.FORMULA = "{GSTOCK.ST_NO}=" & Val(STOCKNO) & " and {GSTOCK.ST_yearid}=" & YearId
                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DailyGreyStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            clear()

            If EDIT = True Then
                Dim OBJDailyGreyStock As New ClsDailyGreyStock()
                Dim dttable As New DataTable
                dttable = OBJDailyGreyStock.selectstock(TEMPSTOCKNO, CmpId, YearId)

                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        TXTSTOCKNO.Text = TEMPSTOCKNO
                        TXTSTOCKNO.ReadOnly = True
                        DTSTOCKDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        LBLTOTALPCS.Text = dr("PCS").ToString
                        LBLTOTALCLOSINGPCS.Text = dr("CLOSINGPCS")

                        'Item Grid
                        GRIDPROGRAM.Rows.Add(dr("ITEMNAME").ToString, Format(Val(dr("GRIDPCS")), "0.00"), Format(Val(dr("GRIDCLOSINGPCS")), "0.00"))
                    Next
                    GRIDPROGRAM.FirstDisplayedScrollingRowIndex = GRIDPROGRAM.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
                total()
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPROGRAM.RowCount = 0
LINE1:
            TEMPSTOCKNO = Val(TXTSTOCKNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTSTOCKNO.Text.Trim
            clear()
            If Val(TXTSTOCKNO.Text) - 1 >= TEMPSTOCKNO Then
                EDIT = True
                DailyGreyStock_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPROGRAM.RowCount = 0 And TEMPSTOCKNO < MAXNO Then
                TXTSTOCKNO.Text = TEMPSTOCKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(ST_NO),0) + 1 ", " GSTOCK", " and ST_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTSTOCKNO.Text = DTTABLE.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDPROGRAM.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDPROGRAM.Rows.Add(CMBITEMNAME.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTCLOSINGPCS.Text.Trim), "0.00"))

            ElseIf GRIDDOUBLECLICK = True Then

                GRIDPROGRAM.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDPROGRAM.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
                GRIDPROGRAM.Item(GCLOSING.Index, TEMPROW).Value = Format(Val(TXTCLOSINGPCS.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If


            CMBITEMNAME.Text = ""
            TXTPCS.Clear()
            TXTCLOSINGPCS.Clear()
            CMBITEMNAME.Text = ""
            CMBITEMNAME.Focus()

            GRIDPROGRAM.FirstDisplayedScrollingRowIndex = GRIDPROGRAM.RowCount - 1
            'clear()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSTOCKNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSTOCKNO.Validating
        Try
            If Val(TXTSTOCKNO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GSTOCK.ST_NO,0)  AS STOCKNO", "", " GSTOCK ", "  AND GSTOCK.ST_NO=" & TXTSTOCKNO.Text.Trim & " AND GSTOCK.ST_CMPID = " & CmpId & " AND GSTOCK.ST_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Grey Stock No Already Exists")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSTOCKNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSTOCKNO.KeyPress
        numkeypress(e, TXTSTOCKNO, Me)
    End Sub

    Private Sub TXTCLOSINGPCS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCLOSINGPCS.Validating
        If CMBITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(TXTCLOSINGPCS.Text.Trim) > 0 Then
            fillgrid()
        Else
            If CMBITEMNAME.Text.Trim = "" Then
                MsgBox("Please Fill Item Name ")
                CMBITEMNAME.Focus()
                Exit Sub
            ElseIf Val(TXTCLOSINGPCS.Text.Trim) = 0 And Val(TXTPCS.Text.Trim) = 0 Then
                MsgBox("PCS can not be zero")
                TXTCLOSINGPCS.Clear()

                Exit Sub
            End If
        End If
    End Sub


    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        CMBITEMNAME.Focus()
    End Sub

    Sub EDITROW()
        Try
            If GRIDPROGRAM.CurrentRow.Index >= 0 And GRIDPROGRAM.Item(GITEMNAME.Index, GRIDPROGRAM.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True

                CMBITEMNAME.Text = GRIDPROGRAM.Item(GITEMNAME.Index, GRIDPROGRAM.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDPROGRAM.Item(GPCS.Index, GRIDPROGRAM.CurrentRow.Index).Value.ToString
                TXTCLOSINGPCS.Text = GRIDPROGRAM.Item(GCLOSING.Index, GRIDPROGRAM.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDPROGRAM.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
   
    Private Sub GRIDPROGRAM_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROGRAM.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            GRIDPROGRAM.RowCount = 0
LINE1:
            TEMPSTOCKNO = Val(TXTSTOCKNO.Text) - 1
            If TEMPSTOCKNO > 0 Then
                EDIT = True
                DailyGreyStock_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPROGRAM.RowCount = 0 And TEMPSTOCKNO > 1 Then
                TXTSTOCKNO.Text = TEMPSTOCKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub total()
        Try
            LBLTOTALPCS.Text = 0.0
            LBLTOTALCLOSINGPCS.Text = 0.0


            For Each ROW As DataGridViewRow In GRIDPROGRAM.Rows
                If ROW.Cells(GITEMNAME.Index).Value.ToString <> Nothing Then

                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCLOSINGPCS.Text = Format(Val(LBLTOTALCLOSINGPCS.Text) + Val(ROW.Cells(GCLOSING.Index).EditedFormattedValue), "0.00")

                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROGRAM_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPROGRAM.CellValidating
        total()
    End Sub


    

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(TEMPSTOCKNO)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJJobinDetails As New DailyGreyStockDetails
            OBJJobinDetails.MdiParent = MDIMain
            OBJJobinDetails.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPROGRAM.RowCount = 0
                TEMPSTOCKNO = Val(tstxtbillno.Text)
                If TEMPSTOCKNO > 0 Then
                    EDIT = True
                    DailyGreyStock_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DailyGreyStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDPROGRAM.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New DailyGreyStockDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GRIDPROGRAM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROGRAM.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPROGRAM.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDPROGRAM.Rows.RemoveAt(GRIDPROGRAM.CurrentRow.Index)

                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class