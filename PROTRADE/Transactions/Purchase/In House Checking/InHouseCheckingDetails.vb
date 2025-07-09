
Imports BL
Imports System.Windows.Forms

Public Class InHouseCheckingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

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
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" INHOUSECHECKING.CHECK_NO AS CHECKINGNO, INHOUSECHECKING.CHECK_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, GODOWNMASTER.GODOWN_name AS GODOWN, INHOUSECHECKING.CHECK_LOTNO AS LOTNO, INHOUSECHECKING.CHECK_MATRECNO AS MATRECNO, INHOUSECHECKING.CHECK_CHECKEDBY AS CHECKEDBY, INHOUSECHECKING.CHECK_TOTALGREYMTRS AS GREYMTRS, INHOUSECHECKING.CHECK_TOTALRECDMTRS AS RECDMTRS, INHOUSECHECKING.CHECK_TOTALCHECKEDMTRS AS CHECKEDMTRS, INHOUSECHECKING.CHECK_TOTALDIFF AS DIFF, INHOUSECHECKING.CHECK_TOTALWT AS WT, INHOUSECHECKING.CHECK_TOTALPCS AS PCS, ISNULL(CHECK_SHRINKAGEPER,0) AS SHRINKAGEPER ", "", "   INHOUSECHECKING INNER JOIN LEDGERS ON INHOUSECHECKING.CHECK_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON INHOUSECHECKING.CHECK_GODOWNID = GODOWNMASTER.GODOWN_id ", " AND dbo.INHOUSECHECKING.CHECK_yearid=" & YearId & " order by dbo.INHOUSECHECKING.CHECK_no")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal CHECKINGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJCHECK As New InHouseChecking
                OBJCHECK.MdiParent = MDIMain
                OBJCHECK.EDIT = editval
                OBJCHECK.TEMPCHECKINGNO = CHECKINGNO
                OBJCHECK.Show()
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CHECKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CHECKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Checking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Checking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Checking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Checking Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class