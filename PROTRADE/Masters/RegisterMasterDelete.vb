
Imports BL

Public Class RegisterMasterDelete

    Public frmstring As String        'Used from Displaying Purchase, Sale, Receipt, Payment, Journal, Contra Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If CMBREGISTER.Text.Trim <> "" Then

                If MsgBox("Delete Register Permanently?", MsgBoxStyle.YesNo, "PROTRADE") = vbYes Then

                    Dim OBJREGISTER As New ClsRegisterMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBREGISTER.Text.Trim)
                    ALPARAVAL.Add(frmstring)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)

                    OBJREGISTER.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJREGISTER.DELETE()
                    MsgBox(DT.Rows(0).Item(0))

                    Me.Close()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub RegisterMasterDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'REGISTER MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillregister(CMBREGISTER, " and register_type = '" & frmstring & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class