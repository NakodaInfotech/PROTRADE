Imports BL

Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class OpeningPurchaseOrderDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PurchaseOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.OPENINGPURCHASEORDER.OPO_yearid=" & YearId & " order by dbo.OPENINGPURCHASEORDER.OPO_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJOPO As New ClsOpeningPurchaseOrder()
            'Dim dt As DataTable = objclsCMST.search(" DISTINCT OPENINGPURCHASEORDER.OPO_NO AS SRNO, OPENINGPURCHASEORDER.OPO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, OPENINGPURCHASEORDER.OPO_TOTALQTY AS TOTALQTY,OPENINGPURCHASEORDER.OPO_REFNO AS ORDERNO , OPENINGPURCHASEORDER.OPO_TOTALMTRS AS TOTALMTRS, OPENINGPURCHASEORDER.OPO_GRANDTOTAL AS TOTALAMT, CAST(OPENINGPURCHASEORDER.OPO_REMARKS AS VARCHAR(MAX)) AS REMARKS, OPENINGPURCHASEORDER_DESC.OPO_DONE  AS DONE, OPENINGPURCHASEORDER_DESC.OPO_CLOSED AS CLOSED ", "", "  OPENINGPURCHASEORDER INNER JOIN LEDGERS ON OPENINGPURCHASEORDER.OPO_LEDGERID = LEDGERS.Acc_id INNER JOIN OPENINGPURCHASEORDER_DESC ON OPENINGPURCHASEORDER.OPO_NO = OPENINGPURCHASEORDER_DESC.OPO_NO AND OPENINGPURCHASEORDER.OPO_YEARID = OPENINGPURCHASEORDER_DESC.OPO_YEARID ", TEMPCONDITION)
            Dim dt As DataTable = OBJOPO.selectopo(0, CmpId, 0, YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal OPONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New OpeningPurchaseOrder
                objPO.MdiParent = MDIMain
                objPO.EDIT = editval
                objPO.TEMPOPONO = OPONO
                objPO.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("OPONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("OPONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("PO Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
