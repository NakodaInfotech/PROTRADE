
Imports System.ComponentModel
Imports BL

Public Class YarnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPYARNNO As Integer     'used for poation no while editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        CMBGODOWN.Text = ""
        CMBNAME.Enabled = True
        CMBNAME.Text = ""

        TXTSONO.Clear()
        SODATE.Value = Now.Date
        CMBTRANSPORT.Text = ""
        TXTREFNO.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        txtadd.Clear()
        YARNDATE.Text = Now.Date

        txtremarks.Clear()


        'clearing itemgrid textboxes and combos
        txtsrno.Text = 1
        CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        GRIDYARN.RowCount = 0
        GRIDORDER.RowCount = 0

        CMDSELECTSO.Enabled = True
        GRIDDOUBLECLICK = False

        getmaxno()


        LBLTOTALCONES.Text = 0
        lbltotalqty.Text = 0
        LBLTOTALWT.Text = 0

    End Sub

    Sub total()
        Try
            LBLTOTALCONES.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDYARN.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub GRNDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles YARNDATE.GotFocus
        YARNDATE.SelectAll()
    End Sub

    Private Sub GRNDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles YARNDATE.Validating
        Try
            If YARNDATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(YARNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Dim DTTABLE As DataTable = getmax(" isnull(max(YARN_no),0) + 1 ", "YARNCHALLAN", " and YARN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTYARNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown Name ")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Entry Locked, Invoice Made")
                bln = False
            End If

            If GRIDYARN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(ORECDBAGS.Index).Value = 0
                    ORDROW.Cells(ORECDWT.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                TXTSONO.Clear()
                For Each a As String In MULTISONO
                    If TXTSONO.Text = "" Then
                        TXTSONO.Text = a
                    Else
                        TXTSONO.Text = TXTSONO.Text & "," & a
                    End If
                Next

                For Each ROW As DataGridViewRow In GRIDYARN.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(GYARNQUALITY.Index).Value = ORDROW.Cells(OYARNQUALITY.Index).Value And ROW.Cells(GDESIGN.Index).Value = ORDROW.Cells(ODESIGN.Index).Value And ROW.Cells(gcolor.Index).Value = ORDROW.Cells(OCOLOR.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(ORECDWT.Index).Value) >= Val(ORDROW.Cells(OWT.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If
                            ORDROW.Cells(ORECDBAGS.Index).Value = Val(ORDROW.Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                            ORDROW.Cells(ORECDWT.Index).Value = Val(ORDROW.Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDBAGS.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORECDWT.Index).Value) + Val(ROW.Cells(GWT.Index).Value)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(CMBNAME, "There are Items which are not Present in Selected Order")
                            bln = False
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next
            End If


            If YARNDATE.Text = "__/__/____" Then
                EP.SetError(YARNDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(YARNDATE.Text) Then
                    EP.SetError(YARNDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If


            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(YARNDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(Format(SODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALCONES.Text))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim YARNQUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim LOTNO As String = ""
            Dim qty As String = ""
            Dim WT As String = ""
            Dim CONES As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDYARN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value)
                        WT = Val(row.Cells(GWT.Index).Value)
                        CONES = Val(row.Cells(GCONES.Index).Value)

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        YARNQUALITY = YARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(YARNQUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(qty)
            alParaval.Add(WT)
            alParaval.Add(CONES)


            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERYARNQUALITY As String = ""
            Dim ORDERDESIGN As String = ""
            Dim ORDERCOLOR As String = ""
            Dim ORDERBAGS As String = ""
            Dim ORDERWT As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERRECDBAGS As String = ""
            Dim ORDERRECDWT As String = ""
            Dim ORDERRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(ORECDBAGS.Index).Value) > 0 Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERDESIGN = row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERYARNQUALITY = ORDERYARNQUALITY & "|" & row.Cells(OYARNQUALITY.Index).Value.ToString
                        ORDERDESIGN = ORDERDESIGN & "|" & row.Cells(ODESIGN.Index).Value.ToString
                        ORDERCOLOR = ORDERCOLOR & "|" & row.Cells(OCOLOR.Index).Value.ToString
                        ORDERBAGS = ORDERBAGS & "|" & Val(row.Cells(OBAGS.Index).Value)
                        ORDERWT = ORDERWT & "|" & Val(row.Cells(OWT.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERRECDBAGS = ORDERRECDBAGS & "|" & Val(row.Cells(ORECDBAGS.Index).Value)
                        ORDERRECDWT = ORDERRECDWT & "|" & Val(row.Cells(ORECDWT.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERYARNQUALITY)
            alParaval.Add(ORDERDESIGN)
            alParaval.Add(ORDERCOLOR)
            alParaval.Add(ORDERBAGS)
            alParaval.Add(ORDERWT)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERRECDBAGS)
            alParaval.Add(ORDERRECDWT)
            alParaval.Add(ORDERRATE)


            Dim objclsGRN As New ClsYarnChallan()
            objclsGRN.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                TXTYARNNO.Text = Val(DTTABLE.Rows(0).Item(0))
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPYARNNO)

                Dim IntResult As Integer = objclsGRN.UPDATE()
                MsgBox("Details Updated")
            End If

            PRINTREPORT()
            EDIT = False

            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Yarn Challan?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJPUR As New YarnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "YARNCHALLAN"
                OBJPUR.WHERECLAUSE = "{YARNCHALLAN.YARN_NO}=" & Val(TXTYARNNO.Text.Trim) & " and {YARNCHALLAN.YARN_YEARID}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDYARN.Focus()
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'YARN RECD'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsYARN As New ClsYarnChallan()
                Dim dttable As DataTable = objclsYARN.SELECTYARN(TEMPYARNNO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTYARNNO.Text = TEMPYARNNO
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        YARNDATE.Text = Format(Convert.ToDateTime(dr("YARNDATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        TXTSONO.Text = Convert.ToString(dr("SONO").ToString)
                        SODATE.Value = Format(Convert.ToDateTime(dr("SODATE")).Date, "dd/MM/yyyy")
                        CMBTRANSPORT.Text = dr("TRANSNAME").ToString
                        TXTREFNO.Text = dr("REFNO").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        GRIDYARN.Rows.Add(Val(dr("GRIDSRNO")), dr("YARNQUALITY"), dr("MILLNAME"), dr("DESIGNNO"), dr("COLOR"), dr("LOTNO"), Format(dr("qty"), "0.00"), Format(dr("WT"), "0.00"), Format(dr("CONES"), "0.00"))

                        If Val(dr("OUTWT")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    total()
                Else
                    EDIT = False
                    clear()
                End If

                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" YARNCHALLAN_SODETAILS.YARN_GRIDSRNO AS GRIDSRNO, YARNQUALITYMASTER.YARN_name AS YARNQUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, YARNCHALLAN_SODETAILS.YARN_ORDERBAGS AS ORDERBAGS, ISNULL(YARNCHALLAN_SODETAILS.YARN_ORDERWT,0) AS ORDERWT, YARNCHALLAN_SODETAILS.YARN_FROMNO AS FROMNO, YARNCHALLAN_SODETAILS.YARN_FROMSRNO AS FROMSRNO, YARNCHALLAN_SODETAILS.YARN_FROMTYPE AS FROMTYPE, YARNCHALLAN_SODETAILS.YARN_BAGS AS RECDBAGS, ISNULL(YARNCHALLAN_SODETAILS.YARN_WT,0) AS RECDWT, ISNULL(YARNCHALLAN_SODETAILS.YARN_RATE,0) AS RATE ", "", " YARNCHALLAN_SODETAILS INNER JOIN YARNQUALITYMASTER ON YARNCHALLAN_SODETAILS.YARN_YARNQUALITYID= YARNQUALITYMASTER.YARN_id LEFT OUTER JOIN COLORMASTER ON YARNCHALLAN_SODETAILS.YARN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON YARNCHALLAN_SODETAILS.YARN_DESIGNID = DESIGNMASTER.DESIGN_id  ", " AND YARNCHALLAN_SODETAILS.YARN_NO = " & TEMPYARNNO & " AND YARNCHALLAN_SODETAILS.YARN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("YARNQUALITY"), DTR("DESIGNNO"), DTR("COLOR"), Val(DTR("ORDERBAGS")), Val(DTR("ORDERWT")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("RECDBAGS")), Val(DTR("RECDWT")), Val(DTR("RATE")))
                    Next
                End If
                getsrno(GRIDORDER)

                If TXTSONO.Text.Trim.Trim.Length = 0 Then
                    CMDSELECTSO.Enabled = False
                    CMBNAME.Enabled = True
                Else
                    CMDSELECTSO.Enabled = True
                    CMBNAME.Enabled = False
                End If

            End If

            If GRIDYARN.RowCount > 0 Then
                txtsrno.Text = Val(GRIDYARN.Rows(GRIDYARN.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' and ACC_TYPE = 'ACCOUNTS'")
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ACC_TYPE = 'TRANSPORT'")

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            FILLMILL(CMBMILL, EDIT)
            FILLDESIGN(CMBDESIGN, "")
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgrndetails As New YarnChallanDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMDSELECTSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSO.Click
        Try

            If CMBNAME.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJSELECTSO As New SelectYarnSO
            OBJSELECTSO.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTSO.ShowDialog()
            DTPO = OBJSELECTSO.DT

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT SONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTSONO.Text.Trim = "" Then
                        TXTSONO.Text = DTR("SONO").ToString
                    Else
                        TXTSONO.Text = TXTSONO.Text & "," & DTR("SONO").ToString
                    End If
                Next

                CMBNAME.Text = DTPO.Rows(0).Item("NAME")
                SODATE.Value = DTPO.Rows(0).Item("SODATE")
                TXTSONO.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("SONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next

                    GRIDORDER.Rows.Add(0, DTROW("YARNQUALITY"), DTROW("DESIGNNO"), DTROW("COLOR"), Val(DTROW("BAGS")), Val(DTROW("WT")), DTROW("SONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))

                    'CHECK WHERTHER STOCK IS PRESENT OR NOT, IF PRESENT THEN ADD THAT ITEM IN ITEMGRID
                    If ClientName = "VAISHALI" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DTSTOCK As DataTable = OBJCMN.search("ISNULL(SUM(BAGS),0) AS BAGS", "", " YARNSTOCKVIEW ", " AND YARNQUALITY = '" & DTROW("YARNQUALITY") & "' AND COLOR = '" & DTROW("COLOR") & "' AND YEARID = " & YearId & " HAVING ISNULL(SUM(BAGS),0) > 0 ")
                        If DTPO.Rows.Count > 0 Then GRIDYARN.Rows.Add(0, DTROW("YARNQUALITY"), "", DTROW("DESIGNNO"), DTROW("COLOR"), "", Val(DTROW("BAGS")), Val(DTROW("WT")), 0)
                    End If

NEXTLINE:
                Next
                getsrno(GRIDORDER)

            End If

            CMDSELECTSO.Enabled = True
            total()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDYARN.RowCount = 0
                TEMPYARNNO = Val(tstxtbillno.Text)
                If TEMPYARNNO > 0 Then
                    EDIT = True
                    GRN_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDYARN.Enabled = True
        Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
        If GRIDDOUBLECLICK = False Then
            GRIDYARN.Rows.Add(Val(txtsrno.Text.Trim), CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), Format(Val(TXTCONES.Text.Trim), "0.00"))
            getsrno(GRIDYARN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDYARN.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDYARN.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDYARN.Item(GMILLNAME.Index, TEMPROW).Value = CMBMILL.Text.Trim

            GRIDYARN.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDYARN.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDYARN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDYARN.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text.Trim), "0.00")
            GRIDYARN.Item(GWT.Index, TEMPROW).Value = Format(Val(TXTWT.Text.Trim), "0.00")

            GRIDYARN.Item(GCONES.Index, TEMPROW).Value = Format(Val(TXTCONES.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False

        End If

        total()

        GRIDYARN.FirstDisplayedScrollingRowIndex = GRIDYARN.RowCount - 1


        If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
        CMBMILL.Text = ""
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTLOTNO.Clear()
        txtqty.Clear()
        TXTWT.Clear()
        TXTCONES.Clear()
        txtsrno.Text = Val(GRIDYARN.Rows(GRIDYARN.RowCount - 1).Cells(0).Value) + 1
        CMBYARNQUALITY.Focus()


    End Sub

    Sub EDITROW()
        Try
            If GRIDYARN.CurrentRow.Index >= 0 And GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDYARN.Item(gsrno.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = GRIDYARN.Item(GYARNQUALITY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                CMBMILL.Text = GRIDYARN.Item(GMILLNAME.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                CMBDESIGN.Text = GRIDYARN.Item(GDESIGN.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDYARN.Item(gcolor.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDYARN.Item(GLOTNO.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDYARN.Item(GQTY.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDYARN.Item(GWT.Index, GRIDYARN.CurrentRow.Index).Value.ToString
                TXTCONES.Text = GRIDYARN.Item(GCONES.Index, GRIDYARN.CurrentRow.Index).Value.ToString

                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDYARN.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) - 1
            If TEMPYARNNO > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO > 1 Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDYARN.RowCount = 0
LINE1:
            TEMPYARNNO = Val(TXTYARNNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTYARNNO.Text.Trim
            clear()
            If Val(TXTYARNNO.Text) - 1 >= TEMPYARNNO Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDYARN.RowCount = 0 And TEMPYARNNO < MAXNO Then
                TXTYARNNO.Text = TEMPYARNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTCONES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTYARNNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsYarnChallan()
                    Clsgrn.alParaval = alParaval
                    IntResult = Clsgrn.DELETE()
                    MsgBox("Yarn Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDYARN.CellValidating
        Try

            Dim colNum As Integer = GRIDYARN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index, GWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDYARN.CurrentCell.Value = Nothing Then GRIDYARN.CurrentCell.Value = "0.00"
                        GRIDYARN.CurrentCell.Value = Convert.ToDecimal(GRIDYARN.Item(colNum, e.RowIndex).Value)
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDYARN.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDYARN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDYARN.Rows.RemoveAt(GRIDYARN.CurrentRow.Index)
                getsrno(GRIDYARN)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(sender As Object, e As EventArgs) Handles cmbcolor.Enter
        Try
            FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry DEBTORS", "ACCOUNTS", CMBTRANSPORT.Text, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Validated
        Try
            If CMBYARNQUALITY.Text = "" Then cmdok.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "")
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

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANSPORT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORT.Text = OBJLEDGER.TEMPNAME
            End If
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

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcolor.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then cmbcolor.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub CMBMILL_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then FILLMILL(CMBMILL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_Validated(sender As Object, e As EventArgs) Handles TXTCONES.Validated
        Try
            If CMBYARNQUALITY.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And Val(TXTWT.Text.Trim) > 0 Then

                'check whether same quality and shade is present in grid or not
                If ClientName = "VAISHALI" And cmbcolor.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDYARN.Rows
                        If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And ROW.Index <> TEMPROW) Then
                            If ROW.Cells(GYARNQUALITY.Index).Value = CMBYARNQUALITY.Text.Trim And ROW.Cells(gcolor.Index).Value = cmbcolor.Text.Trim Then
                                If MsgBox("Quality with same Shade already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                            End If
                        End If
                    Next
                End If

                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCONES_Validating(sender As Object, e As CancelEventArgs) Handles TXTCONES.Validating
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM MILLMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(TXTCONES.Text.Trim) <> 0 And CMBMILL.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(MILL_REMARK,0) AS CONEWT", "", "MILLMASTER ", " AND MILL_NAME = '" & CMBMILL.Text.Trim & "' AND MILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(TXTCONES.Text.Trim) * Val(DT.Rows(0).Item("CONEWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validated(sender As Object, e As EventArgs) Handles txtqty.Validated
        Try
            If ClientName = "VAISHALI" Then
                'FETCH CONEWT FROM YARNQUALITYMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(txtqty.Text.Trim) <> 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_BOXTUBEWT,0) AS BOXWT", "", "YARNQUALITYMASTER ", " AND YARN_NAME = '" & CMBYARNQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(txtqty.Text.Trim) * Val(DT.Rows(0).Item("BOXWT")), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class