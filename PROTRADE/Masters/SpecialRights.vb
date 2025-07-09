
Imports BL

Public Class SpecialRights

    Public EDIT As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub UserMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub UserMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillUSER(CMBUSER)
            clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBUSER.Text.Trim.Length = 0 Then
            EP.SetError(CMBUSER, "Select User Name")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CHKHOME.CheckState = CheckState.Checked
        CHKGRN.CheckState = CheckState.Checked
        CHKINHOUSECHECK.CheckState = CheckState.Checked
        CHKJOBOUT.CheckState = CheckState.Checked
        CHKINHOUSECHECK.CheckState = CheckState.Checked
        CHKPURCHASE.CheckState = CheckState.Checked
        CHKPO.CheckState = CheckState.Checked
        CHKMATREC.CheckState = CheckState.Checked
        CHKGDN.CheckState = CheckState.Checked
        CHKJOBIN.CheckState = CheckState.Checked
        CHKRECPACK.CheckState = CheckState.Checked
        CHKSALE.CheckState = CheckState.Checked
        CHKSALEORDER.CheckState = CheckState.Checked
        CHKGRNCHECK.CheckState = CheckState.Checked


        CHKDASHBOARD.CheckState = CheckState.Checked

        CHKRECOUTSTANDING.CheckState = CheckState.Checked
        CHKPAYOUTSTANDING.CheckState = CheckState.Checked
        CHKPENDINGPO.CheckState = CheckState.Checked
        CHKPENDINGSO.CheckState = CheckState.Checked
        CHKSTOCK.CheckState = CheckState.Checked
        CHKMONTHLY.CheckState = CheckState.Checked

        CHKCHALLANSO.CheckState = CheckState.Checked
        CHKBILLCHECKDISPUTE.CheckState = CheckState.Checked
        CHKLOCKPENDING.CheckState = CheckState.Checked

        CHKMERGEPARAMETER.CheckState = CheckState.Checked
        CHKSTOCKADJUSTMENT.CheckState = CheckState.Checked
        CHKSAMTRDIFF.CheckState = CheckState.Checked

        CMBUSER.Text = ""
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click

        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            Dim OBJCONFIG As New ClsSpecialRightsMaster

            If CHKHOME.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKPO.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKGRN.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKGRNCHECK.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMATREC.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKINHOUSECHECK.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKGDN.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKJOBOUT.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKJOBIN.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKISSUEPACK.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKRECPACK.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKPURCHASE.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKSALE.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKSALEORDER.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKDASHBOARD.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKRECOUTSTANDING.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKPAYOUTSTANDING.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKPENDINGPO.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKPENDINGSO.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKSTOCK.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMONTHLY.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKCHALLANSO.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKBILLCHECKDISPUTE.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKLOCKPENDING.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMERGEPARAMETER.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKSTOCKADJUSTMENT.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKSAMTRDIFF.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(CMBUSER.Text.Trim)


            OBJCONFIG.alParaval = alParaval
            IntResult = OBJCONFIG.save()
            MsgBox("Details Added")
            clear()
            CMBUSER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUSER.Validated
        Try
            If CMBUSER.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.search(" SPECIALRIGHTS.HOME, SPECIALRIGHTS.PO, SPECIALRIGHTS.GRN, SPECIALRIGHTS.MATREC, SPECIALRIGHTS.INHOUSECHECK, SPECIALRIGHTS.CHALLAN, SPECIALRIGHTS.JOBOUT, SPECIALRIGHTS.JOBIN,  SPECIALRIGHTS.ISSUEPACKING, SPECIALRIGHTS.RECPACKING, SPECIALRIGHTS.PURINVOICE, SPECIALRIGHTS.SALEINVOICE, SPECIALRIGHTS.SHOWDASHBOARD, SPECIALRIGHTS.RECOUTSTANDING, SPECIALRIGHTS.PAYOUTSTANDING, SPECIALRIGHTS.PENDINGPO, SPECIALRIGHTS.PENDINGSO, SPECIALRIGHTS.STOCKDETAILS, SPECIALRIGHTS.SALEPURMONTHLY, SPECIALRIGHTS.GRNCHECKING, SPECIALRIGHTS.SALEORDER, ISNULL(SPECIALRIGHTS.CHALLANSO, 0) AS CHALLANSO, ISNULL(SPECIALRIGHTS.BILLCHECKDISPUTE, 0) AS BILLCHECKDISPUTE, ISNULL(SPECIALRIGHTS.LOCKPENDING, 0) AS LOCKPENDING, ISNULL(SPECIALRIGHTS.MERGEPARAMETER, 0) AS MERGEPARAMETER, ISNULL(SPECIALRIGHTS.STOCKADJUSTMENT, 0) AS STOCKADJUSTMENT, ISNULL(SPECIALRIGHTS.SAMTRDIFF, 0) AS SAMTRDIFF ", "", "  USERMASTER RIGHT OUTER JOIN SPECIALRIGHTS ON USERMASTER.User_id = SPECIALRIGHTS.USERID ", "  AND USERMASTER.USER_NAME='" & CMBUSER.Text.Trim & "'")
                If dt.Rows.Count > 0 Then
                    CHKHOME.Checked = dt.Rows(0).Item(0)
                    CHKPO.Checked = dt.Rows(0).Item(1)
                    CHKGRN.Checked = dt.Rows(0).Item(2)
                    CHKMATREC.Checked = dt.Rows(0).Item(3)
                    CHKINHOUSECHECK.Checked = dt.Rows(0).Item(4)
                    CHKGDN.Checked = dt.Rows(0).Item(5)
                    CHKJOBOUT.Checked = dt.Rows(0).Item(6)
                    CHKJOBIN.Checked = dt.Rows(0).Item(7)
                    CHKISSUEPACK.Checked = dt.Rows(0).Item(8)
                    CHKRECPACK.Checked = dt.Rows(0).Item(9)
                    CHKPURCHASE.Checked = dt.Rows(0).Item(10)
                    CHKSALE.Checked = dt.Rows(0).Item(11)
                    CHKDASHBOARD.Checked = dt.Rows(0).Item(12)
                    CHKRECOUTSTANDING.Checked = dt.Rows(0).Item(13)
                    CHKPAYOUTSTANDING.Checked = dt.Rows(0).Item(14)
                    CHKPENDINGPO.Checked = dt.Rows(0).Item(15)

                    CHKPENDINGSO.Checked = dt.Rows(0).Item(16)
                    CHKSTOCK.Checked = dt.Rows(0).Item(17)
                    CHKMONTHLY.Checked = dt.Rows(0).Item(18)
                    CHKGRNCHECK.Checked = dt.Rows(0).Item(19)
                    CHKSALEORDER.Checked = dt.Rows(0).Item(20)

                    CHKCHALLANSO.Checked = dt.Rows(0).Item(21)
                    CHKBILLCHECKDISPUTE.Checked = dt.Rows(0).Item(22)
                    CHKLOCKPENDING.Checked = dt.Rows(0).Item(23)
                    CHKSTOCKADJUSTMENT.Checked = dt.Rows(0).Item(25)
                    CHKMERGEPARAMETER.Checked = dt.Rows(0).Item(24)
                    CHKSAMTRDIFF.Checked = dt.Rows(0).Item(26)


                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUSER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUSER.Validating
        Try
            If CMBUSER.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.search(" * ", "", " SPECIALRIGHTS  ", "  AND specialrights.userid=" & Userid)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class