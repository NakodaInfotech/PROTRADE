
Imports BL
Imports System.Windows.Forms

Public Class RecOutstanding

    Dim FILLDONE As Boolean = True
    Public PARTYNAME As String = ""

    Private Sub RecOutstanding_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "PARTYWISE"

    Sub FILLGRID()
        Try
            GRIDOUTSTANDING.RowCount = 0
            GCMPNAME.Visible = False

            Dim TEMPNAME As String = ""
            Dim GTOTAL, RECDTOTAL, BALANCE, GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"

            'GET ALL YEARID FROM SELECTED COMPANY WITH SAME STARTYEAR
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                    GCMPNAME.Visible = True
                End If
            Next item



            DT = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"



            'WE ARE PASSING YEARID FROM ABOVE CLAUSE SO NO NEED TO ENTER YEARID HERE
            DT = OBJCMN.Execute_Any_String(" SELECT OUTSTANDINGREC.*, CMPMASTER.CMP_NAME AS CMPNAME FROM OUTSTANDINGREC INNER JOIN CMPMASTER ON CMPID = CMP_ID WHERE SECONDARY = 'Sundry Debtors' AND ROUND(BALANCE,2) <> 0 " & WHERECLAUSE & " ORDER BY NAME, DATE, TYPE, BILL", "", "")
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
                        ADDNAMEROW(ROW("NAME"), ROW("MOBILENO"), ROW("PHONENO"), ROW("CITY"))
                    End If
                    GRIDOUTSTANDING.Rows.Add(ROW("AGENT"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), ROW("ITEMNAME"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date), Format(Val(ROW("CHARGES")), "0.00"), ROW("CMPNAME"))
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
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"


            DT = OBJCMN.Execute_Any_String(" SELECT NAME,SUM(BALANCE) AS BALANCE FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' " & WHERECLAUSE & " GROUP BY NAME HAVING ROUND(SUM(BALANCE),2) <> 0", "", "")
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
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            'If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            'If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            'If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"


            DT = OBJCMN.Execute_Any_String(" SELECT BILLINITIALS,DATE,NAME, AGENT,RECDAMT, MOBILENO, PHONENO FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' AND TYPE='RECEIPT' " & WHERECLAUSE & " ORDER BY AGENT, DATE, TYPE", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                RECDTOTAL = 0
                RECDGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("NAME") Then
                        TEMPNAME = ROW("NAME")
                        If GRIDADV.RowCount > 0 Then ADDADVTOTALROW(RECDTOTAL)
                        RECDTOTAL = 0
                        ADDADVNAMEROW(ROW("NAME"), ROW("MOBILENO"), ROW("PHONENO"))
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
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"



            DT = OBJCMN.Execute_Any_String(" SELECT * FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' AND RECDAMT > 0 AND BALANCE > 0 " & WHERECLAUSE & " ORDER BY NAME, DATE, TYPE, BILL", "", "")
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
                        ADDPARTNAMEROW(ROW("NAME"), ROW("MOBILENO"), ROW("PHONENO"))
                    End If
                    GRIDPART.Rows.Add(ROW("AGENT"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), ROW("ITEMNAME"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date))
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

    Sub ADDNAMEROW(ByVal NAME, ByVal MOBILENO, ByVal PHONENO, ByVal CITYNAME)
        Try
            'PRINT NAME 
            GRIDOUTSTANDING.Rows.Add(NAME, "CONTACT NO : ", MOBILENO, PHONENO, "", "", CITYNAME)
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle.Font = New Font("Calibri", 11, FontStyle.Bold)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDADVNAMEROW(ByVal NAME, ByVal MOBILENO, ByVal PHONENO)
        Try
            'PRINT NAME 
            GRIDADV.Rows.Add(NAME, "CONTACT NO : ", MOBILENO, PHONENO)
            GRIDADV.Rows(GRIDADV.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDPARTNAMEROW(ByVal NAME, ByVal MOBILENO, ByVal PHONENO)
        Try
            'PRINT NAME 
            GRIDPART.Rows.Add(NAME, "CONTACT NO : ", MOBILENO, PHONENO)
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
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
            GRIDOUTSTANDING.Rows.Add("SUBTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "", "", "")
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
            GRIDPART.Rows.Add("SUBTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
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
            GRIDOUTSTANDING.Rows.Add("GRANDTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "", "", "")
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
            GRIDPART.Rows.Add("GRANDTOTAL", "", "", "", Format(Val(GTOTAL), "0.00"), "", "", Format(Val(RECDTOTAL), "0.00"), Format(Val(BALANCE), "0.00"), "")
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle = STYLE
            GRIDPART.Rows.Add()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "AGENTWISE"

    Sub FILLAGENTGRID()
        Try
            GRIDOUTSTANDING.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim GTOTAL, RECDTOTAL, BALANCE, GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"

            'GET ALL YEARID FROM SELECTED COMPANY WITH SAME STARTYEAR
            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"



            'WE ARE PASSING YEARID FROM ABOVE CLAUSE SO NO NEED TO ENTER YEARID HERE
            DT = OBJCMN.Execute_Any_String(" SELECT OUTSTANDINGREC.*, CMPMASTER.CMP_NAME AS CMPNAME FROM OUTSTANDINGREC INNER JOIN CMPMASTER ON CMPID = CMP_ID WHERE SECONDARY = 'Sundry Debtors' AND ROUND(BALANCE,2) <> 0 " & WHERECLAUSE & " ORDER BY AGENT, NAME, DATE, TYPE, BILL", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                GTOTAL = 0
                RECDTOTAL = 0
                BALANCE = 0
                GRANDTOTAL = 0
                RECDGRANDTOTAL = 0
                BALANCEGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("AGENT") Then
                        TEMPNAME = ROW("AGENT")
                        If GRIDOUTSTANDING.RowCount > 0 Then ADDPARTYTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                        GTOTAL = 0
                        RECDTOTAL = 0
                        BALANCE = 0
                        ADDAGENTNAMEROW(ROW("AGENT"))
                    End If
                    GRIDOUTSTANDING.Rows.Add(ROW("NAME"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), ROW("ITEMNAME"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date), Format(Val(ROW("CHARGES")), "0.00"), ROW("CMPNAME"))
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

    Sub FILLAGENTSUMMGRID()
        Try
            GRIDSUMM.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim BALANCE, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"


            DT = OBJCMN.Execute_Any_String(" SELECT AGENT,SUM(BALANCE) AS BALANCE FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' " & WHERECLAUSE & " GROUP BY AGENT HAVING ROUND(SUM(BALANCE),2) <> 0", "", "")
            If DT.Rows.Count > 0 Then
                BALANCE = 0
                BALANCEGRANDTOTAL = 0
                For Each ROW As DataRow In DT.Rows
                    GRIDSUMM.Rows.Add(ROW("AGENT"), Format(Val(ROW("BALANCE")), "0.00"))
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

    Sub FILLAGENTADVGRID()
        Try
            GRIDADV.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim RECDTOTAL, RECDGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            'If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            'If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            'If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"


            DT = OBJCMN.Execute_Any_String(" SELECT BILLINITIALS,DATE,NAME, AGENT,RECDAMT, MOBILENO, PHONENO FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' AND TYPE='RECEIPT' " & WHERECLAUSE & " ORDER BY AGENT, DATE, TYPE", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                RECDTOTAL = 0
                RECDGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("AGENT") Then
                        TEMPNAME = ROW("AGENT")
                        If GRIDADV.RowCount > 0 Then ADDADVTOTALROW(RECDTOTAL)
                        RECDTOTAL = 0
                        ADDAGENTADVNAMEROW(ROW("AGENT"))
                    End If
                    GRIDADV.Rows.Add(ROW("NAME"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Val(ROW("RECDAMT")), "0.00"))
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

    Sub FILLAGENTPARTGRID()
        Try
            GRIDPART.RowCount = 0
            Dim TEMPNAME As String = ""
            Dim GTOTAL, RECDTOTAL, BALANCE, GRANDTOTAL, RECDGRANDTOTAL, BALANCEGRANDTOTAL As Decimal
            Dim WHERECLAUSE As String = " "


            If CMBNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & CMBNAME.Text.Trim & "'"
            If CMBBROKERNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBBROKERNAME.Text.Trim & "'"
            If CMBGROUP.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPNAME = '" & CMBGROUP.Text.Trim & "'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITY = '" & CMBCITY.Text.Trim & "'"
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GROUPOFCOMPANIES = '" & CMBGROUPOFCOMPANY.Text.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND STATE = '" & CMBSTATE.Text.Trim & "'"
            If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGTYPE = '" & CMBREGISTER.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & CMBITEMNAME.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'  AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If CHKDUE.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DUEDATE < '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"
            If CHKLASTYEAR.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = 'OPENING'"
            If Val(TXTOVERDUEDAYS.Text.Trim) > 0 Then WHERECLAUSE = WHERECLAUSE & " AND DATEADD(DAY, " & Val(TXTOVERDUEDAYS.Text.Trim) & ", DUEDATE)  <= '" & Format(Mydate.Date, "MM/dd/yyyy") & "'"


            Dim CMPCLAUSE As String = ""
            Dim CHECKED_CMP As CheckedListBox.CheckedItemCollection = LSTCMP.CheckedItems
            For Each item As Object In CHECKED_CMP
                If CMPCLAUSE = "" Then
                    CMPCLAUSE = "'" & item.ToString() & "'"
                Else
                    CMPCLAUSE = CMPCLAUSE & ",'" & item.ToString() & "'"
                End If
            Next item


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("cmp_id AS CMPID ,year_id AS YEARID", "", " CMPMASTER inner join YEARMASTER ON YEAR_CMPID = CMP_ID", " AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND CMP_NAME IN (" & CMPCLAUSE & ")")
            CMPCLAUSE = ""
            For Each DTROW As DataRow In DT.Rows
                If CMPCLAUSE = "" Then CMPCLAUSE = DTROW("YEARID") Else CMPCLAUSE = CMPCLAUSE & "," & DTROW("YEARID")
            Next
            WHERECLAUSE = WHERECLAUSE & " AND YEARID IN (" & CMPCLAUSE & ")"


            DT = OBJCMN.Execute_Any_String(" SELECT * FROM OUTSTANDINGREC WHERE SECONDARY = 'Sundry Debtors' AND RECDAMT > 0 AND BALANCE > 0 " & WHERECLAUSE & " ORDER BY AGENT, NAME, DATE, TYPE, BILL", "", "")
            If DT.Rows.Count > 0 Then
                TEMPNAME = ""
                GTOTAL = 0
                RECDTOTAL = 0
                BALANCE = 0
                GRANDTOTAL = 0
                RECDGRANDTOTAL = 0
                BALANCEGRANDTOTAL = 0

                For Each ROW As DataRow In DT.Rows
                    If TEMPNAME <> ROW("AGENT") Then
                        TEMPNAME = ROW("AGENT")
                        If GRIDPART.RowCount > 0 Then ADDPARTPAIDTOTALROW(GTOTAL, RECDTOTAL, BALANCE)
                        GTOTAL = 0
                        RECDTOTAL = 0
                        BALANCE = 0
                        ADDAGENTPARTNAMEROW(ROW("AGENT"))
                    End If
                    GRIDPART.Rows.Add(ROW("NAME"), ROW("BILLINITIALS"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yy"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yy"), Format(Val(ROW("GRANDTOTAL")), "0.00"), ROW("LRNO"), ROW("ITEMNAME"), Format(Val(ROW("RECDAMT")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("DUEDATE")).Date, Mydate.Date))
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

    Sub ADDAGENTNAMEROW(ByVal AGENT)
        Try
            'PRINT NAME 
            GRIDOUTSTANDING.Rows.Add(AGENT)
            GRIDOUTSTANDING.Rows(GRIDOUTSTANDING.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDAGENTADVNAMEROW(ByVal AGENT)
        Try
            'PRINT NAME 
            GRIDADV.Rows.Add(AGENT)
            GRIDADV.Rows(GRIDADV.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ADDAGENTPARTNAMEROW(ByVal AGENT)
        Try
            'PRINT NAME 
            GRIDPART.Rows.Add(AGENT)
            GRIDPART.Rows(GRIDPART.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


    Sub showform(ByVal editval As Boolean, ByVal INVNO As Integer, ByVal REGISTER As String)
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RecOutstanding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLDONE = False
            fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            fillname(CMBBROKERNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'AGENT'")

            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "Group_name"
                CMBGROUP.DataSource = dt
                CMBGROUP.DisplayMember = "group_name"
                CMBGROUP.Text = ""
            End If

            fillCITY(CMBCITY, False)
            FILLGROUPCOMPANY(CMBGROUPOFCOMPANY)
            fillSTATE(CMBSTATE)
            fillregister(CMBREGISTER, " and register_type = 'SALE'")
            fillitemname(CMBITEMNAME, " AND ITEM_FRMSTRING = 'MERCHANT'")

            dt = OBJCMN.search("CMP_NAME", "", "CMPMASTER", "")
            For Each DTROW As DataRow In dt.Rows
                LSTCMP.Items.Add(DTROW(0).ToString)
                If DTROW(0) = CmpName Then LSTCMP.SetItemChecked(LSTCMP.Items.Count - 1, True)
            Next
            'DONE BY GULKIT, COZ IF FILLDONE IS NOT MENTIONED HERE THEN EVERYTIME IT GOES TO SELECTEDINDEXCHANGE EVENT ON FILLING THE COMBO
            FILLDONE = True
            CMBREPORTTYPE.SelectedIndex = 0

            If PARTYNAME <> "" Then CMBNAME.Text = PARTYNAME

            FILLGRID()
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
        Try

            If CMBREPORTTYPE.Text = "PARTYWISE" Then

                FILLGRID()
                FILLSUMMGRID()
                FILLADVGRID()
                FILLPARTGRID()

            ElseIf CMBREPORTTYPE.Text = "AGENTWISE" Then

                FILLAGENTGRID()
                FILLAGENTSUMMGRID()
                FILLAGENTADVGRID()
                FILLAGENTPARTGRID()

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
            namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

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

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
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

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKERNAME_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.SelectedValueChanged, CMBBROKERNAME.SelectedValueChanged, CMBGROUP.SelectedValueChanged, CMBCITY.SelectedValueChanged, CMBSTATE.SelectedValueChanged, CMBREGISTER.SelectedValueChanged, CMBGROUPOFCOMPANY.SelectedValueChanged, CMBITEMNAME.SelectedValueChanged
        Try
            If FILLDONE = False Then Exit Sub
            CMDSEARCH_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            CMBNAME.Text = ""
            CMBBROKERNAME.Text = ""
            CMBGROUP.Text = ""
            CMBCITY.Text = ""
            CMBGROUPOFCOMPANY.Text = ""
            CMBSTATE.Text = ""
            CMBREGISTER.Text = ""
            TXTOVERDUEDAYS.Clear()
            CHKDUE.CheckState = CheckState.Unchecked
            CHKLASTYEAR.CheckState = CheckState.Unchecked
            chkdate.CheckState = CheckState.Unchecked

            FILLGRID()
            FILLSUMMGRID()
            FILLADVGRID()
            FILLPARTGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFCOMPANY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPOFCOMPANY.Validating
        Try
            If CMBGROUPOFCOMPANY.Text.Trim <> "" Then GROUPCOMPANYVALIDATE(CMBGROUPOFCOMPANY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try
            If GRIDOUTSTANDING.RowCount = 0 Then Exit Sub


            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPOUTSTANDING WHERE YEARID = " & YearId, "", "")

            Dim I As Integer = 1

            If TabControl1.SelectedIndex = 0 Then
                For Each ROW As DataGridViewRow In GRIDOUTSTANDING.Rows
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(I)
                    If ROW.Cells(GNAME.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GNAME.Index).Value)
                    If ROW.Cells(GINVNO.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GINVNO.Index).Value)
                    'If ROW.Cells(GDATE.Index).Value = Nothing Then
                    '    ALPARAVAL.Add("")
                    'Else

                    'End If
                    Dim TEMP As Date
                    If Not DateTime.TryParse(ROW.Cells(GDATE.Index).Value, TEMP) Then
                        ALPARAVAL.Add(DBNull.Value)
                    Else
                        ALPARAVAL.Add(TEMP)
                    End If

                    If Not DateTime.TryParse(ROW.Cells(GDUEDATE.Index).Value, TEMP) Then
                        ALPARAVAL.Add(DBNull.Value)
                    Else
                        ALPARAVAL.Add(TEMP)
                    End If

                    'If ROW.Cells(GDUEDATE.Index).Value = Nothing Then
                    '    ALPARAVAL.Add("")
                    'Else
                    '    Dim TEMP As Date


                    'End If
                    If ROW.Cells(GBILLAMT.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(GBILLAMT.Index).Value))

                    'WE WILL ADD PARTYCONTACT NO IN LR NO COLUMN
                    If ROW.Cells(GINVNO.Index).Value = "CONTACT NO : " Then
                        If ROW.Cells(GDATE.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GDATE.Index).Value)
                    Else
                        If ROW.Cells(GLRNO.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GLRNO.Index).Value)
                    End If

                    If ROW.Cells(GITEMNAME.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GITEMNAME.Index).Value)
                    If ROW.Cells(GRECDAMT.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(GRECDAMT.Index).Value))
                    If ROW.Cells(GBALANCE.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(GBALANCE.Index).Value))
                    If ROW.Cells(GDAYS.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(GDAYS.Index).Value))
                    If ROW.Cells(GCMPNAME.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(GCMPNAME.Index).Value)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)
                    If ROW.Cells(GCHARGES.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(GCHARGES.Index).Value))

                    Dim OBJTB As New ClsTrialBalance
                    OBJTB.alParaval = ALPARAVAL
                    Dim INT As Integer = OBJTB.SAVEOUTSTANDING()

                    I += 1
                Next


                If MsgBox("Wish to Print in Excel?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJRPT As New clsReportDesigner("Outstanding Report", System.AppDomain.CurrentDomain.BaseDirectory & "Outstanding Report.xlsx", 2)
                    OBJRPT.OUTSTANDIGEXCEL(ClientName, CmpId, YearId)
                    Exit Sub
                End If

            Else
                For Each ROW As DataGridViewRow In GRIDSUMM.Rows
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(I)
                    If ROW.Cells(SNAME.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(ROW.Cells(SNAME.Index).Value)
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add("")
                    If ROW.Cells(SBALANCE.Index).Value = Nothing Then ALPARAVAL.Add("") Else ALPARAVAL.Add(Val(ROW.Cells(SBALANCE.Index).Value))
                    ALPARAVAL.Add("")
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add("")

                    Dim OBJTB As New ClsTrialBalance
                    OBJTB.alParaval = ALPARAVAL
                    Dim INT As Integer = OBJTB.SAVEOUTSTANDING()

                    I += 1
                Next
            End If

            Dim OBJPL As New PLDesign
            OBJPL.frmstring = "OUTSTANDING"
            OBJPL.MdiParent = MDIMain
            OBJPL.strsearch = "{TEMPOUTSTANDING.YEARID} = " & YearId
            OBJPL.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(sender As Object, e As EventArgs) Handles CMDCLOSE.Click
        Try
            GBFIND.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDFIND_Click(sender As Object, e As EventArgs) Handles CMDFIND.Click
        Try
            TXTFIND.Clear()
            GBFIND.Visible = True
            If GRIDOUTSTANDING.RowCount > 0 Then GRIDOUTSTANDING.Rows(0).Cells(0).Selected = True
            TXTFIND.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDNEXT_Click(sender As Object, e As EventArgs) Handles CMDNEXT.Click
        Try
            Dim CNO As Integer = GRIDOUTSTANDING.CurrentCell.ColumnIndex + 1
            For ROWNO As Integer = GRIDOUTSTANDING.CurrentRow.Index To GRIDOUTSTANDING.RowCount - 1
                For COLNO As Integer = CNO To GRIDOUTSTANDING.ColumnCount - 1
                    If GRIDOUTSTANDING.Item(COLNO, ROWNO).Value <> Nothing Then
                        If LCase(GRIDOUTSTANDING.Item(COLNO, ROWNO).Value.ToString.Trim) Like LCase(TXTFIND.Text.Trim) & "*" Then
                            GRIDOUTSTANDING.Item(COLNO, ROWNO).Selected = True
                            GoTo LINE1
                        End If
                    End If
                Next
                CNO = 0
            Next
LINE1:
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class