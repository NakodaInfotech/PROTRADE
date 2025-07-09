
Imports BL

Public Class JournalDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Private Sub JournalDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" dbo.journalMaster.journal_no AS SRNO, dbo.Ledgers.acc_cmpname AS [Party Name] ,dbo.JournalMaster.journal_date AS [Date], sum(dbo.journalMaster.journal_credit) as Amount, dbo.journalMaster.journal_remarks AS [Remarks]", "", "  dbo.JournalMaster LEFT OUTER JOIN dbo.Ledgers ON dbo.JournalMaster.journal_cmpid = dbo.Ledgers.acc_cmpid AND dbo.JournalMaster.journal_LOCATIONid = dbo.Ledgers.acc_LOCATIONid AND dbo.JournalMaster.journal_YEARid = dbo.Ledgers.acc_YEARid AND dbo.journalMaster.journal_ledgerid = dbo.Ledgers.acc_id  ", tempcondition & " GROUP BY dbo.journalMaster.journal_no, dbo.Ledgers.acc_cmpname  ,dbo.JournalMaster.journal_date , dbo.journalMaster.journal_remarks order by dbo.JOURNALMASTER.JOURNAL_NO")
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridjournal.FocusedRowHandle = gridjournal.RowCount - 1
                gridjournal.TopRowIndex = gridjournal.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridjournal.RowCount > 0) Then
                Dim objJVmaster As New journal
                objJVmaster.MdiParent = MDIMain
                objJVmaster.edit = editval
                objJVmaster.tempjvno = billno
                objJVmaster.TEMPREGNAME = cmbregister.Text.Trim
                objJVmaster.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridjournal.DoubleClick
        Try
            showform(True, gridjournal.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    JVREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.JOURNALMASTER.JOURNAL_cmpid=" & CmpId & " and dbo.JOURNALMASTER.JOURNAL_LOCATIONid=" & Locationid & " and dbo.JOURNALMASTER.JOURNAL_YEARid=" & YearId & " AND JOURNALMASTER.JOURNAL_registerid = " & JVREGID & " AND DBO.JOURNALMASTER.JOURNAL_DEBIT = 0")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOURNAL VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJJV As New JournalGridDetails
            OBJJV.MdiParent = MDIMain
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridjournal.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Journal Register Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Journal Register Details"
            gridjournal.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Journal Register Details", gridjournal.VisibleColumns.Count + gridjournal.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Journal Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub JournalDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridjournal.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Journal Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Journal from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Journal ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridjournal.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Journal Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp Journal from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected Journal ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridjournal.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Journal Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Journal from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Journal Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJJV As New Journal_Contra_Design
                OBJJV.MdiParent = MDIMain
                OBJJV.DIRECTPRINT = True
                OBJJV.FRMSTRING = "JOURNAL"
                OBJJV.DIRECTMAIL = INVOICEMAIL
                OBJJV.DIRECTWHATSAPP = WHATSAPP
                OBJJV.REGNAME = cmbregister.Text.Trim
                OBJJV.PRINTSETTING = PRINTDIALOG
                OBJJV.BILLNO = Val(I)
                OBJJV.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJJV.strsearch = "{JOURNALMASTER.JOURNAL_NO} = " & Val(I) & " And {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' AND {JOURNALMASTER.JOURNAL_YEARID} = " & YearId
                OBJJV.Show()
                OBJJV.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\JV_" & I & ".pdf")
                FILENAME.Add("JV_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Journal"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList

            If INVOICEMAIL = False And WHATSAPP = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridjournal.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridjournal.GetDataRow(SELECTEDROWS(I))

                Dim OBJJV As New Journal_Contra_Design
                OBJJV.MdiParent = MDIMain
                OBJJV.DIRECTPRINT = True
                OBJJV.FRMSTRING = "JOURNAL"
                OBJJV.DIRECTMAIL = INVOICEMAIL
                OBJJV.DIRECTWHATSAPP = WHATSAPP
                OBJJV.REGNAME = cmbregister.Text.Trim
                OBJJV.PRINTSETTING = PRINTDIALOG
                OBJJV.BILLNO = Val(ROW("SRNO"))
                OBJJV.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJJV.strsearch = "{JOURNALMASTER.JOURNAL_NO} = " & Val(ROW("SRNO")) & " And {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' AND {JOURNALMASTER.JOURNAL_YEARID} = " & YearId
                OBJJV.Show()
                OBJJV.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\JV_" & Val(ROW("SRNO")) & ".pdf")
                FILENAME.Add("JV_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Journal"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class