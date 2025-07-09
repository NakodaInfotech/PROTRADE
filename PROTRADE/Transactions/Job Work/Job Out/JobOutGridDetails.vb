
Imports BL

Public Class JobOutGridDetails

    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Public Where As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JOBOUTDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub JobOutDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        FILLJOBOUTTYPE(CMBTYPE)
        If ClientName <> "SAFFRON" And ClientName <> "SAFFRONOFF" Then fillgrid(" AND dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" JOBOUT.JO_no AS SRNO,  JOBOUT.JO_TYPENO AS TYPENO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, ISNULL(JOBOUT.JO_CHALLANNO, 0) AS CHALLANNO, JOBOUT.JO_TOTALPCS AS TOTALPCS, JOBOUT.JO_TOTALMTRS AS TOTALMTRS,JOBOUT.JO_RECDMTRS AS RECDMTRS, ROUND((JOBOUT.JO_TOTALMTRS-JOBOUT.JO_RECDMTRS),2) AS BALMTRS, ISNULL(JOBOUT.JO_remarks, '') AS REMARKS, ISNULL(PROCESS_NAME,'') AS PROCESS,JOBOUT.JO_BALENUMBER AS BALENUMBER, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(JOBOUT_DESC.JO_BALENO, '') AS BALENO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name,  '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(JOBOUT_DESC.JO_DESCRIPTION, '') AS DESCRIPTION,  ISNULL(JOBOUT_DESC.JO_CUT, 0) AS CUT, ISNULL(JOBOUT_DESC.JO_PCS, 0) AS PCS, ISNULL(JOBOUT_DESC.JO_MTRS, 0) AS MTRS, ISNULL(JOBOUT_DESC.JO_BARCODE, '') AS BARCODE, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", "  LEDGERS AS TRANSLEDGER RIGHT OUTER JOIN PIECETYPEMASTER RIGHT OUTER JOIN CITYMASTER AS TOCITY RIGHT OUTER JOIN UNITMASTER RIGHT OUTER JOIN LEDGERS INNER JOIN JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID ON LEDGERS.Acc_id = JOBOUT.JO_ledgerid ON  UNITMASTER.unit_id = JOBOUT_DESC.JO_UNITID LEFT OUTER JOIN CITYMASTER AS FROMCITY ON JOBOUT.JO_TRANSCITYID = FROMCITY.city_id ON TOCITY.city_id = JOBOUT.JO_TOCITYID LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON JOBOUT.JO_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN PROCESSMASTER ON JOBOUT.JO_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN LEDGERS AS PARTYLEDGER ON JOBOUT.JO_partyledgerid = PARTYLEDGER.Acc_id LEFT OUTER JOIN DESIGNMASTER ON JOBOUT_DESC.JO_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBOUT_DESC.JO_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id ON PIECETYPEMASTER.PIECETYPE_id = JOBOUT_DESC.JO_PIECETYPEID LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ON TRANSLEDGER.Acc_id = JOBOUT.JO_transledgerid LEFT OUTER JOIN JOBOUTTYPEMASTER ON JOBOUT.JO_TYPEID = JOBOUTTYPEMASTER.JOTYPE_ID ", Where & TEMPCONDITION)
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
                Dim objREQ As New JobOut
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPJONO = JONO
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

            Dim PATH As String = Application.StartupPath & "\Job Out Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JobOutDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                GPROCESS.Visible = True
                gsrno.Visible = False
                GTYPENO.Visible = True
                GTYPENO.VisibleIndex = 0
                GPROCESS.VisibleIndex = GREMARKS.VisibleIndex
                LBLTYPE.Visible = True
                CMBTYPE.Visible = True
            End If

            If ClientName = "INDRANI" Then
                GBALENO.Caption = "SO No"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text <> "" And (ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF") Then fillgrid(" AND JOTYPE_NAME = '" & CMBTYPE.Text.Trim & "'  AND dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class