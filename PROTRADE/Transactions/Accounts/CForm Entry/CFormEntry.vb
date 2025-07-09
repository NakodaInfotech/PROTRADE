
Imports BL

Public Class CFormEntry

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        If CMBTYPE.Text.Trim = "" Then
            MsgBox("Select Type", MsgBoxStyle.Critical)
            CMBTYPE.Focus()
            Exit Sub
        End If

        If CMBFORM.Text.Trim = "E1 FORM" And CMBTYPE.Text.Trim = "SALE" Then
            MsgBox("Sale Type Not Allowed in E1 FORM", MsgBoxStyle.Critical)
            CMBTYPE.Focus()
            Exit Sub
        End If
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            Dim ALPARAVAL As New ArrayList
            Dim objregister As New ClsCForm

            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(CMBFORM.Text.Trim)
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
            ALPARAVAL.Add(CMBTYPE.Text.Trim)

            objregister.alParaval = ALPARAVAL
            If RBALL.Checked = True Then
                gridbilldetails.DataSource = objregister.GETALLBILLS
            ElseIf RBPENDING.Checked = True Then
                gridbilldetails.DataSource = objregister.GETPENDINGBILLS
            Else
                gridbilldetails.DataSource = objregister.GETRECDBILLS
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' or GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors') and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' or GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors') and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, txtadd, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' or GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors') and ledgers.acc_cmpname = '" & CMBNAME.Text.Trim & "' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CFormEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CFormEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow= USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillname(CMBNAME, False, " and (GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' or GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors')  and LEDGERS.ACC_YEARID = " & YearId)
            FILLFORMTYPE(CMBFORM, False)
            'fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            If CMBTYPE.Text.Trim = "" Then
                MsgBox("Select Type", MsgBoxStyle.Critical)
                CMBTYPE.Focus()
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFORM_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFORM.Enter
        Try
            If CMBFORM.Text.Trim = "" Then FILLFORMTYPE(CMBFORM, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFORM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFORM.Validating
        Try
            If CMBFORM.Text.Trim <> "" Then FORMvalidate(CMBFORM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridbill.RowCount > 0 Then
                Dim dtrow As DataRow = gridbill.GetFocusedDataRow
                VIEWFORM(dtrow("TYPE"), True, dtrow("BILL"), dtrow("REGTYPE"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Form Details.XLS"
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Form Details"
            gridbilldetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Form Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, CMBNAME.Text.Trim, PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If gridbill.RowCount > 0 And CMBNAME.Text.Trim <> "" And CMBFORM.Text.Trim <> "" Then
                Dim OBJCFORM As New FormDesign
                Dim tempmsg As Integer = MsgBox("Print Form Requesition Letter?", MsgBoxStyle.YesNo)
                If tempmsg = vbNo Then Exit Sub
                OBJCFORM.FRMSTRING = "Letter Format"

                OBJCFORM.FORMNO = CMBFORM.Text.Trim
                OBJCFORM.STRSEARCH = "{CFORMVIEW.NAME} = '" & CMBNAME.Text.Trim & "'"

                If chkdate.Checked = True Then
                    OBJCFORM.FROMDATE = dtfrom.Value.Date
                    OBJCFORM.TODATE = dtto.Value.Date
                Else
                    OBJCFORM.FROMDATE = AccFrom
                    OBJCFORM.TODATE = AccTo
                End If
                OBJCFORM.MdiParent = MDIMain
                OBJCFORM.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBFORM.Text.Trim.Length = 0 Then
            EP.SetError(CMBFORM, " Please Select Form Type")
            bln = False
        End If

        If gridbill.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Select Bills")
            bln = False
        End If


        For i As Integer = 0 To gridbill.RowCount - 1
            Dim dtrow As DataRow = gridbill.GetDataRow(i)
            If dtrow("FORMNO") <> "" Then
                If IsDBNull(dtrow("FORMDATE")) = True Then
                    EP.SetError(CMBNAME, " Please Select Form Date")
                    bln = False
                End If
            End If
        Next

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim DT As DataTable

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList



            Dim TYPE As String = ""
            Dim BILL As String = ""
            Dim REGISTERNAME As String = ""
            Dim BILLINITIALS As String = ""
            Dim NAME As String = ""
            Dim FORMNO As String = ""
            Dim FORMDATE As String = ""
            Dim RECDATE As String = ""
            Dim REMARKS As String = ""
            

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If dtrow("FORMNO") <> "" Then
                    If TYPE = "" Then
                        TYPE = dtrow("TYPE")
                        BILL = dtrow("BILL")
                        REGISTERNAME = dtrow("REGTYPE")
                        BILLINITIALS = dtrow("BILLINITIALS")
                        NAME = dtrow("NAME")
                        FORMNO = dtrow("FORMNO")
                        FORMDATE = Format(Convert.ToDateTime(dtrow("FORMDATE")).Date, "MM/dd/yyyy")
                        RECDATE = Format(Convert.ToDateTime(dtrow("RECDATE")).Date, "MM/dd/yyyy")
                        REMARKS = dtrow("REMARKS")
                        
                    Else
                        TYPE = TYPE & "," & dtrow("TYPE")
                        BILL = BILL & "," & dtrow("BILL")
                        REGISTERNAME = REGISTERNAME & "," & dtrow("REGTYPE")
                        BILLINITIALS = BILLINITIALS & "," & dtrow("BILLINITIALS")
                        NAME = NAME & "," & dtrow("NAME")
                        FORMNO = FORMNO & "," & dtrow("FORMNO")
                        FORMDATE = FORMDATE & "," & Format(Convert.ToDateTime(dtrow("FORMDATE")).Date, "MM/dd/yyyy")
                        RECDATE = RECDATE & "," & Format(Convert.ToDateTime(dtrow("RECDATE")).Date, "MM/dd/yyyy")
                        REMARKS = REMARKS & "," & dtrow("REMARKS")
                    End If
                End If
            Next

            alParaval.Add(CMBFORM.Text.Trim)
            alParaval.Add(TYPE)
            alParaval.Add(BILL)
            alParaval.Add(REGISTERNAME)
            alParaval.Add(BILLINITIALS)
            alParaval.Add(NAME)
            alParaval.Add(FORMNO)
            alParaval.Add(FORMDATE)
            alParaval.Add(RECDATE)
            alParaval.Add(REMARKS)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJCFORM As New ClsCForm()
            OBJCFORM.alParaval = alParaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            DT = OBJCFORM.save()
            MessageBox.Show("Details Added")


            TXTFORMNO.Clear()
            fillgrid()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            
            Dim alParaval As New ArrayList

            Dim dtrow As DataRow = gridbill.GetFocusedDataRow
            If gridbill.RowCount = 0 Then Exit Sub
            If dtrow("FORMNO") <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Delete Form Entry?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    alParaval.Add(CMBFORM.Text.Trim)
                    alParaval.Add(dtrow("TYPE"))
                    alParaval.Add(dtrow("BILL"))
                    alParaval.Add(dtrow("REGTYPE"))
                    alParaval.Add(YearId)
                    alParaval.Add(Userid)

                    Dim OBJCFORM As New ClsCForm()
                    OBJCFORM.alParaval = alParaval
                    If USERDELETE = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    Dim INTRES As Integer = OBJCFORM.DELETE()
                    MessageBox.Show("Form Details Deleted Successfully")
                    fillgrid()
                    CMBNAME.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDAPPLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDAPPLY.Click
        Try
            If TXTFORMNO.Text.Trim <> "" And DTFORMDATE.Text.Trim <> "__/__/____" And DTRECDATE.Text <> "__/__/____" Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim DTROW As DataRow = gridbill.GetDataRow(I)
                    DTROW("FORMNO") = TXTFORMNO.Text.Trim
                    DTROW("FORMDATE") = DTFORMDATE.Text
                    DTROW("RECDATE") = DTRECDATE.Text
                    DTROW("REMARKS") = TXTREMARKS.Text
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text.Trim = "PURCHASE" Then
                LBLDATE.Text = "Iss Date"
                GRECDATE.Caption = "Iss Date"
            Else
                LBLDATE.Text = "Rec Date"
                GRECDATE.Caption = "Rec Date"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFORMNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFORMNO.Validating
        Try
            'CHECKING DUPLICATION
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CFORM_NO,'') AS FORMNO", "", " CFORMENTRY", " and CFORM_NO = '" & TXTFORMNO.Text.Trim & "' AND CFORM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                MsgBox("Form No Already Entered", MsgBoxStyle.Critical)
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTRECDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTRECDATE.Validating
        Try

            If DTRECDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTRECDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            If DTFORMDATE.Text <> "__/__/____" And DTRECDATE.Text <> "__/__/____" Then
                If Convert.ToDateTime(DTRECDATE.Text).Date < Convert.ToDateTime(DTFORMDATE.Text).Date Then
                    MsgBox("Rec Date cannot be previous of Form Date", MsgBoxStyle.Critical)
                    DTRECDATE.Clear()
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class