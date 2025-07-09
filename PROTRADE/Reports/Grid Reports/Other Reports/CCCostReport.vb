
Imports BL

Public Class CCCostReport

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim DTBILL As New DataTable
                DTBILL.Columns.Add("TYPE")
                DTBILL.Columns.Add("SRNO")
                DTBILL.Columns.Add("NAME")
                DTBILL.Columns.Add("PROCESS")
                DTBILL.Columns.Add("AMOUNT")

                Dim FROMNO As Integer = 0
                Dim FROMSRNO As Integer = 0
                Dim FROMTYPE As String = ""

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    FROMNO = DT.Rows(0).Item("FROMNO")
                    FROMSRNO = DT.Rows(0).Item("FROMSRNO")
                    FROMTYPE = DT.Rows(0).Item("TYPE")


                    'WE NEED TO LOOP BACKWARD
                    'FIRST GET THE FROMNO / FROMSRNO / FROMTYPE FROM BARCODE AND THEN GOTO THAT ENTRY AND CHECK 
                    'ITS FROMNO / FROMSRNO / FROMTYPE
                    'ONCE WE REACH GRN OR OPENING WE HAVE TO STOP THE LOOP

LINE1:

                    Dim DTNEW As New DataTable
                    If FROMTYPE = "JOBIN" Then
                        DTNEW = OBJCMN.search(" 'JOBIN' AS TYPE, JOBIN.JI_no AS SRNO, LEDGERS.Acc_cmpname AS NAME, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(JOBIN_DESC.JI_RATE, 0) * JOBIN_DESC.JI_QTY AS AMOUNT, JOBIN_DESC.JI_FROMNO AS FROMNO, JOBIN.JI_JOBOUTNO AS JOBNO ", "", " JOBIN INNER JOIN JOBIN_DESC ON JOBIN.JI_no = JOBIN_DESC.JI_NO AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSMASTER ON JOBIN.JI_PROCESSID = PROCESSMASTER.PROCESS_ID ", " AND JOBIN.JI_NO = " & FROMNO & " AND JI_GRIDSRNO = " & FROMSRNO & " AND JOBIN.JI_YEARID = " & YearId)
                        If DTNEW.Rows.Count > 0 Then
                            DTBILL.Rows.Add(FROMTYPE, Val(DTNEW.Rows(0).Item("SRNO")), DTNEW.Rows(0).Item("NAME"), DTNEW.Rows(0).Item("PROCESS"), Val(DTNEW.Rows(0).Item("AMOUNT")))

                            'AFTER ADD FETCH FROMNO, SRNONO AND GRIDTYPE FROM JOBOUT
                            'SO WE NEED TO GOTO JOBOUT
                            Dim DTJO As DataTable = OBJCMN.search(" TOP 1 JO_FROMNO AS FROMNO, JO_FROMSRNO AS FROMSRNO, JO_FROMTYPE AS TYPE", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_YEARID =JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN DESIGNMASTER ON DESIGN_ID = JO_DESIGNID", " AND JOBOUT.JO_NO = " & Val(DTNEW.Rows(0).Item("JOBNO")) & " AND DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "' AND JOBOUT.JO_YEARID = " & YearId & " ORDER BY JOBOUT_DESC.JO_GRIDSRNO ")
                            If DTJO.Rows.Count > 0 Then
                                FROMNO = DTJO.Rows(0).Item("FROMNO")
                                FROMSRNO = DTJO.Rows(0).Item("FROMSRNO")
                                FROMTYPE = DTJO.Rows(0).Item("TYPE")
                                GoTo LINE1

                            End If

                        End If
                    ElseIf FROMTYPE = "GRN" Then
                        DTNEW = OBJCMN.search("TOP 1 GRN_NO AS SRNO, LEDGERS.ACC_CMPNAME AS NAME, (GRN_PURRATE * " & Val(DT.Rows(0).Item("MTRS")) & ") AS AMOUNT", "", "GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON ACC_ID = GRN.GRN_LEDGERID ", " AND GRN_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND GRN_YEARID = " & YearId)
                        If DTNEW.Rows.Count > 0 Then
                            DTBILL.Rows.Add(FROMTYPE, Val(DTNEW.Rows(0).Item("SRNO")), DTNEW.Rows(0).Item("NAME"), "", Val(DTNEW.Rows(0).Item("AMOUNT")))
                        End If

                    ElseIf FROMTYPE = "OPENING" Then
                        DTNEW = OBJCMN.search("TOP 1 GRN_NO AS SRNO, LEDGERS.ACC_CMPNAME AS NAME, (GRN_PURRATE * " & Val(DT.Rows(0).Item("MTRS")) & ") AS AMOUNT", "", "GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON ACC_ID = GRN.GRN_LEDGERID ", " AND GRN_BARCODE = '" & DT.Rows(0).Item("BARCODE") & "' AND GRN_YEARID = " & YearId)
                        If DTNEW.Rows.Count > 0 Then
                            DTBILL.Rows.Add(FROMTYPE, Val(DTNEW.Rows(0).Item("SRNO")), DTNEW.Rows(0).Item("NAME"), "", Val(DTNEW.Rows(0).Item("AMOUNT")))
                        End If


                    End If

                    gridbilldetails.DataSource = DTBILL
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CCCostReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Cost Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Cost Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Cost Report", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Cost Report Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class