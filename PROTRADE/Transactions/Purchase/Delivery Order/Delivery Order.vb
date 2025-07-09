Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.Net


Public Class DeliveryOrder
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPUPLOADROW, PURREGID As Integer
    Public EDIT As Boolean
    Public TEMPDONO As Integer
    Public Shared selectGRNtable As New DataTable
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        DTDODATE.Focus()
    End Sub

    Sub clear()

        DTDODATE.Text = Mydate
        tstxtbillno.Clear()

        TXTSERIES.Clear()
        cmbtrans.Text = ""
        cmbcode.Text = ""
        cmbGodown.Text = ""
        CMBOURGODOWN.Text = ""
        cmbname.Text = ""
        TXTNAME.Clear()
        LIFTINGDATE.Clear()
        TXTEWBNO.Clear()
        CMDSELECTSTOCK.Enabled = True
        TXTVEHICLENO.Clear()
        TXTTIME.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTADD.Clear()

        EP.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        txtremarks.Clear()

        GRIDDO.RowCount = 0

        getmax_BILL_no()

        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        LBLTOTALBAGS.Text = 0
        LBLTOTALWT.Text = 0.0

        TabControl1.SelectedIndex = 0

        PBSOFTCOPY.Image = Nothing
        TXTUPLOADSRNO.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0


        If gridupload.RowCount > 0 Then
            TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTUPLOADSRNO.Text = 1
        End If

    End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DO_NO),0) + 1 ", "  DELIVERYORDER ", " AND DO_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTDONO.Text = DTTABLE.Rows(0).Item(0)
        End If

        GETMAXSERIES(TXTSERIES)
    End Sub

    Private Sub DeliveryOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'for grid foucs
                GRIDDO.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS' AND (LEDGERS.ACC_SUBTYPE = 'WARPER' OR LEDGERS.ACC_SUBTYPE = 'SIZER' OR LEDGERS.ACC_SUBTYPE = 'WEAVER' or LEDGERS.ACC_SUBTYPE = 'PROCESSOR' or LEDGERS.ACC_SUBTYPE = 'JOBBER')")
        If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, False)
    End Sub

    Private Sub DeliveryOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            clear()
            CMBOURGODOWN.Text = GETDEFAULTGODOWN()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsDO As New ClsDeliveryOrder
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPDONO)
                ALPARAVAL.Add(YearId)
                objclsDO.alParaval = ALPARAVAL
                Dim dttable As DataTable = objclsDO.selectDO()

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSERIES.Text = Val(dr("SERIES"))
                        TXTDONO.Text = TEMPDONO
                        DTDODATE.Text = Format(Convert.ToDateTime(dr("DODATE")).Date, "dd/MM/yyyy")
                        TXTNAME.Text = Convert.ToString(dr("NAME").ToString)
                        'cmbname.Enabled = False


                        'COZ MULTIPLE GODOWNS CAN COME IN ONE DO
                        If ClientName <> "JASHOK" Then cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        CMBOURGODOWN.Text = dr("OURGODOWN").ToString
                        cmbname.Text = Convert.ToString(dr("JOBBERNAME").ToString)
                        LIFTINGDATE.Text = dr("LIFTINGDATE")
                        TXTEWBNO.Text = dr("EWBNO")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        TXTVEHICLENO.Text = Convert.ToString(dr("VEHICLENO").ToString)
                        TXTTIME.Text = Convert.ToString(dr("TIME").ToString)
                        TXTTAXABLEAMT.Text = Val(dr("TAXABLEAMT"))

                        Dim TEMPLRDATE, TEMPLIFTINGDATE As String
                        TEMPLIFTINGDATE = ""
                        TEMPLRDATE = ""
                        TEMPLRDATE = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")


                        'If dr("GRIDLIFTING") <> "" Then TEMPLIFTINGDATE = dr("GRIDLIFTING").ToString.Substring(3, Len(dr("GRIDLIFTING")) - 7) & dr("GRIDLIFTING").ToString.Substring(0, 3) & dr("GRIDLIFTING").ToString.Substring(6, Len(dr("GRIDLIFTING")) - 6)
                        If IsDBNull(dr("GRIDLIFTING")) = True Then TEMPLIFTINGDATE = "" Else TEMPLIFTINGDATE = Format(Convert.ToDateTime(dr("GRIDLIFTING")).Date, "dd/MM/yyyy")

                        'Item Grid
                        GRIDDO.Rows.Add(dr("GRIDSRNO").ToString, dr("QUALITY").ToString, dr("MILLNAME").ToString, Val(dr("BAGS")), Val(dr("WT")), dr("LOTNO"), dr("SHADE"), Val(dr("CONES")), dr("LRNO").ToString, TEMPLRDATE, TEMPLIFTINGDATE, dr("GRIDTRANS").ToString, dr("GRIDGODOWN"), Format(Val(dr("CHGS")), "0.00"), dr("GRNNO"), dr("GRNSRNO"), dr("GRIDTYPE"), dr("GRIDDONE"), Val(dr("OUTBAGS")), Val(dr("OUTWT")), Val(dr("OUTCONES")), dr("SUPPLIERNAME"))

                        If Val(dr("OUTBAGS")) > 0 Or Val(dr("OUTWT")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    'CMDSELECTSTOCK.Enabled = False
                    total()
                Else
                    EDIT = False
                    clear()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" DO_SRNO AS GRIDSRNO, DO_REMARKS AS REMARKS, DO_NAME AS NAME, DO_PHOTO AS IMGPATH ", "", " DELIVERYORDER_UPLOAD", " AND DO_NO = " & TEMPDONO & " AND DO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(DTDODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(CMBOURGODOWN.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(LIFTINGDATE.Text)
            alParaval.Add(TXTEWBNO.Text)
            alParaval.Add(Val(LBLTOTALBAGS.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALCONES.Text.Trim))
            alParaval.Add(Val(LBLTOTALCHGS.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(TXTTIME.Text.Trim)
            alParaval.Add(Val(TXTTAXABLEAMT.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim QUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim BAGS As String = ""
            Dim WT As String = ""
            Dim LOTNO As String = ""
            Dim COLOR As String = ""
            Dim CONES As String = ""
            Dim LRNO As String = ""
            Dim LRDATE As String = ""
            Dim GRIDLIFTING As String = ""
            Dim TRANSPORT As String = ""
            Dim GODOWN As String = ""
            Dim GODOWNCHGS As String = ""
            Dim GRNNO As String = ""        'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNGRIDSRNO As String = ""   'value of GRNGRIDSRNO
            Dim GRIDDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRIDTYPE As String = ""
            Dim OUTBAGS As String = ""
            Dim OUTWT As String = ""
            Dim OUTCONES As String = ""
            Dim SUPPLIERNAME As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        MILLNAME = row.Cells(GMILLNAME.Index).Value.ToString
                        BAGS = Val(row.Cells(gBag.Index).Value)
                        WT = Val(row.Cells(Gwt.Index).Value)
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        COLOR = row.Cells(GCOLOR.Index).Value
                        CONES = Val(row.Cells(GCONES.Index).Value)

                        LRNO = row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value), "MM/dd/yyyy")
                        If row.Cells(GLIFTING.Index).Value <> "" Then GRIDLIFTING = Format(Convert.ToDateTime(row.Cells(GLIFTING.Index).Value), "MM/dd/yyyy") Else GRIDLIFTING = ""
                        TRANSPORT = row.Cells(GTRANSPORT.Index).Value.ToString
                        GODOWN = row.Cells(GGODOWN.Index).Value.ToString
                        GODOWNCHGS = Val(row.Cells(GCHGS.Index).Value)
                        GRNNO = Val(row.Cells(GGRNNO.Index).Value)
                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = row.Cells(GGRNSRNO.Index).Value
                        Else
                            GRNGRIDSRNO = 0
                        End If
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = "1"
                        Else
                            GRIDDONE = "0"
                        End If
                        GRIDTYPE = row.Cells(GGRIDTYPE.Index).Value.ToString
                        OUTBAGS = Val(row.Cells(GOUTBAGS.Index).Value)
                        OUTWT = Val(row.Cells(GOUTWT.Index).Value)
                        OUTCONES = Val(row.Cells(GOUTCONES.Index).Value)
                        SUPPLIERNAME = row.Cells(GNAME.Index).Value.ToString
                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        MILLNAME = MILLNAME & "|" & row.Cells(GMILLNAME.Index).Value.ToString
                        BAGS = BAGS & "|" & Val(row.Cells(gBag.Index).Value)
                        WT = WT & "|" & Val(row.Cells(Gwt.Index).Value)
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value
                        CONES = CONES & "|" & Val(row.Cells(GCONES.Index).Value)

                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value.ToString
                        LRDATE = LRDATE & "|" & Format(Convert.ToDateTime(row.Cells(GLRDATE.Index).Value), "MM/dd/yyyy")
                        If row.Cells(GLIFTING.Index).Value <> "" Then GRIDLIFTING = GRIDLIFTING & "|" & Format(Convert.ToDateTime(row.Cells(GLIFTING.Index).Value), "MM/dd/yyyy") Else GRIDLIFTING = GRIDLIFTING & "|" & ""
                        TRANSPORT = TRANSPORT & "|" & row.Cells(GTRANSPORT.Index).Value.ToString
                        GODOWN = GODOWN & "|" & row.Cells(GGODOWN.Index).Value.ToString
                        GODOWNCHGS = GODOWNCHGS & "|" & Val(row.Cells(GCHGS.Index).Value)
                        GRNNO = GRNNO & "|" & Val(row.Cells(GGRNNO.Index).Value)
                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & Val(row.Cells(GGRNSRNO.Index).Value)
                        Else
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & " 0"
                        End If

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = GRIDDONE & "|" & "1"
                        Else
                            GRIDDONE = GRIDDONE & "|" & "0"
                        End If
                        GRIDTYPE = GRIDTYPE & "|" & row.Cells(GGRIDTYPE.Index).Value.ToString
                        OUTBAGS = OUTBAGS & "|" & Val(row.Cells(GOUTBAGS.Index).Value)
                        OUTWT = OUTWT & "|" & Val(row.Cells(GOUTWT.Index).Value)
                        OUTCONES = OUTCONES & "|" & Val(row.Cells(GOUTCONES.Index).Value)
                        SUPPLIERNAME = SUPPLIERNAME & "|" & row.Cells(GNAME.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(QUALITY)
            alParaval.Add(MILLNAME)
            alParaval.Add(BAGS)
            alParaval.Add(WT)
            alParaval.Add(LOTNO)
            alParaval.Add(COLOR)
            alParaval.Add(CONES)
            alParaval.Add(LRNO)
            alParaval.Add(LRDATE)
            alParaval.Add(GRIDLIFTING)
            alParaval.Add(TRANSPORT)
            alParaval.Add(GODOWN)
            alParaval.Add(GODOWNCHGS)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNGRIDSRNO)
            alParaval.Add(GRIDDONE)
            alParaval.Add(GRIDTYPE)
            alParaval.Add(OUTBAGS)
            alParaval.Add(OUTWT)
            alParaval.Add(OUTCONES)
            alParaval.Add(SUPPLIERNAME)


            Dim OBJDO As New ClsDeliveryOrder
            OBJDO.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJDO.SAVE()
                TEMPDONO = DTTABLE.Rows(0).Item(0)
                MessageBox.Show("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDONO)
                IntResult = OBJDO.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(TEMPDONO)
            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            'clear()
            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            Call toolnext_Click(sender, e)
            DTDODATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If DTDODATE.Text = "__/__/____" Then
            EP.SetError(DTDODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDODATE.Text) Then
                EP.SetError(DTDODATE, "Date not in Accounting Year")
                bln = False
            End If

            If LIFTINGDATE.Text <> "__/__/____" Then
                If Convert.ToDateTime(DTDODATE.Text).Date > Convert.ToDateTime(LIFTINGDATE.Text).Date Then
                    EP.SetError(LIFTINGDATE, " Please Enter Proper Lifting Date")
                    bln = False
                End If

            End If

        End If

        If cmbtrans.Text.Trim.Length = 0 Then
            EP.SetError(cmbtrans, " Please Fill Transport Name ")
            bln = False
        End If


        If CMBOURGODOWN.Text.Trim.Length = 0 And cmbname.Text.Trim.Length = 0 Then
            EP.SetError(CMBOURGODOWN, " Please Fill Godown / Jobber Name ")
            bln = False
        End If

        If CMBOURGODOWN.Text.Trim.Length > 0 And cmbname.Text.Trim.Length > 0 Then
            EP.SetError(CMBOURGODOWN, " Please Fill Either Godown / Jobber Name, Both are not allowed")
            bln = False
        End If

        If cmbGodown.Text.Trim <> "" Then
            If cmbGodown.Text.Trim = CMBOURGODOWN.Text.Trim Then
                EP.SetError(CMBOURGODOWN, "Godown can not same")
                bln = False
            End If
        End If

        If GRIDDO.RowCount = 0 Then
            EP.SetError(cmbtrans, "Select Entry")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDDO.Rows
            If Val(row.Cells(gBag.Index).Value) = 0 Or Val(row.Cells(Gwt.Index).Value) = 0 Then
                EP.SetError(cmbtrans, "Bags / Wt Cannot be 0")
                bln = False
            End If
            'If ClientName <> "JASHOK" Then
            '    If Val(row.Cells(GCONES.Index).Value) = 0 Then
            '        EP.SetError(cmbtrans, "Cones Cannot be 0")
            '        bln = False
            '    End If
            'End If
        Next


        'checking in stock
        If GRIDDO.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDDO.Rows
                If Val(row.Cells(GGRNNO.Index).Value) > 0 And Val(row.Cells(GGRNSRNO.Index).Value) > 0 And (row.Cells(GGRIDTYPE.Index).Value) <> "" And Val(row.Cells(gBag.Index).Value) > 0 Then

                    Dim BALBAGS As Integer = 0
                    Dim BALCONES As Integer = 0
                    Dim BALWT As Double = 0.0

                    Dim OBJCMN As New ClsCommonMaster
                    Dim dt As DataTable = OBJCMN.search(" ISNULL(BAGS,0) AS BAGS,ISNULL(WT,0) as WT, ISNULL(CONES,0) AS CONES ", "", " STOCKVIEW", " AND GODOWN='" & row.Cells(GGODOWN.Index).Value.ToString & "' AND NO= " & Val(row.Cells(GGRNNO.Index).Value) & " AND SRNO= " & Val(row.Cells(GGRNSRNO.Index).Value) & " AND GRIDTYPE='" & row.Cells(GGRIDTYPE.Index).Value & "' AND Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        BALBAGS = dt.Rows(0).Item("BAGS")
                        BALCONES = dt.Rows(0).Item("CONES")
                        BALWT = dt.Rows(0).Item("WT")
                    End If

                    If EDIT = True Then
                        Dim dt1 As DataTable = OBJCMN.search(" isnull(SUM(DELIVERYORDER_DESC.DO_BAGS),0) AS BAGS,isnull(SUM(DELIVERYORDER_DESC.DO_WT),0) AS WT, isnull(SUM(DELIVERYORDER_DESC.DO_CONES),0) AS CONES ", "", " DELIVERYORDER INNER JOIN DELIVERYORDER_DESC ON DELIVERYORDER.DO_no = DELIVERYORDER_DESC.DO_NO AND DELIVERYORDER.DO_yearid = DELIVERYORDER_DESC.DO_YEARID LEFT OUTER JOIN GODOWNMASTER ON DELIVERYORDER_DESC.DO_GODOWNID = GODOWNMASTER.GODOWN_ID", " AND GODOWNMASTER.GODOWN_NAME='" & row.Cells(GGODOWN.Index).Value.ToString & "' AND DELIVERYORDER_DESC.DO_NO= " & TEMPDONO & " AND DELIVERYORDER_DESC.DO_GRNNO= " & Val(row.Cells(GGRNNO.Index).Value) & " AND DELIVERYORDER_DESC.DO_GRNSRNO = " & Val(row.Cells(GGRNSRNO.Index).Value) & " and DELIVERYORDER_DESC.DO_GRIDTYPE = '" & row.Cells(GGRIDTYPE.Index).Value & "' and DELIVERYORDER_DESC.DO_Yearid = " & YearId)
                        If dt1.Rows.Count > 0 Then
                            BALBAGS = BALBAGS + Val(dt1.Rows(0).Item("BAGS"))
                            BALCONES = BALCONES + Val(dt1.Rows(0).Item("CONES"))
                            BALWT = BALWT + Val(dt1.Rows(0).Item("WT"))
                        End If
                    End If

                    If Val(row.Cells(gBag.Index).Value) > Format(Val(BALBAGS), "0") Then
                        EP.SetError(LBLTOTALBAGS, "Bags Not Present only " & Val(BALBAGS) & " Bags Allowed")
                        GRIDDO.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        bln = False
                    End If

                    If Val(row.Cells(Gwt.Index).Value) > Format(Val(BALWT), "0.000") Then
                        EP.SetError(LBLTOTALWT, "Wt Not Present only " & Val(BALWT) & "Wt Allowed")
                        GRIDDO.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        bln = False
                    End If

                    'If ClientName <> "JASHOK" Then
                    '    If Val(row.Cells(GCONES.Index).Value) > Format(Val(BALCONES), "0") Then
                    '        EP.SetError(LBLTOTALCONES, "Cones Not Present only " & Val(BALCONES) & " Cones Allowed")
                    '        GRIDDO.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    '        bln = False
                    '    End If
                    'End If

                End If
            Next
        End If

        'DONE TEMPORARILY
        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Unable to Update, Entry Locked")
        '    bln = False
        'End If


        Return bln
    End Function

    Sub FILLUPLOAD()

        If GRIDUPLOADDOUBLECLICK = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf GRIDUPLOADDOUBLECLICK = True Then

            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = TXTUPLOADSRNO.Text.Trim
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSOFTCOPY.Image

            GRIDUPLOADDOUBLECLICK = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Clear()
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()

    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJDO As New ClsDeliveryOrder


            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPDONO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJDO.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJDO.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, cmbcode, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT' ", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' AND (LEDGERS.ACC_SUBTYPE = 'WARPER' OR LEDGERS.ACC_SUBTYPE = 'SIZER' OR LEDGERS.ACC_SUBTYPE = 'WEAVER' OR LEDGERS.ACC_SUBTYPE = 'PROCESSOR' or LEDGERS.ACC_SUBTYPE = 'JOBBER')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS' AND (LEDGERS.ACC_SUBTYPE = 'WARPER' OR LEDGERS.ACC_SUBTYPE = 'SIZER' OR LEDGERS.ACC_SUBTYPE = 'WEAVER' OR LEDGERS.ACC_SUBTYPE = 'PROCESSOR' or LEDGERS.ACC_SUBTYPE = 'JOBBER')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, cmbcode, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS")
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

    Sub total()
        Try
            LBLTOTALWT.Text = 0.0
            LBLTOTALBAGS.Text = 0.0
            LBLTOTALCONES.Text = 0.0
            LBLTOTALCHGS.Text = 0.0

            TXTCGSTAMT.Clear()
            TXTCGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTIGSTAMT.Clear()
            TXTIGSTPER.Clear()

            For Each ROW As DataGridViewRow In GRIDDO.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALBAGS.Text = Format(Val(LBLTOTALBAGS.Text) + Val(ROW.Cells(gBag.Index).EditedFormattedValue), "0")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(Gwt.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCONES.Text = Format(Val(LBLTOTALCONES.Text) + Val(ROW.Cells(GCONES.Index).EditedFormattedValue), "0")
                    LBLTOTALCHGS.Text = Format(Val(LBLTOTALCHGS.Text) + Val(ROW.Cells(GCHGS.Index).EditedFormattedValue), "0.00")
                End If
            Next

            'GET GST PERCENT AND CALC AMT
            If Val(TXTTAXABLEAMT.Text.Trim) > 0 And GRIDDO.RowCount > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER", "", "QUALITYMASTER INNER JOIN HSNMASTER ON QUALITY_HSNCODEID = HSN_ID", " AND QUALILTY_NAME = '" & GRIDDO.Rows(0).Cells(GQUALITY.Index).Value & "' AND QUALITY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                    TXTCGSTAMT.Text = Format(Val(DT.Rows(0).Item("CGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                    TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    TXTSGSTAMT.Text = Format(Val(DT.Rows(0).Item("SGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                    TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    TXTIGSTAMT.Text = Format(Val(DT.Rows(0).Item("IGSTPER")) * Val(TXTTAXABLEAMT.Text.Trim) / 100, "0.00")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            If cmbGodown.Text.Trim = "" And ClientName = "SASHWINKUMAR" Then
                MsgBox("Please Select Godown First")
                cmbGodown.Focus()
                Exit Sub
            End If

            If DTDODATE.Text = "__/__/____" Then
                MsgBox("Please Select Date First")
                DTDODATE.Focus()
                Exit Sub
            End If

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Dim DTTABLE As DataTable
            Dim OBJSELECTGRN As New SelectGRNforDO
            OBJSELECTGRN.GODOWN = cmbGodown.Text.Trim
            OBJSELECTGRN.DODATE = Convert.ToDateTime(DTDODATE.Text).Date
            OBJSELECTGRN.ShowDialog()

            DTTABLE = OBJSELECTGRN.DT1

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then
                Dim OBJCMN As New ClsCommon

                For Each dr As DataRow In DTTABLE.Rows
                    TXTNAME.Text = dr("NAME")
                    GRIDDO.Rows.Add(0, dr("QUALITY"), dr("MILLNAME"), Format(Val(dr("BAGS")), "0"), Format(Val(dr("WT")), "0.00"), dr("LOTNO"), dr("COLOR"), Val(dr("CONES")), dr("LRNO"), Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy"), "", dr("TRANSPORT"), dr("GODOWN"), 0, dr("NO"), dr("SRNO"), dr("GRIDTYPE"), 0, 0, 0, 0, dr("NAME"))
                Next
                GRIDDO.FirstDisplayedScrollingRowIndex = GRIDDO.RowCount - 1
                getsrno(GRIDDO)
                If ClientName <> "JASHOK" Then CMDSELECTSTOCK.Enabled = False
            End If
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDDO.RowCount = 0
LINE1:
            TEMPDONO = Val(TXTDONO.Text) - 1
Line2:
            If TEMPDONO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DO_NO ", "", "  DELIVERYORDER ", " AND DO_NO = '" & TEMPDONO & "' AND DELIVERYORDER.DO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    DeliveryOrder_Load(sender, e)
                Else
                    TEMPDONO = Val(TEMPDONO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                EDIT = False
            End If

            If GRIDDO.RowCount = 0 And TEMPDONO > 1 Then
                TXTDONO.Text = TEMPDONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDDO.RowCount = 0
LINE1:
            TEMPDONO = Val(TXTDONO.Text) + 1
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTDONO.Text.Trim
            clear()
            If Val(TXTDONO.Text) - 1 >= TEMPDONO Then
                EDIT = True
                DeliveryOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDDO.RowCount = 0 And TEMPDONO < MAXNO Then
                TXTDONO.Text = TEMPDONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDDO.RowCount = 0
                TEMPDONO = Val(tstxtbillno.Text)
                If TEMPDONO > 0 Then
                    EDIT = True
                    DeliveryOrder_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDDO.CellValidating
        Try
            Dim colNum As Integer = GRIDDO.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Gwt.Index, GCHGS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDDO.CurrentCell.Value = Nothing Then GRIDDO.CurrentCell.Value = "0.00"
                        GRIDDO.CurrentCell.Value = Convert.ToDecimal(GRIDDO.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case gBag.Index, GCONES.Index
                    Dim dDebit As Integer
                    Dim bValid As Boolean = Integer.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDDO.CurrentCell.Value = Nothing Then GRIDDO.CurrentCell.Value = "0"
                        GRIDDO.CurrentCell.Value = Convert.ToInt32(GRIDDO.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case GLIFTING.Index
                    Dim dDebit As Date
                    Dim bValid As Boolean = Date.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDDO.CurrentCell.Value = Nothing Then GRIDDO.CurrentCell.Value = ""
                        'GRIDDO.CurrentCell.Value = Convert.ToDateTime(GRIDDO.Item(colNum, e.RowIndex).Value).Date
                    Else
                        MessageBox.Show("Invalid Lifting Date Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDDO.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDDO.Rows.RemoveAt(GRIDDO.CurrentRow.Index)
                getsrno(GRIDDO)
                total()
            End If

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
            Dim objDODetails As New DeliveryOrderDetails
            objDODetails.MdiParent = MDIMain
            objDODetails.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete, Item Used", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Delete Delivery Order?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTDONO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsDO As New ClsDeliveryOrder
                    ClsDO.alParaval = alParaval
                    IntResult = ClsDO.Delete()
                    MsgBox("Delivery Order Deleted")
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

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmbGodown_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGodown.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.SEARCH = " AND GODOWN_ISOUR = 'False'"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal DONO As Integer)
        'Try
        '    TEMPMSG = MsgBox("Wish to Print Delivery Order?", MsgBoxStyle.YesNo)
        '    If TEMPMSG = vbYes Then
        '        Dim OBJDO As New DODesign
        '        OBJDO.MdiParent = MDIMain
        '        OBJDO.FRMSTRING = "DOREPORT"
        '        OBJDO.WHERECLAUSE = "{DELIVERYORDER.DO_NO}=" & Val(DONO) & " AND {DELIVERYORDER.DO_yearid}=" & YearId
        '        OBJDO.Show()
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPDONO)
            PRINTEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOURGODOWN.Enter
        Try
            If CMBOURGODOWN.Text.Trim = "" Then fillGODOWN(CMBOURGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOURGODOWN.Validating
        Try
            If CMBOURGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBOURGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOURGODOWN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOURGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.SEARCH = " AND GODOWN_ISOUR = 'True'"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then CMBOURGODOWN.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTDODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTDODATE.GotFocus
        DTDODATE.Select(0, 0)
    End Sub

    Private Sub DTDODATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTDODATE.Validating
        Try
            If DTDODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTDODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEWB_Click(sender As Object, e As EventArgs) Handles TOOLEWB.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEEWB()
            PRINTEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENERATEEWB()
        Try
            If ALLOWEWAYBILL = False Then Exit Sub
            If cmbname.Text.Trim = "" Then Exit Sub
            If EDIT = False Then Exit Sub
            Dim FROMCITY, TOCITY As String

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If CMPCITYNAME <> "" Then FROMCITY = CMPCITYNAME Else FROMCITY = ""
            TOCITY = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CITY_NAME,'') AS TOCITY", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID", " AND ACC_CMPANME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TOCITY = DT.Rows(0).Item("TOCITY")


            If FROMCITY = "" Then
                MsgBox("Enter City Name in Company Master", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TOCITY = "" Then
                MsgBox("Enter City Name in Jobber Details", MsgBoxStyle.Critical)
                Exit Sub
            End If


            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTEWBNO.Text.Trim <> "" Then
                MsgBox("E-Way Bill No Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            MsgBox("E-Way Bill will not be Generated if there are special characters like {*,/,""""} in Quality Name ", MsgBoxStyle.Critical)

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim TRANSGSTIN As String = ""

            'CMP ADDRESS DETAILS
            DT = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'NO NEED OF SHIPTO DETAILS HERE
            ''FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            'If TXTDELIVERYAT.Text.Trim <> "" AndAlso cmbname.Text.Trim <> TXTDELIVERYAT.Text.Trim Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_RANGE,'') AS KOTHARIPLACE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & TXTDELIVERYAT.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
            '        MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
            '        Exit Sub
            '    Else
            '        SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
            '        PARTYPINCODE = DT.Rows(0).Item("PINCODE")
            '        PARTYKMS = Val(DT.Rows(0).Item("KMS"))
            '        PARTYADD1 = DT.Rows(0).Item("ADD1")
            '        PARTYADD2 = DT.Rows(0).Item("ADD2")
            '        SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
            '        SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
            '    End If
            'End If


            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If cmbtrans.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                If TRANSGSTIN = "" Then
                    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            'CHECKING COUNTER AND VALIDATE WHETHER EWAY BILL WILL BE ALLOWED OR NOT, FOR EACH EWAY BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EWB)
            If CMPEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'GET USED EWAYCOUNTER
            Dim USEDEWAYCOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EWAYCOUNT", "", "EWAYENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE 1% THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.01), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of EWB Package", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'FOR GENERATING EWAY BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/authenticate?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/authenticate?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""O"","
                j = j & """subSupplyType"":""1"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""CHL"","

                j = j & """docNo"":""" & Val(TXTDONO.Text.Trim) & """" & ","

                j = j & """docDate"":""" & DTDODATE.Text & """" & ","
                j = j & """fromGstin"":""" & CMPGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CmpName & """" & ","
                j = j & """fromAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """fromAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """fromPlace"":""" & FROMCITY & """" & ","
                j = j & """fromPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """toTrdName"":""" & cmbname.Text.Trim & """" & ","
                j = j & """toAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """toAddr2"":""" & PARTYADD2 & """" & ","
                j = j & """toPlace"":""" & cmbname.Text.Trim & "-" & TOCITY & """" & ","
                j = j & """toPincode"":""" & PARTYPINCODE & """" & ","
                j = j & """actToStateCode"":""" & SHIPTOSTATECODE & """" & ","
                j = j & """toStateCode"":""" & PARTYSTATECODE & """" & ","

                j = j & """transactionType"":""4"","
                j = j & """dispatchFromGSTIN"":""" & CMPGSTIN & """" & ","
                j = j & """dispatchFromTradeName"":""" & CmpName & """" & ","
                j = j & """shipToGSTIN"":""" & SHIPTOGSTIN & """" & ","
                j = j & """shipToTradeName"":""" & cmbname.Text.Trim & """" & ","
                j = j & """otherValue"":""0"","


                j = j & """totalValue"":""" & Val(TXTTAXABLEAMT.Text.Trim) & """" & ","
                j = j & """cgstValue"":""" & Val(TXTCGSTAMT.Text.Trim) & """" & ","
                j = j & """sgstValue"":""" & Val(TXTSGSTAMT.Text.Trim) & """" & ","
                j = j & """igstValue"":""" & Val(TXTIGSTAMT.Text.Trim) & """" & ","

                j = j & """cessValue"":""" & "0" & """" & ","
                j = j & """cessNonAdvolValue"":""" & "0" & """" & ","
                j = j & """totInvValue"":""" & Val(TXTTAXABLEAMT.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) & """" & ","
                j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                j = j & """transporterName"":""" & cmbtrans.Text.Trim & """" & ","


                If TXTVEHICLENO.Text.Trim = "" Then
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":"""","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":"""","
                    j = j & """vehicleType"":"""","
                Else
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":""" & "1" & """" & ","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """vehicleType"":""" & "R" & """" & ","
                End If


                j = j & """itemList"":[{"


                'WE NEED TO FETCH SUMMARY OF ITEMS AND HSN TO PASS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT QUALITY_NAME AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, SUM(DO_WT) AS MTRS FROM DELIVERYORDER_DESC INNER JOIN QUALITYMASTER ON QUALITY_id = DO_QUALITYID INNER JOIN HSNMASTER ON HSN_ID = QUALITY_HSNCODEID WHERE DO_NO = " & Val(TEMPDONO) & " and DO_YEARID = " & YearId & " GROUP BY QUALITY_NAME, ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0)", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows
                    If CURRROW > 0 Then j = j & ",{"
                    j = j & """productName"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """productDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """hsnCode"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """quantity"":""" & Val(DTROW("MTRS")) & """" & ","
                    j = j & """qtyUnit"":""" & "MTR" & """" & ","

                    j = j & """cgstRate"":""" & Val(TXTCGSTPER.Text.Trim) & """" & ","
                    j = j & """sgstRate"":""" & Val(TXTSGSTPER.Text.Trim) & """" & ","
                    j = j & """igstRate"":""" & Val(TXTIGSTPER.Text.Trim) & """" & ","

                    j = j & """cessRate"":""" & "0" & """" & ","
                    'THIS CODE WAS IN V1.02
                    'j = j & """cessAdvol"":""" & "0" & """" & ","
                    j = j & """cessNonAdvol"":""" & "0" & """" & ","
                    j = j & """taxableAmount"":""" & Val(TXTTAXABLEAMT.Text.Trim) & """"
                    j = j & " }"
                    CURRROW += 1
                Next

                j = j & " ]}"

                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Generating EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()




            Dim EWBNO As String = ""

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ewayBillNo") + Len("ewayBillNo") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS)
            EWBNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            TXTEWBNO.Text = EWBNO

            'WE NEED TO UPDATE THIS EWBNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE DELIVERYORDER SET DO_EWBNO = '" & TXTEWBNO.Text.Trim & "' WHERE DO_NO = " & Val(TEMPDONO) & " AND DO_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTEWB()
        Try

            If PRINTEWAYBILL = False Then Exit Sub
            If EDIT = False Then Exit Sub
            If TXTEWBNO.Text.Trim = "" Then Exit Sub


            If MsgBox("Print EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim TOKENNO As String = ""
            Dim EWBNO As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TOKENNO, '') AS TOKENNO, ISNULL(EWBNO, '') AS EWBNO ", "", " EWAYENTRY ", " AND EWBNO = '" & TXTEWBNO.Text.Trim & "' And YearId = " & YearId)
            If DT.Rows.Count = 0 Then Exit Sub
            TOKENNO = DT.Rows(0).Item("TOKENNO")
            EWBNO = DT.Rows(0).Item("EWBNO")

            'Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/authenticate?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GetEwayBill&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&authtoken=" & TOKENNO & "&ewbNo=" & EWBNO)


            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)
            REQUEST.Method = "Get"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(REQUESTEDTEXT)

            Dim FURL As New Uri("https://einvapi.charteredinfo.com/aspapi/v1.0/printewb?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/x-www-form-urlencoded"
                REQUEST.ContentLength = buffer.Length

                Dim stream As Stream = REQUEST.GetRequestStream()
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()
                Dim STRREADER As Stream = RESPONSE.GetResponseStream()
                Dim BINREADER As New BinaryReader(STRREADER)
                Dim BFFER As Byte() = BINREADER.ReadBytes(CInt(RESPONSE.ContentLength))
                File.WriteAllBytes(Application.StartupPath & "\EWB_" & TXTEWBNO.Text.Trim & ".pdf", BFFER)
                System.Diagnostics.Process.Start(Application.StartupPath & "\EWB_" & TXTEWBNO.Text.Trim & ".pdf")

                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Printing EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTDONO.Text.Trim) & ",'DO','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LIFTINGDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LIFTINGDATE.GotFocus
        LIFTINGDATE.Select(0, 0)
    End Sub

    Private Sub LIFTINGDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LIFTINGDATE.Validating
        Try
            If LIFTINGDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(LIFTINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeliveryOrder_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            cmbGodown.BackColor = Color.White
            BTNTRANS.Text = "Ware House"
            GTRANSPORT.Visible = False
            GGODOWN.Visible = True
            LBLPARTYNAME.Visible = False
            TXTNAME.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDLIFTING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDLIFTING.Click
        Try
            Dim OBJLIFT As New LiftingDetails
            OBJLIFT.MdiParent = MDIMain
            OBJLIFT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCHGS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCHGS.Click
        Try
            Dim OBJCHGS As New DOGodownChargesDetails
            OBJCHGS.MdiParent = MDIMain
            OBJCHGS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTAXABLEAMT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTAXABLEAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub


End Class