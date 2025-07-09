
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System.IO

Public Class StockOnHandSummary

    Public WHERECLAUSE As String = ""
    Public FROMDATE As Date = AccFrom
    Public TODATE As Date = AccTo
    Public STOCKPRINTABLE As Boolean = False
    Public FRMSTRING, TEMPITEMNAME, TEMPDESIGNNO, TEMPCOLOR, TEMPQUALITY As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                GPURRATE.Visible = True
                GPURRATE.VisibleIndex = GTOTALMTRS.VisibleIndex + 1
            End If

            If ClientName = "YASHVI" Then
                GCUT.Visible = True
                GCUT.VisibleIndex = GTOTALMTRS.VisibleIndex + 1
            End If

            If ClientName = "AVIS" Then
                GMILLNAME.Visible = True
                GMILLNAME.VisibleIndex = GDESIGNNO.VisibleIndex + 1
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable


            'IF CHK IS TRUE THEN GET ALL YEARID UDER THAT COMPANY
            Dim TEMPCONDITION As String = ""
            If CHKALLCMP.Checked = True Then TEMPCONDITION = TEMPCONDITION & " And YEARID IN (SELECT YEAR_ID FROM YEARMASTER WHERE YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "')" Else TEMPCONDITION = TEMPCONDITION & " AND YEARID = " & YearId


            If STOCKPRINTABLE = False Then

                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then TEMPCONDITION = TEMPCONDITION & " And ROUND(MTRS,0) > 0 "

                If TEMPDESIGNNO <> "" Then TEMPCONDITION = TEMPCONDITION & " And DESIGNNO = '" & TEMPDESIGNNO & "'"
                If TEMPCOLOR <> "" Then TEMPCONDITION = TEMPCONDITION & " AND COLOR = '" & TEMPCOLOR & "'"
                If TEMPQUALITY <> "" Then TEMPCONDITION = TEMPCONDITION & " AND QUALITY = '" & TEMPQUALITY & "' "
                If TEMPITEMNAME <> "" Then TEMPCONDITION = TEMPCONDITION & " AND ITEMNAME ='" & TEMPITEMNAME & "' "

                Dim GROUPBY As String = " GROUP BY GODOWN, UNIT, CATEGORY, MILLNAME, VALUATIONRATE "
                If TEMPQUALITY <> "" Then GROUPBY = GROUPBY & ", QUALITY "
                If TEMPDESIGNNO <> "" Then GROUPBY = GROUPBY & ", DESIGNNO "
                If TEMPCOLOR <> "" Then GROUPBY = GROUPBY & ", COLOR "
                If TEMPITEMNAME <> "" Then GROUPBY = GROUPBY & ", ITEMNAME "

                If ClientName = "YASHVI" Then GROUPBY = GROUPBY & ", CUT"
                Dim DTUNIT As DataTable = OBJCMN.search("UNIT_ABBR", "", "DEFAULTSTOCKUNIT", "")
                If DTUNIT.Rows.Count > 0 Then TEMPCONDITION = TEMPCONDITION & " AND UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT)"

                If TEMPQUALITY = "" And TEMPDESIGNNO = "" And TEMPCOLOR = "" And TEMPITEMNAME = "" Then
                    DT = OBJCMN.search(" CAST(0 AS BIT) AS SAMPLEMATCH, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, QUALITY,DESIGNNO, COLOR , GODOWN, ITEMNAME, UNIT, ISNULL(DESIGN_PURRATE,0) AS PURRATE, CATEGORY, MILLNAME, VALUATIONRATE, (VALUATIONRATE * SUM(MTRS)) AS STOCKVALUE ", "", "  BARCODESTOCK LEFT OUTER JOIN DESIGNMASTER ON BARCODESTOCK.DESIGNNO = DESIGNMASTER.DESIGN_NO AND BARCODESTOCK.YEARID = DESIGNMASTER.DESIGN_YEARID", TEMPCONDITION & WHERECLAUSE & " GROUP BY QUALITY,DESIGNNO, COLOR , GODOWN, ITEMNAME, UNIT, ISNULL(DESIGN_PURRATE,0), CATEGORY, MILLNAME, VALUATIONRATE")
                Else
                    If ClientName = "YASHVI" Then
                        DT = OBJCMN.search(" CAST(0 AS BIT) AS SAMPLEMATCH, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPQUALITY & "' AS QUALITY,'" & TEMPDESIGNNO & "' AS DESIGNNO, '" & TEMPCOLOR & "' AS COLOR , '" & TEMPITEMNAME & "' AS ITEMNAME , GODOWN, UNIT, CUT, CATEGORY, MILLNAME, VALUATIONRATE, (VALUATIONRATE * SUM(MTRS)) AS STOCKVALUE ", "", "  BARCODESTOCK ", TEMPCONDITION & GROUPBY)
                    Else
                        DT = OBJCMN.search(" CAST(0 AS BIT) AS SAMPLEMATCH, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPQUALITY & "' AS QUALITY,'" & TEMPDESIGNNO & "' AS DESIGNNO, '" & TEMPCOLOR & "' AS COLOR , '" & TEMPITEMNAME & "' AS ITEMNAME , GODOWN, UNIT, CATEGORY, MILLNAME, VALUATIONRATE, (VALUATIONRATE * SUM(MTRS)) AS STOCKVALUE ", "", "  BARCODESTOCK ", TEMPCONDITION & GROUPBY)
                    End If
                End If

            Else

                'GET THIS STOCK FROM STOCKREGISTER
                GGODOWN.Visible = False
                GQUALITY.Visible = False
                GCOLOR.Visible = False
                GUNIT.Visible = False

                'GET STOCK TILL DATE
                WHERECLAUSE = WHERECLAUSE & " AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'"

                If FRMSTRING = "GRIDSTOCKDETAILS" Then
                    GDESIGNNO.Visible = False
                    GITEMNAME.VisibleIndex = GGODOWN.VisibleIndex + 1
                    DT = OBJCMN.search(" (SUM(PCS)-SUM(ISSPCS)) AS TOTALPCS, (SUM(MTRS)-SUM(ISSMTRS)) AS TOTALMTRS, ITEMNAME, CATEGORY, MILLNAME, VALUATIONRATE, (VALUATIONRATE * (SUM(MTRS)-SUM(ISSMTRS))) AS STOCKVALUE ", "", " STOCKREGISTER ", WHERECLAUSE & " GROUP BY ITEMNAME, CATEGORY, MILLNAME, VALUATIONRATE")

                ElseIf FRMSTRING = "ITEMDESIGNSHADEGRIDSTOCKDETAILS" Then
                    GDESIGNNO.VisibleIndex = GITEMNAME.VisibleIndex + 1
                    GCOLOR.Visible = True
                    GITEMNAME.VisibleIndex = GGODOWN.VisibleIndex + 1
                    DT = OBJCMN.search(" (SUM(PCS)-SUM(ISSPCS)) AS TOTALPCS, (SUM(MTRS)-SUM(ISSMTRS)) AS TOTALMTRS, ITEMNAME, CATEGORY, DESIGNNO, COLOR, VALUATIONRATE, (VALUATIONRATE * (SUM(MTRS)-SUM(ISSMTRS))) AS STOCKVALUE ", "", " STOCKREGISTER ", WHERECLAUSE & " GROUP BY ITEMNAME, DESIGNNO, COLOR, CATEGORY, VALUATIONRATE")

                ElseIf FRMSTRING = "DESIGNSTOCKREGISTER" Then
                    GDESIGNNO.VisibleIndex = GGODOWN.VisibleIndex + 1
                    DT = OBJCMN.search(" (SUM(PCS)-SUM(ISSPCS)) AS TOTALPCS, (SUM(MTRS)-SUM(ISSMTRS)) AS TOTALMTRS, ITEMNAME, DESIGNNO, '' AS CATEGORY, '' AS MILLNAME, VALUATIONRATE, (VALUATIONRATE * (SUM(MTRS)-SUM(ISSMTRS))) AS STOCKVALUE ", "", " STOCKREGISTER ", WHERECLAUSE & " GROUP BY ITEMNAME, DESIGNNO, VALUATIONRATE")
                End If

            End If

            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Stock Summary.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Stock Summary"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Summary", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Stock Summary Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Try
            If STOCKPRINTABLE = True Then
                Dim OBJSTOCK As New StockDetailsGridReport
                If FRMSTRING = "GRIDSTOCKDETAILS" Then OBJSTOCK.WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & gridbill.GetFocusedRowCellValue("ITEMNAME") & "'" Else OBJSTOCK.WHERECLAUSE = WHERECLAUSE & " AND DESIGNNO = '" & gridbill.GetFocusedRowCellValue("DESIGNNO") & "' AND ITEMNAME = '" & gridbill.GetFocusedRowCellValue("ITEMNAME") & "'"
                OBJSTOCK.FRMSTRING = FRMSTRING
                OBJSTOCK.FROMDATE = FROMDATE
                OBJSTOCK.TODATE = TODATE
                OBJSTOCK.MdiParent = MDIMain
                OBJSTOCK.Show()
            Else
                showform()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Dim OBJSTOCK As New GodownwiseDetails
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.TEMPDESIGNNO = gridbill.GetFocusedRowCellValue("DESIGNNO")
            OBJSTOCK.TEMPCOLOR = gridbill.GetFocusedRowCellValue("COLOR")
            OBJSTOCK.TEMPGODOWN = gridbill.GetFocusedRowCellValue("GODOWN")
            OBJSTOCK.TEMPITEMNAME = gridbill.GetFocusedRowCellValue("ITEMNAME")
            OBJSTOCK.CHKALLCMP.Checked = CHKALLCMP.Checked
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                'GET DATA FROM SAMPLE BARCODE
                'no need for yearid clause here as we need to fetch this barcode in all acccouting year
                DT = OBJCMN.search(" SAMPLEBARCODE.SB_NO AS SBNO, SAMPLEBARCODE.SB_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITY, ISNULL(DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(SAMPLEBARCODE.SB_REMARKS, '') AS REMARKS, SAMPLEBARCODE.SB_BARCODE AS BARCODE", "", " SAMPLEBARCODE INNER JOIN ITEMMASTER ON SAMPLEBARCODE.SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON SAMPLEBARCODE.SB_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON SAMPLEBARCODE.SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SAMPLEBARCODE.SB_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND SB_BARCODE = '" & TXTBARCODE.Text.Trim & "'")
                If DT.Rows.Count > 0 Then

                    For I As Integer = 0 To gridbill.RowCount - 1
                        Dim ROW As DataRow = gridbill.GetDataRow(I)
                        If ROW("ITEMNAME") = DT.Rows(0).Item("ITEMNAME") And ROW("DESIGNNO") = DT.Rows(0).Item("DESIGNNO") And ROW("COLOR") = DT.Rows(0).Item("COLOR") Then
                            ROW("SAMPLEMATCH") = True
                            GoTo LINE1
                        End If
                    Next
                    'IF ENTRY IS NOT FOUND THEN GIVE MESSAGE
                    MsgBox("Sample Not Present in Stock", MsgBoxStyle.Critical)


LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(sender As Object, e As RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("SAMPLEMATCH")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class