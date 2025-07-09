
Imports BL

Public Class ManualMatchingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PAYREGID As Integer

    Private Sub ManualMatchingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" MANUALMATCHING.MATCH_NO AS MATCHNO, MANUALMATCHING.MATCH_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, MANUALMATCHING.MATCH_TYPE AS TYPE, MANUALMATCHING.MATCH_BILLNO AS BILLNO, ISNULL(REGISTERMASTER.register_name, '') AS REGNAME, ISNULL(MANUALMATCHING.MATCH_BILLINITIALS, '') AS BILLINITIALS, ISNULL(MANUALMATCHING.MATCH_BILLAMT, 0) AS BILLAMT, ISNULL(MANUALMATCHING.MATCH_BALAMT, 0) AS BALAMT, ISNULL(MANUALMATCHING.MATCH_TOTALBAL, 0) AS TOTALBAL, ISNULL(MANUALMATCHING.MATCH_TOTALPAID, 0) AS TOTALPAID, ISNULL(MANUALMATCHING.MATCH_REMARKS, '') AS REMARKS ", "", " MANUALMATCHING INNER JOIN LEDGERS ON MANUALMATCHING.MATCH_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN REGISTERMASTER ON MANUALMATCHING.MATCH_REGID = REGISTERMASTER.register_id ", " AND MANUALMATCHING.MATCH_YEARID =" & YearId)
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                GRIDMATCH.FocusedRowHandle = GRIDMATCH.RowCount - 1
                GRIDMATCH.TopRowIndex = GRIDMATCH.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal MATCHNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (EDITVAL = False) Or (EDITVAL = True And GRIDMATCH.RowCount > 0) Then
                Dim OBJMATCH As New ManualMatching
                OBJMATCH.MdiParent = MDIMain
                OBJMATCH.EDIT = EDITVAL
                OBJMATCH.TEMPMATCHNO = MATCHNO
                OBJMATCH.Show()
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDMATCH.DoubleClick
        Try
            showform(True, GRIDMATCH.GetFocusedRowCellValue("MATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ManualMatchingDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDMATCH.GetFocusedRowCellValue("MATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Matching Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Matching Details"
            GRIDMATCH.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Matching Details", GRIDMATCH.VisibleColumns.Count + GRIDMATCH.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Matching Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class