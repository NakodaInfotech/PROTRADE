Imports BL

Public Class SaleReturnFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")

            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturnFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SaleReturnFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJMATREC As New SaleReturnDesign
            OBJMATREC.MdiParent = MDIMain
            OBJMATREC.WHERECLAUSE = "{SALERETURN.SALRET_cmpid}=" & CmpId & " and {SALERETURN.SALRET_locationid}=" & Locationid & " and {SALERETURN.SALRET_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJMATREC.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJMATREC.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "PARTYWISEDTLS" Else OBJMATREC.FRMSTRING = "PARTYWISESUMM"
                If CMBNAME.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBAGENT.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "JOBBERWISEDTLS" Else OBJMATREC.FRMSTRING = "JOBBERWISESUMM"

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
                If CMBDESIGN.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NAME}='" & CMBDESIGN.Text.Trim & "'"

            ElseIf RDSHADE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "SHADEWISEDTLS" Else OBJMATREC.FRMSTRING = "SHADEWISESUMM"
                If CMBSHADE.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

            ElseIf RDBTRANS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJMATREC.FRMSTRING = "TRANSWISEDTLS" Else OBJMATREC.FRMSTRING = "TRANSWISESUMM"
                If CMBTRANS.Text <> "" Then OBJMATREC.WHERECLAUSE = OBJMATREC.WHERECLAUSE & " and {teansport.ACC_CMPNAME}='" & CMBTRANS.Text.Trim & "'"
            End If

            OBJMATREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
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

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
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
End Class