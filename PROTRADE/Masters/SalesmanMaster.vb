
Imports BL

Public Class SalesmanMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean              'Used for edit
    Public TEMPNAME As String           'Used for edit name
    Public TEMPID As Integer            'Used for edit id

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(TXTNAME.Text.Trim)
            ALPARAVAL.Add(TXTMOBILENO.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            Dim OBJADD As New ClsSalesmanMaster
            OBJADD.ALPARAVAL = ALPARAVAL
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJADD.SAVE()
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                ALPARAVAL.Add(TEMPID)

                IntResult = OBJADD.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            CLEAR()
            TXTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If TXTNAME.Text.Trim.Length = 0 Then
                EP.SetError(TXTNAME, "Fill Name")
                BLN = False
            Else
                If (EDIT = False) Or (EDIT = True And LCase(TEMPNAME) <> LCase(TXTNAME.Text.Trim)) Then
                    ' search duplication 
                    Dim OBJCMN As New ClsCommon
                    Dim dt As New DataTable
                    dt = OBJCMN.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & TXTNAME.Text.Trim & "' AND  SALESMAN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        EP.SetError(TXTNAME, "Name Already Exists")
                        BLN = False
                    End If
                    uppercase(TXTNAME)
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub CLEAR()
        Try
            EP.Clear()
            TXTNAME.Clear()
            TXTMOBILENO.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNAME.Validating
        Try

            If (EDIT = False) Or (EDIT = True And LCase(TEMPNAME) <> LCase(TXTNAME.Text.Trim)) Then
                ' search duplication 
                If TXTNAME.Text.Trim <> Nothing Then
                    Dim OBJCMN As New ClsCommonMaster
                    Dim dt As New DataTable
                    dt = OBJCMN.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & TXTNAME.Text.Trim & "' AND  SALESMAN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                    uppercase(TXTNAME)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalesmanMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SalesmanMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            CLEAR()
            TXTNAME.Text = TEMPNAME

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPID)
                ALPARAVAL.Add(YearId)
                Dim OBJSELECT As New ClsSalesmanMaster
                OBJSELECT.ALPARAVAL = ALPARAVAL
                Dim dttable As DataTable = OBJSELECT.GETSALESMAN()
                If dttable.Rows.Count > 0 Then
                    TXTNAME.Text = dttable.Rows(0).Item("NAME").ToString
                    TXTMOBILENO.Text = dttable.Rows(0).Item("MOBILENO").ToString
                    TEMPNAME = dttable.Rows(0).Item("NAME").ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Salesman Permanently?", MsgBoxStyle.YesNo, "PROTRADE")
                If tempmsg = vbYes Then

                    Dim OBJSalesman As New ClsSalesmanMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPID)
                    ALPARAVAL.Add(YearId)

                    OBJSalesman.ALPARAVAL = ALPARAVAL
                    Dim INTRES As Integer = OBJSalesman.DELETE()
                    EDIT = False
                    CLEAR()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            TXTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class