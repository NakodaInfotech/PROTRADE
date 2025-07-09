Imports BL

Public Class BeamIssueWeaverDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT


    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal BEAMISSUENO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJBEAMISSUE As New BeamIssueWeaver
            OBJBEAMISSUE.EDIT = EDITVAL
            OBJBEAMISSUE.MdiParent = MDIMain
            OBJBEAMISSUE.TEMPBEAMISSUENO = BEAMISSUENO
            OBJBEAMISSUE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BeamIssueDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            Call TOOLREFRESH_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call TOOLEXCEL_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub BeamIssueDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJBEAMISSUE As New ClsBeamIssueToWeaver
            OBJBEAMISSUE.alParaval.Add(0)
            OBJBEAMISSUE.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJBEAMISSUE.selectBEAMISSUE()
            gridbilldetails.DataSource = dttable
            If dttable.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, gridbill.GetFocusedRowCellValue("BEAMISSUENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, gridbill.GetFocusedRowCellValue("BEAMISSUENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADD.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Beam Issue to warper Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Beam Issue to warper Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Beam Issue to warper Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Then Exit Sub
            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Proper Beam Issue Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Wish to Print Beam Issue from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            ' serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), "", "BEAMISSUEBEAMNO", Val(TXTCOPIES.Text.Trim), PRINTDIALOG)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TXTCOPIES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPIES.Validating
        If Val(TXTCOPIES.Text.Trim) <= 0 Then TXTCOPIES.Text = 1
    End Sub
End Class