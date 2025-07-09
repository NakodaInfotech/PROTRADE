
Imports BL

Public Class CFormSummary

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        If CMBTYPE.Text.Trim = "" Then
            MsgBox("Select Type", MsgBoxStyle.Critical)
            CMBTYPE.Focus()
            Exit Sub
        End If
        fillgrid()
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim OBJCFORM As New ClsCForm

        ALPARAVAL.Add(CMBFORM.Text.Trim)

        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(AccFrom)
            ALPARAVAL.Add(AccTo)
        End If

        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)
        ALPARAVAL.Add(CMBTYPE.Text.Trim)

        OBJCFORM.alParaval = ALPARAVAL

        If RBALL.Checked = True Then
            griddetails.DataSource = OBJCFORM.GETALLBILLSSUMMARY
        ElseIf RBPENDING.Checked = True Then
            griddetails.DataSource = OBJCFORM.GETPENDINGBILLSSUMMARY
        Else
            griddetails.DataSource = OBJCFORM.GETRECDBILLSSUMMARY
        End If

        total()

    End Sub

    Sub total()
        Try
            TXTTOTAL.Text = 0.0

            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            For i As Integer = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                TXTTOTAL.Text = (Val(dtrow("AMOUNT")) + Val(TXTTOTAL.Text.Trim))
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFORM_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFORM.Enter
        Try
            If CMBFORM.Text.Trim = "" Then FILLFORMTYPE(CMBFORM, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFORM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFORM.Validating
        Try
            If CMBFORM.Text.Trim <> "" Then FORMVALIDATE(CMBFORM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            If CMBTYPE.Text.Trim = "" Then
                MsgBox("Select Type", MsgBoxStyle.Critical)
                CMBTYPE.Focus()
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        showform()
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            Try
                Dim OBJCFORM As New CFormEntry
                OBJCFORM.MdiParent = MDIMain
                OBJCFORM.cmbname.Text = gridregister.GetFocusedDataRow("NAME")
                OBJCFORM.CMBFORM.Text = CMBFORM.Text.Trim
                OBJCFORM.Show()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Form Summary.XLS"
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Form Summary"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Form Summary", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        showform()
    End Sub

End Class