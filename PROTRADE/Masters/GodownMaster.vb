
Imports System.ComponentModel
Imports BL

Public Class GodownMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public TEMPGODOWN As String
    Public TEMPGODOWNID As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GODOWNMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub clear()
        Try
            TXTGODOWN.Clear()
            TXTADDRESS.Clear()
            TXTPINCODE.Clear()
            TXTKMS.Clear()
            cmbstate.Text = ""
            CHKOURGODOWN.CheckState = CheckState.Unchecked
            CHKDEFAULT.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GODOWNMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GODOWN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            clear()
            TXTGODOWN.Text = TEMPGODOWN
            If cmbstate.Text.Trim = "" Then fillSTATE(cmbstate)

            If edit = True Then


                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search("  GODOWNMASTER.GODOWN_ID AS GODOWNID, GODOWNMASTER.GODOWN_NAME AS GODOWNNAME, GODOWNMASTER.GODOWN_ADDRESS AS GODOWNADDRESS, GODOWNMASTER.GODOWN_ISOUR AS OURGODOWN, GODOWNMASTER.GODOWN_ISDEFAULT AS ISDEFAULT, ISNULL(GODOWNMASTER.GODOWN_PINCODE,'') AS PINCODE, ISNULL(GODOWNMASTER.GODOWN_KMS,0) AS KMS, ISNULL(STATEMASTER.STATE_NAME,'') AS STATENAME ", "", "   GODOWNMASTER LEFT OUTER JOIN STATEMASTER ON GODOWN_STATEID = STATE_ID", " and GODOWNMASTER.GODOWN_ID = '" & TEMPGODOWNID & "' and GODOWNMASTER.GODOWN_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        TEMPGODOWN = ROW("GODOWNNAME")
                        TXTGODOWN.Text = ROW("GODOWNNAME")
                        TXTADDRESS.Text = ROW("GODOWNADDRESS")
                        TXTPINCODE.Text = ROW("PINCODE")
                        TXTKMS.Text = Val(ROW("KMS"))
                        cmbstate.Text = ROW("STATENAME")
                        CHKOURGODOWN.Checked = Convert.ToBoolean(ROW("OURGODOWN"))
                        CHKDEFAULT.Checked = Convert.ToBoolean(ROW("ISDEFAULT"))
                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub TXTGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGODOWN.Validating
        Try
            If TXTGODOWN.Text.Trim <> "" Then
                uppercase(TXTGODOWN)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TXTGODOWN.Text) <> LCase(TEMPGODOWN)) Then
                    dt = OBJCMN.search("GODOWN_NAME", "", "GODOWNMASTER", " and GODOWN_NAME = '" & TXTGODOWN.Text.Trim & "' And GODOWN_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Godown Name Already Exists", MsgBoxStyle.Critical, "PROCESS")
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTGODOWN.Text.Trim.Length = 0 Then
            EP.SetError(TXTGODOWN, "Fill Godown Name")
            bln = False
        End If

        If CHKOURGODOWN.CheckState = CheckState.Unchecked And CHKDEFAULT.CheckState = CheckState.Checked Then
            EP.SetError(CHKDEFAULT, "Only Our Godown can be set as Default")
            bln = False
        End If
        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTGODOWN.Text.Trim)
            alParaval.Add(TXTADDRESS.Text.Trim)
            If CHKOURGODOWN.CheckState = CheckState.Checked Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKDEFAULT.CheckState = CheckState.Checked Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(TXTPINCODE.Text.Trim)
            alParaval.Add(Val(TXTKMS.Text.Trim))
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objclsGODOWNMASTER As New ClsGodownMaster
            objclsGODOWNMASTER.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsGODOWNMASTER.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPGODOWNID)
                IntResult = objclsGODOWNMASTER.Update()
                MsgBox("Details Updated")

            End If
            edit = False


            clear()
            TXTGODOWN.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Enter(sender As Object, e As EventArgs) Handles cmbstate.Enter
        Try
            If cmbstate.Text.Trim = "" Then fillSTATE(cmbstate)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(sender As Object, e As CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then STATEVALIDATE(cmbstate, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class