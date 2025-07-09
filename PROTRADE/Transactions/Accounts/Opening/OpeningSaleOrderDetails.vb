
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class OpeningSaleOrderDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.OPENINGSALEORDER.OPSO_yearid=" & YearId & " order by dbo.OPENINGSALEORDER.OPSO_no, OPENINGSALEORDER_DESC.OPSO_GRIDSRNO  ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" OPENINGSALEORDER.OPSO_no AS OPSONO, OPENINGSALEORDER.OPSO_date AS OPSODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, OPENINGSALEORDER.OPSO_pono AS PARTYPONO, OPENINGSALEORDER.OPSO_DUEDATE AS DELDATE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(OPENINGSALEORDER_DESC.OPSO_PARTYPONO,'') AS GRIDPARTYPONO, ISNULL(OPSO_GRIDREMARKS,'') AS GRIDREMARKS, OPENINGSALEORDER_DESC.OPSO_QTY AS PCS, OPENINGSALEORDER_DESC.OPSO_CUT AS CUT, OPENINGSALEORDER_DESC.OPSO_RATE AS RATE, OPENINGSALEORDER_DESC.OPSO_QTY- OPENINGSALEORDER_DESC.OPSO_RECDQTY AS BALPCS, OPSO_REMARKS AS REMARKS, ISNULL(OPSO_CLOSED,0) AS CLOSED ", "", " OPENINGSALEORDER_DESC INNER JOIN OPENINGSALEORDER ON OPENINGSALEORDER_DESC.OPSO_NO = OPENINGSALEORDER.OPSO_no AND OPENINGSALEORDER_DESC.OPSO_YEARID = OPENINGSALEORDER.OPSO_YEARID INNER JOIN LEDGERS ON OPENINGSALEORDER.OPSO_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON OPENINGSALEORDER_DESC.OPSO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON OPENINGSALEORDER_DESC.OPSO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON OPENINGSALEORDER_DESC.OPSO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGSALEORDER.OPSO_Agentid = AGENTLEDGERS.Acc_id ", TEMPCONDITION
)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SOno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New OpeningSaleOrder
                objPO.MdiParent = MDIMain
                objPO.EDIT = editval
                objPO.TEMPOPSONO = SOno
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
            showform(True, gridbill.GetFocusedRowCellValue("OPSONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("OPSONO"))
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
                    e.Appearance.BackColor = Color.LightSkyBlue
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("SO Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class