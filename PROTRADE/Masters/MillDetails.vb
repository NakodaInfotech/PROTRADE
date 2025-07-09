
Imports BL

Public Class MillDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Sub FILLGRID()
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDEPT As New ClsMillMaster
            OBJDEPT.alParaval.Add(0)
            OBJDEPT.alParaval.Add(YearId)
            Dim DT As DataTable = OBJDEPT.GETMILL
            GRIDBILLDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal ID As Integer)
        Try

            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDEPT As New MillMaster
            OBJDEPT.MdiParent = MDIMain
            OBJDEPT.EDIT = EDITVAL
            OBJDEPT.tempid = ID
            OBJDEPT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ExcelExport_Click(sender As Object, e As EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Mill Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Mill Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Mill Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox("Mill Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MillDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MillDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class