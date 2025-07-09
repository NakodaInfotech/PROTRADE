
Imports BL

Public Class journal

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Dim temprefno As String
    Dim jvregabbr, jvreginitial As String
    Dim jvregid As Integer
    Dim TEMPROW As Integer
    Dim tempamt, temptds As Double
    Dim temprecodate As Date    'for recodate
    Public TEMPJVNO As Integer
    Public TEMPREGNAME As String
    Public Shared SELECTEDBILLNO As String
    Dim ALLOWMANUALJVNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        JOURNALDATE.Text = Now.Date
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        tstxtbillno.Clear()

        If ALLOWMANUALJVNO = True Then
            txtjournalno.ReadOnly = False
            txtjournalno.BackColor = Color.LemonChiffon
        Else
            txtjournalno.ReadOnly = True
            txtjournalno.BackColor = Color.Linen
        End If

        EP.Clear()
        cmbname.Text = ""
        txtremarks.Clear()
        jvregabbr = ""
        jvreginitial = ""
        GRIDDOUBLECLICK = False
        cmbtype.Text = ""
        cmbpaytype.Text = ""
        txtrefno.Clear()
        txtdebit.Clear()
        txtcredit.Clear()
        gridjournal.RowCount = 0
        txtremarks.Clear()
        TXTINVAMT.Clear()
        TXTPARTYBILLNO.Clear()

        cmbpaytype.SelectedIndex = 0

        TXTTOTALDR.Text = 0.0
        TXTTOTALCR.Text = 0.0

        lbllocked.Visible = False
        PBlock.Visible = False

        edit = False
        getmaxno_journalmaster()

    End Sub

    Sub getmaxno_journalmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JOURNAL_NO),0) + 1 ", "JOURNALMASTER", " AND JOURNAL_cmpid=" & CmpId & " AND JOURNAL_LOCATIONID = " & Locationid & " AND JOURNAL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtjournalno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_journalmaster()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated

        If cmbtype.SelectedIndex = 0 Then
            txtcredit.ReadOnly = False
            txtdebit.ReadOnly = True
        Else
            txtcredit.ReadOnly = True
            txtdebit.ReadOnly = False
        End If
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try

            EP.Clear()
            If cmbtype.Text.Trim <> "" And txtrefno.Text.Trim <> "" And cmbpaytype.Text.Trim = "Against Bill" And GRIDDOUBLECLICK = False And EDIT = False Then
                'CHANGED BY GULKIT, COZ IF WE WANT TO ENTER ANY OTHER NO THEN IT VALIDATES US
                ' GETTING BILL DETAILS DIRECTLY FROM REFNO
                '******* OG CODE **************
                'If Not GETBILL(txtrefno.Text.Trim) Then
                '    e.Cancel = True
                '    Exit Sub
                'End If
                '************* END OF OG CODE *************************
                GETBILL(txtrefno.Text.Trim)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In gridjournal.Rows
                If row.Cells(GTYPE.Index).Value <> "" Then row.Cells(8).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno()


            'GET BILLREMARKS
            TXTBILLREMARKS.Clear()
            For Each ROW As DataGridViewRow In gridjournal.Rows
                If ROW.Cells(GPAYTYPE.Index).Value = "Against Bill" Then
                    If TXTBILLREMARKS.Text = "" Then
                        TXTBILLREMARKS.Text = "Against Bill - " & ROW.Cells(GREFNO.Index).Value
                    Else
                        TXTBILLREMARKS.Text = TXTBILLREMARKS.Text & ", " & ROW.Cells(GREFNO.Index).Value
                    End If
                End If
            Next


            Dim alParaval As New ArrayList

            If txtjournalno.ReadOnly = False Then
                alParaval.Add(Val(txtjournalno.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(JOURNALDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBILLREMARKS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim type As String = ""
            Dim name As String = ""
            Dim paytype As String = ""
            Dim refno As String = ""
            Dim debit As String = ""
            Dim credit As String = ""
            Dim gridsrno As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridjournal.Rows
                If row.Cells(1).Value <> Nothing Then
                    If type = "" Then
                        type = row.Cells(0).Value.ToString
                        name = row.Cells(1).Value
                        paytype = row.Cells(2).Value.ToString
                        refno = row.Cells(3).Value
                        debit = Val(row.Cells(4).Value)
                        credit = Val(row.Cells(5).Value)
                        gridsrno = Val(row.Cells(8).Value)
                    Else
                        type = type & "|" & row.Cells(0).Value.ToString
                        name = name & "|" & row.Cells(1).Value
                        paytype = paytype & "|" & row.Cells(2).Value.ToString
                        refno = refno & "|" & row.Cells(3).Value
                        debit = debit & "|" & Val(row.Cells(4).Value)
                        credit = credit & "|" & Val(row.Cells(5).Value)
                        gridsrno = gridsrno & "|" & Val(row.Cells(8).Value)
                    End If
                End If
            Next

            alParaval.Add(type)
            alParaval.Add(name)
            alParaval.Add(paytype)
            alParaval.Add(refno)
            alParaval.Add(debit)
            alParaval.Add(credit)
            alParaval.Add(gridsrno)

            Dim objclsjvmaster As New ClsJournalMaster()
            objclsjvmaster.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = objclsjvmaster.save()
                MessageBox.Show("Details Added")

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = DT.Rows(0).Item(0)
                    OBJTDS.REGISTER = cmbregister.Text.Trim
                    OBJTDS.ShowDialog()
                End If

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempjvno)
                alParaval.Add(tempamt)
                alParaval.Add(temptds)
                DT = objclsjvmaster.update()
                MsgBox("Details Updated")
            End If

            'ACCOUNTS ENTRY TO BE DONE HERE COZ LOOP IS NOT POSSIBLE IN SP
            txtjournalno.Text = DT.Rows(0).Item(0)
            ACCOUNTSENTRY(DT.Rows(0).Item(0))
            clear()
            EDIT = False
            cmbtype.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY(ByVal JVNO As Integer)
        Try
            Dim OBJJV As New ClsJournalMaster
            Dim INTRESULT As Integer

            If edit = True Then
                Dim ALP As New ArrayList
                ALP.Add(TEMPREGNAME)
                ALP.Add(JVNO)
                ALP.Add(CmpId)
                ALP.Add(Locationid)
                ALP.Add(YearId)
                OBJJV.alP = ALP
                INTRESULT = OBJJV.ACCDELETE()
            End If

            Dim tempcredit, creditbal, tempdebit, debitbal As Double
            Dim tempr As Integer    'for row no of grid
            Dim I, J As Integer     'FOR LOOP

            tempcredit = 0
            creditbal = 0
            tempdebit = 0
            debitbal = 0
            tempr = 0

            For I = 0 To gridjournal.RowCount - 1
                If gridjournal.Item(0, I).Value.ToString = "Cr" Then
                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempcredit = Val(gridjournal.Item(5, I).Value.ToString)
                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (creditbal > 0)
                            If J < gridjournal.RowCount Then

                                Dim ALPARAVAL As New ArrayList

                                ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME FROMID

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Dr" Then

                                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If

                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(Format(Convert.ToDateTime(JOURNALDATE.Text).Date, "MM/dd/yyyy"))                        'JOURNAL DATE
                                        ALPARAVAL.Add(txtremarks.Text.Trim)                    'REMARKS
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()

                                    End If
                                End If

                                J = J + 1
                            Else
                                creditbal = 0
                            End If
                        End While


                    End If

                ElseIf gridjournal.Item(0, I).Value.ToString = "Dr" Then

                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempdebit = Val(gridjournal.Item(4, I).Value.ToString)
                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (debitbal > 0)
                            If J < gridjournal.RowCount Then
                                Dim ALPARAVAL As New ArrayList

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Cr" Then

                                        'getting ledgerid
                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString) 'ADDING NAME FROMID

                                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, I).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, J).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If


                                        ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(Format(Convert.ToDateTime(JOURNALDATE.Text).Date, "MM/dd/yyyy"))                        'JOURNAL DATE
                                        ALPARAVAL.Add(txtremarks.Text.Trim)                    'REMARKS
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()


                                    End If
                                End If

                                J = J + 1
                            Else
                                debitbal = 0
                            End If
                        End While


                    End If

                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Journal Locked")
                bln = False
            End If
        End If





        If ALLOWMANUALJVNO = True Then
            If txtjournalno.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon

                Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOURNALMASTER.journal_no,0) AS JOURNALNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN JOURNALMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.journal_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.journal_cmpid AND REGISTERMASTER.register_yearid = JOURNALMASTER.journal_yearid AND REGISTERMASTER.register_locationid = JOURNALMASTER.journal_locationid ", "  AND JOURNALMASTER.journal_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND JOURNALMASTER.journal_cmpid = " & CmpId & " AND JOURNALMASTER.journal_locationid = " & Locationid & " AND JOURNALMASTER.journal_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    EP.SetError(txtjournalno, "Journal No Already Exist")
                    bln = False
                End If
            End If
        End If



        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        If gridjournal.RowCount = 0 Then
            EP.SetError(txtcredit, "Enter Transactions")
            bln = False
        End If

        'cheking whether cr and dr is equal or not
        Dim tempdebit, tempcredit As Double
        For Each row As DataGridViewRow In gridjournal.Rows
            If row.Cells(2).Value = "" Then
                EP.SetError(txtcredit, "Fill PayType")
                bln = False
            End If

            If (row.Cells(GPAYTYPE.Index).Value = "Against Bill" Or row.Cells(GPAYTYPE.Index).Value = "New Ref.") And row.Cells(GREFNO.Index).Value = "" Then
                EP.SetError(cmbregister, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                bln = False
            End If

            tempdebit = Format(Val(tempdebit) + Val(row.Cells(4).Value), "0.00")
            tempcredit = Format(Val(tempcredit) + Val(row.Cells(5).Value), "0.00")

            If Val(row.Cells(GAMTPAIDREC.Index).Value) > 0 Then
                EP.SetError(cmbregister, "Journal Locked, Rec/Pay/JV Raised")
                bln = False
            End If
        Next
        If Val(tempdebit) <> Val(tempcredit) Then
            EP.SetError(txtcredit, "Total Does Not Match")
            bln = False
        End If


        If JOURNALDATE.Text = "__/__/____" Then
            EP.SetError(JOURNALDATE, "Enter Proper Date")
            bln = False
        ElseIf Not datecheck(JOURNALDATE.Text) Then
            EP.SetError(JOURNALDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub Journal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Control = True And e.Shift = True And e.KeyCode = Windows.Forms.Keys.R Then       'for Copy Old Narration
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(JOURNAL_REMARKS,'') AS REMARKS", "", " JOURNALMASTER INNER JOIN REGISTERMASTER  ON REGISTER_ID = JOURNAL_REGISTERID AND REGISTER_CMPID = JOURNAL_CMPID AND REGISTER_LOCATIONID = JOURNAL_LOCATIONID AND REGISTER_YEARID = JOURNAL_YEARID", "  AND JOURNAL_CMPID = " & CmpId & " AND JOURNAL_LOCATIONID = " & Locationid & " AND JOURNAL_YEARID = " & YearId & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND JOURNAL_NO = (SELECT MAX(JOURNAL_NO) FROM JOURNALMASTER INNER JOIN REGISTERMASTER  ON REGISTER_ID = JOURNAL_REGISTERID AND REGISTER_CMPID = JOURNAL_CMPID AND REGISTER_LOCATIONID = JOURNAL_LOCATIONID AND REGISTER_YEARID = JOURNAL_YEARID WHERE JOURNAL_CMPID = " & CmpId & " AND JOURNAL_LOCATIONID = " & Locationid & " AND JOURNAL_YEARID = " & YearId & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "')")
                If DT.Rows.Count > 0 Then txtremarks.Text = DT.Rows(0).Item("REMARKS")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Journal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    jvregabbr = dt.Rows(0).Item(0).ToString
                    jvreginitial = dt.Rows(0).Item(1).ToString
                    jvregid = dt.Rows(0).Item(2)
                    getmaxno_journalmaster()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtjournalno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjournalno.KeyPress
        'enterkeypress(e, Me)
        numkeypress(e, txtjournalno, Me)

    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True

            If edit = False Then
                If GRIDDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If (cmbtype.Text = "Dr" And Val(txtdebit.Text) > Val(TXTBILLAMT.Text)) Or (cmbtype.Text = "Cr" And Val(txtcredit.Text) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If ((cmbtype.Text = "Dr" And (Val(txtdebit.Text) - Val(gridjournal.Item(GDEBIT.Index, TEMPROW).Value))) > Val(TXTBILLAMT.Text)) Or ((cmbtype.Text = "Cr" And (Val(txtcredit.Text) - Val(gridjournal.Item(GCREDIT.Index, TEMPROW).Value))) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                End If
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtcredit_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcredit.Validating
        Try
            If (Val(txtcredit.Text) <> 0 Or Val(txtdebit.Text) <> 0) And cmbname.Text.Trim <> "" And cmbtype.Text.Trim <> "" Then
                If cmbpaytype.Text.Trim = "Against Bill" And txtrefno.Text.Trim = "" Then
                    MsgBox("Please Enter Ref No, Or Do not select Against Bill", MsgBoxStyle.Critical)
                    cmbpaytype.Focus()
                    Exit Sub
                End If

                If cmbpaytype.Text.Trim = "Against Bill" And ClientName <> "ALENCOT" Then
                    'NO NEED FOR THIS
                    'EP.Clear()
                    'If Not AMOUNTVALIDATE() Then
                    '    Exit Sub
                    'End If
                    If TXTPARTYBILLNO.Text.Trim <> "" Then txtremarks.Text = "Against Bill No " & TXTPARTYBILLNO.Text.Trim & " Bill Dt. " & Format(PARTYBILLDATE.Value.Date, "dd/MM/yyy") Else txtremarks.Text = "Against Bill No " & txtrefno.Text.Trim & " Bill Dt. " & Format(PARTYBILLDATE.Value.Date, "dd/MM/yyy")
                End If

                If cmbtype.Text = "Dr" Then
                    txtcredit.Clear()
                Else
                    txtdebit.Clear()
                End If

                fillgrid()
                txtdebit.Clear()
                txtcredit.Clear()
                txtrefno.Clear()
                cmbpaytype.SelectedIndex = 0
                cmbname.Text = ""
                cmbtype.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkledger() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In gridjournal.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If cmbname.Text.Trim = row.Cells(1).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        'GETTING CURRENT BALANCE FROM TRIAL BALANCE
        Dim OBJCOMMON As New ClsCommon
        Dim DT As New DataTable
        Dim BAL As String = String.Empty
        Dim DRCR As String = String.Empty
        DT = OBJCOMMON.search(" (CASE WHEN DR-CR>0 THEN DR-CR ELSE CR-DR END), (CASE WHEN DR-CR>0 THEN 'Dr' ELSE 'Cr' END)", "", " TRIALBALANCE", " AND NAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            BAL = DT.Rows(0).Item(0)
            DRCR = DT.Rows(0).Item(1)
        End If

        If GRIDDOUBLECLICK = False Then

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) & "Cr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL, 0, 0)
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) & "Dr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL, 0, 0)
            End If

        ElseIf GRIDDOUBLECLICK = True Then

            gridjournal.Item(0, TEMPROW).Value = cmbtype.Text
            gridjournal.Item(1, TEMPROW).Value = cmbname.Text.Trim
            gridjournal.Item(2, TEMPROW).Value = cmbpaytype.Text
            gridjournal.Item(3, TEMPROW).Value = txtrefno.Text.Trim
            gridjournal.Item(4, TEMPROW).Value = Format(Val(txtdebit.Text), "0.00")
            gridjournal.Item(5, TEMPROW).Value = Format(Val(txtcredit.Text), "0.00")
            gridjournal.Item(6, TEMPROW).Value = ""
            GRIDDOUBLECLICK = False

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) * (-1) & "Cr"
                End If
                gridjournal.Item(7, TEMPROW).Value = BAL
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) * (-1) & "Dr"
                End If
                gridjournal.Item(7, TEMPROW).Value = BAL
            End If
        End If

        TOTAL()
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALCR.Text = 0.0
            TXTTOTALDR.Text = 0.0

            For Each ROW As DataGridViewRow In gridjournal.Rows
                If Val(ROW.Cells(GDEBIT.Index).Value) > 0 Or Val(ROW.Cells(GCREDIT.Index).Value) > 0 Then
                    TXTTOTALDR.Text = Format(Val(TXTTOTALDR.Text.Trim) + Val(ROW.Cells(GDEBIT.Index).Value), "0.00")
                    TXTTOTALCR.Text = Format(Val(TXTTOTALCR.Text.Trim) + Val(ROW.Cells(GCREDIT.Index).Value), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridjournal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjournal.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridjournal.Rows.RemoveAt(gridjournal.CurrentRow.Index)
            TOTAL()
        End If
    End Sub

    Private Sub gridjournal_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridjournal.CellDoubleClick
        If e.RowIndex >= 0 And gridjournal.Item(0, e.RowIndex).Value <> Nothing Then
            GRIDDOUBLECLICK = True
            TEMPROW = e.RowIndex
            cmbtype.Text = gridjournal.Item(0, e.RowIndex).Value
            cmbname.Text = gridjournal.Item(1, e.RowIndex).Value
            cmbpaytype.Text = gridjournal.Item(2, e.RowIndex).Value
            txtrefno.Text = gridjournal.Item(3, e.RowIndex).Value
            txtdebit.Text = gridjournal.Item(4, e.RowIndex).Value
            txtcredit.Text = gridjournal.Item(5, e.RowIndex).Value
            cmbtype.Focus()
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objjvdtls As New JournalDetails
            objjvdtls.MdiParent = MDIMain
            objjvdtls.Show()
            objjvdtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Journal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOURNAL VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            'getmaxno_journalmaster()
            fillregister(cmbregister, " and register_type = 'JOURNAL'")
            fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            cmbpaytype.SelectedIndex = 0
            cmbname.Text = ""
            JOURNALDATE.Text = Now.Date

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsJV As New ClsJournalMaster()
                dt = objclsJV.selectjournal_edit(tempjvno, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtjournalno.Text = tempjvno
                        txtjournalno.ReadOnly = True

                        cmbregister.Text = TEMPREGNAME
                        JOURNALDATE.Text = Format(Convert.ToDateTime(dr("JOURNAL_DATE")).Date, "dd/MM/yyyy")
                        tempamt = Convert.ToString(dr("JOURNAL_AMT"))
                        temptds = Convert.ToString(dr("JOURNAL_TDS"))
                        txtremarks.Text = Convert.ToString(dr("JOURNAL_remarks"))
                        gridjournal.Rows.Add(dr("JOURNAL_TYPE").ToString, dr("ACC_CMPNAME").ToString, dr("JOURNAL_PAYTYPE").ToString, dr("JOURNAL_REFNO").ToString, dr("JOURNAL_DEBIT").ToString, dr("JOURNAL_CREDIT").ToString, 0, 0, 0, Val(dr("JOURNAL_AMT")))
                        If IsDBNull(dr("JOURNAL_recodate")) = False Then temprecodate = Convert.ToDateTime(dr("JOURNAL_recodate"))
                        If Val(dr("JOURNAL_AMT")) > 0 Then
                            gridjournal.Rows(gridjournal.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    TOTAL()
                    cmbregister.Enabled = False
                    cmbtype.Focus()
                    chkchange.CheckState = CheckState.Checked

                Else
                    edit = False
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_SECONDARY NOT IN ('CASH IN HAND','BANK A/C','BANK OD A/C') and acc_cmpid = " & CmpId)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand' and LEDGERS.ACC_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, TXTADD, " AND  GROUPMASTER.GROUP_SECONDARY NOT IN ('CASH IN HAND','BANK A/C','BANK OD A/C')")
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_journalmaster()
            Dim MAXNO As Integer = txtjournalno.Text.Trim
            clear()
            If Val(txtjournalno.Text) - 1 >= tempjvno Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno < MAXNO Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno > 1 Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                For Each ROW As DataGridViewRow In gridjournal.Rows
                    If Val(ROW.Cells(GAMTPAIDREC.Index).Value) > 0 Then
                        MsgBox("Journal Locked, Rec/Pay/JV Raised")
                        Exit Sub
                    End If

                    'IF TDS CHALLAN IS GENERATED THEN LOCK THE ENTRY
                    If ROW.Cells(GREFNO.Index).Value <> "" Then
                        DT = OBJCMN.search("TDSCHA_BILLNO AS BILLNO", "", " TDSCHALLAN ", " AND TDSCHA_YEARID = " & YearId & " AND TDSCHA_BILLNO = '" & ROW.Cells(GREFNO.Index).Value & "'")
                        If DT.Rows.Count > 0 Then
                            MsgBox("TDS Challan Raised, Please Remove from TDS Challan", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End If


                    'IF TCS CHALLAN IS GENERATED THEN LOCK THE ENTRY
                    DT = OBJCMN.search("TCSCHA_BILLNO AS BILLNO", "", " TCSCHALLAN INNER JOIN REGISTERMASTER ON TCSCHA_REGISTERID = REGISTER_ID", " AND TCSCHA_YEARID = " & YearId & " AND TCSCHA_BILLNO = " & Val(txtjournalno.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "'")
                    If DT.Rows.Count > 0 Then
                        MsgBox("TCS Challan Raised, Please Remove Entry from TCS Challan First", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                Next

                Dim tempmsg As Integer = MsgBox("Delete Journal Entry Permanently?", MsgBoxStyle.YesNo, "TEXPRO")
                If tempmsg = vbYes Then

                    Dim OBJJV As New ClsJournalMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPJVNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJJV.alParaval = ALPARAVAL
                    DT = OBJJV.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridjournal.RowCount = 0
            tempjvno = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJJV As New Journal_Contra_Design
            OBJJV.FRMSTRING = "JOURNAL"
            OBJJV.MdiParent = MDIMain
            OBJJV.strsearch = "{JOURNALMASTER.JOURNAL_NO} = " & tempjvno & " And {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' AND {JOURNALMASTER.JOURNAL_YEARID} = " & YearId
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If cmbname.Text.Trim <> "" Then

                SELECTEDBILLNO = ""
                txtrefno.Clear()
                TXTBILLAMT.Clear()

                Dim OBJSELECTBILL As New SelectBills
                OBJSELECTBILL.CMPNAME = cmbname.Text.Trim
                OBJSELECTBILL.ShowDialog()
                If OBJSELECTBILL.BILLNO <> "" Then SELECTEDBILLNO = OBJSELECTBILL.BILLNO

                If SELECTEDBILLNO.Trim <> "" Then
                    If Not GETBILL(SELECTEDBILLNO) Then
                        Exit Sub
                    End If
                    txtrefno.Focus()
                End If
            Else
                MsgBox("Select Name")
                cmbname.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Call ToolStripdelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDAUTOPOST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDAUTOPOST.Click
        Try
            'GET INVOICENOS FROM PURCHASEMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("MAX(JOURNAL_NO) AS BILLNO", "", " JOURNALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = JOURNAL_REGISTERID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND JOURNAL_YEARID = " & YearId)
            For I As Integer = 1 To Val(DT.Rows(0).Item("BILLNO"))
                gridjournal.RowCount = 0
                tempjvno = Val(I)
                TEMPREGNAME = cmbregister.Text.Trim
                EDIT = True
                Journal_Load(sender, e)
                If gridjournal.RowCount = 0 Then GoTo NEXTLINE
                cmdok_Click(sender, e)
NEXTLINE:
                clear()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function GETBILL(ByVal BILLNO As String) As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" * ", "", " (SELECT OPENINGBILL.BILL_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, OPENINGBILL.BILL_AMT AS BILLAMT, OPENINGBILL.BILL_BALANCE AS BALAMT, 'OPENING' AS TYPE, OPENINGBILL.BILL_INITIALS AS REFNO, OPENINGBILL.BILL_DATE AS PARTYBILLDATE, OPENINGBILL.BILL_NO AS BILLNO, OPENINGBILL.BILL_CMPID AS CMPID, OPENINGBILL.BILL_LOCATIONID AS LOCATIONID, OPENINGBILL.BILL_YEARID AS YEARID FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL.BILL_LOCATIONID = LEDGERS.Acc_locationid And OPENINGBILL.BILL_YEARID = LEDGERS.Acc_yearid WHERE(OPENINGBILL.BILL_BALANCE > 0) UNION ALL  SELECT INVOICEMASTER.INVOICE_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.INVOICE_GRANDTOTAL AS BILLAMT, INVOICEMASTER.INVOICE_BALANCE AS BALAMT, 'INVOICE' AS TYPE, INVOICEMASTER.INVOICE_REFNO AS REFNO, INVOICEMASTER.INVOICE_DATE AS PARTYBILLDATE, INVOICEMASTER.INVOICE_NO AS BILLNO, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_LOCATIONID AS LOCATIONID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id AND INVOICEMASTER.INVOICE_CMPID = LEDGERS.Acc_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = LEDGERS.Acc_locationid And INVOICEMASTER.INVOICE_YEARID = LEDGERS.Acc_yearid WHERE INVOICEMASTER.INVOICE_BALANCE > 0 UNION ALL SELECT PURCHASEMASTER.BILL_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS BILLAMT, PURCHASEMASTER.BILL_BALANCE AS BALAMT, 'PURCHASE' AS TYPE, PURCHASEMASTER.BILL_PARTYBILLNO AS REFNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS PARTYBILLDATE, PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_LOCATIONID AS LOCATIONID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_CMPID = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = LEDGERS.Acc_locationid And PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid WHERE PURCHASEMASTER.BILL_BALANCE > 0 UNION ALL SELECT NONPURCHASE.NP_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, NONPURCHASE.NP_GRANDTOTAL AS BILLAMT, NONPURCHASE.NP_BALANCE AS BALAMT, 'NONPURCHASE' AS TYPE, NONPURCHASE.NP_REFNO AS REFNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, NONPURCHASE.NP_NO AS BILLNO,  NONPURCHASE.NP_CMPID AS CMPID, NONPURCHASE.NP_LOCATIONID AS LOCATIONID, NONPURCHASE.NP_YEARID AS YEARID FROM NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id AND NONPURCHASE.NP_CMPID = LEDGERS.Acc_cmpid AND NONPURCHASE.NP_LOCATIONID = LEDGERS.Acc_locationid And NONPURCHASE.NP_YEARID = LEDGERS.Acc_yearid WHERE NONPURCHASE.NP_BALANCE > 0 UNION ALL SELECT DEBITNOTEMASTER.DN_initials AS SRNO, LEDGERS.Acc_cmpname AS NAME, DEBITNOTEMASTER.DN_GTOTAL AS BILLAMT, DEBITNOTEMASTER.DN_BALANCE AS BALAMT, 'DEBITNOTE' AS TYPE, DEBITNOTEMASTER.DN_initials AS REFNO,  DEBITNOTEMASTER.DN_date AS DATE, DEBITNOTEMASTER.DN_NO AS BILLNO, DEBITNOTEMASTER.DN_CMPID AS CMPID, DEBITNOTEMASTER.DN_LOCATIONID AS LOCATIONID, DEBITNOTEMASTER.DN_YEARID AS YEARID FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id WHERE DEBITNOTEMASTER.DN_BALANCE > 0 AND DN_date >= '07/01/2017' UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS SRNO, LEDGERS.Acc_cmpname AS NAME, CREDITNOTEMASTER.CN_GTOTAL AS BILLAMT, CREDITNOTEMASTER.CN_BALANCE AS BALAMT, 'CREDITNOTE' AS TYPE, CREDITNOTEMASTER.CN_initials AS REFNO,  CREDITNOTEMASTER.CN_date AS DATE, CREDITNOTEMASTER.CN_NO AS BILLNO, CREDITNOTEMASTER.CN_CMPID AS CMPID, CREDITNOTEMASTER.CN_LOCATIONID AS LOCATIONID, CREDITNOTEMASTER.CN_YEARID AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id WHERE CREDITNOTEMASTER.CN_BALANCE > 0 AND CN_date >= '07/01/2017' UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, JOURNALMASTER.JOURNAL_CREDIT AS BILLAMT, (JOURNALMASTER.journal_credit-journal_amt) AS BALAMT, 'JOURNAL' AS TYPE, JOURNALMASTER.journal_refno AS REFNO, JOURNALMASTER.JOURNAL_DATE AS DATE,  JOURNALMASTER.JOURNAL_NO AS BILLNO, JOURNALMASTER.JOURNAL_CMPID AS CMPID, JOURNALMASTER.JOURNAL_LOCATIONID AS LOCATIONID, JOURNALMASTER.JOURNAL_YEARID AS YEARID FROM JOURNALMASTER INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_LEDGERID = LEDGERS.Acc_id  WHERE(JOURNALMASTER.journal_credit - journal_amt) > 0 AND journal_credit > 0 AND journal_paytype = 'New Ref.' UNION ALL SELECT JOURNALMASTER.JOURNAL_INITIALS AS SRNO, LEDGERS.Acc_cmpname AS NAME, JOURNALMASTER.JOURNAL_DEBIT AS BILLAMT, (JOURNALMASTER.journal_DEBIT-journal_amt) AS BALAMT, 'JOURNAL' AS TYPE, JOURNALMASTER.journal_refno AS REFNO, JOURNALMASTER.JOURNAL_DATE AS DATE, JOURNALMASTER.JOURNAL_NO AS BILLNO, JOURNALMASTER.JOURNAL_CMPID AS CMPID, JOURNALMASTER.JOURNAL_LOCATIONID AS LOCATIONID, JOURNALMASTER.JOURNAL_YEARID AS YEARID FROM JOURNALMASTER INNER JOIN LEDGERS ON JOURNALMASTER.JOURNAL_LEDGERID = LEDGERS.Acc_id  WHERE(JOURNALMASTER.journal_debit - journal_amt) > 0 AND journal_debit > 0 AND journal_paytype = 'New Ref.') AS T ", " AND T.SRNO = '" & BILLNO & "'  AND T.BALAMT > 0 AND T.YEARID =" & YearId & " ORDER BY T.TYPE, T.BILLNO ")
            If dt.Rows.Count > 0 Then
                txtrefno.Text = BILLNO
                cmbpaytype.Text = "Against Bill"
                If dt.Rows(0).Item("TYPE") <> "JOURNAL" Then
                    cmbname.Text = dt.Rows(0).Item("NAME")
                    TXTBILLAMT.Text = Val(dt.Rows(0).Item("BALAMT"))
                    TXTPARTYBILLNO.Text = dt.Rows(0).Item("REFNO")
                    PARTYBILLDATE.Value = Format(dt.Rows(0).Item("PARTYBILLDATE"), "dd/MM/yyyy")
                    TXTINVAMT.Text = Val(dt.Rows(0).Item("BILLAMT"))
                    LBLREFNO.Visible = True
                    TXTPARTYBILLNO.Visible = True
                    LBLBILLAMT.Visible = True
                    TXTINVAMT.Visible = True
                    If cmbtype.Text = "Dr" Then
                        txtdebit.Text = Val(dt.Rows(0).Item("BALAMT"))
                    Else
                        txtcredit.Text = Val(dt.Rows(0).Item("BALAMT"))
                    End If
                End If
            Else
                EP.SetError(txtcredit, "Invalid Bill No")
                BLN = False
                LBLREFNO.Visible = False
                TXTPARTYBILLNO.Visible = False
                LBLBILLAMT.Visible = False
                TXTINVAMT.Visible = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(tempjvno)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(JVNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJDN As New Journal_Contra_Design
            OBJDN.MdiParent = MDIMain
            OBJDN.DIRECTPRINT = True
            OBJDN.FRMSTRING = "JOURNAL"
            OBJDN.DIRECTMAIL = False
            OBJDN.DIRECTWHATSAPP = True
            OBJDN.REGNAME = cmbregister.Text.Trim
            OBJDN.PRINTSETTING = PRINTDIALOG
            OBJDN.BILLNO = Val(JVNO)
            OBJDN.strsearch = "{JOURNALMASTER.JOURNAL_NO} = " & JVNO & " And {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' AND {JOURNALMASTER.JOURNAL_YEARID} = " & YearId
            OBJDN.NOOFCOPIES = 1
            OBJDN.Show()
            OBJDN.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\JV_" & Val(JVNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("JV_" & Val(JVNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNALDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JOURNALDATE.Validating
        Try
            If JOURNALDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(JOURNALDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub journal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MAHAVIR" Or ClientName = "PURVITEX" Then ALLOWMANUALJVNO = True

    End Sub

    Private Sub txtjournalno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtjournalno.Validating
        Try
            If (Val(txtjournalno.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And tempjvno <> Val(txtjournalno.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  As PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER On REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid And REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid And REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid And REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  And PAYMENTMASTER.PAYMENT_no=" & txtjournalno.Text.Trim & " And REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOURNALMASTER.journal_no,0) AS JOURNALNO", "", " REGISTERMASTER INNER JOIN JOURNALMASTER ON REGISTERMASTER.register_id = JOURNALMASTER.journal_registerid AND REGISTERMASTER.register_cmpid = JOURNALMASTER.journal_cmpid AND REGISTERMASTER.register_yearid = JOURNALMASTER.journal_yearid AND REGISTERMASTER.register_locationid = JOURNALMASTER.journal_locationid ", "  AND JOURNALMASTER.journal_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND JOURNALMASTER.journal_cmpid = " & CmpId & " AND JOURNALMASTER.journal_locationid = " & Locationid & " AND JOURNALMASTER.journal_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    MsgBox("Journal No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNALDATE_GotFocus(sender As Object, e As EventArgs) Handles JOURNALDATE.GotFocus
        Try
            JOURNALDATE.SelectAll()
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
End Class