Imports BL

Public Class SOFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If FRMSTRING = "SO" Then
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            End If

        Catch ex As Exception
            Throw ex
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
            If FRMSTRING = "SO" Then
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            End If

            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND ACC_TYPE='AGENT'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
            If CMBDISPATCHEDTO.Text.Trim = "" Then filljobbername(CMBDISPATCHEDTO, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
            If CMBCITYNAME.Text.Trim = "" Then fillCITY(CMBCITYNAME, False)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SOFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "SO" Then
                Me.Text = "Sale Order Filter"
                LBLTRANS.Visible = True
                cmbtrans.Visible = True
                LBLTYPE.Visible = False
                CMBORDERTYPE.Visible = False
            Else
                Me.Text = "Purchase Order Filter"
                LBLTRANS.Visible = False
                cmbtrans.Visible = False
                RBORDERSTOCK.Visible = False
            End If

            fillcmb()
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim NAMECLAUSE As String = ""
            Dim ITEMCLAUSE As String = ""
            Dim DESIGNCLAUSE As String = ""
            Dim COLORCLAUSE As String = ""

            Dim OBJGRN As New SaleInvoiceDesign
            OBJGRN.MdiParent = MDIMain
            If FRMSTRING = "SO" Then
                OBJGRN.WHERECLAUSE = " {ALLSALEORDER.SO_yearid}=" & YearId
            Else
                OBJGRN.WHERECLAUSE = " {ALLPURCHASEORDER.PO_yearid}=" & YearId
            End If

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If FRMSTRING = "SO" Then
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {agent.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"
                If CMBUNIT.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " AND {UNITMASTER.UNIT_ABBR} = '" & CMBUNIT.Text.Trim & "'"
                If CMBCITYNAME.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " AND {CITYMASTER.CITY_NAME} = '" & CMBCITYNAME.Text.Trim & "'"
                If CMBFORWARD.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLSALEORDER.SO_FORWARD}='" & CMBFORWARD.Text.Trim & "'"
                If Val(TXTORDERNO.Text.Trim) <> 0 Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLSALEORDER.SO_NO}=" & Val(TXTORDERNO.Text.Trim)
                If RDBPARTY.Checked = True Then
                    OBJGRN.FRMSTRING = "SOSTATUS"
                ElseIf RDBPARTYDTLS.Checked = True Then
                    OBJGRN.FRMSTRING = "SOSTATUSDTLS"
                ElseIf RDBDATEWISE.Checked = True Then
                    OBJGRN.FRMSTRING = "SOSTATUSDATE"
                ElseIf RBCUTWISE.Checked = True Then
                    OBJGRN.FRMSTRING = "CUTWISEDTLS"

                ElseIf RBORDERSTOCK.Checked = True Then

                    'OPEN ORDERVSSTOCK REPORT
                    Dim OBJORDER As New SaleOrderVsStockGridReport
                    OBJORDER.MdiParent = MDIMain
                    OBJORDER.SOCLAUSE = " AND ALLSALEORDER_DESC.SO_CLOSED = 'FALSE' "

                    'FOR NAME
                    gridbill.ClearColumnsFilter()
                    For i As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            If NAMECLAUSE = "" Then
                                NAMECLAUSE = " AND (LEDGERS.ACC_CMPNAME = '" & dtrow("NAME") & "'"
                            Else
                                NAMECLAUSE = NAMECLAUSE & " OR LEDGERS.ACC_CMPNAME = '" & dtrow("NAME") & "'"
                            End If
                        End If
                    Next
                    If NAMECLAUSE <> "" Then
                        NAMECLAUSE = NAMECLAUSE & ")"
                        OBJORDER.SOCLAUSE = OBJORDER.SOCLAUSE & NAMECLAUSE
                    End If


                    'FOR ITEMNAME
                    GRIDBILLITEM.ClearColumnsFilter()
                    For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                        Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            If ITEMCLAUSE = "" Then
                                ITEMCLAUSE = " AND (ITEMMASTER.ITEM_NAME = '" & dtrow("ITEMNAME") & "'"
                            Else
                                ITEMCLAUSE = ITEMCLAUSE & " OR ITEMMASTER.ITEM_NAME = '" & dtrow("ITEMNAME") & "'"
                            End If
                        End If
                    Next
                    If ITEMCLAUSE <> "" Then
                        ITEMCLAUSE = ITEMCLAUSE & ")"
                        OBJORDER.SOCLAUSE = OBJORDER.SOCLAUSE & ITEMCLAUSE
                    End If

                    'FOR DESIGN
                    gridbilldesign.ClearColumnsFilter()
                    For i As Integer = 0 To gridbilldesign.RowCount - 1
                        Dim dtrow As DataRow = gridbilldesign.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            If DESIGNCLAUSE = "" Then
                                DESIGNCLAUSE = " AND (DESIGNMASTER.DESIGN_NO = '" & dtrow("DESIGNNO") & "'"
                            Else
                                DESIGNCLAUSE = DESIGNCLAUSE & " OR DESIGNMASTER.DESIGN_NO = '" & dtrow("DESIGNNO") & "'"
                            End If
                        End If
                    Next
                    If DESIGNCLAUSE <> "" Then
                        DESIGNCLAUSE = DESIGNCLAUSE & ")"
                        OBJORDER.SOCLAUSE = OBJORDER.SOCLAUSE & DESIGNCLAUSE
                    End If

                    'FOR SHADE
                    gridbillcolor.ClearColumnsFilter()
                    For i As Integer = 0 To gridbillcolor.RowCount - 1
                        Dim dtrow As DataRow = gridbillcolor.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            If COLORCLAUSE = "" Then
                                COLORCLAUSE = " AND (COLORMASTER.COLOR_NAME = '" & dtrow("COLOR") & "'"
                            Else
                                COLORCLAUSE = COLORCLAUSE & " OR COLORMASTER.COLOR_NAME = '" & dtrow("COLOR") & "'"
                            End If
                        End If
                    Next
                    If COLORCLAUSE <> "" Then
                        COLORCLAUSE = COLORCLAUSE & ")"
                        OBJORDER.SOCLAUSE = OBJORDER.SOCLAUSE & COLORCLAUSE
                    End If

                    OBJORDER.Show()
                    Exit Sub

                End If


            Else
                If CMBORDERTYPE.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLPURCHASEORDER.PO_ORDERTYPE}='" & CMBORDERTYPE.Text.Trim & "'"
                If CMBNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
                If CMBAGENT.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {agent.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"
                If CMBUNIT.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " AND {UNITMASTER.UNIT_ABBR} = '" & CMBUNIT.Text.Trim & "'"
                If CMBCITYNAME.Text.Trim <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " AND {CITYMASTER.CITY_NAME} = '" & CMBCITYNAME.Text.Trim & "'"
                If Val(TXTORDERNO.Text.Trim) <> 0 Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLPURCHASEORDER.PO_NO}=" & Val(TXTORDERNO.Text.Trim)
                If RDBPARTY.Checked = True Then
                    OBJGRN.FRMSTRING = "POSTATUS"
                ElseIf RDBPARTYDTLS.Checked = True Then
                    OBJGRN.FRMSTRING = "POSTATUSDTLS"
                ElseIf RDBDATEWISE.Checked = True Then
                    OBJGRN.FRMSTRING = "POSTATUSDATE"
                ElseIf RBCUTWISE.Checked = True Then
                    OBJGRN.FRMSTRING = "POCUTWISEDTLS"
                End If
            End If

            If FRMSTRING = "SO" Then
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLSALEORDER_DESC.SO_Closed}=FALSE "
                    OBJGRN.PENDINGSO = "PENDING"
                End If
                If RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} <= 0 and {ALLSALEORDER_DESC.SO_Closed}=FALSE "
                    OBJGRN.PENDINGSO = "COMPLETED"
                End If
                If RDBCLOSED.Checked = True Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLSALEORDER_DESC.SO_Closed}=true "
            Else
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLPURCHASEORDER_DESC.PO_Closed}=FALSE "
                    OBJGRN.PENDINGSO = "PENDING"
                End If
                If RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} <= 0 and {ALLPURCHASEORDER_DESC.PO_Closed}=FALSE "
                    OBJGRN.PENDINGSO = "COMPLETED"
                End If
                If RDBCLOSED.Checked = True Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLPURCHASEORDER_DESC.PO_Closed}=true "
            End If
            If CMBDISPATCHEDTO.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {PACKINGLEDGERS.ACC_CMPNAME}='" & CMBDISPATCHEDTO.Text.Trim & "'"


            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & NAMECLAUSE
            End If


            'FOR ITEMNAME
            GRIDBILLITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & ITEMCLAUSE
            End If


            'FOR DESIGN
            gridbilldesign.ClearColumnsFilter()
            For i As Integer = 0 To gridbilldesign.RowCount - 1
                Dim dtrow As DataRow = gridbilldesign.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If DESIGNCLAUSE = "" Then
                        DESIGNCLAUSE = " AND ({DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'"
                    Else
                        DESIGNCLAUSE = DESIGNCLAUSE & " OR {DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'"
                    End If
                End If
            Next
            If DESIGNCLAUSE <> "" Then
                DESIGNCLAUSE = DESIGNCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & DESIGNCLAUSE
            End If


            'FOR COLOR
            gridbillcolor.ClearColumnsFilter()
            For i As Integer = 0 To gridbillcolor.RowCount - 1
                Dim dtrow As DataRow = gridbillcolor.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If COLORCLAUSE = "" Then
                        COLORCLAUSE = " AND ({COLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                    Else
                        COLORCLAUSE = COLORCLAUSE & " OR {COLORMASTER.COLOR_NAME} = '" & dtrow("COLOR") & "'"
                    End If
                End If
            Next
            If COLORCLAUSE <> "" Then
                COLORCLAUSE = COLORCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & COLORCLAUSE
            End If

            OBJGRN.POSOFRMSTRING = FRMSTRING
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If FRMSTRING = "SO" Then DT = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.GROUP_NAME AS GROUPNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY, ISNULL(STATEMASTER.STATE_NAME,'') AS STATENAME, ISNULL(AREA_NAME,'') AS AREA, ISNULL(SALESMANMASTER.SALESMAN_NAME,'') AS SALESMAN ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATEMASTER.STATE_ID LEFT OUTER JOIN AREAMASTER ON LEDGERS.ACC_AREAID = AREAMASTER.AREA_ID LEFT OUTER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMANMASTER.SALESMAN_ID ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname") Else DT = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.GROUP_NAME AS GROUPNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY, ISNULL(STATEMASTER.STATE_NAME,'') AS STATENAME, ISNULL(AREA_NAME,'') AS AREA, ISNULL(SALESMANMASTER.SALESMAN_NAME,'') AS SALESMAN ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATEMASTER.STATE_ID LEFT OUTER JOIN AREAMASTER ON LEDGERS.ACC_AREAID = AREAMASTER.AREA_ID LEFT OUTER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMANMASTER.SALESMAN_ID ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            Dim DTITEM As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", " AND ITEMMASTER.ITEM_YEARID = '" & YearId & "' ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDBILLDETAILSITEM.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDBILLITEM.FocusedRowHandle = GRIDBILLITEM.RowCount - 1
                GRIDBILLITEM.TopRowIndex = GRIDBILLITEM.RowCount - 15
            End If

            Dim DTDESIGN As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, DESIGNMASTER.DESIGN_NO AS DESIGNNO ", " ", " DESIGNMASTER ", " AND DESIGNMASTER.DESIGN_YEARID = '" & YearId & "' ORDER BY DESIGNMASTER.DESIGN_NO")
            gridbilldetailsdesign.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                gridbilldesign.FocusedRowHandle = gridbilldesign.RowCount - 1
                gridbilldesign.TopRowIndex = gridbilldesign.RowCount - 15
            End If

            Dim DTCOLOR As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS COLOR ", " ", " COLORMASTER ", " AND COLORMASTER.COLOR_YEARID = '" & YearId & "' ORDER BY COLORMASTER.COLOR_NAME")
            gridbilldetailscolor.DataSource = DTCOLOR
            If DTCOLOR.Rows.Count > 0 Then
                gridbillcolor.FocusedRowHandle = gridbillcolor.RowCount - 1
                gridbillcolor.TopRowIndex = gridbillcolor.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = CHKSELECTALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTITEM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTITEM.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                dtrow("CHK") = CHKSELECTITEM.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTDESIGN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTDESIGN.CheckedChanged
        Try
            For i As Integer = 0 To gridbilldesign.RowCount - 1
                Dim dtrow As DataRow = gridbilldesign.GetDataRow(i)
                dtrow("CHK") = CHKSELECTDESIGN.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTCOLOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTCOLOR.CheckedChanged
        Try
            For i As Integer = 0 To gridbillcolor.RowCount - 1
                Dim dtrow As DataRow = gridbillcolor.GetDataRow(i)
                dtrow("CHK") = CHKSELECTCOLOR.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
            If FRMSTRING = "SO" Then
                If e.KeyCode = Keys.F1 Then
                    Dim OBJLEDGER As New SelectLedger
                    OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                    OBJLEDGER.ShowDialog()
                    If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
                End If
            Else
                If e.KeyCode = Keys.F1 Then
                    Dim OBJLEDGER As New SelectLedger
                    OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                    OBJLEDGER.ShowDialog()
                    If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
                End If
            End If
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDISPATCHEDTO.Enter
        Try
            If CMBDISPATCHEDTO.Text.Trim = "" Then fillname(CMBDISPATCHEDTO, edit, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDISPATCHEDTO.Validating
        Try
            If CMBDISPATCHEDTO.Text.Trim <> "" Then namevalidate(CMBDISPATCHEDTO, CMBCODE, e, Me, txtDeliveryadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class