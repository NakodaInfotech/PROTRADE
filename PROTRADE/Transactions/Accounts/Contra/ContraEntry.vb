
Imports BL
Imports System.Windows.Forms

Public Class ContraEntry

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Dim contraregabbr, contrareginitial As String
    Dim jvregid As Integer
    Dim TEMPROW As Integer
    Dim tempamt, temptds As Double
    Dim temprecodate As Date    'for recodate
    Public tempcontrano As Integer
    Public TEMPREGNAME As String
    Dim ALLOWMANUALCONTRANO As Boolean = False


    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        contradate.Value = Now.Date
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        tstxtbillno.Clear()

        If ALLOWMANUALCONTRANO = True Then
            txtjournalno.ReadOnly = False
            txtjournalno.BackColor = Color.LemonChiffon
        Else
            txtjournalno.ReadOnly = True
            txtjournalno.BackColor = Color.Linen
        End If

        cmbname.Text = ""
        TXTCHQNO.Clear()
        txtremarks.Clear()
        contraregabbr = ""
        contrareginitial = ""
        GRIDDOUBLECLICK = False
        cmbtype.Text = ""
        cmbpaytype.Text = ""
        txtrefno.Clear()
        txtrefno.ReadOnly = False
        txtdebit.Clear()
        txtcredit.Clear()
        gridcontra.RowCount = 0
        txtremarks.Clear()
        edit = False
        getmaxno_contramaster()

        CHKRECO.CheckState = CheckState.Unchecked
        RECODATE.Value = Now.Date

        lbllocked.Visible = False
        PBlock.Visible = False

        LBLRECO.Visible = False
        RECODATE.Visible = False
        CMDRECO.Visible = False

    End Sub

    Sub getmaxno_contramaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CONTRA_NO),0) + 1 ", "CONTRA", " AND CONTRA_cmpid=" & CmpId & " AND CONTRA_LOCATIONid=" & Locationid & " AND CONTRA_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtjournalno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub journaldate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles contradate.Validating
        If Not datecheck(contradate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CONTRA'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_contramaster()
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

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In gridcontra.Rows
                If row.Cells(0).Value <> "" Then row.Cells(8).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
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

            Dim alParaval As New ArrayList

            If txtjournalno.ReadOnly = False Then
                alParaval.Add(Val(txtjournalno.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(contradate.Value)
            alParaval.Add(TXTCHQNO.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
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
            Dim RECODT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridcontra.Rows
                If row.Cells(1).Value <> Nothing Then
                    If type = "" Then
                        type = row.Cells(0).Value.ToString
                        name = row.Cells(1).Value
                        paytype = row.Cells(2).Value.ToString
                        refno = row.Cells(3).Value
                        debit = row.Cells(4).Value
                        credit = row.Cells(5).Value
                        gridsrno = row.Cells(8).Value
                        If row.Cells(9).Value <> Nothing Then RECODT = Format(Convert.ToDateTime(row.Cells(9).Value).Date, "MM/dd/yyyy")
                    Else
                        type = type & "," & row.Cells(0).Value.ToString
                        name = name & "," & row.Cells(1).Value
                        paytype = paytype & "," & row.Cells(2).Value.ToString
                        refno = refno & "," & row.Cells(3).Value
                        debit = debit & "," & row.Cells(4).Value
                        credit = credit & "," & row.Cells(5).Value
                        gridsrno = gridsrno & "," & row.Cells(8).Value
                        If row.Cells(9).Value <> Nothing Then RECODT = RECODT & "," & Format(Convert.ToDateTime(row.Cells(9).Value).Date, "MM/dd/yyyy")

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

            If RECODT = Nothing Then RECODT = ""

            Dim OBJCLSCONTRA As New ClsContra()
            OBJCLSCONTRA.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJCLSCONTRA.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempcontrano)
                alParaval.Add(tempamt)
                alParaval.Add(temptds)
                alParaval.Add(RECODT)
                DT = OBJCLSCONTRA.update()
                MsgBox("Details Updated")
            End If

            'ACCOUNTS ENTRY TO BE DONE HERE COZ LOOP IS NOT POSSIBLE IN SP
            txtjournalno.Text = DT.Rows(0).Item(0)
            ACCOUNTSENTRY()
            clear()
            edit = False
            cmbtype.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY()
        Try
            Dim OBJJV As New ClsContra
            Dim INTRESULT As Integer

            If edit = True Then
                Dim ALP As New ArrayList
                ALP.Add(cmbregister.Text.Trim)
                ALP.Add(CmpId)
                ALP.Add(txtjournalno.Text)
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

            For I = 0 To gridcontra.RowCount - 1
                If gridcontra.Item(0, I).Value.ToString = "Cr" Then
                    If Val(gridcontra.Item(6, I).Value.ToString) = 0 Then

                        tempcredit = Val(gridcontra.Item(5, I).Value.ToString)
                        If creditbal = 0 Then creditbal = Val(gridcontra.Item(5, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (creditbal > 0)
                            If J < gridcontra.RowCount Then

                                Dim ALPARAVAL As New ArrayList

                                ALPARAVAL.Add(gridcontra.Item(1, I).Value.ToString)    'ADDING NAME FROMID

                                If Val(gridcontra.Item(6, J).Value.ToString) = 0 Then

                                    If gridcontra.Item(0, J).Value.ToString = "Dr" Then

                                        If debitbal = 0 Then debitbal = Val(gridcontra.Item(4, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridcontra.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridcontra.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridcontra.Item(6, I).Value = 1
                                            gridcontra.Item(6, J).Value = 1

                                        End If

                                        ALPARAVAL.Add(gridcontra.Item(1, J).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'CONTRA NO
                                        ALPARAVAL.Add(contradate.Value)                        'CONTRA DATE
                                        ALPARAVAL.Add(TXTCHQNO.Text.Trim)                        'CHQNO
                                        ALPARAVAL.Add(txtremarks.Text.Trim)                        'REMARKS
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

                ElseIf gridcontra.Item(0, I).Value.ToString = "Dr" Then

                    If Val(gridcontra.Item(6, I).Value.ToString) = 0 Then

                        tempdebit = Val(gridcontra.Item(4, I).Value.ToString)
                        If debitbal = 0 Then debitbal = Val(gridcontra.Item(4, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (debitbal > 0)
                            If J < gridcontra.RowCount Then
                                Dim ALPARAVAL As New ArrayList

                                If Val(gridcontra.Item(6, J).Value.ToString) = 0 Then

                                    If gridcontra.Item(0, J).Value.ToString = "Cr" Then

                                        'getting ledgerid
                                        ALPARAVAL.Add(gridcontra.Item(1, J).Value.ToString) 'ADDING NAME FROMID

                                        If creditbal = 0 Then creditbal = Val(gridcontra.Item(5, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridcontra.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridcontra.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridcontra.Item(6, I).Value = 1
                                            gridcontra.Item(6, J).Value = 1

                                        End If


                                        ALPARAVAL.Add(gridcontra.Item(1, I).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'CONTRA NO
                                        ALPARAVAL.Add(contradate.Value)                        'CONTRA DATE
                                        ALPARAVAL.Add(TXTCHQNO.Text.Trim)                        'CHQNO
                                        ALPARAVAL.Add(txtremarks.Text.Trim)                        'REMARKS
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

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Reco Done, Contra Locked")
            bln = False
        End If

        If ALLOWMANUALCONTRANO = True Then
            If txtjournalno.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon

                Dim dttable As DataTable = OBJCMN.search(" ISNULL(CONTRA.CONTRA_no,0) AS CONTRANO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CONTRA ON REGISTERMASTER.register_id = CONTRA.CONTRA_registerid AND REGISTERMASTER.register_cmpid = CONTRA.CONTRA_cmpid AND REGISTERMASTER.register_yearid = CONTRA.CONTRA_yearid AND REGISTERMASTER.register_locationid = CONTRA.CONTRA_locationid ", "  AND CONTRA.CONTRA_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CONTRA.CONTRA_CMPID = " & CmpId & " AND CONTRA.CONTRA_LOCATIONID = " & Locationid & " AND CONTRA.CONTRA_YEARID = " & YearId)

                If dttable.Rows.Count > 0 Then
                    EP.SetError(txtjournalno, "Contra No Already Exist")
                    bln = False
                End If
            End If
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        If gridcontra.RowCount = 0 Then
            EP.SetError(txtcredit, "Enter Transactions")
            bln = False
        End If

        'cheking whether cr and dr is equal or not
        Dim tempdebit, tempcredit As Double
        For Each row As DataGridViewRow In gridcontra.Rows
            tempdebit = Val(tempdebit) + Val(row.Cells(4).Value)
            tempcredit = Val(tempcredit) + Val(row.Cells(5).Value)
        Next
        If Val(tempdebit) <> Val(tempcredit) Then
            EP.SetError(txtcredit, "Total Does Not Match")
            bln = False
        End If

        If Not datecheck(contradate.Value) Then
            EP.SetError(contradate, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub ContraEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Delete
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraEntry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    contraregabbr = dt.Rows(0).Item(0).ToString
                    contrareginitial = dt.Rows(0).Item(1).ToString
                    jvregid = dt.Rows(0).Item(2)
                    getmaxno_contramaster()
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

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub txtcredit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcredit.Validating
        Try
            If (Val(txtcredit.Text) <> 0 Or Val(txtdebit.Text) <> 0) And cmbname.Text.Trim <> "" And cmbtype.Text.Trim <> "" Then
                'If cmbpaytype.Text <> "On Account" And txtrefno.Text.Trim.Length <> 0 Then
                If cmbtype.Text = "Dr" Then
                    txtcredit.Clear()
                Else
                    txtdebit.Clear()
                End If

                If Not checkledger() Then
                    MsgBox("Ledger already Present in Grid below")
                    Exit Sub
                End If

                fillgrid()
                txtdebit.Clear()
                txtcredit.Clear()
                txtrefno.Clear()
                cmbpaytype.SelectedIndex = 0
                cmbname.Text = ""
                cmbtype.Focus()
                'Else
                '   MsgBox("Enter Ref No.")
                '  txtrefno.Focus()
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkledger() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In gridcontra.Rows
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
                gridcontra.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) & "Dr"
                End If
                gridcontra.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            End If

        ElseIf GRIDDOUBLECLICK = True Then

            gridcontra.Item(0, TEMPROW).Value = cmbtype.Text
            gridcontra.Item(1, TEMPROW).Value = cmbname.Text.Trim
            gridcontra.Item(2, TEMPROW).Value = cmbpaytype.Text
            gridcontra.Item(3, TEMPROW).Value = txtrefno.Text.Trim
            gridcontra.Item(4, TEMPROW).Value = Format(Val(txtdebit.Text), "0.00")
            gridcontra.Item(5, TEMPROW).Value = Format(Val(txtcredit.Text), "0.00")
            gridcontra.Item(6, TEMPROW).Value = ""
            GRIDDOUBLECLICK = False

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) * (-1) & "Cr"
                End If
                gridcontra.Item(7, TEMPROW).Value = BAL
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) * (-1) & "Dr"
                End If
                gridcontra.Item(7, TEMPROW).Value = BAL
            End If
        End If
    End Sub

    Private Sub gridCONTRA_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridcontra.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.RowIndex >= 0 And gridcontra.Item(0, e.RowIndex).Value <> Nothing Then
            GRIDDOUBLECLICK = True
            TEMPROW = e.RowIndex
            cmbtype.Text = gridcontra.Item(0, e.RowIndex).Value
            cmbname.Text = gridcontra.Item(1, e.RowIndex).Value
            cmbpaytype.Text = gridcontra.Item(2, e.RowIndex).Value
            txtrefno.Text = gridcontra.Item(3, e.RowIndex).Value
            txtdebit.Text = gridcontra.Item(4, e.RowIndex).Value
            txtcredit.Text = gridcontra.Item(5, e.RowIndex).Value
            cmbtype.Focus()
        End If
    End Sub

    Private Sub gridCONTRA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridcontra.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridcontra.Rows.RemoveAt(gridcontra.CurrentRow.Index)
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJCONTRADETAILS As New ContraDetails
            OBJCONTRADETAILS.MdiParent = MDIMain
            OBJCONTRADETAILS.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CONTRA VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            'getmaxno_contramaster()
            fillregister(cmbregister, " and register_type = 'CONTRA'")
            fillledger(cmbname, edit, " and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsJV As New ClsContra()
                dt = objclsJV.selectCONTRA_edit(tempcontrano, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        cmbregister.Text = TEMPREGNAME
                        txtjournalno.Text = tempcontrano
                        txtjournalno.ReadOnly = True

                        contradate.Value = Convert.ToDateTime(dr("CONTRA_date"))
                        TXTCHQNO.Text = dr("CHQNO")
                        tempamt = Convert.ToString(dr("CONTRA_AMT"))
                        temptds = Convert.ToString(dr("CONTRA_TDS"))
                        txtremarks.Text = Convert.ToString(dr("CONTRA_remarks"))
                        If IsDBNull(dr("CONTRA_recodate")) = False Then 'temprecodate = Convert.ToDateTime(dr("CONTRA_recodate"))
                            temprecodate = Convert.ToDateTime(dr("CONTRA_recodate")).Date
                            gridcontra.Rows.Add(dr("CONTRA_TYPE").ToString, dr("ACC_CMPNAME").ToString, dr("CONTRA_PAYTYPE").ToString, dr("CONTRA_REFNO").ToString, dr("CONTRA_DEBIT").ToString, dr("CONTRA_CREDIT").ToString, 0, "", "", temprecodate)

                            CHKRECO.CheckState = CheckState.Checked

                            RECODATE.Value = temprecodate

                            lbllocked.Visible = True
                            PBlock.Visible = True

                            LBLRECO.Visible = True
                            RECODATE.Visible = True
                            CMDRECO.Visible = True

                        Else

                            CHKRECO.CheckState = CheckState.Unchecked

                            lbllocked.Visible = False
                            PBlock.Visible = False

                            LBLRECO.Visible = False
                            RECODATE.Visible = False
                            CMDRECO.Visible = False

                            gridcontra.Rows.Add(dr("CONTRA_TYPE").ToString, dr("ACC_CMPNAME").ToString, dr("CONTRA_PAYTYPE").ToString, dr("CONTRA_REFNO").ToString, dr("CONTRA_DEBIT").ToString, dr("CONTRA_CREDIT").ToString, 0)
                        End If
                    Next
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
            If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'CASH IN HAND' OR GROUPMASTER.GROUP_SECONDARY ='BANK A/C' OR GROUPMASTER.GROUP_SECONDARY ='BANK OD A/C') and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
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
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY = 'CASH IN HAND' OR GROUPMASTER.GROUP_SECONDARY ='BANK A/C' OR GROUPMASTER.GROUP_SECONDARY ='BANK OD A/C') and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'CASH IN HAND' OR GROUPMASTER.GROUP_SECONDARY ='BANK A/C' OR GROUPMASTER.GROUP_SECONDARY ='BANK OD A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridcontra.RowCount = 0
LINE1:
            tempcontrano = Val(txtjournalno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_contramaster()
            Dim MAXNO As Integer = txtjournalno.Text.Trim
            clear()
            If Val(txtjournalno.Text) - 1 >= tempcontrano Then
                edit = True
                ContraEntry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridcontra.RowCount = 0 And tempcontrano < MAXNO Then
                txtjournalno.Text = tempcontrano
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridcontra.RowCount = 0
LINE1:
            tempcontrano = Val(txtjournalno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If tempcontrano > 0 Then
                edit = True
                ContraEntry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridcontra.RowCount = 0 And tempcontrano > 1 Then
                txtjournalno.Text = tempcontrano
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

                Dim tempmsg As Integer = MsgBox("Delete Contra Entry Permanently?", MsgBoxStyle.YesNo, "TEXPRO")
                If tempmsg = vbYes Then

                    Dim OBJCONTRA As New ClsContra
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(tempcontrano)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJCONTRA.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJCONTRA.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridcontra.RowCount = 0
            tempcontrano = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If tempcontrano > 0 Then
                edit = True
                ContraEntry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDRECO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDRECO.Click
        Try

            Dim BANKNAME As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            For Each ROW As DataGridViewRow In gridcontra.Rows
                If ROW.Cells(gridname.Index).Value <> "" Then
                    DT = OBJCMN.search(" GROUPMASTER.GROUP_SECONDARY AS GROUPNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID", " AND ACC_CMPNAME = '" & ROW.Cells(gridname.Index).Value & "'")
                    If DT.Rows.Count > 0 Then
                        If DT.Rows(0).Item("GROUPNAME") = "Bank A/C" Or DT.Rows(0).Item("GROUPNAME") = "Bank OD A/C" Then BANKNAME = ROW.Cells(gridname.Index).Value
                    End If
                End If
            Next

            Dim objbankreco As New BankReco
            objbankreco.txtname.Text = BANKNAME
            objbankreco.chkAll.CheckState = CheckState.Checked
            objbankreco.dtfrom.Value = getfirstdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.dtto.Value = getlastdate(CmpId, MonthName(RECODATE.Value.Date.Month))
            objbankreco.MdiParent = MDIMain
            objbankreco.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraEntry_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
        If ClientName = "MAHAVIR" Or ClientName = "PURVITEX" Then ALLOWMANUALCONTRANO = True

    End Sub

    Private Sub txtjournalno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtjournalno.Validating
        Try
            If (Val(txtjournalno.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And tempcontrano <> Val(txtjournalno.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(CONTRA.CONTRA_no,0) AS CONTRANO", "", " REGISTERMASTER INNER JOIN CONTRA ON REGISTERMASTER.register_id = CONTRA.CONTRA_registerid AND REGISTERMASTER.register_cmpid = CONTRA.CONTRA_cmpid AND REGISTERMASTER.register_yearid = CONTRA.CONTRA_yearid AND REGISTERMASTER.register_locationid = CONTRA.CONTRA_locationid ", "  AND CONTRA.CONTRA_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CONTRA.CONTRA_CMPID = " & CmpId & " AND CONTRA.CONTRA_LOCATIONID = " & Locationid & " AND CONTRA.CONTRA_YEARID = " & YearId)

                If dttable.Rows.Count > 0 Then
                    MsgBox("Contra No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtjournalno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjournalno.KeyPress
        numkeypress(e, txtjournalno, Me)
    End Sub
End Class