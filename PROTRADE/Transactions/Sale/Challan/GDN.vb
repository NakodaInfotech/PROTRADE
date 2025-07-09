
Imports System.IO
Imports BL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class GDN

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPGDNNO As Integer     'used for poation no while editing
    Public TEMPPROFORMANO As Integer = 0
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim TEMPMTRS As Double = 0.0
    Dim DTNEW As New DataTable
    Dim PRESENT As Boolean = False
    Dim PARTYCHALLANNO As String


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        'txtgdnno.ReadOnly = False
        txtgdnno.Clear()
        GDNDATE.Text = Now.Date


        If ALLOWMANUALGDNNO = True Then
            txtgdnno.ReadOnly = False
            txtgdnno.BackColor = Color.LemonChiffon
        Else
            txtgdnno.ReadOnly = True
            txtgdnno.BackColor = Color.Linen
        End If

        TXTTYPECHALLANNO.Clear()
        If CMBTYPE.Items.Count > 0 Then
            CMBTYPE.Enabled = True
            CMBTYPE.SelectedIndex = 0
            GETMAXTYPECHALLANNO()
        End If
        TabControl1.SelectedIndex = 0

        tstxtbillno.Clear()
        TXTSONO.Enabled = True
        TXTMULTISONO.Clear()
        TXTMERCHANT.Clear()
        If ClientName <> "ALENCOT" Then cmbname.Text = ""
        cmbname.Enabled = True
        txtadd.Clear()
        TXTCONSIGNEE.Clear()
        CMBHASTE.Text = ""
        CMBAGENT.Text = ""

        txtpono.Clear()
        podate.Value = Now.Date
        TXTSONO.Clear()
        SODATE.Value = Now.Date

        CHKHOLD.Checked = False
        CMBTRANS.Text = ""
        TXTLRNO.Clear()
        LRDATE.Value = Now.Date
        CMBDISPATCHTO.Text = ""
        TXTDISPATCHADDRESS.Clear()
        If ClientName = "PARAS" Then txttransref.Text = "100CMS" Else txttransref.Clear()
        TXTTRANSREMARKS.Clear()
        cmbcity.Text = ""
        If ClientName = "SOFTAS" Or ClientName = "AVIS" Or ClientName = "SANGHVI" Then
            TXTBALENOFROM.Text = 1
        Else
            TXTBALENOFROM.Clear()
            CMBPIECETYPE.Text = ""
        End If
        TXTBALENOTO.Clear()
        txtremarks.Clear()

        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False
        SALELOCK.Visible = False

        'clearing itemgrid textboxes and combos
        GRIDGDN.RowCount = 0
        GRIDORDER.RowCount = 0


        cmdselectOrder.Enabled = True
        cmdselectps.Enabled = True
        GRIDDOUBLECLICK = False
        getmaxno()

        LBLTOTALBALES.Text = 0
        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0
        LBLAMOUNT.Text = 0

        txtsrno.Clear()
        CMBITEMNAME.Text = ""
        If ClientName = "KOTHARI" Then
            CMBQUALITY.Text = "FINISHED"
            CMBPIECETYPE.Text = "FRESH"
        Else
            CMBQUALITY.Text = ""
        End If

        If ClientName = "SMS" Then CMBPIECETYPE.Text = "FRESH"

        TXTDESCRIPTION.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBALENO.Clear()
        TXTPCS.Clear()
        TXTCUT.Clear()
        TXTMTRS.Clear()
        TXTRATE.Clear()
        If ClientName <> "MOMAI" Then CMBPER.SelectedIndex = 0
        TXTAMOUNT.Clear()
        TXTCOPIES.Text = 2
        TXTMOBILENO.Clear()
        TXTGRIDLOTNO.Clear()
        If ClientName <> "SMS" And ClientName <> "SHUBHI" Then CHKHIDEPCS.CheckState = CheckState.Unchecked

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLAMOUNT.Text = 0.0

            If GRIDGDN.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDGDN.Rows
                    If Val(row.Cells(GCUT.Index).EditedFormattedValue) > 0 And Val(row.Cells(Gpcs.Index).EditedFormattedValue) > 0 Then row.Cells(Gmtrs.Index).Value = Format(Val(row.Cells(Gpcs.Index).EditedFormattedValue) * Val(row.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Or row.Cells(GPER.Index).EditedFormattedValue = "Yards" Then
                        row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(Gmtrs.Index).EditedFormattedValue))
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Pcs" Then
                        row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(Gpcs.Index).EditedFormattedValue))
                    End If
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                    LBLAMOUNT.Text = Format(Val(LBLAMOUNT.Text) + Val(row.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                Next
            End If
            BALECOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BALECOUNT()
        Try
            LBLTOTALBALES.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDGDN.Rows.Count - 1
                If Not GRIDGDN.Rows(i).IsNewRow Then
                    cellValue = GRIDGDN(GBALENO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALBALES.Text = Val(dic.Count)
            If ClientName = "PARAS" Or ClientName = "DILIP" Then TXTBALENOFROM.Text = Val(LBLTOTALBALES.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
        TEMPPROFORMANO = 0
    End Sub

    'Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If GDNDATE.Text = "__/__/____" Then
    '        EP.SetError(GDNDATE, " Please Enter Proper Date")
    '        e.Cancel = True
    '    Else
    '        If Not datecheck(GDNDATE.Text) Then
    '            EP.SetError(GDNDATE, "Date not in Accounting Year")
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(gdn_no),0) + 1 ", " GDN ", " and gdn_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then txtgdnno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            Dim OBJCMN As New ClsCommon

            If Val(TXTBALENOTO.Text.Trim) > 0 And Val(TXTBALENOFROM.Text.Trim) > 0 Then
                If Val(TXTBALENOFROM.Text.Trim) > Val(TXTBALENOTO.Text.Trim) Then
                    EP.SetError(TXTBALENOTO, " From Bale No Cannot Be Greater Than To Bale No ")
                    bln = False
                End If
            End If


            If ClientName = "SONU" Then
                If CMBKPL.Text = "" Then CMBKPL.SelectedIndex = 0
                txttransref.Text = CMBKPL.Text.Trim
            End If


            'IF ALLOWPACKINGSLIP IS TRUE THEN FETCH NOOFBALES AUTO FROM LBLTOTALBALES\
            If ALLOWPACKINGSLIP = True And Val(TXTBALENOFROM.Text.Trim) = 0 Then TXTBALENOFROM.Text = LBLTOTALBALES.Text.Trim
            If Val(TXTBALENOFROM.Text.Trim) = 0 And ClientName <> "SONU" Then TXTBALENOFROM.Text = 1

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Party Name ")
                bln = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Select Godown")
                bln = False
            End If

            If ClientName = "KOTHARI" And TXTSONO.Text.Trim = "" Then
                EP.SetError(TXTSONO, " Enter SO No.")
                bln = False
            End If

            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                If CMBTYPE.Text.Trim = "" Then
                    EP.SetError(CMBTYPE, " Please Select Challan Type")
                    bln = False
                End If

                If Val(TXTTYPECHALLANNO.Text.Trim) = 0 Then
                    EP.SetError(CMBTYPE, " Please Select Challan Type")
                    bln = False
                End If
            End If

            If Val(txtgdnno.Text.Trim) = 0 Then
                EP.SetError(cmbname, "Invalid Challan No")
                bln = False
            End If

            If ClientName <> "SANGHVI" And ClientName <> "KDFAB" And ClientName <> "DJIMPEX" And ALLOWMANUALGDNNO = True Then
                If Val(txtgdnno.Text.Trim) <> 0 And EDIT = False Then
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(GDN.GDN_NO,0)  AS GDNNO", "", " GDN ", "  AND GDN.GDN_NO=" & txtgdnno.Text.Trim & " AND GDN.GDN_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(txtgdnno, "Challan No Already Exists")
                        bln = False
                    End If
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Invoice Raised, Delete Invoice First")
                bln = False
            End If

            If SALELOCK.Visible = True Then
                EP.SetError(lbllocked, "Sale Return Raised, Delete Sale Return First")
                bln = False
            End If

            If GRIDGDN.RowCount = 0 Then
                EP.SetError(cmbname, "Fill Packing Slip Details")
                bln = False
            End If

            Dim POMANDATE As Boolean = False
            If cmbname.Text.Trim <> "" Then
                Dim DTLEDGER As DataTable = OBJCMN.search("ISNULL(ACC_POMANDATE,0) AS POMANDATE", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                POMANDATE = Convert.ToBoolean(DTLEDGER.Rows(0).Item("POMANDATE"))
            End If
            For Each ROW As DataGridViewRow In GRIDGDN.Rows
                'ALLOW USER TO KEEP PCS 0 COZ, THIS WILL HELP THEM TO MAINTAIN PCS WISE STOCK
                'If Val(ROW.Cells(Gpcs.Index).Value) = 0 Then
                '    EP.SetError(cmbname, "Pcs Cannot be 0")
                '    bln = False
                'End If


                'CHECK IF POMANDATE AND PARTYPO IS BLANK
                If POMANDATE = True And ROW.Cells(GPARTYPONO.Index).Value = "" Then
                    EP.SetError(cmbname, "Enter Party PO No in Sale Order")
                    bln = False
                    Exit For
                End If



                'CLEAR THE BACKCOLOR
                ROW.DefaultCellStyle.BackColor = Color.Empty


                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" Then
                    If Val(ROW.Cells(Gmtrs.Index).Value) = 0 Then
                        EP.SetError(cmbname, "Mtrs Cannot be 0")
                        bln = False
                    End If
                End If

                If Val(ROW.Cells(GSALEDONE.Index).Value) = 1 Then
                    lbllocked.Visible = True
                    EP.SetError(lbllocked, "Sale Return Raised, Delete Sale Return First")
                    bln = False
                End If

                If ClientName = "MSANCHITKUMAR" And ROW.Cells(GBALENO.Index).Value = "" Then
                    TXTBALENO.BackColor = Color.LemonChiffon
                    EP.SetError(TXTBALENO, "Enter Bale No.")
                    bln = False
                End If


                'NEGATIVE STOCK NOT ALLLOWED
                If ClientName = "RUCHITA" Then
                    Dim DT As DataTable = OBJCMN.search(" ISNULL((SUM(PCS)-SUM(ISSPCS)),0) AS TOTALPCS, ISNULL((SUM(MTRS)-SUM(ISSMTRS)),0) AS TOTALMTRS ", "", " STOCKREGISTER ", " AND ITEMNAME = '" & ROW.Cells(GITEMNAME.Index).Value & "' AND DESIGNNO = '" & ROW.Cells(GDESIGN.Index).Value & "' AND COLOR = '" & ROW.Cells(GSHADE.Index).Value & "' and GODOWN = '" & CMBGODOWN.Text.Trim & "' AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If Val(DT.Rows(0).Item("TOTALMTRS")) <= 0 Then
                            ROW.DefaultCellStyle.BackColor = Color.LightGreen
                            If MsgBox("Mtrs not Present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                EP.SetError(cmbname, "Mtrs Not Present")
                                bln = False
                            End If
                        End If
                    Else
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("Mtrs not Present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(cmbname, "Mtrs Not Present")
                            bln = False
                        End If
                    End If
                End If
            Next


            If ClientName = "KARAN" And txttransref.Text.Trim = "" Then
                EP.SetError(txttransref, "Enter Challan No")
                bln = False
            End If



            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(OGDNQTY.Index).Value = 0
                    ORDROW.Cells(OGDNMTRS.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                TXTMULTISONO.Clear()
                For Each a As String In MULTISONO
                    If TXTMULTISONO.Text = "" Then
                        TXTMULTISONO.Text = a
                    Else
                        TXTMULTISONO.Text = TXTMULTISONO.Text & "," & a
                    End If
                Next


                If SALEORDERONMTRS = False Then
                    For Each ROW As DataGridViewRow In GRIDGDN.Rows
                        For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                            If ROW.Cells(GITEMNAME.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(GSHADE.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                                TEMPORDERMATCH = True
                                'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                                'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                                'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                                If Val(ORDROW.Cells(OGDNQTY.Index).Value) >= Val(ORDROW.Cells(OPCS.Index).Value) Then
                                    TEMPORDERROWNO = ORDROW.Index
                                    GoTo CHECKNEXTLINE
                                End If
                                ORDROW.Cells(OGDNQTY.Index).Value = Val(ORDROW.Cells(OGDNQTY.Index).Value) + Val(ROW.Cells(Gpcs.Index).Value)
                                ROW.Cells(GRATE.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
                                ROW.Cells(GSONO.Index).Value = Val(ORDROW.Cells(OFROMNO.Index).Value)
                                ROW.Cells(GSOSRNO.Index).Value = Val(ORDROW.Cells(OFROMSRNO.Index).Value)
                                ROW.Cells(GPARTYPONO.Index).Value = ORDROW.Cells(OPARTYPONO.Index).Value
                                TEMPORDERROWNO = -1
                                Exit For
CHECKNEXTLINE:
                            End If
                        Next
                        'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                        If TEMPORDERROWNO >= 0 Then
                            GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNQTY.Index).Value) + Val(ROW.Cells(Gpcs.Index).Value)
                            ROW.Cells(GRATE.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
                            ROW.Cells(GSONO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMNO.Index).Value)
                            ROW.Cells(GSOSRNO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMSRNO.Index).Value)
                            ROW.Cells(GPARTYPONO.Index).Value = GRIDORDER.Rows(TEMPORDERROWNO).Cells(OPARTYPONO.Index).Value
                            TEMPORDERROWNO = -1
                        End If
                        If TEMPORDERMATCH = False Then
                            ROW.DefaultCellStyle.BackColor = Color.LightGreen

                            'SALEORDER MANDATORY 
                            If ClientName = "AVIS" Then
                                EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                bln = False
                            Else
                                If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                    bln = False
                                End If
                            End If


                        End If
                        TEMPORDERMATCH = False
                    Next

                Else

                    'FOR SALEORDER ON MTRS
                    For Each ROW As DataGridViewRow In GRIDGDN.Rows
                        For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                            If ROW.Cells(GITEMNAME.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(GSHADE.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                                TEMPORDERMATCH = True
                                'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                                'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                                'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                                If Val(ORDROW.Cells(OGDNMTRS.Index).Value) >= Val(ORDROW.Cells(OMTRS.Index).Value) Then
                                    TEMPORDERROWNO = ORDROW.Index
                                    GoTo CHECKNEXTLINEMTRS
                                End If
                                ORDROW.Cells(OGDNMTRS.Index).Value = Val(ORDROW.Cells(OGDNMTRS.Index).Value) + Val(ROW.Cells(Gmtrs.Index).Value)
                                ROW.Cells(GRATE.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
                                ROW.Cells(GSONO.Index).Value = Val(ORDROW.Cells(OFROMNO.Index).Value)
                                ROW.Cells(GSOSRNO.Index).Value = Val(ORDROW.Cells(OFROMSRNO.Index).Value)
                                ROW.Cells(GPARTYPONO.Index).Value = ORDROW.Cells(OPARTYPONO.Index).Value
                                TEMPORDERROWNO = -1
                                Exit For
CHECKNEXTLINEMTRS:
                            End If
                        Next
                        'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                        If TEMPORDERROWNO >= 0 Then
                            GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNMTRS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNMTRS.Index).Value) + Val(ROW.Cells(Gmtrs.Index).Value)
                            ROW.Cells(GRATE.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
                            ROW.Cells(GSONO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMNO.Index).Value)
                            ROW.Cells(GSOSRNO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMSRNO.Index).Value)
                            ROW.Cells(GPARTYPONO.Index).Value = GRIDORDER.Rows(TEMPORDERROWNO).Cells(OPARTYPONO.Index).Value
                            TEMPORDERROWNO = -1
                        End If
                        If TEMPORDERMATCH = False Then
                            ROW.DefaultCellStyle.BackColor = Color.LightGreen

                            'SALEORDER MANDATORY 
                            If ClientName = "AVIS" Then
                                EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                bln = False
                            Else
                                If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                    bln = False
                                End If
                            End If
                        End If
                        TEMPORDERMATCH = False
                    Next
                End If

            End If


            'lock challan for excess of 30%
            For Each ROW As DataGridViewRow In GRIDORDER.Rows
                ROW.DefaultCellStyle.BackColor = Color.Empty
                If Val(ROW.Cells(OGDNMTRS.Index).Value) > 0 And ((Val(ROW.Cells(OGDNMTRS.Index).Value) - Val(ROW.Cells(OMTRS.Index).Value)) / Val(ROW.Cells(OMTRS.Index).Value)) * 100 > 30 Then
                    ROW.DefaultCellStyle.BackColor = Color.LightPink
                    If MsgBox("Dispacth Greater then Allowed Order Mtrs, widh to Proceed", MsgBoxStyle.YesNo) = vbNo Then
                        bln = False
                        Exit For
                    End If
                    If MsgBox("Are you Sure? wish to Proceed", MsgBoxStyle.YesNo) = vbNo Then
                        bln = False
                        Exit For
                    End If
                End If
            Next


            If (ClientName = "AVIS" Or ClientName = "KOTHARI") And GRIDORDER.RowCount = 0 And CHALLANWITHOUTSO = True Then
                EP.SetError(cmbname, "Please Select Sale Order")
                bln = False
            End If

            If txttransref.Text.Trim <> "" And ClientName <> "KCRAYON" And ClientName <> "DJIMPEX" And ClientName <> "PARAS" And ClientName <> "SONU" Then
                If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txttransref.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim DT As DataTable = objclscommon.search(" GDN_TRANSREFNO", "", " GDN", " and GDN_TRANSREFNO= '" & txttransref.Text.Trim & "' AND GDN_YEARID =" & YearId)
                    If DT.Rows.Count > 0 Then
                        EP.SetError(txttransref, "Challan No. Already Exists")
                        bln = False
                    End If
                End If
            End If


            If GDNDATE.Text = "__/__/____" Then
                EP.SetError(GDNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(GDNDATE.Text) Then
                    EP.SetError(GDNDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If ALLOWMANUALGDNNO = True Then
                If txtgdnno.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(GDN.GDN_NO,0)  AS GDNNO", "", " GDN ", "  AND GDN.GDN_NO=" & txtgdnno.Text.Trim & " AND GDN.GDN_YEARID = " & YearId)

                    If dttable.Rows.Count > 0 Then
                        EP.SetError(txtgdnno, "Challan No Already Exist")
                        bln = False
                    End If
                End If
            End If

            If ClientName = "KOTHARI" And Val(TXTBALENOFROM.Text.Trim) = 0 Then
                EP.SetError(TXTBALENOFROM, " Enter No of Bales")
                bln = False
            End If

            If TXTSONO.Text.Trim <> "" And TXTMULTISONO.Text.Trim = "" Then TXTMULTISONO.Text = TXTSONO.Text.Trim

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdselectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectOrder.Click
        Try
            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim DTSO As New DataTable
            Dim OBJSELECTSO As New SelectSO
            OBJSELECTSO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTSO.ShowDialog()
            DTSO = OBJSELECTSO.DT

            If DTSO.Rows.Count > 0 Then

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTSO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTMULTISONO.Text.Trim = "" Then
                        TXTMULTISONO.Text = DTR("SONO").ToString
                    Else
                        TXTMULTISONO.Text = TXTMULTISONO.Text & "," & DTR("SONO").ToString
                    End If
                Next

                TXTSONO.Text = DTSO.Rows(0).Item("SONO")
                TXTSOGRIDSRNO.Text = DTSO.Rows(0).Item("GRIDSRNO")
                SODATE.Value = DTSO.Rows(0).Item("DATE")


                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                DV = DTSO.DefaultView
                NEWDT = DV.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If txtpono.Text.Trim = "" Then
                        txtpono.Text = DTR("PONO").ToString
                        TXTTRANSREMARKS.Text = DTR("PONO").ToString
                    Else
                        txtpono.Text = txtpono.Text & "," & DTR("PONO").ToString
                        TXTTRANSREMARKS.Text = TXTTRANSREMARKS.Text & "," & DTR("PONO").ToString
                    End If
                Next

                'WE NEED DISTINCT PONO WITH , SO WE HAVE WRITTEN THE ABOVE CODE
                'txtpono.Text = DTSO.Rows(0).Item("PONO")
                'TXTTRANSREMARKS.Text = DTSO.Rows(0).Item("PONO")



                CMBAGENT.Text = DTSO.Rows(0).Item("AGENTNAME")
                If DTSO.Rows(0).Item("TRANSNAME") <> "" Then CMBTRANS.Text = DTSO.Rows(0).Item("TRANSNAME")
                cmbcity.Text = DTSO.Rows(0).Item("CITYNAME")
                CMBDISPATCHTO.Text = DTSO.Rows(0).Item("DELIVERYAT")
                If ClientName = "MOHAN" Then
                    txttransref.Text = DTSO.Rows(0).Item("REFNO")
                    TXTTRANSREMARKS.Text = DTSO.Rows(0).Item("PONO")
                End If
                TXTSONO.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTSO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("SONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next
                    GRIDORDER.Rows.Add(0, DTROW("ITEMNAME"), DTROW("DESIGN"), DTROW("COLOR"), DTROW("QTY"), DTROW("MTRS"), DTROW("SONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")), DTROW("GRIDPARTYPONO"))
NEXTLINE:
                Next
                getsrno(GRIDORDER)

            End If

            cmdselectps.Enabled = True
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub RECOSAVE()
        Try

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(GDNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDGDN.Rows
                Dim objclscommon As New ClsCommonMaster
                Dim dt1 As DataTable = objclscommon.search(" ISNULL(MTRS,0) AS MTRS ", "", " BARCODESTOCK", " AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND FROMNO= " & Val(row.Cells(GFROMNO.Index).Value) & " AND FROMSRNO= " & Val(row.Cells(GFROMSRNO.Index).Value) & " AND TYPE='" & row.Cells(GFROMTYPE.Index).Value & "' AND Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    If Val(dt1.Rows(0).Item(0)) <= 3 Then
                        PRESENT = True
                        TEMPMTRS = Val(dt1.Rows(0).Item(0))
                        If gridsrno = "" Then
                            gridsrno = row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                            QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = row.Cells(GSHADE.Index).Value.ToString
                            PCS = row.Cells(Gpcs.Index).Value.ToString
                            MTRS = TEMPMTRS
                            BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        Else
                            gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value.ToString
                            PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                            ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value.ToString
                            QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                            DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                            COLOR = COLOR & "," & row.Cells(GSHADE.Index).Value.ToString
                            PCS = PCS & "," & row.Cells(Gpcs.Index).Value.ToString
                            MTRS = MTRS & "," & TEMPMTRS
                            BARCODE = BARCODE & "," & row.Cells(GBARCODE.Index).Value.ToString
                            FROMNO = FROMNO & "," & row.Cells(GFROMNO.Index).Value.ToString
                            FROMSRNO = FROMSRNO & "," & row.Cells(GFROMSRNO.Index).Value.ToString
                            FROMTYPE = FROMTYPE & "," & row.Cells(GFROMTYPE.Index).Value.ToString
                        End If

                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim objclsPurord As New ClsStockAdjustment()
            objclsPurord.alParaval = alParaval

            If PRESENT = True Then Dim DT As DataTable = objclsPurord.SAVE()
            MsgBox("Reco done Successfully!")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) And ClientName <> "RUCHITA" Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDGDN.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
                TabControl1.SelectedIndex = 2
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBTRANS.Text.Trim = "" Then filltransname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, EDIT)
            If CMBHASTE.Text.Trim = "" Then filljobbername(CMBHASTE, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")

            If ClientName = "AVIS" Then
                If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND GROUP_NAME = 'HASTE DEBTORS'  AND ACC_TYPE = 'ACCOUNTS'")
                If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND GROUP_NAME <> 'HASTE DEBTORS'")
            Else
                If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND ACC_TYPE = 'ACCOUNTS'")
                If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            End If


            'GRID COMBO FIELDS
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
            fillPIECETYPE(CMBPIECETYPE)
            FILLCHALLANTYPE(CMBTYPE)


            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_NO,'') AS DESIGN ", "", " DESIGNMASTER ", " AND DESIGN_YEARID = " & YearId & " ORDER BY DESIGN_NO ")
            'If DT.Rows.Count > 0 Then
            '    GDESIGN.DataSource = DT
            '    'For Each ROW As DataRow In DT.Rows
            '    '    GDESIGN.Items.Add(ROW("DESIGN"))
            '    'Next
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCLSPROFORMA As New ClsProforma()
            Dim dttable As DataTable = OBJCLSPROFORMA.SELECTPROFORMA(TEMPPROFORMANO, CmpId, Locationid, YearId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    GRIDGDN.Rows.Add(GRIDGDN.RowCount + 1, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("PRINTDESC"), dr("DESIGN"), dr("COLOR"), dr("BALENO"), Format(Val(dr("PCS")), "0"), "", Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), 0, 0, 0, "")
                Next
                txtremarks.Text = "Proforma No - " & Val(TEMPPROFORMANO)
                total()
                GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'GDN'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor


            FILLCMB()
            clear()

            If TEMPPROFORMANO > 0 Then GETDATA()

            If ClientName = "MABHAY" Or ClientName = "SVS" Then Gpcs.ReadOnly = True


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim objclsGDN As New ClsGDN()
                Dim dttable As New DataTable

                dttable = objclsGDN.SELECTGDN(TEMPGDNNO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        txtgdnno.Text = TEMPGDNNO
                        txtgdnno.ReadOnly = True

                        CMBTYPE.Text = Convert.ToString(dr("CHALLANTYPE").ToString)
                        CMBTYPE.Enabled = False
                        TXTTYPECHALLANNO.Text = Val(dr("TYPECHALLANNO"))

                        CHKHOLD.Checked = Convert.ToBoolean(dr("HOLDFORAPPROVAL"))

                        GDNDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)

                        TXTMOBILENO.Text = dr("MOBILENO")

                        'If ClientName <> "DAKSH" And ClientName <> "SHALIBHADRA" And ClientName <> "KARAN" And ClientName <> "" Then cmdselectOrder.Enabled = False

                        TXTCONSIGNEE.Text = Convert.ToString(dr("CONSIGNEE").ToString)
                        CMBHASTE.Text = Convert.ToString(dr("JOBBERNAME").ToString)
                        CMBAGENT.Text = Convert.ToString(dr("AGENT").ToString)

                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        podate.Text = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")
                        TXTSONO.Text = Convert.ToString(dr("SONO").ToString)
                        TXTMULTISONO.Text = Convert.ToString(dr("MULTISONO").ToString)
                        SODATE.Text = Format(Convert.ToDateTime(dr("SODATE")).Date, "dd/MM/yyyy")


                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        cmbcity.Text = dr("CITY").ToString
                        TXTLRNO.Text = dr("LRNO").ToString
                        LRDATE.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        CMBRISK.Text = dr("RISK").ToString
                        TXTBALENOFROM.Text = Val(dr("BALENOFROM"))
                        TXTBALENOTO.Text = Val(dr("BALENOTO"))

                        CMBDISPATCHTO.Text = dr("DISPATCHTO").ToString
                        TXTDISPATCHADDRESS.Text = dr("DISPATCHADD").ToString
                        txttransref.Text = dr("transrefno").ToString
                        If txttransref.Text.Trim <> "" And ClientName = "SONU" Then CMBKPL.Text = txttransref.Text.Trim
                        PARTYCHALLANNO = txttransref.Text.Trim

                        TXTTRANSREMARKS.Text = dr("transremarks").ToString

                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)
                        TXTMERCHANT.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        GRIDGDN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("PRINTDESC"), dr("DESIGN"), dr("COLOR"), dr("BALENO"), dr("GRIDLOTNO"), Format(Val(dr("PCS")), "0"), dr("UNIT"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), dr("SALEDONE"), dr("GRIDSONO"), dr("GRIDSOSRNO"), dr("GRIDPARTYPONO"))

                        If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTMTRS")) > 0 Or Val(dr("OUTPCS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("SMSSEND")) = True Then LBLSMS.Visible = True

                        If Convert.ToBoolean(dr("SALERETURN")) = True Then
                            lbllocked.Visible = True
                            SALELOCK.Visible = True
                        End If
                    Next


                    'ORDER GRID
                    'Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" GDN_SODETAILS.GDN_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, GDN_SODETAILS.GDN_ORDERPCS AS ORDERQTY, ISNULL(GDN_SODETAILS.GDN_ORDERMTRS,0) AS ORDERMTRS, GDN_SODETAILS.GDN_FROMNO AS FROMNO, GDN_SODETAILS.GDN_FROMSRNO AS FROMSRNO, GDN_SODETAILS.GDN_FROMTYPE AS FROMTYPE, GDN_SODETAILS.GDN_PCS AS GDNQTY, ISNULL(GDN_SODETAILS.GDN_MTRS,0) AS GDNMTRS, ISNULL(GDN_SODETAILS.GDN_RATE,0) AS RATE, ISNULL(GDN_SODETAILS.GDN_PARTYPONO,'') AS PARTYPONO ", "", " GDN_SODETAILS INNER JOIN ITEMMASTER ON GDN_SODETAILS.GDN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GDN_SODETAILS.GDN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON GDN_SODETAILS.GDN_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND GDN_SODETAILS.GDN_NO = " & TEMPGDNNO & " AND GDN_SODETAILS.GDN_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("ITEMNAME"), DTR("DESIGNNO"), DTR("COLOR"), Val(DTR("ORDERQTY")), Val(DTR("ORDERMTRS")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("GDNQTY")), Val(DTR("GDNMTRS")), Val(DTR("RATE")), DTR("PARTYPONO"))
                        Next
                    End If
                    getsrno(GRIDORDER)

                    total()
                    GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1
                Else
                    EDIT = False
                    clear()
                End If
                chkchange.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If txtgdnno.ReadOnly = False Then
                alParaval.Add(Val(txtgdnno.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(GDNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(TXTCONSIGNEE.Text.Trim)
            alParaval.Add(CMBHASTE.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)

            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(podate.Value.Date)
            alParaval.Add(Val(TXTSONO.Text.Trim))
            alParaval.Add(Val(TXTSOGRIDSRNO.Text.Trim))
            alParaval.Add(SODATE.Value.Date)
            alParaval.Add(TXTMULTISONO.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(LRDATE.Value)
            alParaval.Add(CMBRISK.Text.Trim)
            alParaval.Add(TXTBALENOFROM.Text.Trim)
            alParaval.Add(TXTBALENOTO.Text.Trim)

            alParaval.Add(CMBDISPATCHTO.Text.Trim)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(TXTTRANSREMARKS.Text.Trim)

            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLAMOUNT.Text))

            alParaval.Add(CHKHOLD.CheckState)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(ClientName)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim PRINTDESC As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim BALENO As String = ""
            Dim GRIDLOTNO As String = ""
            Dim PCS As String = ""
            Dim UNIT As String = ""
            Dim CUT As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""
            Dim PER As String = ""
            Dim AMOUNT As String = ""
            Dim BARCODE As String = ""

            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim SALEDONE As String = ""

            Dim GRIDSONO As String = ""
            Dim GRIDSOSRNO As String = ""
            Dim GRIDPARTYPONO As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDGDN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = ""
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GSHADE.Index).Value.ToString
                        If ClientName = "RMANILAL" Or ClientName = "SUNCOTT" Then
                            BALENO = Val(txtgdnno.Text.Trim)
                        Else
                            If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = row.Cells(GBALENO.Index).Value.ToString Else BALENO = ""
                        End If
                        GRIDLOTNO = row.Cells(GGRIDLOTNO.Index).Value.ToString
                        PCS = Val(row.Cells(Gpcs.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString

                        If ClientName = "PURVITEX" Then
                            CUT = 0
                        ElseIf ClientName = "SMS" Then
                            If Val(row.Cells(GCUT.Index).Value) = 0 And Val(row.Cells(Gpcs.Index).Value) = 1 Then CUT = Format(Val(row.Cells(Gmtrs.Index).Value), "0.00") Else CUT = Val(row.Cells(GCUT.Index).Value)
                        ElseIf ClientName = "AVIS" Or ClientName = "MARKIN" Or ClientName = "PARAS" Or ClientName = "DILIP" Or ClientName = "MOHATUL" Or ClientName = "SAKARIA" Then
                            CUT = Val(row.Cells(GCUT.Index).Value)
                        Else
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = Val(row.Cells(GCUT.Index).Value)
                        End If

                        MTRS = Val(row.Cells(Gmtrs.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        PER = row.Cells(GPER.Index).Value.ToString
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        SALEDONE = row.Cells(GSALEDONE.Index).Value.ToString

                        GRIDSONO = Val(row.Cells(GSONO.Index).Value)
                        GRIDSOSRNO = Val(row.Cells(GSOSRNO.Index).Value)
                        GRIDPARTYPONO = row.Cells(GPARTYPONO.Index).Value.ToString
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        If row.Cells(GPRINTDESC.Index).Value <> Nothing Then PRINTDESC = PRINTDESC & "|" & row.Cells(GPRINTDESC.Index).Value.ToString Else PRINTDESC = PRINTDESC & "|" & ""
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GSHADE.Index).Value.ToString
                        If ClientName = "RMANILAL" Or ClientName = "SUNCOTT" Then
                            BALENO = BALENO & "|" & Val(txtgdnno.Text.Trim)
                        Else
                            If row.Cells(GBALENO.Index).Value <> Nothing Then BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString Else BALENO = BALENO & "|" & ""
                        End If
                        GRIDLOTNO = GRIDLOTNO & "|" & row.Cells(GGRIDLOTNO.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(Gpcs.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString

                        If ClientName = "PURVITEX" Then
                            CUT = CUT & "|" & 0
                        ElseIf ClientName = "SMS" Then
                            If Val(row.Cells(GCUT.Index).Value) = 0 And Val(row.Cells(Gpcs.Index).Value) = 1 Then CUT = CUT & "|" & Format(Val(row.Cells(Gmtrs.Index).Value), "0.00") Else CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        ElseIf ClientName = "AVIS" Or ClientName = "MARKIN" Or ClientName = "PARAS" Or ClientName = "DILIP" Or ClientName = "MOHATUL" Or ClientName = "SAKARIA" Then
                            CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        Else
                            If Val(row.Cells(GCUT.Index).Value) = 0 Then CUT = CUT & "|" & Format(Val(row.Cells(Gmtrs.Index).Value) / Val(row.Cells(Gpcs.Index).Value), "0.00") Else CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        End If

                        MTRS = MTRS & "|" & Val(row.Cells(Gmtrs.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        PER = PER & "|" & row.Cells(GPER.Index).Value.ToString
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString
                        SALEDONE = SALEDONE & "|" & row.Cells(GSALEDONE.Index).Value.ToString

                        GRIDSONO = GRIDSONO & "|" & Val(row.Cells(GSONO.Index).Value)
                        GRIDSOSRNO = GRIDSOSRNO & "|" & Val(row.Cells(GSOSRNO.Index).Value)
                        GRIDPARTYPONO = GRIDPARTYPONO & "|" & row.Cells(GPARTYPONO.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(PRINTDESC)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(BALENO)
            alParaval.Add(GRIDLOTNO)
            alParaval.Add(PCS)
            alParaval.Add(UNIT)
            alParaval.Add(CUT)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMOUNT)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(SALEDONE)
            alParaval.Add(GRIDSONO)
            alParaval.Add(GRIDSOSRNO)
            alParaval.Add(GRIDPARTYPONO)

            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERITEMNAME As String = ""
            Dim ORDERDESIGN As String = ""
            Dim ORDERCOLOR As String = ""
            Dim ORDERPCS As String = ""
            Dim ORDERMTRS As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERGDNPCS As String = ""
            Dim ORDERGDNMTRS As String = ""
            Dim ORDERRATE As String = ""
            Dim ORDERPARTYPONO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso (Val(row.Cells(OGDNQTY.Index).Value) > 0 Or Val(row.Cells(OGDNMTRS.Index).Value) > 0) Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERDESIGN = row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        ORDERPCS = Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGDNPCS = Val(row.Cells(OGDNQTY.Index).Value)
                        ORDERGDNMTRS = Val(row.Cells(OGDNMTRS.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                        ORDERPARTYPONO = row.Cells(OPARTYPONO.Index).Value
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = ORDERITEMNAME & "|" & row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERDESIGN = ORDERDESIGN & "|" & row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = ORDERCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        ORDERPCS = ORDERPCS & "|" & Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = ORDERMTRS & "|" & Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGDNPCS = ORDERGDNPCS & "|" & Val(row.Cells(OGDNQTY.Index).Value)
                        ORDERGDNMTRS = ORDERGDNMTRS & "|" & Val(row.Cells(OGDNMTRS.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                        ORDERPARTYPONO = ORDERPARTYPONO & "|" & row.Cells(OPARTYPONO.Index).Value
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERITEMNAME)
            alParaval.Add(ORDERDESIGN)
            alParaval.Add(ORDERCOLOR)
            alParaval.Add(ORDERPCS)
            alParaval.Add(ORDERMTRS)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERGDNPCS)
            alParaval.Add(ORDERGDNMTRS)
            alParaval.Add(ORDERRATE)
            alParaval.Add(ORDERPARTYPONO)


            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(Val(TXTTYPECHALLANNO.Text.Trim))


            Dim objclsgdn As New ClsGDN()
            objclsgdn.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTT As DataTable = objclsgdn.SAVE()
                txtgdnno.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

                TEMPGDNNO = txtgdnno.Text.Trim

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                ''DONE BY GULKIT
                ''BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                'If ClientName = "SAFFRON" Then
                '    Dim OBJCMN As New ClsCommon
                '    Dim LOOPTABLE As DataTable = OBJCMN.search("  GDN.GDN_ledgerid As LEDGERID, GDN_DESC.GDN_ITEMID As ITEMID, GDN_DESC.GDN_COLORID As COLORID, GDN_DESC.GDN_PCS As PCS ", "", " GDN_DESC INNER JOIN GDN On GDN_DESC.GDN_NO = GDN.GDN_NO And GDN_DESC.GDN_YEARID = GDN.GDN_YEARID ", " And GDN.GDN_NO = " & TEMPGDNNO & " And GDN.GDN_YEARID = " & YearId)
                '    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                '        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS On SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER On SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER On SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " And LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " And ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " And ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " And SCH_YEARID = " & YearId & " And  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                '        If DTTEMP.Rows.Count > 0 Then
                '            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC Set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " And SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " And SCH_yearid= " & YearId, "", "")
                '        End If
                '    Next
                'End If

                alParaval.Add(TEMPGDNNO)
                IntResult = objclsgdn.UPDATE()
                MsgBox("Details Updated")

            End If



            ''DONE BY GULKIT
            'Dim SOARRAY As New ArrayList
            'If ClientName = "SAFFRON" Then
            '    For Each ROW As DataGridViewRow In GRIDGDN.Rows
            '        Dim OBJCMN As New ClsCommon
            '        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO, SCH_SONO As SONO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS On SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER On SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER On SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " And LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ISNULL(ITEM_NAME, '') = '" & ROW.Cells(GITEMNAME.Index).Value & "' AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & ROW.Cells(GSHADE.Index).Value & "' AND SCH_YEARID = " & YearId & " AND  ((SCHEDULEMASTER_DESC.SCH_QTY - SCHEDULEMASTER_DESC.SCH_RECDQTY) > 0) ORDER BY SCH_NO , SCH_GRIDSCHNO")
            '        If DTTEMP.Rows.Count > 0 Then
            '            SOARRAY.Add(Val(DTTEMP.Rows(0).Item("SONO")))
            '            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY + " & Val(ROW.Cells(Gpcs.Index).Value) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
            '        End If
            '    Next
            'End If

            'If SOARRAY.Count > 0 Then
            '    TXTMULTISONO.Clear()
            '    Dim ht As New Hashtable()
            '    For Each ITEM As Integer In SOARRAY
            '        ht.Item(ITEM) = Nothing
            '    Next

            '    'now grab the keys from that hashtable into another arraylist
            '    Dim distincArray As New ArrayList(ht.Keys)
            '    For i As Integer = 0 To distincArray.Count - 1
            '        If TXTMULTISONO.Text = "" Then
            '            TXTMULTISONO.Text = distincArray(i)
            '        Else
            '            TXTMULTISONO.Text = TXTMULTISONO.Text & " | " & distincArray(i)
            '        End If
            '    Next

            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE GDN SET GDN_MULTISONO = '" & TXTMULTISONO.Text.Trim & "' WHERE GDN_NO = " & Val(txtgdnno.Text.Trim) & " AND GDN_YEARID = " & YearId, "", "")

            'End If


            EDIT = False
            PRINTREPORT(txtgdnno.Text.Trim)
            TEMPPROFORMANO = 0

            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDGDN.RowCount = 0
LINE1:
            TEMPGDNNO = Val(txtgdnno.Text) - 1

            'IF WE DONT HAVE ANY PREVIOUS RECORDS THEN EXIT
            If ClientName = "MIDAS" Then
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("GDN_NO AS GDNNO", "", "GDN", " AND GDN_NO <" & Val(txtgdnno.Text.Trim) & " AND GDN_YEARID =" & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    clear()
                    EDIT = False
                    Exit Sub
                End If
            End If


            If TEMPGDNNO > 0 Then
                EDIT = True
                GDN_Load(sender, e)
            Else
                clear()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDGDN.RowCount = 0 And TEMPGDNNO > 1 Then
                txtgdnno.Text = TEMPGDNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDGDN.RowCount = 0
LINE1:
            TEMPGDNNO = Val(txtgdnno.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = txtgdnno.Text.Trim
            clear()



            If Val(txtgdnno.Text) - 1 >= TEMPGDNNO Then
                EDIT = True
                GDN_Load(sender, e)
            Else
                clear()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDGDN.RowCount = 0 And TEMPGDNNO < MAXNO Then
                txtgdnno.Text = TEMPGDNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDGDN.RowCount = 0
                TEMPGDNNO = Val(tstxtbillno.Text)
                If TEMPGDNNO > 0 Then
                    EDIT = True
                    GDN_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal GDNNO As Integer)
        Try

            If ClientName = "MOMAI" Then
                If MsgBox("Wish to Print Label?", MsgBoxStyle.YesNo) = vbYes Then PRINTBARCODE()
            End If


            If MsgBox("Wish to Print Challan?", MsgBoxStyle.YesNo) = vbYes Then

                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "GDN"
                OBJGDN.FORMULA = "{GDN.GDN_no}=" & Val(GDNNO) & " and {GDN.GDN_yearid}=" & YearId
                OBJGDN.vendorname = cmbname.Text.Trim
                OBJGDN.agentname = CMBAGENT.Text.Trim
                OBJGDN.WHITELABEL = CHKWHITELABEL.Checked
                OBJGDN.HIDEPCSDETAILS = CHKHIDEPCS.Checked
                OBJGDN.PRINTINYARDS = CHKYARD.Checked

                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try

            'PRINT BARCODE

            'GET FRESH DATA FROM DATABASE (ONLY GRID)
            'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
            'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
            'GRIDGDN.RowCount = 0
            'Dim OBJGDN As New ClsGDN
            'Dim dttable As DataTable = OBJGDN.SELECTGDN(Val(txtgdnno.Text.Trim), CmpId, Locationid, YearId)
            'For Each dr As DataRow In dttable.Rows
            '    GRIDGDN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("BALENO").ToString, dr("DESIGNNO").ToString, dr("DESC").ToString, dr("COLOR"), Format(dr("qty"), "0.00"), dr("QTYUNIT").ToString, Format(dr("CUT"), "0.00"), Format(dr("MTRS"), "0.00"), dr("RACK"), dr("SHELF"), Format(dr("WT"), "0.00"), Format(dr("PURRATE"), "0.00"), Format(dr("SALERATE"), "0.00"), Format(dr("WHOLESALERATE"), "0.00"), dr("BARCODE").ToString, dr("DONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDPONO").ToString, dr("POGRIDSRNO").ToString)
            'Next

            Dim PRINTMRP As Integer
            If ClientName = "MOMAI" Then
                PRINTMRP = MsgBox("Wish to Print MRP?", MsgBoxStyle.YesNo)
            End If

            For Each ROW As DataGridViewRow In GRIDGDN.Rows

                For I As Integer = 0 To Val(ROW.Cells(Gpcs.Index).Value) - 1

                    Dim dirresults As String = ""
                    Dim oWrite As System.IO.StreamWriter
                    oWrite = File.CreateText("D:\Barcode.txt")

                    If ClientName = "MOMAI" Then

                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>SIZE 47.5 mm, 25 mm")
                        oWrite.WriteLine("GAP 3 mm, 0 mm")
                        oWrite.WriteLine("DIRECTION 0,0")
                        oWrite.WriteLine("REFERENCE 0,0")
                        oWrite.WriteLine("OFFSET 0 mm")
                        oWrite.WriteLine("SET PEEL OFF")
                        oWrite.WriteLine("SET CUTTER OFF")
                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>SET TEAR ON")
                        oWrite.WriteLine("CLS")
                        oWrite.WriteLine("CODEPAGE 1252")
                        oWrite.WriteLine("TEXT 365,188,""0"",180,14,14,""" & ROW.Cells(GITEMNAME.Index).Value & """")
                        oWrite.WriteLine("TEXT 365,146,""0"",180,14,14,""" & ROW.Cells(GDESIGN.Index).Value & """")
                        oWrite.WriteLine("TEXT 365,102,""0"",180,9,9,""" & ROW.Cells(GSHADE.Index).Value & """")
                        oWrite.WriteLine("TEXT 172,101,""0"",180,8,8,""MRP""")

                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
                        Dim TEMPMRP As String = ""
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search("ISNULL(PL_RATE,0) AS RATE", "", "PRICELISTMASTER LEFT OUTER JOIN ITEMMASTER ON PL_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON PL_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON PL_COLORID = COLORMASTER.COLOR_ID", " AND ITEMMASTER.ITEM_NAME = '" & ROW.Cells(GITEMNAME.Index).Value & "' AND DESIGNMASTER.DESIGN_NO = '" & ROW.Cells(GDESIGN.Index).Value & "' AND PL_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            TEMPMRP = Val(DT.Rows(0).Item("RATE"))
                        End If

                        If PRINTMRP = vbNo Then TEMPMRP = ""

                        oWrite.WriteLine("TEXT 119,107,""0"",180,13,13, """ & TEMPMRP & """")
                        oWrite.WriteLine("TEXT 98,71,""0"",180,4,4,""(Inc. of all Taxes)""")
                        oWrite.WriteLine("TEXT 68,138,""0"",180,7,7,""1PCS""")
                        oWrite.WriteLine("BARCODE 365,72,""128M"",52,0,180,1,2, """ & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
                        oWrite.WriteLine("TEXT 325,17,""0"",180,6,6, """ & ROW.Cells(GBARCODE.Index).Value & """")

                        oWrite.WriteLine("PRINT 1,1")
                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        oWrite.Dispose()


                    End If

                    'Printing Barcode
                    Dim psi As New ProcessStartInfo()
                    psi.FileName = "cmd.exe"
                    psi.RedirectStandardInput = False
                    psi.RedirectStandardOutput = True
                    psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                    psi.UseShellExecute = False

                    Dim proc As Process
                    proc = Process.Start(psi)
                    dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                    proc.WaitForExit()
                    proc.Dispose()
NEXTLINE:
                    'THIS LINE IS WRITTEN TO DISPOSE THE BARCODE NOTEPAD OBJECT, WHEN CURSOR COMES DIRECTLY ON NEXTLINE CODE
                    oWrite.Dispose()
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGDNNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New GDNDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
            objpodtls.BringToFront()
            'Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If ClientName = "AVIS" Then
                If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND GROUP_NAME <> 'HASTE DEBTORS'")
            Else
                If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS", CMBTRANS.Text, CMBAGENT.Text)
                'Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_TINNO,'') AS TINNO", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "'  AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                'If DT.Rows.Count > 0 Then LBLTINNO.Text = DT.Rows(0).Item("TINNO")
                'If ClientName <> "KOTHARI" Then TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then CITYVALIDATE(cmbcity, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGDN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDGDN.CellValidating
        Try
            Dim colNum As Integer = GRIDGDN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum
                Case Gpcs.Index, Gmtrs.Index, GRATE.Index, GCUT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    If bValid Then
                        If GRIDGDN.CurrentCell.Value = Nothing Then GRIDGDN.CurrentCell.Value = "0.00"
                        GRIDGDN.CurrentCell.Value = Convert.ToDecimal(GRIDGDN.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case GPER.Index
                    total()
                Case GBALENO.Index
                    BALECOUNT()
            End Select


            'FOR RATE AND DESCRIPTION WITH RESPECT TO ITEMNAME
            If ClientName = "SBA" Or ClientName = "SONU" Or ClientName = "GELATO" Then
                Dim TEMPITEM As String = ""
                Dim TEMPDESIGNNO As String = ""
                For I As Integer = GRIDGDN.CurrentRow.Index + 1 To GRIDGDN.RowCount - 1
                    If I = GRIDGDN.CurrentRow.Index + 1 Then TEMPITEM = GRIDGDN.Item(GITEMNAME.Index, I - 1).Value
                    If I = GRIDGDN.CurrentRow.Index + 1 Then TEMPDESIGNNO = GRIDGDN.Item(GDESIGN.Index, I - 1).Value
                    If ClientName = "SBA" And GRIDGDN.Item(GITEMNAME.Index, I).Value = TEMPITEM Then GRIDGDN.Item(GRATE.Index, I).Value = GRIDGDN.Item(GRATE.Index, I - 1).EditedFormattedValue
                    If ClientName = "SONU" And GRIDGDN.Item(GITEMNAME.Index, I).Value = TEMPITEM Then GRIDGDN.Item(GPRINTDESC.Index, I).Value = GRIDGDN.Item(GPRINTDESC.Index, I - 1).EditedFormattedValue
                    If ClientName = "GELATO" And GRIDGDN.Item(GITEMNAME.Index, I).Value = TEMPITEM And GRIDGDN.Item(GDESIGN.Index, I).Value = TEMPDESIGNNO Then GRIDGDN.Item(GRATE.Index, I).Value = GRIDGDN.Item(GRATE.Index, I - 1).EditedFormattedValue
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGDN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDGDN.RowCount > 0 Then GRIDGDN.Rows.RemoveAt(GRIDGDN.CurrentRow.Index) ''Removing Row From Grid
            'If GRIDGDN.CurrentRow.Index > 0 Then If e.KeyCode = Keys.F12 Then If GRIDGDN.Rows(GRIDGDN.CurrentRow.Index - 1).Cells(GLRNO.Index).Value <> "" Then GRIDGDN.Rows(GRIDGDN.CurrentRow.Index).Cells(GLRNO.Index).Value = GRIDGDN.Rows(GRIDGDN.CurrentRow.Index - 1).Cells(GLRNO.Index).Value
            If e.KeyCode = Keys.F12 And GRIDGDN.RowCount > 0 Then
                'THIS IS DONE FOR DAKSH, COZ WHEN WE FETCH DATA FROM PACKING WE DONT HAVE BARCODE AND WE NEED TO RUN THIS CODE
                'If GRIDGDN.CurrentRow.Cells(GBARCODE.Index).Value <> "" Then GRIDGDN.Rows.Insert(GRIDGDN.CurrentRow.Index, CloneWithValues(GRIDGDN.CurrentRow))
                GRIDGDN.Rows.Insert(GRIDGDN.CurrentRow.Index, CloneWithValues(GRIDGDN.CurrentRow))
                GRIDGDN.Rows(GRIDGDN.RowCount - 1).Selected = True
            End If

            getsrno(GRIDGDN)
            total()
            If e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F8 Then
                If GRIDGDN.CurrentRow.DefaultCellStyle.BackColor = Color.Linen Then GRIDGDN.CurrentRow.DefaultCellStyle.BackColor = Color.Empty Else GRIDGDN.CurrentRow.DefaultCellStyle.BackColor = Color.Linen
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Sale Invoice / Sale Return Made, Delete it First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Delete Challan?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub




                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                'If ClientName = "SAFFRON" Then
                '    Dim OBJCMN As New ClsCommon
                '    Dim LOOPTABLE As DataTable = OBJCMN.search("  GDN.GDN_ledgerid AS LEDGERID, GDN_DESC.GDN_ITEMID AS ITEMID, GDN_DESC.GDN_COLORID AS COLORID, GDN_DESC.GDN_PCS AS PCS ", "", " GDN_DESC INNER JOIN GDN ON GDN_DESC.GDN_NO = GDN.GDN_NO AND GDN_DESC.GDN_YEARID = GDN.GDN_YEARID ", " AND GDN.GDN_NO = " & TEMPGDNNO & " AND GDN.GDN_YEARID = " & YearId)
                '    For Each LOOPROW As DataRow In LOOPTABLE.Rows
                '        Dim DTTEMP As DataTable = OBJCMN.search(" TOP 1 SCH_NO , SCH_GRIDSCHNO ", "", " SCHEDULEMASTER_DESC INNER JOIN LEDGERS ON SCHEDULEMASTER_DESC.SCH_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SCHEDULEMASTER_DESC.SCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SCHEDULEMASTER_DESC.SCH_COLORID = COLORMASTER.COLOR_id  ", " AND LEDGERS.ACC_ID = " & Val(LOOPROW("LEDGERID")) & " AND ISNULL(ITEM_ID, 0) = " & Val(LOOPROW("ITEMID")) & " AND ISNULL(COLORMASTER.COLOR_ID,0) = " & Val(LOOPROW("COLORID")) & " AND SCH_YEARID = " & YearId & " AND  SCHEDULEMASTER_DESC.SCH_RECDQTY > 0 ORDER BY SCH_NO , SCH_GRIDSCHNO DESC")
                '        If DTTEMP.Rows.Count > 0 Then
                '            Dim NEWTEMP As DataTable = OBJCMN.Execute_Any_String(" update SCHEDULEMASTER_DESC set  SCH_RECDQTY = SCH_RECDQTY - " & Val(LOOPROW("PCS")) & " WHERE SCH_NO = " & Val(DTTEMP.Rows(0).Item(0)) & " AND SCH_GRIDSCHNO = " & Val(DTTEMP.Rows(0).Item(1)) & " AND SCH_yearid= " & YearId, "", "")
                '        End If
                '    Next
                'End If

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPGDNNO)
                ALPARAVAL.Add(TXTSONO.Text.Trim)

                ALPARAVAL.Add(TXTSOGRIDSRNO.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(ClientName)

                Dim OBJGDN As New ClsGDN
                OBJGDN.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJGDN.Delete
                MsgBox("GDN Deleted")

                clear()
                EDIT = False
                cmbname.Focus()
                TEMPPROFORMANO = 0

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub GDN_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MAHAVIR" Then LBLCHALLAN.Text = "Ref No"
            If ClientName = "AXIS" Then GDESIGN.HeaderText = "Design/Size"
            If ClientName = "KARAN" Then txttransref.BackColor = Color.LemonChiffon

            If ClientName = "PARAS" Then
                LBLCHALLAN.Text = "Fold"
                txttransref.Text = "100CMS"
            End If

            If ClientName = "SONU" Then
                LBLKPL.Visible = True
                CMBKPL.Visible = True
            End If

            If ClientName <> "SVS" Then
                GQUALITY.Visible = False
                GITEMNAME.Visible = True
                GCUT.Visible = True
            End If

            If ClientName = "AVIS" Then
                LBLCITY.Text = "Delivery To"
                LBLCONSIGNEE.Visible = False
                TXTCONSIGNEE.Visible = False
                LBLPACKING.Visible = False
                CMBHASTE.Visible = False
                LBLCHALLAN.Visible = False
                txttransref.Visible = False
            End If

            If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                CHKRETAIL.Visible = True
            End If

            If ClientName = "SHUBHI" Then CHKHIDEPCS.CheckState = CheckState.Checked

            If ClientName = "SKF" Or ClientName = "PURVITEX" Or ClientName = "SAFFRONOFF" Or ClientName = "MANIBHADRA" Or ClientName = "DEMO" Or ClientName = "SOFTAS" Or ClientName = "ALENCOT" Or ClientName = "MANAS" Or ClientName = "RUCHITA" Or ClientName = "KOTHARI" Or ClientName = "SHREEVALLABH" Or ClientName = "SMS" Then
                'LBLSRNO.Text = "Bale No"
                txtsrno.Visible = True
                CMBPIECETYPE.Visible = True
                CMBITEMNAME.Visible = True
                CMBQUALITY.Visible = True
                TXTDESCRIPTION.Visible = True
                CMBDESIGN.Visible = True
                CMBCOLOR.Visible = True
                TXTBALENO.Visible = True
                TXTPCS.Visible = True
                TXTCUT.Visible = True
                TXTMTRS.Visible = True
                TXTRATE.Visible = True
                CMBPER.Visible = True
                TXTAMOUNT.Visible = True
                GQUALITY.Visible = True
                GPARTYPONO.ReadOnly = False
            End If

            If ClientName = "MOHAN" Then LBLCHALLAN.Text = "Indent No."
            If ClientName = "KENCOT" Then LBLCHALLAN.Text = "Total Wt."

            If ClientName = "MSANCHITKUMAR" Then TXTBALENO.BackColor = Color.LemonChiffon



            LBLBALEFROM.Text = "Bls/Bundle"
            LBLBALETO.Visible = False
            TXTBALENOTO.Visible = False
            TXTMULTISONO.ReadOnly = False
            TXTMULTISONO.Visible = True


            If ClientName = "KCRAYON" Then
                LBLCHALLAN.Text = "Patta"
                LBLCONSIGNEE.Text = "Exp. To"
                TXTSONO.TabStop = True
                TXTMULTISONO.Visible = False
                SODATE.TabStop = True
            End If


            If ClientName = "INDRAPUJAFABRICS" Or ClientName = "INDRAPUJAIMPEX" Or ClientName = "SONU" Then
                TXTMULTISONO.TabStop = True
                TXTMULTISONO.Visible = True
                TXTMULTISONO.TabIndex = TXTSONO.TabIndex
                TXTSONO.Visible = False
                SODATE.TabStop = True
            End If


            If ClientName = "SVS" Then
                GPRINTDESC.Visible = False
                GBALENO.Visible = False
                GBARCODE.Visible = False
            End If

            If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
                LBLTYPE.Visible = True
                CMBTYPE.Visible = True
                txtgdnno.Visible = False
                TXTTYPECHALLANNO.Visible = True
                LBLSRNO.Text = "Challan No"
                LBLCHALLAN.Text = "Ref No"
                toolprevious.Visible = False
                toolnext.Visible = False
                tstxtbillno.Visible = False
                'cmdselectOrder.Text = "View Schedules"
                TXTMULTISONO.Visible = True
            End If

            If ClientName = "SOFTAS" Then
                CMBQUALITY.TabStop = False
                CMBPIECETYPE.Text = "FRESH"
                CMBDESIGN.TabStop = False
                CMBCOLOR.TabStop = False
                TXTBALENO.TabStop = False
                TXTPCS.Text = 1
                CMBAGENT.TabStop = False
                TXTCONSIGNEE.TabStop = False
                CMBHASTE.TabStop = False
                txttransref.TabStop = False
                TXTTRANSREMARKS.TabStop = False
                TXTBARCODE.TabStop = False
                TXTMOBILENO.TabStop = False
                CMBPIECETYPE.TabStop = False
            End If

            If ClientName = "KDFAB" Then
                Label10.Left = Label10.Left - 100
                LBLTOTALBALES.Left = Label10.Left + Label10.Width
                LBLTOTALPCS.Left = LBLTOTALBALES.Left + LBLTOTALBALES.Width
                LBLTOTALMTRS.Left = LBLTOTALPCS.Left + LBLTOTALPCS.Width + LBLTOTALPCS.Width
                LBLAMOUNT.Visible = False
            End If

            If ClientName = "SBA" Then GQUALITY.Visible = True
            If ClientName = "KOTHARI" Then
                CHKHIDEPCS.CheckState = CheckState.Checked
                CMDSELECTSTOCK.Enabled = False
            End If

            If ClientName = "DJIMPEX" Then
                LBLCHALLAN.Text = "Gross Wt"
                CHKYARD.Visible = True
                CHKYARD.CheckState = CheckState.Checked
                LBLBALETO.Visible = True
                TXTBALENOTO.Visible = True
            End If

            If ClientName = "MOMAI" Then
                CMBQUALITY.TabStop = False
                TXTDESCRIPTION.TabStop = False
                TXTBALENO.TabStop = False
                TXTCUT.TabStop = False
                TXTMTRS.TabStop = False
                CMBPER.Text = "Pcs"
                TXTMTRS.BackColor = Color.White
            End If

            If ClientName = "GELATO" Then
                GSHADE.HeaderText = "Size"
            End If

            If ClientName = "SMS" Then GBALENO.HeaderText = "Packing"


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSONO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSONO.KeyPress
        numkeypress(e, TXTSONO, Me)
    End Sub

    Private Sub TXTSONO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSONO.Validating
        Try
            If TXTSONO.Text.Trim <> "" Then
                Dim objclspreq As New ClsCommon()
                Dim DT As DataTable = objclspreq.search(" SALEORDER.so_no AS SONO, SALEORDER.so_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(ADDRESSMASTER.ADDRESS_ALIAS, '') AS Consignee, ISNULL(AGENTLEDGER.Acc_cmpname, '') AS Agent, SALEORDER.so_pono AS PONO, SALEORDER.so_DUEdate AS DUEDATE, SALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ISNULL(ITEMMASTER.item_name,'') AS MERCHANT   ", "", "  SALEORDER INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id AND SALEORDER.SO_CMPID = LEDGERS.Acc_cmpid AND SALEORDER.SO_LOCATIONID = LEDGERS.Acc_locationid AND SALEORDER.SO_YEARID = LEDGERS.Acc_yearid INNER JOIN SALEORDER_DESC ON SALEORDER.so_no = SALEORDER_DESC.SO_NO AND SALEORDER.SO_CMPID = SALEORDER_DESC.SO_CMPID AND SALEORDER.SO_LOCATIONID = SALEORDER_DESC.SO_LOCATIONID AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID LEFT OUTER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id AND SALEORDER_DESC.SO_CMPID = ITEMMASTER.item_cmpid AND SALEORDER_DESC.SO_LOCATIONID = ITEMMASTER.item_locationid AND SALEORDER_DESC.SO_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN LEDGERS AS AGENTLEDGER ON SALEORDER.so_Agentid = AGENTLEDGER.Acc_id AND SALEORDER.SO_CMPID = AGENTLEDGER.Acc_cmpid AND SALEORDER.SO_LOCATIONID = AGENTLEDGER.Acc_locationid AND SALEORDER.SO_YEARID = AGENTLEDGER.Acc_yearid LEFT OUTER JOIN ADDRESSMASTER ON SALEORDER.SO_YEARID = ADDRESSMASTER.ADDRESS_yearid AND SALEORDER.SO_LOCATIONID = ADDRESSMASTER.ADDRESS_locationid AND SALEORDER.SO_CMPID = ADDRESSMASTER.ADDRESS_cmpid AND SALEORDER.so_HASTEID = ADDRESSMASTER.ADDRESS_ID ", " AND SALEORDER.SO_NO = " & Val(TXTSONO.Text.Trim) & " and (SALEORDER_DESC.SO_QTY - SALEORDER_DESC.SO_RECDQTY) > 0 and SALEORDER.so_CMPID = " & CmpId & " AND SALEORDER.so_LOCATIONID = " & Locationid & " AND SALEORDER.so_YEARID = " & YearId & " ORDER BY SALEORDER_DESC.SO_GRIDSRNO")
                If DT.Rows.Count > 0 Then
                    cmbname.Enabled = False
                    cmdselectOrder.Enabled = False
                    TXTSONO.Text = DT.Rows(0).Item("SONO")
                    TXTSOGRIDSRNO.Text = DT.Rows(0).Item("GRIDSRNO")
                    SODATE.Value = DT.Rows(0).Item("DATE")
                    txtpono.Text = DT.Rows(0).Item("PONO")
                    podate.Value = DT.Rows(0).Item("DUEDATE")
                    TXTCONSIGNEE.Text = DT.Rows(0).Item("Consignee")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENT")
                    TXTMERCHANT.Text = DT.Rows(0).Item("MERCHANT")
                    TXTSONO.Enabled = False
                Else
                    If ClientName <> "KEMLINO" Then
                        If MsgBox("Invalid SO No ,Wish To Proceed ?", MsgBoxStyle.YesNo) = vbNo Then
                            TXTSONO.Clear()
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" And CMBHASTE.Text.Trim = "" Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTGDN As New DataTable
            If CMBHASTE.Text.Trim = "" Then
                Dim OBJSELECTGDN As New SelectStockGDN
                If ClientName <> "SANGHVI" Then OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
                If ALLOWPACKINGSLIP = True Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
                OBJSELECTGDN.ShowDialog()
                DTGDN = OBJSELECTGDN.DT
            Else
                Dim OBJSELECTGDN As New SelectStockJobber
                OBJSELECTGDN.TYPE = "PACKTOJOB"
                OBJSELECTGDN.JOBBER = CMBHASTE.Text.Trim
                OBJSELECTGDN.ShowDialog()
                DTGDN = OBJSELECTGDN.DT
            End If
            If DTGDN.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTGDN.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    If ALLOWBARCODEPRINT = True Or ALLOWPACKINGSLIP = True Then
                        For Each ROW As DataGridViewRow In GRIDGDN.Rows
                            If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Or (DTROWPS("BARCODE") = "" And Val(ROW.Cells(GFROMNO.Index).Value) = Val(DTROWPS("FROMNO")) And Val(ROW.Cells(GFROMSRNO.Index).Value) = Val(DTROWPS("FROMSRNO"))) Then GoTo LINE1
                        Next
                    End If

                    If Val(DTROWPS("PCS")) = 0 Then DTROWPS("PCS") = 1
                    If (ClientName <> "SAKARIA" And ClientName <> "ALENCOT" And ClientName <> "AVIS" And ClientName <> "MARKIN" And ClientName <> "DILIP" And ClientName <> "SHUBHI") AndAlso Val(DTROWPS("CUT")) = 0 Then DTROWPS("CUT") = Val(DTROWPS("MTRS"))

                    Dim PER As String = "Mtrs"
                    Dim CCRATE As Double = 0
                    Dim CUT As Double = 0

                    If ClientName = "SOFTAS" Or ClientName = "DEVEN" Or ClientName = "DILIP" Then CUT = 0 Else CUT = Format(Val(DTROWPS("CUT")), "0.00")

                    Dim OBJCMN As New ClsCommon
                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DTROWPS("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        If CHKRETAIL.CheckState = CheckState.Checked Then CCRATE = DTRATE.Rows(0).Item("SALERATE") Else CCRATE = DTRATE.Rows(0).Item("WRATE")
                        PER = "Pcs"
                    End If


                    'GET RATE FROM PRICELIST
                    If ClientName = "MYCOT" Or ClientName = "SBA" Then
                        Dim DTPRICELIST As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                        If DTPRICELIST.Rows.Count > 0 AndAlso DTPRICELIST.Rows(0).Item("COLNAME") <> "" Then
                            Dim DTRATE As DataTable = OBJCMN.search(DTPRICELIST.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DTROWPS("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then CCRATE = Val(DTRATE.Rows(0).Item("RATE"))
                        End If
                    End If



                    If ALLOWPACKINGSLIP = True Then
                        'WE NEED TO FETCH ALL THE DATA FROM BARCODESTOCK WITH RESPECT TO SELECTED FROMNO AND YEARID
                        'FOR MARKING WE NEED DETAILS AND FOR OTHERS WE WILL FETCH SUMMARY
                        Dim DTPS As DataTable = OBJCMN.search(" ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, JOBBERNAME, UNIT, SUM(PCS) AS PCS, CUT, SUM(MTRS) AS MTRS, BARCODE, LOTNO, FROMNO, FROMSRNO, TYPE, PIECETYPE, BALENO ", "", " BARCODESTOCK ", " GROUP BY ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, JOBBERNAME, UNIT, CUT, BARCODE, LOTNO, FROMNO, FROMSRNO, TYPE, PIECETYPE, BALENO, YEARID HAVING ROUND(SUM(MTRS),2) >0 AND GODOWN = '" & CMBGODOWN.Text.Trim & "' AND BARCODE = '' AND FROMNO = " & Val(DTROWPS("FROMNO")) & " AND FROMSRNO = " & Val(DTROWPS("FROMSRNO")) & "   AND YEARID = " & YearId)
                        For Each DTROWBARCODE As DataRow In DTPS.Rows
                            GRIDGDN.Rows.Add(0, DTROWBARCODE("PIECETYPE"), DTROWBARCODE("ITEMNAME"), DTROWBARCODE("QUALITY"), "", DTROWBARCODE("DESIGNNO"), DTROWBARCODE("COLOR"), DTROWBARCODE("BALENO"), Val(DTROWBARCODE("PCS")), DTROWBARCODE("UNIT"), CUT, Format(Val(DTROWBARCODE("MTRS")), "0.00"), CCRATE, PER, 0, DTROWBARCODE("BARCODE"), DTROWBARCODE("FROMNO"), DTROWBARCODE("FROMSRNO"), DTROWBARCODE("TYPE"), 0, 0, 0, "")
                        Next

                    Else
                        If ClientName = "SVS" Then
                            GRIDGDN.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), "", DTROWPS("DESIGNNO"), DTROWPS("COLOR"), "", 1, DTROWPS("UNIT"), Format(Val(DTROWPS("CUT")), "0.00"), Format(Val(DTROWPS("MTRS")), "0.00"), CCRATE, PER, 0, DTROWPS("BARCODE"), DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0, 0, 0, "")
                        Else
                            Dim GRIDDESC As String = ""
                            If ClientName = "AVIS" Then GRIDDESC = DTROWPS("LOTNO")
                            GRIDGDN.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), GRIDDESC, DTROWPS("DESIGNNO"), DTROWPS("COLOR"), DTROWPS("BALENO"), DTROWPS("LOTNO"), Val(DTROWPS("PCS")), DTROWPS("UNIT"), CUT, Format(Val(DTROWPS("MTRS")), "0.00"), CCRATE, PER, 0, DTROWPS("BARCODE"), DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"), 0, 0, 0, "")
                        End If
                    End If



LINE1:
                Next
                CMDSELECTSTOCK.Enabled = True
                getsrno(GRIDGDN)
                total()
                GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1
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

    Private Sub CMBJOBBER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHASTE.Enter
        Try
            If CMBHASTE.Text.Trim = "" Then filljobbername(CMBHASTE, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHASTE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBHASTE.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHASTE.Validating
        Try
            If CMBHASTE.Text.Trim <> "" Then namevalidate(CMBHASTE, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry Debtors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcity.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then cmbcity.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTRANSREMARKS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTTRANSREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTTRANSREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GDNDATE.GotFocus
        GDNDATE.SelectAll()
    End Sub

    Private Sub GDNDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GDNDATE.Validating
        Try
            If GDNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(GDNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQ As New SelectQuality
                OBJQ.FRMSTRING = "QUALITY"
                OBJQ.ShowDialog()
                If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New SelectDesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
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

    Private Sub TXTAMOUNT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If ClientName = "SKF" And CMBQUALITY.Text.Trim = "" Then
                MsgBox("Enter Proper Details")
                Exit Sub
            End If

            If ClientName = "PURVITEX" And CMBCOLOR.Text.Trim = "" Then
                MsgBox("Enter Shade Details")
                Exit Sub
            End If

            If CMBPIECETYPE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then
                If ClientName <> "MOMAI" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub
                FILLGRID()
                total()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        GRIDGDN.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDGDN.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, CMBITEMNAME.Text.Trim, CMBQUALITY.Text.Trim, TXTDESCRIPTION.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), "", Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMOUNT.Text.Trim), "0.00"), "", 0, 0, 0, 0, 0, 0, "")
            getsrno(GRIDGDN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDGDN.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDGDN.Item(GPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
            GRIDGDN.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDGDN.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDGDN.Item(GPRINTDESC.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
            GRIDGDN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDGDN.Item(GSHADE.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDGDN.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            GRIDGDN.Item(GGRIDLOTNO.Index, TEMPROW).Value = TXTGRIDLOTNO.Text.Trim
            GRIDGDN.Item(Gpcs.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDGDN.Item(GCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
            GRIDGDN.Item(Gmtrs.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDGDN.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDGDN.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDGDN.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")
            GRIDGDN.Item(GGRIDLOTNO.Index, TEMPROW).Value = TXTGRIDLOTNO.Text.Trim
            GRIDDOUBLECLICK = False

        End If

        CALC()
        total()

        GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1

        If ClientName <> "SKF" And ClientName <> "MANIBHADRA" And ClientName <> "ALENCOT" And ClientName <> "MNARESH" And ClientName <> "SOFTAS" And ClientName <> "RUCHITA" And ClientName <> "MOMAI" And ClientName <> "SMS" And ClientName <> "SHREEVALLABH" Then

            'FOR KOTHARI KEEP ONLY THESE 2 COLUMN AS IT IS
            If ClientName <> "KOTHARI" Then
                CMBPIECETYPE.Text = ""
                CMBQUALITY.Text = ""
            End If

            CMBITEMNAME.Text = ""
            TXTDESCRIPTION.Clear()
            CMBDESIGN.Text = ""
            CMBCOLOR.Text = ""
            TXTBALENO.Clear()
            TXTPCS.Clear()
            TXTCUT.Clear()
            TXTMTRS.Clear()
            TXTRATE.Clear()
            CMBPER.SelectedItem = Nothing
            TXTAMOUNT.Clear()
            CMBPIECETYPE.Focus()
        Else
            If ClientName <> "SKF" Then TXTMTRS.Clear()
            If ClientName = "RUCHITA" Then TXTDESCRIPTION.Clear()
            If ClientName = "MOMAI" Then
                CMBDESIGN.Text = ""
                TXTPCS.Clear()
                CMBDESIGN.Focus()
            Else
                TXTMTRS.Focus()
            End If
        End If
        txtsrno.Text = Val(GRIDGDN.RowCount) + 1

    End Sub

    Private Sub GRIDGDN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGDN.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDGDN.CurrentRow.Index >= 0 And GRIDGDN.Item(GSRNO.Index, GRIDGDN.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True

                txtsrno.Text = GRIDGDN.Item(GSRNO.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDGDN.Item(GPIECETYPE.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDGDN.Item(GITEMNAME.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDGDN.Item(GQUALITY.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDGDN.Item(GPRINTDESC.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDGDN.Item(GDESIGN.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBCOLOR.Text = GRIDGDN.Item(GSHADE.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDGDN.Item(GBALENO.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDGDN.Item(Gpcs.Index, GRIDGDN.CurrentRow.Index).Value.ToString

                TXTCUT.Text = GRIDGDN.Item(GCUT.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDGDN.Item(Gmtrs.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDGDN.Item(GRATE.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDGDN.Item(GPER.Index, GRIDGDN.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDGDN.Item(GAMOUNT.Index, GRIDGDN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDGDN.CurrentRow.Index
                CMBPIECETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPCS.KeyPress, TXTMTRS.KeyPress, TXTRATE.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = 0.0
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTPCS.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMOUNT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMOUNT.Text = Format(Val(TXTPCS.Text) * Val(TXTRATE.Text), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPER.Validated
        Try
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttransref_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttransref.Validating
        If txttransref.Text.Trim.Length > 0 And ClientName <> "KCRAYON" And ClientName <> "DJIMPEX" And ClientName <> "PARAS" And ClientName <> "SONU" Then
            If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txttransref.Text.Trim)) Then
                'for search
                Dim objclscommon As New ClsCommon()
                Dim dt As New DataTable
                dt = objclscommon.search(" GDN.GDN_TRANSREFNO AS CHALLANNO ", "", " GDN ", " and GDN_TRANSREFNO = '" & txttransref.Text.Trim & "' AND GDN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtgdnno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgdnno.KeyPress
        numkeypress(e, txtgdnno, Me)
    End Sub

    Private Sub txtgdnno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtgdnno.Validating
        Try
            If Val(txtgdnno.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GDN.GDN_NO,0)  AS GDNNO", "", " GDN ", "  AND GDN.GDN_NO=" & txtgdnno.Text.Trim & " AND GDN.GDN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Challan No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            GETMAXTYPECHALLANNO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXTYPECHALLANNO()
        Try
            'GET MAX NO WITH RESPECT TO SELECTED CHALLANTYPE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("isnull(max(GDN_TYPENO),0) + 1", "", "GDN INNER JOIN  CHALLANTYPEMASTER ON GDN_TYPEID = CHALLANTYPE_ID", " AND CHALLANTYPE_NAME = '" & CMBTYPE.Text.Trim & "' AND GDN_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTTYPECHALLANNO.Text = Val(DT.Rows(0).Item(0))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" And CMBDISPATCHTO.Text.Trim = "" Then CMBDISPATCHTO.Text = cmbname.Text.Trim

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(ACC_MOBILE,'') AS MOBILENO, ISNULL(ACC_HOLDFORAPPROVAL,0) AS HOLDFORAPPROVAL ", "", "CITYMASTER RIGHT OUTER JOIN LEDGERS ON CITYMASTER.city_id = LEDGERS.ACC_DELIVERYATID", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If cmbname.Text.Trim = CMBDISPATCHTO.Text.Trim Then cmbcity.Text = DT.Rows(0).Item(0)
                TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                If EDIT = False Then CHKHOLD.Checked = Convert.ToBoolean(DT.Rows(0).Item("HOLDFORAPPROVAL"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDISPATCHTO.Enter
        Try
            If ClientName = "AVIS" Then
                If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND GROUP_NAME = 'HASTE DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBDISPATCHTO.Text.Trim = "" Then fillname(CMBDISPATCHTO, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDISPATCHTO.Validating
        Try
            'If CMBDISPATCHTO.Text.Trim <> "" Then namevalidate(CMBDISPATCHTO, CMBCODE, e, Me, TXTDISPATCHADDRESS, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")

            'If CMBDISPATCHTO.Text.Trim <> "" And ClientName = "DAKSH" And ClientName = "PURVITEX" And ClientName = "SHALIBHADRA" Then
            If CMBDISPATCHTO.Text.Trim <> "" Then namevalidate(CMBDISPATCHTO, CMBCODE, e, Me, TXTDISPATCHADDRESS, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry CREDITORS", "ACCOUNTS")
            'Else
            'namevalidate(CMBDISPATCHTO, CMBCODE, e, Me, TXTDISPATCHADDRESS, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
            'End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALENOFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALENOFROM.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALENOTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALENOTO.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttransref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttransref.KeyPress
        If ClientName = "KENCOT" Then numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If EDIT = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True Then
            If TXTMOBILENO.Text.Trim = "" Then Exit Sub
            If ClientName = "KOTHARI" And CMBDISPATCHTO.Text.Trim = "" Then Exit Sub

            If MsgBox("Send SMS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim MSG As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            MSG = MSG & CMBDISPATCHTO.Text.Trim & " - " & cmbcity.Text.Trim & "\n"
            MSG = MSG & "GOODS READY" & "\n"
            MSG = MSG & "BALE NO." & txtgdnno.Text.Trim & " X " & TXTBALENOFROM.Text.Trim & "\n"
            For Each ROW As DataGridViewRow In GRIDGDN.Rows
                If ROW.Cells(GPER.Index).Value = "Mtrs" Then MSG = MSG & Val(ROW.Cells(GSRNO.Index).Value) & ") " & ROW.Cells(GITEMNAME.Index).Value & "-" & ROW.Cells(GPRINTDESC.Index).Value & " " & Format(Val(ROW.Cells(Gmtrs.Index).Value), "0.00") & " " & ROW.Cells(GPER.Index).Value & "\n" Else MSG = MSG & Val(ROW.Cells(GSRNO.Index).Value) & ") " & ROW.Cells(GITEMNAME.Index).Value & "-" & ROW.Cells(GPRINTDESC.Index).Value & "-" & Format(Val(ROW.Cells(Gpcs.Index).Value), "0") & " " & ROW.Cells(GPER.Index).Value & " " & "-" & " " & Format(Val(ROW.Cells(Gmtrs.Index).Value), "0.00") & " " & "MTRS" & "\n"
            Next

            If SENDMSG(MSG, TXTMOBILENO.Text.Trim) = "1701" Then
                MsgBox("Message Sent")
                DT = OBJCMN.Execute_Any_String("UPDATE GDN SET GDN_SMSSEND = 1 WHERE GDN_NO = " & TEMPGDNNO & " AND GDN_YEARID = " & YearId, "", "")
                LBLSMS.Visible = True
            Else
                MsgBox("Error Sending Message")
            End If
        End If
    End Sub

    Private Sub TXTMTRS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMTRS.Validating
        Try
            If ClientName = "MANIBHADRA" Then TXTAMOUNT_Validating(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDORDER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDORDER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDORDER.RowCount > 0 Then GRIDORDER.Rows.RemoveAt(GRIDORDER.CurrentRow.Index)
            getsrno(GRIDORDER)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(sender As Object, e As EventArgs) Handles TXTCUT.Validated, TXTPCS.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 And Val(TXTPCS.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTPCS.Text.Trim) * Val(TXTCUT.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If EDIT = True Then SENDWHATSAPP(TEMPGDNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(GDNNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJGDN As New GDNDESIGN
            OBJGDN.MdiParent = MDIMain
            OBJGDN.DIRECTPRINT = True
            OBJGDN.FRMSTRING = "GDN"
            OBJGDN.DIRECTMAIL = True
            OBJGDN.vendorname = cmbname.Text.Trim
            OBJGDN.agentname = CMBAGENT.Text.Trim
            OBJGDN.FORMULA = "{GDN.GDN_no}=" & Val(GDNNO) & " and {GDN.GDN_yearid}=" & YearId
            OBJGDN.JONO = GDNNO
            OBJGDN.NOOFCOPIES = 1
            OBJGDN.WHITELABEL = CHKWHITELABEL.Checked
            OBJGDN.HIDEPCSDETAILS = CHKHIDEPCS.Checked
            OBJGDN.PRINTINYARDS = CHKYARD.Checked
            OBJGDN.Show()
            OBJGDN.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = cmbname.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            If cmbname.Text.Trim <> CMBDISPATCHTO.Text.Trim Then OBJWHATSAPP.OTHERNAME1 = CMBDISPATCHTO.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\GDN_" & Val(GDNNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("GDN_" & Val(GDNNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBITEMNAME.Validated
        Try
            If ClientName = "SOFTAS" And CMBITEMNAME.Text.Trim <> "" Then TXTDESCRIPTION.Text = CMBITEMNAME.Text.Trim
            If ClientName = "SMS" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT ISNULL(ITEMMASTER.ITEM_REORDER,0) AS CUT FROM ITEMMASTER WHERE ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' AND ITEM_YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then TXTCUT.Text = Val(DT.Rows(0).Item("CUT"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDISPATCHTO_Validated(sender As Object, e As EventArgs) Handles CMBDISPATCHTO.Validated
        Try
            If CMBDISPATCHTO.Text.Trim <> "" And (EDIT = False Or ClientName = "KOTHARI") Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(ACC_MOBILE,'') AS MOBILENO, ISNULL(ACC_HOLDFORAPPROVAL,0) AS HOLDFORAPPROVAL ", "", "CITYMASTER RIGHT OUTER JOIN LEDGERS ON CITYMASTER.city_id = LEDGERS.ACC_DELIVERYATID", " AND LEDGERS.ACC_CMPNAME = '" & CMBDISPATCHTO.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbcity.Text = DT.Rows(0).Item("CITY")
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    CHKHOLD.Checked = Convert.ToBoolean(DT.Rows(0).Item("HOLDFORAPPROVAL"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    If ClientName = "REAL" Then

                        'CHECK WHETHER ORDER FOR THE SAME IS PRESENT OR NOT, IF NOT THEN DONT ALLOW 
                        If GRIDORDER.RowCount = 0 Then
                            MsgBox("Please Select Sale Order First")
                            TXTBARCODE.Clear()
                            Exit Sub
                        End If

                        'CHECKING WHETHER ORDER FOR SAME ITEM | DESIGN AND SHADE IS PRESENT IN ORDERGRID OR NOT
                        'IF NOT PRESENT THEN VALIDATE
                        For Each ROW As DataGridViewRow In GRIDORDER.Rows
                            If ROW.Cells(OITEMNAME.Index).Value = DT.Rows(0).Item("ITEMNAME") And ROW.Cells(ODESIGN.Index).Value = DT.Rows(0).Item("DESIGNNO") And ROW.Cells(OCOLOR.Index).Value = DT.Rows(0).Item("COLOR") Then
                                GoTo LINEORDERPASS
                            End If
                        Next
                        'IF CODE COMES HERE MEANS ITEM | DESIGN | COLOR DOES NOT MATCH IN ORDERGRID, THEN DONT ALLOW TO PROCEED FURTHER
                        MsgBox("Item Not Present in Order Grid, Please select Order First")
                        TXTBARCODE.Clear()
                        Exit Sub


LINEORDERPASS:
                    End If

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim And ClientName <> "SANGHVI" Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDGDN.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PER As String = "Mtrs"
                    Dim GRIDREMARKS As String = ""
                    Dim RATE As Double = 0
                    Dim PCS As Double = 0

                    If ClientName = "TCOT" Or ClientName = "KCRAYON" Or ClientName = "SBA" Or ClientName = "AXIS" Or ClientName = "KRISHNA" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    If ClientName = "CC" Or ClientName = "SHREEDEV" Then
                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        If CHKRETAIL.CheckState = CheckState.Checked Then RATE = DTRATE.Rows(0).Item("SALERATE") Else RATE = DTRATE.Rows(0).Item("WRATE")
                        PER = "Pcs"
                    End If

                    'getting per from itemmaster
                    If ClientName = "AXIS" Then
                        Dim DTPER As DataTable = OBJCMN.search("ISNULL(UNIT_ABBR,'Mtrs') AS PER", "", " ITEMMASTER LEFT OUTER JOIN UNITMASTER ON item_unitid = UNIT_ID ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId)
                        If DTPER.Rows.Count > 0 Then
                            If DTPER.Rows(0).Item("PER") = "Pcs" Then PER = "Pcs"
                        End If
                    End If


                    'GET RATE
                    'FOR THIS WE NEED TO GET THE COLUMN NAME FROM RATETYPEMASREER 
                    If ClientName = "SBA" Or ClientName = "MYCOT" Then
                        Dim DTRATE As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_PRICELISTCOLUMN, '') AS COLNAME", "", " LEDGERS ", " AND ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                        If DTRATE.Rows.Count > 0 AndAlso DTRATE.Rows(0).Item("COLNAME") <> "" Then
                            DTRATE = OBJCMN.search(DTRATE.Rows(0).Item("COLNAME") & " AS RATE", "", "ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMPRICELIST.ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
                        End If
                    End If


                    If ClientName = "KENCOT" Or ClientName = "SAFFRON" Or ClientName = "NTC" Then GRIDREMARKS = DT.Rows(0).Item("GRIDREMARKS")



                        'GET RATE FROM PRICELISTMASTER
                        If ClientName = "MOMAI" Then
                            Dim WHERECLAUSE As String = ""
                            If DT.Rows(0).Item("ITEMNAME") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMMASTER.ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "'"
                            If DT.Rows(0).Item("DESIGNNO") <> "" Then WHERECLAUSE = WHERECLAUSE & " AND DESIGNMASTER.DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "'"
                            Dim DTRATE As DataTable = OBJCMN.search("ISNULL(PL_RATE,0) AS RATE", "", "PRICELISTMASTER LEFT OUTER JOIN ITEMMASTER ON PL_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON PL_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON PL_COLORID = COLORMASTER.COLOR_ID", WHERECLAUSE & " AND PL_YEARID = " & YearId)
                            If DTRATE.Rows.Count > 0 Then RATE = Val(DTRATE.Rows(0).Item("RATE"))
                        End If

                        If ClientName = "GELATO" Then PER = "Pcs"

                    GRIDGDN.Rows.Add(GRIDGDN.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), GRIDREMARKS, DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DT.Rows(0).Item("BALENO"), DT.Rows(0).Item("LOTNO"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), RATE, PER, 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0, 0, 0, "")
                    total()
                        GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1


LINE1:
                        TXTBARCODE.Clear()
                        TXTBARCODE.Focus()
                    Else
                        MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If

            'OLDCODE
            '            If Len(TXTBARCODE.Text.Trim) > 7 Then

            '                'GET DATA FROM BARCODE
            '                Dim OBJCMN As New ClsCommon
            '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            '                If DT.Rows.Count > 0 Then
            '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
            '                    For Each ROW As DataGridViewRow In GRIDGDN.Rows
            '                        If ROW.Cells(GBARCODE.Index).Value = TXTBARCODE.Text.Trim Then GoTo LINE1
            '                    Next
            '                    GRIDGDN.Rows.Add(GRIDGDN.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", 1, Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
            '                    total()
            '                    GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1

            'LINE1:
            '                    TXTBARCODE.Clear()
            '                Else
            '                    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
            '                    GoTo LINE1
            '                    Exit Sub
            '                End If
            '            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
