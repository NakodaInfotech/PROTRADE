
Imports BL
Imports System.Windows.Forms

Public Class GRNDetails

    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If FRMSTRING = "GRN" Then
                cmbtype.Text = "G.R.N"
            ElseIf FRMSTRING = "GRNJOB" Then
                cmbtype.Text = "Job Work"
                gridbill.Columns("GODOWN").Visible = False
                gridbill.Columns("BROKER").Visible = False
                gridbill.Columns("LOTNO").Visible = True
                gridbill.Columns("JOBBERNAME").Visible = True
            ElseIf FRMSTRING = "GRN FANCY" Then
                cmbtype.Text = "FANCY MATERIAL"
                gridbill.Columns("LOTNO").Visible = False
                gridbill.Columns("JOBBERNAME").Visible = False
            End If
            fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" GRN.grn_no AS SRNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(BROKERLEDGERS.Acc_cmpname, '') AS BROKER, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN_DESC.GRN_QTY, 0) AS PCS, ISNULL(GRN_DESC.GRN_MTRS, 0) AS MTRS, ISNULL(GRN.GRN_PLOTNO,'') AS LOTNO, GRN.GRN_RECDATE AS LOTDATE, ISNULL(GRN.GRN_PONO,'') AS PONO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_NAME, '') AS SHADE, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY, ISNULL(GRN_DESC.GRN_BALENO,'') AS BALENO, ISNULL(GRN.GRN_REMARKS,'') AS REMARKS, ISNULL(GRN_LOTREADY,0) AS LOTREADY ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.GRN_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON GRN.GRN_TOLEDGERID = JOBBERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GRN.GRN_TRANSLEDGERID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNMASTER ON GRN_DESC.GRN_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON COLOR_ID = GRN_DESC.GRN_COLORID LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", TEMPCONDITION)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SRNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objGRN As New GRN
                objGRN.MdiParent = MDIMain
                objGRN.EDIT = editval
                objGRN.tempgrnno = SRNO
                objGRN.FRMSTRING = FRMSTRING
                objGRN.Show()
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

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\GRN Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("GRN Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
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
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
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
            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                If ClientName = "BRILLANTO" Then
                    If cmbtype.Text.Trim = "GRN FANCY" Then OBJGRN.FRMSTRING = "FINISHGRN" Else OBJGRN.FRMSTRING = "GRN"
                Else
                    OBJGRN.FRMSTRING = "GRN"
                End If
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.DIRECTWHATSAPP = WHATSAPP
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.WHERECLAUSE = "{GRN.GRN_no}=" & Val(I) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "'  and {GRN.GRN_yearid}=" & YearId
                OBJGRN.GRNNO = Val(I)
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()

                ALATTACHMENT.Add(Application.StartupPath & "\GRN_" & I & ".pdf")
                FILENAME.Add("GRN_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN"
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

            If INVOICEMAIL = False And WHATSAPP = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                If ClientName = "BRILLANTO" Then
                    If cmbtype.Text.Trim = "GRN FANCY" Then OBJGRN.FRMSTRING = "FINISHGRN" Else OBJGRN.FRMSTRING = "GRN"
                Else
                    OBJGRN.FRMSTRING = "GRN"
                End If
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.DIRECTWHATSAPP = WHATSAPP
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.WHERECLAUSE = "{GRN.GRN_no}=" & Val(ROW("SRNO")) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "'  and {GRN.GRN_yearid}=" & YearId
                OBJGRN.GRNNO = Val(ROW("SRNO"))
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\GRN_" & Val(ROW("SRNO")) & ".pdf")
                FILENAME.Add("GRN_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN"
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            If cmbtype.Text.Trim <> "" Then fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()

            If SELECTEDROWS.Length <= 0 Then Exit Sub
            Dim OBJGDN As New GRNDesign
            Dim SRNOCLAUSE As String = ""
            If MsgBox("Wish to Print Mill Letter ?", MsgBoxStyle.YesNo) = vbYes Then
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "LETTER"
                OBJGDN.WHERECLAUSE = " {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "' and {GRN.GRN_yearid}=" & YearId
            End If

            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                If SRNOCLAUSE = "" Then
                    SRNOCLAUSE = " And ({GRN.GRN_NO} = " & Val(ROW("SRNO"))
                Else
                    SRNOCLAUSE = SRNOCLAUSE & " OR {GRN.GRN_NO} = " & Val(ROW("SRNO"))
                End If
            Next
            If SRNOCLAUSE <> "" Then
                SRNOCLAUSE = SRNOCLAUSE & ")"
                OBJGDN.WHERECLAUSE = OBJGDN.WHERECLAUSE & SRNOCLAUSE
            End If
            OBJGDN.Show()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "INDRANI" Then GBALENO.Caption = "SO No"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class