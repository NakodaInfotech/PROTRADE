Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class QualityDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub RackDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(Optional ByVal WHERE As String = "")
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" QUALITYMASTER.QUALITY_ID AS QUALITYID, QUALITYMASTER.QUALITY_name AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT,QUALITYMASTER.QUALITY_REED AS REED,QUALITYMASTER.QUALITY_PICK AS PICK,QUALITYMASTER.QUALITY_COUNT AS COUNT,QUALITYMASTER.QUALITY_WIDTH AS WIDTH, QUALITYMASTER.QUALITY_remarks AS REMARKS,QUALITYMASTER.QUALITY_WARP AS WARP,QUALITYMASTER.QUALITY_WEFT AS WEFT,QUALITYMASTER.QUALITY_SELVEDGE AS SELVEDGE,ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME ", "", "   QUALITYMASTER LEFT OUTER JOIN PROCESSMASTER ON QUALITYMASTER.QUALITY_processid = PROCESSMASTER.PROCESS_ID AND QUALITYMASTER.QUALITY_cmpid = PROCESSMASTER.PROCESS_CMPID AND QUALITYMASTER.QUALITY_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND QUALITYMASTER.QUALITY_yearid = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_unitid = UNITMASTER.unit_id AND QUALITYMASTER.QUALITY_cmpid = UNITMASTER.unit_cmpid AND QUALITYMASTER.QUALITY_locationid = UNITMASTER.unit_locationid AND QUALITYMASTER.QUALITY_yearid = UNITMASTER.unit_yearid  LEFT OUTER JOIN ITEMMASTER ON QUALITYMASTER.QUALITY_ITEMID = ITEMMASTER.ITEM_ID AND QUALITYMASTER.QUALITY_cmpid = ITEMMASTER.ITEM_CMPID AND QUALITYMASTER.QUALITY_locationid = ITEMMASTER.ITEM_LOCATIONID AND QUALITYMASTER.QUALITY_yearid = ITEMMASTER.ITEM_YEARID ", " and   QUALITYMASTER.QUALITY_cmpid = " & CmpId & "  and QUALITYMASTER.QUALITY_yearid = " & YearId)
            GRIDBILLDETAILS.DataSource = dt
            If dt.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal NAME As String)
        Try
            Dim OBJDEPT As New QualityMaster
            OBJDEPT.MdiParent = MDIMain
            OBJDEPT.EDIT = EDITVAL
            OBJDEPT.tempQualityName = NAME
            OBJDEPT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
            Try
                SHOWFORM(False, 0)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
            Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("QUALITY"))
        Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
            Me.Close()
        End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("QUALITY"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call CMDEDIT_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then               'FOR new
            SHOWFORM(False, 0)
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Quality Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Quality Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Quality Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox("Quality Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class
