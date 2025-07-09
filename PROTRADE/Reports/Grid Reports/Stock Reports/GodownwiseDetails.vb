
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class GodownwiseDetails

    Public FRMSTRING, TEMPDESIGNNO, TEMPCOLOR, TEMPGODOWN, TEMPITEMNAME As String

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

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CMDREFRESH_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            'IF CHK IS TRUE THEN GET ALL YEARID UDER THAT COMPANY
            Dim TEMPCONDITION As String = ""
            If CHKALLCMP.Checked = True Then TEMPCONDITION = TEMPCONDITION & " And YEARID IN (SELECT YEAR_ID FROM YEARMASTER WHERE YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "')" Else TEMPCONDITION = TEMPCONDITION & " AND YEARID = " & YearId


            If ClientName = "YAMUNESH" Or ClientName = "MOMAI" Or ClientName = "AXIS" Then
                TEMPCONDITION = TEMPCONDITION & " AND ROUND(PCS,0) > 0 "
            ElseIf ClientName = "MOHAN" Then
                TEMPCONDITION = TEMPCONDITION & " AND ROUND(MTRS,2) > 0 "
            End If


            If TEMPITEMNAME <> "" Then TEMPCONDITION = TEMPCONDITION & " AND ITEMNAME='" & TEMPITEMNAME & "'"
            If TEMPDESIGNNO <> "" Then TEMPCONDITION = TEMPCONDITION & " AND DESIGNNO='" & TEMPDESIGNNO & "'"
            If TEMPCOLOR <> "" Then TEMPCONDITION = TEMPCONDITION & " AND COLOR='" & TEMPCOLOR & "'"
            If TEMPGODOWN <> "" Then TEMPCONDITION = TEMPCONDITION & " AND GODOWN='" & TEMPGODOWN & "'"

            Dim GROUPBY As String = " GROUP BY ITEMNAME, QUALITY, PIECETYPE, BARCODE, UNIT, BALENO, MILLNAME"
            If TEMPDESIGNNO <> "" Then GROUPBY = GROUPBY & ", DESIGNNO"
            If TEMPCOLOR <> "" Then GROUPBY = GROUPBY & ", COLOR"
            If TEMPGODOWN <> "" Then GROUPBY = GROUPBY & ", GODOWN"

            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable

            Dim DTUNIT As DataTable = OBJCMN.search("UNIT_ABBR", "", "DEFAULTSTOCKUNIT", "")
            If DTUNIT.Rows.Count > 0 Then TEMPCONDITION = TEMPCONDITION & " AND UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT)"


            If TEMPDESIGNNO = "" And TEMPCOLOR = "" And TEMPGODOWN = "" Then
                dt = OBJCMN.Execute_Any_String(" SELECT SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, DESIGNNO, ITEMNAME, QUALITY, COLOR ,GODOWN, LOTNO, BALENO, CHALLANNO, PIECETYPE, BARCODE, UNIT, ITEMCODE, CATEGORY,PURRATE, SALERATE, DESIGNRATE,RACK,SHELF, MILLNAME, DATE, JOBBERNAME, GRIDREMARKS FROM  BARCODESTOCK WHERE 1 = 1 " & TEMPCONDITION & " GROUP BY DESIGNNO, ITEMNAME, QUALITY, LOTNO, BALENO, CHALLANNO, COLOR ,GODOWN, PIECETYPE, BARCODE, UNIT, ITEMCODE, CATEGORY, PURRATE,RACK,SHELF, SALERATE, DESIGNRATE, MILLNAME, DATE, JOBBERNAME, GRIDREMARKS ORDER BY DESIGNNO, QUALITY, COLOR", "", "")
            Else
                dt = OBJCMN.Execute_Any_String(" SELECT SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS,'" & TEMPDESIGNNO & "' AS DESIGNNO, '" & TEMPCOLOR & "' AS COLOR , '" & TEMPGODOWN & "' AS GODOWN, ITEMNAME, QUALITY,  BALENO, PIECETYPE, BARCODE, UNIT, MILLNAME FROM BARCODESTOCK WHERE 1 = 1 " & TEMPCONDITION & GROUPBY, "", "")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
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
            PATH = Application.StartupPath & "\Stock In Hand.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo
            opti.SheetName = "Stock In Hand"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock In Hand", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GodownwiseDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MANALI" Then
                GNAME.Visible = True
                GNAME.VisibleIndex = GGODOWN.VisibleIndex + 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class