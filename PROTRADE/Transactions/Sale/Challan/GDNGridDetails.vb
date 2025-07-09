
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Views.Grid

Public Class GDNGridDetails

    Public EDIT As Boolean
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
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLCHALLANTYPE(CMBTYPE)
            If ClientName <> "SAFFRON" And ClientName <> "SAFFRONOFF" Then fillgrid(" and dbo.gdn.gdn_yearid=" & YearId & " ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" GDN.GDN_TYPENO AS TYPECHALLANNO, GDN.GDN_NO AS SRNO, ISNULL(GDN.GDN_TRANSREFNO, '') AS CHNO, GDN.GDN_date AS DATE, LEDGERS.Acc_cmpname AS CMPNAME, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, ISNULL(GDN.GDN_CONSIGNEE, '') AS CONSIGNEE, ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, GDN.GDN_SONO AS SONO, GDN.GDN_SODATE AS SODATE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(GDN_DESC.GDN_RATE, 0) AS RATE, GDN_DESC.GDN_PCS AS PCS, GDN_DESC.GDN_MTRS AS MTRS, GDN.GDN_TOTALBALES AS TOTALBALES, GDN.GDN_BALENOFROM AS BALENOFROM, GDN_DESC.GDN_BALENO AS BALENO, ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(GDN.GDN_TRANSREMARKS, '') AS PARTYPONO, ISNULL(GDN_DESC.GDN_GRIDPARTYPONO, '') AS GRIDPARTYPONO, ISNULL(GDN.GDN_HOLDFORAPPROVAL, 0) AS HOLDFORAPPROVAL, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSPORT, GDN_DESC.GDN_BARCODE AS BARCODE, ISNULL(GDN_DESC.GDN_GRIDLOTNO, '') AS GRIDLOTNO", "", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_DESC ON GDN.GDN_NO = GDN_DESC.GDN_NO AND GDN.GDN_YEARID = GDN_DESC.GDN_YEARID INNER JOIN ITEMMASTER ON GDN_DESC.GDN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GDN_DESC.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GDN_DESC.GDN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON GDN.GDN_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GDN.GDN_JOBBERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN CHALLANTYPEMASTER ON CHALLANTYPEMASTER.CHALLANTYPE_ID = GDN.GDN_TYPEID LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON GDN.GDN_DISPATCHTOID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", TEMPCONDITION & " ORDER BY GDN.GDN_NO, GDN_DESC.GDN_SRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal gdnno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New GDN
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPGDNNO = gdnno
                objgdn.Show()
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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Challan Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Challan Details Excel File Is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GDNDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                CMBTYPE.Visible = True
                LBLTYPE.Visible = True
                GTYPECHALLANNO.Visible = True
                GTYPECHALLANNO.VisibleIndex = 0
                gsrno.Visible = False
                GCHALLANNO.Caption = "Ref No."
                CMBTYPE.Focus()
            End If

            If ClientName = "DJIMPEX" Then
                GCHALLANNO.Caption = "Gross Wt"
                GBALENOFROM.Caption = "Container No"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text <> "" And (ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF") Then fillgrid(" And CHALLANTYPE_NAME = '" & CMBTYPE.Text.Trim & "' and dbo.gdn.gdn_yearid=" & YearId & " ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("HOLDFORAPPROVAL")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class