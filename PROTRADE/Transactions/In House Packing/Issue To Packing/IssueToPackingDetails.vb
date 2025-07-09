
Imports BL
Imports System.Windows.Forms

Public Class IssueToPackingDetails
    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Public Where As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub IssueToPackingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub IssueToPackingDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        fillgrid(" AND dbo.ISSUEPACKING.ISS_yearid=" & YearId & " order by dbo.ISSUEPACKING.ISS_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName = "SVS" Then
                Me.Text = "For Issue Packing Details"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(ISSUEPACKING.ISS_no, 0) AS SRNO, ISNULL(ISSUEPACKING.ISS_date, GETDATE()) AS DATE, ISNULL(ISSUEPACKING.ISS_REFNO, '') AS REFNO,  ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(ISSUEPACKING_DESC.ISS_PCS, 0) AS PCS, ISNULL(ISSUEPACKING_DESC.ISS_MTRS, 0) AS MTRS,  ISNULL(ISSUEPACKING.ISS_remarks, '') AS REMARKS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO,  ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(ISSUEPACKING_DESC.ISS_BARCODE, '') AS BARCODE, ISNULL(ISSUEPACKING_DESC.ISS_MTRS, 0)  - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0) AS BALMTRS, ISNULL(CONTRACTMASTER.CONTRACT_NAME,'') AS CONTRACTOR, ISNULL(ISSUEPACKING.ISS_SLTP,0) AS SLTP, ISNULL(WEAVERLEDGERS.ACC_CMPNAME,'') AS WEAVERNAME, ISNULL(ISSUEPACKING.ISS_WEAVERCHNO,'') AS WEAVERCHNO, ISNULL(ISSUEPACKING.ISS_CHALLANNO,'') AS CHALLANNO, ISNULL(UNITMASTER.UNIT_ABBR,'') AS UNIT ", "", "   ISSUEPACKING INNER JOIN GODOWNMASTER ON ISSUEPACKING.ISS_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN ISSUEPACKING_DESC ON ISSUEPACKING.ISS_no = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_yearid = ISSUEPACKING_DESC.ISS_YEARID INNER JOIN ITEMMASTER ON ISSUEPACKING_DESC.ISS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON ISSUEPACKING_DESC.ISS_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON ISSUEPACKING_DESC.ISS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN CONTRACTMASTER ON ISSUEPACKING.ISS_CONTRACTID = CONTRACTMASTER.CONTRACT_ID LEFT OUTER JOIN LEDGERS AS WEAVERLEDGERS ON ISSUEPACKING.ISS_WEAVERID = WEAVERLEDGERS.ACC_ID LEFT OUTER JOIN UNITMASTER ON ISSUEPACKING_DESC.ISS_UNITID = UNITMASTER.UNIT_ID ", Where & TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ISSUENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New IssueToPacking
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPISSUENO = ISSUENO
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
            Dim PATH As String = Application.StartupPath & "\Issue To Packing Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Issue To Packing Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Issue To Packing Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Issue Packing Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub IssueToPackingDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "KARAN" Then
                GWEAVERNAME.Visible = True
                GWEAVERCHNO.Visible = True
                GCHALLANNO.Visible = True
                GGREYMTRS.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class