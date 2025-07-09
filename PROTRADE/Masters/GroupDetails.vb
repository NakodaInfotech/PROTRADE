
Imports BL

Public Class GroupDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub GroupDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Then
            showform(False, "")
        End If
    End Sub

    Private Sub GroupDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GROUP MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objClsCommon As New ClsCommonMaster
            Dim dttable As DataTable = objClsCommon.search(" group_name AS GROUPNAME, group_under AS UNDERGROUP", "", "groupmaster", " and group_yearid = " & YearId)
            GRIDBILLDETAILS.DataSource = dttable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgroupmaster As New GroupMaster
            objgroupmaster.EDIT = editval
            objgroupmaster.MdiParent = MDIMain
            objgroupmaster.tempGroupname = name
            objgroupmaster.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
   
    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDGROUP.GetFocusedRowCellValue("GROUPNAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGROUP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDGROUP.DoubleClick
        Try
            showform(True, GRIDGROUP.GetFocusedRowCellValue("GROUPNAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Group Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Group Details"
            GRIDGROUP.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Group Details", GRIDGROUP.VisibleColumns.Count + GRIDGROUP.GroupCount)
        Catch ex As Exception
            MsgBox("Group Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()

    End Sub
End Class
