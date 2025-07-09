
Imports BL

Public Class ManualMatching

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPMATCHNO As Integer

    Sub clear()

        'clearing textboxes
        EP.Clear()
        tstxtbillno.Clear()

        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        TXTMATCHNO.Clear()
        MATCHDATE.Value = Now.Date



        txtremarks.Clear()

        GRIDMATCH.RowCount = 0
        GRIDRECPAY.RowCount = 0

        TXTTOTALPAY.Clear()
        TXTTOTALBAL.Clear()
        GETMAXNO_MATCH()

    End Sub

    Sub GETMAXNO_MATCH()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MATCH_NO),0) + 1 ", " MANUALMATCHING ", " AND MATCH_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTMATCHNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, EDIT, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If Not datecheck(MATCHDATE.Value) Then
                EP.SetError(MATCHDATE, "Date Not in Current Accounting Year")
                BLN = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Name")
                BLN = False
            End If

            If GRIDRECPAY.RowCount = 0 Then
                EP.SetError(GRIDRECPAY, "Enter Match Details")
                BLN = False
            End If

            If GRIDMATCH.RowCount = 0 Then
                EP.SetError(GRIDMATCH, "Enter Match Details")
                BLN = False
            End If

            If Val(TXTTOTALBAL.Text.Trim) = 0 Then
                EP.SetError(TXTTOTALBAL, "Enter Match Details")
                BLN = False
            End If

            If Val(TXTTOTALPAY.Text.Trim) = 0 Then
                EP.SetError(TXTTOTALPAY, "Enter Match Details")
                BLN = False
            End If


            For Each ROW As DataGridViewRow In GRIDRECPAY.Rows
                If Convert.ToBoolean(ROW.Cells(DCHK.Index).Value) = True Then
                    'CHECK WETHER SELECTED AMOUNT IS < ADJUSTED AMOUNT OR NOT
                    If Val(TXTTOTALPAY.Text.Trim) > Val(ROW.Cells(DBALAMT.Index).Value) Then
                        EP.SetError(GRIDRECPAY, "Adjusted Amount Greater then Balance Amount")
                        BLN = False
                    End If
                    GoTo LINE1
                End If
            Next
            EP.SetError(GRIDRECPAY, "Select Rec/Pay Details")
            BLN = False
