
Imports BL

Public Class AgeingReport

    Public AGENTNAME As String = ""

    Private Sub LedgerDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            Dim CLAUSE1 As String = ""
            Dim CLAUSE2 As String = ""
            Dim CLAUSE3 As String = ""
            Dim CLAUSE4 As String = ""
            Dim CLAUSE5 As String = ""
            Dim CLAUSE6 As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DTDATA As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPAGEING WHERE YEARID = " & YearId, "", "")

            Dim WHERECLAUSE As String = " WHERE YEARID = " & YearId
            Dim REGWHERECLAUSE As String = " WHERE YEARID = " & YearId
            If chkdate.CheckState = CheckState.Checked Then
                WHERECLAUSE = WHERECLAUSE & " AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                REGWHERECLAUSE = REGWHERECLAUSE & " And ACC_BILLDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
            End If
            If RBREC.Checked = True Then
                REGWHERECLAUSE = REGWHERECLAUSE & " AND SECONDARY = 'Sundry Debtors'"
            Else
                REGWHERECLAUSE = REGWHERECLAUSE & " AND SECONDARY = 'Sundry Creditors'"
            End If

            If CMBAGENT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND AGENT = '" & CMBAGENT.Text.Trim & "'"

            If Val(TXTCOL1.Text.Trim) > 0 Then
                GCOL1.Visible = True
                GCOL1.VisibleIndex = 3
                GCOL1.Caption = TXTCOL1.Text.Trim
                DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING SELECT DISTINCT T.* FROM (SELECT GROUPNAME, NAME, 0 AS BALANCE, 0 AS ONACCOUNT, SUM(GRANDTOTAL) AS COL1, 0 AS COL2, 0 AS COL3, 0 AS COL4, 0 AS COL5, 0 AS COL6, BILLINITIALS, YEARID FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, NAME, YEARID, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) AS T INNER JOIN OUTSTANDINGREC ON T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS AND T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.DATE, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') < " & Val(TXTCOL1.Text.Trim) & "  ", "", "")
            End If

            If Val(TXTCOL2.Text.Trim) > 0 Then
                GCOL2.Visible = True
                GCOL2.VisibleIndex = 4
                GCOL2.Caption = TXTCOL2.Text.Trim
                DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING Select DISTINCT T.* FROM (Select GROUPNAME, Name, 0 As BALANCE, 0 As ONACCOUNT, 0 As COL1, SUM(GRANDTOTAL) As COL2, 0 As COL3, 0 As COL4, 0 As COL5, 0 AS COL6, BILLINITIALS, YearId FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, Name, YearId, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) As T INNER JOIN OUTSTANDINGREC On T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS And T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.Date, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') >= " & Val(TXTCOL1.Text.Trim) & " AND DATEDIFF(DAY,OUTSTANDINGREC.DATE, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') < " & Val(TXTCOL2.Text.Trim), "", "")
            End If

            If Val(TXTCOL3.Text.Trim) > 0 Then
                GCOL3.Visible = True
                GCOL3.VisibleIndex = 5
                GCOL3.Caption = TXTCOL3.Text.Trim
                DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING Select DISTINCT T.* FROM (Select GROUPNAME, Name, 0 As BALANCE, 0 As ONACCOUNT, 0 As COL1, 0 As COL2, SUM(GRANDTOTAL) As COL3, 0 As COL4, 0 As COL5, 0 AS COL6, BILLINITIALS, YearId FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, Name, YearId, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) As T INNER JOIN OUTSTANDINGREC On T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS And T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.Date, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') >= " & Val(TXTCOL2.Text.Trim) & " AND DATEDIFF(DAY,OUTSTANDINGREC.DATE, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') < " & Val(TXTCOL3.Text.Trim), "", "")
            End If

            If Val(TXTCOL4.Text.Trim) > 0 Then
                GCOL4.Visible = True
                GCOL4.VisibleIndex = 6
                GCOL4.Caption = TXTCOL4.Text.Trim
                DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING Select DISTINCT T.* FROM (Select GROUPNAME, Name, 0 As BALANCE, 0 As ONACCOUNT, 0 As COL1, 0 As COL2, 0 As COL3, SUM(GRANDTOTAL) As COL4, 0 As COL5, 0 AS COL6, BILLINITIALS, YearId FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, Name, YearId, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) As T INNER JOIN OUTSTANDINGREC On T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS And T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.Date, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') >= " & Val(TXTCOL3.Text.Trim) & " AND DATEDIFF(DAY,OUTSTANDINGREC.DATE, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') < " & Val(TXTCOL4.Text.Trim), "", "")
            End If

            If Val(TXTCOL5.Text.Trim) > 0 Then
                GCOL5.Visible = True
                GCOL5.VisibleIndex = 7
                GCOL5.Caption = TXTCOL5.Text.Trim
                DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING Select DISTINCT T.* FROM (Select GROUPNAME, Name, 0 As BALANCE, 0 As ONACCOUNT, 0 As COL1, 0 As COL2, 0 As COL3, 0 As COL4, SUM(GRANDTOTAL) As COL5, 0 AS COL6, BILLINITIALS, YearId FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, Name, YearId, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) As T INNER JOIN OUTSTANDINGREC On T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS And T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.Date, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') >= " & Val(TXTCOL4.Text.Trim) & " AND DATEDIFF(DAY,OUTSTANDINGREC.DATE, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') < " & Val(TXTCOL5.Text.Trim), "", "")
            End If


            'OPEN THIS COLUMN FOR GREATER THAN LAST COLUMN
            GCOL6.Visible = True
            GCOL6.VisibleIndex = 8
            Dim TEMPLASTCOL As Integer = 0
            If Val(TXTCOL5.Text.Trim) > 0 Then
                GCOL6.Caption = "> Then" & TXTCOL5.Text.Trim
                TEMPLASTCOL = Val(TXTCOL5.Text.Trim)
            ElseIf Val(TXTCOL4.Text.Trim) > 0 Then
                GCOL6.Caption = "> Then" & TXTCOL4.Text.Trim
                TEMPLASTCOL = Val(TXTCOL4.Text.Trim)
            ElseIf Val(TXTCOL3.Text.Trim) > 0 Then
                GCOL6.Caption = "> Then" & TXTCOL3.Text.Trim
                TEMPLASTCOL = Val(TXTCOL3.Text.Trim)
            ElseIf Val(TXTCOL2.Text.Trim) > 0 Then
                GCOL6.Caption = "> Then" & TXTCOL2.Text.Trim
                TEMPLASTCOL = Val(TXTCOL2.Text.Trim)
            ElseIf Val(TXTCOL1.Text.Trim) > 0 Then
                GCOL6.Caption = "> Then" & TXTCOL1.Text.Trim
                TEMPLASTCOL = Val(TXTCOL1.Text.Trim)
            End If
            DTDATA = OBJCMN.Execute_Any_String("INSERT INTO TEMPAGEING Select DISTINCT T.* FROM (Select GROUPNAME, Name, 0 As BALANCE, 0 As ONACCOUNT, 0 As COL1, 0 As COL2, 0 As COL3, 0 As COL4, 0 As COL5, SUM(GRANDTOTAL) AS COL6, BILLINITIALS, YearId FROM AGEINGREC " & WHERECLAUSE & " GROUP BY GROUPNAME, Name, YearId, BILLINITIALS HAVING(SUM(GRANDTOTAL) <> 0) ) As T INNER JOIN OUTSTANDINGREC On T.BILLINITIALS = OUTSTANDINGREC.BILLINITIALS And T.YEARID = OUTSTANDINGREC.YEARID WHERE DATEDIFF(DAY,OUTSTANDINGREC.Date, '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "') >= " & Val(TEMPLASTCOL), "", "")


            GONACCOUNT.VisibleIndex = 9




            Dim dt As DataTable = OBJCMN.search(" GROUPNAME , NAME,  SUM(BALANCE) AS BALANCE, SUM(ONACCOUNT) AS ONACCOUNT,  SUM(COL1) AS COL1, SUM(COL2)  AS COL2, SUM(COL3)  AS COL3, SUM(COL4) AS COL4, SUM(COL5) AS COL5, SUM(COL6) AS COL6 ", "", "(select group_name AS GROUPNAME, NAME, SUM(DR)-SUM(CR)  AS BALANCE, 0 AS ONACCOUNT, 0 AS COL1, 0 AS COL2, 0 AS COL3, 0 AS COL4, 0 AS COL5, 0 AS COL6 FROM REGISTER_GROUPED  " & REGWHERECLAUSE & " GROUP BY group_name ,name HAVING (CASE WHEN SUM(DR)-SUM(CR) > 0 THEN SUM(DR)-SUM(CR) ELSE SUM(CR)-SUM(DR) END) <>0 UNION ALL SELECT GROUPNAME, NAME, 0 AS BALANCE, SUM(ONACCOUNT), 0 AS COL1, 0 AS COL2, 0 AS COL3, 0 AS COL4, 0 AS COL5, 0 AS COL6 FROM AGEINGRECONACCOUNT " & WHERECLAUSE & " GROUP BY GROUPNAME, NAME UNION ALL SELECT GROUPNAME, NAME, BALANCE, ONACCOUNT, COL1, COL2, COL3, COL4, COL5, COL6 FROM TEMPAGEING WHERE YEARID = " & YearId & " ) AS T", " GROUP BY GROUPNAME,NAME HAVING SUM(BALANCE) <> 0 OR SUM(ONACCOUNT) <> 0")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ageing Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Ageing Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ageing Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TXTCOL1.Clear()
            TXTCOL2.Clear()
            TXTCOL3.Clear()
            TXTCOL4.Clear()
            TXTCOL5.Clear()

            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            If AGENTNAME <> "" Then CMBAGENT.Text = AGENTNAME
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(sender As Object, e As EventArgs) Handles CMDSHOWDETAILS.Click
        fillgrid()
    End Sub

    Private Sub TXTCOL1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCOL1.KeyPress, TXTCOL2.KeyPress, TXTCOL3.KeyPress, TXTCOL4.KeyPress, TXTCOL5.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCOL2_Validated(sender As Object, e As EventArgs) Handles TXTCOL2.Validated, TXTCOL2.Validated, TXTCOL3.Validated, TXTCOL4.Validated, TXTCOL5.Validated
        Try
            If Val(TXTCOL2.Text.Trim) > 0 AndAlso Val(TXTCOL2.Text.Trim) < Val(TXTCOL1.Text.Trim) Then
                MsgBox("Invalid Days", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTCOL3.Text.Trim) > 0 AndAlso Val(TXTCOL3.Text.Trim) < Val(TXTCOL2.Text.Trim) Then
                MsgBox("Invalid Days", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTCOL4.Text.Trim) > 0 AndAlso Val(TXTCOL4.Text.Trim) < Val(TXTCOL3.Text.Trim) Then
                MsgBox("Invalid Days", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Val(TXTCOL5.Text.Trim) > 0 AndAlso Val(TXTCOL5.Text.Trim) < Val(TXTCOL4.Text.Trim) Then
                MsgBox("Invalid Days", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class