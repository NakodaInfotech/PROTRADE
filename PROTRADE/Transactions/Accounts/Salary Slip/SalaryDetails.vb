
Imports BL

Public Class SalaryDetails

    Dim BOOKINGREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT


    Private Sub SalaryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" SALARYMASTER.SAL_NO AS SRNO, SALARYMASTER.SAL_DATE AS DATE, EMPLOYEEMASTER.EMP_NAME AS EMPNAME, SALARYMASTER.SAL_MONTH AS MONTH, SALARYMASTER.SAL_WORKDAYS AS WORKDAYS, SALARYMASTER.SAL_PAYDAYS AS PAYDAYS, SALARYMASTER.SAL_LEAVE AS LEAVE, SALARYMASTER.SAL_TOTALDED AS TOTALDED, SALARYMASTER.SAL_TOTALEAR AS TOTALEAR, SALARYMASTER.SAL_NETTPAY AS NETTPAY, SALARYMASTER.SAL_REMARKS AS REMARKS ", "", "     SALARYMASTER INNER JOIN EMPLOYEEMASTER ON SALARYMASTER.SAL_EMPID = EMPLOYEEMASTER.EMP_id AND SALARYMASTER.SAL_CMPID = EMPLOYEEMASTER.EMP_cmpid AND SALARYMASTER.SAL_LOCATIONID = EMPLOYEEMASTER.EMP_locationid AND SALARYMASTER.SAL_YEARID = EMPLOYEEMASTER.EMP_yearid ", TEMPCONDITION & " AND SAL_CMPID = " & CmpId & " AND SAL_LOCATIONID = " & Locationid & " AND SAL_YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SALNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJSAL As New SalaryMaster
                OBJSAL.MdiParent = MDIMain
                OBJSAL.edit = editval
                OBJSAL.TEMPSALNO = SALNO
                OBJSAL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYROLL'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Salary Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Salary Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Salary Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalaryDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class