
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class StockDetailsGridReport

    Public FRMSTRING As String = ""
    Public WHERECLAUSE As String = ""
    Public FROMDATE As Date = AccFrom
    Public TODATE As Date = AccTo

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillgrid()

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        Dim DTOP As New DataTable

        If FRMSTRING = "GRIDSTOCKDETAILS" Then
            DT = OBJCMN.search("ENTRYTYPE, DATE, NAME, BILLINITIALS, CHALLANNO,GODOWN, ITEMNAME, SUM(MTRS) AS MTRS, SUM(ISSMTRS) AS ISSMTRS, 0.00 AS RUNNINGBAL, NO, REGNAME ", "", " STOCKREGISTER", WHERECLAUSE & " AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' GROUP BY DATE, REGNAME, NO, ENTRYTYPE,  NAME, BILLINITIALS, CHALLANNO,GODOWN, ITEMNAME ")
            DTOP = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS, T.ITEMNAME", "", "(SELECT MTRS, GODOWN, ITEMNAME FROM STOCKREGISTER WHERE DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YearId & WHERECLAUSE & " UNION ALL Select ISSMTRS * -1 As MTRS, GODOWN, ITEMNAME FROM STOCKREGISTER WHERE DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YearId & WHERECLAUSE & ") AS T", " GROUP BY T.ITEMNAME")
        ElseIf FRMSTRING = "DESIGNSTOCKREGISTER" Then
            GITEMNAME.Caption = "Design No"
            DT = OBJCMN.search("ENTRYTYPE, DATE, NAME, BILLINITIALS, CHALLANNO,GODOWN, DESIGNNO AS ITEMNAME, SUM(MTRS) AS MTRS, SUM(ISSMTRS) AS ISSMTRS, 0.00 AS RUNNINGBAL, NO, REGNAME ", "", " STOCKREGISTER", WHERECLAUSE & " AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' GROUP BY DATE, REGNAME, NO, ENTRYTYPE,  NAME, BILLINITIALS, CHALLANNO,GODOWN, DESIGNNO")
            DTOP = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS, T.ITEMNAME", "", "(SELECT MTRS, GODOWN, DESIGNNO AS ITEMNAME FROM STOCKREGISTER WHERE DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YearId & WHERECLAUSE & " UNION ALL Select ISSMTRS * -1 As MTRS, GODOWN, DESIGNNO AS ITEMNAME FROM STOCKREGISTER WHERE DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YearId & WHERECLAUSE & ") AS T", " GROUP BY T.ITEMNAME")
        End If

        If DTOP.Rows.Count > 0 Then
            Dim ROW As DataRow = DT.NewRow()
            If Val(DTOP.Rows(0).Item("MTRS")) > 0 Then
                ROW("ENTRYTYPE") = "OPENING"
                ROW("DATE") = FROMDATE.Date
                ROW("NAME") = ""
                ROW("BILLINITIALS") = ""
                ROW("CHALLANNO") = ""
                'DONT GET GODOWN IN OPENING BALANCE
                'ROW("GODOWN") = DTOP.Rows(0).Item("GODOWN")
                ROW("GODOWN") = ""
                ROW("ITEMNAME") = DTOP.Rows(0).Item("ITEMNAME")
                ROW("MTRS") = Val(DTOP.Rows(0).Item("MTRS"))
                ROW("ISSMTRS") = 0
                ROW("RUNNINGBAL") = 0.0
                ROW("NO") = 0
                ROW("REGNAME") = ""
            Else
                ROW("ENTRYTYPE") = "OPENING"
                ROW("DATE") = FROMDATE.Date
                ROW("NAME") = ""
                ROW("BILLINITIALS") = ""
                ROW("CHALLANNO") = ""
                ROW("GODOWN") = ""
                ROW("ITEMNAME") = DTOP.Rows(0).Item("ITEMNAME")
                ROW("MTRS") = 0
                ROW("ISSMTRS") = Val(DTOP.Rows(0).Item("MTRS")) * -1
                ROW("RUNNINGBAL") = 0.0
                ROW("NO") = 0
                ROW("REGNAME") = ""
            End If
            DT.Rows.InsertAt(ROW, 0)
        End If

        griddetails.DataSource = DT
        TOTAL()

    End Sub

    Sub FILLSUMMARY()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            DT.Columns.Add("TYPE")

            'WE NEED TO ADD COLUMNS WITH RESPECT TO UNIT
            Dim DTUNIT As DataTable = OBJCMN.search("DISTINCT UNIT ", "", " STOCKREGISTER", WHERECLAUSE & " AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' ORDER BY UNIT")
            For Each ROW As DataRow In DTUNIT.Rows
                Dim COL As New DataColumn(ROW("UNIT"))
                COL.DataType = System.Type.GetType("System.Decimal")
                DT.Columns.Add(COL)
            Next


            'ADD ROWS WITH RESPECT TO ENTRYTYPE
            Dim DTENTRYTYPE As DataTable = OBJCMN.search("DISTINCT ENTRYTYPE ", "", " STOCKREGISTER", WHERECLAUSE & " AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' ORDER BY ENTRYTYPE")
            For Each ROW As DataRow In DTENTRYTYPE.Rows
                Dim DTROW As DataRow = DT.NewRow
                For I As Integer = 0 To DT.Columns.Count - 1
                    Dim DTENTRYMTRS As DataTable = OBJCMN.search("ISNULL(SUM(MTRS),0) - ISNULL(SUM(ISSMTRS),0) AS MTRS", "", "STOCKREGISTER", WHERECLAUSE & " AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND ENTRYTYPE = '" & ROW("ENTRYTYPE") & "' AND UNIT = '" & DT.Columns(I).ToString & "'")
                    If DTENTRYMTRS.Rows.Count > 0 Then DTROW(DT.Columns(I).ToString) = Val(DTENTRYMTRS.Rows(0).Item("MTRS")) Else DTROW(DT.Columns(I).ToString) = 0
                Next
                DTROW("TYPE") = ROW("ENTRYTYPE")
                DT.Rows.Add(DTROW)
            Next


            'add total
            Dim DTROWTOTAL As DataRow = DT.NewRow
            For I As Integer = 1 To DT.Columns.Count - 1
                Dim SUM As Object = Convert.ToDouble(DT.Compute("SUM([" & DT.Columns(I).ToString & "])", "[" & DT.Columns(I).ToString & "] IS NOT NULL"))
                DTROWTOTAL(DT.Columns(I).ToString) = SUM.ToString
            Next
            DTROWTOTAL("TYPE") = "Total"
            DT.Rows.Add(DTROWTOTAL)

            GRIDSUMMDETAILS.DataSource = DT
            GRIDSUMM.PopulateColumns()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double = 0
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("RUNNINGBAL") = (Val(dtrow("MTRS")) + Val(RUNNINGBAL)) - Val(dtrow("ISSMTRS"))
                RUNNINGBAL = dtrow("RUNNINGBAL")
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockDetailsGridReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockDetailsGridReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
            FILLSUMMARY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
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

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                VIEWFORM(dtrow("ENTRYTYPE"), True, Val(dtrow("NO")), dtrow("REGNAME"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Stock Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Stock Details"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Stock Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", "Period - " & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy"), 0, 0)
        Catch ex As Exception
            MsgBox("Stock Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub GRIDSUMM_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GRIDSUMM.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("TYPE")) = "Total" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class