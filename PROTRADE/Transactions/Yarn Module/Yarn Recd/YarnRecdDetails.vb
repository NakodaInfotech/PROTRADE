
Imports BL
Imports System.Windows.Forms

Public Class YarnRecdDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING, TYPE As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            'If FRMSTRING = "YARNRECD" Then
            '    Me.Text = "Yarn Receieved In Godown"
            '    gridbill.Columns("TONAME").Visible = False
            '    'gridbill.Columns("LOTNO").Visible = False
            '    gridbill.Columns("LOTDATE").Visible = False
            'End If

            fillgrid(" and YARNRECD.YARN_type='" & FRMSTRING & "' and dbo.YARNRECD.YARN_yearid=" & YearId & " order by dbo.YARNRECD.YARN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJDEPT As New ClsYarnRecd
            OBJDEPT.alParaval.Add(0)
            OBJDEPT.alParaval.Add(CmpId)
            OBJDEPT.alParaval.Add(Locationid)
            OBJDEPT.alParaval.Add(YearId)

            Dim DT As DataTable = OBJDEPT.selectYARN(0, CmpId, Locationid, YearId)
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SRNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objGRN As New YarnRecd
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.tempYARNno = SRNO
                objGRN.FRMSTRING = FRMSTRING
                objGRN.TYPE = TYPE
                objGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and YARNRECD.YARN_type='" & FRMSTRING & "' and dbo.YARNRECD.YARN_yearid=" & YearId & " order by dbo.YARNRECD.YARN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("YARNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("YARNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Yarn Received Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Received Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Received Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Recd Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub YarnRecdDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.Text = "Yarn Recd (" & TYPE & ")"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class