LINE1:

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Matching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F2 Then
            tstxtbillno.Focus()
        ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
            Call toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Dim OBJINVDTLS As New ManualMatchingDetails
            OBJINVDTLS.MdiParent = MDIMain
            OBJINVDTLS.Show()
        ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
            Call toolnext_Click(sender, e)
        End If
    End Sub

    Private Sub Matching_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            fillledger(CMBNAME, EDIT, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_YEARid = " & YearId)

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJMATCH As New ClsManualMatching()
                dt = OBJMATCH.SELECTBILL(TEMPMATCHNO, YearId)

                If dt.Rows.Count > 0 Then
                    TXTMATCHNO.Text = TEMPMATCHNO
                    MATCHDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("MATCHDATE"))
                    CMBNAME.Text = Convert.ToString(dt.Rows(0).Item("NAME"))
                    CMBNAME.Enabled = False
                    txtremarks.Text = Convert.ToString(dt.Rows(0).Item("remarks"))


                    GRIDRECPAY.Rows.Add(1, dt.Rows(0).Item("TYPE"), Val(dt.Rows(0).Item("BILLNO")), Val(dt.Rows(0).Item("REGID")), dt.Rows(0).Item("BILLINITIALS"), Format(Convert.ToDateTime(dt.Rows(0).Item("MATCHDATE")).Date, "dd/MM/yyyy"), Format(Val(dt.Rows(0).Item("BILLAMT")), 0.0), Format(Val(dt.Rows(0).Item("BALAMT")), 0.0))

                    For Each dr As DataRow In dt.Rows
                        GRIDMATCH.Rows.Add(1, dr("GRIDBILLTYPE"), dr("GRIDBILLNO"), dr("GRIDREGID"), dr("GRIDBILLINITIALS"), Format(Convert.ToDateTime(dr("BILLDATE")).Date, "dd/MM/yyyy"), dr("REFNO"), Format(dr("GRIDBILLAMT"), "0.00"), Format(dr("GRIDBALAMT"), "0.00"), Format(dr("PAIDAMT"), "0.00"))
                    Next
                    MATCHDATE.Focus()
                End If
                total()
            End If
            GRIDMATCH.ClearSelection()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETRECPAY()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" BILL_TYPE AS TYPE, BILL_NO AS BILLNO, BILL_REGISTERID AS REGID, BILL_INITIALS AS BILLINITIALS, BILL_DATE AS DATE, BILL_AMT AS BILLAMT, BILL_BALANCE AS BALAMT ", "", " OPENINGBILL INNER JOIN LEDGERS ON BILL_LEDGERID = ACC_ID ", " AND BILL_BALANCE > 0 AND BILL_TYPE IN('PAYMENT', 'RECEIPT','CREDIT', 'DEBIT') AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    GRIDRECPAY.Rows.Add(0, ROW("TYPE"), Val(ROW("BILLNO")), ROW("REGID"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yyyy"), Val(ROW("BILLAMT")), Val(ROW("BALAMT")))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                CMBNAME.Enabled = False
                GETRECPAY()
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then ledgervalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim DTTABLE As DataTable

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(MATCHDATE.Value)
            alparaval.Add(CMBNAME.Text.Trim)


            'SELECT REC OPAYMENT
            For Each ROW As DataGridViewRow In GRIDRECPAY.Rows
                If Convert.ToBoolean(ROW.Cells(DCHK.Index).Value) = True Then
                    alparaval.Add(ROW.Cells(DTYPE.Index).Value)
                    alparaval.Add(Val(ROW.Cells(DBILLNO.Index).Value))
                    alparaval.Add(Val(ROW.Cells(DREGID.Index).Value))
                    alparaval.Add(ROW.Cells(DBILLINITIALS.Index).Value)
                    alparaval.Add(Val(ROW.Cells(DBILLAMT.Index).Value))
                    alparaval.Add(Val(ROW.Cells(DBALAMT.Index).Value))
                    Exit For
                End If
            Next


            alparaval.Add(Val(TXTTOTALBAL.Text.Trim))
            alparaval.Add(Val(TXTTOTALPAY.Text.Trim))
            alparaval.Add(txtremarks.Text.Trim)

            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim TYPE As String = ""
            Dim BILLNO As String = ""
            Dim REGID As String = ""
            Dim BILLINITIALS As String = ""
            Dim BILLDATE As String = ""
            Dim REFNO As String = ""
            Dim BILLAMT As String = ""
            Dim BALAMT As String = ""
            Dim PAYAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDMATCH.Rows
                Dim I As Integer = 1
                If Convert.ToBoolean(row.Cells(GCHK.Index).Value) = True Then
                    If BILLINITIALS = "" Then
                        GRIDSRNO = I
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        BILLNO = Val(row.Cells(GBILLNO.Index).Value)
                        REGID = Val(row.Cells(GREGID.Index).Value)
                        BILLINITIALS = row.Cells(GBILLINITIALS.Index).Value.ToString
                        BILLDATE = Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        REFNO = row.Cells(GREFNO.Index).Value
                        BILLAMT = Val(row.Cells(GBILLAMT.Index).Value)
                        BALAMT = Val(row.Cells(GBALAMT.Index).Value)
                        PAYAMT = Val(row.Cells(GPAIDAMT.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & I
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        BILLNO = BILLNO & "|" & Val(row.Cells(GBILLNO.Index).Value)
                        REGID = REGID & "|" & Val(row.Cells(GBILLNO.Index).Value)
                        BILLINITIALS = BILLINITIALS & "|" & row.Cells(GBILLINITIALS.Index).Value.ToString
                        BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        REFNO = REFNO & "|" & row.Cells(GREFNO.Index).Value
                        BILLAMT = BILLAMT & "|" & row.Cells(GBILLAMT.Index).Value
                        BALAMT = BALAMT & "|" & row.Cells(GBALAMT.Index).Value.ToString
                        PAYAMT = PAYAMT & "|" & row.Cells(GPAIDAMT.Index).Value.ToString
                    End If
                    I += 1
                End If
            Next

            alparaval.Add(GRIDSRNO)
            alparaval.Add(TYPE)
            alparaval.Add(BILLNO)
            alparaval.Add(REGID)
            alparaval.Add(BILLINITIALS)
            alparaval.Add(BILLDATE)
            alparaval.Add(REFNO)
            alparaval.Add(BILLAMT)
            alparaval.Add(BALAMT)
            alparaval.Add(PAYAMT)


            Dim OBJMATCH As New ClsManualMatching
            OBJMATCH.alParaval = alparaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJMATCH.SAVE()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPMATCHNO)
                Dim IntResult As Integer = OBJMATCH.update()
                MsgBox("Details Updated")
            End If
            clear()
            EDIT = False
            MATCHDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        TXTTOTALBAL.Text = 0.0
        TXTTOTALPAY.Text = 0.0
       

        For Each row As DataGridViewRow In GRIDMATCH.Rows
            If Convert.ToBoolean(row.Cells(GCHK.Index).EditedFormattedValue) = True Then
                TXTTOTALBAL.Text = Format(Val(TXTTOTALBAL.Text) + row.Cells(GBALAMT.Index).EditedFormattedValue, "0.00")
                TXTTOTALPAY.Text = Format(Val(TXTTOTALPAY.Text) + row.Cells(GPAIDAMT.Index).EditedFormattedValue, "0.00")
            End If
        Next

    End Sub

    Sub fillgrid()
        Try
            Dim OBJPAY As New ClsManualMatching
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable = OBJPAY.GETBILLS(CMBNAME.Text.Trim, YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDMATCH.Rows.Add(0, DTROW("BILLTYPE"), DTROW("BILLNO"), Val(DTROW("REGID")), DTROW("BILLINITIALS"), Format(Convert.ToDateTime(DTROW("BILLDATE")).Date, "dd/MM/yyyy"), DTROW("REFNO"), Val(DTROW("BILLAMT")), Val(DTROW("BALAMT")), 0)
                Next
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDMATCH.RowCount = 0
LINE1:
            TEMPMATCHNO = Val(TXTMATCHNO.Text) + 1
            GETMAXNO_MATCH()
            Dim MAXNO As Integer = TXTMATCHNO.Text.Trim
            clear()
            If Val(TXTMATCHNO.Text) - 1 >= TEMPMATCHNO Then
                EDIT = True
                Matching_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDMATCH.RowCount = 0 And TEMPMATCHNO < MAXNO Then
                TXTMATCHNO.Text = TEMPMATCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDMATCH.RowCount = 0
LINE1:
            TEMPMATCHNO = Val(TXTMATCHNO.Text) - 1
            If TEMPMATCHNO > 0 Then
                EDIT = True
                Matching_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDMATCH.RowCount = 0 And TEMPMATCHNO > 1 Then
                TXTMATCHNO.Text = TEMPMATCHNO
                GoTo LINE1
            End If
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
            Dim OBJMATCHDTLS As New ManualMatchingDetails
            OBJMATCHDTLS.MdiParent = MDIMain
            OBJMATCHDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        MATCHDATE.Focus()
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Matching Entry Permanently?", MsgBoxStyle.YesNo, "PROTRADE")
                If tempmsg = vbYes Then

                    Dim OBJREC As New ClsManualMatching
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPMATCHNO)
                    ALPARAVAL.Add(YearId)



                    OBJREC.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJREC.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    EDIT = False
                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMATCH_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDMATCH.CellValidating
        Try
            Dim colNum As Integer = GRIDMATCH.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPAIDAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDMATCH.CurrentCell.Value = Nothing Then GRIDMATCH.CurrentCell.Value = "0.00"
                        GRIDMATCH.CurrentCell.Value = Convert.ToDecimal(GRIDMATCH.Item(colNum, e.RowIndex).Value)
                        '' everything is good

                        'CHECK WHETHER IT IS GREATER THAN BAL AMT OR NOT.
                        If Val(GRIDMATCH.CurrentCell.EditedFormattedValue) > Val(GRIDMATCH.CurrentRow.Cells(GBALAMT.Index).Value) Then
                            MessageBox.Show("Amount greater than Balance Amt")
                            e.Cancel = True
                            Exit Sub
                        End If

                        total()

                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case GCHK.Index
                    total()

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECPAY_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDRECPAY.CellValidating
        Try
            'WH NEED TO CHECK WHETHER ANY OTHER RWO IS CHECKED OR NOT
            'IF CHECKED THEN DONT ALLOW TO CHECK
            Dim TEMPROWNO As Integer = 0
            For Each ROW As DataGridViewRow In GRIDRECPAY.Rows
                If Convert.ToBoolean(ROW.Cells(DCHK.Index).EditedFormattedValue) = True And TEMPROWNO = 0 Then TEMPROWNO = Val(ROW.Cells(DBILLNO.Index).Value)
                If Convert.ToBoolean(ROW.Cells(DCHK.Index).EditedFormattedValue) = True And TEMPROWNO <> Val(ROW.Cells(DBILLNO.Index).Value) Then
                    MsgBox("Select Only Single Entry", MsgBoxStyle.Critical)
                    e.Cancel = True
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMATCH_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDMATCH.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex = GCHK.Index Then
                With GRIDMATCH.Rows(e.RowIndex).Cells(GCHK.Index)
                    If Convert.ToBoolean(.Value) = False Then
                        .Value = True
                        GRIDMATCH.CurrentRow.Cells(GPAIDAMT.Index).Value = GRIDMATCH.CurrentRow.Cells(GBALAMT.Index).Value
                        total()
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class