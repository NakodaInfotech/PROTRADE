Imports BL

Public Class PurchaseReturnDetails
    Public EDIT As Boolean
    Dim TEMPPRNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PURCHASERETURNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PURCHASERETURNDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  PURCHASERETURN.PR_no AS SRNO, PURCHASERETURN.PR_date AS DATE, LEDGERS.Acc_cmpname AS NAME,ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(PURCHASERETURN.PR_BILLNO, '') AS BILLNO, PURCHASERETURN.PR_BILLDATE AS BILLDATE, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS REGNAME, ISNULL(PURCHASERETURN.PR_PARTYBILL, '') AS PARTYBILL, PURCHASERETURN.PR_PARTYDATE AS PARTYDATE, ISNULL(PURCHASERETURN.PR_EWAYBILLNO, '') AS EWAYBILLNO,PURCHASERETURN.PR_TOTALPCS AS TOTALPCS, PURCHASERETURN.PR_TOTALMTRS AS TOTALMTRS, ISNULL(PURCHASERETURN.PR_remarks, '') AS REMARKS,ISNULL(PURCHASERETURN.PR_BILLAMT, 0) AS BILLAMT ,ISNULL(PURCHASERETURN.PR_TOTALCGSTAMT, 0) AS CGSTAMT, ISNULL(PURCHASERETURN.PR_TOTALSGSTAMT, 0) AS SGSTAMT, ISNULL(PURCHASERETURN.PR_SGSTPER, 0) AS SGSTPER, ISNULL(PURCHASERETURN.PR_CGSTPER, 0) AS CGSTPER, ISNULL(PURCHASERETURN.PR_IGSTPER, 0) AS IGSTPER, ISNULL(PURCHASERETURN.PR_TOTALIGSTAMT, 0) AS IGSTAMT, ISNULL(PURCHASERETURN.PR_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(PURCHASERETURN.PR_GRANDTOTAL, 0) AS GRANDTOTAL,ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, ISNULL(PR_PARTYREFNO,'') AS PARTYREFNO, ISNULL(CREDITLEDGERS.Acc_cmpname, '') AS CREDITNAME", "", "  PURCHASERETURN INNER JOIN LEDGERS ON PURCHASERETURN.PR_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASERETURN.PR_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN REGISTERMASTER ON PURCHASERETURN.PR_PURREGID = REGISTERMASTER.REGISTER_ID LEFT OUTER JOIN LEDGERS AS CREDITLEDGERS ON PURCHASERETURN.PR_CREDITLEDGERID = CREDITLEDGERS.Acc_id", " AND PURCHASERETURN.PR_YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SRNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PurchaseReturn
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPPRNO = SRNO
                objREQ.Show()
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Entry Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Entries from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Entries ?", MsgBoxStyle.YesNo) = vbYes Then
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

            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJPURRET As New PurchaseInvoiceDesign
                OBJPURRET.MdiParent = MDIMain
                OBJPURRET.DIRECTPRINT = True
                OBJPURRET.FRMSTRING = "PURRETURN"
                OBJPURRET.DIRECTMAIL = INVOICEMAIL
                OBJPURRET.DIRECTWHATSAPP = WHATSAPP
                OBJPURRET.PRINTSETTING = PRINTDIALOG
                OBJPURRET.PURRETNO = Val(I)
                OBJPURRET.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPURRET.Show()
                OBJPURRET.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PURRET_" & I & ".pdf")
                FILENAME.Add("PURRET_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Purchase Return/Debit Note"
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

            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJPURRET As New PurchaseInvoiceDesign
                OBJPURRET.MdiParent = MDIMain
                OBJPURRET.DIRECTPRINT = True
                OBJPURRET.FRMSTRING = "PURRETURN"
                OBJPURRET.DIRECTMAIL = INVOICEMAIL
                OBJPURRET.DIRECTWHATSAPP = WHATSAPP
                OBJPURRET.PRINTSETTING = PRINTDIALOG
                OBJPURRET.PURRETNO = Val(ROW("SRNO"))
                OBJPURRET.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPURRET.Show()
                OBJPURRET.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PURRET_" & Val(ROW("SRNO")) & ".pdf")
                FILENAME.Add("PURRET_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Purchase Return/Debit Note"
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

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Entry Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Mail Entries from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Entries ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Debit Note Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp Entries from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected Entries ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Purchase Return Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class