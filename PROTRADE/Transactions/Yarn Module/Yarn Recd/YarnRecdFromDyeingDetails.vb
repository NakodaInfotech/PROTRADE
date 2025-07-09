
Imports BL
Imports System.Windows.Forms

Public Class YarnRecdFromDyeingDetails
    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
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

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" GRN.grn_no AS SRNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.grn_challanno AS CHALLANNO, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN_DESC.GRN_QTY, 0) AS PCS, ISNULL(GRN_DESC.GRN_MTRS, 0) AS MTRS, ISNULL(GRN.GRN_PLOTNO,'') AS LOTNO, (CASE WHEN GRN.GRN_PLOTNO = '' THEN '' ELSE CAST(GRN.GRN_RECDATE AS VARCHAR) END) AS LOTDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME, '') AS SHADE ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.GRN_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GRN.GRN_TOLEDGERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON COLOR_ID = GRN_DESC.GRN_COLORID ", TEMPCONDITION)
            dt = objclsCMST.search(" ISNULL(YARNRECDDYEING.YARNRECD_NO, 0) AS SRNO, ISNULL(YARNRECDDYEING.YARNRECD_DATE, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpame, '') AS NAME, ISNULL(YARNRECDDYEING.YARNRECD_LOTNO, '0') AS LOTNO, ISNULL(YARNRECDDYEING.YARNRECD_CHALLANNO, '') AS CHALLANNO, ISNULL(YARNRECDDYEING.YARNRECD_CHALLANDATE, GETDATE()) AS CHALLANDATE, ISNULL(LEDGERS_1.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNRECDDYEING.YARNRECD_LRNO, '') AS LRNO, ISNULL(YARNRECDDYEING.YARNRECD_LRDATE, GETDATE()) AS LRDATE, ISNULL(YARNRECDDYEING.YARNRECD_TOTALBAGS, 0) AS TOTALBAGS, ISNULL(YARNRECDDYEING.YARNRECD_TOTALWT, 0) AS TOTALWT, ISNULL(YARNRECDDYEING.YARNRECD_REMARKS, '') AS REMARKS, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITYDESIGN, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLORNAME, ISNULL(YARNRECDDYEING_DESC.YARNRECD_BAGS, 0) AS BAGS, ISNULL(YARNRECDDYEING_DESC.YARNRECD_WT, 0) AS WT ", "", " YARNRECDDYEING INNER JOIN GODOWNMASTER ON YARNRECDDYEING.YARNRECD_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON YARNRECDDYEING.YARNRECD_LEDGERID = LEDGERS.Acc_id INNER JOIN YARNRECDDYEING_DESC ON YARNRECDDYEING.YARNRECD_NO = YARNRECDDYEING_DESC.YARNRECD_NO AND YARNRECDDYEING.YARNRECD_YEARID = YARNRECDDYEING_DESC.YARNRECD_YEARID INNER JOIN MILLMASTER ON YARNRECDDYEING_DESC.YARNRECD_MILLID = MILLMASTER.MILL_ID INNER JOIN YARNQUALITYMASTER ON YARNRECDDYEING_DESC.YARNRECD_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN DESIGNMASTER ON YARNRECDDYEING_DESC.YARNRECD_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON YARNRECDDYEING_DESC.YARNRECD_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON YARNRECDDYEING.YARNRECD_TRANSID = LEDGERS_1.Acc_id ", TEMPCONDITION)

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
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
                Dim objGRN As New YarnRecdFromDyeing
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.tempYARNno = SRNO
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid("and dbo.YARNRECDdyeing.YARNrecd_yearid=" & YearId & " order by dbo.YARNRECDdyeing.YARNrecd_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Yarn Received Dyeing Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Received Dyeing Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Received Dyeing Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Recd Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub YarnRecdFromDyeingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            fillgrid("and dbo.YARNRECDdyeing.YARNrecd_yearid=" & YearId & " order by dbo.YARNRECDdyeing.YARNrecd_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid("and dbo.YARNRECDdyeing.YARNrecd_yearid=" & YearId & " order by dbo.YARNRECDdyeing.YARNrecd_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class