
Imports BL

Public Class JobInGridDetails

    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JobInGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub JobInGridDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB IN'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" AND dbo.JOBIN.JI_yearid=" & YearId & " order by dbo.JOBIN.JI_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName = "SVS" Then
                lbl.Text = "For Packing Details"
                Me.Text = "For Packing Details"
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" JOBIN.JI_no AS SRNO, JOBIN.JI_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, JOBIN.JI_TOTALQTY AS TOTALPCS, JOBIN.JI_TOTALMTRS AS TOTALMTRS, ISNULL(JI_JOBOUTNO,0) AS JONO, ISNULL(JOBIN.JI_remarks, '') AS REMARKS, ISNULL(JOBIN.JI_LOTNO,'') AS LOTNO, PIECETYPEMASTER.PIECETYPE_name AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY,  ISNULL(JOBIN_DESC.JI_BALENO, '') AS BALENO, ISNULL(OLDDESIGNMASTER.DESIGN_NO, '') AS OLDDESIGN, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(JOBIN_DESC.JI_CUT, 0) AS CUT, ISNULL(JOBIN_DESC.JI_WT, 0) AS WT, ISNULL(JOBIN_DESC.JI_QTY, 0) AS PCS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBIN_DESC.JI_MTRS, 0) AS MTRS, ISNULL(JOBIN_DESC.JI_BARCODE, '') AS BARCODE", "", "  PROCESSMASTER RIGHT OUTER JOIN JOBIN INNER JOIN  JOBIN_DESC ON JOBIN.JI_no = JOBIN_DESC.JI_NO AND JOBIN.JI_cmpid = JOBIN_DESC.JI_CMPID AND JOBIN.JI_locationid = JOBIN_DESC.JI_LOCATIONID AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID INNER JOIN PIECETYPEMASTER ON JOBIN_DESC.JI_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ON PROCESSMASTER.PROCESS_ID = JOBIN.JI_PROCESSID LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON JOBIN.JI_PURLEDGERID = PURLEDGERS.Acc_id LEFT OUTER JOIN SHELFMASTER ON JOBIN_DESC.JI_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN RACKMASTER ON JOBIN_DESC.JI_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN DESIGNMASTER AS OLDDESIGNMASTER ON JOBIN_DESC.JI_OLDDESIGNID = OLDDESIGNMASTER.DESIGN_id LEFT OUTER JOIN GODOWNMASTER ON JOBIN.ji_godownid = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON JOBIN_DESC.JI_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON JOBIN_DESC.JI_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBIN.JI_transledgerid = TRANSLEDGERS.Acc_id ", TEMPCONDITION)
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
                Dim objREQ As New JobIn
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPJOBINNO = JONO
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

            Dim PATH As String = Application.StartupPath & "\Job In Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job In Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job In Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job In Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JobInGridDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "INDRANI" Then
                GBALENO.Caption = "SO No"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class