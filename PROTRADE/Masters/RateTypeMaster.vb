
Imports BL

Public Class RateTypeMaster

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            If TXTRATE01.Text.Trim <> "" And TXTRATE02.Text.Trim <> "" And TXTRATE03.Text.Trim <> "" And TXTRATE04.Text.Trim <> "" And TXTRATE05.Text.Trim <> "" And TXTRATE06.Text.Trim <> "" And TXTRATE07.Text.Trim <> "" And TXTRATE08.Text.Trim <> "" And TXTRATE09.Text.Trim <> "" And TXTRATE10.Text.Trim <> "" Then

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TXTRATE01.Text.Trim)
                ALPARAVAL.Add(TXTRATE02.Text.Trim)
                ALPARAVAL.Add(TXTRATE03.Text.Trim)
                ALPARAVAL.Add(TXTRATE04.Text.Trim)
                ALPARAVAL.Add(TXTRATE05.Text.Trim)
                ALPARAVAL.Add(TXTRATE06.Text.Trim)
                ALPARAVAL.Add(TXTRATE07.Text.Trim)
                ALPARAVAL.Add(TXTRATE08.Text.Trim)
                ALPARAVAL.Add(TXTRATE09.Text.Trim)
                ALPARAVAL.Add(TXTRATE10.Text.Trim)
                ALPARAVAL.Add(CmpId)

                Dim OBJRATE As New ClsRateTypeMaster
                OBJRATE.alParaval = ALPARAVAL
                Dim INTERS As Integer = OBJRATE.SAVE
                MsgBox("Details Added")
                Me.Close()
            Else
                MsgBox("Enter all Fields", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RateTypeMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT COLNAME AS COLNAME, RATENAME FROM RATETYPEMASTER WHERE CMPID = " & CmpId, "", "")
            For Each DTROW As DataRow In DT.Rows
                If DTROW("COLNAME") = "RATE1" Then TXTRATE01.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE2" Then TXTRATE02.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE3" Then TXTRATE03.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE4" Then TXTRATE04.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE5" Then TXTRATE05.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE6" Then TXTRATE06.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE7" Then TXTRATE07.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE8" Then TXTRATE08.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE9" Then TXTRATE09.Text = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE10" Then TXTRATE10.Text = DTROW("RATENAME")
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class