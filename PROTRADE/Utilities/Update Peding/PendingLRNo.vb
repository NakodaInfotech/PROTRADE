
Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class PendingLRNo

    Private Sub PendingReturnDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingReturnDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = ""
            If RBPENDING.Checked = True Then
                WHERECLAUSE = " AND ISNULL(INVOICEMASTER.INVOICE_LRNO,'') = '' "
                gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 0
                gridbill.OptionsSelection.MultiSelect = False
                gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
            Else
                WHERECLAUSE = " AND ISNULL(INVOICEMASTER.INVOICE_LRNO,'') <> ''"
                gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
                gridbill.OptionsSelection.MultiSelect = True
                gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            End If

            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_REGISTERID AS REGID, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.INVOICE_DATE AS DATE,  ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, INVOICEMASTER.INVOICE_LRNO AS LRNO, (CASE WHEN INVOICEMASTER.INVOICE_LRNO ='' THEN NULL ELSE INVOICEMASTER.INVOICE_LRDATE END) AS LRDATE, INVOICEMASTER.INVOICE_TOTALPCS AS PCS, INVOICEMASTER.INVOICE_TOTALMTRS AS MTRS, ISNULL(INVOICEMASTER.INVOICE_GDNNO,'') AS CHALLANNO, ISNULL(SHIPTOLEDGERS.ACC_CMPNAME,'') AS SHIPTO, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY, ISNULL(INVOICE_BALENOFROM,0) AS BALENOFROM, ISNULL(INVOICE_EWAYBILLNO,'') AS EWAYBILLNO, ISNULL(REGISTER_NAME,'') AS REGNAME ", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.REGISTER_ID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN LEDGERS AS TRANSLEDGERS ON INVOICEMASTER.INVOICE_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON INVOICEMASTER.INVOICE_PACKINGID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON INVOICE_TOCITYID = CITY_ID", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER.INVOICE_REGISTERID, INVOICEMASTER.INVOICE_NO ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            If ROW Is Nothing Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'If IsDBNull(ROW("RDATE")) = False Then DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_RETURNDATE = '" & Format(ROW("RDATE"), "MM/dd/yyyy") & "' WHERE INVOICE_NO = " & ROW("GRNO") & " AND INVOICE_YEARID = " & YearId, "", "")
            If ROW("LRNO") <> "" And IsDBNull(ROW("LRDATE")) = False Then
                DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_LRDATE = '" & Format(ROW("LRDATE"), "MM/dd/yyyy") & "', INVOICE_LRNO = '" & ROW("LRNO") & "' WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")

                'SEND INVOIC TO PARTY DIRECTLY MAIL
                If ClientName = "AVIS" Then SENDDIRECTMAIL(ROW("NAME"), Val(ROW("INVOICENO")), ROW("REGNAME"))
            End If



            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDDIRECTMAIL(PARTYNAME As String, INVOICENO As Integer, REGISTER As String)
        Try
            'CHECK WHETHER EMAILID IS PRESENT IN LEDGER OR NOT, IF NOT THEN EXIT SUB WITH MESSAGE
            Dim OBJCMN As New ClsCommon
            Dim DTEMAIL As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", "AND ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID = " & YearId)
            If DTEMAIL.Rows.Count > 0 AndAlso DTEMAIL.Rows(0).Item("EMAILID") <> "" Then

                Dim ALATTACHMENT As New ArrayList
                Dim OBJINVOICE As New saledesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = True
                Dim DT As DataTable = OBJCMN.search("ISNULL(STATE_REMARK,'') AS STATECODE", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", " AND INVOICEMASTER.INVOICE_NO = " & Val(INVOICENO) & " AND REGISTER_NAME = '" & REGISTER & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("STATECODE") <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                OBJINVOICE.registername = REGISTER
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.INVNO = Val(INVOICENO)
                OBJINVOICE.NOOFCOPIES = 1
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(INVOICENO) & ".pdf")

                sendemail(DTEMAIL.Rows(0).Item("EMAILID"), ALATTACHMENT(0), "", "Invoice", ALATTACHMENT, ALATTACHMENT.Count, "", "", "", "", "")
                MsgBox("Mail Sent")
            Else
                MsgBox("Add E-Mail id in Ledger")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "LRDATE")) = False Then
                If gridbill.GetRowCellValue(e.RowHandle, "LRDATE") < Convert.ToDateTime(gridbill.GetRowCellValue(e.RowHandle, "DATE")).Date Then
                    e.Valid = False
                    gridbill.SetColumnError(GLRDATE, "Date must be After Invoice Date")
                    Exit Sub
                End If
            End If
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "LRDATE")) = False And IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "LRNO")) = False Then If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If IsDBNull(ROW("LRNO")) = True Then
                MsgBox("No Row To Delete")
                Exit Sub
            End If

            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_LRDATE = '', INVOICE_LRNO = '' WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSMS_Click(sender As Object, e As EventArgs) Handles CMDSMS.Click
        Try
            If RBENTERED.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    SMSCODE(SELECTEDROWS(I))
                Next
                MsgBox("Message Sent")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SMSCODE(ROWNO As Integer)
        If ALLOWSMS = True Then
            Dim ROW As DataRow = gridbill.GetDataRow(ROWNO)

            If ClientName <> "KOTHARI" And ROW("MOBILENO") = "" Then Exit Sub
            If ClientName = "KOTHARI" And ROW("SHIPTO") = "" Then Exit Sub

            If ClientName = "NVAHAN" And ROW("LRNO") = "" Then
                If MsgBox("LR No not entered, Wish to send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If

            Dim MSG As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim DTINV As DataTable = OBJCMN.search("ITEM_NAME AS ITEMNAME, INVOICE_BALENO AS GRIDBALENO, INVOICE_PCS AS PCS, INVOICE_MTRS AS MTRS", "", "INVOICEMASTER_DESC INNER JOIN ITEMMASTER ON INVOICE_ITEMID = ITEM_ID", " AND INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId)

            If ClientName = "KOTHARI" Then
                MSG = MSG & ROW("SHIPTO") & " - " & ROW("CITY") & "\n"
                MSG = MSG & "GOODS DISPATCHED" & "\n"
                MSG = MSG & "BALE NO." & Val(ROW("INVOICENO")) & " X " & ROW("BALENOFROM") & "\n"
                MSG = MSG & "L.R.NO" & ROW("LRNO") & " DT. " & ROW("LRDATE") & "\n"
                MSG = MSG & ROW("EWAYBILLNO")

            ElseIf ClientName = "KCRAYON" Then
                MSG = "INV NO " & Val(ROW("INVOICENO")) & "\n"
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "\n"
                For Each INVROW As DataRow In DT.Rows
                    MSG = MSG & INVROW("ITEMNAME") & "-" & Format(Val(INVROW("MTRS")), "0.00") & "\n"
                Next
                MSG = MSG & "THANK YOU"

            ElseIf ClientName = "NVAHAN" Then
                MSG = "GOODS DESP" & vbCrLf
                MSG = MSG & "INV-" & Val(ROW("INVOICENO")) & vbCrLf
                MSG = MSG & "LRNO-" & ROW("LRNO") & vbCrLf
                MSG = MSG & "DT-" & ROW("LRDATE") & vbCrLf
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & "TRANS-" & DT.Rows(0).Item("TRANSCODE") & vbCrLf
                For Each INVROW As DataRow In DT.Rows
                    MSG = MSG & "ITEM-" & INVROW("ITEMNAME") & vbCrLf & "PCS-" & Val(INVROW("PCS")) & vbCrLf & "MTRS-" & Val(INVROW("MTRS")) & vbCrLf & "BALE-" & INVROW("GRIDBALENO")
                Next

            ElseIf ClientName = "YASHVI" Then
                MSG = ROW("NAME") & "\n"
                MSG = MSG & "BALENO-" & ROW("CHALLANNO") & "\n"
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & DT.Rows(0).Item("TRANSCODE") & "\n"
                MSG = MSG & "LRNO-" & ROW("LRNO") & "\n"
                MSG = MSG & "DT-" & ROW("LRDATE") & "\n"
                MSG = MSG & "QTY-" & Val(ROW("MTRS")) & "\n"
                MSG = MSG & CmpName

            ElseIf ClientName = "SANGHVI" Then
                MSG = "INV NO" & Val(ROW("INVOICENO")) & "\n"
                MSG = MSG & "DT-" & ROW("DATE") & "\n"
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT NAME-" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "\n"
                MSG = MSG & "LRDT-" & ROW("LRDATE") & "\n"
                MSG = MSG & " & BUNDLES-" & ROW("BALENOFROM") & "\n"
                'For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                '    MSG = MSG & ROW.Cells(GITEMNAME.Index).Value & "-" & Format(Val(ROW.Cells(Gmtrs.Index).Value), "0.00") & "\n"
                'Next
                MSG = MSG & "THANK YOU"
            Else
                MSG = "SALE NO " & Val(ROW("INVOICENO")) & "\n"
                DT = OBJCMN.search("ACC_CODE AS TRANSCODE", "", "LEDGERS", " AND ACC_CMPNAME = '" & ROW("TRANSNAME") & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then MSG = MSG & "TRANSPORT -" & DT.Rows(0).Item("TRANSCODE") & " & LRNO-" & ROW("LRNO") & "(" & ROW("LRDATE").Trim & ")" & "\n"
                For Each INVROW As DataRow In DT.Rows
                    MSG = MSG & INVROW("ITEMNAME") & "-" & Format(Val(INVROW("MTRS")), "0.00") & "\n"
                Next
                MSG = MSG & ROW("BALENOFROM") & "\n"
                MSG = MSG & "THANK YOU"
            End If

            If SENDMSG(MSG, ROW("MOBILENO")) = "1701" Then
                DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_SMSSEND = 1 WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")
            Else
                MsgBox("Error Sending Message")
                Exit Sub
            End If
        End If
    End Sub
End Class