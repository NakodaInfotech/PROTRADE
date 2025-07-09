
Imports BL

Public Class CashRegisterDaily

    Public CASHNAME As String
    Public FromDate As Date
    Public ToDate As Date

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CashRegisterDaily_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F2 Then
                Call TOOLDETAILS_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashRegisterDaily_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtfrom.Enabled = False
            dtto.Enabled = False
            chkdate.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsCashRegister

        ALPARAVAL.Add(CASHNAME)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(FromDate)
            ALPARAVAL.Add(ToDate)
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
            dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CASHNAME & "' and acc_billdate <'" & Format(FromDate, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        Else
            dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CASHNAME & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
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
            dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & CASHNAME & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
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


            'If Val(txtdrtotal.Text) > Val(txtcrtotal.Text) Then
            '    txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")
            '    lbldrcrclosing.Text = "Dr"
            'Else
            '    txttotal.Text = Format(Val(txtcrtotal.Text) - Val(txtdrtotal.Text), "0.00")
            '    lbldrcrclosing.Text = "Cr"
            'End If

            'Dim dtrow As DataRow
            'Dim i As Integer


            'For i = 0 To gridregister.RowCount - 1
            '    dtrow = gridregister.GetDataRow(i)
            '    txtdrtotal.Text = Format(Val(txtdrtotal.Text) + Val(dtrow(4).ToString), "0.00")
            '    txtcrtotal.Text = Format(Val(txtcrtotal.Text) + Val(dtrow(5).ToString), "0.00")
            'Next

            'txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If

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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Cash Register (Daily).XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Cash Register (Daily)"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Cash Register (Daily)", gridregister.VisibleColumns.Count + gridregister.GroupCount, CASHNAME, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

        Catch ex As Exception
            MsgBox("Cash Register Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDETAILS.Click
        Try
            Dim OBJCASH As New CashRegisterDetails
            OBJCASH.CashName = CASHName
            OBJCASH.FromDate = FromDate
            OBJCASH.ToDate = ToDate
            OBJCASH.MdiParent = MDIMain
            OBJCASH.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashRegisterDaily_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class