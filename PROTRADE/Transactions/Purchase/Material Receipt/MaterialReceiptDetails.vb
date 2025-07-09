
Imports BL
Imports System.Windows.Forms

Public Class MaterialReceiptDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MaterialReceiptDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub MaterialReceiptDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.MATERIALRECEIPT.MATREC_yearid=" & YearId & " order by dbo.MATERIALRECEIPT.MATREC_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" MATERIALRECEIPT.MATREC_NO AS SRNO, MATERIALRECEIPT.MATREC_CHALLANNO AS CHALLANNO, MATERIALRECEIPT.MATREC_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO AS LOTNO, ISNULL(MATERIALRECEIPT_DESC.MATREC_QTY, 0) AS PCS, ISNULL(MATERIALRECEIPT_DESC.MATREC_MTRS, 0) AS MTRS, ISNULL(MATERIALRECEIPT_DESC.MATREC_RECDMTRS, 0) AS RECDMTRS, ISNULL(MATERIALRECEIPT_DESC.MATREC_DIFF, 0) AS DIFF, ISNULL(MATERIALRECEIPT.MATREC_remarks, '') AS REMARKS, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO ,ISNULL(MATERIALRECEIPT_DESC.MATREC_BALENO, '') AS BALENO, ISNULL(MATERIALRECEIPT.MATREC_CONTDESIGNRECD, 0) AS CONTDESIGNRECD", "", " MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_ledgerid = LEDGERS.Acc_id INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID LEFT OUTER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON MATERIALRECEIPT_DESC.MATREC_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON MATERIALRECEIPT_DESC.MATREC_DESIGNID = DESIGNMASTER.DESIGN_id ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal MATRECNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMATREC As New MaterialReceipt
                OBJMATREC.MdiParent = MDIMain
                OBJMATREC.edit = editval
                OBJMATREC.TEMPMATRECNO = MATRECNO
                OBJMATREC.Show()
                'Me.Close()
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

            Dim PATH As String = Application.StartupPath & "\Material Receipt Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Dyeing Receipt Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Dyeing Receipt Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Dyeing Rec Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub MaterialReceiptDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "AVIS" Then GCONTDESIGNRECD.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class