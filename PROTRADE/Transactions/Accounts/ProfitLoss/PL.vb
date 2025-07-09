
Imports BL

Public Class PL

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProfitLoss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJPL As New ClsProfitLoss
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable
            Dim OBJCMN As New ClsCommon

            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJPL.alParaval = ALPARAVAL


            'CODE BY GULKIT
            'GET OPSTOCK
            Dim OPSTOCK, CLOSTOCK As Double
            OPSTOCK = 0
            CLOSTOCK = 0


            'IF DATE IS CHECKED THEN WE NEED TO GET THE PROVISIONAL CLOSING STOCK VALUE WITH RESPECT TO TILL DATE
            Dim OPSTOCKDT As DataTable = OBJCMN.search(" ISNULL(OPENINGSTOCK,0) AS OPENINGSTOCK, ISNULL(CLOSINGSTOCK,0) AS CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & YearId)
            If OPSTOCKDT.Rows.Count > 0 Then
                OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OPENINGSTOCK"))
                CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("CLOSINGSTOCK"))
            End If
            'IF DATE IS CHECKED THEN CHANGE CLOSING STOCK VALUE 
            If chkdate.Checked = True Then
                OPSTOCKDT = OBJCMN.search(" ISNULL(BS_APRIL,'') AS APRIL,  ISNULL(BS_MAY,'') AS MAY, ISNULL(BS_JUNE,'') AS JUNE, ISNULL(BS_JULY,'') AS JULY, ISNULL(BS_AUGUST,'') AS AUGUST, ISNULL(BS_SEPTEMBER,'') AS SEPTEMBER, ISNULL(BS_OCTOBER,'') AS OCTOBER , ISNULL(BS_NOVEMBER,'') AS NOVEMBER, ISNULL(BS_DECEMBER,'') AS DECEMBER, ISNULL(BS_JANUARY,'') AS JANUARY, ISNULL(BS_FABRUARY,'') AS FEBRUARY, ISNULL(BS_MARCH,'') AS MARCH ", "", " PROVISIONALBS ", " AND BS_YEARID = " & YearId)
                If OPSTOCKDT.Rows.Count > 0 Then


                    'FOR OPENINGSTOCK
                    If Month(dtfrom.Value) = 5 Then
                        If Val(OPSTOCKDT.Rows(0).Item("APRIL")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("APRIL"))
                    End If
                    If Month(dtfrom.Value) = 6 Then
                        If Val(OPSTOCKDT.Rows(0).Item("MAY")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("MAY"))
                    End If
                    If Month(dtfrom.Value) = 7 Then
                        If Val(OPSTOCKDT.Rows(0).Item("JUNE")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("JUNE"))
                    End If
                    If Month(dtfrom.Value) = 8 Then
                        If Val(OPSTOCKDT.Rows(0).Item("JULY")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("JULY"))
                    End If
                    If Month(dtfrom.Value) = 9 Then
                        If Val(OPSTOCKDT.Rows(0).Item("AUGUST")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("AUGUST"))
                    End If
                    If Month(dtfrom.Value) = 10 Then
                        If Val(OPSTOCKDT.Rows(0).Item("SEPTEMBER")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("SEPTEMBER"))
                    End If
                    If Month(dtfrom.Value) = 11 Then
                        If Val(OPSTOCKDT.Rows(0).Item("OCTOBER")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OCTOBER"))
                    End If
                    If Month(dtfrom.Value) = 12 Then
                        If Val(OPSTOCKDT.Rows(0).Item("NOVEMBER")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("NOVEMBER"))
                    End If
                    If Month(dtfrom.Value) = 1 Then
                        If Val(OPSTOCKDT.Rows(0).Item("DECEMBER")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("DECEMBER"))
                    End If
                    If Month(dtfrom.Value) = 2 Then
                        If Val(OPSTOCKDT.Rows(0).Item("JANUARY")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("JANUARY"))
                    End If
                    If Month(dtfrom.Value) = 3 Then
                        If Val(OPSTOCKDT.Rows(0).Item("FEBRUARY")) > 0 Then OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("FEBRUARY"))
                    End If



                    'FOR CLOSING STOCK
                    If Month(dtto.Value) = 4 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("APRIL"))
                    If Month(dtto.Value) = 5 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("MAY"))
                    If Month(dtto.Value) = 6 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("JUNE"))
                    If Month(dtto.Value) = 7 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("JULY"))
                    If Month(dtto.Value) = 8 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("AUGUST"))
                    If Month(dtto.Value) = 9 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("SEPTEMBER"))
                    If Month(dtto.Value) = 10 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("OCTOBER"))
                    If Month(dtto.Value) = 11 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("NOVEMBER"))
                    If Month(dtto.Value) = 12 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("DECEMBER"))
                    If Month(dtto.Value) = 1 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("JANUARY"))
                    If Month(dtto.Value) = 2 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("FEBRUARY"))
                    If Month(dtto.Value) = 3 Then CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("MARCH"))
                End If
            End If



            If chkcondensed.CheckState = CheckState.Checked Then

                DT = OBJPL.GETSUMMARY()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '*****************************************************************
                    '*****************************************************************
                    Dim i As Integer

                    If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

                        gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                        gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00", CLOSTOCK)
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                    End If



                    If DTROW(0) = "Gross Profit C/O" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "Indirect Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Indirect Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                Next

            ElseIf chkdetails.CheckState = CheckState.Checked Then

                DT = OBJPL.GETDETAILS()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1
                Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS, TOTALNETTPROFIT, TOTALNETTLOSS As Double

                TOTALDREXP += OPSTOCK

                gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                gridexpenses.Rows.Insert(1, "", "")


                Dim i As Integer = 1
                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '*****************************************************************
                '*****************************************************************



                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALCRINC += CLOSTOCK

                gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00", CLOSTOCK)
                gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
                    TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
                    TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''**************************************************************************************



                '***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************



                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

                If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''*************************************************************************


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALDREXP = 0
                TOTALCREXP = 0
                TOTALDRINC = 0
                TOTALCRINC = 0


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Indirect Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                    gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
                    TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                Else
                    gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
                    TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                End If
                ''***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************

            ElseIf CHKLEDGER.CheckState = CheckState.Checked Then

                DT = OBJPL.GETLEDGER()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1
                Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS, TOTALNETTPROFIT, TOTALNETTLOSS As Double



                gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                gridexpenses.Rows.Insert(1, "", "")

                TOTALDREXP += OPSTOCK

                Dim i As Integer = 1
                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '*****************************************************************
                '*****************************************************************



                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                TOTALCRINC += CLOSTOCK

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "Closing Stock", 0.0, CLOSTOCK)
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
                    TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Loss C/O", "", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
                    TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''**************************************************************************************



                '***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("Total", "", Val((TOTALCRINC - TOTALDRINC)))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************



                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

                If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Profit B/F", "", Val(TOTALGROSSPROFIT))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''*************************************************************************


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALDREXP = 0
                TOTALCREXP = 0
                TOTALDRINC = 0
                TOTALCRINC = 0


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Indirect Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                    gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
                    TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                Else
                    gridincome.Rows.Add("Nett Loss", "", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
                    TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                End If
                ''***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("G Total", "", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function SPACER(ByVal LEVEL As Integer) As String
        Dim SPACE As String = ""
        Dim I As Integer = 0
        For I = 0 To LEVEL
            SPACE = SPACE & "   "
        Next
        Return SPACE
    End Function

    Private Sub gridexpenses_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.CellDoubleClick
        Try
            showform(gridexpenses.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridexpenses_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridincome.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridexpenses_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridexpenses.Scroll
        gridincome.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub gridincome_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.CellDoubleClick
        Try
            showform(gridincome.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridincome_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridexpenses.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridincome_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridincome.Scroll
        gridexpenses.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        If chkcondensed.CheckState = CheckState.Checked Or chkdetails.CheckState = CheckState.Checked Or CHKLEDGER.CheckState = CheckState.Checked Then fillgrid()
    End Sub

    Sub showform(ByVal name As String)
        Try
            If name <> "" Then
                Dim objlb As New RegisterDetails
                objlb.cmbname.Text = name
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkcondensed_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcondensed.CheckStateChanged
        Try
            'If chkcondensed.CheckState = CheckState.Checked Then
            '    chkdetails.CheckState = CheckState.Unchecked
            'Else
            '    chkdetails.CheckState = CheckState.Checked
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdetails_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdetails.CheckStateChanged
        Try
            'If chkdetails.CheckState = CheckState.Checked Then
            '    chkcondensed.CheckState = CheckState.Unchecked
            'Else
            '    chkcondensed.CheckState = CheckState.Checked
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim OBJPL As New ClsProfitLoss
            OBJPL.DELETE(CmpId)

            For I As Integer = 0 To gridexpenses.RowCount - 2

                Dim ALPARAVAL As New ArrayList
                If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "===========================" And gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "" Then
                    If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridexpenses.Rows(I).Cells(GEXPDR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridexpenses.Rows(I).Cells(GEXPDR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridexpenses.Rows(I).Cells(GEXPCR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridexpenses.Rows(I).Cells(GEXPCR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                '----------------------------------------------------------------------------------
                If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "===========================" And gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "" Then
                    If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridincome.Rows(I).Cells(GINCNAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridincome.Rows(I).Cells(GINCDR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridincome.Rows(I).Cells(GINCDR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridincome.Rows(I).Cells(GINCCR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridincome.Rows(I).Cells(GINCCR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(I)


                If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "===========================" And gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "" Then
                    If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> Nothing Then
                        If gridexpenses.Rows(I).DefaultCellStyle.ForeColor = Color.Empty Then
                            ALPARAVAL.Add(0)
                        Else
                            ALPARAVAL.Add(1)
                        End If
                    End If
                Else
                    ALPARAVAL.Add(0)
                End If

                If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "===========================" And gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "" Then
                    If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> Nothing Then
                        If gridincome.Rows(I).DefaultCellStyle.ForeColor <> Color.Empty Then
                            ALPARAVAL.Add(1)
                        Else
                            ALPARAVAL.Add(0)
                        End If
                    End If
                Else
                    ALPARAVAL.Add(0)
                End If


                OBJPL.alParaval = ALPARAVAL
                OBJPL.SAVE()

            Next

            Dim OBJPLPRINT As New PLDesign
            OBJPLPRINT.MdiParent = MDIMain
            OBJPLPRINT.frmstring = "PROFITLOSS"
            If chkdate.CheckState = CheckState.Unchecked Then OBJPLPRINT.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy") Else OBJPLPRINT.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
            OBJPLPRINT.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PL_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class