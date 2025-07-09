
Imports System.ComponentModel
Imports BL

Public Class StockTaking

    Public TEMPSTOCKNO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDSAVE_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StockTaking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)
            fillGODOWN(CMBGODOWN, False)
            CMBGODOWN.Text = USERGODOWN
            CLEAR()


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objSTOCK As New ClsStockTaking()
                Dim dttable As DataTable = objSTOCK.SELECTSTOCKTAKING(TEMPSTOCKNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    TXTSTOCKNO.Text = TEMPSTOCKNO
                    STOCKDATE.Value = Format(Convert.ToDateTime(dttable.Rows(0).Item("STOCKDATE")).Date, "dd/MM/yyyy")
                    CMBGODOWN.Text = dttable.Rows(0).Item("STOCKGODOWN")
                    CMBRACK.Text = dttable.Rows(0).Item("STOCKRACK")
                    CMBSHELF.Text = dttable.Rows(0).Item("STOCKSHELF")
                    TXTREMARKS.Text = dttable.Rows(0).Item("STOCKREMARKS")

                    gridbilldetails.DataSource = dttable
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        EP.Clear()

        STOCKDATE.Value = Now.Date
        tstxtbillno.Clear()

        TXTREMARKS.Clear()

        CMBRACK.Text = ""
        CMBSHELF.Text = ""
        TXTBARCODE.Clear()
        TXTREMARKS.Clear()

        gridbilldetails.DataSource = Nothing
        getmaxno()


    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If gridbill.RowCount = 0 Then
                EP.SetError(gridbilldetails, "Fill Item Details")
                bln = False
            End If

            If Not datecheck(STOCKDATE.Text) Then
                EP.SetError(STOCKDATE, "Date not in Accounting Year")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        STOCKDATE.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(NO),0) + 1 ", " STOCKTAKING ", " AND YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSTOCKNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try

            If gridbill.FilterPanelText <> "" Then gridbill.ActiveFilterEnabled = False
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Format(STOCKDATE.Value.Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(CMBRACK.Text.Trim)
            ALPARAVAL.Add(CMBSHELF.Text.Trim)
            ALPARAVAL.Add(Val(GPCS.SummaryText))
            ALPARAVAL.Add(Val(GMTRS.SummaryText))
            ALPARAVAL.Add(TXTREMARKS.Text.Trim)

            Dim BARCODE As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                If BARCODE = "" Then
                    BARCODE = dtrow("BARCODE")
                    FROMNO = Val(dtrow("FROMNO"))
                    FROMSRNO = Val(dtrow("FROMSRNO"))
                    FROMTYPE = dtrow("TYPE")
                Else
                    BARCODE = BARCODE & "|" & dtrow("BARCODE")
                    FROMNO = FROMNO & "|" & Val(dtrow("FROMNO"))
                    FROMSRNO = FROMSRNO & "|" & Val(dtrow("FROMSRNO"))
                    FROMTYPE = FROMTYPE & "|" & dtrow("TYPE")
                End If
            Next

            ALPARAVAL.Add(BARCODE)
            ALPARAVAL.Add(FROMNO)
            ALPARAVAL.Add(FROMSRNO)
            ALPARAVAL.Add(FROMTYPE)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            Dim objSTOCK As New ClsStockTaking()
            objSTOCK.alParaval = ALPARAVAL
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objSTOCK.SAVE()
                MsgBox("Details Added")
                TXTSTOCKNO.Text = DTTABLE.Rows(0).Item(0)
                TEMPSTOCKNO = DTTABLE.Rows(0).Item(0)

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                ALPARAVAL.Add(TEMPSTOCKNO)
                Dim IntResult As Integer = objSTOCK.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If



            'UPDATING RACK AND SHELF
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If ROW Is Nothing Then Exit Sub
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim RACKID As Integer = 0
                Dim SHELFID As Integer = 0

                If CMBRACK.Text.Trim <> "" Then
                    DT = OBJCMN.search("RACK_ID AS RACKID", "", "RACKMASTER", " AND RACK_NAME = '" & CMBRACK.Text.Trim & "' AND RACK_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then RACKID = DT.Rows(0).Item("RACKID")
                End If

                If CMBSHELF.Text.Trim <> "" Then
                    DT = OBJCMN.search("SHELF_ID AS SHELFID", "", "SHELFMASTER", " AND SHELF_NAME = '" & CMBSHELF.Text.Trim & "' AND SHELF_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then SHELFID = DT.Rows(0).Item("SHELFID")
                End If

                If ROW("TYPE") = "OPENING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE STOCKMASTER SET SM_RACKID = " & RACKID & " , SM_SHELFID = " & SHELFID & " WHERE SM_BARCODE = '" & ROW("BARCODE") & "' AND SM_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "GRN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE GRN_DESC SET GRN_RACKID = " & RACKID & " , GRN_SHELFID = " & SHELFID & " WHERE GRN_BARCODE = '" & ROW("BARCODE") & "' AND GRN_GRIDTYPE = 'FANCY MATERIAL' AND GRN_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "MATREC" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT_DESC SET MATREC_RACKID = " & RACKID & " , MATREC_SHELFID = " & SHELFID & " WHERE MATREC_BARCODE = '" & ROW("BARCODE") & "' AND MATREC_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "JOBIN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN_DESC SET JI_RACKID = " & RACKID & " , JI_SHELFID = " & SHELFID & " WHERE JI_BARCODE = '" & ROW("BARCODE") & "' AND JI_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "PACKING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE RECPACKING_DESC SET REC_RACKID = " & RACKID & " , REC_SHELFID = " & SHELFID & " WHERE REC_BARCODE = '" & ROW("BARCODE") & "' AND REC_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "SALERET" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURN_DESC SET SALRET_RACKID = " & RACKID & " , SALRET_SHELFID = " & SHELFID & " WHERE SALRET_BARCODE = '" & ROW("BARCODE") & "' AND SALRET_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "STOCKADJUSTMENT" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE STOCKADJUSTMENT_INDESC SET SA_RACKID = " & RACKID & " , SA_SHELFID = " & SHELFID & " WHERE SA_BARCODE = '" & ROW("BARCODE") & "' AND SA_YEARID = " & YearId, "", "")
                End If

            Next

            CLEAR()
            STOCKDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Enter(sender As Object, e As EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(sender As Object, e As EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridbilldetails.DataSource = Nothing
LINE1:
            TEMPSTOCKNO = Val(TXTSTOCKNO.Text) - 1
            If TEMPSTOCKNO > 0 Then
                EDIT = True
                StockTaking_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPSTOCKNO > 1 Then
                TXTSTOCKNO.Text = TEMPSTOCKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPSTOCKNO = Val(TXTSTOCKNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTSTOCKNO.Text.Trim
            CLEAR()
            If Val(TXTSTOCKNO.Text) - 1 >= TEMPSTOCKNO Then
                EDIT = True
                StockTaking_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPSTOCKNO < MAXNO Then
                TXTSTOCKNO.Text = TEMPSTOCKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridbilldetails.DataSource = Nothing
                TEMPSTOCKNO = Val(tstxtbillno.Text)
                If TEMPSTOCKNO > 0 Then
                    EDIT = True
                    StockTaking_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        '        Try
        '            If TXTBARCODE.Text.Trim.Length > 0 Then

        '                Dim objclsCMST As New ClsCommon
        '                Dim DT As DataTable = objclsCMST.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
        '                If DT.Rows.Count > 0 Then

        '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT, if YES THEN GIVE A MESSAGE THAT BARCODE EXISTS
        '                    'ALSO CHECK WHETHER BARCODE IS PRESENT IN OTHER STOCKTAKING ENTRY
        '                    Dim DTROW As DataRow
        '                    For I As Integer = 0 To gridbill.RowCount - 1
        '                        DTROW = gridbill.GetDataRow(I)
        '                        If LCase(DTROW("BARCODE")) = LCase(TXTBARCODE.Text.Trim) Then
        '                            MsgBox("Barcode Already Exist in Stock..", MsgBoxStyle.Critical)
        '                            GoTo LINE1
        '                        End If
        '                    Next

        '                    Dim DTCHECK As DataTable = objclsCMST.Execute_Any_String("SELECT NO FROM STOCKTAKING_DESC WHERE BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId & " AND NO <> " & Val(TXTSTOCKNO.Text.Trim), "", "")
        '                    If DTCHECK.Rows.Count > 0 Then
        '                        MsgBox("Barcode Already Exist in Entry No " & DTCHECK.Rows(0).Item(0), MsgBoxStyle.Critical)
        '                        GoTo LINE1
        '                    End If

        '                    If gridbill.RowCount = 0 Then
        '                        gridbilldetails.DataSource = DT
        '                    Else
        '                        Dim DTGRID As DataTable = gridbilldetails.DataSource
        '                        DTGRID.ImportRow(DT.Rows(0))
        '                        DTROW = gridbill.GetDataRow(gridbill.DataRowCount - 1)
        '                        gridbill.MakeRowVisible(gridbill.DataRowCount - 1, True)
        '                    End If
        'LINE1:
        '                    TXTBARCODE.Clear()
        '                End If
        '            End If
        '        Catch ex As Exception
        '            Throw ex
        '        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If gridbill.SelectedRowsCount > 0 Then
                If e.KeyCode = Keys.Delete Then
                    Dim DT As DataTable = gridbilldetails.DataSource
                    DT.Rows.RemoveAt(gridbill.FocusedRowHandle)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Stock Taking?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBSTOCK As New ClsStockTaking

                ALPARAVAL.Add(TEMPSTOCKNO)
                ALPARAVAL.Add(YearId)
                OBSTOCK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBSTOCK.DELETE()
                MsgBox("Stock Taking Deleted Succesfully")
                CLEAR()
                EDIT = False
                STOCKDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJstock As New StockTakingDetails
            OBJstock.MdiParent = MDIMain
            OBJstock.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Call CMDSAVE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Stock Taking.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Stock Taking"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Taking", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Stock Taking Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub StockTaking_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then GITEMNAME.Visible = False
        If ClientName = "SAFFRON" Then
            GITEMCODE.Visible = True
            GITEMCODE.VisibleIndex = 0
            GCATEGORY.Visible = True
            GCATEGORY.VisibleIndex = 2
        End If
    End Sub

    Private Sub CMBRACK_Validating(sender As Object, e As CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim objclsCMST As New ClsCommon
                Dim DT As DataTable = objclsCMST.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT, if YES THEN GIVE A MESSAGE THAT BARCODE EXISTS
                    'ALSO CHECK WHETHER BARCODE IS PRESENT IN OTHER STOCKTAKING ENTRY
                    Dim DTROW As DataRow
                    For I As Integer = 0 To gridbill.RowCount - 1
                        DTROW = gridbill.GetDataRow(I)
                        If LCase(DTROW("BARCODE")) = LCase(TXTBARCODE.Text.Trim) Then
                            MsgBox("Barcode Already Exist in Stock..", MsgBoxStyle.Critical)
                            GoTo LINE1
                        End If
                    Next

                    Dim DTCHECK As DataTable = objclsCMST.Execute_Any_String("SELECT NO FROM STOCKTAKING_DESC WHERE BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId & " AND NO <> " & Val(TXTSTOCKNO.Text.Trim), "", "")
                    If DTCHECK.Rows.Count > 0 Then
                        MsgBox("Barcode Already Exist in Entry No " & DTCHECK.Rows(0).Item(0), MsgBoxStyle.Critical)
                        GoTo LINE1
                    End If

                    If gridbill.RowCount = 0 Then
                        gridbilldetails.DataSource = DT
                    Else
                        Dim DTGRID As DataTable = gridbilldetails.DataSource
                        DTGRID.ImportRow(DT.Rows(0))
                        DTROW = gridbill.GetDataRow(gridbill.DataRowCount - 1)
                        gridbill.MakeRowVisible(gridbill.DataRowCount - 1, True)
                    End If
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
End Class