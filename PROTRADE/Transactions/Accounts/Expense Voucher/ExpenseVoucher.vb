
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ExpenseVoucher

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPEXPNO As Integer     'used for non purchase no while editing
    Dim TEMPROW As Integer
    Public partyref As String      'used for refno while edit mode
    Dim PURregid As Integer
    Dim PURregabbr, PURreginitial As String
    Public TEMPREGNAME As String
    Dim ALLOWMANUALNPNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        GRIDEXPENSE.Enabled = True
        If ALLOWMANUALNPNO = True Then
            TXTNPNO.ReadOnly = False
            TXTNPNO.BackColor = Color.LemonChiffon
        Else
            TXTNPNO.ReadOnly = True
            TXTNPNO.BackColor = Color.Linen
        End If


        EP.Clear()
        PBTDS.Visible = False
        PBDN.Visible = False
        PBPAID.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSHOWDETAILS.Visible = False

        NPDATE.Text = Now.Date
        PARTYBILLDATE.Text = Now.Date
        CHKRCM.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked

        TXTTOTALOTHERAMT.Text = 0
        TXTTOTALTAXABLEAMT.Text = 0
        TXTTOTALCGSTAMT.Text = 0
        TXTTOTALSGSTAMT.Text = 0
        TXTTOTALIGSTAMT.Text = 0
        TXTTOTALBILLAMT.Text = 0
        CHKTDS.CheckState = CheckState.Unchecked
        CHKMANUALROUND.CheckState = CheckState.Unchecked

        LBLTOTALAMT.Text = 0
        LBLTOTALQTY.Text = 0
        cmbtax.Text = ""
        txttax.Text = 0.0
        TXTGRANDTOTAL.Text = 0.0
        TXTROUNDOFF.Text = 0.0
        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        TXTADD.Clear()
        TXTPARTYBILLNO.Clear()
        TXTNPNO.Clear()

        TXTSRNO.Text = 1
        CMBDRNAME.Text = ""
        CMBHSNCODE.Text = ""
        TXTNOTE.Clear()
        TXTQTY.Clear()
        TXTRATE.Clear()
        TXTAMT.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        txtremarks.Clear()
        GRIDEXPENSE.RowCount = 0
        partyref = ""
        TXTBAL.Clear()
        TXTAMTREC.Clear()
        TXTTDS.Clear()

        CHKTCS.Checked = False
        TXTTOTALWITHGST.Clear()
        TXTTCSPER.Clear()
        TXTTCSAMT.Clear()

        getmaxno()
        GRIDDOUBLECLICK = False


    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBREGISTER.Enabled = True
        CMBREGISTER.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        If CMBREGISTER.Text <> "" Then
            DTTABLE = getmax(" isnull(max(NP_NO),0) + 1 ", "  NONPURCHASE INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "' AND REGISTER_TYPE = 'EXPENSE' AND NP_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTNPNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub NonPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
            Call toolprevious_Click(sender, e)
        ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
            Call toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F2 Then
            tstxtbillno.Focus()
        End If
    End Sub

    Private Sub NonPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VOUCHER ENTRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor
            fillregister(CMBREGISTER, " and register_type = 'EXPENSE'")
            If CMBREGISTER.Items.Count > 0 Then CMBREGISTER.SelectedIndex = (0)
            'OPEN ALL ACCOUNTS DONE BY GULKIT

            fillname(CMBNAME, EDIT, "")
            fillledger(CMBDRNAME, EDIT, "")
            filltax(cmbtax, EDIT)
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPEXPNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim objclsNP As New ClsExpenseVoucher
                objclsNP.alParaval = ALPARAVAL
                dt = objclsNP.selectNONpurchase()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTNPNO.Text = TEMPEXPNO
                        TXTNPNO.ReadOnly = True

                        CMBREGISTER.Text = Convert.ToString(dr("REGNAME"))
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")
                        NPDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTPARTYBILLNO.Text = dr("REFNO")
                        partyref = TXTPARTYBILLNO.Text.Trim
                        PARTYBILLDATE.Text = Format(Convert.ToDateTime(dr("PARTYBILLDATE")), "dd/MM/yyyy")

                        CHKRCM.Checked = Convert.ToBoolean(dr("RCM"))
                        CHKMANUAL.Checked = Convert.ToBoolean(dr("MANUALGST"))
                        CHKMANUALROUND.Checked = Convert.ToBoolean(dr("MANUALROUNDOFF"))

                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))

                        txtremarks.Text = Convert.ToString(dr("Remarks"))
                        TXTROUNDOFF.Text = Val(dr("ROUNDOFF"))
                        TXTAMTREC.Text = dr("AMTPAID")
                        TXTTDS.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("BILLRETURN")
                        TXTBAL.Text = dr("BALANCE")

                        GRIDEXPENSE.Rows.Add(dr("gridsrno").ToString, dr("DRNAME").ToString, dr("HSNCODE"), dr("NOTE").ToString, Val(dr("qty")), Val(dr("rate")), Val(dr("amt")), Val(dr("OTHERAMT")), Val(dr("TAXABLEAMT")), Val(dr("CGSTPER")), Val(dr("CGSTAMT")), Val(dr("SGSTPER")), Val(dr("SGSTAMT")), Val(dr("IGSTPER")), Val(dr("IGSTAMT")), Val(dr("GRIDTOTAL")))

                        'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        Dim OBJCMNTDS As New ClsCommon
                        Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(JOURNALMASTER.journal_credit,0) AS TDS", "", " JOURNALMASTER INNER JOIN NONPURCHASE ON JOURNALMASTER.journal_refno = NONPURCHASE.NP_INITIALS AND  JOURNALMASTER.journal_yearid = NONPURCHASE.NP_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id ", "AND (LEDGERS.ACC_TDSAC = 'True') AND NP_NO = " & TEMPEXPNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND NP_YEARID = " & YearId)
                        If DTTDS.Rows.Count > 0 Then
                            If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBTDS.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                                CMBNAME.Enabled = False
                            End If
                        End If

                        If PBTDS.Visible = False Then
                            If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBPAID.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If Val(dr("BILLRETURN")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & CMBREGISTER.Text.Trim & "' and register_type = 'EXPENSE' and register_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        PURregabbr = dt.Rows(0).Item(0).ToString
                        PURreginitial = dt.Rows(0).Item(1).ToString
                        PURregid = dt.Rows(0).Item(2)
                    End If
                Else
                    EDIT = False
                    clear()
                End If

                CMBREGISTER.Enabled = False
                CMBNAME.Focus()
                total()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim IntResult As Integer

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If Not VALIDATEREFNO() Then
                EP.SetError(TXTPARTYBILLNO, "Party Ref. Already Exists")
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            If TXTNPNO.ReadOnly = False Then
                alParaval.Add(Val(TXTNPNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(CMBREGISTER.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(NPDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy"))

            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUALROUND.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALAMT.Text))

            alParaval.Add(Val(TXTTOTALOTHERAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALTAXABLEAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALBILLAMT.Text))


            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))


            alParaval.Add(Val(TXTROUNDOFF.Text))
            alParaval.Add(Val(TXTGRANDTOTAL.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTAMTREC.Text.Trim)
            alParaval.Add(TXTTDS.Text.Trim)
            alParaval.Add(TXTRETURN.Text.Trim)
            alParaval.Add(TXTBAL.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim drname As String = ""
            Dim HSNCODE As String = ""

            Dim note As String = ""
            Dim qty As String = ""
            Dim rate As String = ""
            Dim amount As String = ""

            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDEXPENSE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(srno.Index).Value)
                        drname = row.Cells(GDRNAME.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        note = row.Cells(GNOTE.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value.ToString)
                        rate = Val(row.Cells(GRATE.Index).Value.ToString)
                        amount = Val(row.Cells(gAMT.Index).Value.ToString)
                        OTHERAMT = Val(row.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = Val(row.Cells(GGRIDTOTAL.Index).Value)
                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(srno.Index).Value)
                        drname = drname & "|" & row.Cells(GDRNAME.Index).Value.ToString
                        note = note & "|" & row.Cells(GNOTE.Index).Value.ToString
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value.ToString)
                        rate = rate & "|" & Val(row.Cells(GRATE.Index).Value.ToString)
                        amount = amount & "|" & Val(row.Cells(gAMT.Index).Value.ToString)
                        OTHERAMT = OTHERAMT & "|" & Val(row.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = TAXABLEAMT & "|" & Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = CGSTAMT & "|" & Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = SGSTAMT & "|" & Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = IGSTAMT & "|" & Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(row.Cells(GGRIDTOTAL.Index).Value)
                    End If
                End If
            Next



            alParaval.Add(gridsrno)
            alParaval.Add(drname)
            alParaval.Add(HSNCODE)
            alParaval.Add(note)
            alParaval.Add(qty)
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(OTHERAMT)
            alParaval.Add(TAXABLEAMT)
            alParaval.Add(CGSTPER)
            alParaval.Add(CGSTAMT)
            alParaval.Add(SGSTPER)
            alParaval.Add(SGSTAMT)
            alParaval.Add(IGSTPER)
            alParaval.Add(IGSTAMT)
            alParaval.Add(GRIDTOTAL)

            Dim objclsNP As New ClsExpenseVoucher
            objclsNP.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = objclsNP.SAVE()
                MsgBox("Details Added")

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = DT.Rows(0).Item(0)
                    OBJTDS.REGISTER = CMBREGISTER.Text.Trim
                    OBJTDS.ShowDialog()
                End If

            ElseIf EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPEXPNO)
                IntResult = objclsNP.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If NPDATE.Text = "__/__/____" Then
                EP.SetError(NPDATE, " Please Enter Proper Date")
                bln = False
                Return bln
                Exit Function
            Else
                If Not datecheck(NPDATE.Text) Then
                    EP.SetError(NPDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(NPDATE.Text).Date < EXPBLOCKDATE.Date Then
                    EP.SetError(NPDATE, "Date is Blocked, Please make entries after " & Format(EXPBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            If ALLOWMANUALNPNO = True Then
                If TXTNPNO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
                    Dim OBJCMN As New ClsCommon

                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(NONPURCHASE.NP_no,0) AS NPNO, REGISTERMASTER.register_name AS REGNAME", "", " REGISTERMASTER INNER JOIN NONPURCHASE ON REGISTERMASTER.register_id = NONPURCHASE.NP_registerid AND REGISTERMASTER.register_cmpid = NONPURCHASE.NP_cmpid AND REGISTERMASTER.register_locationid = NONPURCHASE.NP_locationid AND REGISTERMASTER.register_yearid = NONPURCHASE.NP_yearid ", "  AND NONPURCHASE.NP_no=" & TXTNPNO.Text.Trim & " AND REGISTER_NAME = '" & CMBREGISTER.Text.Trim & "' AND NONPURCHASE.NP_cmpid = " & CmpId & " AND NONPURCHASE.NP_locationid = " & Locationid & " AND NONPURCHASE.NP_yearid = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(TXTNPNO, "Voucher No Already Exist")
                        bln = False
                    End If
                End If
            End If


            If CMBREGISTER.Text.Trim.Length = 0 Then
                EP.SetError(CMBREGISTER, "Enter Register Name")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If


            If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTPARTYBILLNO, "Please Fill Party Bill No.")
                bln = False
            End If

            If GRIDEXPENSE.RowCount = 0 Then
                EP.SetError(TXTAMT, "Please Fill Proper Entries")
                bln = False
            End If


            If Not datecheck(NPDATE.Text) Then
                EP.SetError(NPDATE, "Date Not in Current Accounting Year")
                bln = False
            End If

            If Not datecheck(PARTYBILLDATE.Text) Then
                EP.SetError(PARTYBILLDATE, "Date Not in Current Accounting Year")
                bln = False
            End If

            If UserName <> "Admin" And lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Rec/Pay/TDS Made, Delete Rec/Pay/TDS First")
                bln = False
            End If

            If Convert.ToDateTime(PARTYBILLDATE.Text).Date >= "01/07/2017" Then
                If TXTSTATECODE.Text.Trim.Length = 0 Then
                    EP.SetError(TXTSTATECODE, "Please enter the state code")
                    bln = False
                End If

                'NOT MANDATE, DONE BY GULKIT
                'If TXTGSTIN.Text.Trim.Length = 0 And CHKRCM.CheckState = CheckState.Unchecked Then
                '    EP.SetError(CHKRCM, "Select Reverse Charge")
                '    bln = False
                'End If


                'If TXTGSTIN.Text.Trim.Length > 0 And CHKRCM.CheckState = CheckState.Checked Then
                '    If MsgBox("Reverse Charge Not Applicable, Wish to Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                '        EP.SetError(CHKRCM, "Reverse Charge Not Applicable")
                '        bln = False
                '    End If
                'End If

                If ClientName <> "NVAHAN" Then
                    If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(TXTTOTALCGSTAMT.Text) > 0 Or Val(TXTTOTALSGSTAMT.Text.Trim) > 0) Then
                        EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                        bln = False
                    End If

                    If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(TXTTOTALIGSTAMT.Text) > 0 Then
                        EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                        bln = False
                    End If
                End If

            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'OPEN ALL ACCOUNTS
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()

        LBLTOTALQTY.Text = "0.0"
        LBLTOTALAMT.Text = "0.0"

        TXTTOTALOTHERAMT.Text = 0.0
        TXTTOTALTAXABLEAMT.Text = 0.0
        TXTTOTALCGSTAMT.Text = "0.0"
        TXTTOTALSGSTAMT.Text = "0.0"
        TXTTOTALIGSTAMT.Text = "0.0"

        TXTTOTALBILLAMT.Text = 0.0
        If CHKMANUALROUND.CheckState = CheckState.Unchecked Then TXTROUNDOFF.Text = 0
        TXTGRANDTOTAL.Text = 0


        TXTTCSPER.Text = 0
        TXTTCSAMT.Text = 0

        'FETCH TCSPERCENT WITH RESPECT TO DATE
        Dim OBJCMN As New ClsCommon
        Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
        If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))

        If GRIDEXPENSE.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDEXPENSE.Rows
                If Val(row.Cells(GQTY.Index).Value) <> 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(gAMT.Index).Value) <> 0 Then LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(row.Cells(gAMT.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GOTHERAMT.Index).Value) <> 0 Then TXTTOTALOTHERAMT.Text = Format(Val(TXTTOTALOTHERAMT.Text) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GTAXABLEAMT.Index).Value) <> 0 Then TXTTOTALTAXABLEAMT.Text = Format(Val(TXTTOTALTAXABLEAMT.Text) + Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GCGSTAMT.Index).Value) <> 0 Then TXTTOTALCGSTAMT.Text = Format(Val(TXTTOTALCGSTAMT.Text) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GSGSTAMT.Index).Value) <> 0 Then TXTTOTALSGSTAMT.Text = Format(Val(TXTTOTALSGSTAMT.Text) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GIGSTAMT.Index).Value) <> 0 Then TXTTOTALIGSTAMT.Text = Format(Val(TXTTOTALIGSTAMT.Text) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GGRIDTOTAL.Index).Value) <> 0 Then TXTTOTALBILLAMT.Text = Format(Val(TXTTOTALBILLAMT.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

            Next
        End If

        TXTTOTALWITHGST.Text = Format(Val(TXTTOTALTAXABLEAMT.Text) + Val(TXTTOTALCGSTAMT.Text.Trim) + Val(TXTTOTALSGSTAMT.Text.Trim) + Val(TXTTOTALIGSTAMT.Text.Trim), "0.00")
        If CHKTCS.CheckState = CheckState.Checked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")


        If CHKMANUALROUND.Checked = False Then
            TXTGRANDTOTAL.Text = Format(Val(TXTTOTALBILLAMT.Text) + Val(TXTTCSAMT.Text.Trim), "0")
            TXTROUNDOFF.Text = Format(Val(TXTGRANDTOTAL.Text) - (Val(TXTTOTALBILLAMT.Text) + Val(TXTTCSAMT.Text.Trim)), "0.00")
        Else
            TXTGRANDTOTAL.Text = Format(Val(TXTTOTALBILLAMT.Text) + Val(TXTROUNDOFF.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0.00")
        End If
        TXTGRANDTOTAL.Text = Format(Val(TXTGRANDTOTAL.Text), "0.00")


    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDEXPENSE.RowCount = 0
LINE1:
            TEMPEXPNO = Val(TXTNPNO.Text) - 1
            TEMPREGNAME = CMBREGISTER.Text.Trim
            If TEMPEXPNO > 0 Then
                EDIT = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDEXPENSE.RowCount = 0 And TEMPEXPNO > 1 Then
                TXTNPNO.Text = TEMPEXPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDEXPENSE.RowCount = 0
LINE1:
            TEMPEXPNO = Val(TXTNPNO.Text) + 1
            TEMPREGNAME = CMBREGISTER.Text.Trim
            getmaxno()
            Dim MAXNO As Integer = TXTNPNO.Text.Trim
            clear()
            If Val(TXTNPNO.Text) - 1 >= TEMPEXPNO Then
                EDIT = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDEXPENSE.RowCount = 0 And TEMPEXPNO < MAXNO Then
                TXTNPNO.Text = TEMPEXPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objNPdetails As New ExpenseVoucherDetails
            objNPdetails.MdiParent = MDIMain
            objNPdetails.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'OPEN ALL ACCOUNTS
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBREGISTER.Enter
        Try
            If CMBREGISTER.Text.Trim = "" Then fillregister(CMBREGISTER, " and register_type = 'EXPENSE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then CMBREGISTER.Text = dt.Rows(0).Item(0).ToString
            getmaxno()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBREGISTER.Validating
        Try
            If CMBREGISTER.Text.Trim.Length > 0 And EDIT = False Then
                clear()
                CMBREGISTER.Text = UCase(CMBREGISTER.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & CMBREGISTER.Text.Trim & "' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURregabbr = dt.Rows(0).Item(0).ToString
                    PURreginitial = dt.Rows(0).Item(1).ToString
                    PURregid = dt.Rows(0).Item(2)
                    getmaxno()
                    CMBREGISTER.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDRNAME.Enter
        Try
            'OPEN ALL ACCOUNTS
            If CMBDRNAME.Text.Trim = "" Then fillledger(CMBDRNAME, EDIT, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDRNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbdrname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDRNAME.Validating
        Try
            'OPEN ALL ACCOUNTS
            If CMBDRNAME.Text.Trim <> "" Then namevalidate(CMBDRNAME, CMBCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTRATE.KeyPress, TXTAMT.KeyPress, TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim.Length > 0 Then
                If VALIDATEREFNO() = False Then
                    MsgBox("Party Ref. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function VALIDATEREFNO() As Boolean
        Try
            Dim BLN As Boolean = True
            If (EDIT = False) Or (EDIT = True And LCase(partyref) <> LCase(TXTPARTYBILLNO.Text.Trim)) Then
                'for search
                Dim objclscommon As New ClsCommon()
                Dim dt As New DataTable
                dt = objclscommon.search(" NONPURCHASE.NP_refno, LEDGERS.ACC_cmpname", "", " dbo.NONPURCHASE INNER JOIN dbo.LEDGERS ON dbo.LEDGERS.ACC_id = dbo.NONPURCHASE.NP_ledgerid AND dbo.NONPURCHASE.NP_cmpid = dbo.LEDGERS.ACC_cmpid AND dbo.NONPURCHASE.NP_locationid = dbo.LEDGERS.ACC_locationid AND dbo.NONPURCHASE.NP_yearid = dbo.LEDGERS.ACC_yearid ", " and NONPURCHASE.NP_refno = '" & TXTPARTYBILLNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' and dbo.NONPURCHASE.NP_cmpid=" & CmpId & " and dbo.NONPURCHASE.NP_locationid=" & Locationid & " and dbo.NONPURCHASE.NP_yearid=" & YearId)
                If dt.Rows.Count > 0 Then BLN = False
            End If
            Return BLN
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDEXPENSE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDEXPENSE.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If TEMPROW = GRIDEXPENSE.CurrentRow.Index And GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDEXPENSE.Rows.RemoveAt(GRIDEXPENSE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDEXPENSE)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDEXPENSE.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDEXPENSE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBDRNAME.Text.Trim, CMBHSNCODE.Text.Trim, TXTNOTE.Text.Trim, Val(TXTQTY.Text.Trim), Val(TXTRATE.Text.Trim), Val(TXTAMT.Text.Trim), Val(TXTOTHERAMT.Text.Trim), Val(TXTTAXABLEAMT.Text.Trim), Val(TXTCGSTPER.Text.Trim), Val(TXTCGSTAMT.Text.Trim), Val(TXTSGSTPER.Text.Trim), Val(TXTSGSTAMT.Text.Trim), Val(TXTIGSTPER.Text.Trim), Val(TXTIGSTAMT.Text.Trim), Val(TXTGRIDTOTAL.Text.Trim))
            getsrno(GRIDEXPENSE)
        ElseIf GRIDDOUBLECLICK = True Then


            GRIDEXPENSE.Item(srno.Index, TEMPROW).Value = TXTSRNO.Text.Trim
            GRIDEXPENSE.Item(GDRNAME.Index, TEMPROW).Value = CMBDRNAME.Text.Trim
            GRIDEXPENSE.Item(GHSNCODE.Index, TEMPROW).Value = CMBHSNCODE.Text.Trim
            GRIDEXPENSE.Item(GNOTE.Index, TEMPROW).Value = TXTNOTE.Text.Trim
            GRIDEXPENSE.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
            GRIDEXPENSE.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDEXPENSE.Item(gAMT.Index, TEMPROW).Value = Val(TXTAMT.Text.Trim)

            GRIDEXPENSE.Item(GOTHERAMT.Index, TEMPROW).Value = Val(TXTOTHERAMT.Text.Trim)
            GRIDEXPENSE.Item(GTAXABLEAMT.Index, TEMPROW).Value = Val(TXTTAXABLEAMT.Text.Trim)
            GRIDEXPENSE.Item(GCGSTPER.Index, TEMPROW).Value = Val(TXTCGSTPER.Text.Trim)
            GRIDEXPENSE.Item(GCGSTAMT.Index, TEMPROW).Value = Val(TXTCGSTAMT.Text.Trim)
            GRIDEXPENSE.Item(GSGSTPER.Index, TEMPROW).Value = Val(TXTSGSTPER.Text.Trim)
            GRIDEXPENSE.Item(GSGSTAMT.Index, TEMPROW).Value = Val(TXTSGSTAMT.Text.Trim)
            GRIDEXPENSE.Item(GIGSTPER.Index, TEMPROW).Value = Val(TXTIGSTPER.Text.Trim)
            GRIDEXPENSE.Item(GIGSTAMT.Index, TEMPROW).Value = Val(TXTIGSTAMT.Text.Trim)
            GRIDEXPENSE.Item(GGRIDTOTAL.Index, TEMPROW).Value = Val(TXTGRIDTOTAL.Text.Trim)

            GRIDDOUBLECLICK = False

        End If
        GRIDEXPENSE.FirstDisplayedScrollingRowIndex = GRIDEXPENSE.RowCount - 1

        TXTSRNO.Text = GRIDEXPENSE.RowCount
        CMBDRNAME.Text = ""
        CMBHSNCODE.Text = ""

        TXTNOTE.Text = ""
        TXTQTY.Clear()
        TXTRATE.Clear()
        TXTAMT.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        CMBDRNAME.Focus()

    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDEXPENSE.CellDoubleClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And GRIDEXPENSE.Item(0, e.RowIndex).Value <> Nothing Then

            GRIDDOUBLECLICK = True
            TXTSRNO.Text = GRIDEXPENSE.Item(srno.Index, e.RowIndex).Value
            CMBDRNAME.Text = GRIDEXPENSE.Item(GDRNAME.Index, e.RowIndex).Value
            CMBHSNCODE.Text = GRIDEXPENSE.Item(GHSNCODE.Index, e.RowIndex).Value.ToString
            TXTNOTE.Text = GRIDEXPENSE.Item(GNOTE.Index, e.RowIndex).Value.ToString

            TXTQTY.Text = Val(GRIDEXPENSE.Item(GQTY.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(GRIDEXPENSE.Item(GRATE.Index, e.RowIndex).Value)
            TXTAMT.Text = Val(GRIDEXPENSE.Item(gAMT.Index, e.RowIndex).Value)

            TXTOTHERAMT.Text = Val(GRIDEXPENSE.Item(GOTHERAMT.Index, e.RowIndex).Value)
            TXTTAXABLEAMT.Text = Val(GRIDEXPENSE.Item(GTAXABLEAMT.Index, e.RowIndex).Value)
            TXTCGSTPER.Text = Val(GRIDEXPENSE.Item(GCGSTPER.Index, e.RowIndex).Value)
            TXTCGSTAMT.Text = Val(GRIDEXPENSE.Item(GCGSTAMT.Index, e.RowIndex).Value)
            TXTSGSTPER.Text = Val(GRIDEXPENSE.Item(GSGSTPER.Index, e.RowIndex).Value)
            TXTSGSTAMT.Text = Val(GRIDEXPENSE.Item(GSGSTAMT.Index, e.RowIndex).Value)
            TXTIGSTPER.Text = Val(GRIDEXPENSE.Item(GIGSTPER.Index, e.RowIndex).Value)
            TXTIGSTAMT.Text = Val(GRIDEXPENSE.Item(GIGSTAMT.Index, e.RowIndex).Value)
            TXTGRIDTOTAL.Text = Val(GRIDEXPENSE.Item(GGRIDTOTAL.Index, e.RowIndex).Value)

            TEMPROW = e.RowIndex
            CMBDRNAME.Focus()

        End If
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        TXTSRNO.Text = GRIDEXPENSE.RowCount + 1
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDEXPENSE.RowCount = 0
            TEMPEXPNO = Val(tstxtbillno.Text)
            TEMPREGNAME = CMBREGISTER.Text.Trim
            If TEMPEXPNO > 0 Then
                EDIT = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            TOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURreginitial & "-" & TEMPEXPNO
            OBJRECPAY.SALEBILLINITIALS = PURreginitial & "-" & TEMPEXPNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If Convert.ToDateTime(PARTYBILLDATE.Text).Date < EXPBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(EXPBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Voucher Entry Permanently?", MsgBoxStyle.YesNo, "PROTRADE")
                If tempmsg = vbYes Then

                    Dim OBJNONPURCHASE As New ClsExpenseVoucher
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPEXPNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJNONPURCHASE.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJNONPURCHASE.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    EDIT = False
                    clear()
                    CMBNAME.Focus()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExpenseVoucher_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
        If ClientName = "PARAS" Then LBLGROUPNAME.Visible = True
        If ClientName = "CC" Or ClientName = "SHREEDEV" Then ALLOWMANUALNPNO = True
        If ClientName = "SOFTAS" Or ClientName = "AVIS" Then NPDATE.TabStop = False
    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            'TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()


            If CMBHSNCODE.Text.Trim <> "" And Convert.ToDateTime(NPDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(PARTYBILLDATE.Text).Date, "MM/dd/yyyy") & "' AND HSNMASTER.HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If DT.Rows.Count > 0 Then
                    'TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If
                End If
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOTHERAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERAMT.KeyPress, TXTROUNDOFF.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated, TXTQTY.Validated, TXTRATE.Validated, TXTAMT.Validated, TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTGRIDTOTAL.Text = 0.0
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTQTY.Text.Trim) > 0 Then TXTAMT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")

            If CHKRCM.CheckState = CheckState.Checked Then TXTTAXABLEAMT.Text = Format((Val(TXTAMT.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0") Else TXTTAXABLEAMT.Text = Format((Val(TXTAMT.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            End If
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALROUND_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALROUND.CheckedChanged
        Try
            If CHKMANUALROUND.Checked = True Then
                TXTROUNDOFF.ReadOnly = False
                TXTROUNDOFF.TabStop = True
            Else
                TXTROUNDOFF.ReadOnly = True
                TXTROUNDOFF.TabStop = False
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            Dim OBJCMN As New ClsCommon
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS, OPEN ALL ACCOUNTS
                Dim DT As DataTable = OBJCMN.search("ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_RCM,0) AS RCM, ISNULL(GROUPMASTER.GROUP_NAME,'') AS GROUPNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_REGISTERID = REGISTER_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                    If EDIT = False Then CHKRCM.Checked = Convert.ToBoolean(DT.Rows(0).Item("RCM"))
                    LBLGROUPNAME.Text = DT.Rows(0).Item("GROUPNAME")

                    'If DT.Rows(0).Item("REGISTERNAME") <> CMBREGISTER.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
                    '    Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
                    '    If TEMPMSG = vbYes Then
                    '        CMBREGISTER.Text = DT.Rows(0).Item("REGISTERNAME")
                    '        getmaxno()
                    '    End If
                    'End If
                    TOTAL()
                End If

                'GET TDSAPPLICABLE
                DT = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TDSPER")) > 0 Then CHKTDS.CheckState = CheckState.Checked
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDTOTAL.Validating
        Try
            If CMBDRNAME.Text.Trim <> "" And Val(TXTAMT.Text.Trim) <> 0 And TXTSRNO.Text.Trim > 0 Then
                fillgrid()
                TOTAL()
            Else
                MsgBox("Fill Proper Details", MsgBoxStyle.Critical, "PROTRADE")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        TOTAL()
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            ToolStripdelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROUNDOFF_Validated(sender As Object, e As EventArgs) Handles TXTROUNDOFF.Validated
        total()
    End Sub

    Private Sub PARTYBILLDATE_Validating(sender As Object, e As CancelEventArgs) Handles PARTYBILLDATE.Validating
        Try
            If PARTYBILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PARTYBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If EDIT = False And ClientName <> "SAKARIA" And ClientName <> "AVIS" Then NPDATE.Text = PARTYBILLDATE.Text
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PARTYBILLDATE_GotFocus(sender As Object, e As EventArgs) Handles PARTYBILLDATE.GotFocus
        Try
            PARTYBILLDATE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class