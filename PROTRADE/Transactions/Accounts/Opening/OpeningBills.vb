
Imports System.ComponentModel
Imports BL

Public Class OpeningBills

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPREGNAME As String
    Public TEMPNAME As String
    Public FRMSTRING As String

    Dim regabbr, reginitial As String
    Dim regid As Integer
    Dim TEMPROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        'clearing textboxes
        EP.Clear()
        txtopening.Clear()
        lbldrcropening.Text = ""
        LBLTOTAL.Text = 0.0
        CMBNAME.Text = ""
        CMBACCCODE.Text = ""

        TXTSRNO.Clear()
        CMBTYPE.SelectedIndex = 0
        CMBREGISTER.Text = ""
        TXTBILLNO.Clear()
        TXTYEAR.Clear()
        BILLDATE.Value = Now.Date
        TXTCRDAYS.Clear()
        DUEDATE.Value = Now.Date
        CMBAGENT.Text = ""
        TXTREMARKS.Clear()
        CHKDISPUTE.Checked = False
        DUEDATE.Enabled = True

        TXTPCS.Clear()
        TXTMTRS.Clear()
        TXTTOTALAMT.Clear()
        TXTCHARGES.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRANDTOTAL.Clear()
        TXTAMT.Clear()

        If FRMSTRING = "OPENINGBILLS" Then
            lbl.Text = "Opening Bill"
            Me.Text = "Opening Bill"
        Else
            CMBTYPE.Enabled = True
            lbl.Text = "Opening Bill (Interest)"
            Me.Text = "Opening Bill (Interest)"
        End If


        regabbr = ""
        reginitial = ""

        GRIDOPENING.RowCount = 0

        CMBNAME.Enabled = True
        CMBACCCODE.Enabled = True

        EDIT = False
        GRIDDOUBLECLICK = False

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'OPEN ALL LEDGERS
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBREGISTER.Enter
        Try
            Dim WHERECLAUSE As String = ""
            If CMBTYPE.Text = "SALE" Then
                WHERECLAUSE = " AND REGISTER_TYPE = 'SALE'"
            ElseIf CMBTYPE.Text = "PURCHASE" Then
                WHERECLAUSE = " AND (REGISTER_TYPE = 'PURCHASE' OR  REGISTER_TYPE = 'EXPENSE')"
            ElseIf CMBTYPE.Text = "RECEIPT" Then
                WHERECLAUSE = " AND REGISTER_TYPE = 'RECEIPT'"
            ElseIf CMBTYPE.Text = "PAYMENT" Then
                WHERECLAUSE = " AND REGISTER_TYPE = 'PAYMENT'"
            ElseIf CMBTYPE.Text = "CREDIT" Then
                WHERECLAUSE = " AND (REGISTER_TYPE = 'CREDITNOTE' OR REGISTER_TYPE = 'SALERETURN')"
            ElseIf CMBTYPE.Text = "DEBIT" Then
                WHERECLAUSE = " AND REGISTER_TYPE = 'DEBITNOTE'"
            End If
            If CMBREGISTER.Text.Trim = "" Then fillregister(CMBREGISTER, WHERECLAUSE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBREGISTER.Validating
        Try
            If CMBREGISTER.Text.Trim.Length > 0 Then
                'clear()
                CMBREGISTER.Text = UCase(CMBREGISTER.Text)

                Dim WHERECLAUSE As String = ""
                If CMBTYPE.Text = "SALE" Then
                    WHERECLAUSE = " AND REGISTER_TYPE = 'SALE'"
                ElseIf CMBTYPE.Text = "PURCHASE" Then
                    WHERECLAUSE = " AND (REGISTER_TYPE = 'PURCHASE' OR  REGISTER_TYPE = 'EXPENSE')"
                ElseIf CMBTYPE.Text = "RECEIPT" Then
                    WHERECLAUSE = " AND REGISTER_TYPE = 'RECEIPT'"
                ElseIf CMBTYPE.Text = "PAYMENT" Then
                    WHERECLAUSE = " AND REGISTER_TYPE = 'PAYMENT'"
                ElseIf CMBTYPE.Text = "CREDIT" Then
                    WHERECLAUSE = " AND (REGISTER_TYPE = 'CREDITNOTE' OR REGISTER_TYPE = 'SALERETURN')"
                ElseIf CMBTYPE.Text = "DEBIT" Then
                    WHERECLAUSE = " AND REGISTER_TYPE = 'DEBITNOTE'"
                End If

                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & CMBREGISTER.Text.Trim & "' AND REGISTER_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
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
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBNAME.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAMT.GotFocus
        TXTAMT.SelectAll()
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress, TXTMTRS.KeyPress, TXTTOTALAMT.KeyPress, TXTCGSTPER.KeyPress, TXTCGSTAMT.KeyPress, TXTSGSTPER.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTPER.KeyPress, TXTIGSTAMT.KeyPress, TXTGRANDTOTAL.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBILLNO.KeyPress, TXTPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Name")
                BLN = False
            End If

            If GRIDOPENING.RowCount = 0 Then
                EP.SetError(TXTAMT, "Enter Bill Details")
                BLN = False
            End If


            If FRMSTRING = "OPENINGBILLS" Then
                'CHECK WHETHER OPENINGTOTAL MATCHES WITH THE OPENING BAL IN LEDGERS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ACC_OPBAL, ACC_DRCR", "", " LEDGERS", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'")
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item(0)) <> Val(LBLTOTAL.Text.Trim) Then
                        MsgBox("Total Does not match in Ledgers", MsgBoxStyle.Critical)
                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub OpeningBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OpeningBills_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()

            fillledger(CMBNAME, EDIT, " and acc_YEARid = " & YearId)
            fillregister(CMBREGISTER, "")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBDELIVERYAT.Text.Trim = "" Then fillname(CMBDELIVERYAT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY, LEDGERS.ACC_OPBAL AS OPBAL, LEDGERS.ACC_DRCR AS DRCR", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    txtopening.Text = Format(Val(DT.Rows(0).Item("OPBAL")), "0.00")
                    lbldrcropening.Text = DT.Rows(0).Item("DRCR")

                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        CMBTYPE.Text = "PURCHASE"
                    Else
                        CMBTYPE.Text = "SALE"
                    End If
                    EDIT = True
                End If

                CMBNAME.Enabled = False
                CMBACCCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' or groupmaster.group_SECONDARY = 'Indirect Income' or groupmaster.group_SECONDARY = 'Direct Income') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBNAME.Text.Trim <> "" Then ledgervalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If TXTBILLNO.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then
                FILLGRIDOPENING()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDOPENING()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" OPENINGBILL.BILL_GRIDSRNO AS GRIDSRNO, OPENINGBILL.BILL_TYPE AS BILLTYPE, OPENINGBILL.BILL_NO AS BILLNO, OPENINGBILL.BILL_YEAR AS YEAR, OPENINGBILL.BILL_DATE AS BILLDATE, OPENINGBILL.BILL_CRDAYS AS CRDAYS, OPENINGBILL.BILL_DUEDATE AS DUEDATE, ISNULL(AGENTLEDGERS.ACC_CMPNAME, '') AS AGENT, OPENINGBILL.BILL_NARRATION AS NARRATION, OPENINGBILL.BILL_DISPUTE AS DISPUTE, OPENINGBILL.BILL_AMT AS AMT, OPENINGBILL.BILL_AMTPAIDREC AS AMTPAIDREC, OPENINGBILL.BILL_EXTRAAMT AS EXTRAAMT, OPENINGBILL.BILL_RETURN AS [RETURN], OPENINGBILL.BILL_BALANCE AS BALANCE, ISNULL(REGISTER_NAME,'') AS REGNAME, ISNULL(BILL_PRINTINITIALS,'') AS PRINTINITIALS, ISNULL(DELIVERYLEDGERS.Acc_cmpname, '') AS DELIVERYAT, ISNULL(OPENINGBILL.BILL_PCS, 0) AS PCS, ISNULL(OPENINGBILL.BILL_MTRS, 0) AS MTRS, ISNULL(OPENINGBILL.BILL_TOTALAMT, 0) AS TOTALAMT, ISNULL(OPENINGBILL.BILL_CHARGES, 0) AS CHARGES, ISNULL(OPENINGBILL.BILL_TAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(OPENINGBILL.BILL_CGSTPER, 0) AS CGSTPER, ISNULL(OPENINGBILL.BILL_CGSTAMT, 0) AS CGSTAMT, ISNULL(OPENINGBILL.BILL_SGSTPER, 0) AS SGSTPER, ISNULL(OPENINGBILL.BILL_SGSTAMT, 0) AS SGSTAMT, ISNULL(OPENINGBILL.BILL_IGSTPER, 0) AS IGSTPER, ISNULL(OPENINGBILL.BILL_IGSTAMT, 0) AS IGSTAMT, ISNULL(OPENINGBILL.BILL_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.Acc_id INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID LEFT OUTER JOIN LEDGERS AS DELIVERYLEDGERS ON OPENINGBILL.BILL_DELIVERYATID = DELIVERYLEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_YEARID = " & YearId & "  ORDER BY OPENINGBILL.BILL_GRIDSRNO ")
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    GRIDOPENING.Rows.Add(ROW("GRIDSRNO"), ROW("BILLTYPE"), ROW("REGNAME"), ROW("BILLNO"), ROW("YEAR"), Format(Convert.ToDateTime(ROW("BILLDATE")).Date, "dd/MM/yyyy"), ROW("CRDAYS"), Format(Convert.ToDateTime(ROW("DUEDATE")).Date, "dd/MM/yyyy"), ROW("AGENT"), ROW("NARRATION"), ROW("DISPUTE"), ROW("DELIVERYAT"), Val(ROW("PCS")), Val(ROW("MTRS")), Val(ROW("TOTALAMT")), Val(ROW("CHARGES")), Val(ROW("TAXABLEAMT")), Val(ROW("CGSTPER")), Val(ROW("CGSTAMT")), Val(ROW("SGSTPER")), Val(ROW("SGSTAMT")), Val(ROW("IGSTPER")), Val(ROW("IGSTAMT")), Val(ROW("GRANDTOTAL")), Format(Val(ROW("AMT")), "0.00"), Format(Val(ROW("AMTPAIDREC")), "0.00"), Format(Val(ROW("EXTRAAMT")), "0.00"), Format(Val(ROW("RETURN")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"), ROW("PRINTINITIALS"))
                    If (Val(ROW("AMTPAIDREC")) > 0 Or Val(ROW("RETURN")) > 0) Then GRIDOPENING.Rows(GRIDOPENING.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim INTRESULT As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(CMBNAME.Text.Trim)
            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim TYPE As String = ""
            Dim REGNAME As String = ""
            Dim BILLNO As String = ""
            Dim YEAR As String = ""
            Dim BILLDATE As String = ""
            Dim CRDAYS As String = "" 'NEW FIELD ADDED
            Dim BILLDUEDATE As String = ""
            Dim AGENTNAME As String = ""
            Dim NARRATION As String = "" 'NEW FIELD ADDED
            Dim DISPUTE As String = "" 'NEW FIELD ADDED
            Dim DELIVERYAT As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim TOTALAMT As String = ""
            Dim CHARGES As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRANDTOTAL As String = ""
            Dim AMT As String = ""
            Dim AMTPAIDREC As String = ""
            Dim EXTRAAMT As String = ""
            Dim [RETURN] As String = ""
            Dim BALANCE As String = ""
            Dim PRINTINITIALS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDOPENING.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        TYPE = row.Cells(GBILLTYPE.Index).Value
                        REGNAME = row.Cells(GREGISTER.Index).Value
                        BILLNO = row.Cells(GBILLNO.Index).Value.ToString
                        YEAR = row.Cells(GYEAR.Index).Value
                        BILLDATE = Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        CRDAYS = row.Cells(GCRDAYS.Index).Value
                        BILLDUEDATE = Format(Convert.ToDateTime(row.Cells(GDUEDATE.Index).Value).Date, "MM/dd/yyyy")
                        AGENTNAME = row.Cells(GAGENT.Index).Value
                        NARRATION = row.Cells(GNARRATION.Index).Value
                        DISPUTE = row.Cells(GDISPUTE.Index).Value
                        DELIVERYAT = row.Cells(GDELIVERYAT.Index).Value
                        PCS = Val(row.Cells(GPCS.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        TOTALAMT = Val(row.Cells(GTOTALAMT.Index).Value)
                        CHARGES = Val(row.Cells(GCHARGES.Index).Value)
                        TAXABLEAMT = Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = Val(row.Cells(GIGSTAMT.Index).Value)
                        GRANDTOTAL = Val(row.Cells(GGRANDTOTAL.Index).Value)
                        AMT = Val(row.Cells(GAMT.Index).Value)
                        AMTPAIDREC = row.Cells(GAMTPAIDREC.Index).Value
                        EXTRAAMT = row.Cells(GEXTRAAMT.Index).Value
                        [RETURN] = row.Cells(GRETURN.Index).Value
                        BALANCE = row.Cells(GBALANCE.Index).Value
                        PRINTINITIALS = row.Cells(GPRINTINITIALS.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                        TYPE = TYPE & "|" & row.Cells(GBILLTYPE.Index).Value
                        REGNAME = REGNAME & "|" & row.Cells(GREGISTER.Index).Value
                        BILLNO = BILLNO & "|" & row.Cells(GBILLNO.Index).Value.ToString
                        YEAR = YEAR & "|" & row.Cells(GYEAR.Index).Value
                        BILLDATE = BILLDATE & "|" & Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        CRDAYS = CRDAYS & "|" & row.Cells(GCRDAYS.Index).Value
                        BILLDUEDATE = BILLDUEDATE & "|" & Format(Convert.ToDateTime(row.Cells(GDUEDATE.Index).Value).Date, "MM/dd/yyyy")
                        AGENTNAME = AGENTNAME & "|" & row.Cells(GAGENT.Index).Value
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value
                        DISPUTE = DISPUTE & "|" & row.Cells(GDISPUTE.Index).Value
                        DELIVERYAT = DELIVERYAT & "|" & row.Cells(GDELIVERYAT.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        TOTALAMT = TOTALAMT & "|" & Val(row.Cells(GTOTALAMT.Index).Value)
                        CHARGES = CHARGES & "|" & Val(row.Cells(GCHARGES.Index).Value)
                        TAXABLEAMT = TAXABLEAMT & "|" & Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = CGSTAMT & "|" & Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = SGSTAMT & "|" & Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = IGSTAMT & "|" & Val(row.Cells(GIGSTAMT.Index).Value)
                        GRANDTOTAL = GRANDTOTAL & "|" & Val(row.Cells(GGRANDTOTAL.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(GAMT.Index).Value)
                        AMTPAIDREC = AMTPAIDREC & "|" & row.Cells(GAMTPAIDREC.Index).Value
                        EXTRAAMT = EXTRAAMT & "|" & row.Cells(GEXTRAAMT.Index).Value
                        [RETURN] = [RETURN] & "|" & row.Cells(GRETURN.Index).Value
                        BALANCE = BALANCE & "|" & row.Cells(GBALANCE.Index).Value
                        PRINTINITIALS = PRINTINITIALS & "|" & row.Cells(GPRINTINITIALS.Index).Value

                    End If
                End If
            Next


            alparaval.Add(GRIDSRNO)
            alparaval.Add(TYPE)
            alparaval.Add(REGNAME)
            alparaval.Add(BILLNO)
            alparaval.Add(YEAR)
            alparaval.Add(BILLDATE)
            alparaval.Add(CRDAYS)
            alparaval.Add(BILLDUEDATE)
            alparaval.Add(AGENTNAME)
            alparaval.Add(NARRATION)
            alparaval.Add(DISPUTE)
            alparaval.Add(DELIVERYAT)
            alparaval.Add(PCS)
            alparaval.Add(MTRS)
            alparaval.Add(TOTALAMT)
            alparaval.Add(CHARGES)
            alparaval.Add(TAXABLEAMT)
            alparaval.Add(CGSTPER)
            alparaval.Add(CGSTAMT)
            alparaval.Add(SGSTPER)
            alparaval.Add(SGSTAMT)
            alparaval.Add(IGSTPER)
            alparaval.Add(IGSTAMT)
            alparaval.Add(GRANDTOTAL)
            alparaval.Add(AMT)
            alparaval.Add(AMTPAIDREC)
            alparaval.Add(EXTRAAMT)
            alparaval.Add([RETURN])
            alparaval.Add(BALANCE)
            alparaval.Add(PRINTINITIALS)


            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CODE = '" & CMBACCCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
            '        alparaval.Add("PURCHASE REGISTER")
            '        alparaval.Add("PURCHASE")
            '    Else
            '        alparaval.Add("SALE REGISTER")
            '        alparaval.Add("SALE")
            '    End If
            'End If


            Dim OBJOPENING As New ClsOpening
            OBJOPENING.alParaval = alparaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            INTRESULT = OBJOPENING.SAVE()
            MessageBox.Show("Details Added")
            clear()
            EDIT = False
            CMBNAME.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        LBLTOTAL.Text = 0.0
        For Each row As DataGridViewRow In GRIDOPENING.Rows
            If row.Cells(GBILLTYPE.Index).Value = "PURCHASE" Or row.Cells(GBILLTYPE.Index).Value = "RECEIPT" Or row.Cells(GBILLTYPE.Index).Value = "CREDIT" Then LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) - Val(row.Cells(GAMT.Index).Value), "0.00") Else LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) + Val(row.Cells(GAMT.Index).Value), "0.00")
        Next
        If Val(LBLTOTAL.Text) < 0 Then LBLTOTAL.Text = Val(LBLTOTAL.Text) * -1
    End Sub

    Sub FILLGRID()
        Try

            For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                If (GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Then
                    If Val(ROW.Cells(GBILLNO.Index).Value) = Val(TXTBILLNO.Text.Trim) And ROW.Cells(GYEAR.Index).Value = TXTYEAR.Text.Trim Then
                        MsgBox("Bill No Already Present in Grid below", MsgBoxStyle.Critical)
                        TXTSRNO.Focus()
                        Exit Sub
                    End If
                End If
            Next

            If GRIDDOUBLECLICK = False Then
                If CHKDISPUTE.Checked = True Then
                    GRIDOPENING.Rows.Add(TXTSRNO.Text.Trim, CMBTYPE.Text.Trim, CMBREGISTER.Text.Trim, TXTBILLNO.Text.Trim, TXTYEAR.Text.Trim, Format(BILLDATE.Value.Date, "dd/MM/yyyy"), TXTCRDAYS.Text.Trim, Format(DUEDATE.Value.Date, "dd/MM/yyyy"), CMBAGENT.Text.Trim, TXTREMARKS.Text.Trim, 1, CMBDELIVERYAT.Text.Trim, Val(TXTPCS.Text.Trim), Val(TXTMTRS.Text.Trim), Val(TXTTOTALAMT.Text.Trim), Val(TXTCHARGES.Text.Trim), Val(TXTTAXABLEAMT.Text.Trim), Val(TXTCGSTPER.Text.Trim), Val(TXTCGSTAMT.Text.Trim), Val(TXTSGSTPER.Text.Trim), Val(TXTSGSTAMT.Text.Trim), Val(TXTIGSTPER.Text.Trim), Val(TXTIGSTAMT.Text.Trim), Val(TXTGRANDTOTAL.Text.Trim), Val(TXTAMT.Text.Trim), 0, 0, 0, 0, "")
                Else
                    GRIDOPENING.Rows.Add(TXTSRNO.Text.Trim, CMBTYPE.Text.Trim, CMBREGISTER.Text.Trim, TXTBILLNO.Text.Trim, TXTYEAR.Text.Trim, Format(BILLDATE.Value.Date, "dd/MM/yyyy"), TXTCRDAYS.Text.Trim, Format(DUEDATE.Value.Date, "dd/MM/yyyy"), CMBAGENT.Text.Trim, TXTREMARKS.Text.Trim, 0, CMBDELIVERYAT.Text.Trim, Val(TXTPCS.Text.Trim), Val(TXTMTRS.Text.Trim), Val(TXTTOTALAMT.Text.Trim), Val(TXTCHARGES.Text.Trim), Val(TXTTAXABLEAMT.Text.Trim), Val(TXTCGSTPER.Text.Trim), Val(TXTCGSTAMT.Text.Trim), Val(TXTSGSTPER.Text.Trim), Val(TXTSGSTAMT.Text.Trim), Val(TXTIGSTPER.Text.Trim), Val(TXTIGSTAMT.Text.Trim), Val(TXTGRANDTOTAL.Text.Trim), Val(TXTAMT.Text.Trim), 0, 0, 0, 0, "")
                End If
                getsrno(GRIDOPENING)
            Else
                GRIDOPENING.Item(GSRNO.Index, TEMPROW).Value = TXTSRNO.Text.Trim
                GRIDOPENING.Item(GBILLTYPE.Index, TEMPROW).Value = CMBTYPE.Text.Trim
                GRIDOPENING.Item(GREGISTER.Index, TEMPROW).Value = CMBREGISTER.Text.Trim
                GRIDOPENING.Item(GBILLNO.Index, TEMPROW).Value = TXTBILLNO.Text.Trim
                GRIDOPENING.Item(GYEAR.Index, TEMPROW).Value = TXTYEAR.Text.Trim
                GRIDOPENING.Item(GBILLDATE.Index, TEMPROW).Value = Format(BILLDATE.Value.Date, "dd/MM/yyyy")
                GRIDOPENING.Item(GCRDAYS.Index, TEMPROW).Value = TXTCRDAYS.Text.Trim
                GRIDOPENING.Item(GDUEDATE.Index, TEMPROW).Value = Format(DUEDATE.Value.Date, "dd/MM/yyyy")
                GRIDOPENING.Item(GAGENT.Index, TEMPROW).Value = CMBAGENT.Text.Trim
                GRIDOPENING.Item(GNARRATION.Index, TEMPROW).Value = TXTREMARKS.Text.Trim
                If CHKDISPUTE.Checked = True Then
                    GRIDOPENING.Item(GDISPUTE.Index, TEMPROW).Value = 1
                Else
                    GRIDOPENING.Item(GDISPUTE.Index, TEMPROW).Value = 0
                End If
                GRIDOPENING.Item(GDELIVERYAT.Index, TEMPROW).Value = CMBDELIVERYAT.Text.Trim
                GRIDOPENING.Item(GPCS.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0")
                GRIDOPENING.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDOPENING.Item(GTOTALAMT.Index, TEMPROW).Value = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                GRIDOPENING.Item(GCHARGES.Index, TEMPROW).Value = Format(Val(TXTCHARGES.Text.Trim), "0.00")
                GRIDOPENING.Item(GTAXABLEAMT.Index, TEMPROW).Value = Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00")
                GRIDOPENING.Item(GCGSTPER.Index, TEMPROW).Value = Format(Val(TXTCGSTPER.Text.Trim), "0.00")
                GRIDOPENING.Item(GCGSTAMT.Index, TEMPROW).Value = Format(Val(TXTCGSTAMT.Text.Trim), "0.00")
                GRIDOPENING.Item(GSGSTPER.Index, TEMPROW).Value = Format(Val(TXTSGSTPER.Text.Trim), "0.00")
                GRIDOPENING.Item(GSGSTAMT.Index, TEMPROW).Value = Format(Val(TXTSGSTAMT.Text.Trim), "0.00")
                GRIDOPENING.Item(GIGSTPER.Index, TEMPROW).Value = Format(Val(TXTIGSTPER.Text.Trim), "0.00")
                GRIDOPENING.Item(GIGSTAMT.Index, TEMPROW).Value = Format(Val(TXTIGSTAMT.Text.Trim), "0.00")
                GRIDOPENING.Item(GGRANDTOTAL.Index, TEMPROW).Value = Format(Val(TXTGRANDTOTAL.Text.Trim), "0.00")
                GRIDOPENING.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If
            total()

            GRIDOPENING.FirstDisplayedScrollingRowIndex = GRIDOPENING.RowCount - 1

            TXTSRNO.Clear()
            CMBREGISTER.Text = ""
            TXTBILLNO.Text = ""
            TXTYEAR.Text = ""
            BILLDATE.Value = Now.Date
            TXTCRDAYS.Clear()
            DUEDATE.Value = Now.Date
            CMBAGENT.Text = ""
            TXTREMARKS.Clear()
            CHKDISPUTE.Checked = False
            CMBDELIVERYAT.Text = ""
            TXTPCS.Clear()
            TXTMTRS.Clear()
            TXTTOTALAMT.Clear()
            TXTCHARGES.Clear()
            TXTTAXABLEAMT.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()
            TXTGRANDTOTAL.Clear()
            TXTAMT.Clear()
            CMBTYPE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDOPENING.CellDoubleClick
        Try

            If (Val(GRIDOPENING.Rows(e.RowIndex).Cells(GAMTPAIDREC.Index).Value) > 0 Or Val(GRIDOPENING.Rows(e.RowIndex).Cells(GRETURN.Index).Value) > 0) Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If e.RowIndex >= 0 And GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDOPENING.Item(GBILLTYPE.Index, e.RowIndex).Value.ToString
                CMBREGISTER.Text = GRIDOPENING.Item(GREGISTER.Index, e.RowIndex).Value.ToString
                TXTBILLNO.Text = GRIDOPENING.Item(GBILLNO.Index, e.RowIndex).Value.ToString
                TXTYEAR.Text = GRIDOPENING.Item(GYEAR.Index, e.RowIndex).Value.ToString
                BILLDATE.Value = Convert.ToDateTime(GRIDOPENING.Item(GBILLDATE.Index, e.RowIndex).Value).Date
                TXTCRDAYS.Text = Val(GRIDOPENING.Item(GCRDAYS.Index, e.RowIndex).Value)
                DUEDATE.Value = Convert.ToDateTime(GRIDOPENING.Item(GDUEDATE.Index, e.RowIndex).Value).Date
                CMBAGENT.Text = GRIDOPENING.Item(GAGENT.Index, e.RowIndex).Value.ToString
                TXTREMARKS.Text = GRIDOPENING.Item(GNARRATION.Index, e.RowIndex).Value.ToString
                CHKDISPUTE.Checked = Convert.ToBoolean(GRIDOPENING.Item(GDISPUTE.Index, e.RowIndex).Value)
                CMBDELIVERYAT.Text = GRIDOPENING.Item(GDELIVERYAT.Index, e.RowIndex).Value.ToString
                TXTPCS.Text = GRIDOPENING.Item(GPCS.Index, e.RowIndex).Value.ToString
                TXTMTRS.Text = GRIDOPENING.Item(GMTRS.Index, e.RowIndex).Value.ToString
                TXTTOTALAMT.Text = GRIDOPENING.Item(GTOTALAMT.Index, e.RowIndex).Value.ToString
                TXTCHARGES.Text = GRIDOPENING.Item(GCHARGES.Index, e.RowIndex).Value.ToString
                TXTTAXABLEAMT.Text = GRIDOPENING.Item(GTAXABLEAMT.Index, e.RowIndex).Value.ToString
                TXTCGSTPER.Text = GRIDOPENING.Item(GCGSTPER.Index, e.RowIndex).Value.ToString
                TXTCGSTAMT.Text = GRIDOPENING.Item(GCGSTAMT.Index, e.RowIndex).Value.ToString
                TXTSGSTPER.Text = GRIDOPENING.Item(GSGSTPER.Index, e.RowIndex).Value.ToString
                TXTSGSTAMT.Text = GRIDOPENING.Item(GSGSTAMT.Index, e.RowIndex).Value.ToString
                TXTIGSTPER.Text = GRIDOPENING.Item(GIGSTPER.Index, e.RowIndex).Value.ToString
                TXTIGSTAMT.Text = GRIDOPENING.Item(GIGSTAMT.Index, e.RowIndex).Value.ToString
                TXTGRANDTOTAL.Text = GRIDOPENING.Item(GGRANDTOTAL.Index, e.RowIndex).Value.ToString
                TXTAMT.Text = GRIDOPENING.Item(GAMT.Index, e.RowIndex).Value.ToString

                TEMPROW = e.RowIndex
                CMBTYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDOPENING.KeyDown

        If e.KeyCode = Keys.Delete Then

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            'if REC/PAYMERNT IS MADE THEN DONT ALLOW TO DELETE
            If (Val(GRIDOPENING.Rows(GRIDOPENING.CurrentRow.Index).Cells(GAMTPAIDREC.Index).Value) > 0 Or Val(GRIDOPENING.Rows(GRIDOPENING.CurrentRow.Index).Cells(GRETURN.Index).Value) > 0) Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete Bill No " & GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBNAME.Text.Trim)
                    ALPARAVAL.Add(GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJOP.alParaval = ALPARAVAL

                    If FRMSTRING = "OPENINGBILLS" Then
                        Dim INTRES As Integer = OBJOP.DELETE
                    Else
                        Dim INTRES As Integer = OBJOP.DELETEINT
                    End If

                    GRIDOPENING.Rows.RemoveAt(GRIDOPENING.CurrentRow.Index)
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If

        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBNAME.Enabled = True
        CMBNAME.Focus()
    End Sub

    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBACCCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            If CMBACCCODE.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CODE = '" & CMBACCCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        CMBTYPE.Text = "PURCHASE"
                    Else
                        CMBTYPE.Text = "SALE"
                    End If
                End If
                CMBNAME.Enabled = False
                CMBACCCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            If TXTSRNO.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)
            If DUEDATE.Value.Date < BILLDATE.Value.Date Then
                MsgBox("Bill Date Cannot be Less that Due Date", MsgBoxStyle.Critical)
                BILLDATE.Focus()
                Exit Sub
            End If
            If TXTSRNO.Text.Trim.Length > 0 And Val(TXTAMT.Text) > 0 And TXTBILLNO.Text.Trim <> "" And TXTYEAR.Text.Trim <> "" And CMBTYPE.Text <> "" And CMBREGISTER.Text.Trim <> "" Then
                FILLGRID()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDOPENING.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDOPENING.Rows(GRIDOPENING.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete All Bills of " & CMBNAME.Text.Trim, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening

                    For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(CMBNAME.Text.Trim)
                        ALPARAVAL.Add(ROW.Cells(GBILLNO.Index).Value)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJOP.alParaval = ALPARAVAL

                        If FRMSTRING = "OPENINGBILLS" Then
                            Dim INTRES As Integer = OBJOP.DELETE
                        Else
                            Dim INTRES As Integer = OBJOP.DELETEINT
                        End If
                    Next
                    clear()
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJOP As New OpeningBillDetails
            OBJOP.MdiParent = MDIMain
            OBJOP.FRMSTRING = FRMSTRING
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpeningBills_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SVS" Then Me.Close()
            If TEMPNAME <> "" Then
                CMBNAME.Text = TEMPNAME
                cmbname_Validated(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        Try
            If CMBTYPE.Text.Trim <> "" And CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY as GROUPNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID AND ACC_CMPID = GROUP_CMPID AND ACC_LOCATIONID = GROUP_LOCATIONID AND ACC_YEARID = GROUP_YEARID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID  = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                'If DT.Rows(0).Item("GROUPNAME") = "Sundry Creditors" And CMBTYPE.Text = "SALE" Then
                '    MsgBox("SALE not Allowed to Creditors", MsgBoxStyle.Critical)
                '    e.Cancel = True
                'ElseIf DT.Rows(0).Item("GROUPNAME") = "Sundry Debtors" And CMBTYPE.Text = "PURCHASE" Then
                '    MsgBox("PURCHASE not Allowed to Debtors", MsgBoxStyle.Critical)
                '    e.Cancel = True
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        Try
            If Val(TXTCRDAYS.Text.Trim) > 0 Then DUEDATE.Value = BILLDATE.Value.AddDays(Val(TXTCRDAYS.Text.Trim))
            DUEDATE.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRDAYS.KeyPress
        numdotkeypress(e, TXTCRDAYS, Me)
    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            If CMBTYPE.Text.Trim = "SALE" And GRIDDOUBLECLICK = False Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BILL_NO as BILLNO", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id ", " AND OPENINGBILL.BILL_NO='" & TXTBILLNO.Text.Trim & "' and OPENINGBILL.BILL_YEAR = '" & TXTYEAR.Text.Trim & "' AND BILL_TYPE = 'SALE' AND BILL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox(" Bill No already Exists", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHARGES_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCHARGES.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub CMBDELIVERYAT_Enter(sender As Object, e As EventArgs) Handles CMBDELIVERYAT.Enter
        Try
            If CMBDELIVERYAT.Text.Trim = "" Then fillledger(CMBDELIVERYAT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDELIVERYAT.Validating
        Try
            If CMBDELIVERYAT.Text.Trim <> "" Then ledgervalidate(CMBDELIVERYAT, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class