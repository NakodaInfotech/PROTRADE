
Imports BL

Public Class TB

    Sub FILLGRID()
        Try
            Dim totaldr, totalcr, TOTALOPBALDR, TOTALOPBALCR As Double
            gridtrialbalance.RowCount = 1
            Dim OBJTB As New ClsTrialBalance
            Dim ALPARAVAL As New ArrayList

            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJTB.alParaval = ALPARAVAL

            If chkdetails.CheckState = CheckState.Checked Then

                Dim DT As DataTable = OBJTB.GETDETAILSRND

                For Each DTROW As DataRow In DT.Rows
                    If (Val(DTROW("DR")) - Val(DTROW("CR"))) > 0 Or (Val(DTROW("DR")) - Val(DTROW("CR"))) < 0 Or Val(DTROW("OPBALDR")) > 0 Or Val(DTROW("OPBALCR")) > 0 Then
                        Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))
                        If chkopbal.Checked = False Then
                            If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                                gridtrialbalance.Rows.Add(DTROW("PRIMARYGP"), "", "", "", DTROW("DR"), DTROW("CR"), "")
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)

                                TOTALOPBALDR += Val(DTROW("OPBALDR"))
                                TOTALOPBALCR += Val(DTROW("OPBALCR"))

                                totaldr += Val(DTROW("DR"))
                                totalcr += Val(DTROW("CR"))

                            ElseIf DTROW("NAME").ToString.Trim <> "" Then
                                gridtrialbalance.Rows.Add(SPACE & "     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
                            Else
                                If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                                gridtrialbalance.Rows.Add(SPACE & DTROW("GPNAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)
                            End If
                        Else
                            If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                                gridtrialbalance.Rows.Add(DTROW("PRIMARYGP"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), "")
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)

                                TOTALOPBALDR += Val(DTROW("OPBALDR"))
                                TOTALOPBALCR += Val(DTROW("OPBALCR"))

                                totaldr += Val(DTROW("DR"))
                                totalcr += Val(DTROW("CR"))

                            ElseIf DTROW("NAME").ToString.Trim <> "" Then
                                gridtrialbalance.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
                            Else
                                If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                                gridtrialbalance.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)
                            End If
                        End If
                    End If
                        'End If
                Next
                '    End If
                'Next
                'DISPLAYING TOTALS
                'Dim dtTotalSum As New DataTable()
                'dtTotalSum = GroupBy("", "DR", "CR", DT)
                gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
                gridtrialbalance.Rows.Add("TOTAL", TOTALOPBALDR, TOTALOPBALCR, "", totaldr, totalcr, "")
                gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
            Else
                Dim DT As DataTable = OBJTB.GETSUMMARY()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("         " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            End If
                        Else
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
                    gridtrialbalance.Rows.Add("TOTAL", "", "", "", totaldr, totalcr, "")
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDOPCLOSING()
        Try
            Dim totaldr, totalcr, TOTALOPBALDR, TOTALOPBALCR, TOTALCLODR, TOTALCLOCR As Double
            gridopclo.RowCount = 1
            Dim OBJTB As New ClsTrialBalance
            Dim ALPARAVAL As New ArrayList

            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJTB.alParaval = ALPARAVAL

            If chkdetails.CheckState = CheckState.Checked Then

                Dim DT As DataTable = OBJTB.GETDETAILSOPCLOSINGRND

                For Each DTROW As DataRow In DT.Rows
                    'If (Val(DTROW("DR")) - Val(DTROW("CR"))) > 0 Or (Val(DTROW("DR")) - Val(DTROW("CR"))) < 0 Or Val(DTROW("OPBALDR")) > 0 Or Val(DTROW("OPBALCR")) > 0 Then
                    'GET ALL THE NAMES'
                    'If Val(DTROW("DR")) > 0 Or Val(DTROW("CR")) > 0 Or Val(DTROW("OPBALDR")) > 0 Or Val(DTROW("OPBALCR")) > 0 Then
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))
                    If chkopbal.Checked = False Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridopclo.Rows.Add(DTROW("PRIMARYGP"), "", "", "", DTROW("DR"), DTROW("CR"), "", DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)

                            TOTALOPBALDR += Val(DTROW("OPBALDR"))
                            TOTALOPBALCR += Val(DTROW("OPBALCR"))

                            totaldr += Val(DTROW("DR"))
                            totalcr += Val(DTROW("CR"))

                            TOTALCLODR += Val(DTROW("CLOBALDR"))
                            TOTALCLOCR += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridopclo.Rows.Add(SPACE & "     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridopclo.Rows.Add(SPACE & DTROW("GPNAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)
                        End If
                    Else
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridopclo.Rows.Add(DTROW("PRIMARYGP"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), "", DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)

                            TOTALOPBALDR += Val(DTROW("OPBALDR"))
                            TOTALOPBALCR += Val(DTROW("OPBALCR"))

                            totaldr += Val(DTROW("DR"))
                            totalcr += Val(DTROW("CR"))

                            TOTALCLODR += Val(DTROW("CLOBALDR"))
                            TOTALCLOCR += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridopclo.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridopclo.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 9, FontStyle.Bold)
                        End If
                    End If
                    'End If
                    'End If
                Next
                '    End If
                'Next
                'DISPLAYING TOTALS
                'Dim dtTotalSum As New DataTable()
                'dtTotalSum = GroupBy("", "DR", "CR", DT)
                gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "===============")
                gridopclo.Rows.Add("TOTAL", TOTALOPBALDR, TOTALOPBALCR, "", totaldr, totalcr, "", TOTALCLODR, TOTALCLOCR)
                gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "===============")
            Else
                Dim DT As DataTable = OBJTB.GETSUMMARY()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                                End If
                            End If
                        Else
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "===============")
                    gridopclo.Rows.Add("TOTAL", "", "", "", totaldr, totalcr, "")
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "===============")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function GroupBy(ByVal i_sGroupByColumn As String, ByVal i_sAggregateColumn1 As String, ByVal i_sAggregateColumn2 As String, ByVal i_dSourceTable As DataTable) As DataTable
        Try

            Dim dv As New DataView(i_dSourceTable)

            'getting distinct values for group column
            Dim dtGroup As New DataTable
            If i_sGroupByColumn.Trim.Length > 0 Then
                dtGroup = dv.ToTable(True, New String() {i_sGroupByColumn})
            End If
            'adding column for the row count
            dtGroup.Columns.Add("Sum_DR", GetType(Double))
            dtGroup.Columns.Add("Sum_CR", GetType(Double))
            'Dim tempDataSourceTable As DataTable = i_dSourceTable.
            'looping thru distinct values for the group, counting
            If dtGroup.Rows.Count > 0 Then
                For Each dr As DataRow In dtGroup.Rows
                    dr("Sum_DR") = i_dSourceTable.Compute("Sum(" & i_sAggregateColumn1 & ")", i_sGroupByColumn & " = '" & dr(i_sGroupByColumn) & "' And Name = '' AND LEVELNO <= 1 ")
                    dr("Sum_CR") = i_dSourceTable.Compute("Sum(" & i_sAggregateColumn2 & ")", i_sGroupByColumn & " = '" & dr(i_sGroupByColumn) & "' And Name = '' AND LEVELNO <= 1 ")
                Next
            Else
                dtGroup.Rows.Add.Item("Sum_DR") = 0
                dtGroup.Rows.Add.Item("Sum_CR") = 0
                dtGroup.Rows(0).Item("Sum_DR") = i_dSourceTable.Compute("Sum(" & i_sAggregateColumn1 & ")", "Name = ''")
                dtGroup.Rows(0).Item("Sum_CR") = i_dSourceTable.Compute("Sum(" & i_sAggregateColumn2 & ")", "Name = ''")
            End If
            'returning grouped/sum result
            Return dtGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function SPACER(ByVal LEVEL As Integer) As String
        Dim SPACE As String = ""
        Dim I As Integer = 0
        For I = 0 To LEVEL
            SPACE = SPACE & "   "
        Next
        Return SPACE
    End Function

    Private Sub TB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call CMDSHOWDETAILS_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        If chkopclosing.CheckState = CheckState.Checked Then
            Tabtb.Visible = False
            tabop.Visible = True
            cmdok.Location = New System.Drawing.Point(370, 542)
            cmdexit.Location = New System.Drawing.Point(448, 543)
            Me.Width = 898
            FILLGRIDOPCLOSING()
        Else
            Tabtb.Visible = True
            tabop.Visible = False
            Me.Width = 756
            cmdok.Location = New System.Drawing.Point(295, 542)
            cmdexit.Location = New System.Drawing.Point(373, 543)
            FILLGRID()
        End If
    End Sub

