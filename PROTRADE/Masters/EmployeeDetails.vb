
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class EmployeeDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub EmployeeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
                Call cmdedit_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                Call cmdadd_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EmployeeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'EMPLOYEE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillgridname()
        Dim dttable As New DataTable
        Dim OBJEMP As New ClsEmployeeMaster
        OBJEMP.alParaval.Add("")
        OBJEMP.alParaval.Add(CmpId)
        OBJEMP.alParaval.Add(Locationid)
        OBJEMP.alParaval.Add(YearId)
        dttable = OBJEMP.GETEMPLOYEE()
        gridname.DataSource = dttable
        
    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim OBJEMP As New ClsEmployeeMaster
        OBJEMP.alParaval.Add(name)
        OBJEMP.alParaval.Add(CmpId)
        OBJEMP.alParaval.Add(Locationid)
        OBJEMP.alParaval.Add(YearId)
        dttable = OBJEMP.GETEMPLOYEE

        cleartextbox()

        Dim TEMPEMPID As Integer

        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows
                TEMPEMPID = ROW("EMPID")
                TXTEMPNAME.Text = ROW("EMPNAME")
                TXTCODE.Text = ROW("CODE")
                TXTDEPARTMENT.Text = ROW("DEPARTMENT")
                TXTDESIGNATION.Text = ROW("DESIGNATION")

                txtarea.Text = ROW("AREA")
                txtcity.Text = ROW("CITY")
                txtzipcode.Text = ROW("ZIPCODE")
                txtstate.Text = ROW("STATE")
                txtcountry.Text = ROW("COUNTRY")

                TXTRESINO.Text = ROW("RESINO")
                TXTCONTACTNO.Text = ROW("CONTACTNO")
                txtaltno.Text = ROW("ALTNO")
                txtmobile.Text = ROW("MOBILENO")
                txtemail.Text = ROW("EMAILID")

                txtpanno.Text = ROW("PANNO")
                TXTPFNO.Text = ROW("PFNO")
                TXTSALMODE.Text = ROW("SALMODE")
                TXTACNO.Text = ROW("ACNO")

                txtadd.Text = ROW("ADD")
                txtimgpath.Text = ROW("IMGPATH")
                TXTOURLOCATION.Text = ROW("OURLOCATION")

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


            Next

        End If
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

    Sub cleartextbox()

        TXTEMPNAME.Text = ""
        TXTCODE.Text = ""
        TXTDEPARTMENT.Text = ""
        TXTDESIGNATION.Text = ""

        TXTRESINO.Clear()
        txtaltno.Clear()
        txtmobile.Clear()
        TXTCONTACTNO.Clear()
        txtemail.Text = ""

        txtarea.Text = ""
        txtcity.Text = ""
        txtzipcode.Clear()
        txtcountry.Text = ""
        txtstate.Text = ""


        txtpanno.Clear()
        TXTPFNO.Clear()
        TXTSALMODE.Clear()
        TXTACNO.Clear()

        GRIDDED.RowCount = 0
        GRIDEAR.RowCount = 0


        TXTFILENAME.Clear()
        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        PBIMG.ImageLocation = ""

        txtadd.Clear()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim OBJEMP As New EmployeeMaster
                OBJEMP.MdiParent = MDIMain
                OBJEMP.edit = editval
                OBJEMP.TEMPEMPNAME = name
                OBJEMP.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
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

End Class