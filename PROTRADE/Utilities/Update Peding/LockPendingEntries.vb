
Imports BL

Public Class LockPendingEntries

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LockPendingEntries_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LockPendingEntries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                dt = objclsCMST.search("*", "", " PENDINGDETAILS ", " AND PENDINGDETAILS.YEARID=" & YearId & " ORDER BY TYPE, NO")
            Else
                dt = objclsCMST.search(" TOP (100) PERCENT NO, INITIALS, DATE, NAME, TRANSNAME, TOTALPCS, TOTALMTRS, TYPE, CMPID, YEARID ", "", "   (SELECT dbo.GDN.GDN_NO AS NO, CAST(dbo.GDN.GDN_NO AS VARCHAR(20)) AS INITIALS, dbo.GDN.GDN_date AS DATE, dbo.LEDGERS.Acc_cmpname AS NAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '')  AS TRANSNAME, dbo.GDN.GDN_TOTALPCS AS TOTALPCS, dbo.GDN.GDN_TOTALMTRS AS TOTALMTRS, 'PENDING CHALLAN' AS TYPE, dbo.GDN.GDN_CMPID AS CMPID,  dbo.GDN.GDN_YEARID AS YEARID FROM dbo.GDN INNER JOIN  dbo.LEDGERS ON dbo.GDN.GDN_ledgerid = dbo.LEDGERS.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS TRANSLEDGERS ON dbo.GDN.GDN_transid = TRANSLEDGERS.Acc_id WHERE (dbo.GDN.GDN_OUTMTRS <> 0) AND GDN.GDN_YEARID = " & YearId & "  UNION ALL SELECT dbo.INVOICEMASTER.INVOICE_NO AS NO, dbo.INVOICEMASTER.INVOICE_INITIALS AS INITIALS, dbo.INVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS_3.Acc_cmpname AS NAME,   ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, dbo.INVOICEMASTER.INVOICE_TOTALPCS AS TOTALPCS, dbo.INVOICEMASTER.INVOICE_TOTALMTRS AS TOTALMTRS,  'PENDING LR' AS TYPE, dbo.INVOICEMASTER.INVOICE_CMPID AS CMPID, dbo.INVOICEMASTER.INVOICE_YEARID AS YEARID FROM dbo.INVOICEMASTER INNER JOIN  dbo.LEDGERS AS LEDGERS_3 ON dbo.INVOICEMASTER.INVOICE_LEDGERID = LEDGERS_3.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS TRANSLEDGERS ON dbo.INVOICEMASTER.INVOICE_TRANSID = TRANSLEDGERS.Acc_id WHERE (dbo.INVOICEMASTER.INVOICE_LRNO <> '') AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " UNION ALL SELECT dbo.PURCHASERETURN.PR_NO AS NO, dbo.PURCHASERETURN.PR_INITIALS AS INITIALS, dbo.PURCHASERETURN.PR_DATE AS DATE, LEDGERS_3.Acc_cmpname AS NAME,   ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, dbo.PURCHASERETURN.PR_TOTALPCS AS TOTALPCS, dbo.PURCHASERETURN.PR_TOTALMTRS AS TOTALMTRS,  'PENDING PURRET LR' AS TYPE, dbo.PURCHASERETURN.PR_CMPID AS CMPID, dbo.PURCHASERETURN.PR_YEARID AS YEARID FROM dbo.PURCHASERETURN INNER JOIN  dbo.LEDGERS AS LEDGERS_3 ON dbo.PURCHASERETURN.PR_LEDGERID = LEDGERS_3.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS TRANSLEDGERS ON dbo.PURCHASERETURN.PR_transledgerid = TRANSLEDGERS.Acc_id WHERE (dbo.PURCHASERETURN.PR_LRNO <> '') AND PURCHASERETURN.PR_YEARID = " & YearId & " UNION ALL SELECT dbo.MATERIALRECEIPT.MATREC_NO AS NO, CAST(dbo.MATERIALRECEIPT.MATREC_NO AS VARCHAR(20)) AS INITIALS, dbo.MATERIALRECEIPT.MATREC_DATE AS DATE,  LEDGERS_2.Acc_cmpname AS NAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, dbo.MATERIALRECEIPT.MATREC_TOTALQTY AS TOTALPCS,  dbo.MATERIALRECEIPT.MATREC_TOTALRECDMTR AS TOTALMTRS, 'PENDING DYEING BILL' AS TYPE, dbo.MATERIALRECEIPT.MATREC_cmpid AS CMPID,  dbo.MATERIALRECEIPT.MATREC_yearid AS YEARID FROM dbo.MATERIALRECEIPT INNER JOIN  dbo.LEDGERS AS LEDGERS_2 ON dbo.MATERIALRECEIPT.MATREC_ledgerid = LEDGERS_2.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS TRANSLEDGERS ON dbo.MATERIALRECEIPT.MATREC_TRANSID = TRANSLEDGERS.Acc_id WHERE (dbo.MATERIALRECEIPT.MATREC_DONE = 'TRUE') AND MATERIALRECEIPT.MATREC_YEARID = " & YearId & "  UNION ALL  SELECT dbo.GRN.grn_no AS NO, CASE WHEN GRN_TYPE = 'Job Work' THEN 'G-' + CAST(grn_no AS VARCHAR(20)) ELSE 'F-' + CAST(grn_no AS VARCHAR(20)) END AS INITIALS, dbo.GRN.grn_date AS DATE,  LEDGERS_1.Acc_cmpname AS NAME, ISNULL(LEDGERS_4.Acc_cmpname, '') AS TRANSNAME, dbo.GRN.GRN_TOTALQTY AS TOTALPCS, dbo.GRN.GRN_TOTALMTRS AS TOTALMTRS,  'PENDING PURCHASE BILL' AS TYPE, dbo.GRN.grn_cmpid AS CMPID, dbo.GRN.grn_yearid AS YEARID  FROM dbo.GRN INNER JOIN  dbo.LEDGERS AS LEDGERS_1 ON dbo.GRN.grn_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.GRN.grn_transledgerid = LEDGERS_4.Acc_id WHERE (dbo.GRN.GRN_DONE = 'TRUE') AND GRN.GRN_YEARID = " & YearId & " UNION  ALL SELECT dbo.JOBIN.JI_no AS NO, CAST(JI_no AS VARCHAR(20)) AS INITIALS, dbo.JOBIN.JI_date AS DATE,  LEDGERS_1.Acc_cmpname AS NAME, ISNULL(LEDGERS_4.Acc_cmpname, '') AS TRANSNAME, dbo.JOBIN.JI_TOTALQTY AS TOTALPCS, dbo.JOBIN.JI_TOTALMTRS AS TOTALMTRS,  'PENDING JOB BILL' AS TYPE, dbo.JOBIN.JI_cmpid AS CMPID, dbo.JOBIN.JI_yearid AS YEARID  FROM dbo.JOBIN INNER JOIN  dbo.LEDGERS AS LEDGERS_1 ON dbo.JOBIN.JI_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.JOBIN.JI_transledgerid = LEDGERS_4.Acc_id WHERE (dbo.JOBIN.JI_DONE = 'TRUE') AND JOBIN.JI_YEARID = " & YearId & " UNION ALL   SELECT     dbo.YARNRECD.YARN_no AS NO, CAST(YARN_no AS VARCHAR(20)) AS INITIALS, dbo.YARNRECD.YARN_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, ISNULL(LEDGERS_4.Acc_cmpname, '') AS TRANSNAME, dbo.YARNRECD.YARN_TOTALQTY AS TOTALPCS, dbo.YARNRECD.YARN_TOTALWT AS TOTALMTRS, 'PENDING YARN BILL' AS TYPE, dbo.YARNRECD.YARN_cmpid AS CMPID, dbo.YARNRECD.YARN_yearid AS YEARID FROM dbo.YARNRECD INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.YARNRECD.YARN_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.YARNRECD.YARN_transledgerid = LEDGERS_4.Acc_id WHERE (dbo.YARNRECD.YARN_DONE = 'TRUE') AND YARNRECD.YARN_YEARID = " & YearId & " UNION ALL SELECT     dbo.YARNCHALLAN.YARN_no AS NO, CAST(YARN_no AS VARCHAR(20)) AS INITIALS, dbo.YARNCHALLAN.YARN_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, ISNULL(LEDGERS_4.Acc_cmpname, '') AS TRANSNAME, dbo.YARNCHALLAN.YARN_TOTALQTY AS TOTALPCS, dbo.YARNCHALLAN.YARN_TOTALWT AS TOTALMTRS, 'PENDING YARN CHALLAN' AS TYPE, dbo.YARNCHALLAN.YARN_cmpid AS CMPID, dbo.YARNCHALLAN.YARN_yearid AS YEARID FROM dbo.YARNCHALLAN INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.YARNCHALLAN.YARN_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.YARNCHALLAN.YARN_transledgerid = LEDGERS_4.Acc_id WHERE (dbo.YARNCHALLAN.YARN_OUTWT <> 0) AND YARNCHALLAN.YARN_YEARID = " & YearId & " UNION ALL SELECT dbo.SALEGATEPASS.GP_no AS NO, CAST(GP_no AS VARCHAR(20)) AS INITIALS, dbo.SALEGATEPASS.GP_date AS DATE,  LEDGERS_1.Acc_cmpname AS NAME, ISNULL(LEDGERS_4.Acc_cmpname, '') AS TRANSNAME, dbo.SALEGATEPASS.GP_TOTALPCS AS TOTALPCS, dbo.SALEGATEPASS.GP_TOTALMTRS AS TOTALMTRS,  'PENDING GATEPASS' AS TYPE, dbo.SALEGATEPASS.GP_cmpid AS CMPID, dbo.SALEGATEPASS.GP_yearid AS YEARID  FROM dbo.SALEGATEPASS INNER JOIN  dbo.LEDGERS AS LEDGERS_1 ON dbo.SALEGATEPASS.GP_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.SALEGATEPASS.GP_TRANSID= LEDGERS_4.Acc_id WHERE (dbo.SALEGATEPASS.GP_SALEDONE = 'TRUE') AND SALEGATEPASS.GP_YEARID = " & YearId & " UNION ALL SELECT dbo.SALERETURNCHALLAN.SRCH_NO AS NO, CAST(dbo.SALERETURNCHALLAN.SRCH_NO AS VARCHAR(20)) AS INITIALS, dbo.SALERETURNCHALLAN.SRCH_date AS DATE, dbo.LEDGERS.Acc_cmpname AS NAME, '' AS TRANSNAME, dbo.SALERETURNCHALLAN.SRCH_TOTALQTY AS TOTALPCS, dbo.SALERETURNCHALLAN.SRCH_TOTALMTRS AS TOTALMTRS, 'PENDING SALERET' AS TYPE, dbo.SALERETURNCHALLAN.SRCH_CMPID AS CMPID,  dbo.SALERETURNCHALLAN.SRCH_YEARID AS YEARID FROM dbo.SALERETURNCHALLAN INNER JOIN  dbo.LEDGERS ON dbo.SALERETURNCHALLAN.SRCH_ledgerid = dbo.LEDGERS.Acc_id WHERE (dbo.SALERETURNCHALLAN.SRCH_DONE = 'TRUE') AND SALERETURNCHALLAN.SRCH_YEARID = " & YearId & " UNION ALL SELECT dbo.GRN.GRN_no AS NO, CAST(GRN_no AS VARCHAR(20)) AS INITIALS, dbo.GRN.GRN_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, '' AS TRANSNAME, dbo.GRN.GRN_TOTALQTY AS TOTALPCS, dbo.GRN.GRN_TOTALMTRS AS TOTALMTRS, 'PENDING INHOUSECHECK' AS TYPE, dbo.GRN.GRN_cmpid AS CMPID, dbo.GRN.GRN_yearid AS YEARID FROM dbo.GRN INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.GRN.GRN_ledgerid = LEDGERS_1.Acc_id  WHERE (dbo.GRN.GRN_INHOUSECHECKDONE = 0) AND GRN_TYPE = 'FANCY MATERIAL' AND GRN.GRN_YEARID = " & YearId & " UNION ALL SELECT dbo.JOBIN.JI_no AS NO, CAST(JI_no AS VARCHAR(20)) AS INITIALS, dbo.JOBIN.JI_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, '' AS TRANSNAME, dbo.JOBIN.JI_TOTALQTY AS TOTALPCS, dbo.JOBIN.JI_TOTALMTRS AS TOTALMTRS, 'PENDING INHOUSECHECKJOB' AS TYPE, dbo.JOBIN.JI_cmpid AS CMPID, dbo.JOBIN.JI_yearid AS YEARID FROM dbo.JOBIN INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.JOBIN.JI_ledgerid = LEDGERS_1.Acc_id WHERE (dbo.JOBIN.JI_INHOUSECHECKDONE = 0) AND JOBIN.JI_YEARID = " & YearId & " UNION ALL SELECT dbo.MATERIALRECEIPT.MATREC_no AS NO, CAST(MATREC_no AS VARCHAR(20)) AS INITIALS, dbo.MATERIALRECEIPT.MATREC_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, '' AS TRANSNAME, dbo.MATERIALRECEIPT.MATREC_TOTALQTY AS TOTALPCS, dbo.MATERIALRECEIPT.MATREC_TOTALMTRS AS TOTALMTRS, 'PENDING INHOUSECHECKDYEING' AS TYPE, dbo.MATERIALRECEIPT.MATREC_cmpid AS CMPID, dbo.MATERIALRECEIPT.MATREC_yearid AS YEARID FROM dbo.MATERIALRECEIPT INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.MATERIALRECEIPT.MATREC_ledgerid = LEDGERS_1.Acc_id WHERE (dbo.MATERIALRECEIPT.MATREC_INHOUSECHECKDONE = 0) AND MATERIALRECEIPT.MATREC_YEARID = " & YearId & ")  AS T ", " ORDER BY TYPE, DATE, NO")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Lock-Unlock Pending Entries.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Lock-Unlock Pending Entries"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lock-Unlock Pending Entries", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Pending Entries Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                    If DTROW("TYPE") = "PENDING CHALLAN" Then DT = OBJCMN.Execute_Any_String(" UPDATE GDN SET GDN_OUTPCS = GDN_TOTALPCS, GDN_OUTMTRS = GDN_TOTALMTRS WHERE GDN_NO = " & DTROW("NO") & " AND GDN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING LR" Then DT = OBJCMN.Execute_Any_String(" UPDATE INVOICEMASTER SET INVOICE_LRNO = 'LOCKED' WHERE INVOICE_INITIALS = '" & DTROW("INITIALS") & "' AND INVOICE_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING PURRET LR" Then DT = OBJCMN.Execute_Any_String(" UPDATE PURCHASERETURN SET PR_LRNO = 'LOCKED' WHERE PR_INITIALS = '" & DTROW("INITIALS") & "' AND PR_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING DYEING BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT SET MATERIALRECEIPT.MATREC_DONE = 'TRUE' WHERE MATREC_NO = " & DTROW("NO") & " AND MATREC_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING JOB BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN SET JOBIN.JI_DONE = 'TRUE' WHERE JI_NO = " & DTROW("NO") & " AND JI_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING GATEPASS" Then DT = OBJCMN.Execute_Any_String(" UPDATE SALEGATEPASS SET SALEGATEPASS.GP_SALEDONE = 'TRUE' WHERE GP_NO = " & DTROW("NO") & " AND GP_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING SALERET" Then DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURNCHALLAN SET SALERETURNCHALLAN.SRCH_DONE = 'TRUE' WHERE SALERETURNCHALLAN.SRCH_NO = " & DTROW("NO") & " AND SALERETURNCHALLAN.SRCH_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECK" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN.GRN_INHOUSECHECKDONE = 'TRUE' WHERE GRN.GRN_NO = " & DTROW("NO") & " AND GRN.GRN_TYPE = 'FANCY MATERIAL' AND GRN.GRN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECKJOB" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN SET JOBIN.JI_INHOUSECHECKDONE = 'TRUE' WHERE JOBIN.JI_NO = " & DTROW("NO") & " AND JOBIN.JI_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECKDYEING" Then DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT SET MATERIALRECEIPT.MATREC_INHOUSECHECKDONE = 'TRUE' WHERE MATERIALRECEIPT.MATREC_NO = " & DTROW("NO") & " AND MATERIALRECEIPT.MATREC_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING YARN BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE YARNRECD SET YARN_DONE = 'TRUE' WHERE YARN_NO = " & DTROW("NO") & " AND YARN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING YARN CHALLAN" Then DT = OBJCMN.Execute_Any_String(" UPDATE YARNCHALLAN SET YARN_OUTWT = YARN_TOTALWT WHERE YARN_NO = " & DTROW("NO") & " AND YARN_YEARID = " & YearId, "", "")

                    'IF FIRST CHAR OF INITIALS IS F THEN FINISHED ELES JOBWORK
                    If DTROW("TYPE") = "PENDING PURCHASE BILL" Then
                        If DTROW("INITIALS").ToString.Substring(0, 1) = "F" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'TRUE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'FANCY MATERIAL' AND GRN_YEARID = " & YearId, "", "") Else DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'TRUE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'Job Work' AND GRN_YEARID = " & YearId, "", "")
                    End If

                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                    If DTROW("TYPE") = "PENDING CHALLAN" Then DT = OBJCMN.Execute_Any_String(" UPDATE GDN SET GDN_OUTPCS = 0, GDN_OUTMTRS = 0 WHERE GDN_NO = " & DTROW("NO") & " AND GDN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING LR" Then DT = OBJCMN.Execute_Any_String(" UPDATE INVOICEMASTER SET INVOICE_LRNO = '' WHERE INVOICE_INITIALS = '" & DTROW("INITIALS") & "' AND INVOICE_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING PURRET LR" Then DT = OBJCMN.Execute_Any_String(" UPDATE PURCHASERETURN SET PR_LRNO = '' WHERE PR_INITIALS = '" & DTROW("INITIALS") & "' AND PR_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING DYEING BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT SET MATERIALRECEIPT.MATREC_DONE = 'FALSE' WHERE MATREC_NO = " & DTROW("NO") & " AND MATREC_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING JOB BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN SET JOBIN.JI_DONE = 'FALSE' WHERE JI_NO = " & DTROW("NO") & " AND JI_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING GATEPASS" Then DT = OBJCMN.Execute_Any_String(" UPDATE SALEGATEPASS SET SALEGATEPASS.GP_SALEDONE = 'FALSE' WHERE GP_NO = " & DTROW("NO") & " AND GP_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING SALRET" Then DT = OBJCMN.Execute_Any_String(" UPDATE SALERETURNCHALLAN SET SALERETURNCHALLAN.SRCH_SALEDONE = 'FALSE' WHERE SALERETURNCHALLAN.SRCH_NO = " & DTROW("NO") & " AND SALERETURNCHALLAN.SRCH_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECK" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN.GRN_INHOUSECHECKDONE = 'FALSE' WHERE GRN.GRN_NO = " & DTROW("NO") & " AND GRN.GRN_TYPE = 'FANCY MATERIAL' AND GRN.GRN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECKJOB" Then DT = OBJCMN.Execute_Any_String(" UPDATE JOBIN SET JOBIN.JI_INHOUSECHECKDONE = 'FALSE' WHERE JOBIN.JI_NO = " & DTROW("NO") & " AND JOBIN.JI_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING INHOUSECHECKDYEING" Then DT = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT SET MATERIALRECEIPT.MATREC_INHOUSECHECKDONE = 'FALSE' WHERE MATERIALRECEIPT.MATREC_NO = " & DTROW("NO") & " AND MATERIALRECEIPT.MATREC_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING YARN BILL" Then DT = OBJCMN.Execute_Any_String(" UPDATE YARNRECD SET YARN_DONE = 'FALSE' WHERE YARN_NO = " & DTROW("NO") & " AND YARN_YEARID = " & YearId, "", "")
                    If DTROW("TYPE") = "PENDING YARN CHALLAN" Then DT = OBJCMN.Execute_Any_String(" UPDATE YARNCHALLAN SET YARN_OUTWT = 0 WHERE YARN_NO = " & DTROW("NO") & " AND YARN_YEARID = " & YearId, "", "")

                    'IF FIRST CHAR OF INITIALS IS F THEN FINISHED ELES JOBWORK
                    If DTROW("TYPE") = "PENDING PURCHASE BILL" Then
                        If DTROW("INITIALS").ToString.Substring(0, 1) = "F" Then DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'FALSE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'FANCY MATERIAL' AND GRN_YEARID = " & YearId, "", "") Else DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'FALSE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'Job Work' AND GRN_YEARID = " & YearId, "", "")
                    End If

                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If


            'DT = OBJCMN.Execute_Any_String("UPDATE CHALLAN SET CHALLAN.CHALLAN_SIGNRECD = 1 WHERE CHALLAN.CHALLAN_NO = " & Val(dtrow("CHALLANNO")) & "  AND CHALLAN.CHALLAN_YEARID = " & YearId, "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class