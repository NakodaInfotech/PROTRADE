
Imports BL
Imports System.Windows.Forms

Public Class PayOutstanding

    Private Sub RecOutstanding_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDOUTSTANDING.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim GTOTAL, RECDTOTAL, BALANCE, GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT * FROM OUTSTANDINGPAY WHERE SECONDARY = 'Sundry CREDITORS' AND ROUND(BALANCE,2) <> 0 AND YEARID = " & YearId & WHERECLAUSE & " ORDER BY NAME, DATE, TYPE, BILL", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                GTOTAL = 0
                RECDTOTAL = 0
                BALANCE = 0
                GRANDTOTAL = 0
                RECDGRANDTOTAL = 0
                BALANCEGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("NAME") Then
                        TEMPNAME = ROW("NAME")
                        If GRIDOUTSTANDING.RowCount > 0 Then ADDPARTYTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                        GTOTAL = 0
                        RECDTOTAL = 0
                        BALANCE = 0
                        ADDNAMEROW(ROW("NAME"))
                    End If
                    GRIDOUTSTANDING.Rows.Add(ROW("AGENT"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date))
                    GTOTAL += Val(ROW("GRANDTOTAL"))
                    RECDTOTAL += Val(ROW("RECDAMT"))
                    BALANCE += Val(ROW("BALANCE"))

                    GRANDTOTAL += Val(ROW("GRANDTOTAL"))
                    RECDGRANDTOTAL += Val(ROW("RECDAMT"))
                    BALANCEGRANDTOTAL += Val(ROW("BALANCE"))
                Next
                'FOR LAST RECORD WE NNEED TO ADD TOTAL ALSO
                If GRIDOUTSTANDING.RowCount > 0 Then ADDPARTYTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                If GRIDOUTSTANDING.RowCount > 0 Then ADDGRANDTOTALROW(GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSUMMGRID()
        Try
            GRIDSUMM.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim BALANCE, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT NAME,SUM(BALANCE) AS BALANCE FROM OUTSTANDINGPAY WHERE SECONDARY = 'Sundry CREDITORS' AND YEARID = " & YearId & WHERECLAUSE & " GROUP BY NAME HAVING ROUND(SUM(BALANCE),2) <> 0", "", "")
            If DT.Rows.Count > 0 Then
                BALANCE = 0
                BALANCEGRANDTOTAL = 0
                For Each ROW As DataRow In DT.Rows
                    GRIDSUMM.Rows.Add(ROW("NAME"), Format(Val(ROW("BALANCE")), "0.00"))
                    BALANCE += Val(ROW("BALANCE"))
                    BALANCEGRANDTOTAL += Val(ROW("BALANCE"))
                Next
                'FOR LAST RECORD WE NNEED TO ADD TOTAL ALSO
                If GRIDSUMM.RowCount > 0 Then ADDSUMMTOTALROW(BALANCE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLADVGRID()
        Try
            GRIDADV.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim RECDTOTAL, RECDGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            'If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            'If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            'If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT BILLINITIALS,DATE,NAME, AGENT,RECDAMT FROM OUTSTANDINGPAY WHERE SECONDARY = 'Sundry CREDITORS' AND TYPE='PAYMENT' AND YEARID = " & YearId & WHERECLAUSE & " ORDER BY AGENT, DATE, TYPE", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                RECDTOTAL = 0
                RECDGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("NAME") Then
                        TEMPNAME = ROW("NAME")
                        If GRIDADV.RowCount > 0 Then ADDADVTOTALROW(RECDTOTAL)
                        RECDTOTAL = 0
                        ADDADVNAMEROW(ROW("NAME"))
                    End If
                    GRIDADV.Rows.Add(ROW("AGENT"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Val(ROW("RECDAMT")), "0.00"))
                    RECDTOTAL += Val(ROW("RECDAMT"))
                    RECDGRANDTOTAL += Val(ROW("RECDAMT"))
                Next

                'FOR LAST RECORD WE NNEED TO ADD TOTAL ALSO
                If GRIDADV.RowCount > 0 Then ADDADVTOTALROW(RECDTOTAL)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPARTGRID()
        Try
            GRIDPART.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim GTOTAL, RECDTOTAL, BALANCE, GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT * FROM OUTSTANDINGPAY WHERE SECONDARY = 'Sundry CREDITORS' AND RECDAMT > 0 AND BALANCE > 0 AND YEARID = " & YearId & WHERECLAUSE & " ORDER BY NAME, DATE, TYPE, BILL", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                GTOTAL = 0
                RECDTOTAL = 0
                BALANCE = 0
                GRANDTOTAL = 0
                RECDGRANDTOTAL = 0
                BALANCEGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("NAME") Then
                        TEMPNAME = ROW("NAME")
                        If GRIDPART.RowCount > 0 Then ADDPARTPAIDTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                        GTOTAL = 0
                        RECDTOTAL = 0
                        BALANCE = 0
                        ADDPARTNAMEROW(ROW("NAME"))
                    End If
                    GRIDPART.Rows.Add(ROW("AGENT"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date))
                    GTOTAL += Val(ROW("GRANDTOTAL"))
                    RECDTOTAL += Val(ROW("RECDAMT"))
                    BALANCE += Val(ROW("BALANCE"))

                    GRANDTOTAL += Val(ROW("GRANDTOTAL"))
                    RECDGRANDTOTAL += Val(ROW("RECDAMT"))
                    BALANCEGRANDTOTAL += Val(ROW("BALANCE"))
                Next
                'FOR LAST RECORD WE NNEED TO ADD TOTAL ALSO
                If GRIDPART.RowCount > 0 Then ADDPARTPAIDTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                If GRIDPART.RowCount > 0 Then ADDPARTGRANDTOTALROW(GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDNAMEROW(ByVal NAME)
        Try
            'PRINT NAME 
            GRIDOUTSTANDING.Rows.Add(NAME)
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(213, 228, 248)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDADVNAMEROW(ByVal NAME)
        Try
            'PRINT NAME 
            GRIDADV.Rows.Add(NAME)
            GRIDADV.Rows(GRIDADV.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(213, 228, 248)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDPARTNAMEROW(ByVal NAME)
        Try
            'PRINT NAME 
            GRIDPART.Rows.Add(NAME)
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(213, 228, 248)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDPARTYTOTALROW(ByVal GTOTAL As Decimal, ByVal RECDTOTAL As Decimal, ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDOUTSTANDING.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Yellow
            GRIDOUTSTANDING.Rows.Add("SUBTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle = STYLE
            GRIDOUTSTANDING.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDPARTPAIDTOTALROW(ByVal GTOTAL As Decimal, ByVal RECDTOTAL As Decimal, ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDPART.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Yellow
            GRIDPART.Rows.Add("SUBTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle = STYLE
            GRIDPART.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDSUMMTOTALROW(ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDSUMM.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Yellow
            GRIDSUMM.Rows.Add("TOTAL", Format(Val(BALANCE), "0.00"), "")
            GRIDSUMM.Rows(GRIDSUMM.RowCount - 1).DefaultCellStyle = STYLE
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDADVTOTALROW(ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDADV.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Yellow
            GRIDADV.Rows.Add("SUBTOTAL", "", "", Format(Val(BALANCE), "0.00"))
            GRIDADV.Rows(GRIDADV.RowCount - 1).DefaultCellStyle = STYLE
            GRIDADV.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDSUMMGRANDTOTALROW(ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDSUMM.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Orange
            GRIDSUMM.Rows.Add("GRANDTOTAL", Format(Val(BALANCE), "0.00"), "")
            GRIDSUMM.Rows(GRIDSUMM.RowCount - 1).DefaultCellStyle = STYLE
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDGRANDTOTALROW(ByVal GTOTAL As Decimal, ByVal RECDTOTAL As Decimal, ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDOUTSTANDING.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Orange
            GRIDOUTSTANDING.Rows.Add("GRANDTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle = STYLE
            GRIDOUTSTANDING.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDPARTGRANDTOTALROW(ByVal GTOTAL As Decimal, ByVal RECDTOTAL As Decimal, ByVal BALANCE As Decimal)
        Try
            'PRINT NAME 
            Dim STYLE As New DataGridViewCellStyle
            STYLE.Font = New Font(GRIDPART.Font, FontStyle.Bold)
            STYLE.BackColor = Color.Orange
            GRIDPART.Rows.Add("GRANDTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle = STYLE
            GRIDPART.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal INVNO As Integer, ByVal REGISTER As String)
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RecOutstanding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
            FILLSUMMGRID()
            FILLADVGRID()
            FILLPARTGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDSEARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSEARCH.Click
        fillgrid()
        FILLSUMMGRID()
        FILLADVGRID()
        FILLPARTGRID()
    End Sub

    Private Sub CMBGROUP_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUP.Enter
        Try
            If CMBGROUP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    CMBGROUP.DataSource = dt
                    CMBGROUP.DisplayMember = "group_name"
                    CMBGROUP.Text = ""
                End If
                CMBGROUP.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUP.Validated
        Try
            If cmbgroup.Text.Trim <> "" Then
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbregister.Text = ""
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        fillregister(cmbregister, " and register_type = 'PURCHASE'")
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        fillregister(cmbregister, " and register_type = 'SALE'")
                    Else
                        cmbregister.DataSource = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUP.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then
                pcase(cmbgroup)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbgroup.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        CMBGROUP.Text = a
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = CMBGROUP.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & CMBGROUP.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBGROUP.DataSource
                            If CMBGROUP.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(CMBGROUP.Text)
                                CMBGROUP.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS'", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBROKERNAME.Enter
        If CMBBROKERNAME.Text.Trim = "" Then fillagentledger(CMBBROKERNAME, False, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKERNAME.Validating
        Try
            If CMBBROKERNAME.Text.Trim <> "" Then namevalidate(CMBBROKERNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBROKERNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBBROKERNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBREGISTER.Enter
        Try
            If CMBREGISTER.Text.Trim = "" Then fillregister(CMBREGISTER, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                CMBREGISTER.Text = dt.Rows(0).Item(0).ToString
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSTATE.Enter
        Try
            If CMBSTATE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    CMBSTATE.DataSource = dt
                    CMBSTATE.DisplayMember = "state_name"
                    CMBSTATE.Text = ""
                End If
                CMBSTATE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTATE.Validating
        Try
            If CMBSTATE.Text.Trim <> "" Then
                pcase(CMBSTATE)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & CMBSTATE.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillCITY(CMBCITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
  
End Class