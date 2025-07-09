
Imports System.ComponentModel
Imports BL

Public Class UpdateRackShelf

    Public TEMPENTRYNO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateRackShelf_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub UpdateRackShelf_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
            CLEAR()

            FILLGRID()

            If EDIT = True Then

                Dim OBJRACK As New ClsUpdateRackShelf()
                Dim dttable As DataTable = OBJRACK.SELECTUPDATERACKSHELF(TEMPENTRYNO, YearId)
                If dttable.Rows.Count > 0 Then
                    TXTENTRYNO.Text = TEMPENTRYNO
                    DTUPDATEDATE.Value = Format(Convert.ToDateTime(dttable.Rows(0).Item("DATE")).Date, "dd/MM/yyyy")
                    CMBRACK.Text = Convert.ToString(dttable.Rows(0).Item("RACK").ToString)
                    CMBSHELF.Text = Convert.ToString(dttable.Rows(0).Item("SHELF").ToString)
                    txtremarks.Text = Convert.ToString(dttable.Rows(0).Item("remarks").ToString)
                    gridbilldetails.DataSource = dttable
                    If dttable.Rows.Count > 0 Then
                        gridbill.FocusedRowHandle = gridbill.RowCount - 1
                        gridbill.TopRowIndex = gridbill.RowCount - 15
                    End If
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
        DTUPDATEDATE.Value = Now.Date
        tstxtbillno.Clear()

        CMBRACK.Text = ""
        CMBSHELF.Text = ""
        TXTBARCODE.Clear()
        txtremarks.Clear()



        gridbilldetails.DataSource = Nothing
        GETMAXNO()


    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBRACK.Text.Trim.Length = 0 Then
                EP.SetError(CMBRACK, " Please Select Rack")
                bln = False
            End If

            If gridbill.RowCount = 0 Then
                EP.SetError(TXTBARCODE, "Select Barcode")
                bln = False
            End If

            If Not datecheck(DTUPDATEDATE.Text) Then
                EP.SetError(DTUPDATEDATE, "Date not in Accounting Year")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            EDIT = False
            DTUPDATEDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(UPDATE_no),0) + 1 ", " UPDATERACKSHELF ", " AND UPDATE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTENTRYNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMDSAVE_Click(sender As Object, e As EventArgs) Handles CMDSAVE.Click
        Try
            If CMBRACK.Text.Trim = "" And CMBSHELF.Text.Trim = "" Then Exit Sub

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

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
                ElseIf ROW("TYPE") = "INHOUSECHECK" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE INHOUSECHECKING_DESC SET CHECK_RACKID = " & RACKID & " , CHECK_SHELFID = " & SHELFID & " WHERE CHECK_BARCODE = '" & ROW("BARCODE") & "' AND CHECK_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "JOBIN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN_DESC SET JI_RACKID = " & RACKID & " , JI_SHELFID = " & SHELFID & " WHERE JI_BARCODE = '" & ROW("BARCODE") & "' AND JI_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "PACKING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE RECPACKING_DESC SET REC_RACKID = " & RACKID & " , REC_SHELFID = " & SHELFID & " WHERE REC_BARCODE = '" & ROW("BARCODE") & "' AND REC_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "SALERET" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURN_DESC SET SALRET_RACKID = " & RACKID & " , SALRET_SHELFID = " & SHELFID & " WHERE SALRET_BARCODE = '" & ROW("BARCODE") & "' AND SALRET_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "SALERETCHALLAN" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURNCHALLAN_DESC SET SRCH_RACKID = " & RACKID & " , SRCH_SHELFID = " & SHELFID & " WHERE SRCH_BARCODE = '" & ROW("BARCODE") & "' AND SRCH_YEARID = " & YearId, "", "")
                ElseIf ROW("TYPE") = "STOCKADJUSTMENT" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE STOCKADJUSTMENT_INDESC SET SA_RACKID = " & RACKID & ", SA_SHELFID = " & SHELFID & " WHERE SA_BARCODE = '" & ROW("BARCODE") & "' AND SA_YEARID = " & YearId, "", "")
                End If

            Next



            Dim alParaval As New ArrayList
            alParaval.Add(Format(DTUPDATEDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBRACK.Text.Trim)
            alParaval.Add(CMBSHELF.Text.Trim)
            alParaval.Add(Val(GPCS.SummaryText))
            alParaval.Add(Val(GMTRS.SummaryText))
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim GODOWN As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim MTRS As String = ""
            Dim PIECETYPE As String = ""
            Dim LOTNO As String = ""
            Dim BALENO As String = ""
            Dim CHALLANNO As String = ""
            Dim BARCODE As String = ""
            Dim TYPE As String = ""

            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                If GRIDSRNO = "" Then
                    GRIDSRNO = Val(ROW("SRNO"))
                    ITEMNAME = ROW("ITEMNAME")
                    QUALITY = ROW("QUALITY")
                    DESIGN = ROW("DESIGNNO")
                    COLOR = ROW("COLOR")
                    GODOWN = ROW("GODOWN")
                    PCS = Val(ROW("PCS"))
                    UNIT = ROW("UNIT")
                    MTRS = Val(ROW("MTRS"))
                    PIECETYPE = ROW("PIECETYPE")
                    LOTNO = ROW("LOTNO")
                    BALENO = ROW("BALENO")
                    CHALLANNO = ROW("CHALLANNO")
                    BARCODE = ROW("BARCODE")
                    TYPE = ROW("TYPE")

                Else
                    GRIDSRNO = GRIDSRNO & "|" & Val(ROW("SRNO"))
                    ITEMNAME = ITEMNAME & "|" & ROW("ITEMNAME")
                    QUALITY = QUALITY & "|" & ROW("QUALITY")
                    DESIGN = DESIGN & "|" & ROW("DESIGNNO")
                    COLOR = COLOR & "|" & ROW("COLOR")
                    GODOWN = GODOWN & "|" & ROW("GODOWN")
                    PCS = PCS & "|" & Val(ROW("PCS"))
                    UNIT = UNIT & "|" & ROW("UNIT")
                    MTRS = MTRS & "|" & Val(ROW("MTRS"))
                    PIECETYPE = PIECETYPE & "|" & ROW("PIECETYPE")
                    LOTNO = LOTNO & "|" & ROW("LOTNO")
                    BALENO = BALENO & "|" & ROW("BALENO")
                    CHALLANNO = CHALLANNO & "|" & ROW("CHALLANNO")
                    BARCODE = BARCODE & "|" & ROW("BARCODE")
                    TYPE = TYPE & "|" & ROW("TYPE")

                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(GODOWN)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)
            alParaval.Add(PIECETYPE)
            alParaval.Add(LOTNO)
            alParaval.Add(BALENO)
            alParaval.Add(CHALLANNO)
            alParaval.Add(BARCODE)
            alParaval.Add(TYPE)

            Dim OBJRACK As New ClsUpdateRackShelf()
            OBJRACK.alParaval = alParaval
            If EDIT = False Then
                Dim DTTABLE As DataTable = OBJRACK.SAVE()
                TXTENTRYNO.Text = DTTABLE.Rows(0).Item(0)
                TEMPENTRYNO = DTTABLE.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                alParaval.Add(TEMPENTRYNO)
                Dim IntResult As Integer = OBJRACK.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If

            CLEAR()
            DTUPDATEDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSRNO()
        Try
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                ROW("SRNO") = I + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            'THIS CODE IS WRITTEN BY GULKIT
            'WE HAVE PASSED YEARID=0, DONT CHANGE THIS CODE
            'THIS IS DONE AS WE NEED DATASOURCE TO BE LINKED WITH GRID
            Dim objclsCMST As New ClsCommon
            Dim dt As DataTable = objclsCMST.Execute_Any_String(" SELECT *, 0 as SRNO FROM BARCODESTOCK WHERE BARCODESTOCK.YEARID = 0 ", "", "")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
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

    Private Sub CMBRACK_Validating(sender As Object, e As CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
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
            Cursor.Current = Cursors.WaitCursor
            gridbilldetails.DataSource = Nothing
LINE1:
            TEMPENTRYNO = Val(TXTENTRYNO.Text) - 1
            If TEMPENTRYNO > 0 Then
                EDIT = True
                UpdateRackShelf_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPENTRYNO > 1 Then
                TXTENTRYNO.Text = TEMPENTRYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPENTRYNO = Val(TXTENTRYNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTENTRYNO.Text.Trim
            CLEAR()
            If Val(TXTENTRYNO.Text) - 1 >= TEMPENTRYNO Then
                EDIT = True
                UpdateRackShelf_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPENTRYNO < MAXNO Then
                TXTENTRYNO.Text = TEMPENTRYNO
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
                TEMPENTRYNO = Val(tstxtbillno.Text)
                If TEMPENTRYNO > 0 Then
                    EDIT = True
                    UpdateRackShelf_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridbill.RowCount > 0 Then
                Dim DT As DataTable = gridbilldetails.DataSource
                Dim ROW As DataRow = gridbill.GetFocusedDataRow
                DT.Rows.Remove(ROW)
                GETSRNO()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT, if YES THEN GIVE A MESSAGE THAT BARCODE EXISTS
                    Dim DTROW As DataRow
                    For I As Integer = 0 To gridbill.RowCount - 1
                        DTROW = gridbill.GetDataRow(I)
                        If LCase(DTROW("BARCODE")) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next
                    Dim DTGRID As DataTable = gridbilldetails.DataSource
                    DTGRID.ImportRow(DT.Rows(0))
LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                    GETSRNO()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(sender As Object, e As CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJRACK As New ClsUpdateRackShelf

                ALPARAVAL.Add(TEMPENTRYNO)
                ALPARAVAL.Add(YearId)
                OBJRACK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJRACK.DELETE()
                MsgBox("Entry Deleted Succesfully")
                CLEAR()
                EDIT = False
                DTUPDATEDATE.Focus()
            End If
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

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJRACK As New UpdateRackShelfDetails
            OBJRACK.MdiParent = MDIMain
            OBJRACK.Show()
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

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class