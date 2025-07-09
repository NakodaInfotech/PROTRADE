
Imports BL

Public Class BankReco

    Dim EDIT As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BankReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objRECO As New ClsBankReco
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

            TXTTOTALCR.Clear()
            TXTTOTALDR.Clear()

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            objRECO.alParaval = ALPARAVAL

            If chkAll.CheckState = CheckState.Unchecked Then
                DT = objRECO.GETDATA
                EDIT = False
            Else
                DT = objRECO.GETALLDATA()
                EDIT = True
            End If

            'If DT.Rows.Count > 0 Then
            griddetails.DataSource = DT
            TOTAL()

            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALCR.Clear()
            TXTTOTALDR.Clear()

            Dim OBJBANKRECO As New ClsBankReco
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJBANKRECO.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJBANKRECO.GETTOTAL
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then txtbalcmp.Text = Format(DT.Rows(0).Item(0), "0.00")
                LBLBOOKDRCR.Text = DT.Rows(0).Item(1)
                If DT.Rows(0).Item(2).ToString <> "" Then txtdr.Text = Format(DT.Rows(0).Item(2), "0.00")
                If DT.Rows(0).Item(3).ToString <> "" Then txtcr.Text = Format(DT.Rows(0).Item(3), "0.00")
                If DT.Rows(0).Item(4).ToString <> "" Then txtbal.Text = Format(DT.Rows(0).Item(4), "0.00")
                LBLBANKDRCR.Text = DT.Rows(0).Item(5)
            End If


            Dim NEWDT As DataTable = griddetails.DataSource
            For Each DTROW As DataRow In NEWDT.Rows
                If IsDBNull(DTROW("RecoDate")) = False Then
                    TXTTOTALDR.Text = Val(TXTTOTALDR.Text) + Val(DTROW("DR"))
                    TXTTOTALCR.Text = Val(TXTTOTALCR.Text) + Val(DTROW("CR"))
                End If
            Next

            TXTTEMPBAL.Text = Val(txtbalcmp.Text.Trim) + (Val(txtcr.Text.Trim) - Val(TXTTOTALCR.Text.Trim)) - (Val(txtdr.Text.Trim) - Val(TXTTOTALDR.Text.Trim))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim OBJRECO As New ClsBankReco
            Dim INTRESULT As Integer
            Dim ALPARAVAL As New ArrayList
            Dim type As String = ""
            Dim BILLINITIALS As String = ""
            Dim billno As String = ""
            Dim recodate As String = ""
            Dim gridsrno As String = ""
            Dim BILLYEARID As String = ""

            If gridBANKRECO.FilterPanelText <> "" Then gridBANKRECO.ActiveFilterEnabled = False

            For i As Integer = 0 To gridBANKRECO.DataRowCount - 1
                Dim dtrow As DataRow = gridBANKRECO.GetDataRow(i)
                If dtrow(3).ToString <> "" Then

                    If type = "" Then
                        type = dtrow(2).ToString
                        BILLINITIALS = dtrow("BillInitials").ToString
                        billno = dtrow(9).ToString
                        recodate = Format(Convert.ToDateTime(dtrow(3)).Date, "MM/dd/yyyy")
                        gridsrno = dtrow(8).ToString
                        BILLYEARID = dtrow("YEARID").ToString
                    Else
                        type = type & "," & dtrow(2).ToString
                        BILLINITIALS = BILLINITIALS & "," & dtrow("BillInitials").ToString
                        billno = billno & "," & dtrow(9).ToString
                        recodate = recodate & "," & Format(Convert.ToDateTime(dtrow(3)).Date, "MM/dd/yyyy")
                        gridsrno = gridsrno & "," & dtrow(8)
                        BILLYEARID = BILLYEARID & "," & dtrow("YEARID").ToString
                    End If

                End If
            Next

            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
            ALPARAVAL.Add(type)
            ALPARAVAL.Add(BILLINITIALS)
            ALPARAVAL.Add(billno)
            ALPARAVAL.Add(recodate)
            ALPARAVAL.Add(gridsrno)
            ALPARAVAL.Add(BILLYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJRECO.alParaval = ALPARAVAL

            If EDIT = False Then
                INTRESULT = OBJRECO.SAVE()
                MsgBox("Details Saved")
            Else
                INTRESULT = OBJRECO.UPDATE()
                MsgBox("Details Saved")
            End If

            chkAll.CheckState = CheckState.Unchecked
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Print Statement?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJRPT As New clsReportDesigner("BANK STATEMENT", System.AppDomain.CurrentDomain.BaseDirectory & "BANK STATEMENT.xlsx", 2)
                OBJRPT.BANKSTATEMENT(txtname.Text.Trim, dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId)
            Else
                Dim OBJRPT As New clsReportDesigner("BANK RECO", System.AppDomain.CurrentDomain.BaseDirectory & "BANK RECO.xlsx", 2)
                OBJRPT.BANKRECO(txtname.Text.Trim, dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBANKRECO_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridBANKRECO.InvalidRowException
        Try
            e.ErrorText = "Reco Date should be after Bill Date"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBANKRECO_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridBANKRECO.ValidateRow
        Try

            Dim BILLDATE, BANKDATE As Date
            BILLDATE = gridBANKRECO.GetFocusedRowCellValue("BillDate")
            If IsDBNull(gridBANKRECO.GetFocusedRowCellValue("RecoDate")) = True Then
                BANKDATE = BILLDATE
            Else
                BANKDATE = gridBANKRECO.GetFocusedRowCellValue("RecoDate")
            End If

            If BILLDATE > BANKDATE Then
                e.Valid = False
            Else
                Dim DTROW As DataRow = gridBANKRECO.GetFocusedDataRow
                If IsDBNull(DTROW("RecoDate")) = True Then
                    TXTTOTALDR.Text = Val(TXTTOTALDR.Text.Trim) - Val(DTROW("DR"))
                    TXTTOTALCR.Text = Val(TXTTOTALCR.Text.Trim) - Val(DTROW("CR"))
                Else
                    TXTTOTALDR.Text = Val(TXTTOTALDR.Text.Trim) + Val(DTROW("DR"))
                    TXTTOTALCR.Text = Val(TXTTOTALCR.Text.Trim) + Val(DTROW("CR"))
                End If
                TXTTEMPBAL.Text = Val(txtbalcmp.Text.Trim) + (Val(txtcr.Text.Trim) - Val(TXTTOTALCR.Text.Trim)) - (Val(txtdr.Text.Trim) - Val(TXTTOTALDR.Text.Trim))

            End If
            gridBANKRECO.SetColumnError(gridBANKRECO.Columns("grecodate"), "Reco Date should be after Bill Date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BankReco_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub TOOLUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLUPLOAD.Click

        On Error GoTo LINE1
        Dim OBJUPLOAD As New UploadExcelStatement
        OBJUPLOAD.ShowDialog()
        If OBJUPLOAD.txtimgpath.Text.Trim <> "" Then
            Dim STARTROW, ENDROW As Integer
            Dim FILENAME, FILEPATH, DATECOL, CHQCOL, DRCOL, CRCOL, SHEETNAME As String

            STARTROW = Val(OBJUPLOAD.TXTSTART.Text.Trim)
            ENDROW = Val(OBJUPLOAD.TXTEND.Text.Trim)
            DATECOL = OBJUPLOAD.TXTDATECOL.Text.Trim
            CHQCOL = OBJUPLOAD.TXTCHQCOL.Text.Trim
            DRCOL = OBJUPLOAD.TXTDRCOL.Text.Trim
            CRCOL = OBJUPLOAD.TXTCRCOL.Text.Trim

            FILENAME = OBJUPLOAD.TXTFILENAME.Text.Trim
            FILEPATH = OBJUPLOAD.txtimgpath.Text.Trim
            SHEETNAME = OBJUPLOAD.TXTSHEETNAME.Text.Trim


            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open(FILEPATH, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets(SHEETNAME)

            'GRID
            Dim DT As New System.Data.DataTable
            DT.Columns.Add("CHQNO")
            DT.Columns.Add("DR")
            DT.Columns.Add("CR")

            Dim COLDATE As DataColumn = New DataColumn("DATE")
            COLDATE.DataType = System.Type.GetType("System.DateTime")
            DT.Columns.Add(COLDATE)

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            For I As Integer = STARTROW To ENDROW
                Dim DTROW As System.Data.DataRow = DT.NewRow()
                If IsDBNull(oSheet.Range(CHQCOL.ToString & I.ToString).Text) = False Then
                    DTROW("CHQNO") = oSheet.Range(CHQCOL.ToString & I.ToString).Text
                Else
                    DTROW("CHQNO") = ""
                End If
                If IsDBNull(oSheet.Range(DRCOL.ToString & I.ToString).Text) = False Then
                    DTROW("DR") = Val(oSheet.Range(DRCOL.ToString & I.ToString).Value)
                Else
                    DTROW("DR") = 0
                End If
                If IsDBNull(oSheet.Range(CRCOL.ToString & I.ToString).Text) = False Then
                    DTROW("CR") = Val(oSheet.Range(CRCOL.ToString & I.ToString).Value)
                Else
                    DTROW("CR") = 0
                End If
                If IsDBNull(oSheet.Range(DATECOL.ToString & I.ToString).Text) = False Then
                    DTROW("DATE") = oSheet.Range(DATECOL.ToString & I.ToString).Text
                Else
                    DTROW("DATE") = Now.Date
                End If
                DT.Rows.Add(DTROW)
            Next

            Dim DV As DataView = gridBANKRECO.DataSource
            Dim DTNEW As DataTable = DV.Table
            If DT.Rows.Count > 0 Then
                For Each ROW As System.Data.DataRow In DT.Rows
                    For Each DTNEWROW As DataRow In DTNEW.Rows
                        If ROW("CHQNO") = DTNEWROW("ChqNo") And (Val(ROW("DR")) = Val(DTNEWROW("dr")) Or Val(ROW("CR")) = Val(DTNEWROW("cr"))) Then
                            'If Format(Convert.ToDateTime(DTNEWROW("BillDate")).Date, "dd/MM/yyyy") <= Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yyyy") Then DTNEWROW("RecoDate") = Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yyyy")
                            'If Format(Convert.ToDateTime(DTNEWROW("BillDate")).Date, "dd/MM/yyyy") <= Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yyyy") Then DTNEWROW("RecoDate") = ROW("DATE")
                            DTNEWROW("RecoDate") = ROW("DATE")
                        End If
                    Next
                Next
            End If


            oBook.Close()

        End If
        Exit Sub
LINE1:
        MsgBox("Enter Proper Excel File Parameters", MsgBoxStyle.Critical)
        Exit Sub

    End Sub

    Private Sub gridBANKRECO_KeyDown(sender As Object, e As KeyEventArgs) Handles gridBANKRECO.KeyDown
        Try
            Dim DTROW As DataRow = gridBANKRECO.GetFocusedDataRow()
            If e.KeyCode = Keys.F5 Then
                DTROW("RecoDate") = DTROW("BillDate")
                'ElseIf e.KeyCode = Keys.Delete Then
                '    DTROW("RecoDate") = vbNull
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class