
Imports BL

Public Class JobOutDetails

    Public EDIT As Boolean
    Public TYPE As String
    Dim TEMPPONO As Integer
    Public Where As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JOBOUTDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobOutDetails_LOAD(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB OUT'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        FILLJOBOUTTYPE(CMBTYPE)
        If ClientName <> "SAFFRON" And ClientName <> "SAFFRONOFF" Then fillgrid(" AND dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" JOBOUT.JO_no AS SRNO,  JOBOUT.JO_TYPENO AS TYPENO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, ISNULL(JOBOUT.JO_CHALLANNO, 0) AS CHALLANNO, JOBOUT.JO_TOTALPCS AS TOTALPCS, JOBOUT.JO_TOTALMTRS AS TOTALMTRS,JOBOUT.JO_RECDMTRS AS RECDMTRS, ROUND((JOBOUT.JO_TOTALMTRS-JOBOUT.JO_RECDMTRS),2) AS BALMTRS, ISNULL(JOBOUT.JO_remarks, '') AS REMARKS, ISNULL(PROCESS_NAME,'') AS PROCESS,JOBOUT.JO_BALENUMBER AS BALENUMBER, ISNULL(JOBOUT.JO_LOTREADY,0) AS LOTREADY", "", "  JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id AND JOBOUT.JO_cmpid = LEDGERS.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_yearid = GODOWNMASTER.GODOWN_yearid AND JOBOUT.JO_locationid = GODOWNMASTER.GODOWN_locationid AND JOBOUT.JO_cmpid = GODOWNMASTER.GODOWN_cmpid AND JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN PROCESSMASTER ON PROCESS_ID = JO_PROCESSID LEFT OUTER JOIN JOBOUTTYPEMASTER ON JOTYPE_ID = JO_TYPEID ", Where & TEMPCONDITION)
            dt = objclsCMST.search(" JOBOUT.JO_no AS SRNO, JOBOUT.JO_TYPENO AS TYPENO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWNMASTER.GODOWN_NAME, '') AS GODOWN, ISNULL(JOBOUT.JO_LOTNO, 0) AS LOTNO, ISNULL(JOBOUT.JO_CHALLANNO, 0) AS CHALLANNO, JOBOUT.JO_TOTALPCS AS TOTALPCS, JOBOUT.JO_TOTALMTRS AS TOTALMTRS, JOBOUT.JO_RECDMTRS AS RECDMTRS, ROUND(JOBOUT.JO_TOTALMTRS - JOBOUT.JO_RECDMTRS, 2) AS BALMTRS, ISNULL(JOBOUT.JO_remarks, '') AS REMARKS, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, JOBOUT.JO_BALENUMBER AS BALENUMBER, ISNULL(JOBOUT.JO_LOTREADY, 0) AS LOTREADY, ISNULL(USERMASTER.User_Name, '') AS CREATEDBY, ISNULL(MODIFIEDBY.User_Name, '') AS MODIFIEDBY, JOBOUT.JO_created AS CREATEDDATE, JOBOUT.JO_MODIFIED AS MODIFIEDDATE", "", "  JOBOUTTYPEMASTER RIGHT OUTER JOIN GODOWNMASTER RIGHT OUTER JOIN JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id AND JOBOUT.JO_cmpid = LEDGERS.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN USERMASTER AS MODIFIEDBY ON JOBOUT.JO_MODIFIEDBY = MODIFIEDBY.User_id LEFT OUTER JOIN USERMASTER ON JOBOUT.JO_userid = USERMASTER.User_id ON GODOWNMASTER.GODOWN_YEARID = JOBOUT.JO_yearid AND GODOWNMASTER.GODOWN_LOCATIONID = JOBOUT.JO_locationid AND GODOWNMASTER.GODOWN_CMPID = JOBOUT.JO_cmpid AND GODOWNMASTER.GODOWN_ID = JOBOUT.JO_GODOWNID LEFT OUTER JOIN PROCESSMASTER ON JOBOUT.JO_PROCESSID = PROCESSMASTER.PROCESS_ID ON JOBOUTTYPEMASTER.JOTYPE_ID = JOBOUT.JO_TYPEID ", Where & TEMPCONDITION)

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal JONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New JobOut
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPJONO = JONO
                objREQ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJJO As New JobOutGridDetails
            OBJJO.MdiParent = MDIMain
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(sender As Object, e As EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Job Out Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Job Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("Job Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Job Out Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Job Out from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Job Out ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Job Out Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp Job Out from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected Job Out ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Job Out Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Print Job Out from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Job Out Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            Dim GSTRPT As Boolean = False
            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            If MsgBox("Wish to Send Whatsapp of Job Out With GST...?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then GSTRPT = True
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJJO As New GDNDESIGN
                OBJJO.MdiParent = MDIMain
                OBJJO.DIRECTPRINT = True
                OBJJO.FRMSTRING = "JOBOUT"
                OBJJO.DIRECTMAIL = INVOICEMAIL
                OBJJO.DIRECTWHATSAPP = WHATSAPP
                OBJJO.GSTRPT = GSTRPT
                OBJJO.PRINTSETTING = PRINTDIALOG
                OBJJO.FORMULA = "{JOBOUT.JO_NO}=" & Val(I) & " and {JOBOUT.JO_yearid}=" & YearId
                OBJJO.JONO = Val(I)
                OBJJO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJJO.Show()
                OBJJO.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\JOBOUT_" & I & ".pdf")
                FILENAME.Add("JOBOUT_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "JOBOUT"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            Dim GSTRPT As Boolean = False

            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            If MsgBox("Wish to Send Whatsapp of Job Out With GST...?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then GSTRPT = True
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJJO As New GDNDESIGN
                OBJJO.MdiParent = MDIMain
                OBJJO.DIRECTPRINT = True
                OBJJO.FRMSTRING = "JOBOUT"
                OBJJO.DIRECTMAIL = INVOICEMAIL
                OBJJO.DIRECTWHATSAPP = WHATSAPP
                OBJJO.GSTRPT = GSTRPT
                OBJJO.PRINTSETTING = PRINTDIALOG
                OBJJO.FORMULA = "{JOBOUT.JO_NO}=" & Val(ROW("SRNO")) & " and {JOBOUT.JO_yearid}=" & YearId
                OBJJO.JONO = Val(ROW("SRNO"))
                OBJJO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJJO.Show()
                OBJJO.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\JOBOUT_" & Val(ROW("SRNO")) & ".pdf")
                FILENAME.Add("JOBOUT_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "JOBOUT"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub JobOutDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                GPROCESS.Visible = True
                gsrno.Visible = False
                GTYPENO.Visible = True
                GTYPENO.VisibleIndex = 0
                GPROCESS.VisibleIndex = GREMARKS.VisibleIndex
                LBLTYPE.Visible = True
                CMBTYPE.Visible = True
            End If

            If ClientName = "INDRANI" Then
                GRECDMTRS.Caption = "Recd Pcs"
                GBALMTRS.Caption = "Bal Pcs"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text <> "" And (ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF") Then fillgrid(" AND JOTYPE_NAME = '" & CMBTYPE.Text.Trim & "'  AND dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class