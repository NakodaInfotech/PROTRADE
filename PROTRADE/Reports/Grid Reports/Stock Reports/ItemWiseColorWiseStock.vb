Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class ItemWiseColorWiseStock

    Public FRMSTRING, TEMPCOLOR As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemWiseColorWiseStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemWiseColorWiseStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Dim ObjGodownwiseStock As New GodownwiseStock
            ObjGodownwiseStock.MdiParent = MDIMain
            ObjGodownwiseStock.TEMPITEMNAME = gridbill.GetFocusedRowCellValue("ITEMNAME")
            ObjGodownwiseStock.TEMPCOLOR = gridbill.GetFocusedRowCellValue("COLOR")
            ObjGodownwiseStock.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try

            If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "AVIS" Then TEMPCONDITION = TEMPCONDITION & " AND ROUND(MTRS,0) > 0 "
            If TEMPCOLOR <> "" Then TEMPCONDITION = TEMPCONDITION & " AND COLOR = '" & TEMPCOLOR & "' "

            Dim GROUPBY As String = " GROUP BY ITEMNAME  "
            If TEMPCOLOR <> "" Then GROUPBY = GROUPBY & ", COLOR "

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If TEMPCOLOR = "" Then
                If CHKNILSTOCK.CheckState = CheckState.Checked Then
                    dt = objclsCMST.search(" T.ITEMNAME,T.COLOR, SUM(T.PCS) AS TOTALPCS, SUM(T.MTRS) AS TOTALMTRS  ", "", " (SELECT ITEMNAME, COLOR,SUM(PCS) AS PCS, SUM(MTRS) AS MTRS FROM BARCODESTOCK WHERE 1=1 " & TEMPCONDITION & " GROUP BY  ITEMNAME,COLOR  UNION ALL SELECT DISTINCT ITEMNAME,COLOR,0,0   FROM OUTBARCODESTOCK) AS T ", " GROUP BY T.ITEMNAME,T.COLOR order by ITEMNAME,color")
                Else
                    dt = objclsCMST.search(" ITEMNAME,COLOR, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS  ", "", "  BARCODESTOCK", TEMPCONDITION & " GROUP BY  ITEMNAME,COLOR order by ITEMNAME,color ")
                End If
            Else
                dt = objclsCMST.search(" ITEMNAME,'" & TEMPCOLOR & "' AS COLOR,SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS  ", "", "  BARCODESTOCK", TEMPCONDITION & GROUPBY)
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Itemwise Shadewise Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Itemwise Shadewise Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Itemwise Shadewise Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Item Shade Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            gridbill.ClearColumnsFilter()
            fillgrid(" AND ROUND(MTRS,0) > 0 and CMPID=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemWiseColorWiseStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            CHKNILSTOCK.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class