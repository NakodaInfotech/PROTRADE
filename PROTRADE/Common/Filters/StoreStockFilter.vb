
Imports BL

Public Class StoreStockFilter

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
            If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StoreStockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim OBJSTOCK As New StoreStockDesign
            OBJSTOCK.MdiParent = MDIMain

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

            OBJSTOCK.WHERECLAUSE = " {STORESTOCKREGISTER.YEARID}=" & YearId
            If CMBSTOREITEMNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STORESTOCKREGISTER.ITEMNAME}='" & CMBSTOREITEMNAME.Text.Trim & "'"

            If RBITEMSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "STOREITEMSTOCKSUMM"
            ElseIf RBITEMDTLS.Checked = True Then
                OBJSTOCK.FRMSTRING = "STOREITEMSTOCKDTLS"
            End If

            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSTOREITEMNAME.Enter
        Try
            If CMBSTOREITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBSTOREITEMNAME)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSTOREITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSTOREITEMNAME.Validating
        Try
            If CMBSTOREITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBSTOREITEMNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class