
Imports BL

Public Class OpeningClosingStock

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            'CHECK WHETHER DATA IS THERE FOR THIS YEAR OR NOT IF PRESENT THEN UPDATE ELSE INSERT
            DT = OBJCMN.search("OPENINGSTOCK", "", "OPENINGCLOSINGSTOCK", " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then DT = OBJCMN.Execute_Any_String(" UPDATE OPENINGCLOSINGSTOCK SET OPENINGSTOCK = " & Val(TXTOPENING.Text.Trim) & ", CLOSINGSTOCK = " & Val(TXTCLOSING.Text.Trim) & " WHERE YEARID = " & YearId, "", "") Else DT = OBJCMN.Execute_Any_String(" INSERT INTO OPENINGCLOSINGSTOCK VALUES (" & Val(TXTOPENING.Text.Trim) & "," & Val(TXTCLOSING.Text.Trim) & "," & CmpId & "," & YearId & ")", "", "")

            'POSTING IN ACCMASTER
            'Stock In Hand DEBIT AND Closing Stock CR
            Dim FROMLEDGERID, TOLEDGERID As Integer
            DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Closing Stock' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then FROMLEDGERID = DT.Rows(0).Item(0)


            DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Stock In Hand' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TOLEDGERID = DT.Rows(0).Item(0)


            DT = OBJCMN.Execute_Any_String(" DELETE FROM ACCMASTER WHERE ACC_TYPE = 'STOCK' AND ACC_FROMID = " & FROMLEDGERID & " AND ACC_TOID = " & TOLEDGERID & " AND ACC_YEARID = " & YearId, "", "")
            If Val(TXTCLOSING.Text.Trim) > 0 Then DT = OBJCMN.Execute_Any_String(" INSERT INTO ACCMASTER VALUES (" & Val(FROMLEDGERID) & "," & Val(TXTCLOSING.Text.Trim) & "," & TOLEDGERID & ",0,'" & Format(AccTo.Date, "MM/dd/yyyy") & "','STOCK','','', '', '" & Format(AccTo.Date, "MM/dd/yyyy") & "', '" & Format(AccTo.Date, "MM/dd/yyyy") & "','',0,'','',''," & CmpId & ",0," & Userid & "," & YearId & ",0,GETDATE())", "", "")


            'POSTNG IN ACCMASTER
            'OPENING STOCK DEBIT AND OPENING A/C CREDIT
            DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Opening A/C' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then FROMLEDGERID = DT.Rows(0).Item(0)


            DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Opening Stock' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TOLEDGERID = DT.Rows(0).Item(0)


            DT = OBJCMN.Execute_Any_String(" DELETE FROM ACCMASTER WHERE ACC_TYPE = 'OPENING' AND ACC_FROMID = " & FROMLEDGERID & " AND ACC_TOID = " & TOLEDGERID & " AND ACC_YEARID = " & YearId, "", "")
            If Val(TXTOPENING.Text.Trim) > 0 Then DT = OBJCMN.Execute_Any_String(" INSERT INTO ACCMASTER VALUES (" & Val(FROMLEDGERID) & "," & Val(TXTOPENING.Text.Trim) & "," & TOLEDGERID & ",0,'" & Format(AccFrom.Date, "MM/dd/yyyy") & "','OPENING','','','', '" & Format(AccTo.Date, "MM/dd/yyyy") & "', '" & Format(AccTo.Date, "MM/dd/yyyy") & "','',0,'','',''," & CmpId & ", 0, " & Userid & ", " & YearId & ", 0, GETDATE()) ", "", "")
            DT = OBJCMN.Execute_Any_String("UPDATE ACCOUNTSMASTER SET ACC_DRCR = 'Dr.', ACC_OPBAL = " & Val(TXTOPENING.Text.Trim) & " WHERE ACC_CMPNAME = 'OPENING STOCK' AND ACC_YEARID = " & YearId, "", "")

            MsgBox("Details Updated")
            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningClosingStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningClosingStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(OPENINGSTOCK,0) AS OPENINGSTOCK, ISNULL(CLOSINGSTOCK,0) AS CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TXTOPENING.Text = DT.Rows(0).Item("OPENINGSTOCK")
                TXTCLOSING.Text = DT.Rows(0).Item("CLOSINGSTOCK")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class