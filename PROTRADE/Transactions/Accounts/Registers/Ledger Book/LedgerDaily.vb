
Imports BL

Public Class LedgerDaily

    Public FromDate As Date
    Public ToDate As Date

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsLedgerBook

        ALPARAVAL.Add(cmbname.Text.Trim)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(AccFrom)
            'COZ DATE WONT BE IN ACCOUNTING YEAR
            If CmpName = "TRANSFER DATA" Then
                ALPARAVAL.Add(Now.Date)
            Else
                ALPARAVAL.Add(AccTo)
            End If
        End If

       ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        dt = objregister.GETDAILY
        griddetails.DataSource = dt


        'getting opening balances
        Dim OBJCOMMON As New ClsCommonMaster
        If chkdate.CheckState = CheckState.Unchecked Then
            dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(AccFrom, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        ElseIf chkdate.CheckState = CheckState.Checked Then
            dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        End If

        If dt.Rows.Count > 0 Then
            If Val(dt.Rows(0).Item(0).ToString) < 0 Then
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
                lbldrcropening.Text = "Cr"
            Else
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                lbldrcropening.Text = "Dr"
            End If
        End If


        'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
        'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
        If Val(txtopening.Text.Trim) = 0 Then
            dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                If dt.Rows(0).Item(1).ToString = "Dr." Then
                    lbldrcropening.Text = "Dr"
                Else
                    lbldrcropening.Text = "Cr"
                End If
            End If
        End If

        total()
        txtopening.Text = Format(Val(txtopening.Text), "0.00")
    End Sub

    Sub total()
        Try
            txttotal.Text = 0.0
            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")

            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double
            If lbldrcropening.Text = "Dr" Then
                RUNNINGBAL = Val(txtopening.Text)
            Else
                RUNNINGBAL = Val(txtopening.Text) * (-1)
            End If

            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("RUNNINGBAL") = (Val(dtrow("Debit")) + Val(RUNNINGBAL)) - Val(dtrow("Credit"))
                RUNNINGBAL = dtrow("RUNNINGBAL")
            Next

            'txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")

            'If chkdate.CheckState = CheckState.Checked Then
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If
            'End If

            'calculating total
            If Val(txttotal.Text) < 0 Then
                txttotal.Text = Format(Val(txttotal.Text) * (-1), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                lbldrcrclosing.Text = "Dr"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and ledgers.acc_cmpname = '" & cmbname.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerDaily_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.F8 Then
                Dim objlb As New RegisterDetails
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                Dim objlb As New LedgerBillwise
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F7 Then
                Dim objlb As New LedgerMonthly
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                Me.Close()
                objlb.Show()
            End If
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

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ledger Book Daily.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If


            opti.SheetName = "Ledger Book Daily"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ledger Book Daily", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

        Catch ex As Exception
            MsgBox("Ledger Book Daily Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLBILL.Click
        Try
            Dim objlb As New LedgerBillwise
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMONTHLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMONTHLY.Click
        Try
            Dim objlb As New LedgerMonthly
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDETAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDETAIL.Click
        Try
            Dim objlb As New REgisterDetails
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerDaily_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class