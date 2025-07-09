
Imports BL
Imports System.Windows.Forms

Public Class JobOutDetailReport
    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Public Where As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JOBOUTDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobOutDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB OUT'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" AND dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName = "SVS" Then
                lbl.Text = "For Packing Details"
                Me.Text = "For Packing Details"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" JOBOUT.JO_no AS SRNO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(JOBOUT.JO_CHALLANNO, 0) AS CHALLANNO, JOBOUT.JO_TOTALPCS AS TOTALPCS, JOBOUT.JO_TOTALMTRS AS TOTALMTRS, JOBOUT.JO_RECDMTRS AS RECDMTRS, ROUND(JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS, 2) AS BALMTRS, ISNULL(JOBOUT.JO_remarks, '') AS REMARKS, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(JOBOUT_DESC.JO_BALENO, '') AS BALENO", "", "  JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id AND JOBOUT.JO_cmpid = LEDGERS.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS.Acc_yearid INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_yearid = GODOWNMASTER.GODOWN_yearid AND JOBOUT.JO_locationid = GODOWNMASTER.GODOWN_locationid AND JOBOUT.JO_cmpid = GODOWNMASTER.GODOWN_cmpid AND JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN PROCESSMASTER ON PROCESSMASTER.PROCESS_ID = JOBOUT.JO_PROCESSID", Where & TEMPCONDITION)
            dt = objclsCMST.search(" JOBOUT.JO_no AS SRNO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(JOBOUT.JO_CHALLANNO, 0) AS CHALLANNO, JOBOUT_DESC.JO_PCS AS PCS, JOBOUT_DESC.JO_MTRS AS MTRS, ISNULL(JOBOUT.JO_remarks, '') AS REMARKS, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(JOBOUT_DESC.JO_BALENO, '') AS BALENO", "", "  JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id AND JOBOUT.JO_cmpid = LEDGERS.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS.Acc_yearid INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_yearid = GODOWNMASTER.GODOWN_yearid AND JOBOUT.JO_locationid = GODOWNMASTER.GODOWN_locationid AND JOBOUT.JO_cmpid = GODOWNMASTER.GODOWN_cmpid AND JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN PROCESSMASTER ON PROCESSMASTER.PROCESS_ID = JOBOUT.JO_PROCESSID", Where & TEMPCONDITION)

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal JONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New JobOut
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPJONO = JONO
                objREQ.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = "D:\Job Out Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JobOutDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Then
                GPROCESS.Visible = True
                GPROCESS.VisibleIndex = GREMARKS.VisibleIndex
            End If
            If ClientName = "MANINATH" Or ClientName = "KANVASU" Then
                GCHALLANNO.Caption = "Lot No"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class