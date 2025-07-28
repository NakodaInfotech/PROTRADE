
Imports BL
Imports System.ComponentModel

Public Class AccountsMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public EDIT As Boolean
    Public tempAccountsName As String
    Public TEMPGROUPNAME As String
    Public tempAccountsCode As String
    Public tempTYPE As String = "ACCOUNTS"
    Public TEMPSUBTYPE As String = "ACCOUNTS"
    Public tempISAGENT As String = ""
    Public tempISTRANS As String = ""
    Dim tempAccountId As Integer
    Public TEMPGSTIN As String           'Used for edit name

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AccountsMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
        '    Me.Close()
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_cmpname", "", " ACCOUNTSMaster ", " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_cmpname"
                cmbcmpname.DataSource = dt
                cmbcmpname.DisplayMember = "acc_cmpname"
                cmbcmpname.Text = tempAccountsName
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMPCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_CODE", "", " ACCOUNTSMaster ", " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "acc_CODE"
                CMBCODE.Text = tempAccountsCode
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_name"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

        dt = objclscommon.search("RATENAME", "", "RATETYPEMASTER", " and CMPID = " & CmpId)
        If dt.Rows.Count > 0 Then
            CMBPRICELIST.DataSource = dt
            CMBPRICELIST.DisplayMember = "RATENAME"
            CMBPRICELIST.Text = ""
        End If

        If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE='TRANSPORT'")
        If CMBGROUPOFCOMPANIES.Text.Trim = "" Then FILLGROUPCOMPANY(CMBGROUPOFCOMPANIES)
        If CMBPACKINGTYPE.Text.Trim = "" Then FILLPACKINGTYPE(CMBPACKINGTYPE)
        If CMBSALESMAN.Text.Trim = "" Then FILLSALESMAN(CMBSALESMAN)
        If CMBPARTYBANK.Text = "" Then FILLBANK(CMBPARTYBANK)
        If CMBBANKCITY.Text.Trim = "" Then fillCITY(CMBBANKCITY, EDIT)
        If CMBDELIVERYAT.Text.Trim = "" Then fillCITY(CMBDELIVERYAT, EDIT)
        fillname(CMBTDSDEDUCTEDAC, "False", " AND LEDGERS.ACC_TDSAC = 1")

    End Sub

    Private Sub CMBTDS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTDSDEDUCTEDAC.Enter
        Try
            If CMBTDSDEDUCTEDAC.Text.Trim = "" Then fillname(CMBTDSDEDUCTEDAC, "FALSE", " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTDS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTDSDEDUCTEDAC.Validating
        Try
            If CMBTDSDEDUCTEDAC.Text.Trim <> "" Then namevalidate(CMBTDSDEDUCTEDAC, CMBTDSDEDUCTEDAC, e, Me, txtadd, " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccountsMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            clear()
            FILLCMPNAME()
            FILLCMPCODE()
            cmbgroup.Text = TEMPGROUPNAME
            CMBTYPE.Text = tempTYPE
            cmbdrcrrs.SelectedIndex = 0
            If ClientName = "YASHVI" Then CMBSEZTYPE.Text = "NON SEZ"

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Me.Text = "Accounts Master"
            Dim OBJACC As New ClsAccountsMaster
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(tempAccountsName)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJACC.alParaval = ALPARAVAL
            If EDIT = True Then dttable = OBJACC.GETACCOUNTS

            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    tempAccountId = Val(dttable.Rows(0).Item("ACCID"))
                    cmbcmpname.Text = dttable.Rows(0).Item("CMPNAME").ToString

                    If Convert.ToBoolean(dttable.Rows(0).Item("ISLOCKED")) = True Then cmbcmpname.Enabled = False

                    txtname.Text = dttable.Rows(0).Item("NAME").ToString
                    cmbgroup.Text = dttable.Rows(0).Item("GROUPNAME").ToString

                    'FILLING REGISTER
                    If cmbgroup.Text.Trim <> "" Then
                        'CHECK GROUP_SECONDARY
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            TXTPROFITPER.ReadOnly = True

                            If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                                fillregister(cmbregister, " and register_type = 'PURCHASE'")
                            ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                                fillregister(cmbregister, " and register_type = 'SALE'")
                            ElseIf DT.Rows(0).Item(0) = "Capital A/C" Then
                                TXTPROFITPER.ReadOnly = False
                            End If
                        End If
                    End If


                    txtopbal.Text = Val(dttable.Rows(0).Item("OPBAL").ToString)
                    cmbdrcrrs.Text = dttable.Rows(0).Item("DRCR").ToString
                    TXTINTPER.Text = Val(dttable.Rows(0).Item("INTPER").ToString)

                    txtadd1.Text = dttable.Rows(0).Item("ADD1").ToString
                    txtadd2.Text = dttable.Rows(0).Item("ADD2").ToString
                    cmbarea.Text = dttable.Rows(0).Item("AREA").ToString
                    cmbcity.Text = dttable.Rows(0).Item("CITY").ToString
                    cmbstate.Text = dttable.Rows(0).Item("STATE").ToString
                    txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString
                    cmbcountry.Text = dttable.Rows(0).Item("COUNTRY").ToString
                    txtstd.Text = dttable.Rows(0).Item("STD").ToString
                    txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
                    txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString
                    txttel1.Text = dttable.Rows(0).Item("PHONE").ToString
                    txtmobile.Text = dttable.Rows(0).Item("MOBILE").ToString
                    TXTWHATSAPPNO.Text = dttable.Rows(0).Item("WHATSAPPNO").ToString
                    txtfax.Text = dttable.Rows(0).Item("FAX").ToString
                    txtwebsite.Text = dttable.Rows(0).Item("WEBSITE").ToString
                    cmbemail.Text = dttable.Rows(0).Item("EMAIL").ToString
                    CMBTRANS.Text = dttable.Rows(0).Item("TRANS").ToString
                    CMBAGENT.Text = dttable.Rows(0).Item("AGENT").ToString
                    TXTAGENTCOMM.Text = dttable.Rows(0).Item("AGENTCOMM").ToString
                    TXTDISC.Text = dttable.Rows(0).Item("DISC").ToString
                    TXTCDPER.Text = dttable.Rows(0).Item("CDPER").ToString

                    TXTKMS.Text = dttable.Rows(0).Item("KMS").ToString
                    txtcrdays.Text = Val(dttable.Rows(0).Item("CRDAYS").ToString)
                    txtcrlimit.Text = Val(dttable.Rows(0).Item("CRLIMIT").ToString)
                    txtpanno.Text = dttable.Rows(0).Item("PANNO").ToString
                    txtexciseno.Text = dttable.Rows(0).Item("EXCISENO").ToString
                    txtrange.Text = dttable.Rows(0).Item("RANGE").ToString
                    CMBADDLESS.Text = dttable.Rows(0).Item("ADDLESS").ToString
                    txtcstno.Text = dttable.Rows(0).Item("CSTNO").ToString
                    txttinno.Text = dttable.Rows(0).Item("TINNO").ToString
                    txtstno.Text = dttable.Rows(0).Item("STNO").ToString
                    txtvatno.Text = dttable.Rows(0).Item("VATNO").ToString

                    TXTGSTIN.Text = dttable.Rows(0).Item("GSTIN").ToString
                    TEMPGSTIN = dttable.Rows(0).Item("GSTIN").ToString

                    cmbregister.Text = dttable.Rows(0).Item("REGISTERNAME").ToString
                    txtadd.Text = dttable.Rows(0).Item("ADD").ToString
                    txtshipadd.Text = dttable.Rows(0).Item("SHIPPINGADD").ToString
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString
                    CMBDELIVERYAT.Text = dttable.Rows(0).Item("DELIVERYAT").ToString

                    CMBPARTYBANK.Text = dttable.Rows(0).Item("PARTYBANKNAME").ToString
                    TXTACCTYPE.Text = dttable.Rows(0).Item("ACCTYPE").ToString
                    TXTACCNO.Text = dttable.Rows(0).Item("ACCNO").ToString
                    TXTIFSC.Text = dttable.Rows(0).Item("IFSCCODE").ToString
                    TXTBRANCH.Text = dttable.Rows(0).Item("BRANCH").ToString
                    CMBBANKCITY.Text = dttable.Rows(0).Item("BANKCITY").ToString

                    CMBGROUPOFCOMPANIES.Text = dttable.Rows(0).Item("GOC").ToString
                    CMBCODE.Text = dttable.Rows(0).Item("CODE").ToString
                    tempAccountsCode = dttable.Rows(0).Item("CODE").ToString


                    'IF PRICELISTCOLUMN IS NOT BLANK THEN FETCH RATENAME FRMO RATETYPEMASTER 
                    'THIS CODE IS DONE BY GULKIT DO NOT CHANGE
                    If dttable.Rows(0).Item("PRICELISTCOLUMN") <> "" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DTRATE As DataTable = OBJCMN.Execute_Any_String("SELECT RATENAME FROM RATETYPEMASTER WHERE COLNAME = '" & dttable.Rows(0).Item("PRICELISTCOLUMN") & "' AND CMPID = " & CmpId, "", "")
                        If DTRATE.Rows.Count > 0 Then CMBPRICELIST.Text = DTRATE.Rows(0).Item("RATENAME")
                    End If
                    CMBPACKINGTYPE.Text = dttable.Rows(0).Item("PACKINGTYPE")
                    CMBTERM.Text = dttable.Rows(0).Item("TERM")
                    CMBSALESMAN.Text = dttable.Rows(0).Item("SALESMAN")
                    TXTPROFITPER.Text = Val(dttable.Rows(0).Item("PROFITPER"))
                    CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                    CHKRCM.Checked = Convert.ToBoolean(dttable.Rows(0).Item("RCM"))
                    CHKOVERSEAS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("OVERSEAS"))
                    CHKHOLD.Checked = Convert.ToBoolean(dttable.Rows(0).Item("HOLDFORAPPROVAL"))
                    CHKPOMANDATE.Checked = Convert.ToBoolean(dttable.Rows(0).Item("POMANDATE"))
                    CHKTCS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TCS"))
                    TXTDELIVERYPINCODE.Text = dttable.Rows(0).Item("DELIVERYPINCODE").ToString
                    TXTUPI.Text = dttable.Rows(0).Item("UPI").ToString
                    TXTMSMENO.Text = dttable.Rows(0).Item("MSMENO").ToString


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    CHKTDSAPP.CheckState = CheckState.Checked
                    CMBDEDUCTEETYPE.Text = dttable.Rows(0).Item("DEDUCTEETYPE")
                    CMBTDSFORM.Text = dttable.Rows(0).Item("TDSFORM")
                    CMBTDSCOMPANY.Text = dttable.Rows(0).Item("TDSCOMPANY")
                    If dttable.Rows(0).Item("ISLOWER") = True Then
                        CMBISLOWER.Text = "Yes"
                    Else
                        CMBISLOWER.Text = "No"
                    End If
                    CMBSECTION.Text = dttable.Rows(0).Item("SECTION")

                    TXTTDSRATE.Text = Format(Val(dttable.Rows(0).Item("TDSRATE")), "0.00")
                    TXTTDSPER.Text = Format(Val(dttable.Rows(0).Item("TDSPER")), "0.00")
                    If CMBSECTION.Text.Trim = "197" Then
                        TXTTDSRATE.Enabled = True
                    Else
                        TXTTDSRATE.Enabled = False
                    End If

                    If dttable.Rows(0).Item("SURCHARGE") = True Then
                        CMBSURCHARGE.Text = "Yes"
                    Else
                        CMBSURCHARGE.Text = "No"
                    End If
                    TXTLIMIT.Text = dttable.Rows(0).Item("LIMIT")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    CHKTDS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSAC"))
                    CMBSEZTYPE.Text = dttable.Rows(0).Item("SEZTYPE")
                    CMBNATURE.Text = dttable.Rows(0).Item("NATURE")

                    CMBTYPE.Text = dttable.Rows(0).Item("TYPE")
                    CMBCALC.Text = dttable.Rows(0).Item("CALC")
                    CMBTDSDEDUCTEDAC.Text = dttable.Rows(0).Item("TDSDEDUCTEDAC").ToString
                    CHKTDSONGTOTAL.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSONGTOTAL"))

                    TXTHINDINAME.Text = dttable.Rows(0).Item("HINDINAME")
                    CMBSUBTYPE.Text = dttable.Rows(0).Item("SUBTYPE")

                    TXTEFFECTIVEPER.Text = dttable.Rows(0).Item("EFFECTIVEPER").ToString
                    TXTWHOLESALEDISC.Text = dttable.Rows(0).Item("WHOLESALEDISC").ToString
                    TXTRETAILDISC.Text = dttable.Rows(0).Item("RETAILDISC").ToString

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        fillregister(cmbregister, " and register_type = 'PURCHASE'")
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        fillregister(cmbregister, " and register_type = 'SALE'")
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        DT = OBJCMN.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        DT = OBJCMN.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    End If
                    If DT.Rows.Count = 0 Then
                        MsgBox("Register Not Present, Add New from Master Module")
                        cmbregister.Text = ""
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub add()
        txtadd.Clear()
        If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
        If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

        If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

        txtadd.Text = txtadd.Text & "" & cmbcity.Text.Trim

        If txtzipcode.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & vbNewLine
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbstate.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbcountry.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'CODE DONE BY GULKIT DONT TOUCH STRICTLY
            'IF COMMON FOR ALL IS SELECTED THEN WE NEED TO LOOP FOR ALL COMPANYIES WITH SAME ACCOUNTING YEAR
            'BEFORE THIS SAVE WE NEED TO CHECK WHETHER SAME GROUPNAME AND STATE IS PRESENT IN THAT YEAR OR NOT
            'IF NOT PRESENT THEN DONT SAVE
            If CHKCOMMON.CheckState = CheckState.Unchecked Then
                If EDIT = False Then SAVEUPDATE(CmpId, YearId, 0) Else SAVEUPDATE(CmpId, YearId, tempAccountId)
            Else
                Dim OBJCMN As New ClsCommon
                Dim DTCMP As DataTable = OBJCMN.search("YEAR_CMPID AS CMPID, YEAR_ID AS YEARID ", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(Convert.ToDateTime(AccFrom.Date), "MM/dd/yyyy") & "' ORDER BY YEAR_ID")
                For Each DTROW As DataRow In DTCMP.Rows
                    'BEFORE SAVING WE WILL CHECK WHETHER CMPNAME OR GROUPNAME AND STATE IS PRESENT IN THAY UYEAR OR NOT
                    'IF NOT THEN GOTONEXTLINE
                    'IF CMPNAME IS ALREADY PRESENT THEN SKIP
                    Dim DTTEMP As DataTable

                    DTTEMP = OBJCMN.search("GROUP_ID AS GROUPID", "", "GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then GoTo NEXTLINE

                    'CHECK STATE
                    DTTEMP = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", " AND STATE_NAME = '" & cmbstate.Text.Trim & "' AND STATE_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then GoTo NEXTLINE

                    If EDIT = False Then
                        If YearId <> DTROW("YEARID") Then
                            DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                            If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE
                        End If
                        SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), 0)
                    Else

                        DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_ID <> " & tempAccountId & " AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE

                        'FIRST GET THE ACCOUNTID FROM YEARID AND THEN PASS IT IN THE UPDATE QUERY
                        DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & tempAccountsName & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), Val(DTTEMP.Rows(0).Item("ACCID")))
                    End If
