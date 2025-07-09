Imports BL
Public Class JobInFilter

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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobInFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then Me.Close()

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

    Private Sub JobInFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
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

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

        Dim OBJJI As New JobInDesign
        OBJJI.MdiParent = MDIMain
        OBJJI.WHERECLAUSE = "{JOBIN.JI_cmpid}=" & CmpId & " and {JOBIN.JI_locationid}=" & Locationid & " and {JOBIN.JI_yearid}=" & YearId

        If chkdate.Checked = True Then
            getFromToDate()
            OBJJI.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
        Else
            OBJJI.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
        End If

        If RDBPARTY.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "PARTYWISEDTLS" Else OBJJI.FRMSTRING = "PARTYWISESUMM"
            If CMBNAME.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

        ElseIf RDGODOWN.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "GODOWNWISEDTLS" Else OBJJI.FRMSTRING = "GODOWNWISESUMM"
            If CMBGODOWN.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"

        ElseIf RDITEM.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "ITEMWISEDTLS" Else OBJJI.FRMSTRING = "ITEMWISESUMM"
            If CMBITEMNAME.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"

        ElseIf RDQUALITY.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "QUALITYWISEDTLS" Else OBJJI.FRMSTRING = "QUALITYWISESUMM"
            If CMBQUALITY.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"

        ElseIf RDBDESIGN.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "DESIGNWISEDTLS" Else OBJJI.FRMSTRING = "DESIGNWISESUMM"
            If CMBDESIGN.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"

        ElseIf RDBTRANS.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "TRANSWISEDTLS" Else OBJJI.FRMSTRING = "TRANSWISESUMM"
            If CMBTRANS.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {TRANSPORT.ACC_CMPNAME}='" & CMBTRANS.Text.Trim & "'"

        ElseIf RDSHADE.Checked = True Then
            If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJJI.FRMSTRING = "SHADEWISEDTLS" Else OBJJI.FRMSTRING = "SHADEWISESUMM"
            If CMBSHADE.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"
        End If
        If CMBPIECETYPE.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {PIECETYPEMASTER.PIECETYPE_NAME}='" & CMBPIECETYPE.Text.Trim & "'"

        If TXTJINO.Text <> "" Then OBJJI.WHERECLAUSE = OBJJI.WHERECLAUSE & " and {JOBIN.JI_NO}= " & TXTJINO.Text.Trim & " AND {JOBIN.JI_yearid}= " & YearId

        OBJJI.Show()

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

    Private Sub TXTMATRECNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTJINO.KeyPress
        numkeypress(e, TXTJINO, Me)
    End Sub
End Class