
Imports BL

Public Class InterestCalc_Summary

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            EP.Clear()
            If Val(TXTPERCENT.Text.Trim) = 0 Then
                EP.SetError(TXTPERCENT, "Enter Rate Of Interest")
                Exit Sub
            End If

            If Val(TXTDAYS.Text.Trim) = 0 Then
                EP.SetError(TXTDAYS, "Enter Days")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim WHERE As String = " AND YEARID = " & YearId
            Dim OPWHERE As String = " AND YEARID = " & YearId
            If CHKDN.CheckState = CheckState.Unchecked Then WHERE = WHERE & " AND TYPE <> 'INVOICEDEBITNOTE' "
            If CHKDATE.Checked = True Then
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

            Dim GROUP As String = ""
            If cmbgroup.Text <> "" Then GROUP = GROUP & " AND GROUPMASTER.GROUP_NAME ='" & cmbgroup.Text.Trim & "'"

            Dim NAMEDT As New DataTable
            If RBDUEDATE.Checked = True Then
                NAMEDT = OBJCMN.search(" 1 AS SORTNO, NAME,GROUPMASTER.group_secondary AS GROUPSECONDARY, GROUPMASTER.GROUP_NAME AS GROUPNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, (CASE WHEN (SUM(DEBIT) - SUM(CREDIT)) > 0 THEN (SUM(DEBIT) - SUM(CREDIT)) ELSE (SUM(CREDIT) - SUM(DEBIT)) END) AS NETTBALANCE, " & Format(Val(TXTPERCENT.Text.Trim), "0.00") & " AS INTPER, 0 AS TOPAY, 0 AS TOREC, 0 AS INTDR, 0 AS INTCR,isnull(LEDGERS.ACC_PANNO,'') AS PANNO,ISNULL(ACCOUNTSMASTER_TDS.ACC_TDSPER,0) AS TDSPER, 0 AS TDSAMT, 0 AS NETTINT, isnull(ACCOUNTSMASTER_TDS.ACC_TDSFORM,'') AS TDSFORM, 0 AS SIDEINT, 0 AS TOTALINT  ", "", " (SELECT ROW_NUMBER() OVER (ORDER BY DUEDATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE YEARID =  " & YearId & " " & WHERE & " UNION ALL SELECT ROW_NUMBER() OVER (ORDER BY DUEDATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE 1=1 " & OPWHERE & ") AS NEWT INNER JOIN LEDGERS ON NEWT.YEARID = LEDGERS.Acc_yearid AND NEWT.NAME = LEDGERS.Acc_CMPname INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND YEARID = " & YearId & GROUP & " GROUP BY NAME,GROUPMASTER.group_secondary, GROUPMASTER.GROUP_NAME, LEDGERS.ACC_PANNO, ACCOUNTSMASTER_TDS.ACC_TDSFORM, ACCOUNTSMASTER_TDS.ACC_TDSPER ORDER BY NEWT.NAME ")
            Else
                NAMEDT = OBJCMN.search(" 1 AS SORTNO, NAME,GROUPMASTER.group_secondary AS GROUPSECONDARY, GROUPMASTER.GROUP_NAME AS GROUPNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, (CASE WHEN (SUM(DEBIT) - SUM(CREDIT)) > 0 THEN (SUM(DEBIT) - SUM(CREDIT)) ELSE (SUM(CREDIT) - SUM(DEBIT)) END) AS NETTBALANCE, " & Format(Val(TXTPERCENT.Text.Trim), "0.00") & " AS INTPER, 0 AS TOPAY, 0 AS TOREC, 0 AS INTDR, 0 AS INTCR,isnull(LEDGERS.ACC_PANNO,'') AS PANNO,ISNULL(ACCOUNTSMASTER_TDS.ACC_TDSPER,0) AS TDSPER, 0 AS TDSAMT, 0 AS NETTINT, isnull(ACCOUNTSMASTER_TDS.ACC_TDSFORM,'') AS TDSFORM, 0 AS SIDEINT, 0 AS TOTALINT  ", "", " (SELECT ROW_NUMBER() OVER (ORDER BY DATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE YEARID =  " & YearId & " " & WHERE & " UNION ALL SELECT ROW_NUMBER() OVER (ORDER BY DATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE 1=1 " & OPWHERE & ") AS NEWT INNER JOIN LEDGERS ON NEWT.YEARID = LEDGERS.Acc_yearid AND NEWT.NAME = LEDGERS.Acc_CMPname INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND YEARID = " & YearId & GROUP & " GROUP BY NAME,GROUPMASTER.group_secondary, GROUPMASTER.GROUP_NAME, LEDGERS.ACC_PANNO, ACCOUNTSMASTER_TDS.ACC_TDSFORM, ACCOUNTSMASTER_TDS.ACC_TDSPER ORDER BY NEWT.NAME ")
            End If

            If NAMEDT.Rows.Count > 0 Then

                For Each NAMEROW As DataRow In NAMEDT.Rows

                    'CHANGE INTPER IN NAMEDT
                    'GET INTPER FROM LEDGERS IF WE HAVE ENTERED THERE ELSE CONTINUEE
                    If NAMEROW("NAME") <> "" And CHKALL.CheckState = CheckState.Unchecked Then
                        Dim DTPARTYINT As DataTable = OBJCMN.search(" ISNULL(ACC_INTPER,0.0) AS INTPER ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & NAMEROW("NAME") & "' AND ACC_YEARID = " & YearId)
                        If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then NAMEROW("INTPER") = Val(DTPARTYINT.Rows(0).Item("INTPER"))
                    End If

                    'ADD SIDEDR OR SIDECR
                    If ClientName = "NVAHAN" Or ClientName = "SASKARIA" Then
                        Dim DTPARTYSIDE As DataTable = OBJCMN.search(" ISNULL(SUM(T.AMT),0) AS SIDEAMTDR ", "", " (SELECT  ROUND(((SUM(INVOICE_GRANDTOTAL)* TERM_CRDAYS)/" & Val(TXTDAYS.Text.Trim) & ")*(" & Val(NAMEROW("INTPER")) / 100 & "),0) AS AMT FROM INVOICEMASTER INNER JOIN TERMMASTER ON INVOICE_TERMID = TERM_ID INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID WHERE INVOICE_YEARID = " & YearId & " AND LEDGERS.ACC_CMPNAME = '" & NAMEROW("NAME") & "' AND TERM_CRDAYS >0 GROUP BY TERM_CRDAYS ) AS T ", "")
                        If Val(DTPARTYSIDE.Rows(0).Item("SIDEAMTDR")) > 0 Then NAMEROW("SIDEINT") = Val(DTPARTYSIDE.Rows(0).Item("SIDEAMTDR"))
                    End If

                    Dim DT As New DataTable
                    If RBDUEDATE.Checked = True Then
                        DT = OBJCMN.search("1 AS SORTNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE, TOTALBALES,DEBIT, CREDIT, ISNULL( DATEDIFF(DAY,(SELECT DUEDATE FROM (SELECT     ROW_NUMBER() OVER ( ORDER BY DUEDATE)AS ROWNO, DUEDATE FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND YEARID = " & YearId & WHERE & ")) AS T WHERE T.ROWNO = NEWT.ROWNO -1 ), NEWT.[DUEDATE]),0) AS [DAYS], 0 AS NETTBALANCE, 0 AS TOPAY, 0 AS TOREC  ", "", " (SELECT     ROW_NUMBER() OVER (ORDER BY DUEDATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND YEARID = " & YearId & WHERE & ")) AS NEWT ", WHERE & " ORDER BY NEWT.NAME, NEWT.DUEDATE  ")
                    Else
                        DT = OBJCMN.search("1 AS SORTNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE, TOTALBALES,DEBIT, CREDIT, ISNULL( DATEDIFF(DAY,(SELECT DATE FROM (SELECT     ROW_NUMBER() OVER ( ORDER BY DATE)AS ROWNO, DATE FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND YEARID = " & YearId & WHERE & ")) AS T WHERE T.ROWNO = NEWT.ROWNO -1 ), NEWT.[DATE]),0) AS [DAYS], 0 AS NETTBALANCE, 0 AS TOPAY, 0 AS TOREC  ", "", " (SELECT     ROW_NUMBER() OVER (ORDER BY DATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND YEARID = " & YearId & WHERE & ")) AS NEWT ", WHERE & " ORDER BY NEWT.NAME, NEWT.DATE  ")
                    End If
                    Dim DTROW() As DataRow

                    Dim DTOPENING As DataTable = OBJCMN.search(" (CASE WHEN (SUM(DEBIT) - SUM(CREDIT)> 0) THEN (SUM(DEBIT) - SUM(CREDIT)) ELSE 0 END )AS DEBITBAL, (CASE WHEN (SUM(CREDIT) - SUM(DEBIT)> 0 )THEN (SUM(CREDIT) - SUM(DEBIT)) ELSE 0 END)  AS CREDITBAL ", "", " INTERESTVIEW ", OPWHERE & " AND NAME = '" & NAMEROW("NAME") & "'")
                    If DTOPENING.Rows.Count > 0 Then
                        If CHKDATE.CheckState = CheckState.Checked Then
                            If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "", "OPENING", "", "", dtfrom.Value.Date, dtfrom.Value.Date, dtfrom.Value.Date, 0, Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), 0, 0, 0, 0)
                        Else
                            If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "", "OPENING", "", "", AccFrom.Date, AccFrom.Date, AccFrom.Date, 0, Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), 0, 0, 0, 0)
                        End If
                    End If


                    If dt.Rows.Count > 0 Then

                        Dim CLODAYS As Integer = 0
                        If RBDUEDATE.Checked = True Then
                            DTROW = dt.Select("DUEDATE = MAX(DUEDATE)")
                            Dim NETBAL As Double = dt.Compute("(SUM(DEBIT) - SUM(CREDIT))", "")
                            If Val(NETBAL) <> 0 Then CLODAYS = 1
                            If CHKDATE.CheckState = CheckState.Checked Then
                                CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DUEDATE"), dtto.Value.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            Else
                                CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DUEDATE"), AccTo.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            End If

                        ElseIf RBBILLDATE.Checked = True Then
                            DTROW = dt.Select("DATE = MAX(DATE)")
                            Dim NETBAL As Double = dt.Compute("(SUM(DEBIT) - SUM(CREDIT))", "")
                            If Val(NETBAL) <> 0 Then CLODAYS = 1
                            If CHKDATE.CheckState = CheckState.Checked Then
                                CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), dtto.Value.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            Else
                                CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), AccTo.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            End If

                        ElseIf RBPASSDATE.Checked = True Then
                            DTROW = dt.Select("APPDATE = MAX(APPDATE)")
                            If CHKDATE.CheckState = CheckState.Checked Then
                                CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("APPDATE"), dtto.Value.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            Else
                                CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("APPDATE"), AccTo.Date)
                                If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                            End If

                        End If

                    End If

                    Dim DV As New DataView(dt)
                    If RBDUEDATE.Checked = True Then
                        DV.Sort = "SORTNO ASC, NAME ASC,DUEDATE ASC"
                    ElseIf RBBILLDATE.Checked = True Then
                        DV.Sort = "SORTNO ASC, NAME ASC,DATE ASC"
                    ElseIf RBPASSDATE.Checked = True Then
                        DV.Sort = "SORTNO ASC, NAME ASC,APPDATE ASC"
                    End If

                    griddetails.DataSource = DV
                    TOTAL(Val(TXTPERCENT.Text.Trim), NAMEROW("NAME"))

                    NAMEROW("TOPAY") = Val(GTOPAY.SummaryText)
                    NAMEROW("TOREC") = Val(GTOREC.SummaryText)

                    If IsDBNull(NAMEROW("TDSPER")) = False Then
                        If NAMEROW("TDSPER") > 0 Then
                            If Val(NAMEROW("TOPAY")) > 0 Then NAMEROW("TDSAMT") = Format(((Val(NAMEROW("TOPAY")) * Val(NAMEROW("TDSPER"))) / 100), "0") Else NAMEROW("TDSAMT") = Format(((Val(NAMEROW("TOREC")) * Val(NAMEROW("TDSPER"))) / 100), "0")
                        End If
                    End If

                    If Val(NAMEROW("TOPAY")) > Val(NAMEROW("TOREC")) Then
                        NAMEROW("NETTINT") = (Val(NAMEROW("TOPAY")) - Val(NAMEROW("TOREC"))) - Val(NAMEROW("TDSAMT"))
                        NAMEROW("TOTALINT") = (Val(NAMEROW("TOPAY")) - Val(NAMEROW("TOREC"))) - Val(NAMEROW("TDSAMT")) + Val(NAMEROW("SIDEINT"))
                    Else
                        NAMEROW("NETTINT") = (Val(NAMEROW("TOREC")) - Val(NAMEROW("TOPAY"))) - Val(NAMEROW("TDSAMT"))
                        NAMEROW("TOTALINT") = (Val(NAMEROW("TOREC")) - Val(NAMEROW("TOPAY"))) - Val(NAMEROW("TDSAMT")) - Val(NAMEROW("SIDEINT"))
                    End If


                    If lbldrcrclosing.Text = "Dr" Then
                        NAMEROW("INTDR") = Val(txttotal.Text.Trim)
                    Else
                        NAMEROW("INTCR") = Val(txttotal.Text.Trim)
                    End If

                Next

                GRIDNAMEDETAILS.DataSource = NAMEDT

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL(ByVal PERCENTCAL As Double, ByVal LEDGERNAME As String)
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


            Dim OBJCMN As New ClsCommon
            RUNNINGBAL = 0
            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                If dtrow("BILLINITIALS") = "OPENING" Then
                    Dim NEWDTROW As DataRow = gridregister.GetDataRow(i + 1)
                    If NEWDTROW("BILLINITIALS") <> "CLOSING" Then
                        If RBDUEDATE.Checked = True Then NEWDTROW("DAYS") = DateDiff(DateInterval.Day, dtrow("DUEDATE"), NEWDTROW("DUEDATE")) Else NEWDTROW("DAYS") = DateDiff(DateInterval.Day, dtrow("DATE"), NEWDTROW("DATE"))
                    End If
                End If

                'CHECKING WHETHER INTPER IS PRESENT IN MASTER OR NOT
                'IF PRESEN THEN CALCULATE PERCENTCAL WITH THAT PERCENT ELSE CONTINUE
                Dim PARTYINTPER As Double = 0
                Dim DTPARTYINT As DataTable = OBJCMN.search(" isnull(ACC_INTPER,0) AS INTPER ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & LEDGERNAME & "' AND ACC_YEARID = " & YearId)
                If CHKALL.CheckState = CheckState.Checked Then PARTYINTPER = PERCENTCAL Else PARTYINTPER = Val(DTPARTYINT.Rows(0).Item("INTPER"))


                If dtrow("BILLINITIALS") = "CLOSING" Then
                    'IF LAST DATE IS SAME AS CLOSING DATE THEN THERE WILL BE NOT CALCULATIONS OF DATS IN CLOSING
                    'THIS IS DONE BY GULKIT DO NOT CHANGE 
                    Dim TEMPDTROW As DataRow = gridregister.GetDataRow(i - 1)
                    If RBDUEDATE.Checked = True Then
                        If dtrow("DUEDATE") = TEMPDTROW("DUEDATE") And TEMPDTROW("BILLINITIALS") <> "OPENING" Then
                            TEMPDTROW("DAYS") = TEMPDTROW("DAYS") + 1
                            Dim TEMPDTROW1 As DataRow = gridregister.GetDataRow(i - 2)
                            If TEMPDTROW("NETTBALANCE") > 0 Then
                                If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then TEMPDTROW("TOREC") = (((Val(PARTYINTPER) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS"))) Else TEMPDTROW("TOREC") = (((Val(PERCENTCAL) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            Else
                                If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then TEMPDTROW("TOPAY") = (((Val(PARTYINTPER) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS"))) Else TEMPDTROW("TOPAY") = (((Val(PERCENTCAL) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            End If
                            dtrow("DAYS") = 0
                        End If
                    Else
                        If dtrow("DATE") = TEMPDTROW("DATE") And TEMPDTROW("BILLINITIALS") <> "OPENING" Then
                            TEMPDTROW("DAYS") = TEMPDTROW("DAYS") + 1
                            Dim TEMPDTROW1 As DataRow = gridregister.GetDataRow(i - 2)
                            If TEMPDTROW("NETTBALANCE") > 0 Then
                                If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then TEMPDTROW("TOREC") = (((Val(PARTYINTPER) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS"))) Else TEMPDTROW("TOREC") = (((Val(PERCENTCAL) * Val(TEMPDTROW1("NETTBALANCE"))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            Else
                                If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then TEMPDTROW("TOPAY") = (((Val(PARTYINTPER) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS"))) Else TEMPDTROW("TOPAY") = (((Val(PERCENTCAL) * (Val(TEMPDTROW1("NETTBALANCE")) * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(TEMPDTROW("DAYS")))
                            End If
                            dtrow("DAYS") = 0
                        End If
                    End If
                End If


                    If Val(dtrow("DAYS")) > 0 Then
                    If Val(RUNNINGBAL) > 0 Then
                        If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then dtrow("TOREC") = (((PARTYINTPER * RUNNINGBAL) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS"))) Else dtrow("TOREC") = (((Val(PERCENTCAL) * RUNNINGBAL) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
                    Else
                        If Val(DTPARTYINT.Rows(0).Item("INTPER")) > 0 Then dtrow("TOPAY") = (((Val(PARTYINTPER) * (RUNNINGBAL * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS"))) Else dtrow("TOPAY") = (((Val(PERCENTCAL) * (RUNNINGBAL * (-1))) / 100) / Val(TXTDAYS.Text.Trim) * Val(dtrow("DAYS")))
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

    Private Sub InterestCalc_Summary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKDATE.CheckedChanged
        Try
            dtfrom.Enabled = CHKDATE.CheckState
            dtto.Enabled = CHKDATE.CheckState
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
            If GRIDNAMEREGISTER.RowCount > 0 Then
                Dim dtrow As DataRow = GRIDNAMEREGISTER.GetFocusedDataRow
                Dim OBJINT As New InterestCalc
                OBJINT.MdiParent = MDIMain
                OBJINT.cmbname.Text = dtrow("NAME")
                OBJINT.TXTPERCENT.Text = Val(dtrow("INTPER"))
                OBJINT.TXTDAYS.Text = Val(TXTDAYS.Text)
                OBJINT.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Interest Calculator Summary.XLS"
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If CHKDATE.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Interest Calculator Summary"
            GRIDNAMEREGISTER.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Interest Calculator Summary", GRIDNAMEREGISTER.VisibleColumns.Count + GRIDNAMEREGISTER.GroupCount, cmbgroup.Text.Trim, PERIOD)
        Catch ex As Exception
            MsgBox("Interest Calculator Summary Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        numkeypress(e, TXTDAYS, Me)
    End Sub

    Private Sub TXTPERCENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPERCENT.KeyPress
        numdotkeypress(e, TXTPERCENT, Me)
    End Sub

    Private Sub GRIDNAMEREGISTER_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GRIDNAMEREGISTER.CellValueChanged
        Try
            If e.Column.Name = "GNINTPER" Then


                Dim OBJCMN As New ClsCommon
                Dim WHERE As String = " AND CMPID= " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId
                Dim OPWHERE As String = " AND CMPID= " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId
                If CHKDN.CheckState = CheckState.Unchecked Then WHERE = WHERE & " AND TYPE <> 'INVOICEDEBITNOTE' "
                If CHKDATE.Checked = True Then
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

                Dim NAMEROW As DataRow = GRIDNAMEREGISTER.GetFocusedDataRow


                Dim dt As DataTable = OBJCMN.search("1 AS SORTNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE, TOTALBALES,DEBIT, CREDIT, ISNULL( DATEDIFF(DAY,(SELECT DUEDATE FROM (SELECT     ROW_NUMBER() OVER ( ORDER BY DUEDATE)AS ROWNO, DUEDATE FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & WHERE & ")) AS T WHERE T.ROWNO = NEWT.ROWNO -1 ), NEWT.[DUEDATE]),0) AS [DAYS], 0 AS NETTBALANCE, 0 AS TOPAY, 0 AS TOREC  ", "", " (SELECT     ROW_NUMBER() OVER (ORDER BY DUEDATE)AS ROWNO, SRNO, REGTYPE, BILLINITIALS, TYPE, NAME, DATE, APPDATE, DUEDATE,TOTALBALES, DEBIT, CREDIT,  CMPID, LOCATIONID, YEARID FROM INTERESTVIEW WHERE (NAME = '" & NAMEROW("NAME") & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & WHERE & ")) AS NEWT ", WHERE & " ORDER BY NEWT.NAME, NEWT.DUEDATE  ")
                Dim DTROW() As DataRow

                Dim DTOPENING As DataTable = OBJCMN.search(" (CASE WHEN (SUM(DEBIT) - SUM(CREDIT)> 0) THEN (SUM(DEBIT) - SUM(CREDIT)) ELSE 0 END )AS DEBITBAL, (CASE WHEN (SUM(CREDIT) - SUM(DEBIT)> 0 )THEN (SUM(CREDIT) - SUM(DEBIT)) ELSE 0 END)  AS CREDITBAL ", "", " INTERESTVIEW ", OPWHERE & " AND NAME = '" & NAMEROW("NAME") & "'")
                If DTOPENING.Rows.Count > 0 Then
                    If CHKDATE.CheckState = CheckState.Checked Then
                        If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "", "OPENING", "", "", dtfrom.Value.Date, dtfrom.Value.Date, dtfrom.Value.Date, 0, Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), 0, 0, 0, 0)
                    Else
                        If (Val(DTOPENING.Rows(0).Item("DEBITBAL")) > 0 Or Val(DTOPENING.Rows(0).Item("CREDITBAL")) > 0) Then dt.Rows.Add(0, 0, "", "OPENING", "", "", AccFrom.Date, AccFrom.Date, AccFrom.Date, 0, Val(DTOPENING.Rows(0).Item("DEBITBAL")), Val(DTOPENING.Rows(0).Item("CREDITBAL")), 0, 0, 0, 0)
                    End If
                End If


                If dt.Rows.Count > 0 Then

                    Dim CLODAYS As Integer = 0
                    If RBDUEDATE.Checked = True Then
                        DTROW = dt.Select("DUEDATE = MAX(DUEDATE)")
                        Dim NETBAL As Double = dt.Compute("(SUM(DEBIT) - SUM(CREDIT))", "")
                        If Val(NETBAL) <> 0 Then CLODAYS = 1
                        If CHKDATE.CheckState = CheckState.Checked Then
                            CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DUEDATE"), dtto.Value.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        Else
                            CLODAYS = CLODAYS + DateDiff(DateInterval.Day, DTROW(0).Item("DUEDATE"), AccTo.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        End If

                    ElseIf RBBILLDATE.Checked = True Then
                        DTROW = dt.Select("DATE = MAX(DATE)")
                        If CHKDATE.CheckState = CheckState.Checked Then
                            CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), dtto.Value.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        Else
                            CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("DATE"), AccTo.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        End If

                    ElseIf RBPASSDATE.Checked = True Then
                        DTROW = dt.Select("APPDATE = MAX(APPDATE)")
                        If CHKDATE.CheckState = CheckState.Checked Then
                            CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("APPDATE"), dtto.Value.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", dtto.Value.Date, dtto.Value.Date, dtto.Value.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        Else
                            CLODAYS = DateDiff(DateInterval.Day, DTROW(0).Item("APPDATE"), AccTo.Date)
                            If CLODAYS > 0 Then dt.Rows.Add(2, 0, "", "CLOSING", "", "", AccTo.Date, AccTo.Date, AccTo.Date, 0, 0, 0, CLODAYS, 0, 0, 0)
                        End If

                    End If

                End If

                Dim DV As New DataView(dt)
                If RBDUEDATE.Checked = True Then
                    DV.Sort = "SORTNO ASC, NAME ASC,DUEDATE ASC"
                ElseIf RBBILLDATE.Checked = True Then
                    DV.Sort = "SORTNO ASC, NAME ASC,DATE ASC"
                ElseIf RBPASSDATE.Checked = True Then
                    DV.Sort = "SORTNO ASC, NAME ASC,APPDATE ASC"
                End If

                griddetails.DataSource = DV
                TOTAL(Val(NAMEROW("INTPER")), NAMEROW("NAME"))

                If NAMEROW("INTPER") = 0 Then
                    NAMEROW("INTDR") = 0
                    NAMEROW("INTCR") = 0
                End If

                NAMEROW("TOPAY") = Val(GTOPAY.SummaryText)
                NAMEROW("TOREC") = Val(GTOREC.SummaryText)
                If lbldrcrclosing.Text = "Dr" Then
                    NAMEROW("INTDR") = Val(txttotal.Text.Trim)
                Else
                    NAMEROW("INTCR") = Val(txttotal.Text.Trim)
                End If
                GRIDNAMEREGISTER.RefreshData()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "Group_name"
                cmbgroup.DataSource = dt
                cmbgroup.DisplayMember = "group_name"
                cmbgroup.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalc_Summary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim OBJINTCALC As New ClsInterestCalc
            Dim ALPARAVAL As New ArrayList
            If CHKDATE.CheckState = CheckState.Checked Then ALPARAVAL.Add("Interest Summary From : " & Format(dtfrom.Value.Date, "dd/MM/yyyy").ToString & " To " & Format(dtto.Value.Date, "dd/MM/yyyy").ToString) Else ALPARAVAL.Add("Interest Summary From : " & Format(AccFrom, "dd/MM/yyyy").ToString & " To " & Format(AccTo, "dd/MM/yyyy").ToString)

            Dim INTPER As String = ""
            Dim NAME As String = ""
            Dim DRBAL As String = ""
            Dim CRBAL As String = ""
            Dim INTREC As String = ""
            Dim INTPAY As String = ""
            Dim TDSPER As String = ""
            Dim TDSAMT As String = ""
            Dim TDSFORM As String = ""
            Dim PANNO As String = ""
            Dim GROUPNAME As String = ""
            Dim LINENO As String = ""
            Dim SIDEINT As String = ""
            Dim TOTALINT As String = ""


            Dim OBJCMN As New ClsCommon
            Dim DTTDS As New DataTable
            For I As Integer = 0 To GRIDNAMEREGISTER.RowCount - 1

                Dim DTROW As DataRow = GRIDNAMEREGISTER.GetDataRow(I)
                'GET TDS FROM LEDGERS
                DTTDS = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER, ISNULL(ACC_TDSFORM,'TDS') AS TDSFORM ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.Acc_id = ACCOUNTSMASTER_TDS.ACC_ID  ", " AND ACC_CMPNAME = '" & DTROW("NAME") & "' AND LEDGERS.ACC_YEARID = " & YearId)

                If NAME = "" Then
                    INTPER = Val(DTROW("INTPER"))
                    NAME = DTROW("NAME")
                    If Val(DTROW("DEBIT")) > Val(DTROW("CREDIT")) Then DRBAL = Val(DTROW("NETTBALANCE")) Else DRBAL = "0"
                    If Val(DTROW("CREDIT")) > Val(DTROW("DEBIT")) Then CRBAL = Val(DTROW("NETTBALANCE")) Else CRBAL = "0"
                    INTREC = Val(DTROW("INTDR"))
                    INTPAY = Val(DTROW("INTCR"))
                    If DTTDS.Rows.Count > 0 Then
                        TDSPER = Val(DTTDS.Rows(0).Item(0))
                        If Val(DTROW("INTDR")) > 0 Then TDSAMT = Format(((Val(DTROW("INTDR")) * Val(DTTDS.Rows(0).Item(0))) / 100), "0") Else TDSAMT = Format(((Val(DTROW("INTCR")) * Val(DTTDS.Rows(0).Item(0))) / 100), "0")
                        TDSFORM = DTTDS.Rows(0).Item("TDSFORM")
                    Else
                        TDSPER = "0"
                        TDSAMT = "0"
                        TDSFORM = "TDS"
                    End If
                    PANNO = DTROW("PANNO")
                    GROUPNAME = DTROW("GROUPNAME")
                    LINENO = Val(I) + 1
                    SIDEINT = Val(DTROW("SIDEINT"))
                    TOTALINT = Val(DTROW("TOTALINT"))
                Else
                    INTPER = INTPER & "|" & Val(DTROW("INTPER"))
                    NAME = NAME & "|" & DTROW("NAME")
                    If Val(DTROW("DEBIT")) > Val(DTROW("CREDIT")) Then DRBAL = DRBAL & "|" & Val(DTROW("NETTBALANCE")) Else DRBAL = DRBAL & "|" & "0"
                    If Val(DTROW("CREDIT")) > Val(DTROW("DEBIT")) Then CRBAL = CRBAL & "|" & Val(DTROW("NETTBALANCE")) Else CRBAL = CRBAL & "|" & "0"
                    INTREC = INTREC & "|" & Val(DTROW("INTDR"))
                    INTPAY = INTPAY & "|" & Val(DTROW("INTCR"))
                    If DTTDS.Rows.Count > 0 Then
                        TDSPER = TDSPER & "|" & Val(DTTDS.Rows(0).Item(0))
                        If Val(DTROW("INTDR")) > 0 Then TDSAMT = TDSAMT & "|" & Format(((Val(DTROW("INTDR")) * Val(DTTDS.Rows(0).Item(0))) / 100), "0") Else TDSAMT = TDSAMT & "|" & Format(((Val(DTROW("INTCR")) * Val(DTTDS.Rows(0).Item(0))) / 100), "0")
                        TDSFORM = TDSFORM & "|" & DTTDS.Rows(0).Item("TDSFORM")
                    Else
                        TDSPER = TDSPER & "|" & "0"
                        TDSAMT = TDSAMT & "|" & "0"
                        TDSFORM = TDSFORM & "|" & "TDS"
                    End If
                    PANNO = PANNO & "|" & DTROW("PANNO")
                    GROUPNAME = GROUPNAME & "|" & DTROW("GROUPNAME")
                    LINENO = LINENO & "|" & Val(I) + 1
                    SIDEINT = SIDEINT & "|" & Val(DTROW("SIDEINT"))
                    TOTALINT = TOTALINT & "|" & Val(DTROW("TOTALINT"))
                End If

            Next

            ALPARAVAL.Add(INTPER)
            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(DRBAL)
            ALPARAVAL.Add(CRBAL)
            ALPARAVAL.Add(INTREC)
            ALPARAVAL.Add(INTPAY)
            ALPARAVAL.Add(TDSPER)
            ALPARAVAL.Add(TDSAMT)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(TDSFORM)
            ALPARAVAL.Add(PANNO)
            ALPARAVAL.Add(GROUPNAME)
            ALPARAVAL.Add(LINENO)
            ALPARAVAL.Add(SIDEINT)
            ALPARAVAL.Add(TOTALINT)

            OBJINTCALC.alParaval = ALPARAVAL
            OBJINTCALC.SAVE()


            Dim OBJPLPRINT As New PLDesign
            OBJPLPRINT.MdiParent = MDIMain
            OBJPLPRINT.frmstring = "INTERESTSUMM"
            OBJPLPRINT.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDNAMEDETAILS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDNAMEDETAILS.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class