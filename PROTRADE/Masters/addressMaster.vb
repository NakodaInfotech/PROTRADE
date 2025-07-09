
Imports BL
Imports System.Windows.Forms

Public Class addressMaster

    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TempID As Integer
    Public TEMPALIAS, TEMPNAME As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtaddress.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(TXTGSTIN.Text.Trim)
            alParaval.Add(txtcstno.Text.Trim)
            alParaval.Add(txtvatno.Text.Trim)
            alParaval.Add(CMBSTATE.Text.Trim)

            Dim objclsADDRESSMaster As New clsaddress
            objclsADDRESSMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsADDRESSMaster.save()
                MsgBox("Details Added")

            ElseIf edit = True Then

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TempID)
                IntResult = objclsADDRESSMaster.update()
                MsgBox("Details Updated")

            End If

            clear()
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbname, "Fill Name")
            bln = False
        End If

        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If CMBSTATE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBSTATE, "Select State")
            bln = False
        End If

        If txtaddress.Text.Trim.Length = 0 Then
            Ep.SetError(txtaddress, "Fill Address")
            bln = False
        End If


        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If CMBSTATE.Text.Trim <> "" And TXTGSTIN.Text.Trim <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & CMBSTATE.Text.Trim & "'  and STATE_YEARID = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTIN.Text.Substring(0, 2) Then
                Ep.SetError(TXTGSTIN, "State Code does not match with GST No")
                bln = False
            End If
        End If

        If TXTGSTIN.Text.Trim.Length > 0 And TXTGSTIN.Text.Trim.Length <> 15 Then
            Ep.SetError(TXTGSTIN, "Enter Proper GST No")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        Ep.Clear()
        txtname.Clear()
        txtaddress.Clear()
        txtcstno.Clear()
        txtvatno.Clear()
        TXTGSTIN.Clear()
        CMBSTATE.Text = ""
    End Sub

    Private Sub addressMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                pcase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ACC_add", "", "LEDGERS", " and ACC_cmpname = '" & cmbname.Text.Trim & "' and ACC_cmpid = " & CmpId & " and ACC_Locationid = " & Locationid & " and ACC_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("ACC not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCounts"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_cmpname", "", "LEDGERS", " and ACC_cmpname = '" & cmbname.Text.Trim & "' and ACC_cmpid = " & CmpId & " and ACC_Locationid = " & Locationid & " and ACC_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    'txtadd.Text = dt.Rows(0).Item(0).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub addressMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            txtname.Text = TEMPALIAS
            cmbname.Text = TEMPNAME
            fillSTATE(CMBSTATE)

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If EDIT = True Then dttable = objCommon.search("     LEDGERS.Acc_cmpname, ADDRESSMASTER.ADDRESS_ALIAS, ADDRESSMASTER.ADDRESS_FULL, ADDRESSMASTER.ADDRESS_VATNO, ADDRESSMASTER.ADDRESS_GSTIN, ADDRESSMASTER.ADDRESS_CSTNO, ISNULL(STATEMASTER.state_name, '') AS STATE ", "", "  ADDRESSMASTER INNER JOIN LEDGERS ON ADDRESSMASTER.ADDRESS_LEDGERID = LEDGERS.Acc_id AND ADDRESSMASTER.ADDRESS_cmpid = LEDGERS.Acc_cmpid AND ADDRESSMASTER.ADDRESS_locationid = LEDGERS.Acc_locationid AND ADDRESSMASTER.ADDRESS_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON ADDRESSMASTER.ADDRESS_STATEID = STATEMASTER.state_id ", " and ADDRESS_id = " & TempID & " and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                cmbname.Text = dttable.Rows(0).Item(0).ToString
                txtname.Text = dttable.Rows(0).Item(1).ToString
                TEMPALIAS = dttable.Rows(0).Item(1).ToString
                txtaddress.Text = dttable.Rows(0).Item(2).ToString
                txtvatno.Text = dttable.Rows(0).Item(3).ToString
                TXTGSTIN.Text = dttable.Rows(0).Item(4).ToString
                txtcstno.Text = dttable.Rows(0).Item(5).ToString
                CMBSTATE.Text = dttable.Rows(0).Item(6).ToString
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(txtname.Text) <> LCase(TEMPALIAS)) Then
                dt = objclscommon.search("address_alias", "", "addressMaster", " and address_alias = '" & txtname.Text & "' And address_cmpid = " & CmpId & " And address_locationid = " & Locationid & " And address_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("address Alias Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
    End Sub

   
End Class