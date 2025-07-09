
Imports BL

Public Class CurrencyMaster

    Public EDIT As Boolean
    Public TEMPCURRID As Integer
    Public TEMPCURRNAME As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub ShelfMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            If EDIT = True Then
                Dim OBJCURR As New ClsCurrencyMaster
                OBJCURR.alParaval.Add(TEMPCURRID)
                OBJCURR.alParaval.Add(YearId)
                Dim DT As DataTable = OBJCURR.GETCURR()
                If DT.Rows.Count > 0 Then
                    txtname.Text = DT.Rows(0).Item("NAME")
                    TEMPCURRNAME = DT.Rows(0).Item("NAME")
                    txtremarks.Text = DT.Rows(0).Item("REMARKS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShelfMaster_KEYDOWN(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If txtname.Text.Trim = "" Then
                EP.SetError(txtname, "Enter Proper Name")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim OBJCURR As New ClsCurrencyMaster
            OBJCURR.alParaval.Add(txtname.Text.Trim)
            OBJCURR.alParaval.Add(txtremarks.Text.Trim)
            OBJCURR.alParaval.Add(CmpId)
            OBJCURR.alParaval.Add(Userid)
            OBJCURR.alParaval.Add(YearId)

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim INTRES As Integer = OBJCURR.SAVE()
                MsgBox("Details Added")
            Else
                OBJCURR.alParaval.Add(TEMPCURRID)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim INTRES As Integer = OBJCURR.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            CLEAR()
            txtname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        Try
            txtname.Clear()
            txtremarks.Clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCURR As New ClsCurrencyMaster
                OBJCURR.alParaval.Add(TEMPCURRID)
                OBJCURR.alParaval.Add(YearId)

                Dim intResult As Integer = OBJCURR.DELETE
                MsgBox("Currency Deleted Successfully")
                CLEAR()
                EDIT = False
                txtname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPCURRNAME.Trim.ToLower <> txtname.Text.Trim.ToLower) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("CURR_ID AS ID", "", "CURRENCYMASTER", " AND CURR_NAME = '" & txtname.Text.Trim & "' AND CURR_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Currency Name Already Exists", MsgBoxStyle.Critical)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class



