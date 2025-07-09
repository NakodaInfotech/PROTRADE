
Imports BL

Public Class SalesTaxRegisterDetails

    Private Sub SalesTexRegisterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim ALPARAVAL As New ArrayList

            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            Dim OBJCMN As New ClsSalesTaxRegister

            OBJCMN.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJCMN.SALETAX
            If DT.Rows.Count > 0 Then
                griddetails.DataSource = DT

                gridregister.OptionsView.AllowCellMerge = False

                For I As Integer = 3 To gridregister.Columns.Count - 1
                    If I <> 7 And I <> 8 And I <> 9 Then gridregister.Columns(I).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                Next

                gridregister.Columns("Hotel Name").Width = 180
                gridregister.Columns("BILL").Visible = False
                gridregister.Columns("BOOKTYPE").Visible = False
                gridregister.Columns("TYPE").Visible = False

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Sales Tax Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If


            opti.SheetName = "Sales Tax Register"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sales Tax Register", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        FILLGRID()
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
                VIEWFORM(dtrow("TYPE"), True, dtrow("BILL"), dtrow("REGTYPE"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class