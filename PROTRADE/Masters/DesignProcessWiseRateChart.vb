
Imports BL

Public Class DesignProcessWiseRateChart
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGNPROCESSWISERATECHART.DES_NO, 0) AS ID ", "", " DESIGNPROCESSWISERATECHART INNER JOIN DESIGNMASTER ON DESIGNPROCESSWISERATECHART.DES_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN PROCESSMASTER ON DESIGNPROCESSWISERATECHART.DES_PROCESSID = PROCESSMASTER.PROCESS_ID ", "AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND PROCESSMASTER.PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "'  AND DES_YEARID = " & YearId & " AND DES_CMPID = " & CmpId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(CMBDESIGN, "Rate for This Design & Process Already Exist in Grid below")
                bln = False
            End If
        End If

        If CMBDESIGN.Text.Trim.Length = 0 Then
            EP.SetError(CMBDESIGN, "Select Design")
            bln = False
        End If

        If CMBPROCESS.Text.Trim.Length = 0 Then
            EP.SetError(CMBPROCESS, "Select Process")
            bln = False
        End If

        Return bln
    End Function

    Sub FILLGRID()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGNPROCESSWISERATECHART.DES_NO, 0) AS ID, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(DESIGNPROCESSWISERATECHART.DES_RATE, '') AS RATE ", "", " DESIGNPROCESSWISERATECHART INNER JOIN DESIGNMASTER ON DESIGNPROCESSWISERATECHART.DES_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN PROCESSMASTER ON DESIGNPROCESSWISERATECHART.DES_PROCESSID = PROCESSMASTER.PROCESS_ID ", " AND DES_YEARID = " & YearId & " AND DES_CMPID = " & CmpId)

        gridbilldetails.DataSource = DT

    End Sub

    Private Sub KarigarWiseLabour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F1 And e.Alt = True Then

        End If
    End Sub

    Sub FILLCMB()
        Try
            fillDESIGN(CMBDESIGN, "")
            FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            CMBDESIGN.Text = ""
            CMBPROCESS.Text = ""
            TXTRATE.Clear()
            gridbilldetails.DataSource = Nothing

            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarWiseLabour_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            FILLCMB()
            CLEAR()
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Function CHECKGRID() As Boolean
        'Try
        '    Dim BLN As Boolean = True

        '    For I As Integer = 0 To gridbill.RowCount - 1
        '        Dim ROW As DataRow = gridbill.GetDataRow(I)
        '        If (GRIDDOUBLECLICK = False And ROW("DESIGN") = CMBDESIGN.Text.Trim And ROW("PROCESS") = CMBPROCESS.Text.Trim) Or (GRIDDOUBLECLICK = True And I <> TEMPROW And ROW("DESIGN") = CMBDESIGN.Text.Trim And ROW("PROCESS") = CMBPROCESS.Text.Trim) Then
        '            BLN = False
        '        End If
        '    Next
        '    Return BLN
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        Try
            If CMBDESIGN.Text.Trim <> "" And CMBPROCESS.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then
                If Not errorvalid() Then
                    MsgBox("Rate for This Design & Process Already Exist in Grid below", MsgBoxStyle.Critical)
                    CMBDESIGN.Focus()
                    Exit Sub
                End If
                SAVE()
            Else
                MsgBox("Enter Details")
            End If
            CMBDESIGN.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        CMBDESIGN.Focus()
    End Sub

    Sub SAVE()
        Try

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            Dim OBJCONFIG As New ClsDesignProcessWiseRateChart

            ALPARAVAL.Add(Val(TXTNO.Text.Trim))
            ALPARAVAL.Add(CMBDESIGN.Text.Trim)
            ALPARAVAL.Add(CMBPROCESS.Text.Trim)
            ALPARAVAL.Add(TXTRATE.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            OBJCONFIG.alParaval = ALPARAVAL

            Dim INT As Integer = OBJCONFIG.SAVE()
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click

        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub


            'DELETE FROM TABLE
            Dim OBJSM As New ClsDesignProcessWiseRateChart
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("ID"))
            ALPARAVAL.Add(Userid)


            OBJSM.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJSM.DELETE()
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLABOUR_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If TXTRATE.Visible = True Then Exit Sub
            If CMBDESIGN.Text.Trim <> "" And CMBPROCESS.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then
                If Not CHECKGRID() Then
                    MsgBox("Rate for This Design & Process Already Exist in Grid below", MsgBoxStyle.Critical)
                    CMBDESIGN.Focus()
                    Exit Sub
                End If
                FILLGRID()
            Else
                MsgBox("Enter Details")
            End If
            CMBDESIGN.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        EDITROW()

    End Sub

    Sub EDITROW()
        Try
            If gridbill.GetFocusedRowCellValue("ID") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = gridbill.GetFocusedRowCellValue("ID")
                CMBDESIGN.Text = gridbill.GetFocusedRowCellValue("DESIGN")
                CMBPROCESS.Text = gridbill.GetFocusedRowCellValue("PROCESS")
                TXTRATE.Text = Val(gridbill.GetFocusedRowCellValue("RATE"))
                CMBDESIGN.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Call CMDDELETE_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class