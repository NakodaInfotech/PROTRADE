
Imports BL

Public Class TaxFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaxFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RDTAX.Checked = True Then

                Dim WHERECLAUSE As String = " WHERE 1=1 "
                If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND T.REGNAME = '" & CMBREGISTER.Text.Trim & "'"

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Tax Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then

                        OBJRPT.TAXREPORT_EXCEL(WHERECLAUSE & " AND T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy"), CmpId, YearId)
                    Else
                        OBJRPT.TAXREPORT_EXCEL(WHERECLAUSE & " AND T.DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy"), CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Tax Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.TAXREPORT_EXCEL(WHERECLAUSE & " AND T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy"), CmpId, YearId)
                    Else
                        OBJRPT.TAXREPORT_EXCEL(WHERECLAUSE & " AND T.DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "' AND T.YEARID = " & YearId, Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy"), CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Tax Summary.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBJ1.Checked = True Then
                Dim WHERECLAUSE As String = ""
                If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "'"

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("J1 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J1REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J1REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("J1 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J1REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J1REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "J1 Annexure.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBJ2.Checked = True Then
                Dim WHERECLAUSE As String = ""
                If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "'"

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("J2 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J2REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J2REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("J2 Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J2REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J2REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "J2 Annexure.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBG.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Annexure G", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure G.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GREPORT_EXCEL(" AND RECDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND RECDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.GREPORT_EXCEL(" AND RECDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND RECDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Annexure G", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure G.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GREPORT_EXCEL(" AND RECDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND RECDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.GREPORT_EXCEL(" AND RECDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND RECDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Annexure G.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBI.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Annexure I", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure I.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.IREPORT_EXCEL(" AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.IREPORT_EXCEL(" AND DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Annexure I", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure I.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.IREPORT_EXCEL(" AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.IREPORT_EXCEL(" AND  DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Annexure I.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBJ6.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Annexure J (Section - 6)", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure J (Section - 6).xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J6REPORT_EXCEL(" AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J6REPORT_EXCEL(" AND DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Annexure J (Section - 6)", System.AppDomain.CurrentDomain.BaseDirectory & "Annexure J (Section - 6).xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.J6REPORT_EXCEL(" AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.J6REPORT_EXCEL(" AND  DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Annexure J (Section - 6).xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RB231SALES.Checked = True Then
                Dim WHERECLAUSE As String = ""
                If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "'"

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Sales (231) Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "Sales (231) Annexure.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.SALES231REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.SALES231REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Sales (231) Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "Sales (231) Annexure.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.SALES231REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.SALES231REPORT_EXCEL(WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Sales (231) Annexure.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RB231PURCHASE.Checked = True Then
                Dim WHERECLAUSE As String = ""
                If CMBREGISTER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "'"

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("Purchase (231) Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "Purchase (231) Annexure.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.PURCHASE231REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.PURCHASE231REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("Purchase (231) Annexure", System.AppDomain.CurrentDomain.BaseDirectory & "Purchase (231) Annexure.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.PURCHASE231REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'", dtfrom.Value.Date, dtto.Value.Date, CmpId, YearId)
                    Else
                        OBJRPT.PURCHASE231REPORT_EXCEL(WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'", AccFrom.Date, AccTo.Date, CmpId, YearId)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "Purchase (231) Annexure.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaxFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillregister(CMBREGISTER, " AND (REGISTER_TYPE ='SALE' OR REGISTER_TYPE = 'PURCHASE')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class