NEXTLINE:
                Next
            End If

            If EDIT = False Then MsgBox("Details Added") Else MsgBox("Details Updated")
            clear()
            tempAccountsName = ""
            EDIT = False
            cmbcmpname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub SAVEUPDATE(ByVal TCMPID As Integer, ByVal TYEARID As Integer, ByVal TACCID As Integer)
        Try
            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(UCase(cmbcmpname.Text.Trim))
            alParaval.Add(UCase(txtname.Text.Trim))
            alParaval.Add(cmbgroup.Text.Trim)
            'DONT SAVE OR UPDATE OPBAL FOR ALL COMPANY
            If TYEARID = YearId Then
                alParaval.Add(Val(txtopbal.Text.Trim))
                alParaval.Add(cmbdrcrrs.Text.Trim)
            Else
                'GET OPBAL OF THAT YEAR AND PASS THAT VALUE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_OPBAL,0) AS OPBAL, ACC_DRCR AS DRCR ", "", "LEDGERS", "AND ACC_ID = " & TACCID)
                If DT.Rows.Count > 0 Then
                    alParaval.Add(Val(DT.Rows(0).Item("OPBAL")))
                    alParaval.Add(DT.Rows(0).Item("DRCR"))
                Else
                    alParaval.Add(0)
                    alParaval.Add("")
                End If
            End If
            alParaval.Add(Val(TXTINTPER.Text.Trim))
            alParaval.Add(Val(TXTPROFITPER.Text.Trim))
            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtcrdays.Text.Trim)
            alParaval.Add(txtcrlimit.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(TXTWHATSAPPNO.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(Val(TXTAGENTCOMM.Text.Trim))
            alParaval.Add(Val(TXTDISC.Text.Trim))
            alParaval.Add(Val(TXTCDPER.Text.Trim))
            alParaval.Add(Val(TXTKMS.Text.Trim))
            alParaval.Add(txtpanno.Text.Trim)
            alParaval.Add(txtexciseno.Text.Trim)
            alParaval.Add(txtrange.Text.Trim)
            alParaval.Add(CMBADDLESS.Text.Trim)
            alParaval.Add(txtcstno.Text.Trim)
            alParaval.Add(txttinno.Text.Trim)
            alParaval.Add(txtstno.Text.Trim)
            alParaval.Add(txtvatno.Text.Trim)
            alParaval.Add(TXTGSTIN.Text.Trim)
            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtshipadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBPARTYBANK.Text.Trim)
            alParaval.Add(TXTACCTYPE.Text.Trim)
            alParaval.Add(TXTACCNO.Text.Trim)
            alParaval.Add(TXTIFSC.Text.Trim)
            alParaval.Add(TXTBRANCH.Text.Trim)
            alParaval.Add(CMBBANKCITY.Text.Trim)
            alParaval.Add(CMBGROUPOFCOMPANIES.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(CHKRCM.CheckState)
            alParaval.Add(CHKOVERSEAS.CheckState)
            alParaval.Add(CHKHOLD.CheckState)
            alParaval.Add(TCMPID)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(TYEARID)
            alParaval.Add(0)
            alParaval.Add(UCase(CMBCODE.Text.Trim))


            'IF CMBPRICELIST IS NOT BLANK THEN FETCH COLUMN NAME FRMO RATETYPEMASTER 
            'THIS CODE IS DONE BY GULKIT DO NOT CHANGE
            If CMBPRICELIST.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DTRATE As DataTable = OBJCMN.Execute_Any_String("SELECT COLNAME FROM RATETYPEMASTER WHERE RATENAME = '" & CMBPRICELIST.Text.Trim & "' AND CMPID = " & CmpId, "", "")
                alParaval.Add(DTRATE.Rows(0).Item("COLNAME"))
            Else
                alParaval.Add("")   'PRICELISTNAME
            End If
            alParaval.Add(CMBPACKINGTYPE.Text.Trim)
            alParaval.Add(CMBTERM.Text.Trim)
            alParaval.Add(CMBSALESMAN.Text.Trim)
            alParaval.Add(CMBDELIVERYAT.Text.Trim)


            'TDS
            '*******************************
            alParaval.Add(CHKTDSAPP.CheckState)
            alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)
            alParaval.Add(CMBTDSFORM.Text.Trim)
            alParaval.Add(CMBTDSCOMPANY.Text.Trim)

            If CMBISLOWER.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSECTION.Text.Trim)
            alParaval.Add(Val(TXTTDSRATE.Text.Trim))
            alParaval.Add(Val(TXTTDSPER.Text.Trim))

            If CMBSURCHARGE.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Val(TXTLIMIT.Text.Trim))
            '*******************************



            alParaval.Add(CHKTDS.CheckState)
            alParaval.Add(CMBSEZTYPE.Text.Trim)
            alParaval.Add(CMBNATURE.Text.Trim)
            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(CMBCALC.Text.Trim)
            alParaval.Add(CHKPOMANDATE.CheckState)
            alParaval.Add(TXTDELIVERYPINCODE.Text.Trim)
            alParaval.Add(TXTUPI.Text.Trim)
            alParaval.Add(TXTMSMENO.Text.Trim)
            alParaval.Add(CHKTCS.CheckState)
            alParaval.Add(CMBTDSDEDUCTEDAC.Text.Trim)
            alParaval.Add(CHKTDSONGTOTAL.Checked)
            alParaval.Add(TXTHINDINAME.Text.Trim)
            alParaval.Add(CMBSUBTYPE.Text.Trim)


            alParaval.Add(Val(TXTEFFECTIVEPER.Text.Trim))
            alParaval.Add(Val(TXTWHOLESALEDISC.Text.Trim))
            alParaval.Add(Val(TXTRETAILDISC.Text.Trim))

            Dim objAccountsMaster As New ClsAccountsMaster
            objAccountsMaster.alParaval = alParaval
            objAccountsMaster.frmstring = frmstring

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAccountsMaster.SAVE()
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TACCID)
                IntResult = objAccountsMaster.UPDATE()
                'MsgBox("Details Updated")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        'TDS
        CHKTDS.CheckState = CheckState.Unchecked
        CHKTDSONGTOTAL.CheckState = CheckState.Unchecked
        CMBNATURE.Text = ""
        CHKBLOCKED.CheckState = CheckState.Unchecked
        CHKRCM.CheckState = CheckState.Unchecked
        CHKOVERSEAS.CheckState = CheckState.Unchecked
        CHKHOLD.CheckState = CheckState.Unchecked
        CHKTDSAPP.CheckState = CheckState.Unchecked
        CHKPOMANDATE.CheckState = CheckState.Unchecked
        CHKTCS.CheckState = CheckState.Unchecked
        GROUPTDS.Enabled = False
        CMBDEDUCTEETYPE.Text = ""
        CMBISLOWER.SelectedIndex = 0
        CMBSECTION.SelectedIndex = 0
        TXTTDSRATE.Clear()
        TXTTDSPER.Clear()
        CMBTDSDEDUCTEDAC.Text = ""
        CMBSURCHARGE.SelectedIndex = 0
        TXTTDSRATE.Enabled = False

        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtaltno.Clear()
        cmbcmpname.Text = ""
        cmbcmpname.Enabled = True
        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtcstno.Clear()

        cmbemail.Text = ""
        CMBTRANS.Text = ""
        CMBAGENT.Text = ""
        TXTAGENTCOMM.Clear()

        txtexciseno.Clear()
        txtfax.Clear()
        TXTGSTIN.Clear()
        txtmobile.Clear()
        TXTWHATSAPPNO.Clear()
        txtname.Clear()
        txtopbal.Clear()
        txtpanno.Clear()
        txtrange.Clear()
        txtremarks.Clear()
        txtresino.Clear()
        txtshipadd.Clear()
        txtstd.Clear()
        txtstno.Clear()
        txttel1.Clear()
        txttinno.Clear()
        txtvatno.Clear()
        txtwebsite.Clear()
        txtzipcode.Clear()
        cmbarea.Text = ""
        cmbcity.Text = ""
        cmbcountry.Text = ""
        cmbdrcrrs.Text = ""
        cmbgroup.Text = ""
        cmbstate.Text = ""
        CMBCODE.Text = ""
        CMBPRICELIST.Text = ""
        CMBPACKINGTYPE.Text = ""
        'tempAccountsName = ""
        cmbcmpname.Text = ""
        TXTDISC.Clear()
        TXTCDPER.Clear()
        TXTKMS.Clear()
        CMBTERM.Text = ""
        CMBSALESMAN.Text = ""
        TXTPROFITPER.Clear()
        TXTPROFITPER.ReadOnly = True
        TXTACCTYPE.Clear()
        CMBPARTYBANK.Text = ""
        TXTACCNO.Clear()
        TXTIFSC.Clear()
        TXTBRANCH.Clear()
        CMBBANKCITY.Text = ""
        CMBGROUPOFCOMPANIES.Text = ""
        CMBDELIVERYAT.Text = ""
        TXTDELIVERYPINCODE.Clear()
        TXTUPI.Clear()
        TXTMSMENO.Clear()
        TXTHINDINAME.Clear()
        CMBSUBTYPE.Text = ""

        TXTEFFECTIVEPER.Clear()
        TXTWHOLESALEDISC.Clear()
        TXTRETAILDISC.Clear()

        'EDIT = False

        'cmbregister.DataSource = Nothing

        If frmstring = "CUSTOMER" Then
            Me.Text = "Customer Master"
            cmbgroup.Text = "Sundry Debtors"
        ElseIf frmstring = "VENDOR" Then
            Me.Text = "Supplier Master"
            cmbgroup.Text = "Sundry Creditors"
        ElseIf frmstring = "ACCOUNTS" Then
            Me.Text = "Accounts Master"
        ElseIf frmstring = "EMPLOYEE" Then
            Me.Text = "Employee Master"
        End If
    End Sub

    Private Sub CMBTERM_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTERM.Enter
        Try
            If CMBTERM.Text.Trim = "" Then fillTERM(CMBTERM, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTERM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTERM.Validating
        Try
            If CMBTERM.Text.Trim <> "" Then TERMVALIDATE(CMBTERM, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbcmpname)
            'CMBCODE.Text = cmbcmpname.Text.Trim
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then
                dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
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
        If cmbcmpname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcmpname, "Fill Company Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbcmpname, "Name Already Exists")
            bln = False
        End If


        If CMBTYPE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBTYPE, "Select Type")
            bln = False
        End If

        If CHKTDS.CheckState = CheckState.Unchecked Then CMBNATURE.Text = ""

        If CHKTDS.CheckState = CheckState.Checked And CMBNATURE.Text.Trim = "" Then
            Ep.SetError(CMBNATURE, "Select Nature Of Payment")
            bln = False
        End If


        If cmbstate.Text.Trim.Length = 0 And CHKOVERSEAS.CheckState = CheckState.Unchecked Then
            Ep.SetError(cmbstate, "Select State")
            bln = False
        End If


        'IF GROUPNAME = CREDITORS OR DEBTORS THEN ONLY
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("GROUP_SECONDARY AS GROUPNAME", "", " GROUPMASTER", " AND GROUP_NAME ='" & cmbgroup.Text.Trim & "' AND GROUP_CMPID =  " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            If (DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors") And CMBTYPE.Text.Trim = "ACCOUNTS" Then
                If txtzipcode.Text.Trim.Length = 0 Then
                    Ep.SetError(txtzipcode, "Fill Pin-Code")
                    bln = False
                End If


                If ClientName = "AVIS" Then
                    If TXTGSTIN.Text.Trim.Length = 0 Then
                        If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Ep.SetError(TXTGSTIN, "Enter GSTIN....")
                            bln = False
                        End If
                    End If

                    If txtadd1.Text.Trim.Length = 0 Or txtadd2.Text.Trim.Length = 0 Then
                        Ep.SetError(txtadd1, "Enter Address....")
                        bln = False
                    End If

                    If cmbcity.Text.Trim.Length = 0 Then
                        Ep.SetError(cmbcity, "Enter City....")
                        bln = False
                    End If

                    If cmbemail.Text.Trim.Length = 0 Then
                        Ep.SetError(cmbemail, "Enter Emailid....")
                        bln = False
                    End If

                    If Val(txtcrdays.Text.Trim) = 0 Then
                        Ep.SetError(txtcrdays, "Enter Cr Days....")
                        bln = False
                    End If

                    If CMBAGENT.Text.Trim.Length = 0 Then
                        Ep.SetError(CMBAGENT, "Enter Agent....")
                        bln = False
                    End If

                    If DT.Rows(0).Item(0) = "Sundry Debtors" And CMBTRANS.Text.Trim = "" Then
                        Ep.SetError(CMBTRANS, "Enter Transport....")
                        bln = False
                    End If

                    If DT.Rows(0).Item(0) = "Sundry Debtors" And txtmobile.Text.Trim = "" Then
                        Ep.SetError(txtmobile, "Enter Mobile No....")
                        bln = False
                    End If

                    'If CMBAGENT.Text.Trim <> "SELF" And Val(TXTAGENTCOMM.Text.Trim) = 0 Then
                    '    Ep.SetError(TXTAGENTCOMM, "Enter Agent Commission....")
                    '    bln = False
                    'End If

                    If DT.Rows(0).Item(0) = "Sundry Debtors" And CMBSALESMAN.Text.Trim.Length = 0 Then
                        Ep.SetError(CMBSALESMAN, "Enter Sales Person....")
                        bln = False
                    End If

                End If


                If ClientName = "ALENCOT" Then
                    '        If TXTGSTIN.Text.Trim.Length = 0 Then
                    '            Ep.SetError(TXTGSTIN, "Fill GSTIN....")
                    '            bln = False
                    '        End If
                    If TXTGSTIN.Text.Trim.Length = 0 Then
                        If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Ep.SetError(TXTGSTIN, "Enter GSTIN....")
                            bln = False
                        End If
                    End If
                    If DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        If txtmobile.Text.Trim.Length = 0 And txttel1.Text.Trim.Length = 0 Then
                            Ep.SetError(txtmobile, "Fill Contact no...")
                            bln = False
                        End If
                    End If
                    If CMBTYPE.Text = "ACCOUNTS" Then
                        If CMBAGENT.Text.Trim.Length = 0 Then
                            Ep.SetError(CMBAGENT, "Select Agent....")
                            bln = False
                        End If
                    End If
                End If

                If ClientName = "DETLINE" And CMBTYPE.Text = "ACCOUNTS" Then
                    If CMBAGENT.Text.Trim.Length = 0 Then
                        Ep.SetError(CMBAGENT, "Select Agent....")
                        bln = False
                    End If
                End If

                If ClientName = "KOTHARI" Then
                    If txtexciseno.Text.Trim.Length = 0 Then
                        Ep.SetError(txtexciseno, "Fill Excise No....")
                    ElseIf txtrange.Text.Trim.Length = 0 Then
                        Ep.SetError(txtrange, "Fill Range....")
                        bln = False
                    End If
                End If

                If ClientName = "YASHVI" And DT.Rows(0).Item(0) = "Sundry Debtors" And CMBPACKINGTYPE.Text.Trim = "" Then
                    Ep.SetError(CMBPACKINGTYPE, "Fill Packing Type")
                    bln = False
                End If

                If ClientName = "YASHVI" Or ClientName = "KOTHARI" Then
                    If Val(txtcrdays.Text.Trim) = 0 Then
                        Ep.SetError(txtcrdays, "Fill Credit Days")
                        bln = False
                    End If
                End If
            End If

            If DT.Rows(0).Item(0) = "Sundry Debtors" And ClientName <> "AVIS" Then
                If Val(TXTKMS.Text.Trim) = 0 Then
                    Ep.SetError(TXTKMS, "Enter Kilometers")
                    bln = False
                End If
            End If


            If ClientName = "PARAS" Then
                If DT.Rows(0).Item(0) = "Sundry Debtors" And txtmobile.Text.Trim = "" Then
                    Ep.SetError(txtmobile, "Enter Mobile No....")
                    bln = False
                End If
            End If

        End If




        'do not VALIDATE GSTIN JUST GIVE INTIMATION WISH TO PROCEED
        'DONE BY GULKIT
        If TXTGSTIN.Text.Trim <> "" Then
            If (EDIT = False) Or (EDIT = True And TEMPGSTIN <> TXTGSTIN.Text.Trim) Then
                DT = OBJCMN.search("ACC_GSTIN AS GSTIN", "", "LEDGERS", " and LEDGERS.acc_GSTIN = '" & TXTGSTIN.Text.Trim & "' and ACC_yearid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If MsgBox("Ledger With same GSTIN is already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Ep.SetError(TXTGSTIN, "GSTIN Already Exists")
                        bln = False
                    End If
                End If
            End If
        End If

        If CMBCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCODE, "Fill Company Code")
            bln = False
        End If

        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group")
            bln = False
        End If

        If CMBTRANS.Text.Trim = cmbcmpname.Text.Trim Then
            Ep.SetError(CMBTRANS, "Transport Name cannot be same as Company Name")
            bln = False
        End If

        If CMBAGENT.Text.Trim = cmbcmpname.Text.Trim Then
            Ep.SetError(CMBAGENT, "Agent Name cannot be same as Company Name")
            bln = False
        End If


        If txtpanno.Text.Trim <> "" Then

            'If CMBDEDUCTEETYPE.Text.Trim = "" Then
            '    Ep.SetError(txtpanno, "Select Company Type")
            '    bln = False
            'End If

            If txtpanno.Text.Trim.Length <> 10 Then
                Ep.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            Else
                'validating PAN NO
                For x = 1 To Len(txtpanno.Text.Trim)
                    If x <= 5 Or x = 10 Then
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    Else
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    End If
                    'CHECKING 4TH ALPHABET WITH DEDUCTEETYPE
                    'If x = 4 Then
                    '    If CMBDEDUCTEETYPE.Text.Trim = "Individual" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "P" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text.Trim = "Firm" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "F" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Company" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "C" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "HUF" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "H" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Association of Persons" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "A" And txtpanno.Text.Substring(x - 1, 1) <> "T" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Local Authority" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "L" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Artificial Juridical Person" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "J" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Government" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "G" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    End If
                    'End If
                Next x
            End If
        End If


        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If cmbstate.Text.Trim <> "" And TXTGSTIN.Text.Trim <> "" AndAlso TXTGSTIN.Text.Substring(0, 2) <> "88" Then
            'Dim OBJCMN As New ClsCommon
            DT = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & cmbstate.Text.Trim & "'  and STATE_YEARID = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTIN.Text.Substring(0, 2) Then
                Ep.SetError(TXTGSTIN, "State Code does not match with GST No")
                bln = False
            End If
        End If


        If TXTGSTIN.Text.Trim.Length > 0 Then
            'If txtpanno.Text.Trim = "" Then
            '    Ep.SetError(txtpanno, "Enter Pan No")
            '    bln = False
            'End If

            'If txtpanno.Text.Trim.Length <> 10 Then
            '    Ep.SetError(txtpanno, "Insert Proper PAN No")
            '    bln = False
            'End If

            'CHECKING 2ND TO 11TH ALPHABETS WITH PANNO
            'If TXTGSTIN.Text.Trim.Length = 15 Then
            '    If txtpanno.Text.Trim <> TXTGSTIN.Text.Substring(2, 10) Then
            '        Ep.SetError(txtpanno, "Enter Proper PAN Details")
            '        bln = False
            '    End If
            'End If

            If TXTGSTIN.Text.Trim.Length <> 15 Then
                Ep.SetError(TXTGSTIN, "Enter Proper GST No")
                bln = False
            End If
        End If


        'If UserName <> "Admin" Then
        '    Dim bln_4_case As Boolean = True
        '    Select Case tempAccountsName
        '        Case "Transport Charges"
        '            ' Str = "Turquoise"
        '            bln_4_case = False
        '        Case "Other Charges"
        '            bln_4_case = False
        '        Case "S.T. 1.03%"
        '            bln_4_case = False
        '        Case "PURCHASE"
        '            bln_4_case = False
        '        Case "SALE"
        '            bln_4_case = False
        '        Case "T.D.S."
        '            bln_4_case = False
        '        Case "Cash In Hand"
        '            bln_4_case = False
        '        Case "Petty Cash"
        '            bln_4_case = False
        '        Case "Round Off"
        '            bln_4_case = False
        '        Case "Discount Recd"
        '            bln_4_case = False
        '        Case "Commission Recd"
        '            bln_4_case = False
        '        Case "Discount Given"
        '            bln_4_case = False
        '        Case "Commission A/C"
        '            bln_4_case = False
        '        Case "Agent Commission"
        '            bln_4_case = False
        '        Case "Profit & Loss A/C"
        '            bln_4_case = False
        '        Case "Opening A/C"
        '            bln_4_case = False

        '    End Select

        '    If bln_4_case = False Then
        '        Ep.SetError(cmbcmpname, "Build In Ledger Cannot edit")
        '        bln = False
        '    End If
        'End If
        Return bln
    End Function

    Private Sub cmbgroup_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.Enter
        Try
            If cmbgroup.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    cmbgroup.DataSource = dt
                    cmbgroup.DisplayMember = "group_name"
                    cmbgroup.Text = ""
                End If
                cmbgroup.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.Enter
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.Enter
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(cmbcountry.Text)
                                cmbcountry.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo Line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.Enter
        Try
            If cmbarea.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    cmbarea.DataSource = dt
                    cmbarea.DisplayMember = "area_name"
                    cmbarea.Text = ""
                End If
                cmbarea.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then
                pcase(cmbarea)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbarea.Text.Trim
                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbarea.Text = a
                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbarea.DataSource
                        If cmbarea.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbarea.Text)
                                cmbarea.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.Validated
        Try
            If cmbgroup.Text.Trim <> "" Then
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbregister.Text = ""
                    TXTPROFITPER.ReadOnly = True
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        fillregister(cmbregister, " and register_type = 'PURCHASE'")
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        fillregister(cmbregister, " and register_type = 'SALE'")
                    ElseIf DT.Rows(0).Item(0) = "Capital A/C" Then
                        TXTPROFITPER.ReadOnly = False
                    Else
                        cmbregister.DataSource = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then
                pcase(cmbgroup)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbgroup.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "PROTRADE")
                    If tempmsg = vbYes Then
                        cmbgroup.Text = a
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = cmbgroup.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbgroup.DataSource
                            If cmbgroup.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(cmbgroup.Text)
                                cmbgroup.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        pcase(txtname)
    End Sub

    Private Sub txtadd1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd1.Validating
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd2.Validating
        pcase(txtadd2)
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress, TXTKMS.KeyPress, TXTWHATSAPPNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdotkeypress(e, txtcrlimit, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numdotkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numdotkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub cmbcmpname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcmpname.Enter
        Try
            If cmbcmpname.Text.Trim = "" Then
                FILLCMPNAME()
                cmbcmpname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcmpname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcmpname.Validating
        Try
            If cmbcmpname.Text.Trim <> "" Then
                pcase(cmbcmpname)
                If CMBCODE.Text.Trim = "" Then CMBCODE.Text = cmbcmpname.Text.Trim
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then
                    dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot Delete")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If MsgBox("Wish To Delete the Ledger?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Ep.Clear()
                If Not DELETEERRORVALID() Then
                    Exit Sub
                End If

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempAccountsName)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJACC As New ClsAccountsMaster
                OBJACC.alParaval = ALPARAVAL
                OBJACC.frmstring = frmstring
                Dim DT As DataTable = OBJACC.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                FILLCMPCODE()
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBCODE.Text) <> LCase(tempAccountsCode)) Then
                    dt = objclscommon.search("ACC_CODE", "", " LEDGERS", " AND ACC_CODE = '" & CMBCODE.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Code Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkcopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcopy.CheckedChanged
        Try
            txtadd.Clear()
            If chkcopy.CheckState = CheckState.Checked Then
                If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
                If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

                If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

                If cmbcity.Text.Trim <> "" Then txtadd.Text = txtadd.Text & ", " & cmbcity.Text.Trim

                If txtzipcode.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & "," & vbNewLine
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If ClientName <> "AVIS" Then
                    If cmbstate.Text.Trim <> "" Then
                        txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim & ","
                    Else
                        txtadd.Text = txtadd.Text & vbNewLine
                    End If

                    If cmbcountry.Text.Trim <> "" Then
                        txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim & "."
                    End If
                Else
                    txtadd.Text = Replace(txtadd.Text, vbNewLine, "")
                End If

                'OPEN FOR ALL
                'If ClientName = "PARAS" Or ClientName = "CC" Or ClientName = "YASHVI" Or ClientName = "KEMLINO" Or ClientName = "SHREEVALLABH" Or ClientName = "MOHATUL" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then
                If txtmobile.Text.Trim <> "" Then txtadd.Text = txtadd.Text & vbNewLine & txtmobile.Text.Trim
                If txttel1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "/" & txttel1.Text.Trim
                'End If
                If ClientName = "KEMLINO" Or ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Then txtadd.Text = UCase(txtadd.Text)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBILL.Click
        Try
            If EDIT = True And cmbcmpname.Text.Trim = tempAccountsName Then
                Dim OBJOPENING As New OpeningBills
                OBJOPENING.MdiParent = MDIMain
                OBJOPENING.TEMPNAME = cmbcmpname.Text.Trim
                OBJOPENING.FRMSTRING = "OPENINGBILLS"
                OBJOPENING.Show()
            Else
                MsgBox("Entry Allowed in Edit mode only", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTDSAPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTDSAPP.CheckedChanged
        Try
            If cmbgroup.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable = objcmn.search(" GROUP_SECONDARY", "", " GROUPMASTER", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors" Or DT.Rows(0).Item(0) = "Provisions" Or DT.Rows(0).Item(0) = "Loans" Or DT.Rows(0).Item(0) = "Unsecured Loans" Or DT.Rows(0).Item(0) = "Secured Loans" Or DT.Rows(0).Item(0) = "Loans & Advances" Then
                        GROUPTDS.Enabled = CHKTDSAPP.CheckState
                        'DONE BY GULKIT
                        'Else
                        '    MsgBox("Not Applicable for this Group")
                        '    CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSECTION_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSECTION.Validating
        Try
            TXTTDSRATE.Clear()
            If CMBSECTION.Text = "194C" Then
                TXTTDSRATE.Enabled = True
                TXTTDSRATE.Focus()
                LBLLIMIT.Visible = True
                TXTLIMIT.Visible = True
            Else
                TXTTDSRATE.Enabled = False
                LBLLIMIT.Visible = False
                TXTLIMIT.Visible = False
                TXTLIMIT.Clear()
                TXTTDSRATE.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNATURE.Enter
        Try
            If CMBNATURE.Text.Trim = "" Then FILLNATURE(CMBNATURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNATURE.Validating
        Try
            If CMBNATURE.Text.Trim <> "" Then NATUREVALIDATE(CMBNATURE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND  LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, cmbhotelcode, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, cmbhotelcode, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTAGENTCOMM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTCOMM.KeyPress, TXTTDSPER.KeyPress, TXTTDSRATE.KeyPress, TXTINTPER.KeyPress, TXTDISC.KeyPress, TXTLIMIT.KeyPress, TXTPROFITPER.KeyPress, txtstno.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBAGENT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Validated
        Try
            If CMBAGENT.Text.Trim <> "" Then
                'FETCH AGENT COMM 
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_AGENTCOMM,0) AS COMMPER", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBAGENT.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso Val(TXTAGENTCOMM.Text.Trim) = 0 Then TXTAGENTCOMM.Text = Val(DT.Rows(0).Item("COMMPER"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFCOMPANIES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPOFCOMPANIES.Enter
        Try
            If CMBGROUPOFCOMPANIES.Text.Trim = "" Then FILLGROUPCOMPANY(CMBGROUPOFCOMPANIES)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFCOMPANIES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPOFCOMPANIES.Validating
        Try
            If CMBGROUPOFCOMPANIES.Text.Trim <> "" Then GROUPCOMPANYVALIDATE(CMBGROUPOFCOMPANIES, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPACKINGTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKINGTYPE.Enter
        Try
            If CMBPACKINGTYPE.Text.Trim = "" Then FILLPACKINGTYPE(CMBPACKINGTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKINGTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKINGTYPE.Validating
        Try
            If CMBPACKINGTYPE.Text.Trim <> "" Then PACKINGTYPEVALIDATE(CMBPACKINGTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSALESMAN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSALESMAN.Enter
        Try
            If CMBSALESMAN.Text.Trim = "" Then FILLSALESMAN(CMBSALESMAN)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSALESMAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSALESMAN.Validating
        Try
            If CMBSALESMAN.Text.Trim <> "" Then SALESMANVALIDATE(CMBSALESMAN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBPARTYBANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYBANK.Enter
        Try
            If CMBPARTYBANK.Text.Trim = "" Then FILLBANK(CMBPARTYBANK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYBANK.Validating
        Try
            If CMBPARTYBANK.Text.Trim <> "" Then PARTYBANKvalidate(CMBPARTYBANK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBBANKCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANKCITY.Enter
        Try
            If CMBBANKCITY.Text.Trim = "" Then fillCITY(CMBBANKCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANKCITY.Validating
        Try
            If CMBBANKCITY.Text.Trim <> "" Then CITYVALIDATE(CMBBANKCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccountsMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub TXTPROFITPER_Validating(sender As Object, e As CancelEventArgs) Handles TXTPROFITPER.Validating
        Try
            If Val(TXTPROFITPER.Text.Trim) > 100 Then
                e.Cancel = True
                MsgBox("% Cannot be Greater then 100", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDHINDI_Click(sender As Object, e As EventArgs) Handles CMDHINDI.Click
        Try
            Dim OBJHINDI As New HindiTyping
            OBJHINDI.TEMPHINDINAME = TXTHINDINAME.Text.Trim
            OBJHINDI.ShowDialog()
            TXTHINDINAME.Text = OBJHINDI.TXTNAME.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Enter(sender As Object, e As EventArgs) Handles CMBDELIVERYAT.Enter
        Try
            If CMBDELIVERYAT.Text.Trim = "" Then fillCITY(CMBDELIVERYAT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDELIVERYAT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDELIVERYAT.Validating
        Try
            If CMBDELIVERYAT.Text.Trim <> "" Then CITYVALIDATE(CMBDELIVERYAT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSTIN_Validated(sender As Object, e As EventArgs) Handles TXTGSTIN.Validated
        Try
            If ClientName = "PARAS" And TXTGSTIN.Text.Trim.Length = 15 Then txtpanno.Text = TXTGSTIN.Text.Trim.Substring(2, 10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class