Imports BL

Public Class LoomMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public LOOMID As Integer         'Used for tempname while edit mode
    Public EDIT As Boolean           'Used for edit
    Public WEAVERNAME As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub LoomMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub LoomMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            clear()
            If WEAVERNAME <> "" Then
                CMBNAME.Text = WEAVERNAME
                FILLGRID()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            'GET DATA FROM LOOM MASTER WITH RESPECT TO WEAVER
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, cmbcode, e, Me, TXTADD, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS", "", "", "WARPER")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("LOOM_NO AS LOOMNO, LOOMMASTER.LOOM_ID AS LOOMID", "", " LOOMMASTER INNER JOIN LOOMMASTER_DESC ON LOOMMASTER.LOOM_ID = LOOMMASTER_DESC.LOOM_ID INNER JOIN LEDGERS ON LOOM_WEAVERID = ACC_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND LOOM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                GRIDLOOM.RowCount = 0
                LOOMID = DT.Rows(0).Item("LOOMID")
                For Each DTROW As DataRow In DT.Rows
                    GRIDLOOM.Rows.Add(DTROW("LOOMNO"))
                Next
                LBLTOTALLOOMS.Text = GRIDLOOM.RowCount
                EDIT = True
            Else
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Val(LBLTOTALLOOMS.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim LOOMNO As String = ""
            For Each ROW As DataGridViewRow In GRIDLOOM.Rows
                If ROW.Cells(GLOOMNO.Index).Value <> Nothing Then
                    If LOOMNO = "" Then
                        LOOMNO = Val(ROW.Cells(GLOOMNO.Index).Value)
                    Else
                        LOOMNO = LOOMNO & "|" & Val(ROW.Cells(GLOOMNO.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(LOOMNO)

            Dim OBJLOOM As New ClsLoomMaster
            OBJLOOM.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJLOOM.SAVE()
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(LOOMID)
                IntResult = OBJLOOM.UPDATE()
                EDIT = False
                MsgBox("Details Updated")
            End If

            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Warper Name")
            bln = False
        End If

        If GRIDLOOM.RowCount = 0 Then
            EP.SetError(CMBNAME, "Enter Loom Details")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CMBNAME.Text = ""
        TXTFROM.Clear()
        TXTTO.Clear()
        GRIDLOOM.RowCount = 0
        LBLTOTALLOOMS.Text = 0
    End Sub

    Private Sub CMDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADD.Click
        Try
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Loom No", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                    If Not VALIDATELOOMNO(I.ToString) Then
                        GoTo LINE1
                    End If
                    GRIDLOOM.Rows.Add(I.ToString)
LINE1:
                Next
                LBLTOTALLOOMS.Text = GRIDLOOM.RowCount
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATELOOMNO(ByVal LOOMNO As String) As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDLOOM.Rows
                If ROW.Cells(GLOOMNO.Index).Value = LOOMNO Then BLN = False
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTLOOMNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTO.KeyPress, TXTFROM.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub GRIDLOOM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDLOOM.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDLOOM.RowCount > 0 Then
                GRIDLOOM.Rows.RemoveAt(GRIDLOOM.CurrentRow.Index)
                LBLTOTALLOOMS.Text = GRIDLOOM.RowCount
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class