
Imports BL

Public Class GRNCheckingFilter

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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJCHECK As New GRNCheckingDesign
            OBJCHECK.MdiParent = MDIMain
            OBJCHECK.WHERECLAUSE = "{CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJCHECK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJCHECK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If




            If RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "PARTYWISEDTLS" Else OBJCHECK.FRMSTRING = "PARTYWISESUMM"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBPARTYDESIGN.Checked = True Then
                OBJCHECK.FRMSTRING = "PARTYDESIGNWISEDTLS"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
                If CMBDESIGN.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NAME}='" & CMBDESIGN.Text.Trim & "'"

            ElseIf RDBPARTYMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "PARTYWISEMONTHLY"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBPARTYQUALITY.Checked = True Then
                OBJCHECK.FRMSTRING = "PARTYQUALITYWISEDTLS"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
                If CMBQUALITY.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"




            ElseIf RDJOBBER.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "JOBBERWISEDTLS" Else OBJCHECK.FRMSTRING = "JOBBERWISESUMM"
                If CMBJOBBER.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBJOBBER.Text.Trim & "'"

            ElseIf RDBJOBBERMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "JOBBERWISEMONTHLY"
                If CMBJOBBER.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBJOBBER.Text.Trim & "'"




            ElseIf RDITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "ITEMWISEDTLS" Else OBJCHECK.FRMSTRING = "ITEMWISESUMM"
                If CMBITEMNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"

            ElseIf RDBITEMMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "ITEMWISEMONTHLY"
                If CMBITEMNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEMNAME.Text.Trim & "'"




            ElseIf RDQUALITY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "QUALITYWISEDTLS" Else OBJCHECK.FRMSTRING = "QUALITYWISESUMM"
                If CMBQUALITY.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"

            ElseIf RDBQUALITYPARTY.Checked = True Then
                OBJCHECK.FRMSTRING = "QUALITYPARTYWISEDTLS"
                If CMBQUALITY.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBQUALITYMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "QUALITYWISEMONTHLY"
                If CMBQUALITY.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"




            ElseIf RDBDESIGN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "DESIGNWISEDTLS" Else OBJCHECK.FRMSTRING = "DESIGNWISESUMM"
                If CMBDESIGN.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NAME}='" & CMBDESIGN.Text.Trim & "'"

            ElseIf RDBDESIGNPARTY.Checked = True Then
                OBJCHECK.FRMSTRING = "DESIGNPARTYWISEDTLS"
                If CMBDESIGN.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NAME}='" & CMBDESIGN.Text.Trim & "'"
                If CMBNAME.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBDESIGNMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "DESIGNWISEMONTHLY"
                If CMBDESIGN.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NAME}='" & CMBDESIGN.Text.Trim & "'"




            ElseIf RDSHADE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "SHADEWISEDTLS" Else OBJCHECK.FRMSTRING = "SHADEWISESUMM"
                If CMBSHADE.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

            ElseIf RDBSHADEMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "SHADEWISEMONTHLY"
                If CMBSHADE.Text <> "" Then OBJCHECK.WHERECLAUSE = OBJCHECK.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"




            ElseIf RDBLOTWISE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCHECK.FRMSTRING = "LOTWISEDTLS" Else OBJCHECK.FRMSTRING = "LOTWISESUMM"



            ElseIf RDBMONTHLY.Checked = True Then
                OBJCHECK.FRMSTRING = "MONTHLY"


            End If

            OBJCHECK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBSHADE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
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

    Private Sub CMBJOBBER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Enter
        Try
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBJOBBER.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBJOBBER.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJOBBER.Validating
        Try
            If CMBJOBBER.Text.Trim <> "" Then namevalidate(CMBJOBBER, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
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
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class