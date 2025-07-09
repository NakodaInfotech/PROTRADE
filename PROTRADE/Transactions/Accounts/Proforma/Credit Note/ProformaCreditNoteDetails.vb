
Imports BL

Public Class ProformaCreditNoteDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim JVREGID As Integer

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" PROFORMACREDITNOTEMASTER.CN_no AS SRNO, PROFORMACREDITNOTEMASTER.CN_date AS DATE, CN_BILLNO AS BILLNO, LEDGERS.Acc_cmpname AS NAME, DEBITLEDGERS.ACC_CMPNAME AS DEBITNAME, PROFORMACREDITNOTEMASTER.CN_GTOTAL AS AMT, PROFORMACREDITNOTEMASTER.CN_REMARKS AS REMARKS", "", "  PROFORMACREDITNOTEMASTER INNER JOIN REGISTERMASTER ON PROFORMACREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON PROFORMACREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id INNER JOIN LEDGERS AS DEBITLEDGERS ON PROFORMACREDITNOTEMASTER.CN_DEBITLEDGERID = DEBITLEDGERS.Acc_id ", tempcondition & " AND CN_YEARID = " & YearId & " order by dbo.PROFORMACREDITNOTEMASTER.CN_NO")
            dt = objclsCMST.search(" PROFORMACREDITNOTEMASTER.CN_no AS SRNO, PROFORMACREDITNOTEMASTER.CN_date AS DATE, PROFORMACREDITNOTEMASTER.CN_BILLNO AS BILLNO, LEDGERS.Acc_cmpname AS NAME,ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, DEBITLEDGERS.Acc_cmpname AS DEBITNAME, PROFORMACREDITNOTEMASTER.CN_GTOTAL AS AMT, PROFORMACREDITNOTEMASTER.CN_remarks AS REMARKS, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNITEMDESC, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(PROFORMACREDITNOTEMASTER.CN_TOTALAMT, 0) AS BILLAMT, ISNULL(PROFORMACREDITNOTEMASTER.CN_CHARGES, 0) AS CHGS, ISNULL(PROFORMACREDITNOTEMASTER.CN_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(PROFORMACREDITNOTEMASTER.CN_CGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PROFORMACREDITNOTEMASTER.CN_SGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PROFORMACREDITNOTEMASTER.CN_IGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(PROFORMACREDITNOTEMASTER.CN_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PROFORMACREDITNOTEMASTER.CN_PARTYREFNO, '') AS PARTYREFNO, ISNULL(PROFORMACREDITNOTEMASTER.CN_RCM, 0) AS RCM,ISNULL(PROFORMACREDITNOTEMASTER.CN_NOGSTR1, 0) AS NOGSTR1, ISNULL(DELIVERYLEDGERS.ACC_CMPNAME,'') AS DELIVERYAT ", "", "   PROFORMACREDITNOTEMASTER INNER JOIN REGISTERMASTER ON PROFORMACREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON PROFORMACREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN  LEDGERS AS AGENTLEDGERS ON PROFORMACREDITNOTEMASTER.CN_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN  LEDGERS AS DELIVERYLEDGERS ON PROFORMACREDITNOTEMASTER.CN_DELIVERYATID = DELIVERYLEDGERS.Acc_id INNER JOIN LEDGERS AS DEBITLEDGERS ON PROFORMACREDITNOTEMASTER.CN_DEBITLEDGERID = DEBITLEDGERS.Acc_id LEFT OUTER JOIN HSNMASTER ON PROFORMACREDITNOTEMASTER.CN_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", tempcondition & " AND CN_YEARID = " & YearId & " order by dbo.PROFORMACREDITNOTEMASTER.CN_NO")

            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridCN.FocusedRowHandle = gridCN.RowCount - 1
                gridCN.TopRowIndex = gridCN.RowCount - 15
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
            If (editval = False) Or (editval = True And gridCN.RowCount > 0) Then
                Dim objCN As New ProformaCreditNote
                objCN.MdiParent = MDIMain
                objCN.edit = editval
                objCN.TEMPCNNO = billno
                objCN.TEMPREGNAME = cmbregister.Text.Trim
                objCN.Show()
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

    Private Sub gridjournal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridCN.DoubleClick
        Try
            showform(True, gridCN.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CREDITNOTE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CREDITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CREDITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
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

    Private Sub CreditNoteDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub CreditNoteDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CREDIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            'fillgrid(" and REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridCN.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Credit Note Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Credit Note Register"
            gridCN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Credit Note Register", gridCN.VisibleColumns.Count + gridCN.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Credit Note Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CreditNoteDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SVS" Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridCN.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Credit Note Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Credit Note from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Credit Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridCN.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Credit Note Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Credit Note from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Credit Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJCN As New CrDrNoteDesign
                OBJCN.MdiParent = MDIMain
                OBJCN.DIRECTPRINT = True
                OBJCN.FRMSTRING = "PROFORMACREDIT"
                OBJCN.DIRECTMAIL = INVOICEMAIL
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.PRINTSETTING = PrintDialog
                OBJCN.BILLNO = Val(I)
                OBJCN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJCN.Show()
                OBJCN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\CN_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Credit Note"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridCN.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridCN.GetDataRow(SELECTEDROWS(I))

                Dim OBJCN As New CrDrNoteDesign
                OBJCN.MdiParent = MDIMain
                OBJCN.DIRECTPRINT = True
                OBJCN.FRMSTRING = "PROFORMACREDIT"
                OBJCN.DIRECTMAIL = INVOICEMAIL
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.PRINTSETTING = PrintDialog
                OBJCN.BILLNO = Val(ROW("SRNO"))
                OBJCN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJCN.Show()
                OBJCN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\CN_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Credit Note"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class