
Imports BL

Public Class GDNFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
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

    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
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

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " AND LEDGERS.ACC_TYPE = 'AGENT' ")
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)


            Dim OBJCMN As New ClsCommon
            Dim WHERECLAUSE As String = ""
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.GROUP_NAME AS GROUPNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY, ISNULL(STATEMASTER.STATE_NAME,'') AS STATENAME, ISNULL(AREA_NAME,'') AS AREA, ISNULL(SALESMANMASTER.SALESMAN_NAME,'') AS SALESMAN ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATEMASTER.STATE_ID LEFT OUTER JOIN AREAMASTER ON LEDGERS.ACC_AREAID = AREAMASTER.AREA_ID LEFT OUTER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMANMASTER.SALESMAN_ID", " AND (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR LEDGERS.ACC_TYPE = 'AGENT') AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            Dim DTITEM As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", " ", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", WHERECLAUSE & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' AND  Item_yearid = " & YearId & " ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDITEMDETAILS.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDITEM.FocusedRowHandle = GRIDITEM.RowCount - 1
                GRIDITEM.TopRowIndex = GRIDITEM.RowCount - 15
            End If

            Dim DTDESIGN As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, DESIGNMASTER.DESIGN_NO AS DESIGNNO ", " ", " DESIGNMASTER ", WHERECLAUSE & " ORDER BY DESIGNMASTER.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If

            Dim DTSHADE As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS SHADE", " ", " COLORMASTER ", WHERECLAUSE & " ORDER BY COLORMASTER.COLOR_NAME")
            GRIDSHADEDETAILS.DataSource = DTSHADE
            If DTSHADE.Rows.Count > 0 Then
                GRIDSHADE.FocusedRowHandle = GRIDSHADE.RowCount - 1
                GRIDSHADE.TopRowIndex = GRIDSHADE.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKITEM_CheckedChanged(sender As Object, e As EventArgs) Handles CHKITEM.CheckedChanged
        Try
            If GRIDITEMDETAILS.Visible = True Then
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    dtrow("CHK") = CHKITEM.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKDESIGN_CheckedChanged(sender As Object, e As EventArgs) Handles CHKDESIGN.CheckedChanged
        Try
            If GRIDDESIGNDETAILS.Visible = True Then
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    dtrow("CHK") = CHKDESIGN.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSHADE_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSHADE.CheckedChanged
        Try
            If GRIDSHADEDETAILS.Visible = True Then
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    dtrow("CHK") = CHKSHADE.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJGRN As New DispatchDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.WHERECLAUSE = " {GDN.GDN_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If ClientName = "KENCOT" Or ClientName = "RMANILAL" And CMBAGENT.Text.Trim <> "" Then OBJGRN.PERIOD = OBJGRN.PERIOD & " (" & CMBAGENT.Text.Trim & ")"

            If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"


            If RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "PARTYWISEDTLS" Else OBJGRN.FRMSTRING = "PARTYWISESUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBITEM.Checked = True Then
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "ITEMWISEDTLS" Else OBJGRN.FRMSTRING = "ITEMWISESUMM"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RDBQUALITY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "QUALITYWISEDTLS" Else OBJGRN.FRMSTRING = "QUALITYWISESUMM"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text.Trim & "'"

            ElseIf RDBDESIGN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "DESIGNWISEDTLS" Else OBJGRN.FRMSTRING = "DESIGNWISESUMM"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"

            ElseIf RDBSHADE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "SHADEWISEDTLS" Else OBJGRN.FRMSTRING = "SHADEWISESUMM"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "'"

            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "GODOWNWISEDTLS" Else OBJGRN.FRMSTRING = "GODOWNWISESUMM"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"

            ElseIf RDBAGENT.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJGRN.FRMSTRING = "AGENTWISEDTLS" Else OBJGRN.FRMSTRING = "AGENTWISESUMM"

            ElseIf RDBPARTYDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"

            ElseIf RDBPARTYWISESUMM.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYSUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"

            ElseIf RDBDESIGNDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "DESIGNDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            ElseIf RDBDESIGNWISESUM.Checked = True Then
                OBJGRN.FRMSTRING = "DESIGNSUMM"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            ElseIf RDBDISPPARTYITEMSHADEDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYITEMSHADEDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RDBDISPPARTYDESIGNDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYDESIGNDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RDBDISPPARTYDESIGNSHADEDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYDESIGNSHADEDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RBPARTYITEMDESIGNSHADE.Checked = True Then
                OBJGRN.FRMSTRING = "PARTYITEMDESIGNSHADEDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RDBITEMSHADEMONTHLY.Checked = True Or RDBITEMSHADEPARTYMONTHLY.Checked = True Or RDBITEMPARTYMONTHLY.Checked = True Or RDBPARTYITEMMONTHLY.Checked = True Then
                If RDBITEMSHADEMONTHLY.Checked = True Then
                    OBJGRN.FRMSTRING = "ITEMSHADEMONTHLY"
                ElseIf RDBITEMPARTYMONTHLY.Checked = True Then
                    If CHKSUMMARY.Checked = True Then OBJGRN.FRMSTRING = "ITEMPARTYSUMM" Else OBJGRN.FRMSTRING = "ITEMPARTYMONTHLY"
                ElseIf RDBPARTYITEMMONTHLY.Checked = True Then
                    OBJGRN.FRMSTRING = "PARTYITEMMONTHLY"
                Else
                    OBJGRN.FRMSTRING = "ITEMSHADEPARTYMONTHLY"
                End If
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {QUALITYMASTER.QUALITY_NAME}='" & CMBQUALITY.Text & "'"
                If CMBGODOWN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text & "'"
                If CMBDESIGN.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {DESIGNMASTER.DESIGN_NO}='" & CMBDESIGN.Text & "'"
                If CMBSHADE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({COLORMASTER.COLOR_NAME}='" & CMBSHADE.Text.Trim & "')"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"
                If CMBITEM.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ITEMMASTER.ITEM_NAME}='" & CMBITEM.Text.Trim & "'"

            ElseIf RDBKPL.Checked = True Then
                OBJGRN.FRMSTRING = "KPLDTLS"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text & "'"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({AGENT.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "')"

            End If

            If CMBDONE.Text <> "" Then
                If CMBDONE.Text = "Pending Challan" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GDN.GDN_DONE}=FALSE"
                If CMBDONE.Text = "Bill Done" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {GDN.GDN_DONE}=TRUE"
            End If


            'FOR PARTYNAME
            Dim NAMECLAUSE As String = ""
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'" Else NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                End If
            Next

            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & NAMECLAUSE
            End If



            'FOR ITEMNAME
            Dim ITEMCLAUSE As String = ""
            GRIDITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then ITEMCLAUSE = " AND ({ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'" Else ITEMCLAUSE = ITEMCLAUSE & " OR {ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                End If
            Next

            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & ITEMCLAUSE
            End If



            'FOR DESIGNNAME
            Dim DESIGNCLAUSE As String = ""
            GRIDDESIGN.ClearColumnsFilter()
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If DESIGNCLAUSE = "" Then DESIGNCLAUSE = " AND ({DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'" Else DESIGNCLAUSE = DESIGNCLAUSE & " OR {DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'"
                End If
            Next

            If DESIGNCLAUSE <> "" Then
                DESIGNCLAUSE = DESIGNCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & DESIGNCLAUSE
            End If


            'FOR SHADENAME
            Dim SHADECLAUSE As String = ""
            GRIDSHADE.ClearColumnsFilter()
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If SHADECLAUSE = "" Then SHADECLAUSE = " AND ({COLORMASTER.COLOR_NAME} = '" & dtrow("SHADE") & "'" Else SHADECLAUSE = SHADECLAUSE & " OR {COLORMASTER.COLOR_NAME} = '" & dtrow("SHADE") & "'"
                End If
            Next

            If SHADECLAUSE <> "" Then
                SHADECLAUSE = SHADECLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & SHADECLAUSE
            End If


            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
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

    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GDNFilter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "SONU" Then RDBKPL.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class