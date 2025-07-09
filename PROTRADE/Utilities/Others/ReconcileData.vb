
Imports BL

Public Class ReconcileData

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CHKRECOINV.CheckState = CheckState.Unchecked
            CHKRECOPURCHASE.CheckState = CheckState.Unchecked
            CHKRECONONPURCHASE.CheckState = CheckState.Unchecked
            CHKRECOSTOCK.CheckState = CheckState.Unchecked
            CHKRECOPENDINGDATA.CheckState = CheckState.Unchecked
            CHKRECOORDER.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Reconcile Data?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim OBJURECO As New ClsDataReco
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                Dim INTRES As Integer
                OBJURECO.alParaval = ALPARAVAL
                If CHKRECOINV.Checked = True Then
                    INTRES = OBJURECO.INVRECO()

                ElseIf CHKRECOPURCHASE.Checked = True Then
                    INTRES = OBJURECO.PURRECO()

                ElseIf CHKRECONONPURCHASE.Checked = True Then
                    INTRES = OBJURECO.NONPURRECO()

                ElseIf CHKRECOSTOCK.Checked = True Then
                    INTRES = OBJURECO.STOCKRECO()

                ElseIf CHKRECOPENDINGDATA.Checked = True Then
                    INTRES = OBJURECO.GRNCHALLANRECO()

                ElseIf CHKRECOORDER.Checked = True Then
                    INTRES = OBJURECO.ORDERRECO()
                End If
                MsgBox("Reco Done Successfully")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECONCILEDATAFILTER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class