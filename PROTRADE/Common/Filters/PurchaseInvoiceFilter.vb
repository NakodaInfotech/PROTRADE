
Imports System.ComponentModel
Imports BL

Public Class PurchaseInvoiceFilter
    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, edit, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Sale A/C' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' )")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, txtadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses'  or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim <> "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, "")
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, edit, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Sale A/C' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' )")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
            fillregister(cmbregister, " and register_type = 'PURCHASE'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, ISNULL(GROUPMASTER.GROUP_NAME,'') AS GROUPNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY, ISNULL(STATEMASTER.STATE_NAME,'') AS STATENAME, ISNULL(AREA_NAME,'') AS AREA ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATEMASTER.STATE_ID LEFT OUTER JOIN AREAMASTER ON LEDGERS.ACC_AREAID = AREAMASTER.AREA_ID", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBITEMRATE.Checked = True Then
                Dim OBJRATE As New PurchaseItemRateReport
                If CMBNAME.Text <> "" Then OBJRATE.WHERECLAUSE = OBJRATE.WHERECLAUSE & " and LEDGERS.ACC_CMPNAME ='" & CMBNAME.Text.Trim & "'"
                If CMBITEMNAME.Text <> "" Then OBJRATE.WHERECLAUSE = OBJRATE.WHERECLAUSE & " and ITEMMASTER.ITEM_NAME='" & CMBITEMNAME.Text.Trim & "'"
                If cmbregister.Text <> "" Then OBJRATE.WHERECLAUSE = OBJRATE.WHERECLAUSE & " and REGISTERMASTER.REGISTER_NAME='" & cmbregister.Text.Trim & "'"
                OBJRATE.MdiParent = MDIMain
                OBJRATE.FRMSTRING = "PURCHASE"
                OBJRATE.Show()
                Exit Sub
            End If



            'IF LABEL PRINT IS SELECTED THEN PRINT ONLYN THOSE LEDGERS WHOSE INVOICES ARE CREATED WITHIN THAT DATE
            'ELSE PRINT ALL LEDGERS (SUNDRY DEBTORS ONLY)
            Dim NAMECLAUSE As String = ""
            If RDBLABEL.Checked = True Then
                Dim OBJLABEL As New SaleInvoiceDesign
                OBJLABEL.MdiParent = MDIMain
                OBJLABEL.FRMSTRING = "LABEL"
                OBJLABEL.WHERECLAUSE = " {LEDGERS.ACC_YEARID} = " & YearId

                'FOR PARTYNAME
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                Next

                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    OBJLABEL.WHERECLAUSE = OBJLABEL.WHERECLAUSE & NAMECLAUSE
                End If

                OBJLABEL.Show()
                Exit Sub
            End If



            If RBENVELOPE.Checked = True Then
                Dim OBJENV As New payment_advice
                OBJENV.FRMSTRING = "ENVELOPE"
                OBJENV.MdiParent = MDIMain
                OBJENV.WHERECLAUSE = " {LEDGERS.ACC_YEARID} = " & YearId

                'FOR PARTYNAME
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                Next

                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    OBJENV.WHERECLAUSE = OBJENV.WHERECLAUSE & NAMECLAUSE
                End If

                OBJENV.Show()
                Exit Sub
            End If



            Dim OBJGRN As New PurchaseInvoiceDesign
            OBJGRN.SHOWNARRATION = CHKNARRATION.Checked
            OBJGRN.MdiParent = MDIMain
            OBJGRN.WHERECLAUSE = " {PURCHASEMASTER.BILL_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                If ClientName = "SAKARIA" Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@ENTRYDATE} in date " & fromD & " to date " & toD & ""
                Else
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                End If
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "PARTYWISEDTLS" Else OBJGRN.FRMSTRING = "PARTYWISESUMM"

            ElseIf RDBAGENT.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "JOBBERWISEDTLS" Else OBJGRN.FRMSTRING = "JOBBERWISESUMM"

            ElseIf RDBTRANS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "TRANSWISEDTLS" Else OBJGRN.FRMSTRING = "TRANSWISESUMM"

            ElseIf RDITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "ITEMWISEDTLS" Else OBJGRN.FRMSTRING = "ITEMWISESUMM"

            ElseIf RDQUALITY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "QUALITYWISEDTLS" Else OBJGRN.FRMSTRING = "QUALITYWISESUMM"

            ElseIf RDSHADE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "SHADEWISEDTLS" Else OBJGRN.FRMSTRING = "SHADEWISESUMM"

            ElseIf RDBMONTHLY.Checked = True Then
                OBJGRN.FRMSTRING = "MONTHLY"

                'ElseIf RDCHGS.Checked = True Then
                '    OBJGRN.FRMSTRING = "CHARGESWISEDTLS"
                '    If CMBCHARGES.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CHGSLEDGERS.ACC_CMPNAME}='" & CMBCHARGES.Text.Trim & "'"

                'ElseIf RDCHGS.Checked = True Then
                '    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONPAIDAMT = True
                '    OBJGRN.FRMSTRING = "CHARGESWISEDTLS"
            ElseIf RDBPURCHASEENTRYWISE.Checked = True Then
                OBJGRN.FRMSTRING = "PURCHASEWISE"


            ElseIf RDBENTRYWISE.Checked = True Then
                OBJGRN.FRMSTRING = "ENTRYWISE"

            ElseIf RDBPARTYENTRYWISE.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYENTRYWISE"

            End If

            'If RDCHGS.Checked = True Then
            '    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONPAIDAMT = True
            '    OBJGRN.FRMSTRING = "CHARGESWISEDTLS"
            '    OBJGRN.WHERECLAUSE = " {AGENTCOMMVIEW.YEARID}= " & YearId & " And {AGENTCOMMVIEW.TYPE} IN ['PURCHASE','PURCHASE RETURN']"
            'End If

            If TXTAMT.Text <> "" And CMBSIGN.Text <> "" Then
                If CMBSIGN.Text = "=" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GRANDTOTAL}=" & TXTAMT.Text.Trim & ""
                If CMBSIGN.Text = ">" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GRANDTOTAL}>" & TXTAMT.Text.Trim & ""
                If CMBSIGN.Text = "<" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GRANDTOTAL}<" & TXTAMT.Text.Trim & ""
            End If

            'ALL FILTERS
            If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {BROKERLEDGERS.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"
            If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"
            If cmbtrans.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {TRANSLEDGERS.ACC_CMPNAME}='" & cmbtrans.Text.Trim & "'"
            If cmbregister.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {REGISTERMASTER.REGISTER_NAME}='" & cmbregister.Text.Trim & "'"
            If CMBCATEGORY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"


            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                End If
            Next

            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & NAMECLAUSE
            End If


            If RDBCOMMISSION.Checked = True Then
                If CMBAGENT.Text.Trim = "" Then
                    OBJGRN.WHERECLAUSE = " {AGENTCOMMVIEW.YEARID}= " & YearId & " And {AGENTCOMMVIEW.TYPE} IN ['PURCHASE','PURCHASE RETURN','DEBITNOTE']"
                    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONRECDAMT = True
                Else
                    OBJGRN.WHERECLAUSE = " {AGENTCOMMVIEW.YEARID}= " & YearId & " AND {AGENTCOMMVIEW.AGENT}='" & CMBAGENT.Text.Trim & "'  And {AGENTCOMMVIEW.TYPE} IN ['PURCHASE','PURCHASE RETURN','DEBITNOTE']"
                    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONRECDAMT = True
                End If
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {AGENTCOMMVIEW.NAME}='" & CMBNAME.Text.Trim & "'"
                If CHKSUMMARY.Checked = True Then OBJGRN.FRMSTRING = "COMMSUMM" Else OBJGRN.FRMSTRING = "COMMISSION"
                OBJGRN.COMMPER = Val(TXTAGENTCOMM.Text.Trim)
            End If

            If RDBCOMMISSIONOPENING.Checked = True Then
                If CMBAGENT.Text.Trim = "" Then
                    OBJGRN.WHERECLAUSE = " {AGENTCOMMVIEWOPENING.YEARID}= " & YearId & " And {AGENTCOMMVIEWOPENING.TYPE} IN ['PURCHASE','PURCHASE RETURN','DEBITNOTE']"
                    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONRECDAMT = True
                Else
                    OBJGRN.WHERECLAUSE = " {AGENTCOMMVIEWOPENING.YEARID}= " & YearId & " AND {AGENTCOMMVIEWOPENING.AGENT}='" & CMBAGENT.Text.Trim & "'  And {AGENTCOMMVIEWOPENING.TYPE} IN ['PURCHASE','PURCHASE RETURN','DEBITNOTE']"
                    If MsgBox("Show Commission on Paid Amount?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGRN.COMMISSIONONRECDAMT = True
                End If
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {AGENTCOMMVIEWOPENING.NAME}='" & CMBNAME.Text.Trim & "'"
                If CHKSUMMARY.Checked = True Then OBJGRN.FRMSTRING = "COMMOPSUMM" Else OBJGRN.FRMSTRING = "COMMISSIONOP"
                OBJGRN.COMMPER = Val(TXTAGENTCOMM.Text.Trim)
            End If


            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSHADE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBSHADE.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        Try
            numkeypress(e, TXTAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class