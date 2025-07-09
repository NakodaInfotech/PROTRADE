
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data


'Imports Microsoft.Office.Interop.Excel


Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try
                For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                    proc.Kill()
                Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Sample"

    Public Function RPT_SampleGeneral_Loading(ByVal intPDIID As Integer, ByVal strPUser As String) As Object
        Try
            Dim id As Integer = 0
            Dim intJ As Integer = 0
            Dim intTotal As Integer = 0
            Dim intSrNo As Integer = 0
            Dim intRowStart, intRowEnd As Integer
            Dim drRow As DataRow
            Dim drNew As System.Data.DataRow = Nothing
            Dim dtTable As New System.Data.DataTable
            Dim dtSetItem As New System.Data.DataTable
            Dim dtChild As New System.Data.DataTable
            Dim objDispatch As New Object()

            'BrandPromotion.clsSampleDispatch()
            'Dim Tot1, Tot2, tot3, Tot4 As Double
            'Dim Gt1, Gt2, Gt3 As Double
            'Dim dvTemp As DataView
            'dtTable = objDispatch.DispatchChitReport(intPDIID)
            'If dtTable.Rows.Count = 0 Then Return Nothing
            'dtChild = objDispatch.DispatchChitReportCHILD(intPDIID)
            'dtSetItem = objDispatch.DispatchChitReportItem(intPDIID)




            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")
            'SetColumn("10", "J")
            'SetColumn("11", "K")
            'SetColumn("12", "L")
            'SetColumn("13", "M")
            'SetColumn("14", "N")
            'SetColumn("15", "O")
            SetColumnWidth("A1", 50)

            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write(_Report_Title, Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("2. Exports of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Gold Exports (non-monetary gold)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Repairs on goods", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Coffee and other Exports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("3. Income Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Interest received on External assets", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Dividends / profits received", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("4. Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(h) Royalties and license fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("5. Transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) NGO inflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("6. Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("7. Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Bank", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("8. Loans", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Loan Received", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Other (Please specify)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Private Sub FetchData(ByVal fromDate As Date, ByVal toDate As Date, ByVal sp_name As String)
        Try
            'Dim conn As New SqlClient.SqlConnection("Data Source=DELL-B0BA70D352\SQLDELL;Initial Catalog=Forex;Integrated Security=True;uid=sa;pwd=admin123;")
            'Dim conn As New SqlClient.SqlConnection("Data Source=.\SQLDELL;Initial Catalog=Project;Integrated Security=True;")
            Dim conn As New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString())


            Dim comm As New SqlClient.SqlCommand()
            conn.Open()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = sp_name
            comm.Parameters.Add(New SqlClient.SqlParameter("@FromDate", fromDate))
            comm.Parameters.Add(New SqlClient.SqlParameter("@ToDate", toDate))
            comm.CommandTimeout = 1000
            Dim adap As New SqlClient.SqlDataAdapter(comm)
            adap.Fill(dsResult)
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillAmount()
        Try

            If dv.Count > 0 Then
                For index As Integer = 1 To dv.Count
                    If dv.Item(index - 1)("CurrencyId") = 1 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 2 Then
                        Write(dv.Item(index - 1)("Amount"), Range("3"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 3 Then
                        Write(dv.Item(index - 1)("Amount"), Range("4"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 4 Then
                        Write(dv.Item(index - 1)("Amount"), Range("5"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 5 Then
                        Write(dv.Item(index - 1)("Amount"), Range("6"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 7 Then
                        Write(dv.Item(index - 1)("Amount"), Range("7"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 9 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RPT_Sales_Report(ByVal fromDate As Date, ByVal toDate As Date) As Object
        Try
            Me.FetchData(fromDate, toDate, "SP_SELECTSO_FOR_EDIT")

            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")

            SetColumnWidth("A1", 50)
            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write("FORM P(Sales)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, , True)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            dv = dsResult.Tables(0).DefaultView

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CurrencyHoldingDiposits'"
            Me.FillAmount()

            RowIndex += 1
            Write("2. Import of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Govt imports (Incl. Govt. Projects)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Private Imports (Incl. Parastatal & NGOs)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PrivateImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Oil Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OilImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Gold Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoldImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iii) Repairs", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='Repairs'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iv) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='GoodsProPortsByCarrier'"
            Me.FillAmount()

            RowIndex += 1
            Write("(v) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsForProcessig'"
            Me.FillAmount()

            RowIndex += 1
            Write("Income Payments", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Interest received on External liabilities", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InterestPaidOnExternalLib'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Dividends / profits paid", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='DividentProfitPaid'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='WagesSalaries'"
            Me.FillAmount()

            RowIndex += 1
            Write("Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransFreight'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransPassanger'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CommunicationService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='ConstructionService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InsuranceDeInsu'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='FinancialService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelBusinessOfficial'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelEducation'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelMedical'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelOtherPersonal'"
            Me.FillAmount()

            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CompAndInfoService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(h) Royalties and licence fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RoyaliAndLicenceFees'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OtherBusinessService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PersonalCultAndReceService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtServices'"
            Me.FillAmount()

            RowIndex += 1
            Write("Transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) NGO Outflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransNGOOutFlows'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransGovtGrants'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransWorkerRemitance'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransOtherTransfer'"
            Me.FillAmount()

            RowIndex += 1
            Write("Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='ForeignDirectEquityInvestment'"
            Me.FillAmount()

            RowIndex += 1
            Write("Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) By Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) By Bank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByBanks'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) By Other", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByOthers'"
            Me.FillAmount()

            RowIndex += 1
            Write("Loans", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) Loans Extended abroad", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanOtherGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanRepaymentPrincipal'"
            Me.FillAmount()

            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='BankBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("Inerbank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBank'"
            Me.FillAmount()

            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String)
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "MFG CONSUMPTION"

    Public Function MFG_CONSUMPTION_EXCEL(ByVal whereclause As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal CONDITION As String, ByVal NOTCONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon
            Dim a As Integer = 0
            Dim dt As System.Data.DataTable

            dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  sum(MFGMASTER_DESC.MFG_inpcs) AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & CONDITION & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ")

            If dt.Rows.Count > 0 Then

                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 8)
                Next

                SetColumnWidth("R1", 7)
                SetColumnWidth("T1", 7)
                SetColumnWidth("U1", 10)


                '''''''''''Report Title
                'CMPNAME
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_name"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("15"))

                'ADD1
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_add1"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("15"))

                'ADD2
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_add2"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("15"))

                RowIndex += 1
                Write("MFG DETAIL", Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 12)
                SetBorder(RowIndex, Range("1"), Range("15"))


                RowIndex += 1
                Write("LOT NO", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("DATE", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
                Write("PCS", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                Write("QUALITY", Range("6"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                Write("WT / MTRS", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
                Write("MTRS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("WT", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
                Write("PROCESS", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)

                'FREEZE  ROWS
                objSheet.Range(objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("15").ToString & RowIndex + 1).Select()
                objSheet.Range(objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("15").ToString & RowIndex + 1).Application.ActiveWindow.FreezePanes = True

                SetBorder(RowIndex, Range("1"), Range("15"))

                Dim SRNO As Integer = 0
                Dim PROCESSN As String
                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("LOTNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                    Write(dr("PCS"), Range("4"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
                    Write(dr("QUALITY"), Range("6"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                    If dr("WT") > 0 And dr("MTRS") > 0 Then
                        Write(dr("WT") / dr("MTRS"), Range("11"), XlHAlign.xlHAlignRight, Range("12"), False, 10)
                    Else
                        Write("0", Range("11"), XlHAlign.xlHAlignRight, Range("12"), False, 10)
                    End If
                    Write(dr("MTRS"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(dr("WT"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                    If PROCESSN <> dr("PROCESS_NAME") Then
                        Write(dr("PROCESS_NAME"), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                        PROCESSN = dr("PROCESS_NAME")
                    End If
                Next

                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("1"))
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - SRNO - 1, Range("3"))
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("10"))
                SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - SRNO - 1, Range("12"))
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - SRNO - 1, Range("13"))
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex - SRNO - 1, Range("14"))
                SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - SRNO - 1, Range("15"))


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("1"), True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("15"))
                Dim TOTALWT, TOTALPCS, TOTALMTRS As Double

                Write(dt.Compute("sum(PCS)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("5"))
                Write(dt.Compute("sum(WT)", ""), Range("14"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
                TOTALWT = dt.Compute("sum(WT)", "")
                TOTALPCS = dt.Compute("sum(PCS)", "")
                TOTALMTRS = dt.Compute("sum(MTRS)", "")
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, Range("15"))
                Write(dt.Compute("sum(MTRS)", ""), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("13"))

                RowIndex += 1
                CONDITION = Replace(CONDITION, "MFGMASTER_DESC.MFG_DONE", "MFGMASTER.MFG_DONE")
                dt = objCMN.search("  ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY ", "", "   MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND  MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid ", whereclause & CONDITION & " GROUP BY ITEMMASTER.item_name ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))


                'TOTAL NOT CONSUMPTION
                RowIndex += 2
                Write("PREVIOUS CONSUMPTION", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  MFGMASTER.MFG_TOTALPCS AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & NOTCONDITION & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, MFGMASTER.MFG_TOTALPCS ")
                If dt.Rows.Count > 0 Then
                    TOTALWT = dt.Compute("sum(WT)", "")
                    TOTALPCS = dt.Compute("sum(PCS)", "")
                    TOTALMTRS = dt.Compute("sum(MTRS)", "")
                End If
                dt = objCMN.search("  ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY ", "", "   MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND  MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid ", whereclause & NOTCONDITION & " GROUP BY ITEMMASTER.item_name ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))




                'TOTAL CONSUMPTION
                RowIndex += 2
                Write("TILL DATE CONSUMPTION", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  MFGMASTER.MFG_TOTALPCS AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, MFGMASTER.MFG_TOTALPCS ")
                If dt.Rows.Count > 0 Then
                    TOTALWT = dt.Compute("sum(WT)", "")
                    TOTALPCS = dt.Compute("sum(PCS)", "")
                    TOTALMTRS = dt.Compute("sum(MTRS)", "")
                End If
                dt = objCMN.search("  ITEMMASTER.item_name AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY ", "", "   MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND  MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid ", whereclause & " GROUP BY ITEMMASTER.item_name ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))





                objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).Font.Size = 10
                objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

                objBook.Application.ActiveWindow.Zoom = 85

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlPortrait
                '    .TopMargin = 20
                '    .LeftMargin = 10
                '    .RightMargin = 5
                '    .BottomMargin = 0
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("15").ToString & RowIndex + 2)
                'objSheet.Protect("infosys123")
                SaveAndClose()
            Else
                MsgBox("No Record Found")
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "INVOICE SUMMARY REPORT"

    Public Function INVOICE_SUMMARY_EXCEL(ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_DATE AS DATE, CUSTOMERMASTER.Customer_cmpname AS NAME, INVOICEMASTER.INVOICE_ORDERNO AS PONO, INVOICEMASTER.INVOICE_ORDERDATE AS PODATE, SUM(INVOICEMASTER_DESC.INVOICE_QTY) AS TOTALSETS, INVOICEMASTER.INVOICE_GRANDTOTAL AS TOTALAMT, (CASE WHEN SUM(INVOICE_QTY) < SALEORDER.SO_TOTALQTY THEN 'PENDING' ELSE 'COMPLETED' END) AS STATUS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_INITIALS = INVOICEMASTER.INVOICE_INITIALS AND INVOICEMASTER_DESC.INVOICE_CMPID = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_DESC.INVOICE_LOCATIONID = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN CUSTOMERMASTER ON INVOICEMASTER.INVOICE_LEDGERID = CUSTOMERMASTER.Customer_id AND INVOICEMASTER.INVOICE_CMPID = CUSTOMERMASTER.Customer_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = CUSTOMERMASTER.Customer_locationid AND INVOICEMASTER.INVOICE_YEARID = CUSTOMERMASTER.Customer_yearid INNER JOIN CMPMASTER ON INVOICEMASTER.INVOICE_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN SALEORDER ON INVOICEMASTER.INVOICE_YEARID = SALEORDER.so_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = SALEORDER.so_locationid AND INVOICEMASTER.INVOICE_CMPID = SALEORDER.so_cmpid AND INVOICEMASTER.INVOICE_ORDERNO = SALEORDER.so_pono", CONDITION & " GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_DATE, CUSTOMERMASTER.Customer_cmpname, INVOICEMASTER.INVOICE_ORDERNO, INVOICEMASTER.INVOICE_ORDERDATE, INVOICEMASTER.INVOICE_GRANDTOTAL, SALEORDER.so_totalqty, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, CMPMASTER.cmp_invinitials")

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("H1", 15)
            SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD1
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD2
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            RowIndex += 1
            Write("INVOICE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("25"))


            RowIndex += 2
            Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Customer", Range("5"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            Write("PO No", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PO Date", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            Write("Total Sets", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            Write("Total Amt", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Transport Name", Range("17"), XlHAlign.xlHAlignCenter, Range("19"), True, 10)
            Write("LR No", Range("20"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            Write("LR Date", Range("22"), XlHAlign.xlHAlignCenter, Range("23"), True, 10)
            Write("Status", Range("24"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)

            SetBorder(RowIndex, Range("1"), Range("25"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("INVOICENO"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), False, 10)
                Write(dr("DATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("NAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                Write(dr("PONO"), Range("8"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PODATE"), Range("11"), XlHAlign.xlHAlignLeft, Range("12"), False, 10)
                Write(dr("TOTALSETS"), Range("13"), XlHAlign.xlHAlignRight, Range("14"), False, 10)
                Write(dr("TOTALAMT"), Range("15"), XlHAlign.xlHAlignRight, Range("16"), False, 10)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - DT.Rows.Count, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - DT.Rows.Count, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - DT.Rows.Count, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - DT.Rows.Count, Range("21"))
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex - DT.Rows.Count, Range("23"))
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex - DT.Rows.Count, Range("25"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            RowIndex += 1
            Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("25").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX DETAILS REPORT"

    Public Function SALES_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_TAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID  FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_BOOKTYPE = 'BOOKING' AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TOTALSALEAMT AS NETT, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILL, 'PACKAGE' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, INTERNATIONALBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER.BOOKING_TAX AS TAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILL, 'INTERNATIONAL' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' union all SELECT CN_initials AS BILLNO, CN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (CN_GTOTAL * (-1)) AS GRANDTOTAL, (CN_TOTALAMT * (-1)) AS NETT  , (CN_SUBTOTAL * (-1)) AS SUBTOTAL,	CN_TAXID AS TAXID, (CN_TAX * (-1)) AS TAXAMT, CN_ADDTAXID AS ADDTAXID, (CN_ADDTAX  * (-1)) AS ADDTAXAMT, (CN_OTHERCHGS * (-1)) AS OTHERCHGS, (CN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, CN_no AS BILL, 'CREDITNOTE' AS TYPE, CN_cmpid AS CMPID, CN_locationid AS LOCATIONID, CN_yearid AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = CN_LEDGERID AND Acc_cmpid =  CN_cmpid AND Acc_locationid = CN_locationid AND Acc_yearid = CN_yearid INNER JOIN CMPMASTER ON CN_cmpid = cmp_id ) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_TAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_ADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("SALES-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX DETAILS REPORT"

    Public Function PURCHASE_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE HOTELBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND HOTELBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE' UNION ALL Select DISTINCT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'PACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL Select DISTINCT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE (INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE')) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim COLINDEX As Integer = 0
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        COLINDEX = DT.Columns.IndexOf(DRADDTAX("TAXNAME"))
                        If COLINDEX = 0 Then DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID") & " OR TAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            If IsDBNull(DR(DRADDTAX("TAXNAME"))) = False Then
                                DR(DRADDTAX("TAXNAME")) = Val(DR(DRADDTAX("TAXNAME"))) + DR("ADDTAXAMT")
                            Else
                                DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                            End If
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("Purchase-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX SUMMARY REPORT"

    Public Function SALES_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS NETTAMT", "", " HOTELBOOKINGMASTER", " AND BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(BOOKING_DATE) = " & Val(DR("MONTH")) & " AND BOOKING_CMPID = " & CMPID & " AND BOOKING_LOCATIONID = " & LOCATIONID & " AND BOOKING_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            'Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN INVOICEMASTER ON EXCISEMASTER.EXCISE_yearid = INVOICEMASTER.INVOICE_YEARID AND EXCISEMASTER.EXCISE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = INVOICEMASTER.INVOICE_CMPID AND EXCISEMASTER.EXCISE_id = INVOICEMASTER.INVOICE_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            'If DTEXCISE.Rows.Count > 0 Then
            '    For Each DREXCISE As DataRow In DTEXCISE.Rows
            '        DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales")
            '        DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Sales")
            '        DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Sales")
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_HSECESSAMT),0) AS HSECESSAMT", "", " INVOICEMASTER", " AND INVOICE_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
            '            Else
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = 0.0
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = 0.0
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = 0.0
            '            End If
            '        Next
            '    Next
            'End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER ON TAXMASTER.TAX_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.TAX_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.TAX_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.TAX_id = HOTELBOOKINGMASTER.BOOKING_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_TAX),0) AS TAXAMT ", "", " HOTELBOOKINGMASTER", " AND HOTELBOOKINGMASTER.BOOKING_TAXID = " & DRTAX("TAXID") & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(HOTELBOOKINGMASTER.BOOKING_DATE) = " & Val(DR("MONTH")) & " AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CMPID & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & LOCATIONID & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            ''FOR ADDTAXAMT
            'Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN INVOICEMASTER ON TAXMASTER.TAX_yearid = INVOICEMASTER.INVOICE_YEARID AND TAXMASTER.TAX_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND TAXMASTER.TAX_cmpid = INVOICEMASTER.INVOICE_CMPID AND TAXMASTER.TAX_id = INVOICEMASTER.INVOICE_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            'If DTADDTAX.Rows.Count > 0 Then
            '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
            '        DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search("ISNULL(SUM(INVOICEMASTER.INVOICE_ADDTAXAMT),0) AS ADDTAXAMT", "", " INVOICEMASTER", " AND INVOICE_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(INVOICE_DATE)= " & DR("MONTH") & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
            '            Else
            '                DR(DRADDTAX("TAXNAME")) = 0.0
            '            End If
            '        Next
            '    Next
            'End If


            'DTMONTH.Columns.Add("FREIGHT")
            'DTMONTH.Columns.Add("OCTROIAMT")
            'DTMONTH.Columns.Add("INSAMT")
            'DTMONTH.Columns.Add("ROUNDOFF")
            'For Each DR As DataRow In DTMONTH.Rows
            '    DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_FREIGHT),0) AS FREIGHT, ISNULL(SUM(INVOICEMASTER.INVOICE_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_INSAMT),0) AS INSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_ROUNDOFF),0) AS ROUNDOFF", "", " INVOICEMASTER", " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '    If DTVAL.Rows.Count > 0 Then
            '        DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
            '        DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
            '        DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
            '        DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
            '    Else
            '        DR("FREIGHT") = 0.0
            '        DR("OCTROIAMT") = 0.0
            '        DR("INSAMT") = 0.0
            '        DR("ROUNDOFF") = 0.0
            '    End If
            'Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            'Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                'Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("SALES-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX SUMMARY REPORT"

    Public Function PURCHASE_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_NETT),0) AS NETTAMT", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN PURCHASEMASTER ON EXCISEMASTER.EXCISE_yearid = PURCHASEMASTER.BILL_YEARID AND EXCISEMASTER.EXCISE_locationid = PURCHASEMASTER.BILL_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = PURCHASEMASTER.BILL_CMPID AND EXCISEMASTER.EXCISE_id = PURCHASEMASTER.BILL_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            If DTEXCISE.Rows.Count > 0 Then
                For Each DREXCISE As DataRow In DTEXCISE.Rows
                    DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase")
                    DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Purchase")
                    DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Purchase")
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(PURCHASEMASTER.BILL_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_HSECESSAMT),0) AS HSECESSAMT", "", " PURCHASEMASTER", " AND BILL_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
                        Else
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = 0.0
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = 0.0
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = 0.0
                        End If
                    Next
                Next
            End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_TAXAMT),0) AS TAXAMT ", "", " PURCHASEMASTER", " AND BILL_TAXID = " & DTTAX.Rows(0).Item("TAXID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            'FOR ADDTAXAMT
            Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTADDTAX.Rows.Count > 0 Then
                For Each DRADDTAX As DataRow In DTADDTAX.Rows
                    DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search("ISNULL(SUM(PURCHASEMASTER.BILL_ADDTAXAMT),0) AS ADDTAXAMT", "", " PURCHASEMASTER", " AND BILL_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(BILL_DATE)= " & DR("MONTH") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
                        Else
                            DR(DRADDTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            DTMONTH.Columns.Add("FREIGHT")
            DTMONTH.Columns.Add("OCTROIAMT")
            DTMONTH.Columns.Add("INSAMT")
            DTMONTH.Columns.Add("ROUNDOFF")
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_FREIGHT),0) AS FREIGHT, ISNULL(SUM(PURCHASEMASTER.BILL_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(PURCHASEMASTER.BILL_INSAMT),0) AS INSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_ROUNDOFF),0) AS ROUNDOFF", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
                    DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
                    DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
                    DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
                Else
                    DR("FREIGHT") = 0.0
                    DR("OCTROIAMT") = 0.0
                    DR("INSAMT") = 0.0
                    DR("ROUNDOFF") = 0.0
                End If
            Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("PURCHASE-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GROUP WISE TRANS DETAILS REPORT"

    Public Function GROUP_TRANS_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("B1", 40)


            'CMPHEADER
            CMPHEADER(CMPID, "GROUP-WISE TRANSACTION REPORT")



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bll No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim ALCOL(1) As String
            ALCOL(0) = ("ACC_INITIALS")
            ALCOL(1) = ("ACC_BILLNO")

            Dim OBJGROUP As New ClsCommon
            Dim DTALL As System.Data.DataTable = OBJGROUP.search("ACC_BILLDATE AS [DATE], NAME, ACC_TYPE AS [TYPE], ACC_BILLNO, ACC_INITIALS , DR,CR, PRIMARYGROUP ", "", " REGISTER ", CONDITION & " AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " ORDER BY ACC_BILLDATE")
            Dim DTMAIN As System.Data.DataTable = DTALL.DefaultView.ToTable(True, ALCOL)
            Dim DR() As System.Data.DataRow = DTMAIN.Select("ACC_INITIALS <> '0'", "ACC_BILLNO ASC")
            Dim DR1() As System.Data.DataRow
            For I As Integer = 0 To DR.GetUpperBound(0)

                DR1 = DTALL.Select("ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")

                Dim DTINITIALPARTY As System.Data.DataTable = OBJGROUP.search(" TOP(1) NAME", "", " REGISTER", " and acc_cmpid = " & CMPID & " and YEARID = " & YEARID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND name NOT IN (SELECT name FROM REGISTER WHERE REGISTER.acc_cmpid = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND REGISTER.YEARID = " & YEARID & CONDITION & ")  and acc_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")
                If DTINITIALPARTY.Rows.Count > 0 Then
                    RowIndex += 2
                    Write(Format(Convert.ToDateTime(DR1(0)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTINITIALPARTY.Rows(0).Item("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTALL.Compute("SUM(CR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTALL.Compute("SUM(DR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                    For A As Integer = 0 To DR1.GetUpperBound(0)

                        RowIndex += 1
                        Write(Format(Convert.ToDateTime(DR1(A)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("     " & DR1(A)("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(DR1(A)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("DR"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DR1(A)("cr"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Next
                End If

            Next



            For I As Integer = 1 To 6
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))


            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("6").ToString & RowIndex + 1)


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TRIALBALANCE"

    Public Function TRIALBALANCE_EXCEL(ByVal CONDITION As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("TRIAL-BALANCE (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Name", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("O/P Dr", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("O/P Cr", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Dr", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Cr", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " TEMPTRIALBALANCEPRINT", " ORDER BY ROWNO")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                If DTROW("OPENINGDR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGDR")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("OPENINGCR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGCR")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

                If DTROW("CLOSINGDR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGDR")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("CLOSINGCR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGCR")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If Left(DTROW("NAME"), 1) = " " And Left(DTROW("NAME"), 6) <> "      " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                ElseIf Left(DTROW("NAME"), 1) <> " " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE SUMMARY (REGISTER WISE)"

    Public Function REGISTERPURCHASESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'PURCHASE' AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL PURCHASE", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_PURCHASESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("PURCHASE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 5
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALE SUMMARY (REGISTER WISE)"

    Public Function REGISTERSALESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'SALE' AND REGISTER_CMPID = " & CMPID & " AND REGISTER_LOCATIONID = " & LOCATIONID & " AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL SALES", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_INVOICESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next

            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("SALE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 5
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "CST REPORTS"

    Public Function CSTSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)



            RowIndex = 1
            Write("SALES DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CSTPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)


            RowIndex = 1
            Write("PURCHASE DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "SOR"

            SetColumnWidth(Range(10), 20)
            SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" cmp_displayedname AS NAME, cmp_cstno AS CSTNO, cmp_email AS EMAILID, cmp_tel AS MOBILENO ", "", " CMPMASTER ", " AND CMP_ID = " & CMPID)
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(LEDGERS.Acc_tinno, '') AS CSTNO, COUNT(DISTINCT PURCHASEMASTER.BILL_INITIALS) AS NOOFTRANS, SUM(PURCHASEMASTER.BILL_BILLAMT) AS GRANDTOTAL, ISNULL(LEDGERS.Acc_email, '') AS EMAIL, ISNULL(LEDGERS.Acc_mobile, '') AS MOBILENO ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND FORM_NAME = 'C FORM' AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' GROUP BY LEDGERS.Acc_cmpname, ISNULL(STATEMASTER.state_name, ''), ISNULL(LEDGERS.Acc_tinno, ''), ISNULL(LEDGERS.Acc_email, ''), ISNULL(LEDGERS.Acc_mobile, '') ORDER BY LEDGERS.ACC_CMPNAME")



            RowIndex = 1
            Write("Statement of Requirement of Statutory Forms", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1

            Write("(To Be Filled in Capital Letters)", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1


            Write("Name of the Form Issueing Dealer", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("7"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("7"))

            Write("Email Id", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("8"), Range("8")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write(DTCMP.Rows(0).Item("EMAILID"), Range("9"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("9"), Range("10"))

            Write("Ver 1.4.0", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(0, 0, 255)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("CST TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, Range("5"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("5"))

            Write("Location Of Main POB", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))


            Write("01-Mazgoan", Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            Write("Period", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("9"), Range("9")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex + 1)

            Write("From Date (DD/MM/YY)", Range("10"), XlHAlign.xlHAlignLeft, Range("10"), True, 9)
            objSheet.Range(Range("10"), Range("10")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("10"), Range("10")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("10"), Range("10"))


            Write("To Date (DD/MM/YY)", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), True, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("Date Of Application (dd-mmm-yy)", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write("", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("4"))

            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Mobile No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write(DTCMP.Rows(0).Item("MOBILENO"), Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)

            Write(FROMDATE.Date, Range("10"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write(Format(TODATE.Date, "dd/MM/yy"), Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("Form Type", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Name of the Form Accepting Dealer", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("State of the form Accepting Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("CST TIN of the Form Accepting Dealer", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Period of Transaction", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Total No Of Transactions", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Total Value Of Transaction Including Tax", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Email Id of Accepting Dealer", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Mobile No Of Accepting Dealer", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("2", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("3", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("4", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("5 (From)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("6 (To)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("7", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("8", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("9", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("10", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("C-FORM", Range("1"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), True, 9)
                Write(DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CSTNO"), Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Format(TODATE.Date, "dd/MM/yy"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("NOOFTRANS")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("EMAIL"), Range("10"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("MOBILENO"), Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("11"))
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION1(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next

            objSheet.Name = "C FORM DETAILS"

            SetColumnWidth(Range(1), 5)
            'SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, CAST(PURCHASEMASTER.BILL_PARTYBILLNO AS VARCHAR(20)) AS BILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS BILLDATE, PURCHASEMASTER.BILL_BILLAMT AS BILLAMT, PURCHASEMASTER_CHGS.BILL_AMT AS TAXES, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_TOTALMTRS AS TOTALWT  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND  PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID AND  PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER_CHGS.BILL_TAXID > 0 AND FORM_NAME = 'C FORM' AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' ORDER BY LEDGERS.ACC_CMPNAME, PURCHASEMASTER.BILL_PARTYBILLDATE")



            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("C/F Form Invoice Wise Details", Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("12"))

            Write("Ver 1.4.0", Range("13"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("13"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Linking Fields", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))

            Write("Common Fields", Range("6"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("6"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Sno", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Form Type Requested", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("CST TIN of Form Accepting Dealer", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period Of TRansaction (DD-MM-YY)", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("5"))

            Write("Invoice No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Invoice Date (DD-MM-YY)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Nett Value Of Invoice", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Gross Value Of Invoice", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Description Of Goods", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            Write("Quantity Of Goods", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 9, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Purpose of Purchase", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 9, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Remarks", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 9, True)
            SetBorder(RowIndex, Range("14"), Range("14"))
            RowIndex += 1

            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("From", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("To", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            SetBorder(RowIndex, Range("6"), Range("6"))
            SetBorder(RowIndex, Range("7"), Range("7"))
            SetBorder(RowIndex, Range("8"), Range("8"))
            SetBorder(RowIndex, Range("9"), Range("9"))
            SetBorder(RowIndex, Range("10"), Range("10"))
            SetBorder(RowIndex, Range("11"), Range("11"))
            SetBorder(RowIndex, Range("12"), Range("12"))
            SetBorder(RowIndex, Range("13"), Range("13"))
            SetBorder(RowIndex, Range("14"), Range("14"))


            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write("C-FORM", Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("TINNO"), Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(TODATE.Date, Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BILLNO"), Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BILLDATE"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXES")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write("YARN", Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("TOTALWT")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write("Resale", Range("13"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("14"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "VAT REPORTS"

    Public Function VATSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object

        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201A", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer to whom goods sold", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Sale of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Sale of Goods to registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function VATPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201B", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer from whom goods purchased", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Purchase of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Purchase of Goods from registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TAX REPORTS"

    Public Function TAXREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 30)


            ' **************************** CMPHEADER *************************
            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))




            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Select()
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Application.ActiveWindow.FreezePanes = True

            ' **************************** CMPHEADER *************************


            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 2
            Write("PURCHASE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("Type Of Purchase", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Gross Amount", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("2"))
            Write("Other Charges", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Tax %", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("V.A.T.", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("C.S.T.", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Round Off", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Nett Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)

            Dim DT As System.Data.DataTable = OBJCMN.search(" A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT PURCHASEMASTER.BILL_PARTYBILLDATE AS [DATE], PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, ISNULL(SUM(PURCHASEMASTER_CHGS.BILL_AMT),0) AS CHARGES, 0 AS TAX,0 AS VAT,0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER LEFT OUTER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(BILL_TAXID,0) = 0) GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE ,PURCHASEMASTER.BILL_INITIALS,REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL  SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, SUM(PURCHASEMASTER_CHGS.BILL_AMT) AS VAT, 0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id WHERE TAX_ISVAT = 'True' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(PURCHASEMASTER_CHGS.BILL_AMT) AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF,PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'True' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID ) AS T  " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next
            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 9 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))



            'SALE DETAILS
            RowIndex += 2
            Write("SALE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            Dim SSTART As Integer = RowIndex
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))
            DT = OBJCMN.search("A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT    INVOICEMASTER.INVOICE_DATE AS [DATE], INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, ISNULL(SUM(INVOICEMASTER_CHGS.INVOICE_AMT),0) AS CHARGES,0 AS TAX,0 AS VAT,0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER LEFT OUTER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(INVOICE_TAXID ,0)= 0)  GROUP BY INVOICEMASTER.INVOICE_DATE ,INVOICEMASTER.INVOICE_INITIALS,REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL  SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, SUM(INVOICEMASTER_CHGS.INVOICE_AMT) AS VAT, 0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISVAT = 'True' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(INVOICEMASTER_CHGS.INVOICE_AMT) AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF,INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'True' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID ) AS T  " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next

            objSheet.Range(Range("4")).NumberFormat = "0.00"
            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"

            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & SSTART & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & SSTART & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & SSTART & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & SSTART & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & SSTART & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & SSTART & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & SSTART & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J1REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next


            RowIndex += 1
            Write("Sales Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CUSTOMER-WISE VAT SALES", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("TIN of Customer", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Nett Taxable Amount Rs.", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("V.A.T. Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Gross Total Rs.", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, SUM(INVOICEMASTER.INVOICE_AMOUNT) AS TOTALAMT, 0 AS TAXAMT, SUM(INVOICEMASTER.INVOICE_GRANDTOTAL) AS GTOTAL", "", " INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID", WHERECLAUSE & " AND TAX_ISVAT = 'True' AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("TINNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, Range("6"), False, 12)
                objSheet.Range(Range("5"), Range("6")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("2"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, Range("6"), True, 12)
            objSheet.Range(Range("3"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J2REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next


            RowIndex += 1
            Write("Purchase Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("SUPPLIERS-WISE VAT PURCHASE", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("TIN of Suppliers", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Nett Taxable Amount Rs.", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("V.A.T. Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Gross Total Rs.", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, SUM(PURCHASEMASTER.BILL_BILLAMT) AS TOTALAMT, SUM(PURCHASEMASTER.BILL_TOTALTAXAMT) AS TAXAMT, SUM(PURCHASEMASTER.BILL_GRANDTOTAL) AS GTOTAL", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id INNER JOIN REGISTERMASTER ON REGISTER_ID = PURCHASEMASTER.BILL_REGISTERID", WHERECLAUSE & " AND TAX_ISVAT = 'True' AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("TINNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, Range("6"), False, 12)
                objSheet.Range(Range("5"), Range("6")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("2"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, Range("6"), True, 12)
            objSheet.Range(Range("3"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next
            SetColumnWidth(Range("2"), 60)


            RowIndex += 1
            Write("ANNEXURE-G", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("To", Range("7"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))


            RowIndex += 1
            Write("Enter Declaration wise Top 4999 seperately in descending order and put Total of Remaining in 5000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("1"), Range("8")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 1
            Write("Details of Declarations or Certificates Received", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of the Dealer who has issued Declaration or Certificated", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN / RC No", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Declaration or Cretificate Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Issuing State", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Declaration No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Gross Amt as per Invoice covered by Declaration (Net of goods returned) (Rs.)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12, True)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Amount for which Declaration received (Rs.)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12, True)
            SetBorder(RowIndex, Range("8"), Range("8"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("7", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("8", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("8"), Range("8"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " (select NAME, CSTNO, FORMNAME, STATENAME, FORMNO,SUM(AMT) AS AMT from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'C FORM' and TYPE = 'SALE' AND FORMNO <> ''  " & WHERECLAUSE & " GROUP BY NAME, CSTNO, FORMNAME, STATENAME, FORMNO UNION ALL select NAME, CSTNO, FORMNAME, STATENAME, FORMNO,SUM(AMT) AS AMT from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'E1 FORM' and TYPE = 'PURCHASE' AND FORMNO <> '' " & WHERECLAUSE & " GROUP BY NAME, CSTNO, FORMNAME, STATENAME, FORMNO) AS T ", "")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("STATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNO"), Range("6"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 8 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("7"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("8"))


            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0"
            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function IREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 13)
            Next
            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 60)
            SetColumnWidth(Range("5"), 8)
            SetColumnWidth(Range("6"), 9)


            RowIndex += 1
            Write("ANNEXURE-I", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("11"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            objSheet.Range(Range("6"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("To", Range("8"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("9"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            objSheet.Range(Range("9"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("11"))


            RowIndex += 1
            Write("Enter Declaration wise Top 4999 seperately in descending order and put Total of Remaining in 5000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            objSheet.Range(Range("1"), Range("11")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("11"))


            RowIndex += 1
            Write("Details of Declarations or Certificates not Received Under Cenrtal Sales Tax Act, 1956. (Other than Local Form-H)", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("11"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of the Dealer who has issued Declaration or Certificated", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("CST TIN No", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Declaration or Cretificate Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Invoice No", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Invoice Date", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12, True)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Taxable Amount (Rs.) (Net)", Range("7"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Tax Amount (Rs.)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12, True)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Rate of Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Amount of Tax (Column 7*9*%)", Range("10"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("Differential tax liability (Rs.) (Col 10 - Col 8)", Range("11"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("11"), Range("11"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("7", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("8", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("9", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("10", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("11", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            SetBorder(RowIndex, Range("11"), Range("11"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " (select NAME, CSTNO, FORMNAME, CAST(BILL AS VARCHAR(30)) AS BILLINITIALS, DATE, AMT, TAXAMT, TAXPER, BILL, QUARTERNAME from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'C FORM' and TYPE = 'SALE' AND (FORMNO = '' OR (FORMNO <> '' AND RECDATE > '" & Format(TODATE.Date, "MM/dd/yyyy") & "'))  UNION ALL select NAME, CSTNO, FORMNAME, CFORMVIEW.BILLINITIALS, DATE, AMT, TAXAMT, TAXPER, BILL, QUARTERNAME from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'E1 FORM' and TYPE = 'PURCHASE' AND (FORMNO = '' OR (FORMNO <> '' AND RECDATE > '" & Format(TODATE.Date, "MM/dd/yyyy") & "'))) AS T ", " ORDER BY T.FORMNAME,T.QUARTERNAME, T.NAME, T.DATE, T.BILL ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("BILLINITIALS"), Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 12)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXPER")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 12)
                FORMULA("=ROUND((" & objColumn.Item("7").ToString & RowIndex & "*" & objColumn.Item("9").ToString & RowIndex & ")/100,0)", Range("10"), XlHAlign.xlHAlignRight, , False, 12)
                FORMULA("=ROUND((" & objColumn.Item("7").ToString & RowIndex & "*" & objColumn.Item("9").ToString & RowIndex & ")/100,0)", Range("11"), XlHAlign.xlHAlignRight, , False, 12)
                objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("11"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 8 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 8 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 8 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("7"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))


            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J6REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 15)
            Next
            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 60)
            SetColumnWidth(Range("5"), 8)


            RowIndex += 1
            Write("ANNEXURE-J (SECTION 6)", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            Write(FROMDATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("To", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("6"))


            RowIndex += 1
            Write("EnteSupplier Wise Transactions Under CST Act, 1956", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Enter Gross Amount wise Top 999 Separately in descending order and put Total of Remaining in 1000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of Supplier", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN No Supplier (If Any)", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Transaction Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Any Other Cost of Purchase", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Gross Amount (Rs.)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12, True)
            SetBorder(RowIndex, Range("6"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" NAME, CSTNO, SUM(AMT) AS AMOUNT ", "", " CFORMVIEW ", " AND TYPE = 'PURCHASE' AND FORMNAME = 'E1 FORM' AND YEARID = " & YEARID & WHERECLAUSE & " GROUP BY NAME, CSTNO ORDER BY NAME ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write("Purchase u/s 6(2)", Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("AMOUNT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 12)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next

            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 8 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function SALES231REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("4"), 40)
            SetColumnWidth(Range("5"), 20)
            SetColumnWidth(Range("18"), 72)


            RowIndex += 1
            Write("Annexure of Sales under M.V.A.T. Act, 2002 (See Rule 17, 17A, 18 and 45)", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("18"))

            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("M.V.A.T. R.C. No.", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("8"), Range("10"))

            Write("C.S.T. R.C. No.", Range("11"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("11"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("16"))

            Write("", Range("17"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("17"), Range("18"))


            RowIndex += 1
            Write("2", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("Name of the Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("18"))


            RowIndex += 1
            Write("3", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Type Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether First Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))



            RowIndex += 1
            Write("Periodicity Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether Last Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Period Covered By Annexure", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), objColumn.Item("6").ToString & RowIndex + 1)

            Write("From", Range("7"), XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("7"), objColumn.Item("7").ToString & RowIndex + 1)

            Write("Date", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Month", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Year", Range("10"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("10"), Range("11"))

            Write("To", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Date", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("13"), Range("14"))

            Write("Month", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("15"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("15"), Range("16"))

            Write("Year", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("17"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("17"), Range("17"))


            Write("", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            RowIndex += 2
            Write("Transactionwise Sales Details", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("18"))


            RowIndex += 1
            Write("Gross Total", Range("1"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("5"))


            FORMULA("=ROUND(SUM(" & objColumn.Item("6").ToString & 12 & ":" & objColumn.Item("6").ToString & RowIndex + 104857 & "),2)", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("7").ToString & 12 & ":" & objColumn.Item("7").ToString & RowIndex + 104857 & "),2)", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("8").ToString & 12 & ":" & objColumn.Item("8").ToString & RowIndex + 104857 & "),2)", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("9").ToString & 12 & ":" & objColumn.Item("9").ToString & RowIndex + 104857 & "),2)", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("9"), Range("9"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("10").ToString & 12 & ":" & objColumn.Item("10").ToString & RowIndex + 104857 & "),2)", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("10"), Range("10"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("11").ToString & 12 & ":" & objColumn.Item("11").ToString & RowIndex + 104857 & "),2)", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("11"), Range("11"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("12").ToString & 12 & ":" & objColumn.Item("12").ToString & RowIndex + 104857 & "),2)", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("12"), Range("12"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("13").ToString & 12 & ":" & objColumn.Item("13").ToString & RowIndex + 104857 & "),2)", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("13"), Range("13"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("14").ToString & 12 & ":" & objColumn.Item("14").ToString & RowIndex + 104857 & "),2)", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("14"), Range("14"))


            Write("", Range("15"), XlHAlign.xlHAlignRight, Range("18"), True, 10)
            SetBorder(RowIndex, Range("15"), Range("18"))


            RowIndex += 1
            Write("Sr. No.", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("1").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("17")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), objColumn.Item("1").ToString & RowIndex + 1)

            Write("Invoice No.", Range("2"), XlHAlign.xlHAlignCenter, objColumn.Item("2").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("2"), objColumn.Item("2").ToString & RowIndex + 1)

            Write("Date Of Invoice", Range("3"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("3"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Name", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("4").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("4"), objColumn.Item("4").ToString & RowIndex + 1)

            Write("TIN Of Purchaser (If Any)", Range("5"), XlHAlign.xlHAlignCenter, objColumn.Item("5").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("5"), objColumn.Item("5").ToString & RowIndex + 1)

            Write("Taxable Value Or Value of Composition u/s 42(3),(3A), (4)", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Nett Rs.", objColumn.Item("6").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10, True)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            Write("Tax (If Any)", objColumn.Item("7").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            Write("Value Inclusive of Tax Rs.", Range("8"), XlHAlign.xlHAlignCenter, objColumn.Item("8").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("8"), objColumn.Item("8").ToString & RowIndex + 1)

            Write("Value of Compisition u/s 42 (1), (2) Rs.", Range("9"), XlHAlign.xlHAlignCenter, objColumn.Item("9").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("9"), objColumn.Item("9").ToString & RowIndex + 1)

            Write("Tax Free Sales Rs.", Range("10"), XlHAlign.xlHAlignCenter, objColumn.Item("10").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("10"), objColumn.Item("10").ToString & RowIndex + 1)

            Write("Exempted Sales u/s 41 & 8 Rs.", Range("11"), XlHAlign.xlHAlignCenter, objColumn.Item("11").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("11"), objColumn.Item("11").ToString & RowIndex + 1)

            Write("Labour Charges Rs.", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Other Charges (Rs.)", Range("13"), XlHAlign.xlHAlignCenter, objColumn.Item("13").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("13"), objColumn.Item("13").ToString & RowIndex + 1)

            Write("Gross Total (Rs.)", Range("14"), XlHAlign.xlHAlignCenter, objColumn.Item("14").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("14"), objColumn.Item("14").ToString & RowIndex + 1)

            Write("Action", Range("15"), XlHAlign.xlHAlignCenter, objColumn.Item("15").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("15"), objColumn.Item("15").ToString & RowIndex + 1)

            Write("Return Form No", Range("16"), XlHAlign.xlHAlignCenter, objColumn.Item("16").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("16"), objColumn.Item("16").ToString & RowIndex + 1)

            Write("Transaction Code", Range("17"), XlHAlign.xlHAlignCenter, objColumn.Item("17").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("17"), objColumn.Item("17").ToString & RowIndex + 1)

            Write("Description of Transaction Type", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            'GET DATA
            RowIndex += 1
            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" INVOICE_NO AS INVOICENO, INVOICE_DATE AS DATE, ACC_CMPNAME AS PARTYNAME, Acc_VATNO AS TINNO, INVOICE_AMOUNT AS NETTAMT, 0 AS TAXAMT, ROUND((INVOICE_CHARGES + INVOICE_ROUNDOFF),2) AS OTHERCHGS, INVOICE_GRANDTOTAL AS GRANDTOTAL, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 200 ELSE 100 END) AS CODE, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 'Sales to Non-TIN Holder (Within the State or Interstate)' ELSE 'Sales to TIN Holder (Within the State or Interstate Excluding Against Forms / Declaration)' END) AS CODEDESC", "", " INVOICEMASTER INNER JOIN LEDGERS ON Acc_id = INVOICE_LEDGERID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY DATE, INVOICENO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("INVOICENO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10, True)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("PARTYNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("TINNO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("OTHERCHGS")), "0.00"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("GRANDTOTAL")), "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write("231", Range("16"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODE"), Range("17"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODEDESC"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)

                SetBorder(RowIndex, Range("1"), Range("18"))
                SRNO += 1
            Next

            objSheet.Range(objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 12, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 12, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 12, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 12, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 12, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & 12, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & 12, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & 12, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & 12, objColumn.Item("18").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100


            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function PURCHASE231REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("4"), 40)
            SetColumnWidth(Range("5"), 20)
            SetColumnWidth(Range("18"), 72)


            RowIndex += 1
            Write("Annexure of Purchase under M.V.A.T. Act, 2002 (See Rule 17, 17A, 18 and 45)", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("18"))

            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("M.V.A.T. R.C. No.", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))

            Write("C.S.T. R.C. No.", Range("11"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("11"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("16"))

            Write("", Range("17"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("17"), Range("18"))


            RowIndex += 1
            Write("2", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("Name of the Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("18"))


            RowIndex += 1
            Write("3", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Type Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether First Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))



            RowIndex += 1
            Write("Periodicity Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether Last Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Period Covered By Annexure", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), objColumn.Item("6").ToString & RowIndex + 1)

            Write("From", Range("7"), XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("7"), objColumn.Item("7").ToString & RowIndex + 1)

            Write("Date", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Month", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Year", Range("10"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("10"), Range("11"))

            Write("To", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Date", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("13"), Range("14"))

            Write("Month", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("15"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("15"), Range("16"))

            Write("Year", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("17"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("17"), Range("17"))


            Write("", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            RowIndex += 2
            Write("Transactionwise Purchase Details", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("18"))


            RowIndex += 1
            Write("Gross Total", Range("1"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("5"))


            FORMULA("=ROUND(SUM(" & objColumn.Item("6").ToString & 12 & ":" & objColumn.Item("6").ToString & RowIndex + 104857 & "),2)", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("7").ToString & 12 & ":" & objColumn.Item("7").ToString & RowIndex + 104857 & "),2)", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("8").ToString & 12 & ":" & objColumn.Item("8").ToString & RowIndex + 104857 & "),2)", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("9").ToString & 12 & ":" & objColumn.Item("9").ToString & RowIndex + 104857 & "),2)", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("9"), Range("9"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("10").ToString & 12 & ":" & objColumn.Item("10").ToString & RowIndex + 104857 & "),2)", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("10"), Range("10"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("11").ToString & 12 & ":" & objColumn.Item("11").ToString & RowIndex + 104857 & "),2)", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("11"), Range("11"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("12").ToString & 12 & ":" & objColumn.Item("12").ToString & RowIndex + 104857 & "),2)", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("12"), Range("12"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("13").ToString & 12 & ":" & objColumn.Item("13").ToString & RowIndex + 104857 & "),2)", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("13"), Range("13"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("14").ToString & 12 & ":" & objColumn.Item("14").ToString & RowIndex + 104857 & "),2)", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("14"), Range("14"))



            Write("", Range("15"), XlHAlign.xlHAlignRight, Range("18"), True, 10)
            SetBorder(RowIndex, Range("15"), Range("18"))


            RowIndex += 1
            Write("Sr. No.", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("1").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("17")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), objColumn.Item("1").ToString & RowIndex + 1)

            Write("Invoice No.", Range("2"), XlHAlign.xlHAlignCenter, objColumn.Item("2").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("2"), objColumn.Item("2").ToString & RowIndex + 1)

            Write("Date Of Invoice", Range("3"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("3"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Name", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("4").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("4"), objColumn.Item("4").ToString & RowIndex + 1)

            Write("TIN Of Seller (If Any)", Range("5"), XlHAlign.xlHAlignCenter, objColumn.Item("5").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("5"), objColumn.Item("5").ToString & RowIndex + 1)

            Write("Taxable Value Or Value of Composition u/s 42(3),(3A), (4)", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Nett Rs.", objColumn.Item("6").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10, True)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            Write("Tax (If Any)", objColumn.Item("7").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            Write("Value Inclusive of Tax Rs.", Range("8"), XlHAlign.xlHAlignCenter, objColumn.Item("8").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("7"), objColumn.Item("8").ToString & RowIndex + 1)

            Write("Value of Compisition u/s 42 (1), (2) Rs.", Range("9"), XlHAlign.xlHAlignCenter, objColumn.Item("9").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("9"), objColumn.Item("9").ToString & RowIndex + 1)

            Write("Tax Free Sales Rs.", Range("10"), XlHAlign.xlHAlignCenter, objColumn.Item("10").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("10"), objColumn.Item("10").ToString & RowIndex + 1)

            Write("Exempted Sales u/s 41 & 8 Rs.", Range("11"), XlHAlign.xlHAlignCenter, objColumn.Item("11").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("11"), objColumn.Item("11").ToString & RowIndex + 1)

            Write("Labour Charges Rs.", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Other Charges (Rs.)", Range("13"), XlHAlign.xlHAlignCenter, objColumn.Item("13").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("13"), objColumn.Item("13").ToString & RowIndex + 1)

            Write("Gross Total (Rs.)", Range("14"), XlHAlign.xlHAlignCenter, objColumn.Item("14").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("14"), objColumn.Item("14").ToString & RowIndex + 1)

            Write("Action", Range("15"), XlHAlign.xlHAlignCenter, objColumn.Item("15").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("15"), objColumn.Item("15").ToString & RowIndex + 1)

            Write("Return Form No", Range("16"), XlHAlign.xlHAlignCenter, objColumn.Item("16").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("16"), objColumn.Item("16").ToString & RowIndex + 1)

            Write("Transaction Code", Range("17"), XlHAlign.xlHAlignCenter, objColumn.Item("17").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("17"), objColumn.Item("17").ToString & RowIndex + 1)

            Write("Description of Transaction Type", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            'GET DATA
            RowIndex += 1
            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" BILL_PARTYBILLNO AS INVOICENO, BILL_PARTYBILLDATE AS DATE, ACC_CMPNAME AS PARTYNAME, Acc_VATNO AS TINNO, BILL_BILLAMT AS NETTAMT, BILL_TOTALTAXAMT AS TAXAMT, ROUND((BILL_TOTALCHGSAMT + BILL_ROUNDOFF),2) AS OTHERCHGS, BILL_GRANDTOTAL AS GRANDTOTAL, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 20 ELSE 10 END) AS CODE, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 'Within the State URD Purchases' ELSE 'Within the State Purchases from  RD' END) AS CODEDESC, REGISTERMASTER.REGISTER_NAME AS REGNAME ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON Acc_id = BILL_LEDGERID  INNER JOIN REGISTERMASTER ON REGISTER_ID = PURCHASEMASTER.BILL_REGISTERID ", WHERECLAUSE & " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " ORDER BY DATE, INVOICENO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("INVOICENO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10, True)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("PARTYNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("TINNO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("OTHERCHGS")), "0.00"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("GRANDTOTAL")), "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write("231", Range("16"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODE"), Range("17"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODEDESC"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("REGNAME"), Range("19"), XlHAlign.xlHAlignLeft, , False, 10)

                SetBorder(RowIndex, Range("1"), Range("18"))
                SRNO += 1
            Next

            objSheet.Range(objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 12, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 12, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 12, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 12, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 12, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & 12, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & 12, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & 12, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & 12, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & 12, objColumn.Item("19").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100


            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "COST SHEET"

    Public Function COSTSHEET_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal SHRINKAGENO As Integer, ByVal AVGSHRINKAGEPER As Double, ByVal DYEINGNAME As String) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("21"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("21"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("21"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("21"))

            RowIndex += 1
            Write("COST SHEET", Range("1"), XlHAlign.xlHAlignCenter, Range("21"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("21"))


            ''FREEZE TOP 7 ROWS
            'objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("21").ToString & 8).Select()
            'objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("21").ToString & 8).Application.ActiveWindow.FreezePanes = True


            'LOT DETAILS
            RowIndex += 2
            Write("PROCESS NAME", Range("1"), XlHAlign.xlHAlignCenter,, True, 12)
            Write("LR NO", Range("2"), XlHAlign.xlHAlignCenter,, True, 12)
            Write("MTRS", Range("3"), XlHAlign.xlHAlignCenter, , True, 12)
            Write("RATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 12)
            Write("AMOUNT", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            Write("LOTNO", Range("6"), XlHAlign.xlHAlignCenter, , True, 12)
            Write("ITEM NAME", Range("7"), XlHAlign.xlHAlignCenter, , True, 12)
            Write("SUPPIER NAME", Range("8"), XlHAlign.xlHAlignCenter, , True, 12)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            'DT = OBJCMN.search("  DISTINCT ISNULL(DYEINGLEDGERS.Acc_cmpname, '') AS DYEINGNAME, ISNULL(GRN.grn_lrno, '') AS LRNO, ISNULL(GRN.GRN_TOTALMTRS, 0) AS MTRS, ISNULL(BILL_RATE,0) AS RATE, ISNULL(BILL_amt,0) AS AMOUNT, ISNULL(GRN.GRN_PLOTNO, '') AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME ", "", " LOTCOMPLETED INNER JOIN GRN ON LOTCOMPLETED.LOT_DYEINGID = GRN.GRN_TOLEDGERID and LOTCOMPLETED.LOT_YEARID = GRN.GRN_YEARID INNER JOIN LOTCOMPLETED_DESC ON LOTCOMPLETED.LOT_NO = LOTCOMPLETED_DESC.LOT_NO AND LOTCOMPLETED.LOT_YEARID = LOTCOMPLETED_DESC.LOT_YEARID AND GRN.GRN_PLOTNO = LOTCOMPLETED_DESC.LOT_LOTNO INNER JOIN ITEMMASTER ON LOTCOMPLETED_DESC.LOT_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS AS DYEINGLEDGERS ON LOTCOMPLETED.LOT_DYEINGID = DYEINGLEDGERS.Acc_id INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN  PURCHASEMASTER_DESC ON GRN.GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO AND PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' ", " AND LOTCOMPLETED.LOT_NO = " & SHRINKAGENO & " AND LOTCOMPLETED.LOT_YEARID = " & YEARID & " ORDER BY LOTNO")
            DT = OBJCMN.search("*", "", "(SELECT DISTINCT ISNULL(DYEINGLEDGERS.Acc_cmpname, '') AS DYEINGNAME, ISNULL(GRN.grn_lrno, '') AS LRNO, ISNULL(GRN.GRN_TOTALMTRS, 0) AS MTRS, ISNULL(BILL_RATE,0) AS RATE, ISNULL(BILL_amt,0) AS AMOUNT, ISNULL(GRN.GRN_PLOTNO, '') AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME FROM LOTCOMPLETED INNER JOIN GRN ON LOTCOMPLETED.LOT_DYEINGID = GRN.GRN_TOLEDGERID and LOTCOMPLETED.LOT_YEARID = GRN.GRN_YEARID INNER JOIN LOTCOMPLETED_DESC ON LOTCOMPLETED.LOT_NO = LOTCOMPLETED_DESC.LOT_NO AND LOTCOMPLETED.LOT_YEARID = LOTCOMPLETED_DESC.LOT_YEARID AND GRN.GRN_PLOTNO = LOTCOMPLETED_DESC.LOT_LOTNO INNER JOIN ITEMMASTER ON LOTCOMPLETED_DESC.LOT_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS AS DYEINGLEDGERS ON LOTCOMPLETED.LOT_DYEINGID = DYEINGLEDGERS.Acc_id INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN  PURCHASEMASTER_DESC ON GRN.GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO AND PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE LOTCOMPLETED.LOT_NO = " & SHRINKAGENO & " AND LOTCOMPLETED.LOT_YEARID = " & YEARID & " UNION ALL SELECT DISTINCT ISNULL(DYEINGLEDGERS.Acc_cmpname, '') AS DYEINGNAME, ISNULL(JOBOUT.JO_lrno, '') AS LRNO, ISNULL(JOBOUT.JO_TOTALMTRS, 0) AS MTRS, ISNULL(BILL_RATE,0) AS RATE, ISNULL(BILL_amt,0) AS AMOUNT, ISNULL(JOBOUT.JO_LOTNO, '') AS LOTNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME FROM LOTCOMPLETED INNER JOIN JOBOUT ON LOTCOMPLETED.LOT_DYEINGID = JOBOUT.JO_LEDGERID and LOTCOMPLETED.LOT_YEARID = JOBOUT.JO_YEARID INNER JOIN LOTCOMPLETED_DESC ON LOTCOMPLETED.LOT_NO = LOTCOMPLETED_DESC.LOT_NO AND LOTCOMPLETED.LOT_YEARID = LOTCOMPLETED_DESC.LOT_YEARID AND JOBOUT.JO_LOTNO = LOTCOMPLETED_DESC.LOT_LOTNO INNER JOIN ITEMMASTER ON LOTCOMPLETED_DESC.LOT_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS AS DYEINGLEDGERS ON LOTCOMPLETED.LOT_DYEINGID = DYEINGLEDGERS.Acc_id INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN PURCHASEMASTER_DESC ON JOBOUT.JO_NO = PURCHASEMASTER_DESC.BILL_GRNNO AND PURCHASEMASTER_DESC.BILL_TYPE = 'JOBIN' WHERE LOTCOMPLETED.LOT_NO = " & SHRINKAGENO & " AND LOTCOMPLETED.LOT_YEARID = " & YEARID & ") AS T", " ORDER BY T.LOTNO")
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("DYEINGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(ROW("LRNO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("MTRS")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("RATE")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("AMOUNT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(ROW("LOTNO"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(ROW("ITEMNAME"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(ROW("NAME"), Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
            Next


            'GET TOTAL
            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 8 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 8 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 8 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")/SUM(" & objColumn.Item("3").ToString & 8 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)

            Dim AVGGREYRATE As Double = Format(Val(objSheet.Range("D" & RowIndex.ToString).Text), "0.000")


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)



            RowIndex += 3
            Dim NEWGRIDINDEX As Integer = RowIndex

            Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DESIGN NO", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SHADE", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("MTRS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("ISSUED TO PACK MTRS", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BAL TO PACK MTRS", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("LOT NO", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GREY RATE", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DYEING RATE", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TRANS", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CHECKING", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PACKING", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DESIGN", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SHRINKAGE @" & Val(AVGSHRINKAGEPER), Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RATE B/F V.LOSS", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("V.LOSS MTRS", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("V.LOSS %", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("V.LOSS RATE", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("COSTING", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("AMOUNT", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("REMARKS", Range("21"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, objColumn.Item("19").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, objColumn.Item("20").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("21").ToString & RowIndex, objColumn.Item("21").ToString & RowIndex)




            DT = OBJCMN.search("*", "", " (SELECT ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS) AS MTRS, SUM(MATERIALRECEIPT_DESC.MATREC_OUTMTRS) AS ISSUEMTRS, SUM(MATERIALRECEIPT_DESC.MATREC_RECDMTRS - MATERIALRECEIPT_DESC.MATREC_OUTMTRS) AS BALMTRS, ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, '') AS LOTNO, ISNULL(ITEMMASTER.ITEM_TRANSRATE, 0) AS TRANSRATE, ISNULL(ITEMMASTER.ITEM_CHECKRATE, 0) AS CHECKRATE, ISNULL(ITEM_PACKRATE, 0) AS PACKRATE, ISNULL(ITEMMASTER.ITEM_DESIGNRATE, 0) AS DESIGNRATE FROM DESIGNMASTER RIGHT OUTER JOIN LOTCOMPLETED_DESC INNER JOIN LOTCOMPLETED ON LOTCOMPLETED_DESC.LOT_NO = LOTCOMPLETED.LOT_NO AND LOTCOMPLETED_DESC.LOT_YEARID = LOTCOMPLETED.LOT_YEARID INNER JOIN MATERIALRECEIPT INNER JOIN MATERIALRECEIPT_DESC ON MATERIALRECEIPT.MATREC_NO = MATERIALRECEIPT_DESC.MATREC_NO AND MATERIALRECEIPT.MATREC_yearid = MATERIALRECEIPT_DESC.MATREC_YEARID ON LOTCOMPLETED.LOT_DYEINGID = MATERIALRECEIPT.MATREC_ledgerid AND LOTCOMPLETED.LOT_YEARID = MATERIALRECEIPT.MATREC_yearid AND LOTCOMPLETED_DESC.LOT_LOTNO = MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO INNER JOIN ITEMMASTER ON MATERIALRECEIPT_DESC.MATREC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON MATERIALRECEIPT_DESC.MATREC_COLORID = COLORMASTER.COLOR_id ON DESIGNMASTER.DESIGN_id = MATERIALRECEIPT_DESC.MATREC_DESIGNID  WHERE LOTCOMPLETED.LOT_NO = " & SHRINKAGENO & " AND LOTCOMPLETED.LOT_YEARID = " & YEARID & " GROUP BY ISNULL(ITEMMASTER.item_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(MATERIALRECEIPT_DESC.MATREC_GRIDLOTNO, ''), ISNULL(ITEMMASTER.ITEM_TRANSRATE, 0), ISNULL(ITEMMASTER.ITEM_CHECKRATE, 0), ISNULL(ITEM_PACKRATE, 0), ISNULL(ITEMMASTER.ITEM_DESIGNRATE, 0) UNION ALL SELECT ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, SUM(JOBOUT_DESC.JO_MTRS) AS MTRS, SUM(JOBOUT_DESC.JO_OUTMTRS) AS ISSUEMTRS, SUM(JOBOUT_DESC.JO_MTRS - JOBOUT_DESC.JO_OUTMTRS) AS BALMTRS, ISNULL(JOBOUT.JO_LOTNO, '') AS LOTNO, ISNULL(ITEMMASTER.ITEM_TRANSRATE, 0) AS TRANSRATE, ISNULL(ITEMMASTER.ITEM_CHECKRATE, 0) AS CHECKRATE, ISNULL(ITEM_PACKRATE, 0) AS PACKRATE, ISNULL(ITEMMASTER.ITEM_DESIGNRATE, 0) AS DESIGNRATE  FROM  DESIGNMASTER RIGHT OUTER JOIN LOTCOMPLETED_DESC INNER JOIN LOTCOMPLETED ON LOTCOMPLETED_DESC.LOT_NO = LOTCOMPLETED.LOT_NO AND LOTCOMPLETED_DESC.LOT_YEARID = LOTCOMPLETED.LOT_YEARID INNER JOIN JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID ON LOTCOMPLETED.LOT_DYEINGID = JOBOUT.JO_ledgerid AND LOTCOMPLETED.LOT_YEARID = JOBOUT.JO_yearid AND LOTCOMPLETED_DESC.LOT_LOTNO = JOBOUT.JO_LOTNO INNER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id ON DESIGNMASTER.DESIGN_id = JOBOUT_DESC.JO_DESIGNID  WHERE LOTCOMPLETED.LOT_NO = " & SHRINKAGENO & " AND LOTCOMPLETED.LOT_YEARID = " & YEARID & " GROUP BY ISNULL(ITEMMASTER.item_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(JOBOUT.JO_LOTNO, ''), ISNULL(ITEMMASTER.ITEM_TRANSRATE, 0), ISNULL(ITEMMASTER.ITEM_CHECKRATE, 0), ISNULL(ITEM_PACKRATE, 0), ISNULL(ITEMMASTER.ITEM_DESIGNRATE, 0)) AS T ", " ORDER BY LOTNO")
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(ROW("DESIGNNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(ROW("SHADE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(ROW("MTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("ISSUEMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("BALMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(ROW("LOTNO"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(AVGGREYRATE, Range("8"), XlHAlign.xlHAlignRight, , False, 10)

                'GET DYEING PUR RATE WITH RESPECT TO LOTNO, ITEM, DESIGN, SHADE AND DYEINGNAME
                Dim DTDYEINGRATE As System.Data.DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER_DESC.BILL_rate, 0) AS RATE ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_DESC.BILL_yearid INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON PURCHASEMASTER_DESC.BILL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON PURCHASEMASTER_DESC.BILL_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND LEDGERS.ACC_CMPNAME = '" & DYEINGNAME & "' AND PURCHASEMASTER_DESC.BILL_LOTNO = '" & objSheet.Range("G" & RowIndex.ToString).Text & "' AND ITEMMASTER.ITEM_NAME = '" & objSheet.Range("A" & RowIndex.ToString).Text & "' AND DESIGNMASTER.DESIGN_NO = '" & objSheet.Range("B" & RowIndex.ToString).Text & "' AND COLORMASTER.COLOR_NAME = '" & objSheet.Range("C" & RowIndex.ToString).Text & "' AND PURCHASEMASTER.BILL_YEARID = " & YEARID)
                If DTDYEINGRATE.Rows.Count > 0 Then Write(Val(DTDYEINGRATE.Rows(0).Item("RATE")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)

                Write(Val(ROW("TRANSRATE")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("CHECKRATE")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("PACKRATE")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(ROW("DESIGNRATE")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)

                Write(Format((Val(AVGGREYRATE) * AVGSHRINKAGEPER) / 100, "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                FORMULA("=SUM(" & objColumn.Item("8").ToString & RowIndex & ":" & objColumn.Item("14").ToString & RowIndex & ")", Range("15"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            ''FIRST GET OPENING WITH RESPECT TO FROM DATE
            ''FOR NOW OPENING WILL BE BLANK
            'RowIndex += 1
            'Write("OPENING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

            'Dim WHERECLAUSE As String = ""
            'If REGNAME <> "" Then WHERECLAUSE = " And REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            ''PURCHASE(REGISTERED)
            'RowIndex += 1
            'Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'FALSE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If


            ''NONPURCHASE (REGISTERED)
            'RowIndex += 1
            'Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search("  ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'FALSE'")
            'If DTNP.Rows.Count > 0 Then
            '    Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''CREDITNOTE
            'RowIndex += 1
            'Write("CREDIT NOTE", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(SALERETURN.SALRET_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0)) AS IGST FROM SALERETURN WHERE SALRET_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND SALRET_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND SALRET_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(CN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(CN_CGSTAMT),0) AS CGST, ISNULL(SUM(CN_SGSTAMT),0) AS SGST, ISNULL(SUM(CN_IGSTAMT),0) AS IGST FROM CREDITNOTEMASTER WHERE CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_YEARID = " & YEARID & " AND ISNULL(CN_RCM,0) = 'FALSE') AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If


            ''SALE(REGISTERED)
            'RowIndex += 1
            'Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("ISNULL(SUM(T.TAXABLEAMT ),0) AS TAXABLEAMT, ISNULL(SUM(T.CGST),0) AS CGST, ISNULL(SUM(T.SGST),0) AS SGST, ISNULL(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') <> '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''SALE URD (LOCAL)
            'RowIndex += 1
            'Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'FALSE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''SALE URD (EXPORT)
            'RowIndex += 1
            'Write("SALE (URD-EXPORT)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''DEBITNOTE
            'RowIndex += 1
            'Write("DEBIT NOTE", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0)) AS IGST FROM PURCHASERETURN WHERE PR_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PR_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PR_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(DN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(DN_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(DN_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(DN_TOTALIGSTAMT),0) AS IGST FROM DEBITNOTEMASTER WHERE DN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND DN_YEARID = " & YEARID & ") AS T", "")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'End If



            ''CLOSING
            'RowIndex += 1
            'Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & 11 & ") - SUM(" & objColumn.Item("3").ToString & 12 & ":" & objColumn.Item("3").ToString & 15 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & 11 & ") - SUM(" & objColumn.Item("4").ToString & 12 & ":" & objColumn.Item("4").ToString & 15 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & 11 & ") - SUM(" & objColumn.Item("5").ToString & 12 & ":" & objColumn.Item("5").ToString & 15 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & 11 & ") - SUM(" & objColumn.Item("6").ToString & 12 & ":" & objColumn.Item("6").ToString & 15 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & 11 & ") - SUM(" & objColumn.Item("7").ToString & 12 & ":" & objColumn.Item("7").ToString & 15 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 165, 0)


            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)





            ''PURCHASE (URD)
            'RowIndex += 3
            'Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'TRUE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            'If DT.Rows.Count > 0 Then
            '    Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            'End If


            ''NONPURCHASE (URD)
            'RowIndex += 1
            'Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'TRUE'")
            'If DTNP.Rows.Count > 0 Then
            '    Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            '    Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            'End If

            ''RCM CLOSING
            'RowIndex += 1
            'Write("RCM CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'FORMULA("=SUM(" & objColumn.Item("3").ToString & RowIndex - 2 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex - 2 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("5").ToString & RowIndex - 2 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("6").ToString & RowIndex - 2 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - 2 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(0, 255, 0)

            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)



            ''PAYMENT
            'RowIndex += 1
            'Write("GST PAYMENT", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DTNP = OBJCMN.search(" ISNULL(SUM(PAYMENT_TOTAL),0) AS PAIDAMOUNT ", "", " PAYMENTMASTER INNER JOIN LEDGERS ON PAYMENT_ledgerid = Acc_id ", " AND LEDGERS.ACC_CMPNAME IN ('CGST', 'SGST','IGST', 'REVERSE CHARGE') AND PAYMENT_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_YEARID = " & YEARID)
            'Write(Val(DTNP.Rows(0).Item("PAIDAMOUNT")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            'objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 255, 0)



            SetBorder(RowIndex, objColumn.Item("1").ToString & NEWGRIDINDEX, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & NEWGRIDINDEX, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & NEWGRIDINDEX, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & NEWGRIDINDEX, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & NEWGRIDINDEX, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & NEWGRIDINDEX, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & NEWGRIDINDEX, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & NEWGRIDINDEX, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & NEWGRIDINDEX, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & NEWGRIDINDEX, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & NEWGRIDINDEX, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & NEWGRIDINDEX, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & NEWGRIDINDEX, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & NEWGRIDINDEX, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & NEWGRIDINDEX, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & NEWGRIDINDEX, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & NEWGRIDINDEX, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & NEWGRIDINDEX, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & NEWGRIDINDEX, objColumn.Item("19").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("20").ToString & NEWGRIDINDEX, objColumn.Item("20").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("21").ToString & NEWGRIDINDEX, objColumn.Item("21").ToString & RowIndex)




            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GST REPORTS"

    Public Function GSTSUMMARY_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            RowIndex += 1
            Write("GST SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            RowIndex += 2
            Write("", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("TAXABLE AMT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            'FIRST GET OPENING WITH RESPECT TO FROM DATE
            'FOR NOW OPENING WILL BE BLANK
            RowIndex += 1
            Write("OPENING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'PURCHASE(REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'FALSE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            End If


            'NONPURCHASE (REGISTERED)
            RowIndex += 1
            Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DTNP = OBJCMN.search("  ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID INNER JOIN LEDGERS ON NP_LEDGERID = LEDGERS.ACC_ID", WHERECLAUSE & " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'FALSE'")
            If DTNP.Rows.Count > 0 Then
                Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            End If


            'CREDITNOTE(OF PURCHASE)
            RowIndex += 1
            Write("CREDIT NOTE (PUR)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT ISNULL(SUM(CN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(CN_CGSTAMT),0) AS CGST, ISNULL(SUM(CN_SGSTAMT),0) AS SGST, ISNULL(SUM(CN_IGSTAMT),0) AS IGST FROM CREDITNOTEMASTER WHERE CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_YEARID = " & YEARID & "  AND ISNULL(CN_NOGSTR1,0) = 'TRUE' AND ISNULL(CN_RCM,0) = 'FALSE') AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            End If




            'CREDITNOTE (OF SALES)
            RowIndex += 1
            Write("CREDIT NOTE (SALE)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(SALERETURN.SALRET_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0)) AS IGST FROM SALERETURN WHERE SALRET_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND SALRET_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND SALRET_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(CN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(CN_CGSTAMT),0) AS CGST, ISNULL(SUM(CN_SGSTAMT),0) AS SGST, ISNULL(SUM(CN_IGSTAMT),0) AS IGST FROM CREDITNOTEMASTER WHERE CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_YEARID = " & YEARID & " AND ISNULL(CN_NOGSTR1,0) = 'FALSE' AND ISNULL(CN_RCM,0) = 'FALSE') AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(144, 144, 144)
            End If


            'SALE(REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search("ISNULL(SUM(T.TAXABLEAMT ),0) AS TAXABLEAMT, ISNULL(SUM(T.CGST),0) AS CGST, ISNULL(SUM(T.SGST),0) AS SGST, ISNULL(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') <> '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If



            'SALE URD (LOCAL)
            RowIndex += 1
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'FALSE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If



            'SALE URD (EXPORT)
            RowIndex += 1
            Write("SALE (URD-EXPORT)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If




            'DEBITNOTE (OF SALE)
            RowIndex += 1
            Write("DEBIT NOTE (SALE)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT ISNULL(SUM(DN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(DN_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(DN_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(DN_TOTALIGSTAMT),0) AS IGST FROM DEBITNOTEMASTER WHERE DN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND ISNULL(DN_GSTR1,0) = 'TRUE' AND DN_YEARID = " & YEARID & ") AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If


            'DEBITNOTE (OF PURCHASE)
            RowIndex += 1
            Write("DEBIT NOTE (PUR)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST ", "", "(SELECT SUM(ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0)) AS TAXABLEAMT, SUM(ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0)) AS CGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0)) AS IGST FROM PURCHASERETURN WHERE PR_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PR_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PR_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(DN_SUBTOTAL),0) AS TAXABLEAMT, ISNULL(SUM(DN_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(DN_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(DN_TOTALIGSTAMT),0) AS IGST FROM DEBITNOTEMASTER WHERE DN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND ISNULL(DN_GSTR1,0) = 'FALSE' AND DN_YEARID = " & YEARID & ") AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If




            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & 12 & ") - SUM(" & objColumn.Item("3").ToString & 13 & ":" & objColumn.Item("3").ToString & 17 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & 12 & ") - SUM(" & objColumn.Item("4").ToString & 13 & ":" & objColumn.Item("4").ToString & 17 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & 12 & ") - SUM(" & objColumn.Item("5").ToString & 13 & ":" & objColumn.Item("5").ToString & 17 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & 12 & ") - SUM(" & objColumn.Item("6").ToString & 13 & ":" & objColumn.Item("6").ToString & 17 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & 12 & ") - SUM(" & objColumn.Item("7").ToString & 13 & ":" & objColumn.Item("7").ToString & 17 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 165, 0)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)





            'PURCHASE (URD)
            RowIndex += 3
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'TRUE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            End If


            'NONPURCHASE (URD)
            RowIndex += 1
            Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'TRUE'")
            If DTNP.Rows.Count > 0 Then
                Write(Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTNP.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            End If

            'RCM CLOSING
            RowIndex += 1
            Write("RCM CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & RowIndex - 2 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex - 2 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & RowIndex - 2 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & RowIndex - 2 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - 2 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(0, 255, 0)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)



            'PAYMENT
            RowIndex += 1
            Write("GST PAYMENT", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DTNP = OBJCMN.search(" ISNULL(SUM(PAYMENT_TOTAL),0) AS PAIDAMOUNT ", "", " PAYMENTMASTER INNER JOIN LEDGERS ON PAYMENT_ledgerid = Acc_id ", " AND LEDGERS.ACC_CMPNAME IN ('CGST', 'SGST','IGST', 'REVERSE CHARGE') AND PAYMENT_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND PAYMENT_YEARID = " & YEARID)
            Write(Val(DTNP.Rows(0).Item("PAIDAMOUNT")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(255, 255, 0)



            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)




            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTSALEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal CLIENTNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            RowIndex += 1
            Write("GST SALE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("14").ToString & RowIndex + 1)

            RowIndex += 2
            Write("INV NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("INV DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            If CLIENTNAME = "BARKHA" Or CLIENTNAME = "SHUBHI" Then
                DT = OBJCMN.search(" INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            Else
                DT = OBJCMN.search(" INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            End If
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 2
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = ''  ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURCHASEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            RowIndex += 1
            Write("GST PURCHASE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("13"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("13").ToString & RowIndex + 1)

            RowIndex += 2
            Write("BILL NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("BILL DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("REGISTER", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'PURCHASE (REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, (CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST')='LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, (ISNULL(PURCHASEMASTER.BILL_CHARGES, 0)+ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0)) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, REGISTERMASTER.REGISTER_NAME AS REGNAME  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("REGNAME"), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (REGISTERED)
            RowIndex += 2
            Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NP_TOTALTAXABLEAMT,0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL, REGISTERMASTER.REGISTER_NAME AS REGNAME  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND ISNULL(NONPURCHASE.NP_RCM,0) = 'FALSE' ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("REGNAME"), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'NONPURCHASE (RCM)
            RowIndex += 2
            Write("NONPURCHASE (RCM)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NP_TOTALTAXABLEAMT,0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL, REGISTERMASTER.REGISTER_NAME AS REGNAME  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND ISNULL(NONPURCHASE.NP_RCM,0) = 'TRUE' ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("REGNAME"), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next




            'PURCHASE (URD)
            RowIndex += 2
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, (CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, REGISTERMASTER.REGISTER_NAME AS REGNAME  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(LEDGERS.ACC_GSTIN,'') = '' ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("REGNAME"), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (URD)
            RowIndex += 2
            Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NONPURCHASE.NP_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL, REGISTERMASTER.REGISTER_NAME AS REGNAME  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(LEDGERS.ACC_GSTIN,'') = '' ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("REGNAME"), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCNDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 14)
            Next

            SetColumnWidth(Range("4"), 25)
            SetColumnWidth(Range("5"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            RowIndex += 1
            Write("GST Credit Note DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("14").ToString & RowIndex + 1)

            RowIndex += 2
            Write("BILL NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("BILL DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("INVOICE NO", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            'Dim WHERECLAUSE As String = ""
            'If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'PURCHASE (REGISTERED)
            RowIndex += 1
            Write("Credit Note/Sale Return Details", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            ''  DT = OBJCMN.search(" * ", "", "(SELECT 'SR-'+ISNULL(CAST(SALERETURN.SALRET_NO AS VARCHAR(50)),'') AS INVNO, SALERETURN.SALRET_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(SALERETURN.SALRET_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0) AS CGST, ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0) AS SGST, ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0) AS IGST, ISNULL(SALERETURN.SALRET_CHARGES, 0) + ISNULL(SALERETURN.SALRET_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(SALERETURN.SALRET_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(SALERETURN.SALRET_cmpid, 0) AS CMPID, ISNULL(SALERETURN.SALRET_yearid, 0) AS YEARID FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS INVNO, CREDITNOTEMASTER.CN_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY,  ISNULL(CREDITNOTEMASTER.CN_SUBTOTAL,0) AS TAXABLEAMT, ISNULL(CREDITNOTEMASTER.CN_CGSTAMT, 0) AS CGST, ISNULL(CREDITNOTEMASTER.CN_SGSTAMT, 0) AS SGST, ISNULL(CREDITNOTEMASTER.CN_IGSTAMT, 0) AS IGST, (ISNULL(CREDITNOTEMASTER.CN_CHARGES, 0)+ISNULL(CREDITNOTEMASTER.CN_ROUNDOFF, 0)) AS ROUNDOFF, ISNULL(CREDITNOTEMASTER.CN_GTOTAL, 0) AS GRANDTOTAL ,ISNULL(CREDITNOTEMASTER.CN_cmpid, 0) AS CMPID, ISNULL(CREDITNOTEMASTER.CN_yearid, 0) AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = CN_REGISTERID) AS T ", " AND T.DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & "  ORDER BY T.DATE, T.INVNO ")
            DT = OBJCMN.search(" * ", "", "(SELECT  'SR-' + ISNULL(CAST(SALERETURN.SALRET_NO AS VARCHAR(50)), '') AS INVNO, SALERETURN.SALRET_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(SALERETURN.SALRET_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(SALERETURN.SALRET_TOTALCGSTAMT, 0) AS CGST, ISNULL(SALERETURN.SALRET_TOTALSGSTAMT, 0) AS SGST, ISNULL(SALERETURN.SALRET_TOTALIGSTAMT, 0) AS IGST,ISNULL(SALERETURN.SALRET_CHARGES, 0) + ISNULL(SALERETURN.SALRET_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(SALERETURN.SALRET_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(SALERETURN.SALRET_cmpid, 0) AS CMPID, ISNULL(SALERETURN.SALRET_yearid, 0) AS YEARID, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid  LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID AND SALERETURN.SALRET_INVOICEINITIALS = OPENINGBILL.BILL_INITIALS LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID  UNION ALL SELECT     CREDITNOTEMASTER.CN_initials AS INVNO, CREDITNOTEMASTER.CN_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(CREDITNOTEMASTER.CN_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(CREDITNOTEMASTER.CN_CGSTAMT, 0) AS CGST, ISNULL(CREDITNOTEMASTER.CN_SGSTAMT, 0) AS SGST, ISNULL(CREDITNOTEMASTER.CN_IGSTAMT, 0) AS IGST, ISNULL(CREDITNOTEMASTER.CN_CHARGES, 0) + ISNULL(CREDITNOTEMASTER.CN_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(CREDITNOTEMASTER.CN_GTOTAL, 0) AS GRANDTOTAL, ISNULL(CREDITNOTEMASTER.CN_cmpid, 0) AS CMPID, ISNULL(CREDITNOTEMASTER.CN_yearid, 0) AS YEARID, ISNULL(CREDITNOTEMASTER.CN_BILLNO, '') as INVINITIALS FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = CREDITNOTEMASTER.CN_registerid WHERE CREDITNOTEMASTER.CN_YEARID = " & YEARID & ") AS T", " AND T.DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & "  ORDER BY T.DATE, T.INVNO ")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVINITIALS"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next







            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("5"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTDNDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 14)
            Next

            SetColumnWidth(Range("4"), 25)
            SetColumnWidth(Range("5"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            RowIndex += 1
            Write("GST Debit Note DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("14").ToString & RowIndex + 1)

            RowIndex += 2
            Write("BILL NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("BILL DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("INVOICE NO", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            'Dim WHERECLAUSE As String = ""
            'If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'PURCHASE (REGISTERED)
            RowIndex += 1
            Write("Debit Note/Purchase Return Details", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            '' DT = OBJCMN.search(" * ", "", " (SELECT PURCHASERETURN.PR_INITIALS AS INVNO, PURCHASERETURN.PR_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASERETURN.PR_CHARGES, 0) + ISNULL(PURCHASERETURN.PR_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASERETURN.PR_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASERETURN.PR_cmpid, 0) AS CMPID, ISNULL(PURCHASERETURN.PR_yearid, 0) AS YEARID FROM PURCHASERETURN INNER JOIN LEDGERS ON PURCHASERETURN.PR_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid UNION ALL SELECT     DEBITNOTEMASTER.DN_initials AS INVNO, DEBITNOTEMASTER.DN_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(DEBITNOTEMASTER.DN_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(DEBITNOTEMASTER.DN_TOTALCGSTAMT, 0) AS CGST, ISNULL(DEBITNOTEMASTER.DN_TOTALSGSTAMT, 0) AS SGST, ISNULL(DEBITNOTEMASTER.DN_TOTALIGSTAMT, 0) AS IGST, ISNULL(DEBITNOTEMASTER.DN_CHARGES, 0) + ISNULL(DEBITNOTEMASTER.DN_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(DEBITNOTEMASTER.DN_GTOTAL, 0) AS GRANDTOTAL, ISNULL(DEBITNOTEMASTER.DN_cmpid, 0) AS CMPID, ISNULL(DEBITNOTEMASTER.DN_yearid, 0) AS YEARID FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = DEBITNOTEMASTER.DN_registerid)AS T ", " AND T.DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & "  ORDER BY T.DATE, T.INVNO ")
            DT = OBJCMN.search(" * ", "", " (SELECT PURCHASERETURN.PR_INITIALS AS INVNO, PURCHASERETURN.PR_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASERETURN.PR_CHARGES, 0) + ISNULL(PURCHASERETURN.PR_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASERETURN.PR_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASERETURN.PR_cmpid, 0) AS CMPID, ISNULL(PURCHASERETURN.PR_yearid, 0) AS YEARID, ISNULL(PURCHASERETURN.PR_PARTYBILL, '') AS AGAINSTBILL FROM PURCHASERETURN INNER JOIN LEDGERS ON PURCHASERETURN.PR_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid  UNION ALL SELECT     DEBITNOTEMASTER.DN_initials AS INVNO, DEBITNOTEMASTER.DN_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(DEBITNOTEMASTER.DN_SUBTOTAL, 0) AS TAXABLEAMT, ISNULL(DEBITNOTEMASTER.DN_TOTALCGSTAMT, 0) AS CGST, ISNULL(DEBITNOTEMASTER.DN_TOTALSGSTAMT, 0) AS SGST, ISNULL(DEBITNOTEMASTER.DN_TOTALIGSTAMT, 0) AS IGST, ISNULL(DEBITNOTEMASTER.DN_CHARGES, 0) + ISNULL(DEBITNOTEMASTER.DN_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(DEBITNOTEMASTER.DN_GTOTAL, 0) AS GRANDTOTAL, ISNULL(DEBITNOTEMASTER.DN_cmpid, 0) AS CMPID, ISNULL(DEBITNOTEMASTER.DN_yearid, 0) AS YEARID,ISNULL(DEBITNOTEMASTER.DN_BILLNO, '') AS AGAINSTBILL FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATEMASTER.state_id = LEDGERS.Acc_stateid LEFT OUTER JOIN CITYMASTER ON CITYMASTER.city_id = LEDGERS.Acc_cityid INNER JOIN REGISTERMASTER ON REGISTERMASTER.register_id = DEBITNOTEMASTER.DN_registerid WHERE DEBITNOTEMASTER.DN_YEARID = " & YEARID & ") AS T ", " AND T.DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & "  ORDER BY T.DATE, T.INVNO ")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("AGAINSTBILL"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("5"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTSALESUMM_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal PARTYNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 15)
            SetColumnWidth(Range("3"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("GST SALE SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("10").ToString & RowIndex + 1)

            RowIndex += 2
            'Write("INV NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            'Write("INV DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            'Write("CITY", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"
            If PARTYNAME <> "" Then WHERECLAUSE = " AND LEDGERS.Acc_cmpname = '" & PARTYNAME & "'"


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE SUMMARY", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN,ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0)) AS QTY, SUM(CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) ) AS CGST,SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0)) AS IGST,SUM( ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)) AS GRANDTOTAL ", "", "INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & "  GROUP BY ISNULL(LEDGERS.Acc_cmpname, ''),ISNULL(LEDGERS.ACC_GSTIN, ''),ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') ,ISNULL(STATEMASTER.STATE_NAME, '') ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
           
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                'Write(DTROW("CITY"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                'Write(Val(DTROW("ROUNDOFF")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            Next



         



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            'FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURSUMM_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal PARTYNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 15)
            SetColumnWidth(Range("3"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("GST PURCHASE SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("10").ToString & RowIndex + 1)

            RowIndex += 2
            Write("NAME", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"
            If PARTYNAME <> "" Then WHERECLAUSE = " AND LEDGERS.Acc_cmpname = '" & PARTYNAME & "'"


            'PURCHASE  SUMMARY
            RowIndex += 1
            Write("PURCHASE SUMMARY", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN,ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,SUM(ISNULL(PURCHASEMASTER.BILL_TOTALMTRS, 0)) AS QTY, SUM(CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, SUM(ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) ) AS CGST,SUM(ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0)) AS IGST,SUM( ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0)) AS GRANDTOTAL ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & "  GROUP BY ISNULL(LEDGERS.Acc_cmpname, ''),ISNULL(LEDGERS.ACC_GSTIN, ''),ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') ,ISNULL(STATEMASTER.STATE_NAME, '') ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            Next







            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURSTATESUMM_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal STATENAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range("1"), 25)
            'SetColumnWidth(Range("2"), 15)
            'SetColumnWidth(Range("3"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("GST PURCHASE STATE SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("8").ToString & RowIndex + 1)

            RowIndex += 2
            Write("STATE", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            If STATENAME <> "" Then WHERECLAUSE = " AND STATEMASTER.STATE_NAME = '" & STATENAME & "'"


            'PURCHASE  SUMMARY
            RowIndex += 1
            Write("PURCHASE STATE SUMMARY", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,SUM(ISNULL(PURCHASEMASTER.BILL_TOTALMTRS, 0)) AS QTY, SUM(CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, SUM(ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) ) AS CGST,SUM(ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0)) AS IGST,SUM( ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0)) AS GRANDTOTAL ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & "  GROUP BY ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') ,ISNULL(STATEMASTER.STATE_NAME, '') ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 9 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTSALESTATESUMM_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal STATENAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range("1"), 25)
            'SetColumnWidth(Range("2"), 15)
            'SetColumnWidth(Range("3"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("GST SALE STATE SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("8").ToString & RowIndex + 1)

            RowIndex += 2
            Write("STATE", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            If STATENAME <> "" Then WHERECLAUSE = " AND STATEMASTER.STATE_NAME = '" & STATENAME & "'"


            'SALE  SUMMARY
            RowIndex += 1
            Write("SALE STATE SUMMARY", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search("ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0)) AS QTY, SUM(CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) ) AS CGST,SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0)) AS SGST, SUM(ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0)) AS IGST,SUM( ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & "  GROUP BY ISNULL(CAST(STATEMASTER.STATE_REMARK AS VARCHAR(10)), '') ,ISNULL(STATEMASTER.STATE_NAME, '') ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 9 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
          

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
         

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2B_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("5"), 17)
            SetColumnWidth(Range("6"), 17)
            SetColumnWidth(Range("10"), 17)
            SetColumnWidth(Range("11"), 10)
            SetColumnWidth(Range("12"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable




            Write("Summary For B2B (4)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("No Of Invoices", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Invoice Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("13")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            'WE HAVE WRITTEN THIS FORMULA AT THE END, IF WE WRITE HERE THEN THE SPEED REDUCES DRASTICALLY
            'FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            'FORMULA("=SUMPRODUCT((" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "," & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "&""""))", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 5 & ":" & objColumn.Item("12").ToString & 40000 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 5 & ":" & objColumn.Item("13").ToString & 40000 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 3, objColumn.Item("12").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)



            RowIndex += 1
            Write("GSTIN/UIN Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Receiver Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice No", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reverse Charge", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Type", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            'THIS IS DONE ADDITIONALLY
            Write("CGST Amount", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST Amount", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST Amount", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'SALE(REGISTERED)
            'DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            DT = OBJCMN.Execute_Any_String(" select INVOICEMASTER.INVOICE_PRINTINITIALS AS PRINTINITIALS, INVOICEMASTER.INVOICE_INITIALS AS INVNO, ISNULL(LEDGERS.ACC_CMPNAME, '') AS NAME, CAST(INVOICEMASTER.INVOICE_DATE AS VARCHAR(10)) AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT from INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID where   INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  " & WHERECLAUSE & "   AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO", "", "")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                'CHANGED BY GULKIT
                'Write("=(""" & DTROW("INVNO") & """)", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PRINTINITIALS"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd-MMM-yy"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("N", Range("7"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("Regular", Range("9"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("10"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE_DESC
                Dim OBJGST As System.Data.DataTable = OBJCMN.search(" TOP 1 (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' THEN ISNULL(HSN_EXPIGST,0) ELSE HSN_IGST END) AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER_DESC ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER_DESC.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID INNER JOIN INVOICEMASTER ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND HSNMASTER_DESC.HSN_WEFDATE <= INVOICEMASTER.INVOICE_DATE AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC ")
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("13"), XlHAlign.xlHAlignRight, , False, 10)


                Write(Val(DTROW("TOTALCGSTAMT")), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TOTALSGSTAMT")), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TOTALIGSTAMT")), Range("16"), XlHAlign.xlHAlignRight, , False, 10)
            Next



            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ": " & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", objColumn.Item("1").ToString & 3, XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT((" & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "&""""))", objColumn.Item("3").ToString & 3, XlHAlign.xlHAlignCenter, , True, 10)



            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 5, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 5, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 5, objColumn.Item("13").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("7"), 17)
            SetColumnWidth(Range("9"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CL (5)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Invoices", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT(1/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&"""")," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & ")", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)



            RowIndex += 1
            Write("Invoice No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'SALE(URD)
            DT = OBJCMN.Execute_Any_String(" SELECT INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE  INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' " & WHERECLAUSE & " AND  INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) > 250000 ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO", "", "")

            ''DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) > 250000 ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("=(""" & DTROW("INVNO") & """)", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd-MMM-yy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search(" TOP 1 (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' THEN ISNULL(HSN_EXPIGST,0) ELSE HSN_IGST END) AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER_DESC ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER_DESC.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID INNER JOIN INVOICEMASTER ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID ", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND HSNMASTER_DESC.HSN_WEFDATE <= INVOICEMASTER.INVOICE_DATE AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("5"), 17)
            SetColumnWidth(Range("7"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CS (7)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Taxable Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("7")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)



            RowIndex += 1
            Write("Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE(URD)<250000
            'DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")

            DT = OBJCMN.Execute_Any_String(" SELECT INVOICEMASTER.INVOICE_PRINTINITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) AS GRANDTOTAL FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' " & WHERECLAUSE & " AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_TOTALWITHGST, 0) <= 250000 ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO", "", "")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("OE", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search(" TOP 1 (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_EXPORTGST,0) = 'TRUE' THEN ISNULL(HSN_EXPIGST,0) ELSE HSN_IGST END) AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER_DESC ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER_DESC.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID INNER JOIN INVOICEMASTER ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_PRINTINITIALS = '" & DTROW("INVNO") & "' AND HSNMASTER_DESC.HSN_WEFDATE <= INVOICEMASTER.INVOICE_DATE AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC ")
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 25)
            Next

            SetColumnWidth(Range("8"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim TEMPDT As New System.Data.DataTable

            Write("GSTIN/UIN of Recipient", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Receiver Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt Number", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt date", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher Number", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Document Type", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Voucher Value", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pre GST", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'CREDITNOTE / DEBITNOTE / SALERETURN
            'DT = OBJCMN.search("*", "", " (SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE CREDITNOTEMASTER.CN_BILLNO END) AS INVINITIALS, (CASE WHEN CN_BILLNO = '' THEN CN_date ELSE COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE) END) AS INVDATE, CREDITNOTEMASTER.CN_initials AS CNINITIALS, CREDITNOTEMASTER.CN_date AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, CREDITNOTEMASTER.CN_cmpid AS CMPID, CREDITNOTEMASTER.CN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, CREDITNOTEMASTER.CN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER.HSN_IGST,0) AS RATE, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON CREDITNOTEMASTER.CN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN INVOICEMASTER ON CREDITNOTEMASTER.CN_yearid = INVOICEMASTER.INVOICE_YEARID AND CREDITNOTEMASTER.CN_BILLNO = INVOICEMASTER.INVOICE_INITIALS LEFT OUTER JOIN OPENINGBILL ON CREDITNOTEMASTER.CN_yearid = OPENINGBILL.BILL_YEARID AND CREDITNOTEMASTER.CN_BILLNO = OPENINGBILL.BILL_INITIALS UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, DEBITNOTEMASTER.DN_initials AS INVINITIALS, DEBITNOTEMASTER.DN_date AS INVDATE, DEBITNOTEMASTER.DN_initials AS DNINITIALS, DEBITNOTEMASTER.DN_date AS DNDATE, 'D' AS DOCTYPE, '07-Others' AS REASON, DEBITNOTEMASTER.DN_cmpid AS CMPID, DEBITNOTEMASTER.DN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, DEBITNOTEMASTER.DN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER.HSN_IGST, 0) AS RATE, DEBITNOTEMASTER.DN_SUBTOTAL AS TAXABLEAMT FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON DEBITNOTEMASTER.DN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE (DEBITNOTEMASTER.DN_BILLNO = '') UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS, (CASE WHEN ISNULL(SALRET_INVOICENO, '') = '' THEN SALRET_date ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE), SALRET_DATE) END) AS INVDATE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10)) AS CNINITIALS, SALERETURN.SALRET_DATE AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, SALERETURN.SALRET_cmpid AS CMPID, SALERETURN.SALRET_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, SALERETURN.SALRET_GRANDTOTAL AS GRANDTOTAL, CASE WHEN ISNULL(SALRET_IGSTPER, 0) = 0 THEN ISNULL(SALRET_CGSTPER, 0) + ISNULL(SALRET_SGSTPER, 0) ELSE ISNULL(SALRET_IGSTPER, 0) END AS RATE, SALERETURN.SALRET_SUBTOTAL AS TAXABLEAMT FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID) AS T ", " AND T.CNDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.CNDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & " AND T.GSTIN <> '' ORDER BY T.CNDATE")
            DT = OBJCMN.Execute_Any_String("SELECT * FROM (SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE CREDITNOTEMASTER.CN_BILLNO END) AS INVINITIALS, ISNULL((CASE WHEN CN_BILLNO = '' THEN CN_date ELSE COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE) END), GETDATE()) AS INVDATE, CREDITNOTEMASTER.CN_initials AS CNINITIALS, CREDITNOTEMASTER.CN_date AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, CREDITNOTEMASTER.CN_cmpid AS CMPID, CREDITNOTEMASTER.CN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, CREDITNOTEMASTER.CN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS RATE, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE COALESCE(INVOICEMASTER.INVOICE_PRINTINITIALS, OPENINGBILL.BILL_PRINTINITIALS) END) AS PRINTINITIALS FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id CROSS APPLY (SELECT TOP 1 * FROM HSNMASTER_DESC WHERE HSN_WEFDATE <= CREDITNOTEMASTER.CN_DATE AND HSN_YEARID = CREDITNOTEMASTER.CN_yearid AND HSN_ID = CN_HSNCODEID ORDER BY HSN_WEFDATE DESC) AS HSNMASTER_DESC LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN INVOICEMASTER ON CREDITNOTEMASTER.CN_yearid = INVOICEMASTER.INVOICE_YEARID AND CREDITNOTEMASTER.CN_BILLNO = INVOICEMASTER.INVOICE_INITIALS LEFT OUTER JOIN OPENINGBILL ON CREDITNOTEMASTER.CN_yearid = OPENINGBILL.BILL_YEARID AND CREDITNOTEMASTER.CN_BILLNO = OPENINGBILL.BILL_INITIALS WHERE ISNULL(CREDITNOTEMASTER.CN_NOGSTR1,'FALSE') = 'FALSE' UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(DEBITNOTEMASTER.DN_SALEREFNO,'') AS INVINITIALS, DN_DATE AS INVDATE, DEBITNOTEMASTER.DN_initials AS DNINITIALS, DEBITNOTEMASTER.DN_date AS DNDATE, 'D' AS DOCTYPE, '07-Others' AS REASON, DEBITNOTEMASTER.DN_cmpid AS CMPID, DEBITNOTEMASTER.DN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, DEBITNOTEMASTER.DN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS RATE, DEBITNOTEMASTER.DN_SUBTOTAL AS TAXABLEAMT, ISNULL(DEBITNOTEMASTER.DN_SALEREFNO,'') AS PRINTINITIALS  FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id CROSS APPLY (SELECT TOP 1 * FROM HSNMASTER_DESC WHERE HSN_WEFDATE <= DEBITNOTEMASTER.DN_DATE AND HSN_YEARID = DEBITNOTEMASTER.DN_yearid AND HSN_ID = DN_HSNCODEID ORDER BY HSN_WEFDATE DESC) AS HSNMASTER_DESC LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE ISNULL(DEBITNOTEMASTER.DN_GSTR1,'TRUE') = 'TRUE' UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS, (CASE WHEN ISNULL(SALRET_INVOICENO, '') = '' THEN SALRET_date ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE), SALRET_DATE) END) AS INVDATE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10)) AS CNINITIALS, SALERETURN.SALRET_DATE AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, SALERETURN.SALRET_cmpid AS CMPID, SALERETURN.SALRET_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, SALERETURN.SALRET_GRANDTOTAL AS GRANDTOTAL, CASE WHEN ISNULL(SALRET_IGSTPER, 0) = 0 THEN ISNULL(SALRET_CGSTPER, 0) + ISNULL(SALRET_SGSTPER, 0) ELSE ISNULL(SALRET_IGSTPER, 0) END AS RATE, SALERETURN.SALRET_SUBTOTAL AS TAXABLEAMT, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_PRINTINITIALS, OPENINGBILL.BILL_PRINTINITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS PRINTINITIALS  FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID AND SALERETURN.SALRET_INVOICEINITIALS = OPENINGBILL.BILL_INITIALS LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID) AS T WHERE  T.CNDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.CNDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & " AND T.GSTIN <> '' ORDER BY T.CNDATE", "", "")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("=(""" & DTROW("PRINTINITIALS") & """)", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("INVDATE")).Date, "dd-MMM-yy"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("CNINITIALS"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("CNDATE")).Date, "dd-MMM-yy"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DOCTYPE"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("13"), XlHAlign.xlHAlignRight, , False, 10)

                'CHECK WHETHER BILLNO IS PREGST OR NOT
                Dim TEMPPREGST As String = "N"
                If DTROW("INVINITIALS") <> "" Then TEMPDT = OBJCMN.search("INVOICE_DATE AS DATE", "", "INVOICEMASTER ", " AND INVOICE_INITIALS = '" & DTROW("INVINITIALS") & "' AND INVOICE_YEARID = " & YEARID) Else TEMPPREGST = "N"
                If TEMPDT.Rows.Count > 0 Then
                    If Convert.ToDateTime(TEMPDT.Rows(0).Item("DATE")).Date < "01/07/2017" Then TEMPPREGST = "Y" Else TEMPPREGST = "N"
                End If
                Write(TEMPPREGST, Range("14"), XlHAlign.xlHAlignLeft, , False, 10)
            Next

            objSheet.Range(objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 2, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 2, objColumn.Item("14").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 2 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 2 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNUR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 25)
            Next

            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("UR Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher Number", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher date", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Document Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt Number", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Voucher Value", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pre GST", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'CREDITNOTE / DEBITNOTE / SALERETURN
            'DT = OBJCMN.search("*", "", " (SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE CREDITNOTEMASTER.CN_BILLNO END) AS INVINITIALS, (CASE WHEN CN_BILLNO = '' THEN CN_date ELSE COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE) END) AS INVDATE, CREDITNOTEMASTER.CN_initials AS CNINITIALS, CREDITNOTEMASTER.CN_date AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, CREDITNOTEMASTER.CN_cmpid AS CMPID, CREDITNOTEMASTER.CN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, CREDITNOTEMASTER.CN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER.HSN_IGST,0) AS RATE, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON CREDITNOTEMASTER.CN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN INVOICEMASTER ON CREDITNOTEMASTER.CN_yearid = INVOICEMASTER.INVOICE_YEARID AND CREDITNOTEMASTER.CN_BILLNO = INVOICEMASTER.INVOICE_INITIALS LEFT OUTER JOIN OPENINGBILL ON CREDITNOTEMASTER.CN_yearid = OPENINGBILL.BILL_YEARID AND CREDITNOTEMASTER.CN_BILLNO = OPENINGBILL.BILL_INITIALS UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, DEBITNOTEMASTER.DN_initials AS INVINITIALS, DEBITNOTEMASTER.DN_date AS INVDATE, DEBITNOTEMASTER.DN_initials AS DNINITIALS, DEBITNOTEMASTER.DN_date AS DNDATE, 'D' AS DOCTYPE, '07-Others' AS REASON, DEBITNOTEMASTER.DN_cmpid AS CMPID, DEBITNOTEMASTER.DN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, DEBITNOTEMASTER.DN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER.HSN_IGST, 0) AS RATE, DEBITNOTEMASTER.DN_SUBTOTAL AS TAXABLEAMT FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON DEBITNOTEMASTER.DN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE (DEBITNOTEMASTER.DN_BILLNO = '') UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS, (CASE WHEN ISNULL(SALRET_INVOICENO, '') = '' THEN SALRET_date ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE), SALRET_DATE) END) AS INVDATE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10)) AS CNINITIALS, SALERETURN.SALRET_DATE AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, SALERETURN.SALRET_cmpid AS CMPID, SALERETURN.SALRET_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, SALERETURN.SALRET_GRANDTOTAL AS GRANDTOTAL, CASE WHEN ISNULL(SALRET_IGSTPER, 0) = 0 THEN ISNULL(SALRET_CGSTPER, 0) + ISNULL(SALRET_SGSTPER, 0) ELSE ISNULL(SALRET_IGSTPER, 0) END AS RATE, SALERETURN.SALRET_SUBTOTAL AS TAXABLEAMT FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID) AS T ", " AND T.CNDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.CNDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & " AND T.GSTIN = '' ORDER BY T.CNDATE")
            DT = OBJCMN.Execute_Any_String("SELECT * FROM (SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE CREDITNOTEMASTER.CN_BILLNO END) AS INVINITIALS, (CASE WHEN CN_BILLNO = '' THEN CN_date ELSE COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE) END) AS INVDATE, CREDITNOTEMASTER.CN_initials AS CNINITIALS, CREDITNOTEMASTER.CN_date AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, CREDITNOTEMASTER.CN_cmpid AS CMPID, CREDITNOTEMASTER.CN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATE, CREDITNOTEMASTER.CN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER_DESC.HSN_IGST,0) AS RATE, CREDITNOTEMASTER.CN_SUBTOTAL AS TAXABLEAMT, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE INVOICEMASTER.INVOICE_PRINTINITIALS END) AS PRINTINITIALS FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id CROSS APPLY (SELECT TOP 1 * FROM HSNMASTER_DESC WHERE HSN_WEFDATE <= CREDITNOTEMASTER.CN_DATE AND HSN_YEARID = CREDITNOTEMASTER.CN_yearid AND HSN_ID = CN_HSNCODEID ORDER BY HSN_WEFDATE DESC) AS HSNMASTER_DESC LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN INVOICEMASTER ON CREDITNOTEMASTER.CN_yearid = INVOICEMASTER.INVOICE_YEARID AND CREDITNOTEMASTER.CN_BILLNO = INVOICEMASTER.INVOICE_INITIALS LEFT OUTER JOIN OPENINGBILL ON CREDITNOTEMASTER.CN_yearid = OPENINGBILL.BILL_YEARID AND CREDITNOTEMASTER.CN_BILLNO = OPENINGBILL.BILL_INITIALS WHERE ISNULL(CREDITNOTEMASTER.CN_NOGSTR1,'FALSE') = 'FALSE' UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(DEBITNOTEMASTER.DN_SALEREFNO,'') AS INVINITIALS, DEBITNOTEMASTER.DN_date AS INVDATE, DEBITNOTEMASTER.DN_initials AS DNINITIALS, DEBITNOTEMASTER.DN_date AS DNDATE, 'D' AS DOCTYPE, '07-Others' AS REASON, DEBITNOTEMASTER.DN_cmpid AS CMPID, DEBITNOTEMASTER.DN_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, DEBITNOTEMASTER.DN_GTOTAL AS GRANDTOTAL, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS RATE, DEBITNOTEMASTER.DN_SUBTOTAL AS TAXABLEAMT, '' AS PRINTINITIALS FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id CROSS APPLY (SELECT TOP 1 * FROM HSNMASTER_DESC WHERE HSN_WEFDATE <= DEBITNOTEMASTER.DN_DATE AND HSN_YEARID = DEBITNOTEMASTER.DN_yearid AND HSN_ID = DN_HSNCODEID ORDER BY HSN_WEFDATE DESC) AS HSNMASTER_DESC LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE (DEBITNOTEMASTER.DN_BILLNO = '')  AND ISNULL(DEBITNOTEMASTER.DN_GSTR1,'TRUE') = 'TRUE'  UNION ALL SELECT ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS, (CASE WHEN ISNULL(SALRET_INVOICENO, '') = '' THEN SALRET_date ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE), SALRET_DATE) END) AS INVDATE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10)) AS CNINITIALS, SALERETURN.SALRET_DATE AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, SALERETURN.SALRET_cmpid AS CMPID, SALERETURN.SALRET_yearid AS YEARID, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, SALERETURN.SALRET_GRANDTOTAL AS GRANDTOTAL, CASE WHEN ISNULL(SALRET_IGSTPER, 0) = 0 THEN ISNULL(SALRET_CGSTPER, 0) + ISNULL(SALRET_SGSTPER, 0) ELSE ISNULL(SALRET_IGSTPER, 0) END AS RATE, SALERETURN.SALRET_SUBTOTAL AS TAXABLEAMT, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_PRINTINITIALS, OPENINGBILL.BILL_INITIALS), 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS PRINTINITIALS FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID) AS T WHERE T.CNDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND T.CNDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YEARID & " AND T.GSTIN = '' ORDER BY T.CNDATE", "", "")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CNINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("CNDATE")).Date, "dd-MMM-yy"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DOCTYPE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("=(""" & DTROW("PRINTINITIALS") & """)", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("INVDATE")).Date, "dd-MMM-yy"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("N", Range("13"), XlHAlign.xlHAlignLeft, , False, 10)
            Next

            objSheet.Range(objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 2, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 2 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 2 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTHSN_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal INVOICESCREENTYPE As String, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("7"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For HSN (12)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Integrated Tax", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Central Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total State/UT Tax", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("11")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & 40000 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 5 & ":" & objColumn.Item("11").ToString & 40000 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 3, objColumn.Item("11").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)



            RowIndex += 1
            Write("HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Description", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UQC", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Integrated Tax Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Central Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("State/UT Tax Amount", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            DT = OBJCMN.Execute_Any_String(" SELECT HSNCODE, HSNDESC, HSNRATE, SUM(QTY) AS QTY, SUM(GRANDTOTAL) AS GRANDTOTAL, SUM(TAXABLEAMT) AS TAXABLEAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT, CMPID, YEARID FROM HSNSUMMARY WHERE DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' " & WHERECLAUSE & " AND YEARID = " & YEARID & " GROUP BY HSNCODE, HSNDESC, HSNRATE, CMPID, YEARID", "", "")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("HSNCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("HSNDESC"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("MTR", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)


                'Dim DTINV As New System.Data.DataTable
                'WE CAN NOT GET GRAND TOTAL IN ABOVE QUERY COZ THIS WIL CALC GRANDTOTAL MULTIPLE TIMES COZ WE HAVE JOIN WITH INVOICEDESC
                'BELOW CODE WASS TAKING TIME 
                'If INVOICESCREENTYPE = "LINE GST" Then
                'Else
                '    DTINV = OBJCMN.search("DISTINCT INVOICEMASTER.INVOICE_NO  ROUND(SUM(ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)),0) AS GRANDTOTAL, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) ELSE SUM(ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0)) END) AS TAXABLEAMT,", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " AND HSN_CODE = '" & DTROW("HSNCODE") & "'")
                'End If

                Write(Val(DTROW("GRANDTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("HSNRATE")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGSTAMT")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"



            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTDOCS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 40)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary of Documents issued during the tax period (13)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Number", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cancelled", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("5")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("5")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)



            RowIndex += 1
            Write("Name Of Document", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Sr. No From", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Sr. No To", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Number", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cancelled", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)


            Dim DTINV As New System.Data.DataTable

            'SALE INVOICE DETAILS
            DT = OBJCMN.search(" DISTINCT INVOICE_REGISTERID AS REGISTERID ", "", " INVOICEMASTER ", " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_TOTALCGSTAMT > 0 OR INVOICE_TOTALIGSTAMT > 0  AND INVOICEMASTER.INVOICE_YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write("Invoice For Outward Supply", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" TOP 1 INVOICE_PRINTINITIALS  AS FROMNO ", "", " INVOICEMASTER ", " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY INVOICEMASTER.INVOICE_NO ")
                If DTINV.Rows.Count > 0 Then Write(DTINV.Rows(0).Item("FROMNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" TOP 1 INVOICE_PRINTINITIALS  AS TONO ", "", " INVOICEMASTER ", " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY INVOICEMASTER.INVOICE_NO DESC ")
                If DTINV.Rows.Count > 0 Then Write(DTINV.Rows(0).Item("TONO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" DISTINCT COUNT(INVOICE_PRINTINITIALS) AS TOTALINV ", "", " INVOICEMASTER ", " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID)
                If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("TOTALINV")), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.Execute_Any_String("CREATE TABLE #TEMP (ID INT) DECLARE @I INT, @MAXNO INT   SELECT @I = MIN(INVOICE_NO) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = register_id WHERE INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & "  SELECT @MAXNO = MAX(INVOICE_NO) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = register_id WHERE INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & "  WHILE @I <= @MAXNO  BEGIN 	INSERT INTO #TEMP VALUES (@I) 	SET @I+=1  END   SELECT COUNT(#TEMP.ID) AS SRNO FROM #TEMP WHERE ID NOT IN (SELECT INVOICE_NO FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = register_id WHERE INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & ")  DROP TABLE #TEMP ", "", "")
                If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("SRNO")), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)

            Next




            'CREDIT NOTE DETAILS
            DT = OBJCMN.search(" DISTINCT CN_REGISTERID AS REGISTERID ", "", " CREDITNOTEMASTER ", " AND CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_CGSTAMT > 0 OR CN_IGSTAMT > 0  AND CREDITNOTEMASTER.CN_YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write("Credit Note", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" TOP 1 CN_INITIALS  AS FROMNO ", "", " CREDITNOTEMASTER ", " AND CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID & " ORDER BY CREDITNOTEMASTER.CN_NO ")
                If DTINV.Rows.Count > 0 Then Write(DTINV.Rows(0).Item("FROMNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" TOP 1 CN_INITIALS  AS TONO ", "", " CREDITNOTEMASTER ", " AND CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID & " ORDER BY CREDITNOTEMASTER.CN_NO DESC ")
                If DTINV.Rows.Count > 0 Then Write(DTINV.Rows(0).Item("TONO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.search(" DISTINCT COUNT(CN_INITIALS) AS TOTALINV ", "", " CREDITNOTEMASTER ", " AND CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID)
                If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("TOTALINV")), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

                DTINV = OBJCMN.Execute_Any_String("CREATE TABLE #TEMP (ID INT) DECLARE @I INT, @MAXNO INT   SELECT @I = MIN(CN_NO) FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = register_id WHERE CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID & "  SELECT @MAXNO = MAX(CN_NO) FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = register_id WHERE CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID & "  WHILE @I <= @MAXNO  BEGIN 	INSERT INTO #TEMP VALUES (@I) 	SET @I+=1  END   SELECT COUNT(#TEMP.ID) AS SRNO FROM #TEMP WHERE ID NOT IN (SELECT CN_NO FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CN_REGISTERID = register_id WHERE CREDITNOTEMASTER.CN_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CREDITNOTEMASTER.CN_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND CN_REGISTERID = " & Val(DTROW("REGISTERID")) & " AND CREDITNOTEMASTER.CN_YEARID = " & YEARID & ")  DROP TABLE #TEMP ", "", "")
                If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("SRNO")), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
            Next




            'JOB WORK SERIES
            RowIndex += 1
            Write("Delivery Challan for Job Work", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

            DTINV = OBJCMN.search(" TOP 1 JO_NO AS FROMNO ", "", " JOBOUT ", " AND JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JO_YEARID = " & YEARID & " ORDER BY JO_NO ")
            If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("FROMNO")), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

            DTINV = OBJCMN.search(" TOP 1 JO_NO AS TONO ", "", " JOBOUT ", " AND JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JO_YEARID = " & YEARID & " ORDER BY JO_NO DESC ")
            If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("TONO")), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DTINV = OBJCMN.search(" DISTINCT COUNT(JO_NO) AS TOTALINV ", "", " JOBOUT ", " AND JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JO_YEARID = " & YEARID)
            If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("TOTALINV")), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

            DTINV = OBJCMN.Execute_Any_String("CREATE TABLE #TEMP (ID INT) DECLARE @I INT, @MAXNO INT   SELECT @I = MIN(JO_NO) FROM JOBOUT WHERE JOBOUT.JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_YEARID = " & YEARID & "  SELECT @MAXNO = MAX(JO_NO) FROM JOBOUT WHERE JOBOUT.JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_YEARID = " & YEARID & "  WHILE @I <= @MAXNO  BEGIN 	INSERT INTO #TEMP VALUES (@I) 	SET @I+=1  END   SELECT COUNT(#TEMP.ID) AS SRNO FROM #TEMP WHERE ID NOT IN (SELECT JO_NO FROM JOBOUT WHERE JOBOUT.JO_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND JOBOUT.JO_YEARID = " & YEARID & ")  DROP TABLE #TEMP ", "", "")
            If DTINV.Rows.Count > 0 Then Write(Val(DTINV.Rows(0).Item("SRNO")), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function EWAYBILL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            For I As Integer = 27 To 52
                SetColumn(I, Chr(65) + Chr(64 + I - 26))
            Next


            RowIndex = 1
            For i As Integer = 1 To 36
                SetColumnWidth(Range(i), 13)
            Next

            'SetColumnWidth(Range("3"), 25)
            'SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            
            Write("Supply Type", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Sub Type", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Doc Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Doc No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Doc Date", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_OtherPartyName", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_GSTIN", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_Address1", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_Place", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_Pin Code", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("From_State", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_OtherPartyName", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_GSTIN", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_Address1", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_Address2", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_Place", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_Pin Code", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("To_State", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Product", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Description", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("HSN", Range("21"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Unit", Range("22"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Qty", Range("23"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Ass_Value", Range("24"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Tax Rate", Range("25"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST Amt", Range("26"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGAT Amt", Range("27"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST Amt", Range("28"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amt", Range("29"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Trans Mode", Range("30"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Distance", Range("31"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Trans Name", Range("32"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Trans ID", Range("33"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Trans DocNo", Range("34"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Trans Date", Range("35"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Vehicle No", Range("36"), XlHAlign.xlHAlignCenter, , True, 10)


            For I As Integer = 1 To 36
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex, objColumn.Item(I.ToString).ToString & RowIndex)
            Next


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 2
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = ''  ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    '.TopMargin = 20
            '    '.LeftMargin = 10
            '    '.RightMargin = 5
            '    '.BottomMargin = 10
            '    '.Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURHSNSUMM_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal INVOICESCREENTYPE As String, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("7"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For HSN (12)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Integrated Tax", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Central Tax", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total State/UT Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & 40000 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            RowIndex += 1
            Write("HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Description", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UQC", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Integrated Tax Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Central Tax Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("State/UT Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            DT = OBJCMN.Execute_Any_String(" SELECT HSNCODE, HSNDESC, SUM(QTY) AS QTY, SUM(GRANDTOTAL) AS GRANDTOTAL, SUM(TAXABLEAMT) AS TAXABLEAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT, CMPID, YEARID FROM HSNPURSUMMARY WHERE DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' " & WHERECLAUSE & " AND YEARID = " & YEARID & " GROUP BY HSNCODE, HSNDESC, CMPID, YEARID", "", "")


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("HSNCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("HSNDESC"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)


                'Dim DTINV As New System.Data.DataTable
                'WE CAN NOT GET GRAND TOTAL IN ABOVE QUERY COZ THIS WIL CALC GRANDTOTAL MULTIPLE TIMES COZ WE HAVE JOIN WITH INVOICEDESC
                'BELOW CODE WASS TAKING TIME 
                'If INVOICESCREENTYPE = "LINE GST" Then
                'Else
                '    DTINV = OBJCMN.search("DISTINCT INVOICEMASTER.INVOICE_NO  ROUND(SUM(ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)),0) AS GRANDTOTAL, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) ELSE SUM(ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0)) END) AS TAXABLEAMT,", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " AND HSN_CODE = '" & DTROW("HSNCODE") & "'")
                'End If

                Write(Val(DTROW("GRANDTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGSTAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"



            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TDS REPORTS"

    Public Function TDSCHALLANDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            objSheet.Name = "CHALLAN DETAILS"
            SetColumnWidth(Range(8), 25)


            Dim OBJCMN As New ClsCommon
            'WE NEED TO GROUP
            'Dim DT As System.Data.DataTable = OBJCMN.search(" T.DATE, T.NAME, T.[BILLINITIALS], T.BILLAMT, T.TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION   ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  ORDER BY T.BILL")
            Dim DT As System.Data.DataTable = OBJCMN.search(" SUM(T.TDSAMT) AS TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  GROUP BY ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') , TDSCHALLAN.TDSCHA_CHALLANDATE , ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') , ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') , ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE ")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Font.Color = RGB(255, 255, 255)

            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No. (401)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))


            objSheet.Range(Range("2"), Range("6")).Interior.Color = RGB(102, 102, 153)
            Write("Income Tax (402)", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Interest (403)", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Fees (404)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Others/Penalty (405)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Total Tax Deposited/ Book Adjustment (406)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))



            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(255, 0, 0)
            Write("Whether deposited by book Adjustment Yes/No (407)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))



            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(102, 102, 153)
            Write("BSR Code (408)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))



            objSheet.Range(Range("9"), Range("10")).Interior.Color = RGB(255, 0, 0)
            Write("Date on which Tax Deposited/ Date of Transfer voucher (410)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Challan Serial No./DDO Serial No. of Form no. 24G (409)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))



            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(102, 102, 153)
            Write("Receipt No. of form 24G (408)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(255, 0, 0)
            Write("Minor Head of Challan (411)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))



            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(102, 102, 153)
            Write("Cheque/DD No.", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Section Code For Own Record (It will be import in Remark)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))



            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write("No", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("BANKNAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Convert.ToDateTime(DTROW("CHALLANDATE")).Date, Range("9"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHALLANNO"), Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("200", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHQNO"), Range("13"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("SECTION"), Range("14"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function TDSDEDUCTEEDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "DEDUCTEE DETAILS"



            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION, ACCOUNTSMASTER.Acc_panno AS PANNO,  T.NAME,T.DATE,  T.BILLAMT, ROUND(((T.TDSAMT/ T.BILLAMT) * 100),2) AS TAXPER,  T.TDSAMT, ACCOUNTSMASTER.Acc_add1  AS BLDGNAME, '' AS STREETNAME, ISNULL(area_name,'') AS AREANAME, ISNULL(CITY_NAME,'') AS CITYNAME, Acc_zipcode AS PIN, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW  WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T  LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID LEFT OUTER JOIN AREAMASTER ON Acc_areaid = area_id LEFT OUTER JOIN CITYMASTER ON Acc_cityid = city_id LEFT OUTER JOIN STATEMASTER ON Acc_stateid = state_id ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> '' ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE, TDSCHALLAN.TDSCHA_CHALLANNO, T.BILL")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("23")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Section Code", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))



            objSheet.Range(Range("3"), Range("5")).Interior.Color = RGB(102, 102, 153)
            Write("Type Of Rent", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("PAN Reference No. (In case of No PAN)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Deductee Reference no. If Available (413)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))



            objSheet.Range(Range("6"), Range("11")).Interior.Color = RGB(255, 0, 0)
            Write("Deductee Code (414)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Permanent Account Number (PAN) of deductee (415)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Name of Deductee (416)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Date on which Amount paid / credited (418)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Date on which tax deducted (422)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Amount of Payment (Rs.) (419)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("23")).Interior.Color = RGB(102, 102, 153)
            Write("Rate at which tax deducted (423)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Amount of tax deducted", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Total Tax Deposited (421)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))

            Write("Reason for Non-deduction / Lower Deduction, if any (424)", Range("15"), XlHAlign.xlHAlignCenter, Range("15"), True, 10, True)
            SetBorder(RowIndex, Range("15"), Range("15"))

            Write("Certificate No. u/s 197 issued by the AO for non deduction/ lower deduction (425)", Range("16"), XlHAlign.xlHAlignCenter, Range("16"), True, 10, True)
            SetBorder(RowIndex, Range("16"), Range("16"))

            Write("Deductee Flat No.", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10, True)
            SetBorder(RowIndex, Range("17"), Range("17"))

            Write("Deductee Building Name", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10, True)
            SetBorder(RowIndex, Range("18"), Range("18"))

            Write("Deductee Street Name", Range("19"), XlHAlign.xlHAlignCenter, Range("19"), True, 10, True)
            SetBorder(RowIndex, Range("19"), Range("19"))

            Write("Deductee Area", Range("20"), XlHAlign.xlHAlignCenter, Range("20"), True, 10, True)
            SetBorder(RowIndex, Range("20"), Range("20"))

            Write("Deductee City/Town", Range("21"), XlHAlign.xlHAlignCenter, Range("21"), True, 10, True)
            SetBorder(RowIndex, Range("21"), Range("21"))

            Write("Deductee PIN", Range("22"), XlHAlign.xlHAlignCenter, Range("22"), True, 10, True)
            SetBorder(RowIndex, Range("22"), Range("22"))

            Write("Deductee State", Range("23"), XlHAlign.xlHAlignCenter, Range("23"), True, 10, True)
            SetBorder(RowIndex, Range("23"), Range("23"))


            Dim a As Integer = 0
            Dim CNO As String = ""
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If CNO <> DTROW("CHALLANNO") Then
                    a += 1
                    CNO = DTROW("CHALLANNO")
                End If
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("SECTION"), Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PANNO"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("DATE"), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("11"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXPER")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("13"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("14"), XlHAlign.xlHAlignRight, , True, 9)
                Write("", Range("15"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("16"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("17"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BLDGNAME"), Range("18"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("STREETNAME"), Range("19"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("AREANAME"), Range("20"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CITYNAME"), Range("21"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PIN"), Range("22"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("STATENAME"), Range("23"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("23"))
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "OUTSTANDING REPORTS"

    Public Function OUTSTANDIGEXCEL(CLIENTNAME As String, CMPID As Integer, YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            objSheet.Name = "OUTSTANDING DETAILS"


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable


            RowIndex += 1
            Write("Party Name", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Bill No.", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Days", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bill Amt", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Part Payment", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Balance Amt", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Running Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Party Contact", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Agent Name", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Agent Contact", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Due Date", Range("12"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Charges", Range("13"), XlHAlign.xlHAlignLeft, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)



            Dim PARTYNAME As String = ""
            Dim AGENTNAME As String = ""
            Dim PARTYCONTACTNO As String = ""
            Dim AGENTCONTACTNO As String = ""
            Dim OLDAGENTNAME As String = ""

            DT = OBJCMN.Execute_Any_String("SELECT * FROM TEMPOUTSTANDING WHERE YEARID = " & YEARID & " ORDER BY SRNO", "", "")
            For Each DTROW As DataRow In DT.Rows
                If DTROW("INVNO") = "CONTACT NO : " Then
                    If Not IsDBNull(DTROW("LRNO")) Then PARTYCONTACTNO = DTROW("LRNO")
                    PARTYNAME = DTROW("NAME")
                    RowIndex += 1
                ElseIf DTROW("INVNO") <> "" Then
                    AGENTNAME = DTROW("NAME")
                End If
                If DTROW("INVNO") <> "" And DTROW("INVNO") <> "CONTACT NO : " Then
                    RowIndex += 1
                    Write(PARTYNAME, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("INVNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    If CLIENTNAME = "AVIS" Then Write(DateDiff(DateInterval.Day, DTROW("DATE"), Now.Date), Range("4"), XlHAlign.xlHAlignRight, , False, 10) Else Write(DTROW("DAYS"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("BILLAMT"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("RECDAMT"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("BALANCE"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    If RowIndex = 3 Then Write(DTROW("BALANCE"), Range("8"), XlHAlign.xlHAlignRight, , False, 10) Else FORMULA("=(" & objColumn.Item("8").ToString & RowIndex - 1 & "+" & objColumn.Item("7").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(PARTYCONTACTNO, Range("9"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(AGENTNAME, Range("10"), XlHAlign.xlHAlignLeft, , False, 10)

                    'AGENTMOBILENO
                    If OLDAGENTNAME <> AGENTNAME Then
                        Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" DISTINCT ISNULL(LEDGERS.Acc_mobile,'') AS AGENTMOBILENO ", "", " LEDGERS", " AND LEDGERS.ACC_CMPNAME = '" & AGENTNAME & "' AND LEDGERS.ACC_YEARID = " & YEARID)
                        If DTLEDGER.Rows.Count > 0 Then AGENTCONTACTNO = DTLEDGER.Rows(0).Item("AGENTMOBILENO")
                    End If

                    Write(AGENTCONTACTNO, Range("11"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("DUEDATE"), Range("12"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("CHARGES"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)


                    'IF DAYS IS GREATER THEN CRDAYS IN PARTYMASTER THEN IN RED COLOR ELSE BLACK COLOR
                    Dim DTCRDAYS As System.Data.DataTable = OBJCMN.Execute_Any_String("SELECT ISNULL(ACC_CRDAYS,0) AS CRDAYS FROM LEDGERS WHERE ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID = " & YEARID, "", "")
                    If CLIENTNAME = "AVIS" Then
                        If Val(DateDiff(DateInterval.Day, DTROW("DATE"), Now.Date)) > Val(DTCRDAYS.Rows(0).Item("CRDAYS")) Then objSheet.Range(Range("7"), Range("8")).Font.Color = RGB(255, 0, 0) Else objSheet.Range(Range("7"), Range("8")).Font.Color = RGB(0, 0, 0)
                    Else
                        If Val(DTROW("DAYS")) > Val(DTCRDAYS.Rows(0).Item("CRDAYS")) Then objSheet.Range(Range("7"), Range("8")).Font.Color = RGB(255, 0, 0) Else objSheet.Range(Range("7"), Range("8")).Font.Color = RGB(0, 0, 0)
                    End If

                    OLDAGENTNAME = DTROW("NAME")

                End If
            Next

            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 3 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 3 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 3 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 3, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 3, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 3, objColumn.Item("13").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STATEMENTOFACCOUNTS"

    Public Function STATEMENTOFACCOUNTS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt:" & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    '.Zoom = False
            '    ''.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function STATEMENTOFACCOUNTSDETAILS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS (DETAILS)", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt: " & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy") & "; Bales: " & Val(DTROW("TOTALBALES")) & "; Lot No: " & DTROW("LOTNO") & "; " & DTROW("STATION") & "; P.R.No: " & DTROW("PRNO") & "; NW: " & Val(DTROW("NETTWT")) & "; Rt:" & Format(((Val(DTROW("SUBTOTAL")) / 0.2812) / Val(DTROW("NETTWT"))) * 100, "0"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    '.Zoom = False
            '    ''.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "BANKRECO"

    Public Function BANKRECO(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DT As System.Data.DataTable = OBJRECO.GETDATA()
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL

            SetWorkSheet()
            For I = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For I = 1 To 26
                SetColumnWidth(Range(I), 14)
            Next


            ' **************************** CMPHEADER *************************
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))




            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

            ' **************************** CMPHEADER *************************




            RowIndex += 2
            Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 1
            Write("Bank Reconciliation Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'HEADERS
            RowIndex += 2
            Write("Bill No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reco Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            RowIndex += 2
            Write("Bank Balance as per Ledger Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)





            'GET ALL DEBIT AMOUNT
            I = 0
            RowIndex += 1
            Write("Chques Deposited but not Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            RowIndex += 1
            For Each DTROW As DataRow In DT.Rows

                If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                    I += 1
                    RowIndex += 1
                    Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                ElseIf Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                    If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    End If
                End If
            Next


            RowIndex += 1
            Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))



            'GET ALL CREDIT AMOUNT
            I = 0
            RowIndex += 2
            Write("Chques Issused but not Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            RowIndex += 1
            For Each DTROW As DataRow In DT.Rows
                If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                    I += 1
                    RowIndex += 1
                    Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                ElseIf Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                    If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    End If
                End If
            Next


            RowIndex += 1
            Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 2
            Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function BANKSTATEMENT(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0
            Dim BALANCE As Double = 0

            Dim DT As System.Data.DataTable = OBJCMN.search("DISTINCT RecoDate AS RECODATE, acc_initials AS BILLINITIALS, AGAINST AS NAME, ChqNo AS CHQNO, dr AS DR, cr AS CR", "", " BANKRECO", " AND BANKRECO.NAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " AND CAST(RECODATE AS DATE) >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(RECODATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "'  ORDER BY RECODATE")


            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Booking No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Bank Pass Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                BALANCE = Val(DTTOTAL.Rows(0).Item("BOOKBAL"))


                'GET ALL DEBIT AMOUNT
                I = 0
                Dim RDATE As Date = Now.Date
                Dim FROW As Boolean = True
                Dim FROMNO As Integer = 0
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    I += 1
                    RowIndex += 1
                    'GET REOCDATE ONLY ONCE
                    If RDATE <> DTROW("RECODATE") Then
                        If FROW = False Then
                            RowIndex += 1
                            Write(DTROW("RECODATE"), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & FROMNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & FROMNO & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)

                            'SET BALANCE
                            BALANCE = (BALANCE + Val(objSheet.Range(Range("7"), Range("7")).Text)) - Val(objSheet.Range(Range("6"), Range("6")).Text)

                            Write(Format(BALANCE, "0.00"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                            SetBorder(RowIndex, Range("1"), Range("8"))
                        End If

                        RowIndex += 2
                        Write(DTROW("RECODATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        RDATE = DTROW("RECODATE")
                        'GET TOTAL OF THE PARTICULAR DATE IF NOT FIRST ROW

                        FROMNO = RowIndex
                    End If
                    Write(DTROW("BILLINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    FROW = False
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))




                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlPortrait
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "JOBOUT REPORT"

    Public Function JOBOUTSUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal CLIENTNAME As String) As Object
        Try

            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" JOBOUT.JO_no AS JONO, JOBOUT.JO_date AS JODATE, LEDGERS.Acc_cmpname AS JOBBERNAME, GODOWNMASTER.GODOWN_name AS GODOWN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, SUM(JOBOUT_DESC.JO_PCS) AS TOTALPCS, SUM(JOBOUT_DESC.JO_MTRS) AS TOTALMTRS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2", "", "  QUALITYMASTER  RIGHT OUTER JOIN DESIGNMASTER  RIGHT OUTER JOIN ITEMMASTER  RIGHT OUTER JOIN JOBOUT_DESC INNER JOIN JOBOUT INNER JOIN CMPMASTER ON JOBOUT.JO_cmpid = CMPMASTER.cmp_id INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ON ITEMMASTER.item_id = JOBOUT_DESC.JO_ITEMID LEFT OUTER JOIN COLORMASTER  ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id ON DESIGNMASTER.DESIGN_id = JOBOUT_DESC.JO_DESIGNID ON QUALITYMASTER.QUALITY_id = JOBOUT_DESC.JO_QUALITYID", " AND JOBOUT.JO_YEARID = " & YEARID & CONDITION & " GROUP BY JOBOUT.JO_no, JOBOUT.JO_date, LEDGERS.Acc_cmpname, GODOWNMASTER.GODOWN_name, ISNULL(JOBOUT.JO_LOTNO, 0), ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ORDER BY JOBOUT.JO_DATE, JOBOUT.JO_NO ")
            If DT.Rows.Count > 0 Then


                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 52
                    SetColumn(I, Chr(65) + Chr(64 + I - 26))
                Next

                For I As Integer = 53 To 78
                    SetColumn(I, Chr(66) + Chr(64 + I - 52))
                Next

                For I As Integer = 79 To 104
                    SetColumn(I, Chr(67) + Chr(64 + I - 78))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 11)
                Next


                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("JO No", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Godown", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Item Name", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Quality", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Design", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Lot No", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Total Pcs", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Total Mtrs", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)

                Dim COLNO As Integer = 11

                'FOR PIECETYPE
                Dim DTPIECETYPE As System.Data.DataTable = objCMN.search(" DISTINCT PIECETYPE_NAME AS PIECETYPENAME", "", " PIECETYPEMASTER ", " AND PIECETYPE_YEARID = " & YEARID)
                For Each DTROW As System.Data.DataRow In DTPIECETYPE.Rows
                    Write(DTROW("PIECETYPENAME"), Range(COLNO.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    COLNO += 1
                Next

                Write("Recd Mtrs", Range(COLNO.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                COLNO += 1
                Write("Bal Mtrs", Range(COLNO.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                COLNO += 1

                If CLIENTNAME = "PURVITEX" Then
                    Write("Pur Party Name", Range(COLNO.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                Else
                    Write("Shrinkage %", Range(COLNO.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                End If
                COLNO += 1


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(COLNO.ToString).ToString & RowIndex)
                objSheet.Range(Range("1"), Range(COLNO.ToString)).Interior.Color = RGB(255, 255, 0)

                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("JONO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("JODATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("JOBBERNAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GODOWN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("ITEMNAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("QUALITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("DESIGN"), Range("7"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("LOTNO"), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Val(dr("TOTALPCS")), Range("9"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Val(dr("TOTALMTRS")), Range("10"), XlHAlign.xlHAlignRight, , False, 9)

                    For I As Integer = 11 To COLNO - 1
                        'FETCH JOBIN MTRS WITH RESPECT TO PIECETYPE
                        If IsDBNull(objSheet.Range(Range(I.ToString) & 7).Text) = False Then
                            'MsgBox(objSheet.Range(objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & 7).Text())
                            Dim DTJI As System.Data.DataTable = objCMN.search("ISNULL(SUM(JI_MTRS),0) AS TOTALMTRS", "", " JOBIN INNER JOIN JOBIN_DESC ON JOBIN.JI_no = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID INNER JOIN PIECETYPEMASTER ON JI_PIECETYPEID = PIECETYPE_id  ", " AND JI_JOBOUTNO = " & Val(dr("JONO")) & " AND PIECETYPE_name = '" & objSheet.Range(objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & 7).Text() & "' AND JOBIN.JI_YEARID = " & YEARID)
                            If DTJI.Rows.Count > 0 Then
                                Write(Val(DTJI.Rows(0).Item("TOTALMTRS")), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                            End If
                        End If
                    Next

                    FORMULA("=ROUND(SUM(" & objColumn.Item("11").ToString & RowIndex & ":" & objColumn.Item((COLNO - 4).ToString).ToString & RowIndex & "),2)", Range((COLNO - 3).ToString), XlHAlign.xlHAlignRight, , True, 9)
                    FORMULA("=ROUND((" & objColumn.Item("10").ToString & RowIndex & "-" & objColumn.Item((COLNO - 3).ToString).ToString & RowIndex & "),2)", Range((COLNO - 2).ToString), XlHAlign.xlHAlignRight, , True, 9)

                    'GET PURPARTYNAME FOR PURVITEX
                    If CLIENTNAME = "PURVITEX" Then
                        Dim DTPNAME As System.Data.DataTable = objCMN.search("ISNULL(PURLEDGERS.ACC_CMPNAME,'') AS PURNAME", "", " JOBIN LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON JI_PURLEDGERID = PURLEDGERS.ACC_ID   ", " AND JI_JOBOUTNO = " & Val(dr("JONO")) & " AND JOBIN.JI_YEARID = " & YEARID)
                        If DTPNAME.Rows.Count > 0 Then
                            Write(DTPNAME.Rows(0).Item("PURNAME"), Range(COLNO - 1.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        End If
                    End If

                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(COLNO.ToString).ToString & RowIndex)

                Next

                For i As Integer = 1 To COLNO - 1
                    SetBorder(RowIndex, objColumn.Item(i.ToString).ToString & 7, objColumn.Item(i.ToString).ToString & RowIndex)
                Next


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(COLNO.ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(COLNO.ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(COLNO.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(COLNO.ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(COLNO.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(COLNO.ToString))


                RowIndex += 1
                Write("JOB DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(COLNO.ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(COLNO.ToString))

                'SetBorder(RowIndex, Range("1"), Range(COLNO.ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(COLNO.ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(COLNO.ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True




                objBook.Application.ActiveWindow.Zoom = 100

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function JOBOUTDTLS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal CLIENTNAME As String) As Object
        Try

            Dim objCMN As New ClsCommon

            Dim DT As New System.Data.DataTable

            If CLIENTNAME = "MANINATH" Then
                DT = objCMN.search(" JOBOUT.JO_no AS JONO, JOBOUT.JO_date AS JODATE, LEDGERS.Acc_cmpname AS JOBBERNAME, GODOWNMASTER.GODOWN_name AS GODOWN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(JOBOUT_DESC.JO_BALENO, '') AS COLOR, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, SUM(JOBOUT_DESC.JO_PCS) AS TOTALPCS, SUM(JOBOUT_DESC.JO_MTRS) AS TOTALMTRS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2", "", "  QUALITYMASTER  RIGHT OUTER JOIN DESIGNMASTER  RIGHT OUTER JOIN ITEMMASTER  RIGHT OUTER JOIN JOBOUT_DESC INNER JOIN JOBOUT INNER JOIN CMPMASTER ON JOBOUT.JO_cmpid = CMPMASTER.cmp_id INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ON ITEMMASTER.item_id = JOBOUT_DESC.JO_ITEMID LEFT OUTER JOIN COLORMASTER  ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id ON DESIGNMASTER.DESIGN_id = JOBOUT_DESC.JO_DESIGNID ON QUALITYMASTER.QUALITY_id = JOBOUT_DESC.JO_QUALITYID", " AND JOBOUT.JO_YEARID = " & YEARID & CONDITION & " GROUP BY JOBOUT.JO_no, JOBOUT.JO_date, LEDGERS.Acc_cmpname, GODOWNMASTER.GODOWN_name, ISNULL(JOBOUT.JO_LOTNO, 0), ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(JOBOUT_DESC.JO_BALENO, ''), CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ORDER BY JOBOUT.JO_DATE, JOBOUT.JO_NO ")
            Else
                DT = objCMN.search(" JOBOUT.JO_no AS JONO, JOBOUT.JO_date AS JODATE, LEDGERS.Acc_cmpname AS JOBBERNAME, GODOWNMASTER.GODOWN_name AS GODOWN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_NAME, '') AS COLOR, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, SUM(JOBOUT_DESC.JO_PCS) AS TOTALPCS, SUM(JOBOUT_DESC.JO_MTRS) AS TOTALMTRS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2", "", "  QUALITYMASTER  RIGHT OUTER JOIN DESIGNMASTER  RIGHT OUTER JOIN ITEMMASTER  RIGHT OUTER JOIN JOBOUT_DESC INNER JOIN JOBOUT INNER JOIN CMPMASTER ON JOBOUT.JO_cmpid = CMPMASTER.cmp_id INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid LEFT OUTER JOIN PIECETYPEMASTER ON JOBOUT_DESC.JO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ON ITEMMASTER.item_id = JOBOUT_DESC.JO_ITEMID LEFT OUTER JOIN COLORMASTER  ON JOBOUT_DESC.JO_COLORID = COLORMASTER.COLOR_id ON DESIGNMASTER.DESIGN_id = JOBOUT_DESC.JO_DESIGNID ON QUALITYMASTER.QUALITY_id = JOBOUT_DESC.JO_QUALITYID", " AND JOBOUT.JO_YEARID = " & YEARID & CONDITION & " GROUP BY JOBOUT.JO_no, JOBOUT.JO_date, LEDGERS.Acc_cmpname, GODOWNMASTER.GODOWN_name, ISNULL(JOBOUT.JO_LOTNO, 0), ISNULL(ITEMMASTER.item_name, ''), ISNULL(QUALITYMASTER.QUALITY_name, ''), ISNULL(DESIGNMASTER.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_NAME, ''), CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ORDER BY JOBOUT.JO_DATE, JOBOUT.JO_NO ")
            End If
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 52
                    SetColumn(I, Chr(65) + Chr(64 + I - 26))
                Next

                For I As Integer = 53 To 78
                    SetColumn(I, Chr(66) + Chr(64 + I - 52))
                Next

                For I As Integer = 79 To 104
                    SetColumn(I, Chr(67) + Chr(64 + I - 78))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 11)
                Next


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("11"))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
                SetBorder(RowIndex, Range("1"), Range("11"))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
                SetBorder(RowIndex, Range("1"), Range("11"))


                RowIndex += 1
                Write("JOB DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
                SetBorder(RowIndex, Range("1"), Range("11"))


                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("11").ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("11").ToString & 8).Application.ActiveWindow.FreezePanes = True



                RowIndex += 2
                Write("JO No", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Godown", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Item Name", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Shade", Range("6"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Lot No", Range("7"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Total Pcs", Range("8"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Total Mtrs", Range("9"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Recd Mtrs", Range("10"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Bal Mtrs", Range("11"), XlHAlign.xlHAlignCenter, , True, 9)

                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
                objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(255, 255, 0)

                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("JONO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("JODATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("JOBBERNAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GODOWN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("ITEMNAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("COLOR"), Range("6"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("LOTNO"), Range("7"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Val(dr("TOTALPCS")), Range("8"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(Val(dr("TOTALMTRS")), Range("9"), XlHAlign.xlHAlignRight, , False, 9)

                    'FETCH JOBIN MTRS WITH RESPECT TO ITEM/QUALITY/DESIGN/COLOR
                    If IsDBNull(objSheet.Range(Range("5")).Text) = False Then
                        Dim DTJI As System.Data.DataTable = objCMN.search("ISNULL(SUM(JI_MTRS),0) AS TOTALMTRS", "", " JOBIN INNER JOIN JOBIN_DESC ON JOBIN.JI_no = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID INNER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON JOBIN_DESC.JI_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON JOBIN_DESC.JI_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id  ", " AND JI_JOBOUTNO = " & Val(dr("JONO")) & " AND ISNULL(ITEM_NAME,'') = '" & objSheet.Range(Range("5"), Range("5")).Text() & "' AND ISNULL(COLOR_NAME,'') = '" & objSheet.Range(Range("6"), Range("6")).Text() & "' AND JOBIN.JI_YEARID = " & YEARID)
                        If DTJI.Rows.Count > 0 Then
                            Write(Val(DTJI.Rows(0).Item("TOTALMTRS")), Range("10"), XlHAlign.xlHAlignRight, , False, 9)
                        End If
                    End If
                    FORMULA("=ROUND((" & objColumn.Item("9").ToString & RowIndex & "-" & objColumn.Item("10").ToString & RowIndex & "),2)", Range("11"), XlHAlign.xlHAlignRight, , True, 9)

                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)

                Next

                For i As Integer = 1 To 11
                    SetBorder(RowIndex, objColumn.Item(i.ToString).ToString & 7, objColumn.Item(i.ToString).ToString & RowIndex)
                Next

                objBook.Application.ActiveWindow.Zoom = 100

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    .Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "MIS REPORTS"

    Public Function MISALLDAILY_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("DAILY MIS REPORT (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("10"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("10").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("10").ToString & RowIndex + 1)

            RowIndex += 2
            Write("SR.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("PARTICULARS", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TODAYS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO LAST DATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO DATE (MONTH)", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO DATE (YEAR)", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            'SALES
            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("SALES", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE = CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE < CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            'SALES VALUE
            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE = CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE < CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)





            'SALES ORDER
            RowIndex += 2
            Write("2", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("ORDERS RECEIVED", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Number", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("No.", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            'ORDER METERS
            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            'ORDER VALUE
            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)





            'GREY PURCHASE
            RowIndex += 2
            Write("3", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("GREY PURCHASE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE = CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE < CAST(GETDATE() AS DATE) AND MONTH(GRN_DATE) = MONTH(GETDATE()) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE <= CAST(GETDATE() AS DATE) AND MONTH(GRN_DATE) = MONTH(GETDATE()) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE = CAST(GETDATE() AS DATE) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE = CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE < CAST(GETDATE() AS DATE) AND MONTH(PURCHASEMASTER.BILL_PARTYBILLDATE) = MONTH(GETDATE()) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE < CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE <= CAST(GETDATE() AS DATE) AND MONTH(PURCHASEMASTER.BILL_PARTYBILLDATE) = MONTH(GETDATE()) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE <= CAST(GETDATE() AS DATE) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)




            'STOCK
            RowIndex += 2
            Write("STOCKS", Range("2"), XlHAlign.xlHAlignLeft, , True, 13)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignCenter, , True, 13)
            Write("GREY STOCK", Range("4"), XlHAlign.xlHAlignCenter, , True, 13)
            Write("PROCESS STOCK", Range("5"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("WIP TOTAL STOCK", Range("6"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("GODOWN STOCK (FRESH)", Range("7"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("GODOWN STOCK (PCS)", Range("8"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("PACKING STOCK", Range("9"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("FINISH TOTAL STOCK", Range("10"), XlHAlign.xlHAlignCenter, , True, 13, True)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Opening Stock", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            'GREY STOCK
            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GREYMTRS", "", " GRN LEFT OUTER JOIN LEDGERS ON GRN.GRN_TOLEDGERID = LEDGERS.ACC_ID", " AND GRN_TYPE = 'Job Work' AND (ISNULL(GRN_TOLEDGERID,0) = 0 OR ISNULL(LEDGERS.ACC_CMPNAME,'') = 'AVIS TRANSPORT') AND GRN_DATE < CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            'PROCESS STOCK
            DT = OBJCMN.search(" ISNULL(SUM(BALMTRS),0) AS PROCESSMTRS", "", " LOT_VIEW ", " and LOT_VIEW.LOTCOMPLETED ='FALSE' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PROCESSMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            'TOTAL WIP OPENING STOCK
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)

            'BARCODE STOCK ONLY FRESH PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='FRESH' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)


            'BARCODE STOCK ONLY PIECES PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='PIECES' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)


            'INHOUSE PACKING STOCK
            DT = OBJCMN.search(" ISNULL(SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)), 0) AS TOTALMTRS", "", " ISSUEPACKING_DESC INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID", " and ISSUEPACKING.ISS_DATE < CAST(GETDATE() AS DATE) AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0  AND ISSUEPACKING.ISS_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)


            'TOTAL FINISH OPENING STOCK
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex & ":" & objColumn.Item("9").ToString & RowIndex & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            'TODAYS RECEIPT STOCK
            RowIndex += 1
            Write("Today's Receipt", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            'GREY STOCK
            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GREYMTRS", "", " GRN LEFT OUTER JOIN LEDGERS ON GRN.GRN_TOLEDGERID = LEDGERS.ACC_ID", " AND GRN_TYPE = 'Job Work' AND (ISNULL(GRN_TOLEDGERID,0) = 0 OR ISNULL(LEDGERS.ACC_CMPNAME,'') = 'AVIS TRANSPORT') AND GRN_DATE = CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            'PROCESS STOCK
            DT = OBJCMN.search(" ISNULL(SUM(BALMTRS),0) AS PROCESSMTRS", "", " LOT_VIEW ", " and LOT_VIEW.LOTCOMPLETED ='FALSE' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PROCESSMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            'TOTAL WIP TODAYS STOCK
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)


            'BARCODE STOCK ONLY FRESH PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='FRESH' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)


            'BARCODE STOCK ONLY PIECES PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='PIECES' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)


            'INHOUSE PACKING STOCK
            DT = OBJCMN.search(" ISNULL(SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)), 0) AS TOTALMTRS", "", " ISSUEPACKING_DESC INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID", " and ISSUEPACKING.ISS_DATE = CAST(GETDATE() AS DATE) AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0  AND ISSUEPACKING.ISS_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)


            'TOTAL FINISH TODAYS STOCK
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex & ":" & objColumn.Item("9").ToString & RowIndex & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            'CLOSING STOCK
            RowIndex += 1
            Write("Closing Stock", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex - 2 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & RowIndex - 2 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & RowIndex - 2 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - 2 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & RowIndex - 2 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & RowIndex - 2 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & RowIndex - 2 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)




            'SALE ORDER
            RowIndex += 2
            Write("5", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PENDING SALE ORDER", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING ORDERS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PO ISSUED", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BALANCE ORDER", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS),0) AS ORDERMTRS", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.TYPE = ALLSALEORDER_DESC.TYPE AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID ", " AND ALLSALEORDER_DESC.SO_CLOSED = 0 AND (ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS) > 0 and ALLSALEORDER.SO_DATE < CAST(GETDATE() AS DATE) AND ALLSALEORDER_DESC.SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS),0) AS ORDERMTRS", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.TYPE = ALLSALEORDER_DESC.TYPE AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID ", " AND ALLSALEORDER_DESC.SO_CLOSED = 0 AND (ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS) > 0 and ALLSALEORDER.SO_DATE = CAST(GETDATE() AS DATE) AND ALLSALEORDER_DESC.SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)





            'PURCHASE ORDER
            RowIndex += 2
            Write("6", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PENDING PURCHASE ORDER", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING ORDERS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIVED", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BALANCE ORDER", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS),0) AS ORDERMTRS", "", " ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.TYPE = ALLPURCHASEORDER_DESC.TYPE AND ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID ", " AND ALLPURCHASEORDER_DESC.PO_CLOSED = 0 AND (ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS) > 0 and ALLPURCHASEORDER.PO_DATE < CAST(GETDATE() AS DATE) AND ALLPURCHASEORDER_DESC.PO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS),0) AS ORDERMTRS", "", " ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.TYPE = ALLPURCHASEORDER_DESC.TYPE AND ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID ", " AND ALLPURCHASEORDER_DESC.PO_CLOSED = 0 AND (ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS) > 0 and ALLPURCHASEORDER.PO_DATE = CAST(GETDATE() AS DATE) AND ALLPURCHASEORDER_DESC.PO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)




            'RECEIVABLE BALANCE
            RowIndex += 2
            Write("7", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("RECEIVABLE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SALES / DEBITNOTE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT RECEIVED", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT NOTE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND acc_type <> 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS RECAMT", "", " REGISTER ", " AND acc_type = 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("RECAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND acc_type <> 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-SUM(" & objColumn.Item("6").ToString & RowIndex & ":" & objColumn.Item("7").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)





            'PAYABLE BALANCE
            RowIndex += 2
            Write("8", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PAYABLE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PURCHASE / CREDITNOTE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT MADE", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT NOTE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR)-SUM(DR),0) AS BALAMT", "", " REGISTER ", " AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND acc_type <> 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS PAYAMT", "", " REGISTER ", " AND acc_type = 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PAYAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND acc_type <> 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-SUM(" & objColumn.Item("6").ToString & RowIndex & ":" & objColumn.Item("7").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)





            'BANK A/C
            RowIndex += 2
            Write("9", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("BANK", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIPT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ACC_CMPNAME AS BANKNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID", " AND (GROUP_Secondary = 'BANK A/C' OR GROUP_Secondary = 'BANK OD A/C') AND  ACC_YEARID = " & YEARID)
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("BANKNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND NAME = '" & ROW("BANKNAME") & "' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND NAME = '" & ROW("BANKNAME") & "' AND (acc_type = 'RECEIPT' OR acc_type = 'CONTRA' OR acc_type = 'PAYMENT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", "  AND NAME = '" & ROW("BANKNAME") & "' AND (acc_type = 'PAYMENT' OR acc_type = 'CONTRA' OR acc_type = 'RECEIPT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-" & objColumn.Item("6").ToString & RowIndex, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            Next





            'CASH IN HAND
            RowIndex += 2
            Write("9", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("BANK", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIPT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ACC_CMPNAME AS CASHNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID", " AND GROUP_Secondary = 'Cash In Hand' AND  ACC_YEARID = " & YEARID)
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("CASHNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND (acc_type = 'RECEIPT' OR acc_type = 'CONTRA' OR acc_type = 'PAYMENT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND (acc_type = 'PAYMENT' OR acc_type = 'CONTRA' OR acc_type = 'RECEIPT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-" & objColumn.Item("6").ToString & RowIndex, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            Next




            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)




            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function DAILYDISPATCH_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next



            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("DAILY DISPATCH REPORT (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("8").ToString & RowIndex + 1)

            RowIndex += 2
            Write("DATE", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("SALES (MTRS)", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SALES (MTRS TOTAL)", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DISPATCH (MTRS)", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DISPATCH (MTRS TOTAL)", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GR (MTRS)", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GR (MTRS TOTAL)", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL MTRS", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            'LOOP DAY WISE FOR CURRENT MONTH
            For I As Integer = 1 To Now.Day

                RowIndex += 1
                Write(" " & I & "/" & Now.Month & "/" & Now.Year, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET SALEMTRS
                DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND DAY(invoice_DATE) = " & I & " AND MONTH(invoice_DATE) = " & Now.Month & " And INVOICE_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("INVMTRS")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                End If

                'GET DISPATCHMTRS
                DT = OBJCMN.search(" ISNULL(SUM(GDN_TOTALMTRS),0) AS GDNMTRS", "", " GDN ", " AND DAY(GDN_DATE) = " & I & " AND MONTH(GDN_DATE) = " & Now.Month & " And GDN_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("GDNMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("GDNMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If


                'GET GRMTRS
                DT = OBJCMN.search(" ISNULL(SUM(SALRET_TOTALMTRS),0) AS GRMTRS", "", " SALERETURN ", " AND DAY(SALRET_DATE) = " & I & " AND MONTH(SALRET_DATE) = " & Now.Month & " And SALRET_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("GRMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("GRMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                End If


                'IF 1ST DAY THEN DONT ADD FORMULA
                If I > 1 Then
                    FORMULA("=(" & objColumn.Item("3").ToString & RowIndex - 1 & "+" & objColumn.Item("2").ToString & RowIndex & ")", Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                    FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 1 & "+" & objColumn.Item("4").ToString & RowIndex & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    FORMULA("=(" & objColumn.Item("7").ToString & RowIndex - 1 & "+" & objColumn.Item("6").ToString & RowIndex & ")", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                End If

                FORMULA("=(" & objColumn.Item("4").ToString & RowIndex & "-" & objColumn.Item("6").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

End Class
