
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectItemSO

    Public DT As New DataTable
    Dim CLEAR As Boolean = False
    Public EDIT As Boolean
    Public tempMsg As Integer
    Public ITEMNAME As String
    Public DESIGNNO As String

    Private Sub SelectItemSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim WHERECLAUSE As String = ""
            Dim GROUPBY As String
            If FETCHITEMWISEDESIGN = True Then
                GROUPBY = " GROUP BY C.COLOR_name, DESIGNMASTER_COLOR.DESIGN_SRNO, B.COLOR, D.DESIGN_NO, D.DESIGN_yearid  ORDER BY DESIGNMASTER_COLOR.DESIGN_SRNO "
                WHERECLAUSE = " AND D.DESIGN_NO = '" & DESIGNNO & "' AND D.DESIGN_YEARID = " & YearId

                'Dim DTUNIT As DataTable = OBJCMN.search("UNIT_ABBR", "", "DEFAULTSTOCKUNIT", "")
                'If DTUNIT.Rows.Count > 0 Then WHERECLAUSE = WHERECLAUSE & " AND B.UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT)"

                DT = OBJCMN.search(" ISNULL(C.COLOR_name,'') AS COLOR,  SUM(ISNULL(B.PCS, 0)) AS TOTALPCS, SUM(ISNULL(B.MTRS, 0)) AS TOTALMTRS, 0.00 AS CUT, 0 AS ORDERPCS, 0.00 AS ORDERMTRS , ISNULL(( SELECT SUM(SO_MTRS-SO_RECDMTRS) FROM SALEORDER_DESC LEFT OUTER JOIN DESIGNMASTER ON DESIGN_id = SO_DESIGNID LEFT OUTER JOIN COLORMASTER ON COLOR_id = SO_COLORID WHERE SO_CLOSED = 'FALSE' AND SO_QTY-SO_RECDQTY > 0 AND (DESIGNMASTER.DESIGN_NO = D.DESIGN_NO And COLOR_name = C.COLOR_name And SO_YEARID = D.DESIGN_YEARID)),0) AS PENDINGQTY", "", " DESIGNMASTER AS D INNER JOIN  DESIGNMASTER_COLOR ON D.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID INNER JOIN  COLORMASTER AS C ON DESIGNMASTER_COLOR.DESIGN_COLORID = C.COLOR_id LEFT OUTER JOIN BARCODESTOCK AS B ON C.COLOR_name = B.COLOR AND D.DESIGN_NO = B.DESIGNNO AND D.DESIGN_YEARID = B.YEARID AND B.UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT) ", WHERECLAUSE & GROUPBY)
            Else
                GROUPBY = " GROUP BY COLOR , ITEMNAME, YEARID "
                WHERECLAUSE = " AND ITEMNAME = '" & ITEMNAME & "'AND ROUND(MTRS,0) > 0 and yearid=" & YearId
                DT = OBJCMN.search(" COLOR, SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS, 0.00 AS CUT,  0 AS ORDERPCS, 0.00 AS ORDERMTRS , ISNULL(( SELECT SUM(SO_QTY-SO_RECDQTY) FROM SALEORDER_DESC INNER JOIN ITEMMASTER ON item_id = SO_ITEMID LEFT OUTER JOIN COLORMASTER ON COLOR_id = SO_COLORID LEFT OUTER JOIN UNITMASTER ON unit_id = SO_UNITID WHERE SO_CLOSED = 'FALSE' AND SO_QTY-SO_RECDQTY > 0 AND (ItemMaster.item_name = B.ITEMNAME And COLOR_name = B.COLOR And SO_YEARID = B.YEARID)),0) AS PENDINGQTY  ", "", " BARCODESTOCK AS B ", WHERECLAUSE & GROUPBY)
            End If
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = 0
                gridbill.FocusedColumn = GCUT
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
           
            DT.Columns.Add("COLOR")
            DT.Columns.Add("CUT")
            DT.Columns.Add("ORDERPCS")
            DT.Columns.Add("ORDERMTRS")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Val(dtrow("ORDERPCS")) > 0 Then
                    DT.Rows.Add(dtrow("COLOR"), Val(dtrow("CUT")), Val(dtrow("ORDERPCS")), Val(dtrow("ORDERMTRS")))
                End If
            Next

            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridbill.CellValueChanged
        Try
            Dim DTROW As DataRow = gridbill.GetFocusedDataRow()
            If Val(DTROW("ORDERPCS")) > 0 Then
                Dim DTROW1 As DataRow
                For I As Integer = gridbill.FocusedRowHandle - 1 To 0 Step -1
                    DTROW1 = gridbill.GetDataRow(I)
                    If Val(DTROW1("ORDERPCS")) > 0 Then Exit For
                Next
                If Val(DTROW("CUT")) = 0 Then DTROW("CUT") = Val(DTROW1("CUT"))
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If Val(DTROW("CUT")) > 0 And Val(DTROW("ORDERPCS")) > 0 Then DTROW("ORDERMTRS") = Format(Val(DTROW("CUT")) * Val(DTROW("ORDERPCS")), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Space And gridbill.FocusedRowHandle > 0 Then
                Dim DTROW As DataRow = gridbill.GetFocusedDataRow()
                Dim DTROW1 As DataRow
                For I As Integer = gridbill.FocusedRowHandle - 1 To 0 Step -1
                    DTROW1 = gridbill.GetDataRow(I)
                    If Val(DTROW1("ORDERPCS")) > 0 Then Exit For
                Next
                DTROW("CUT") = Val(DTROW1("CUT"))
                DTROW("ORDERPCS") = Val(DTROW1("ORDERPCS"))
                DTROW("ORDERMTRS") = Val(DTROW1("ORDERMTRS"))
            End If

            If e.KeyCode = Keys.Delete And gridbill.FocusedRowHandle >= 0 Then
                Dim DTROW As DataRow = gridbill.GetFocusedDataRow()
                DTROW("CUT") = 0
                DTROW("ORDERPCS") = 0
                DTROW("ORDERMTRS") = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWSTOCK.Click
        Try
            Dim OBJSTOCK As New StockOnHandSummary
            OBJSTOCK.TEMPITEMNAME = ITEMNAME
            OBJSTOCK.TEMPDESIGNNO = DESIGNNO
            OBJSTOCK.TEMPCOLOR = gridbill.GetFocusedRowCellDisplayText("COLOR")
            OBJSTOCK.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class