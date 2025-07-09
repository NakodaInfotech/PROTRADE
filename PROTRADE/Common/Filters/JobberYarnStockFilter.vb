
Imports BL

Public Class JobberYarnStockFilter

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
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
            If CMBMILLNAME.Text.Trim = "" Then fillmill(CMBMILLNAME, False)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, "")
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobberYarnStockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobberYarnStockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBSTOCKONHAND.Checked = True Then
                Dim OBJYARNSTOCK As New JobberYarnStockOnHand
                OBJYARNSTOCK.MdiParent = MDIMain
                OBJYARNSTOCK.Show()
                Exit Sub
            End If


            Dim OBJSTOCK As New YarnStockDesign
            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.WHERECLAUSE = " {JOBBERYARNSTOCKREGISTER.YEARID}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.NAME}='" & CMBNAME.Text.Trim & "'"
            If CMBYARNQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.YARNQUALITY}='" & CMBYARNQUALITY.Text.Trim & "'"
            If CMBMILLNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.MILLNAME}='" & CMBMILLNAME.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.DESIGNNO}='" & CMBDESIGN.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {JOBBERYARNSTOCKREGISTER.COLOR}='" & CMBSHADE.Text.Trim & "'"

            If RBYARNQUALITYSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERQUALITYSTOCKSUMM"
            ElseIf RBDETAILS.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSTOCKDTLS"
            ElseIf RBJOBBERSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSTOCKSUMM"
            ElseIf RBDESIGNSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERDESIGNSTOCKSUMM"
            ElseIf RBSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "JOBBERSHADESTOCKSUMM"
            End If

            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "  AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILLNAME.Enter
        Try
            If CMBMILLNAME.Text.Trim = "" Then fillmill(CMBMILLNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILLNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILLNAME.Validating
        Try
            If CMBMILLNAME.Text.Trim <> "" Then MILLVALIDATE(CMBMILLNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class