
Imports BL

Public Class SalaryMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPSALNO As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDEARDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Dim TEMPEARROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLCMB()
        Try
            FILLEMP(CMBNAME, edit)
            fillledger(CMBEARNINGS, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
            fillledger(CMBDEDUCTION, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' OR GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Loans & Advances') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()

        TXTSALNO.Clear()
        SALDATE.Value = Now.Date

        CMBNAME.Text = ""
        CMBMONTH.SelectedIndex = 0
        TXTWORKDAYS.Clear()
        TXTPAYDAYS.Clear()
        TXTLEAVE.Clear()

        TXTTOTALDED.Clear()
        TXTTOTALPAY.Clear()
        TXTNETTPAY.Clear()

        TXTEARSRNO.Clear()
        CMBEARNINGS.Text = ""
        TXTEARAMT.Clear()
        GRIDEAR.RowCount = 0

        TXTDEDSRNO.Clear()
        CMBDEDUCTION.Text = ""
        TXTDEDAMT.Clear()
        GRIDDED.RowCount = 0

        txtremarks.Clear()
        txtinwords.Clear()

        GETMAXNO_SALNO()

        TXTAMTREC.Clear()
        TXTEXTRAAMT.Clear()
        TXTRETURN.Clear()
        TXTBALANCE.Clear()

        CMDSHOWDETAILS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        PBPAID.Visible = False

    End Sub

    Sub GETMAXNO_SALNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SAL_NO),0) + 1 ", "SALARYMASTER", " AND SAL_cmpid=" & CmpId & " AND SAL_LOCATIONid=" & Locationid & " AND SAL_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSALNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub SalaryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Or chkchange.CheckState = CheckState.Checked Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Delete
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                'e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F1 Then
                tstxtbillno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = MDIMain
            OBJSAL.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub SalaryMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYROLL'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            FILLCMB()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJSAL As New ClsSalaryMaster()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPSALNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSAL.alParaval = ALPARAVAL
                dt = OBJSAL.selectbill_edit()

                If dt.Rows.Count > 0 Then

                    TXTSALNO.Text = TEMPSALNO
                    SALDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("SALDATE")).Date

                    CMBNAME.Text = dt.Rows(0).Item("NAME")
                    CMBMONTH.Text = dt.Rows(0).Item("MONTH")

                    TXTWORKDAYS.Text = dt.Rows(0).Item("WORKDAYS")
                    TXTPAYDAYS.Text = dt.Rows(0).Item("PAYDAYS")
                    TXTLEAVE.Text = dt.Rows(0).Item("LEAVE")

                    txtremarks.Text = Convert.ToString(dt.Rows(0).Item("REMARKS"))


                    TXTAMTREC.Text = dt.Rows(0).Item("AMTPAID")
                    TXTEXTRAAMT.Text = dt.Rows(0).Item("EXTRAAMT")
                    TXTRETURN.Text = dt.Rows(0).Item("RETURN")
                    TXTBALANCE.Text = dt.Rows(0).Item("BALANCE")


                    If Convert.ToBoolean(dt.Rows(0).Item("DONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    If Val(dt.Rows(0).Item("AMTPAID")) > 0 Or Val(dt.Rows(0).Item("EXTRAAMT")) > 0 Then
                        CMDSHOWDETAILS.Visible = True
                        PBPAID.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" SALARYMASTER_DEDUCTION.SAL_SRNO AS SRNO, LEDGERS.Acc_cmpname AS DEDUCTION, SALARYMASTER_DEDUCTION.SAL_AMT AS DEDAMT ", "", " SALARYMASTER_DEDUCTION INNER JOIN LEDGERS ON SALARYMASTER_DEDUCTION.SAL_DEDID = LEDGERS.Acc_id AND SALARYMASTER_DEDUCTION.SAL_cmpid = LEDGERS.Acc_cmpid AND SALARYMASTER_DEDUCTION.SAL_locationid = LEDGERS.Acc_locationid AND SALARYMASTER_DEDUCTION.SAL_yearid = LEDGERS.Acc_yearid ", " AND SAL_NO = " & TEMPSALNO & " AND SAL_CMPID = " & CmpId & " AND SAL_LOCATIONID = " & Locationid & " AND SAL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTDED As DataRow In dt.Rows
                            GRIDDED.Rows.Add(DTDED("SRNO"), DTDED("DEDUCTION"), Format(Val(DTDED("DEDAMT")), "0.00"))
                        Next
                    End If

                    dt = OBJCMN.search(" SALARYMASTER_EARNINGS.SAL_SRNO AS SRNO, LEDGERS.Acc_cmpname AS EARNINGS, SALARYMASTER_EARNINGS.SAL_AMT AS EARAMT ", "", " SALARYMASTER_EARNINGS INNER JOIN LEDGERS ON SALARYMASTER_EARNINGS.SAL_EARID = LEDGERS.Acc_id AND SALARYMASTER_EARNINGS.SAL_cmpid = LEDGERS.Acc_cmpid AND SALARYMASTER_EARNINGS.SAL_locationid = LEDGERS.Acc_locationid AND SALARYMASTER_EARNINGS.SAL_yearid = LEDGERS.Acc_yearid ", " AND SAL_NO = " & TEMPSALNO & " AND SAL_CMPID = " & CmpId & " AND SAL_LOCATIONID = " & Locationid & " AND SAL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTEAR As DataRow In dt.Rows
                            GRIDEAR.Rows.Add(DTEAR("SRNO"), DTEAR("EARNINGS"), Format(Val(DTEAR("EARAMT")), "0.00"))
                        Next
                    End If

                    TOTAL()
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

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            DELETE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SALDATE.Validating
        If Not datecheck(SALDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno(GRIDDED)
            getsrno(GRIDEAR)

            Dim alParaval As New ArrayList

            alParaval.Add(Format(SALDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBMONTH.Text.Trim)
            alParaval.Add(Val(TXTWORKDAYS.Text.Trim))
            alParaval.Add(Val(TXTPAYDAYS.Text.Trim))
            alParaval.Add(Val(TXTLEAVE.Text.Trim))

            alParaval.Add(Val(TXTTOTALDED.Text.Trim))
            alParaval.Add(Val(TXTTOTALPAY.Text.Trim))
            alParaval.Add(Val(TXTNETTPAY.Text.Trim))


            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBALANCE.Text.Trim))


            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)


            Dim DEDGRIDSRNO As String = ""
            Dim DEDUCTION As String = ""
            Dim DEDAMT As String = ""

            Dim EARGRIDSRNO As String = ""
            Dim EARNINGS As String = ""
            Dim EARAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDED.Rows
                If row.Cells(GDEDSRNO.Index).Value <> Nothing Then
                    If DEDGRIDSRNO = "" Then

                        DEDGRIDSRNO = row.Cells(GDEDSRNO.Index).Value.ToString
                        DEDUCTION = row.Cells(GDEDUCTION.Index).Value
                        DEDAMT = row.Cells(GDEDAMT.Index).Value.ToString

                    Else

                        DEDGRIDSRNO = DEDGRIDSRNO & "," & row.Cells(GDEDSRNO.Index).Value.ToString
                        DEDUCTION = DEDUCTION & "," & row.Cells(GDEDUCTION.Index).Value
                        DEDAMT = DEDAMT & "," & row.Cells(GDEDAMT.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(DEDGRIDSRNO)
            alParaval.Add(DEDUCTION)
            alParaval.Add(DEDAMT)



            For Each row As Windows.Forms.DataGridViewRow In GRIDEAR.Rows
                If row.Cells(GEARSRNO.Index).Value <> Nothing Then
                    If DEDGRIDSRNO = "" Then

                        EARGRIDSRNO = row.Cells(GEARSRNO.Index).Value.ToString
                        EARNINGS = row.Cells(GEARNINGS.Index).Value
                        EARAMT = row.Cells(GEARAMT.Index).Value.ToString

                    Else

                        EARGRIDSRNO = EARGRIDSRNO & "," & row.Cells(GEARSRNO.Index).Value.ToString
                        EARNINGS = EARNINGS & "," & row.Cells(GEARNINGS.Index).Value
                        EARAMT = EARAMT & "," & row.Cells(GEARAMT.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(EARGRIDSRNO)
            alParaval.Add(EARNINGS)
            alParaval.Add(EARAMT)


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJSAL As New ClsSalaryMaster
            OBJSAL.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = OBJSAL.save()
                MessageBox.Show("Details Added")
                PRINTREPORT(DT.Rows(0).Item(0))
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSALNO)
                Dim INT As Integer = OBJSAL.update()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPSALNO)
            End If

            clear()
            edit = False
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If edit = False Then
            'CHECKING WHETHER SALARY OF THE EMPLOYUEE FOR THE MONTH IS PRESENT OR NOT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" SAL_NO", "", " SALARYMASTER INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID = EMPLOYEEMASTER.EMP_id AND SALARYMASTER.SAL_CMPID = EMPLOYEEMASTER.EMP_cmpid AND SALARYMASTER.SAL_LOCATIONID = EMPLOYEEMASTER.EMP_locationid AND SALARYMASTER.SAL_YEARID = EMPLOYEEMASTER.EMP_yearid ", " AND EMP_NAME ='" & CMBNAME.Text.Trim & "' AND SAL_MONTH = '" & CMBMONTH.Text.Trim & "' AND SAL_CMPID = " & CmpId & " AND SAL_LOCATIONID = " & Locationid & " AND SAL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                EP.SetError(CMBMONTH, "Salary for selected Month Already Present")
                bln = False
            End If
        End If


        If TXTWORKDAYS.Text.Trim.Length = 0 Then
            EP.SetError(TXTWORKDAYS, "Select Month")
            bln = False
        End If

        If CMBMONTH.Text.Trim.Length = 0 Then
            EP.SetError(CMBMONTH, "Select Month")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Salary Paid, Entry Locked")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Employee's Name")
            bln = False
        End If

        If GRIDEAR.RowCount = 0 Then
            EP.SetError(TXTEARAMT, "Select Earnings")
            bln = False
        End If

        If TXTNETTPAY.Text.Trim.Length = 0 Then
            EP.SetError(TXTNETTPAY, "Enter Salary Amount")
            bln = False
        End If

        If Not datecheck(SALDATE.Value) Then
            EP.SetError(SALDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLEMP(CMBNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                GRIDDED.RowCount = 0
                GRIDEAR.RowCount = 0

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" EMPLOYEEMASTER_DEDUCTION.EMP_SRNO AS SRNO, LEDGERS.Acc_cmpname AS DEDUCTION, EMPLOYEEMASTER_DEDUCTION.EMP_AMT AS DEDAMT ", "", " EMPLOYEEMASTER_DEDUCTION INNER JOIN LEDGERS ON EMPLOYEEMASTER_DEDUCTION.EMP_DEDID = LEDGERS.Acc_id AND EMPLOYEEMASTER_DEDUCTION.EMP_cmpid = LEDGERS.Acc_cmpid AND EMPLOYEEMASTER_DEDUCTION.EMP_locationid = LEDGERS.Acc_locationid AND EMPLOYEEMASTER_DEDUCTION.EMP_yearid = LEDGERS.Acc_yearid INNER JOIN EMPLOYEEMASTER ON EMPLOYEEMASTER.EMP_ID = EMPLOYEEMASTER_DEDUCTION.EMP_ID AND EMPLOYEEMASTER.EMP_CMPID = EMPLOYEEMASTER_DEDUCTION.EMP_CMPID AND EMPLOYEEMASTER.EMP_LOCATIONID = EMPLOYEEMASTER_DEDUCTION.EMP_LOCATIONID AND EMPLOYEEMASTER.EMP_YEARID = EMPLOYEEMASTER_DEDUCTION.EMP_YEARID  ", " AND EMPLOYEEMASTER.EMP_NAME = '" & CMBNAME.Text.Trim & "' AND EMPLOYEEMASTER.EMP_CMPID = " & CmpId & " AND EMPLOYEEMASTER.EMP_LOCATIONID = " & Locationid & " AND EMPLOYEEMASTER.EMP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTDED As DataRow In DT.Rows
                        GRIDDED.Rows.Add(DTDED("SRNO"), DTDED("DEDUCTION"), Format(Val(DTDED("DEDAMT")), "0.00"))
                    Next
                End If

                DT = OBJCMN.search(" EMPLOYEEMASTER_EARNINGS.EMP_SRNO AS SRNO, LEDGERS.Acc_cmpname AS EARNINGS, EMPLOYEEMASTER_EARNINGS.EMP_AMT AS EARAMT ", "", " EMPLOYEEMASTER_EARNINGS INNER JOIN LEDGERS ON EMPLOYEEMASTER_EARNINGS.EMP_EARID = LEDGERS.Acc_id AND EMPLOYEEMASTER_EARNINGS.EMP_cmpid = LEDGERS.Acc_cmpid AND EMPLOYEEMASTER_EARNINGS.EMP_locationid = LEDGERS.Acc_locationid AND EMPLOYEEMASTER_EARNINGS.EMP_yearid = LEDGERS.Acc_yearid  INNER JOIN EMPLOYEEMASTER ON EMPLOYEEMASTER.EMP_ID = EMPLOYEEMASTER_EARNINGS.EMP_ID AND EMPLOYEEMASTER.EMP_CMPID = EMPLOYEEMASTER_EARNINGS.EMP_CMPID AND EMPLOYEEMASTER.EMP_LOCATIONID = EMPLOYEEMASTER_EARNINGS.EMP_LOCATIONID AND EMPLOYEEMASTER.EMP_YEARID = EMPLOYEEMASTER_EARNINGS.EMP_YEARID", " AND EMPLOYEEMASTER.EMP_NAME = '" & CMBNAME.Text.Trim & "' AND EMPLOYEEMASTER.EMP_CMPID = " & CmpId & " AND EMPLOYEEMASTER.EMP_LOCATIONID = " & Locationid & " AND EMPLOYEEMASTER.EMP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTEAR As DataRow In DT.Rows
                        GRIDEAR.Rows.Add(DTEAR("SRNO"), DTEAR("EARNINGS"), Format(Val(DTEAR("EARAMT")), "0.00"))
                    Next
                End If
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPSALNO = Val(TXTSALNO.Text) + 1
            GETMAXNO_SALNO()
            Dim MAXNO As Integer = TXTSALNO.Text.Trim
            clear()
            If Val(TXTSALNO.Text) - 1 >= TEMPSALNO Then
                edit = True
                SalaryMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TEMPSALNO < MAXNO Then
                TXTSALNO.Text = TEMPSALNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
LINE1:
            TEMPSALNO = Val(TXTSALNO.Text) - 1
            If TEMPSALNO > 0 Then
                edit = True
                SalaryMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If TEMPSALNO > 1 Then
                TXTSALNO.Text = TEMPSALNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        DELETE()
    End Sub

    Sub DELETE()
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            TEMPSALNO = Val(tstxtbillno.Text)
            If TEMPSALNO > 0 Then
                edit = True
                SalaryMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEDUCTION.Enter
        Try
            If CMBDEDUCTION.Text.Trim = "" Then fillledger(CMBDEDUCTION, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEDUCTION.Validating
        Try
            If CMBDEDUCTION.Text.Trim <> "" Then ledgervalidate(CMBDEDUCTION, CMBACCCODE, e, Me, TXTDEDADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEARNINGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEARNINGS.Enter
        Try
            If CMBEARNINGS.Text.Trim = "" Then fillledger(CMBEARNINGS, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Loans & Advances') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEARNINGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBEARNINGS.Validating
        Try
            If CMBEARNINGS.Text.Trim <> "" Then ledgervalidate(CMBEARNINGS, CMBACCCODE, e, Me, TXTDEDADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Loans & Advances') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDDED.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDDED.Item(GDEDSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTDEDSRNO.Text = GRIDDED.Item(GDEDSRNO.Index, e.RowIndex).Value
                CMBDEDUCTION.Text = GRIDDED.Item(GDEDUCTION.Index, e.RowIndex).Value
                TXTDEDAMT.Text = GRIDDED.Item(GDEDAMT.Index, e.RowIndex).Value.ToString
                TEMPROW = e.RowIndex
                TXTDEDSRNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDEAR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDEAR.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDEAR.Item(GEARSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDEARDOUBLECLICK = True
                TXTEARSRNO.Text = GRIDEAR.Item(GEARSRNO.Index, e.RowIndex).Value
                CMBEARNINGS.Text = GRIDEAR.Item(GEARNINGS.Index, e.RowIndex).Value
                TXTEARAMT.Text = GRIDEAR.Item(GEARAMT.Index, e.RowIndex).Value.ToString
                TEMPEARROW = e.RowIndex
                TXTEARSRNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDED_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDED.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDDED.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDDED.Rows.RemoveAt(GRIDDED.CurrentRow.Index)
                getsrno(GRIDDED)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDEAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDEAR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDEAR.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDEARDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDEAR.Rows.RemoveAt(GRIDEAR.CurrentRow.Index)
                getsrno(GRIDEAR)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDEDAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDEDAMT.Validating
        Try
            If CMBDEDUCTION.Text.Trim <> "" And Val(TXTDEDAMT.Text.Trim) > 0 Then
                FILLDED()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEARAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEARAMT.Validating
        Try
            If CMBEARNINGS.Text.Trim <> "" And Val(TXTEARAMT.Text.Trim) > 0 Then
                FILLEAR()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDEDSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDEDSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDDED.RowCount > 0 Then
                TXTDEDSRNO.Text = Val(GRIDDED.Rows(GRIDDED.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTDEDSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTEARSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEARSRNO.GotFocus
        If GRIDEARDOUBLECLICK = False Then
            If GRIDEAR.RowCount > 0 Then
                TXTEARSRNO.Text = Val(GRIDEAR.Rows(GRIDEAR.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTEARSRNO.Text = 1
            End If
        End If
    End Sub

    Sub GETDATE()
        Try
            If CMBMONTH.Text.Trim = "January" Then
                dtfrom.Value = "01/01/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "February" Then
                dtfrom.Value = "01/02/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "March" Then
                dtfrom.Value = "01/03/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "April" Then
                dtfrom.Value = "01/04/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "May" Then
                dtfrom.Value = "01/05/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "June" Then
                dtfrom.Value = "01/06/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "July" Then
                dtfrom.Value = "01/07/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "August" Then
                dtfrom.Value = "01/08/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "September" Then
                dtfrom.Value = "01/09/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "October" Then
                dtfrom.Value = "01/10/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "November" Then
                dtfrom.Value = "01/11/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "December" Then
                dtfrom.Value = "01/12/" & Year(AccFrom)
            End If
            dtto.Value = dtfrom.Value.AddMonths(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            If CMBMONTH.Text.Trim = "" Then CMBMONTH.SelectedIndex = 0
            GETDATE()
            TXTWORKDAYS.Clear()
            TXTPAYDAYS.Clear()
            TXTLEAVE.Clear()

            TXTTOTALDED.Clear()
            TXTTOTALPAY.Clear()
            TXTNETTPAY.Clear()

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            'GET WORKDAYS FROM ATTENDENCE
            DTDAY.Value = dtfrom.Value
            For I As Integer = 1 To DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
                'IF IT IS IN HOLIDAYMASTER THEN PINK COLOR 
                DT = OBJCMN.search(" HOLIDAY_REMARKS", "", " HOLIDAYMASTER", " AND HOLIDAY_DATE = '" & Format(DTDAY.Value.Date, "MM/dd/yyyy") & "' AND HOLIDAY_CMPID = " & CmpId & " AND HOLIDAY_LOCATIONID = " & Locationid & " AND HOLIDAY_YEARID = " & YearId)
                If DT.Rows.Count = 0 And DTDAY.Value.DayOfWeek <> DayOfWeek.Sunday Then TXTWORKDAYS.Text = Val(TXTWORKDAYS.Text) + 1
                DTDAY.Value = DateAdd(DateInterval.Day, I, dtfrom.Value.Date)
            Next

            DT = OBJCMN.search("  COUNT(DISTINCT  DAY(ATTENDENCE.ATT_DATE)) AS PAYDAYS ", "", " EMPLOYEEMASTER INNER JOIN ATTENDENCE ON EMPLOYEEMASTER.EMP_id = ATTENDENCE.ATT_EMPID AND EMPLOYEEMASTER.EMP_cmpid = ATTENDENCE.ATT_CMPID AND EMPLOYEEMASTER.EMP_locationid = ATTENDENCE.ATT_LOCATIONID AND EMPLOYEEMASTER.EMP_yearid = ATTENDENCE.ATT_YEARID ", " AND EMP_NAME = '" & CMBNAME.Text.Trim & "' AND DATENAME(month,ATT_DATE)  = '" & CMBMONTH.Text.Trim & "' AND ATT_CMPID = " & CmpId & " AND ATT_LOCATIONID = " & Locationid & " AND ATT_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TXTPAYDAYS.Text = Val(DT.Rows(0).Item("PAYDAYS"))
                TXTLEAVE.Text = Val(TXTWORKDAYS.Text.Trim) - Val(DT.Rows(0).Item("PAYDAYS"))
            End If

            For Each ROW As DataGridViewRow In GRIDDED.Rows
                TXTTOTALDED.Text = Format(Val(TXTTOTALDED.Text.Trim) + Val(ROW.Cells(GDEDAMT.Index).EditedFormattedValue), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDEAR.Rows
                TXTTOTALPAY.Text = Format(Val(TXTTOTALPAY.Text.Trim) + Val(ROW.Cells(GEARAMT.Index).EditedFormattedValue), "0.00")
            Next

            TXTNETTPAY.Text = Val(TXTTOTALPAY.Text.Trim) - Val(TXTTOTALDED.Text.Trim)
            If Val(TXTNETTPAY.Text.Trim) > 0 Then txtinwords.Text = CurrencyToWord(Val(TXTNETTPAY.Text.Trim))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLDED()

        If GRIDDOUBLECLICK = False Then
            GRIDDED.Rows.Add(Val(TXTDEDSRNO.Text.Trim), CMBDEDUCTION.Text.Trim, Val(TXTDEDAMT.Text.Trim))
            getsrno(GRIDDED)
        ElseIf GRIDDOUBLECLICK = True Then

            GRIDDED.Item(GDEDSRNO.Index, TEMPROW).Value = TXTDEDSRNO.Text.Trim
            GRIDDED.Item(GDEDUCTION.Index, TEMPROW).Value = CMBDEDUCTION.Text.Trim
            GRIDDED.Item(GDEDAMT.Index, TEMPROW).Value = Val(TXTDEDAMT.Text.Trim)

            GRIDDOUBLECLICK = False

        End If
        TOTAL()
        GRIDDED.FirstDisplayedScrollingRowIndex = GRIDDED.RowCount - 1

        TXTDEDSRNO.Clear()
        CMBDEDUCTION.Text = ""
        TXTDEDAMT.Clear()
        TXTDEDSRNO.Focus()

    End Sub

    Sub FILLEAR()

        If GRIDEARDOUBLECLICK = False Then
            GRIDEAR.Rows.Add(Val(TXTEARSRNO.Text.Trim), CMBEARNINGS.Text.Trim, Val(TXTEARAMT.Text.Trim))
            getsrno(GRIDEAR)
        ElseIf GRIDEARDOUBLECLICK = True Then

            GRIDEAR.Item(GEARSRNO.Index, TEMPEARROW).Value = TXTEARSRNO.Text.Trim
            GRIDEAR.Item(GEARNINGS.Index, TEMPEARROW).Value = CMBEARNINGS.Text.Trim
            GRIDEAR.Item(GEARAMT.Index, TEMPEARROW).Value = Val(TXTEARAMT.Text.Trim)

            GRIDEARDOUBLECLICK = False

        End If
        TOTAL()
        GRIDEAR.FirstDisplayedScrollingRowIndex = GRIDEAR.RowCount - 1

        TXTEARSRNO.Clear()
        CMBEARNINGS.Text = ""
        TXTEARAMT.Clear()
        TXTEARSRNO.Focus()

    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If edit = True Then
                Dim OBJPAY As New ShowRecPay
                OBJPAY.MdiParent = MDIMain
                OBJPAY.PURBILLINITIALS = "SAL-" & TEMPSALNO
                OBJPAY.SALEBILLINITIALS = "SAL-" & TEMPSALNO
                OBJPAY.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMONTH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMONTH.Validated
        TOTAL()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPSALNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SALNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Print Salary Slip?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub
            Dim OBJSAL As New SalarySlipDesign
            OBJSAL.MdiParent = MDIMain
            OBJSAL.SALNO = SALNO
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then EMPVALIDATE(CMBNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class