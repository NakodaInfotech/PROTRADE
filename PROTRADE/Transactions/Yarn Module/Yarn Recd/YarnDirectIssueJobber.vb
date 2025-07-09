
Imports System.ComponentModel
Imports BL

Public Class YarnDirectIssueJobber

    Public TYPE As String = ""

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        If MsgBox("Exit Without Saving Direct Issue To Jobber?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        CMBJOBBER.Text = ""
        CMBPROCESS.Text = ""
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If CMBJOBBER.Text.Trim = "" Or CMBPROCESS.Text.Trim = "" Then
                MsgBox("Please Enter Proper Data", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DirectIssueSizer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillname(CMBJOBBER, False, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            FILLPROCESS(CMBPROCESS)
            If ClientName = "VAISHALI" Then
                If TYPE = "GREY" Then CMBPROCESS.Text = "DYEING" Else CMBPROCESS.Text = "TUBING"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Enter
        Try
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, False, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBJOBBER.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBJOBBER.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJOBBER.Validating
        Try
            If CMBJOBBER.Text.Trim <> "" Then namevalidate(CMBJOBBER, cmbcode, e, Me, TXTADD, "AND GROUPMASTER.GROUP_SECONDARY='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(sender As Object, e As EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(sender As Object, e As CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class