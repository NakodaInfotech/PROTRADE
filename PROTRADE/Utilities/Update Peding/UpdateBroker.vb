
Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class UpdateBroker

    Private Sub UpdateBroker_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateBroker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cmbtype.SelectedIndex = 0
            FILLAGENT()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAGENT()
        Try
            CMBAGENTNAME.Items.Clear()
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID  ", " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'AGENT' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    CMBAGENTNAME.Items.Add(DTROW("NAME"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim WHERECLAUSE As String = ""
            If RBPENDING.Checked = True Then WHERECLAUSE = " AND ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') = '' " Else WHERECLAUSE = " AND ISNULL(AGENTLEDGERS.ACC_CMPNAME,'') <> ''"
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As New DataTable
            If cmbtype.Text.Trim = "SALE" Then
                GINVOICENO.Caption = "Invoice No"
                GDATE.Caption = "Invoice Date"
                GLRNO.Caption = "LR No"
                GLRDATE.Caption = "LR Date"
                dt = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_REGISTERID AS REGID, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.INVOICE_DATE AS DATE, INVOICEMASTER.INVOICE_LRNO AS LRNO, (CASE WHEN INVOICEMASTER.INVOICE_LRNO ='' THEN NULL ELSE INVOICEMASTER.INVOICE_LRDATE END) AS LRDATE, INVOICEMASTER.INVOICE_TOTALPCS AS PCS, INVOICEMASTER.INVOICE_TOTALMTRS AS MTRS,  ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER.INVOICE_REGISTERID, INVOICEMASTER.INVOICE_NO ")

            ElseIf cmbtype.Text.Trim = "SALE RETURN" Then
                GINVOICENO.Caption = "Return No"
                GDATE.Caption = "Return Date"
                GLRNO.Caption = "LR No"
                GLRDATE.Caption = "LR Date"
                dt = OBJCMN.search(" SALERETURN.SALRET_NO AS INVOICENO, 0 AS REGID, LEDGERS.Acc_cmpname AS NAME, SALERETURN.SALRET_DATE AS DATE, SALERETURN.SALRET_LRNO AS LRNO, (CASE WHEN SALERETURN.SALRET_LRNO ='' THEN NULL ELSE SALERETURN.SALRET_LRDATE END) AS LRDATE, SALERETURN.SALRET_TOTALQTY AS PCS, SALERETURN.SALRET_TOTALMTRS AS MTRS,  ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME ", "", " SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON SALERETURN.SALRET_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " AND SALERETURN.SALRET_YEARID = " & YearId & " ORDER BY SALERETURN.SALRET_NO ")

            ElseIf cmbtype.Text.Trim = "PURCHASE" Then
                GINVOICENO.Caption = "Entry No"
                GDATE.Caption = "Entry Date"
                GLRNO.Caption = "Party Bill No"
                GLRDATE.Caption = "Bill Date"
                dt = OBJCMN.search(" PURCHASEMASTER.BILL_NO AS INVOICENO, PURCHASEMASTER.BILL_REGISTERID AS REGID, LEDGERS.Acc_cmpname AS NAME, PURCHASEMASTER.BILL_DATE AS DATE, PURCHASEMASTER.BILL_PARTYBILLNO AS LRNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS LRDATE, PURCHASEMASTER.BILL_TOTALQTY AS PCS, PURCHASEMASTER.BILL_TOTALMTRS AS MTRS,  ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " AND PURCHASEMASTER.BILL_YEARID = " & YearId & " ORDER BY PURCHASEMASTER.BILL_REGISTERID, PURCHASEMASTER.BILL_NO ")
            End If
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
            If ROW("AGENTNAME") <> "" Then
                Dim TEMPNAMEID As Integer = 0
                DT = OBJCMN.search(" ACC_ID AS NAMEID", "", " LEDGERS ", " AND ACC_CMPNAME = '" & ROW("AGENTNAME") & "' AND ACC_YEARID = " & YearId)
                TEMPNAMEID = DT.Rows(0).Item(0)
                If cmbtype.Text.Trim = "SALE" Then
                    DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_AGENTID = " & Val(TEMPNAMEID) & " WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")
                ElseIf cmbtype.Text.Trim = "SALE RETURN" Then
                    DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_AGENTID = " & Val(TEMPNAMEID) & " WHERE SALRET_NO = " & Val(ROW("INVOICENO")) & " AND SALRET_YEARID = " & YearId, "", "")
                ElseIf cmbtype.Text.Trim = "PURCHASE" Then
                    DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_AGENTID = " & Val(TEMPNAMEID) & " WHERE BILL_NO = " & Val(ROW("INVOICENO")) & " AND BILL_REGISTERID = " & Val(ROW("REGID")) & " AND BILL_YEARID = " & YearId, "", "")
                End If

            End If

            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "AGENTNAME")) = False Then If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If IsDBNull(ROW("AGENTNAME")) = True Then
                MsgBox("No Row To Delete")
                Exit Sub
            End If

            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If cmbtype.Text.Trim = "SALE" Then
                DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_AGENTID =0  WHERE INVOICE_NO = " & Val(ROW("INVOICENO")) & " AND INVOICE_REGISTERID = " & Val(ROW("REGID")) & " AND INVOICE_YEARID = " & YearId, "", "")
            ElseIf cmbtype.Text.Trim = "SALE RETURN" Then
                DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_AGENTID =0  WHERE SALRET_NO = " & Val(ROW("INVOICENO")) & " AND SALRET_YEARID = " & YearId, "", "")
            ElseIf cmbtype.Text.Trim = "PURCHASE" Then
                DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_AGENTID =0  WHERE BILL_NO = " & Val(ROW("INVOICENO")) & " AND BILL_REGISTERID = " & Val(ROW("REGID")) & " AND BILL_YEARID = " & YearId, "", "")
            End If
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class