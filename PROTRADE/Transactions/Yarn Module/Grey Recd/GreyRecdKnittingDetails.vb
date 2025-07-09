
Imports BL
Imports System.Windows.Forms

Public Class GreyRecdKnittingDetails

    Public EDIT As Boolean
    Dim TEMPGREYNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyRecdKnittingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GreyRecdKnittingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.GREYRECDKNITTING.GREY_yearid=" & YearId & " order by dbo.GREYRECDKNITTING.GREY_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("ISNULL(GREYRECDKNITTING.GREY_no, 0) AS SRNO, ISNULL(GREYRECDKNITTING.GREY_date, GETDATE()) AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GREYRECDKNITTING.GREY_challanno, '') AS CHALLANNO, ISNULL(GREYRECDKNITTING.GREY_CHALLANDATE, GETDATE()) AS CHALLANDATE, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(GREYRECDKNITTING.GREY_LRNO, '') AS LRNO, ISNULL(GREYRECDKNITTING.GREY_LRDATE, GETDATE()) AS LRDATE, ISNULL(GREYRECDKNITTING.GREY_TOTALQTY, 0) AS TOTALQTY, ISNULL(GREYRECDKNITTING.GREY_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(GREYRECDKNITTING.GREY_TOTALWT, 0) AS TOTALWT, ISNULL(GREYRECDKNITTING.GREY_remarks, '') AS REMARKS,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GREYRECDKNITTING_DESC.GREY_ROLLNO, '') AS ROLLNO, ISNULL(GREYRECDKNITTING_DESC.GREY_QTY, 0) AS QTY, ISNULL(GREYRECDKNITTING_DESC.GREY_MTRS, 0) AS MTRS, ISNULL(GREYRECDKNITTING_DESC.GREY_WT, 0) AS WT", "", "  GODOWNMASTER INNER JOIN GREYRECDKNITTING ON GODOWNMASTER.GODOWN_id = GREYRECDKNITTING.GREY_GODOWNID INNER JOIN LEDGERS ON GREYRECDKNITTING.GREY_LEDGERID = LEDGERS.Acc_id INNER JOIN GREYRECDKNITTING_DESC ON GREYRECDKNITTING.GREY_NO = GREYRECDKNITTING_DESC.GREY_NO AND GREYRECDKNITTING.GREY_yearid = GREYRECDKNITTING_DESC.GREY_YEARID INNER JOIN ITEMMASTER ON GREYRECDKNITTING_DESC.GREY_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN YARNQUALITYMASTER ON GREYRECDKNITTING_DESC.GREY_QUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN DESIGNMASTER ON GREYRECDKNITTING_DESC.GREY_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON GREYRECDKNITTING_DESC.GREY_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GREYRECDKNITTING.GREY_transledgerid = TRANSLEDGERS.Acc_id", TEMPCONDITION)
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
                Dim objGRN As New GreyRecdKnitting
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.TEMPGREYNO = SRNO
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Grey Recd Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Grey Recd Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Grey Recd Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Grey Recd Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        fillgrid(" and dbo.GREYRECDKNITTING.GREY_yearid=" & YearId & " order by dbo.GREYRECDKNITTING.GREY_no ")
    End Sub
End Class