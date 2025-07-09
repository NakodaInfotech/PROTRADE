
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Class TransportChallan

    Public EDIT As Boolean          'used for editing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPTRANSNO As Integer     'used for poation no while editing
    Dim ALLOWMANUALTRANSNO As Boolean = False

    Sub clear()



        EP.Clear()
        tstxtbillno.Clear()

        If ALLOWMANUALTRANSNO = True Then
            TXTTRANSGDNNO.ReadOnly = False
            TXTTRANSGDNNO.BackColor = Color.LemonChiffon
        Else
            TXTTRANSGDNNO.ReadOnly = True
            TXTTRANSGDNNO.BackColor = Color.Linen
        End If

        TRANSGDNDATE.Text = Now.Date
        cmbname.Text = ""
        txtadd.Clear()

        CMBTRANS.Text = ""
        CMBDISPATCHTO.Text = ""
        If CMPCITYNAME <> "" Then CMBFROMCITY.Text = CMPCITYNAME Else CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""

        GRIDTRANS.RowCount = 0
        txtremarks.Clear()

        CMDSELECTGDN.Enabled = True
        GETMAXTRANSCHALLANNO()

        LBLTOTALBALES.Text = 0
        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0
        LBLAMOUNT.Text = 0

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLAMOUNT.Text = 0.0
            LBLTOTALBALES.Text = 0
            If GRIDTRANS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDTRANS.Rows
                    If Val(row.Cells(GRATE.Index).EditedFormattedValue) > 0 Then
                        If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                            row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(GTOTALMTRS.Index).EditedFormattedValue))
                        ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Pcs" Then
                            row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(GTOTALPCS.Index).EditedFormattedValue))
                        ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Bale" Then
                            row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(GTOTALBALES.Index).EditedFormattedValue))
                        End If
                    End If
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(GTOTALPCS.Index).EditedFormattedValue), "0.00")
                    LBLAMOUNT.Text = Format(Val(LBLAMOUNT.Text) + Val(row.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALBALES.Text = Format(Val(LBLTOTALBALES.Text) + Val(row.Cells(GTOTALBALES.Index).EditedFormattedValue), "0")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS", CMBTRANS.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDISPATCHTO.Enter
        Try
            If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDISPATCHTO.Validating
        Try
            If CMBDISPATCHTO.Text.Trim <> "" Then namevalidate(CMBDISPATCHTO, CMBCODE, e, Me, txtadd, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then fillledger(cmbname, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANS.Text.Trim = "" Then fillledger(CMBTRANS, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXTRANSCHALLANNO()
        Try
            'GET MAX NO OF TRANS CHALLAN
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("isnull(max(TRANS_NO),0) + 1", "", "TRANSPORTCHALLAN", " AND TRANS_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTTRANSGDNNO.Text = Val(DT.Rows(0).Item(0))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJTRANS As New TransportChallanDetails
            OBJTRANS.MdiParent = MDIMain
            OBJTRANS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True
            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Party Name ")
                bln = False
            End If

            If Val(TXTTRANSGDNNO.Text.Trim) = 0 Then
                EP.SetError(TXTTRANSGDNNO, "Invalid Trans Challan No")
                bln = False
            End If

          
            If Val(TXTTRANSGDNNO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(TRANSPORTCHALLAN.TRANS_NO,0)  AS TRANSNO", "", " TRANSPORTCHALLAN ", "  AND TRANS_NO=" & Val(TXTTRANSGDNNO.Text.Trim) & " AND TRANS_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTTRANSGDNNO, "Trans Challan No Already Exists")
                    bln = False
                End If
            End If

            If CMBTRANS.Text.Trim = "" Then
                EP.SetError(CMBTRANS, "Select Transport")
                bln = False
            End If

            If CMBFROMCITY.Text.Trim = "" Then
                EP.SetError(CMBFROMCITY, "Select From City")
                bln = False
            End If

            If CMBTOCITY.Text.Trim = "" Then
                EP.SetError(CMBTOCITY, "Select To City")
                bln = False
            End If

            If GRIDTRANS.RowCount = 0 Then
                EP.SetError(cmbname, "Fill Challan Details")
                bln = False
            End If

            If TRANSGDNDATE.Text = "__/__/____" Then
                EP.SetError(TRANSGDNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(TRANSGDNDATE.Text) Then
                    EP.SetError(TRANSGDNDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub CMDSELECTGDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTGDN.Click
        Try
            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim DTSO As New DataTable
            Dim OBJCHALLAN As New SelectChallanforTrans
            OBJCHALLAN.PARTYNAME = cmbname.Text.Trim
            OBJCHALLAN.ShowDialog()
            DTSO = OBJCHALLAN.DT
            If DTSO.Rows.Count > 0 Then
                CMBTRANS.Text = DTSO.Rows(0).Item("TRANSNAME")
                CMBDISPATCHTO.Text = DTSO.Rows(0).Item("DISPATCHTO")
                CMBTOCITY.Text = DTSO.Rows(0).Item("TOCITY")
                For Each DTROWPS As DataRow In DTSO.Rows
                    GRIDTRANS.Rows.Add(0, Val(DTROWPS("TYPECHALLANNO")), Val(DTROWPS("CHALLANNO")), Val(DTROWPS("TOTALBALES")), Val(DTROWPS("TOTALPCS")), Format(Val(DTROWPS("TOTALMTRS")), "0.00"), 0, "Mtrs", Val(DTROWPS("TOTALAMT")))
                Next
            End If
            getsrno(GRIDTRANS)
            CMDSELECTGDN.Enabled = False
            total()

        Catch ex As Exception
            Throw ex
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTTRANSGDNNO.ReadOnly = False Then
                alParaval.Add(Val(TXTTRANSGDNNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(TRANSGDNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(CMBDISPATCHTO.Text.Trim)
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)

            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLAMOUNT.Text))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim TYPECHALLANNO As String = ""
            Dim CHALLANNO As String = ""
            Dim BALE As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""
            Dim PER As String = ""
            Dim AMOUNT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        TYPECHALLANNO = Val(row.Cells(GTYPENO.Index).Value)
                        CHALLANNO = Val(row.Cells(GCHALLANNO.Index).Value)
                        BALE = Val(row.Cells(GTOTALBALES.Index).Value)
                        PCS = Val(row.Cells(GTOTALPCS.Index).Value)
                        MTRS = Val(row.Cells(GTOTALMTRS.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        PER = row.Cells(GPER.Index).Value.ToString
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        TYPECHALLANNO = TYPECHALLANNO & "|" & Val(row.Cells(GTYPENO.Index).Value)
                        CHALLANNO = CHALLANNO & "|" & Val(row.Cells(GCHALLANNO.Index).Value)
                        BALE = BALE & "|" & Val(row.Cells(GTOTALBALES.Index).Value)
                        PCS = PCS & "|" & Val(row.Cells(GTOTALPCS.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GTOTALMTRS.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        PER = PER & "|" & row.Cells(GPER.Index).Value.ToString
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(TYPECHALLANNO)
            alParaval.Add(CHALLANNO)
            alParaval.Add(BALE)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMOUNT)


            Dim OBJTRANS As New ClsTransChallan()
            OBJTRANS.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTT As DataTable = OBJTRANS.SAVE()
                TXTTRANSGDNNO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPTRANSNO)
                Dim IntResult As Integer = OBJTRANS.UPDATE()
                MsgBox("Details Updated")

            End If

            EDIT = False
            PRINTREPORT(TXTTRANSGDNNO.Text.Trim)

            clear()
            cmbname.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPTRANSNO = Val(TXTTRANSGDNNO.Text) - 1
            If TEMPTRANSNO > 0 Then
                EDIT = True
                TransportChallan_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDTRANS.RowCount = 0 And TEMPTRANSNO > 1 Then
                TXTTRANSGDNNO.Text = TEMPTRANSNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPTRANSNO = Val(TXTTRANSGDNNO.Text) + 1
            GETMAXTRANSCHALLANNO()
            Dim MAXNO As Integer = TXTTRANSGDNNO.Text.Trim
            clear()
            If Val(TXTTRANSGDNNO.Text) - 1 >= TEMPTRANSNO Then
                EDIT = True
                TransportChallan_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDTRANS.RowCount = 0 And TEMPTRANSNO < MAXNO Then
                TXTTRANSGDNNO.Text = TEMPTRANSNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDTRANS.RowCount = 0
                TEMPTRANSNO = Val(tstxtbillno.Text)
                If TEMPTRANSNO > 0 Then
                    EDIT = True
                    TransportChallan_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Wish to Delete Transport Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJTRANS As New ClsTransChallan
                OBJTRANS.alParaval.Add(TEMPTRANSNO)
                OBJTRANS.alParaval.Add(YearId)
                Dim INTRES As Integer = OBJTRANS.Delete
                MsgBox("Trans Challan Deleted")

                clear()
                EDIT = False
                cmbname.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal TRANSNO As Integer)
        Try
            If MsgBox("Wish to Print Transport Challan?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJTRANSGDN As New GDNDESIGN
                OBJTRANSGDN.MdiParent = MDIMain
                OBJTRANSGDN.FRMSTRING = "TRANSGDN"
                'OBJTRANSGDN.FORMULA = "{GDN.GDN_no}=" & Val(TRANSNO) & " AND {GDN.GDN_yearid}=" & YearId
                OBJTRANSGDN.FORMULA = "{TRANSPORTCHALLAN.TRANS_NO}=" & Val(TRANSNO) & " AND {TRANSPORTCHALLAN.TRANS_YEARID}=" & YearId

                OBJTRANSGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT(TEMPTRANSNO)
    End Sub

    Private Sub GRIDTRANS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDTRANS.CellValidating
        Try
            Dim colNum As Integer = GRIDTRANS.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum
                Case GRATE.Index, GAMOUNT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    If bValid Then
                        If GRIDTRANS.CurrentCell.Value = Nothing Then GRIDTRANS.CurrentCell.Value = "0.00"
                        GRIDTRANS.CurrentCell.Value = Convert.ToDecimal(GRIDTRANS.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case GTOTALBALES.Index
                    Dim dDebit As Integer
                    Dim bValid As Boolean = Integer.TryParse(e.FormattedValue.ToString, dDebit)
                    If bValid Then
                        If GRIDTRANS.CurrentCell.Value = Nothing Then GRIDTRANS.CurrentCell.Value = "0"
                        GRIDTRANS.CurrentCell.Value = Convert.ToDecimal(GRIDTRANS.Item(colNum, e.RowIndex).Value)
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case GPER.Index
                    total()
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTRANS.RowCount > 0 Then GRIDTRANS.Rows.RemoveAt(GRIDTRANS.CurrentRow.Index) ''Removing Row From Grid
            getsrno(GRIDTRANS)
            total()
             
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TransportChallan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDTRANS.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TransportChallan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'GDN'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJTRANS As New ClsTransChallan()
                OBJTRANS.alParaval.Add(TEMPTRANSNO)
                OBJTRANS.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJTRANS.SELECTTRANSGDN()
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTTRANSGDNNO.Text = TEMPTRANSNO
                        TXTTRANSGDNNO.ReadOnly = True

                        TRANSGDNDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        CMBDISPATCHTO.Text = dr("DISPATCHTO").ToString

                        CMBFROMCITY.Text = dr("FROMCITY").ToString
                        CMBTOCITY.Text = dr("TOCITY").ToString
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)

                        GRIDTRANS.Rows.Add(Val(dr("GRIDSRNO")), Val(dr("TYPECHALLANNO")), Val(dr("CHALLANNO")), Val(dr("BALES")), Val(dr("PCS")), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"))

                    Next
                    total()
                    GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TransportChallan_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Then
                GTYPENO.Visible = True
                GCHALLANNO.Visible = False
            End If
            If ClientName = "MOHAN" Then ALLOWMANUALTRANSNO = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSGDNDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TRANSGDNDATE.Validating
        Try
            If TRANSGDNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TRANSGDNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTRANSGDNNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTRANSGDNNO.KeyPress
        numkeypress(e, TXTTRANSGDNNO, Me)
    End Sub

    Private Sub TXTTRANSGDNNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTRANSGDNNO.Validating
        Try
            If Val(TXTTRANSGDNNO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(TRANS_NO,0)  AS TRANSNO", "", " TRANSPORTCHALLAN ", "  AND TRANS_NO=" & Val(TXTTRANSGDNNO.Text.Trim) & " AND TRANS_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Transport Challan No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class