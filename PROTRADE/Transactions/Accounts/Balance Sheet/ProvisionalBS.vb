
Imports BL

Public Class ProvisionalBS

    Public EDIT As Boolean

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim OBJPROVISION As New ClsProvisionalBS
            OBJPROVISION.alParaval.Add(Val(TXTAPRAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTMAYAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTJUNEAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTJULAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTAUGAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTSEPAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTOCTAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTNOVAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTDECAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTJANAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTFEBAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(Val(TXTMARAMT.Text.Trim))
            OBJPROVISION.alParaval.Add(CmpId)
            OBJPROVISION.alParaval.Add(YearId)

            If EDIT = False Then
                Dim INTRES As Integer = OBJPROVISION.SAVE()
                MsgBox("Details Added")
                Me.Close()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If Val(TXTAPRAMT.Text.Trim) = 0 And Val(TXTMAYAMT.Text.Trim) = 0 And Val(TXTJUNEAMT.Text.Trim) = 0 And Val(TXTJULAMT.Text.Trim) = 0 And Val(TXTAUGAMT.Text.Trim) = 0 And Val(TXTSEPAMT.Text.Trim) = 0 And Val(TXTOCTAMT.Text.Trim) = 0 And Val(TXTNOVAMT.Text.Trim) = 0 And Val(TXTDECAMT.Text.Trim) = 0 And Val(TXTJANAMT.Text.Trim) = 0 And Val(TXTFEBAMT.Text.Trim) = 0 And Val(TXTMARAMT.Text.Trim) = 0 Then
                EP.SetError(TXTAPRAMT, "Enter Values")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProvisionalBS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            dttable = objCommon.search("ISNULL(PROVISIONALBS.BS_ID,0) AS ID,ISNULL(PROVISIONALBS.BS_APRIL,0) AS APRIL,ISNULL(PROVISIONALBS.BS_MAY,0) AS MAY,ISNULL(PROVISIONALBS.BS_JUNE,0) AS JUNE,ISNULL(PROVISIONALBS.BS_JULY,0) AS JULY, ISNULL(PROVISIONALBS.BS_AUGUST,0) AS AUGUST,ISNULL(PROVISIONALBS.BS_SEPTEMBER,0) AS SEPTEMBER,ISNULL(PROVISIONALBS.BS_OCTOBER,0) AS OCTOBER,ISNULL(PROVISIONALBS.BS_NOVEMBER,0) AS NOVEMBER,ISNULL(PROVISIONALBS.BS_DECEMBER,0) AS DECEMBER,ISNULL(PROVISIONALBS.BS_JANUARY,0) AS JANUARY,ISNULL(PROVISIONALBS.BS_FABRUARY,0) AS FABRUARY,  ISNULL(PROVISIONALBS.BS_MARCH,0) AS MARCH ", "", " PROVISIONALBS ", " and PROVISIONALBS.BS_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                For Each ROW As DataRow In dttable.Rows

                    TXTAPRAMT.Text = ROW("APRIL").ToString
                    TXTMAYAMT.Text = ROW("MAY").ToString
                    TXTJUNEAMT.Text = ROW("JUNE").ToString
                    TXTJULAMT.Text = ROW("JULY").ToString
                    TXTAUGAMT.Text = ROW("AUGUST").ToString
                    TXTSEPAMT.Text = ROW("SEPTEMBER").ToString
                    TXTOCTAMT.Text = ROW("OCTOBER").ToString
                    TXTNOVAMT.Text = ROW("NOVEMBER").ToString
                    TXTDECAMT.Text = ROW("DECEMBER").ToString
                    TXTJANAMT.Text = ROW("JANUARY").ToString
                    TXTFEBAMT.Text = ROW("FABRUARY").ToString
                    TXTMARAMT.Text = ROW("MARCH").ToString
                Next
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

End Class