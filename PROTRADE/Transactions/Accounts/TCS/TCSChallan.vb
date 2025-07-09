
Imports BL

Public Class TCSChallan

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsTCSChallan

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

        objregister.alParaval = ALPARAVAL
        If CHKUNPAID.Checked = True Then
            dt = objregister.GETUNPAID
        ElseIf CHKUNPAID.Checked = False Then
            dt = objregister.GETALL
        End If

        griddetails.DataSource = dt

    End Sub

    Private Sub TCSChallan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TCSChallan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cmbname.SelectedIndex = 0
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKUNPAID.CheckedChanged
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            Dim OBJTDS As New ClsTCSChallan

            Dim INTRESULT As Integer

            Dim BILLINITIALS As String = ""
            Dim BILLNO As String = ""
            Dim REGISTERID As String = ""
            Dim BILLDATE As String = ""
            Dim CHALLANNO As String = ""
            Dim CHALLANDATE As String = ""
            Dim CHQNO As String = ""
            Dim BANKNAME As String = ""

            If gridregister.FilterPanelText <> "" Then gridregister.ActiveFilterEnabled = False

            For i As Integer = 0 To gridregister.DataRowCount - 1
                Dim dtrow As DataRow = gridregister.GetDataRow(i)
                If dtrow("CHALLANNO").ToString.Trim <> "" Then

                    If BILLNO = "" Then
                        BILLINITIALS = dtrow("BILLINITIALS")
                        BILLNO = Val(dtrow("BILLNO"))
                        REGISTERID = Val(dtrow("REGISTERID"))
                        BILLDATE = Format(Convert.ToDateTime(dtrow("DATE")).Date, "MM/dd/yyyy")
                        CHALLANNO = dtrow("CHALLANNO").ToString
                        CHALLANDATE = Format(Convert.ToDateTime(dtrow("CHALLANDATE")).Date, "MM/dd/yyyy")
                        CHQNO = dtrow("CHQNO").ToString
                        BANKNAME = dtrow("BANKNAME").ToString
                    Else
                        BILLINITIALS = BILLINITIALS & "|" & dtrow("BILLINITIALS")
                        BILLNO = BILLNO & "|" & Val(dtrow("BILLNO"))
                        REGISTERID = REGISTERID & "|" & Val(dtrow("REGISTERID"))
                        BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(dtrow("DATE")).Date, "MM/dd/yyyy")
                        CHALLANNO = CHALLANNO & "|" & dtrow("CHALLANNO").ToString
                        CHALLANDATE = CHALLANDATE & "|" & Format(Convert.ToDateTime(dtrow("CHALLANDATE")).Date, "MM/dd/yyyy")
                        CHQNO = CHQNO & "|" & dtrow("CHQNO").ToString
                        BANKNAME = BANKNAME & "|" & dtrow("BANKNAME").ToString
                    End If

                End If
            Next

            ALPARAVAL.Add(cmbname.Text.Trim)
            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If

            ALPARAVAL.Add(BILLINITIALS)
            ALPARAVAL.Add(BILLNO)
            ALPARAVAL.Add(REGISTERID)
            ALPARAVAL.Add(BILLDATE)
            ALPARAVAL.Add(CHALLANNO)
            ALPARAVAL.Add(CHALLANDATE)
            ALPARAVAL.Add(CHQNO)
            ALPARAVAL.Add(BANKNAME)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(CHKUNPAID.Checked)

            OBJTDS.alParaval = ALPARAVAL
            INTRESULT = OBJTDS.SAVE()
            MsgBox("Details Saved")

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Challan Details"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD)

        Catch ex As Exception
            MsgBox("TCS Challan Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub griddetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles griddetails.KeyDown
        Try
            If e.KeyCode = Keys.F12 And gridregister.FocusedRowHandle - 1 >= 0 Then
                'COPY DATA FROM UPPER LINE

                Dim DTROWUP As DataRow = gridregister.GetDataRow(gridregister.FocusedRowHandle - 1)
                Dim DTROW As DataRow = gridregister.GetFocusedDataRow
                DTROW("CHALLANNO") = DTROWUP("CHALLANNO")
                DTROW("CHALLANDATE") = DTROWUP("CHALLANDATE")
                DTROW("CHQNO") = DTROWUP("CHQNO")
                DTROW("BANKNAME") = DTROWUP("BANKNAME")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDAPPLY_Click(sender As Object, e As EventArgs) Handles CMDAPPLY.Click
        Try

            If TXTCHNO.Text.Trim <> "" And TXTBSRCODE.Text.Trim <> "" Then
                If MsgBox("Apply Data for all records?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                For i As Integer = 0 To gridregister.DataRowCount - 1
                    Dim dtrow As DataRow = gridregister.GetDataRow(i)
                    dtrow("CHALLANNO") = TXTCHNO.Text.Trim
                    dtrow("CHALLANDATE") = CHDATE.Value.Date
                    dtrow("CHQNO") = TXTCHQNO.Text.Trim
                    dtrow("BANKNAME") = TXTBSRCODE.Text.Trim
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class