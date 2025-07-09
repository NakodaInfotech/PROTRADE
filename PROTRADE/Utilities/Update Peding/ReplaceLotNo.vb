
Imports BL

Public Class ReplaceLotNo

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            TXTMATRECNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTMATRECNO.Clear()
            TXTNAME.Clear()
            TXTOLDLOTNO.Clear()
            TXTNEWLOTNO.Clear()
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

    Private Sub CMDUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            Dim DTUPDATE As New DataTable

            'OLD LOTNO
            DT = OBJCMN.Execute_Any_String("SELECT MATERIALRECEIPT_DESC.MATREC_FROMNO AS FROMNO, MATERIALRECEIPT_DESC.MATREC_FROMSRNO AS FROMSRNO, MATERIALRECEIPT_DESC.MATREC_FROMTYPE AS FROMTYPE, MATERIALRECEIPT_DESC.MATREC_RECDMTRS AS RECDMTRS, MATERIALRECEIPT_DESC.MATREC_QTY AS RECDQTY FROM MATERIALRECEIPT_DESC WHERE MATERIALRECEIPT_DESC.MATREC_NO = " & Val(TXTMATRECNO.Text.Trim) & " AND MATREC_GRIDLOTNO = '" & TXTOLDLOTNO.Text.Trim & "' AND MATERIALRECEIPT_DESC.MATREC_YEARID = " & YearId, "", "")
            For Each DTROW As DataRow In DT.Rows
                If DTROW("FROMTYPE") = "OPENING" Then
                    DTUPDATE = OBJCMN.Execute_Any_String("UPDATE STOCKMASTER SET SM_DONE = 0, SM_OUTMTRS = SM_OUTMTRS - " & Val(DTROW("RECDMTRS")) & ", SM_OUTPCS = SM_OUTPCS - " & Val(DTROW("RECDQTY")) & " WHERE SM_NO = " & Val(DTROW("FROMNO")) & " AND SM_YEARID = " & YearId, "", "")
                ElseIf DTROW("FROMTYPE") = "CHECKING" Then
                    DTUPDATE = OBJCMN.Execute_Any_String("UPDATE CHECKINGMASTER_DESC SET CHECK_CHECKINGDONE = 0 WHERE CHECK_NO = " & Val(DTROW("FROMNO")) & " AND CHECK_GRIDSRNO = " & Val(DTROW("FROMSRNO")) & " AND SM_YEARID = " & YearId, "", "")
                End If
            Next


            'NEW LOTNO
            DT = OBJCMN.Execute_Any_String("SELECT GRNTYPE, CHECKNO FROM LOT_VIEW WHERE LOTNO = '" & TXTNEWLOTNO.Text.Trim & "' AND YEARID = " & YearId, "", "")
            If DT.Rows.Count > 0 Then
                DTUPDATE = OBJCMN.Execute_Any_String(" UPDATE MATERIALRECEIPT_DESC SET MATREC_GRIDLOTNO = '" & TXTNEWLOTNO.Text.Trim & "', MATREC_FROMNO = " & DT.Rows(0).Item("CHECKNO") & ", MATREC_FROMTYPE = '" & DT.Rows(0).Item("GRNTYPE") & "' WHERE MATREC_NO = " & Val(TXTMATRECNO.Text.Trim) & " And MATREC_YEARID = " & YearId, "", "")
                MsgBox("Lot No Updated Successfully")
            End If
            CLEAR()
            TXTMATRECNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTMATRECNO.Text.Trim) = 0 Then
            EP.SetError(TXTMATRECNO, "Enter Dyeing Rec No")
            bln = False
        End If

        If TXTOLDLOTNO.Text.Trim = "" Or TXTNEWLOTNO.Text.Trim = "" Then
            EP.SetError(TXTOLDLOTNO, "Enter Lot No")
            bln = False
        End If

        If TXTOLDLOTNO.Text.Trim = TXTNEWLOTNO.Text.Trim Then
            EP.SetError(TXTOLDLOTNO, "Same Lot No")
            bln = False
        End If

        Return bln
    End Function

    Private Sub TXTGRNNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMATRECNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub ReplaceLotNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMATRECNO_Validated(sender As Object, e As EventArgs) Handles TXTMATRECNO.Validated
        Try
            If Val(TXTMATRECNO.Text.Trim) > 0 Then
                'GET DYEING NAME
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME", "", " MATERIALRECEIPT INNER JOIN LEDGERS ON MATREC_ledgerid = LEDGERS.ACC_ID", " AND MATREC_NO = " & Val(TXTMATRECNO.Text.Trim) & " AND MATREC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTNAME.Text = DT.Rows(0).Item("NAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReplaceLotNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class