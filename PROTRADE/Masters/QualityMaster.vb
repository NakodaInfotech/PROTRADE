
Imports BL
Imports System.Windows.Forms
Imports System.Data

Public Class QualityMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim IntResult As Integer
    Public EDIT As Boolean
    Public tempQualityName As String
    Public tempQualityId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(UCase(cmbQuality.Text.Trim))
            alParaval.Add(cmbProcessName.Text.Trim)
            alParaval.Add(cmbunit.Text.Trim)
            alParaval.Add(cmbitemname.Text.Trim)
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(TXTPICK.Text.Trim)
            alParaval.Add(TXTCOUNT.Text.Trim)
            alParaval.Add(TXTWIDTH.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTWARP.Text.Trim)
            alParaval.Add(TXTWEFT.Text.Trim)
            alParaval.Add(TXTSELVEDGE.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objclsProcessMaster As New ClsQualityMaster
            objclsProcessMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsProcessMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempQualityId)
                IntResult = objclsProcessMaster.Update()
                MsgBox("Details Updated")
                edit = False

            End If

            clear()
            cmbQuality.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbQuality)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbQuality.Text) <> LCase(tempQualityName)) Then
                dt = objclscommon.search("QUALITY_name", "", "QUALITYMaster", " and QUALITY_name = '" & cmbQuality.Text.Trim & "'  And QUALITY_cmpid = " & CmpId & " And QUALITY_locationid = " & Locationid & " And QUALITY_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Quality Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbQuality.Text.Trim.Length = 0 Then
            Ep.SetError(cmbQuality, "Fill Process Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbQuality, "Quality Already Exists")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        Try
            cmbQuality.Text = ""
            cmbunit.Text = ""
            cmbprocessname.Text = ""
            TXTREED.Clear()
            TXTPICK.Clear()
            TXTCOUNT.Clear()
            TXTWIDTH.Clear()
            txtremarks.Clear()
            TXTWARP.Clear()
            TXTWEFT.Clear()
            TXTSELVEDGE.Clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Enter
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub QualityMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillcmb()
        Try
            If cmbprocessname.Text.Trim = "" Then FILLPROCESS(cmbprocessname)
            If cmbQuality.Text.Trim = "" Then fillQUALITY(cmbQuality, EDIT)
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            cmbQuality.Text = tempQualityName

            If EDIT = True Then

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                dttable = objCommon.search(" QUALITYMASTER.QUALITY_ID AS QUALITYID, QUALITYMASTER.QUALITY_name AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT,QUALITYMASTER.QUALITY_REED AS REED,QUALITYMASTER.QUALITY_PICK AS PICK,QUALITYMASTER.QUALITY_COUNT AS COUNT,QUALITYMASTER.QUALITY_WIDTH AS WIDTH, QUALITYMASTER.QUALITY_remarks AS REMARKS,QUALITYMASTER.QUALITY_WARP AS WARP,QUALITYMASTER.QUALITY_WEFT AS WEFT,QUALITYMASTER.QUALITY_SELVEDGE AS SELVEDGE,ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME ", "", "   QUALITYMASTER LEFT OUTER JOIN PROCESSMASTER ON QUALITYMASTER.QUALITY_processid = PROCESSMASTER.PROCESS_ID AND QUALITYMASTER.QUALITY_cmpid = PROCESSMASTER.PROCESS_CMPID AND QUALITYMASTER.QUALITY_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND QUALITYMASTER.QUALITY_yearid = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN UNITMASTER ON QUALITYMASTER.QUALITY_unitid = UNITMASTER.unit_id AND QUALITYMASTER.QUALITY_cmpid = UNITMASTER.unit_cmpid AND QUALITYMASTER.QUALITY_locationid = UNITMASTER.unit_locationid AND QUALITYMASTER.QUALITY_yearid = UNITMASTER.unit_yearid  LEFT OUTER JOIN ITEMMASTER ON QUALITYMASTER.QUALITY_ITEMID = ITEMMASTER.ITEM_ID AND QUALITYMASTER.QUALITY_cmpid = ITEMMASTER.ITEM_CMPID AND QUALITYMASTER.QUALITY_locationid = ITEMMASTER.ITEM_LOCATIONID AND QUALITYMASTER.QUALITY_yearid = ITEMMASTER.ITEM_YEARID ", " and QUALITYMASTER.QUALITY_Name = '" & tempQualityName & "' and QUALITYMASTER.QUALITY_cmpid = " & CmpId & " and QUALITYMASTER.QUALITY_locationid = " & Locationid & " and QUALITYMASTER.QUALITY_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        tempQualityId = ROW("QUALITYID")

                        cmbprocessname.Text = ROW("Process").ToString

                        cmbunit.Text = ROW("UNIT").ToString
                        cmbQuality.Text = ROW("QUALITY").ToString
                        cmbitemname.Text = ROW("ITEMNAME").ToString

                        TXTREED.Text = ROW("REED").ToString
                        TXTPICK.Text = ROW("PICK").ToString
                        TXTCOUNT.Text = ROW("COUNT").ToString
                        TXTWIDTH.Text = ROW("WIDTH").ToString

                        txtremarks.Text = ROW("REMARKS").ToString
                        TXTWARP.Text = ROW("WARP").ToString
                        TXTWEFT.Text = ROW("WEFT").ToString
                        TXTSELVEDGE.Text = ROW("SELVEDGE").ToString
                    Next
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbProcessname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocessname.Enter
        Try
            If cmbprocessname.Text.Trim = "" Then FILLPROCESS(cmbprocessname)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITYNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbQuality.Validating
        Try
            If cmbQuality.Text.Trim <> "" Then
                uppercase(cmbQuality)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(cmbQuality.Text) <> LCase(tempQualityName)) Then
                    dt = objclscommon.search("QUALITY_name", "", "QUALITYMaster", " and QUALITY_name = '" & cmbQuality.Text.Trim & "'  And QUALITY_cmpid = " & CmpId & " And QUALITY_locationid = " & Locationid & " And QUALITY_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Process Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbQuality.Enter
        Try
            If cmbQuality.Text.Trim = "" Then fillQUALITY(cmbQuality, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub cmbProcessname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprocessname.Validating
    '    Try
    '        If cmbprocessname.Text.Trim <> "" Then PROCESSVALIDATE(cmbprocessname, e, Me)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEM_FRMSTRING='ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEM_FRMSTRING='ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTREED_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress
        'Try
        '    numdotkeypress(e, TXTREED, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        'Try
        '    numdotkeypress(e, TXTPICK, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TXTCOUNT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTCOUNT.KeyDown
        Try
            If e.KeyCode = Keys.F1 And ClientName = "SVS" Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then TXTCOUNT.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click

    End Sub


    Private Sub TXTCOUNT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOUNT.KeyPress
        Try
            numdotkeypress(e, TXTCOUNT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWIDTH_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWIDTH.KeyPress
        Try
            numdotkeypress(e, TXTWIDTH, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QualityMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SVS" Then
                TXTCOUNT.BackColor = Color.LemonChiffon
                LBLCOUNT.Text = "HSN Code"
                TXTCOUNT.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class