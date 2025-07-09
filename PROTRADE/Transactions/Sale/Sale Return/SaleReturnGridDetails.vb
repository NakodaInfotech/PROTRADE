
Imports BL
Imports System.Windows.Forms

Public Class SaleReturnGridDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SaleReturnGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SaleReturnGridDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            fillgrid(" and SALERETURN.SALRET_yearid=" & YearId & " order by SALERETURN.SALRET_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" SALERETURN.SALRET_NO AS SRNO, SALERETURN.SALRET_DATE AS DATE, SALERETURN.SALRET_CHALLANDATE AS CHALLANDATE, ISNULL(SALERETURN.SALRET_CHALLANNO, '') AS CHALLANNO, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(SALERETURN.SALRET_EWAYBILLNO, '') AS EWAYBILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(SALERETURN.SALRET_GRANDTOTAL, 0) AS GTOTAL, ISNULL(SALERETURN.SALRET_remarks, '') AS REMARKS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(SALERETURN_DESC.SALRET_QTY, 0) AS PCS, ISNULL(SALERETURN_DESC.SALRET_MTRS, 0) AS MTRS, ISNULL(SALERETURN.SALRET_INVOICENO, '') AS INVOICENO, ISNULL(SALERETURN.SALRET_INVOICEDATE, GETDATE()) AS INVOICEDATE, ISNULL(SALERETURN_DESC.SALRET_AMT, 0) AS AMT, ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0) AS CGSTAMT, ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0) AS SGSTAMT, ISNULL(SALERETURN.SALRET_SGSTPER, 0) AS SGSTPER, ISNULL(SALERETURN.SALRET_CGSTPER, 0) AS CGSTPER, ISNULL(SALERETURN.SALRET_IGSTPER, 0) AS IGSTPER, ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0) AS IGSTAMT, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(SALERETURN.SALRET_LRNO, '') AS LRNO, (CASE WHEN ISNULL(SALERETURN.SALRET_LRNO, '') = '' THEN NULL ELSE SALRET_LRDATE END) AS LRDATE, ISNULL(SALERETURN_DESC.SALRET_BALENO, '') AS BALENO, ISNULL(agentLEDGERS.Acc_cmpname, '') AS AGENT, ISNULL(SALERETURN.SALRET_PARTYREFNO, '') AS PARTYREFNO, ISNULL(DEBITLEDGERS.Acc_cmpname, '') AS DEBITNAME, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS DELIVERYAT  ", "", " SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id INNER JOIN SALERETURN_DESC ON SALERETURN.SALRET_NO = SALERETURN_DESC.SALRET_NO AND SALERETURN.SALRET_yearid = SALERETURN_DESC.SALRET_YEARID INNER JOIN ITEMMASTER ON SALERETURN_DESC.SALRET_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SALERETURN_DESC.SALRET_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SALERETURN_DESC.SALRET_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS agentLEDGERS ON SALERETURN.SALRET_AGENTID = agentLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS DEBITLEDGERS ON SALERETURN.SALRET_DEBITLEDGERID = DEBITLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON SALERETURN.SALRET_DELIVERYATID = PACKINGLEDGERS.Acc_id ", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SALRETNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJSALRET As New SaleReturn
                OBJSALRET.MdiParent = MDIMain
                OBJSALRET.EDIT = editval
                OBJSALRET.TEMPSALRETNO = SALRETNO
                OBJSALRET.Show()
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

            Dim PATH As String = Application.StartupPath & "\Sale Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Sale Return Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class