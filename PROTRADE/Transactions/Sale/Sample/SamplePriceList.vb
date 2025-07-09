
Imports System.ComponentModel
Imports BL

Public Class SamplePriceList

    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSPLNO As String

    Private Sub cmdEXIT_Click(sender As Object, e As EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim OBJSPL As New ClsSamplePriceList()

            OBJSPL.ALPARAVAL.Add(Format(Convert.ToDateTime(SPLDATE.Text).Date, "MM/dd/yyyy"))
            OBJSPL.ALPARAVAL.Add(CMBPARTYNAME.Text.Trim)
            OBJSPL.ALPARAVAL.Add(TXTMODEOFSHIPMENT.Text.Trim)
            OBJSPL.ALPARAVAL.Add(Val(LBLTOTALMTRS.Text.Trim))
            OBJSPL.ALPARAVAL.Add(Val(LBLTOTALAMT.Text.Trim))
            OBJSPL.ALPARAVAL.Add(txtremarks.Text.Trim)

            OBJSPL.ALPARAVAL.Add(CmpId)
            OBJSPL.ALPARAVAL.Add(Userid)
            OBJSPL.ALPARAVAL.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim RATE As String = ""
            Dim MTRS As String = ""
            Dim AMOUNT As String = ""
            Dim NARRATION As String = ""

            For Each ROW As DataGridViewRow In GRIDSPL.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(gsrno.Index).Value)
                        ITEMNAME = ROW.Cells(gitemname.Index).Value
                        QUALITY = ROW.Cells(GQUALITY.Index).Value
                        DESIGN = ROW.Cells(GDESIGN.Index).Value
                        COLOR = ROW.Cells(GCOLOR.Index).Value
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        MTRS = Val(ROW.Cells(GMTRS.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        NARRATION = ROW.Cells(GNARRATION.Index).Value

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(gsrno.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & ROW.Cells(gitemname.Index).Value
                        QUALITY = QUALITY & "|" & ROW.Cells(GQUALITY.Index).Value
                        DESIGN = DESIGN & "|" & ROW.Cells(GDESIGN.Index).Value
                        COLOR = COLOR & "|" & ROW.Cells(GCOLOR.Index).Value
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        MTRS = MTRS & "|" & Val(ROW.Cells(GMTRS.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        NARRATION = NARRATION & "|" & ROW.Cells(GNARRATION.Index).Value


                    End If
                End If
            Next

            OBJSPL.ALPARAVAL.Add(GRIDSRNO)
            OBJSPL.ALPARAVAL.Add(ITEMNAME)
            OBJSPL.ALPARAVAL.Add(QUALITY)
            OBJSPL.ALPARAVAL.Add(DESIGN)
            OBJSPL.ALPARAVAL.Add(COLOR)
            OBJSPL.ALPARAVAL.Add(RATE)
            OBJSPL.ALPARAVAL.Add(MTRS)
            OBJSPL.ALPARAVAL.Add(AMOUNT)
            OBJSPL.ALPARAVAL.Add(NARRATION)



            If EDIT = False Then
                Dim DT As DataTable = OBJSPL.SAVE()
                MessageBox.Show("Details Added")
                TXTSPLNO.Text = DT.Rows(0).Item(0)
            Else
                OBJSPL.ALPARAVAL.Add(TEMPSPLNO)
                Dim IntResult As Integer = OBJSPL.UPDATE()
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

        If GRIDSPL.RowCount = 0 Then
            EP.SetError(TXTNARRATION, " Please Enter Data in grid")
            bln = False
        End If

        If SPLDATE.Text = "__/__/____" Then
            EP.SetError(SPLDATE, " Please Enter Proper Date")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMBPARTYNAME_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.GotFocus
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDSPL.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, Val(TXTRATE.Text.Trim), Val(TXTMTRS.Text.Trim), Val(TXTAMOUNT.Text.Trim), TXTNARRATION.Text.Trim)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSPL.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDSPL.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDSPL.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDSPL.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDSPL.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDSPL.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDSPL.Item(GMTRS.Index, TEMPROW).Value = Val(TXTMTRS.Text.Trim)
            GRIDSPL.Item(GAMOUNT.Index, TEMPROW).Value = Val(TXTAMOUNT.Text.Trim)
            GRIDSPL.Item(GNARRATION.Index, TEMPROW).Value = TXTNARRATION.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        GRIDSPL.FirstDisplayedScrollingRowIndex = GRIDSPL.RowCount - 1

        TXTSRNO.Text = GRIDSPL.RowCount + 1
        CMBITEMNAME.Text = ""
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBARCODE.Clear()
        TXTRATE.Clear()
        TXTMTRS.Clear()
        TXTAMOUNT.Clear()
        TXTNARRATION.Clear()

        TXTBARCODE.Focus()
        TOTAL()

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALAMT.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSPL.Rows
                LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text.Trim) + Val(ROW.Cells(GAMOUNT.Index).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            CMBPARTYNAME.Text = ""
            SPLDATE.Text = Now.Date
            TXTMODEOFSHIPMENT.Clear()
            TXTBARCODE.Clear()
            txtremarks.Clear()
            CMBITEMNAME.Text = ""
            CMBQUALITY.Text = ""
            CMBDESIGN.Text = ""
            CMBCOLOR.Text = ""
            TXTRATE.Clear()
            TXTMTRS.Clear()
            TXTAMOUNT.Clear()
            TXTNARRATION.Clear()
            GRIDSPL.RowCount = 0

            LBLTOTALMTRS.Text = 0.0
            LBLTOTALAMT.Text = 0.0

            EP.Clear()
            GETMAX_SPLNO()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_SPLNO()
        Dim DTTABLE As DataTable = getmax(" isnull(max(SPL_no),0) + 1 ", "SAMPLEPRICELIST", " AND SPL_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSPLNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub SamplePricelist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                Dim objclsSMP As New ClsSamplePriceList()
                Dim dt_po As DataTable = objclsSMP.selectSMP(TEMPSPLNO, CmpId, Locationid, YearId)

                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows
                        TXTSPLNO.Text = TEMPSPLNO
                        SPLDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBPARTYNAME.Text = Convert.ToString(dr("NAME"))
                        TXTMODEOFSHIPMENT.Text = Convert.ToString(dr("MODE"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        GRIDSPL.Rows.Add(Val(dr("GRIDSRNO")), dr("ITEMNAME"), dr("QUALITYNAME"), dr("DESIGN").ToString, dr("COLOR").ToString, Val(dr("RATE")), Val(dr("MTRS")), Val(dr("AMOUNT")), dr("NARRATION").ToString)

                    Next
                    GRIDSPL.FirstDisplayedScrollingRowIndex = GRIDSPL.RowCount - 1
                    TOTAL()
                Else
                    EDIT = False
                    clear()
                End If
            End If

            TXTSRNO.Text = Val(GRIDSPL.RowCount) + 1

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors')")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBPARTYNAME.Focus()
    End Sub

    Private Sub SamplePricelist_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDSPL.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                ToolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                Toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
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

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Delete Sample barcode ?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPSPLNO)
                    alParaval.Add(YearId)

                    Dim clspo As New ClsSamplePriceList()
                    clspo.ALPARAVAL = alParaval
                    Dim IntResult As Integer = clspo.Delete()
                    MsgBox("sample barcode Deleted")
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
            If GRIDSPL.CurrentRow.Index >= 0 And GRIDSPL.Item(gsrno.Index, GRIDSPL.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = GRIDSPL.CurrentRow.Index
                TXTSRNO.Text = GRIDSPL.Item(gsrno.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSPL.Item(gitemname.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDSPL.Item(GQUALITY.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSPL.Item(GDESIGN.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDSPL.Item(GCOLOR.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(GRIDSPL.Item(GRATE.Index, GRIDSPL.CurrentRow.Index).Value)
                TXTMTRS.Text = Val(GRIDSPL.Item(GMTRS.Index, GRIDSPL.CurrentRow.Index).Value)
                TXTAMOUNT.Text = Val(GRIDSPL.Item(GAMOUNT.Index, GRIDSPL.CurrentRow.Index).Value)
                TXTNARRATION.Text = GRIDSPL.Item(GNARRATION.Index, GRIDSPL.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSPL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSPL.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSPL.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSPL.Rows.RemoveAt(GRIDSPL.CurrentRow.Index)
                getsrno(GRIDSPL)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
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
            GRIDSPL.RowCount = 0
LINE1:
            TEMPSPLNO = Val(TXTSPLNO.Text) - 1
            If TEMPSPLNO > 0 Then
                EDIT = True
                SamplePricelist_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSPL.RowCount = 0 And TEMPSPLNO > 1 Then
                TXTSPLNO.Text = TEMPSPLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolnext.Click
        Try
            GRIDSPL.RowCount = 0
LINE1:
            TEMPSPLNO = Val(TXTSPLNO.Text) + 1
            GETMAX_SPLNO()
            Dim MAXNO As Integer = TXTSPLNO.Text.Trim
            clear()
            If Val(TXTSPLNO.Text) - 1 >= TEMPSPLNO Then
                EDIT = True
                SamplePricelist_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDSPL.RowCount = 0 And TEMPSPLNO < MAXNO Then
                TXTSPLNO.Text = TEMPSPLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Price List?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJSMP As New SaleOrderDesign
            OBJSMP.MdiParent = MDIMain
            OBJSMP.FRMSTRING = "SAMPLEPRICELIST"
            OBJSMP.FORMULA = "{SAMPLEPRICELIST.SPL_no}=" & Val(TXTSPLNO.Text.Trim) & " and {SAMPLEPRICELIST.SPL_yearid}=" & YearId
            OBJSMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
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

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SPLDATE_Validating(sender As Object, e As CancelEventArgs) Handles SPLDATE.Validating
        Try
            If SPLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SPLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try
            If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, CMBCODE, e, Me, TXTADD, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors') ", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(sender As Object, e As EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then
        '                Dim OBJCMN As New ClsCommon
        '                'no need for yearid clause here as we need to fetch this barcode in all acccouting year
        '                Dim DT As DataTable = OBJCMN.search(" SAMPLEBARCODE.SB_NO AS SBNO, SAMPLEBARCODE.SB_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(SAMPLEBARCODE.SB_REMARKS, '') AS REMARKS, SAMPLEBARCODE.SB_BARCODE AS BARCODE", "", " SAMPLEBARCODE INNER JOIN ITEMMASTER ON SAMPLEBARCODE.SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SAMPLEBARCODE.SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SAMPLEBARCODE.SB_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND SB_BARCODE = '" & TXTBARCODE.Text.Trim & "'")
        '                If DT.Rows.Count > 0 Then

        '                    Dim RATE As Double = 0

        '                    'GET RATE
        '                    Dim WHERECLAUSE As String = ""
        '                    If DT.Rows(0).Item("DESIGN") <> "" Then WHERECLAUSE = WHERECLAUSE & " And ISNULL(DESIGNMASTER.DESIGN_NO,'') = '" & DT.Rows(0).Item("DESIGN") & "'"
        '                    If DT.Rows(0).Item("COLOR") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DT.Rows(0).Item("COLOR") & "'"
        '                    Dim DTRATE As DataTable = OBJCMN.search("PRICELISTMASTER.PL_RATE AS SALERATE ", "", "PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ISNULL(ITEMMASTER.ITEM_NAME,'') = '" & DT.Rows(0).Item("ITEMNAME") & "'" & WHERECLAUSE & " AND PL_YEARID = " & YearId)
        '                    If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("SALERATE"))

        '                    GRIDSPL.Rows.Add(GRIDSPL.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("DESIGN"), DT.Rows(0).Item("COLOR"), Val(RATE), 0, 0, "")
        '                    GRIDSPL.FirstDisplayedScrollingRowIndex = GRIDSPL.RowCount - 1


        'LINE1:
        '                    TXTBARCODE.Clear()
        '                    TXTBARCODE.Focus()
        '                End If
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub GRIDSPL_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSPL.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNARRATION_Validating(sender As Object, e As CancelEventArgs) Handles TXTNARRATION.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated, TXTMTRS.Validated
        TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTMTRS.Text.Trim), "0.00")
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                'no need for yearid clause here as we need to fetch this barcode in all acccouting year
                Dim DT As DataTable = OBJCMN.search(" SAMPLEBARCODE.SB_NO AS SBNO, SAMPLEBARCODE.SB_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITY, ISNULL(DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(SAMPLEBARCODE.SB_REMARKS, '') AS REMARKS, SAMPLEBARCODE.SB_BARCODE AS BARCODE", "", " SAMPLEBARCODE INNER JOIN ITEMMASTER ON SAMPLEBARCODE.SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON SAMPLEBARCODE.SB_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON SAMPLEBARCODE.SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SAMPLEBARCODE.SB_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND SB_BARCODE = '" & TXTBARCODE.Text.Trim & "'")
                If DT.Rows.Count > 0 Then

                    Dim RATE As Double = 0

                    'GET RATE
                    Dim WHERECLAUSE As String = ""
                    If DT.Rows(0).Item("DESIGN") <> "" Then WHERECLAUSE = WHERECLAUSE & " And ISNULL(DESIGNMASTER.DESIGN_NO,'') = '" & DT.Rows(0).Item("DESIGN") & "'"
                    If DT.Rows(0).Item("COLOR") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & DT.Rows(0).Item("COLOR") & "'"
                    Dim DTRATE As DataTable = OBJCMN.search("PRICELISTMASTER.PL_RATE AS SALERATE ", "", "PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ISNULL(ITEMMASTER.ITEM_NAME,'') = '" & DT.Rows(0).Item("ITEMNAME") & "'" & WHERECLAUSE & " AND PL_YEARID = " & YearId)
                    If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("SALERATE"))

                    GRIDSPL.Rows.Add(GRIDSPL.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGN"), DT.Rows(0).Item("COLOR"), Val(RATE), 0, 0, "")
                    GRIDSPL.FirstDisplayedScrollingRowIndex = GRIDSPL.RowCount - 1


LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class