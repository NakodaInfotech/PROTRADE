

Imports BL
Imports System.Windows.Forms

Public Class RecFromPackingDetails
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

        fillgrid(" AND dbo.RECPACKING.REC_yearid=" & YearId & " order by dbo.RECPACKING.REC_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName = "SVS" Then
                lbl.Text = "For Issue Packing Details"
                Me.Text = "For Issue Packing Details"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(RECPACKING.REC_no, 0) AS SRNO, ISNULL(RECPACKING.REC_date, GETDATE()) AS DATE, ISNULL(RECPACKING.REC_REFNO, '') AS REFNO,  ISNULL(RECPACKING.REC_LOTNO, '') AS LOTNO, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(RECPACKING_DESC.REC_QTY, 0) AS PCS, ISNULL(RECPACKING_DESC.REC_MTRS, 0) AS MTRS,  ISNULL(RECPACKING.REC_remarks, '') AS REMARKS, ISNULL(PIECETYPEMASTER.PIECETYPE_NAME,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO,  ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(RECPACKING_DESC.REC_BARCODE, '') AS BARCODE, ISNULL(RECPACKING_DESC.REC_MTRS, 0)  - ISNULL(RECPACKING_DESC.REC_OUTMTRS, 0) AS BALMTRS, ISNULL(RECPACKING.REC_FROMNO,0) AS FROMNO, ISNULL(RECPACKING.REC_OUTBARCODE,'') AS OUTBARCODE, ISNULL(UNITMASTER.UNIT_ABBR,'') AS UNIT, ISSUEPACKING.ISS_DATE AS ISSDATE", "", "   RECPACKING INNER JOIN GODOWNMASTER ON RECPACKING.REC_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN RECPACKING_DESC ON RECPACKING.REC_no = RECPACKING_DESC.REC_NO AND RECPACKING.REC_yearid = RECPACKING_DESC.REC_YEARID INNER JOIN ITEMMASTER ON RECPACKING_DESC.REC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON RECPACKING_DESC.REC_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id  LEFT OUTER JOIN DESIGNMASTER ON RECPACKING_DESC.REC_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON RECPACKING_DESC.REC_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN UNITMASTER ON RECPACKING_DESC.REC_QTYUNITID = UNITMASTER.UNIT_ID INNER JOIN ISSUEPACKING ON RECPACKING.REC_FROMNO = ISSUEPACKING.ISS_NO AND RECPACKING.REC_YEARID = ISSUEPACKING.ISS_YEARID ", Where & TEMPCONDITION)
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
                Dim objREQ As New RecFromPacking
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPRECNO = ISSUENO
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
            Dim PATH As String = Application.StartupPath & "\Rec From Packing Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Rec From Packing Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Rec From Packing Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Rec Packing Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class