#Region "waste"
    'Dim dtUniqRecords As New DataTable()
    'dtUniqRecords = GroupBy("PRIMARYGP", "DR", "CR", DT)
    'For Each DTUNIQUE As DataRow In dtUniqRecords.Rows
    '    If (Val(DTUNIQUE("Sum_DR")) - Val(DTUNIQUE("Sum_CR"))) > 0 Or (Val(DTUNIQUE("Sum_DR")) - Val(DTUNIQUE("Sum_CR"))) < 0 Then
    '        gridtrialbalance.Rows.Add(DTUNIQUE("PRIMARYGP"), "", "", "", DTUNIQUE("Sum_DR"), DTUNIQUE("Sum_CR"), "")
    '        gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '        gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
    '        For Each DTROW As DataRow In DT.Rows
    '            If DTUNIQUE("PRIMARYGP").ToString = DTROW("PRIMARYGP").ToString Then
    '                If (Val(DTROW("DR")) - Val(DTROW("CR"))) > 0 Or (Val(DTROW("DR")) - Val(DTROW("CR"))) < 0 Then
    '                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))
    '                    If DTROW("NAME").ToString.Trim <> "" Then
    '                        gridtrialbalance.Rows.Add(SPACE & "     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
    '                        gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
    '                    Else
    '                        gridtrialbalance.Rows.Add(SPACE & DTROW("GPNAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GPNAME"))
    '                        gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                        gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
    '                    End If
    '                End If
    '            End If
    '        Next
    '    End If
    'Next
    ''DISPLAYING TOTALS
    'Dim dtTotalSum As New DataTable()
    'dtTotalSum = GroupBy("", "DR", "CR", DT)
    'gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
    'gridtrialbalance.Rows.Add("TOTAL", "", "", "", dtTotalSum.Rows(0).Item("Sum_DR"), dtTotalSum.Rows(0).Item("Sum_CR"), "")
    'gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
