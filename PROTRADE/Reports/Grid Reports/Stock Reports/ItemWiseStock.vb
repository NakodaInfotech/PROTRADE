Imports BL
Imports System.Windows.Forms

Public Class ItemWiseStock

    Public FRMSTRING As String
    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemWiseStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and yearid = " & YearId & "  GROUP BY ITEMCODE, ITEMNAME, CATEGORY, VALUATIONRATE ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemWiseStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then WHERECLAUSE = WHERECLAUSE & " AND ROUND(MTRS,0) > 0 "

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, ITEMCODE, ITEMNAME, CATEGORY, VALUATIONRATE, (VALUATIONRATE*SUM(MTRS))  AS STOCKVALUE ", "", " BARCODESTOCK ", WHERECLAUSE & TEMPCONDITION)
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
            PATH = Application.StartupPath & "\Item wise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Item wise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Item wise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Item Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid(" AND ROUND(MTRS,0) > 0 and yearid = " & YearId & "  GROUP BY  ITEMCODE, ITEMNAME, CATEGORY, VALUATIONRATE ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemWiseStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Then
                GITEMNAME.Visible = False
            Else
                GITEMCODE.Visible = False
                GCATEGORY.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class