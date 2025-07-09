
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports Axzkemkeeper

Public Class EmployeeMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDEARDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Dim TEMPEARROW As Integer
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public EDIT As Boolean
    Public TEMPEMPNAME As String
    Public TEMPEMPCODE As String
    Dim TEMPEMPID As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

    Private Sub EmployeeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("EMP_NAME", "", " EMPLOYEEMASTER ", " and EMP_cmpid = " & CmpId & " and EMP_locationid = " & Locationid & " and EMP_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "EMP_NAME"
                CMBEMPNAME.DataSource = dt
                CMBEMPNAME.DisplayMember = "EMP_NAME"
                CMBEMPNAME.Text = TEMPEMPNAME
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMPCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("EMP_CODE", "", " EMPLOYEEMASTER ", " and EMP_cmpid = " & CmpId & " and EMP_locationid = " & Locationid & " and EMP_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "EMP_CODE"
                CMBEMPCODE.DataSource = dt
                CMBEMPCODE.DisplayMember = "EMP_CODE"
                CMBEMPCODE.Text = TEMPEMPCODE
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("DESIGNATION_name", "", "DESIGNATIONMaster", " and DESIGNATION_cmpid =" & CmpId & " and DESIGNATION_Locationid =" & Locationid & " and DESIGNATION_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "DESIGNATION_name"
            CMBDESIGNATION.DataSource = dt
            CMBDESIGNATION.DisplayMember = "DESIGNATION_name"
            CMBDESIGNATION.Text = ""
        End If

        dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_cmpid =" & CmpId & " and DEPARTMENT_Locationid =" & Locationid & " and DEPARTMENT_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "DEPARTMENT_name"
            CMBDEPARTMENT.DataSource = dt
            CMBDEPARTMENT.DisplayMember = "DEPARTMENT_name"
            CMBDEPARTMENT.Text = ""
        End If


        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid =" & CmpId & " and area_Locationid =" & Locationid & " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_name"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

        If CMBDEDUCTION.Text.Trim = "" Then fillledger(CMBDEDUCTION, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        If CMBEARNINGS.Text.Trim = "" Then fillledger(CMBEARNINGS, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income') ")

        CMBSALMODE.SelectedIndex = 0

    End Sub

    Private Sub EmployeeMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'EMPLOYEE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)



            fillcmb()
            FILLCMPNAME()
            FILLCMPCODE()
            clear()

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJEMP As New ClsEmployeeMaster

                OBJEMP.alParaval.Add(TEMPEMPNAME)
                OBJEMP.alParaval.Add(CmpId)
                OBJEMP.alParaval.Add(Locationid)
                OBJEMP.alParaval.Add(YearId)

                dttable = OBJEMP.GETEMPLOYEE()

                If dttable.Rows.Count > 0 Then
                    TEMPEMPID = Val(dttable.Rows(0).Item("EMPID"))
                    CMBEMPNAME.Text = dttable.Rows(0).Item("EMPNAME").ToString

                    CMBEMPCODE.Text = dttable.Rows(0).Item("CODE").ToString
                    TEMPEMPCODE = dttable.Rows(0).Item("CODE").ToString

                    CMBDEPARTMENT.Text = dttable.Rows(0).Item("DEPARTMENT").ToString
                    CMBDESIGNATION.Text = dttable.Rows(0).Item("DESIGNATION").ToString
                    TXTENROLLNO.Text = dttable.Rows(0).Item("ENROLLNO")

                    cmbarea.Text = dttable.Rows(0).Item("AREA").ToString
                    cmbcity.Text = dttable.Rows(0).Item("CITY").ToString
                    cmbstate.Text = dttable.Rows(0).Item("STATE").ToString

                    txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString

                    cmbcountry.Text = dttable.Rows(0).Item("COUNTRY").ToString

                    txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
                    txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString

                    txttel1.Text = dttable.Rows(0).Item("CONTACTNO").ToString
                    txtmobile.Text = dttable.Rows(0).Item("MOBILENO").ToString

                    cmbemail.Text = dttable.Rows(0).Item("EMAILID").ToString

                    txtpanno.Text = dttable.Rows(0).Item("PANNO").ToString
                    TXTPFNO.Text = dttable.Rows(0).Item("PFNO").ToString
                    CMBSALMODE.Text = dttable.Rows(0).Item("SALMODE").ToString
                    TXTACNO.Text = dttable.Rows(0).Item("ACNO").ToString

                    txtadd.Text = dttable.Rows(0).Item("ADD").ToString
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString

                    txtimgpath.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    TXTOURLOCATION.Text = dttable.Rows(0).Item("OURLOCATION").ToString

                    GETIMG()


                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" EMPLOYEEMASTER_DEDUCTION.EMP_SRNO AS SRNO, LEDGERS.Acc_cmpname AS DEDUCTION, EMPLOYEEMASTER_DEDUCTION.EMP_AMT AS DEDAMT ", "", " EMPLOYEEMASTER_DEDUCTION INNER JOIN LEDGERS ON EMPLOYEEMASTER_DEDUCTION.EMP_DEDID = LEDGERS.Acc_id AND EMPLOYEEMASTER_DEDUCTION.EMP_cmpid = LEDGERS.Acc_cmpid AND EMPLOYEEMASTER_DEDUCTION.EMP_locationid = LEDGERS.Acc_locationid AND EMPLOYEEMASTER_DEDUCTION.EMP_yearid = LEDGERS.Acc_yearid ", " AND EMP_ID = " & TEMPEMPID & " AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTDED As DataRow In DT.Rows
                            GRIDDED.Rows.Add(DTDED("SRNO"), DTDED("DEDUCTION"), Format(Val(DTDED("DEDAMT")), "0.00"))
                        Next
                    End If

                    DT = OBJCMN.search(" EMPLOYEEMASTER_EARNINGS.EMP_SRNO AS SRNO, LEDGERS.Acc_cmpname AS EARNINGS, EMPLOYEEMASTER_EARNINGS.EMP_AMT AS EARAMT ", "", " EMPLOYEEMASTER_EARNINGS INNER JOIN LEDGERS ON EMPLOYEEMASTER_EARNINGS.EMP_EARID = LEDGERS.Acc_id AND EMPLOYEEMASTER_EARNINGS.EMP_cmpid = LEDGERS.Acc_cmpid AND EMPLOYEEMASTER_EARNINGS.EMP_locationid = LEDGERS.Acc_locationid AND EMPLOYEEMASTER_EARNINGS.EMP_yearid = LEDGERS.Acc_yearid ", " AND EMP_ID = " & TEMPEMPID & " AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTEAR As DataRow In DT.Rows
                            GRIDEAR.Rows.Add(DTEAR("SRNO"), DTEAR("EARNINGS"), Format(Val(DTEAR("EARAMT")), "0.00"))
                        Next
                    End If

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETIMG()
        On Error Resume Next
        PBIMG.ImageLocation = ""
        If txtimgpath.Text.Trim <> "" Then
            PBIMG.ImageLocation = txtimgpath.Text.Trim
            PBIMG.Load(txtimgpath.Text.Trim)
        ElseIf TXTOURLOCATION.Text.Trim <> "" Then
            PBIMG.ImageLocation = TXTOURLOCATION.Text.Trim
            PBIMG.Load(TXTOURLOCATION.Text.Trim)
        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(CMBEMPNAME.Text.Trim)
            alParaval.Add(CMBEMPCODE.Text.Trim)
            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(CMBDESIGNATION.Text.Trim)
            alParaval.Add(TXTENROLLNO.Text.Trim)

            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(txtpanno.Text.Trim)
            alParaval.Add(TXTPFNO.Text.Trim)
            alParaval.Add(CMBSALMODE.Text.Trim)
            alParaval.Add(TXTACNO.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtimgpath.Text.Trim)
            alParaval.Add(TXTOURLOCATION.Text.Trim)

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


            Dim objEMPLOYEEMASTER As New ClsEmployeeMaster
            objEMPLOYEEMASTER.alParaval = alParaval
            objEMPLOYEEMASTER.frmstring = frmstring


            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objEMPLOYEEMASTER.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPEMPID)
                IntResult = objEMPLOYEEMASTER.update()
                edit = False
                MsgBox("Details Updated")
            End If

            clear()
            CMBEMPNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        CMBEMPNAME.Text = ""
        CMBEMPCODE.Text = ""
        CMBDEPARTMENT.Text = ""
        CMBDESIGNATION.Text = ""
        TXTENROLLNO.Clear()

        txtresino.Clear()
        txttel1.Clear()
        txtaltno.Clear()
        txtmobile.Clear()
        cmbemail.Text = ""

        cmbarea.Text = ""
        cmbcity.Text = ""
        txtzipcode.Clear()
        cmbcountry.Text = ""
        cmbstate.Text = ""


        txtpanno.Clear()
        TXTPFNO.Clear()
        CMBSALMODE.SelectedIndex = 0
        TXTACNO.Clear()

        TXTDEDSRNO.Clear()
        CMBDEDUCTION.Text = ""
        TXTDEDAMT.Clear()
        GRIDDED.RowCount = 0

        TXTEARSRNO.Clear()
        CMBEARNINGS.Text = ""
        TXTEARAMT.Clear()
        GRIDEAR.RowCount = 0


        TXTFILENAME.Clear()
        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        PBIMG.ImageLocation = ""

        GRIDDOUBLECLICK = False
        GRIDEARDOUBLECLICK = False

        txtadd.Clear()
        txtremarks.Clear()

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
        GRIDEAR.FirstDisplayedScrollingRowIndex = GRIDEAR.RowCount - 1

        TXTEARSRNO.Clear()
        CMBEARNINGS.Text = ""
        TXTEARAMT.Clear()
        TXTEARSRNO.Focus()

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBEMPNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBEMPNAME, "Fill Employee Name")
            bln = False
        End If

        If CMBEMPCODE.Text.Trim.Length = 0 Then
            EP.SetError(CMBEMPCODE, "Fill Employee Code")
            bln = False
        End If

        If CMBDEPARTMENT.Text.Trim.Length = 0 Then
            EP.SetError(CMBDEPARTMENT, "Select Department")
            bln = False
        End If

        If CMBDESIGNATION.Text.Trim.Length = 0 Then
            EP.SetError(CMBDESIGNATION, "Select Designation")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
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

    Private Sub cmbstate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.Enter
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
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

    Private Sub cmbcountry_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.Enter
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(cmbcountry.Text)
                                cmbcountry.Text = a
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

    Private Sub cmbarea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.Enter
        Try
            If cmbarea.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    cmbarea.DataSource = dt
                    cmbarea.DisplayMember = "area_name"
                    cmbarea.Text = ""
                End If
                cmbarea.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then
                pcase(cmbarea)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbarea.Text.Trim
                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbarea.Text = a
                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbarea.DataSource
                        If cmbarea.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbarea.Text)
                                cmbarea.Text = a
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

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numkeypress(e, txtmobile, Me)
    End Sub

    Private Sub CMBEMPNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEMPNAME.Enter
        Try
            If CMBEMPNAME.Text.Trim = "" Then
                FILLCMPNAME()
                CMBEMPNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBEMPNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBEMPNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBEMPNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBEMPNAME.Validating
        Try
            If CMBEMPNAME.Text.Trim <> "" Then
                pcase(CMBEMPNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBEMPNAME.Text) <> LCase(TEMPEMPNAME)) Then
                    dt = objclscommon.search("EMP_NAME", "", " EMPLOYEEMASTER", " AND EMP_NAME = '" & CMBEMPNAME.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPEMPNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJACC As New ClsEmployeeMaster
                OBJACC.alParaval = ALPARAVAL
                OBJACC.frmstring = frmstring
                Dim DT As DataTable = OBJACC.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEMPCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEMPCODE.Enter
        Try
            If CMBEMPCODE.Text.Trim = "" Then
                FILLCMPCODE()
                CMBEMPCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBEMPCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBEMPCODE.Validating
        Try
            If CMBEMPCODE.Text.Trim <> "" Then
                pcase(CMBEMPCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBEMPCODE.Text) <> LCase(TEMPEMPCODE)) Then
                    dt = objclscommon.search("EMP_CODE", "", " EMPLOYEEMASTER", " AND EMP_CODE = '" & CMBEMPCODE.Text.Trim & "' AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Code Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click


        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()

        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\EMPLOYEE IMAGES") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\EMPLOYEE IMAGES")

        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        TXTOURLOCATION.Text = Application.StartupPath & "\EMPLOYEE IMAGES\" & CMBEMPNAME.Text.Trim & TXTFILENAME.Text.Trim
        txtimgpath.Text = OpenFileDialog1.FileName

        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then PBIMG.ImageLocation = txtimgpath.Text.Trim
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            PBIMG.ImageLocation = ""
            txtimgpath.Clear()
            TXTOURLOCATION.Clear()
            TXTFILENAME.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBIMG.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
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

    Private Sub CMBDEDUCTION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEDUCTION.Enter
        Try
            If CMBDEDUCTION.Text.Trim = "" Then fillledger(CMBDEDUCTION, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEDUCTION.Validating
        Try
            If CMBDEDUCTION.Text.Trim <> "" Then ledgervalidate(CMBDEDUCTION, CMBACCCODE, e, Me, TXTDEDADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEARNINGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEARNINGS.Enter
        Try
            If CMBEARNINGS.Text.Trim = "" Then fillledger(CMBEARNINGS, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEARNINGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBEARNINGS.Validating
        Try
            If CMBEARNINGS.Text.Trim <> "" Then ledgervalidate(CMBEARNINGS, CMBACCCODE, e, Me, TXTDEDADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNATION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNATION.Enter
        Try
            If CMBDESIGNATION.Text.Trim = "" Then fillDESIGNATION(CMBDESIGNATION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNATION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNATION.Validating
        Try
            If CMBDESIGNATION.Text.Trim <> "" Then DESIGNATIONVALIDATE(CMBDESIGNATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class