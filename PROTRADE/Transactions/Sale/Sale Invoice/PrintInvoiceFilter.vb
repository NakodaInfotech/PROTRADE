
Imports BL

Public Class PrintInvoiceFilter

    Public INVOICENO As Integer
    Public PARTYNAME As String
    Public AGENTNAME As String
    Public REGISTERNAME As String
    Public TEMPSTATECODE As String
    Public BLANKPAPER As Boolean = False
    Public PARTYCHANGEADD As String = ""

    Dim INVOICEMAIL As Boolean = False

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            If CHKCUSTOMER.CheckState = CheckState.Unchecked AndAlso CHKTRANSPORT.CheckState = CheckState.Unchecked AndAlso CHKOFFICE.CheckState = CheckState.Unchecked AndAlso CHKDUPLICATE.CheckState = CheckState.Unchecked Then
                MsgBox("SELECT PROPER COPIES....", MsgBoxStyle.Critical)
                Exit Sub
            End If



            If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub
            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Proper Invoice Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTCOPIES.Text.Trim) = 0 Then
                MsgBox("Enter Proper No Of Copies", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTFROM.Text.Trim) = Val(TXTTO.Text.Trim) Then

                'SHOW SINGLE INVOICE

                If CHKCUSTOMER.CheckState = CheckState.Checked Or (ClientName = "GELATO" And CHKTRANSPORT.CheckState = CheckState.Checked) Then
                    Dim OBJINVOICE As New saledesign
                    OBJINVOICE.FRMSTRING = "INVOICE"
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.PARTYCHANGEADD = PARTYCHANGEADD
                    OBJINVOICE.IGSTFORMAT = False
                    OBJINVOICE.INVOICECOPYNAME = CHKCUSTOMER.Text

                    If ClientName = "GELATO" And CHKTRANSPORT.CheckState = CheckState.Checked Then OBJINVOICE.INVOICECOPYNAME = CHKTRANSPORT.Text

                    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.strsearch = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGISTERNAME & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.PARTYNAME = PARTYNAME
                    OBJINVOICE.AGENTNAME = AGENTNAME
                    OBJINVOICE.Show()
                End If


                If CHKDUPLICATE.CheckState = CheckState.Checked Then
                    Dim OBJINVOICE As New saledesign
                    OBJINVOICE.FRMSTRING = "INVOICE"
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.PARTYCHANGEADD = PARTYCHANGEADD
                    OBJINVOICE.IGSTFORMAT = False
                    OBJINVOICE.INVOICECOPYNAME = CHKDUPLICATE.Text
                    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.strsearch = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGISTERNAME & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.PARTYNAME = PARTYNAME
                    OBJINVOICE.AGENTNAME = AGENTNAME
                    OBJINVOICE.Show()
                End If

                If CHKOFFICE.CheckState = CheckState.Checked Then
                    Dim OBJINVOICE As New saledesign
                    OBJINVOICE.FRMSTRING = "INVOICE"
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.PARTYCHANGEADD = PARTYCHANGEADD
                    OBJINVOICE.IGSTFORMAT = False
                    OBJINVOICE.INVOICECOPYNAME = CHKOFFICE.Text
                    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.strsearch = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGISTERNAME & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.PARTYNAME = PARTYNAME
                    OBJINVOICE.AGENTNAME = AGENTNAME
                    OBJINVOICE.Show()
                End If

                If CHKTRANSPORT.CheckState = CheckState.Checked And ClientName <> "GELATO" Then
                    Dim OBJINVOICE As New saledesign
                    OBJINVOICE.FRMSTRING = "INVOICE"
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.PARTYCHANGEADD = PARTYCHANGEADD
                    OBJINVOICE.IGSTFORMAT = False
                    OBJINVOICE.INVOICETRANS = True
                    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.strsearch = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGISTERNAME & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.PARTYNAME = PARTYNAME
                    OBJINVOICE.AGENTNAME = AGENTNAME
                    OBJINVOICE.Show()
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(INVOICENO) & " AND INVOICE_YEARID = " & YearId, "", "")

            Else

                'PRINT DIRECTLY
                If INVOICEMAIL = False Then
                    If MsgBox("Print Invoice Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
                End If


                Dim ALATTACHMENT As New ArrayList
                For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                    Dim OBJINVOICE As New saledesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.DIRECTPRINT = True
                    OBJINVOICE.FRMSTRING = "INVOICE"
                    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    OBJINVOICE.PARTYCHANGEADD = PARTYCHANGEADD
                    If CHKTRANSPORT.Checked = True Then OBJINVOICE.INVOICETRANS = True
                    If CHKCUSTOMER.CheckState = CheckState.Checked Then
                        OBJINVOICE.INVOICECOPYNAME = CHKCUSTOMER.Text
                    End If
                    If CHKDUPLICATE.CheckState = CheckState.Checked Then
                        OBJINVOICE.INVOICECOPYNAME = CHKDUPLICATE.Text
                    End If
                    If CHKOFFICE.CheckState = CheckState.Checked Then
                        OBJINVOICE.INVOICECOPYNAME = CHKOFFICE.Text
                    End If

                    OBJINVOICE.registername = REGISTERNAME
                    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    'OBJINVOICE.INVOICECOPYNAME = CMBCOPY.Text.Trim
                    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    OBJINVOICE.INVNO = Val(I)
                    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    OBJINVOICE.PARTYNAME = PARTYNAME
                    OBJINVOICE.Show()
                    OBJINVOICE.Close()
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")




                    'If CHKCUSTOMER.CheckState = CheckState.Checked Then
                    '    Dim OBJINVOICE As New saledesign
                    '    OBJINVOICE.MdiParent = MDIMain
                    '    OBJINVOICE.DIRECTPRINT = True
                    '    OBJINVOICE.FRMSTRING = "INVOICE"
                    '    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    '    'If CHKTRANSPORT.Checked = True Then OBJINVOICE.INVOICETRANS = True
                    '    'If CHKCUSTOMER.CheckState = CheckState.Checked Then
                    '    OBJINVOICE.INVOICECOPYNAME = CHKCUSTOMER.Text
                    '    OBJINVOICE.registername = REGISTERNAME
                    '    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    '    'OBJINVOICE.INVOICECOPYNAME = CMBCOPY.Text.Trim
                    '    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    '    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    '    OBJINVOICE.INVNO = Val(I)
                    '    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    '    OBJINVOICE.PARTYNAME = PARTYNAME
                    '    OBJINVOICE.Show()
                    '    OBJINVOICE.Close()
                    '    'Dim OBJCMN As New ClsCommon
                    '    'Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    '    'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
                    'End If


                    'If CHKDUPLICATE.CheckState = CheckState.Checked Then
                    '    Dim OBJINVOICE As New saledesign
                    '    OBJINVOICE.MdiParent = MDIMain
                    '    OBJINVOICE.DIRECTPRINT = True
                    '    OBJINVOICE.FRMSTRING = "INVOICE"
                    '    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    '    'If CHKTRANSPORT.Checked = True Then OBJINVOICE.INVOICETRANS = True
                    '    'If CHKCUSTOMER.CheckState = CheckState.Checked Then
                    '    OBJINVOICE.INVOICECOPYNAME = CHKDUPLICATE.Text
                    '    OBJINVOICE.registername = REGISTERNAME
                    '    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    '    'OBJINVOICE.INVOICECOPYNAME = CMBCOPY.Text.Trim
                    '    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    '    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    '    OBJINVOICE.INVNO = Val(I)
                    '    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    '    OBJINVOICE.PARTYNAME = PARTYNAME
                    '    OBJINVOICE.Show()
                    '    OBJINVOICE.Close()
                    '    'Dim OBJCMN As New ClsCommon
                    '    'Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    '    'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
                    'End If


                    'If CHKOFFICE.CheckState = CheckState.Checked Then
                    '    Dim OBJINVOICE As New saledesign
                    '    OBJINVOICE.MdiParent = MDIMain
                    '    OBJINVOICE.DIRECTPRINT = True
                    '    OBJINVOICE.FRMSTRING = "INVOICE"
                    '    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    '    'If CHKTRANSPORT.Checked = True Then OBJINVOICE.INVOICETRANS = True
                    '    'If CHKCUSTOMER.CheckState = CheckState.Checked Then
                    '    OBJINVOICE.INVOICECOPYNAME = CHKOFFICE.Text
                    '    OBJINVOICE.registername = REGISTERNAME
                    '    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    '    'OBJINVOICE.INVOICECOPYNAME = CMBCOPY.Text.Trim
                    '    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    '    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    '    OBJINVOICE.INVNO = Val(I)
                    '    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    '    OBJINVOICE.PARTYNAME = PARTYNAME
                    '    OBJINVOICE.Show()
                    '    OBJINVOICE.Close()
                    '    'Dim OBJCMN As New ClsCommon
                    '    'Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    '    'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
                    'End If

                    'If CHKTRANSPORT.CheckState = CheckState.Checked Then
                    '    Dim OBJINVOICE As New saledesign
                    '    OBJINVOICE.MdiParent = MDIMain
                    '    OBJINVOICE.DIRECTPRINT = True
                    '    OBJINVOICE.FRMSTRING = "INVOICE"
                    '    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    '    'If CHKTRANSPORT.Checked = True Then OBJINVOICE.INVOICETRANS = True
                    '    'If CHKCUSTOMER.CheckState = CheckState.Checked Then
                    '    OBJINVOICE.INVOICETRANS = True
                    '    OBJINVOICE.registername = REGISTERNAME
                    '    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    '    'OBJINVOICE.INVOICECOPYNAME = CMBCOPY.Text.Trim
                    '    If TEMPSTATECODE <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                    '    OBJINVOICE.BLANKPAPER = BLANKPAPER
                    '    OBJINVOICE.INVNO = Val(I)
                    '    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    '    OBJINVOICE.PARTYNAME = PARTYNAME
                    '    OBJINVOICE.Show()
                    '    OBJINVOICE.Close()
                    '    'Dim OBJCMN As New ClsCommon
                    '    'Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    '    'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
                    'End If


                    'Dim OBJCMN As New ClsCommon
                    'Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_PRINT = 1 WHERE INVOICE_NO = " & Val(I) & " and INVOICE_YEARID = " & YearId, "", "")
                    'ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")

                Next

                If INVOICEMAIL Then
                    Dim OBJMAIL As New SendMail
                    OBJMAIL.ALATTACHMENT = ALATTACHMENT
                    OBJMAIL.subject = "Invoice"
                    OBJMAIL.ShowDialog()
                    INVOICEMAIL = False
                End If
            End If
            'End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintInvoiceFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TXTFROM.Text = INVOICENO
            TXTTO.Text = INVOICENO
            TXTCOPIES.Enabled = 1

            ' CMBCOPY.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEMAIL.Click
        INVOICEMAIL = True
        Call CMDPRINT_Click(sender, e)
    End Sub

    Private Sub PrintInvoiceFilter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "SOFTAS" Then CHKOFFICE.Text = "AGENT COPY"
            If ClientName = "RMANILAL" Or ClientName = "YUMILONE" Or ClientName = "TARUN" Then CHKDUPLICATE.Text = "AGENT COPY"
            If ClientName = "ALENCOT" Then CHKDUPLICATE.Text = "REVISED COPY"
            If ClientName = "GELATO" Then CHKTRANSPORT.Text = "DUPLICATE FOR TRANSPORT"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class