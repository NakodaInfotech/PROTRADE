
Imports BL

Public Class DayBook

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub DayBook_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DayBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lbldate.Text = Now.Date.Date
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try

            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")


            'Dim dtrow As DataRow
            'Dim i As Integer

            'For i = 0 To gridregister.RowCount - 1
            '    dtrow = gridregister.GetDataRow(i)
            '    txtdrtotal.Text = Format(Val(txtdrtotal.Text) + Val(dtrow(4).ToString), "0.00")
            '    txtcrtotal.Text = Format(Val(txtcrtotal.Text) + Val(dtrow(5).ToString), "0.00")
            'Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objDAYBOOK As New ClsDayBook

        If chkdate.Checked = True Then
            ALPARAVAL.Add(1)
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(0)
            ALPARAVAL.Add(Format(Mydate, "MM/dd/yyyy"))
            ALPARAVAL.Add(Format(Mydate, "MM/dd/yyyy"))
        End If
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objDAYBOOK.alParaval = ALPARAVAL
        If chkdetails.CheckState = CheckState.Unchecked Then
            dt = objDAYBOOK.getdata
        Else
            dt = objDAYBOOK.getDETAILS
        End If
        griddetails.DataSource = dt


        total()
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dtto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtto.Validated
        Try
            If chkdate.CheckState = CheckState.Checked Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
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

    Private Sub chkdetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdetails.CheckedChanged
        fillgrid()
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim objreg As New registerdesign
            'strsearch = "{SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@PBILL_NO}=" & tempbillno & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@registername}=" & cmbregister.Text & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@cmpid}=" & CmpId & ""
            If chkdetails.Checked = False Then
                objreg.frmstring = "DayBook"
            Else
                objreg.frmstring = "DayBookDetails"
            End If
            If chkdate.Checked = True Then
                objreg.CHECK = True

                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
            Else
                objreg.CHECK = False

                objreg.FROMDATE = Now.Date
                objreg.TODATE = Now.Date
            End If
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        showform()
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Day Book.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If


            opti.SheetName = "Day Book"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Day Book", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Day Book Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DayBook_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class