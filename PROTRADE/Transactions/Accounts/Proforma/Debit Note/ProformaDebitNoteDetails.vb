
Imports BL

Public Class ProformaDebitNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" PROFORMADEBITNOTEMASTER.DN_no AS SRNO, PROFORMADEBITNOTEMASTER.DN_date AS DATE, PROFORMADEBITNOTEMASTER.DN_BILLNO AS BILLNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, CREDITLEDGERS.Acc_cmpname AS CREDITNAME, PROFORMADEBITNOTEMASTER.DN_GTOTAL AS AMT, PROFORMADEBITNOTEMASTER.DN_remarks AS REMARKS, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNITEMDESC, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE,ISNULL(PROFORMADEBITNOTEMASTER.DN_SALEREFNO, 0) AS SALEREFNO, ISNULL(PROFORMADEBITNOTEMASTER.DN_TOTALAMT, 0) AS BILLAMT, ISNULL(PROFORMADEBITNOTEMASTER.DN_CHARGES, 0) AS CHGS, ISNULL(PROFORMADEBITNOTEMASTER.DN_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(PROFORMADEBITNOTEMASTER.DN_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PROFORMADEBITNOTEMASTER.DN_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PROFORMADEBITNOTEMASTER.DN_TOTALIGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(PROFORMADEBITNOTEMASTER.DN_ROUNDOFF, 0) AS ROUNDOFF,  ISNULL(PROFORMADEBITNOTEMASTER.DN_PARTYBILLNO, '') AS PARTYBILLNO,  ISNULL(PROFORMADEBITNOTEMASTER.DN_PARTYBILLDATE, '') AS PARTYBILLDATE,ISNULL(PROFORMADEBITNOTEMASTER.DN_GSTR1, 0) AS GSTR1", "", "  PROFORMADEBITNOTEMASTER INNER JOIN REGISTERMASTER ON PROFORMADEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON  PROFORMADEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN  LEDGERS AS AGENTLEDGERS ON PROFORMADEBITNOTEMASTER.DN_AGENTID = AGENTLEDGERS.Acc_id INNER JOIN LEDGERS AS CREDITLEDGERS ON  PROFORMADEBITNOTEMASTER.DN_CREDITLEDGERID = CREDITLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON PROFORMADEBITNOTEMASTER.DN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", tempcondition & " AND DN_YEARID = " & YearId & " order by dbo.PROFORMADEBITNOTEMASTER.DN_NO")
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridDN.FocusedRowHandle = gridDN.RowCount - 1
                gridDN.TopRowIndex = gridDN.RowCount - 15
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
            If (editval = False) Or (editval = True And gridDN.RowCount > 0) Then
                Dim objDN As New ProformaDebitNote
                objDN.MdiParent = MDIMain
                objDN.edit = editval
                objDN.TEMPDNNO = billno
                objDN.TEMPREGNAME = cmbregister.Text.Trim
                objDN.Show()
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDN.DoubleClick
        Try
            showform(True, gridDN.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    JVREGID = dt.Rows(0).Item(0)
                    fillgrid(" and REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProformaDebitNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProformaDebitNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridDN.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Debit Note Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Debit Note Register"
            gridDN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Debit Note Register", gridDN.VisibleColumns.Count + gridDN.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Debit Note Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DebitNoteDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub

    'Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    'End Sub

    'Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridDN.SelectedRowsCount = 0 Then Exit Sub
    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Debit Note Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                If MsgBox("Wish to Mail Debit Note from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '                SERVERPROPDIRECT(True)
    '            End If
    '        Else
    '            If MsgBox("Wish to Mail Selected Debit Note ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPSELECTED(True)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridDN.SelectedRowsCount = 0 Then Exit Sub


    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Debit Note Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If
    '            If MsgBox("Wish to Print Debit Note from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPDIRECT()
    '            End If
    '        Else
    '            If MsgBox("Wish to Print Selected Debit Note ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPSELECTED()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
    '    Try
    '        Dim ALATTACHMENT As New ArrayList
    '        If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
    '        For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
    '            Dim OBJDN As New CrDrNoteDesign
    '            OBJDN.MdiParent = MDIMain
    '            OBJDN.DIRECTPRINT = True
    '            OBJDN.FRMSTRING = "PROFORMADEBIT"
    '            OBJDN.DIRECTMAIL = INVOICEMAIL
    '            OBJDN.REGNAME = cmbregister.Text.Trim
    '            OBJDN.PRINTSETTING = PrintDialog
    '            OBJDN.BILLNO = Val(I)
    '            OBJDN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJDN.Show()
    '            OBJDN.Close()
    '            ALATTACHMENT.Add(Application.StartupPath & "\DN_" & I & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "Debit Note"
    '            OBJMAIL.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
    '    Try

    '        Dim ALATTACHMENT As New ArrayList

    '        If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
    '        Dim SELECTEDROWS As Int32() = gridDN.GetSelectedRows()
    '        For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
    '            Dim ROW As DataRow = gridDN.GetDataRow(SELECTEDROWS(I))

    '            Dim OBJDN As New CrDrNoteDesign
    '            OBJDN.MdiParent = MDIMain
    '            OBJDN.DIRECTPRINT = True
    '            OBJDN.FRMSTRING = "PROFORMADEBIT"
    '            OBJDN.DIRECTMAIL = INVOICEMAIL
    '            OBJDN.REGNAME = cmbregister.Text.Trim
    '            OBJDN.PRINTSETTING = PrintDialog
    '            OBJDN.BILLNO = Val(ROW("SRNO"))
    '            OBJDN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJDN.Show()
    '            OBJDN.Close()
    '            ALATTACHMENT.Add(Application.StartupPath & "\DN_" & Val(ROW("SRNO")) & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "Debit Note"
    '            OBJMAIL.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class