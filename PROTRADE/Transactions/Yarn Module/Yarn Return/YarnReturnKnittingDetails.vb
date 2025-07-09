

Imports BL
Imports System.Windows.Forms

Public Class YarnReturnKnittingDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
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
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.YARNKNITTINGRETURN.YARNRET_yearid=" & YearId & " order by dbo.YARNKNITTINGRETURN.YARNRET_NO ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" GRN.grn_no AS SRNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.grn_challanno AS CHALLANNO, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN_DESC.GRN_QTY, 0) AS PCS, ISNULL(GRN_DESC.GRN_MTRS, 0) AS MTRS, ISNULL(GRN.GRN_PLOTNO,'') AS LOTNO, (CASE WHEN GRN.GRN_PLOTNO = '' THEN '' ELSE CAST(GRN.GRN_RECDATE AS VARCHAR) END) AS LOTDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME, '') AS SHADE ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.GRN_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GRN.GRN_TOLEDGERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON COLOR_ID = GRN_DESC.GRN_COLORID ", TEMPCONDITION)
            'dt = objclsCMST.search(" ISNULL(YARNRECD.YARN_no, 0) AS SRNO, ISNULL(YARNRECD.YARN_date, GETDATE()) AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(TONAME.Acc_cmpname, '') AS TONAME, ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNRECD.YARN_PLOTNO, '') AS LOTNO, (CASE WHEN YARNRECD.YARN_PLOTNO = '' THEN '' ELSE CAST(YARNRECD.YARN_RECDATE AS VARCHAR) END) AS LOTDATE, ISNULL(YARNRECD.YARN_challanno, '') AS CHALLANNO, (CASE WHEN YARNRECD.YARN_CHALLANNO = '' THEN '' ELSE CAST(YARNRECD.YARN_CHALLANDT AS VARCHAR) END) AS CHALLANDATE, ISNULL(YARNRECD.YARN_pono, '') AS PONO, (CASE WHEN YARNRECD.YARN_PONO = '' THEN '' ELSE CAST(YARNRECD.YARN_PODATE AS VARCHAR) END) AS PODATE, ISNULL(YARNRECD.YARN_TOTALQTY, 0) AS TOTALQTY, ISNULL(YARNRECD.YARN_TOTALWT, 0) AS TOTALWT, ISNULL(YARNRECD.YARN_TOTALCONES, 0) AS TOTALCONES, ISNULL(YARNRECD.YARN_remarks, '') AS REMARKS ", "", " YARNRECD INNER JOIN LEDGERS ON YARNRECD.YARN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON YARNRECD.YARN_transledgerid = TRANSNAME.Acc_id LEFT OUTER JOIN LEDGERS AS TONAME ON YARNRECD.YARN_TOLEDGERID = TONAME.Acc_id LEFT OUTER JOIN GODOWNMASTER ON YARNRECD.YARN_GODOWNID = GODOWNMASTER.GODOWN_id ", TEMPCONDITION)
            dt = objclsCMST.search(" ISNULL(YARNKNITTINGRETURN.YARNRET_NO, 0) AS SRNO, ISNULL(YARNKNITTINGRETURN.YARNRET_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(YARNKNITTINGRETURN.YARNRET_CHALLANNO, '') AS CHALLANNO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(YARNKNITTINGRETURN.YARNRET_TOTALBAGS, 0) AS TOTALBAGS, ISNULL(YARNKNITTINGRETURN.YARNRET_TOTALWT, 0) AS TOTALWT, ISNULL(YARNKNITTINGRETURN.YARNRET_TOTALCONES, 0) AS TOTALCONES, ISNULL(YARNKNITTINGRETURN.YARNRET_remarks, '') AS REMARKS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS , ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(MILLMASTER.MILL_NAME, '') AS MILL, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(YARNKNITTINGRETURN_DESC.YARNRET_LOTNO, '') AS LOTNO, ISNULL(YARNKNITTINGRETURN_DESC.YARNRET_BAGS, 0) AS BAGS, ISNULL(YARNKNITTINGRETURN_DESC.YARNRET_WT, 0) AS WT, ISNULL(YARNKNITTINGRETURN_DESC.YARNRET_CONES, 0) AS CONES ", "", " YARNKNITTINGRETURN INNER JOIN GODOWNMASTER ON YARNKNITTINGRETURN.YARNRET_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON YARNKNITTINGRETURN.YARNRET_LEDGERID = LEDGERS.Acc_id INNER JOIN PROCESSMASTER ON YARNKNITTINGRETURN.YARNRET_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN YARNKNITTINGRETURN_DESC ON YARNKNITTINGRETURN.YARNRET_NO = YARNKNITTINGRETURN_DESC.YARNRET_NO AND YARNKNITTINGRETURN.YARNRET_yearid = YARNKNITTINGRETURN_DESC.YARNRET_YEARID INNER JOIN YARNQUALITYMASTER ON YARNKNITTINGRETURN_DESC.YARNRET_YARNQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN MILLMASTER ON YARNKNITTINGRETURN_DESC.YARNRET_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN COLORMASTER ON YARNKNITTINGRETURN_DESC.YARNRET_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON YARNKNITTINGRETURN_DESC.YARNRET_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON YARNKNITTINGRETURN.YARNRET_transledgerid = TRANSLEDGERS.Acc_id  ", TEMPCONDITION)
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
                Dim objGRN As New YarnReturnKnitting
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.TEMPYARNKNITTINGRETNO = SRNO
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.YARNKNITTINGRETURN.YARNRET_yearid=" & YearId & " order by dbo.YARNKNITTINGRETURN.YARNRET_NO ")
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

            Dim PATH As String = Application.StartupPath & "\Yarn Return Knitting Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Yarn Return Knitting Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Yarn Return Knitting Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Yarn Return Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid(" and dbo.YARNKNITTINGRETURN.yarnRET_yearid=" & YearId & " order by dbo.YARNKNITTINGRETURN.yarnRET_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class