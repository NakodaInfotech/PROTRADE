
Imports BL
Imports System.Windows.Forms

Public Class ContraDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim CONTRAREGID As Integer

    Private Sub ContraDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" dbo.CONTRA.CONTRA_no AS [Sr. No], dbo.Ledgers.acc_cmpname AS [Party Name] ,dbo.CONTRA.CONTRA_date AS [Date], sum(dbo.Contra.contra_credit) as Amount, dbo.Contra.contra_remarks AS [Remarks] ", "", "  dbo.CONTRA LEFT OUTER JOIN dbo.Ledgers ON dbo.CONTRA.CONTRA_cmpid = dbo.Ledgers.acc_cmpid AND dbo.CONTRA.CONTRA_LOCATIONid = dbo.Ledgers.acc_LOCATIONid AND dbo.CONTRA.CONTRA_YEARid = dbo.Ledgers.acc_YEARid AND dbo.CONTRA.CONTRA_ledgerid = dbo.Ledgers.acc_id  ", tempcondition & " group by dbo.CONTRA.CONTRA_no , dbo.Ledgers.acc_cmpname ,dbo.CONTRA.CONTRA_date ,  dbo.Contra.contra_remarks order by dbo.CONTRA.CONTRA_no")
            If dt.Rows.Count > 0 Then
                griddetails.DataSource = dt

                gridcontra.FocusedRowHandle = gridcontra.RowCount - 1
                gridcontra.TopRowIndex = gridcontra.RowCount - 15

            Else
                griddetails.DataSource = dt
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridcontra.RowCount > 0) Then
                Dim objcontramaster As New ContraEntry
                objcontramaster.MdiParent = MDIMain
                objcontramaster.edit = editval
                objcontramaster.tempcontrano = billno
                objcontramaster.TEMPREGNAME = cmbregister.Text.Trim
                objcontramaster.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridcontra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridcontra.DoubleClick
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.GotFocus
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'CONTRA'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    CONTRAREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.CONTRA.CONTRA_cmpid=" & CmpId & " and dbo.CONTRA.CONTRA_LOCATIONid=" & Locationid & " and dbo.CONTRA.CONTRA_YEARid=" & YearId & " AND CONTRA.CONTRA_registerid = " & CONTRAREGID & " AND CONTRA.CONTRA_DEBIT = 0 ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CONTRA VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLCOPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLCOPY.Click
        Dim IntResult As Integer
        Dim alParaval As New ArrayList
        Dim TEMPMSG As Integer
        TEMPMSG = MsgBox("Wish to Copy CONTRA No " & gridcontra.GetFocusedRowCellValue("Sr. No"), MsgBoxStyle.YesNo)
        If TEMPMSG = vbYes Then
            alParaval.Add(gridcontra.GetFocusedRowCellValue("Sr. No"))
            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)

            Dim objclscontra As New ClsContra()
            objclscontra.alParaval = alParaval


            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            IntResult = objclscontra.COPY()
            MessageBox.Show("Details Copied")

            cmbregister.Text = UCase(cmbregister.Text)
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'CONTRA' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                CONTRAREGID = dt.Rows(0).Item(0)
                fillgrid(" and dbo.CONTRA.CONTRA_cmpid=" & CmpId & " and dbo.CONTRA.CONTRA_LOCATIONid=" & Locationid & " and dbo.CONTRA.CONTRA_YEARid=" & YearId & " AND CONTRA.CONTRA_registerid = " & CONTRAREGID & " AND CONTRA.CONTRA_DEBIT = 0")
            End If
        End If
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Contra Register Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Contra Register Details"
            gridcontra.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Contra Register Details", gridcontra.VisibleColumns.Count + gridcontra.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Contra Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ContraDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class