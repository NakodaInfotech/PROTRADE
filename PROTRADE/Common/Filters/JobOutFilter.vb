Imports BL

Public Class JobOutFilter

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

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobOutFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Enter
        Try
            fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
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

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

        Dim OBJMATREC As New JobOutDesign
        OBJMATREC.MdiParent = MDIMain
        OBJMATREC.WHERECLAUSE = "{JOBOUT.JO_yearid}=" & YearId

        If chkdate.Checked = True Then
            getFromToDate()
            OBJMATREC.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
        Else
            OBJMATREC.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
        End If

        If RDBPARTY.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "PARTYWISEDTLS" Else OBJMATREC.FRMSTRING = "PARTYWISESUMM"
            If CMBNAME.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {JOBBER.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

        ElseIf RDBJOBBER.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "JOBBERWISEDTLS" Else OBJMATREC.FRMSTRING = "JOBBERWISESUMM"
            If CMBJOBBER.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBJOBBER.Text.Trim & "'"

        ElseIf RDGODOWN.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "GODOWNWISEDTLS" Else OBJMATREC.FRMSTRING = "GODOWNWISESUMM"
            If CMBGODOWN.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"

        ElseIf RDITEM.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "ITEMWISEDTLS" Else OBJMATREC.FRMSTRING = "ITEMWISESUMM"
            If CMBITEMNAME.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"

        ElseIf RDQUALITY.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "QUALITYWISEDTLS" Else OBJMATREC.FRMSTRING = "QUALITYWISESUMM"
            If CMBQUALITY.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"

        ElseIf RDBDESIGN.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "DESIGNWISEDTLS" Else OBJMATREC.FRMSTRING = "DESIGNWISESUMM"
            If CMBDESIGN.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"

        ElseIf RDBTRANS.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "TRANSWISEDTLS" Else OBJMATREC.FRMSTRING = "TRANSWISESUMM"
            If CMBTRANS.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {TRANSPORT.ACC_CMPNAME}='" & CMBTRANS.Text.Trim & "'"

        ElseIf RDSHADE.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "SHADEWISEDTLS" Else OBJMATREC.FRMSTRING = "SHADEWISESUMM"
            If CMBSHADE.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

        ElseIf RDBJOBLOTWISESUMM.Checked = True Or RDBJOBLOTWISEDTLS.Checked = True Then
            Dim OBJRPT As New clsReportDesigner("Job Wise Details", System.AppDomain.CurrentDomain.BaseDirectory & "Job Wise Details.xlsx", 2)
            Dim WHERECLAUSE As String = " AND JOBOUT.JO_YEARID = " & YearId

            If CMBJOBBER.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND LEDGERS.ACC_CMPNAME = '" & CMBJOBBER.Text.Trim & "'"
            If CMBGODOWN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND GODOWNMASTER.GODOWN_name = '" & CMBGODOWN.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMMASTER.item_name = '" & CMBITEMNAME.Text.Trim & "'"
            If CMBQUALITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND QUALITYMASTER.QUALITY_name = '" & CMBQUALITY.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGN.Text.Trim & "'"
            If Val(TXTJONO.Text.Trim) <> 0 Then WHERECLAUSE = WHERECLAUSE & " AND JOBOUT.JO_NO = " & Val(TXTJONO.Text.Trim)
            If chkdate.CheckState = CheckState.Checked Then
                WHERECLAUSE = WHERECLAUSE & " AND JO_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND JO_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
            Else
                WHERECLAUSE = WHERECLAUSE & " AND JO_DATE >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND JO_DATE <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'"
            End If

            If RDBJOBLOTWISESUMM.Checked = True Then OBJRPT.JOBOUTSUMM_EXCEL(WHERECLAUSE, CmpId, YearId, ClientName) Else OBJRPT.JOBOUTDTLS_EXCEL(WHERECLAUSE, CmpId, YearId, ClientName)
            Exit Sub
        End If

        If CMBPIECETYPE.Text <> "" Then
            OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {PIECETYPEMASTER.PIECETYPE_NAME}='" & CMBPIECETYPE.Text.Trim & "'"
        ElseIf CMBPIECETYPE.Text <> "" And CMBNAME.Text <> "" Then
            OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {PIECETYPEMASTER.PIECETYPE_NAME}='" & CMBPIECETYPE.Text.Trim & "'" & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
        End If
        'If CMBPIECETYPE.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {PIECETYPEMASTER.PIECETYPE_NAME}='" & CMBPIECETYPE.Text.Trim & "'"

        If TXTJONO.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {JOBOUT.JO_NO}= " & TXTJONO.Text.Trim & " AND {JOBOUT.JO_yearid}= " & YearId

        OBJMATREC.Show()

    End Sub

    Private Sub JobOutFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTJONO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTJONO.KeyPress
        numkeypress(e, TXTJONO, Me)
    End Sub
End Class