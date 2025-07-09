
Imports BL
Imports System.IO

Public Class Reprint

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim WHOLESALEBARCODE As Integer = 0
            If ClientName = "CC" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)

            Dim TEMPHEADER As String = ""
            If ClientName = "YASHVI" Then
                TEMPHEADER = InputBox("Enter Sticker Type (M/N/O/P)")
                If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "O" And TEMPHEADER <> "P" And TEMPHEADER <> "Y" Then Exit Sub
                If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
                If TEMPHEADER = "N" Or TEMPHEADER = "P" Then TEMPHEADER = ""
                If TEMPHEADER = "O" Then TEMPHEADER = "ORGALIN"
                If TEMPHEADER = "Y" Then TEMPHEADER = "PREPRINTED"
            End If


            If ClientName = "GELATO" Then
                TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
            End If

            If ClientName = "MANALI" Then
                TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR PRE PRINTED")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
            End If

            If ClientName = "MANS" Then
                TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR SALVATROE" & Chr(13) & "2 FOR MANS")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
            End If

            If ClientName = "AXIS" Then
                TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR PCS" & Chr(13) & "2 FOR MTRS")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
            End If

            If ClientName = "KRISHNA" Then
                TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR BOX STICKER")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
            End If


            Dim SUPRIYAHEADER As String = ""
            If ClientName = "SUPRIYA" Then
                TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
                If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
                If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
                If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
                If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
                If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
                If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If ClientName = "AVIS" And TXTPIECETYPE.Text = "SECOND" Then TXTPIECETYPE.Text = "FRESH"

            For I As Integer = 1 To Val(txtcopies.Text.Trim)
                BARCODEPRINTING(txtbarcode.Text.Trim, TXTPIECETYPE.Text.Trim, TXTITEMNAME.Text.Trim, TXTQUALITY.Text.Trim, TXTDESIGN.Text.Trim, TXTSHADE.Text.Trim, TXTUNIT.Text.Trim, TXTLOTNO.Text.Trim, TXTBALENO.Text.Trim, TXTDESC.Text.Trim, Val(TXTMTRS.Text.Trim), 1, Val(TXTCUT.Text.Trim), TXTRACK.Text.Trim, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
            Next
LINE1:
            clear()
            txtbarcode.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub clear()
        Try
            txtbarcode.Clear()
            txtcopies.Text = 1
            TXTPIECETYPE.Clear()
            TXTITEMNAME.Clear()
            TXTQUALITY.Clear()
            TXTDESIGN.Clear()
            TXTSHADE.Clear()
            TXTGODOWN.Clear()
            TXTLOTNO.Clear()
            TXTMTRS.Clear()
            TXTDESC.Clear()
            TXTUNIT.Clear()
            TXTCUT.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Labelprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clear()
    End Sub

    Private Sub txtcopies_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcopies.KeyPress
        numkeypress(e, txtcopies, Me)
    End Sub

    Private Sub Reprint_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "CC" Or ClientName = "SHREEDEV" Then CHKBARCODE.Visible = True
        If ClientName = "SANGHVI" Or ClientName = "KDFAB" Or ClientName = "ALENCOT" Then
            LBLDESC.Visible = True
            TXTDESC.Visible = True
        End If
        If ClientName = "DEVEN" Then
            CHKBARCODE.Visible = True
            CHKBARCODE.Text = "Print In Yards"
        End If
    End Sub

    Private Sub txtbarcode_Validated(sender As Object, e As EventArgs) Handles txtbarcode.Validated
        Try
            If Len(txtbarcode.Text.Trim) > 7 Then

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & txtbarcode.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPIECETYPE.Text = DT.Rows(0).Item("PIECETYPE")
                    TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                    TXTQUALITY.Text = DT.Rows(0).Item("QUALITY")
                    TXTDESIGN.Text = DT.Rows(0).Item("DESIGNNO")
                    TXTSHADE.Text = DT.Rows(0).Item("COLOR")
                    TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                    TXTMTRS.Text = Format((Val(DT.Rows(0).Item("MTRS"))), "0.00")
                    TXTBALENO.Text = DT.Rows(0).Item("BALENO")
                    TXTLOTNO.Text = DT.Rows(0).Item("LOTNO")
                    TXTRACK.Text = DT.Rows(0).Item("RACK")
                    TXTUNIT.Text = DT.Rows(0).Item("UNIT")
                    TXTDESC.Text = DT.Rows(0).Item("GRIDREMARKS")
                    TXTCUT.Text = Format((Val(DT.Rows(0).Item("CUT"))), "0.00")
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    txtbarcode.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class