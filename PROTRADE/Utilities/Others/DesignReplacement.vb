
Imports BL

Public Class DesignReplacement

    Public edit As Boolean
    Public tempdesignno As String
    Public tempQualityName As String

    Sub FILLCMB()
        If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        If CMBOLDDESIGN.Text.Trim = "" Then fillDESIGN(CMBOLDDESIGN, "")
        If CMBNEWDESIGN.Text.Trim = "" Then fillDESIGN(CMBNEWDESIGN, "")

    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            Throw ex
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

    Private Sub CMBQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBOLDDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOLDDESIGN.Enter
        Try
            If CMBOLDDESIGN.Text.Trim = "" Then fillDESIGN(CMBOLDDESIGN, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOLDDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOLDDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBOLDDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOLDDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOLDDESIGN.Validating
        Try
            If CMBOLDDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBOLDDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBOLDCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOLDCOLOR.Enter
        Try
            Cursor.Current = Cursors.WaitCursor
            FILLCOLOR(CMBOLDCOLOR, CMBOLDDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBOLDCOLOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOLDCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                ' If CMBOLDSHADE.TEMPNAME <> "" Then CMBOLDSHADE.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOLDCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOLDCOLOR.Validating
        Try
            If CMBOLDCOLOR.Text.Trim <> "" Then COLORvalidate(CMBOLDCOLOR, e, Me, CMBOLDDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNEWCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNEWCOLOR.Enter
        Try
            Cursor.Current = Cursors.WaitCursor
            FILLCOLOR(CMBNEWCOLOR, CMBNEWDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBNEWCOLOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNEWCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                ' If CMBNEWSHADE.TEMPNAME <> "" Then CMBNEWSHADE.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNEWCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNEWCOLOR.Validating
        Try
            If CMBNEWCOLOR.Text.Trim <> "" Then COLORvalidate(CMBNEWCOLOR, e, Me, CMBNEWDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNEWDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNEWDESIGN.Enter
        Try
            If CMBNEWDESIGN.Text.Trim = "" Then fillDESIGN(CMBNEWDESIGN, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNEWDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNEWDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBNEWDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNEWDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNEWDESIGN.Validating
        Try
            If CMBNEWDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBNEWDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        edit = False
        CMBQUALITY.Focus()
    End Sub

    Sub CLEAR()
        EP.Clear()
        CMBQUALITY.Text = ""
        CMBOLDDESIGN.Text = ""
        CMBNEWDESIGN.Text = ""
        CMBOLDCOLOR.Text = ""
        CMBNEWCOLOR.Text = ""
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True
            If CMBQUALITY.Text.Trim.Length = 0 Then
                EP.SetError(CMBQUALITY, "Enter Quality")
                bln = False
            End If

            If CMBOLDDESIGN.Text.Trim.Length = 0 Then
                EP.SetError(CMBOLDDESIGN, "Enter Old Design")
                bln = False
            End If

            If CMBNEWDESIGN.Text.Trim.Length = 0 Then
                EP.SetError(CMBNEWDESIGN, "Enter New Design")
                bln = False
            End If

            If CMBOLDCOLOR.Text.Trim.Length = 0 Then
                EP.SetError(CMBOLDCOLOR, "Enter Old Shade")
                bln = False
            End If

            If CMBNEWCOLOR.Text.Trim.Length = 0 Then
                EP.SetError(CMBNEWCOLOR, "Enter New Shade")
                bln = False
            End If

            If CMBOLDDESIGN.Text.Trim = CMBNEWDESIGN.Text.Trim Then
                EP.SetError(CMBNEWDESIGN, "Old and New Design can not be same")
                bln = False
            End If

            'AS DISCUSSED WITH SIDHHRTH BHAI
            'If CMBOLDCOLOR.Text.Trim = CMBNEWCOLOR.Text.Trim Then
            '    EP.SetError(CMBNEWCOLOR, "Old and New Shade can not be same")
            '    bln = False
            'End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(CMBOLDDESIGN.Text.Trim)
            alParaval.Add(CMBNEWDESIGN.Text.Trim)
            alParaval.Add(CMBOLDCOLOR.Text.Trim)
            alParaval.Add(CMBNEWCOLOR.Text.Trim)

            alParaval.Add(YearId)

            Dim OBJDESIGN As New ClsDesignReplacement()
            OBJDESIGN.alParaval = alParaval

            Dim intresult As Integer = OBJDESIGN.UPDATE()
            MsgBox("Details Updated")

            CLEAR()
            CMBQUALITY.Focus()

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub DesignReplacement_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class