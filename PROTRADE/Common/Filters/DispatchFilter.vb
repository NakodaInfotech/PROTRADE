
Imports BL

Public Class DispatchFilter
    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.Enter
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try
            If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, cmbacccode, e, Me, txtadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS') ", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillitemname(CMBQUALITY, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then itemvalidate(CMBQUALITY, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgodown_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgodown_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            ' dtopening.Value = DateAdd(DateInterval.Day, -1, AccFrom)
            If CMBQUALITY.Text.Trim = "" Then fillitemname(CMBQUALITY, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBQUALITY.Text.Trim)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
            If RDBPARTY.Checked = True Then TXTTEMP.Text = "PARTYWISE"
            If RDBPARTYDETAILS.Checked = True Then TXTTEMP.Text = "PARTYWISEDETAILS"
            If RDBDESIGN.Checked = True Then TXTTEMP.Text = "DESIGNWISE"
            If RDBDESIGNDETAILS.Checked = True Then TXTTEMP.Text = "DESIGNWISEDETAILS"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

        Dim OBJSTOCK As New GDNDESIGN
        OBJSTOCK.FRMSTRING = TXTTEMP.Text
        OBJSTOCK.MdiParent = MDIMain
        OBJSTOCK.selfor_ss = "1=1"

        If chkdate.Checked = True Then
            getFromToDate()
            OBJSTOCK.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
            OBJSTOCK.TODATE = Format(dtto.Value, "MM/dd/yyyy")
            OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {@DATE} in date " & fromD & " to date " & toD & ""
        Else
            OBJSTOCK.OPENINGDATE = Format(DateAdd(DateInterval.Day, -1, AccFrom), "MM/dd/yyyy")
            OBJSTOCK.FROMDATE = Format(AccFrom, "MM/dd/yyyy")
            OBJSTOCK.TODATE = Format(AccTo, "MM/dd/yyyy")
            OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
        End If

        If RDBPARTY.Checked = True Then
            If CMBPARTYNAME.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {LEDGERS.ACC_CMPNAME}='" & CMBPARTYNAME.Text & "'"
            If CMBQUALITY.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
            If CMBGODOWN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
            If CMBDESIGN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
            If CMBPIECETYPE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({JOBBERSTOCK.Piece Type}='" & CMBPIECETYPE.Text.Trim & "')"
            If CMBSHADE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
            If CMBAGENT.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GDN.GDN_cmpid}=" & CmpId & " and {GDN.GDN_locationid}=" & Locationid & " and {GDN.GDN_yearid}=" & YearId

        ElseIf RDBPARTYDETAILS.Checked = True Then
            If CMBPARTYNAME.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {LEDGERS.ACC_CMPNAME}='" & CMBPARTYNAME.Text & "'"
            If CMBQUALITY.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
            If CMBGODOWN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
            If CMBDESIGN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
            If CMBPIECETYPE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({JOBBERSTOCK.Piece Type}='" & CMBPIECETYPE.Text.Trim & "')"
            If CMBSHADE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
            If CMBAGENT.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GDN.GDN_cmpid}=" & CmpId & " and {GDN.GDN_locationid}=" & Locationid & " and {GDN.GDN_yearid}=" & YearId

        ElseIf RDBDESIGN.Checked = True Then
            If CMBPARTYNAME.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {LEDGERS.ACC_CMPNAME}='" & CMBPARTYNAME.Text & "'"
            If CMBQUALITY.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
            If CMBGODOWN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
            If CMBDESIGN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
            If CMBPIECETYPE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({JOBBERSTOCK.Piece Type}='" & CMBPIECETYPE.Text.Trim & "')"
            If CMBSHADE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
            If CMBAGENT.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GDN.GDN_cmpid}=" & CmpId & " and {GDN.GDN_locationid}=" & Locationid & " and {GDN.GDN_yearid}=" & YearId

        ElseIf RDBDESIGNDETAILS.Checked = True Then
            If CMBPARTYNAME.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {LEDGERS.ACC_CMPNAME}='" & CMBPARTYNAME.Text & "'"
            If CMBQUALITY.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
            If CMBGODOWN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
            If CMBDESIGN.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
            If CMBPIECETYPE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({JOBBERSTOCK.Piece Type}='" & CMBPIECETYPE.Text.Trim & "')"
            If CMBSHADE.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
            If CMBAGENT.Text <> "" Then OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
            OBJSTOCK.selfor_ss = OBJSTOCK.selfor_ss & " and {GDN.GDN_cmpid}=" & CmpId & " and {GDN.GDN_locationid}=" & Locationid & " and {GDN.GDN_yearid}=" & YearId

        End If

        OBJSTOCK.Show()

    End Sub

    Private Sub StockFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBQUALITY.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RDBPARTY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBPARTY.CheckedChanged
        Try
            If RDBPARTY.Checked = True Then TXTTEMP.Text = "PARTYWISE"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBDESIGN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBDESIGN.CheckedChanged
        Try
            If RDBDESIGN.Checked = True Then TXTTEMP.Text = "DESIGNWISE"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBPARTYDETAILS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBPARTYDETAILS.CheckedChanged
        Try
            If RDBPARTYDETAILS.Checked = True Then TXTTEMP.Text = "PARTYWISEDETAILS"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBDESIGNDETAILS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBDESIGNDETAILS.CheckedChanged
        Try
            If RDBDESIGNDETAILS.Checked = True Then TXTTEMP.Text = "DESIGNWISEDETAILS"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBHASTE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHASTE.Enter
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHASTE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" ADDRESS_alias ", "", "   ADDRESSMASTER INNER JOIN LEDGERS ON ADDRESSMASTER.ADDRESS_LEDGERID = LEDGERS.ACC_id AND ADDRESSMASTER.ADDRESS_cmpid = LEDGERS.ACC_cmpid AND ADDRESSMASTER.ADDRESS_locationid = LEDGERS.ACC_locationid AND ADDRESSMASTER.ADDRESS_yearid = LEDGERS.ACC_yearid  ", "  and  LEDGERS.ACC_cmpname ='" & CMBPARTYNAME.Text.Trim & "' and ADDRESS_cmpid=" & CmpId & " and ADDRESS_Locationid=" & Locationid & " and ADDRESS_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ADDRESS_alias"
                    CMBHASTE.DataSource = dt
                    CMBHASTE.DisplayMember = "ADDRESS_alias"
                End If
                CMBHASTE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBHASTE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHASTE.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHASTE.Text.Trim <> "" Then
                pcase(CMBHASTE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ADDRESS_full", "", " ADDRESSMASTER INNER JOIN LEDGERS ON ADDRESSMASTER.ADDRESS_LEDGERID = LEDGERS.ACC_id AND ADDRESSMASTER.ADDRESS_cmpid = LEDGERS.ACC_cmpid AND ADDRESSMASTER.ADDRESS_locationid = LEDGERS.ACC_locationid AND ADDRESSMASTER.ADDRESS_yearid = LEDGERS.ACC_yearid  ", "  and  LEDGERS.ACC_cmpname ='" & CMBPARTYNAME.Text.Trim & "'  and ADDRESS_alias = '" & CMBHASTE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHASTE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("ADDRESS not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then

                        CMBHASTE.Text = a
                        Dim objADDRESSmaster As New addressMaster
                        objADDRESSmaster.txtname.Text = CMBHASTE.Text
                        objADDRESSmaster.cmbname.Text = CMBPARTYNAME.Text
                        objADDRESSmaster.cmbname.Enabled = False
                        objADDRESSmaster.ShowDialog()
                        dt = objclscommon.search("ADDRESS_alias", "", "ADDRESSMaster", " and ADDRESS_alias = '" & CMBHASTE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHASTE.DataSource
                            If CMBHASTE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHASTE.Text.Trim)
                                    CMBHASTE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtDeliveryadd.Text = dt.Rows(0).Item(0).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class