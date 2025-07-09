
Imports BL

Public Class ProgramFilter


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProgramFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProgramFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillname(CMBPARTYNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If CMBPARTYNAME.Text.Trim = "" Then
                MsgBox("Select Name", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim OBJPROGRAM As New ProgramDesign
            OBJPROGRAM.MdiParent = MDIMain
            OBJPROGRAM.WHERECLAUSE = "{PROGRAMMASTER.PROGRAM_YEARID} = " & YearId & " AND {LEDGERS.ACC_CMPNAME}= '" & CMBPARTYNAME.Text.Trim & "'"
            If RBSELECTED.Checked = True Then
                gridbill.ClearColumnsFilter()
                Dim LOTNOS As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If LOTNOS = "" Then
                            LOTNOS = " AND ({PROGRAMMASTER.PROGRAM_LOTNO} = " & Val(dtrow("LOTNO"))
                        Else
                            LOTNOS = LOTNOS & " OR {PROGRAMMASTER.PROGRAM_LOTNO} = " & Val(dtrow("LOTNO"))
                        End If
                    End If
                Next
                If LOTNOS <> "" Then
                    LOTNOS = LOTNOS & ")"
                    OBJPROGRAM.WHERECLAUSE = OBJPROGRAM.WHERECLAUSE & LOTNOS
                End If
            End If
            OBJPROGRAM.Show()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub FILLGRID()
        Try
            Dim WHERECLAUSE As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, PROGRAMMASTER.PROGRAM_LOTNO AS LOTNO ", " ", " PROGRAMMASTER INNER JOIN LEDGERS ON PROGRAMMASTER.PROGRAM_LEDGERID = LEDGERS.Acc_id ", " AND LEDGERS.ACC_CMPNAME = '" & CMBPARTYNAME.Text.Trim & "' AND PROGRAM_YEARID = '" & YearId & "' ORDER BY PROGRAM_LOTNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        gridbilldetails.Visible = True
        FILLGRID()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        gridbilldetails.Visible = False
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class