#End Region

    Private Sub chkcondensed_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcondensed.CheckStateChanged
        Try
            If chkcondensed.CheckState = CheckState.Checked Then
                chkdetails.CheckState = CheckState.Unchecked
                chkledger.CheckState = CheckState.Unchecked
            Else
                chkdetails.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdetails_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdetails.CheckStateChanged
        Try
            If chkdetails.CheckState = CheckState.Checked Then
                chkcondensed.CheckState = CheckState.Unchecked
            Else
                chkcondensed.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If tabop.Visible = False Then
                showform(gridtrialbalance.CurrentRow.Cells(GNAME.Index).Value.ToString.Trim)
            Else
                showform(gridopclo.CurrentRow.Cells(0).Value.ToString.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal name As String)
        Try
            Dim objlb As New RegisterDetails
            objlb.cmbname.Text = name
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridtrialbalance_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridtrialbalance.CellDoubleClick
        Try
            showform(gridtrialbalance.CurrentRow.Cells(GNAME.Index).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridopclo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridopclo.CellDoubleClick
        Try
            showform(gridopclo.CurrentRow.Cells(GOPCLNAME.Index).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim OBJTB As New ClsTrialBalance
            OBJTB.DELETE(CmpId)

            Dim SKIPROW As Boolean = False
            Dim SKIPNEXTLINE As Boolean = False

            If chkopclosing.CheckState = CheckState.Checked Then
                If gridopclo.RowCount > 0 Then

                    'THEY DONT NEED TO PRINT LEDGERS OF DEBTORS AND CREDITRS
                    If ClientName = "SAKARIA" AndAlso MsgBox("Show Debtors & Creditors Ledgers", MsgBoxStyle.YesNo) = MsgBoxResult.No Then SKIPROW = True

                    For Each ROW As DataGridViewRow In gridopclo.Rows
                        If ROW.Cells(GOPCLNAME.Index).Value <> "==================================" And ROW.Cells(GOPCLNAME.Index).Value <> "" Then
                            Dim ALPARAVAL As New ArrayList

                            If ROW.Cells(GOPCLNAME.Index).Value.ToString.Length < 11 Then SKIPNEXTLINE = False
                            If (SKIPNEXTLINE = True AndAlso ROW.Cells(GOPCLNAME.Index).Value.ToString.Substring(0, 11) <> "           ") Then
                                SKIPNEXTLINE = False
                            End If
                            If SKIPNEXTLINE = True Then GoTo SKIPLINE
                            If (ROW.Cells(GOPCLNAME.Index).Value = "       Sundry Creditors" Or ROW.Cells(GOPCLNAME.Index).Value = "       Sundry Debtors") And SKIPROW = True Then SKIPNEXTLINE = True

                            If ROW.Cells(GOPCLNAME.Index).Value <> Nothing Then
                                ALPARAVAL.Add(ROW.Cells(GOPCLNAME.Index).Value)
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPCLOPDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPCLOPDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPCLOPCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPCLOPCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPCLDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPCLDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPCLCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPCLCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GCLODR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GCLODR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GCLOCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GCLOCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If

                            ALPARAVAL.Add(CmpId)
                            ALPARAVAL.Add(ROW.Index)

                            OBJTB.alParaval = ALPARAVAL
                            OBJTB.SAVE()

                        End If
SKIPLINE:
                    Next
                End If
            Else
                If gridtrialbalance.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In gridtrialbalance.Rows
                        If ROW.Cells(GNAME.Index).Value <> "==================================" And ROW.Cells(GNAME.Index).Value <> "" Then
                            Dim ALPARAVAL As New ArrayList
                            If ROW.Cells(GNAME.Index).Value <> Nothing Then
                                ALPARAVAL.Add(ROW.Cells(GNAME.Index).Value)
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GOPCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GOPCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                            If ROW.Cells(GCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Val(ROW.Cells(GCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If

                            ALPARAVAL.Add(0)
                            ALPARAVAL.Add(0)
                            ALPARAVAL.Add(CmpId)
                            ALPARAVAL.Add(ROW.Index)

                            OBJTB.alParaval = ALPARAVAL
                            OBJTB.SAVE()
                        End If
                    Next
                End If
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish to Print in Excel?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                Dim OBJTBPRINT As New TrialBalanceDesign
                If chkopclosing.CheckState = CheckState.Unchecked Then OBJTBPRINT.frmstring = "TrialBalanceDetails"
                If chkdate.CheckState = CheckState.Checked Then OBJTBPRINT.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy") Else OBJTBPRINT.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy")
                OBJTBPRINT.MdiParent = MDIMain
                OBJTBPRINT.Show()
            Else
                TEMPMSG = MsgBox("Excel Printing will take some time to Open, Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJRPT As New clsReportDesigner("TRIAL-BALANCE", System.AppDomain.CurrentDomain.BaseDirectory & "TRIAL-BALANCE.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then OBJRPT.TRIALBALANCE_EXCEL("", dtfrom.Value.Date, dtto.Value.Date, CmpId, Locationid, YearId) Else OBJRPT.TRIALBALANCE_EXCEL("", AccFrom.Date, AccTo.Date, CmpId, Locationid, YearId)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TB_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class