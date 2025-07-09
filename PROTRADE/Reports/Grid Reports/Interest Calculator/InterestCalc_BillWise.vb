
Imports BL

Public Class InterestCalc_BillWise

    Dim BILLINTWHERECLAUSE As String = ""   'USED TO FETCH SELECTED BILLS IN WHERECLAOSE FROM SELECT BILL FORM
    Dim BILLINTPRINTWHERECLAUSE As String = ""   'USED TO FETCH SELECTED BILLS IN WHERECLAOSE FROM SELECT BILL FORM FOR PRINT
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        If CHKDATE.Checked = True Then
            a1 = DatePart(DateInterval.Day, dtfrom.Value)
            a2 = DatePart(DateInterval.Month, dtfrom.Value)
            a3 = DatePart(DateInterval.Year, dtfrom.Value)
            fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

            a11 = DatePart(DateInterval.Day, dtto.Value)
            a12 = DatePart(DateInterval.Month, dtto.Value)
            a13 = DatePart(DateInterval.Year, dtto.Value)
            toD = "(" & a13 & "," & a12 & "," & a11 & ")"
        Else
            a1 = DatePart(DateInterval.Day, AccFrom.Date)
            a2 = DatePart(DateInterval.Month, AccFrom.Date)
            a3 = DatePart(DateInterval.Year, AccFrom.Date)
            fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

            a11 = DatePart(DateInterval.Day, AccTo.Date)
            a12 = DatePart(DateInterval.Month, AccTo.Date)
            a13 = DatePart(DateInterval.Year, AccTo.Date)
            toD = "(" & a13 & "," & a12 & "," & a11 & ")"
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            EP.Clear()
            If Val(TXTSIDE.Text.Trim) = 0 Then
                EP.SetError(TXTSIDE, "Enter Side")
                Exit Sub
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, "Select Party")
                Exit Sub
            End If

            If Val(TXTPERCENT.Text.Trim) = 0 Then
                EP.SetError(TXTPERCENT, "Enter Rate Of Interest")
                Exit Sub
            End If

            If Val(TXTDAYS.Text.Trim) = 0 Then
                EP.SetError(TXTDAYS, "Enter Days")
                Exit Sub
            End If


            gduedate.Visible = RBDUEDATE.Checked
            gduedate.VisibleIndex = GDATE.VisibleIndex + 1

            Dim OBJCMN As New ClsCommon
            Dim dt As New DataTable
            Dim TEMPDATE As Date = Now.Date

            Dim WHERE As String = " AND YEARID = " & YearId
            Dim OPWHERE As String = " AND YEARID = " & YearId
            If CHKOVERRIDE.CheckState = CheckState.Unchecked Then WHERE = WHERE & " AND TYPE <> 'INVOICEDEBITNOTE' "
            If CHKDATE.Checked = True Then
                TEMPDATE = dtto.Value.Date.AddDays(1)
                If RBDUEDATE.Checked = True Then
                    WHERE = WHERE & " AND DUEDATE > '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DUEDATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND DUEDATE <= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'"
                ElseIf RBBILLDATE.Checked = True Then
                    WHERE = WHERE & " AND DATE > '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND DATE <= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'"
                ElseIf RBPASSDATE.Checked = True Then
                    WHERE = WHERE & " AND APPDATE > '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND APPDATE <='" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND APPDATE <= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "'"
                End If
            Else
                TEMPDATE = AccTo.Date.AddDays(1)
                If RBDUEDATE.Checked = True Then
                    WHERE = WHERE & " AND DUEDATE > '" & Format(AccFrom, "MM/dd/yyyy") & "' AND DUEDATE <='" & Format(AccTo, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND DUEDATE <= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'"
                ElseIf RBBILLDATE.Checked = True Then
                    WHERE = WHERE & " AND DATE > '" & Format(AccFrom, "MM/dd/yyyy") & "' AND DATE <='" & Format(AccTo, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND DATE <= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'"
                ElseIf RBPASSDATE.Checked = True Then
                    WHERE = WHERE & " AND APPDATE > '" & Format(AccFrom, "MM/dd/yyyy") & "' AND APPDATE <='" & Format(AccTo, "MM/dd/yyyy") & "'"
                    OPWHERE = OPWHERE & " AND APPDATE <= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'"
                End If
            End If


            Dim SIDEDUEDATE As String = ""
            If CHKOVERRIDE.CheckState = CheckState.Checked Then SIDEDUEDATE = "(CASE WHEN TYPE IN ('SALE','PURCHASE') THEN DATEADD(DAY," & Val(TXTSIDE.Text.Trim) & ",DATE) ELSE DATE END)" Else SIDEDUEDATE = "(CASE WHEN TYPE IN ('SALE','PURCHASE') THEN DUEDATE ELSE DATE END)"

            'dt = OBJCMN.search("1 AS SORTNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, " & SIDEDUEDATE & " AS DUEDATE, TOTALBALES,DEBIT, CREDIT, REMARKS, ISNULL(DATEDIFF(DAY," & SIDEDUEDATE & ",'" & Format(TEMPDATE.Date, "MM/dd/yyyy") & "'),0) AS [DAYS], 0 AS NETTBALANCE, 0.0 AS TOPAY, 0.0 AS TOREC  ", "", " INTERESTVIEWBILL ", " AND NAME = '" & cmbname.Text.Trim & "' AND YEARID = " & YearId & WHERE & " ORDER BY NAME, DUEDATE  ")
            If BILLINTWHERECLAUSE <> "" Then WHERE = WHERE & BILLINTWHERECLAUSE
            dt = OBJCMN.search("1 AS SORTNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, " & SIDEDUEDATE & " AS DUEDATE, TOTALBALES, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, REMARKS, ISNULL(DATEDIFF(DAY," & SIDEDUEDATE & ",'" & Format(TEMPDATE.Date, "MM/dd/yyyy") & "'),0) AS [DAYS], 0 AS NETTBALANCE, 0.0 AS TOPAY, 0.0 AS TOREC  ", "", " INTERESTVIEWBILL ", " AND NAME = '" & cmbname.Text.Trim & "' AND YEARID = " & YearId & WHERE & " GROUP BY NAME, DUEDATE, SRNO, REGTYPE, BILLINITIALS, TYPE,  DATE, APPDATE, TOTALBALES, REMARKS, ISNULL(DATEDIFF(DAY," & SIDEDUEDATE & ",'" & Format(TEMPDATE.Date, "MM/dd/yyyy") & "'),0)  ")


            Dim DV As New DataView(dt)
            If RBDUEDATE.Checked = True Then
                DV.Sort = "SORTNO ASC, NAME ASC,DUEDATE ASC"
            ElseIf RBBILLDATE.Checked = True Then
                DV.Sort = "SORTNO ASC, NAME ASC,DATE ASC"
            ElseIf RBPASSDATE.Checked = True Then
                DV.Sort = "SORTNO ASC, NAME ASC,APPDATE ASC"
            End If

            griddetails.DataSource = DV
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try

            txttotal.Text = 0.0

            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("NETTBALANCE") = (Val(dtrow("DEBIT")) + Val(RUNNINGBAL)) - Val(dtrow("CREDIT"))
                RUNNINGBAL = dtrow("NETTBALANCE")
            Next


            RUNNINGBAL = 0
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                Dim NEWDTROW As DataRow = gridregister.GetDataRow(i + 1)
                If dtrow("BILLINITIALS") = "OPENING" Then
                    If NEWDTROW("BILLINITIALS") <> "CLOSING" Then
                        If RBDUEDATE.Checked = True Then NEWDTROW("DAYS") = DateDiff(DateInterval.Day, dtrow("DUEDATE"), NEWDTROW("DUEDATE")) Else NEWDTROW("DAYS") = DateDiff(DateInterval.Day, dtrow("DATE"), NEWDTROW("DATE"))
                    End If
                End If

                If dtrow("BILLINITIALS") = "CLOSING" Then
                    'IF LAST DATE IS SAME AS CLOSING DATE THEN THERE WILL BE NOT CALCULATIONS OF DATS IN CLOSING
                    'THIS IS DONE BY GULKIT DO NOT CHANGE 
                    Dim TEMPDTROW As DataRow = gridregister.GetDataRow(i - 1)
                    If RBDUEDATE.Checked = True Then
                        If dtrow("DUEDATE") = TEMPDTROW("DUEDATE") And TEMPDTROW("BILLINITIALS") <> "OPENING" Then
                            TEMPDTROW("DAYS") = TEMPDTROW("DAYS") + 1
                            Dim TEMPDTROW1 As DataRow = gridregister.GetDataRow(i - 2)
                            If TEMPDTROW("NETTBALANCE") > 0 Then
                                TEMPDTROW("TOREC") = (((Val(TXTPERCENT.Text.Trim) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            Else
                                TEMPDTROW("TOPAY") = (((Val(TXTPERCENT.Text.Trim) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            End If
                            dtrow("DAYS") = 0
                        End If
                    Else
                        If dtrow("DATE") = TEMPDTROW("DATE") And TEMPDTROW("BILLINITIALS") <> "OPENING" Then
                            TEMPDTROW("DAYS") = TEMPDTROW("DAYS") + 1
                            Dim TEMPDTROW1 As DataRow = gridregister.GetDataRow(i - 2)
                            If TEMPDTROW("NETTBALANCE") > 0 Then
                                TEMPDTROW("TOREC") = (((Val(TXTPERCENT.Text.Trim) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            Else
                                TEMPDTROW("TOPAY") = (((Val(TXTPERCENT.Text.Trim) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            End If
                            dtrow("DAYS") = 0
                        End If
                    End If

                End If

                If Val(dtrow("DAYS")) > 0 Then
                    If Val(dtrow("DEBIT")) > 0 Then
                        dtrow("TOREC") = (((Val(TXTPERCENT.Text.Trim) * Val(dtrow("DEBIT"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
                    Else
                        dtrow("TOPAY") = (((Val(TXTPERCENT.Text.Trim) * Val(dtrow("CREDIT"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
                    End If
                End If
                RUNNINGBAL = dtrow("NETTBALANCE")

            Next


            If Val(GTOPAY.SummaryText) > Val(GTOREC.SummaryText) Then
                txttotal.Text = Format(Val(GTOPAY.SummaryText) - Val(GTOREC.SummaryText), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                txttotal.Text = Format(Val(GTOREC.SummaryText) - Val(GTOPAY.SummaryText), "0.00")
                lbldrcrclosing.Text = "Dr"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUP_SECONDARY = 'Sundry Creditors' or GROUP_SECONDARY = 'Sundry Debtors'  OR GROUP_SECONDARY = 'Loans' OR GROUP_SECONDARY = 'Unsecured Loans' OR GROUP_SECONDARY = 'Loans & Advances' OR GROUP_SECONDARY = 'Capital A/C' OR GROUP_SECONDARY = 'Deposit (Assets)') and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND (GROUP_SECONDARY = 'Sundry Creditors' or GROUP_SECONDARY = 'Sundry Debtors'  OR GROUP_SECONDARY = 'Loans' OR GROUP_SECONDARY = 'Unsecured Loans' OR GROUP_SECONDARY = 'Loans & Advances' OR GROUP_SECONDARY = 'Capital A/C' OR GROUP_SECONDARY = 'Deposit (Assets)') and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("isnull(ACC_INTPER,0) AS INTPER", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                TXTPERCENT.Text = Val(DT.Rows(0).Item("INTPER"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' and ledgers.acc_cmpid = " & CmpId & " and ledgers.acc_LOCATIONid = " & Locationid & " and ledgers.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_BillWise_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_BillWise_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillname(cmbname, False, " AND (GROUP_SECONDARY = 'Sundry Creditors' or GROUP_SECONDARY = 'Sundry Debtors' OR GROUP_SECONDARY = 'Loans' OR GROUP_SECONDARY = 'Loans & Advances' OR GROUP_SECONDARY = 'Capital A/C' OR GROUP_SECONDARY = 'Deposit (Assets)') and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
            If cmbname.Text.Trim <> "" Then fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKDATE.CheckedChanged
        Try
            dtfrom.Enabled = CHKDATE.CheckState
            dtto.Enabled = CHKDATE.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                VIEWFORM(dtrow("TYPE"), True, dtrow("SRNO"), dtrow("REGTYPE"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Interest Calculator.XLS"
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If CHKDATE.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Interest Calculator"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Interest Calculator", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD)
        Catch ex As Exception
            MsgBox("Interest Calculator Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        numkeypress(e, TXTDAYS, Me)
    End Sub

    Private Sub TXTPERCENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPERCENT.KeyPress
        numdotkeypress(e, TXTPERCENT, Me)
    End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            If Val(TXTSIDE.Text.Trim) > 0 And Val(TXTPERCENT.Text.Trim) > 0 And Val(TXTDAYS.Text.Trim) > 0 Then
                If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJPLPRINT As New PLDesign
                OBJPLPRINT.MdiParent = MDIMain
                OBJPLPRINT.frmstring = "INTERESTBILLDTLS"
                getFromToDate()

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ACC_TDSPER AS TDSPER ", "", " ACCOUNTSMASTER_TDS INNER JOIN ACCOUNTSMASTER ON ACCOUNTSMASTER_TDS.ACC_ID = ACCOUNTSMASTER.ACC_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACCOUNTSMASTER.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then OBJPLPRINT.TDSPER = Val(DT.Rows(0).Item("TDSPER"))

                OBJPLPRINT.strsearch = "{INTERESTVIEWBILLREPORT.NAME} = '" & cmbname.Text.Trim & "' AND {INTERESTVIEWBILLREPORT.INVYEARID} = " & YearId & BILLINTPRINTWHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                OBJPLPRINT.PERIOD = "NAME : " & cmbname.Text.Trim
                If CHKOVERRIDE.Checked = True Then OBJPLPRINT.PERIOD = OBJPLPRINT.PERIOD & "            SIDE - " & Val(TXTSIDE.Text.Trim)
                If CHKDATE.CheckState = CheckState.Checked Then
                    OBJPLPRINT.TODATE = dtto.Value.Date
                    OBJPLPRINT.PERIOD = OBJPLPRINT.PERIOD & "           INTEREST DETAILS FROM : " & Format(dtfrom.Value.Date, "dd/MM/yy").ToString & " TO " & Format(dtto.Value.Date, "dd/MM/yy").ToString
                Else
                    OBJPLPRINT.TODATE = AccTo.Date
                    OBJPLPRINT.PERIOD = OBJPLPRINT.PERIOD & "           INTEREST DETAILS FROM : " & Format(AccFrom.Date, "dd/MM/yy").ToString & " TO " & Format(AccTo.Date, "dd/MM/yy").ToString
                End If
                OBJPLPRINT.SIDEDAYS = Val(TXTSIDE.Text.Trim)
                OBJPLPRINT.INTPER = Val(TXTPERCENT.Text.Trim)
                OBJPLPRINT.CALCDAYS = Val(TXTDAYS.Text.Trim)
                OBJPLPRINT.CHANGEDUEDATE = CHKCHANGEDUEDATE.Checked
                OBJPLPRINT.DUEDATE = DUEDATE.Value.Date

                If CHKOVERRIDE.CheckState = CheckState.Checked Then OBJPLPRINT.OVERRIDEDUEDATE = 1 Else OBJPLPRINT.OVERRIDEDUEDATE = 0
                OBJPLPRINT.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTBILLS_Click(sender As Object, e As EventArgs) Handles CMDSELECTBILLS.Click
        Try
            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim OBJBILL As New SelectBills
            OBJBILL.CMPNAME = cmbname.Text.Trim
            OBJBILL.FRMSTRING = "BILLINTEREST"
            OBJBILL.ShowDialog()
            BILLINTWHERECLAUSE = OBJBILL.BILLINTWHERECLAUSE
            BILLINTPRINTWHERECLAUSE = OBJBILL.BILLINTPRINTWHERECLAUSE
            Call cmdshowdetails_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_BillWise_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "NVAHAN" Then CHKOVERRIDE.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class